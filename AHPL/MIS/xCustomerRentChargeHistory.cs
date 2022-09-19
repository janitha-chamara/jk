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
    public partial class xCustomerRentChargeHistory : DevExpress.XtraEditors.XtraForm
    {
        List<ShopOccupancy> ShopOccupancyList = new List<ShopOccupancy>();

        public xCustomerRentChargeHistory()
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

                    // customer
                   


                    // Current Date/Time for the report
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
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

                //object comps = this.lookCompany.Properties.GetCheckedItems();
                //object locs = this.lookLocaiton.Properties.GetCheckedItems();
                int compid = int.Parse(this.lookCompany.EditValue.ToString());
                int locid = int.Parse(this.lookLocaiton.EditValue.ToString());
                int excustid = int.Parse(this.lookCustomer.EditValue.ToString());


                DateTime currentDate = DateTime.Now.Date;
                
                //// updating records if there any null or 0 in increased rent, increased SC, 
                //MMS.CustomClasses.cCommon_Functions.UpdateRentSchemeIncreasedRentandSC();

                ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisCustomerRentChargeHistory(compid, locid, excustid);
                shopOccupancyBindingSource.DataSource = ShopOccupancyList;
                gridView1.BestFitColumns();
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
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Generating Print"); }

                rptMain reportMain = new rptMain();
                DataTier.Reports.MIS.rptCustomerRentChargeHistory custRentHistory = new DataTier.Reports.MIS.rptCustomerRentChargeHistory();
                reportMain.crystalReportViewer1.ReportSource = custRentHistory;

                custRentHistory.Database.Tables["DataTier_ReportClasses_ShopOccupancy"].SetDataSource(ShopOccupancyList);

                reportMain.Show(this);
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }


            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xCustomerRentChargeHistory_Load(object sender, EventArgs e)
        {
            load_data();
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

        private void chkCompany_EditValueChanged(object sender, EventArgs e)
        {
            load_Customer();

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

        private void load_Customer()
        {
            try
            {
                if (string.IsNullOrEmpty(this.lookCompany.Text)) { return; }
                if (string.IsNullOrEmpty(this.lookLocaiton.Text)) { return; }

                int compid = int.Parse(this.lookCompany.EditValue.ToString());
                int locid = int.Parse(this.lookLocaiton.EditValue.ToString());

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryCust = (from ec in context.Extended_Customers
                                   join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                   where ec.CompanyID == compid && ec.LocationID == locid
                                   select new { ec.ExtendedCustomerID, gc.CustomerName }).ToList();

                    this.lookCustomer.Properties.DataSource = qryCust;
                    this.lookCustomer.Properties.DisplayMember = "CustomerName";
                    this.lookCustomer.Properties.ValueMember = "ExtendedCustomerID";



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lookLocaiton_EditValueChanged(object sender, EventArgs e)
        {
            load_Customer();
        }
    }
}