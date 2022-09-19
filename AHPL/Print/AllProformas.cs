using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTier;
using DataTier.Reports.OtherService;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace MMS.Print
{
    public partial class xAllProformas : Form
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<cPromotionInvoice> cProList = new List<cPromotionInvoice>();

        bool withSignature = false;
        bool IsEmail = false;
        int cust_id;
        int print_opt;
        public xAllProformas(int option)
        {
            InitializeComponent();
            LoadComapanyData();
            this.print_opt = option;
        }
        private void LoadComapanyData()
        {
            var qryComp = (from c in context.Companies
                           select new { c.CompanyID, c.CompanyCode }).ToList();
            this.lookCompany.Properties.DataSource = qryComp;
            this.lookCompany.Properties.DisplayMember = "CompanyCode";
            this.lookCompany.Properties.ValueMember = "CompanyID";

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
                    //this.lookLocation.Properties.DataSource = qryLoc;
                    //this.lookLocation.Properties.DisplayMember = "CompanyCode";
                    //this.lookLocation.Properties.ValueMember = "CompanyID";

                }
            }
        }

        private void LoadPromotionaInvoice()
        {
            try
            {

                DateTime? fromDate = dateEditFrom.DateTime;
                DateTime? todate = dateEditTo.DateTime;

                int loCId = int.Parse(lookLocation.EditValue.ToString());
                int CompId = int.Parse(lookCompany.EditValue.ToString());
             
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryInv = (from i in context.Invoices
                                  join c in context.Companies on i.CompanyID equals c.CompanyID
                                  join l in context.Locations on i.LocationID equals l.LocationID
                                  join lv in context.Floor_Levels on i.LevelID equals lv.LevelID
                                  join m in context.Months on i.ProcessMonth equals m.MonthID
                                  where i.InvoiceDate >= fromDate && i.InvoiceDate <= todate && i.LocationID == loCId
                                  && i.CompanyID == CompId && i.ProfomaNo !=null

                                  select new
                                  {
                                      i.InvoiceID,  i.InvoiceNo, i.ShopNo,  i.ShopName,  l.LocationCode, lv.LevelName, c.CompanyCode, i.InvoiceDate, 
                                      Year = i.ProcessYear, Month = m.MonthName, i.DateFrom, i.DateTo,i.CustomerName,i.ProfomaNo
                                  }).ToList();

                    cProList.Clear();

                    foreach (var qres in qryInv)
                    {

                        cPromotionInvoice promo = new cPromotionInvoice();
                        promo.InvoiceID = qres.InvoiceID;
                        promo.ProfomaNo = qres.ProfomaNo;
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

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            
            try
            {
                IsEmail = true;
                Cursor.Current = Cursors.WaitCursor;
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
                    MessageBox.Show("Non of Profams Selected", "Proforma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print");
                }
                string pdfFile = null;
                List<string> pdflist = new List<string>();
                int loCId = int.Parse(lookLocation.EditValue.ToString());
                
                //add curent user
                pdflist.Add(loCId.ToString() + ";" + cust_id.ToString() + ";" + MMS.CustomClasses.cCommon_Functions.LoggedUserID.ToString());
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

                IsEmail = false;
            }

            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GeneratePrintView();
        }

        private void GeneratePrintView()
        {
            try
            {
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
                    MessageBox.Show("Non of Profams Selected", "Proforma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print");
                }
                string pdfFile = null;
                
                foreach (var invid in qrySelected)
                {

                    pdfFile = generateinvoice(invid.InvoiceID);
                    if (string.IsNullOrEmpty(pdfFile))
                        return;
                }

                if (string.IsNullOrEmpty(pdfFile))
                { return; }

            }

            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string  generateinvoice(int invoiceid)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                // List of invoices which selected in the grid
                var qryInvoice = (from i in context.Invoices
                                  where i.InvoiceID == invoiceid
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
                                      i.Naration,
                                      i.FooterText1,
                                      i.ProfomaNo
                                  }).ToList();
              /// Report generation
                /// Report generation
                cust_id = qryInvoice[0].CustomerID;
                rptMain _main = new rptMain();

                //rptRent_Invoice rptrentInv = new rptRent_Invoice();
                rptProformaInvoice rptProforma = new rptProformaInvoice();

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


                rptProforma.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                rptProforma.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                rptProforma.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                rptProforma.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                rptProforma.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                rptProforma.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                rptProforma.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                rptProforma.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                rptProforma.Database.Tables["DataTier_Permission_Users"].SetDataSource(prepairedSignature);

                if (print_opt == 2)
                {
                    rptProforma.SetParameterValue("pHeaderText", "COPY");
                    rptProforma.SetParameterValue("pDetailText", "This is a computer generated copy. Signature is not required");
                }
                else {
                    rptProforma.SetParameterValue("pHeaderText", "");
                    rptProforma.SetParameterValue("pDetailText", "");
                }
               
                

                _main.crystalReportViewer1.ReportSource = rptProforma;

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                if (!IsEmail)
                { _main.Show(this); }



                string invoiceNo = qryInvoice.First().ProfomaNo.Replace('/', '-');
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

                rptProforma.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfFile);
                rptProforma.Close();
                rptProforma.Dispose();
                //if (!IsEmail)
                //{
                //    MessageBox.Show("Invoice : " + pdfFile + " , Save Successfull");
                //}
                return pdfFile;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cProList.Count == 0)
            {
                return;
            }

            if (this.chkSelectAll.Checked == true)
            {
                this.chkSelectAll.Text = "Unselect All";
                foreach (var qry in cProList)
                {
                    qry.Select = true;
                }
            }
            else
            {
                this.chkSelectAll.Text = "Select All";
                foreach (var qry in cProList)
                {
                    qry.Select = false;
                }
            }

            this.gvpromotions.RefreshDataSource();

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
        //private void GenerateProformInvoice()
        //{
        //    try
        //    {

        //        if (splashScreenManager1.IsSplashFormVisible == false)
        //        {
        //            splashScreenManager1.ShowWaitForm();
        //            splashScreenManager1.SetWaitFormDescription("Generating Print - Proforma Invoice");
        //        }


        //        var qrySelected = (from i in cGenList
        //                           where i.Select == true
        //                           select new { i.InvoiceID }).ToList();
        //        List<int> intSelected = new List<int>();
        //        foreach (var qry in qrySelected)
        //        {
        //            intSelected.Add(qry.InvoiceID);

        //        }

        //        // List of invoices which selected in the grid

        //        var qryInvoice = (from i in context.Invoices
        //                          join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
        //                          orderby lvl.StdOrder ascending
        //                          where intSelected.Contains(i.InvoiceID)
        //                          select new
        //                          {
        //                              i.InvoiceID,
        //                              i.InvoiceNo,
        //                              i.InvoiceTypeID,
        //                              i.SubInvTypeID,
        //                              i.InvoiceDate,
        //                              i.CustomerID,
        //                              i.CustomerName,
        //                              i.CustomerAddress,
        //                              i.DateFrom,
        //                              i.DateTo,
        //                              i.TotalRentPerMonth,
        //                              i.MandatoryTaxAmount,
        //                              i.TotalWithMandatoryTax,
        //                              i.OtherTax,
        //                              i.TaxRegNo,
        //                              i.SAP_DocHeaderText,
        //                              i.IsTaxCustomer,
        //                              i.MandatoryTaxCode,
        //                              i.ProcessMonth,
        //                              i.ProcessYear,
        //                              i.ShopNo,
        //                              i.CompanyID,
        //                              i.LocationID,
        //                              i.ShopName,
        //                              i.IsTaxApplicable,
        //                              i.Naration,
        //                              i.FooterText1,
        //                              i.ProfomaNo
        //                          }).ToList();


        //        if (qryInvoice.Count == 0)
        //        {
        //            if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
        //            return;
        //        }


        //        /// Report generation
        //        rptMain _main = new rptMain();

        //        //rptRent_Invoice rptrentInv = new rptRent_Invoice();
        //        rptProformaInvoice rptProforma = new rptProformaInvoice();

        //        var qryInvDet = (from invdet in context.Invoice_Details
        //                         join t in context.Taxes on invdet.TaxID equals t.TaxID
        //                         where t.IsMandatory == false
        //                         select new { invdet.Amount, invdet.InvoiceDetailID, invdet.InvoiceID, invdet.IsPrint, invdet.TaxCode, invdet.TaxID, invdet.TaxRate }).ToList();

        //        var qryCompany = (from c in context.Companies
        //                          select new { c.CompanyCode, c.CompanyID, c.DefaultTaxRegNo, c.CompanyName, c.Tele1, c.Tele2, c.Fax, c.Address, c.BusinessRegNo, c.InvoiceFooterText1, c.InvoiceFooterText2 }).ToList();

        //        var qryMonth = (from m in context.Months
        //                        select m).ToList();

        //        var qryTax = (from t in context.Taxes
        //                      select new { t.TaxID, t.TaxCode, t.IsMandatory }).ToList();

        //        var qryLocaiton = (from l in context.Locations
        //                           select new { l.LocationID, l.LocationName, l.Logo, l.Address }).ToList();


        //        var qryInvType = (from it in context.Invoice_Types
        //                          select new { it.InvoiceTypeID, it.InvoiceTypeName }).ToList();

        //        var qrySubInvType = (from sit in context.Sub_Invoice_Types
        //                             select new { sit.SubInvTypeID, sit.SubInvTypeName }).ToList();



        //        rptProforma.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
        //        rptProforma.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
        //        rptProforma.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
        //        rptProforma.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
        //        rptProforma.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
        //        rptProforma.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
        //        rptProforma.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
        //        rptProforma.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
        //        rptProforma.SetParameterValue("pHeaderText", "");
        //        rptProforma.SetParameterValue("pDetailText", "");
        //        //rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);

        //        _main.crystalReportViewer1.ReportSource = rptProforma;

        //        if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

        //        _main.Refresh();
        //        _main.Show();

        //        PrintDialog printdg = new PrintDialog();
        //        printdg.AllowSomePages = true;
        //        printdg.AllowPrintToFile = true;

        //        if (printdg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            rptProforma.PrintOptions.PrinterName = printdg.PrinterSettings.PrinterName;
        //            rptProforma.PrintToPrinter(1, true, 0, 0);
        //        }

        //        printdg.Dispose();
        //        // btnDirectPrint.Enabled = true;

        //    }
        //    catch (Exception ex)
        //    {
        //        if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}



    }
}
