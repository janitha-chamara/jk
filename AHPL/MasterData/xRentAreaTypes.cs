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
    public partial class xRentAreaTypes : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xRentAreaTypes()
        {
            InitializeComponent();
        }

        
        private void xRentAreaTypes_Load(object sender, EventArgs e)
        {

            load_data();

        }

        private void load_data()
        {
            // primary entity
            var qryRentA = (from r in context.Rent_Area_Types
                            select r).ToList();
            
            //binding to the data binding source
            this.rent_Area_TypesBindingSource.DataSource = qryRentA;

            //this.enable_control(false, eRecStatus.eInit);

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        //private void cmdEdit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //   // this.enable_control(true, eRecStatus.eEdit);

        //}

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.rent_Area_TypesBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.rent_Area_TypesBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.rent_Area_TypesBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.rent_Area_TypesBindingSource.MoveLast();
        //}

        //private void cmdUndo_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
           
        //}

        //private void cmdDelete_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
            
        //}

        //private void cmdRefresh_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
            

        //}

        //private void cmdClose_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.Close();
        //}

        //private void cmdNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
           

        //}

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.rent_Area_TypesBindingSource.EndEdit();

                ////validating fields
                //validating rent are type name 

                if (string.IsNullOrEmpty(this.rentAreaTypeNameTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.rentAreaTypeNameTextEdit, "Invalid Rent Area Type Name");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.rentAreaTypeNameTextEdit, "");
                }


                ////


                Rent_Area_Types oRentAreaType = (Rent_Area_Types)this.rent_Area_TypesBindingSource.Current;

                if (oRentAreaType != null)
                {

                    if (oRentAreaType.RentAreaTypeID == 0) // add new status is 0
                    {
                        // check for duplication 

                        var qryDupp = (from r in context.Rent_Area_Types
                                       where r.RentAreaTypeName == oRentAreaType.RentAreaTypeName
                                       select new { r.RentAreaTypeName }).ToList();
                        if (qryDupp.Count > 0)
                        {
                            MessageBox.Show("Rent Area Type Name is already exist", "Dupplication - Rent Area Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //--
                        oRentAreaType.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                        oRentAreaType.CreatedDate = DateTime.Now;

                        context.Rent_Area_Types.AddObject(oRentAreaType); // adding objects to the context

                    }
                    else
                    {
                        oRentAreaType.LastUpdated = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                        oRentAreaType.LastUpdateDate = DateTime.Now;
                        context.Rent_Area_Types.ApplyCurrentValues(oRentAreaType); // editing values 

                    }

                    // commiting changes to the database 

                    int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                    if (succ > 0)
                    {
                        MessageBox.Show("Record saved Successfully..", "Save Success - Rent Area Types", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_data();
                    }
                    else
                    {
                        //this.enable_control(false, eRecStatus.eSave);
                    }



                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.rent_Area_TypesBindingSource.CancelEdit();
            this.dxErrorProvider1.ClearErrors();
            load_data();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);
                this.Validate();
                this.rent_Area_TypesBindingSource.EndEdit();
                Rent_Area_Types oRentA = (Rent_Area_Types)this.rent_Area_TypesBindingSource.Current;

                if (oRentA == null)
                { return; }

                string RentTypeName = oRentA.RentAreaTypeName;

                DialogResult dlg = MessageBox.Show("Do you want to Delete current record " + oRentA.RentAreaTypeName + " ?", "Delete - Rent Area Type?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    context.Rent_Area_Types.DeleteObject(oRentA);
                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Rent Tyep Area Type '" + RentTypeName + "' deleted successfully...", "Deleted - Rent Area Type", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
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
            load_data();
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
                //this.enable_control(true, eRecStatus.eAddNew);
                this.rent_Area_TypesBindingSource.AddNew();
                rentAreaTypeNameTextEdit.Focus();

                btnNew.Enabled = false;
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
