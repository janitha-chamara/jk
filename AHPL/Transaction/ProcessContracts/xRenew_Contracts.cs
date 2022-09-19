using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using System.Data.Linq.SqlClient;
using DataTier;
using DataTier.Reports;
namespace MMS
{
    public partial class xRenew_Contracts : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        //List<Contract_TaxRates> oldcontTaxRateList = new List<Contract_TaxRates>();
        //List<Contract_TaxRates> newcontTaxRateList = new List<Contract_TaxRates>();
        bool IsFilled = false;

        public xRenew_Contracts()
        {
            InitializeComponent();
        }

        

        //private void cmdNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    ClearText();
        //    this.enable_control(true, eRecStatus.eAddNew);

        //}

        //private void cmdUndo_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{
        //    this.ClearText();
        //    this.enable_control(false, eRecStatus.eInit);

        //}

       

        private void xRenew_Contracts_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            // contracts
            var qryContract = (from c in context.Contracts
                               join exc in context.Extended_Customers on c.CustomerID equals exc.ExtendedCustomerID
                               join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                               join loc in context.Locations on c.LocationID equals loc.LocationID
                               join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
                               join cshop in context.Contract_Shops on c.ContractID equals cshop.ContractID
                               join shop in context.Shops on cshop.ShopID equals shop.ShopID
                               join crate in context.Contract_Rates on c.ContractID equals crate.ContractID
                               join comp in context.Companies on c.CompanyID equals comp.CompanyID 
                               where crate.IsActive == true
                               select new { c.ContractID, c.ShopName, gcus.CustomerName, loc.LocationCode, lvl.LevelCode, shop.ShopNo ,comp.CompanyCode}).ToList();
            
            this.searchLookUpEditContractID.Properties.DataSource = qryContract;
            this.searchLookUpEditContractID.Properties.DisplayMember = "ShopName";
            this.searchLookUpEditContractID.Properties.ValueMember = "ContractID";

            // location
            this.lookUpEditLocationID.Properties.DataSource = (from l in context.Locations
                                                               select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
            this.lookUpEditLocationID.Properties.DisplayMember = "LocationCode";
            this.lookUpEditLocationID.Properties.ValueMember = "LocationID";


            // customer 
            this.lookUpEditCustomerID.Properties.DataSource = (from exc in context.Extended_Customers
                                                               join gcust in context.Global_Customers on exc.CustomerID equals gcust.CustomerID
                                                               select new { exc.ExtendedCustomerID, gcust.CustomerName }).ToList();
            this.lookUpEditCustomerID.Properties.DisplayMember = "CustomerName";
            this.lookUpEditCustomerID.Properties.ValueMember = "ExtendedCustomerID";

            // level 
            this.lookUpEditLevelID.Properties.DataSource = (from l in context.Floor_Levels
                                                            select new { l.LevelID, l.LevelCode }).ToList();
            this.lookUpEditLevelID.Properties.DisplayMember = "LevelCode";
            this.lookUpEditLevelID.Properties.ValueMember = "LevelID";

            // shops 
            //this.chkShops.Properties.DataSource = (from s in context.Shops
            //                                       select new { s.ShopID, s.ShopNo }).ToList();
            //this.chkShops.Properties.DisplayMember = "ShopNo";
            //this.chkShops.Properties.ValueMember = "ShopID";

            // company 
            this.lookUpEditCompanyID.Properties.DataSource = (from c in context.Companies
                                                              select new { c.CompanyID, c.CompanyCode }).ToList();

            this.lookUpEditCompanyID.Properties.DisplayMember = "CompanyCode";
            this.lookUpEditCompanyID.Properties.ValueMember = "CompanyID";


            // New Contract Tax Rates         
            //this.bsContractTaxRate_New.DataSource = newcontTaxRateList;
            this.gridControl1.DataSource = bsContractTaxRate_New;

            // Old contract tax rates
            //this.contract_TaxRatesBindingSource.DataSource = oldcontTaxRateList;
            //this.contract_TaxRatesGridControl.DataSource = oldcontTaxRateList;

            //tax
            this.taxBindingSource.DataSource = (from t in context.Taxes
                                                select new { t.TaxID, t.TaxCode }).ToList();
            //tax rates 
            this.taxRateBindingSource.DataSource = (from t in context.TaxRates
                                                    select new { t.TaxRateID, t.TaxRate1 }).ToList();



        }

