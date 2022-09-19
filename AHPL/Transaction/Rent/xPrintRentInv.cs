using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using DataTier;
using DataTier.Reports.Rent;
using DataTier.Reports.Print;

namespace MMS
{
    public partial class xPrintRentInv : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<cGen_Rent_Invoice> cGenInvList = new List<cGen_Rent_Invoice>();
        private rptRent_Invoice rptrentInv;
        bool withSignature = false;
        bool IsPrint = false;
        public xPrintRentInv()
        {
            InitializeComponent();
        }

        private void xPrintRentInv_Load(object sender, EventArgs e)
        {
            try
            {

                Load_data(InvStatus.Confirmed);

                rptrentInv = new rptRent_Invoice();//for new print button
               // btnDirectPrint.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void Load_data(InvStatus invstatus)
        {
          
            var qrySubInvT = (from si in context.Sub_Invoice_Types
                              select si).ToList();
            this.subInvoiceTypesBindingSource.DataSource = qrySubInvT;

            // customers
            var qryCust = (from gcus in context.Global_Customers
                           select new { gcus.CustomerID, gcus.CustomerName }).ToList();
            this.globalCustomersBindingSource.DataSource = qryCust;

            // company 
            var qryCompany = (from c in context.Companies
                              select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
            this.chkCompany.Properties.DataSource = qryCompany;
            this.chkCompany.Properties.DisplayMember = "CompanyCode";
            this.chkCompany.Properties.ValueMember = "CompanyID";

            // month 
            var qryMonth = (from m in context.Months
                            select new { m.MonthID, m.MonthCode }).ToList();
            this.repositoryItemLookUpEditMonth.DataSource = qryMonth;
            this.repositoryItemLookUpEditMonth.DisplayMember = "MonthCode";
            this.repositoryItemLookUpEditMonth.ValueMember = "MonthID";

            //return;


            var subInvoiceType = context.Sub_Invoice_Types.Select(s => new { s.SubInvTypeID, s.SubInvTypeName }).ToList();////26June2015..ro..for add sub invoice filter...RB-Ajith.
            this.lookUpInvoiceType.Properties.DataSource = subInvoiceType;
            this.lookUpInvoiceType.Properties.DisplayMember = "SubInvTypeName";
            this.lookUpInvoiceType.Properties.ValueMember = "SubInvTypeID";


        }

        //private void Load_YearMonth(List<Invoice> qryInv)
        //{
        //    cboYear.Properties.Items.Clear();
        //    var qryYear = (from y in qryInv
        //                   select new { y.ProcessYear }).Distinct();
        //    foreach (var qry in qryYear)
        //    {
        //        cboYear.Properties.Items.Add(qry.ProcessYear.ToString());
        //    }



        //    var qryMonth = (from i in qryInv
        //                    join m in context.Months on i.ProcessMonth equals m.MonthID
        //                    select new { m.MonthID, m.MonthCode }).Distinct();
        //    this.chkMonhs.Properties.DataSource = qryMonth;
        //    this.chkMonhs.Properties.DisplayMember = "MonthCode";
        //    this.chkMonhs.Properties.ValueMember = "MonthID";




        //}

        enum InvStatus
        {
            All,
            Confirmed,
            NotConfirmed
        };

        private void optRent_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_Selected();
            //if (optRent.SelectedIndex == 0) // confirmed 
            //{

            //    //Load_data(InvStatus.Confirmed);
            //}
            //if (optRent.SelectedIndex == 1) // not confirmed
            //{
            //    Load_data(InvStatus.NotConfirmed);
            //}

            //if (optRent.SelectedIndex == 2) // all
            //{
            //    Load_data(InvStatus.All);
            //}
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print - Rent Invoice");
                }


                var qrySelected = (from i in cGenInvList
                                   where i.Select == true
                                   select new { i.InvoiceID }).ToList();
                List<int> intSelected = new List<int>();
                foreach (var qry in qrySelected)
                {
                    intSelected.Add(qry.InvoiceID);
                }


                // List of invoices which selected in the grid
                var qryInvoice = (from i in context.Invoices
                                  join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
                                  orderby lvl.StdOrder ascending
                                  where intSelected.Contains(i.InvoiceID)
                                  select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate,
                                      i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth,
                                      i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax,
                                      i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, 
                                      i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable,
                                      i.Naration, i.FooterText1 }).ToList();


                if (qryInvoice.Count == 0)
                {
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                    return;
                }


                /// Report generation
                rptMain _main = new rptMain();

                //rptRent_Invoice rptrentInv = new rptRent_Invoice();
                rptrentInv = new rptRent_Invoice();

                var qryInvDet = (from invdet in context.Invoice_Details
                                 join t in context.Taxes on invdet.TaxID equals t.TaxID
                                 where t.IsMandatory == false
                                 select new { invdet.Amount, invdet.InvoiceDetailID, invdet.InvoiceID, invdet.IsPrint, invdet.TaxCode, invdet.TaxID, invdet.TaxRate }).ToList();

                var qryCompany = (from c in context.Companies
                                  select new { c.CompanyCode, c.CompanyID, c.DefaultTaxRegNo, c.CompanyName, c.Tele1, c.Tele2, c.Fax, c.Address, c.BusinessRegNo, c.InvoiceFooterText1, c.InvoiceFooterText2 }).ToList();

                var qryMonth = (from m in context.Months
                                select m).ToList();

                var qryTax = (from t in context.Taxes
                              select new { t.TaxID, t.TaxCode, t.IsMandatory }).ToList();

                var qryLocaiton = (from l in context.Locations
                                   select new { l.LocationID, l.LocationName, l.Logo, l.Address }).ToList();


                var qryInvType = (from it in context.Invoice_Types
                                  select new { it.InvoiceTypeID, it.InvoiceTypeName }).ToList();

                var qrySubInvType = (from sit in context.Sub_Invoice_Types
                                     select new { sit.SubInvTypeID, sit.SubInvTypeName }).ToList();

                int userId = 0;
          
                if (withSignature)
                {
                     userId = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                }
                    var prepairedSignature = (from usr in context.Permission_Users
                                              where usr.UserID == userId
                                              select new { usr.signature }
                                  );
 
                rptrentInv.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                rptrentInv.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                rptrentInv.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                rptrentInv.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                rptrentInv.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                rptrentInv.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                rptrentInv.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                rptrentInv.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                rptrentInv.Database.Tables["DataTier_Permission_Users"].SetDataSource(prepairedSignature);
                
                
                //rptrentInv.SetParameterValue("signature",withSignature);
                rptrentInv.SetParameterValue("pHeaderText", "");
                rptrentInv.SetParameterValue("pDetailText", "");
                //rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);

                _main.crystalReportViewer1.ReportSource = rptrentInv;

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                _main.Refresh();
                _main.Show();

                //btnDirectPrint.Enabled = true;
                
            }
            catch (Exception ex) 
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            //foreach (var qry in cGenInvList)
            //{
            //    qry.Select = true;
            //}
            //cGen_Rent_InvoiceGridControl.RefreshDataSource();
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print-invoice Summary");
                }


                var qrySelected = (from i in cGenInvList
                                   join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
                                   orderby lvl.StdOrder ascending
                                   where i.Select == true
                                   select new { i.InvoiceID }).ToList();
                List<int> intSelected = new List<int>();
                foreach (var qry in qrySelected)
                {
                    intSelected.Add(qry.InvoiceID);
                }


                // List of invoices which selected in the grid
                var qryInvoice = (from i in context.Invoices
                                  join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
                                  orderby lvl.StdOrder ascending
                                  where intSelected.Contains(i.InvoiceID)
                                  select new { i.RentWithSCPerMonth, i.RentPerMonth, i.ShopName, i.InvoiceID, i.InvoiceNo, 
                                      i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, 
                                      i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, 
                                      i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer,
                                      i.MandatoryTaxCode,i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID,
                                      i.LevelName, i.RentalDiscount,i.SCDiscount,i.TotalTax }).ToList();
              

                  
                if (qryInvoice.Count == 0)
                {
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                    return;
                }


                /// Report generation
                rptMain _main = new rptMain();
                rptRentInvSummary rptrentInv = new rptRentInvSummary();

                

                var qryCompany = (from c in context.Companies
                                  select new { c.CompanyCode, c.CompanyID, c.DefaultTaxRegNo, c.CompanyName, c.Tele1, c.Tele2, c.Address, c.BusinessRegNo, c.InvoiceFooterText1, c.InvoiceFooterText2 }).ToList();


                var qryMonth = (from m in context.Months
                                select m).ToList();


                var qryLocaiton = (from l in context.Locations
                                   select new { l.LocationID, l.LocationCode, l.LocationName, l.Logo, l.Address }).ToList();



                var qryInvType = (from it in context.Invoice_Types
                                  select new { it.InvoiceTypeID, it.InvoiceTypeName }).ToList();

                var qrySubInvType = (from sit in context.Sub_Invoice_Types
                                     select new { sit.SubInvTypeID, sit.SubInvTypeName }).ToList();

                
                
                rptrentInv.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                //rptrentInv.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);

                rptrentInv.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                //rptrentInv.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                rptrentInv.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                rptrentInv.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                rptrentInv.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                rptrentInv.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                //rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);
               
                _main.crystalReportViewer1.ReportSource = rptrentInv;

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                _main.Show(this);

                #region added by ravindra 18-04-2019 print document
                if (IsPrint)
                {
                    PrintDialog printdg = new PrintDialog();
                    printdg.AllowSomePages = true;
                    printdg.AllowPrintToFile = true;

                    if (printdg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rptrentInv.PrintOptions.PrinterName = printdg.PrinterSettings.PrinterName;
                        rptrentInv.PrintToPrinter(1, true, 0, 0);
                    }

                    printdg.Dispose();
                }
                #endregion
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void chkCompany_EditValueChanged(object sender, EventArgs e)
        {
            load_Selected();
            //btnDirectPrint.Enabled = false;

            //if (string.IsNullOrEmpty(this.chkCompany.Text.ToString()))
            //{
            //    return;
            //}

            ////selected company 
            //string selected = this.chkCompany.Properties.GetCheckedItems().ToString();

            //string theString = selected;
            //List<int> ints = theString.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));

            //foreach (var qry in cGenInvList)
            //{
            //    qry.Select = false;
            //}

            //var qrySelected = (from c in cGenInvList
            //                  where ints.Contains(c.CompanyID)
            //                 select c).ToList();
            //foreach (var qry in qrySelected)
            //{
            //    qry.Select = true;
            //}


        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(this.cboYear.Text.ToString()))
            //{ return; }

            //bool res = false;
            //int year = 0;
            //res = int.TryParse(cboYear.EditValue.ToString(), out year);
            //if (res == false) { year = 0; }
            //if (year == 0) { return; }

            load_Selected();

        }

        private void load_Selected()
        {
            try
            {
                //Load_YearMonth();

                ////validating company 
                if (string.IsNullOrEmpty(this.chkCompany.Text.ToString().Trim()))
                { return; }

                //////////validating year/month...remove this validation(above commented)..acording to Nimal's request on 20March2014..by roshan
                //////////validating year/month
                //////if (string.IsNullOrEmpty(dtMonthYear.Text.ToString()))
                //////{ return; }
                //////int year = dtMonthYear.DateTime.Year;
                //////int month = dtMonthYear.DateTime.Month;

                /////////validating date from..10July2014..Niluka's request
                ////if (string.IsNullOrEmpty(dtMonthYear.Text.ToString()))
                ////{ return; }


                ////if (string.IsNullOrEmpty(dtMonthYear_2.Text.ToString()))
                ////{ return; }

                //////////END--validating date to..10July2014..Niluka's request
                //////////Remove above validation to implement Show All invice functionality, implement below..Niluka's request..by roshan..18Nove2014.
                if (!chkShowAllInv.Checked)
                {
                    if (string.IsNullOrEmpty(dtMonthYear.Text.ToString()))
                    { return; }

                    if (string.IsNullOrEmpty(dtMonthYear_2.Text.ToString()))
                    { return; }
                }

                if (dtMonthYear.DateTime > dtMonthYear_2.DateTime)
                {
                    return;
                }

                int fromYear = 0;
                int fromMonth = 0;
                int toYear = 0;
                int toMonth = 0;

                DateTime? fromDate = dtMonthYear.DateTime;////To load all invoicess..18May2015..
                DateTime? todate = dtMonthYear_2.DateTime;

                if (!string.IsNullOrEmpty(dtMonthYear.Text.ToString()))
                {
                    fromYear = dtMonthYear.DateTime.Year;
                    fromMonth = dtMonthYear.DateTime.Month;
                }
                else 
                {
                    fromDate = null;
                }

                if (!string.IsNullOrEmpty(dtMonthYear_2.Text.ToString()))
                {
                    toYear = dtMonthYear_2.DateTime.Year;
                    toMonth = dtMonthYear_2.DateTime.Month;
                }
                else 
                {
                    todate = null;
                }

                //selected company 
                string selected = this.chkCompany.Properties.GetCheckedItems().ToString();

                string theString = selected;
                List<int> intCompList = new List<int>();
                if (!string.IsNullOrEmpty(theString))
                {
                    intCompList = theString.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));
                }


                if (intCompList.Count == 0)
                {
                    var qryCo = (from c in context.Companies
                                 select new { c.CompanyID }).ToList();
                    foreach (var qry in qryCo)
                    {
                        intCompList.Add(qry.CompanyID);
                    }
                }

                ////26June2015..add subinvoice filter requested by Ajith..ro
                bool res = false;
                int subinvID = 0;

                if (!string.IsNullOrEmpty(this.lookUpInvoiceType.Text.ToString()))
                {
                    res = int.TryParse(this.lookUpInvoiceType.EditValue.ToString(), out subinvID);
                    if (res == false)
                    {
                        subinvID = 0;
                    }
                }

                ////....


                //foreach (var qry in cGenInvList)
                //{
                //    qry.Select = false;

                //}
                if (optRent.SelectedIndex == 0) // confirmed invoices
                {
                    ////load_Selected(intCompList, fromYear, fromMonth, toYear, toMonth, InvStatus.Confirmed);
                    load_Selected(intCompList, fromDate, todate, InvStatus.Confirmed, subinvID);
                }
                if (optRent.SelectedIndex == 1) // not confirmed invoices 
                {
                    //////load_Selected(intCompList, fromYear, fromMonth, toYear, toMonth, InvStatus.NotConfirmed);
                    load_Selected(intCompList, fromDate, todate, InvStatus.NotConfirmed, subinvID);
                }

                if (optRent.SelectedIndex == 2) // confirmed and not confirmed invoices
                {
                    //////load_Selected(intCompList, fromYear, fromMonth, toYear, toMonth, InvStatus.All);
                    load_Selected(intCompList, fromDate, todate, InvStatus.All, subinvID);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //////private void load_Selected(List<int> intCompList, int fromYear, int fromMonth, int toyear, int tomonth, InvStatus invstatus)
        private void load_Selected(List<int> intCompList, DateTime? fromDT,DateTime? toDT, InvStatus invstatus,int subInvID)
        {
            
            if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            
            if (splashScreenManager1.IsSplashFormVisible == false)
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormDescription("Loading Data...");
            }

            IQueryable<Invoice> InvList = null;//context.Invoices.AsQueryable();
           // InvList.ToList().Clear();
            //List<Invoice> intCompList = new List<int>();

            if (invstatus == InvStatus.Confirmed)
            {
                //////if (!fromYear.Equals(0))
                if (!fromDT.Equals(null))
                {
                    ////InvList = (from i in context.Invoices
                    ////           where intCompList.Contains(i.CompanyID) && i.SAP_PstnDateInDoc.Value.Year == fromYear && i.SAP_PstnDateInDoc.Value.Month == fromMonth && i.IsConfirmed == true && i.InvoiceTypeID == 1
                    ////           select i).AsQueryable();

                    ////comment above existing code and implemented below, to implement date range..18 June 2014.

                    //////InvList = (from i in context.Invoices
                    //////           where intCompList.Contains(i.CompanyID) && i.SAP_PstnDateInDoc.Value.Year >= fromYear && i.SAP_PstnDateInDoc.Value.Month >= fromMonth && i.IsConfirmed == true && i.InvoiceTypeID == 1
                    //////           select i).AsQueryable();

                    //////InvList = InvList.Where(w => w.SAP_PstnDateInDoc.Value.Year <= toyear && w.SAP_PstnDateInDoc.Value.Month <= tomonth).AsQueryable();

                    InvList = (from i in context.Invoices
                               where intCompList.Contains(i.CompanyID) && i.SAP_PstnDateInDoc.Value >=fromDT && i.IsConfirmed == true && i.InvoiceTypeID == 1
                               select i).AsQueryable();

                    InvList = InvList.Where(w => w.SAP_PstnDateInDoc.Value <= toDT).AsQueryable();
                }
                else
                {
                    InvList = (from i in context.Invoices
                               where intCompList.Contains(i.CompanyID) && i.IsConfirmed == true && i.InvoiceTypeID == 1
                               select i).AsQueryable();
                }
            }
            if (invstatus == InvStatus.NotConfirmed)
            {
                if (!fromDT.Equals(0))
                {
                    ////InvList = (from i in context.Invoices
                    ////           where intCompList.Contains(i.CompanyID) && i.SAP_PstnDateInDoc.Value.Year == fromYear && i.SAP_PstnDateInDoc.Value.Month == fromMonth && i.IsConfirmed == false && i.IsProcessed == true && i.InvoiceTypeID == 1
                    ////           select i).AsQueryable();

                    //////InvList = (from i in context.Invoices
                    //////           where intCompList.Contains(i.CompanyID) && i.SAP_PstnDateInDoc.Value.Year >= fromYear && i.SAP_PstnDateInDoc.Value.Month >= fromMonth && i.IsConfirmed == false && i.IsProcessed == true && i.InvoiceTypeID == 1
                    //////           select i).AsQueryable();

                    //////InvList = InvList.Where(w => w.SAP_PstnDateInDoc.Value.Year <= toyear && w.SAP_PstnDateInDoc.Value.Month <= tomonth).AsQueryable();

                    InvList = (from i in context.Invoices
                               where intCompList.Contains(i.CompanyID) && i.SAP_PstnDateInDoc.Value >= fromDT && i.IsConfirmed == false && i.IsProcessed == true && i.InvoiceTypeID == 1
                               select i).AsQueryable();

                    InvList = InvList.Where(w => w.SAP_PstnDateInDoc.Value <= toDT ).AsQueryable();
                }
                else
                {
                    InvList = (from i in context.Invoices
                               where intCompList.Contains(i.CompanyID) && i.IsConfirmed == false && i.IsProcessed == true && i.InvoiceTypeID == 1
                               select i).AsQueryable();
                }
            }

            if (invstatus == InvStatus.All)
            {
                if (!fromDT.Equals(0))
                {
                    ////InvList = (from i in context.Invoices
                    ////           where intCompList.Contains(i.CompanyID) && i.SAP_PstnDateInDoc.Value.Year == fromYear && i.SAP_PstnDateInDoc.Value.Month == fromMonth && i.IsProcessed == true && i.InvoiceTypeID == 1
                    ////           select i).AsQueryable();

                    //////InvList = (from i in context.Invoices
                    //////           where intCompList.Contains(i.CompanyID) && i.SAP_PstnDateInDoc.Value.Year == fromYear && i.SAP_PstnDateInDoc.Value.Month == fromMonth && i.IsProcessed == true && i.InvoiceTypeID == 1
                    //////           select i).AsQueryable();

                    //////InvList = InvList.Where(w => w.SAP_PstnDateInDoc.Value.Year <= toyear && w.SAP_PstnDateInDoc.Value.Month <= tomonth).AsQueryable();

                    InvList = (from i in context.Invoices
                               where intCompList.Contains(i.CompanyID) && i.SAP_PstnDateInDoc.Value == fromDT && i.IsProcessed == true && i.InvoiceTypeID == 1
                               select i).AsQueryable();

                    InvList = InvList.Where(w => w.SAP_PstnDateInDoc.Value <= toDT).AsQueryable();
                }
                else
                {
                    InvList = (from i in context.Invoices
                               where intCompList.Contains(i.CompanyID) && i.IsProcessed == true && i.InvoiceTypeID == 1
                               select i).AsQueryable();
                }
            }

            if (subInvID > 0) 
            {
                InvList = InvList.Where(w => w.SubInvTypeID == subInvID).AsQueryable();
            }


            cGenInvList.Clear();
            foreach (var qry in InvList)
            {
                cGen_Rent_Invoice oGenInv = new cGen_Rent_Invoice();
                oGenInv.SequenceNo = qry.SequenceNo;
                oGenInv.InvoiceNo = qry.InvoiceNo;
                oGenInv.InvoiceID = qry.InvoiceID;
                oGenInv.InvoiceTypeID = qry.InvoiceTypeID;
                oGenInv.CompanyID = qry.CompanyID;
                oGenInv.CompanyCode = context.Companies.Where(x => x.CompanyID == qry.CompanyID).FirstOrDefault().CompanyCode;
                oGenInv.LocationID = qry.LocationID;
                oGenInv.LocationCode = context.Locations.Where(x => x.LocationID == qry.LocationID).FirstOrDefault().LocationCode;
                oGenInv.InvDate = qry.InvoiceDate;
                oGenInv.Confirm = qry.IsConfirmed;
                oGenInv.ShopName = qry.ShopName;
                oGenInv.TotalRent = qry.TotalRentPerMonth;
                oGenInv.SubInvTypeID = qry.SubInvTypeID;
                oGenInv.CustomerID = qry.CustomerID;
                oGenInv.ProcessMonth = qry.ProcessMonth;
                oGenInv.ProcessYear = qry.ProcessYear;
                oGenInv.ShopNo = qry.ShopNo;
                oGenInv.ProcessMonth = qry.ProcessMonth;
                oGenInv.ProcessYear = qry.ProcessYear;
                oGenInv.LevelID = qry.LevelID;
                oGenInv.RentalDiscount = (qry.RentalDiscount);
                oGenInv.SCDiscount = qry.SCDiscount;
                oGenInv.SCPerMonth = qry.SCPerMonth;
                cGenInvList.Add(oGenInv);
            }

            cGen_Rent_InvoiceBindingSource.DataSource = cGenInvList;
            cGen_Rent_InvoiceGridControl.RefreshDataSource();
            cGen_Rent_InvoiceGridControl.RefreshDataSource();

            if (splashScreenManager1.IsSplashFormVisible == true)
            { splashScreenManager1.CloseWaitForm(); }
        }

        private void chkMonhs_EditValueChanged(object sender, EventArgs e)
        {
            load_Selected();
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelect.Checked == true)
            {
                chkSelect.Text = "Unselect All";
                foreach (var qry in cGenInvList)
                {
                    qry.Select = true;
                }
                cGen_Rent_InvoiceGridControl.RefreshDataSource();
            }
            else
            {
                chkSelect.Text = "Select All";
                foreach (var qry in cGenInvList)
                {
                    qry.Select = false;
                }
                cGen_Rent_InvoiceGridControl.RefreshDataSource();
            }
        }

        private void dtMonthYear_EditValueChanged(object sender, EventArgs e)
        {
            load_Selected();
            //btnDirectPrint.Enabled = false;
        }

        private void dtMonthYear_2_EditValueChanged(object sender, EventArgs e)
        {
            load_Selected();
            //btnDirectPrint.Enabled = false;
        }

        private void chkShowAllInv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAllInv.Checked)
            {
                dtMonthYear.EditValue = null;
                dtMonthYear.Enabled = false;

                dtMonthYear_2.EditValue = null;
                dtMonthYear_2.Enabled = false;

                lookUpInvoiceType.EditValue = null;

                load_Selected();
            }
            else
            {
                dtMonthYear.EditValue = null;
                dtMonthYear.Enabled = true;

                dtMonthYear_2.EditValue = null;
                dtMonthYear_2.Enabled = true;
            }
        }

        private void lookUpInvoiceType_EditValueChanged(object sender, EventArgs e)
        {
            load_Selected();
            //btnDirectPrint.Enabled = false;
        }

        private void btnDirectPrint_Click(object sender, EventArgs e)
        {
            #region old code
            //IsPrint = true;
           // btnPrint_Click(null, null);
            //DialogResult dlg = MessageBox.Show("Are you sure, you want to print the previewed invoicess ?", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dlg == System.Windows.Forms.DialogResult.No)
            //{
            //    return;
            //}
            //else
            //{
            //    if (rptrentInv != null)
            //    {
                    
            //        rptrentInv.PrintToPrinter(1, true, 0, 0);////For fix logo missing issue
            //    }
            //}
            #endregion

            #region amedment 18-04-2019 by Ravindra
            try
            {

                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print - Rent Invoice");
                }


                var qrySelected = (from i in cGenInvList
                                   where i.Select == true
                                   select new { i.InvoiceID }).ToList();
                List<int> intSelected = new List<int>();
                foreach (var qry in qrySelected)
                {
                    intSelected.Add(qry.InvoiceID);
                }


                // List of invoices which selected in the grid
                var qryInvoice = (from i in context.Invoices
                                  join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
                                  orderby lvl.StdOrder ascending
                                  where intSelected.Contains(i.InvoiceID)
                                  select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable, i.Naration, i.FooterText1 }).ToList();


                if (qryInvoice.Count == 0)
                {
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                    return;
                }


                /// Report generation
                rptMain _main = new rptMain();

                //rptRent_Invoice rptrentInv = new rptRent_Invoice();
                rptrentInv = new rptRent_Invoice();

                var qryInvDet = (from invdet in context.Invoice_Details
                                 join t in context.Taxes on invdet.TaxID equals t.TaxID
                                 where t.IsMandatory == false
                                 select new { invdet.Amount, invdet.InvoiceDetailID, invdet.InvoiceID, invdet.IsPrint, invdet.TaxCode, invdet.TaxID, invdet.TaxRate }).ToList();

                var qryCompany = (from c in context.Companies
                                  select new { c.CompanyCode, c.CompanyID, c.DefaultTaxRegNo, c.CompanyName, c.Tele1, c.Tele2, c.Fax, c.Address, c.BusinessRegNo, c.InvoiceFooterText1, c.InvoiceFooterText2 }).ToList();

                var qryMonth = (from m in context.Months
                                select m).ToList();

                var qryTax = (from t in context.Taxes
                              select new { t.TaxID, t.TaxCode, t.IsMandatory }).ToList();

                var qryLocaiton = (from l in context.Locations
                                   select new { l.LocationID, l.LocationName, l.Logo, l.Address }).ToList();


                var qryInvType = (from it in context.Invoice_Types
                                  select new { it.InvoiceTypeID, it.InvoiceTypeName }).ToList();

                var qrySubInvType = (from sit in context.Sub_Invoice_Types
                                     select new { sit.SubInvTypeID, sit.SubInvTypeName }).ToList();

                int userId = 0;

                if (withSignature)
                {
                    userId = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                }
                var prepairedSignature = (from usr in context.Permission_Users
                                          where usr.UserID == userId
                                          select new { usr.signature }
                              );

                string selected = this.chkCompany.Properties.GetCheckedItems().ToString();
                

                
                rptrentInv.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                rptrentInv.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                rptrentInv.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                rptrentInv.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                rptrentInv.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                rptrentInv.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                rptrentInv.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                rptrentInv.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                rptrentInv.Database.Tables["DataTier_Permission_Users"].SetDataSource(prepairedSignature);
                 
                rptrentInv.SetParameterValue("pHeaderText", "");
                rptrentInv.SetParameterValue("pDetailText", "");
                //rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);
                
                _main.crystalReportViewer1.ReportSource = rptrentInv;

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                _main.Refresh();
                _main.Show();

                PrintDialog printdg = new PrintDialog();
                printdg.AllowSomePages = true;
                printdg.AllowPrintToFile = true;

                if (printdg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rptrentInv.PrintOptions.PrinterName = printdg.PrinterSettings.PrinterName;
                    rptrentInv.PrintToPrinter(1, true, 0, 0);
                }

                printdg.Dispose();
                // btnDirectPrint.Enabled = true;

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
        }

        private void chkSignature_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSignature.Checked == true)
            {
                withSignature = true;
            }
            else
            {
                withSignature = false;
            }
        }
    }
}