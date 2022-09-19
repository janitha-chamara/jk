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
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using System.Data.Linq.SqlClient;
using DataTier;
using DataTier.Reports;
using System.Transactions;

namespace MMS
{
    public partial class xUtilityInvoice_Confirm : DevExpress.XtraEditors.XtraForm
    {
        //AHPL_DBEntities context = new AHPL_DBEntities();
        List<cGen_Rent_Invoice> cGenList = new List<cGen_Rent_Invoice>();
        List<cGen_Rent_Invoice> cRecentInvList = new List<cGen_Rent_Invoice>();

        List<cGen_Rent_Invoice> cConfirmedtInvList = new List<cGen_Rent_Invoice>();
        //List<cGen_Rent_Invoice> cNotConfrimedInvList = new List<cGen_Rent_Invoice>();

        public xUtilityInvoice_Confirm()
        {
            InitializeComponent();
        }

        private void xUtilityInvoice_Confirm_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                //if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Connecting......"); }
                //bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
               
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    // utility 
                    this.utilityBindingSource.DataSource = (from u in context.Utilities
                                                            select new { u.UtilityID, u.UtilityName }).ToList();
                    // --

                    //level 
                    var qryLevel = (from l in context.Floor_Levels
                                    select new { l.LevelID, l.LevelName }).ToList();
                    this.lookLevelID.DataSource = qryLevel;
                    this.lookLevelID.DisplayMember = "LevelName";
                    this.lookLevelID.ValueMember = "LevelID";

                    //company 
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

                    // month 

                    var qryMonth = (from m in context.Months
                                    select new { m.MonthID, m.MonthCode }).ToList();
                    this.repositoryItemLookUpEditMonth.DataSource = qryMonth;
                    this.repositoryItemLookUpEditMonth.DisplayMember = "MonthCode";
                    this.repositoryItemLookUpEditMonth.ValueMember = "MonthID";

                    //loading Processed and Not Confirmed invoice list
                    var qryinv = (from inv in context.Invoices
                                  where inv.IsConfirmed == false && inv.InvoiceTypeID == 2 && inv.IsProcessed == true
                                  select inv).ToList();

