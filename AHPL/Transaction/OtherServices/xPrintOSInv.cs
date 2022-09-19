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
using DataTier.Reports.OtherService;

namespace MMS
{
    public partial class xPrintOSInv : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<cGen_Rent_Invoice> cGenInvList = new List<cGen_Rent_Invoice>();
        bool withSignature = false;
        enum InvStatus
        {
            All,
            Confirmed,
            NotConfirmed
        };

        public xPrintOSInv()
        {
            InitializeComponent();
        }

        private void optRent_SelectedIndexChanged(object sender, EventArgs e)
        {

            load_Selected();
        }

        ////private void Load_data(int pCompid, int pLocid, int fromMonth, int fromYear, int toMonth, int toYear)
        private void Load_data(int pCompid, int pLocid, DateTime? fromDT,DateTime? toDT)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

                List<Invoice> qryInv = new List<Invoice>();


                // confirmed invoice
                if (optRent.SelectedIndex == 0)
                {

                    if (!fromDT.Equals(null))
                    {
                        ////qryInv = (from inv in context.Invoices
                        ////          where inv.IsConfirmed == true && inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.SAP_PstnDateInDoc.Value.Month == fromMonth && inv.SAP_PstnDateInDoc.Value.Year == fromYear
                        ////          select inv).ToList();

                        //////qryInv = (from inv in context.Invoices
                        //////          where inv.IsConfirmed == true && inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.InvoiceDate.Month >= fromMonth && inv.InvoiceDate.Year >= fromYear
                        //////          select inv).ToList();

                        //////qryInv = qryInv.Where(w => w.InvoiceDate.Year <= toYear && w.InvoiceDate.Month <= toMonth).ToList();

                        qryInv = (from inv in context.Invoices
                                  where inv.IsConfirmed == true && inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.InvoiceDate >= fromDT //&& inv.ProfomaNo ==null//inv.IsProforma==false
                                  select inv).ToList();

                        qryInv = qryInv.Where(w => w.InvoiceDate <= toDT).ToList();
                    }
                    else
                    {
                        qryInv = (from inv in context.Invoices
                                  where inv.IsConfirmed == true && inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.IsProforma == false
                                  select inv).ToList();
                    }
                }

                // not confirmed invoice 
                if (optRent.SelectedIndex == 1)
                {

                    if (!fromDT.Equals(null))
                    {
                        ////qryInv = (from inv in context.Invoices
                        ////          where inv.IsConfirmed == false && inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.SAP_PstnDateInDoc.Value.Month == fromMonth && inv.SAP_PstnDateInDoc.Value.Year == fromYear
                        ////          select inv).ToList();

                        //////qryInv = (from inv in context.Invoices
                        //////          where inv.IsConfirmed == false && inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.InvoiceDate.Month >= fromMonth && inv.InvoiceDate.Year >= fromYear
                        //////          select inv).ToList();

                        //////qryInv = qryInv.Where(w => w.InvoiceDate.Year <= toYear && w.InvoiceDate.Month <= toMonth).ToList();

                        qryInv = (from inv in context.Invoices
                                  where inv.IsConfirmed == false && inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.InvoiceDate >= fromDT && inv.IsProforma == false
                                  select inv).ToList();

                        qryInv = qryInv.Where(w => w.InvoiceDate <= toDT).ToList();
                    }
                    else
                    {
                        qryInv = (from inv in context.Invoices
                                  where inv.IsConfirmed == false && inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.IsProforma == false
                                  select inv).ToList();
                    }
                }
                //----

                // all invoice
                if (optRent.SelectedIndex == 2)
                {
                    if (!fromDT.Equals(null))
                    {
                        ////qryInv = (from inv in context.Invoices
                        ////          where inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.SAP_PstnDateInDoc.Value.Month == fromMonth && inv.SAP_PstnDateInDoc.Value.Year == fromYear
                        ////          select inv).ToList();

                        //////qryInv = (from inv in context.Invoices
                        //////          where inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.InvoiceDate.Month >= fromMonth && inv.InvoiceDate.Year >= fromYear
                        //////          select inv).ToList();

                        //////qryInv = qryInv.Where(w => w.InvoiceDate.Year <= toYear && w.InvoiceDate.Month <= toMonth).ToList();

                        qryInv = (from inv in context.Invoices
                                  where inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.InvoiceDate >= fromDT && inv.IsProforma == false
                                  select inv).ToList();

                        qryInv = qryInv.Where(w => w.InvoiceDate <= toDT).ToList();
                    }
                    else
                    {
                        qryInv = (from inv in context.Invoices
                                  where inv.InvoiceTypeID == 3 && inv.CompanyID == pCompid && inv.LocationID == pLocid && inv.IsProforma == false
                                  select inv).ToList();
                    }
                }




