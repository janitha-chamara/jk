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
    public partial class xOtherSettings : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xOtherSettings()
        {
            InitializeComponent();
        }

        

        //private void cmdNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    deliveryOptionBindingSource.AddNew();
        //    //this.enable_control(true, eRecStatus.eAddNew);
        //    //this.deliveryOptionNameTextEdit.Focus();
        //}

        private void xDeliveryOptions_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {
            this.deliveryOptionBindingSource.DataSource = context.DeliveryOptions;
        


            //this.enable_control(false, eRecStatus.eInit);
        }

        
        

        //private void cmdEdit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    //enable_control(true, eRecStatus.eEdit);

        //}

        //private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.deliveryOptionBindingSource.MoveFirst();
        //}

        //private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.deliveryOptionBindingSource.MovePrevious();
        //}

        //private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.deliveryOptionBindingSource.MoveNext();
        //}

        //private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.deliveryOptionBindingSource.MoveLast();
        //}

        //private void cmdDelete_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{

        //}

        //private void cmdSave_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
            
        //    //this.enable_control(false, eRecStatus.eSave);

        //}

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                deliveryOptionBindingSource.AddNew();
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

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.deliveryOptionBindingSource.CancelEdit();
            load_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Validate();
            this.deliveryOptionBindingSource.EndEdit();


            int succ = context.SaveChanges(SaveOptions.None);
            if (succ > 0)
            {
                MessageBox.Show("Record Saved Successfully", "Save Success - Delivery Options", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            load_data();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        
    }
}
