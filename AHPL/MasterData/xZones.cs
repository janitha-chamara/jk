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
    public partial class xZones : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xZones()
        {
            InitializeComponent();
        }

        private void xZones_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
           // location
            this.locationBindingSource.DataSource = (from l in context.Locations
                                                     select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
            
            // primary entity
            this.zoneBindingSource.DataSource = (from z in context.Zones
                                                     select z).ToList();

            //this.enable_control(false, eRecStatus.eInit);

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

       

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    zoneBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    zoneBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    zoneBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    zoneBindingSource.MoveLast();
        //}

        


      
       

       


        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            zoneBindingSource.CancelEdit();
            load_data();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.enable_control(true, eRecStatus.eEdit);

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

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                this.Validate();
                this.zoneBindingSource.EndEdit();

                // validating Location 

                if (string.IsNullOrEmpty(this.locationIDLookUpEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.locationIDLookUpEdit, "Invalid Location");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.locationIDLookUpEdit, "");
                }

                // validating zone name 
                if (string.IsNullOrEmpty(this.zoneNameTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.zoneNameTextEdit, "Invalid Name");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.zoneNameTextEdit, "");
                }

                Zone zoneObject = (Zone)this.zoneBindingSource.Current;
                if (zoneObject.ZoneID == 0)
                {
                    //check for dupplication 
                    var qrydupp = (from z in context.Zones
                                   where z.ZoneName == zoneObject.ZoneName && z.LocationID == zoneObject.LocationID
                                   select new { z.ZoneName, z.LocationID }).ToList();

                    if (qrydupp.Count > 0)
                    {
                        MessageBox.Show("Already Zone " + zoneObject.ZoneName + " in the Location", "Dupplication - Zone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // 
                    context.Zones.AddObject(zoneObject);
                }
                else
                {
                    context.Zones.ApplyCurrentValues(zoneObject);

                }




                int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Save Success - Zone");
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
            DialogResult dlg = MessageBox.Show("Do you want to delete the current record..?", "Delete Record - Zone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                zoneBindingSource.RemoveCurrent();
                int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;

            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);


                this.zoneBindingSource.AddNew();
                //this.enable_control(true, eRecStatus.eAddNew);
                this.locationIDLookUpEdit.Focus();

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
    }
}
