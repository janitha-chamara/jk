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

namespace MMS
{
    public partial class xRent_Confirm_Invoice : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<cGen_Rent_Invoice> cGenList = new List<cGen_Rent_Invoice>();
        List<cGen_Rent_Invoice> cRecentInvList = new List<cGen_Rent_Invoice>();
        List<cGen_Rent_Invoice> cNotConfrimedInvList = new List<cGen_Rent_Invoice>();

        public xRent_Confirm_Invoice()
        {
            InitializeComponent();
        }

        private void xRent_GenInvoice_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {

            try
            {

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
               
                //company 
                var qryComp = (from c in context.Companies
                               select new { c.CompanyID, c.CompanyCode }).ToList();
                this.lookCompany.Properties.DataSource = qryComp;
                this.lookCompany.Properties.DisplayMember = "CompanyCode";
                this.lookCompany.Properties.ValueMember = "CompanyID";

                var subInvoiceType = context.Sub_Invoice_Types.Select(s => new { s.SubInvTypeID, s.SubInvTypeName }).ToList();////26June2015..ro..for add sub invoice filter...RB-Ajith.
                this.lookUpInvoiceType.Properties.DataSource = subInvoiceType;
                this.lookUpInvoiceType.Properties.DisplayMember = "SubInvTypeName";
                this.lookUpInvoiceType.Properties.ValueMember = "SubInvTypeID";

                //Location
                var qryLoc = (from l in context.Locations
                              select new { l.LocationID, l.LocationCode }).ToList();
                this.lookLocation.Properties.DataSource = qryLoc;
                this.lookLocation.Properties.ValueMember = "LocationID";
                this.lookLocation.Properties.DisplayMember = "LocationCode";



                //loading Processed and Not Confirmed invoice list
                var qryinv = (from inv in context.Invoices
                              where inv.IsConfirmed == false && inv.InvoiceTypeID == 1 && inv.IsProcessed == true
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

                    if (splashScreenManager1.IsSplashFormVisible == true)
                    {
                        //splashScreenManager1.SetWaitFormDescription(oGenInv.CustomerName);
                    }
                    else
                    {

                        //splashScreenManager1.ShowWaitForm();
                        //splashScreenManager1.SetWaitFormDescription(oGenInv.CustomerName);
                    }

                    cGenList.Add(oGenInv);
                }

                this.cGen_Rent_InvoiceBindingSource.DataSource = cGenList;
                this.cGen_Rent_InvoiceGridControl.RefreshDataSource();

                //---

                //// Loading Recent Invoice List 
                //var qryinvRecent = (from inv in context.Invoices
                //                    where inv.IsConfirmed == true && inv.InvoiceTypeID == 1
                //                    orderby inv.InvoiceID descending
                //                    select inv).ToList().Take(10);
                //cRecentInvList.Clear();

                //foreach (var qry in qryinvRecent)
                //{
                //    cGen_Rent_Invoice oGenInv = new cGen_Rent_Invoice();
                //    oGenInv.SequenceNo = qry.SequenceNo;
                //    oGenInv.InvoiceNo = qry.InvoiceNo;
                //    oGenInv.InvoiceID = qry.InvoiceID;
                //    oGenInv.InvoiceTypeID = qry.InvoiceTypeID;
                //    oGenInv.CompanyID = qry.CompanyID;
                //    oGenInv.CompanyCode = context.Companies.Where(x => x.CompanyID == qry.CompanyID).FirstOrDefault().CompanyCode;
                //    oGenInv.LocationID = qry.LocationID;
                //    oGenInv.LocationCode = context.Locations.Where(x => x.LocationID == qry.LocationID).FirstOrDefault().LocationCode;
                //    oGenInv.InvDate = qry.InvoiceDate;
                //    oGenInv.Confirm = qry.IsConfirmed;
                //    oGenInv.ShopName = qry.ShopName;
                //    oGenInv.TotalRent = qry.TotalRentPerMonth;
                //    oGenInv.CustomerID = qry.CustomerID;
                //    oGenInv.SubInvTypeID = qry.SubInvTypeID;

                //    if (splashScreenManager1.IsSplashFormVisible == true)
                //    {
                //        //splashScreenManager1.SetWaitFormDescription(oGenInv.CustomerName);
                //    }
                //    else
                //    {
                //        //splashScreenManager1.ShowWaitForm();
                //        //splashScreenManager1.SetWaitFormDescription(oGenInv.CustomerName);
                //    }

                //    cRecentInvList.Add(oGenInv);
                //}


                //bsRecentRentList.DataSource = cRecentInvList;
                //cGen_Rent_InvoiceGridControl1.RefreshDataSource();
                // ----

                //Loading Not Confirmed List of Invoice 
                //var qryNotConfirmed = (from inv in context.Invoices
                //                       where inv.IsConfirmed == false && inv.InvoiceTypeID == 1
                //                       orderby inv.InvoiceID ascending
                //                       select inv).ToList();

                //cNotConfrimedInvList.Clear();
                //foreach (var qry in qryNotConfirmed)
                //{
                //    cGen_Rent_Invoice oGenInv = new cGen_Rent_Invoice();
                //    oGenInv.SequenceNo = qry.SequenceNo;
                //    oGenInv.InvoiceNo = qry.InvoiceNo;
                //    oGenInv.InvoiceID = qry.InvoiceID;
                //    oGenInv.InvoiceTypeID = qry.InvoiceTypeID;
                //    oGenInv.SubInvTypeID = qry.SubInvTypeID;
                //    oGenInv.CustomerID = qry.CustomerID;
                //    oGenInv.CompanyID = qry.CompanyID;
                //    oGenInv.CompanyCode = context.Companies.Where(x => x.CompanyID == qry.CompanyID).FirstOrDefault().CompanyCode;
                //    oGenInv.LocationID = qry.LocationID;
                //    oGenInv.LocationCode = context.Locations.Where(x => x.LocationID == qry.LocationID).FirstOrDefault().LocationCode;
                //    oGenInv.InvDate = qry.InvoiceDate;
                //    oGenInv.Confirm = qry.IsConfirmed;
                //    oGenInv.ShopName = qry.ShopName;
                //    oGenInv.TotalRent = qry.TotalRentPerMonth;
                //    cNotConfrimedInvList.Add(oGenInv);
                //}

                //bsUnConfirmedInvList.DataSource = cNotConfrimedInvList;
                //cGen_Rent_InvoiceGridControl2.RefreshDataSource();

                //--

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

                this.gridView1.BestFitColumns();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnGenInv_Click(object sender, EventArgs e)
        {
            try
            {

                 if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                // querying INVOICE  (1 - Adjustmnet, 2 - CreditNote , 3 - Invoice) 

                ////Coment below to activate select All button..13May2014.

                ////if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                ////{ throw new Exception("Invalid Company"); }

                ////if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
                ////{ throw new Exception("Invalid Location"); }
                ////End..

                var qrySelected = (from i in cGenList
                                   join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
                                   orderby lvl.StdOrder ascending
                                   where i.Confirm == true
                                   select i).ToList();

              
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Confirming Rent Invoices"); }
                foreach (var qry in qrySelected)
                {
                  

                    if (qry.IsInvoiceNoGenerated == false)
                    {
                        qry.InvoiceNo = cGenerateInvoiceNo.generateInvoice(1, qry.LocationID, cRecentInvList, qrySelected, qry.CompanyID, qry.SubInvTypeID);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
                { throw new Exception("Invalid Location"); }
                if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                { throw new Exception("Invalid Company"); }

                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Confirming Rent Invoice");
                }

                var qryselected = from i in cGenList
                                  where i.Confirm == true
                                  select i;

                foreach (var qry in qryselected)
                {
                    Invoice oInv = (from inv in context.Invoices
                                    where inv.InvoiceID == qry.InvoiceID
                                    select inv).FirstOrDefault();
                    oInv.InvoiceNo = qry.InvoiceNo;

                    int index = qry.InvoiceNo.ToString().LastIndexOf('/');
                    qry.SequenceNo = int.Parse(qry.InvoiceNo.Substring(index + 1, 10 - (index + 1)).ToString());  // getting Int value of Invoice No string
                    oInv.SequenceNo = qry.SequenceNo;
                    this.splashScreenManager1.SetWaitFormDescription(oInv.InvoiceNo);
                    oInv.IsConfirmed = true;
                }


                if (splashScreenManager1.IsSplashFormVisible == true)
                {
                    splashScreenManager1.SetWaitFormDescription("Saving Data");
                }
             
                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    if (splashScreenManager1.IsSplashFormVisible == true)
                    {
                        splashScreenManager1.CloseWaitForm();
                    }

                    MessageBox.Show("Record Saved Successfully", "Save Success - Generate Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //// email alert 
                    int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.RentInvoiceConfirmed;
                    this.gridView1.OptionsPrint.ShowPrintExportProgress = false;
                    MMS.CustomClasses.cCommon_Functions.AddToEmailList(int.Parse(lookCompany.EditValue.ToString()), int.Parse(this.lookLocation.EditValue.ToString()), alert, "", MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.gridView1);


                    //--
                }

                load_data();
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.CloseWaitForm();
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dockPanel3_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSelectAll.Checked == true)
            {
                btnSelectAll.Text = "Unselect All";
                foreach (var qry in cGenList)
                {
                    qry.Confirm = true;
                }

            }

            else
            {
                btnSelectAll.Text = "Select All";
                foreach (var qry in cGenList)
                {
                    qry.Confirm = false;
                }

            }

            this.cGen_Rent_InvoiceGridControl.RefreshDataSource();
        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
        {
            checkSelected();

            //// Location..roshan..06oct2014
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

        private void lookUpInvoiceType_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lookUpInvoiceType.Text.ToString()))
            { return; }

            bool res = false;
            int subinvID = 0;
            res = int.TryParse(this.lookUpInvoiceType.EditValue.ToString(), out subinvID);
            if (res == false) 
            { 
                subinvID = 0; 
                return; 
            }

            var qrySelectionToUncheck = (from c in cGenList
                                         select c).ToList();

            foreach (var qry in qrySelectionToUncheck)
            {
                qry.Confirm = false;
            }

            var qrySelection = (from c in cGenList
                                where c.SubInvTypeID == subinvID 
                                select c).ToList();

            foreach (var qry in qrySelection)
            {
                qry.Confirm = true;
            }



            this.cGen_Rent_InvoiceGridControl.RefreshDataSource();

        }
    }
}