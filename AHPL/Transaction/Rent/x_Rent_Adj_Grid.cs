using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTier;

namespace MMS.Transaction.Rent
{
    public partial class x_Rent_Adj_Grid : Form
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<Invoice_Details> invDetList = new List<Invoice_Details>();
        List<cGen_Rent_Invoice> cGenList = new List<cGen_Rent_Invoice>();
        
        private Transaction.Rent.xRentVariation rentvariation;

        public x_Rent_Adj_Grid()
        {
            InitializeComponent();
            load_data();
        }

        private void load_data()
        {
            if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Connecting......"); }
            if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
            
            try
            {
                //Location
                var qryLoc = (from l in context.Locations
                              select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
                this.locationBindingSource.DataSource = qryLoc;

                //company
                var qryComp = (from comp in context.Companies
                               select new { comp.CompanyID, comp.CompanyCode, comp.CompanyName });
                this.companyBindingSource.DataSource = qryComp;

                // tax 
                var qrytax = (from t in context.Taxes
                              select new { t.TaxID, t.TaxCode }).ToList();
                this.taxBindingSource.DataSource = qrytax;

                //tax rate 
                var qrytaxrate = (from tr in context.TaxRates
                                  select new { tr.TaxRateID, tr.TaxRate1 }).ToList();
                this.taxRateBindingSource.DataSource = qrytaxrate;

               
            
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void lookLocation_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
            {
                GetShopDetails();
            }
            //else
            //{ 
               
            //}
        }

        private void GetShopDetails()
        {

            if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Connecting......"); }
            //bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
            if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
            
            bool res = false;
            int compid = 0; int locid = 0;
            //company 
            res = int.TryParse(lookCompany.EditValue.ToString(), out compid);
            if (res == false) { compid = 0; return; }

            // location
            res = int.TryParse(lookLocation.EditValue.ToString(), out locid);
            if (res == false) { locid = 0; return; }

            var qryShops = (from s in context.Shops 
                            join ec in context.Extended_Customers on s.CustomerID equals ec.ExtendedCustomerID
                            join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID 
                            where s.CompanyID == compid && s.LocationID == locid 
                            select new
                            {
                                ExtendedCustomerID = s.CustomerID,          
                                s.CompanyID,
                                s.LocationID,
                                s.ShopID,
                                s.ShopNo,
                                s.ShopName,
                                gc.CustomerName,
                                gc.CustomerID
                            }).ToList();


            foreach (var qry in qryShops)
            {
                cGen_Rent_Invoice invoiceobject = new cGen_Rent_Invoice();
                invoiceobject.ShopID = qry.ShopID;
                invoiceobject.ShopName = qry.ShopName;
                invoiceobject.ShopNo = qry.ShopNo;
                invoiceobject.CustomerName = qry.CustomerName;
                invoiceobject.TotalRentPerMonth = 0;
                invoiceobject.SCPerMonth = 0;
                invoiceobject.CustomerID = qry.CustomerID;
                //invoiceobject.OtherTax = 0;
                //invoiceobject.MandatoryTaxAmount = 0;
                cGenList.Add(invoiceobject);

            }

            this.cInvoicesBindigSource.DataSource = cGenList;
            this.gvallcreditnotes.RefreshDataSource();

        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                int comid = 0;
                bool res = false;
                if (!string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                {
                    res = int.TryParse(lookCompany.EditValue.ToString(), out comid);
                }
                else
                {
                    res = false;
                }
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            
           this.Close();
        }

        private void chkselect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkselect.Checked == true)
            {
                chkselect.Text = "Unselect All";
                foreach (var qry in cGenList)
                {
                    qry.Confirm = true;
                }
                gvallcreditnotes.RefreshDataSource();
            }
            else
            {
                chkselect.Text = "Select All";
                foreach (var qry in cGenList)
                {
                    qry.Confirm = false;
                }
                gvallcreditnotes.RefreshDataSource();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
                try
            {
                if (e.Column == service_charge|| e.Column == Adjustment_amount)
                {

                   
                    using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {
                        
                        cGen_Rent_Invoice oInvoicebatch = (cGen_Rent_Invoice)gridView1.GetFocusedRow();
                        decimal CurentInvoiceValue = 0;
                        decimal  ServiceCharge = 0;
                        int contractclouserid = 0;

                        //get contactclouserIDby invoiceno

                        contractclouserid = MMS.CustomClasses.cCommon_Functions.getContractClauseIDbyShopID(oInvoicebatch.ShopID);

                        //--invoice details

                        
                            var qryContractTax = (from t in context.Taxes
                                                  join tr in context.TaxRates on t.TaxID equals tr.TaxID
                                                  where tr.IsActive == true
                                                  select new { t.TaxID, tr.TaxRateID }).ToList();

                            if (invDetList.Count > 0) { invDetList.Clear(); }

                            foreach (var qry in qryContractTax)
                            {
                                Invoice_Details oInvDet = new Invoice_Details();
                                oInvDet.TaxID = qry.TaxID;
                                oInvDet.TaxRateID = qry.TaxRateID;
                                oInvDet.Amount = 0;
                                invDetList.Add(oInvDet);
                            }
                        //--


                        bool res = false;

                        if (oInvoicebatch != null)
                        {
                            res = decimal.TryParse(oInvoicebatch.TotalRentPerMonth.ToString(), out CurentInvoiceValue);
                            if (res == false) { CurentInvoiceValue = 0; }

                            res = decimal.TryParse(oInvoicebatch.SCPerMonth.ToString(), out ServiceCharge);
                            if (res == false) { ServiceCharge = 0; }


                            //check Is Tax applicable
                            
                            bool IsTaxCalApply = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicable(contractclouserid);
                            
                            
                            //get tax latest rates
                            //NBT
                            cMandatoryTax mandatoryTax = new cMandatoryTax();
                            mandatoryTax = cTaxCalculations.getAmountWithMandatoryTax(CurentInvoiceValue + ServiceCharge);
                            decimal totalwithmandetorytax = mandatoryTax.TotalWithMandatoryTax;
                           

                            if (IsTaxCalApply == true)
                            {
                                
                                oInvoicebatch.MandatoryTaxAmount = Math.Round((mandatoryTax.MandatoryTaxAmount), 4);
                            }
                            else {
                                oInvoicebatch.SCPerMonth = ServiceCharge;
                                oInvoicebatch.MandatoryTaxAmount = 0; }

                            //VAT
                            List<cOtherTax> otherTaxList = cTaxCalculations.getOtherTax(mandatoryTax.TotalWithMandatoryTax);

                            // tax details
                            

                            foreach (var qryOT in otherTaxList)
                            {
                                //oInvDet = new Invoice_Details();
                                if (IsTaxCalApply == false)
                                { oInvoicebatch.OtherTax = 0; }
                                else 
                                {
                                    
                                    oInvoicebatch.OtherTax = Math.Round((qryOT.TaxAmount), 4); 
                                } 

                            }

                            if (IsTaxCalApply == true)
                            {
                                decimal othertax = oInvoicebatch.OtherTax;
                                decimal totalcreditvalue = othertax + mandatoryTax.TotalWithMandatoryTax;
                                oInvoicebatch.TotalCreditValue = Math.Round((totalcreditvalue), 4);
                            }
                            else
                            {
                                oInvoicebatch.TotalCreditValue = Math.Round((ServiceCharge), 4);
                            }

                        
                        }


                    }
                     
                
                
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            load_data();
            txtInvoiceFooter.Text = "";
            dateEditFrom.EditValue = null;
            dateEditTo.EditValue = null;
            adjDate.EditValue = null;
            this.lookCompany.EditValue = null;
            this.lookLocation.EditValue = null;
            for (int i = 0; i < gridView1.RowCount; )
            { gridView1.DeleteRow(i); }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveNewAdjustmentInvoice();
           
        }

        private void SaveNewAdjustmentInvoice()
        {

            try
            {
              
                if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); 
                    splashScreenManager2.SetWaitFormDescription("Loading......"); }
                //chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
               if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);
                if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.lookCompany, "Invalid Company");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.lookCompany, "");
                }
                if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.lookLocation, "Invalid Location");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.lookLocation, "");
                }
                if (string.IsNullOrEmpty(this.adjDate.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.adjDate, "Invalid Date");
                    return;
                }
                else
                { dxErrorProvider1.SetError(this.adjDate, ""); }

                if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.dateEditFrom, "Invalid Date");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.dateEditFrom, "");
                }
                if (string.IsNullOrEmpty(this.dateEditTo.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.dateEditTo, "Invalid Date");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.dateEditTo, "");
                }

                if (string.IsNullOrEmpty(this.txtInvoiceFooter.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.txtInvoiceFooter, "Invalid footer Note");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.txtInvoiceFooter, "");
                }

               

                var qryContracts = (from c in cGenList
                                    where c.TotalCreditValue > 0
                                    select c).ToList();

                if (qryContracts.Count == 0)
                {
                    MessageBox.Show("No invoice(s) selected");
                    return;
                }

                int contclauseid = 0;
                decimal amount = 0;
                foreach (var row in qryContracts)
                {
                    Invoice oInvoice = new Invoice();
                    contclauseid = MMS.CustomClasses.cCommon_Functions.getContractClauseIDbyShopID(row.ShopID);
                    oInvoice.ContractClosureID = contclauseid;
                    oInvoice.ShopID = MMS.CustomClasses.cCommon_Functions.getShopID(contclauseid);
                    oInvoice.ShopName = MMS.CustomClasses.cCommon_Functions.getShopName(contclauseid);
                    oInvoice.ShopNo = MMS.CustomClasses.cCommon_Functions.getShopNo(contclauseid);
                    oInvoice.CustomerID = int.Parse(row.CustomerID.ToString());
                    oInvoice.CustomerName = row.CustomerName.ToString();
                    bool IsTaxCalApply = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicable(contclauseid);
                    oInvoice.IsTaxApplicable = IsTaxCalApply;

                    //// var qryExtendedCustomerID 
                    var qryExCust = (from c in context.ContractClosures
                                     where c.ContractClosureID == contclauseid
                                     select new { c.ExtendedCustomerID }).FirstOrDefault();
                    int extendedCustID = qryExCust.ExtendedCustomerID;

                    //// 
                    oInvoice.TaxRegNo = MMS.CustomClasses.cCommon_Functions.getTaxRegNo(extendedCustID, true);
                    oInvoice.IsTaxCustomer = MMS.CustomClasses.cCommon_Functions.IsTaxCustomer(oInvoice.CustomerID);
                 

                    var qryCustAdd = (from c in context.Global_Customers
                                      where c.CustomerID == oInvoice.CustomerID
                                      select new { c.CompanyAddress }).FirstOrDefault();
                    if (qryCustAdd != null)
                    {
                        oInvoice.CustomerAddress = qryCustAdd.CompanyAddress;
                    }
                    var qryCont = (from c in context.ContractClosures
                                   where c.ContractClosureID == oInvoice.ContractClosureID
                                   select new { c.ExtendedCustomerID, c.LevelID, c.ShopID, c.ContractClosureID }).FirstOrDefault();
                    if (qryCont != null)
                    {
                        oInvoice.ExtendedCustomerID = qryCont.ExtendedCustomerID;
                        oInvoice.LevelID = qryCont.LevelID;
                        oInvoice.LevelName = context.Floor_Levels.Where(x => x.LevelID == qryCont.LevelID).FirstOrDefault().LevelName;

                        oInvoice.ShopID = qryCont.ShopID;

                        ////getting active rent scheme from Contract_RentScheme table 

                        var contclosureid = cActiveRentScheme.getDefaultOrLastRate(adjDate.DateTime, qryCont.ContractClosureID, dateEditFrom.DateTime, dateEditTo.DateTime);
                        oInvoice.ContractClosureID = contclosureid.ContractClosureID;
                        oInvoice.Contract_RentSchemeID = contclosureid.Contract_RentSchemeID;

                        oInvoice.RentPerSqFt = contclosureid.RentPerSqFeet;
                        oInvoice.SCPerSqFt = contclosureid.SCperSqFeet;

                        //// -- 
                    }

                    oInvoice.CompanyID = int.Parse(lookCompany.EditValue.ToString());
                    oInvoice.CompanyCode = context.Companies.Where(x => x.CompanyID == oInvoice.CompanyID).FirstOrDefault().CompanyCode;
                    oInvoice.LocationID = int.Parse(lookLocation.EditValue.ToString());
                    oInvoice.LocationCode = context.Locations.Where(x => x.LocationID == oInvoice.LocationID).FirstOrDefault().LocationCode;
                    oInvoice.ProcessYear = adjDate.DateTime.Year;
                    oInvoice.ProcessMonth = adjDate.DateTime.Month;
                    oInvoice.DateFrom = dateEditFrom.DateTime;
                    oInvoice.DateTo = dateEditTo.DateTime;
                    int nosdays = dateEditTo.DateTime.Subtract(dateEditTo.DateTime).Days;
                    oInvoice.NosDay = nosdays;
                    amount = row.SCPerMonth + row.TotalRentPerMonth; //row.TotalCreditValue;
                    oInvoice.RentWithSCPerMonth = amount;
                    oInvoice.Naration = txtInvoiceFooter.Text;
                    ////////****To Add Rent and Service charge together **** by Roshan..17Nove2014//////
                    decimal rentAmount = 0;
                    decimal scamount = 0;
                    
                    oInvoice.IsRentVariance = false;
                    oInvoice.IsSCVariance = false;

                    bool isrent = decimal.TryParse(row.TotalRentPerMonth.ToString(), out rentAmount);
                    if (isrent)
                    {
                    
                        oInvoice.RentPerMonth = row.TotalRentPerMonth;
                        if (row.TotalRentPerMonth > 0)
                        {
                            oInvoice.IsRentVariance = true;
                        }
                    }

                        bool isscAmount = decimal.TryParse(row.SCPerMonth.ToString(), out scamount);
                    if (isscAmount)
                   {
                        oInvoice.SCPerMonth = row.SCPerMonth;
                        if (row.SCPerMonth > 0)
                        {
                            oInvoice.IsSCVariance = true;
                        }
                   }

                  //get taxes
                    var qryContractTax = (from t in context.Taxes
                                          join tr in context.TaxRates on t.TaxID equals tr.TaxID
                                          where tr.IsActive == true
                                          select new { t.TaxID, tr.TaxRateID }).ToList();

                    if (invDetList.Count > 0) { invDetList.Clear(); }

                    foreach (var qry in qryContractTax)
                    {
                        Invoice_Details oInvDet = new Invoice_Details();
                        oInvDet.TaxID = qry.TaxID;
                        oInvDet.TaxRateID = qry.TaxRateID;
                        oInvDet.Amount = 0;
                        invDetList.Add(oInvDet);
                    }

                  //end get taxes


                    //// mandatory tax 
                    var qryMandatoryTax = (from m in invDetList
                                           join t in context.Taxes on m.TaxID equals t.TaxID
                                           where t.IsMandatory == true
                                           select new { MandatoryTaxAmount = m.Amount, MandatoryTaxCode = m.TaxCode, MandatoryTaxID = m.TaxID, MandatoryTaxRateID = m.TaxRateID }).FirstOrDefault();
                  
                        cMandatoryTax mandatoryTax = cTaxCalculations.getAmountWithMandatoryTax(amount);
                        
                        
                        
                        if (IsTaxCalApply == true) //// global tax
                        {

                            oInvoice.MandatoryTaxAmount = mandatoryTax.MandatoryTaxAmount;
                        }
                        else
                        {
                            oInvoice.MandatoryTaxAmount = 0;
                        }

                        oInvoice.MandatoryTaxCode = mandatoryTax.MandatoryTaxCode;
                        oInvoice.MandatoryTaxID = mandatoryTax.MandatoryTaxID;
                        oInvoice.MandatoryTaxRateID = mandatoryTax.MandatoryTaxRateID;
                        decimal Madatorytaxrate = mandatoryTax.MandatoryTaxRate;
                    
                   
                    decimal TotalwithMandatoryTax = mandatoryTax.TotalWithMandatoryTax;
                    List<cOtherTax> otherTaxList = cTaxCalculations.getOtherTax(TotalwithMandatoryTax);
                   
                    decimal totalTax = otherTaxList.Sum(x => x.TaxAmount);
                     
                    if (IsTaxCalApply == true)
                    {
                        oInvoice.TotalTax = oInvoice.MandatoryTaxAmount+totalTax;
                        
                        
                    }
                    else
                    {
                        oInvoice.TotalTax = 0;
                    }


                    if (totalTax > 0)
                    {
                        if (IsTaxCalApply == true)
                        {
                            oInvoice.OtherTax = totalTax;
                        }
                        else
                        {
                            oInvoice.OtherTax = 0;
                        }
                       
                        
                    }
                    foreach (var tax in otherTaxList)
                    {
                        oInvoice.OtherTaxCodes = tax.TaxCode;
                    }
                   
                    oInvoice.TotalWithMandatoryTax = amount + oInvoice.MandatoryTaxAmount;

                    oInvoice.TotalRentPerMonth = row.TotalCreditValue;
                    


                    //oInvoice.Naration = narationMemoEdit.Text;
                    oInvoice.InvoiceDate = adjDate.DateTime;
                    oInvoice.SAP_PstnDateInDoc = adjDate.DateTime;
                    oInvoice.ModifiedDate = DateTime.Now;
                    oInvoice.IsProcessed = true;
                    oInvoice.IsConfirmed = false;

                    string invoiceType = "";
                    
                    oInvoice.SubInvTypeID = 1; //// Adjustment (Invoice/CreditNote/Adjustment)
                    invoiceType = "Adjustment";
                    oInvoice.InvoiceTypeID = 1;  //// 1- RENT INVOICE 2 - Utility Invoice
                    ////credit note values (-)

                    ////record creation time 
                    oInvoice.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oInvoice.CreatedDate = DateTime.Now;
                    ////

                    //// SAP field update
                    //// document header update
                    oInvoice.SAP_DocHeaderText = "R" + oInvoice.ShopNo + adjDate.DateTime.Month.ToString() + adjDate.DateTime.Year.ToString();

                    ////SAP fields update

                    oInvoice.SAP_Assignment = "RENT";

                    oInvoice.SAP_Text = txtInvoiceFooter.Text;
                    oInvoice.SAP_RefKey1 = oInvoice.ShopNo;
                    oInvoice.SAP_RefKey2 = oInvoice.ShopName;
                    oInvoice.SAP_RefKey3 = "FIXED";
                    //// document type
                    var qryDT = (from dt in context.SAP_DocTypes
                                 where dt.CompanyID == oInvoice.CompanyID && dt.InvoiceTypeID == 1
                                 select dt).FirstOrDefault();
                    if (qryDT != null)
                    {
                        oInvoice.SAP_DocType = qryDT.DOCTYPE;
                    }


                    context.Invoices.AddObject(oInvoice);
                   
                  
                    
                        foreach (var qry in invDetList)
                        {
                            Invoice_Details oInvDet = new Invoice_Details();
                            bool IsMandatory = MMS.CustomClasses.cCommon_Functions.IsMandatory(qry.TaxID);
                            var tqry = (from t in context.Taxes
                                        where t.TaxID == qry.TaxID
                                        select new { t.TaxCode }).FirstOrDefault();
                            var trqry = (from t in context.TaxRates
                                         where t.TaxRateID == qry.TaxRateID
                                         select new { t.TaxRate1 }).FirstOrDefault();

                            if (IsMandatory == false)
                            {       
                               
                                oInvDet.Amount = totalTax;
                                oInvDet.TaxRate = trqry.TaxRate1;
                            }
                            else
                            {
                                oInvDet.Amount = oInvoice.MandatoryTaxAmount;
                                oInvDet.TaxRate = Madatorytaxrate;
                            }
                            oInvDet.TaxCode = tqry.TaxCode;
                            oInvDet.TaxRateID = qry.TaxRateID;
                            oInvDet.TaxID = qry.TaxID;
                            

                            
                            if (IsMandatory == false)
                            {
                                oInvDet.IsPrint = true;
                            }
                            else { oInvDet.IsPrint = false; }

                            //record creation time 
                            oInvDet.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                            oInvDet.CreatedDate = DateTime.Now;
                            // -- 

                            oInvoice.Invoice_Details.Add(oInvDet);
                        }
                    
                }
                //if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Connecting......"); }
                // chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
                //if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Rent Adjustment Grid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());

            }

        }

        
    }
}