                cGenInvList.Clear();
                foreach (var qry in qryInv)
                {
                    cGen_Rent_Invoice oGenInv = new cGen_Rent_Invoice();
                    oGenInv.SequenceNo = qry.SequenceNo;
                    oGenInv.InvoiceNo = qry.InvoiceNo;
                    oGenInv.InvDate = qry.InvoiceDate;
                    oGenInv.InvoiceID = qry.InvoiceID;
                    oGenInv.InvoiceTypeID = qry.InvoiceTypeID;
                    oGenInv.CompanyID = qry.CompanyID;
                    oGenInv.CompanyCode = qry.CompanyCode;
                    oGenInv.LocationID = qry.LocationID;
                    oGenInv.LocationCode = qry.LocationCode;
                    oGenInv.Confirm = qry.IsConfirmed;
                    oGenInv.ShopName = qry.ShopName;
                    oGenInv.ShopNo = qry.ShopNo;
                    oGenInv.TotalRent = qry.TotalRentPerMonth;
                    oGenInv.SubInvTypeID = qry.SubInvTypeID;
                    oGenInv.CustomerID = qry.CustomerID;
                    oGenInv.ProcessMonth = qry.ProcessMonth;
                    oGenInv.ProcessYear = qry.ProcessYear;
                    if (qry.IsProforma == true)
                        oGenInv.IsProforma = true;

                    oGenInv.Select = true;

                    cGenInvList.Add(oGenInv);
                    if (splashScreenManager1.IsSplashFormVisible == true)
                    {
                        splashScreenManager1.SetWaitFormDescription(oGenInv.ShopNo);
                    }
                }

                cGen_Rent_InvoiceBindingSource.DataSource = cGenInvList;
                cGen_Rent_InvoiceGridControl.RefreshDataSource();
                this.gridView1.BestFitColumns();
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getSelectedInvoices(List<Invoice> qryInv)
        {
            throw new NotImplementedException();
        }

        private void xPrintOSInv_Load(object sender, EventArgs e)
        {
            Load_data();

        }

        private void Load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    // sub invoice types
                    var qrySubInvT = (from si in context.Sub_Invoice_Types
                                      select si).ToList();
                    this.subInvoiceTypesBindingSource.DataSource = qrySubInvT;

                    this.lookSubInvTypeID.DataSource = qrySubInvT;
                    this.lookSubInvTypeID.DisplayMember = "SubInvTypeName";
                    this.lookSubInvTypeID.ValueMember = "SubInvTypeID";

                    // customers
                    var qryCust = (from gcus in context.Global_Customers
                                   select new { gcus.CustomerID, gcus.CustomerName }).ToList();
                    this.globalCustomersBindingSource.DataSource = qryCust;

