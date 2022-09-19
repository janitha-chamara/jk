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
    public partial class xShops : DevExpress.XtraEditors.XtraForm
    {


        AHPL_DBEntities context = new AHPL_DBEntities();
        bool addnew = false;
        List<Shops_UtilityReadings> shopUReadingList = new List<Shops_UtilityReadings>();

        private MasterData.xShop_Details shopDet;
        //List<Shop> shopList;
        //List<Shop_Details> shopdetailLits;
        //List<Floor_Levels> floorlevelLists;


        public xShops()
        {
            InitializeComponent();
        }

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    shopBindingSource.MoveFirst();
        //}

        private void parentTopPanel_Click(object sender, EventArgs e)
        {

        }

        private void xShops_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data() 
        {

            {
                //shops - primary entitiy              
                var qryShop = (from s in context.Shops
                               select s).ToList();

                shopBindingSource.DataSource = qryShop;
                //--

                // Rent Area Types 
                var qryRentAreaType = (from r in context.Rent_Area_Types
                                       select new { r.RentAreaTypeID, r.RentAreaTypeName }).ToList();
                this.lookRentAreaTypeID.DataSource = qryRentAreaType;
                this.lookRentAreaTypeID.DisplayMember = "RentAreaTypeName";
                this.lookRentAreaTypeID.ValueMember = "RentAreaTypeID";


                // location query
                var qryLoc = (from loc in context.Locations
                              select new { loc.LocationID, loc.LocationCode, loc.LocationName }).ToList();

                ////this.locationBindingSource.DataSource = qryLoc;
                this.locationBindingSource.DataSource = null;

                // level query               

                var levQry = (from f in context.Floor_Levels
                              select new { f.LevelID, f.LevelCode, f.LevelName }).ToList();
                ////this.floorLevelsBindingSource.DataSource = levQry;
                this.floorLevelsBindingSource.DataSource = null;

                // company query
                var qrycompany = (from c in context.Companies
                                  select new { c.CompanyCode, c.CompanyID, c.CompanyName }).ToList();
                this.companyBindingSource.DataSource = qrycompany;


                // ratio
                var qryratio = (from r in context.Ratios
                                select r).ToList();
                this.ratioBindingSource.DataSource = qryratio;

                // rent area types 
                var qryRentATypes = (from r in context.Rent_Area_Types
                                     select new { r.RentAreaTypeID, r.RentAreaTypeName }).ToList();
                this.rentAreaTypesBindingSource.DataSource = qryRentATypes;

                // zone 
                var qryZone = (from z in context.Zones
                               select new { z.ZoneID, z.ZoneName, z.LocationID }).ToList();
                this.zoneBindingSource.DataSource = qryZone;
                //--

                // Utility Rate
                var qryUR = (from u in context.Utilities
                             join ur in context.Utility_Rates on u.UtilityID equals ur.UtilityID
                             select new { u.UtilityName, ur.UtilityRateID, ur.UtilityRateProfileName }).ToList();
                repositoryItemLookUpEdit10.DataSource = qryUR;
                repositoryItemLookUpEdit10.DisplayMember = "UtilityRateProfileName";
                repositoryItemLookUpEdit10.ValueMember = "UtilityRateID";

                // -- 

                //this.enable_control(false, eRecStatus.eInit);

                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        

        private void locationIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.locationIDLookUpEdit.Text.ToString()))
            {
                return;
            }

            if (string.IsNullOrEmpty(this.companyIDLookUpEdit.Text.ToString()))
            { return; }

            int locid = 0;
            int compid = 0;
            bool res = int.TryParse(this.locationIDLookUpEdit.EditValue.ToString(), out locid);
            if (res == false) { locid = 0; }
            res = int.TryParse(this.companyIDLookUpEdit.EditValue.ToString(), out compid);
            if (res == false) { compid = 0; }

            if (locid > 0)
            {
                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    // zone 
                    var qryZone = (from z in context.Zones
                                   where z.LocationID == locid
                                   select new { z.ZoneID, z.ZoneName, z.LocationID }).ToList();
                    this.zoneBindingSource.DataSource = qryZone;

                    ////level query..roshan..26August2014.. 

                   

                    var levQry = (from f in context.Floor_Levels.Where(l => l.LocationID.Equals(locid))
                                  select new { f.LevelID, f.LevelCode, f.LevelName }).ToList();
                    this.floorLevelsBindingSource.DataSource = levQry;

                    ////End..26August2014

                    // Utility Rate
                    var qryUR = (from u in context.Utilities
                                 join ur in context.Utility_Rates on u.UtilityID equals ur.UtilityID
                                 where ur.CompanyID == compid && ur.LocatoinID == locid
                                 select new { u.UtilityName, ur.UtilityRateID, ur.UtilityRateProfileName }).ToList();

                    repositoryItemLookUpEdit10.DataSource = qryUR;
                    repositoryItemLookUpEdit10.DisplayMember = "UtilityRateProfileName";
                    repositoryItemLookUpEdit10.ValueMember = "UtilityRateID";

                    
                }

            }
            else ////roshan..26August2014
            {
                this.floorLevelsBindingSource.DataSource = null;
            }
        }

        private void companyIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            

            ////To filter Location acording to extended customer..roshan26August2014..
            ////location query

            if (string.IsNullOrEmpty(this.companyIDLookUpEdit.Text.ToString()))
            {
                return;
            }

            int compid = 0;
            bool res = int.TryParse(this.companyIDLookUpEdit.EditValue.ToString(), out compid);
            if (res == false)
            {
                compid = 0;
            }

            List<int> locationIds = context.Extended_Customers.Where(c => c.CompanyID.Equals(compid)).Select(s => s.LocationID).ToList();

            var qryLoc = (from loc in context.Locations.Where(w => locationIds.Contains(w.LocationID))
                          select new { loc.LocationID, loc.LocationCode, loc.LocationName }).ToList();

            this.locationBindingSource.DataSource = qryLoc;

            ////level query 

            if (string.IsNullOrEmpty(this.locationIDLookUpEdit.Text.ToString()))
            {
                this.floorLevelsBindingSource.DataSource = null;
                return;
            }

            int locationid = 0;
            res = int.TryParse(this.locationIDLookUpEdit.EditValue.ToString(), out locationid);
            if (res == false) { locationid = 0; }

            var levQry = (from f in context.Floor_Levels.Where(l => l.LocationID.Equals(locationid))
                          select new { f.LevelID, f.LevelCode, f.LevelName }).ToList();
            this.floorLevelsBindingSource.DataSource = levQry;

            ////End..26August2014

        }



        private void customerIDSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }


        private void levelIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colIsRatioApplied)
            {
                bool bval = false;
                bool res = bool.TryParse(e.Value.ToString(), out bval);
                if (res == false) { bval = false; }

                if (bval == false)
                {
                    gridView2.SetRowCellValue(e.RowHandle, colRatioID, 0);
                }
            }

            if (e.Column == colUtilityRateID)
            {
                bool res = false;
                int utilityrateid = 0;
                res = int.TryParse(e.Value.ToString(), out utilityrateid);
                if (res == false) { utilityrateid = 0; }
                if (utilityrateid == 0) { return; }


                var qryUtilityRate = (from ur in context.Utility_Rates
                                      where ur.UtilityRateID == utilityrateid
                                      select new { ur.UtilityID }).FirstOrDefault();
                if (qryUtilityRate != null)
                {
                    Shops_UtilityReadings shoputilityReading = (Shops_UtilityReadings)shops_UtilityReadingsBindingSource.Current;

                    if (shoputilityReading != null)
                    {
                        shoputilityReading.UtilityID = qryUtilityRate.UtilityID;
                    }


                }

            }

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rentAreaTypeIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow qryRow = this.gridView2.GetDataRow(e.RowHandle);
            Shops_UtilityReadings drow = (Shops_UtilityReadings)e.Row;

            if (drow == null)
            { return; }


            if (drow.MeterName == null)
            {
                e.ErrorText = "Invalid Meter Name";
                e.Valid = false;

            } { e.ErrorText = ""; e.Valid = true; }


            if (string.IsNullOrEmpty(drow.MeterName.ToString()))
            {
                e.ErrorText = "Invalid Meter Name";
                e.Valid = false;

            }
            {
                e.ErrorText = "";
                e.Valid = true;
            }


        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Excel (*.xlsx)|*.xlsx";
                saveDlg.ShowDialog();
                string filename = saveDlg.FileName;
                this.gridView1.OptionsPrint.AutoWidth = false;
                this.gridView1.ExportToXlsx(filename);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
        }

        private void sqFeetTextEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            try
            {
                Shop shopObj = (Shop)this.shopBindingSource.Current;
                if (shopObj == null) { return; }

                shopDet = new MasterData.xShop_Details();


                shopDet.FormClosing += new FormClosingEventHandler(shopDet_FormClosing);

                //location total 
                decimal totalFloorArea = 0;
                int locationID = 0;
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryLocTotal = (from l in context.Locations
                                       where l.LocationID == shopObj.LocationID
                                       select new { l.TotalFloorArea, l.LocationID }).FirstOrDefault();
                    totalFloorArea = qryLocTotal.TotalFloorArea;
                    locationID = qryLocTotal.LocationID;

                }
                shopDet.LocationID = locationID;
                shopDet.LocTotalFloorArea = totalFloorArea;
                shopDet.ShopID = shopObj.ShopID;
                shopDet.ShopNo = shopObj.ShopNo;
                shopDet.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void shopDet_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (shopDet.SqFt > 0)
            {
                Shop oShop = (Shop)this.shopBindingSource.Current;
                if (oShop == null)
                { return; }


                var qryLocTotal = (from l in context.Locations
                                   where l.LocationID == oShop.LocationID
                                   select new { l.TotalFloorArea }).FirstOrDefault();

                List<decimal> total = new List<decimal>();

                var qryShopTotal = (from s in context.Shops
                                    join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                    where s.LocationID == oShop.LocationID && s.SqFeet > 1 && ra.IsAdvertisement == false
                                    select new { s.SqFeet }).ToList();
                foreach (var qry in qryShopTotal)
                {
                    total.Add(qry.SqFeet);
                }

                decimal shopTotal = total.Sum();
                decimal totalwithEnterdValue = 0;
                if (oShop.SqFeet > 1)
                {
                    totalwithEnterdValue = shopTotal + oShop.SqFeet;
                }
                else
                {
                    totalwithEnterdValue = shopTotal;

                }



                if (totalwithEnterdValue > qryLocTotal.TotalFloorArea)
                {
                    ////throw new Exception("Entered Square Feet is greater than the Location's total square feet");
                    MessageBox.Show("Entered Square Feet is greater than the Location's total square feet");
                    return;
                }

                oShop.SqFeet = shopDet.SqFt;
                oShop.LastUpdated = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                oShop.LastUpdateDate = DateTime.Now;
                context.Shops.ApplyCurrentValues(oShop);

                int succ = context.SaveChanges();

                //this.enable_control(false, eRecStatus.eSave);
                //this.sqFeetTextEdit.EditValue = shopDet.SqFt;
            }
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


                this.shopBindingSource.AddNew();
                //this.enable_control(true, eRecStatus.eAddNew);
                this.companyIDLookUpEdit.Focus();
                addnew = true;
                sqFeetTextEdit.Enabled = false;

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


                Shop oShop = (Shop)this.shopBindingSource.Current;
                sqFeetTextEdit.Properties.ReadOnly = false;
                sqFeetTextEdit.Enabled = true;


                if (oShop != null)
                {
                    int shopid = oShop.ShopID;
                    int shopdetcount = 0;
                    if (shopid > 0)
                    {
                        var qryUR = (from ur in context.Shops_UtilityReadings
                                     where ur.ShopID == shopid
                                     select new { ur.ShopID }).ToList();
                        if (qryUR.Count == 0)
                        {

                            //this.enable_control(true, eRecStatus.eEdit);
                            shops_UtilityReadingsGridControl.Enabled = true;
                        }
                        else
                        {
                            shopdetcount = qryUR.Count;
                            //this.enable_control(false, eRecStatus.eInit);
                            shops_UtilityReadingsGridControl.Enabled = true;

                        }
                        //// allow user to enter utility readings , already processed contracts as requested on 24/04/2013

                        

                        var qryCont = (from c in context.ContractClosures
                                       where c.ShopID == shopid && c.IsTerminated == false
                                       select new { c.IsProcessed }).FirstOrDefault();

                        if (qryCont == null)
                        {
                            //this.enable_control(true, eRecStatus.eEdit);
                        }
                        else
                        {

                            if (qryCont.IsProcessed == true) // if the contract is processed for the relevent shop cannot be edited square foot value
                            {
                                
                                this.locationIDLookUpEdit.Properties.ReadOnly = true;
                                this.levelIDLookUpEdit.Properties.ReadOnly = true;
                                this.companyIDLookUpEdit.Properties.ReadOnly = true;
                                this.zoneIDLookUpEdit.Properties.ReadOnly = true;
                                this.shopNoTextEdit.Properties.ReadOnly = true;
                                this.sqFeetTextEdit.Properties.ReadOnly = true;
                                this.rentAreaTypeIDLookUpEdit.Properties.ReadOnly = true;
                                this.shops_UtilityReadingsGridControl.Enabled = true;
                            }
                            else
                            {
                                //this.enable_control(true, eRecStatus.eEdit); // enabling save button

                                //this.locationIDLookUpEdit.Properties.ReadOnly = true;
                                //this.levelIDLookUpEdit.Properties.ReadOnly = true;
                                //this.companyIDLookUpEdit.Properties.ReadOnly = true;
                                //this.zoneIDLookUpEdit.Properties.ReadOnly = true;
                                //this.shopNoTextEdit.Properties.ReadOnly = true;
                                ////this.sqFeetTextEdit.Properties.ReadOnly = true;
                                //this.rentAreaTypeIDLookUpEdit.Properties.ReadOnly = true;

                                //this.shops_UtilityReadingsGridControl.Enabled = true;

                            }
                        }
                    }
                }
                //this.customerIDSearchLookUpEdit.Properties.ReadOnly = true;
                //this.shopNameTextEdit.Properties.ReadOnly = true;

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
                this.shopBindingSource.EndEdit();
                this.shops_UtilityReadingsBindingSource.EndEdit();

                int locid = 0; int levelid = 0; int compid = 0;
                string shopno = string.Empty;


                bool res = false;

                res = int.TryParse(this.locationIDLookUpEdit.EditValue.ToString(), out locid);
                if (res == false) { locid = 0; }

                res = int.TryParse(this.levelIDLookUpEdit.EditValue.ToString(), out levelid);
                if (res == false) { levelid = 0; }

                res = int.TryParse(this.companyIDLookUpEdit.EditValue.ToString(), out compid);
                if (res == false) { compid = 0; }

                //validating rent area type 
                if (string.IsNullOrEmpty(this.rentAreaTypeIDLookUpEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.rentAreaTypeIDLookUpEdit, "Invalid Rent Area");
                    return;
                }
                else
                {
                    int rentarea = 0;
                    res = int.TryParse(this.rentAreaTypeIDLookUpEdit.EditValue.ToString(), out rentarea);
                    if (res == false || rentarea == 0)
                    {
                        dxErrorProvider1.SetError(this.rentAreaTypeIDLookUpEdit, "Invalid Rent Area");
                        return;
                    }
                    else
                    {
                        dxErrorProvider1.SetError(this.rentAreaTypeIDLookUpEdit, "");
                    }
                }


                shopno = this.shopNoTextEdit.EditValue.ToString().Trim();


                if (addnew == true)
                {
                    var qry = (from s in context.Shops
                               where s.LocationID == locid && s.CompanyID == compid && s.LevelID == levelid && s.ShopNo == shopno
                               select new { s.ShopID }).ToList();
                    if (qry.Count > 0)
                    {
                        MessageBox.Show("Already a record exist with same value of Locaiton, Company and Level", "Duplicate Item cannot be entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }


                //validating location
                if (locid == 0)
                {
                    dxErrorProvider1.SetError(this.locationIDLookUpEdit, "Invalid Location");
                    return;
                }
                else { dxErrorProvider1.SetError(this.locationIDLookUpEdit, ""); }

                //validating levels
                if (levelid == 0)
                {
                    dxErrorProvider1.SetError(this.levelIDLookUpEdit, "Invalid Level");
                    return;

                }
                else { dxErrorProvider1.SetError(this.levelIDLookUpEdit, ""); }
                //--

                //validating company
                if (compid == 0)
                {
                    dxErrorProvider1.SetError(this.companyIDLookUpEdit, "Invalid Company");
                    return;
                }
                else { dxErrorProvider1.SetError(this.companyIDLookUpEdit, ""); }
                //--

                ////validating Utility readings
                Shop oShop = (Shop)this.shopBindingSource.Current;
                List<Shops_UtilityReadings> shopUDet = oShop.Shops_UtilityReadings.ToList();
                if (shopUDet.Any(a => a.UtilityRateID.Equals(0))) 
                {
                    MessageBox.Show("Invalid Utility Profile Name");
                    return;
                }

                // getting current instance of the shop


                foreach (var qry in shopUDet)
                {
                    if (qry.IsDeleted == true)
                    {
                        context.Shops_UtilityReadings.DeleteObject(qry);
                    }
                }

                // if shopid =0 then the add new object to the entity
                if (oShop.ShopID == 0)
                {
                    oShop.SqFeet = 0;
                    oShop.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oShop.CreatedDate = DateTime.Now;
                    context.Shops.AddObject(oShop);

                }
                else // replacing the value
                {
                    var qryLocTotal = (from l in context.Locations
                                       where l.LocationID == oShop.LocationID
                                       select new { l.TotalFloorArea }).FirstOrDefault();
                    var qryShopTotal = (from s in context.Shops
                                        join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                        where s.LocationID == oShop.LocationID && s.SqFeet > 1 && ra.IsAdvertisement == false
                                        select new { s.SqFeet }).Sum(x => x.SqFeet);
                    decimal availArea = qryLocTotal.TotalFloorArea - qryShopTotal;


                    decimal sqFt = 0;
                    res = decimal.TryParse(sqFeetTextEdit.EditValue.ToString(), out sqFt);
                    if (res == false) { sqFt = 0; }




                    oShop.LastUpdated = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oShop.LastUpdateDate = DateTime.Now;
                    context.Shops.ApplyCurrentValues(oShop);

                }



                // commiting changes to the database 
                int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                if (succ > 0)
                {
                    string msg = "";
                    if (addnew == true)
                    {
                        msg = "Record Saved Successfully..." + System.Environment.NewLine +
                            "Do you want to enter shop's square feet?";
                        DialogResult dlg = MessageBox.Show(msg, "Save Success - Shops/Booths", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlg == System.Windows.Forms.DialogResult.Yes)
                        {
                            Shop shopObj = (Shop)this.shopBindingSource.Current;
                            if (shopObj == null) { return; }

                            shopDet = new MasterData.xShop_Details();


                            shopDet.FormClosing += new FormClosingEventHandler(shopDet_FormClosing);

                            //location total 
                            decimal totalFloorArea = 0;
                            int locationID = 0;

                            var qryLocTotal = (from l in context.Locations
                                               where l.LocationID == shopObj.LocationID
                                               select new { l.TotalFloorArea, l.LocationID }).FirstOrDefault();
                            totalFloorArea = qryLocTotal.TotalFloorArea;
                            locationID = qryLocTotal.LocationID;

                            shopDet.LocationID = locationID;
                            shopDet.LocTotalFloorArea = totalFloorArea;
                            shopDet.ShopID = shopObj.ShopID;
                            shopDet.ShopNo = shopObj.ShopNo;
                            shopDet.ShowDialog(this);

                        }
                    }
                    else
                    {

                        MessageBox.Show("Record Saved Successfully", "Save Success - Shops/Booths", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //this.enable_control(false, eRecStatus.eSave);
                context.Refresh(RefreshMode.StoreWins, context.Shops);

                addnew = false;

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

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.shopBindingSource.CancelEdit();
            dxErrorProvider1.ClearErrors();
            load_data();
            addnew = false;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DialogResult dlg = MessageBox.Show("Do you want to delete the current record?", "Delete - Shop/Booth", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.No)
                { return; }
                //check existing data in the contract_shops
                Shop oShop = (Shop)shopBindingSource.Current;
                var qryShop = (from cs in context.ContractClosures
                               where cs.ShopID == oShop.ShopID && cs.IsTerminated == false
                               select new { cs.ShopID, cs.ContractClosureName, cs.ShopNo, cs.ShopName }).ToList();
                if (qryShop.Count > 0)
                {
                    var qryShopFirst = qryShop.FirstOrDefault();

                    MessageBox.Show("The Shop already integrated in the Contracts," + System.Environment.NewLine +
                        "Contract : " + qryShopFirst.ContractClosureName + System.Environment.NewLine +
                        "Shop No : " + qryShopFirst.ShopNo + System.Environment.NewLine +
                        "Shop Name : " + qryShopFirst.ShopName + System.Environment.NewLine +
                        "Therefore you cannot delete this Shop/Booth", "Cannot Delete - Shop/Booths", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Shop shopObjectDelete = (from s in context.Shops
                                         where s.ShopID == oShop.ShopID
                                         select s).FirstOrDefault();

                shopBindingSource.RemoveCurrent();
                context.Shops.DeleteObject(shopObjectDelete);


                int succ = context.SaveChanges();

                if (succ > 0)
                {
                    MessageBox.Show("Shop/Booths Deleted Successfully...", "Delete Success - Shop/Booth", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_data();
        }


    }
}
