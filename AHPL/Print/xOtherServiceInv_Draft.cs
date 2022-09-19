using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataTier;
using DataTier.Reports;
using System.Linq;
using System.Linq.Expressions;
using DataTier.Reports.OtherService;
using System.Configuration;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace MMS.Print
{
    public partial class xOtherServiceInv_Draft : DevExpress.XtraEditors.XtraForm
    {
        bool withSignature = false;

        public xOtherServiceInv_Draft()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try 
            {
                if (string.IsNullOrEmpty(this.searchLookUpEdit1.Text.ToString()))
                { return; }


                int invoiceid = 0;
                bool res = false;
                res = int.TryParse(searchLookUpEdit1.EditValue.ToString(), out invoiceid);
                if (res == false) { invoiceid = 0; }
                if (invoiceid == 0)
                {
                    MessageBox.Show("Invalid Invoice No", "Invalid Invoice No - Invoice Draft Printing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print");
                }

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    // List of invoices which selected in the grid
                    var qryInvoice = (from i in context.Invoices
                                      where i.InvoiceID == invoiceid
                                      select new { i.OtherServiceID, i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.Naration, i.CustomerAddress2, i.IsTaxApplicable }).ToList();


                    if (qryInvoice.Count == 0)
                    {
                        if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                        return;
                    }


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

                    _main.Show(this);


                    ////10July2014..to add attachments to outlook
                    string invoiceNo = qryInvoice.First().InvoiceNo.Replace('/', '-');
                    string pdfFile = ConfigurationManager.AppSettings["OutLookEmailPath"] + invoiceNo + ".pdf";
                    rptOtherSInv.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfFile);

                    Outlook.Application oApp = new Outlook.Application();
                    Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                    oMailItem.Attachments.Add(pdfFile, Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                    ////body, To,CC,bcc etc...
                    oMailItem.Display(true);
                    ////oMailItem.Send();
                }
            }

            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xOtherServiceInv_Draft_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryInv = (from i in context.Invoices
                                  join c in context.Companies on i.CompanyID equals c.CompanyID
                                  join l in context.Locations on i.LocationID equals l.LocationID
                                  join lv in context.Floor_Levels on i.LevelID equals lv.LevelID
                                  join m in context.Months on i.ProcessMonth equals m.MonthID
                                  where i.InvoiceTypeID == 3 && i.IsConfirmed == true
                                  select new { i.InvoiceID, i.InvoiceNo, i.ShopNo, i.ShopName, l.LocationCode, lv.LevelName, c.CompanyCode, i.InvoiceDate, Year = i.ProcessYear, Month = m.MonthName, i.DateFrom, i.DateTo }).ToList();
                    this.searchLookUpEdit1.Properties.DataSource = qryInv;
                    this.searchLookUpEdit1.Properties.DisplayMember = "InvoiceNo";
                    this.searchLookUpEdit1.Properties.ValueMember = "InvoiceID";


                    this.searchLookUpEdit1View.BestFitColumns();




                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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