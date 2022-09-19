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
using System.Data.Linq.SqlClient;
using DataTier;
using DataTier.Reports;

namespace MMS
{
    public partial class xRent_Invoice_Edit : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<Invoice_Details> InvDetList = new List<Invoice_Details>();
        public xRent_Invoice_Edit()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                ///validating fields 
                ///
                bool res = false;

                int icompid = 0;
                int ilocid = 0;
                int icustid = 0;
                int iinvoiceid = 0; // shopname
                int ilevelid = 0;
                DateTime dtFrom;
                DateTime dtTo;
                //---
                decimal dtotalsqft = 0;
                decimal dRentPerSqFt = 0;
                decimal dScPerSqFt = 0;
                decimal dRentWithScPerSqft = 0;
                decimal dRentPerMonnth = 0;
                decimal dSCperMonth = 0;
                decimal dRentWithSCperMonth = 0;
                decimal dTotalTax = 0;
                decimal dTotalRentPerMonth = 0;

                res = DateTime.TryParse(this.dateEditFrom.EditValue.ToString(), out dtFrom); // Date From
                if (res == false) { dtFrom = DateTime.Now.Date; }

                res = DateTime.TryParse(this.dateEditTo.EditValue.ToString(), out dtTo);  // Date To
                if (res == false) { dtTo = DateTime.Now.Date; }

                res = int.TryParse(this.lookUpEditCompany.EditValue.ToString(), out icompid); // company
                if (res == false) { icompid = 0; }

                res = int.TryParse(this.lookUpEditLocation.EditValue.ToString(), out ilocid); // location
                if (res == false) { ilocid = 0; }

                res = int.TryParse(this.lookUpEditFloorLevel.EditValue.ToString(), out ilevelid); // level
                if (res == false) { ilevelid = 0; }

                res = int.TryParse(this.searchLookUpEditShopName.EditValue.ToString(), out iinvoiceid); // Invoiceid
                if (res == false) { iinvoiceid = 0; }

                res = int.TryParse(this.lookUpEditCustomer.EditValue.ToString(), out icustid); // Customer
                if (res == false) { icustid = 0; }
                ///---

                res = decimal.TryParse(this.txtTotalSqFt.EditValue.ToString(), out dtotalsqft); // Total Sqft
                if (res == false) { dtotalsqft = 0; }

                res = decimal.TryParse(this.rentPerSqFtTextEdit.EditValue.ToString(), out dRentPerSqFt); // rent per sqft
                if (res == false) { dRentPerSqFt = 0; }

                res = decimal.TryParse(this.sCPerSqFtTextEdit.EditValue.ToString(), out dScPerSqFt); // SC per sqft
                if (res == false) { dScPerSqFt = 0; }

                res = decimal.TryParse(this.rentWIthSCPerSqFtTextEdit.EditValue.ToString(), out dRentWithScPerSqft); // Rent with SC per sqft
                if (res == false) { dScPerSqFt = 0; }

                res = decimal.TryParse(this.rentPerMonthTextEdit.EditValue.ToString(), out dRentPerMonnth); // Rent per month
                if (res == false) { dRentPerMonnth = 0; }

                res = decimal.TryParse(this.sCPerMonthTextEdit.EditValue.ToString(), out dSCperMonth); // SC per month
                if (res == false) { dSCperMonth = 0; }

                res = decimal.TryParse(this.rentWithSCPerMonthTextEdit.EditValue.ToString(), out dRentWithSCperMonth); // Rent with SC permonth 
                if (res == false) { dRentWithSCperMonth = 0; }

                res = decimal.TryParse(this.txtTotalTax.EditValue.ToString(), out dTotalTax); //  total tax 
                if (res == false) { dTotalTax = 0; }

                res = decimal.TryParse(this.totalRentPerMonthTextEdit.EditValue.ToString(), out dTotalRentPerMonth); // Total Rent 
                if (res == false) { dTotalRentPerMonth = 0; }

                /// -- 
                /// 

                if (iinvoiceid == 0)
                {
                    return;
                }

                var qryInv = (from inv in context.Invoices
                              where inv.InvoiceID == iinvoiceid
                              select inv).FirstOrDefault();

