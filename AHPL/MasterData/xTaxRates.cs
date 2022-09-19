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
    public partial class xTaxRates : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xTaxRates()
        {
            InitializeComponent();
        }



        private void xTaxRates_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    taxRatesBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    taxRatesBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.taxRatesBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.taxRatesBindingSource.MoveLast();
        //}



        private void Load_data()
        {

            this.taxRatesBindingSource.DataSource = context.TaxRates;
            this.taxBindingSource.DataSource = (from t in context.Taxes
                                                select t).ToList();

            //this.enable_control(false, eRecStatus.eInit);

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }




        private void taxIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }



        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.taxRatesBindingSource.CancelEdit();
            Load_data();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Load_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.taxRatesBindingSource.EndEdit();
                this.taxBindingSource.EndEdit();

                TaxRate _current = (TaxRate)this.taxRatesBindingSource.Current;

                int taxcode = 0;
                decimal taxrate = 0;


                bool ress = int.TryParse(this.taxIDLookUpEdit.EditValue.ToString(), out taxcode);
                if (ress == false) { taxcode = 0; }

                ress = decimal.TryParse(this.taxRate1TextEdit.Text.ToString(), out taxrate);
                if (ress == false) { taxrate = 0; }

                // validating tax code
                if (taxcode == 0)
                {
                    dxErrorProvider1.SetError(taxIDLookUpEdit, "Invalid Tax Code");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(taxIDLookUpEdit, "");
                }
                //-- 

                //Validating Tax Rate
                if (string.IsNullOrEmpty (taxrate.ToString())  )
                {
                    dxErrorProvider1.SetError(taxRate1TextEdit, "Invalid Tax Rate");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(taxRate1TextEdit, "");
                }

                //---


                if (_current.TaxRateID == 0)
                {
                    _current.IsActive = true;
                }


                //// Activating activeTo date
                if (_current.TaxRateID == 0)
                {
                    var qryRate1 = from v in context.TaxRates
                                   where v.IsActive == true && v.TaxID == taxcode
                                   select v;
                    foreach (var qry in qryRate1)
                    {
                        qry.ActiveTo = DateTime.Now.Date;
                    }

                   

                    ////unechecking IsActive =false
                    var qryRate2 = from v in context.TaxRates
                                   where v.TaxID == taxcode
                                   select v;
                    if (qryRate2.ToList().Count > 0)
                    {
                        foreach (var qry in qryRate2)
                        {
                            qry.IsActive = false;
                        }
                    }

                    
                }



                if (_current.TaxRateID == 0)
                {
                    // check duplicate entry 
                    var qryDupp = (from t in context.TaxRates
                                   where t.TaxRate1 == taxrate && t.TaxID == taxcode
                                   select t).ToList();
                    if (qryDupp.Count > 0)
                    {
                        dxErrorProvider1.SetError(this.taxRate1TextEdit, "Tax Rate already exist with the Tax Code");
                        return;
                    }
                    else
                    {
                        dxErrorProvider1.SetError(this.taxRate1TextEdit, "");
                    }

                    context.TaxRates.AddObject(_current);

                }
                else //// editing existing values 
                {
                    context.TaxRates.ApplyCurrentValues(_current);

                }



                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Save Success - Tax Rates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Load_data();
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
                this.activeToDateEdit.Properties.ReadOnly = true;

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
                taxRatesBindingSource.AddNew();
                this.taxIDLookUpEdit.Focus();
                //this.enable_control(true, eRecStatus.eAddNew);

                TaxRate _taxrate = (TaxRate)this.taxRatesBindingSource.Current;
                _taxrate.ActiveFrom = DateTime.Now.Date;
                this.activeToDateEdit.Properties.ReadOnly = true;

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

                DialogResult dlg = MessageBox.Show("Do you want to delete the current record?", "Delete - Tax Rates", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    // checking tax rates in the contract_taxrates
                    TaxRate oTaxRate = (TaxRate)this.taxRatesBindingSource.Current;
                    var qryTaxrate = (from tr in context.Invoice_Details
                                      where tr.TaxRateID == oTaxRate.TaxRateID
                                      select new { tr.TaxRateID }).ToList();
                    if (qryTaxrate.Count > 0)
                    {
                        MessageBox.Show("The selected Tax Rate already in the Contract, there for you cannot delete this Tax Rate", "Cannot Delete - Tax Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //--

                    var urdetails = context.UtlityRate_Details.Where(w => w.TaxRateID == oTaxRate.TaxRateID).ToList();
                    if (urdetails.Count > 0)
                    {
                        MessageBox.Show("The selected Tax Rate already in the Utility Details, there for you cannot delete this Tax Rate", "Cannot Delete - Tax Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    taxRatesBindingSource.RemoveCurrent();
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


    }
}
