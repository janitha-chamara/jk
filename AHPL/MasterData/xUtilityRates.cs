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
    public partial class xUtilityRates : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xUtilityRates()
        {
            InitializeComponent();
        }

        private void xUtilityRates_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {

            //primary entity
            this.utility_RatesBindingSource.DataSource = (from ur in context.Utility_Rates
                                                          select ur).ToList();

            //Taxes 
            var qryTax = (from t in context.Taxes
                          select new { t.TaxID, t.TaxCode, t.TaxName }).ToList();
            this.taxBindingSource.DataSource = qryTax;

            //Tax Rates
            var qrytaxrate = (from tr in context.TaxRates
                              select new { tr.TaxRateID, tr.TaxID, tr.TaxRate1 }).ToList();
            this.taxRateBindingSource.DataSource = qrytaxrate;

            this.utilityBindingSource.DataSource = (from u in context.Utilities
                                                    select new { u.UtilityID, u.UtilityName }).ToList();

            //company


            companyBindingSource.DataSource = (from c in context.Companies
                                               select new { c.CompanyID, c.CompanyCode }).ToList();

            //--

            // location
            locationBindingSource.DataSource = (from l in context.Locations
                                                select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
            ///---


            //this.enable_control(false, eRecStatus.eInit);

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }



        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.utility_RatesBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.utility_RatesBindingSource.MovePrevious();
        //}

        private void utlityRate_DetailsGridControl_Click(object sender, EventArgs e)
        {

        }



        private void parentTopPanel_Click(object sender, EventArgs e)
        {

        }




        private void xUtilityRates_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.utility_RatesBindingSource.EndEdit();
            Utility_Rates uRate = (Utility_Rates)this.utility_RatesBindingSource.Current;

            var state = uRate.EntityState;
            if (state == EntityState.Modified || state == EntityState.Added || state == EntityState.Deleted || state == EntityState.Detached)
            {
                DialogResult dlg = MessageBox.Show("There are some changes have been done , do you want to save the changes?", "Save Changes ? - Utility Rate", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                { e.Cancel = true; }
                else { e.Cancel = false; }

            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                Utility_Rates oUtilityRate = (Utility_Rates)this.utility_RatesBindingSource.Current;
                if (oUtilityRate != null)
                {
                    //this.enable_control(true, eRecStatus.eEdit);

                    if (oUtilityRate.LocatoinID == 0)
                    { locatoinIDLookUpEdit.Enabled = true; }
                    else { locatoinIDLookUpEdit.Enabled = false; }
                    if (oUtilityRate.CompanyID == 0)
                    { companyIDLookUpEdit.Enabled = true; }
                    else { companyIDLookUpEdit.Enabled = false; }
                    utilityRateNameTextEdit.Enabled = false;

                    btnNew.Enabled = false;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.utility_RatesBindingSource.CancelEdit();
            load_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.utility_RatesBindingSource.EndEdit();
                this.utlityRate_DetailsBindingSource.EndEdit();



                // validate fields

                // check utility name
                if (string.IsNullOrEmpty(this.utilityRateNameTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.utilityRateNameTextEdit, "Invalid Utility Name");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.utilityRateNameTextEdit, "");
                }

                ///-- 

                // check unit rate .
                if (string.IsNullOrEmpty(this.unitRateTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.unitRateTextEdit, "Invalid Rate");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.unitRateTextEdit, "");
                }

                bool res = false;
                decimal unitrate = 0;
                res = decimal.TryParse(this.unitRateTextEdit.EditValue.ToString(), out unitrate);
                if (res == false) { unitrate = 0; }

                if (unitrate == 0 || unitrate < 0)
                {
                    dxErrorProvider1.SetError(this.unitRateTextEdit, "Invalid Rate");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.unitRateTextEdit, "");
                }

                int utilityid = 0;
                res = int.TryParse(this.utilityRateNameTextEdit.EditValue.ToString(), out utilityid);
                if (res == false) { utilityid = 0; }
                if (utilityid <= 0)
                {
                    dxErrorProvider1.SetError(this.utilityRateNameTextEdit, "Invalid Utility Name");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.utilityRateNameTextEdit, "");
                }

                // validating company
                if (string.IsNullOrEmpty(this.companyIDLookUpEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.companyIDLookUpEdit, "Invalid Company");
                    return;
                }
                else { dxErrorProvider1.SetError(this.companyIDLookUpEdit, ""); }

                // validating locaiton
                if (string.IsNullOrEmpty(this.locatoinIDLookUpEdit.Text.ToString()))
                { dxErrorProvider1.SetError(this.locatoinIDLookUpEdit, "Invalid Location"); }
                else { dxErrorProvider1.SetError(this.locatoinIDLookUpEdit, ""); }



                ///--
                ///


                Utility_Rates utilityRateObject = (Utility_Rates)utility_RatesBindingSource.Current;

                if (utilityRateObject.UtilityRateID == 0) // addnew status
                {
                    //check duplication
                    var qryURate = (from ur in context.Utility_Rates
                                    where ur.UtilityID == utilityRateObject.UtilityID && ur.CompanyID == utilityRateObject.CompanyID && ur.LocatoinID == utilityRateObject.LocatoinID
                                    select new { ur.UtilityID }).ToList();
                    if (qryURate.Count > 0)
                    {
                        MessageBox.Show("Utility is already exist", "Cannot Duplicate - Utility Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    context.Utility_Rates.AddObject(utilityRateObject);
                }
                else // editing values 
                {
                    context.Utility_Rates.ApplyCurrentValues(utilityRateObject);
                }



                int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                if (succ > 0)
                {

                    MessageBox.Show("Record Saved Successfully", "Save Success - Utility Rates", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                this.utility_RatesBindingSource.AddNew();
                this.utilityRateNameTextEdit.Focus();

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

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                ////DialogResult dlg = MessageBox.Show("Do you want to delete the current record?", "Delete Utility Rate?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                UtlityRate_Details rateDetail = (UtlityRate_Details)utlityRate_DetailsBindingSource.Current;
                Utility_Rates current = (Utility_Rates)utility_RatesBindingSource.Current;

                if (rateDetail != null)
                {
                    int taxID = rateDetail.TaxID.Value;
                    Tax taxRec = context.Taxes.Where(w => w.TaxID.Equals(taxID)).FirstOrDefault();
                    string taxName = string.Empty;
                    if (taxRec != null)
                    {
                        taxName = taxRec.TaxName;
                    }

                    DialogResult dlg = MessageBox.Show("Do you want to delete the " + taxName + " record from " + current.UtilityRateProfileName + " profile?", "Delete Utility Rate?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {

                        ////Using below code utility rates profile will be deleted. but that will causes to other issues.
                        ////Utility detail record only will be deleting as temp solution.
                        ////Need to add proper delete button only for tax rate delete in UtlityRate_Details grid
                        ////Nimal request to do this later.
                        ////..roshan..24Sep2014

                        ////Utility_Rates current = (Utility_Rates)utility_RatesBindingSource.Current;
                        ////context.Utility_Rates.DeleteObject(current);
                        ////int succ = context.SaveChanges();

                        ////roshan..to delete existing taxes(only tax records will be deleted) for utility. 

                        context.UtlityRate_Details.DeleteObject(rateDetail);
                        context.SaveChanges();


                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Please select tax record from grid", "Please select tax record from grid", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