                if (qryInv != null)
                {
                    //qryInv.CompanyID = icompid;
                    //qryInv.LocationID = ilocid;
                    //qryInv.CustomerID = icustid;
                    //qryInv.LevelID = ilevelid;
                    qryInv.DateFrom = dtFrom;
                    qryInv.DateTo = dtTo;

                    qryInv.AreaInSqFt = dtotalsqft;
                    qryInv.RentPerSqFt = dRentPerSqFt;
                    qryInv.SCPerSqFt = dScPerSqFt;
                    qryInv.RentWIthSCPerSqFt = dRentWithScPerSqft;
                    qryInv.RentPerMonth = dRentPerMonnth;
                    qryInv.SCPerMonth = dSCperMonth;
                    qryInv.RentWithSCPerMonth = dRentWithSCperMonth;
                    cMandatoryTax _mandatorytax = cTaxCalculations.getAmountWithMandatoryTax(dRentWithSCperMonth);
                    qryInv.MandatoryTaxAmount = _mandatorytax.MandatoryTaxAmount;
                    qryInv.MandatoryTaxCode = _mandatorytax.MandatoryTaxCode;
                    qryInv.MandatoryTaxID = _mandatorytax.MandatoryTaxID;
                    qryInv.MandatoryTaxRateID = _mandatorytax.MandatoryTaxRateID;
                    qryInv.TotalWithMandatoryTax = _mandatorytax.TotalWithMandatoryTax; // total + NBT (mandatory tax) 

                    List<cOtherTax> _othertaxList = cTaxCalculations.getOtherTax(qryInv.TotalWithMandatoryTax);
                    qryInv.OtherTax = _othertaxList.Sum(x => x.TaxAmount);

                    qryInv.TotalTax = dTotalTax;
                    qryInv.TotalRentPerMonth = dTotalRentPerMonth;
                    qryInv.Naration = this.memoEditRemarks.EditValue.ToString();
                    qryInv.IsPerDay = checkEditPerDay.Checked;
                    if (qryInv.IsPerDay == true)
                    {
                        qryInv.NosDay = int.Parse(this.txtperDay.EditValue.ToString());
                    }
                    else
                    {
                        qryInv.NosDay = 0;
                    }

                    qryInv.FooterText1 = this.txtInvoiceFooter.Text.ToString();

                }
                else
                {
                    MessageBox.Show("Invoice Values are Null");
                    return;
                }


                foreach (var qry in InvDetList)
                {
                    searchAndModify(qry.InvoiceDetailID, qry.TaxID, qry.TaxRateID, qry.Amount);
                }

                int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Save Success - Rent Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void searchAndModify(int pInvoiceDetailID, int pTaxID, int pTaxRateID, decimal pAmount)
        {
            var qryInvDet = (from idet in context.Invoice_Details
                             where idet.InvoiceDetailID == pInvoiceDetailID
                             select idet).FirstOrDefault();
            if (qryInvDet != null) 
            {
                qryInvDet.Amount = pAmount;
                qryInvDet.TaxID = pTaxID;
                qryInvDet.TaxRateID = pTaxRateID;

            }
        }

        private void xRent_Invoice1_Load(object sender, EventArgs e)
        {
            load_data();       



        }

