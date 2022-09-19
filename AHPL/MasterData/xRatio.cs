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
    public partial class xRatio : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xRatio()
        {
            InitializeComponent();
        }

        private void xRatio_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {
            this.ratioBindingSource.DataSource = context.Ratios;

            //this.enable_control(false, eRecStatus.eInit);

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        

        //private void cmdEdit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    //this.enable_control(true, eRecStatus.eEdit);
        //}

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.ratioBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.ratioBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.ratioBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.ratioBindingSource.MoveLast();
        //}

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                DialogResult dlg = MessageBox.Show("Do you want to delete the current record?", "Delete - Ratio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    ratioBindingSource.RemoveCurrent();
                    try
                    {
                        context.SaveChanges();

                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ratioBindingSource.EndEdit();

                // validating ratio code
                if (string.IsNullOrEmpty(this.ratioCodeTextEdit.Text.ToString()))
                {

                    dxErrorProvider1.SetError(this.ratioCodeTextEdit, "Invalid Code");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.ratioCodeTextEdit, "");
                }


                //validating ratio value 
                int ratioval = 0;
                bool res = int.TryParse(this.ratioNoSpinEdit.EditValue.ToString(), out ratioval);
                if (res == false) { ratioval = 0; }

                if (ratioval == 0 || ratioval < 0)
                {
                    dxErrorProvider1.SetError(this.ratioNoSpinEdit, "Invalid Ratio Value");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.ratioNoSpinEdit, "");
                }




                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Ration Meter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                load_data();
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
                this.ratioBindingSource.AddNew();
                this.ratioNoSpinEdit.Focus();

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

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ratioBindingSource.CancelEdit();
            load_data();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_data();
        }

        
    }
}
