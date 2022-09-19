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
using System.Data.Objects;

namespace MMS.Transaction.OtherServices
{
    public partial class xProformaInvoice : Form
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<cGen_Rent_Invoice> cGenList = new List<cGen_Rent_Invoice>();
        List<cGen_Rent_Invoice> cRecentInvList = new List<cGen_Rent_Invoice>();
        bool IsConfirm = false;
        bool IsCancel = false;
        int compid = 0; int locid = 0;
        public  xProformaInvoice()
        {
            InitializeComponent();
            //load_data();
            LoadComapanyData();
        }
        public void xProformaInvoice_Load(object sender, EventArgs e)
        {
            //load_data();
  
        
        }
        private void LoadComapanyData()
        {
            var qryComp = (from c in context.Companies
                           select new { c.CompanyID, c.CompanyCode }).ToList();
            this.lookCompany.Properties.DataSource = qryComp;
            this.lookCompany.Properties.DisplayMember = "CompanyCode";
            this.lookCompany.Properties.ValueMember = "CompanyID";

            //Location
            var qryLoc = (from l in context.Locations
                          select new { l.LocationID, l.LocationCode }).ToList();
            this.lookLocation.Properties.DataSource = qryLoc;
            this.lookLocation.Properties.ValueMember = "LocationID";
            this.lookLocation.Properties.DisplayMember = "LocationCode";

          
        
        }
        private void load_data(int comid,int locid)
        {


            //load proformas
            var qryinv = (from inv in context.Invoices
                          where inv.IsProforma == true && inv.InvoiceState == 0 && inv.CompanyID == comid && inv.LocationID == locid
                          select inv).ToList();

            cGenList.Clear();

            foreach (var qry in qryinv)
            {
                cGen_Rent_Invoice oGenInv = new cGen_Rent_Invoice();
                oGenInv.ProfomaSequenceNo = qry.ProfomaSequenceNo;
                oGenInv.ProfomaNo = qry.ProfomaNo;
                oGenInv.InvoiceID = qry.InvoiceID;
                oGenInv.InvoiceTypeID = qry.InvoiceTypeID;
                oGenInv.SubInvTypeID = qry.SubInvTypeID;
                oGenInv.CompanyID = qry.CompanyID;
                oGenInv.CompanyCode = context.Companies.Where(x => x.CompanyID == qry.CompanyID).FirstOrDefault().CompanyCode;
                oGenInv.LocationID = qry.LocationID;
                oGenInv.LocationCode = context.Locations.Where(x => x.LocationID == qry.LocationID).FirstOrDefault().LocationCode;
                oGenInv.InvDate = qry.InvoiceDate;
                oGenInv.Confirm = false;
                oGenInv.CustomerID = qry.CustomerID;
                oGenInv.ShopName = qry.ShopName;
                oGenInv.CustomerName = qry.CustomerName;
                oGenInv.TotalRent = qry.TotalRentPerMonth;
                oGenInv.OtherServiceID = qry.OtherServiceID; // other services i.e Promotion etc.
               
                cGenList.Add(oGenInv);
            }
            cGenList = (from c in cGenList
                        orderby c.CompanyID, c.LocationID, c.SubInvTypeID
                        select c).ToList();

            this.cGen_Rent_InvoiceBindingSource.DataSource = cGenList;
            this.cGen_Rent_InvoiceGridControl.RefreshDataSource();
            

           

        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
        {
           // checkSelected();

           
            int comid = 0;
            bool res = false;
            res = int.TryParse(lookCompany.EditValue.ToString(), out comid);
            if (res.Equals(true))
            {
                var qryLoc = (from c in context.Companies
                              join l in context.Locations on c.LocationID equals l.LocationID
                              where c.CompanyID == comid
                              select new { l.LocationID, l.LocationCode }).ToList();


                this.lookLocation.Properties.DataSource = qryLoc;
                this.lookLocation.Properties.ValueMember = "LocationID";
                this.lookLocation.Properties.DisplayMember = "LocationCode";
            }

        }

        private void checkSelected()
        {
            if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
            { return; }

            if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
            { return; }

            bool res = false;
            int compid = 0;
            res = int.TryParse(this.lookCompany.EditValue.ToString(), out compid);
            if (res == false) { compid = 0; return; }

            int locid = 0;
            res = int.TryParse(this.lookLocation.EditValue.ToString(), out locid);
            if (res == false) { locid = 0; return; }

            var qrySelection = (from c in cGenList
                                where c.CompanyID == compid && c.LocationID == locid
                                select c).ToList();


            foreach (var qry in qrySelection)
            {
                qry.Select = true;
            }
            cGen_Rent_InvoiceGridControl.RefreshDataSource();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
        }
        private void GenerateProformaNumber()
        {


            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                var qrySelected = (from i in cGenList
                                   where i.Select == true
                                   select i).ToList();

                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormCaption("Generating Proforma Invoice No(s)"); }
                foreach (var qry in qrySelected)
                {
                    if (qry.IsInvoiceNoGenerated == false)
                    {
                        
                        string profrmano = cGenerateInvoiceNo.generateProformainvoiceno(qry.OtherServiceID,qry.CompanyID,qry.LocationID, qrySelected);
                        qry.ProfomaNo = profrmano;
                        qry.IsInvoiceNoGenerated = true;
                        int index = profrmano.ToString().LastIndexOf('/');
                        qry.ProfomaSequenceNo = int.Parse(profrmano.Substring(index + 1, 12 - (index + 1)).ToString());
                        splashScreenManager1.SetWaitFormCaption(qry.ProfomaNo);
                    }

                }

                cGen_Rent_InvoiceGridControl.RefreshDataSource();
                chkBtnConfirm.Checked = false;
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        
        
        
        
        }
        private void UpdateSelectedProformaStatus()
        {
            try {

                

                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);
                if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
                { throw new Exception("Invalid Location"); }
                if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                { throw new Exception("Invalid Company"); }


                var qryselected = (from i in cGenList
                                   where i.Select == true
                                   select i).ToList();
                if (qryselected.Count == 0)
                { return; }

                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Confirming Invoice No(s)"); }

                foreach (var qry in qryselected)
                {
                    Invoice oInv = (from inv in context.Invoices
                                    where inv.InvoiceID == qry.InvoiceID
                                    select inv).FirstOrDefault();
                    if (IsConfirm == true)
                    {
                        oInv.InvoiceState = MMS.CustomClasses.constants.ProformaStatus.PROFORMA_STATE_CONFIRM;
                        oInv.ProfomaNo = qry.ProfomaNo;
                        oInv.ProfomaSequenceNo = qry.ProfomaSequenceNo;
                        splashScreenManager1.SetWaitFormDescription(qry.ProfomaNo);
                    }
                    if (IsCancel == true)
                    {
                        oInv.InvoiceState = MMS.CustomClasses.constants.ProformaStatus.PROFORMA_STATE_CANCEL;
                        oInv.InvoiceID = qry.InvoiceID;
                    }

                    

                }

                // splashScreenManager1.SetWaitFormDescription("Saving Data");SaveOptions.None

                int succ = context.SaveChanges();

                if (succ > 0)
                {
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                    MessageBox.Show("Record Saved Successfully", "Save Success - Generate Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    load_data(compid, locid);
                    
                   
                }
                


            }
            catch (Exception ex)
            {
                

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lookLocation_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()) || string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
            { return; }

            compid = int.Parse(this.lookCompany.EditValue.ToString());
            locid = int.Parse(this.lookLocation.EditValue.ToString());
            load_data(compid, locid);

        }