        public void Fill_Data(int pInvoiceID)
        {

            /// fill single entities 
            this.cboMonthYear.Enabled = false;


            var qryInv = (from i in context.Invoices
                          join m in context.Months on i.ProcessMonth equals m.MonthID
                          where i.InvoiceID == pInvoiceID
                          select new { i.InvoiceID, i.LocationID, i.LevelID, i.CompanyID, i.CustomerID, i.ShopID, i.DateFrom, i.DateTo, i.ProcessMonth, i.ProcessYear, i.Naration, i.ContractID, i.ContractRateID,i.ShopName,i.AreaInSqFt,i.RentPerSqFt,i.SCPerSqFt,i.RentWIthSCPerSqFt,i.RentWithSCPerMonth,i.RentPerMonth,i.SCPerMonth,i.TotalTax,i.TotalRentPerMonth,m.MonthCode,i.IsPerDay,i.NosDay,i.IsConfirmed,i.ExtendedCustomerID }).FirstOrDefault();
            if (qryInv != null)
            {
                // disable/enable Save button on IsConfirmed status
                if (qryInv.IsConfirmed == true)
                {
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }
                this.lookUpEditLocation.EditValue = qryInv.LocationID;
                this.lookUpEditFloorLevel.EditValue = qryInv.LevelID;
                this.lookUpEditCompany.EditValue = qryInv.CompanyID;
                this.lookUpEditCustomer.EditValue = qryInv.CustomerID;
                this.lookUpEditShopID.EditValue = qryInv.ShopID;
                this.dateEditFrom.EditValue = qryInv.DateFrom;
                this.dateEditTo.EditValue = qryInv.DateTo;
                this.searchLookUpEditShopName.EditValue = qryInv.InvoiceID;

                

                this.cboMonthYear.EditValue = qryInv.ProcessYear + " - " + qryInv.MonthCode;
                this.checkEditPerDay.Checked = qryInv.IsPerDay;
                if (qryInv.IsPerDay == true)
                {
                    this.txtperDay.Enabled = true;
                    this.txtperDay.EditValue = qryInv.NosDay;
                }
                else
                {
                    this.txtperDay.EditValue = 0;
                    this.txtperDay.Enabled = false;
                }


                /// rent values 
                this.txtTotalSqFt.EditValue = qryInv.AreaInSqFt;
                this.rentPerSqFtTextEdit.EditValue = qryInv.RentPerSqFt;
                this.sCPerSqFtTextEdit.EditValue = qryInv.SCPerSqFt;

                this.rentWIthSCPerSqFtTextEdit.EditValue = qryInv.RentWIthSCPerSqFt;
                this.rentPerMonthTextEdit.EditValue = qryInv.RentPerMonth;
                this.sCPerMonthTextEdit.EditValue = qryInv.SCPerMonth;
                this.rentWithSCPerMonthTextEdit.EditValue = qryInv.RentWithSCPerMonth;
                this.txtTotalTax.EditValue = qryInv.TotalTax;
                this.totalRentPerMonthTextEdit.EditValue = qryInv.TotalRentPerMonth;
                this.memoEditRemarks.EditValue = qryInv.Naration;
                //---

                 istaxApplicable = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicable(qryInv.ExtendedCustomerID);

                /// fill if there any taxes 
                InvDetList.Clear();
                int invoiceid = qryInv.InvoiceID;
                var qryTaxes = (from invdet in context.Invoice_Details
                                where invdet.InvoiceID == invoiceid
                                select invdet).ToList();
                foreach (var qry in qryTaxes)
                {
                    Invoice_Details oInvDet = new Invoice_Details();
                    oInvDet.InvoiceID = qry.InvoiceID;
                    oInvDet.InvoiceDetailID = qry.InvoiceDetailID;
                    oInvDet.TaxID = qry.TaxID;
                    oInvDet.TaxRateID = qry.TaxRateID;
                    oInvDet.Amount = qry.Amount;
                    InvDetList.Add(oInvDet);                  
                }

                calTotal();
                contract_TaxRatesGridControl.DataSource = InvDetList;
                contract_TaxRatesGridControl.RefreshDataSource();
                ///--

                
                ///// Month / year 
                //var qryMonthY = (from  

                /////

                
            }
            else
            {
                return;
            }

                           



        }

