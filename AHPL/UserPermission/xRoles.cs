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
    public partial class xRoles : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xRoles()
        {
            InitializeComponent();
        }

        private void xRoles_Load(object sender, EventArgs e)
        {

            load_data();


        }

        private void load_data()
        {
            var qryRoles = (from r in context.Permission_Roles
                            select r).ToList();
            this.permission_RolesBindingSource.DataSource = qryRoles;

            //this.enable_control(false, eRecStatus.eInit);

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

        }

        

       

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_RolesBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_RolesBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_RolesBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_RolesBindingSource.MoveLast();
        //}

        
       

       

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Excel (*.xlsx)|*.xlsx";
                saveDlg.ShowDialog();
                string filename = saveDlg.FileName;
                this.gridView1.OptionsPrint.AutoWidth = false;
                if (string.IsNullOrEmpty(filename.ToString()))
                { return; }
                this.gridView1.ExportToXlsx(filename);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.permission_RolesBindingSource.CancelEdit();
            load_data();
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

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.enable_control(true, eRecStatus.eAddNew);
                this.permission_RolesBindingSource.AddNew();
                this.roleNameTextEdit.Focus();

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

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.permission_RolesBindingSource.EndEdit();

                //validating fields
                if (string.IsNullOrEmpty(this.roleNameTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.roleNameTextEdit, "Invalid Role Name");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.roleNameTextEdit, "");
                }

                // -- 

                Permission_Roles _roles = (Permission_Roles)this.permission_RolesBindingSource.Current;
                if (_roles == null) { return; }
                if (_roles.RoleID == 0) //add new status 
                {
                    var qryDupp = (from r in context.Permission_Roles
                                   where r.RoleName == _roles.RoleName
                                   select r).ToList();
                    if (qryDupp.Count > 0)
                    {
                        MessageBox.Show("Already '" + _roles.RoleName + "' Exist", "Dupplication - Roles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    context.Permission_Roles.AddObject(_roles);
                }
                else
                {
                    context.Permission_Roles.ApplyCurrentValues(_roles);
                }

                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully...", "Save Success - Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_data();
                }
                else
                {
                    //enable_control(false, eRecStatus.eSave);
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

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.permission_RolesBindingSource.EndEdit();

                Permission_Roles roleObject = (Permission_Roles)this.permission_RolesBindingSource.Current;
                if (roleObject == null) { return; }

                DialogResult dlg = MessageBox.Show("Do you want to delete current role '" + roleObject.RoleName + "' ?", "Delete Confirmation - Role", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.No) { return; }

                var qryUser = (from u in context.Permission_Users
                               where u.RoleID == roleObject.RoleID
                               select u).ToList();
                if (qryUser.Count > 0)
                {
                    string userName = qryUser.FirstOrDefault().UserName;
                    throw new Exception("Cannot delete the selected Role, role already integrated with the  user '" + userName + "'");
                }

                context.Permission_Roles.DeleteObject(roleObject);

                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    this.permission_RolesBindingSource.RemoveCurrent();
                    MessageBox.Show("Role Deleted Successfully..", "Delete Success - Role", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

       
    }
}
