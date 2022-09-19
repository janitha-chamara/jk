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
    public partial class xUtilityConsumption : DevExpress.XtraEditors.XtraForm
    {
private  List<ShopOccupancy> ShopOccupancyList;
        public xUtilityConsumption()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

                    //Utilities 
                    var qryUtility = (from u in context.Utilities
                                      select new { u.UtilityID, u.UtilityName }).ToList();
                    this.lookUtility.Properties.DataSource = qryUtility;
                    this.lookUtility.Properties.DisplayMember = "UtilityName";
                    this.lookUtility.Properties.ValueMember = "UtilityID";


                    this.dateEditFrom.DateTime = DateTime.Now.Date;
                    this.dateEditTo.DateTime = DateTime.Now.Date;


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
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }
                int compid = int.Parse(this.lookCompany.EditValue.ToString());
                int locid = int.Parse(this.lookLocaiton.EditValue.ToString());
                int utilityID = int.Parse(this.lookUtility.EditValue.ToString());

                DateTime currentDate = this.dateEditFrom.DateTime.Date;


                ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisUtilityConsumption(compid, locid, utilityID, dateEditFrom.DateTime,dateEditTo.DateTime);
                shopOccupancyBindingSource.DataSource = ShopOccupancyList;

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

             
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xUtilityConsumption_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

                rptMain reportMain = new rptMain();
                DataTier.Reports.MIS.rptUtilityConsumption utilityConsumption = new DataTier.Reports.MIS.rptUtilityConsumption();
                reportMain.crystalReportViewer1.ReportSource = utilityConsumption;

                utilityConsumption.Database.Tables["DataTier_ReportClasses_ShopOccupancy"].SetDataSource(ShopOccupancyList);

                string pUtilityFromTo = this.lookUtility.Text.ToString() + " Charges From " + this.dateEditFrom.Text.ToString() + " To " + this.dateEditTo.Text.ToString();
                utilityConsumption.SetParameterValue("pUtility", pUtilityFromTo);

                reportMain.Show(this);


                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
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

        private void lookUtility_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dateEditFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
            { return; }

            dateEditTo.DateTime = dateEditFrom.DateTime.AddMonths(1).AddDays(-1).Date;
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