        private void load_data()
        {
            // loading shops 
            //var qryShop = (from c in context.Contracts
            //               join exC in context.Extended_Customers on c.CustomerID equals exC.ExtendedCustomerID
            //               join gCus in context.Global_Customers on exC.CustomerID equals gCus.CustomerID
            //               join loc in context.Locations on c.LocationID equals loc.LocationID
            //               join com in context.Companies on c.CompanyID equals com.CompanyID
            //               join cshp in context.Contract_Shops on c.ContractID equals cshp.ContractID
            //               join shp in context.Shops on cshp.ShopID equals shp.ShopID
            //               join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
            //               select new { c.ShopName, c.ContractID, shp.ShopNo, gCus.CustomerName, com.CompanyCode, loc.LocationCode, lvl.LevelName }).ToList();
            //this.searchLookUpEditShopName.Properties.DataSource = qryShop;
            //this.searchLookUpEditShopName.Properties.ValueMember = "ContractID";
            //this.searchLookUpEditShopName.Properties.DisplayMember = "ShopName";


            // Month / Year 
            var qryMonthYear = (from i in context.Invoices
                                join m in context.Months on i.ProcessMonth equals m.MonthID
                                where i.IsConfirmed == false && i.InvoiceTypeID == 1
                                select new { m.MonthCode, i.ProcessYear }).ToList();
            cboMonthYear.Properties.Items.Clear();
            foreach (var qry in qryMonthYear)
            {
                cboMonthYear.Properties.Items.Add(qry.MonthCode + " - " + qry.ProcessYear);
            }



            // shop name from invoice
            //var qryShop = (from i in context.Invoices
            //               join c in context.Companies on i.CompanyID equals c.CompanyID
            //               join l in context.Locations on i.LocationID equals l.LocationID
            //               join cust in context.Global_Customers on i.CustomerID equals cust.CustomerID
            //               join cont in context.Contracts on i.ContractID equals cont.ContractID
            //               join lvl in context.Floor_Levels on cont.LevelID equals lvl.LevelID
            //               select new { i.InvoiceID,i.ShopName, i.ShopNo, l.LocationCode, cust.CustomerName, lvl.LevelName, c.CompanyCode }).ToList();
            //this.searchLookUpEditShopName.Properties.DataSource = qryShop;
            //this.searchLookUpEditShopName.Properties.DisplayMember = "ShopName";
            //this.searchLookUpEditShopName.Properties.ValueMember = "InvoiceID";

            var qryShop = (from i in context.Invoices
                           join c in context.Contracts on i.ContractID equals c.ContractID
                           join comp in context.Companies on c.CompanyID equals comp.CompanyID
                           join loc in context.Locations on c.LocationID equals loc.LocationID
                           join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
                           join gcus in context.Global_Customers on i.CustomerID equals gcus.CustomerID
                           select new { i.InvoiceID, c.ShopName, i.ShopNo, loc.LocationCode, gcus.CustomerName, lvl.LevelName, comp.CompanyCode }).ToList();
            this.searchLookUpEditShopName.Properties.DataSource = qryShop;
            this.searchLookUpEditShopName.Properties.DisplayMember = "ShopName";
            this.searchLookUpEditShopName.Properties.ValueMember = "InvoiceID";

            // 

            // location 
            var qryLoc = (from l in context.Locations
                          select new { l.LocationID, l.LocationCode }).ToList();
            this.lookUpEditLocation.Properties.DataSource = qryLoc;
            this.lookUpEditLocation.Properties.DisplayMember = "LocationCode";
            this.lookUpEditLocation.Properties.ValueMember = "LocationID";

            // company 
            var qryCom = (from c in context.Companies
                          select new { c.CompanyID, c.CompanyCode }).ToList();
            this.lookUpEditCompany.Properties.DataSource = qryCom;
            this.lookUpEditCompany.Properties.DisplayMember = "CompanyCode";
            this.lookUpEditCompany.Properties.ValueMember = "CompanyID";

            // customer 
            var qryCust = (from c in context.Global_Customers
                           select new { c.CustomerID, c.CustomerName }).ToList();
            this.lookUpEditCustomer.Properties.DataSource = qryCust;
            this.lookUpEditCustomer.Properties.DisplayMember = "CustomerName";
            this.lookUpEditCustomer.Properties.ValueMember = "CustomerID";
            //

            // Floor Level
            var qryLevel = (from l in context.Floor_Levels
                            select new { l.LevelID, l.LevelName }).ToList();
            this.lookUpEditFloorLevel.Properties.DataSource = qryLevel;
            this.lookUpEditFloorLevel.Properties.DisplayMember = "LevelName";
            this.lookUpEditFloorLevel.Properties.ValueMember = "LevelID";
            //

            // Shops

            var qryShopNo = (from s in context.Shops
                           select new { s.ShopID, s.ShopNo }).ToList();
            this.lookUpEditShopID.Properties.DataSource = qryShopNo;
            this.lookUpEditShopID.Properties.DisplayMember = "ShopNo";
            this.lookUpEditShopID.Properties.ValueMember = "ShopID";


            // taxes 
            var qryTax = (from t in context.Taxes
                          select new { t.TaxID, t.TaxCode, t.TaxName }).ToList();
            this.taxBindingSource.DataSource = qryTax;

            // tax rates
            var qryTaxRate = (from tr in context.TaxRates
                              select new { tr.TaxID, tr.TaxRateID, tr.TaxRate1 }).ToList();
            this.taxRateBindingSource.DataSource = qryTaxRate;



        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void txtTotalSqFt_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtTotalSqFt.Text.ToString()))
            {
                calTotal();

            }
        }

        private void calTotal()
        {
            bool res = false;
            decimal dtotalsqft = 0;
            decimal dRentPerSqFt = 0;
            decimal dScPerSqFt = 0;
            decimal dRentWithScPerSqft = 0;
            decimal dRentPerMonnth = 0;
            decimal dSCperMonth = 0;
            decimal dRentWithSCperMonth = 0;
            decimal dTotalTax = 0;
            decimal dTotalRentPerMonth = 0;

            res = decimal.TryParse(this.txtTotalSqFt.EditValue.ToString(), out dtotalsqft); // Total Sqft
            if (res == false) { dtotalsqft = 0; }

            res = decimal.TryParse(this.rentPerSqFtTextEdit.EditValue.ToString(), out dRentPerSqFt); // rent per sqft
            if (res == false) { dRentPerSqFt = 0; }

            res = decimal.TryParse(this.sCPerSqFtTextEdit.EditValue.ToString(), out dScPerSqFt); // SC per sqft
            if (res == false) { dScPerSqFt = 0; }

            // Total Tax 
           
           
            
            // rent with sqft 
                //InvDetList.Clear();

            if (checkEditPerDay.Checked == false)
            {
                this.rentWIthSCPerSqFtTextEdit.EditValue = dRentWithScPerSqft = dRentPerSqFt + dScPerSqFt;
                this.rentPerMonthTextEdit.EditValue = dRentPerMonnth = dtotalsqft * dRentPerSqFt;
                this.sCPerMonthTextEdit.EditValue = dSCperMonth = dScPerSqFt * dtotalsqft;
                this.rentWithSCPerMonthTextEdit.EditValue = dRentWithSCperMonth = dRentPerMonnth + dSCperMonth;


                // calculating Mandatory tax 
                decimal TotalWithMandatoryTax = 0;
                decimal MandatoryTax = 0;
                var qryMTax = (from ot in InvDetList
                               join t in context.Taxes on ot.TaxID equals t.TaxID
                               where t.IsMandatory == true
                               select ot).ToList();

                foreach (var qry in qryMTax)
                {
                    if (istaxApplicable == false)
                    { qry.Amount = 0; }
                    else
                    {
                        qry.Amount = MandatoryTax = getTaxM(qry.TaxRateID, dRentWithSCperMonth);
                    }

                }

                TotalWithMandatoryTax = MandatoryTax + dRentWithSCperMonth;
                //calculating other tax 
                var qryOTax = (from mt in InvDetList
                               join t in context.Taxes on mt.TaxID equals t.TaxID
                               where t.IsMandatory == false
                               select mt).ToList();

                foreach (var qry in qryOTax)
                {
                    if (istaxApplicable == false)
                    {
                        qry.Amount = 0;
                    }
                    else { qry.Amount = getTaxO(qry.TaxRateID, TotalWithMandatoryTax); }
                    

                }
                // -- 

                contract_TaxRatesGridControl.DataSource = InvDetList;
                contract_TaxRatesGridControl.RefreshDataSource();
                // -- 

                // calculating total tax 
                var qrytotaltax = InvDetList.Sum(x => x.Amount);

                res = decimal.TryParse(qrytotaltax.ToString(), out dTotalTax); //  total tax 
                if (res == false) { dTotalTax = 0; }

                this.txtTotalTax.EditValue = dTotalTax;

                this.totalRentPerMonthTextEdit.EditValue = dTotalRentPerMonth = dTotalTax + dRentWithSCperMonth;

            }
            else
            {
                int nosdays = 0;
                res = int.TryParse(this.txtperDay.EditValue.ToString(),out nosdays);
                if (res == false) { nosdays =0;}
                if (nosdays == 0) 
                {
                    return ;
                }
                this.rentPerMonthTextEdit.EditValue = dRentPerMonnth = (dRentPerSqFt * dtotalsqft)/30 * nosdays;
                this.sCPerMonthTextEdit.EditValue = dSCperMonth = (dScPerSqFt * dtotalsqft)/30 * nosdays;                
                this.rentWIthSCPerSqFtTextEdit.EditValue = dRentWithScPerSqft = dRentPerSqFt + dScPerSqFt;

                this.rentWithSCPerMonthTextEdit.EditValue = dRentWithSCperMonth = dRentPerMonnth + dSCperMonth;
                // calculating Mandatory tax 
                decimal TotalWithMandatoryTax = 0;
                decimal MandatoryTax = 0;
                var qryMTax = (from ot in InvDetList
                               join t in context.Taxes on ot.TaxID equals t.TaxID
                               where t.IsMandatory == true
                               select ot).ToList();

                foreach (var qry in qryMTax)
                {
                    if (istaxApplicable == false)
                    { qry.Amount = 0; }
                    else
                    {
                        qry.Amount = MandatoryTax = getTaxM(qry.TaxRateID, dRentWithSCperMonth);
                    }

                }

                TotalWithMandatoryTax = MandatoryTax + dRentWithSCperMonth;
                 //calculating other tax 
                var qryOTax = (from mt in InvDetList
                               join t in context.Taxes on mt.TaxID equals t.TaxID
                               where t.IsMandatory == false
                               select mt).ToList();

                foreach (var qry in qryOTax)
                {
                    if (istaxApplicable == false)
                    { qry.Amount = 0; }
                    else
                    {
                        qry.Amount = getTaxO(qry.TaxRateID, TotalWithMandatoryTax);
                    }
                }
                // -- 

                contract_TaxRatesGridControl.DataSource = InvDetList;
                contract_TaxRatesGridControl.RefreshDataSource();

                // calculating total tax 
                var qrytotaltax = InvDetList.Sum(x => x.Amount);

                res = decimal.TryParse(qrytotaltax.ToString(), out dTotalTax); //  total tax 
                if (res == false) { dTotalTax = 0; }

                this.txtTotalTax.EditValue = dTotalTax;

                this.totalRentPerMonthTextEdit.EditValue = dTotalRentPerMonth = dTotalTax + dRentWithSCperMonth;

            }
          




        }

        private decimal getTaxM(int pTaxRateID, decimal dRentWithSCperMonth)
        {
            decimal taxamount = 0;

            var qryTaxRate = (from tr in context.TaxRates
                              join t in context.Taxes on tr.TaxID equals t.TaxID
                              where tr.TaxRateID == pTaxRateID && t.IsMandatory ==true
                              select new { tr.TaxRate1 }).FirstOrDefault();
            if (qryTaxRate != null)
            {
                taxamount = (dRentWithSCperMonth * qryTaxRate.TaxRate1) / 100;

            }
            else
            {

                taxamount = 0;
            }            
            return taxamount;
        }

        private decimal getTaxO(int pTaxRateID, decimal dTotalWithMandatoryTax)
        {
            decimal taxamount = 0;

            var qryTaxRate = (from tr in context.TaxRates
                              join t in context.Taxes on tr.TaxID equals t.TaxID
                              where tr.TaxRateID == pTaxRateID && t.IsMandatory == false
                              select new { tr.TaxRate1 }).FirstOrDefault();
            if (qryTaxRate != null)
            {
                taxamount = (dTotalWithMandatoryTax * qryTaxRate.TaxRate1) / 100;

            }
            else
            {

                taxamount = 0;
            }
            return taxamount;
        }

        private void checkEditPerDay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditPerDay.Checked == true)
            {
                //txtTotalTax.Enabled = true;
                txtperDay.Enabled = true;
                DateTime dtfrom = this.dateEditFrom.DateTime;
                DateTime dtTo = this.dateEditTo.DateTime;

                int idays = dtTo.Subtract(dtfrom).Days;
                 this.txtperDay.EditValue = idays;


            }
            else
            {
                txtperDay.EditValue = 0;
                txtperDay.Enabled = false;
                //txtTotalTax.Enabled = false;
            }
        }

        private void searchLookUpEditShopName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void rentPerSqFtTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.rentPerSqFtTextEdit.Text.ToString()))
            {
                calTotal();
            }
        }

        private void sCPerSqFtTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.sCPerSqFtTextEdit.Text.ToString()))
            {
                calTotal();
            }
        }

        private void txtperDay_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtperDay.Text.ToString()))
            { return; }

            int perday = 0;          
            if (int.TryParse(this.txtperDay.EditValue.ToString(), out perday) == false)
            { perday = 0; }

            if (perday > 0)
            {
                calTotal();

            }
            else
            {
                calTotal();

            }


        }

       

        private void lookUpEditFloorLevel_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditLocation_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditCompany_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditCustomer_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditShopID_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void rentWithSCPerMonthTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        public bool istaxApplicable { get; set; }
    }
}