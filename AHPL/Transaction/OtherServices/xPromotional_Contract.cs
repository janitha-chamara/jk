using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using System.Data.Linq.SqlClient;
using DataTier;
using DataTier.Reports;
namespace MMS
{
    public partial class xPromotional_Contract : DevExpress.XtraEditors.XtraForm
    {

        AHPL_DBEntities context = new AHPL_DBEntities();
        //private bool bEdit;
        //private bool bAddNew;


        public xPromotional_Contract()
        {
            InitializeComponent();
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

                contractClosureBindingSource.AddNew();
                cEnable_Controls.enable_control(this, true);
                cEnable_Controls.ClearText(this);

                //bAddNew = true;
                //bEdit = false;
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

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                this.Validate();
                this.contractClosureBindingSource.EndEdit();
                this.contract_RentSchemesBindingSource.EndEdit();

                //validating contract clause
                if (string.IsNullOrEmpty(this.contractClosureNameTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.contractClosureNameTextEdit, "Invalid Contract Name");
                    return;
                }
                else { dxErrorProvider1.SetError(this.contractClosureNameTextEdit, ""); }
                //--

                //validating customer name 
                if (string.IsNullOrEmpty(this.customerNameTextEdit.Text.ToString()))
                { dxErrorProvider1.SetError(this.customerNameTextEdit, "Invalid Customer Name"); return; }
                else { dxErrorProvider1.SetError(this.customerNameTextEdit, ""); }
                //--

                //validating company 
                if (string.IsNullOrEmpty(this.companyIDLookUpEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.companyIDLookUpEdit, "Invalid Company");
                    return;
                }
                else { dxErrorProvider1.SetError(this.companyIDLookUpEdit, ""); }
                //--

                //validating location 
                if (string.IsNullOrEmpty(this.locationIDLookUpEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(locationIDLookUpEdit, "Invalid Location");
                    return;
                }
                else { dxErrorProvider1.SetError(this.locationIDLookUpEdit, ""); }
                //--

                //validating floor level 
                if (string.IsNullOrEmpty(this.levelIDLookUpEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.levelIDLookUpEdit, "Invalid Floor Level");
                    return;
                }
                else { dxErrorProvider1.SetError(this.levelIDLookUpEdit, ""); }
                //

                //validating floor area 
                if (string.IsNullOrEmpty(this.floorAreaTextEdit.Text.ToString()))
                { dxErrorProvider1.SetError(this.floorAreaTextEdit, "Invalid Floor Area"); return; }
                else { dxErrorProvider1.SetError(this.floorAreaTextEdit, ""); }
                //-

                // validating Rent Type 
                if (string.IsNullOrEmpty(this.poRentTypeIDLookUpEdit.Text.ToString()))
                { dxErrorProvider1.SetError(this.poRentTypeIDLookUpEdit, "Invalid Rent Type"); return; }
                else { dxErrorProvider1.SetError(this.poRentTypeIDLookUpEdit, ""); }
                //-

                bool res = false;
                decimal floorarea = 0;
                res = decimal.TryParse(this.floorAreaTextEdit.EditValue.ToString(), out floorarea);
                if (res == false)
                { dxErrorProvider1.SetError(floorAreaTextEdit, "Invalid Floor Area"); return; }
                else { dxErrorProvider1.SetError(floorAreaTextEdit, ""); }

                ContractClosure oContClause = (ContractClosure)this.contractClosureBindingSource.Current;
                oContClause.IsPromotion = true;
                oContClause.IsActive = true;
                if (chkispromotion.Checked == true){
                    oContClause.PromotionCnt = true;
                }
                else{

                    oContClause.PromotionCnt = true;
                    }


                if (oContClause.ContractClosureID == 0)
                {
                    oContClause.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oContClause.CreatedDate = DateTime.Now.Date;

                    context.ContractClosures.AddObject(oContClause);
                }
                else
                {
                    oContClause.LastUpdated = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oContClause.LastUpdateDate = DateTime.Now.Date;

                    context.ContractClosures.ApplyCurrentValues(oContClause);

                }

              //  if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Connecting......"); }
              //  bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
               
                int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

                if (succ > 0)
                {
                    MessageBox.Show("Record saved successfully...", "Save Success - Promotional Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.OtherServiceContractProcessed;
                    MMS.CustomClasses.cCommon_Functions.AddToEmailList(int.Parse(this.companyIDLookUpEdit.EditValue.ToString()), int.Parse(this.locationIDLookUpEdit.EditValue.ToString()), alert, "Customer : " + this.customerNameTextEdit.Text.ToString() + System.Environment.NewLine + "Contract : " + this.contractClosureNameTextEdit.Text.ToString(), MMS.CustomClasses.cCommon_Functions.LoggedUserID);
                }

                cEnable_Controls.enable_control(this, false);

                //bAddNew = false; bEdit = false;
                this.btnSave.Enabled = false;
                this.btnNew.Enabled = true;
                this.btnEdit.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }

        private void poRentTypeIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            format_grid();
        }

        private void format_grid()
        {
            if (string.IsNullOrEmpty(this.poRentTypeIDLookUpEdit.Text.ToString()))
            { return; }

            bool res = false;
            int rentTypeID = 0;
            res = int.TryParse(this.poRentTypeIDLookUpEdit.EditValue.ToString(), out rentTypeID);
            if (res == false) { rentTypeID = 0; }

            if (rentTypeID > 0)
            {

                string rentType = this.poRentTypeIDLookUpEdit.Text.ToString().Trim();

                gridView3.Columns["RentPerSqFeet"].Caption = "Rent per " + rentType;
            }


        }

        private void xPromotional_Contract_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
          //  if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Connecting......"); }
           // bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
            if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
           
            contractClosureBindingSource.DataSource = (from c in context.ContractClosures
                                                       where c.IsPromotion == true && c.IsTerminated == false //&& c.IsActive == true
                                                       select c).ToList();

            //loading company 
            this.companyBindingSource.DataSource = (from c in context.Companies
                                                    orderby c.CompanyCode ascending
                                                    select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
            //--


            // loading location 
            this.locationBindingSource.DataSource = (from l in context.Locations
                                                     orderby l.LocationCode ascending
                                                     select new { l.LocationCode, l.LocationName, l.LocationID }).ToList();

            //--

            //advertisment spaces 
            var qryShop = (from s in context.Shops
                           join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                           where ra.IsAdvertisement == true
                           select new { s.ShopID, s.ShopNo }).ToList();
            this.shopIDLookUpEdit.Properties.DataSource = qryShop;
            this.shopIDLookUpEdit.Properties.DisplayMember = "ShopNo";
            this.shopIDLookUpEdit.Properties.ValueMember = "ShopID";


            //loading promotional contract types 
            var qryPR = (from p in context.Promotion_RentTypes
                         select new { p.PoRentTypeID, p.RentTypeName }).ToList();
            this.promotionRentTypesBindingSource.DataSource = qryPR;
            //-

            ////cEnable_Controls.enable_control(this, false);

            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = false;
        }

        private void levelIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(this.levelIDLookUpEdit.Text.ToString()))
                { return; }

