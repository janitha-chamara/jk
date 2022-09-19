using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using DataTier;
using DataTier.Reports.MIS;
namespace MMS
{
    public partial class xContractExpiry_Ageing : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<Company> compList = new List<Company>();
        List<cContract_Ageing> AgeingList = new List<cContract_Ageing>();
        public xContractExpiry_Ageing()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xContractExpiry_Ageing_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        private void Load_data()
        {
            //dateEditDate.DateTime = DateTime.Now.Date;

            compList.Clear();

            //Company 
            var qryComp = (from c in context.Companies
                           select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
            foreach (var qry in qryComp)
            {
                Company oComp = new Company();
                oComp.CompanyID = qry.CompanyID;
                oComp.CompanyCode = qry.CompanyCode;
                oComp.CompanyName = qry.CompanyName;
                compList.Add(oComp);
            }

            this.chkCompany.Properties.DataSource = compList;
            this.chkCompany.Properties.DisplayMember = "CompanyCode";
            this.chkCompany.Properties.ValueMember = "CompanyID";

            this.companyBindingSource.DataSource = compList;
            chkCompany.CheckAll();
            //---

            // location
            var qryLoc = (from l in context.Locations
                          select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
            this.locationBindingSource.DataSource = qryLoc;

            // Customer
            var qryCust = (from c in context.Extended_Customers
                           join gc in context.Global_Customers on c.CustomerID equals gc.CustomerID
                           select new { CustomerID = c.ExtendedCustomerID, gc.CustomerName }).ToList();
            this.globalCustomersBindingSource.DataSource = qryCust;


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            
            processAge(DateTime.Now.Date);

            if (AgeingList.Count == 0)
            {
                MessageBox.Show("No Record(s) to Display", "No Records - Ageing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (splashScreenManager1.IsSplashFormVisible == false) splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormDescription("Generating Print Preview of Contrract Exipiry");

            var qryComp = (from c in context.Companies
                           select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
            var qryLoc = (from l in context.Locations
                          select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
            var qryGCust = (from c in context.Global_Customers
                            select new { c.CustomerID, c.CustomerName }).ToList();
            var qryECust = (from ec in context.Extended_Customers
                            select new { ec.ExtendedCustomerID, ec.CustomerID }).ToList();

            rptMain _main = new rptMain();
            rptContractAgeing rptAge = new rptContractAgeing();
            _main.crystalReportViewer1.ReportSource = rptAge;

            rptAge.Database.Tables["DataTier_cContract_Ageing"].SetDataSource(AgeingList);
            rptAge.Database.Tables["DataTier_Company"].SetDataSource(qryComp);
            rptAge.Database.Tables["DataTier_Location"].SetDataSource(qryLoc);
            rptAge.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);
            rptAge.Database.Tables["DataTier_Extended_Customers"].SetDataSource(qryECust);

            string currentDate = DateTime.Now.Date.ToString("dd/MM/yyyy");
            rptAge.SetParameterValue("pDate", currentDate);

            _main.Show();

            if (splashScreenManager1.IsSplashFormVisible == true) splashScreenManager1.CloseWaitForm();




        }

        private void processAge(DateTime dateTime)
        {
            ////To Do: Below 11September2016.. issue is fixed for only "Expired" records onlly(Requested that part only..by Niluka,Nimal)
            ////Do the same fix for other sections also(0 to 30, 31 to 60,...) 
            ////*****

            try
             {

                var selectedItem = this.chkCompany.Properties.GetCheckedItems();
                if (string.IsNullOrEmpty(selectedItem.ToString()) || string.IsNullOrEmpty(this.dateEditDate.Text.ToString()))
                {
                    return;
                }

                AgeingList.Clear();
                string selected = chkCompany.Properties.GetCheckedItems().ToString();

                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }
                List<int> ints = selected.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));
                

                var qrySelectedComp = (from c in context.ContractClosures
                                       join cr in context.Contract_RentSchemes on c.ContractClosureID equals cr.ContractClosureID
                                       where ints.Contains(c.CompanyID) && c.IsTerminated == false && c.IsPromotion == false
                                       orderby cr.ToDate ascending
                                       select new { c.ShopID, c.ShopNo, ActiveFrom = cr.FromDate, ActiveTo = cr.ToDate, c.CompanyID, c.ExtendedCustomerID, c.LocationID, c.LevelID, c.ShopName,cr.Contract_RentSchemeID }).ToList();

                var newqrySelectedComp = qrySelectedComp;

                List<int> shopIDDuplicateList = qrySelectedComp.Select(s => s.ShopID).ToList();
                shopIDDuplicateList = shopIDDuplicateList.GroupBy(g => g).Where(x => x.Count() > 1).Select(s => s.Key).ToList();

                ////11September2016.. roshan .. remove duplicate records from the report ...Start
                ////NOTE:
                //// IF CHANGE BELOW CODE, PLEASE CHECK , rec.RemoveAt(allExpDupRowcount - 1);, PROPERLLY

                foreach (int sid in shopIDDuplicateList)
                {
                    int allDupRowcount = newqrySelectedComp.Where(s => s.ShopID == sid).Select(s => s.Contract_RentSchemeID).Count();

                    List<int> rec = newqrySelectedComp.Where(s => s.ShopID == sid && s.ActiveTo <= dateTime).Select(s => s.Contract_RentSchemeID).ToList();
                    int allExpDupRowcount = rec.Count;

                    if (allDupRowcount != allExpDupRowcount)
                    {
                        qrySelectedComp.RemoveAll(r => rec.Contains(r.Contract_RentSchemeID));
                    }
                    else 
                    {
                        ////11September2016.. roshan .. remove duplicate records from the report ...Start
                        ////If customer has 3 year's continoues contract and once contract is expired 
                        ////Report is displaying 3 records(duplicates, one should be displayed)

                        ////rec.RemoveRange(0, (allExpDupRowcount - 1));

                        ////End..

                        rec.RemoveAt(allExpDupRowcount - 1);
                        qrySelectedComp.RemoveAll(r => rec.Contains(r.Contract_RentSchemeID));
                    }
                }

                foreach (var qry in qrySelectedComp)
                {

                    cContract_Ageing oAge = new cContract_Ageing();
                    int laps = qry.ActiveTo.Subtract(dateTime).Days;
                    oAge.LapsDays = laps;
                    if (laps < 0)
                    {
                        oAge.AgeGroup = 1;
                        oAge.AgeName = "Exipired";
                    }
                    if (laps >= 0 && laps <= 30)
                    {
                        oAge.AgeGroup = 2;
                        oAge.AgeName = "0 to 30 days to be expired";
                    }
                    if (laps > 30 && laps <= 60)
                    {
                        oAge.AgeGroup = 3;
                        oAge.AgeName = "31 to 60 days to be expired";
                    }
                    if (laps > 60 && laps <= 90)
                    {
                        oAge.AgeGroup = 4;
                        oAge.AgeName = "61 to 90 days to be expired";
                    }

                    if (laps > 90)
                    {
                        oAge.AgeGroup = 5;
                        oAge.AgeName = "Over 90 days to be expired";
                    }

                    oAge.CommencedDate = qry.ActiveFrom;
                    oAge.ExpiryDate = qry.ActiveTo;
                    oAge.LevelID = qry.LevelID;
                    oAge.CompanyID = qry.CompanyID;
                    oAge.CustomerID = qry.ExtendedCustomerID;

                    // look for shop name, shop no for the customer 
                    var qryShop = (from s in context.Shops
                                   where s.ShopID == qry.ShopID
                                   select new { s.ShopName, s.ShopNo }).FirstOrDefault();

                    if (qryShop != null)
                    {
                        oAge.ShopName = qryShop.ShopName;
                        oAge.ShopNo = qryShop.ShopNo;
                    }

                    oAge.LocationID = qry.LocationID;

                    AgeingList.Add(oAge);
                }

                var qryAge = (from a in AgeingList
                              orderby a.AgeGroup ascending
                              select a).ToList();

                this.cContract_AgeingBindingSource.DataSource = qryAge;
                this.cContract_AgeingGridControl.RefreshDataSource();
                this.gridView1.BestFitColumns();
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkCompany_EditValueChanged(object sender, EventArgs e)
        {
            processAge(dateEditDate.DateTime.Date);
        }

        private void dateEditDate_EditValueChanged(object sender, EventArgs e)
        {
            processAge(dateEditDate.DateTime.Date);
        }
    }
}