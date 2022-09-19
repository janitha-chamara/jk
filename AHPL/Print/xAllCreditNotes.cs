using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTier;
using DataTier.Reports.Rent;
using System.Configuration;

namespace MMS.Print
{
    public partial class xAllCreditNotes : Form
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<cGen_Rent_Invoice> cGenList = new List<cGen_Rent_Invoice>();
        List<cGen_Rent_Invoice> cGenInvList = new List<cGen_Rent_Invoice>();
        private rptRent_Invoice rptrentInv;
        bool IsEmail = false;
        bool withSignature = false;
        int cust_id;
        public xAllCreditNotes()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var qryCom = (from c in context.Companies
                          select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
            companyBindingSource.DataSource = qryCom;
        }

        private void dateEditFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
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


            processYear = dateEditFrom.DateTime.Year;
            processMonth = dateEditFrom.DateTime.Month;

            processYearTo = dateEditTo.DateTime.Year;
            processMonthTo = dateEditTo.DateTime.Month;

            DateTime? fromDate = dateEditFrom.DateTime;
            DateTime? todate = dateEditTo.DateTime;

            int LocId = int.Parse(lookLocation.EditValue.ToString());
            int ComId = int.Parse(lookCompany.EditValue.ToString());


            var qryinv = (from inv in context.Invoices
                          where inv.SubInvTypeID == 2 && inv.InvoiceDate >= fromDate && inv.InvoiceDate <= todate && inv.IsConfirmed == true 
                          && inv.LocationID == LocId && inv.CompanyID == ComId
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

            this.invoiceBindingSource.DataSource = cGenList;
            this.gvAllInvoicess.RefreshDataSource();

            if (cGenList.Count > 0)
            {

                chkSelectAll.Enabled = true;
            }
            else
            {
                chkSelectAll.Enabled = false;
            
            }
            
        }

