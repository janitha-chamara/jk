using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Linq.Expressions;
using DataTier;

namespace MMS.UserPermission
{
    public partial class xEmailAlertProfiles : ParentForm.xParentDefault
    {
        List<EmailAlertRole> emailAlertList = new List<EmailAlertRole>();
        public xEmailAlertProfiles()
        {
            InitializeComponent();
        }

        private void xEmailAlertProfiles_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    // role 
                    var qryRole = (from r in context.Permission_Roles                                   
                                   select new { r.RoleID, r.RoleName }).ToList();
                    this.lookRoleID.Properties.DataSource = qryRole;
                    this.lookRoleID.Properties.DisplayMember = "RoleName";
                    this.lookRoleID.Properties.ValueMember = "RoleID";
                    // - 

                    // Email Alert Items
                    var qryAlerts = (from a in context.EmailAlertItems
                                     select new { a.EmailAlertItemID, a.EmailArertItemName }).ToList();
                    lookAlertItemID.DataSource = qryAlerts;
                    lookAlertItemID.DisplayMember = "EmailArertItemName";
                    lookAlertItemID.ValueMember = "EmailAlertItemID";
                    // - 

                    this.emailAlertRoleBindingSource.DataSource = emailAlertList;
                    // - 

                    //this.enable_control(false, eRecStatus.eInit);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdClose_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void cmdNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            try
            {
                //MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.emailAlertUserBindingSource.AddNew();
                this.enable_control(true, eRecStatus.eAddNew);
                //this.userIDLookUpEdit.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdEdit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            try
            {
                //MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                this.enable_control(true, eRecStatus.eEdit);
                //this.userIDLookUpEdit.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            //this.emailAlertUserBindingSource.MoveFirst();
        }

        private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            //this.emailAlertUserBindingSource.MovePrevious();
        }

        private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            //this.emailAlertUserBindingSource.MoveNext();
        }

