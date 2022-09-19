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
    public partial class xFloor_Levels : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();


        public xFloor_Levels()
        {
            InitializeComponent();
        }





        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    Floor_LevelsBindingSource.MoveFirst();

        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    Floor_LevelsBindingSource.MovePrevious();

        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    Floor_LevelsBindingSource.MoveNext();

        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    Floor_LevelsBindingSource.MoveLast();

        //}



        private void refresh_data()
        {
            load_data();


        }



        private void save_data()
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                this.Floor_LevelsBindingSource.EndEdit();
                Floor_Levels _flowlevel = (Floor_Levels)this.Floor_LevelsBindingSource.Current;

                if (_flowlevel.LevelID == 0)
                {
                    context.Floor_Levels.AddObject(_flowlevel);

                }
                else
                {
                    var entkey = context.GetObjectByKey(_flowlevel.EntityKey);
                    context.Floor_Levels.ApplyCurrentValues(_flowlevel);

                }

                int succ = context.SaveChanges(SaveOptions.DetectChangesBeforeSave);

                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Flow Level - Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }

        }

        private bool validate_data()
        {
            this.Validate();
            this.Floor_LevelsBindingSource.EndEdit();

            bool validated = false;
            string loccode = this.locationIDLookUpEdit.EditValue.ToString().Trim();
            int intloccode = 0;
            bool res = int.TryParse(loccode, out intloccode);
            if (res == false) intloccode = 0;



            string levelcode = this.levelCodeTextEdit.Text.ToString().Trim();

            if (intloccode == 0)
            {
                dxErrorProvider1.SetError(this.locationIDLookUpEdit, "Invalid Location, Please Select the Location");
                validated = false;
                return validated;
            }
            else
            {
                dxErrorProvider1.SetError(this.locationIDLookUpEdit, "");
                validated = true;
            }

            if (string.IsNullOrEmpty(levelcode))
            {
                dxErrorProvider1.SetError(this.levelCodeTextEdit, "Please Enter Level Code");
                validated = false;
                return validated;
            }
            else
            {
                dxErrorProvider1.SetError(this.levelCodeTextEdit, "");
                validated = true;
            }

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                // checking existing code for duplicate datea //

                Floor_Levels flowlevel = (Floor_Levels)this.Floor_LevelsBindingSource.Current;
                if (flowlevel.LevelID == 0)
                {

                    var qry = (from f in context.Floor_Levels
                               where f.LevelCode == levelcode && f.LocationID == intloccode
                               select new { f.LocationID, f.LevelCode }).ToList();
                    if (qry.Count > 0)
                    {
                        dxErrorProvider1.SetError(this.levelCodeTextEdit, "Level Code is Exist with the Location Code");
                        validated = false;
                        return validated;
                    }
                    else
                    {
                        dxErrorProvider1.SetError(this.levelCodeTextEdit, "");
                        validated = true;
                    }

                }
                else
                {


                }

            }



            return validated;
        }


        private void xFloor_Levels_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {

            //primary entity 
            this.Floor_LevelsBindingSource.DataSource = (from f in context.Floor_Levels
                                                         select f).ToList();

            //location
            var qryloc = (from l in context.Locations
                          select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();

            this.locationBindingSource.DataSource = qryloc;


            ///this.enable_control(false, eRecStatus.eInit);

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;


        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                DialogResult dlg = MessageBox.Show("Do you want to delete the current record?", "Delete - Floor Level", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {

                    // check existing data 
                    Floor_Levels oFLevel = (Floor_Levels)this.Floor_LevelsBindingSource.Current;
                    var qryFL = (from f in context.Contracts
                                 where f.LevelID == oFLevel.LevelID
                                 select new { f.LevelID }).ToList();
                    if (qryFL.Count > 0)
                    {
                        MessageBox.Show("Floor Level already in the contracts, there for you cannot delete this floor level", "Cannot Delete - Floor Level", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //---


                    Floor_LevelsBindingSource.RemoveCurrent();

                    context.SaveChanges();

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

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.enable_control(true, eRecStatus.eEdit);
                this.levelCodeTextEdit.Properties.ReadOnly = true;
                this.locationIDLookUpEdit.Properties.ReadOnly = true;

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
                this.Floor_LevelsBindingSource.AddNew();
                //this.enable_control(true, eRecStatus.eAddNew);

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

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Floor_LevelsBindingSource.CancelEdit();
            refresh_data();
            //this.enable_control(false, eRecStatus.eInit);
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
                this.Floor_LevelsBindingSource.EndEdit();

                if (string.IsNullOrEmpty(this.levelCodeTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.levelCodeTextEdit, "Invalid Level Code");
                    return;
                }
                else { dxErrorProvider1.SetError(this.locationIDLookUpEdit, ""); }

                if (string.IsNullOrEmpty(this.locationIDLookUpEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.locationIDLookUpEdit, "Invalid Locaiton");
                    return;
                }
                else { dxErrorProvider1.SetError(this.locationIDLookUpEdit, ""); }

                string levelcode = this.levelCodeTextEdit.Text.ToString().Trim();
                int locid = int.Parse(this.locationIDLookUpEdit.EditValue.ToString());



                Floor_Levels oFloorLevel = (Floor_Levels)this.Floor_LevelsBindingSource.Current;
                if (oFloorLevel.LevelID == 0)
                {
                    // check for duplication
                    var qryDupp = (from f in context.Floor_Levels
                                   where f.LevelCode == levelcode && f.LocationID == locid
                                   select f).ToList();
                    if (qryDupp.Count > 0)
                    {
                        MessageBox.Show("Record Already Exist with Level Code and Location", "Duplication", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    oFloorLevel.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oFloorLevel.CreatedDate = DateTime.Now;
                    context.Floor_Levels.AddObject(oFloorLevel);

                }
                else
                {
                    oFloorLevel.LastUpdated = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oFloorLevel.LastUpdateDate = DateTime.Now;
                    context.Floor_Levels.ApplyCurrentValues(oFloorLevel);

                }


                int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                if (succ > 0)
                {
                    MessageBox.Show("Record saved Successfully", "Save success - Floor Level", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_data();
                }
                else
                {
                    //this.enable_control(false, eRecStatus.eSave);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