        private void btnSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            
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
                cGen_Rent_InvoiceGridControl.RefreshDataSource();
            }
            else
            {
                chkSelectAll.Text = "Select All";
                foreach (var qry in cGenList)
                {
                    qry.Select = false;
                }
                cGen_Rent_InvoiceGridControl.RefreshDataSource();
            }
        }

        private void chkBtnConfirm_CheckedChanged(object sender, EventArgs e)
        {
            chkBtnConfirm.Checked = true;
            GenerateProformaNumber();
           // chkBtnConfirm.Checked = false;
            
        }

        private void chkcancel_CheckedChanged(object sender, EventArgs e)
        {
            chkcancel.Checked = true;
            UpdateSelectedProformaStatus();
           // chkcancel.Checked = false;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GenerateProformInvoice();
        }

        

        private void GenerateProformInvoice()
        {
            try
            {

                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print - Proforma Invoice");
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


                    if (qryInvoice.Count == 0)
                    {
                        if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                        return;
                    }


                    /// Report generation
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

                    int userId = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    var prepairedSignature = (from usr in context.Permission_Users
                                              where usr.UserID == userId
                                              select new { usr.signature }
                                   );
                    rptProforma.Database.Tables["DataTier_Permission_Users"].SetDataSource(prepairedSignature);
                    rptProforma.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                    rptProforma.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                    rptProforma.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                    rptProforma.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                    rptProforma.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                    rptProforma.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                    rptProforma.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                    rptProforma.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                    rptProforma.SetParameterValue("pHeaderText", "");
                    rptProforma.SetParameterValue("pDetailText", "This is a computer generated copy. Signature is not required");
                    //rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);

                    _main.crystalReportViewer1.ReportSource = rptProforma;

                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                    _main.Refresh();
                    _main.Show();
                
                PrintDialog printdg = new PrintDialog();
                printdg.AllowSomePages = true;
                printdg.AllowPrintToFile = true;

                if (printdg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rptProforma.PrintOptions.PrinterName = printdg.PrinterSettings.PrinterName;
                    rptProforma.PrintToPrinter(1, true, 0, 0);
                }

                printdg.Dispose();
                // btnDirectPrint.Enabled = true;

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GerateProformaSummery()
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Proforma Summary");
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
                                  select new
                                  {
                                      i.RentWithSCPerMonth,i.RentPerMonth,i.ShopName,i.InvoiceID, i.InvoiceNo,i.InvoiceTypeID, i.SubInvTypeID,
                                      i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom,  i.DateTo, i.TotalRentPerMonth,
                                      i.MandatoryTaxAmount,i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo,i.SAP_DocHeaderText, i.IsTaxCustomer,
                                      i.MandatoryTaxCode,i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID,i.LocationID, i.LevelName, i.RentalDiscount,
                                      i.SCDiscount, i.TotalTax, i.ProfomaNo  }).ToList();



                if (qryInvoice.Count == 0)
                {
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                    return;
                }


                /// Report generation
                rptMain _main = new rptMain();
                rptProformaSummery rptrentInv = new rptProformaSummery();



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
              
                    PrintDialog printdg = new PrintDialog();
                    printdg.AllowSomePages = true;
                    printdg.AllowPrintToFile = true;

                    if (printdg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rptrentInv.PrintOptions.PrinterName = printdg.PrinterSettings.PrinterName;
                        rptrentInv.PrintToPrinter(1, true, 0, 0);
                    }

                    printdg.Dispose();
              
                #endregion
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        
        
        
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            GerateProformaSummery();
        }

        private void btnSaveGenProformas_Click(object sender, EventArgs e)
        {
            SaveConfiemedProformas();
        }
        private void SaveConfiemedProformas()
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
                { throw new Exception("Invalid Location"); }
                if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                { throw new Exception("Invalid Company"); }


                var qryselected = (from i in cGenList
                                   where i.Select == true
                                   select i).ToList();
                if (qryselected.Count == 0)
                { return; }

                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Confirming Invoice No(s)"); }

                foreach (var qry in qryselected)
                {
                    Invoice oInv = (from inv in context.Invoices
                                    where inv.InvoiceID == qry.InvoiceID
                                    select inv).FirstOrDefault();
                    oInv.ProfomaNo = qry.ProfomaNo;

                    int index = qry.ProfomaNo.ToString().LastIndexOf('/');
                    qry.ProfomaSequenceNo = int.Parse(qry.ProfomaNo.Substring(index + 1, 12 - (index + 1)).ToString());  // getting Int value of Invoice No string
                    oInv.ProfomaSequenceNo = qry.ProfomaSequenceNo;
                    oInv.InvoiceState = MMS.CustomClasses.constants.ProformaStatus.PROFORMA_STATE_CONFIRM;
                    splashScreenManager1.SetWaitFormDescription(oInv.ProfomaNo);

                }

                //splashScreenManager1.SetWaitFormDescription("Saving Data");

                int succ = context.SaveChanges(SaveOptions.None);


                if (succ > 0)
                {
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                    MessageBox.Show("Record Saved Successfully", "Save Success - Generate Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // ////email alert 
                    int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.OtherServiceInvoiceConfirmed;
                    this.gridView1.OptionsPrint.ShowPrintExportProgress = false;
                    MMS.CustomClasses.cCommon_Functions.AddToEmailList(int.Parse(this.lookCompany.EditValue.ToString()), int.Parse(this.lookLocation.EditValue.ToString()), alert, "", MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.gridView1);

                }
                load_data(compid, locid);
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void btnConfirmProf_Click(object sender, EventArgs e)
        {
            IsConfirm = true;
            GenerateProformaNumber();
            IsConfirm = false;
        }

        private void btnCancelProf_Click(object sender, EventArgs e)
        {
            IsCancel = true;
            UpdateSelectedProformaStatus();
            IsCancel = false;
        }
       
    }
}
