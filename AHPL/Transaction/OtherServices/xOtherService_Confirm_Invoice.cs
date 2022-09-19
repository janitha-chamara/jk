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
    public partial class xOtherService_Confirm_Invoice : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<cGen_Rent_Invoice> cGenList = new List<cGen_Rent_Invoice>();
        List<cGen_Rent_Invoice> cRecentInvList = new List<cGen_Rent_Invoice>();

        public xOtherService_Confirm_Invoice()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenInv_Click(object sender, EventArgs e)
        {
            try
            {
                
                 if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                ////Coment below to activate select All button..13May2014.
                ////if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
                ////{ throw new Exception("Invalid Location"); }
                ////if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                ////{ throw new Exception("Invalid Company"); }
                ////End..

                //load_recentInvoiceList();
                // querying INVOICE  (1 - Adjustmnet, 2 - CreditNote , 3 - Invoice) 
                var qrySelected = (from i in cGenList
                                   where i.Confirm == true
                                   select i).ToList();
               
                
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormCaption("Generating Invoice No(s)"); }
                foreach (var qry in qrySelected)
                {
                   

                    if (qry.IsInvoiceNoGenerated == false)
                    {
                        qry.InvoiceNo = cGenerateInvoiceNo.GenerateOtherServiceInvoice(qry.LocationID, cRecentInvList, qrySelected, qry.SubInvTypeID, qry.CompanyID, qry.OtherServiceID);
                        int index = qry.InvoiceNo.ToString().LastIndexOf('/');
                        qry.SequenceNo = int.Parse(qry.InvoiceNo.Substring(index + 1, 10 - (index + 1)).ToString());  // getting Int value of Invoice No string
                        qry.IsInvoiceNoGenerated = true;

                        splashScreenManager1.SetWaitFormCaption(qry.InvoiceNo);

                    }

                }

                cGen_Rent_InvoiceGridControl.RefreshDataSource();
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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


                var qryselected = (from i in cGenList
                                   where i.Confirm == true
                                   select i).ToList();
                if (qryselected.Count == 0)
                { return; }
               
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Confirming Invoice No(s)"); }

                foreach (var qry in qryselected)
                {
                    

                    Invoice oInv = (from inv in context.Invoices
                                    where inv.InvoiceID == qry.InvoiceID
                                    select inv).FirstOrDefault();
                    oInv.InvoiceNo = qry.InvoiceNo;

                    int index = qry.InvoiceNo.ToString().LastIndexOf('/');
                    qry.SequenceNo = int.Parse(qry.InvoiceNo.Substring(index + 1, 10 - (index + 1)).ToString());  // getting Int value of Invoice No string
                    oInv.SequenceNo = qry.SequenceNo;

                    oInv.IsConfirmed = true;

                    splashScreenManager1.SetWaitFormDescription(oInv.InvoiceNo);

                }

                splashScreenManager1.SetWaitFormDescription("Saving Data");
                

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
                load_data();
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xOtherService_Confirm_Invoice_Load(object sender, EventArgs e)
        {
            load_data();
        }
        private void load_data()
        {

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

            

            //loading Processed and Not Confirmed invoice list
            var qryinv = (from inv in context.Invoices
                          where inv.IsConfirmed == false && inv.InvoiceTypeID == 3 && inv.IsProcessed == true && inv.InvoiceState == 1
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
                oGenInv.ProfomaNo = qry.ProfomaNo;
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
            cGenList = (from c in cGenList
                        orderby c.CompanyID, c.LocationID, c.SubInvTypeID
                        select c).ToList();

            this.cGen_Rent_InvoiceBindingSource.DataSource = cGenList;
            this.cGen_Rent_InvoiceGridControl.RefreshDataSource();
            //---





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


            // Loading Recent Invoice List 
            //load_recentInvoiceList();

            // ----

        }

        //private void load_recentInvoiceList()
        //{
        //    try
        //    {
        //        var qryinvRecent = (from inv in context.Invoices
        //                            where inv.IsConfirmed == true && inv.InvoiceTypeID == 3
        //                            orderby inv.InvoiceID descending
        //                            select inv).ToList().Take(10);
        //        cRecentInvList.Clear();

        //        foreach (var qry in qryinvRecent)
        //        {
        //            cGen_Rent_Invoice oGenInv = new cGen_Rent_Invoice();
        //            oGenInv.SequenceNo = qry.SequenceNo;
        //            oGenInv.InvoiceNo = qry.InvoiceNo;
        //            oGenInv.InvoiceID = qry.InvoiceID;
        //            oGenInv.InvoiceTypeID = qry.InvoiceTypeID;
        //            oGenInv.CompanyID = qry.CompanyID;
        //            oGenInv.CompanyCode = context.Companies.Where(x => x.CompanyID == qry.CompanyID).FirstOrDefault().CompanyCode;
        //            oGenInv.LocationID = qry.LocationID;
        //            oGenInv.LocationCode = context.Locations.Where(x => x.LocationID == qry.LocationID).FirstOrDefault().LocationCode;
        //            oGenInv.InvDate = qry.InvoiceDate;
        //            oGenInv.Confirm = qry.IsConfirmed;
        //            oGenInv.ShopName = qry.ShopName;
        //            oGenInv.TotalRent = qry.TotalRentPerMonth;
        //            oGenInv.CustomerID = qry.CustomerID;
        //            oGenInv.SubInvTypeID = qry.SubInvTypeID;
        //            oGenInv.OtherServiceID = qry.OtherServiceID;
        //            cRecentInvList.Add(oGenInv);
        //        }


        //        bsRecentRentList.DataSource = cRecentInvList;
        //        cGen_Rent_InvoiceGridControl1.RefreshDataSource();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}



        private void btnSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSelectAll.Checked == true)
            {
                this.btnSelectAll.Text = "Unselect All";
                foreach (var qry in cGenList)
                {
                    qry.Confirm = true;

                }
            }
            else
            {
                this.btnSelectAll.Text = "Select All";
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

                var qryDelete = (from c in cGenList
                                 where c.Delete == true
                                 select c).ToList();

                if (qryDelete.Count == 0) { return; }


                DialogResult dl = MessageBox.Show("Do you want to delete selected invoice(s)", "Delete Confirmation - Other Service Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == System.Windows.Forms.DialogResult.No)
                { return; }

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
                    this.Close();
                }




            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDeleteSelectAll.Checked == true)
            {
                this.btnDeleteSelectAll.Text = "Unselect All For Delete";
                foreach (var qry in cGenList)
                {
                    qry.Delete = true;

                }
            }
            else
            {
                this.btnDeleteSelectAll.Text = "Select All For Delete";
                foreach (var qry in cGenList)
                {
                    qry.Delete = false;
                }
            }

            this.cGen_Rent_InvoiceGridControl.RefreshDataSource();
        }
    }
}