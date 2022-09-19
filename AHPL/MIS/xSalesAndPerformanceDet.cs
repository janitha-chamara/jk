using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Linq.Expressions;
using DataTier;

namespace MMS.MIS
{
    public partial class xSalesAndPerformanceDet : DevExpress.XtraEditors.XtraForm
    {
        public xSalesAndPerformanceDet()
        {
            InitializeComponent();
        }

        bool IsBudget = false;
        List<cFinYearDet> finyearList = new List<cFinYearDet>();
        List<DataTier.ReportClasses.PerformanceDetail_OSIncome> osList = new List<DataTier.ReportClasses.PerformanceDetail_OSIncome>();

        List<DataTier.ReportClasses.PerformanceDetails> perfomDetList = new List<DataTier.ReportClasses.PerformanceDetails>();
        private decimal occupied;
        private decimal rentperMonth;
        private decimal serviceChargeperMonth;
        private decimal rentperSqFt;
        private decimal serviceChargeperSqFt;
        private void xSalesAndPerformanceDet_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    //company
                    var qryComp = (from c in context.Companies
                                   select new { c.CompanyID, c.CompanyCode }).ToList();

                   this.companyIDLookUpEdit.Properties.DataSource = qryComp;
                   this.companyIDLookUpEdit.Properties.DisplayMember = "CompanyCode";
                    this.companyIDLookUpEdit.Properties.ValueMember = "CompanyID";

