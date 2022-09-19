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
    public partial class xShopOccupied : DevExpress.XtraEditors.XtraForm
    {
        List<ShopOccupancy> ShopOccupancyList = new List<ShopOccupancy>();
        public xShopOccupied()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }
                int comps = int.Parse(this.lookCompany.EditValue.ToString());
                int locs = int.Parse(this.lookLocaiton.EditValue.ToString());


                DateTime currentDate = this.dateEditDate.DateTime.Date;

                if (this.IsShopOccupiedReport == true)
                {
                    ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisShopOccupancy(comps, locs, currentDate, splashScreenManager1);

                    ShopOccupancyList = ShopOccupancyList.OrderBy(x => x.ShopNo).ToList();
                    shopOccupancyBindingSource.DataSource = ShopOccupancyList;


                    // Summary 
                    using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {

                        decimal occpiedArea = ShopOccupancyList.Sum(x => x.OccupiedAreaSqFt);

                        DateTime fromdate = currentDate.AddMonths(-1).AddDays(1).Date;

                        decimal loctotal = 0;

                        var qryLocTotal1 = (from l in context.Locations
                                            join ld in context.Location_Details on l.LocationID equals ld.LocationID
                                            where l.LocationID == locs && ld.ActiveFrom.Month == currentDate.Month && ld.ActiveFrom.Year == currentDate.Year
                                            select new { ld.SqFeet, ld.IsActive }).AsEnumerable().LastOrDefault();
                        if (qryLocTotal1 != null)
                        {

                            loctotal = qryLocTotal1.SqFeet;
                        }


                        decimal occupiedPrcntg = 0;
                        if (occpiedArea > 0 && loctotal > 0)
                        {
                            occupiedPrcntg = (occpiedArea / loctotal) * 100;
                            occupiedPrcntg = Math.Round(occupiedPrcntg, 2);
                        }


                        this.txtOccupiedAreaPrcntg.EditValue = occupiedPrcntg;
                        this.txtOccupiedAreaSqFt.EditValue = occpiedArea;
                        this.txtSqFtTotal.EditValue = loctotal;
                        this.txtSqFtprcntgTotal.EditValue = 100;


                    }


                }
                if (this.IsShopUnoccupiedReport == true)
                {
                    ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisShopUnOccupancy(comps, locs, currentDate);
                    shopOccupancyBindingSource.DataSource = ShopOccupancyList;

                }
                if (this.IsShopOccAndUnOccReport == true)
                {
                    ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisShopOccupiedAndUnOccupied(comps, locs, currentDate);
                    shopOccupancyBindingSource.DataSource = ShopOccupancyList;
                }
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                //this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void xMisReports_Load(object sender, EventArgs e)
        {
            if (this.IsShopUnoccupiedReport == true)
            {
                this.Text = "Unoccupied Shops - MIS Report";
                this.gridView1.ViewCaption = "List of Unoccupied Shops";

            }
            if (this.IsShopOccAndUnOccReport == true)
            {
                this.Text = "Status of Occupancy and Unoccupancy";
                this.gridView1.ViewCaption = "List of Unoccupied/Unoccupied Shops";
            }

            format_grid();

            load_data();

        }

        private void format_grid()
        {

            if (this.IsShopUnoccupiedReport == true)
            {
                this.gridView1.Columns["UnoccupiedFrom"].Visible = true;
                this.gridView1.Columns["LossOfRentperSqFt"].Visible = true;
                this.gridView1.Columns["LossOfSCperSqFt"].Visible = true;
                this.gridView1.Columns["SAPCustomerCode"].Visible = false;
                this.gridView1.Columns["CustomerName"].Visible = false;
                this.gridView1.Columns["RentPerSqFt"].Visible = false;
                this.gridView1.Columns["ScPerSqFt"].Visible = false;

            }


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


                    this.dateEditDate.DateTime = DateTime.Now.Date;


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
                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print");
                }

                rptMain reportMain = new rptMain();

                if (this.IsShopOccupiedReport == true)
                {
                    DataTier.Reports.MIS.rptShopOccupancy shopOccReport = new DataTier.Reports.MIS.rptShopOccupancy();
                    reportMain.crystalReportViewer1.ReportSource = shopOccReport;
                    shopOccReport.Database.Tables["DataTier_ReportClasses_ShopOccupancy"].SetDataSource(ShopOccupancyList);
                    shopOccReport.SetParameterValue("pDate", this.dateEditDate.Text.ToString());

                }




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

        public bool IsShopOccupiedReport { get; set; }

        public bool IsShopUnoccupiedReport { get; set; }

        public bool IsShopOccAndUnOccReport { get; set; }

        private void txtTotalSqFtOccupied_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (string.IsNullOrEmpty(filename)) { return; }
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