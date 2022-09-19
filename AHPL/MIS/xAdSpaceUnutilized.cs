using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Linq.Expressions;
using DataTier;

namespace MMS.MIS
{
    public partial class xAdSpaceUnutilized : DevExpress.XtraEditors.XtraForm
    {
        private List<DataTier.ReportClasses.ShopOccupancy> ShopOccupancyList;
        public xAdSpaceUnutilized()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xAdSpaceUnutilized_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    // company
                    var qryComps = (from c in context.Companies
                                    select new { c.CompanyID, c.CompanyCode }).ToList();
                    this.lookCompany.Properties.DataSource = qryComps;
                    this.lookCompany.Properties.DisplayMember = "CompanyCode";
                    this.lookCompany.Properties.ValueMember = "CompanyID";

                    // location 
                    var qryLocs = (from l in context.Locations
                                   select new { l.LocationID, l.LocationCode }).ToList();
                    this.lookLocaiton.Properties.DataSource = qryLocs;
                    this.lookLocaiton.Properties.DisplayMember = "LocationCode";
                    this.lookLocaiton.Properties.ValueMember = "LocationID";

                    //curr date
                    dateEditDate.DateTime = DateTime.Now.Date;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()) || string.IsNullOrEmpty(this.lookLocaiton.Text.ToString()) || string.IsNullOrEmpty(this.dateEditDate.Text.ToString()))
                { return; }

                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }
                int compid = int.Parse(this.lookCompany.EditValue.ToString());
                int locid = int.Parse(this.lookLocaiton.EditValue.ToString());
                DateTime currDate = dateEditDate.DateTime.Date;


                ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisAdSpaceUnutilizied(compid, locid,currDate);
                shopOccupancyBindingSource.DataSource = ShopOccupancyList;

                // Summary 

                //this.gridView1.BestFitColumns();
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
             
            }
            catch (Exception ex)
            {              
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
        {
            //// Location..roshan..06oct2014
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                int comid = 0;
                bool res = false;
                res = int.TryParse(lookCompany.EditValue.ToString(), out comid);
                if (res.Equals(true))
                {
                    var qryLocs = (from c in context.Companies
                                   join l in context.Locations on c.LocationID equals l.LocationID
                                   where c.CompanyID == comid
                                   select new { l.LocationID, l.LocationCode }).ToList();

                    this.lookLocaiton.Properties.DataSource = qryLocs;
                    this.lookLocaiton.Properties.DisplayMember = "LocationCode";
                    this.lookLocaiton.Properties.ValueMember = "LocationID";
                }
            }
        }
    }
}