                    //location
                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode }).ToList();
                   this.locationIDLookUpEdit.Properties.DataSource = qryLoc;
                   this.locationIDLookUpEdit.Properties.DisplayMember = "LocationCode";
                   this.locationIDLookUpEdit.Properties.ValueMember = "LocationID";

                   //other services 
                   var qryOS = (from os in context.OtherServiceCategories
                                select new { os.OtherServiceID, os.OtherServiceName }).ToList();
                   this.lookOSCategoryID.DataSource = qryOS;
                   this.lookOSCategoryID.DisplayMember = "OtherServiceName";
                   this.lookOSCategoryID.ValueMember = "OtherServiceID";

                   updateCreditNoteInvoices();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateCreditNoteInvoices()
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCN = (from i in context.Invoices
                             where i.SubInvTypeID == 2
                             select i).ToList();
                foreach (var qry in qryCN)
                {
                    if (qry.RentPerSqFt > 0)
                    {
                        qry.RentPerSqFt = qry.RentPerSqFt * -1;
                    }

                    if (qry.SCPerSqFt > 0)
                    {
                        qry.SCPerSqFt = qry.SCPerSqFt * -1;
                    }
                    if (qry.RentPerMonth > 0)
                    {
                        qry.RentPerMonth = qry.RentPerMonth * -1;
                    }

                    if (qry.SCPerMonth > 0)
                    {
                        qry.SCPerMonth = qry.SCPerMonth * -1;
                    }

                    if (qry.RentWIthSCPerSqFt > 0)
                    {
                        qry.RentWIthSCPerSqFt = qry.RentWIthSCPerSqFt * -1;
                    }

                    if (qry.TotalAmount > 0)
                    {
                        qry.TotalAmount = qry.TotalAmount * -1;
                    }

                    if (qry.TotalTax > 0)
                    {
                        qry.TotalTax = qry.TotalTax * -1;
                    }

                    if (qry.OtherTax > 0)
                    {
                        qry.OtherTax = qry.OtherTax * -1;
                    }
                    if (qry.RentWithSCPerMonth > 0)
                    {
                        qry.RentWithSCPerMonth = qry.RentWithSCPerMonth * -1;
                    }
                    if (qry.MandatoryTaxAmount > 0)
                    {
                        qry.MandatoryTaxAmount = qry.MandatoryTaxAmount * -1;
                    }
                    if (qry.TotalWithMandatoryTax > 0)
                    {
                        qry.TotalWithMandatoryTax = qry.TotalWithMandatoryTax * -1;
                    }
                    if (qry.TotalRentPerMonth > 0)
                    {
                        qry.TotalRentPerMonth = qry.TotalRentPerMonth * -1;
                    }

                    var qryDet = qry.Invoice_Details.ToList();
                    foreach (var qryD in qryDet)
                    {
                        if (qryD.Amount > 0)
                        {
                            qryD.Amount = qryD.Amount * -1;
                        }
                    }
                }

                int num = context.SaveChanges();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.lookMonthYear.Text.ToString()))
                { throw new Exception("Please Select Month/Year"); }


                this.gridView1.Columns[5].Caption = "Re-Forecasting - " + this.lookMonthYear.Text.ToString();
                this.gridView1.Columns[6].Caption = "Budget - " + this.lookMonthYear.Text.ToString();
                this.gridView1.Columns[7].Caption = "Actual - " + this.lookMonthYear.Text.ToString();
                this.gridView1.Columns[8].Caption = "Re-Forecasting - As at " + this.lookMonthYear.Text.ToString() + "(YTD)";
                this.gridView1.Columns[9].Caption = "Actual - As at " + this.lookMonthYear.Text.ToString() + "(YTD)";
                this.gridView1.Columns["BudgetValueYTD"].Caption = "Budget - As at " + this.lookMonthYear.Text.ToString() + "(YTD)";
                //get last year value for the caption
              
                perfomDetList.Clear();
                int fisdetid = int.Parse(this.lookMonthYear.EditValue.ToString());
              
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    int CompID = 0;
                    int LocID = 0;
                    DateTime lastYearDate = DateTime.Now.Date;
                    
                    var qryDet = (from d in context.FinancialYear_Details
                                  join f in context.Financial_Years on d.FinancialYearID equals f.FinancialYearID
                                  join m in context.Months on d.MonthID equals m.MonthID
                                  where d.FinancialYearDetailID == fisdetid
                                  select new { d.CurrentYear,d.MonthID, m.MonthCode,f.FromDate,f.ToDate,f.CompanyID,f.LocationID }).FirstOrDefault();
                    if (qryDet != null)
                    {
                        int lastYear = qryDet.CurrentYear - 1;
                        string month = qryDet.MonthCode;
                        string caption = month + "-" + lastYear.ToString();
                        this.gridView1.Columns[10].Caption = caption;

                        CompID = qryDet.CompanyID;
                        LocID = qryDet.LocationID;


                        DateTime fromdate = qryDet.FromDate.Value;
                        DateTime selectedYearMonth1;
                        DateTime selectedYearMonth = new DateTime(qryDet.CurrentYear, qryDet.MonthID, 1);

                        selectedYearMonth1 = selectedYearMonth;
                        selectedYearMonth = selectedYearMonth.AddMonths(1).AddDays(-1).Date;

                        DateTime reforeCastDay = fromdate.AddMonths(6).Date;
                        if (reforeCastDay >= selectedYearMonth)  // if true then its within 1st 6 month of the financial year
                        {
                            this.gridView1.Columns[5].Visible = false;
                            this.gridView1.Columns[8].Visible = false;
                            this.gridView1.Columns["BudgetValueYTD"].Visible = true;
                            this.gridView1.Columns[6].Visible = true;
                            IsBudget = true;
                        }
                        else
                        {
                            this.gridView1.Columns[5].Visible = true;
                            this.gridView1.Columns[8].Visible = true;
                            this.gridView1.Columns["BudgetValueYTD"].Visible = false;
                            this.gridView1.Columns[6].Visible = false;
                            IsBudget = false;
                        }
                        
                    }

                    this.gridView1.BestFitColumns();
                         DateTime fromDate = DateTime.Now.Date;
                        DateTime dateAsAt = DateTime.Now.Date;
                    //--
                    var qryRptItem = (from r in context.MisReportItems
                                      orderby r.SortOrder
                                      select r).ToList();

                    foreach (var qry in qryRptItem)
                    {
                        DataTier.ReportClasses.PerformanceDetails performDet = new DataTier.ReportClasses.PerformanceDetails();


                        var qryPerfDet = (from f in context.MISPerformanceDetails
                                          where f.ReportItemID == qry.ReportItemID && f.FinancialYearDetailID == fisdetid
                                          select f).FirstOrDefault();

                      
                        performDet.ReportItemID = qry.ReportItemID;
                        performDet.ReportItemName = qry.ReportItemName;
                        performDet.CompanyID = CompID;
                        performDet.LocationID = LocID;

                        if (qryPerfDet != null)
                        {
                            performDet.FinancialYearDetailID = qryPerfDet.FinancialYearDetailID;
                            performDet.PerformanceDetailID = qryPerfDet.PerformanceDetailID;
                            //forecasting value                     
                            performDet.ReforecastingValueM = qryPerfDet.ReforecastingValue;
                            // budget value 
                            performDet.BudgetValueM = qryPerfDet.BudgetValue;
                        }


                        var qryFinYear = (from d in context.FinancialYear_Details
                                          join m in context.Financial_Years on d.FinancialYearID equals m.FinancialYearID
                                          where d.FinancialYearDetailID == fisdetid
                                          select new { m.CompanyID, m.LocationID, d.MonthID, d.CurrentYear,m.FromDate,m.ToDate,d.FinancialYearDetailID }).FirstOrDefault();

                      
                        if (qryFinYear != null)
                        {
                            dateAsAt = new DateTime(qryFinYear.CurrentYear, qryFinYear.MonthID, 1);
                            dateAsAt = dateAsAt.AddMonths(1).AddDays(-1).Date;

                            lastYearDate = dateAsAt.AddYears(-1).Date;

                            fromDate = qryFinYear.FromDate.Value;

                            //TimeSpan ts = dateAsAt.Subtract(fromDate).d                       

                        }

                        // Actual values 


                        if (qry.ReportItemID == 1)  // Total Area 
                        {
                            decimal totalArea = 0;                           
                            if (qryFinYear != null)
                            {

                                //totalArea = getTotalArea(qryFinYear.LocationID, dateAsAt);
                                //totalArea = CustomClasses.cCommon_Functions.MisShopOccupancy_Summmary(qryFinYear.LocationID, dateAsAt);
                                totalArea = CustomClasses.cCommon_Functions.getTotalSqFtInLocation(qryFinYear.CompanyID, qryFinYear.LocationID, dateAsAt);
                                performDet.ActualValueM = totalArea;
                                performDet.ActualValueYTD = getTotalAreaYTD(qryFinYear.LocationID,fromDate,dateAsAt,qryFinYear.CompanyID);
                                performDet.LastYearActualValue = getTotalArea(qryFinYear.LocationID, lastYearDate);
                                performDet.BudgetValueYTD = getValue_B_YTD(qryFinYear.LocationID, fromDate, dateAsAt,1,fisdetid);
                                performDet.ReforecastingValueYTD = getValue_R_YTD(qryFinYear.LocationID, fromDate, dateAsAt, qry.ReportItemID, fisdetid);
                                //performDet.BudgetValueM = getValueB_M(qryFinYear.LocationID, fisdetid,1);

                                if (splashScreenManager1.IsSplashFormVisible == true)
                                {
                                    splashScreenManager1.SetWaitFormDescription("Total Area");
                                }
                            }

                        }

                        if (qry.ReportItemID == 2) // Un-Occupied
                        {
                            decimal unoccupied = 0;

                            if (qryFinYear != null)
                            {
                                unoccupied = CustomClasses.cCommon_Functions.MisShopUnOccupancy_Summary(qryFinYear.CompanyID, qryFinYear.LocationID, dateAsAt);

                                performDet.ActualValueM = unoccupied;
                                performDet.ActualValueYTD = getUnoccupiedYTD(qryFinYear.LocationID, qryFinYear.CompanyID, fromDate, dateAsAt); ;
                                performDet.LastYearActualValue = getUnoccupied(qryFinYear.LocationID, qryFinYear.CompanyID, lastYearDate);
                                //performDet.BudgetValueM = getValueB_M(qryFinYear.LocationID, fisdetid, 2);
                                performDet.BudgetValueYTD = getValue_B_YTD(qryFinYear.LocationID, fromDate, dateAsAt, 2, fisdetid);
                                performDet.ReforecastingValueYTD = getValue_R_YTD(qryFinYear.LocationID, fromDate, dateAsAt, qry.ReportItemID, fisdetid);

                                if (splashScreenManager1.IsSplashFormVisible == true)
                                {
                                    splashScreenManager1.SetWaitFormDescription("Un-Occupied Area");
                                }

                            }
                        }
                        //--

                        if (qry.ReportItemID == 3) // occupied area 
                        {

                             occupied = 0;
                            if (qryFinYear != null)
                            {
                                occupied = CustomClasses.cCommon_Functions.MisShopOccupancy_Summmary(qryFinYear.LocationID, dateAsAt);
                                performDet.ActualValueM = occupied;
                                //occupied = getOccupied(qryFinYear.LocationID, qryFinYear.CompanyID, dateAsAt);
                                performDet.ActualValueYTD = getOccupiedYTD(qryFinYear.LocationID, qryFinYear.CompanyID,fromDate, dateAsAt);
                                performDet.LastYearActualValue = getOccupied(qryFinYear.LocationID, qryFinYear.CompanyID, lastYearDate);
                                //performDet.BudgetValueM = getValueB_M(qryFinYear.LocationID, fisdetid, 3);
                                performDet.BudgetValueYTD = getValue_B_YTD(qryFinYear.LocationID, fromDate, dateAsAt, 3, fisdetid);
                                performDet.ReforecastingValueYTD = getValue_R_YTD(qryFinYear.LocationID, fromDate, dateAsAt, qry.ReportItemID, fisdetid);

                                if (splashScreenManager1.IsSplashFormVisible == true)
                                {
                                    splashScreenManager1.SetWaitFormDescription("Occupied Area");
                                }

                            }

                            performDet.ActualValueM = occupied;

                        }

                        if (qry.ReportItemID == 4) // occupancy %
                        {
                            decimal occupancy = 0;
                            if (qryFinYear != null)
                            {
                                decimal totalArea = CustomClasses.cCommon_Functions.getTotalSqFtInLocation(qryFinYear.CompanyID, qryFinYear.LocationID, dateAsAt);
                                decimal occArea = CustomClasses.cCommon_Functions.MisShopOccupancy_Summmary(qryFinYear.LocationID, dateAsAt);
                                occupancy = (occArea / totalArea) * 100;
                                occupancy = Math.Round(occupancy, 2);

                                //occupancy = getOccupancy(qryFinYear.LocationID, qryFinYear.CompanyID, dateAsAt);

                                performDet.ActualValueM = occupancy;
                                performDet.ActualValueYTD = getOccupancyYTD(qryFinYear.LocationID, qryFinYear.CompanyID, fromDate, dateAsAt);
                                //performDet.BudgetValueM = getValueB_M(qryFinYear.LocationID, fisdetid, 4);
                                performDet.BudgetValueYTD = getValue_B_YTD(qryFinYear.LocationID, fromDate, dateAsAt, 4, fisdetid);
                                performDet.ReforecastingValueYTD = getValue_R_YTD(qryFinYear.LocationID, fromDate, dateAsAt, qry.ReportItemID, fisdetid);

                                if (splashScreenManager1.IsSplashFormVisible == true)
                                {
                                    splashScreenManager1.SetWaitFormDescription("Occupancy");
                                }
                            }
                        }

                        if (qry.ReportItemID == 5) // Rent per Month with NBT
                        {
                             rentperMonth = 0;
                            if (qryFinYear != null)
                            {
                                rentperMonth = CustomClasses.cCommon_Functions.getRentperMonth(qryFinYear.LocationID, qryFinYear.CompanyID, dateAsAt);
                                performDet.LastYearActualValue = CustomClasses.cCommon_Functions.getRentperMonth(qryFinYear.LocationID, qryFinYear.CompanyID, lastYearDate);
                            }
                            performDet.ActualValueM = rentperMonth;
                            performDet.ActualValueYTD = getRentperMonthYTD(qryFinYear.LocationID, qryFinYear.CompanyID, fromDate, dateAsAt);
                            //performDet.BudgetValueM = getValueB_M(qryFinYear.LocationID, fisdetid, 5);
                            performDet.BudgetValueYTD = getValue_B_YTD(qryFinYear.LocationID, fromDate, dateAsAt, 5, fisdetid);
                            performDet.ReforecastingValueYTD = getValue_R_YTD(qryFinYear.LocationID, fromDate, dateAsAt, qry.ReportItemID, fisdetid);

                            if (splashScreenManager1.IsSplashFormVisible == true)
                            {
                                splashScreenManager1.SetWaitFormDescription("Rent/Month");
                            }

                        }


                        if (qry.ReportItemID == 6) // service charge per month with NBT
                        {
                             serviceChargeperMonth = 0;
                            if (qryFinYear != null)
                            {
                                serviceChargeperMonth = CustomClasses.cCommon_Functions.getSCperMonth(qryFinYear.LocationID, qryFinYear.CompanyID, dateAsAt);
                                performDet.LastYearActualValue = CustomClasses.cCommon_Functions.getSCperMonth(qryFinYear.LocationID, qryFinYear.CompanyID, lastYearDate);
                            }
                            performDet.ActualValueM = serviceChargeperMonth;
                            performDet.ActualValueYTD = getSCperMonthYTD(qryFinYear.LocationID, qryFinYear.CompanyID, fromDate, dateAsAt);
                            //performDet.BudgetValueM = getValueB_M(qryFinYear.LocationID, fisdetid, 6);
                            performDet.BudgetValueYTD = getValue_B_YTD(qryFinYear.LocationID, fromDate, dateAsAt, 6, fisdetid);
                            performDet.ReforecastingValueYTD = getValue_R_YTD(qryFinYear.LocationID, fromDate, dateAsAt, qry.ReportItemID, fisdetid);

                            if (splashScreenManager1.IsSplashFormVisible == true)
                            {
                                splashScreenManager1.SetWaitFormDescription("Service Charge/Month");
                            }

                        }

                        if (qry.ReportItemID == 7) // Rent With Sc perMonth 
                        {
                            decimal totalRentWithSC = 0;
                            if (qryFinYear != null)
                            {
                                totalRentWithSC =CustomClasses.cCommon_Functions.getTotalRentWithSC(qryFinYear.CompanyID, qryFinYear.LocationID, dateAsAt);
                                performDet.LastYearActualValue = CustomClasses.cCommon_Functions.getTotalRentWithSC(qryFinYear.CompanyID, qryFinYear.LocationID, lastYearDate);

                            }
                            performDet.ActualValueM = totalRentWithSC;
                            performDet.ActualValueYTD = getTotalRentWithSCYTD(qryFinYear.CompanyID, qryFinYear.LocationID, fromDate, dateAsAt);
                            //performDet.BudgetValueM = getValueB_M(qryFinYear.LocationID, fisdetid, 7);
                            performDet.BudgetValueYTD = getValue_B_YTD(qryFinYear.LocationID, fromDate, dateAsAt, 7, fisdetid);
                            performDet.ReforecastingValueYTD = getValue_R_YTD(qryFinYear.LocationID, fromDate, dateAsAt, qry.ReportItemID, fisdetid);

                            
                            if (splashScreenManager1.IsSplashFormVisible == true)
                            {
                                splashScreenManager1.SetWaitFormDescription("Rent + Sc / Month");
                            }

                        }

                        if (qry.ReportItemID == 8) // Rent/sqft without exceptional customer   with NBT
                        {
                            decimal rentperSqFt = 0;
                            if (qryFinYear != null)
                            {
                                rentperSqFt = CustomClasses.cCommon_Functions.getRentperSqFtWithout(qryFinYear.CompanyID, qryFinYear.LocationID, dateAsAt, qry.ExceptionItem, occupied, rentperMonth);
                                performDet.LastYearActualValue = CustomClasses.cCommon_Functions.getRentperSqFtWithout(qryFinYear.CompanyID, qryFinYear.LocationID, lastYearDate, qry.ExceptionItem,occupied);
                            }
                            performDet.ActualValueM = rentperSqFt;
                            performDet.ActualValueYTD = getRentperSqFtWithoutYTD(qryFinYear.CompanyID, qryFinYear.LocationID, fromDate, dateAsAt, qry.ExceptionItem,occupied);
                            //performDet.BudgetValueM = getValueB_M(qryFinYear.LocationID, fisdetid, 8);
                            performDet.BudgetValueYTD = getValue_B_YTD(qryFinYear.LocationID, fromDate, dateAsAt, 8, fisdetid);
                            performDet.ReforecastingValueYTD = getValue_R_YTD(qryFinYear.LocationID, fromDate, dateAsAt, qry.ReportItemID, fisdetid);

                            if (splashScreenManager1.IsSplashFormVisible == true)
                            {
                                splashScreenManager1.SetWaitFormDescription("Rent/SqFt without Exceptional Cust.");
                            }

                        }

                        if (qry.ReportItemID == 9) // Rent/sqft with NBT
                        {
                            rentperSqFt = 0;
                            if (qryFinYear != null)
                            {
                                rentperSqFt = Math.Round(rentperMonth / occupied, 2);
                                performDet.LastYearActualValue = getRentperSqFt(qryFinYear.CompanyID, qryFinYear.LocationID, lastYearDate);
                            }
                            performDet.ActualValueM = rentperSqFt;
                            performDet.ActualValueYTD = getRentperSqFtYTD(qryFinYear.CompanyID, qryFinYear.LocationID, fromDate, dateAsAt);
                            //performDet.BudgetValueM = getValueB_M(qryFinYear.LocationID, fisdetid, 9);
                            performDet.BudgetValueYTD = getValue_B_YTD(qryFinYear.LocationID, fromDate, dateAsAt, 9, fisdetid);
                            performDet.ReforecastingValueYTD = getValue_R_YTD(qryFinYear.LocationID, fromDate, dateAsAt, qry.ReportItemID, fisdetid);

                            
                            if (splashScreenManager1.IsSplashFormVisible == true)
                            {
                                splashScreenManager1.SetWaitFormDescription("Rent/SqFt");
                            }

                        }

                        if (qry.ReportItemID == 10) // service charge/sqft with NBT
                        {
                             serviceChargeperSqFt = 0;
                            if (qryFinYear != null)
                            {
                                serviceChargeperSqFt = Math.Round(serviceChargeperMonth / occupied, 2);
                                //serviceChargeperSqFt = getSCperSqFt(qryFinYear.CompanyID, qryFinYear.LocationID, dateAsAt);
                                performDet.LastYearActualValue = getSCperSqFt(qryFinYear.CompanyID, qryFinYear.LocationID, lastYearDate);

                            }
                            performDet.ActualValueM = serviceChargeperSqFt;
                            performDet.ActualValueYTD = getSCperSqFtYTD(qryFinYear.CompanyID, qryFinYear.LocationID, fromDate, dateAsAt);
                            //performDet.BudgetValueM = getValueB_M(qryFinYear.LocationID, fisdetid, 10);
                            performDet.BudgetValueYTD = getValue_B_YTD(qryFinYear.LocationID, fromDate, dateAsAt, 10, fisdetid);
                            performDet.ReforecastingValueYTD = getValue_R_YTD(qryFinYear.LocationID, fromDate, dateAsAt, qry.ReportItemID, fisdetid);

                            if (splashScreenManager1.IsSplashFormVisible == true)
                            {
                                splashScreenManager1.SetWaitFormDescription("Service Charge / SqFt");
                            }
                        }

                        if (qry.ReportItemID == 11) // Total rent / SqFt
                        {
                            decimal totalRentperSqFt = 0;
                            if (qryFinYear != null)
                            {
                                totalRentperSqFt = rentperSqFt + serviceChargeperSqFt;
                                //totalRentperSqFt = getTotalrentperSqFt(qryFinYear.CompanyID, qryFinYear.LocationID, dateAsAt);
                                performDet.LastYearActualValue = getTotalrentperSqFt(qryFinYear.CompanyID, qryFinYear.LocationID, lastYearDate);
                            }
                            performDet.ActualValueM = totalRentperSqFt;
                            performDet.ActualValueYTD = getTotalrentperSqFtYTD(qryFinYear.CompanyID, qryFinYear.LocationID, fromDate, dateAsAt);
                            //performDet.BudgetValueM = getValueB_M(qryFinYear.LocationID, fisdetid, 11);
                            performDet.BudgetValueYTD = getValue_B_YTD(qryFinYear.LocationID, fromDate, dateAsAt, 11, fisdetid);
                            performDet.ReforecastingValueYTD = getValue_R_YTD(qryFinYear.LocationID, fromDate, dateAsAt, qry.ReportItemID, fisdetid);

                            if (splashScreenManager1.IsSplashFormVisible == true)
                            {
                                splashScreenManager1.SetWaitFormDescription("Total Rent");
                            }
                        }


                        perfomDetList.Add(performDet);

                        // 

                    }

                    //get other service income 
                    getOtherServiceIncome(locationIDLookUpEdit.EditValue, companyIDLookUpEdit.EditValue, dateAsAt);
                    if (splashScreenManager1.IsSplashFormVisible == true)
                    {
                        splashScreenManager1.SetWaitFormDescription("Other Service Income");
                    }
                    ///-- 

                    
                }

               
                this.performanceDetailsBindingSource.DataSource = perfomDetList;
                this.performanceDetailsGridControl.RefreshDataSource();
                this.gridView1.BestFitColumns();
                if (splashScreenManager1.IsSplashFormVisible == true)
                { splashScreenManager1.CloseWaitForm(); }

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                { splashScreenManager1.CloseWaitForm(); }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal getValue_R_YTD(int pLocId, DateTime fromDate, DateTime pDateAsAt, int pReportItemId, int pFinYearDetID)
        {

            decimal value = 0;
            int finYrStart = 0;
            int finYrSel = 0;

            try
            {

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryFinYearDet = (from d in context.FinancialYear_Details
                                         where d.FinancialYearDetailID == pFinYearDetID
                                         select new { d.FinancialYearID, d.FinancialYearDetailID }).FirstOrDefault();
                    if (qryFinYearDet != null)
                    {
                        finYrSel = qryFinYearDet.FinancialYearDetailID;
                        var qryFinYear = (from m in context.FinancialYear_Details
                                          where m.FinancialYearID == qryFinYearDet.FinancialYearID
                                          select new { m.FinancialYearDetailID }).FirstOrDefault();
                        if (qryFinYear != null)
                        {
                            finYrStart = qryFinYear.FinancialYearDetailID;
                        }
                    }


                    // year to date budget 
                    List<decimal> totalList = new List<decimal>();
                    var qryBudgetdYtd = (from d in context.FinancialYear_Details
                                         join m in context.MISPerformanceDetails on d.FinancialYearDetailID equals m.FinancialYearDetailID
                                         where d.FinancialYearDetailID >= finYrStart && d.FinancialYearDetailID <= finYrSel && m.ReportItemID == pReportItemId
                                         select m).ToList();
                    foreach (var qry in qryBudgetdYtd)
                    {
                        totalList.Add(qry.ReforecastingValue);

                    }

                    if (pReportItemId >= 5 && pReportItemId <= 7) // for Rent , Service Charge, Total rent & service charge Sum will be calculated Year to date
                    {
                        value = totalList.Sum();
                    }
                    else
                    {
                        value = totalList.Average();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;


        }

        private decimal getValueB_M(int pLocationId, int fisdetid, int pReportItemId)
        {
            decimal value = 0;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryVal = (from m in context.MISPerformanceDetails
                                  join d in context.FinancialYear_Details on m.FinancialYearDetailID equals d.FinancialYearDetailID
                                  where d.FinancialYearDetailID == fisdetid && m.ReportItemID == pReportItemId
                                  select m).FirstOrDefault();
                    if (qryVal != null)
                    {
                        value = qryVal.BudgetValue;
                    }
                                  

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return value;
        }

       

        private decimal getValue_B_YTD(int pLocId, DateTime pfromDate, DateTime pDateAsAt,int pReportItemId,int pFinYearDetID )
        {
            decimal value = 0;
            int finYrStart = 0;
            int finYrSel = 0;

            try
            {

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryFinYearDet = (from d in context.FinancialYear_Details
                                      where d.FinancialYearDetailID == pFinYearDetID
                                      select new { d.FinancialYearID,d.FinancialYearDetailID }).FirstOrDefault();
                    if (qryFinYearDet != null)
                    {
                        finYrSel = qryFinYearDet.FinancialYearDetailID;
                        var qryFinYear = (from m in context.FinancialYear_Details
                                          where m.FinancialYearID == qryFinYearDet.FinancialYearID
                                          select new { m.FinancialYearDetailID }).FirstOrDefault();
                        if (qryFinYear != null)
                        {
                            finYrStart = qryFinYear.FinancialYearDetailID;
                        }
                    }


                    // year to date budget 
                    List<decimal> totalList = new List<decimal>();
                    var qryBudgetdYtd = (from d in context.FinancialYear_Details
                                         join m in context.MISPerformanceDetails on d.FinancialYearDetailID equals m.FinancialYearDetailID
                                         where d.FinancialYearDetailID >= finYrStart && d.FinancialYearDetailID <= finYrSel && m.ReportItemID == pReportItemId
                                         select m).ToList();
                    foreach (var qry in qryBudgetdYtd)
                    {
                        totalList.Add(qry.BudgetValue);

                    }

                    if (pReportItemId >= 5 && pReportItemId <= 7) // for Rent , Service Charge, Total rent & service charge Sum will be calculated Year to date
                    {
                        value = totalList.Sum();
                    }
                    else
                    {
                        value = totalList.Average();
                    }
                }            

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;
        }

        private void getOtherServiceIncome(object pLocID, object pCompID, DateTime pDateAsAt)
        {
            try
            {
                osList.Clear();
                int locid = int.Parse(pLocID.ToString());
                int compid = int.Parse(pCompID.ToString());

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryOSIncome = (from i in context.Invoices
                                       where i.InvoiceTypeID == 3  && i.SAP_PstnDateInDoc.Value.Month == pDateAsAt.Month && i.SAP_PstnDateInDoc.Value.Year ==pDateAsAt.Year && i.CompanyID == compid && i.LocationID ==locid && i.IsConfirmed == true
                                       group i by i.OtherServiceID into g
                                       select new { OtherServiceID = g.Key }).ToList();
                    foreach (var qry in qryOSIncome)
                    {

                        int otherSID = qry.OtherServiceID;

                        var qrySum = (from i in context.Invoices
                                      where i.InvoiceTypeID == 3 && i.SAP_PstnDateInDoc.Value.Month == pDateAsAt.Month && i.OtherServiceID == otherSID && i.SAP_PstnDateInDoc.Value.Year == pDateAsAt.Year && i.CompanyID == compid && i.LocationID == locid && i.IsConfirmed == true
                                      select new { i.TotalWithMandatoryTax }).Sum(x => x.TotalWithMandatoryTax);
                        if (qrySum > 0)
                        {
                            DataTier.ReportClasses.PerformanceDetail_OSIncome osObj = new DataTier.ReportClasses.PerformanceDetail_OSIncome();
                            osObj.OtherServiceCategoryID = otherSID;
                            osObj.RentWithMandatoryTax = qrySum;
                            osList.Add(osObj);
                        }





                    }

                    this.performanceDetail_OSIncomeBindingSource.DataSource = osList;
                    this.performanceDetail_OSIncomeGridControl.RefreshDataSource();

                    //select new { i.TotalWithMandatoryTax }).Sum(x => x.TotalWithMandatoryTax);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal getTotalrentperSqFtYTD(int pLocID, int pCompID, DateTime pFromDate, DateTime pDateAsAt)
        {
            decimal totalrentperSqFt = 0;

            int monthNos = ((pDateAsAt.Year - pFromDate.Year) * 12) + pDateAsAt.Month - pFromDate.Month;

            List<decimal> rentList = new List<decimal>();
            for (int i = 0; i <= monthNos; i++)
            {
                DateTime currDateFrom = pFromDate.AddMonths(i).Date;
                DateTime currDateTo = currDateFrom.AddMonths(1).AddDays(-1).Date;

                decimal rent = getTotalrentperSqFt(pLocID, pCompID, currDateFrom);
                if (rent > 0)
                {
                    rentList.Add(rent);

                }

                totalrentperSqFt = rentList.Average();

            }

            return totalrentperSqFt;
        }

        private decimal getSCperSqFtYTD(int pLocID, int pCompID, DateTime pFromDate, DateTime pDateAsAt)
        {
            decimal serviceChargeperSqFt = 0;

            int monthNos = ((pDateAsAt.Year - pFromDate.Year) * 12) + pDateAsAt.Month - pFromDate.Month;

            List<decimal> rentList = new List<decimal>();
            for (int i = 0; i <= monthNos; i++)
            {
                DateTime currDateFrom = pFromDate.AddMonths(i).Date;
                DateTime currDateTo = currDateFrom.AddMonths(1).AddDays(-1).Date;

                decimal rent = getSCperSqFt(pLocID, pCompID, currDateFrom);
                if (rent > 0)
                {
                    rentList.Add(rent);

                }

                serviceChargeperSqFt = rentList.Average();

            }

            return serviceChargeperSqFt; 
        }

        private decimal getRentperSqFtYTD(int pLocID, int pCompID, DateTime pFromDate, DateTime pDateAsAt)
        {
            decimal renperSqFt = 0;

            int monthNos = ((pDateAsAt.Year - pFromDate.Year) * 12) + pDateAsAt.Month - pFromDate.Month;

            List<decimal> rentList = new List<decimal>();
            for (int i = 0; i <= monthNos; i++)
            {
                DateTime currDateFrom = pFromDate.AddMonths(i).Date;
                DateTime currDateTo = currDateFrom.AddMonths(1).AddDays(-1).Date;

                decimal rent = getRentperSqFt(pLocID, pCompID, currDateFrom);
                if (rent > 0)
                {
                    rentList.Add(rent);

                }

                renperSqFt = rentList.Average();

            }


            return renperSqFt; 
        }

       

        private decimal getRentperSqFtWithoutYTD(int pLocID, int pCompID, DateTime pFromDate, DateTime pDateAsAt, int? pExtendedCustomerID,decimal totalOccupied)
        {
            decimal renperSqFtWithout = 0;

            int monthNos = ((pDateAsAt.Year - pFromDate.Year) * 12) + pDateAsAt.Month - pFromDate.Month;

            List<decimal> rentList = new List<decimal>();
            for (int i = 0; i <= monthNos; i++)
            {
                DateTime currDateFrom = pFromDate.AddMonths(i).Date;
                DateTime currDateTo = currDateFrom.AddMonths(1).AddDays(-1).Date;

                decimal rent = CustomClasses.cCommon_Functions.getRentperSqFtWithout(pLocID, pCompID, currDateFrom,pExtendedCustomerID,totalOccupied);
                if (rent > 0)
                {
                    rentList.Add(rent);

                }

                renperSqFtWithout = rentList.Average();

            }

            return renperSqFtWithout;
        }

        private decimal getTotalRentWithSCYTD(int pLocID, int pCompID, DateTime pFromDate, DateTime pDateAsAt)
        {
            decimal totalRentWithSc = 0;

            int monthNos = ((pDateAsAt.Year - pFromDate.Year) * 12) + pDateAsAt.Month - pFromDate.Month;

            List<decimal> rentList = new List<decimal>();
            for (int i = 0; i <= monthNos; i++)
            {
                DateTime currDateFrom = pFromDate.AddMonths(i).Date;
                DateTime currDateTo = currDateFrom.AddMonths(1).AddDays(-1).Date;

                decimal rent = CustomClasses.cCommon_Functions.getTotalRentWithSC(pLocID, pCompID, currDateFrom);
                if (rent > 0)
                {
                    rentList.Add(rent);

                }

                totalRentWithSc = rentList.Sum();

            }


            return totalRentWithSc;
        }

        private decimal getSCperMonthYTD(int pLocID, int pCompID, DateTime pFromDate, DateTime pDateAsAt)
        {
            decimal scperMonth = 0;

              int monthNos = ((pDateAsAt.Year - pFromDate.Year) * 12) + pDateAsAt.Month - pFromDate.Month;

              List<decimal> rentList = new List<decimal>();
              for (int i = 0; i <= monthNos; i++)
              {
                  DateTime currDateFrom = pFromDate.AddMonths(i).Date;
                  DateTime currDateTo = currDateFrom.AddMonths(1).AddDays(-1).Date;

                  decimal sc = CustomClasses.cCommon_Functions.getSCperMonth(pLocID, pCompID, currDateFrom);
                  if (sc > 0)
                  {
                      rentList.Add(sc);

                  }

                  scperMonth = rentList.Sum();

              }


            return scperMonth;
        }

        private decimal getRentperMonthYTD(int pLocID, int pCompID, DateTime pFromDate, DateTime pDateAsAt)
        {
            decimal rentPerMonth = 0;

           
                int monthNos = ((pDateAsAt.Year - pFromDate.Year) * 12) + pDateAsAt.Month - pFromDate.Month;

                //each month total , add to the list and take average 
                List<decimal> rentList = new List<decimal>();
                for (int i = 0; i <= monthNos; i++)
                {
                    DateTime currDateFrom = pFromDate.AddMonths(i).Date;
                    DateTime currDateTo = currDateFrom.AddMonths(1).AddDays(-1).Date;


                    decimal rent = CustomClasses.cCommon_Functions.getRentperMonth(pLocID, pCompID, currDateFrom);

                    if (rent > 0)
                    {
                        rentList.Add(rent);

                    }

                    rentPerMonth = rentList.Sum();
                }
            return rentPerMonth;
        }

        private decimal getOccupancyYTD(int pLocID, int pCompID, DateTime pFromDate, DateTime pDateAsAt)
        {
            decimal occupancy = 0;
            try
            {
                

                int monthNos = ((pDateAsAt.Year - pFromDate.Year) * 12) + pDateAsAt.Month - pFromDate.Month;

                //each month total , add to the list and take average 
                List<decimal> occTotalList = new List<decimal>();
                for (int i = 0; i <= monthNos; i++)
                {
                    DateTime currDateFrom = pFromDate.AddMonths(i).Date;
                    DateTime currDateTo = currDateFrom.AddMonths(1).AddDays(-1).Date;

                    decimal totalArea = CustomClasses.cCommon_Functions.getTotalSqFtInLocation(pCompID, pLocID, currDateFrom);
                    decimal occArea = CustomClasses.cCommon_Functions.MisShopOccupancy_Summmary(pCompID, currDateFrom);
                    occupancy = (occArea / totalArea) * 100;
                    occupancy = Math.Round(occupancy, 2);

                    if (occupancy > 0)
                    {
                        occTotalList.Add(occupancy);
                    }
                }

                occupancy = occTotalList.Average();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ///---
  
            return occupancy;

        }

        private decimal getOccupiedYTD(int pLocID, int pCompID, DateTime pfromDate, DateTime pDateAsAt)
        {
            decimal occupied = 0;

            // total area 
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                decimal occupiedTotal = 0;                         

                int monthNos = ((pDateAsAt.Year - pfromDate.Year) * 12) + pDateAsAt.Month - pfromDate.Month;

                //each month total , add to the list and take average 
                List<decimal> occTotalList = new List<decimal>();
                for (int i=0; i<=monthNos;i++)
                {
                    DateTime currDateFrom = pfromDate.AddMonths(i).Date;
                    DateTime currDateTo = currDateFrom.AddMonths(1).AddDays(-1).Date;


                    //var qryShopOccupied = (from s in context.Shops
                    //                        join sd in context.Shop_Details on s.ShopID equals sd.ShopID
                    //                        join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                    //                        where s.CompanyID == pCompID && s.LocationID == pLocID && ra.IsAdvertisement == false && s.SqFeet > 1 && sd.ActiveFrom >= currDateFrom && sd.ActiveFrom <= currDateTo && s.CustomerID > 0
                    //                        select new { s.SqFeet }).ToList();
                    decimal total = 0;
                    total = CustomClasses.cCommon_Functions.MisShopOccupancy_Summmary(pLocID, currDateFrom); 


                    //if (qryShopOccupied.Count > 0)
                    //{
                    //    total = qryShopOccupied.Sum(x => x.SqFeet);
                    //}

                    if (total > 0)
                    {
                        occTotalList.Add(total);
                    }
                }


                occupiedTotal = occTotalList.Average();
               
                ///---
                ///
                occupied = occupiedTotal;

            }

            return occupied;
        }

        private decimal getUnoccupiedYTD(int pLocID, int pCompID, DateTime pfromDate, DateTime pDateAsAt)
        {
            decimal unoccupied = 0;

            // total area 
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                int monthNos = ((pDateAsAt.Year - pfromDate.Year) * 12) + pDateAsAt.Month - pfromDate.Month;

                //each month total , add to the list and take average 
                List<decimal> totareaList = new List<decimal>();
                for (int i = 0; i <= monthNos; i++)
                {
                    DateTime currDateFrom = pfromDate.AddMonths(i).Date;
                    DateTime currDateTo = currDateFrom.AddMonths(1).AddDays(-1).Date;



                    //var qryLocTotal1 = (from l in context.Locations
                    //                    join ld in context.Location_Details on l.LocationID equals ld.LocationID
                    //                    where l.LocationID == pLocID && ld.ActiveFrom >= currDateFrom && ld.ActiveFrom <= currDateTo
                    //                    select new { ld.SqFeet }).ToList();

                    decimal total = 0;
                    total = CustomClasses.cCommon_Functions.MisShopUnOccupancy_Summary(pCompID, pLocID, currDateFrom);

                    //if (qryLocTotal1.Count > 0)
                    //{
                    //    total = qryLocTotal1.Average(x => x.SqFeet);
                    //}

                    if (total > 0)
                    {
                        totareaList.Add(total);
                    }
                }

                unoccupied = totareaList.Average();


                //decimal occupiedTotal = 0;

                //occupiedTotal = getUnoccupied(pLocID, pCompID, pDateAsAt);

                //List<decimal> total = new List<decimal>();

                //////for active shop details
                //var qryShopOccupied1 = (from s in context.Shops
                //                        join sd in context.Shop_Details on s.ShopID equals sd.ShopID
                //                        join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                //                        where s.CompanyID == pCompID && s.LocationID == pLocID && ra.IsAdvertisement == false && s.SqFeet > 1 && sd.ActiveFrom >= pfromDate && sd.ActiveFrom <= pDateAsAt && s.CustomerID > 0
                //                        select new { s.SqFeet }).ToList();
                //foreach (var qry in qryShopOccupied1)
                //{
                //    total.Add(qry.SqFeet);
                //}
            
                /////---
                //occupiedTotal = total.Sum();


                //decimal loctotal = 0;

                //List<decimal> loctotalList = new List<decimal>();

                //var qryLocTotal1 = (from l in context.Locations
                //                    join ld in context.Location_Details on l.LocationID equals ld.LocationID
                //                    where l.LocationID == pLocID && ld.ActiveFrom >= pfromDate && ld.ActiveFrom <= pDateAsAt
                //                    select new { ld.SqFeet }).ToList();
                //foreach (var qry in qryLocTotal1)
                //{
                //    loctotalList.Add(qry.SqFeet);
                //}


                //loctotal = loctotalList.Average();

                


                //unoccupied = loctotal - occupiedTotal;

            }

            return unoccupied;

        }

        private decimal getTotalAreaYTD(int pLocID, DateTime pfromDate, DateTime pDateAsAt, int pCompID = 0)
        {
            decimal totalarea = 0;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
               

               int monthNos = ((pDateAsAt.Year - pfromDate.Year) * 12) + pDateAsAt.Month - pfromDate.Month;

                //each month total , add to the list and take average 
                List<decimal> totareaList = new List<decimal>();
                for (int i = 0; i <= monthNos; i++)
                {
                    DateTime currDateFrom = pfromDate.AddMonths(i).Date;
                    DateTime currDateTo = currDateFrom.AddMonths(1).AddDays(-1).Date;

                    

                    //var qryLocTotal1 = (from l in context.Locations
                    //                    join ld in context.Location_Details on l.LocationID equals ld.LocationID
                    //                    where l.LocationID == pLocID && ld.ActiveFrom >= currDateFrom && ld.ActiveFrom <= currDateTo
                    //                    select new { ld.SqFeet }).ToList();

                    decimal total = 0;
                    total = CustomClasses.cCommon_Functions.getTotalSqFtInLocation(pCompID, pLocID, currDateFrom);

                    //if (qryLocTotal1.Count > 0)
                    //{
                    //    total = qryLocTotal1.Average(x => x.SqFeet);
                    //}

                    if (total > 0)
                    {
                        totareaList.Add(total);
                    }
                }

                totalarea = totareaList.Average() ;
            }

            return totalarea;
        }

        private decimal getTotalrentperSqFt(int pLocID, int pCompID, DateTime pDateAsAt)
        {
            decimal totalrentperSqFt = 0;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    DateTime fromDate = new DateTime(pDateAsAt.Year, pDateAsAt.Month, 1);
                    DateTime toDate = fromDate.AddMonths(1).AddDays(-1).Date;

                    decimal totalRentWithSCperSqFt = 0;

                    List<decimal> total = new List<decimal>();

                    var qryRentWithSCperSqFt = (from i in context.Invoices
                                                join tr in context.TaxRates on i.MandatoryTaxRateID equals tr.TaxID
                                                where i.IsConfirmed == true && i.CompanyID == pCompID && i.LocationID == pLocID && i.InvoiceTypeID == 1 && (i.SAP_PstnDateInDoc >= fromDate && i.SAP_PstnDateInDoc<=toDate)
                                                select new { i.RentWithSCPerMonth,tr.TaxRate1 }).ToList();
                    foreach (var qry in qryRentWithSCperSqFt)
                    {
                        total.Add(qry.RentWithSCPerMonth * ((100 +  qry.TaxRate1)/100));
                    }
                    totalRentWithSCperSqFt = total.Sum();

                    //total occupied area 
                    decimal totalOccupied = CustomClasses.cCommon_Functions.MisShopOccupancy_Summmary(pLocID, pDateAsAt);
                    //--

                    if (totalRentWithSCperSqFt > 0 && totalOccupied > 0)
                    {
                        totalrentperSqFt = Math.Round(totalRentWithSCperSqFt / totalOccupied, 2);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return totalrentperSqFt;
        }

        private decimal getSCperSqFt(int pLocID, int pCompID, DateTime pDateAsAt)
        {
            decimal serviceChargeperSqFt = 0;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    DateTime fromDate = new DateTime(pDateAsAt.Year, pDateAsAt.Month, 1);
                    DateTime toDate = fromDate.AddMonths(1).AddDays(-1).Date;


                    List<decimal> total = new List<decimal>();


                    decimal totalSCperSqFt = 0;
                    var qrySCperSqFt = (from i in context.Invoices
                                        join tr in context.TaxRates on i.MandatoryTaxRateID equals tr.TaxRateID
                                          where i.IsConfirmed == true && i.CompanyID == pCompID && i.LocationID == pLocID && i.InvoiceTypeID == 1 && (i.SAP_PstnDateInDoc >= fromDate && i.SAP_PstnDateInDoc <=toDate)
                                        select new { i.SCPerMonth,tr.TaxRate1 }).ToList();
                    foreach (var qry in qrySCperSqFt)
                    {
                        total.Add(qry.SCPerMonth * ((100 + qry.TaxRate1)/100));
                    }


                    totalSCperSqFt = total.Sum();

                    //total occupied area 
                    decimal totalOccupied = CustomClasses.cCommon_Functions.MisShopOccupancy_Summmary(pLocID, pDateAsAt);
                    //--

                    if (totalSCperSqFt > 0 && totalOccupied > 0)
                    {
                        serviceChargeperSqFt = Math.Round(totalSCperSqFt / totalOccupied, 2);
                    }
                   
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return serviceChargeperSqFt; 
        }

        private decimal getRentperSqFt(int pLocID, int pCompID, DateTime pDateAsAt)
        {
            decimal renperSqFt = 0;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    DateTime dateFrom = new DateTime(pDateAsAt.Year, pDateAsAt.Month, 1);
                    DateTime dateTo = dateFrom.AddMonths(1).AddDays(-1).Date;

                    int month = pDateAsAt.Date.Month;
                    int year = pDateAsAt.Date.Year;
                    List<decimal> total = new List<decimal>();

                    decimal rentPerMonthTotal = 0;
                    var qryRentperSqFt = (from i in context.Invoices       
                                          join tr in context.TaxRates on i.MandatoryTaxRateID equals tr.TaxRateID
                                          where i.IsConfirmed == true && i.CompanyID == pCompID && i.LocationID == pLocID && i.InvoiceTypeID == 1 &&  (i.SAP_PstnDateInDoc >=dateFrom && i.SAP_PstnDateInDoc <=dateTo)
                                          select new { i.RentPerMonth,tr.TaxRate1}).ToList();
                    foreach (var qry in qryRentperSqFt)
                    {
                        total.Add(qry.RentPerMonth * ((100+qry.TaxRate1)/100));
                    }


                    rentPerMonthTotal = total.Sum();

                    //total occupied area 
                    decimal totalOccupied = CustomClasses.cCommon_Functions.MisShopOccupancy_Summmary(pLocID, pDateAsAt);
                    //--


                    if (rentPerMonthTotal > 0 && totalOccupied > 0)
                    {
                        renperSqFt = Math.Round(rentPerMonthTotal / totalOccupied, 2);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return renperSqFt; 
        }

      

       

       

  

        private decimal getOccupancy(int pLocID, int pCompID, DateTime pDateAsAt)
        {
            decimal occupancy = 0;

            // total area 

            decimal occTotal = getOccupied(pLocID, pCompID, pDateAsAt);
            decimal locTotal = getTotalArea(pLocID, pDateAsAt);

            if (occTotal > 0 && locTotal > 0)
            {
                occupancy = Math.Round(occTotal / locTotal, 2) * 100;
            }

            return occupancy;
        }

        private decimal getOccupied(int pLocID, int pCompID, DateTime pDateAsAt)
        {
            decimal occupied = 0;

            // total area 
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                decimal occupiedTotal = 0;
                DateTime dateFrom = pDateAsAt.AddMonths(-1).AddDays(1);
                ////for active shop details
                List<decimal> totalList= new List<decimal>();
                var qryShopOccupied1 = (from s in context.Shops
                                        join sd in context.Shop_Details on s.ShopID equals sd.ShopID
                                        join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                        where s.CompanyID == pCompID && s.LocationID == pLocID && ra.IsAdvertisement == false && s.SqFeet > 1 && sd.ActiveFrom >= dateFrom && sd.ActiveFrom <= pDateAsAt && s.CustomerID > 0
                                        select new { s.SqFeet }).ToList();
                if (qryShopOccupied1.Count > 0)
                {


                    foreach (var qry in qryShopOccupied1)
                    {
                        totalList.Add(qry.SqFeet);

                    }



                  

                    //occupiedTotal = qryShopOccupied;
                }
              
                ///---
                occupiedTotal = totalList.Sum();

                occupied = occupiedTotal;

            }

            return occupied;
        }

        private decimal getUnoccupied(int pLocID, int pCompID, DateTime pDateAsAt)
        {
            decimal unoccupied = 0;

            // total area 
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                decimal occupiedTotal = 0;
                ////for active shop details

                List<decimal> total = new List<decimal>();

                var qryShopOccupied1 = (from s in context.Shops
                                        join sd in context.Shop_Details on s.ShopID equals sd.ShopID
                                        join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                        where s.CompanyID == pCompID && s.LocationID == pLocID && ra.IsAdvertisement == false && s.SqFeet > 1 && sd.ActiveFrom.Month == pDateAsAt.Month && sd.ActiveFrom.Year == pDateAsAt.Year && s.CustomerID > 0
                                        select new { s.SqFeet }).ToList();
                foreach (var qry in qryShopOccupied1)
                {
                    total.Add(qry.SqFeet);

                }

                occupiedTotal = total.Sum() ;



                decimal loctotal = this.getTotalArea(pLocID, pDateAsAt);

                 
                unoccupied = loctotal - occupiedTotal;

            }

            return unoccupied;


        }

        private decimal getTotalArea(int pLocID, DateTime pDateAsAt)
        {
            decimal totalarea = 0;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                decimal loctotal = 0;
                List<decimal> totalList = new List<decimal>();

                DateTime fromdate = pDateAsAt.AddMonths(-1).AddDays(1).Date;


                var qryLocTotal1 = (from l in context.Locations
                                    join ld in context.Location_Details on l.LocationID equals ld.LocationID
                                    where l.LocationID == pLocID && ld.ActiveFrom.Month == pDateAsAt.Month && ld.ActiveFrom.Year == pDateAsAt.Year
                                    select new { ld.SqFeet, ld.IsActive }).AsEnumerable().LastOrDefault();
                if (qryLocTotal1 != null)
                {

                    loctotal = qryLocTotal1.SqFeet;
                }

                //if (qryLocTotal1.Count > 0)
                //{
                //    foreach (var qry in qryLocTotal1) 
                //    {
                //        totalList.Add(qry.SqFeet);
                //    }

                //    loctotal = totalList.Average();
                totalarea = loctotal;
                //}

 
            }

            return totalarea;
        }

        private void locationIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            load_month();

        }

        private void load_month()
        {
            try
            {
                if (string.IsNullOrEmpty(this.locationIDLookUpEdit.Text.ToString()) || string.IsNullOrEmpty(this.companyIDLookUpEdit.Text.ToString()))
                { return; }

                int locid = int.Parse(this.locationIDLookUpEdit.EditValue.ToString());
                int compid = int.Parse(this.companyIDLookUpEdit.EditValue.ToString());
                lookMonthYear.EditValue = 0;
                finyearList.Clear();
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryDet = (from d in context.FinancialYear_Details
                                  join m in context.Months on d.MonthID equals m.MonthID
                                  join f in context.Financial_Years on d.FinancialYearID equals f.FinancialYearID
                                  orderby d.CurrentYear, d.MonthID
                                  where f.IsActive == true && f.CompanyID == compid && f.LocationID ==locid 
                                  select new { d.FinancialYearDetailID, m.MonthCode, d.CurrentYear }).ToList();
                    foreach (var qry in qryDet)
                    {
                        cFinYearDet finyearObj = new cFinYearDet();
                        finyearObj.FinancialYearDetailID = qry.FinancialYearDetailID;
                        finyearObj.YearMonth = qry.MonthCode.ToString() + " " + qry.CurrentYear.ToString();
                        finyearList.Add(finyearObj);
                    }

                    lookMonthYear.Properties.DataSource = finyearList;
                    lookMonthYear.Properties.DisplayMember = "YearMonth";
                    lookMonthYear.Properties.ValueMember = "FinancialYearDetailID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void companyIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            load_month();

            //// Location..roshan..06oct2014
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                int comid = 0;
                bool res = false;
                res = int.TryParse(companyIDLookUpEdit.EditValue.ToString(), out comid);
                if (res.Equals(true))
                {
                    var qryLoc = (from c in context.Companies
                                  join l in context.Locations on c.LocationID equals l.LocationID
                                  where c.CompanyID == comid
                                  select new { l.LocationID, l.LocationCode }).ToList();

                    this.locationIDLookUpEdit.Properties.DataSource = qryLoc;
                    this.locationIDLookUpEdit.Properties.DisplayMember = "LocationCode";
                    this.locationIDLookUpEdit.Properties.ValueMember = "LocationID";
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {          

            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Generating Report"); }
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryComp = (from c in context.Companies
                                   select new { c.CompanyID, c.CompanyName }).ToList();

                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationName }).ToList();

                    var qryreportItem = (from r in context.MisReportItems
                                         select new { r.ReportItemID, r.ReportItemName }).ToList();

                    var qrySC = (from p in perfomDetList
                                 where p.ReportItemID == 6
                                 select p).FirstOrDefault();
             

                    var qryOS = (from os in context.OtherServiceCategories
                                 select new { os.OtherServiceID, os.OtherServiceName }).ToList();


                    rptMain _main = new rptMain();

                    DataTier.Reports.MIS.rptSalesAndPerformance salesP = new DataTier.Reports.MIS.rptSalesAndPerformance();
                   
                    _main.crystalReportViewer1.ReportSource = salesP;
                    
                    salesP.Database.Tables["DataTier_ReportClasses_PerformanceDetails"].SetDataSource(perfomDetList);
                    salesP.Database.Tables["DataTier_Company"].SetDataSource(qryComp);
                    salesP.Database.Tables["DataTier_Location"].SetDataSource(qryLoc);
                    salesP.Database.Tables["DataTier_MisReportItem"].SetDataSource(qryreportItem);


                    salesP.Subreports[0].Database.Tables["DataTier_OtherServiceCategory"].SetDataSource(qryOS);
                    salesP.Subreports[0].Database.Tables["DataTier_ReportClasses_PerformanceDetail_OSIncome"].SetDataSource(osList);

                    salesP.SetParameterValue("B_M", this.gridView1.Columns[6].Caption);
                    salesP.SetParameterValue("R_M", this.gridView1.Columns["ReforecastingValueM"].Caption);
                    salesP.SetParameterValue("A_M", this.gridView1.Columns[7].Caption);
                    salesP.SetParameterValue("B_Y", this.gridView1.Columns["BudgetValueYTD"].Caption);
                    salesP.SetParameterValue("R_Y", this.gridView1.Columns["ReforecastingValueYTD"].Caption);
                    salesP.SetParameterValue("A_Y", this.gridView1.Columns[9].Caption);
                    salesP.SetParameterValue("L_Y", this.gridView1.Columns[10].Caption);
                    salesP.SetParameterValue("pSC", qrySC.ActualValueYTD);
                    salesP.SetParameterValue("pIsBudget", IsBudget);

                    salesP.SetParameterValue("LastMonthYear", this.gridView1.Columns[10].Caption);
                    salesP.SetParameterValue("CurrentMonthYear", this.lookMonthYear.Text.ToString().Trim());
                    //salesP.Subreports["OtherServiceIncome"].SetParameterValue("CurrentMonthYear", this.lookMonthYear.Text.ToString().Trim());
                    salesP.SetParameterValue("currentMonthYear", this.lookMonthYear.Text.ToString().Trim(), salesP.Subreports[0].Name.ToString());
                    _main.Show(this);

                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }


                }



            }

            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lookMonthYear_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCN = (from i in context.Invoices
                             where i.SubInvTypeID == 2
                             select i).ToList();
                foreach (var qry in qryCN)
                {
                    if (qry.RentPerSqFt > 0)
                    {
                        qry.RentPerSqFt = qry.RentPerSqFt * -1;
                    }

                    if (qry.SCPerSqFt > 0)
                    {
                        qry.SCPerSqFt = qry.SCPerSqFt * -1;
                    }
                    if (qry.RentPerMonth > 0)
                    {
                        qry.RentPerMonth = qry.RentPerMonth * -1;
                    }

                    if (qry.SCPerMonth > 0)
                    {
                        qry.SCPerMonth = qry.SCPerMonth * -1;
                    }

                    if (qry.RentWIthSCPerSqFt > 0)
                    {
                        qry.RentWIthSCPerSqFt = qry.RentWIthSCPerSqFt * -1;
                    }

                    if (qry.TotalAmount > 0)
                    {
                        qry.TotalAmount = qry.TotalAmount * -1;
                    }

                    if (qry.TotalTax > 0)
                    {
                        qry.TotalTax = qry.TotalTax * -1;
                    }

                    if (qry.OtherTax > 0)
                    {
                        qry.OtherTax = qry.OtherTax * -1;
                    }
                    if (qry.RentWithSCPerMonth > 0)
                    {
                        qry.RentWithSCPerMonth = qry.RentWithSCPerMonth * -1;
                    }
                    if (qry.MandatoryTaxAmount > 0)
                    {
                        qry.MandatoryTaxAmount = qry.MandatoryTaxAmount * -1;
                    }
                    if (qry.TotalWithMandatoryTax > 0)
                    {
                        qry.TotalWithMandatoryTax = qry.TotalWithMandatoryTax * -1;
                    }
                    if (qry.TotalRentPerMonth > 0)
                    {
                        qry.TotalRentPerMonth = qry.TotalRentPerMonth * -1;
                    }

                    var qryDet = qry.Invoice_Details.ToList();
                    foreach (var qryD in qryDet)
                    {
                        if (qryD.Amount > 0)
                        {
                            qryD.Amount = qryD.Amount * -1;
                        }                     
                    }
                }

                int num = context.SaveChanges();
                if (num > 0)
                {

                    MessageBox.Show("saved");
                }

            }


        }


    }

    public class cFinYearDet
    {
        public int FinancialYearDetailID { get; set; }
        public string YearMonth { get; set; }        
    }

    //public class cFinYearDetB
    //{
    //    public int ReportItemID { get; set; }



    //}


}