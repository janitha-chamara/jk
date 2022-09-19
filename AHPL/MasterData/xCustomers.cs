using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using DataTier;
namespace MMS
{
    public partial class xCustomers : DevExpress.XtraEditors.XtraForm//ParentForm.xParentDefault
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xCustomers()
        {
            InitializeComponent();
            
        }

        private void parentTopPanel_Click(object sender, EventArgs e)
        {

        }




        private bool validate_Data()
        {
            //using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                this.Validate();
                this.global_CustomersBindingSource.EndEdit();
                //this.customer_AttachmentsBindingSource.EndEdit();
                Global_Customers customer = (Global_Customers)this.global_CustomersBindingSource.Current;

                bool validated = false;

                string customername = this.customerNameTextEdit.Text.ToString().Trim();
                string SAPCode = this.sAPCustomerCodeTextEdit.Text.ToString().Trim();

                if (string.IsNullOrEmpty(customername))
                {
                    dxErrorProvider1.SetError(this.customerNameTextEdit, "Customer Name cannot be empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    validated = false;
                    return validated;
                }
                else
                {
                    dxErrorProvider1.SetError(this.customerNameTextEdit, "");
                    validated = true;
                }


                if (customer.CustomerID == 0)
                {

                    var custs = (from c in context.Global_Customers
                                 select c).ToList();
                    var custcode = custs.Find(item => item.SAPCustomerCode == SAPCode);
                    if (custcode != null)
                    {
                        dxErrorProvider1.SetError(this.sAPCustomerCodeTextEdit, "Customer SAP Code Already Exist");
                        validated = false;
                        return validated;
                    }
                    else
                    {
                        dxErrorProvider1.SetError(this.sAPCustomerCodeTextEdit, "");
                        validated = true;
                    }

                    var custname = custs.Find(item => item.CustomerName == customername);

                    if (custname != null)
                    //if (custs.Count > 0)
                    {
                        dxErrorProvider1.SetError(this.customerNameTextEdit, "Customer Name already exist, please enter different customer name", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);

                        validated = false;
                        return validated;
                    }
                    else
                    {
                        dxErrorProvider1.SetError(this.customerNameTextEdit, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                        validated = true;
                    }
                }
                ////context.SaveChanges(SaveOptions.None);
                ////context.Global_Customers.ApplyCurrentValues(customer);

                //}





                return validated;
            }
        }

        private void Save_Data()
        {
            this.global_CustomersBindingSource.EndEdit();
            //this.customer_AttachmentsBindingSource.EndEdit();
            int succ = 0;
            try
            {
                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    Global_Customers gcust = (Global_Customers)this.global_CustomersBindingSource.Current;
                    //context.Global_Customers.ApplyCurrentValues(gcust);


                    if (gcust.CustomerID == 0)
                    {
                        context.Global_Customers.AddObject(gcust);

                    }
                    else
                    {
                        ObjectStateEntry objstate;
                        context.ObjectStateManager.TryGetObjectStateEntry(gcust, out objstate);
                        objstate.ChangeState(EntityState.Modified);

                        context.Global_Customers.ApplyCurrentValues(gcust);
                    }


                    if (splashScreenManager2.IsSplashFormVisible == false) splashScreenManager2.ShowWaitForm();
                    splashScreenManager2.SetWaitFormDescription("Saving Data...");
                    succ = context.SaveChanges(SaveOptions.None);
                    if (splashScreenManager2.IsSplashFormVisible == true) splashScreenManager2.CloseWaitForm();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Saved Successfully", "Global Customer - Client Managment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //this.enable_control(false, eRecStatus.eSave);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void authShareCaptialLabel_Click(object sender, EventArgs e)
        {

        }

        private void xCustomers_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        public void load_dataByCustomer(int custid)
        {
            var qryCustomer = (from c in context.Global_Customers
                               where c.Discontinued == false && c.CustomerID == custid
                               orderby c.CustomerName ascending
                               select c).ToList();

            if (qryCustomer == null)
            {
                qryCustomer = (from c in context.Global_Customers
                               where c.Discontinued == false
                               orderby c.CustomerName ascending
                               select c).ToList();
                //this.enable_control(true, eRecStatus.eAddNew);
            }
            else
            {
                //this.enable_control(false, eRecStatus.eInit);
            }
            this.global_CustomersBindingSource.DataSource = qryCustomer;


        }


        private void LoadData()
        {
            try
            {
                {
                    this.global_CustomersBindingSource.DataSource = (from c in context.Global_Customers
                                                                     where c.Discontinued == false
                                                                     select c).ToList();

                    this.attachmentBindingSource.DataSource = (from attch in context.Attachments
                                                               select new { attch.AttachmentID, attch.AttachmentName }).ToList();
                    xtraTabControl1.SelectedTabPage = xtraTabPage1;


                    this.taxBindingSource.DataSource = (from t in context.Taxes
                                                        select new { t.TaxID, t.TaxCode, t.TaxName }).ToList();



                    //this.enable_control(false, eRecStatus.eInit);

                    btnNew.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void cmdUndo_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.global_CustomersBindingSource.CancelEdit();
            this.dxErrorProvider1.ClearErrors();
            //this.enable_control(false, eRecStatus.eInit);
            Refresh_data();

        }

        private void Refresh_data()
        {
            //using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var customers = from cust in context.Global_Customers
                                where cust.Discontinued == false
                                select cust;
                context.Refresh(RefreshMode.StoreWins, customers);
                this.global_CustomersBindingSource.DataSource = customers;
            }
        }

        private void cmdLast_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.global_CustomersBindingSource.MoveLast();

        }

        private void cmdPrev_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.global_CustomersBindingSource.MovePrevious();

        }

        private void cmdFirst_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.global_CustomersBindingSource.MoveFirst();
        }

        private void cmdNext_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.global_CustomersBindingSource.MoveNext();
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if  (e.Column ==colAttachmentID)
            //{
            //    var qrys = customer_AttachmentsBindingSource.List;


            //    List<int> clist = new List<int>();
            //    foreach (var qry in qrys)               {

            //        Customer_Attachments iCustAtch = (Customer_Attachments)qry;
            //        clist.Add(int.Parse(iCustAtch.AttachmentID.Value.ToString()));
            //    }

            //    // checking duplicating items
            //    var duplicates = clist.GroupBy(x => x).SelectMany(grp => grp.Skip(1)).ToList();                             

            //}

        }

