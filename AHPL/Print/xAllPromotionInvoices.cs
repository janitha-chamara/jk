using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTier;
using Outlook = Microsoft.Office.Interop.Outlook;
using DataTier.Reports.OtherService;
using System.Configuration;

namespace MMS.Print
{
     
    public partial class xAllPromotionInvoices : Form
    {

        // by raindra 
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<cPromotionInvoice> cProList = new List<cPromotionInvoice>();
        bool IsEmail = false;
        bool withSignature = false;
        int cust_id;
        public xAllPromotionInvoices()
        {
            InitializeComponent();
            load_data();
        }

        private void load_data()
        {
            try
            {
                //load companies
                var qryCom = (from c in context.Companies
                              select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
                companyBindingSource.DataSource = qryCom;


                
                dateEditTo.DateTime = DateTime.Now.Date;
                dateEditTo.DateTime = DateTime.Now.Date;


                
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

                int invoiceid = 0;
                //bool res = false;
                //res = int.TryParse(searchLookUpEdit1.EditValue.ToString(), out invoiceid);
                var qrySelected = (from i in cProList
                                   where i.Select == true
                                   select new { i.InvoiceID }).ToList();
                List<int> intSelected = new List<int>();
                foreach (var qry in qrySelected)
                {
                    intSelected.Add(qry.InvoiceID);
                }


                // if (res == false) { invoiceid = 0; }
                if (intSelected.Count <= 0)
                {
                    MessageBox.Show("Invalid Invoice No", "Invalid Invoice No - Invoice Draft Printing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print");
                }
                string pdfFile = null;
                
                   // Microsoft.Office.Interop.Outlook.Application oApp = new Outlook.Application();
                    //Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                
                

                foreach (var invid in qrySelected)
                {

                    pdfFile = generateinvoice(invid.InvoiceID);
                    if (string.IsNullOrEmpty(pdfFile))
                        return;

                    //oMailItem.Attachments.Add(pdfFile, Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                }

                if (string.IsNullOrEmpty(pdfFile))
                { return; }
               
               // if (IsEmail) { oMailItem.Display(true); }


            }

            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string generateinvoice(int invoiceid)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                // List of invoices which selected in the grid
                var qryInvoice = (from i in context.Invoices
                                  where i.InvoiceID == invoiceid
                                  select new
                                  {
                                      i.OtherServiceID, i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID,i.SubInvTypeID,i.InvoiceDate,
                                      i.CustomerID,i.CustomerName,i.CustomerAddress,i.DateFrom,i.DateTo,i.TotalRentPerMonth,i.MandatoryTaxAmount,
                                      i.TotalWithMandatoryTax,i.OtherTax,i.TaxRegNo,i.SAP_DocHeaderText,i.IsTaxCustomer,i.MandatoryTaxCode,
                                      i.ProcessMonth,i.ProcessYear,i.ShopNo,i.CompanyID,i.LocationID,i.Naration,i.CustomerAddress2,i.IsTaxApplicable
                                  }).ToList();



                cust_id = qryInvoice[0].CustomerID;
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

                if (!IsEmail)
                {   _main.Show(this);  }



                string invoiceNo = qryInvoice.First().InvoiceNo.Replace('/', '-');
              //   string pdfFile = ConfigurationManager.AppSettings["OutLookEmailPath"] + invoiceNo + ".pdf";
                string pdfFile = null;

                if (!IsEmail)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = "C:\\MMS_files\\";
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
                        MessageBox.Show("Invoice Save Successfull");
                    }
                    else
                    { return null; }
                }
                else
                {
                    pdfFile = "C:\\MMS_files\\" + invoiceNo + ".pdf";
                }
               
                rptOtherSInv.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfFile);
                rptOtherSInv.Close();
                rptOtherSInv.Dispose();
                //if (!IsEmail)