                    cGenList.Clear();
                    foreach (var qry in qryinv)
                    {
                        cGen_Rent_Invoice oGenInv = new cGen_Rent_Invoice();
                        oGenInv.UtilityID = qry.UtilityID;
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
                        oGenInv.TotalRent = qry.RentPerMonth;
                        oGenInv.TotalTax = qry.OtherTax;
                        oGenInv.GrandTotal = qry.TotalRentPerMonth;
                        oGenInv.DateTo = qry.DateTo;
                        oGenInv.DateFrom = qry.DateFrom;
                        oGenInv.InvDate = qry.InvoiceDate;
                        oGenInv.ProcessMonth = qry.ProcessMonth;
                        oGenInv.ProcessYear = qry.ProcessYear;
                        oGenInv.ShopNo = qry.ShopNo;
                        oGenInv.SequenceNo = qry.SequenceNo;
                        oGenInv.Edit = "Edit";

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

                    this.cGen_Rent_InvoiceBindingSource.DataSource = cGenList;
                    this.cGen_Rent_InvoiceGridControl.RefreshDataSource();
                    //---

                    //////Loading Recent Invoice List 
                    //var qryinvRecent = (from inv in context.Invoices
                    //                    where inv.IsConfirmed == true && inv.InvoiceTypeID == 2
                    //                    orderby inv.InvoiceID descending
                    //                    select inv).ToList();
                    ////cRecentInvList.Clear();



                    // Loading sub invoice types
                    var qrySubInvtype = (from si in context.Sub_Invoice_Types
                                         orderby si.StdOrder ascending
                                         select si).ToList();
                    this.subInvoiceTypesBindingSource.DataSource = qrySubInvtype;


                    // loading global customer 
                    var qryGlobalCust = (from gc in context.Global_Customers
                                         orderby gc.CustomerName ascending
                                         select new { gc.CustomerID, gc.CustomerName }).ToList();
                    this.globalCustomersBindingSource.DataSource = qryGlobalCust;


                    //// Loading Recent Invoice List (Confirmed) 
                    //var qryinvConfirmed = (from inv in context.Invoices
                    //                       where inv.IsConfirmed == true && inv.InvoiceTypeID == 2
                    //                       select inv).ToList();

                    //cConfirmedtInvList.Clear();
                    //foreach (var qry in qryinvConfirmed)
                    //{
                    //    cGen_Rent_Invoice oGenInv = new cGen_Rent_Invoice();
                    //    oGenInv.UtilityID = qry.UtilityID;
                    //    oGenInv.SequenceNo = qry.SequenceNo;
                    //    oGenInv.InvoiceNo = qry.InvoiceNo;
                    //    oGenInv.InvoiceID = qry.InvoiceID;
                    //    oGenInv.InvoiceTypeID = qry.InvoiceTypeID;
                    //    oGenInv.SubInvTypeID = qry.SubInvTypeID;
                    //    oGenInv.CompanyID = qry.CompanyID;
                    //    oGenInv.CompanyCode = context.Companies.Where(x => x.CompanyID == qry.CompanyID).FirstOrDefault().CompanyCode;
                    //    oGenInv.LocationID = qry.LocationID;
                    //    oGenInv.LocationCode = context.Locations.Where(x => x.LocationID == qry.LocationID).FirstOrDefault().LocationCode;
                    //    oGenInv.InvDate = qry.InvoiceDate;
                    //    oGenInv.Confirm = qry.IsConfirmed;
                    //    oGenInv.IsProcessed = qry.IsProcessed;
                    //    oGenInv.CustomerID = qry.CustomerID;
                    //    oGenInv.ShopName = qry.ShopName;
                    //    oGenInv.ShopNo = qry.ShopNo;
                    //    oGenInv.TotalRent = qry.TotalAmount;
                    //    if (oGenInv.SequenceNo > 0)
                    //    {
                    //        oGenInv.IsInvoiceNoGenerated = true;
                    //    }
                    //    else
                    //    {
                    //        oGenInv.IsInvoiceNoGenerated = false;
                    //    }
                    //    cConfirmedtInvList.Add(oGenInv);
                    //}

                    //this.gridControlRecentInvList.DataSource = cConfirmedtInvList;
                    //this.gridControlRecentInvList.RefreshDataSource();
                    //-
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenInv_Click(object sender, EventArgs e)
        {

            try
            {
               // if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Connecting......"); }
                //bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                ////Coment below to activate select All button..13May2014..

                ////if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
                ////{ throw new Exception("Invalid Location"); }
                ////if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                ////{ throw new Exception("Invalid Company"); }

                ////End..
               

                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormCaption("Generating invoice No(s)"); }
                // querying RENT INVOICE  (1 - Adjustmnet, 2 - CreditNote , 3 - Invoice) 

                var qrySelected = (from i in cGenList
                                   where i.Confirm == true
                                   select i).ToList();

                foreach (var qry in qrySelected)
                {
                   

                    if (qry.IsInvoiceNoGenerated == false)
                    {
                        //cGenerateInvoiceNo.generateUInvoce(
                        qry.InvoiceNo = cGenerateInvoiceNo.generateUtilityInvoice(2, qry.LocationID, qrySelected, cConfirmedtInvList, qry.CompanyID, qry.SubInvTypeID, qry.UtilityID);
                        int index = qry.InvoiceNo.ToString().LastIndexOf('/');
                        qry.SequenceNo = int.Parse(qry.InvoiceNo.Substring(index + 1, 10 - (index + 1)).ToString());  // getting Int value of Invoice No string
                        qry.IsInvoiceNoGenerated = true;
                        splashScreenManager1.SetWaitFormDescription(qry.InvoiceNo);
                    }

                }

                cGen_Rent_InvoiceGridControl.RefreshDataSource();
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               // bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                

                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    using (TransactionScope trs = new TransactionScope())
                    {

                        var qryConfirmed = (from i in cGenList
                                            where i.Confirm == true
                                            select i).ToList();

                        if (qryConfirmed.Count == 0)
                        {
                            MessageBox.Show("Please select the invoice(s) to be generated", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Confirming Invoice(s)"); }

                        foreach (var qry in qryConfirmed)
                        {
                           

                            Invoice oInv = (from inv in context.Invoices
                                            where inv.InvoiceID == qry.InvoiceID
                                            select inv).FirstOrDefault();
                            oInv.InvoiceNo = qry.InvoiceNo;
                            oInv.SequenceNo = qry.SequenceNo;
                            oInv.IsConfirmed = true;
                            updateShopLastReading(oInv.InvoiceID, oInv.ShopUtilityReadingID, oInv.EndReading, oInv.EndReading2, oInv.M_EndReading);
                            splashScreenManager1.SetWaitFormDescription(oInv.InvoiceNo);

                        }
                        //if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Connecting......"); }
                      
                        splashScreenManager1.SetWaitFormDescription("Saving Data");
                        int succ = context.SaveChanges();


                        if (succ > 0)
                        {
                            if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                            MessageBox.Show("Record Saved Successfully", "Save Success - Generate Unitily Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Confirming Invoice(s)"); }

                            //// email alert 
                            int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.UtilityInvoiceConfirmed;
                            this.gridView1.OptionsPrint.ShowPrintExportProgress = false;
                            MMS.CustomClasses.cCommon_Functions.AddToEmailList(int.Parse(lookCompany.EditValue.ToString()), int.Parse(this.lookLocation.EditValue.ToString()), alert, "", MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.gridView1);

                            trs.Complete();

                        }
                    }

                    load_data();
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateShopLastReading(int pInvoiceID, int pShopUtilityReadingID, decimal pEndReading, decimal pEndReadingReset, decimal pMaintenanceEndReading)
        {

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    using (TransactionScope trs = new TransactionScope())
                    {
                        var qryShopUR = (from sur in context.Shops_UtilityReadings
                                         where sur.ShopUtilityReadingID == pShopUtilityReadingID
                                         select sur).FirstOrDefault();
                        if (qryShopUR != null)
                        {
                            if (pEndReadingReset > 0)
                            {
                                qryShopUR.LastReading = pEndReadingReset;

                            }
                            else if (pMaintenanceEndReading > 0)
                            {
                                qryShopUR.LastReading = pMaintenanceEndReading;

                            }
                            else
                            {
                                qryShopUR.LastReading = pEndReading;
                            }

                            // updating meter name in the invoice
                            var qryInvoice = (from i in context.Invoices
                                              where i.InvoiceID == pInvoiceID
                                              select i).FirstOrDefault();
                            if (qryInvoice != null)
                            {
                                qryInvoice.UtilityMeterName = qryShopUR.MeterName;
                            }
                            //---

                            context.SaveChanges();
                            trs.Complete();


                        }

                   }

                }

            }
            catch (Exception ex)  
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCheckAll.Checked == true)
            {
                btnCheckAll.Text = "Unselect All";
                foreach (var qry in cGenList)
                {
                    qry.Confirm = true;
                }
            }

            else
            {
                btnCheckAll.Text = "Select All";

                foreach (var qry in cGenList)
                {
                    qry.Confirm = false;
                }

            }

            //this.cGen_Rent_InvoiceBindingSource.DataSource = cGenList;
            this.cGen_Rent_InvoiceGridControl.RefreshDataSource();

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
        {
            checkSelected();

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

                this.lookLocation.Properties.DataSource = qryLoc;
                this.lookLocation.Properties.ValueMember = "LocationID";
                this.lookLocation.Properties.DisplayMember = "LocationCode";

                lookUtilityID.EditValue = null;
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

            ////roshan..to uncheck selected confirm
            foreach (var qry in cGenList)
            {
                qry.Confirm = false;
            }
            ////End..

            var qrySelection = (from c in cGenList
                                where c.CompanyID == compid && c.LocationID == locid
                                select c).ToList();


            foreach (var qry in qrySelection)
            {
                qry.Confirm = true;
            }



            this.cGen_Rent_InvoiceGridControl.RefreshDataSource();
        }

        private void lookLocation_EditValueChanged(object sender, EventArgs e)
        {
            checkSelected();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                this.cGen_Rent_InvoiceBindingSource.EndEdit();

                DialogResult dlg = MessageBox.Show("Do you want to delete?", "Delete Confirmation - Utility Invoices", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.No) { return; }

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryDelete = (from d in cGenList
                                     where d.Delete == true
                                     select d).ToList();


                    foreach (var qry in qryDelete)
                    {
                        Invoice invoiceObject = (from i in context.Invoices
                                                 where i.InvoiceID == qry.InvoiceID && i.IsConfirmed == false
                                                 select i).FirstOrDefault();

                        context.Invoices.DeleteObject(invoiceObject);

                        var qryInvDetList = invoiceObject.Invoice_Details.ToList();

                        foreach (var qryD in qryInvDetList)
                        {
                            Invoice_Details invoiceDetailObject = (from i in context.Invoice_Details
                                                                   where i.InvoiceDetailID == qryD.InvoiceDetailID
                                                                   select i).FirstOrDefault();
                            if (invoiceDetailObject != null)
                            {
                                context.Invoice_Details.DeleteObject(invoiceDetailObject);
                            }
                        }
                    }


                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {

                        MessageBox.Show("Selected Invoice Deleted Successfully...", "Delete Success - Utility Invoices", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ////this.Close();..roshan..12May2014..to load remaining data
                        this.load_data();
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lookUtilityID_EditValueChanged(object sender, EventArgs e)
        {
            ////roshan..07Oct2014..to add utility filter
            if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
            { return; }

            if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
            { return; }

            if (string.IsNullOrEmpty(this.lookUtilityID.Text.ToString()))
            {
                return;
            }

            bool res = false;
            int compid = 0;
            res = int.TryParse(this.lookCompany.EditValue.ToString(), out compid);
            if (res == false) { compid = 0; return; }

            int locid = 0;
            res = int.TryParse(this.lookLocation.EditValue.ToString(), out locid);
            if (res == false) { locid = 0; return; }

            int utilityid = 0;
            res = int.TryParse(this.lookUtilityID.EditValue.ToString(), out utilityid);
            if (res == false)
            {
                return;
            }

            foreach (var qry in cGenList)
            {
                qry.Confirm = false;
            }

            var qrySelection = (from c in cGenList
                                where c.CompanyID == compid && c.LocationID == locid && c.UtilityID == utilityid
                                select c).ToList();


            foreach (var qry in qrySelection)
            {
                qry.Confirm = true;
            }



            this.cGen_Rent_InvoiceGridControl.RefreshDataSource();
        }

        private void btnSelectAllDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSelectAllDelete.Checked == true)
            {
                btnSelectAllDelete.Text = "Unselect All For Delete";
                foreach (var qry in cGenList)
                {
                    qry.Delete = true;
                }
            }
            else
            {
                btnSelectAllDelete.Text = "Select All For Delete";

                foreach (var qry in cGenList)
                {
                    qry.Delete = false;
                }
            }

            this.cGen_Rent_InvoiceGridControl.RefreshDataSource();
        }
    }
}