                int levelid = int.Parse(this.levelIDLookUpEdit.EditValue.ToString());

                var qryAdv = (from s in context.Shops
                              join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                              where ra.IsAdvertisement == true && s.CustomerID == 0
                              select new { s.ShopID, s.ShopNo }).ToList();
                this.shopIDLookUpEdit.Properties.DataSource = qryAdv;
                this.shopIDLookUpEdit.Properties.DisplayMember = "ShopNo";
                this.shopIDLookUpEdit.Properties.ValueMember = "ShopID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void locationIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool res = false;

                //int compid = 0;
                int locid = 0;

                //res = int.TryParse(this.companyIDLookUpEdit.EditValue.ToString(), out compid);
                //if (res == false) { return; }

                res = int.TryParse(this.locationIDLookUpEdit.EditValue.ToString(), out locid);
                if (res == false) { return; }

                var qryflevel = (from f in context.Floor_Levels
                                 where f.LocationID == locid
                                 select new { f.LevelID, f.LevelCode, f.LevelName }).ToList();
                this.floorLevelsBindingSource.DataSource = qryflevel;

                // advertising spaces 
                var qryShop = (from s in context.Shops
                               join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                               where ra.IsAdvertisement == true && s.LocationID == locid
                               select new { s.ShopID, s.ShopNo }).ToList();
                this.shopIDLookUpEdit.Properties.DataSource = qryShop;
                this.shopIDLookUpEdit.Properties.DisplayMember = "ShopNo";
                this.shopIDLookUpEdit.Properties.ValueMember = "ShopID";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customerAddressMemoExEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void customerAddressLabel_Click(object sender, EventArgs e)
        {

        }

        private void customerNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                ContractClosure _contclosure = (ContractClosure)this.contractClosureBindingSource.Current;
                if (_contclosure != null)
                {
                    //if (_contclosure.IsProcessed == true)
                    //{
                    //    MessageBox.Show("Contract is already processed, therefore you cannot edit the contract", "Cannot Edit - Contract", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;

                    //}
                    //else
                    //{
                    this.btnSave.Enabled = true;
                    this.btnEdit.Enabled = false;
                    this.btnNew.Enabled = false;
                    ////cEnable_Controls.enable_control(this,true);
                    this.btnDelete.Enabled = true;
                    //}


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            cEnable_Controls.ClearText(this);
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = true;
            this.btnSave.Enabled = false;

            cEnable_Controls.enable_control(this, false);
            contractClosureBindingSource.CancelEdit();
        }

