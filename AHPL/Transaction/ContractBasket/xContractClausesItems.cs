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

namespace MMS
{
    public partial class xContractClausesItems : DevExpress.XtraEditors.XtraForm
    {   
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xContractClausesItems()
        {
            InitializeComponent();
        }

        private void xContractClosureItems_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void Load_Data()
        {
            this.contract_Closure_ItemsBindingSource.DataSource = from c in context.Contract_Closure_Items
                                                                  orderby c.SortOrder ascending
                                                                  select c;
            this.closureMappingItemBindingSource.DataSource = (from m in context.ClosureMappingItems
                                                               select m).ToList();
            //this.enable_control(false, eRecStatus.eInit);

            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;

        }

        

        //private void cmdEdit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    //this.enable_control(true, eRecStatus.eEdit);
        //}

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.contract_Closure_ItemsBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.contract_Closure_ItemsBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.contract_Closure_ItemsBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.contract_Closure_ItemsBindingSource.MoveLast();
        //}

       
        

        private void closureMappingItemIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.closureMappingItemIDLookUpEdit.Text.ToString()))
            {
                if (string.IsNullOrEmpty(contractClosreItemNameTextEdit.Text.ToString().Trim()))
                {
                    DialogResult dlg = MessageBox.Show("Do you want to copy to the '" + closureMappingItemIDLookUpEdit.Text.ToString().Trim() + " '", "Copy to Left", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        contractClosreItemNameTextEdit.Text = closureMappingItemIDLookUpEdit.Text;
                        isMappedCheckEdit.Checked = true;
                        this.contract_Closure_ItemsBindingSource.EndEdit();
                    }

                }

            }
        }

        private void isMappedCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (isMappedCheckEdit.Checked == false)
            {
                closureMappingItemIDLookUpEdit.EditValue = 0;
                this.contract_Closure_ItemsBindingSource.EndEdit();
                this.closureMappingItemIDLookUpEdit.Enabled = false;
            }
            else
            {
                this.closureMappingItemIDLookUpEdit.Enabled = true;
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);


                //this.enable_control(true, eRecStatus.eAddNew);
                contract_Closure_ItemsBindingSource.AddNew();
                this.contractClosreItemNameTextEdit.Focus();

                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.contract_Closure_ItemsBindingSource.CancelEdit();
            Load_Data();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Load_Data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Validate();
            this.contract_Closure_ItemsBindingSource.EndEdit();


            // Validating fields
            if (string.IsNullOrEmpty(this.contractClosreItemNameTextEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.contractClosreItemNameTextEdit, "Invalid Contract Closure Item");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.contractClosreItemNameTextEdit, "");
            }


            if (string.IsNullOrEmpty(this.sortOrderSpinEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.sortOrderSpinEdit, "Invalid Sort Order");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.sortOrderSpinEdit, "");
            }

            int sortorder = 0;
            bool res = false;

            res = int.TryParse(this.sortOrderSpinEdit.EditValue.ToString(), out sortorder);
            if (res == false) { sortorder = 0; }

            if (sortorder == 0 || sortorder < 0)
            {
                dxErrorProvider1.SetError(sortOrderSpinEdit, "Invalid Sort Order");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(sortOrderSpinEdit, "");
            }
            ///-- 
            ///

            if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }
            splashScreenManager1.SetWaitFormDescription("Saving Data...");
            int succ = context.SaveChanges();
            if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            if (succ > 0)
            {

                MessageBox.Show("Record Saved Successfully..", "Save Success - Contract Closure Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_Data();
            }
            else
            {
                //enable_control(false, eRecStatus.eSave);
            }

            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = false;

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
