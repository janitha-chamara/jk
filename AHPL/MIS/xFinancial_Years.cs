using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Expressions;
using DataTier;

namespace MMS.MIS
{
    public partial class xFinancial_Years : ParentForm.xParentDefault
    {
        public xFinancial_Years()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void xFinancial_Years_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryFinYear = (from f in context.Financial_Years
                                      select f).ToList() ;
                    this.financial_YearsBindingSource.DataSource = qryFinYear;


                    var qryMisP = (from p in context.MISPerformanceDetails
                                   select p).ToList();
                    this.mISPerformanceDetailsBindingSource.DataSource = qryMisP;


                    var qryMonth = (from m in context.Months
                                    select new { m.MonthID, m.MonthCode }).ToList();
                    this.lookMonthID.DataSource = qryMonth;
                    this.lookMonthID.DisplayMember = "MonthCode";
                    this.lookMonthID.ValueMember = "MonthID";

                    
                    //company
                    var qryComp = (from c in context.Companies
                                   select new { c.CompanyID, c.CompanyCode }).ToList();

                     this.lookCompany.DataSource = this.companyIDLookUpEdit.Properties.DataSource = qryComp;
                     this.lookCompany.DisplayMember=  this.companyIDLookUpEdit.Properties.DisplayMember = "CompanyCode";
                      this.lookCompany.ValueMember=  this.companyIDLookUpEdit.Properties.ValueMember = "CompanyID";