        private void gridView4_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

            {
                var qrys = customer_AttachmentsBindingSource.List;


                List<int> clist = new List<int>();
                foreach (var qry in qrys)
                {

                    Customer_Attachments iCustAtch = (Customer_Attachments)qry;
                    clist.Add(int.Parse(iCustAtch.AttachmentID.Value.ToString()));
                }

                // checking duplicating items
                var duplicates = clist.GroupBy(x => x).SelectMany(grp => grp.Skip(1)).ToList();
                if (duplicates.Count > 0)
                {
                    e.ErrorText = "Duplicate Item Found, Please Remove the Duplicate Entry";

                    e.Valid = false;
                }
                else
                {
                    e.ErrorText = "";
                    e.Valid = true;

                }

            }

        }

        private void defaultTaxIDLabel_Click(object sender, EventArgs e)
        {

        }



        private void global_CustomersBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (global_CustomersBindingSource.Position != -1)
            {
                Global_Customers oGCust = (Global_Customers)this.global_CustomersBindingSource.Current;
                if (oGCust != null)
                {
                    int custid = oGCust.CustomerID;

                    var qryCT = (from ct in context.Customer_Taxes
                                 join tx in context.Taxes on ct.TaxID equals tx.TaxID
                                 where ct.CustomerID == custid && tx.IsMandatory == false
                                 select new { tx.IsMandatory, tx.TaxID }).ToList();

                    if (qryCT.Count == 0)
                    {
                        //labelControl1.Appearance.BackColor2 = Color.Green;
                    }
                    else
                    {
                        //labelControl1.Appearance.BackColor2 = Color.Red;
                    }

                    //foreach (var qry in qryCT)
                    //{
                    //    if (qry.IsMandatory == false)
                    //    {

                    //    }

                    //}



                }

            }

        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colTaxRegNo)
            {



                if (string.IsNullOrEmpty(e.Value.ToString()))
                {

                    gridView2.SetColumnError(colTaxRegNo, "Invalid Tax Registration No");
                    return;
                }

            }
        }

        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colTaxRegNo)
            {



                if (string.IsNullOrEmpty(e.Value.ToString()))
                {

                    gridView2.SetColumnError(colTaxRegNo, "Invalid Tax Registration No");
                    return;
                }

            }
        }

        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var qryFocus = (Customer_Taxes)this.gridView2.GetFocusedRow();

            if (qryFocus != null)
            {

                if (string.IsNullOrEmpty(qryFocus.TaxRegNo))
                {

                    e.ErrorText = "Invalid Tax Regisration No";
                    e.Valid = false;
                }
                else
                {
                    e.ErrorText = "";
                    e.Valid = true;
                }
            }


        }

        private void isGLACCDefualtLabel_Click(object sender, EventArgs e)
        {

        }

        private void gL_CodeTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gL_CodeLabel_Click(object sender, EventArgs e)
        {

        }

        private void isGLACCDefualtLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void isGLACCDefualtCheckEdit_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.enable_control(true, eRecStatus.eAddNew);
                this.global_CustomersBindingSource.AddNew();
                this.sAPCustomerCodeTextEdit.Focus();

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

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.enable_control(true, eRecStatus.eEdit);

                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Validate();
            this.global_CustomersBindingSource.EndEdit();
            this.customer_TaxesBindingSource.EndEdit();
            this.customer_AttachmentsBindingSource.EndEdit();

            //validating customer name
            if (string.IsNullOrEmpty(this.customerNameTextEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.customerNameTextEdit, "Customer Name cannot be empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.customerNameTextEdit, "");
            }


            // validating company address
            if (string.IsNullOrEmpty(this.companyAddressMemoEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.companyAddressMemoEdit, "Invalid Company Address");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.companyAddressMemoEdit, "");
            }

            //validating Tele No
            if (string.IsNullOrEmpty(this.telNosTextEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.telNosTextEdit, "Invalid Telephone No");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.telNosTextEdit, "");
            }

            //Validating Fax no 

            if (string.IsNullOrEmpty(this.faxNosTextEdit.ToString()))
            {
                dxErrorProvider1.SetError(this.faxNosTextEdit, "Invalid Fax No");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.faxNosTextEdit, "");
            }

            // validating Email Address this.emailAddressTextEdit.Text.ToString())
            if (string.IsNullOrEmpty(txtemails.Text.ToString()))
            {
                dxErrorProvider1.SetError(txtemails, "Invalid Email Address");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(txtemails, "");
            }

            // check customer name duplicaiton
            Global_Customers oCustomer = (Global_Customers)this.global_CustomersBindingSource.Current;
            if (oCustomer.CustomerID == 0)
            {
                var qryCust = (from c in context.Global_Customers
                               where c.CustomerName == oCustomer.CustomerName && c.Discontinued == false
                               select new { c.CustomerName }).FirstOrDefault();
                if (qryCust != null)
                {
                    MessageBox.Show("Customer Name '" + qryCust.CustomerName + "' already exist", "Dupplicate entry - Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oCustomer.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                oCustomer.CreatedDate = DateTime.Now;
                // tax customer
                List<Customer_Taxes> custTaxList = oCustomer.Customer_Taxes.ToList();
                if (custTaxList.Count > 0)
                {
                    oCustomer.IsTaxCustomer = true;
                }
                else { oCustomer.IsTaxCustomer = false; }
                //---

                context.Global_Customers.AddObject(oCustomer);

            }
            else
            {
                // tax customer 
                List<Customer_Taxes> custTaxList = oCustomer.Customer_Taxes.ToList();
                if (custTaxList.Count > 0)
                {
                    oCustomer.IsTaxCustomer = true;
                }
                else { oCustomer.IsTaxCustomer = false; }

                oCustomer.UpdatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                oCustomer.UpdatedDate = DateTime.Now;

                context.Global_Customers.ApplyCurrentValues(oCustomer);

            }


            // deleting deleted items in the customer tax 

            var qryDeleted = (from c in context.Customer_Taxes
                              where c.Deleted == true
                              select c).ToList();
            foreach (var qry in qryDeleted)
            {
                context.Customer_Taxes.DeleteObject(qry);

            }

            // - 

            //try
            {
                int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    //this.Close();

                    btnNew.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    //this.enable_control(false, eRecStatus.eSave);
                }
            }

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                List<DataTier.Reports.Master.GlobalCustomers> gCustList = new List<DataTier.Reports.Master.GlobalCustomers>();
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {


                    var qryCust = (from c in context.Global_Customers
                                   where c.Discontinued == false
                                   orderby c.CustomerName
                                   select c).ToList();
                    foreach (var qry in qryCust)
                    {
                        DataTier.Reports.Master.GlobalCustomers gCust = new DataTier.Reports.Master.GlobalCustomers();
                        gCust.CustomerID = qry.CustomerID;
                        gCust.CustomerName = qry.CustomerName;
                        gCust.Address = qry.CompanyAddress;
                        gCust.SAPCustomerCode = qry.SAPCustomerCode;
                        gCust.RegNo = qry.RegNo;
                        gCustList.Add(gCust);
                    }

                }

                if (gCustList.Count == 0)
                { return; }

                if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Generating Report"); }

                rptMain _main = new rptMain();
                DataTier.Reports.Master.rptGlobalCustomers rptGcust = new DataTier.Reports.Master.rptGlobalCustomers();
                _main.crystalReportViewer1.ReportSource = rptGcust;
                rptGcust.Database.Tables["DataTier_Reports_Master_GlobalCustomers"].SetDataSource(gCustList);

                _main.Show();
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }

            }
            catch (Exception ex)
            {
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool havePermission = MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                if (havePermission)
                {
                    DialogResult dlg = MessageBox.Show("Do you want to delete current record?", "Delete - Master Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == System.Windows.Forms.DialogResult.Yes)
                    {
                        Global_Customers oGus = (Global_Customers)global_CustomersBindingSource.Current;
                        int cutid = oGus.CustomerID;

                        var qryCust = (from c in context.Global_Customers
                                       where c.CustomerID == cutid
                                       select c).FirstOrDefault();

                        qryCust.Discontinued = true;
                        qryCust.DiscontinuedDate = DateTime.Now;
                        qryCust.UpdatedBy = CustomClasses.cCommon_Functions.LoggedUserID;
                        qryCust.UpdatedDate = DateTime.Now;


                        context.SaveChanges();

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

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (splashScreenManager2.IsSplashFormVisible == false)
            {
                splashScreenManager2.ShowWaitForm();
                splashScreenManager2.SetWaitFormDescription("Refreshing Data");
            }
            Refresh_data();
            //this.enable_control(false, eRecStatus.eInit);

            if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
        }


    }
}