        private void contractClosureBindingSource_PositionChanged(object sender, EventArgs e)
        {
            ContractClosure oCClause = (ContractClosure)this.contractClosureBindingSource.Current;
            if (oCClause != null)
            {
                format_grid(oCClause.PoRentTypeID);
                if (oCClause.IsPoAdvertisement == true)
                {
                    this.shopIDLookUpEdit.Properties.ReadOnly = false;
                }
                else
                {
                    this.shopIDLookUpEdit.Properties.ReadOnly = true;
                }

            }
        }

        private void format_grid(int prentTypeID)
        {
            if (prentTypeID > 0)
            {
                if (prentTypeID == 1)
                {
                    gridView3.Columns["RentPerSqFeet"].Caption = "Rent per Day";
                }

                if (prentTypeID == 2)
                {
                    gridView3.Columns["RentPerSqFeet"].Caption = "Rent per Month";
                }

            }
            else
            {
                gridView3.Columns["RentPerSqFeet"].Caption = "Rent";
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult dlg = MessageBox.Show("Do you want to delete current contract", "Delete Confirmtion - Other Service Contract", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.No)
                { return; }


                this.contractClosureBindingSource.EndEdit();

                ContractClosure contClosureObj = (ContractClosure)this.contractClosureBindingSource.Current;

                if (contClosureObj.IsReleased == false)
                {
                    ContractClosure qryCont = (from c in context.ContractClosures
                                               where c.ContractClosureID == contClosureObj.ContractClosureID
                                               select c).FirstOrDefault();
                    var qryContR = qryCont.ContractClosure_Details.ToList();

                    var qryContRS = qryCont.Contract_RentSchemes.ToList();

                    foreach (var qry in qryContR)
                    {
                        ContractClosure_Details contDet = qry;
                        context.ContractClosure_Details.DeleteObject(contDet);

                    }

                    foreach (var qry in qryContRS)
                    {
                        Contract_RentSchemes contrentS = qry;
                        context.Contract_RentSchemes.DeleteObject(contrentS);
                    }

                    context.ContractClosures.DeleteObject(qryCont);

                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {

                        MessageBox.Show("Contract Deleted Successfully...", "Delete Success - Other Service Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please use Terminate Contract", "Terminating Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



                load_data();
                contractClosureGridControl.RefreshDataSource();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //this.contractClosureBindingSource.EndEdit();
            //ContractClosure oCClause = (ContractClosure)this.contractClosureBindingSource.Current;
            //if (oCClause != null)
            //{
            //    DialogResult dlg = MessageBox.Show("Do you want to delete current Promotional Contract '" + oCClause.CustomerName + "' ?", "Delete Conrimtion - Promotional Contract", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dlg == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        context.ContractClosures.DeleteObject(oCClause);

            //    }

            //    int suc = context.SaveChanges();
            //    if (suc > 0)
            //    {
            //        MessageBox.Show("Promotional Contract Deleted", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void isPoAdvertisementCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isPoAdvertisementCheckBox.Checked == true)
            {
                this.shopIDLookUpEdit.Properties.ReadOnly = false;
                this.floorAreaTextEdit.Properties.ReadOnly = true;
            }
            else
            {
                this.shopIDLookUpEdit.EditValue = 0;
                this.shopIDLookUpEdit.Properties.ReadOnly = true;
                this.floorAreaTextEdit.Properties.ReadOnly = false;
            }
        }

        private void companyIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //// Location..roshan..06oct2014
            int comid = 0;
            bool res = false;
            res = int.TryParse(companyIDLookUpEdit.EditValue.ToString(), out comid);
            if (res.Equals(true))
            {
                this.locationBindingSource.DataSource = (from c in context.Companies
                                                         join l in context.Locations on c.LocationID equals l.LocationID
                                                         where c.CompanyID == comid
                                                         select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
            }

        }

        private void shopIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.shopIDLookUpEdit.Text.ToString()))
            { return; }

            int shopid = int.Parse(this.shopIDLookUpEdit.EditValue.ToString());

            var qryShop = (from s in context.Shop_Details
                           where s.ShopID == shopid
                           select new { s.SqFeet }).AsEnumerable().LastOrDefault();
            if (qryShop != null)
            {
                ContractClosure cont = (ContractClosure)this.contractClosureBindingSource.Current;
                if (cont != null)
                {
                    cont.FloorArea = qryShop.SqFeet;
                }
            }

        }




    }
}