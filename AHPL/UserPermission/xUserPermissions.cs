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
    public partial class xRolePermissions : DevExpress.XtraEditors.XtraForm
    {
        //AHPL_DBEntities context = new AHPL_DBEntities();
        List<Permission_UserForms> userPermissionList = new List<Permission_UserForms>();
        public xRolePermissions()
        {
            InitializeComponent();
        }

        private void xRolePermissions_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    //primary entity
                    var qryUP = from up in context.Permission_UserForms
                                select up;
                    this.permission_UserFormsBindingSource.DataSource = qryUP;

                    // permission form
                    var qryPermissionForm = (from p in context.Permission_Forms
                                             select new { p.FormID, p.InternalFormName, p.FormDescriotion,p.ModuleName,p.SubModuleName }).ToList();
                    permissionFormsBindingSource.DataSource = qryPermissionForm;


                    // roles 
                    var qryR = (from r in context.Permission_Roles
                                select new { r.RoleID, r.RoleName }).ToList();
                    this.permissionRolesBindingSource.DataSource = qryR;

                    this.lookRoleID.DataSource = qryR;
                    this.lookRoleID.DisplayMember = "RoleName";
                    this.lookRoleID.ValueMember = "RoleID";


                    this.permission_UserFormsBindingSource.DataSource = userPermissionList;
                    this.permission_UserFormsGridControl.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
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
                int roleid = 0;
                bool res = false;
                res = int.TryParse(this.lookUpEditRoleName.EditValue.ToString(), out roleid);
                if (res == false) { roleid = 0; MessageBox.Show("Invalid Role", "Invalid Role - Role Permission", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }



                //AHPL.CustomClasses.cPermission.IsUpdate(AHPL.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                if (splashScreenManager1.IsSplashFormVisible == false)
                { splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormDescription("Saveing Data...");
                }
                

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    foreach (var qry in userPermissionList)
                    {
                        // finding object 
                        bool found = findOjbect(qry.UserFormID,roleid);
                        if (found == true)
                        {
                            // Editing object 
                            
                            Permission_UserForms permissionUserForm = (from up in context.Permission_UserForms
                                                                       where up.UserFormID == qry.UserFormID
                                                                       select up).FirstOrDefault();
                            permissionUserForm.C = qry.C;
                            permissionUserForm.D = qry.D;
                            permissionUserForm.FormID = qry.FormID;                          
                            permissionUserForm.R = qry.R;
                            permissionUserForm.RoleID = qry.RoleID;
                            permissionUserForm.U = qry.U;
                            permissionUserForm.ModuleName = qry.ModuleName;
                            permissionUserForm.SubModuleName = qry.SubModuleName;
                            splashScreenManager1.SetWaitFormDescription(qry.SubModuleName);
                            context.Permission_UserForms.ApplyCurrentValues(permissionUserForm);
                            //--
                        }
                        else
                        {
                            Permission_UserForms permissionUserForm = (Permission_UserForms)qry;
                            Permission_UserForms permissioUserFormObject = new Permission_UserForms();

                            permissioUserFormObject.C = qry.C;
                            permissioUserFormObject.D = qry.D;
                            permissioUserFormObject.FormID = qry.FormID;
                            permissioUserFormObject.ModuleName = qry.ModuleName;
                            permissioUserFormObject.ModuleOrderID = qry.ModuleOrderID;
                            permissioUserFormObject.R = qry.R;
                            permissioUserFormObject.RoleID = roleid;
                            permissioUserFormObject.SubModuleName = qry.SubModuleName;
                            permissioUserFormObject.SubModuleOrderID = qry.SubModuleOrderID;
                            permissioUserFormObject.U = qry.U;

                            splashScreenManager1.SetWaitFormDescription(permissioUserFormObject.SubModuleName);
                            context.Permission_UserForms.AddObject(permissioUserFormObject);
                        }


                    }

                    int succ = context.SaveChanges();
                    if (succ > 0)                  
                    {
                        if (splashScreenManager1.IsSplashFormVisible == true)
                        {
                            splashScreenManager1.CloseWaitForm();
                        }

                        MessageBox.Show("Record saved successfully...", "Save Success - User Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                   

                }

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                {
                    splashScreenManager1.CloseWaitForm();
                }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private bool findOjbect(int puserFormID, int pRoleID )
        {
            bool found = false;
            try
            {
              
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryUserPermission = (from up in context.Permission_UserForms
                                             where up.UserFormID == puserFormID && up.RoleID == pRoleID
                                             select new { up.UserFormID }).ToList();
                    if (qryUserPermission.Count > 0)
                    {
                        found = true;
                    }

                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return found;
        }

        private void lookUpEditRoleName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Loading Data...");
                }

                if (string.IsNullOrEmpty(this.lookUpEditRoleName.Text.ToString()))
                { return; }
                userPermissionList.Clear();
                int roleid = 0;
                bool res = false;

                res = int.TryParse(this.lookUpEditRoleName.EditValue.ToString(), out roleid);
                if (res == false) { roleid = 0; }
                if (roleid == 0)
                { return; }
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    IQueryable<Permission_UserForms> qryFormList = (from up in context.Permission_UserForms
                                                                    join p in context.Permission_Forms on up.FormID equals p.FormID
                                                                    where up.RoleID == roleid
                                                                    orderby p.ModuleOrderID,p.SubModuleOrderID
                                                                    select up).AsQueryable();
                    foreach (var qry in qryFormList)
                    {
                        if (qry.FormID == 131) 
                        {
                        
                        }

                        Permission_UserForms userPermissionObject = new Permission_UserForms();
                        userPermissionObject.FormID = qry.FormID;
                        userPermissionObject.ModuleName = getModuleName(qry.FormID);
                        userPermissionObject.ModuleOrderID = getModuleNameOrderID(qry.FormID);
                        userPermissionObject.SubModuleName = getSubModuleName(qry.FormID);
                        userPermissionObject.SubModuleOrderID = getSubModuleNameOrderID(qry.FormID);
                        //userPermissionObject.IsVisibile = qry.IsVisibile;
                        userPermissionObject.RoleID = qry.RoleID;
                        userPermissionObject.UserFormID = qry.UserFormID;
                        userPermissionObject.C = qry.C;
                        userPermissionObject.R = qry.R;
                        userPermissionObject.U = qry.U;
                        userPermissionObject.D = qry.D;

                        splashScreenManager1.SetWaitFormDescription(userPermissionObject.ModuleName.ToString());
                        //oUserPermission.
                        userPermissionList.Add(userPermissionObject);
                    }

                    var qryList = (from p in qryFormList
                                   select new { p.FormID }).ToList();
                    List<int> intList = new List<int>();
                    foreach (var qry in qryList)
                    {
                        intList.Add(qry.FormID);
                    }

                 
                    // find not in the list (qryList) 
                    var qryFormBaseList = (from p in context.Permission_Forms
                                           where !intList.Contains(p.FormID) 
                                           select p).ToList();
                    foreach (var qry in qryFormBaseList)
                    {
                        Permission_UserForms userPermissionObject = new Permission_UserForms();
                        userPermissionObject.FormID = qry.FormID;
                        //userPermissionObject.IsVisibile = false;
                        userPermissionObject.RoleID = roleid;
                        userPermissionObject.ModuleName = getModuleName(qry.FormID);
                        userPermissionObject.ModuleOrderID = getModuleNameOrderID(qry.FormID);
                        userPermissionObject.SubModuleName = getSubModuleName(qry.FormID);
                        userPermissionObject.SubModuleOrderID = getSubModuleNameOrderID(qry.FormID);
                        userPermissionObject.C = false;
                        userPermissionObject.R = false;
                        userPermissionObject.U = false;
                        userPermissionObject.D = false;

                        splashScreenManager1.SetWaitFormDescription(userPermissionObject.ModuleName.ToString());


                        userPermissionList.Add(userPermissionObject);
                    }

                    // Ordering 
                    userPermissionList = (from u in userPermissionList
                                          orderby u.ModuleOrderID,u.SubModuleOrderID
                                          select u).ToList();

                    this.permission_UserFormsBindingSource.DataSource = userPermissionList;                                                         
                    this.permission_UserFormsGridControl.RefreshDataSource();
                    if (splashScreenManager1.IsSplashFormVisible == true)
                    { splashScreenManager1.CloseWaitForm(); }

                }

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                { splashScreenManager1.CloseWaitForm(); }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private int getSubModuleNameOrderID(int pUserFormID)
        {
            int submoduleNameOrderID = 0;
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryUserForms = (from u in context.Permission_Forms
                                        where u.FormID == pUserFormID
                                        select new { u.ModuleOrderID }).FirstOrDefault();
                    if (qryUserForms != null)
                    {
                        submoduleNameOrderID = qryUserForms.ModuleOrderID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return submoduleNameOrderID;
        }

        private int getModuleNameOrderID(int pFormID)
        {
            int moduleNameOrderID = 0;
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryUserForms = (from u in context.Permission_Forms
                                        where u.FormID == pFormID
                                        select new { u.ModuleOrderID }).FirstOrDefault();
                    if (qryUserForms != null)
                    {
                        moduleNameOrderID = qryUserForms.ModuleOrderID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return moduleNameOrderID;
        }

        private string getSubModuleName(int pFormID)
        {
            string submoduleName = "";
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryUserForms = (from u in context.Permission_Forms
                                        where u.FormID == pFormID
                                        select new { u.SubModuleName }).FirstOrDefault();
                    if (qryUserForms != null)
                    {
                        submoduleName = qryUserForms.SubModuleName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return submoduleName;
        }

        private string getModuleName(int pFormID)
        {
            string moduleName = "";
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryUserForms = (from u in context.Permission_Forms
                                        where u.FormID == pFormID
                                        select new { u.ModuleName }).FirstOrDefault();
                    if (qryUserForms != null)
                    {
                        moduleName = qryUserForms.ModuleName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return moduleName;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colR)
                {
                    bool res = false;
                    bool read = false;
                    res = bool.TryParse(e.Value.ToString(), out read);
                    if (res == false) { read = false; }

                    if (read == false)
                    {
                        this.gridView1.SetRowCellValue(e.RowHandle, colC, false);
                        this.gridView1.SetRowCellValue(e.RowHandle, colD, false);
                        this.gridView1.SetRowCellValue(e.RowHandle, colU, false);
                    }
                }

                if (e.Column == colC)
                {
                    bool res = false;
                    bool write = false;
                    res = bool.TryParse(e.Value.ToString(), out write);
                    if (res == false) { write = false; }
                    if (write == true)
                    {

                        this.gridView1.SetRowCellValue(e.RowHandle, colR, true);
                    }

                }

                if (e.Column == colD)
                {
                    bool res = false;
                    bool delete = false;
                    res = bool.TryParse(e.Value.ToString(), out delete);
                    if (res == false) { delete = false; }
                    if (delete == true)
                    {
                        this.gridView1.SetRowCellValue(e.RowHandle, colR, true);

                    }

                }

                if (e.Column == colU)
                {
                    bool res = false;
                    bool update = false;
                    res = bool.TryParse(e.Value.ToString(), out update);
                    if (res == false) { update = false; }
                    if (update == true)
                    {
                        this.gridView1.SetRowCellValue(e.RowHandle, colR, true);

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
           
        }

        private void btbSelectAll_CheckedChanged(object sender, EventArgs e)
        {

            if (this.btbSelectAll.Checked == true)
            {
                this.btbSelectAll.Text = "Unselect All";

                foreach (var qry in userPermissionList)
                {
                    qry.C = true;
                    qry.D = true;
                    qry.U = true;
                    qry.R = true;
                }

            }
            else 
            {
                this.btbSelectAll.Text = "Select All";
                foreach (var qry in userPermissionList)
                {
                    qry.C = false;
                    qry.D = false;
                    qry.U = false;
                    qry.R = false;
                }

                permission_UserFormsGridControl.RefreshDataSource();
            }

       
        }

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

       
    }
}