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
    public partial class xPoContract_Confirm : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xPoContract_Confirm()
        {
            InitializeComponent();
        }

        private void xPoContract_Confirm_Load(object sender, EventArgs e)
        {
            // loading contract clause 
            var qryCClause = (from c in context.ContractClosures
                              select c).ToList();
            this.contractClosureBindingSource.DataSource = qryCClause;
            //--

            // loading companies 
            var qryComp = (from c in context.Companies
                           select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();

            this.companyIDLookUpEdit.Properties.DataSource = this.lookUpEditCompanyN.Properties.DataSource = qryComp;
            //--

            // loading locations
            var qryLoc = (from l in context.Locations
                          select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
            this.locationIDLookUpEdit.Properties.DataSource = this.lookUpEditLocationN.Properties.DataSource = qryLoc;

            //--

            //Loading Floor Levels
            var qryFlevel = (from f in context.Floor_Levels
                             select new { f.LevelID, f.LevelCode, f.LevelName }).ToList();
            this.levelIDLookUpEdit.Properties.DataSource = qryFlevel;
            //--

            // Loading Promotional Rent Type 
            var qryRentType = (from r in context.Promotion_RentTypes
                               select new { r.PoRentTypeID, r.RentTypeName }).ToList();
            this.promotionRentTypesBindingSource.DataSource = qryRentType;
            this.lookUpEditRentTypeN.Properties.DataSource = qryRentType;
            //-

            //shops 
            var qryShop = (from s in context.Shops
                           join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                           where ra.IsAdvertisement == true
                           select new { s.ShopID, s.ShopNo }).ToList();
          this.lookShopNID.Properties.DataSource =  this.shopIDLookUpEdit.Properties.DataSource = qryShop;
          this.lookShopNID.Properties.DisplayMember =  this.shopIDLookUpEdit.Properties.DisplayMember = "ShopNo";
          this.lookShopNID.Properties.ValueMember =  this.shopIDLookUpEdit.Properties.ValueMember = "ShopID";
           

            load_Customer();

        }
        public void Load_DataByPoContractClauseID(int pCClauseID)
        {
           
            var qryCClause = (from c in context.ContractClosures
                              where c.ContractClosureID == pCClauseID
                              select c).FirstOrDefault();
            this.contractClosureBindingSource.DataSource = qryCClause;

            this.customerNameTextEdit.EditValue = qryCClause.CustomerName;
            this.lookupEditCustomer.EditValue = qryCClause.ExtendedCustomerID;
            this.lookUpEditCompanyN.EditValue = this.companyIDLookUpEdit.EditValue;
            this.lookUpEditLocationN.EditValue = this.locationIDLookUpEdit.EditValue;
            this.textEditFloorAreaN.EditValue = this.floorAreaTextEdit.EditValue;
            this.lookUpEditLevelN.EditValue = this.levelIDLookUpEdit.EditValue;
            this.lookUpEditRentTypeN.EditValue = this.poRentTypeIDLookUpEdit.EditValue;
            this.shopIDLookUpEdit.EditValue = qryCClause.ShopID;







        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                bool res = false;
                int cclauseid = 0;
                int exCustID = 0;
                int compid = 0;
                int locid = 0;
                int levelid = 0;
                decimal floorAreaN = 0;
                decimal floorArea = 0;
                int rentTyepN = 0;

                //validating customer 
                if (!string.IsNullOrEmpty(this.lookupEditCustomer.Text.ToString()))
                {
                    res = int.TryParse(this.lookupEditCustomer.EditValue.ToString(), out exCustID);
                    if (res == false)
                    {
                        dxErrorProvider1.SetError(this.lookupEditCustomer, "Invalid Customer");
                        return;
                    }
                    else { dxErrorProvider1.SetError(this.lookupEditCustomer, ""); }
                }
                else
                {
                    dxErrorProvider1.SetError(this.lookupEditCustomer, "Invalid Customer");
                    return;
                }
                //---

                //Validating Company 
                if (!string.IsNullOrEmpty(this.lookUpEditCompanyN.Text.ToString()))
                {
                    res = int.TryParse(this.lookUpEditCompanyN.EditValue.ToString(), out compid);
                    if (res == false)
                    {
                        dxErrorProvider1.SetError(this.lookUpEditCompanyN, "Invalid Company");
                        return;
                    }

                }
                else
                {
                    dxErrorProvider1.SetError(this.lookUpEditCompanyN, "Invalid Company");
                    return;
                }

                //- 

                //Validating Location 
                if (!string.IsNullOrEmpty(this.lookUpEditLocationN.Text.ToString()))
                {
                    res = int.TryParse(this.lookUpEditLocationN.EditValue.ToString(), out locid);
                    if (res == false)
                    { dxErrorProvider1.SetError(this.lookUpEditLocationN, "Invalid Location"); return; }


                }
                else { dxErrorProvider1.SetError(this.lookUpEditLocationN, "Invalid Location"); return; }

                //--

                //validating floor level 
                if (!string.IsNullOrEmpty(this.lookUpEditLevelN.Text.ToString()))
                {
                    res = int.TryParse(this.lookUpEditLevelN.EditValue.ToString(), out levelid);
                    if (res == false)
                    {
                        dxErrorProvider1.SetError(this.lookUpEditLevelN, "Invalid Floor Level");
                        return;
                    }
                }
                else
                {
                    dxErrorProvider1.SetError(this.lookUpEditLevelN, "Invalid Floor Level");
                    return;
                }

                //--

                //validating floor area 
                if (!string.IsNullOrEmpty(this.textEditFloorAreaN.Text.ToString()))
                {
                    res = decimal.TryParse(this.textEditFloorAreaN.EditValue.ToString(), out floorAreaN);
                    if (res == false)
                    {
                        dxErrorProvider1.SetError(this.textEditFloorAreaN, "Invalid Floor Area");
                        return;
                    }
                }
                else
                {
                    dxErrorProvider1.SetError(this.textEditFloorAreaN, "Invalid Floor Area");
                    return;
                }

                //--

                //valdating Rent Type 
                if (!string.IsNullOrEmpty(this.lookUpEditRentTypeN.Text.ToString()))
                {
                    res = int.TryParse(this.lookUpEditRentTypeN.EditValue.ToString(), out rentTyepN);
                    if (res == false)
                    {
                        dxErrorProvider1.SetError(this.lookUpEditRentTypeN, "Invalid Rent Type");
                        return;
                    }
                }
                else
                {
                    dxErrorProvider1.SetError(this.lookUpEditRentTypeN, "Invalid Rent Type");
                    return;
                }
                //--

                // Validating Contract Clause 
                if (!string.IsNullOrEmpty(this.lookUpEditContractName.Text.ToString()))
                {
                    res = int.TryParse(this.lookUpEditContractName.EditValue.ToString(), out cclauseid);
                    if (res == false)
                    {
                        dxErrorProvider1.SetError(this.lookUpEditContractName, "Invalid Contract Clause");
                        return;
                    }

                }
                else
                {
                    dxErrorProvider1.SetError(this.lookUpEditContractName, "Invalid Contract Clause");
                    return;
                }
                //--

                if (isPoAdvertisementCheckBox.Checked == true)
                {

                    // new linking shop no validating
                    if (string.IsNullOrEmpty(this.lookShopNID.Text.ToString()))
                    {
                        dxErrorProvider1.SetError(this.lookShopNID, "Shop No cannot be empty");
                        return;
                    }
                    else { dxErrorProvider1.SetError(this.lookShopNID, ""); }

                    // floor area validating
                    res = decimal.TryParse(this.floorAreaTextEdit.EditValue.ToString(), out floorArea);
                    if (res == false) { floorArea = 0; }
                    res = decimal.TryParse(this.textEditFloorAreaN.EditValue.ToString(), out floorAreaN);
                    if (res == false) { floorAreaN = 0; }
                    
                    if (floorArea!= floorAreaN)
                    {
                        dxErrorProvider1.SetError(this.textEditFloorAreaN, "Floor Area mis matched");
                        return;
                    }
                    else
                    {
                        dxErrorProvider1.SetError(this.textEditFloorAreaN, "");
                    }
                       
                    // shop no matching and validating
                    int shopid = int.Parse(this.shopIDLookUpEdit.EditValue.ToString());
                    int shopidN = int.Parse(this.lookShopNID.EditValue.ToString());

                    if (shopid != shopidN)
                    {
                        dxErrorProvider1.SetError(this.lookShopNID, "Shop No Mis Matched");
                        return;
                    } else { dxErrorProvider1.SetError(this.lookShopNID,"");}
                  
                    
                        var qryShop = (from s in context.Shops
                                       where s.ShopID == shopid
                                       select s).FirstOrDefault();
                        if (qryShop !=null) 
                        {
                            if (qryShop.CustomerID > 0) 
                            {
                                throw new Exception("Advertisement space '" + qryShop.ShopNo + "' already assigned to a cutomer");
                            }
                            else 
                            {
                                cReserveShop.ReserveShop(shopidN, exCustID,"Advertisement");
                              
                            }

                        }


                }



                dxErrorProvider1.ClearErrors();

                var qryCClause = (from c in context.ContractClosures
                                  where c.ContractClosureID == cclauseid
                                  select c).FirstOrDefault();
                if (qryCClause != null)
                {
                    qryCClause.ExtendedCustomerID = exCustID;
                    qryCClause.CompanyID = compid;
                    qryCClause.LocationID = locid;
                    qryCClause.LevelID = levelid;
                    qryCClause.PoRentTypeID = rentTyepN;
                    qryCClause.FloorArea = floorAreaN;
                    if (qryCClause.IsPoAdvertisement == true)
                    {
                        qryCClause.ShopID = int.Parse(shopIDLookUpEdit.EditValue.ToString());
                    }

                    qryCClause.IsProcessed = true;
                }

                // saving entity 
                int succ = context.SaveChanges();
                int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.OtherServiceContractAssigned;
                MMS.CustomClasses.cCommon_Functions.AddToEmailList(compid, locid, alert, "Contract : " + this.lookUpEditContractName.Text + System.Environment.NewLine + "Customer : " + this.customerNameTextEdit.Text,MMS.CustomClasses.cCommon_Functions.LoggedUserID);
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully...", "Save Success - Pro. Contrct Confirmtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }


                //--
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void linkLabelCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xExtended_Customers excCust = new xExtended_Customers();
            excCust.FormClosing+=new FormClosingEventHandler(excCust_FormClosing);
            excCust.Show(this);

           
        }

        private void excCust_FormClosing(object sender, FormClosingEventArgs e)
        {
            load_Customer();

        }

        private void load_Customer()
        {
            context.Refresh(RefreshMode.StoreWins, context.Extended_Customers);
            var qryCust = (from ecust in context.Extended_Customers
                           join gcust in context.Global_Customers on ecust.CustomerID equals gcust.CustomerID
                           join comp in context.Companies on ecust.CompanyID equals comp.CompanyID
                           join loc in context.Locations on ecust.LocationID equals loc.LocationID
                           select new {ecust.ExtendedCustomerID, gcust.CustomerName, comp.CompanyCode, loc.LocationCode }).ToList();
            cCustomersContractBindingSource.DataSource = qryCust;


        }

        private void lookUpEditContractName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditLocationN_EditValueChanged(object sender, EventArgs e)
        {
            bool res = false;
            int locid = 0;
            int compid = 0;
            if (!string.IsNullOrEmpty(this.lookUpEditLocationN.Text.ToString()))
            {                           
                res = int.TryParse(this.lookUpEditLocationN.EditValue.ToString(), out locid);
                if (res == false)
                {
                    return;
                }

                var qryLevel = (from l in context.Floor_Levels
                                where l.LocationID == locid
                                select new { l.LevelID, l.LevelCode, l.LevelName }).ToList();
                this.lookUpEditLevelN.Properties.DataSource = qryLevel;
            }

            if (!string.IsNullOrEmpty(this.lookUpEditCompanyN.Text.ToString()))
            {
                res = int.TryParse(this.lookUpEditCompanyN.EditValue.ToString(), out compid);
                if (res == false)
                {
                    return;
                }

            }

            if (compid > 0 && locid > 0)
            {
                var qryCust = (from ecust in context.Extended_Customers
                               join gcust in context.Global_Customers on ecust.CustomerID equals gcust.CustomerID
                               join comp in context.Companies on ecust.CompanyID equals comp.CompanyID
                               join loc in context.Locations on ecust.LocationID equals loc.LocationID
                               where comp.CompanyID == compid && loc.LocationID == locid
                               select new { ecust.ExtendedCustomerID, gcust.CustomerName, comp.CompanyCode, loc.LocationCode }).ToList();
                lookupEditCustomer.Properties.DataSource = qryCust;
                lookupEditCustomer.Properties.DisplayMember = "CustomerName";
                lookupEditCustomer.Properties.ValueMember = "ExtendedCustomerID";

            }

        }

    }
}