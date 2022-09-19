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
    public partial class xOtherServiceIncome : DevExpress.XtraEditors.XtraForm
    {
        public xOtherServiceIncome()
        {
            InitializeComponent();
        }
        List<DataTier.ReportClasses.ShopOccupancy> promotionalIncomeList = new List<DataTier.ReportClasses.ShopOccupancy>();

        private void lookLocation_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

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
                    //
                  
                    this.dateEditFrom.DateTime = this.dateEditTo.DateTime = DateTime.Now.Date;


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xOtherServiceIncome_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(this.lookLocation.Text.ToString())) { return; }
                if (string.IsNullOrEmpty(this.lookCompany.Text.ToString())) { return; }

                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

                int compid = int.Parse(this.lookCompany.EditValue.ToString());
                int locid = int.Parse(this.lookLocation.EditValue.ToString());
         

                DateTime fromDate = this.dateEditFrom.DateTime.Date;
                DateTime toDate = this.dateEditTo.DateTime.Date;


                promotionalIncomeList = MMS.CustomClasses.cCommon_Functions.MisPromotionalIncome(compid, locid, fromDate, toDate);
                shopOccupancyBindingSource.DataSource = promotionalIncomeList;
                this.gridView1.BestFitColumns();

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
                DataTier.Reports.MIS.rptPromotionalIncome promoIncome = new DataTier.Reports.MIS.rptPromotionalIncome();
                reportMain.crystalReportViewer1.ReportSource = promoIncome;
                //string pFromTo = "From " + this.dateEditFrom.Text.ToString() + " To " + this.dateEditTo.Text.ToString();
                promoIncome.Database.Tables["DataTier_ReportClasses_ShopOccupancy"].SetDataSource(promotionalIncomeList);
                //promoIncome.SetParameterValue("pPeriod", pFromTo);
                promoIncome.SetParameterValue("pPeriod", "From : " + this.dateEditFrom.Text.ToString() + " To " + this.dateEditTo.Text.ToString());
                //promoIncome.SetParameterValue("pYear", this.spinEditYear.Text.ToString());
              
                reportMain.Show(this);
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }


            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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