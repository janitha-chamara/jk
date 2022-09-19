using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataTier;
using System.Linq;
using System.Linq.Expressions;
using DataTier.Reports.Utility;
using System.Configuration;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace MMS.Print
{
    public partial class xUtilityInv_Draft : DevExpress.XtraEditors.XtraForm
    {
        bool withSignature = false;
        public xUtilityInv_Draft()
        {
            InitializeComponent();
        }

        private void xUtilityInv_Draft_Load(object sender, EventArgs e)
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
                                  where i.InvoiceTypeID == 2 && i.IsConfirmed == true
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



                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    if (splashScreenManager1.IsSplashFormVisible == false)
                    {
                        splashScreenManager1.ShowWaitForm();
                        splashScreenManager1.SetWaitFormDescription("Generating Print - Utility Invoice");
                    }




                    // List of invoices which selected in the grid
                    var qryInvoice = (from i in context.Invoices
                                      where i.InvoiceID == invoiceid
                                      select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable, i.StartReading, i.EndReading, i.StartReading2, i.EndReading2, i.UtilityName, i.UtilityUnitRate, i.FooterText1, i.NosUnitsConsumed1, i.NosUnitsConsumed2, i.M_NosUnitsConsumed, i.IsUtilityTaxApplicable,i.Reset }).ToList();


                    if (qryInvoice.Count == 0)
                    {
                        if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                        return;
                    }


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

                    reportMain.Show(this);
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                    ////10July2014..to add attachments to outlook
                    string invoiceNo = qryInvoice.First().InvoiceNo.Replace('/', '-');
                    string pdfFile = ConfigurationManager.AppSettings["OutLookEmailPath"] + invoiceNo + ".pdf";
                    rptUtility.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfFile);

                    //Outlook.Application oApp = new Outlook.Application();
                    //Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                    //oMailItem.Attachments.Add(pdfFile, Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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