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
using System.IO;
namespace MMS
{
    public partial class xUsers : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        byte[] signature_array = new byte[3];
        byte IsDefault = 0;
        public xUsers()
        {
            InitializeComponent();
        }

        private void xUsers_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    // Primary Entity - Users 
                    var qryUsers = (from u in context.Permission_Users
                                    select u).ToList();
                    this.permission_UsersBindingSource.DataSource = qryUsers;


                    // Roles 
                    var qryRoles = (from r in context.Permission_Roles
                                    select new { r.RoleID, r.RoleName }).ToList();
                    this.permissionRolesBindingSource.DataSource = qryRoles;

                    // user group 
                    var qryUserGroup = (from u in context.Permission_UserGroups
                                        select new { u.UserGroupID, u.UserGroupName }).ToList();
                    this.userGroupIDLookUpEdit.Properties.DataSource = qryUserGroup;
                    this.userGroupIDLookUpEdit.Properties.DisplayMember = "UserGroupName";
                    this.userGroupIDLookUpEdit.Properties.ValueMember = "UserGroupID";

                    this.repositoryItemLookUpEditUserGroupID.DataSource = qryUserGroup;
                    this.repositoryItemLookUpEditUserGroupID.DisplayMember = "UserGroupName";
                    this.repositoryItemLookUpEditUserGroupID.ValueMember = "UserGroupID";
                    //--

                    //location
                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode }).ToList();
                    this.lookLocationID.DataSource = qryLoc;
                    this.lookLocationID.DisplayMember = "LocationCode";
                    this.lookLocationID.ValueMember = "LocationID";

                    //this.enable_control(false, eRecStatus.eInit);

                    btnNew.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
           
        }

        
        

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_UsersBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_UsersBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_UsersBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.permission_UsersBindingSource.MoveLast();
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

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.enable_control(true, eRecStatus.eAddNew);
                this.permission_UsersBindingSource.AddNew();
                this.userNameTextEdit.Focus();

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

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.permission_UsersBindingSource.CancelEdit();
            load_data();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                Permission_Users userObject = (Permission_Users)this.permission_UsersBindingSource.Current;
                if (userObject == null) { return; }

                DialogResult dlg = MessageBox.Show("Do you want to discontinue the user '" + userObject.UserName + "' ?", "Discontiue User?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.No) { return; }

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryUserDiscontinue = (from u in context.Permission_Users
                                              where u.UserID == userObject.UserID
                                              select u).FirstOrDefault();

                    qryUserDiscontinue.Discontinued = true;
                    qryUserDiscontinue.DiscontinuedDate = DateTime.Now;

                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Discontinued Successfully...", "Discontinue Success - User", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            load_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.permission_UsersBindingSource.EndEdit();

                //validating fields 
                if (string.IsNullOrEmpty(this.userNameTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.userNameTextEdit, "Invalid User Name");
                    return;
                }
                else { dxErrorProvider1.SetError(this.userNameTextEdit, ""); }

                //validating password
                if (string.IsNullOrEmpty(this.passwordTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.passwordTextEdit, "Invalid Password");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.passwordTextEdit, "");
                }
                //

                // validating user group 

                if (string.IsNullOrEmpty(this.userGroupIDLookUpEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.userGroupIDLookUpEdit, "Invalid User Group");
                    return;
                }
                else { dxErrorProvider1.SetError(this.userGroupIDLookUpEdit, ""); }
                //--



                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    Permission_Users userObject = (Permission_Users)this.permission_UsersBindingSource.Current;
                    if (userObject == null) { return; }

                    if (userObject.UserID == 0) // add new status 
                    {
                        var qryDupp = (from u in context.Permission_Users
                                       where u.UserName == userObject.UserName
                                       select u).ToList();
                        if (qryDupp.Count > 0)
                        {
                            MessageBox.Show("User '" + userObject.UserName + "' already exist", "Dupplication - Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        context.Permission_Users.AddObject(userObject);
                        //context.UserLocations.AddObject(userObject)
                    }
                    else
                    {
                        var qryUser = (from u in context.Permission_Users
                                       where u.UserID == userObject.UserID
                                       select u).FirstOrDefault();
                        //userObject.EntityKey = qryUser.EntityKey;
                        userObject.UserName = this.userNameTextEdit.Text.ToString();
                        userObject.UserGroupID = int.Parse(this.userGroupIDLookUpEdit.EditValue.ToString());
                        userObject.RoleID = int.Parse(this.roleIDLookUpEdit.EditValue.ToString());
                        //userObject.IsUserHead = isUserHeadCheckEdit.Checked;
                        userObject.Password = this.passwordTextEdit.Text.ToString();
                        if (qryUser.signature != null)
                        {
                            userObject.signature = qryUser.signature;
                        }
                        else {
                            userObject.signature = signature_array;
                        }
                       
                        var qryUserLocList = (from u in userObject.UserLocations
                                              where u.IsDelete == true
                                              select u).ToList();
                        foreach (var qryUL in qryUserLocList)
                        {
                            UserLocation userLocObject = (from ul in context.UserLocations
                                                          where ul.UserLocationID == qryUL.UserLocationID
                                                          select ul).FirstOrDefault();
                            context.UserLocations.DeleteObject(userLocObject);

                        }
                        

                        context.Permission_Users.ApplyCurrentValues(userObject);
                    }

                    ////19May2015..
                    ////Add audit record..have to add this log code level, due to existing data on 'Users' table is not enoughf to check the user details( who is change the data).
                    Permission_Users_Audit userAuditObj = new Permission_Users_Audit();
                    userAuditObj.Discontinued = userObject.Discontinued;
                    userAuditObj.DiscontinuedDate = userObject.DiscontinuedDate;
                    userAuditObj.DNSUserName = userObject.DNSUserName;
                    userAuditObj.Email1 = userObject.Email1;
                    userAuditObj.Email2 = userObject.Email2;
                    userAuditObj.ISR_Password = userObject.ISR_Password;
                    userAuditObj.ISR_UserName = userObject.ISR_UserName;
                    userAuditObj.IsUserHead = userObject.IsUserHead;
                    userAuditObj.Password = userObject.Password;
                    userAuditObj.R3_Password = userObject.R3_Password;
                    userAuditObj.R3_UserName = userObject.R3_UserName;
                    userAuditObj.RoleID = userObject.RoleID;
                    userAuditObj.UserGroupID = userObject.UserGroupID;
                    userAuditObj.UserID = userObject.UserID;
                    userAuditObj.UserName = userObject.UserName;
                    userAuditObj.UpdatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    userAuditObj.UpdatedDate = DateTime.Now;
                    userAuditObj.signature = signature_array;
                    userAuditObj.default_asignee = userObject.default_asignee;
                    context.Permission_Users_Audit.AddObject(userAuditObj);
                    ////End..


                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Saved Sucessfully...", "Save Sucess - Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_data();
                    }
                    else
                    {
                        //enable_control(false, eRecStatus.eSave);
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
        
        private void btnaddsignature_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\Documents",
                Title = "Browse Signature Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".png",
                //Filter = "png files (*.pp)|*.txt",
                Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picturebox.Image = Image.FromFile(openFileDialog1.FileName);
                signature_array = imageToByteArray(Image.FromFile(openFileDialog1.FileName));
                
            }
        }
        // convert image to byte array
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        //Byte array to photo
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void btnremoveimage_Click(object sender, EventArgs e)
        {
            Permission_Users userObject = (Permission_Users)this.permission_UsersBindingSource.Current;
            userObject.signature = null;

        }

        private void chkdefault_CheckedChanged(object sender, EventArgs e)
        {
           
            

        }
    }
}
