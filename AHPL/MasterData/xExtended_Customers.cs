using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using DataTier;
using System.Transactions;
namespace MMS
{
    public partial class xExtended_Customers : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();

        public xExtended_Customers()
        {
            InitializeComponent();
        }



        private void xExtended_Customers_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {

            try
            {
                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    // primary entity
                    var qryExCust = (from ec in context.Extended_Customers
                                     select ec).ToList();
                    this.extended_CustomersBindingSource.DataSource = qryExCust;


                    //global customer
                    load_global_customer();

                    //locations
                    var qryloc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
                    this.locationBindingSource.DataSource = qryloc;

                    //companies
                    var qryComp = (from com in context.Companies
                                   select new { com.CompanyID, com.CompanyCode, com.CompanyName }).ToList();
                    this.companyBindingSource.DataSource = qryComp;

                    // Utility
                    var qryutility = (from u in context.Utility_Rates
                                      select u).ToList();
                    this.utilityRatesBindingSource.DataSource = qryutility;

                    //transaction categories // Invoice Types
                    var qrytrscat = (from t in context.Invoice_Types
                                     select t).ToList();
                    this.transactionCategoryBindingSource.DataSource = qrytrscat;


                    // Tax
                    var qryTax = (from t in context.Taxes
                                  select new { t.TaxID, t.TaxCode, t.TaxName }).ToList();
                    this.taxBindingSource.DataSource = qryTax;


                    ////this.enable_control(false, eRecStatus.eInit);

                    btnNew.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }

        private void load_global_customer()
        {
            //using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCust = (from gc in context.Global_Customers
                               where gc.Discontinued == false
                               select new { gc.CustomerID, gc.CustomerName, gc.SAPCustomerCode }).ToList();
                this.globalCustomersBindingSource.DataSource = qryCust;
            }
        }

        private void customerIDSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.customerIDSearchLookUpEdit.Text.ToString()))
                {
                    //using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {

                        int custid = 0;
                        bool res = int.TryParse(this.customerIDSearchLookUpEdit.EditValue.ToString(), out custid);
                        if (res == false) { custid = 0; }

                        if (custid > 0)
                        {
                            Extended_Customers extendedCustomer = (Extended_Customers)this.extended_CustomersBindingSource.Current;
                            if (extendedCustomer.ExtendedCustomerID != 0) // if not add new status 
                            {
                                return;
                            }

                            var qry = (from c in context.Global_Customers
                                       where c.CustomerID == custid
                                       select new { c.SAPCustomerCode }).FirstOrDefault();
                            if (qry.SAPCustomerCode != null)
                            {

                                extendedCustomer.CustomerID = custid;
                                extendedCustomer.SAPAlternateCode = qry.SAPCustomerCode;
                                dxErrorProvider1.SetError(this.sAPAlternateCodeTextEdit, "You can extend the SAP Customer Code different SAP code for the customer", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                            }
                            else
                            {
                                this.sAPAlternateCodeTextEdit.Text = "";
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void customerIDLabel_Click(object sender, EventArgs e)
        {

        }

        private void locationIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(this.locationIDLookUpEdit.Text.ToString()))
            //{
            //    int intlocid = 0;
            //    bool res = int.TryParse(this.locationIDLookUpEdit.EditValue.ToString(), out intlocid);
            //    if (res == false) { intlocid = 0; }
            //    if (intlocid > 0)
            //    {
            //        var qryCompany = (from co in context.Companies
            //                          where co.LocationID == intlocid
            //                          select new { co.CompanyID,co.CompanyCode,co.CompanyName }).ToList();
            //       //seting the datasource for the company to the locaiton
            //        this.companyIDLookUpEdit.Properties.DataSource = qryCompany;

            //        //--


            //        var qryCompnayFirst = qryCompany.FirstOrDefault();



            //        if (qryCompany.Count > 0)
            //        {
            //            this.companyIDLookUpEdit.EditValue = qryCompnayFirst.CompanyID;

            //        }

            //    }
            //    this.extended_CustomersBindingSource.EndEdit();
            //}
        }

        private void companyIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

            //// Location..roshan..06oct2014
            int intcompid = 0;
            bool res = int.TryParse(Convert.ToString(this.companyIDLookUpEdit.EditValue), out intcompid);
            if (res == false)
            {
                return;
            }

            this.locationBindingSource.DataSource = (from c in context.Companies
                                                     join l in context.Locations on c.LocationID equals l.LocationID
                                                     where c.CompanyID == intcompid
                                                     select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();


        }





        private bool validateFields()
        {
            this.Validate();
            this.extended_CustomersBindingSource.EndEdit();

            bool validated = false;

            //validating location
            if (string.IsNullOrEmpty(this.locationIDLookUpEdit.Text.ToString().Trim()))
            {
                dxErrorProvider1.SetError(this.locationIDLookUpEdit, "Invalid Location");
                validated = false;
                return validated;
            }
            else
            {
                validated = true;
            }

            // validation company 
            if (string.IsNullOrEmpty(this.companyIDLookUpEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.companyIDLookUpEdit, "Invalid Company");
                validated = false;
                return validated;
            }
            else
            {
                dxErrorProvider1.SetError(this.companyIDLookUpEdit, "");
                validated = true;
            }

            //validating customer 
            if (string.IsNullOrEmpty(this.customerIDSearchLookUpEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.customerIDSearchLookUpEdit, "Invalid Customer");
                validated = false;
                return validated;

            }
            else
            {
                dxErrorProvider1.SetError(this.customerIDSearchLookUpEdit, "");
                validated = true;
            }

            //validating sap customer code 
            if (string.IsNullOrEmpty(this.sAPAlternateCodeTextEdit.Text.ToString().Trim()))
            {
                dxErrorProvider1.SetError(this.sAPAlternateCodeTextEdit, "Invalid SAP Customer Code");
                validated = false;
                return validated;
            }
            else
            {
                dxErrorProvider1.SetError(this.sAPAlternateCodeTextEdit, "");
                validated = true;
            }

            return validated;

        }


        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    extended_CustomersBindingSource.MoveNext();


        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    extended_CustomersBindingSource.MoveLast();

        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    extended_CustomersBindingSource.MovePrevious();

        //}

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    extended_CustomersBindingSource.MoveFirst();

        //}



        private void refresh_data()
        {
            //throw new NotImplementedException();
        }

        //private void cmdUndo_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.extended_CustomersBindingSource.CancelEdit();
        //    dxErrorProvider1.ClearErrors();
        //    load_data();
        //    ////this.enable_control(false, eRecStatus.eInit);

        //}

        //private void cmdDelete_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{




        //}

        private void linkGCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool res = false;
            int custid = 0;

            if (!string.IsNullOrEmpty(this.customerIDSearchLookUpEdit.Text.ToString()))
            {
                res = int.TryParse(this.customerIDSearchLookUpEdit.EditValue.ToString(), out custid);
            }



            xCustomers cust = new xCustomers();
            //cust.Load+=new EventHandler(cust_Load);
            cust.FormClosing += new FormClosingEventHandler(cust_FormClosing);

            cust.Show(this);
            if (custid > 0)
            {
                cust.load_dataByCustomer(custid);
            }




        }

        private void cust_FormClosing(object sender, FormClosingEventArgs e)
        {
            load_global_customer();

        }

        private void isGLACCDefualtCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            //if (isGLACCDefualtCheckEdit.Checked == true)
            //{
            //    this.gL_CodeTextEdit.Properties.ReadOnly = true;
            //}
            //else
            //{
            //    this.gL_CodeTextEdit.Properties.ReadOnly = false;
            //}
        }

        //private void cmdPrint_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{

        //}

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                List<DataTier.Reports.Master.ExtendedCustomers> eCustList = new List<DataTier.Reports.Master.ExtendedCustomers>();

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryEcust = (from ec in context.Extended_Customers
                                    join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                    join c in context.Companies on ec.CompanyID equals c.CompanyID
                                    join l in context.Locations on ec.LocationID equals l.LocationID
                                    orderby c.CompanyName, l.LocationName, gc.CustomerName
                                    select new { GlobalCustomerID = gc.CustomerID, ExtendedCustomerID = ec.ExtendedCustomerID, gc.CustomerName, gc.RegNo, gc.CompanyAddress, ec.SAPAlternateCode, Company = c.CompanyName, Location = l.LocationName }).ToList();
                    foreach (var qry in qryEcust)
                    {
                        DataTier.Reports.Master.ExtendedCustomers eCust = new DataTier.Reports.Master.ExtendedCustomers();
                        eCust.ExtendedCustomerID = qry.ExtendedCustomerID;
                        eCust.GlobalCustomerID = qry.GlobalCustomerID;
                        eCust.SAPCustomerCode = qry.SAPAlternateCode;
                        eCust.CustomerName = qry.CustomerName;
                        eCust.Adddress = qry.CompanyAddress;
                        eCust.Company = qry.Company;
                        eCust.Location = qry.Location;
                        eCustList.Add(eCust);
                    }

                    if (eCustList.Count == 0) { return; }

                    rptMain _main = new rptMain();
                    DataTier.Reports.Master.rptExtendedCustomers rptECust = new DataTier.Reports.Master.rptExtendedCustomers();
                    _main.crystalReportViewer1.ReportSource = rptECust;
                    rptECust.Database.Tables["DataTier_Reports_Master_ExtendedCustomers"].SetDataSource(eCustList);
                    _main.Show();




                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);


                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    this.extended_CustomersBindingSource.EndEdit();



                    DialogResult dlg = MessageBox.Show("Do you want to delete current record?", "Delete - Extended Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == System.Windows.Forms.DialogResult.Yes)
                    {
                        Extended_Customers oextendedCustomer = (Extended_Customers)extended_CustomersBindingSource.Current;

                        if (oextendedCustomer == null)
                        { return; }



                        using (TransactionScope trs = new TransactionScope())
                        {

                            // check extended customer is already in the contract 
                            var qryExc = (from exc in context.Contracts
                                          where exc.CustomerID == oextendedCustomer.ExtendedCustomerID
                                          select new { exc.CustomerID }).ToList();
                            if (qryExc.Count > 0)
                            {
                                MessageBox.Show("Extended Customer already integrated in the Contracts, Therefore you cannot delete this customer", "Cannot Delete - Extended Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            var qryDet = (from det in context.Customer_MailingOptions
                                          where det.ExtendedCustomerID == oextendedCustomer.ExtendedCustomerID
                                          select det).ToList();
                            foreach (var qry in qryDet)
                            {
                                context.Customer_MailingOptions.DeleteObject(qry);
                            }

                            context.Extended_Customers.DeleteObject(oextendedCustomer);
                            context.SaveChanges();
                            trs.Complete(); // completeing transaction


                        }

                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.extended_CustomersBindingSource.CancelEdit();
            dxErrorProvider1.ClearErrors();
            load_data();
            ////this.enable_control(false, eRecStatus.eInit);
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_data();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);


                Extended_Customers extededCustomer = (Extended_Customers)this.extended_CustomersBindingSource.Current;
                if (extededCustomer != null)
                {
                    //enable_control(true, eRecStatus.eEdit);
                    locationIDLookUpEdit.Properties.ReadOnly = true;
                    companyIDLookUpEdit.Properties.ReadOnly = true;
                    customerIDSearchLookUpEdit.Properties.ReadOnly = true;
                    //sAPAlternateCodeTextEdit.Properties.ReadOnly = true;

                    btnNew.Enabled = false;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.extended_CustomersBindingSource.EndEdit();
                this.extendedCustomer_GLCodesBindingSource.EndEdit();


                ////validating location
                if (string.IsNullOrEmpty(this.locationIDLookUpEdit.Text.ToString().Trim()))
                {
                    dxErrorProvider1.SetError(this.locationIDLookUpEdit, "Invalid Location");
                    return;
                }

                //// validation company 
                if (string.IsNullOrEmpty(this.companyIDLookUpEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.companyIDLookUpEdit, "Invalid Company");
                    return;

                }
                else
                {
                    dxErrorProvider1.SetError(this.companyIDLookUpEdit, "");
                }


                ////validating customer 
                if (string.IsNullOrEmpty(this.customerIDSearchLookUpEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.customerIDSearchLookUpEdit, "Invalid Customer");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.customerIDSearchLookUpEdit, "");
                }

                int locid = 0; int compid = 0; int custid = 0; string SapCode = "";
                bool res = int.TryParse(this.locationIDLookUpEdit.EditValue.ToString(), out locid);
                if (res == false) { locid = 0; }

                res = int.TryParse(this.companyIDLookUpEdit.EditValue.ToString(), out compid);
                if (res == false) { compid = 0; }

                res = int.TryParse(customerIDSearchLookUpEdit.EditValue.ToString(), out custid);
                if (res == false) { custid = 0; }

                SapCode = this.sAPAlternateCodeTextEdit.Text.ToString().Trim();

                Extended_Customers oExtendedCustomer = (Extended_Customers)this.extended_CustomersBindingSource.Current;

                if (oExtendedCustomer.ExtendedCustomerID == 0)
                {
                    var qryDuplication = (from ec in context.Extended_Customers
                                          where ec.LocationID == oExtendedCustomer.LocationID && ec.CompanyID == oExtendedCustomer.CompanyID && ec.CustomerID == oExtendedCustomer.CustomerID
                                          select new { ec.ExtendedCustomerID }).ToList();
                    if (qryDuplication.Count > 0)
                    {
                        MessageBox.Show("You cannot enter duplicae item for the Same customer with the Locaiton and Company", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    oExtendedCustomer.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oExtendedCustomer.CreatedDate = DateTime.Now;

                    //// adding object to the context 
                    context.Extended_Customers.AddObject(oExtendedCustomer);
                }
                else
                {
                    //// editing object 
                    oExtendedCustomer.LastUpdated = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oExtendedCustomer.LastUpdateDate = DateTime.Now;
                    context.Extended_Customers.ApplyCurrentValues(oExtendedCustomer);

                    
                }

                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Save Success - Extended Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_data();
                }
                else
                {
                    ////this.enable_control(false, eRecStatus.eSave);
                }


                btnSave.Enabled = false;

            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //enable_control(true, eRecStatus.eAddNew);
                extended_CustomersBindingSource.AddNew();
                this.companyIDLookUpEdit.Focus();

                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