                    //location
                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode }).ToList();
                   this.lookLocation.DataSource =  this.locationIDLookUpEdit.Properties.DataSource = qryLoc;
                   this.lookLocation.DisplayMember= this.locationIDLookUpEdit.Properties.DisplayMember = "LocationCode";
                   this.lookLocation.ValueMember= this.locationIDLookUpEdit.Properties.ValueMember = "LocationID";
                    //--

                    this.enable_control(false, eRecStatus.eInit);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            financial_YearsBindingSource.MoveFirst();
        }

        private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            financial_YearsBindingSource.MovePrevious();
        }

        private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            financial_YearsBindingSource.MoveNext();
        }

        private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            financial_YearsBindingSource.MoveLast();
        }

        private void cmdUndo_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            financial_YearsBindingSource.CancelEdit();
            load_data();

        }

        private void cmdRefresh_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            load_data();
        }

        private void cmdSave_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {

            try
            {
                //check for field validation
                //financial year
                this.financial_YearsBindingSource.EndEdit();
                if (string.IsNullOrEmpty(this.financial_YearSpinEdit.Text.ToString()))
                { dxErrorProvider1.SetError(this.financial_YearSpinEdit, "Invalid Year"); return; }
                else { dxErrorProvider1.SetError(this.financial_YearSpinEdit, ""); }

                if (string.IsNullOrEmpty(this.fromDateDateEdit.Text.ToString()))
                { dxErrorProvider1.SetError(this.fromDateDateEdit, "Invalid From Date"); return; }
                else { dxErrorProvider1.SetError(this.fromDateDateEdit, ""); }

                if (string.IsNullOrEmpty(this.toDateDateEdit.Text.ToString()))
                { dxErrorProvider1.SetError(this.toDateDateEdit, "Invalid To Date"); return; }
                else { dxErrorProvider1.SetError(this.toDateDateEdit, ""); }

                if (string.IsNullOrEmpty(this.companyIDLookUpEdit.Text.ToString()))
                { dxErrorProvider1.SetError(this.companyIDLookUpEdit, "Invalid Company"); return; }
                else { dxErrorProvider1.SetError(this.companyIDLookUpEdit, ""); }

                if (string.IsNullOrEmpty(this.locationIDLookUpEdit.Text.ToString()))
                { dxErrorProvider1.SetError(this.locationIDLookUpEdit, "Invalid Location"); return; }
                else { dxErrorProvider1.SetError(this.locationIDLookUpEdit, "");  }
            
           


                if (string.IsNullOrEmpty(this.financial_YearSpinEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.financial_YearSpinEdit, "Invalid Financial Year");
                    return;
                }
                else { dxErrorProvider1.SetError(this.financial_YearSpinEdit, ""); }

                // from date
                if (string.IsNullOrEmpty(this.fromDateDateEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.fromDateDateEdit, "Invalid From Date");
                    return;
                }
                else { dxErrorProvider1.SetError(this.fromDateDateEdit, ""); }

                //--
                
                // todate 
                if (string.IsNullOrEmpty(this.toDateDateEdit.Text.ToString()))
                { dxErrorProvider1.SetError(this.toDateDateEdit, "Invalid To Date"); return; }
                else { dxErrorProvider1.SetError(this.toDateDateEdit, ""); }
                
                Financial_Years finyearObj = (Financial_Years)this.financial_YearsBindingSource.Current;
                if (finyearObj == null) { return; }

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    if (finyearObj.FinancialYearID == 0) // add new status
                    {
                        //check for duplicate 
                        var qryduplicate = (from f in context.Financial_Years
                                            where f.Financial_Year == finyearObj.Financial_Year && f.LocationID == finyearObj.LocationID && f.CompanyID ==finyearObj.CompanyID
                                            select f).ToList();
                        if (qryduplicate.Count > 0)
                        {
                            throw new Exception("Financial Year '" + finyearObj.Financial_Year + "' already exist");
                        }

                        var qryInactivete = (from f in context.Financial_Years
                                             where f.FinancialYearID != finyearObj.FinancialYearID && f.CompanyID == finyearObj.CompanyID && f.LocationID == finyearObj.LocationID
                                             select f).ToList();
                        foreach (var qry in qryInactivete)
                        {
                            qry.IsActive = false;
                        }
                                             

                        context.Financial_Years.AddObject(finyearObj);

                    }
                    else
                    {
                        var qryFinYear = (from f in context.Financial_Years
                                          where f.FinancialYearID == finyearObj.FinancialYearID
                                          select f).FirstOrDefault();
                        qryFinYear.FromDate = finyearObj.FromDate;
                        qryFinYear.ToDate = finyearObj.ToDate;
                        qryFinYear.LocationID = finyearObj.LocationID;
                        qryFinYear.CompanyID = finyearObj.CompanyID;
                        qryFinYear.IsActive = finyearObj.IsActive;
                       


                        //context.Financial_Years.ApplyCurrentValues(finyearObj);

                    }

                  

                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Saved Successfully...", "Save Success - Financial Year", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    load_data();

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdEdit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.enable_control(true, eRecStatus.eEdit);
        }

        private void toDateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.toDateDateEdit.Text.ToString()))
            { return;}

            load_contents();

           
        }

        private void load_contents()
        {
            try
            {

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    Financial_Years finyearObj = (Financial_Years)this.financial_YearsBindingSource.Current;
                    if (finyearObj.FinancialYearID == 0) // add new status 
                    {
                        if (string.IsNullOrEmpty(fromDateDateEdit.Text.ToString()) || string.IsNullOrEmpty(this.toDateDateEdit.Text.ToString()))
                        { throw new Exception("Invalid From-Date or To-Date"); }

                        DateTime fromdate = fromDateDateEdit.DateTime.Date;
                        DateTime todate = toDateDateEdit.DateTime.Date;
                        //validate from date
                        if (fromdate == DateTime.MinValue)
                        { dxErrorProvider1.SetError(this.fromDateDateEdit, "Invalid Date"); return; }
                        else { dxErrorProvider1.SetError(this.fromDateDateEdit, ""); }

                        // validate to date
                        if (todate == DateTime.MinValue)
                        { dxErrorProvider1.SetError(this.toDateDateEdit, "Invalid Date"); return; }
                        else { dxErrorProvider1.SetError(this.toDateDateEdit, ""); }


                        int monthNos = (todate.Month - fromdate.Month) + 12 * (todate.Year - fromdate.Year);

                        if (finyearObj.FinancialYear_Details.Count > 0)
                        { return; }

                        for (int i = 0; i <= monthNos; i++)
                        {
                            FinancialYear_Details finyearDet = new FinancialYear_Details();
                            finyearDet.CurrentYear = fromdate.AddMonths(i).Year;
                            finyearDet.MonthID = fromdate.AddMonths(i).Month;
                            finyearDet.CompanyID = int.Parse(companyIDLookUpEdit.EditValue.ToString());
                            finyearDet.LocationID = int.Parse(locationIDLookUpEdit.EditValue.ToString());
                            finyearObj.FinancialYear_Details.Add(finyearDet);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmdNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.enable_control(true, eRecStatus.eAddNew);
            financial_YearsBindingSource.AddNew();
            Financial_Years finyear = (Financial_Years)this.financial_YearsBindingSource.Current;
            finyear.IsActive = true;


            finyear.Financial_Year = DateTime.Now.Year;

            //financial_YearSpinEdit.EditValue = DateTime.Now.Year;





        }

        private void financial_YearSpinEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void fromDateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.fromDateDateEdit.Text.ToString()))
            { return; }

            DateTime from = fromDateDateEdit.DateTime.Date;
            DateTime to = DateTime.Now.Date ;
            for (int i = 0; i <= 12; i++)
            {
                to = from.AddMonths(i);

            }

            DateTime todate = to.AddDays(-1).Date;

            this.toDateDateEdit.DateTime = todate;

            Financial_Years finyear = (Financial_Years)this.financial_YearsBindingSource.Current;
            finyear.FromDate = from;
            finyear.ToDate = todate;

        }

        private void locationIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void companyIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
