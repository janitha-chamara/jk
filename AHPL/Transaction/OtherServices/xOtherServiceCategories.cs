using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using AHPL.DataTier;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using DataTier;

namespace MMS
{
    public partial class xOtherServiceCategories : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xOtherServiceCategories()
        {
            InitializeComponent();
        }

        private void otherServiceCategoryGridControl_Click(object sender, EventArgs e)
        {

        }

        

        private void xOtherServiceCategories_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {

            this.otherServiceCategoryBindingSource.DataSource = context.OtherServiceCategories;
            //this.enable_control(false, eRecStatus.eInit);

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

        }

       
        

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    otherServiceCategoryBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    otherServiceCategoryBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    otherServiceCategoryBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    otherServiceCategoryBindingSource.MoveNext();
        //}

      

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //enable_control(true, eRecStatus.eEdit);

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

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.enable_control(true, eRecStatus.eAddNew);
                this.otherServiceNameTextEdit.Focus();
                otherServiceCategoryBindingSource.AddNew();

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

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.otherServiceCategoryBindingSource.CancelEdit();
            load_data();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.load_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Validate();
            this.otherServiceCategoryBindingSource.EndEdit();

            if (string.IsNullOrEmpty(this.otherServiceNameTextEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.otherServiceNameTextEdit, "Invalid Other Service Cateogry Name");
                return;

            }
            else
            {
                dxErrorProvider1.SetError(this.otherServiceNameTextEdit, "");
            }

            int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            if (succ > 0)
            {
                MessageBox.Show("Record Saved Successfully", "Save Success - Other Service Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            load_data();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                OtherServiceCategory otherserviceCategory = (OtherServiceCategory)this.otherServiceCategoryBindingSource.Current;

                DialogResult dlg = MessageBox.Show("Do you want to delete current record", "Delete Other Service Category?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    if (otherserviceCategory != null)
                    {
                        // check transaction integration 

                        var qryInv = (from inv in context.Invoices
                                      where inv.OtherServiceID == otherserviceCategory.OtherServiceID
                                      select new { inv.InvoiceID }).ToList();
                        if (qryInv.Count > 0)
                        {
                            MessageBox.Show("Other Service Category '" + otherserviceCategory.OtherServiceName + "' cannot be deleted, already integrated in invoices", "Cannot Delete - Other Service Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            OtherServiceCategory otherserviceCategoryDelete = (from os in context.OtherServiceCategories
                                                                               where os.OtherServiceID == otherserviceCategory.OtherServiceID
                                                                               select os).FirstOrDefault();
                            context.OtherServiceCategories.DeleteObject(otherserviceCategoryDelete);

                            int succ = context.SaveChanges();
                            if (succ > 0)
                            {
                                MessageBox.Show("Record Deleted Successfully...", "Delete Success-Other Service Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }


                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
