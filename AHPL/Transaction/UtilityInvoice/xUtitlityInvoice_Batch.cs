using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataTier;
using MMS.CustomClasses;
using DevExpress.XtraGrid.Columns;
using System.Transactions;
using System.Threading;

namespace MMS
{
    public partial class xUtitlityInvoice_Batch : DevExpress.XtraEditors.XtraForm
    {
        //AHPL_DBEntities context = new AHPL_DBEntities();
        List<cUtilityInvoiceBatch> utilityInvoiceList = new List<cUtilityInvoiceBatch>();
        List<Invoice_Details> invDetList = new List<Invoice_Details>();
        //List<cUtilityInvoiceBatch> prosdList = new List<cUtilityInvoiceBatch>();
        public xUtitlityInvoice_Batch()
        {
            InitializeComponent();
        }

        private void xUtitlityInvoice_Batch_Load(object sender, EventArgs e)
        {
           
            if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
            
            load_data();

        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    //locaiton 
                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
                    this.locationBindingSource.DataSource = qryLoc;

                    //--

                    // Company 
                    var qryCom = (from c in context.Companies
                                  select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
                    this.companyBindingSource.DataSource = qryCom;

                    // utility 
                    var qryUtility = (from u in context.Utilities
                                      select new { u.UtilityID, u.UtilityName }).ToList();
                    this.lookUpEditUtitliyID.Properties.DataSource = qryUtility;
                    this.lookUpEditUtitliyID.Properties.ValueMember = "UtilityID";
                    this.lookUpEditUtitliyID.Properties.DisplayMember = "UtilityName";

                    //
                    //shop utility reading 
                    var qryUR = (from ur in context.Shops_UtilityReadings
                                 select new { ur.ShopUtilityReadingID, ur.ShopID, ur.MeterName }).ToList();
                    this.shopsUtilityReadingsBindingSource.DataSource = qryUR;

                    // Utility Rates 
                    var qryURate = (from ur in context.Utility_Rates
                                    select new { ur.UtilityRateID, ur.UtilityID, ur.UnitRate }).ToList();
                    this.utilityRatesBindingSource.DataSource = qryURate;

                    // current month / year 
                    this.dateEditMonthYear.DateTime = DateTime.Now.Date;

                    // -- 


                    var qryShop = (from s in context.Shops
                                   select new { s.ShopID, s.ShopNo }).ToList();
                    lookShopID.DataSource = qryShop;
                    lookShopID.DisplayMember = "ShopNo";
                    lookShopID.ValueMember = "ShopID";

                    //---

                    // utility id  missing update in shops 
                    var qryShopUti = (from s in context.Shops_UtilityReadings
                                      where s.UtilityID == 0
                                      select s).ToList();
                    foreach (var qry in qryShopUti)
                    {
                        var qryUtilityID = (from u in context.Utility_Rates
                                            where u.UtilityRateID == qry.UtilityRateID
                                            select u).FirstOrDefault();

                        var qryShopUtilityReadingID = (from ur in context.Shops_UtilityReadings
                                                       where ur.ShopUtilityReadingID == qry.ShopUtilityReadingID
                                                       select ur).FirstOrDefault();
                        qryShopUtilityReadingID.UtilityID = qryUtilityID.UtilityID;


                    }

                    //--


                    //extended customer
                    var qryCust = (from c in context.Global_Customers
                                   select new { c.CustomerID, c.CustomerName }).ToList();
                    repositoryItemLookUpEdit3.DataSource = qryCust;
                    repositoryItemLookUpEdit3.DisplayMember = "CustomerName";
                    repositoryItemLookUpEdit3.ValueMember = "CustomerID";
                    //---

                    // setting invoice date 
                    dateEditInvDate.DateTime = DateTime.Now.Date;

                    utilityInvoiceList = (from u in utilityInvoiceList
                                          orderby u.CompanyID, u.LocationID, u.ShopNo
                                          select u).ToList();


                    this.cUtilityInvoiceBatchBindingSource.DataSource = utilityInvoiceList;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateEditMonthYear_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(this.dateEditMonthYear.Text.ToString()))
            //{
            //    return;
            //}

            //DateTime dtFrom =  new DateTime(1,dateEditMonthYear.DateTime.Month,dateEditMonthYear.DateTime.Year);
            //DateTime dtTo = new DateTime( 

            //}
            try
            {
                if (string.IsNullOrEmpty(this.dateEditMonthYear.Text.ToString()))
                { return; }

                DateTime fromdate;
                DateTime todate;

                fromdate = new DateTime(dateEditMonthYear.DateTime.Year, dateEditMonthYear.DateTime.Month, 1);
                todate = fromdate.AddMonths(1).Date.AddDays(-1);
                dateEditFrom.DateTime = fromdate;
                dateEditTo.DateTime = todate;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            try
            {
                if (e.Column == colEndReading1)
                {
                    using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {
                        cUtilityInvoiceBatch oUtilityBatch = (cUtilityInvoiceBatch)gridView1.GetFocusedRow();
                        //===
                        var qryURs = (from ur in context.Shops_UtilityReadings
                                     select new { ur.ShopUtilityReadingID, ur.ShopID, ur.MeterName }).ToList();
                        this.shopsUtilityReadingsBindingSource.DataSource = qryURs;

                        bool validated = validateField();
                        if (validated == false)
                        {
                            MessageBox.Show( "Validation Failed in the Header Items");
                            //e.Valid = false;
                            load_utilityMeters();
                            return;
                        }

                        else
                        {
                            //e.ErrorText = "";
                            //e.Valid = true;
                            int shopid = 0;
                            int compid = 0;
                            int locid = 0;
                            int month = 0;
                            int year = 0;
                            int utilityRateID = 0;
                            compid = int.Parse(this.lookCompany.EditValue.ToString());
                            locid = int.Parse(this.lookLocation.EditValue.ToString());
                            month = int.Parse(dateEditMonthYear.DateTime.Month.ToString());
                            year = int.Parse(dateEditMonthYear.DateTime.Year.ToString());
                            string metername = oUtilityBatch.MeterName.Trim();
                            utilityRateID = oUtilityBatch.UtilityRateID;
                            shopid = oUtilityBatch.ShopID;

                            //utilityid = int.Parse(this.lookUpEditUtitliyID.EditValue.ToString());

                            var qryFound = (from i in context.Invoices
                                            where i.CompanyID == compid && i.LocationID == locid && i.ProcessYear == year && i.ProcessMonth == month &&
                                            i.UtilityRateID == utilityRateID && i.ShopID == shopid && i.UtilityMeterName == metername
                                            select new { i.InvoiceID }).ToList();
                            if (qryFound.Count > 0)
                            {
                                MessageBox.Show( "Already Shop '" + oUtilityBatch.ShopNo + "' has Invoiced for the selected Meter/Month/Year/Company/Location");
                                IsValid = false;
                                load_utilityMeters();
                            }
                            
                        }
                        //===
                        decimal startreading = 0;
                        decimal endreading = 0;
                        bool res = false;
                        if (oUtilityBatch != null)
                        {
                            res = decimal.TryParse(oUtilityBatch.StartReading1.ToString(), out startreading);
                            if (res == false) { startreading = 0; }

                            res = decimal.TryParse(oUtilityBatch.EndReading1.ToString(), out endreading);
                            if (res == false) { endreading = 0; }

                            decimal unitrate = 0;
                            decimal ratio = 0;
                            // querying unit rate

                            var qryUR = (from ur in context.Shops_UtilityReadings
                                         join u in context.Utility_Rates on ur.UtilityRateID equals u.UtilityRateID
                                         where ur.ShopUtilityReadingID == oUtilityBatch.ShopUtilityReadingID
                                         select new { u.UnitRate, ur.IsRatioApplied, ur.RatioID }).FirstOrDefault();
                            if (qryUR != null)
                            {

                                if (qryUR.IsRatioApplied == true)
                                {
                                    var qryRatio = (from ra in context.Ratios
                                                    where ra.RatioID == qryUR.RatioID
                                                    select new { ra.RatioNo }).FirstOrDefault();
                                    if (qryRatio != null)
                                    {
                                        ratio = qryRatio.RatioNo.Value;
                                    }

                                }


                                res = decimal.TryParse(qryUR.UnitRate.Value.ToString(), out unitrate);
                                if (res == false) { unitrate = 0; }


                            }

                            decimal totalamount = 0;
                            decimal totalconsumption = endreading - startreading;
                            oUtilityBatch.NosUnitConsumed = totalconsumption; // total cosnumption
                            if (ratio != 0)
                            {
                                totalamount = totalconsumption * unitrate * ratio;
                                oUtilityBatch.Amount = totalamount;
                            }
                            else
                            {
                                totalamount = totalconsumption * unitrate;
                                oUtilityBatch.Amount = totalamount;
                            }
                            if (IsValid)
                            {
                                //SaveUtilityInvoice();
                                //load_utilityMeters();
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        bool IsValid=true;
            
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //try
            //{
            //    cUtilityInvoiceBatch oUtilityBatch = (cUtilityInvoiceBatch)gridView1.GetFocusedRow();
                
            //    using (AHPL_DBEntities context = new AHPL_DBEntities())
            //    {
            //        var qryUR = (from ur in context.Shops_UtilityReadings
            //                     select new { ur.ShopUtilityReadingID, ur.ShopID, ur.MeterName }).ToList();
            //        this.shopsUtilityReadingsBindingSource.DataSource = qryUR;

            //        bool validated = validateField();
            //        if (validated == false)
            //        {
            //            e.ErrorText = "Validation Failed in the Header Items";
            //            e.Valid = false;
            //            return;
            //        }

            //        else
            //        {
            //            e.ErrorText = "";
            //            e.Valid = true;
            //            int shopid = 0;
            //            int compid = 0;
            //            int locid = 0;
            //            int month = 0;
            //            int year = 0;
            //            int utilityRateID = 0;
            //            compid = int.Parse(this.lookCompany.EditValue.ToString());
            //            locid = int.Parse(this.lookLocation.EditValue.ToString());
            //            month = int.Parse(dateEditMonthYear.DateTime.Month.ToString());
            //            year = int.Parse(dateEditMonthYear.DateTime.Year.ToString());
            //            utilityRateID = oUtilityBatch.UtilityRateID;
            //            shopid = oUtilityBatch.ShopID;

            //            //utilityid = int.Parse(this.lookUpEditUtitliyID.EditValue.ToString());

            //            var qryFound = (from i in context.Invoices
            //                            where i.CompanyID == compid && i.LocationID == locid && i.ProcessYear == year && i.ProcessMonth == month && i.UtilityRateID == utilityRateID && i.ShopID == shopid
            //                            select new { i.InvoiceID }).ToList();
            //            if (qryFound.Count > 0)
            //            {
            //                e.ErrorText = "Already Shop '" + oUtilityBatch.ShopNo + "' has Invoiced for the selected Meter/Month/Year/Company/Location";
            //                e.Valid = false;

            //            }
            //            else
            //            {
            //                e.ErrorText = "";
            //                e.Valid = true;
                            
            //            }
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void repositoryItemLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            
        }

        private void repositoryItemLookUpEdit1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void repositoryItemLookUpEdit1_Enter(object sender, EventArgs e)
        {
            //cUtilityInvoiceBatch oUtilityBatch = (cUtilityInvoiceBatch)this.gridView1.GetFocusedRow();
            int utilityid = 0;
            if (string.IsNullOrEmpty(this.lookUpEditUtitliyID.Text.ToString()))
            { dxErrorProvider1.SetError(this.lookUpEditUtitliyID, "Invalid Utility"); return; }
            else { dxErrorProvider1.SetError(this.lookUpEditUtitliyID, ""); }
            bool res = int.TryParse(lookUpEditUtitliyID.EditValue.ToString(), out utilityid);
            if (res == false) { utilityid = 0; }
            if (utilityid == 0)
            { dxErrorProvider1.SetError(lookUpEditUtitliyID, "Invalid Utility"); }

            cUtilityInvoiceBatch oUtilityBatch = (cUtilityInvoiceBatch)this.gridView1.GetFocusedRow();
            int shopid = 0;
            shopid = oUtilityBatch.ShopID;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryUR = (from ur in context.Shops_UtilityReadings
                             where ur.ShopID == shopid && ur.UtilityID == utilityid
                             select new { ur.ShopUtilityReadingID, ur.ShopID, ur.MeterName }).ToList();
                shopsUtilityReadingsBindingSource.DataSource = qryUR;
            }

        }

        private void repositoryItemSearchLookUpEdit1_Enter(object sender, EventArgs e)
        {
            cUtilityInvoiceBatch oUtilityBatch = (cUtilityInvoiceBatch)this.cUtilityInvoiceBatchBindingSource.Current;
            if (oUtilityBatch != null)
            {


            }
        }

        private void lookUpEditLocation_EditValueChanged(object sender, EventArgs e)
        {
            //bool res = false;
            //int locid = 0;
            //int compid = 0;

            ////validating locaiton
            //if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
            //{ return; }
            //res = int.TryParse(lookLocation.EditValue.ToString(), out locid);
            //if (res == false) { locid = 0; }
            //if (locid == 0)
            //{
            //    dxErrorProvider1.SetError(this.lookLocation, "Invalid Location");
            //    return;
            //}
            //else { dxErrorProvider1.SetError(this.lookLocation, ""); }
            ///// -- 
            ///// 

            //// validating company 
            //if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
            //{ return; }
            //res = int.TryParse(this.lookCompany.EditValue.ToString(), out compid);
            //if (res == false) { compid = 0; }
            //if (compid == 0)
            //{ dxErrorProvider1.SetError(this.lookCompany, "Invalid Company"); return; }
            //else { dxErrorProvider1.SetError(this.lookCompany, ""); }
            ////
            //using (AHPL_DBEntities context = new AHPL_DBEntities())
            //{
            //    var qryShops = (from c in context.ContractClosures
            //                    join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
            //                    join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
            //                    join com in context.Companies on c.CompanyID equals com.CompanyID
            //                    join loc in context.Locations on c.LocationID equals loc.LocationID
            //                    orderby com.CompanyCode, loc.LocationCode, c.ShopNo
            //                    where c.IsTerminated == false && c.IsPromotion == false && c.IsProcessed == true && c.CompanyID == compid && c.LocationID == locid
            //                    select new { c.ShopNo, c.ShopID, c.ShopName, gcus.CustomerName, com.CompanyCode, loc.LocationCode }).ToList();
            //    repositoryItemSearchLookUpEdit1.DataSource = qryShops;
            //    repositoryItemSearchLookUpEdit1.DisplayMember = "ShopNo";
            //    repositoryItemSearchLookUpEdit1.ValueMember = "ShopID";
            //    repositoryItemSearchLookUpEdit1View.BestFitColumns();
            //}


           // load_utilityMeters();
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm();
            splashScreenManager2.SetWaitFormDescription("Upload Confirming ......"); 
            }
            SaveUtilityInvoice();
            load_utilityMeters();
            if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
            textEdit1.Text = "";
            MessageBox.Show("Record(s) Saved Successfully...", "Utility Batch Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }
        private void SaveUtilityInvoice(){
    
        AHPL_DBEntities context = new AHPL_DBEntities();


            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                bool validated = validateField();
                if (validated == false)
                { return; }

                if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Processing Utility Invoice"); }

                using (TransactionScope trs = new TransactionScope())
                {

                    cUtilityInvoiceBatchBindingSource.EndEdit();
                    using (context)
                    {

                        var qryList = (from u in utilityInvoiceList
                                       where u.Amount != 0
                                       select u).ToList();

                        foreach (var qry in qryList)
                        {
                            //Console.WriteLine(qry.ShopName);
                            Invoice oInv = new Invoice();
                            oInv.ContractClosureID = qry.ContractClauseID;
                            oInv.InvoiceDate = dateEditInvDate.DateTime;
                            oInv.SAP_PstnDateInDoc = oInv.InvoiceDate;
                            oInv.InvoiceNo = "";
                            oInv.InvoiceTypeID = 2; // utility invoice
                            oInv.SubInvTypeID = 3; // // Invoice
                            oInv.FooterText1 = this.txtInvoiceFooter.Text.ToString();
                            oInv.UtilityName = lookUpEditUtitliyID.Text.ToString(); // Utility Name
                            oInv.ShopUtilityReadingID = qry.ShopUtilityReadingID;
                            //Ratio 
                            
                            var qryRatio = (from s in context.Shops_UtilityReadings
                                            join r in context.Ratios on s.RatioID equals r.RatioID
                                            where s.ShopUtilityReadingID == oInv.ShopUtilityReadingID
                                            select new { r.RatioNo }).FirstOrDefault();
                            if (qryRatio != null)
                            {
                                if (qryRatio.RatioNo.HasValue)
                                {
                                    oInv.Ratio = qryRatio.RatioNo.Value;
                                }
                            }
                            //--

                            oInv.UtilityMeterName = context.Shops_UtilityReadings.Where(x => x.ShopUtilityReadingID == qry.ShopUtilityReadingID).FirstOrDefault().MeterName;
                            oInv.CompanyID = qry.CompanyID;
                            oInv.CompanyCode = context.Companies.Where(x => x.CompanyID == qry.CompanyID).FirstOrDefault().CompanyCode;
                            oInv.LocationID = qry.LocationID;
                            oInv.LocationCode = context.Locations.Where(x => x.LocationID == qry.LocationID).FirstOrDefault().LocationCode;
                            oInv.LevelID = qry.FloorLevelID;
                            oInv.LevelName = context.Floor_Levels.Where(x => x.LevelID == qry.FloorLevelID).FirstOrDefault().LevelName;
                            oInv.ExtendedCustomerID = qry.ExtendedCustomerID; // customerid

                            // cusomter 
                            var qryCust = (from ec in context.Extended_Customers
                                           join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                           where ec.ExtendedCustomerID == qry.ExtendedCustomerID
                                           select new { gc.IsTaxCustomer, gc.CustomerID, gc.CustomerName, CustomerAddress = gc.CompanyAddress, ec.IsTaxApplicable }).FirstOrDefault();


                            //
                            oInv.CustomerName = qryCust.CustomerName;
                            oInv.CustomerAddress = qryCust.CustomerAddress;
                            oInv.CustomerAddress2 = oInv.CustomerAddress;
                            oInv.CustomerID = qry.CustomerID;
                            oInv.IsTaxCustomer = qryCust.IsTaxCustomer;
                            oInv.ShopID = qry.ShopID;
                            oInv.ShopNo = qry.ShopNo;
                            oInv.ShopName = qry.ShopName;
                            //oInv.UtilityUnitRate = qry.UnitRate;
                            oInv.UtilityID = qry.UtilityID;
                            oInv.UtilityRateID = qry.UtilityRateID;

                           

                            var qryUnitRate = (from ur in context.Utility_Rates
                                               where ur.UtilityRateID == qry.UtilityRateID
                                               select ur).FirstOrDefault();
                            oInv.UtilityUnitRate = qryUnitRate.UnitRate.Value;
                            oInv.RentPerMonth = qry.Amount;
                            oInv.NosUnitsConsumed1 = qry.NosUnitConsumed;
                            oInv.DateFrom = dateEditFrom.DateTime;
                            oInv.DateTo = dateEditTo.DateTime;
                            oInv.ProcessYear = dateEditMonthYear.DateTime.Year;
                            oInv.ProcessMonth = dateEditMonthYear.DateTime.Month;
                            oInv.NosDay = dateEditTo.DateTime.Subtract(dateEditFrom.DateTime).Days;
                            oInv.StartReading = qry.StartReading1;
                            oInv.EndReading = Decimal.Parse(qry.EndReading1.ToString());
                            // updating shop's last reading
                            //AHPL.CustomClasses.cCommon_Functions.updateShopLastReading(qry.ShopUtilityReadingID,qry.EndReading1);
                            //--
                            oInv.Reset = qry.IsReset;
                            oInv.StartReading2 = qry.StartReading2;
                            oInv.EndReading2 = qry.EndReading2;


                            oInv.ModifiedDate = DateTime.Now;
                            oInv.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                            oInv.CreatedDate = DateTime.Now;

                            // check weather tax applicabable for the utility


                            bool istaxAppllicable = qryCust.IsTaxApplicable;
                            oInv.IsTaxApplicable = istaxAppllicable;

                            ////bool istaxAppllicable = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicable(qry.ContractClauseID);

                            bool istaxApplicableforUtility = MMS.CustomClasses.cCommon_Functions.IsOtherTaxApplicableForUtility(qry.ShopUtilityReadingID);
                            oInv.IsUtilityTaxApplicable = istaxApplicableforUtility;
                            bool ismandatoryTaxApplicable = MMS.CustomClasses.cCommon_Functions.IsMandatoryTaxApplicableForUtility(qry.ShopUtilityReadingID);
                            invDetList.Clear();

                           
                            cMandatoryTax mandatoryTax = cTaxCalculations.getAmountWithMandatoryTax(qry.Amount);
                            decimal totalWithMandatoryTax = mandatoryTax.TotalWithMandatoryTax;

                            oInv.MandatoryTaxCode = mandatoryTax.MandatoryTaxCode;
                            oInv.MandatoryTaxID = mandatoryTax.MandatoryTaxID;
                            oInv.MandatoryTaxRateID = mandatoryTax.MandatoryTaxRateID;
                           
                            //if (oInv.IsTaxCustomer == true)//// comment and add below if condition and else, there were no else command in previous.. 25July2016
                            if (istaxAppllicable)
                            {
                                if (ismandatoryTaxApplicable == true)
                                {
                                    oInv.TotalWithMandatoryTax = totalWithMandatoryTax;
                                }
                                else
                                {
                                    oInv.TotalWithMandatoryTax = qry.Amount;
                                }

                                oInv.MandatoryTaxAmount = mandatoryTax.MandatoryTaxAmount;////ro..25July..for add MandatoryTaxAmount for utility invoicess
                            }
                            else 
                            {
                                oInv.MandatoryTaxAmount = 0;////ro..25July..for add MandatoryTaxAmount for utility invoicess
                                oInv.TotalWithMandatoryTax = qry.Amount;////23Nove2016..for add 'TotalWithMandatoryTax' field,because individual rep displaying 0 values
                            }

                            // Mandatory Tax 
                            Invoice_Details oInvDet = new Invoice_Details();
                            oInvDet.TaxID = mandatoryTax.MandatoryTaxID;
                            oInvDet.TaxCode = mandatoryTax.MandatoryTaxCode;
                            oInvDet.TaxRate = mandatoryTax.MandatoryTaxRate;
                            oInvDet.TaxRateID = mandatoryTax.MandatoryTaxRateID;
                            if (ismandatoryTaxApplicable == true)
                            {
                                if (istaxAppllicable == true)
                                {
                                    oInvDet.Amount = mandatoryTax.MandatoryTaxAmount;
                                    oInvDet.IsPrint = false;
                                }
                                else
                                {
                                    oInvDet.Amount = 0;
                                    oInvDet.IsPrint = false;
                                }
                            }
                            else
                            {
                                oInvDet.Amount = 0;
                                oInvDet.IsPrint = false;
                            }
                            invDetList.Add(oInvDet);
                            oInv.Invoice_Details.Add(oInvDet);
                            //--

                            // Other Tax 
                            List<cOtherTax> otherTaxList = new List<cOtherTax>();
                            if (ismandatoryTaxApplicable == true)
                            {
                                otherTaxList = cTaxCalculations.getOtherTax(totalWithMandatoryTax);
                            }
                            else
                            {
                                //if (istaxApplicableforUtility == true)
                                {
                                    otherTaxList = cTaxCalculations.getOtherTax(qry.Amount);
                                }
                            }

                            decimal otherTax = otherTaxList.Sum(x => x.TaxAmount);
                            if (istaxApplicableforUtility == true)
                            {
                                if (istaxAppllicable == true)
                                {
                                    oInv.OtherTax = otherTax;
                                }
                            }

                            foreach (var qryT in otherTaxList)
                            {
                                oInvDet = new Invoice_Details();
                                oInvDet.TaxID = qryT.TaxID;
                                oInvDet.TaxCode = qryT.TaxCode;
                                oInvDet.TaxRate = qryT.TaxRate;
                                oInvDet.TaxRateID = qryT.TaxRateID;
                                if (istaxApplicableforUtility == true)
                                {
                                    if (istaxAppllicable == true)
                                    {

                                        oInvDet.Amount = qryT.TaxAmount;
                                        oInvDet.IsPrint = true;
                                    }
                                    else
                                    {
                                        oInvDet.Amount = 0;
                                        oInvDet.IsPrint = false;
                                    }
                                }
                                else
                                {
                                    oInvDet.Amount = 0;
                                    oInvDet.IsPrint = false;
                                }
                                invDetList.Add(oInvDet);
                                oInv.Invoice_Details.Add(oInvDet);
                            }

                            //--

                            // other tax codes 

                            oInv.OtherTaxCodes = MMS.CustomClasses.cCommon_Functions.getOtherTaxCodes();
                            // -- 
                            //total tax 
                            decimal totalTax = oInv.Invoice_Details.Sum(x => x.Amount);
                            oInv.TotalRentPerMonth = oInv.RentPerMonth + totalTax;
                            //--
                           
                            // record creation time
                            oInv.CreatedBy = cCommon_Functions.LoggedUserID;
                            oInv.CreatedDate = DateTime.Now;


                            oInv.TaxRegNo = MMS.CustomClasses.cCommon_Functions.getTaxRegNo(oInv.ExtendedCustomerID, istaxAppllicable, istaxApplicableforUtility);


                            //Updating SAP fields 
                            int utilityid = int.Parse(lookUpEditUtitliyID.EditValue.ToString());
                            oInv.SAP_Assignment = lookUpEditUtitliyID.Text.ToString().ToUpper();
                            oInv.SAP_Text = lookUpEditUtitliyID.Text.ToString().ToUpper() + "_" + oInv.ShopNo.ToString().Trim() + "_" + MMS.CustomClasses.cCommon_Functions.getMonthAbbrName(dateEditMonthYear.DateTime.Month) + "_" + dateEditMonthYear.DateTime.Year.ToString();
                            oInv.SAP_RefKey1 = oInv.ShopNo;
                            oInv.SAP_RefKey2 = oInv.ShopName;
                            oInv.SAP_RefKey3 = "FIXED";
                            var qryInvPrefix = (from up in context.Utilities
                                                where up.UtilityID == utilityid
                                                select new { up.InvoicePrefix }).FirstOrDefault();

                            oInv.SAP_DocHeaderText = qryInvPrefix.InvoicePrefix + oInv.ShopNo + dateEditMonthYear.DateTime.Month.ToString() + dateEditMonthYear.DateTime.Year.ToString();
                            var qryDT = (from dt in context.SAP_DocTypes
                                         where dt.CompanyID == oInv.CompanyID && dt.InvoiceTypeID == 2 && dt.DocID == utilityid
                                         select dt).FirstOrDefault();
                            if (qryDT != null)
                            {
                                oInv.SAP_DocType = qryDT.DOCTYPE;

                            }
                            //--


                            context.Invoices.AddObject(oInv);
                            splashScreenManager2.SetWaitFormDescription(oInv.InvoiceNo);
                            ////}

                            

                        }

           
                        int succ = context.SaveChanges();

                        if (succ > 0)
                        {
                            if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                            
                            trs.Complete();
                            

                        }


                    }
                }

               
                    
                
                
            }
            catch (Exception ex)
            {
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool validateField()
        {
            bool validated = false;
            // validating company
            if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
            { dxErrorProvider1.SetError(this.lookCompany, "Invalid Company"); return false; }
            else { dxErrorProvider1.SetError(this.lookCompany, ""); validated = true; }

            // validating location
            if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
            { dxErrorProvider1.SetError(this.lookLocation, "Invalid Location"); return false; }
            else { dxErrorProvider1.SetError(this.lookLocation, ""); validated = true; }

            // validating utiliy 
            if (string.IsNullOrEmpty(this.lookUpEditUtitliyID.Text.ToString()))
            { dxErrorProvider1.SetError(this.lookUpEditUtitliyID, "Invalid Utility"); return false; }
            else { dxErrorProvider1.SetError(this.lookUpEditUtitliyID, ""); validated = true; }

            //validating Month/Year 
            if (string.IsNullOrEmpty(this.dateEditMonthYear.Text.ToString()))
            { dxErrorProvider1.SetError(this.dateEditMonthYear, "Invalid Month/Year"); return false; }
            else { dxErrorProvider1.SetError(this.dateEditMonthYear, ""); validated = true; }

            //validating date from
            if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
            { dxErrorProvider1.SetError(this.dateEditFrom, "Invalid Date From"); return false; }
            else { dxErrorProvider1.SetError(this.dateEditFrom, ""); validated = true; }

            //validatein date to 
            if (string.IsNullOrEmpty(this.dateEditTo.Text.ToString()))
            { dxErrorProvider1.SetError(this.dateEditTo, "Invalid Date To"); return false; }
            else { dxErrorProvider1.SetError(this.dateEditTo, ""); validated = true; }

            // validating invoice date 
            if (string.IsNullOrEmpty(this.dateEditInvDate.Text.ToString()))
            { dxErrorProvider1.SetError(this.dateEditInvDate, "Invalid Invoice Date"); return false; }
            else { dxErrorProvider1.SetError(this.dateEditInvDate, ""); validated = true; }

            // validating batch Lablel
            if (string.IsNullOrEmpty(this.textEdit1.Text.ToString()))
            { dxErrorProvider1.SetError(this.textEdit1, "Invalid Batch Name"); return false; }
            else { dxErrorProvider1.SetError(this.textEdit1, ""); validated = true; }








            return validated;

        }

        private void dateEditTo_EditValueChanged(object sender, EventArgs e)
        {
            load_utilityMeters();
        }

        private void lookUpEditUtitliyID_EditValueChanged(object sender, EventArgs e)
        {

    
        }

        private void load_utilityMeters()
        {
          
            if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
            
            try
            {


                if (string.IsNullOrEmpty(this.lookUpEditUtitliyID.Text.ToString()))
                { return; }

                bool res = false;
                int utilityid = 0; int compid = 0; int locid = 0;
                //utility
                res = int.TryParse(this.lookUpEditUtitliyID.EditValue.ToString(), out utilityid);
                if (res == false) { utilityid = 0; return; }

                //company 
                res = int.TryParse(lookCompany.EditValue.ToString(), out compid);
                if (res == false) { compid = 0; return; }

                // location
                res = int.TryParse(lookLocation.EditValue.ToString(), out locid);
                if (res == false) { locid = 0; return; }

                utilityInvoiceList.Clear();

                if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); }
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    

                    //get processed invoices by ravindra 07-02-2020

                    int month = dateEditMonthYear.DateTime.Month;
                    int year = dateEditMonthYear.DateTime.Year;
                    int invtypeId = int.Parse(lookUpEditUtitliyID.EditValue.ToString());
                    
                    List<Invoice> ProcessInvList = new List<Invoice>();
                    var qryInvProcessed = (from i in context.Invoices
                                           where i.IsProcessed == true && i.ProcessMonth == month && i.ProcessYear == year && i.UtilityID == invtypeId &&
                                                  i.CompanyID == compid && i.LocationID == locid
                                           select new { i.ShopID, i.UtilityMeterName, i.ShopUtilityReadingID }).ToList();

                        
                    
                            var qryShops = (from s in context.Shops
                                            join d in context.Shops_UtilityReadings on s.ShopID equals d.ShopID
                                            join ec in context.Extended_Customers on s.CustomerID equals ec.ExtendedCustomerID
                                            join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                            join ud in context.Utility_Rates on d.UtilityRateID equals ud.UtilityRateID
                                            where d.UtilityID == utilityid && s.CustomerID > 0 && s.CompanyID == compid && s.LocationID == locid      
                                            select new { ExtendedCustomerID = s.CustomerID, d.UtilityID, s.CompanyID, s.LocationID, s.ShopID, 
                                                s.ShopNo, s.ShopName,d.LastReading, d.MeterName, gc.CustomerID, ud.UnitRate, ud.UtilityRateID,
                                                d.ShopUtilityReadingID, s.LevelID }).ToList();

                         
                          //ignore already processed utility invoices  by Ravindra 13-06-2020 
                            var result = qryShops.Where(p => !qryInvProcessed.Any(p2 => p2.ShopUtilityReadingID == p.ShopUtilityReadingID));

                    #region comment

                    ////var qryShops = (from s in context.Shops
                    ////                join d in context.Shops_UtilityReadings on s.ShopID equals d.ShopID
                    ////                join ec in context.Extended_Customers on s.CustomerID equals ec.ExtendedCustomerID
                    ////                join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                    ////                join ud in context.Utility_Rates on d.UtilityRateID equals ud.UtilityRateID
                    ////                join i in context.Invoices.Where(w => w.ProcessYear.Equals(dateEditMonthYear.DateTime.Year)
                    ////                    & w.ProcessMonth.Equals(dateEditMonthYear.DateTime.Month) & w.UtilityID.Equals(utilityid)
                    ////                    & w.CompanyID.Equals(compid) & w.LocationID.Equals(locid)) on s.ShopID equals i.ShopID into ig
                    ////                from sig in ig.DefaultIfEmpty()
                    ////                where d.UtilityID == utilityid && s.CustomerID > 0 && s.CompanyID == compid && s.LocationID == locid
                    ////                select new
                    ////                {
                    ////                    ExtendedCustomerID = s.CustomerID,
                    ////                    d.UtilityID,
                    ////                    s.CompanyID,
                    ////                    s.LocationID,
                    ////                    s.ShopID,
                    ////                    s.ShopNo,
                    ////                    s.ShopName,
                    ////                    d.LastReading,
                    ////                    d.MeterName,
                    ////                    gc.CustomerID,
                    ////                    ud.UnitRate,
                    ////                    ud.UtilityRateID,
                    ////                    d.ShopUtilityReadingID,
                    ////                    s.LevelID
                    ////                    ,
                    ////                    RentPerMonth = sig == null ? 0 : sig.RentPerMonth,
                    ////                    EndReading = sig == null ? 0 : sig.EndReading
                    ////                }).ToList();
                    #endregion
                            foreach (var qry in result)
                    {
                        cUtilityInvoiceBatch utilityBatchObject = new cUtilityInvoiceBatch();
                        utilityBatchObject.ShopID = qry.ShopID;
                        utilityBatchObject.ShopName = qry.ShopName;
                        utilityBatchObject.ShopNo = qry.ShopNo;
                        utilityBatchObject.ShopUtilityReadingID = qry.ShopUtilityReadingID;
                        utilityBatchObject.StartReading1 = qry.LastReading;
                        utilityBatchObject.UtilityRateID = qry.UtilityRateID;
                        utilityBatchObject.ProcessMonth = dateEditMonthYear.DateTime.Month;
                        utilityBatchObject.ProcessYear = dateEditMonthYear.DateTime.Year;
                        utilityBatchObject.CompanyID = qry.CompanyID;
                        utilityBatchObject.LocationID = qry.LocationID;
                        utilityBatchObject.FloorLevelID = qry.LevelID;
                        utilityBatchObject.UtilityID = qry.UtilityID;
                        utilityBatchObject.CustomerID = qry.CustomerID;
                        utilityBatchObject.ExtendedCustomerID = qry.ExtendedCustomerID.Value;
                        utilityBatchObject.DateFrom = dateEditFrom.DateTime;
                        utilityBatchObject.DateTo = dateEditTo.DateTime;
                        utilityBatchObject.ContractClauseID = 0;
                        utilityBatchObject.MeterName = qry.MeterName;
                        ////utilityBatchObject.Amount = qry.RentPerMonth;
                        ////utilityBatchObject.EndReading1 = qry.EndReading;

                        utilityInvoiceList.Add(utilityBatchObject);
                        splashScreenManager2.SetWaitFormDescription(qry.ShopNo);

                       
                        
                    }
 
                     this.cUtilityInvoiceBatchGridControl.RefreshDataSource();

                }

                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }

            }

            catch (Exception ex)
            {
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
        {
           // load_utilityMeters();

            //// Location..roshan..06oct2014
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                int comid = 0;
                bool res = false;
                res = int.TryParse(lookCompany.EditValue.ToString(), out comid);
                if (res.Equals(true))
                {
                    var qryLoc = (from c in context.Companies
                                  join l in context.Locations on c.LocationID equals l.LocationID
                                  where c.CompanyID == comid
                                  select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();

                    this.locationBindingSource.DataSource = qryLoc;
                }
            }
        }

        private void cUtilityInvoiceBatchGridControl_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
             
        }

        private void cUtilityInvoiceBatchGridControl_EditorKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }
    }


}