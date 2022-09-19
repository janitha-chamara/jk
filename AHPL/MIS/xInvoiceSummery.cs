using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTier;
using DataTier.ReportClasses;
using MMS.CustomClasses;

namespace MMS.MIS
{
    public partial class xInvoiceSummery : Form
    {
        private List<InvoiceSummeryDetail> listSummery;

        public xInvoiceSummery()
        {
            InitializeComponent();
        }

        private void xInvoiceSummery_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    //// company
                    var qryComps = (from c in context.Companies
                                    select new { c.CompanyID, c.CompanyCode }).ToList();
                    this.chkCompany.Properties.DataSource = qryComps;
                    this.chkCompany.Properties.DisplayMember = "CompanyCode";
                    this.chkCompany.Properties.ValueMember = "CompanyID";

                    //// location 
                    var qryLocs = (from l in context.Locations
                                   select new { l.LocationID, l.LocationCode }).ToList();
                    this.chkLocation.Properties.DataSource = qryLocs;
                    this.chkLocation.Properties.DisplayMember = "LocationCode";
                    this.chkLocation.Properties.ValueMember = "LocationID";

                    //// Utilities 

                    List<AllInvoiceTypes> allTypes = new List<AllInvoiceTypes>();

                    List<Utility> utilityList = context.Utilities.ToList();
                    allTypes.AddRange(utilityList.Select(s => new AllInvoiceTypes
                    {
                        AllInvoiceTypeID = "UT_" + s.UtilityID,
                        MainTableMappingID = s.UtilityID,
                        DisplayValue = s.UtilityName
                    }).ToList());

                    ////Add Rent
                    AllInvoiceTypes rentType = new AllInvoiceTypes();
                    rentType.AllInvoiceTypeID = "RN_" + 1;
                    rentType.DisplayValue = "Rent";
                    rentType.MainTableMappingID = 1;

                    allTypes.Add(rentType);
                    ////Add Rent...End

                    ////Add other
                    List<OtherServiceCategory> otherList = context.OtherServiceCategories.ToList();
                    allTypes.AddRange(otherList.Select(s => new AllInvoiceTypes
                    {
                        AllInvoiceTypeID = "OS_" + s.OtherServiceID,
                        MainTableMappingID = s.OtherServiceID,
                        DisplayValue = s.OtherServiceName
                    }).ToList());

                    ////Add other..End

                    this.chkInvoiceType.Properties.DataSource = allTypes;
                    this.chkInvoiceType.Properties.DisplayMember = "DisplayValue";
                    this.chkInvoiceType.Properties.ValueMember = "AllInvoiceTypeID";

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
            ////TO Do:L add proper filter concidering sub invoice type

            if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

            GetDataSource();

            invoiceSummerybindingSource.DataSource = listSummery;

            if (splashScreenManager1.IsSplashFormVisible == true) 
            { 
                splashScreenManager1.CloseWaitForm(); 
            }
        }

        private void GetDataSource()
        {
            object comps = this.chkCompany.Properties.GetCheckedItems();
            object locs = this.chkLocation.Properties.GetCheckedItems();
            object utilityId = this.chkInvoiceType.Properties.GetCheckedItems();

            DateTime fromDate = this.dateEditFrom.DateTime.Date;
            DateTime toDate = this.dateEditTo.DateTime.Date;

            if (comps == string.Empty || locs == string.Empty || utilityId == string.Empty || string.IsNullOrEmpty(dateEditFrom.Text) || string.IsNullOrEmpty(dateEditTo.Text))
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                {
                    splashScreenManager1.CloseWaitForm();
                }
            }
            if (fromDate > toDate)
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                {
                    splashScreenManager1.CloseWaitForm();
                }
            }
            else
            {
                listSummery = MMS.CustomClasses.cCommon_Functions.MisInvoiceSummery(comps, locs, utilityId, fromDate, toDate);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

                //object comps = this.chkCompany.Properties.GetCheckedItems();
                //object locs = this.chkLocaiton.Properties.GetCheckedItems();
                string pUtilityFromTo = "Credit Notes Summery - From " + this.dateEditFrom.Text.ToString() + " To " + this.dateEditTo.Text.ToString();

                rptMain reportMain = new rptMain();
                DataTier.Reports.MIS.rptInvoiceDetails invoiceSummeryRpt = new DataTier.Reports.MIS.rptInvoiceDetails();

                reportMain.crystalReportViewer1.ReportSource = invoiceSummeryRpt;

                GetDataSource();

                invoiceSummeryRpt.Database.Tables["DataTier_ReportClasses_InvoiceSummeryDetail"].SetDataSource(listSummery);
                invoiceSummeryRpt.SetParameterValue("repTitle", pUtilityFromTo);
                reportMain.Show(this);

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            }
        }
    }
}