                //{
                //    MessageBox.Show("Invoice : " + pdfFile + " , Save Successfull");
                //}
                return pdfFile;
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {

           
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                IsEmail = true;
                var qrySelected = (from i in cProList
                                   where i.Select == true
                                   select new { i.InvoiceID }).ToList();
                List<int> intSelected = new List<int>();
                foreach (var qry in qrySelected)
                {
                    intSelected.Add(qry.InvoiceID);
                    
                }

                if (intSelected.Count <= 0)
                {
                    MessageBox.Show("Invalid Invoice No", "Invalid Invoice No - Invoice Draft Printing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print");
                }
     
                List<string> pdflist = new List<string>();
                int loCId = int.Parse(lookLocation.EditValue.ToString());
                //add curent user
                pdflist.Add(loCId.ToString() + ";" + cust_id.ToString() + ";" + MMS.CustomClasses.cCommon_Functions.LoggedUserID.ToString());
                string pdfFile = string.Empty;
                foreach (var invid in qrySelected)
                {

                    pdfFile = generateinvoice(invid.InvoiceID);
                    
                    if (!string.IsNullOrEmpty(pdfFile))
                    { pdflist.Add(pdfFile); }
                    else
                    { return; }
                   
                }
                bool complete = MMS.CustomClasses.cCommon_Functions.writeToTextfile(pdflist);
                Cursor.Current = Cursors.Default;
                if (complete)
                {
                    System.Diagnostics.Process.Start("SMTP.exe");
                }

                if (string.IsNullOrEmpty(pdfFile))
                { return; }
                IsEmail = false;

            }

            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //btnPrint_Click(null, null);
            
        }

        private void dateEditFrom_DrawItem(object sender, DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs e)
        {

        }

        private void dateEditFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
            {
                return;
            }

            LoadPromotionaInvoice();
        }

        private void dateEditTo_EditValueChanged(object sender, EventArgs e)
        {
            dateEditFrom_EditValueChanged(null, null);
            btnPrintAll.Enabled = true;
            btnPrint.Enabled = true;
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

        }


        private void LoadPromotionaInvoice()
        {
            try
            {

                DateTime? fromDate = dateEditFrom.DateTime;
                DateTime? todate = dateEditTo.DateTime;

                int loCId=int.Parse(lookLocation.EditValue.ToString());
                 int CompId=int.Parse(lookCompany.EditValue.ToString());

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryInv = (from i in context.Invoices
                                  join c in context.Companies on i.CompanyID equals c.CompanyID
                                  join l in context.Locations on i.LocationID equals l.LocationID
                                  join lv in context.Floor_Levels on i.LevelID equals lv.LevelID
                                  join m in context.Months on i.ProcessMonth equals m.MonthID
                                  where i.InvoiceTypeID == 3 && i.IsConfirmed == true && i.InvoiceDate >= fromDate && i.InvoiceDate <= todate && i.LocationID == loCId && i.CompanyID==CompId && i.SubInvTypeID==3
                                  select new { i.InvoiceID, i.InvoiceNo, i.ShopNo, i.ShopName, l.LocationCode, lv.LevelName, c.CompanyCode, i.InvoiceDate,
                                      Year = i.ProcessYear, Month = m.MonthName, i.DateFrom, i.DateTo,i.CustomerName }).ToList();

                    cProList.Clear();

                    foreach (var qres in qryInv)
                    {

                        cPromotionInvoice promo = new cPromotionInvoice();
                        promo.InvoiceID = qres.InvoiceID;
                        promo.InvoiceNo = qres.InvoiceNo;
                        promo.InvoiceDate = qres.InvoiceDate;
                        promo.ShopNo = qres.ShopNo;
                        promo.ShopName = qres.ShopName;
                        promo.LevelName = qres.LevelName;
                        promo.LocationCode = qres.LocationCode;
                        promo.ProcessYear = qres.Year;
                        promo.MonthName = qres.Month;
                        promo.DateTo = qres.DateTo;
                        promo.DateFrom = qres.DateFrom;
                        promo.CustomerName = qres.CustomerName;

                        cProList.Add(promo);


                    }

                    cPromotionInvoiceBindingSource.DataSource = cProList;
                    this.gvpromotions.RefreshDataSource();


                }

            }
            catch (Exception ex)
           {
               MessageBox.Show(ex.ToString()); 
            
            
            }
        
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                chkSelectAll.Text = "Unselect All";
                foreach (var qry in cProList)
                {
                    qry.Select = true;
                }
                gvpromotions.RefreshDataSource();
            }
            else
            {
                chkSelectAll.Text = "Select All";
                foreach (var qry in cProList)
                {
                    qry.Select = false;
                }
                gvpromotions.RefreshDataSource();
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
