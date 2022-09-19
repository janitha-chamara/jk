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
using System.Transactions;

namespace MMS
{
    public partial class xSCPerSq : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xSCPerSq()
        {
            InitializeComponent();
        }

        private void xSCPerSq_Load(object sender, EventArgs e)
        {
            //// To Do: Add grid view to display currently using values 
            //// Add addendum record for each and every record for future reference. -- check addendum adding process which is handling one by one below bulk implementation
            load_data();
        }

        private void load_data()
        {
            dateFromdateEdit.EditValue = DateTime.Now;
            dateTodateEdit.EditValue = DateTime.Now;
            scvaluetextEdit.EditValue = 0.0000;

            //primary entity
            this.company_BindingSource.DataSource = (from ur in context.Companies
                                                          select ur).ToList();

           

            btnNew.Enabled = true;
            btnEdit.Enabled = false;
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
            this.company_BindingSource.EndEdit();
            

            //var state = uRate.EntityState;
            //if (state == EntityState.Modified || state == EntityState.Added || state == EntityState.Deleted || state == EntityState.Detached)
            //{
            //    DialogResult dlg = MessageBox.Show("There are some changes have been done , do you want to save the changes?", "Save Changes ? - Utility Rate", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dlg == System.Windows.Forms.DialogResult.Yes)
            //    { e.Cancel = true; }
            //    else { e.Cancel = false; }

            //}
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.company_BindingSource.CancelEdit();
            load_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();

                Company company = (Company)company_BindingSource.Current;
                int companyId = 0;
                if (company != null)
                {
                    using (TransactionScope trs = new TransactionScope())
                    {
                        companyId = company.CompanyID;

                        SCAndRentValue scAndRentValue = new SCAndRentValue();
                        scAndRentValue.CompanyID = companyId;
                        scAndRentValue.FromDate = dateFromdateEdit.DateTime;
                        scAndRentValue.IsActive = true;
                        scAndRentValue.ToDate = dateTodateEdit.DateTime;
                        scAndRentValue.SCValue = Convert.ToDecimal(scvaluetextEdit.EditValue);
                        scAndRentValue.CreatedBy = CustomClasses.cCommon_Functions.LoggedUserID;
                        scAndRentValue.CreatedDate = DateTime.Now;

                        context.SCAndRentValues.AddObject(scAndRentValue);


                        List<ContractClosure> listContract = context.ContractClosures.Where(w => w.IsTerminated.Equals(false) && w.IsActive.Equals(true) && w.IsPromotion.Equals(false)
                            && w.CompanyID.Equals(companyId) && w.FloorArea > 1).ToList();
                        foreach (ContractClosure contract in listContract)
                        {
                            int contractClosureID = contract.ContractClosureID;

                            List<Contract_RentSchemes> listContractSchemes = context.Contract_RentSchemes.Where(w => w.ContractClosureID.Equals(contractClosureID) && w.ToDate > dateFromdateEdit.DateTime).ToList();

                            foreach (Contract_RentSchemes qryRentSch in listContractSchemes)
                            {
                                //// updating Contract Rent Scheme
                                qryRentSch.SCPerSqFeet = Convert.ToDecimal(scvaluetextEdit.EditValue);

                                context.Contract_RentSchemes.ApplyCurrentValues(qryRentSch);
                            }
                        }

                        this.ClearForm();

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;

                        context.SaveChanges();
                        trs.Complete();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            dateFromdateEdit.EditValue = DateTime.Now;
            dateTodateEdit.EditValue = DateTime.Now;
            scvaluetextEdit.EditValue = 0.0000;
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
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

        //private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    try
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


    }
}
