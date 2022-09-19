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
    public partial class xPerformanceDetails : DevExpress.XtraEditors.XtraForm
    {
        public xPerformanceDetails()
        {
            InitializeComponent();
        }

        List<MISPerformanceDetail> prfmDetList = new List<MISPerformanceDetail>();
        AHPL_DBEntities context = new AHPL_DBEntities();
        private void xPerformanceDetails_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryMonth = (from m in context.Months
                                    select new { m.MonthID, m.MonthCode }).ToList();
                    this.lookMonthID.DataSource = qryMonth;
                    this.lookMonthID.DisplayMember = "MonthCode";
                    this.lookMonthID.ValueMember = "MonthID";

                    var qryFinYearDet = (from f in context.FinancialYear_Details                                       
                                         select f).ToList();
                    this.financialYear_DetailsBindingSource.DataSource = qryFinYearDet;

                     //finyear 
                    var qryFinYear = (from f in context.Financial_Years
                                      select new { f.FinancialYearID, f.Financial_Year }).ToList();
                    this.lookFinYear.DataSource = qryFinYear;
                    this.lookFinYear.DisplayMember = "Financial_Year";
                    this.lookFinYear.ValueMember = "FinancialYearID";

                    var qryItem = (from r in context.MisReportItems
                                   select new { r.ReportItemID, r.ReportItemName }).ToList();
                    this.lookItemID.DataSource = qryItem;
                    this.lookItemID.DisplayMember = "ReportItemName";
                    this.lookItemID.ValueMember = "ReportItemID";

                    var qryComp = (from c in context.Companies
                                   select new { c.CompanyID, c.CompanyCode }).ToList();
                    this.lookCompany.DataSource = qryComp;
                    this.lookCompany.DisplayMember = "CompanyCode";
                    this.lookCompany.ValueMember = "CompanyID";

                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode }).ToList();
                    this.lookLocation.DataSource = qryLoc;
                    this.lookLocation.DataSource = qryLoc;
                    this.lookLocation.DisplayMember = "LocationCode";
                    this.lookLocation.ValueMember = "LocationID";


                    this.mISPerformanceDetailBindingSource.DataSource = prfmDetList;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        private void financialYear_DetailsBindingSource_PositionChanged(object sender, EventArgs e)
        {
            
        }

        

        //private void cmdEdit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    //this.enable_control(true, eRecStatus.eEdit);
        //}

        private void financialYear_DetailsBindingSource_PositionChanged_1(object sender, EventArgs e)
        {
            try
            {

                FinancialYear_Details finyrDet = (FinancialYear_Details)this.financialYear_DetailsBindingSource.Current;
                if (finyrDet == null)
                { return; }

                // if existing item 

                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qrydet = (from p in context.MISPerformanceDetails
                                  where p.FinancialYearDetailID == finyrDet.FinancialYearDetailID
                                  select p).ToList();

                    if (qrydet.Count > 0)
                    {
                        //foreach (var qry in qrydet)
                        {
                            prfmDetList = (from d in context.MISPerformanceDetails
                                           where d.FinancialYearDetailID == finyrDet.FinancialYearDetailID
                                           select d).ToList();

                            //prfmDetList = qryPerDet;

                            //this.mISPerformanceDetailBindingSource.DataSource = qryPerDet;
                        }

                    }
                    else
                    {
                        var qryItem = (from i in context.MisReportItems
                                       select i).ToList();
                        //mISPerformanceDetailBindingSource.Clear();
                        prfmDetList.Clear();
                        foreach (var qry in qryItem)
                        {
                            MISPerformanceDetail detobj = new MISPerformanceDetail();
                            detobj.FinancialYearDetailID = finyrDet.FinancialYearDetailID;
                            detobj.ReportItemID = qry.ReportItemID;
                            prfmDetList.Add(detobj);
                            //mISPerformanceDetailBindingSource.Add(detobj);

                        }

                    }
                    this.mISPerformanceDetailBindingSource.DataSource = prfmDetList;
                    this.mISPerformanceDetailGridControl.RefreshDataSource();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    FinancialYear_Details finyearDet = (FinancialYear_Details)this.financialYear_DetailsBindingSource.Current;
                    if (finyearDet == null) { return; }

                    var qryFinYear = (from f in context.FinancialYear_Details
                                      join d in context.Financial_Years on f.FinancialYearID equals d.FinancialYearID
                                      where f.FinancialYearDetailID == finyearDet.FinancialYearDetailID
                                      select new { d.CompanyID, d.LocationID }).FirstOrDefault();
                    int CompID = 0;
                    int LocID = 0;
                    if (qryFinYear != null)
                    {
                        CompID = qryFinYear.CompanyID;
                        LocID = qryFinYear.LocationID;
                    }


                    var qryPrfmDet = (from p in context.MISPerformanceDetails
                                      where p.FinancialYearDetailID == finyearDet.FinancialYearDetailID
                                      select p).ToList();



                    if (qryPrfmDet.Count == 0)
                    {

                        foreach (var qry in prfmDetList)
                        {
                            MISPerformanceDetail misDet = new MISPerformanceDetail();
                            misDet.ReforecastingValue = qry.ReforecastingValue;
                            misDet.BudgetValue = qry.BudgetValue;
                            misDet.ReportItemID = qry.ReportItemID;
                            misDet.FinancialYearDetailID = qry.FinancialYearDetailID;
                            misDet.CompanyID = CompID;
                            misDet.LocationID = LocID;
                            context.MISPerformanceDetails.AddObject(misDet);

                        }
                    }
                    else
                    {

                        foreach (var qry in prfmDetList)
                        {

                            var qryPerDetEdit = (from p in context.MISPerformanceDetails
                                                 where p.FinancialYearDetailID == qry.FinancialYearDetailID && p.ReportItemID == qry.ReportItemID
                                                 select p).FirstOrDefault();

                            if (qryPerDetEdit != null)
                            {
                                qryPerDetEdit.ReforecastingValue = qry.ReforecastingValue;
                                qryPerDetEdit.BudgetValue = qry.BudgetValue;
                                qryPerDetEdit.LocationID = LocID;
                                qryPerDetEdit.CompanyID = CompID;
                            }
                        }

                    }


                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Saved Successfully...", "Save Success - Performance Detail Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    //this.enable_control(false, eRecStatus.eSave);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

       
        
    }

    public class cFinancialYear
    {
        //public int financialYearID { get; set; }
        //public int financialYear { get; set; }
        //public string 

    }


}