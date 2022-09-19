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
using DataTier.Reports.Utility;

namespace MMS
{
    public partial class xPrintUtilites : DevExpress.XtraEditors.XtraForm
    {
        //AHPL_DBEntities context = new AHPL_DBEntities();
        List<cGen_Rent_Invoice> cGenInvList = new List<cGen_Rent_Invoice>();
        bool withSignature = false;
        private rptUtilityInvoice rptUtility;

        public xPrintUtilites()
        {
            InitializeComponent();
        }

        private void xPrintUtilites_Load(object sender, EventArgs e)
        {
            Load_data();

            rptUtility = new rptUtilityInvoice();//for new print button
            btnDirectPrintU.Enabled = false;
        }

        private void load_Selected()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    int compid = 0;
                    int locid = 0;
                    int utilityid = 0;
                    int fromMonth = 0;
                    int fromYear = 0;
                    int toYear = 0;
                    int toMonth = 0;
                    bool res = false;

                    DateTime? fromDate = dtMonthYear.DateTime;////To load all invoicess..18May2015..
                    DateTime? todate = dtMonthYear_2.DateTime;

                    if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()) || string.IsNullOrEmpty(this.lookLocaiton.Text.ToString()) || string.IsNullOrEmpty(this.lookUtility.Text.ToString()))
                    ////..remove dtMonthYear validation(above commented)..acording to Nimal's request on 20March2014..by roshan...////23Sep2014..again request to implement above logic
                    ////if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()) || string.IsNullOrEmpty(this.lookLocaiton.Text.ToString()) || string.IsNullOrEmpty(this.lookUtility.Text.ToString()))
                    { return; }

                    res = int.TryParse(this.lookCompany.EditValue.ToString(), out compid);
                    if (res == false) { return; }
                    res = int.TryParse(this.lookLocaiton.EditValue.ToString(), out locid);
                    if (res == false) { return; }
                    res = int.TryParse(this.lookUtility.EditValue.ToString(), out utilityid);
                    if (res == false) { return; }

                    ////res = int.TryParse(this.dtMonthYear.DateTime.Month.ToString(), out month);
                    ////if (res == false) { return; }
                    ////res = int.TryParse(this.dtMonthYear.DateTime.Year.ToString(), out year);

                    if (dtMonthYear.DateTime > dtMonthYear_2.DateTime)
                    {
                        return;
                    }

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

                    List<Invoice> qryInv = new List<Invoice>();

                    if (optRent.SelectedIndex == 0) // confirmed 
                    {
                        if (!fromYear.Equals(0))
                        {
                            ////qryInv = (from inv in context.Invoices
                            ////          where inv.IsConfirmed == true && inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.SAP_PstnDateInDoc.Value.Month == fromMonth && inv.SAP_PstnDateInDoc.Value.Year == fromYear && inv.UtilityID == utilityid
                            ////          select inv).ToList();

                            //////qryInv = (from inv in context.Invoices
                            //////          where inv.IsConfirmed == true && inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.InvoiceDate.Month >= fromMonth && inv.InvoiceDate.Year >= fromYear && inv.UtilityID == utilityid
                            //////          select inv).ToList();

                            //////qryInv = qryInv.Where(w => w.InvoiceDate.Year <= toYear && w.InvoiceDate.Month <= toMonth).ToList();

                            qryInv = (from inv in context.Invoices
                                      where inv.IsConfirmed == true && inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.InvoiceDate >= fromDate && inv.UtilityID == utilityid
                                      select inv).ToList();

                            qryInv = qryInv.Where(w => w.InvoiceDate <= todate).ToList();

                        }
                        else
                        {
                            qryInv = (from inv in context.Invoices
                                      where inv.IsConfirmed == true && inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.UtilityID == utilityid
                                      select inv).ToList();
                        }

                    }
                    if (optRent.SelectedIndex == 1) // not confirmed
                    {
                        if (!fromYear.Equals(0))
                        {
                            ////qryInv = (from inv in context.Invoices
                            ////          where inv.IsConfirmed == false && inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.SAP_PstnDateInDoc.Value.Month == fromMonth && inv.SAP_PstnDateInDoc.Value.Year == fromYear && inv.UtilityID == utilityid
                            ////          select inv).ToList();

                            //////qryInv = (from inv in context.Invoices
                            //////          where inv.IsConfirmed == false && inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.InvoiceDate.Month >= fromMonth && inv.InvoiceDate.Year >= fromYear && inv.UtilityID == utilityid
                            //////          select inv).ToList();

                            //////qryInv = qryInv.Where(w => w.InvoiceDate.Year <= toYear && w.InvoiceDate.Month <= toMonth).ToList();

                            qryInv = (from inv in context.Invoices
                                      where inv.IsConfirmed == false && inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.InvoiceDate >= fromDate && inv.UtilityID == utilityid
                                      select inv).ToList();

                            qryInv = qryInv.Where(w => w.InvoiceDate <= todate ).ToList();
                        }
                        else
                        {
                            qryInv = (from inv in context.Invoices
                                      where inv.IsConfirmed == false && inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.UtilityID == utilityid
                                      select inv).ToList();
                        }
                    }

                    if (optRent.SelectedIndex == 2) // all
                    {
                        if (!fromYear.Equals(0))
                        {
                            ////qryInv = (from inv in context.Invoices
                            ////          where inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.SAP_PstnDateInDoc.Value.Month == fromMonth && inv.SAP_PstnDateInDoc.Value.Year == fromYear && inv.UtilityID == utilityid
                            ////          select inv).ToList();

                            //////qryInv = (from inv in context.Invoices
                            //////          where inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.InvoiceDate.Month >= fromMonth && inv.InvoiceDate.Year >= fromYear && inv.UtilityID == utilityid
                            //////          select inv).ToList();

                            //////qryInv = qryInv.Where(w => w.InvoiceDate.Year <= toYear && w.InvoiceDate.Month <= toMonth).ToList();

                            qryInv = (from inv in context.Invoices
                                      where inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.InvoiceDate >= fromDate && inv.UtilityID == utilityid
                                      select inv).ToList();

                            qryInv = qryInv.Where(w => w.InvoiceDate <= todate).ToList();
                        }
                        else
                        {
                            qryInv = (from inv in context.Invoices
                                      where inv.InvoiceTypeID == 2 && inv.CompanyID == compid && inv.LocationID == locid && inv.UtilityID == utilityid
                                      select inv).ToList();
                        }
                    }


                    cGenInvList.Clear();
                    if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

                    foreach (var qry in qryInv)
                    {
                        cGen_Rent_Invoice oGenInv = new cGen_Rent_Invoice();
                        oGenInv.UtilityID = qry.UtilityID;
                        oGenInv.UtilityUnitRate = qry.UtilityUnitRate;
                        oGenInv.SubInvTypeID = qry.SubInvTypeID;
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
                        oGenInv.DateFrom = qry.DateFrom;
                        oGenInv.DateTo = qry.DateTo;
                        oGenInv.ProcessYear = qry.ProcessYear;
                        oGenInv.ProcessMonth = qry.ProcessMonth;
                        oGenInv.StartReading1 = qry.StartReading;
                        oGenInv.EndReading1 = qry.EndReading;
                        oGenInv.StartReading2 = qry.StartReading2;
                        oGenInv.EndReading2 = qry.EndReading2;
                        oGenInv.TotalAmount = qry.RentPerMonth;
                        oGenInv.TotalTax = qry.TotalTax;
                        oGenInv.ShopNo = qry.ShopNo;
                        oGenInv.GrandTotal = qry.RentPerMonth + qry.TotalTax;

                        //oGenInv.TotalRent = qry.TotalAmount;
                        oGenInv.SubInvTypeID = qry.SubInvTypeID;
                        oGenInv.CustomerID = qry.CustomerID;
                        oGenInv.Select = true;
                        cGenInvList.Add(oGenInv);
                        splashScreenManager1.SetWaitFormDescription("Loading " + oGenInv.ShopNo);

                    }

                    cGenInvList = (from c in cGenInvList
                                   orderby c.InvoiceNo ascending
                                   select c).ToList();

                    cGen_Rent_InvoiceBindingSource.DataSource = cGenInvList;
                    cGen_Rent_InvoiceGridControl.RefreshDataSource();
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_data()
        {
            try
            {
              
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {



                    //Company 
                    var qryComp = (from c in context.Companies
                                   select new { c.CompanyID, c.CompanyCode }).ToList();
                    this.lookCompany.Properties.DataSource = qryComp;
                    this.lookCompany.Properties.ValueMember = "CompanyID";
                    this.lookCompany.Properties.DisplayMember = "CompanyCode";

                    //Location 
                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode }).ToList();
                    this.lookLocaiton.Properties.DataSource = qryLoc;
                    this.lookLocaiton.Properties.DisplayMember = "LocationCode";
                    this.lookLocaiton.Properties.ValueMember = "LocationID";

                    // Utility 
                    var qryUtility = (from u in context.Utilities
                                      select new { u.UtilityID, u.UtilityName }).ToList();
                    this.lookUtility.Properties.DataSource = qryUtility;
                    this.lookUtility.Properties.ValueMember = "UtilityID";
                    this.lookUtility.Properties.DisplayMember = "UtilityName";





                    // utility invoice 
                    this.utilityBindingSource.DataSource = (from u in context.Utilities
                                                            select new { u.UtilityID, u.UtilityName }).ToList();
                    //--


                    // sub invoice types
                    var qrySubInvT = (from si in context.Sub_Invoice_Types
                                      select si).ToList();
                    this.subInvoiceTypesBindingSource.DataSource = qrySubInvT;

                    // customers
                    var qryCust = (from gcus in context.Global_Customers
                                   select new { gcus.CustomerID, gcus.CustomerName }).ToList();
                    this.globalCustomersBindingSource.DataSource = qryCust;



                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        enum InvStatus
        {
            All,
            Confirmed,
            NotConfirmed
        };

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                
                using (AHPL_DBEntities context = new AHPL_DBEntities())
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
                                      where intSelected.Contains(i.InvoiceID)
                                      select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable, i.StartReading, i.EndReading, i.StartReading2, i.EndReading2, i.UtilityName, i.UtilityUnitRate, i.FooterText1, i.NosUnitsConsumed1, i.NosUnitsConsumed2, i.M_NosUnitsConsumed, i.IsUtilityTaxApplicable, i.Reset,i.UtilityMeterName }).ToList();


                    if (qryInvoice.Count == 0)
                    {
                        if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                        return;
                    }


                    rptMain reportMain = new rptMain();
                    //rptUtilityInvoice rptUtility = new rptUtilityInvoice();
                    rptUtility = new rptUtilityInvoice();

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

                    //var qryUtility = (from u in context.Utilities
                    //                  select new { u.UtilityID, u.UtilityName }).ToList();
                    int userId = 0;

                    if (withSignature)
                    {
                        userId = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    }
                    var prepairedSignature = (from usr in context.Permission_Users
                                              where usr.UserID == userId
                                              select new { usr.signature }
                                  );


                    rptUtility.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                    rptUtility.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                    rptUtility.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                    rptUtility.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                    rptUtility.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                    rptUtility.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                    rptUtility.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                    rptUtility.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                    rptUtility.Database.Tables["DataTier_Permission_Users"].SetDataSource(prepairedSignature);
                    rptUtility.SetParameterValue("pHeaderText", "");
                    rptUtility.SetParameterValue("pDetailText", "");

                    //rptUtility.Database.Tables["DataTier_Utility"].SetDataSource(qryUtility);

                    //rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);
                    reportMain.crystalReportViewer1.ReportSource = rptUtility;

                    reportMain.Show(this);
                    btnDirectPrintU.Enabled = true;
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void optRent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (optRent.SelectedIndex == 0) // confirmed 
            //{

            //    Load_data(InvStatus.Confirmed);
            //}
            //if (optRent.SelectedIndex == 1) // not confirmed
            //{
            //    Load_data(InvStatus.NotConfirmed);
            //}

            //if (optRent.SelectedIndex == 2) // all
            //{
            //    Load_data(InvStatus.All);
            //}

            load_Selected();

            btnDirectPrintU.Enabled = false;

            //getSelected();
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    if (splashScreenManager1.IsSplashFormVisible == false)
                    {
                        splashScreenManager1.ShowWaitForm();
                        splashScreenManager1.SetWaitFormDescription("Generating Utility Invoice(s)");
                    }

                    

                    var qrySelected = (from i in cGenInvList
                                       where i.Select == true
                                       select new { i.InvoiceID }).ToList();
                    List<int> intSelected = new List<int>();
                    foreach (var qry in qrySelected)
                    {
                        intSelected.Add(qry.InvoiceID);
                    }

                    rptMain reportMain = new rptMain();
                    rptUtilityInvSummary rptutilityInvSummary = new rptUtilityInvSummary();
                   

                    // List of invoices which selected in the grid
                    var qryInvoice = (from i in context.Invoices
                                      where intSelected.Contains(i.InvoiceID)
                                      select new
                                      {
                                          i.InvoiceID,
                                          i.InvoiceNo,
                                          i.InvoiceTypeID,
                                          i.SubInvTypeID,
                                          i.InvoiceDate,
                                          i.CustomerID,
                                          i.CustomerName,
                                          i.CustomerAddress,
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
                                          i.ShopName,
                                          i.IsTaxApplicable,
                                          i.StartReading,
                                          i.EndReading,
                                          i.StartReading2,
                                          i.EndReading2,
                                          i.UtilityName,
                                          i.UtilityUnitRate,
                                          i.FooterText1,
                                          i.NosUnitsConsumed1,
                                          i.NosUnitsConsumed2,
                                          i.M_NosUnitsConsumed,
                                          i.IsUtilityTaxApplicable,
                                          i.UtilityMeterName,
                                          i.LocationCode,
                                          i.CompanyCode,
                                          i.LevelName,
                                          i.M_StartReading,
                                          i.M_EndReading,
                                          i.TotalAmount,
                                          i.TotalNosUnitConsumed,
                                          i.OtherTaxCodes,
                                          i.RentPerMonth,
                                          i.Reset
                                      }).ToList();

                    rptutilityInvSummary.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);

                    string pMonthYear = MMS.CustomClasses.cCommon_Functions.getMonthAbbrName(this.dtMonthYear.DateTime.Month) + " - " + this.dtMonthYear.DateTime.Year.ToString();
                    string pUtility = this.lookUtility.Text.ToString().Trim();
                    rptutilityInvSummary.SetParameterValue("pMonthYear", pMonthYear);
                    rptutilityInvSummary.SetParameterValue("pUtility", pUtility);

                    reportMain.crystalReportViewer1.ReportSource = rptutilityInvSummary;

                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                    reportMain.Show(this);

                    #region added by ravindra 18-04-2019 print document

                    PrintDialog printdg = new PrintDialog();
                    printdg.AllowSomePages = true;
                    printdg.AllowPrintToFile = true;

                    if (printdg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rptutilityInvSummary.PrintOptions.PrinterName = printdg.PrinterSettings.PrinterName;
                        rptutilityInvSummary.PrintToPrinter(1, true, 0, 0);
                    }

                    printdg.Dispose();

                    //reportMain.crystalReportViewer1.ReportSource = rptutilityInvSummary;
                    //reportMain.Show(this);

                    //PrintDialog printdg = new PrintDialog();
                    //printdg.AllowSomePages = true;
                    //printdg.AllowPrintToFile = true;

                    //if (printdg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    //{
                    //    rptUtility.PrintOptions.PrinterName = printdg.PrinterSettings.PrinterName;
                    //    rptUtility.PrintToPrinter(1, true, 0, 0);
                    //}

                    //printdg.Dispose();
                    ////closing splash screen
                    //if (splashScreenManager1.IsSplashFormVisible == true)
                    //{
                    //    splashScreenManager1.CloseWaitForm();
                    //}

                    #endregion
                }

            }
            catch (Exception ex)
            {
                //closing splash screen
                if (splashScreenManager1.IsSplashFormVisible == true)
                {
                    splashScreenManager1.CloseWaitForm();
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSelectAll.Checked == true)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookLocaiton_EditValueChanged(object sender, EventArgs e)
        {
            if (chkShowAllInv.Checked)
            {
                load_Selected();
                btnDirectPrintU.Enabled = false;
            }
        }

        private void getSelected()
        {
            bool res = false;
            int locid = 0;
            int compid = 0;

            res = int.TryParse(this.lookCompany.EditValue.ToString(), out compid);
            if (res == false) { compid = 0; }

            res = int.TryParse(this.lookLocaiton.EditValue.ToString(), out locid);
            if (res == false) { locid = 0; }

            int month = dtMonthYear.DateTime.Month;
            int year = dtMonthYear.DateTime.Year;

            int utilityId = 0;
            if (string.IsNullOrEmpty(this.lookUtility.Text.ToString())) { return; }
            res = int.TryParse(this.lookUtility.EditValue.ToString(), out utilityId);
            if (res == false) { utilityId = 0; }




            if (compid > 0 && locid > 0 & utilityId > 0)
            {
                var qrySelected = (from c in cGenInvList
                                   where c.CompanyID == compid && c.LocationID == locid && c.ProcessMonth == month && c.ProcessYear == year && c.UtilityID == utilityId
                                   select c).ToList();
                foreach (var qry in qrySelected)
                {
                    qry.Select = true;
                }

            }

            this.cGen_Rent_InvoiceGridControl.RefreshDataSource();


        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (chkShowAllInv.Checked)
            {
                load_Selected();
                btnDirectPrintU.Enabled = false;
            }

            //// Location..roshan..06oct2014
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                int comid = 0;
                bool res = false;
                res = int.TryParse(lookCompany.EditValue.ToString(), out comid);

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

            btnDirectPrintU.Enabled = false;
        }

        private void lookUtility_EditValueChanged(object sender, EventArgs e)
        {
            if (chkShowAllInv.Checked)
            {
                load_Selected();

                btnDirectPrintU.Enabled = false;
            }
        }

        private void cGen_Rent_InvoiceGridControl_Click(object sender, EventArgs e)
        {

        }

        private void dtMonthYear_2_EditValueChanged(object sender, EventArgs e)
        {
            load_Selected();

            btnDirectPrintU.Enabled = false;
        }

        private void chkShowAllInv_CheckedChanged(object sender, EventArgs e)
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

        private void btnPrintSummaryWG_Click(object sender, EventArgs e)
        {
            //// Add new report without grouping option(for current report)..roshan..27July2015

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    if (splashScreenManager1.IsSplashFormVisible == false)
                    {
                        splashScreenManager1.ShowWaitForm();
                        splashScreenManager1.SetWaitFormDescription("Generating Utility Invoice(s)");
                    }

                    rptMain reportMain = new rptMain();
                    rptUtilityInvSummaryWithoutGrouping rptutilityInvSummary = new rptUtilityInvSummaryWithoutGrouping();
                    reportMain.crystalReportViewer1.ReportSource = rptutilityInvSummary;

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
                                          i.InvoiceID,
                                          i.InvoiceNo,
                                          i.InvoiceTypeID,
                                          i.SubInvTypeID,
                                          i.InvoiceDate,
                                          i.CustomerID,
                                          i.CustomerName,
                                          i.CustomerAddress,
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
                                          i.ShopName,
                                          i.IsTaxApplicable,
                                          i.StartReading,
                                          i.EndReading,
                                          i.StartReading2,
                                          i.EndReading2,
                                          i.UtilityName,
                                          i.UtilityUnitRate,
                                          i.FooterText1,
                                          i.NosUnitsConsumed1,
                                          i.NosUnitsConsumed2,
                                          i.M_NosUnitsConsumed,
                                          i.IsUtilityTaxApplicable,
                                          i.UtilityMeterName,
                                          i.LocationCode,
                                          i.CompanyCode,
                                          i.LevelName,
                                          i.M_StartReading,
                                          i.M_EndReading,
                                          i.TotalAmount,
                                          i.TotalNosUnitConsumed,
                                          i.OtherTaxCodes,
                                          i.RentPerMonth,
                                          i.Reset
                                      }).ToList();

                    rptutilityInvSummary.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);

                    string pMonthYear = MMS.CustomClasses.cCommon_Functions.getMonthAbbrName(this.dtMonthYear.DateTime.Month) + " - " + this.dtMonthYear.DateTime.Year.ToString();
                    string pUtility = this.lookUtility.Text.ToString().Trim();
                    rptutilityInvSummary.SetParameterValue("pMonthYear", pMonthYear);
                    rptutilityInvSummary.SetParameterValue("pUtility", pUtility);

                    reportMain.Show(this);

                    //closing splash screen
                    if (splashScreenManager1.IsSplashFormVisible == true)
                    {
                        splashScreenManager1.CloseWaitForm();
                    }
                }

            }
            catch (Exception ex)
            {
                //closing splash screen
                if (splashScreenManager1.IsSplashFormVisible == true)
                {
                    splashScreenManager1.CloseWaitForm();
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDirectPrintU_Click(object sender, EventArgs e)
        {
            btnPrint_Click(null, null);
            DialogResult dlg = MessageBox.Show("Are you sure, you want to print the previewed utility invoicess ?", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            else
            {
                if (rptUtility != null)
                {
                   
                    PrintDialog printdg = new PrintDialog();
                    printdg.AllowSomePages = true;
                    printdg.AllowPrintToFile = true;

                    if (printdg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rptUtility.PrintOptions.PrinterName = printdg.PrinterSettings.PrinterName;
                        rptUtility.PrintToPrinter(1, true, 0, 0);
                    }

                    printdg.Dispose();





                   // rptUtility.PrintToPrinter(1, true, 0, 0);////For fix logo missing issue
                }
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