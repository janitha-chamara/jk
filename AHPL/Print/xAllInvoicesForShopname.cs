using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using System.Data.Entity;
using DataTier;
using System.Linq.Expressions;
using System.Linq;
using DataTier.Reports.Rent;
using System.Configuration;
using DataTier.Reports.Utility;
using DataTier.Reports.OtherService;

namespace MMS.Print
{
    public partial class xAllInvoicesForShopname : Form
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<cGen_Rent_Invoice> cGenList = new List<cGen_Rent_Invoice>();
        bool saveToDisk = false;
        bool withSignature = false;
        public xAllInvoicesForShopname()
        {
            InitializeComponent();
            loadData();

        }

        private void loadData()
        {


            // Company 
            var qryCom = (from c in context.Companies
                          select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
            companyBindingSource.DataSource = qryCom;


            dateEditMonthYear.DateTime = DateTime.Now.Date;
            dateEditTo.DateTime = DateTime.Now.Date;

            dateEditMonthYear.DateTime = DateTime.Now.Date;
            dateEditTo.DateTime = DateTime.Now.Date;

            

        }

        private void searchLookUpShopNo_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditMonthYear.Text.ToString()))
            {
                return;
            }

            int contclauseid = 0;
            int shopId = 0;
            int cusId = 0;
            int processMonth = 0;
            int processYear = 0;

            int processMonthTo = 0;
            int processYearTo = 0;

            DateTime? fromDate = dateEditMonthYear.DateTime;
            DateTime? todate = dateEditTo.DateTime;

            bool res = false;

            //res = int.TryParse(this.searchLookUpShopNo.EditValue.ToString(), out shopId);
            res = int.TryParse(this.searchLookUpShopNo.EditValue.ToString(), out cusId);
            if (res == false)
            {
                //contclauseid = 0;
                shopId = 0;
                return;
            }

            processYear = dateEditMonthYear.DateTime.Year;
            processMonth = dateEditMonthYear.DateTime.Month;

            processYearTo = dateEditTo.DateTime.Year;
            processMonthTo = dateEditTo.DateTime.Month;


            var qryinv = (from inv in context.Invoices
                          where inv.CustomerID == cusId && inv.InvoiceDate >= fromDate && inv.InvoiceDate <= todate
                          select inv).ToList();

            

            cGenList.Clear();
            foreach (var qry in qryinv)
            {
                cGen_Rent_Invoice oGenInv = new cGen_Rent_Invoice();
                oGenInv.SequenceNo = qry.SequenceNo;
                oGenInv.InvoiceNo = qry.InvoiceNo;
                oGenInv.InvoiceID = qry.InvoiceID;
                oGenInv.InvoiceTypeID = qry.InvoiceTypeID;
                oGenInv.SubInvTypeID = qry.SubInvTypeID;
                oGenInv.CompanyID = qry.CompanyID;
                oGenInv.CompanyCode = qry.CompanyCode;
                oGenInv.LocationID = qry.LocationID;
                oGenInv.LocationCode = qry.LocationCode;
                oGenInv.LevelID = qry.LevelID;
                oGenInv.LevelCode = qry.LevelName;
                oGenInv.InvDate = qry.InvoiceDate;
                oGenInv.Confirm = false;/////Do not set this value to true, this field is used to selection
                oGenInv.CustomerID = qry.CustomerID;
                oGenInv.ShopName = qry.ShopName;
                oGenInv.TotalRent = qry.TotalRentPerMonth;

                if (oGenInv.SequenceNo > 0)
                {
                    oGenInv.IsInvoiceNoGenerated = true;
                }
                else
                {
                    oGenInv.IsInvoiceNoGenerated = false;
                }

                cGenList.Add(oGenInv);
            }

            //this.invoiceBindingSource.DataSource = cGenList;
            InvoiceBindingSource.DataSource = cGenList;
            this.gvAllInvoicess.RefreshDataSource();
        }

        private void dateEditMonthYear_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditMonthYear.Text.ToString()))
            {
                return;
            }

            int contclauseid = 0;
            int shopId = 0;
            int cusId = 0;
            int processMonth = 0;
            int processYear = 0;

            int processMonthTo = 0;
            int processYearTo = 0;

            bool res = false;
            //res = int.TryParse(this.searchLookUpShopNo.EditValue.ToString(), out contclauseid);
            res = int.TryParse(this.searchLookUpShopNo.EditValue.ToString(), out cusId);
            if (res == false)
            {
                //contclauseid = 0;
                shopId = 0;
                return;
            }

            processYear = dateEditMonthYear.DateTime.Year;
            processMonth = dateEditMonthYear.DateTime.Month;

            processYearTo = dateEditTo.DateTime.Year;
            processMonthTo = dateEditTo.DateTime.Month;

            DateTime? fromDate = dateEditMonthYear.DateTime;
            DateTime? todate = dateEditTo.DateTime;

            ////var qryinv = (from inv in context.Invoices
            ////              where inv.ContractClosureID == contclauseid && inv.ProcessMonth == processMonth && inv.ProcessYear == processYear
            ////              select inv).ToList();
            int ComId=int.Parse(lookCompany.EditValue.ToString());
            int LocId=int.Parse(lookLocation.EditValue.ToString());

            var qryinv = (from inv in context.Invoices
                          where inv.CustomerID == cusId && inv.InvoiceDate >= fromDate && inv.InvoiceDate <= todate 
                          && inv.IsConfirmed==true && inv.LocationID==LocId && inv.CompanyID==ComId
                          select inv).ToList();

            

            cGenList.Clear();
            foreach (var qry in qryinv)
            {
                cGen_Rent_Invoice oGenInv = new cGen_Rent_Invoice();
                oGenInv.SequenceNo = qry.SequenceNo;
                oGenInv.InvoiceNo = qry.InvoiceNo;
                oGenInv.InvoiceID = qry.InvoiceID;
                oGenInv.InvoiceTypeID = qry.InvoiceTypeID;
                oGenInv.SubInvTypeID = qry.SubInvTypeID;
                oGenInv.CompanyID = qry.CompanyID;
                oGenInv.CompanyCode = qry.CompanyCode;
                oGenInv.LocationID = qry.LocationID;
                oGenInv.LocationCode = qry.LocationCode;
                oGenInv.LevelID = qry.LevelID;
                oGenInv.LevelCode = qry.LevelName;
                oGenInv.InvDate = qry.InvoiceDate;
                oGenInv.Confirm = false;
                oGenInv.CustomerID = qry.CustomerID;
                oGenInv.ShopName = qry.ShopName;
                oGenInv.TotalRent = qry.TotalRentPerMonth;
                if (oGenInv.SequenceNo > 0)
                {
                    oGenInv.IsInvoiceNoGenerated = true;
                }
                else
                {
                    oGenInv.IsInvoiceNoGenerated = false;
                }

                cGenList.Add(oGenInv);
            }

           // invoiceBindingSource.DataSource = cGenList;
            InvoiceBindingSource.DataSource = cGenList;
            this.gvAllInvoicess.RefreshDataSource();
        }

        private void dateEditTo_EditValueChanged(object sender, EventArgs e)
        {
            dateEditMonthYear_EditValueChanged(null, null);
        }

        public string AddInvoice(int invoiceId)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                rptMain _main = new rptMain();
                rptRent_Invoice rptrentInv = new rptRent_Invoice();

                var qryInvoice = (from i in context.Invoices
                                  join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
                                  orderby lvl.StdOrder ascending
                                  where i.InvoiceID == invoiceId
                                  select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable, i.Naration }).ToList();

                /// Report generation
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
                rptrentInv.Database.Tables["DataTier_Permission_Users"].SetDataSource(prepairedSignature);
                rptrentInv.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                rptrentInv.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                rptrentInv.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                rptrentInv.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                rptrentInv.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                rptrentInv.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                rptrentInv.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                rptrentInv.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                rptrentInv.SetParameterValue("pHeaderText", "COPY");
                rptrentInv.SetParameterValue("pDetailText", "This is a computer generated copy. Signature is not required"); // for the time being it will be fixed , or it should come from a table which has definable text???
                //rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);

                _main.crystalReportViewer1.ReportSource = rptrentInv;

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                if (saveToDisk) { _main.Show(); }

                string invoiceNo = qryInvoice.First().InvoiceNo.Replace('/', '-');
                string pdfFile = null;

                //savefile dialog
                if (saveToDisk)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = "C:\\";
                    saveFileDialog1.Title = "Save Files";
                  //  saveFileDialog1.CheckFileExists = true;
                  //  saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.DefaultExt = "pdf";
                    saveFileDialog1.Filter = "pdf files (*.pdf)|*.txt|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.FileName = invoiceNo;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pdfFile = saveFileDialog1.FileName;
                    }

                }
                else
                     pdfFile = "C:\\MMS_files\\" + invoiceNo + ".pdf";


                 
                
                rptrentInv.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfFile);
                rptrentInv.Close();
                rptrentInv.Dispose();
                return pdfFile;

            }
        }

        public string AddUtilityInvoice(int invoiceId)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print - Utility Invoice");
                }

                // List of invoices which selected in the grid
                var qryInvoice = (from i in context.Invoices
                                  where i.InvoiceID == invoiceId
                                  select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable, i.StartReading, i.EndReading, i.StartReading2, i.EndReading2, i.UtilityName, i.UtilityUnitRate, i.FooterText1, i.NosUnitsConsumed1, i.NosUnitsConsumed2, i.M_NosUnitsConsumed, i.IsUtilityTaxApplicable, i.Reset }).ToList();





                rptMain reportMain = new rptMain();
                rptUtilityInvoice rptUtility = new rptUtilityInvoice();

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
                rptUtility.Database.Tables["DataTier_Permission_Users"].SetDataSource(prepairedSignature);
                rptUtility.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                rptUtility.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                rptUtility.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                rptUtility.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                rptUtility.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                rptUtility.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                rptUtility.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                rptUtility.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                rptUtility.SetParameterValue("pHeaderText", "COPY");
                rptUtility.SetParameterValue("pDetailText", "This is a computer generated copy. Signature is not required"); // for the time being it will be fixed , or it should come from a table which has definable text???

                reportMain.crystalReportViewer1.ReportSource = rptUtility;
                if (saveToDisk)
                {
                    reportMain.Show(this);
                }
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                string invoiceNo = qryInvoice.First().InvoiceNo.Replace('/', '-');
                string pdfFile = null;//ConfigurationManager.AppSettings["OutLookEmailPath"] + invoiceNo + ".pdf";

                  if (saveToDisk)
                  {
                      SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                      saveFileDialog1.InitialDirectory = "C:\\";
                      saveFileDialog1.Title = "Save Files";
                     // saveFileDialog1.CheckFileExists = true;
                      //saveFileDialog1.CheckPathExists = true;
                      saveFileDialog1.DefaultExt = "pdf";
                      saveFileDialog1.Filter = "pdf files (*.pdf)|*.txt|All files (*.*)|*.*";
                      saveFileDialog1.FilterIndex = 2;
                      saveFileDialog1.FileName = invoiceNo;
                      saveFileDialog1.RestoreDirectory = true;
                      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                      {
                          pdfFile = saveFileDialog1.FileName;
                      }

                  }
                  else
                      pdfFile = "C:\\MMS_files\\" + invoiceNo + ".pdf";


                //string pdfFile = "C:\\MMS_files\\" + invoiceNo + ".pdf";
                rptUtility.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfFile);
                rptUtility.Close();
                rptUtility.Dispose();
                return pdfFile;
            }
        }

        public string AddServiceInvoice(int invoiceId)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                // List of invoices which selected in the grid
                var qryInvoice = (from i in context.Invoices
                                  where i.InvoiceID == invoiceId
                                  select new { i.OtherServiceID, i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.Naration, i.CustomerAddress2, i.IsTaxApplicable }).ToList();


                /// Report generation
                rptMain _main = new rptMain();
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
                rptOtherSInv.Database.Tables["DataTier_Permission_Users"].SetDataSource(prepairedSignature);
                rptOtherSInv.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                rptOtherSInv.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                rptOtherSInv.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                rptOtherSInv.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                rptOtherSInv.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                rptOtherSInv.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                rptOtherSInv.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                rptOtherSInv.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                rptOtherSInv.Database.Tables["DataTier_OtherServiceCategory"].SetDataSource(qryOtherS);
                rptOtherSInv.SetParameterValue("pHeaderText", "COPY");
                rptOtherSInv.SetParameterValue("pDetailText", "This is a computer generated copy. Signature is not required"); // for the time being it will be fixed , or it should come from a table which has definable text???

                _main.crystalReportViewer1.ReportSource = rptOtherSInv;

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                
                


                ////10July2014..to add attachments to outlook
                string invoiceNo = qryInvoice.First().InvoiceNo.Replace('/', '-');
                string pdfFile = null;//ConfigurationManager.AppSettings["OutLookEmailPath"] + invoiceNo + ".pdf";
                //string pdfFile = "C:\\MMS_files\\" + invoiceNo + ".pdf";
                 if (saveToDisk)
                 {
                     _main.Show(this);
                     SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                     saveFileDialog1.InitialDirectory = "C:\\";
                     saveFileDialog1.Title = "Save Files";
                     //saveFileDialog1.CheckFileExists = true;
                     //saveFileDialog1.CheckPathExists = true;
                     saveFileDialog1.DefaultExt = "pdf";
                     saveFileDialog1.Filter = "pdf files (*.pdf)|*.txt|All files (*.*)|*.*";
                     saveFileDialog1.FilterIndex = 2;
                     saveFileDialog1.FileName = invoiceNo;
                     saveFileDialog1.RestoreDirectory = true;
                     if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                     {
                         pdfFile = saveFileDialog1.FileName;
                     }

                 }
                 else
                     pdfFile = "C:\\MMS_files\\" + invoiceNo + ".pdf";


                rptOtherSInv.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfFile);
                rptOtherSInv.Close();
                rptOtherSInv.Dispose();
                return pdfFile;
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print - Rent Invoice");
                }

                Cursor.Current = Cursors.WaitCursor;
                var qrySelected = (from i in cGenList
                                   where i.Confirm == true
                                   select new { i.InvoiceID, i.InvoiceTypeID }).ToList();
                List<int> intSelected = new List<int>();
                List<string> pdflist = new List<string>();
                int loCId = int.Parse(lookLocation.EditValue.ToString());
                int custId = int.Parse(this.searchLookUpShopNo.EditValue.ToString());
                //add curent user
                pdflist.Add(loCId.ToString() + ";" + custId.ToString() + ";" + MMS.CustomClasses.cCommon_Functions.LoggedUserID.ToString());
               // Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                //Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                string pdfFile = string.Empty;
                foreach (var qry in qrySelected)
                {
                    switch (qry.InvoiceTypeID)
                    {
                        case 1:
                            pdfFile = AddInvoice(qry.InvoiceID);
                            break;
                        case 2:
                            pdfFile = AddUtilityInvoice(qry.InvoiceID);
                            break;
                        case 3:
                            pdfFile = AddServiceInvoice(qry.InvoiceID);
                            break;
                    }
                    if (!string.IsNullOrEmpty(pdfFile))
                    { pdflist.Add(pdfFile); }
                    else
                    { return; }
                   // oMailItem.Attachments.Add(pdfFile, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                    ////body, To,CC,bcc etc...
                }
                Cursor.Current = Cursors.Default;
                if (!saveToDisk)
                {
                    
                    bool complete = MMS.CustomClasses.cCommon_Functions.writeToTextfile(pdflist);
                    if (complete)
                    {
                        System.Diagnostics.Process.Start("SMTP.exe");
                    }
                    //frmsendEmails frmemail = new frmsendEmails(pdflist, loCId,cust_id);
                    //frmemail.Show();
                }
                




                // added by ravindra on 18-04-2019
                //check whether save file to disk [ SaveToDisk==true -> email function won't process]
                //if (!saveToDisk)
                //{
                //    Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                //    Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //    foreach (var fls in pdflist)
                //    {
                //        oMailItem.Attachments.Add(fls, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                //    }
                //    oMailItem.Display(true);
                //}

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Email Client already open,please Close them all" + ex.ToString());
                //throw ex;
            }
        }

        private void btnPrintSave_Click(object sender, EventArgs e)
        {
            saveToDisk = true;
            try
            {
                btnPrintAll_Click(null, null);
                MessageBox.Show("Invoice(s) saved successfully");
                saveToDisk = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


            }
        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
        {
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

        private void lookLocation_EditValueChanged(object sender, EventArgs e)
        {
            int loCId = int.Parse(lookLocation.EditValue.ToString());
            int CompId = int.Parse(lookCompany.EditValue.ToString());


            var qrycontract = (from c in context.ContractClosures
                               join comp in context.Companies on c.CompanyID equals comp.CompanyID
                               join cust in context.Extended_Customers on c.ExtendedCustomerID equals cust.ExtendedCustomerID
                               join gcust in context.Global_Customers on cust.CustomerID equals gcust.CustomerID
                               join loc in context.Locations on c.LocationID equals loc.LocationID
                               where c.IsPromotion == false && c.IsProcessed == true && c.IsActive == true && c.CompanyID == CompId && c.LocationID == loCId
                               orderby comp.CompanyID, loc.LocationID, c.ShopNo
                               select new { c.ContractClosureID, comp.CompanyCode, loc.LocationCode, c.ShopName, c.ShopNo, c.ShopID, gcust.CustomerName, gcust.CustomerID }).ToList();

            ////select new { c.ContractClosureID, comp.CompanyCode, loc.LocationCode, c.ShopName, c.ShopNo, gcust.CustomerName, c.IsTerminated, c.IsRenew }).ToList();

            searchLookUpShopNo.Properties.DataSource = qrycontract;
            searchLookUpShopNo.Properties.DisplayMember = "CustomerName";
            searchLookUpShopNo.Properties.ValueMember = "CustomerID";
            searchLookUpEdit1View.BestFitColumns();

        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                chkSelectAll.Text = "Unselect All";
                foreach (var qry in cGenList)
                {
                    qry.Confirm = true;
                }
                gvAllInvoicess.RefreshDataSource();
            }
            else
            {
                chkSelectAll.Text = "Select All";
                foreach (var qry in cGenList)
                {
                    qry.Confirm = false;
                }
                gvAllInvoicess.RefreshDataSource();
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

        private void xAllInvoicesForShopname_Load(object sender, EventArgs e)
        {

        }
    }
}
