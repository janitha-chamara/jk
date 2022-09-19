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
    public partial class xUtilities : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xUtilities()
        {
            InitializeComponent();
        }

        private void xUtilities_Load(object sender, EventArgs e)
        {
            load_data();
        }

        

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.utilityBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.utilityBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.utilityBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.utilityBindingSource.MoveLast();
        //}

        

        private void load_data()
        {
           //primary entity
            this.utilityBindingSource.DataSource = (from u in context.Utilities
                                                    select u).ToList();

            //this.enable_control(false, eRecStatus.eInit);

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

       
        
        
        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.enable_control(true, eRecStatus.eAddNew);
                this.utilityBindingSource.AddNew();
                this.utilityNameTextEdit.Focus();
                this.invoicePrefixTextEdit.Properties.ReadOnly = false;

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
                this.invoicePrefixTextEdit.Properties.ReadOnly = true;

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
            this.utilityBindingSource.CancelEdit();
            load_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                this.Validate();
                this.utilityBindingSource.EndEdit();


                //validating Utility Name
                if (string.IsNullOrEmpty(this.utilityNameTextEdit.Text.ToString()))
                {

                    dxErrorProvider1.SetError(this.utilityNameTextEdit, "Invalid Utility Name");
                    return;
                }
                else { dxErrorProvider1.SetError(this.utilityNameTextEdit, ""); }

                //Validating Infoice Prefix
                if (string.IsNullOrEmpty(this.invoicePrefixTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.invoicePrefixTextEdit, "Invalid Invoice Prefix");
                    return;
                }
                else { dxErrorProvider1.SetError(this.invoicePrefixTextEdit, ""); }

                Utility _current = (Utility)this.utilityBindingSource.Current;

                if (_current.UtilityID == 0) // addnew status
                {
                    ///check for dupplication
                    string invprefix = this.invoicePrefixTextEdit.Text.ToString().Trim();
                    var qryDup = (from u in context.Utilities
                                  where u.InvoicePrefix == invprefix
                                  select new { u.UtilityID }).ToList();
                    if (qryDup.Count > 0)
                    {
                        MessageBox.Show("Duplicate Record Cannot Be Entered", "Duplicate- Utilities", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    context.Utilities.AddObject(_current);

                }
                else
                {
                    context.Utilities.ApplyCurrentValues(_current);

                }


                int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Save Success - Utilities", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                DialogResult dlg = MessageBox.Show("Do you want to delete the current record?", "Delete -Utility", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    // checking existing data in Invoice table
                    Utility oUtility = (Utility)this.utilityBindingSource.Current;
                    var qryU = (from u in context.Invoices
                                where u.UtilityID == oUtility.UtilityID
                                select new { u.UtilityID }).ToList();
                    if (qryU.Count > 0)
                    {
                        MessageBox.Show("The selected Utility already in the Invoice, there for you cannot delete this Utility", "Cannot Delete - Utility", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //--
                    utilityBindingSource.RemoveCurrent();

                    context.SaveChanges();

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
