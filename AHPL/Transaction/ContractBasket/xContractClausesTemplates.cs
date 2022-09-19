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
    public partial class xContractClausesTemplates : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xContractClausesTemplates()
        {
            InitializeComponent();
        }

        private void xContractClosureTemplates_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {

            //primary entity
            this.conract_Closure_Sub_TemplatesBindingSource.DataSource = (from c in context.Conract_Closure_Sub_Templates
                                                                          orderby c.CompanyID ascending
                                                                          select c).ToList();

            //loading companies 
            this.companyBindingSource.DataSource = (from com in context.Companies
                                                    orderby com.CompanyID ascending
                                                    select new { com.CompanyCode, com.CompanyID, com.CompanyName }).ToList();

            //loading Closure Items 
            this.contractClosureItemsBindingSource.DataSource = (from ci in context.Contract_Closure_Items
                                                                 orderby ci.SortOrder ascending
                                                                 select new { ci.ContractClosureItemID, ci.ContractClosreItemName, ci.SortOrder }).ToList();
            //this.enable_control(false, eRecStatus.eInit);

            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
        }

        

        

       

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.conract_Closure_Sub_TemplatesBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.conract_Closure_Sub_TemplatesBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.conract_Closure_Sub_TemplatesBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.conract_Closure_Sub_TemplatesBindingSource.MoveLast();
        //}

        
        

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Validate();
            this.conract_Closure_Sub_TemplatesBindingSource.EndEdit();

            //validating fields
            if (string.IsNullOrEmpty(this.templateNameTextEdit.Text.ToString()))
            { dxErrorProvider1.SetError(this.templateNameTextEdit, "Invalid Template Name"); return; }
            else { dxErrorProvider1.SetError(this.templateNameTextEdit, ""); }

            if (string.IsNullOrEmpty(this.companyIDLookUpEdit.Text.ToString()))
            { dxErrorProvider1.SetError(this.companyIDLookUpEdit, "Invalid Company"); return; }
            else { dxErrorProvider1.SetError(this.companyIDLookUpEdit, ""); }

            if (string.IsNullOrEmpty(this.pageNoTextEdit.Text.ToString()))
            { dxErrorProvider1.SetError(this.pageNoTextEdit, "Invalid Page No"); return; }
            else { dxErrorProvider1.SetError(this.pageNoTextEdit, ""); }

            if (string.IsNullOrEmpty(this.pageTitleTextEdit.Text.ToString()))
            { dxErrorProvider1.SetError(this.pageTitleTextEdit, "Invalid Page Title"); return; }
            else { dxErrorProvider1.SetError(this.pageTitleTextEdit, ""); }


            Conract_Closure_Sub_Templates oContTemp = (Conract_Closure_Sub_Templates)this.conract_Closure_Sub_TemplatesBindingSource.Current;
            if (oContTemp.ContractClosureTempID == 0) //  add new status
            {
                // check duplicate

                var qryDup = (from c in context.Conract_Closure_Sub_Templates
                              where c.TemplateName == oContTemp.TemplateName
                              select new { c.TemplateName }).ToList();
                if (qryDup.Count > 0) // updating existing 
                {
                    dxErrorProvider1.SetError(this.templateNameTextEdit, "Template Name already exist");
                    return;
                }
                else { dxErrorProvider1.SetError(this.templateNameTextEdit, ""); }



                context.Conract_Closure_Sub_Templates.AddObject(oContTemp);
            }
            else
            {
                context.Conract_Closure_Sub_Templates.ApplyOriginalValues(oContTemp);

            }

            int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            if (succ > 0)
            {
                MessageBox.Show("Record Saved Successfully..", "Save Success - Contract Closure Template", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                //this.enable_control(false, eRecStatus.eSave);
            }
            //--

            load_data();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                conract_Closure_Sub_TemplatesBindingSource.AddNew();
                //this.enable_control(true, eRecStatus.eAddNew);
                this.templateNameTextEdit.Focus();

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

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.enable_control(true, eRecStatus.eEdit);

                btnSave.Enabled = true;
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.conract_Closure_Sub_TemplatesBindingSource.CancelEdit();
            load_data();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_data();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                this.conract_Closure_Sub_TemplatesBindingSource.EndEdit();

                Conract_Closure_Sub_Templates oContSubTemp = (Conract_Closure_Sub_Templates)this.conract_Closure_Sub_TemplatesBindingSource.Current;
                if (oContSubTemp != null)
                {
                    DialogResult dlg = MessageBox.Show("Do you want to delete current template '" + oContSubTemp.TemplateName + "' ?", "Delete Confirmation - Contract Template", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == System.Windows.Forms.DialogResult.Yes)
                    {
                        /// check existing record 
                        var qryExist = (from ct in context.ContractClosures
                                        where ct.ContractClosureTempID == oContSubTemp.ContractClosureTempID
                                        select new { ct.ContractClosureTempID }).ToList();
                        if (qryExist.Count > 0)
                        {
                            MessageBox.Show("Contract Template '" + oContSubTemp.TemplateName + "' already integrated with a contract clause", "Cannot Delete - Contract Template", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        context.Conract_Closure_Sub_Templates.DeleteObject(oContSubTemp);
                        int succ = context.SaveChanges();
                        if (succ > 0)
                        {
                            MessageBox.Show("Record Deleted", "Delete Success - Contract Template", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        load_data();
                        /// 

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