        private void dateEditTo_EditValueChanged(object sender, EventArgs e)
        {
            dateEditFrom_EditValueChanged(null, null);
            btnPrint.Enabled = true;
            btnPrintAll.Enabled = true;
        }

        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print - Credit Note");
                }


                var qrySelected = (from i in cGenList
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
                rptrentInv.SetParameterValue("pDetailText", "This is a computer generated copy. Signature is not required");
                //rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);

                _main.crystalReportViewer1.ReportSource = rptrentInv;

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                
                string pdf = ExportToPdf(qryInvoice.First().InvoiceNo);
                if (!string.IsNullOrEmpty(pdf))
                {
                    _main.Refresh();
                    _main.Show();
                }
                else
                { return; }
              

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region added by ravindra on 08-05-2019 - save file
        public string ExportToPdf(string InvNo)
        {


            string invoiceNo = InvNo.Replace('/', '-');
            string pdfFile = null;
           //save file to selected location
            if (!IsEmail)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = "C:\\";
                saveFileDialog1.Title = "Save Files";
                saveFileDialog1.DefaultExt = "pdf";
                saveFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.FileName = invoiceNo;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pdfFile = saveFileDialog1.FileName;
                    rptrentInv.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfFile);
                    MessageBox.Show("Invoice Save Successfull");
                }
                else
                { return null; }

            }
            else
            {
                pdfFile = "C:\\MMS_files\\" + invoiceNo + ".pdf";
            }
               // pdfFile = ConfigurationManager.AppSettings["OutLookEmailPath"] + invoiceNo + ".pdf";}
            rptrentInv.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfFile);

            return pdfFile;

        }
        #endregion 

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                IsEmail = true;

                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print - Credit Note");
                }


                var qrySelected = (from i in cGenList
                                   where i.Select == true
                                   select new { i.InvoiceID }).ToList();
                List<int> intSelected = new List<int>();
                List<string> pdflist = new List<string>(); 
                string pdfFile = string.Empty;
                int loCId = int.Parse(lookLocation.EditValue.ToString());
              
                //add curent user
                pdflist.Add(loCId.ToString() + ";" + cust_id.ToString() + ";" + MMS.CustomClasses.cCommon_Functions.LoggedUserID.ToString());
                
                foreach (var qry in qrySelected)
                {
                    pdfFile = generateInvoice(qry.InvoiceID);
                    if (!string.IsNullOrEmpty(pdfFile))
                    { pdflist.Add(pdfFile); }
                    else
                    { return; }
                    //intSelected.Add(qry.InvoiceID);
                }
               
                bool complete = MMS.CustomClasses.cCommon_Functions.writeToTextfile(pdflist);
                Cursor.Current = Cursors.Default;
                if (complete)
                {
                    System.Diagnostics.Process.Start("SMTP.exe");
                }
                //frmsendEmails frmemail = new frmsendEmails(pdflist, loCId,cust_id);
                //frmemail.Show();

                //// List of invoices which selected in the grid
                //var qryInvoice = (from i in context.Invoices
                //                  join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
                //                  orderby lvl.StdOrder ascending
                //                  where intSelected.Contains(i.InvoiceID)
                //                  select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable, i.Naration, i.FooterText1 }).ToList();


                //if (qryInvoice.Count == 0)
                //{
                //    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                //    return;
                //}


                ///// Report generation
                //rptMain _main = new rptMain();


                //rptrentInv = new rptRent_Invoice();

                //var qryInvDet = (from invdet in context.Invoice_Details
                //                 join t in context.Taxes on invdet.TaxID equals t.TaxID
                //                 where t.IsMandatory == false
                //                 select new { invdet.Amount, invdet.InvoiceDetailID, invdet.InvoiceID, invdet.IsPrint, invdet.TaxCode, invdet.TaxID, invdet.TaxRate }).ToList();

                //var qryCompany = (from c in context.Companies
                //                  select new { c.CompanyCode, c.CompanyID, c.DefaultTaxRegNo, c.CompanyName, c.Tele1, c.Tele2, c.Fax, c.Address, c.BusinessRegNo, c.InvoiceFooterText1, c.InvoiceFooterText2 }).ToList();

                //var qryMonth = (from m in context.Months
                //                select m).ToList();

                //var qryTax = (from t in context.Taxes
                //              select new { t.TaxID, t.TaxCode, t.IsMandatory }).ToList();

                //var qryLocaiton = (from l in context.Locations
                //                   select new { l.LocationID, l.LocationName, l.Logo, l.Address }).ToList();


                //var qryInvType = (from it in context.Invoice_Types
                //                  select new { it.InvoiceTypeID, it.InvoiceTypeName }).ToList();

                //var qrySubInvType = (from sit in context.Sub_Invoice_Types
                //                     select new { sit.SubInvTypeID, sit.SubInvTypeName }).ToList();

                //int userId = 0;

                //if (withSignature)
                //{
                //    userId = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                //}
                //var prepairedSignature = (from usr in context.Permission_Users
                //                          where usr.UserID == userId
                //                          select new { usr.signature }
                //              );
                //rptrentInv.Database.Tables["DataTier_Permission_Users"].SetDataSource(prepairedSignature);
                //rptrentInv.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                //rptrentInv.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                //rptrentInv.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                //rptrentInv.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                //rptrentInv.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                //rptrentInv.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                //rptrentInv.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                //rptrentInv.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);

                //rptrentInv.SetParameterValue("pHeaderText", "");
                //rptrentInv.SetParameterValue("pDetailText", "");
                ////rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);

                //_main.crystalReportViewer1.ReportSource = rptrentInv;

                //if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                //_main.Refresh();
                //if (!IsEmail)
                //{
                //    _main.Show();
                //}
                //else
                //{

                //    //Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                //    //Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //    //oMailItem.Attachments.Add(ExportToPdf(qryInvoice.First().InvoiceNo), Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                //    //oMailItem.Display(true);
                //}

                //IsEmail = false;

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string generateInvoice(int invoiceId)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities()) {
                
                rptMain _main = new rptMain();
                rptrentInv = new rptRent_Invoice();
                // List of invoices which selected in the grid
                //var qryInvoice = (from i in context.Invoices
                //                  join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
                //                  orderby lvl.StdOrder ascending
                //                  where i.InvoiceID == i.InvoiceID
                //                  select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable, i.Naration, i.FooterText1 }).ToList();
                
                var qryInvoice = (from i in context.Invoices
                                  join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
                                  orderby lvl.StdOrder ascending
                                  where i.InvoiceID == invoiceId
                                  select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable, i.Naration, i.FooterText1 }).ToList();

                cust_id = qryInvoice[0].CustomerID;
               

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
                rptrentInv.SetParameterValue("pDetailText", "This is a computer generated copy. Signature is not required");
                //rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);

                _main.crystalReportViewer1.ReportSource = rptrentInv;

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                string invoiceNo = qryInvoice.First().InvoiceNo.Replace('/', '-');
                string pdfFile = null;
                
                pdfFile = "C:\\MMS_files\\" + invoiceNo + ".pdf";
                rptrentInv.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfFile);
                rptrentInv.Close();
                rptrentInv.Dispose();
                IsEmail = false;
                return pdfFile;

                ////_main.Refresh();
                //if (!IsEmail)
                //{
                //    _main.Show();
                //}
                //else
                //{

                //    //Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                //    //Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //    //oMailItem.Attachments.Add(ExportToPdf(qryInvoice.First().InvoiceNo), Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                //    //oMailItem.Display(true);
                //}

                
              
            
            
            
            }
             
        }
        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

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

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                chkSelectAll.Text = "Unselect All";
                foreach (var qry in cGenList)
                {
                    qry.Select = true;
                }
                gvAllInvoicess.RefreshDataSource();
            }
            else
            {
                chkSelectAll.Text = "Select All";
                foreach (var qry in cGenList)
                {
                    qry.Select = false;
                }
                gvAllInvoicess.RefreshDataSource();
            }
        }

        private void lookLocation_EditValueChanged(object sender, EventArgs e)
        {

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
