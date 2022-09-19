using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataTier;
using System.Linq;

namespace MMS.MIS
{
    public partial class xUtilityConsumptionCustomerWise : DevExpress.XtraEditors.XtraForm
    {
        private List<DataTier.ReportClasses.ShopOccupancy> ShopOccupancyList;
        public xUtilityConsumptionCustomerWise()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xUtilityConsumptionCustomerWise_Load(object sender, EventArgs e)
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

        private void lookLocaiton_EditValueChanged(object sender, EventArgs e)
        {
            load_Customer();

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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }
                int compid = int.Parse(this.lookCompany.EditValue.ToString());
                int locid = int.Parse(this.lookLocaiton.EditValue.ToString());
                int utilityID = int.Parse(this.lookUtility.EditValue.ToString());
                int extendedCustomerID = int.Parse(this.lookCustomer.EditValue.ToString());

                DateTime currentDate = this.dateEditFrom.DateTime.Date;


                ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisUtilityConsumptionCustomerWise(compid, locid, utilityID, dateEditFrom.DateTime, dateEditTo.DateTime, extendedCustomerID);
                shopOccupancyBindingSource.DataSource = ShopOccupancyList;

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
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

                rptMain reportMain = new rptMain();
                DataTier.Reports.MIS.rptUtilityConsumptionCustomerWise utilityConsumptionCW = new DataTier.Reports.MIS.rptUtilityConsumptionCustomerWise();
                reportMain.crystalReportViewer1.ReportSource = utilityConsumptionCW;

                utilityConsumptionCW.Database.Tables["DataTier_ReportClasses_ShopOccupancy"].SetDataSource(ShopOccupancyList);

                string pUtilityFromTo = this.lookUtility.Text.ToString() + " Consumption From " + this.dateEditFrom.Text.ToString() + " To " + this.dateEditTo.Text.ToString();
                utilityConsumptionCW.SetParameterValue("pUtility", pUtilityFromTo);

                reportMain.Show(this);


                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
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

        private void lookCustomer_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dateEditFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
            { return; }

            dateEditTo.DateTime = dateEditFrom.DateTime.AddMonths(1).AddDays(-1).Date;
        }

    }
}