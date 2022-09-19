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
    public partial class xMisRentalIncome : DevExpress.XtraEditors.XtraForm
    {
        List<ShopOccupancy> ShopOccupancyList = new List<ShopOccupancy>();

        public xMisRentalIncome()
        {
            InitializeComponent();
        }

        private void xMisRentalIncome_Load(object sender, EventArgs e)
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


                    this.dateEditDate.DateTime = DateTime.Now.Date;


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

                int compid = int.Parse(this.lookCompany.EditValue.ToString());
                int locid = int.Parse(this.lookCompany.EditValue.ToString());

                if (compid == 0 || locid == 0)
                {
                    return;
                }

                int extendedCustID = 0;

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryExceptionCust = (from m in context.MisReportItems
                                            where m.ReportItemID == 8
                                            select m).FirstOrDefault();
                    if (qryExceptionCust != null)
                    {
                        if (qryExceptionCust.ExceptionItem == 0)
                        {
                            throw new Exception("Please Setup the Exceptional Customer");
                        }
                        else
                        {
                            extendedCustID = qryExceptionCust.ExceptionItem.Value;
                        }
                    }

                }

                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

                DateTime currentDate = this.dateEditDate.DateTime.Date;

                ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisRentalIncome(compid, locid, currentDate,extendedCustID,splashScreenManager1);
                shopOccupancyBindingSource.DataSource = ShopOccupancyList;

                //format_grid();
                this.gridView1.BestFitColumns();
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void format_grid()
        {
            throw new NotImplementedException();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                { MessageBox.Show("Company is Empty"); return; }
                if (string.IsNullOrEmpty(this.lookLocaiton.Text.ToString()))
                { MessageBox.Show("Location is Empty"); return; }
                if (string.IsNullOrEmpty(this.dateEditDate.Text.ToString()))
                { MessageBox.Show("Date is Empty"); return; }


                int compid = int.Parse(this.lookCompany.EditValue.ToString());
                int locid = int.Parse(this.lookCompany.EditValue.ToString());
                DateTime date = dateEditDate.DateTime.Date;

                int extendedCustID = 0;
                string exceptionItem = "";



                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }

                rptMain reportMain = new rptMain();
                DataTier.Reports.MIS.rptRentalIncome rentalIncome = new DataTier.Reports.MIS.rptRentalIncome();
                reportMain.crystalReportViewer1.ReportSource = rentalIncome;

                rentalIncome.Database.Tables["DataTier_ReportClasses_ShopOccupancy"].SetDataSource(ShopOccupancyList);

                /// With/Without 
                /// 

                //Total Square Feet 

                decimal totalOccSqFt = 0;
                //total squafeet 

                decimal totalSquareFeet = 0;

                string pMTax = "";
                string pOtherTax = "";

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryExceptionCust = (from m in context.MisReportItems
                                            where m.ReportItemID == 8
                                            select m).FirstOrDefault();
                    if (qryExceptionCust != null)
                    {
                        extendedCustID = qryExceptionCust.ExceptionItem.Value;
                        exceptionItem = qryExceptionCust.ReportItemName;
                    }



                    totalOccSqFt = MMS.CustomClasses.cCommon_Functions.MisShopOccupancy_Summmary(locid, date);



                    totalSquareFeet = MMS.CustomClasses.cCommon_Functions.getTotalSqFtInLocation(compid, locid, date);

                    // mandatory tax 
                    var qryMT = (from m in context.Taxes
                                 where m.IsMandatory == true
                                 select new { m.TaxCode }).ToList();
                    if (qryMT.Count == 1)
                    {

                        pMTax = qryMT.FirstOrDefault().TaxCode;
                    }
                    if (qryMT.Count > 1)
                    {
                        int count = 0;
                        foreach (var qry in qryMT)
                        {
                            if (count == 0)
                            {
                                pMTax = qry.TaxCode;
                            }
                            if (count > 0)
                            {
                                pMTax = pMTax + " + " + qry.TaxCode;
                            }

                            count++;
                        }

                    }
                    //--

                    //Other Tax 
                    var qryOT = (from t in context.Taxes
                                 where t.IsMandatory == false
                                 select new { t.TaxCode }).ToList();
                    if (qryOT.Count == 1)
                    {
                        pOtherTax = qryOT.FirstOrDefault().TaxCode;
                    }
                    if (qryOT.Count > 1)
                    {
                        int count = 0;
                        foreach (var qry in qryOT)
                        {
                            if (count == 0)
                            {
                                pOtherTax = qry.TaxCode;
                            }
                            if (count > 0)
                            {
                                pOtherTax = pOtherTax + " + " + qry.TaxCode;
                            }
                        }

                    }

                }

                decimal occupancy = Math.Round((totalOccSqFt / totalSquareFeet) * 100,2);
                decimal rentpermonth = Math.Round(CustomClasses.cCommon_Functions.getRentperMonth(locid, compid, date),2);
                decimal scpermonth = Math.Round(CustomClasses.cCommon_Functions.getSCperMonth(locid, compid, date),2);
                decimal rentpersqft = Math.Round(rentpermonth / totalOccSqFt,2);
                decimal scpersqft = Math.Round(scpermonth / totalOccSqFt,2);
                decimal totalrentwithscsqft = rentpersqft + scpersqft;
                decimal rentpersqftWithoutKeells = CustomClasses.cCommon_Functions.getRentperSqFtWithout(locid, compid, date, extendedCustID,totalOccSqFt,rentpermonth);

               
                string pOccupancy = "Occupancy in " + lookCompany.Text.ToString() + " (%) : " + occupancy.ToString().Trim();
                string pRentWithut = exceptionItem + "  (Rs.) : " + rentpersqftWithoutKeells.ToString();
                string pRentWith = "Rent/Sq.Ft ( Rs.) : " +  rentpersqft.ToString();
                string pTotal = "Total  Rent & SC / Sq.Ft (Rs.) : " + totalrentwithscsqft.ToString();
                string pSC = "SC/Sq.Ft (Rs.) : " + scpersqft.ToString();
                
                rentalIncome.SetParameterValue("pOccupancy", pOccupancy);
                rentalIncome.SetParameterValue("pRentWithoutCust", pRentWithut);
                rentalIncome.SetParameterValue("pRentWithCust", pRentWith);
                rentalIncome.SetParameterValue("pSC", pSC);

                rentalIncome.SetParameterValue("pTotal", pTotal);

                /// month  
                int month = dateEditDate.DateTime.Date.Month;
                var dtf = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
                string monthName = dtf.GetMonthName(month);
                string abbrvation = dtf.GetAbbreviatedMonthName(month);
                ///--

                string pMonthYear = monthName + " - " + this.dateEditDate.DateTime.Year.ToString();
                rentalIncome.SetParameterValue("pMonthYear", pMonthYear);
                rentalIncome.SetParameterValue("pMTax", pMTax);
                rentalIncome.SetParameterValue("pOtherT", pOtherTax);
                string pTotalWithM = "Total + " + pMTax;
                rentalIncome.SetParameterValue("pTotalWithM", pTotalWithM);

                


                reportMain.Show(this);


                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
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
                    //var qryCust = (from ec in context.Extended_Customers
                    //               join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                    //               where ec.CompanyID == compid && ec.LocationID == locid
                    //               select new { ec.ExtendedCustomerID, gc.CustomerName }).ToList();

                    //this.lookCustomer.Properties.DataSource = qryCust;
                    //this.lookCustomer.Properties.DisplayMember = "CustomerName";
                    //this.lookCustomer.Properties.ValueMember = "ExtendedCustomerID";



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

        private void lookCustomer_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}