using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using DataTier;

namespace MMS.MIS
{
    public partial class xShopUnOccupancy : DevExpress.XtraEditors.XtraForm
    {
        private List<DataTier.ReportClasses.ShopOccupancy> ShopOccupancyList;
        public xShopUnOccupancy()
        {
            InitializeComponent();
        }

        private void xShopUnOccupancy_Load(object sender, EventArgs e)
        {
            Load_data();

        }

        private void Load_data()
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
                    this.lookLocation.Properties.DataSource = qryLocs;
                    this.lookLocation.Properties.DisplayMember = "LocationCode";
                    this.lookLocation.Properties.ValueMember = "LocationID";

                    // current date
                    this.dateEditDate.DateTime = DateTime.Now.Date;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }
                int comps = int.Parse(this.lookCompany.EditValue.ToString());
                int locs = int.Parse(this.lookLocation.EditValue.ToString());

                  ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisShopUnOccupancy(comps, locs, dateEditDate.DateTime.Date,splashScreenManager1);
                  shopOccupancyBindingSource.DataSource = ShopOccupancyList;

                  if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                
                //this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showProgress(DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1)
        {
            throw new NotImplementedException();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print");
                }
              

                rptMain reportMain = new rptMain();


                DataTier.Reports.MIS.rptShopUnoccupancy shopOccReport = new DataTier.Reports.MIS.rptShopUnoccupancy();
                    reportMain.crystalReportViewer1.ReportSource = shopOccReport;
                    shopOccReport.Database.Tables["DataTier_ReportClasses_ShopOccupancy"].SetDataSource(ShopOccupancyList);
                    shopOccReport.SetParameterValue("pDate", this.dateEditDate.Text.ToString());        
        
                reportMain.Show(this);
                if (splashScreenManager1.IsSplashFormVisible == true)
                {
                    splashScreenManager1.CloseWaitForm();
                }

            }

            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                {
                    splashScreenManager1.CloseWaitForm();
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                    this.lookLocation.Properties.DataSource = qryLocs;
                    this.lookLocation.Properties.DisplayMember = "LocationCode";
                    this.lookLocation.Properties.ValueMember = "LocationID";
                }
            }
        }
    }
}