        private void searchLookUpEditContractID_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.searchLookUpEditContractID.Text.ToString()))
            {
                int contractid = 0;
                bool res = int.TryParse(this.searchLookUpEditContractID.EditValue.ToString(), out contractid);
                if (res == false) { contractid = 0; }

                if (contractid > 0)
                {
                    var qryContract = from c in context.Contracts
                                       join exc in context.Extended_Customers on c.CustomerID equals exc.ExtendedCustomerID
                                       join cshop in context.Contract_Shops on c.ContractID equals cshop.ContractID
                                       join shop in context.Shops on cshop.ShopID equals shop.ShopID
                                       join crate in context.Contract_Rates on c.ContractID equals crate.ContractID
                                       where crate.IsActive == true && c.ContractID == contractid
                                       select new { c,crate,shop.ShopID,shop.ShopNo};


                    var qryContractFirst = qryContract.FirstOrDefault();
                    if (qryContractFirst != null)
                    {
                        this.lookUpEditCustomerID.EditValue = qryContractFirst.c.CustomerID;;
                        this.lookUpEditCompanyID.EditValue = qryContractFirst.c.CompanyID;
                        this.lookUpEditLevelID.EditValue = qryContractFirst.c.LevelID;
                        this.lookUpEditLocationID.EditValue = qryContractFirst.c.LocationID;
                        this.txtPeriod.EditValue = qryContractFirst.crate.Period;
                        //this.txtTotalTax.EditValue = this.txtTotalTaxNew.EditValue = qryContractFirst.crate.TotalTax;
                        qryContractFirst.crate.IsActive = false;


                    }

                    // Contract Shops

                    this.chkShops.Properties.DataSource = qryContract.ToList();
                    this.chkShops.Properties.DisplayMember = "ShopNo";
                    this.chkShops.Properties.ValueMember = "ShopID";
                    this.chkShops.CheckAll();

                  
                    // Contract Tax rates
                    //if (oldcontTaxRateList.Count > 0)
                    //{
                    //    oldcontTaxRateList.Clear();
                    //}
                    if (bsContractTaxRate_New.Count > 0)
                    {
                        bsContractTaxRate_New.Clear();
                    }

                    //var qryTaxRates = from c in context.Contracts
                                      //join exc in context.Extended_Customers on c.CustomerID equals exc.ExtendedCustomerID
                                      //join crate in context.Contract_Rates on c.ContractID equals crate.ContractID
                                      //join ctxr in context.Contract_TaxRates on crate.ContractRateID equals ctxr.ContractRateID
                                      //where crate.IsActive == true && c.ContractID == contractid
                                      //select new { c.ContractID, c.CompanyID, c.LevelID, c.LocationID, c.CustomerID, ctxr.ContractDetailID, ctxr.ContractRateID, ctxr.TaxID, ctxr.TaxRateID, ctxr.PerMonth };
                    //foreach (var qry in qryTaxRates)
                    //{
                    //    Contract_TaxRates ctr = new Contract_TaxRates();
                    //    ctr.ContractDetailID = qry.ContractDetailID;
                    //    ctr.TaxRateID = qry.TaxRateID;
                    //    ctr.TaxID = qry.TaxID;
                    //    ctr.PerMonth = qry.PerMonth;
                    //    //contract_TaxRatesBindingSource.Add(ctr);
                    //    //bsContractTaxRate_New.Add(ctr);
                    //    oldcontTaxRateList.Add(ctr);
                    //    newcontTaxRateList.Add(ctr);
                    //}

                    this.contract_TaxRatesGridControl.RefreshDataSource(); this.gridControl1.RefreshDataSource();


                    // fill other fiiels values 
                    this.activeFromDateEdit.DateTime = NewDateFrom.DateTime = qryContractFirst.crate.ActiveFrom;
                    this.activeToDateEdit.DateTime = NewDateTo.DateTime = qryContractFirst.crate.ActiveTo;
                    this.areaInSqFtTextEdit.EditValue = NewAreaInSqFt.EditValue = qryContractFirst.crate.AreaInSqFt;
                    this.rentPerMonthTextEdit.EditValue = NewRentPerMonth.EditValue = qryContractFirst.crate.RentPerMonth;
                    this.sCPerSqFtTextEdit.EditValue = NewSCPerSQFt.EditValue = qryContractFirst.crate.SCPerSqFt;
                    this.sCPerMonthTextEdit.EditValue = NewSCPerMonth.EditValue = qryContractFirst.crate.SCPerMonth;
                    this.rentPerSqFtTextEdit.EditValue = NewRentPerSqft.EditValue = qryContractFirst.crate.RentPerSqFt;
                    this.rentWithSCPerMonthTextEdit.EditValue = NewRentWithSCperMonth.EditValue = qryContractFirst.crate.RentWithSCPerMonth;
                    this.rentWIthSCPerSqFtTextEdit.EditValue = newRentWithSCPerSqFt.EditValue = qryContractFirst.crate.RentWIthSCPerSqFt;
                    //this.totalRentPerMonthTextEdit.EditValue = txtNewTotalAmount.EditValue = qryContractFirst.crate.TotalRentPerMonth;



                }


            }

            IsFilled = true;
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colTaxID1)
            {
                int taxid = 0;
                bool res = int.TryParse(e.Value.ToString(),out taxid);
                if (res==false) { taxid =0;}

                var qryactivetax = (from tx in context.TaxRates
                                    where tx.TaxID == taxid && tx.IsActive ==true
                                        select tx).FirstOrDefault();
                this.gridView2.SetRowCellValue(e.RowHandle, colTaxRateID1, qryactivetax.TaxRateID);

                decimal taxpermonth = (decimal.Parse(qryactivetax.TaxRate1.ToString()) * decimal.Parse(NewRentWithSCperMonth.EditValue.ToString()))/100;
                this.gridView2.SetRowCellValue(e.RowHandle, colPerMonth1, taxpermonth);
                calculate();




            }
        }

        private void calculate()
        {
            decimal areaintsqt = 0;
            decimal scpersqft = 0;
            decimal scpermonth = 0;
            decimal rentpermonth = 0;
            decimal rentpersqft = 0;

            bool res = false;

            res = decimal.TryParse(this.NewAreaInSqFt.EditValue.ToString(), out areaintsqt);
            if (res == false) { areaintsqt = 0; }

            res = decimal.TryParse(this.NewSCPerMonth.EditValue.ToString(), out scpermonth);
            if (res == false) { scpermonth = 0; }

            res = decimal.TryParse(this.NewSCPerSQFt.EditValue.ToString(), out scpersqft);
            if (res == false) { scpersqft = 0; }

            res = decimal.TryParse(this.NewRentPerSqft.EditValue.ToString(), out rentpersqft);
            if (res == false) { rentpersqft = 0; }

            res = decimal.TryParse(this.NewRentPerMonth.EditValue.ToString(), out rentpermonth);
            if (res == false) { rentpermonth = 0; }


            rentpermonth = areaintsqt * rentpersqft;
            scpermonth = areaintsqt * scpersqft;

            this.NewSCPerMonth.EditValue = scpermonth;
            this.NewRentPerMonth.EditValue = rentpermonth;
            this.NewRentPerSqft.EditValue = rentpersqft;
            this.newRentWithSCPerSqFt.EditValue = rentpersqft + scpersqft;
            this.NewRentWithSCperMonth.EditValue = rentpermonth + scpermonth;
            decimal drentiwthSCpermonth = rentpermonth + scpermonth;

            //foreach (var qry in newcontTaxRateList)
            //{
            //    decimal taxrate = getTaxRate(qry.TaxRateID);
            //    qry.PerMonth = (taxrate * drentiwthSCpermonth) / 100; 
            //}
         

            //decimal totalTax = newcontTaxRateList.Sum(x => x.PerMonth);
            //this.txtTotalTaxNew.Text = Math.Round(totalTax, 2).ToString();

            //decimal TotalAmountPerMonth = totalTax + rentpermonth + scpermonth;

            //txtNewTotalAmount.EditValue = TotalAmountPerMonth;
            //gridControl1.RefreshDataSource();
            //this.bsContractTaxRate_New.DataSource = newcontTaxRateList;
            this.gridControl1.RefreshDataSource();
        }

        private decimal getTaxRate(int pTaxRateID)
        {
            decimal taxrate = 0;

            var qryTaxRate = (from tr in context.TaxRates
                              where tr.TaxRateID == pTaxRateID
                              select new { tr.TaxRate1 }).FirstOrDefault();
            if (qryTaxRate != null)
            {
                taxrate = qryTaxRate.TaxRate1;
            }


            return taxrate;

        }

        private void NewAreaInSqFt_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.NewAreaInSqFt.Text.ToString()))
            {
                //decimal areaintsqt = 0;
                //decimal scpersqft = 0;
                //decimal scpermonth = 0;
                //decimal rentpermonth = 0;
                //decimal rentpersqft = 0;

                //bool res = false;

                //res = decimal.TryParse(this.NewAreaInSqFt.EditValue.ToString(), out areaintsqt);
                //if (res == false) { areaintsqt = 0; }
                //calculate();

            }
        }

        private void NewRentPerSqft_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.NewRentPerSqft.Text.ToString()))
            {
                if (IsFilled == true)
                {
                    calculate();
                }
            }
        }

        private void NewSCPerSQFt_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.NewSCPerSQFt.Text.ToString()))
            {

                if (IsFilled == true)
                {
                    calculate();
                }
            }
        }

        private void rentPerSqFtTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void contract_TaxRatesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void NewDateTo_EditValueChanged(object sender, EventArgs e)
        {
            getMonth();
        }

        private void getMonth()
        {
            DateTime fromdate;
            DateTime todate;
            bool res = DateTime.TryParse(NewDateFrom.Text, out fromdate);
            if (res == false)
            {
                return;
            }

            res = DateTime.TryParse(NewDateTo.Text, out todate);
            if (res == false)
            {
                return;
            }

            DateTime dtFrom = NewDateFrom.DateTime.Date;
            DateTime dtTo = NewDateTo.DateTime.Date;
             double dmonth = (dtTo.Subtract(dtFrom).Days/(365.25/12));
             double month = Math.Ceiling(dmonth);
             this.txtPeriodNew.EditValue = month;
            
                 
        }

        private void NewDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            getMonth();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int period = 0;
            decimal rentpersqft = 0;
            bool res = int.TryParse(this.txtPeriodNew.EditValue.ToString(), out period);
            if (res == false) { period = 0; }

            if (period == 0)
            {
                dxErrorProvider1.SetError(this.txtPeriodNew, "Invalid Period");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.txtPeriodNew, "");
            }

            res = decimal.TryParse(this.NewRentPerSqft.EditValue.ToString(), out rentpersqft);
            if (res == false) { rentpersqft = 0; }
            if (rentpersqft == 0)
            {
                dxErrorProvider1.SetError(this.rentPerSqFtTextEdit, "Invalid Rent");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.rentPerSqFtTextEdit, "");
            }

            var qryUpdCurContRate = (from cr in context.Contract_Rates
                                     where cr.IsActive == true
                                     select cr).FirstOrDefault();
            qryUpdCurContRate.IsActive = false;
            int CurrentContractRateID = qryUpdCurContRate.ContractRateID;


            Contract_Rates crate = new Contract_Rates();
            crate.ContractID = int.Parse(this.searchLookUpEditContractID.EditValue.ToString());
            crate.AreaInSqFt = decimal.Parse(NewAreaInSqFt.EditValue.ToString());
            crate.SCPerSqFt = decimal.Parse(NewSCPerSQFt.EditValue.ToString());
            crate.SCPerMonth = decimal.Parse(NewSCPerMonth.EditValue.ToString());
            crate.RentPerMonth = decimal.Parse(NewRentPerMonth.EditValue.ToString());
            crate.RentPerSqFt = decimal.Parse(NewRentPerSqft.EditValue.ToString());
            crate.RentWIthSCPerSqFt = decimal.Parse(newRentWithSCPerSqFt.EditValue.ToString());
            crate.RentWithSCPerMonth = decimal.Parse(NewRentWithSCperMonth.EditValue.ToString());
            //crate.TotalRentPerMonth = decimal.Parse(txtNewTotalAmount.EditValue.ToString());

            crate.IsActive = true;
            crate.ActiveFrom = NewDateFrom.DateTime;
            crate.ActiveTo = NewDateTo.DateTime;
            crate.Period = period;
            //crate.Period = NewDateTo.DateTime.Subtract(NewDateFrom.DateTime).
            crate.IsRenew = true;
            crate.PreviousContractRateID = CurrentContractRateID;
            //crate.TotalTax = oldcontTaxRateList.Sum(x => x.PerMonth);


            //var qry= contTaxRateList;

            //foreach (var qry in oldcontTaxRateList)
            //{
            //    Contract_TaxRates ctx = new Contract_TaxRates();
            //    ctx.TaxID = qry.TaxID;
            //    ctx.TaxRateID = qry.TaxRateID;
            //    ctx.PerMonth = qry.PerMonth;
            //    crate.Contract_TaxRates.Add(ctx);
            //}

            context.Contract_Rates.AddObject(crate);

            int succ = context.SaveChanges();
            if (succ > 0)
            {
                MessageBox.Show("Record Saved Successfully", "Save Success - Renew Contracts", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //ClearText();
            //this.enable_control(false, eRecStatus.eSave);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

       

                      
       
    }
}
