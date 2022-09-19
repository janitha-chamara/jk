using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using MMS.DataTier;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using DataTier;

namespace MMS
{
    public partial class xTaxes : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xTaxes()
        {
            InitializeComponent();
        }

        private void parentTopPanel_Click(object sender, EventArgs e)
        {

        }

       

        private void xTaxes_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            //primary entity
            try
            {
                this.taxBindingSource.DataSource = (from t in context.Taxes
                                                    select t).ToList();

                

                //this.enable_control(false, eRecStatus.eInit);

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

       

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    taxBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    taxBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    taxBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    taxBindingSource.MoveLast();
        //}

        

        

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
             

        

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                taxBindingSource.AddNew();
                //this.enable_control(true, eRecStatus.eAddNew);
                this.taxCodeTextEdit.Focus();

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
                this.taxCodeTextEdit.Properties.ReadOnly = true;

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

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.taxBindingSource.EndEdit();

                //validating tax code
                if (string.IsNullOrEmpty(this.taxCodeTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.taxCodeTextEdit, "Invalid Tax Code");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.taxCodeTextEdit, "");
                }

                Tax taxObject = (Tax)this.taxBindingSource.Current;
                if (taxObject.TaxID == 0) // addnew status
                {
                    var qryDupp = (from t in context.Taxes
                                   where t.TaxCode == taxObject.TaxCode || t.TaxName == taxObject.TaxName
                                   select new { t.TaxName, t.TaxCode }).ToList();
                    if (qryDupp.Count > 0)
                    {
                        MessageBox.Show("Tax Code/Tax Name already Exist", "Dupplication - Tax", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    taxObject.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    taxObject.CreatedDate = DateTime.Now;

                    context.Taxes.AddObject(taxObject);
                }
                else // editing 
                {
                    taxObject.LastUpdated = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    taxObject.LastUpdateDate = DateTime.Now;
                    context.Taxes.ApplyCurrentValues(taxObject);

                }


                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Save Success - Taxes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.taxBindingSource.CancelEdit();
            load_data();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_data();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);


                Tax taxObject = (Tax)this.taxBindingSource.Current;

                DialogResult dlg = MessageBox.Show("Do you want to delete the current record?", "Delete - Taxes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    // check existing data in contract_tax

                    var qryTax = (from t in context.Invoice_Details
                                  where t.TaxID == taxObject.TaxID
                                  select new { t.TaxID }).ToList();
                    if (qryTax.Count > 0)
                    {
                        MessageBox.Show("The selected Tax already in the Contract, there for you cannot delete this Tax", "Cannot Delete - Tax", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // --

                    context.Taxes.DeleteObject(taxObject);
                    context.SaveChanges();

                    ////roshan..29Sep2014..to refresh grid
                    taxBindingSource.Remove(taxObject);
                    taxGridControl.RefreshDataSource();


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
        