using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using DataTier;

namespace MMS.UserPermission
{
    public partial class xUserGroups : DevExpress.XtraEditors.XtraForm
    {
        public xUserGroups()
        {
            InitializeComponent();
        }

        

        private void xUserGroups_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryUserGroup = (from u in context.Permission_UserGroups
                                        select u).ToList();
                    this.permission_UserGroupsBindingSource.DataSource = qryUserGroup;

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

        

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_UserGroupsBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_UserGroupsBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_UserGroupsBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_UserGroupsBindingSource.MoveLast();
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

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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

                //this.enable_control(false, eRecStatus.eEdit);
                this.userGroupNameTextEdit.Focus();

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
            this.permission_UserGroupsBindingSource.CancelEdit();
            load_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.permission_UserGroupsBindingSource.EndEdit();

                Permission_UserGroups userGroupObject = (Permission_UserGroups)this.permission_UserGroupsBindingSource.Current;
                if (userGroupObject == null)
                {
                    MessageBox.Show("There is no value to save", "Invalid Save - User Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(this.userGroupNameTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.userGroupNameTextEdit, "Invalid User Group Name");
                    return;
                }
                else { dxErrorProvider1.SetError(this.userGroupNameTextEdit, ""); }
                //---
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    if (userGroupObject.UserGroupID == 0)  // add new status
                    {
                        // check dupplication 
                        var qryDupplicate = (from u in context.Permission_UserGroups
                                             where u.UserGroupName == userGroupObject.UserGroupName
                                             select u).ToList();
                        if (qryDupplicate.Count > 0)
                        {
                            dxErrorProvider1.SetError(this.userGroupNameTextEdit, "User Group Name already Exist");
                            return;

                        }
                        else { dxErrorProvider1.SetError(this.userGroupNameTextEdit, ""); }
                        //

                        //record creation time
                        userGroupObject.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                        userGroupObject.CreatedDate = DateTime.Now;
                        //--

                        context.Permission_UserGroups.AddObject(userGroupObject);


                    }
                    else /// editing 
                    {
                        // record modification time
                        userGroupObject.UpdatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                        userGroupObject.UpdatedDate = DateTime.Now;
                        //--
                        context.Permission_UserGroups.ApplyCurrentValues(userGroupObject);
                    }


                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Saved Successfully...", "Save Success - User Groups", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }

                    //this.enable_control(false, eRecStatus.eSave);
                }


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

                permission_UserGroupsBindingSource.AddNew();
                //this.enable_control(true, eRecStatus.eAddNew);
                this.userGroupNameTextEdit.Focus();

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

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    this.permission_UserGroupsBindingSource.EndEdit();
                    Permission_UserGroups userGroupObject = (Permission_UserGroups)this.permission_UserGroupsBindingSource.Current;
                    if (userGroupObject == null)
                    { return; }

                    // check user group has already in the user table
                    var qryGroupFound = (from u in context.Permission_Users
                                         where u.UserGroupID == userGroupObject.UserGroupID
                                         select u).FirstOrDefault();
                    if (qryGroupFound != null)
                    {
                        MessageBox.Show("User Group '" + userGroupObject.UserGroupName + "' already integrated in the '" + qryGroupFound.UserName + "'", "Cannot Delete - User Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //

                    // deleting user group 
                    context.Permission_UserGroups.DeleteObject(userGroupObject);

                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Deleted Succcessfully..", "Delete Success - User Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    load_data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
