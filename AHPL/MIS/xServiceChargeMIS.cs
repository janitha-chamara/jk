using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using DataTier;
using DataTier.ReportClasses;
using DevExpress.XtraEditors;

namespace MMS.MIS
{
    public partial class xServiceChargeMIS : DevExpress.XtraEditors.XtraForm
    {
        List<ShopOccupancy> ShopOccupancyList = new List<ShopOccupancy>();

        public xServiceChargeMIS()
        {
            InitializeComponent();
        }

        private void xServiceChargeMIS_Load(object sender, EventArgs e)
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
                    this.lookLocation.Properties.DataSource = qryLocs;
                    this.lookLocation.Properties.DisplayMember = "LocationCode";
                    this.lookLocation.Properties.ValueMember = "LocationID";

                    ////// Level 
                    ////var qryLevels = (from l in context.Floor_Levels
                    ////                 select new { l.LevelID, l.LevelName }).ToList();
                    ////this.chkLevel.Properties.DataSource = qryLevels;
                    ////this.chkLevel.Properties.DisplayMember = "LevelName";
                    ////this.chkLevel.Properties.ValueMember = "LevelID";

                    //this.dateEditDate.DateTime = DateTime.Now.Date;


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
                if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()) || string.IsNullOrEmpty(this.lookLocation.Text.ToString()) || string.IsNullOrEmpty(this.dateEditDate.Text.ToString()))
                { return; }

                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }
                int compid = int.Parse(this.lookCompany.EditValue.ToString());
                int locid =int.Parse(this.lookLocation.EditValue.ToString());
                //DateTime fromDate = dateEditFrom.DateTime.Date;
                //DateTime toDate = dateEditTo.DateTime.Date;
                DateTime dateAsAt = dateEditDate.DateTime.Date;
                

                ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisServiceCharge(compid, locid, dateAsAt);
                // service charge > 0 
                ShopOccupancyList = (from s in ShopOccupancyList
                                     where s.ScPerSqFt > 0
                                     select s).ToList();
                shopOccupancyBindingSource.DataSource = ShopOccupancyList;
                //-- 

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
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print");
                }

                rptMain reportMain = new rptMain();
                DataTier.Reports.MIS.rptServiceCharges shopOccReport = new DataTier.Reports.MIS.rptServiceCharges();
                reportMain.crystalReportViewer1.ReportSource = shopOccReport;

                shopOccReport.Database.Tables["DataTier_ReportClasses_ShopOccupancy"].SetDataSource(ShopOccupancyList);

                //setting parameter fields
                string pFromTo = "AS AT : " + this.dateEditDate.Text.ToString();
                shopOccReport.SetParameterValue("pFromTo", pFromTo);
                // -- 

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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