        private void userIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(this.userIDLookUpEdit.Text.ToString()))
            { return; }

            //this.emailAlertUserBindingSource.EndEdit();
            //using (AHPL_DBEntities context = new AHPL_DBEntities())
            //{
                ////EmailAlertUser emailalertuserObject = (EmailAlertUser)this.emailAlertUserBindingSource.Current;
                ////if (emailalertuserObject == null) { return; }
                ////var qryAlertDet = emailalertuserObject.EmailAlertUser_Details.ToList();
                ////var qryAlertItems = (from a in context.EmailAlertItems
                ////                     select a).ToList();

                ////// list of alert item in detail
                ////List<int> alertdetList = new List<int>();
                ////foreach (var qry in qryAlertDet) 
                ////{
                ////    alertdetList.Add(qry.EmailAlertItemID);
                ////}
                ////// -- 

                ////var qryListToAdd = (from a in qryAlertItems
                ////                    where !alertdetList.Contains(a.EmailAlertItemID)
                ////                    select a).ToList();


                ////foreach (var qry in qryListToAdd)
                ////{
                ////    EmailAlertUser_Details alertDetails = new EmailAlertUser_Details();
                ////    alertDetails.EmailAlertItemID = qry.EmailAlertItemID;
                ////    alertDetails.IsEnabled = false;
                ////    alertDetails.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                ////    alertDetails.CreatedDate = DateTime.Now;
                ////    emailalertuserObject.EmailAlertUser_Details.Add(alertDetails);
                ////}

            //}
            


            
        }

        private void cmdSave_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.emailAlertRoleBindingSource.EndEdit();

                if (string.IsNullOrEmpty(this.lookRoleID.Text.ToString()))
                { return; }

                int roleid = int.Parse(this.lookRoleID.EditValue.ToString());

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    foreach (var qry in emailAlertList)
                    {
                        //search in exiting email alert role 
                        var qryFound = (from a in context.EmailAlertRoles
                                        where a.EmailAlertItemID == qry.EmailAlertItemID && a.RoleID==roleid
                                        select a).FirstOrDefault();

                        if (qryFound != null) // editing
                        {
                            qryFound.IsEnabled = qry.IsEnabled;
                        }
                        else // add new
                        {
                            EmailAlertRole emalalertRoleObj = new EmailAlertRole();
                            emalalertRoleObj.EmailAlertItemID = qry.EmailAlertItemID;
                            emalalertRoleObj.IsEnabled = qry.IsEnabled;
                            emalalertRoleObj.RoleID = qry.RoleID;
                            context.EmailAlertRoles.AddObject(emalalertRoleObj);
                        }
                    }

                    int succ = context.SaveChanges();

                    if (succ > 0)
                    {
                        MessageBox.Show("Record Saved Successfully...", "Email Alert Profiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }


                //this.emailAlertUserBindingSource.EndEdit();
                //this.emailAlertUser_DetailsBindingSource.EndEdit();

                //validating user id
                //if (string.IsNullOrEmpty(this.userIDLookUpEdit.Text.ToString()))
                //{
                //    dxErrorProvider1.SetError(this.userIDLookUpEdit, "Invalid User Name");
                //    return;
                //}
                //else { dxErrorProvider1.SetError(this.userIDLookUpEdit, ""); }
                //--

                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    //EmailAlertUser emailalertuserObject = (EmailAlertUser)this.emailAlertUserBindingSource.Current;
                    //if (emailalertuserObject != null)
                    //{

                    //    if (emailalertuserObject.EmailAlertUserID == 0)
                    //    {
                    //        context.EmailAlertUsers.AddObject(emailalertuserObject);                            
                    //    }

                    //    else
                    //    {
                            
                    //        var qryFound = (from a in context.EmailAlertUsers
                    //                        where a.EmailAlertUserID == emailalertuserObject.EmailAlertUserID
                    //                        select a).FirstOrDefault();
                    //        qryFound.UserID = emailalertuserObject.UserID;
                    //        //record modification 
                    //        qryFound.LastUpdatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    //        qryFound.LastUpdatedDate = DateTime.Now;
                    //        //-
                    //        foreach (var qry in emailalertuserObject.EmailAlertUser_Details)
                    //        {
                    //            var qryFoundDetail = (from a in context.EmailAlertUser_Details
                    //                                  where a.EmailAlertUserDetalID == qry.EmailAlertUserDetalID
                    //                                  select a).FirstOrDefault();
                    //            qryFoundDetail.IsEnabled = qry.IsEnabled;
                    //            // record modification time 
                    //            qryFoundDetail.LastUpdatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    //            qryFoundDetail.LastUpdatedDate = DateTime.Now;
                    //            // - 
                    //        }


                    //    }

                    //}

                    //int succ = context.SaveChanges();
                    //if (succ > 0)
                    //{
                    //    MessageBox.Show("Record Saved Successfully...", "Save Success - Email Alert Profiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //enable_control(false, eRecStatus.eSave);
                    //load_data();


                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdDelete_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {

        }

        private void lookRoleID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.lookRoleID.Text.ToString()))
                { return; }

                int roleid = int.Parse(this.lookRoleID.EditValue.ToString());

              
                List<int> alertRole = new List<int>();
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryAvailList = (from a in context.EmailAlertRoles
                                        where a.RoleID == roleid
                                        select a).ToList();
                    emailAlertList.Clear(); //clearing the list 

                    foreach (var qry in qryAvailList)
                    {
                        EmailAlertRole emailAlertRoleObj = new EmailAlertRole();
                        emailAlertRoleObj.EmailAlertRoleID = qry.EmailAlertRoleID;
                        emailAlertRoleObj.EmailAlertItemID = qry.EmailAlertItemID;
                        emailAlertRoleObj.RoleID = roleid;
                        emailAlertRoleObj.IsEnabled = qry.IsEnabled;
                        emailAlertList.Add(emailAlertRoleObj);
                    }



                    var qryRoleAlert = (from r in context.EmailAlertRoles
                                        where r.RoleID == roleid
                                        select new { r.EmailAlertItemID }).ToList();

                    foreach (var qry in qryRoleAlert)
                    {
                        alertRole.Add(qry.EmailAlertItemID);
                    }

                    var qryAlertToBeAdded = (from a in context.EmailAlertItems
                                             where !alertRole.Contains(a.EmailAlertItemID)
                                             orderby a.StdOrder
                                             select new { a.EmailAlertItemID }).ToList();

                   
                    foreach (var qry in qryAlertToBeAdded)
                    {
                        EmailAlertRole emailAlertRoleObj = new EmailAlertRole();
                        emailAlertRoleObj.EmailAlertItemID = qry.EmailAlertItemID;
                        emailAlertRoleObj.RoleID = roleid;
                        emailAlertRoleObj.IsEnabled = false;
                        emailAlertList.Add(emailAlertRoleObj);
                    }

                    emailAlertList = (from a in emailAlertList
                                      orderby a.EmailAlertItemID ascending
                                      select a).ToList();



                }


                this.emailAlertRoleBindingSource.DataSource = emailAlertList;
                this.emailAlertRoleGridControl.RefreshDataSource();
                //var qryAlerts = 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             




        }

        private void cmdUndo_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {

        }
    }
}