                    // company 
                    var qryCompany = (from c in context.Companies
                                      select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
                    this.lookCompany.Properties.DataSource = qryCompany;
                    this.lookCompany.Properties.DisplayMember = "CompanyCode";
                    this.lookCompany.Properties.ValueMember = "CompanyID";

                    //location 
                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode }).ToList();
                    this.lookLocaiton.Properties.DataSource = qryLoc;
                    this.lookLocaiton.Properties.DisplayMember = "LocationCode";
                    this.lookLocaiton.Properties.ValueMember = "LocationID";

                    // Customer 
                    var qryCustomer = (from c in context.Global_Customers
                                       select new { c.CustomerID, c.CustomerName }).ToList();
                    this.lookCustomerID.DataSource = qryCust;
                    this.lookCustomerID.DisplayMember = "CustomerName";
                    this.lookCustomerID.ValueMember = "CustomerID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                this.cGen_Rent_InvoiceBindingSource.EndEdit();
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating - Other Service Invoice");
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
                                  where intSelected.Contains(i.InvoiceID)
                                  select new { i.OtherServiceID, i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.Naration, i.CustomerAddress2, i.IsTaxApplicable }).ToList();//,i.IsProforma


                if (qryInvoice.Count == 0)
                {
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                    return;
                }


                /// Report generation
                rptMain _main = new rptMain();
                //added by Ravindra 14-11-2019 
                //seperate Proforma & other invoice preview
                 
                rptOtherServiceInvoice rptOtherSInv = new rptOtherServiceInvoice();

                var qryInvDet = (from i in context.Invoice_Details
                                 join t in context.Taxes on i.TaxID equals t.TaxID
                                 where t.IsMandatory == false
                                 select new { i.InvoiceDetailID, i.InvoiceID, i.IsPrint, i.ItemName, i.Amount, i.TaxCode, i.TaxID, i.TaxRate, i.TaxRateID }).ToList();

                var qryCompany = (from c in context.Companies
                                  select new { c.Address, c.BusinessRegNo, c.CompanyCode, c.CompanyID, c.CompanyName, c.Fax, c.InvoiceFooterText1, c.InvoiceFooterText2, c.Tele1, c.Tele2 }).ToList();

                var qryMonth = (from m in context.Months
                                select m).ToList();

                var qryTax = (from t in context.Taxes
                              select new { t.TaxID, t.TaxCode, t.IsMandatory }).ToList();

                // Other Service category
                var qryOtherS = (from o in context.OtherServiceCategories
                                 select new { o.InvoicePrefix, o.OtherServiceID, o.OtherServiceName }).ToList();

                var qryLocaiton = (from l in context.Locations
                                   select new { l.Address, l.LocationCode, l.LocationID, l.LocationName, l.Logo }).ToList();


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


                rptOtherSInv.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                rptOtherSInv.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                rptOtherSInv.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                rptOtherSInv.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                rptOtherSInv.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                rptOtherSInv.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                rptOtherSInv.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                rptOtherSInv.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                rptOtherSInv.Database.Tables["DataTier_OtherServiceCategory"].SetDataSource(qryOtherS);
                rptOtherSInv.Database.Tables["DataTier_Permission_Users"].SetDataSource(prepairedSignature);
                rptOtherSInv.SetParameterValue("pHeaderText", "");
                rptOtherSInv.SetParameterValue("pDetailText", "");

                _main.crystalReportViewer1.ReportSource = rptOtherSInv;

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                _main.Show(this);

                PrintDialog printdg = new PrintDialog();
                printdg.AllowSomePages = true;
                printdg.AllowPrintToFile = true;

                if (printdg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rptOtherSInv.PrintOptions.PrinterName = printdg.PrinterSettings.PrinterName;
                    rptOtherSInv.PrintToPrinter(1, true, 0, 0);
                }

                printdg.Dispose();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkCompany_EditValueChanged(object sender, EventArgs e)
        {
            load_Selected();
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_Selected();
        }

        private void chkMonhs_EditValueChanged(object sender, EventArgs e)
        {
            load_Selected();
        }
        private void load_Selected()
        {

            try
            {

                ////if (string.IsNullOrEmpty(this.lookLocaiton.Text.ToString()) || string.IsNullOrEmpty(this.lookCompany.Text.ToString()) || string.IsNullOrEmpty(this.dtMonthYear.Text.ToString()))
                ////...remove this validation(above commented)..acording to Nimal's request on 20March2014..by roshan
                if (string.IsNullOrEmpty(this.lookLocaiton.Text.ToString()) || string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                { return; }


                int compid = 0; int locid = 0;

                int fromMonth = 0;
                int fromYear = 0;
                int toMonth = 0;
                int toYear = 0;

                DateTime? fromDate = dtMonthYear.DateTime;////To load all invoicess..18May2015..
                DateTime? todate = dtMonthYear_2.DateTime;

                compid = int.Parse(this.lookCompany.EditValue.ToString());
                locid = int.Parse(this.lookLocaiton.EditValue.ToString());

                if (dtMonthYear.DateTime > dtMonthYear_2.DateTime)
                {
                    return;
                }

                ////month = dtMonthYear.DateTime.Month;
                ////year = dtMonthYear.DateTime.Year;
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

                ////Load_data(compid, locid, fromMonth, fromYear, toMonth, toYear);

                Load_data(compid, locid, fromDate, todate);

                cGen_Rent_InvoiceGridControl.RefreshDataSource();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Other Service Invoice Summary");
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
                                  where intSelected.Contains(i.InvoiceID)
                                  select new
                                  {
                                      i.OtherServiceID,
                                      i.RentPerMonth,
                                      i.ShopName,
                                      i.InvoiceID,
                                      i.InvoiceNo,
                                      i.InvoiceTypeID,
                                      i.SubInvTypeID,
                                      i.InvoiceDate,
                                      i.CustomerID,
                                      i.CustomerName,
                                      i.CustomerAddress,
                                      i.CustomerAddress2,
                                      i.DateFrom,
                                      i.DateTo,
                                      i.TotalRentPerMonth,
                                      i.MandatoryTaxAmount,
                                      i.TotalWithMandatoryTax,
                                      i.OtherTax,
                                      i.TaxRegNo,
                                      i.SAP_DocHeaderText,
                                      i.IsTaxCustomer,
                                      i.MandatoryTaxCode,
                                      i.ProcessMonth,
                                      i.ProcessYear,
                                      i.ShopNo,
                                      i.CompanyID,
                                      i.LocationID,
                                      i.SAP_Assignment,
                                      i.CompanyCode,
                                      i.LocationCode,
                                      i.LevelName,
                                      i.Naration,
                                      i.TotalAmount,
                                      i.OtherTaxCodes
                                  }).ToList();


                if (qryInvoice.Count == 0)
                {
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                    return;
                }


                /// Report generation
                rptMain _main = new rptMain();
                DataTier.Reports.OtherService.rptOtherServiceInvSummaryMIS rptOsInvSummary = new DataTier.Reports.OtherService.rptOtherServiceInvSummaryMIS();

                //var qryInvDet = (from invdet in context.Invoice_Details
                //                 join t in context.Taxes on invdet.TaxID equals t.TaxID
                //                 where t.IsMandatory == false
                //                 select invdet).ToList();

                //var qryCompany = (from c in context.Companies
                //                  select c).ToList();

                //var qryMonth = (from m in context.Months
                //                select m).ToList();

                //var qryOtherS = (from o in context.OtherServiceCategories
                //                 select o).ToList();

                //var qryTax = (from t in context.Taxes
                //              select new { t.TaxID, t.TaxCode, t.IsMandatory }).ToList();

                //var qryTaxRate = (from t in context.TaxRates
                //                  select new { t.TaxRateID, t.TaxID, t.TaxRate1 }).ToList();

                //var qryLocaiton = (from l in context.Locations
                //                   select l).ToList();


                //var qryInvType = (from it in context.Invoice_Types
                //                  select new { it.InvoiceTypeID, it.InvoiceTypeName }).ToList();

                //var qrySubInvType = (from sit in context.Sub_Invoice_Types
                //                     select new { sit.SubInvTypeID, sit.SubInvTypeName }).ToList();



                rptOsInvSummary.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                //rptrentInv.Database.Tables["DataTier_OtherServiceCategory"].SetDataSource(qryOtherS);
                //rptrentInv.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                ////rptrentInv.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                //rptrentInv.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                //rptrentInv.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                //rptrentInv.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                //rptrentInv.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                //rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);

                _main.crystalReportViewer1.ReportSource = rptOsInvSummary;

                rptOsInvSummary.SetParameterValue("pMonthYear", dtMonthYear.Text.ToString());


                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                _main.Show(this);






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cGenInvList.Count == 0)
            {
                return;
            }

            if (this.btnSelectAll.Checked == true)
            {
                this.btnSelectAll.Text = "Unselect All";
                foreach (var qry in cGenInvList)
                {
                    qry.Select = true;
                }
            }
            else
            {
                this.btnSelectAll.Text = "Select All";
                foreach (var qry in cGenInvList)
                {
                    qry.Select = false;
                }
            }

            this.cGen_Rent_InvoiceGridControl.RefreshDataSource();

        }

        private void lookLocaiton_EditValueChanged(object sender, EventArgs e)
        {
            ////07Oct2014..toavoid loading until date select
            if (chkShowAllInv.Checked)
            {
                load_Selected();
            }
        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
        {
            ////07Oct2014..toavoid loading until date select
            if (chkShowAllInv.Checked)
            {
                load_Selected();
            }
            //// Location..roshan..06oct2014
            int comid = 0;
            bool res = false;
            res = int.TryParse(lookCompany.EditValue.ToString(), out comid);
            if (res.Equals(true))
            {
                var qryLoc = (from c in context.Companies
                              join l in context.Locations on c.LocationID equals l.LocationID
                              where c.CompanyID == comid
                              select new { l.LocationID, l.LocationCode }).ToList();


                this.lookLocaiton.Properties.DataSource = qryLoc;
                this.lookLocaiton.Properties.DisplayMember = "LocationCode";
                this.lookLocaiton.Properties.ValueMember = "LocationID";
            }
        }

        private void dtMonthYear_EditValueChanged(object sender, EventArgs e)
        {
            load_Selected();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            load_Selected();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAllInv.Checked)
            {
                dtMonthYear.EditValue = null;
                dtMonthYear.Enabled = false;

                dtMonthYear_2.EditValue = null;
                dtMonthYear_2.Enabled = false;

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