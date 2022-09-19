using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataTier;
using DataTier.ReportClasses;
using System.Linq;
using System.Linq.Expressions;

namespace MMS.MIS
{
    public partial class xMisUtilityReadings : DevExpress.XtraEditors.XtraForm
    {
        private List<ShopOccupancy> ShopOccupancyList;
        public xMisUtilityReadings()
        {
            InitializeComponent();
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
                object comps = this.chkCompany.Properties.GetCheckedItems();
                object locs = this.chkLocaiton.Properties.GetCheckedItems();
                int utilityId = int.Parse(this.lookUtility.EditValue.ToString());

                DateTime currentDate = this.dateEditFrom.DateTime.Date;


                ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisUtilityReading(comps, locs, utilityId, currentDate);
                shopOccupancyBindingSource.DataSource = ShopOccupancyList;

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }


            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xMisUtilityReadings_Load(object sender, EventArgs e)
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
                    this.chkCompany.Properties.DataSource = qryComps;
                    this.chkCompany.Properties.DisplayMember = "CompanyCode";
                    this.chkCompany.Properties.ValueMember = "CompanyID";

                    // location 
                    var qryLocs = (from l in context.Locations
                                   select new { l.LocationID, l.LocationCode }).ToList();
                    this.chkLocaiton.Properties.DataSource = qryLocs;
                    this.chkLocaiton.Properties.DisplayMember = "LocationCode";
                    this.chkLocaiton.Properties.ValueMember = "LocationID";

                    //Utilities 
                    var qryUtility = (from u in context.Utilities
                                      select new { u.UtilityID, u.UtilityName }).ToList();
                    this.lookUtility.Properties.DataSource = qryUtility;
                    this.lookUtility.Properties.DisplayMember = "UtilityName";
                    this.lookUtility.Properties.ValueMember = "UtilityID";


                    this.dateEditFrom.DateTime = DateTime.Now.Date;


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

                //object comps = this.chkCompany.Properties.GetCheckedItems();
                //object locs = this.chkLocaiton.Properties.GetCheckedItems();
                string pUtilityFromTo = this.lookUtility.Text.ToString() + " Charges - From " + this.dateEditFrom.Text.ToString() + " To " + this.dateEditTo.Text.ToString();

                rptMain reportMain = new rptMain();
                DataTier.Reports.MIS.rptShopUtilityReadings shopUtilityReadingRpt = new DataTier.Reports.MIS.rptShopUtilityReadings();


                reportMain.crystalReportViewer1.ReportSource = shopUtilityReadingRpt;

                shopUtilityReadingRpt.Database.Tables["DataTier_ReportClasses_ShopOccupancy"].SetDataSource(ShopOccupancyList);
                shopUtilityReadingRpt.SetParameterValue("pUtility", pUtilityFromTo);
                reportMain.Show(this);

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }


            }
            catch (Exception ex)
            {
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

        private void dateEditFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
            { return; }

            dateEditTo.DateTime = dateEditFrom.DateTime.Date.AddMonths(1).AddDays(-1).Date;
        }

        private void chkCompany_EditValueChanged(object sender, EventArgs e)
        {
            //// Location..roshan..06oct2014
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                string strcomids = chkCompany.EditValue.ToString();
                if (!string.IsNullOrEmpty(strcomids))
                {
                    string[] strArr = strcomids.Split(',');
                    if (strArr.Length > 0)
                    {
                        int[] comids = Array.ConvertAll(strArr, int.Parse); ;
                        if (comids.Length > 0)
                        {
                            var qryLocs = (from c in context.Companies
                                           join l in context.Locations on c.LocationID equals l.LocationID
                                           where comids.Contains(c.CompanyID)
                                           select new { l.LocationID, l.LocationCode }).ToList();

                            this.chkLocaiton.Properties.DataSource = qryLocs;
                            this.chkLocaiton.Properties.DisplayMember = "LocationCode";
                            this.chkLocaiton.Properties.ValueMember = "LocationID";
                        }
                    }
                }
            }
        }
    }
}