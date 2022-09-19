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

namespace MMS
{
    public partial class xInvoice_Draft : DevExpress.XtraEditors.XtraForm
    {
        bool withSignature = false;
        public xInvoice_Draft()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xInvoice_Draft_Load(object sender, EventArgs e)
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
                                  where i.InvoiceTypeID == 1 && i.IsConfirmed == true
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

                    rptMain _main = new rptMain();
                    rptRent_Invoice rptrentInv = new rptRent_Invoice();

                    var qryInvoice = (from i in context.Invoices
                                      join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
                                      orderby lvl.StdOrder ascending
                                      where i.InvoiceID == invoiceid
                                      select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable, i.Naration }).ToList();


                    if (qryInvoice.Count == 0)
                    {
                        if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                        return;
                    }


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

                    _main.Show();


                    ////10July2014..to add attachments to outlook
                    string invoiceNo = qryInvoice.First().InvoiceNo.Replace('/', '-');
                    string pdfFile = ConfigurationManager.AppSettings["OutLookEmailPath"] + invoiceNo + ".pdf";
                    rptrentInv.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfFile);

                    //Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                    //Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                    //oMailItem.Attachments.Add(pdfFile, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing,Type.Missing);
                    //////body, To,CC,bcc etc...
                    //oMailItem.Display(true); 
                    ////oMailItem.Send();
                }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

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