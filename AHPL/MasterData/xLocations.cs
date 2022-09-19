using System;
using System.Windows.Forms;
//using MMS.DataTier;
using System.Data.Objects;
using System.Linq;
using DataTier;
using MMS.CustomClasses;
using System.Collections;
using System.Collections.Generic;

namespace MMS
{
    public partial class xLocations : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        //List<Location> LocationList;
        private MasterData.xLocation_Details locdet;
        public xLocations()
        {
            InitializeComponent();
        }

        private void xLocations_Load(object sender, EventArgs e)
        {
            load_data();

            

        }

        private void load_data()
        {

            // primary entity
            this.locationBindingSource.DataSource = (from l in context.Locations
                                                     select l).ToList();
            //this.enable_control(false, eRecStatus.eInit);

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

                


        

        private void refresh_data()
        {
            //using (AHPL_DBEntities context = new AHPL_DBEntities())
            //{
                var locs = from loc in context.Locations
                           select loc;
                context.Refresh(RefreshMode.StoreWins, locs);
                this.locationBindingSource.DataSource = locs;
                //this.enable_control(false, eRecStatus.eInit);
            //}
        }

        

        private void save_data()
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                int succ = 0;
                //this.Validate();
                this.locationBindingSource.EndEdit();
                Location loc = (Location)this.locationBindingSource.Current;
                if (loc.LocationID == 0)
                {
                    context.Locations.AddObject(loc);
                }
                else
                {
                    var entkey = context.GetObjectByKey(loc.EntityKey);
                    // context.Locations.Attach(loc);

                    //context.ObjectStateManager.ChangeObjectState(loc, EntityState.Modified);
                    //context.Locations.ApplyCurrentValues(loc);
                    context.Locations.ApplyCurrentValues(loc);
                  
                }

                 succ = context.SaveChanges(SaveOptions.DetectChangesBeforeSave);

                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Save Success - Location - MMS Client Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.enable_control(false, eRecStatus.eSave);
                }

            }
        }

        private bool validate_data()
        {
            bool validated = false;


            string loccode = this.locationCodeTextEdit.Text.ToString().Trim();

            if (string.IsNullOrEmpty(loccode))
            {
                dxErrorProvider1.SetError(this.locationCodeTextEdit, "Location Code cannot be empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);

                validated = false;
                return validated;
            }
            else
            {
                dxErrorProvider1.SetError(this.locationCodeTextEdit, "");
                validated = true;
            }
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                this.locationBindingSource.EndEdit();

                Location loc = (Location)this.locationBindingSource.Current;

                if (loc.LocationID == 0)
                {

                    var qryloc = (from l in context.Locations
                                  where l.LocationCode == loccode
                                  select new { l.LocationCode }).ToList();
                    if (qryloc.Count > 0)
                    {
                        dxErrorProvider1.SetError(this.locationCodeTextEdit, "Location Code already exist, please enter different location code");
                        validated = false;
                        return validated;
                    }
                    else
                    {
                        dxErrorProvider1.SetError(this.locationCodeTextEdit, "");
                        validated = true;
                        return validated;
                    }

                }

                else
                {

                }

            }





            return validated;
        }

       

        private void locationBindingSource_PositionChanged(object sender, EventArgs e)
        {
            getLocationValue();

        }

        private void getLocationValue()
        {
            try
            {

                Location oLoc = (Location)this.locationBindingSource.Current;
                if (oLoc != null)
                {
                    if (oLoc.LocationID > 0)
                    {
                        txtAvailArea.EditValue = cCommon_Functions.getAvailableArea(oLoc.LocationID);

                        txtOccupiedArea.EditValue = cCommon_Functions.getTotalOccArea(oLoc.LocationID);

                        bool res = false;
                        decimal availArea = 0; decimal occArea = 0;
                        //res = decimal.TryParse(txtAvailArea.Text.ToString(), out availArea);
                        //if (res == false) { availArea = 0; }
                        availArea = oLoc.TotalFloorArea;

                        res = decimal.TryParse(txtOccupiedArea.Text.ToString(), out occArea);

                        decimal freeArea = 0;
                        List<decimal> totalList = new List<decimal>();

                        var qryShopTotal = (from s in context.Shops
                                            join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                            where s.LocationID == oLoc.LocationID && s.SqFeet > 1 && ra.IsAdvertisement == false
                                            select new { s.SqFeet }).ToList();
                        foreach (var qry in qryShopTotal)
                        {
                            totalList.Add(qry.SqFeet);
                        }

                        decimal shopTotal = totalList.Sum();

                        freeArea = availArea - shopTotal;
                        this.txtFreeArea.EditValue = freeArea;
                    }
                    else
                    {
                        this.txtAvailArea.EditValue = 0;
                        this.txtOccupiedArea.EditValue = 0;
                        this.txtFreeArea.EditValue = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void totalFloorAreaTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            try
            {
                Location locObj = (Location)this.locationBindingSource.Current;
                if (locObj == null) { return; }

                if (locObj.LocationID == 0)
                {
                    MessageBox.Show("Please Save the Location first to enter location's square feet detail", "Save the changes - Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                locdet = new MasterData.xLocation_Details();


                locdet.FormClosing += new FormClosingEventHandler(locDet_FormClosing);
                locdet.LocationID = locObj.LocationID;
                locdet.LocationCode = locObj.LocationCode;
                locdet.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void locDet_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (locdet.SqFt > 0)
            {
                this.totalFloorAreaTextEdit.EditValue = locdet.SqFt;
            }
            getLocationValue();

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


                ////this.enable_control(true, eRecStatus.eAddNew);
                locationBindingSource.AddNew();
                this.locationCodeTextEdit.Focus();
                txtOccupiedArea.Properties.ReadOnly = true;
                txtAvailArea.Properties.ReadOnly = true;
                totalFloorAreaTextEdit.Properties.ReadOnly = true;

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


                ///this.enable_control(true, eRecStatus.eEdit);
                locationCodeTextEdit.Properties.ReadOnly = true;
                this.txtAvailArea.Properties.ReadOnly = true;
                this.txtOccupiedArea.Properties.ReadOnly = true;
                totalFloorAreaTextEdit.Properties.ReadOnly = true;

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
            this.locationBindingSource.CancelEdit();
            refresh_data();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Do you want to delete the current record?", "Delete - Location", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                Location oLoc = (Location)this.locationBindingSource.Current;

                // checking existing data in the contract
                var qryLoc = (from l in context.Contracts
                              where l.LocationID == oLoc.LocationID
                              select new { l.LocationID }).ToList();
                if (qryLoc.Count > 0)
                {
                    MessageBox.Show("The Locaiton already in the contracts, there for you cannot delete this Location", "Cannot Delete - Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // ---- 

                // checking existing data in companies 
                var qryComp = (from c in context.Companies
                               where c.LocationID == oLoc.LocationID
                               select new { c.LocationID }).ToList();
                if (qryComp.Count > 0)
                {
                    MessageBox.Show("The selected Locaiton already in the Company, there for you cannot delete this Location", "Cannot Delete - Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //


                // checking existing data in Shops 
                var qryShop = (from s in context.Shops
                               where s.LocationID == oLoc.LocationID
                               select new { s.LocationID }).ToList();
                if (qryShop.Count > 0)
                {
                    MessageBox.Show("The selected Locaiton already in the Company, there for you cannot delete this Location", "Cannot Delete - Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // -- 

                // if everything is okay then delete 
                locationBindingSource.RemoveCurrent();

                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                this.Validate();
                locationBindingSource.EndEdit();

                Location oLocation = (Location)this.locationBindingSource.Current;
                if (oLocation == null) { return; }

                if (string.IsNullOrEmpty(this.locationCodeTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.locationCodeTextEdit, "Location Code cannot be empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.locationCodeTextEdit, "");
                }

                if (string.IsNullOrEmpty(this.invoicePrefixTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.invoicePrefixTextEdit, "Invoice Prefix Cannot Be Empty");
                    return;
                }
                else { dxErrorProvider1.SetError(this.invoicePrefixTextEdit, ""); }

                if (oLocation.LocationID == 0) // addnew status
                {
                    var qryDupp = (from l in context.Locations
                                   where l.LocationName == oLocation.LocationName
                                   select new { l.LocationName }).ToList();
                    if (qryDupp.Count > 0)
                    {
                        MessageBox.Show("Location Already Exist", "Dupplicate Entry - Locaiton", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    oLocation.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oLocation.CreatedDate = DateTime.Now;
                    context.Locations.AddObject(oLocation);
                }

                else
                {
                    oLocation.LastUpdated = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oLocation.LastUpdateDate = DateTime.Now;
                    context.Locations.ApplyCurrentValues(oLocation); // editing
                }


                //if (_current.LocationID ==0)
                int succ = 0;


                succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                if (succ > 0)
                {
                    MessageBox.Show("Record saved Successfully", "Save Success - Location", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_data();
                }
                else
                {
                    //enable_control(false, eRecStatus.eSave);
                }
            }

            catch (System.Data.UpdateException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
