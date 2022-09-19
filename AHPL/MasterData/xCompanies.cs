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
using DevExpress.XtraEditors;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using DataTier;

namespace MMS
{
    public partial class xCompanies : DevExpress.XtraEditors.XtraForm        //: ParentForm.xParentDefault 
    {
        AHPL_DBEntities context = new AHPL_DBEntities();

        public xCompanies()
        {
            InitializeComponent();
        }






        private void save_data()
        {

        }

        private bool validate_data()
        {
            this.Validate();
            this.companyBindingSource.EndEdit();

            bool validated = false;
            string compcode = this.companyCodeTextEdit.Text.ToString();





            if (string.IsNullOrEmpty(compcode))
            {
                dxErrorProvider1.SetError(this.companyCodeTextEdit, "Invalid Company Code", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                validated = false;
                return validated;
            }
            else
            {
                dxErrorProvider1.SetError(this.companyCodeTextEdit, "");
                validated = true;

            }

            //using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                this.companyBindingSource.EndEdit();
                Company companyObject = (Company)this.companyBindingSource.Current;

                if (companyObject.CompanyID == 0)
                {
                    var qry = (from c in context.Companies
                               where c.CompanyCode == compcode
                               select new { c.CompanyCode }).ToList();

                    if (qry.Count > 0)
                    {
                        dxErrorProvider1.SetError(this.companyCodeTextEdit, "Company Code already exist", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                        validated = false;
                        return validated;
                        //return false;

                    }
                }
            }




            return validated;
        }

        private void xCompanies_Load(object sender, EventArgs e)
        {
            load_Data();

        }

        private void load_Data()
        {

            try
            {
                //this.enable_control(false, eRecStatus.eInit);
                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    // primary entity
                    var qryComp = (from c in context.Companies
                                   select c).ToList();


                    this.companyBindingSource.DataSource = qryComp;

                    // location
                    //var qryLoc = (from l in context.Locations
                    //              select new { l.LocationID, l.LocationCode, l.LocationName, l.Address }).ToList();
                    //this.locationBindingSource.DataSource = qryLoc;


                    // taxes
                    this.taxBindingSource.DataSource = (from t in context.Taxes
                                                        select new { t.TaxID, t.TaxCode, t.TaxName }).ToList();


                    // this.enable_control(false, eRecStatus.eInit);

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



        private void cmdPrev_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.companyBindingSource.MovePrevious();
        }





        private void cmdFirst_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.companyBindingSource.MoveFirst();
        }

        private void cmdNext_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.companyBindingSource.MoveNext();
        }

        private void cmdLast_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.companyBindingSource.MoveLast();
        }

        private void cmdUndo_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            companyBindingSource.CancelEdit();
            //this.enable_control(false, eRecStatus.eInit);
            this.dxErrorProvider1.ClearErrors();
            load_Data();


        }

        private void cmdRefresh_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.context.Refresh(RefreshMode.StoreWins, context.Companies);
            //Company comp = (Company) this.companyBindingSource.Current;
            //context.Refresh(RefreshMode.StoreWins, comp);
            //load_Data();


        }

        private void refres_data()
        {
            try
            {
                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var companies = from c in context.Companies
                                    select c;

                    context.Refresh(RefreshMode.StoreWins, companies);
                    this.companyBindingSource.DataSource = companies;
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
                //this.enable_control(true, eRecStatus.eAddNew);
                this.companyBindingSource.AddNew();
                this.companyCodeTextEdit.Focus();

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
                bool havePErmission = MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                if (havePErmission)
                {
                    DialogResult dlg = MessageBox.Show("Do you want to delete current record?", "Delete -Company", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == System.Windows.Forms.DialogResult.Yes)
                    {


                        Company oComp = (Company)companyBindingSource.Current;

                        if (oComp == null) { return; }

                        // check in the transcation weather company has raised transaction
                        var qryInv = (from c in context.Invoices
                                      where c.CompanyID == oComp.CompanyID
                                      select c).ToList();
                        if (qryInv.Count > 0)
                        {
                            throw new Exception("Company '" + oComp.CompanyCode + "' already exist in the transaction, therefore you cannot delete this company");
                        }

                        ////Check whethere shops are exist for this company
                        var qryShops = context.Shops.Where(s => s.CompanyID == oComp.CompanyID).ToList();
                        if (qryShops.Count > 0) 
                        {
                            throw new Exception("Company '" + oComp.CompanyCode + "' already exist in the shops, therefore you cannot delete this company");
                        }

                        //using (AHPL_DBEntities context = new AHPL_DBEntities())
                        {
                            var qryCompTax = (from ct in context.Company_Taxes
                                              where ct.CompanyID == oComp.CompanyID
                                              select ct).ToList();
                            foreach (var qry in qryCompTax)
                            {
                                var qryDelete = (from ct in context.Company_Taxes
                                                 where ct.CompanyID == qry.CompanyID
                                                 select ct).FirstOrDefault();
                                if (qryDelete != null)
                                {
                                    context.Company_Taxes.DeleteObject(qryDelete);
                                }
                            }


                            var qryComp = (from c in context.Companies
                                           where c.CompanyID == oComp.CompanyID
                                           select c).FirstOrDefault();


                            if (oComp != null)
                            {
                                context.DeleteObject(qryComp);
                                int succ = context.SaveChanges();

                                if (succ > 0)
                                {
                                    MessageBox.Show("Record Deleted Successfully...", "Delete Success - Company", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                load_Data();
                            }
                        }
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
            refres_data();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.enable_control(true, eRecStatus.eEdit);               
                this.companyCodeTextEdit.Properties.ReadOnly = true;

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
                bool validated = validate_data();

                if (validated == false)
                {
                    return;
                }

                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    this.companyBindingSource.EndEdit();
                    this.company_TaxesBindingSource.EndEdit();
                    int succ = 0;
                    Company companyObject = (Company)companyBindingSource.Current;

                    if (companyObject == null) { return; }


                    if (companyObject.CompanyID == 0)
                    {
                        companyObject.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                        companyObject.CreatedDate = DateTime.Now.Date;
                        context.Companies.AddObject(companyObject);
                    }
                    else
                    {
                        companyObject.LastUpdated = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                        companyObject.LastUpdateDate = DateTime.Now;
                        context.Companies.ApplyOriginalValues(companyObject);
                    }

                    succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Saved Successfully", "Company - MMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }

                //this.enable_control(false, eRecStatus.eSave);


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


    }
}
