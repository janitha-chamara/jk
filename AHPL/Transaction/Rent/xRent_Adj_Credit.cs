using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.XtraEditors;
using System.Data.Objects.DataClasses;
using DataTier;
namespace MMS
{
    public partial class xRent_Adj_Credit : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<Invoice_Details> invDetList = new List<Invoice_Details>();
        List<cGen_Rent_Invoice> cGenInvList = new List<cGen_Rent_Invoice>();
        private Transaction.Rent.xRentVariation rentvariation;


        public xRent_Adj_Credit()
        {
            InitializeComponent();
            load_data();
        }

        public enum eInvoiceType
        {
            Adjustment,
            CreditNote
        }

        public eInvoiceType pInvoiceType { get; set; }

        private void Loaddata()
        {

            var qryCom = (from c in context.Companies
                          select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
            companyBindingSource.DataSource = qryCom;
        
        
        }

        private void xAdjustment_Load(object sender, EventArgs e)
        {

            if (pInvoiceType == eInvoiceType.Adjustment)
            {
                //labelControl1.Text = "Adjustment - RENT";
                //this.Text = labelControl1.Text;
                //this.parentTopPanel.Text = this.Text;
                //this.splitContainerControl1.Panel2.Text = "Recent Adjustment List";
                this.lblInvoiceFooter.Visible = true;
                this.txtInvoiceFooter.Visible = true;
                //ravindra
                this.lookUpEditCustomerID.Enabled = true;
                this.lookContractClauseID.Enabled = true;
                this.lookCompany.Enabled = true;
                this.lookLocation.Enabled = true;
                this.lookContractClauseID.Visible = true;
                this.Text = "Adjustment - RENT";////roshan..21March2014
            }
            else
            {
                //labelControl1.Text = "Credit Note - RENT";
                //this.Text = labelControl1.Text;
                //this.parentTopPanel.Text = this.Text;
                //this.splitContainerControl1.Panel2.Text = "Recent Credit Note List";
                this.lblInvoiceFooter.Visible = false;
                this.txtInvoiceFooter.Visible = false;
                //ravindra
                this.dateEditFrom.Enabled = true;
                this.dateEditTo.Enabled = true;
                this.lookCompanies.Enabled = true;
                this.lookUpEdit1.Enabled = true;
                //this.chkcboInvoiceNo.Enabled = true;
                this.invoiceNolookup.Enabled = true;
                this.txtshopno.Visible = true;
                this.Text = "Credit Note - RENT";////roshan..21March2014
                
            }

            load_data();
            
            //cEnable_Controls.enable_control(this, false);
        }

        private void load_data()
        {
            try
            {
                //  invoice type 
                var qryInvType = (from s in context.Invoice_Types
                                  select new { s.InvoiceTypeID, s.InvoiceTypeName }).ToList();
                this.invoiceTypesBindingSource.DataSource = qryInvType;

                // sub invoice type 
                var qrysubinvtype = (from si in context.Sub_Invoice_Types
                                     select si).ToList();
                this.subInvoiceTypesBindingSource.DataSource = qrysubinvtype;


                // Customer
                var qryCustomer = (from c in context.Global_Customers
                                   select new { c.CustomerID, c.CustomerName }).ToList();
                this.globalCustomersBindingSource.DataSource = qryCustomer;


                // contract 
                var qrycontract = (from c in context.ContractClosures
                                   join comp in context.Companies on c.CompanyID equals comp.CompanyID
                                   join cust in context.Extended_Customers on c.ExtendedCustomerID equals cust.ExtendedCustomerID
                                   join gcust in context.Global_Customers on cust.CustomerID equals gcust.CustomerID
                                   join loc in context.Locations on c.LocationID equals loc.LocationID
                                   where c.IsPromotion == false && c.IsProcessed == true && c.IsActive == true
                                   orderby comp.CompanyID, loc.LocationID, c.ShopNo
                                   select new { c.ContractClosureID, comp.CompanyCode, loc.LocationCode, c.ShopName, c.ShopNo, gcust.CustomerName, c.IsTerminated, c.IsRenew }).ToList();

                lookContractClauseID.Properties.DataSource = qrycontract;
                lookContractClauseID.Properties.DisplayMember = "ShopNo";
                lookContractClauseID.Properties.ValueMember = "ContractClosureID";
                searchLookUpEdit1View.BestFitColumns();



                //Global Customer
                var qryGcust = (from gcust in context.Global_Customers
                                select new { gcust.CustomerID, gcust.CustomerName }).ToList();
                this.lookUpEditCustomerID.Properties.DataSource = qryGcust;
                this.lookUpEditCustomerID.Properties.DisplayMember = "CustomerName";
                this.lookUpEditCustomerID.Properties.ValueMember = "CustomerID";

                //get invoice numbers
                //var invqury = (from i in context.Invoices
                //               where i.InvoiceNo != null
                //               select new { i.InvoiceNo }).ToList();

                //chkcboInvoiceNo.Properties.DataSource = invqury;
                //chkcboInvoiceNo.Properties.DisplayMember = "InvoiceNo";
                //lookContractClauseID.Properties.ValueMember = "InvoiceNo";


                //Location
                var qryLoc = (from l in context.Locations
                              select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
                this.locationBindingSource.DataSource = qryLoc;

                //company
                var qryComp = (from comp in context.Companies
                               select new { comp.CompanyID, comp.CompanyCode, comp.CompanyName });
                this.companyBindingSource.DataSource = qryComp;

                // tax 
                var qrytax = (from t in context.Taxes
                              select new { t.TaxID, t.TaxCode }).ToList();
                this.taxBindingSource.DataSource = qrytax;

                //tax rate 
                var qrytaxrate = (from tr in context.TaxRates
                                  select new { tr.TaxRateID, tr.TaxRate1 }).ToList();
                this.taxRateBindingSource.DataSource = qrytaxrate;

                this.invoice_DetailsBindingSource.DataSource = invDetList;

                // Utility 

                var qryUtility = (from u in context.Utilities
                                  select new { u.UtilityID, u.UtilityName }).ToList();
                this.utilityBindingSource.DataSource = qryUtility;


               

                btnNew.Enabled = true;
                btnSave.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private int getActiveContractRateID(int pContractID)
        {
            int contractrateid = 0;
            var qry = (from c in context.Contracts
                       join cr in context.Contract_Rates on c.ContractID equals cr.ContractID
                       where cr.IsActive == true
                       select new { cr.ContractRateID }).FirstOrDefault();
            if (qry != null)
            {
                contractrateid = qry.ContractRateID;
            }

            return contractrateid;
        }

        private int getExtenedInvID(int pContractID)
        {
            int extendedCustID = 0;
            var qry = (from c in context.Contracts
                       where c.ContractID == pContractID
                       select new { c.CustomerID }).FirstOrDefault();
            if (qry != null)
            {
                extendedCustID = qry.CustomerID;
            }

            return extendedCustID;

        }

        private void searchLookUpEditContractNo_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lookContractClauseID.EditValue.ToString()))
            {
                int contclauseid = 0;
                bool res = false;
                res = int.TryParse(this.lookContractClauseID.EditValue.ToString(), out contclauseid);
                if (res == false) { contclauseid = 0; }


                int invtypeid = 0;

                if (contclauseid == 0)
                { return; }


                var qryComp = (from c in context.ContractClosures
                               join exC in context.Extended_Customers on c.ExtendedCustomerID equals exC.ExtendedCustomerID
                               join gCust in context.Global_Customers on exC.CustomerID equals gCust.CustomerID
                               where c.ContractClosureID == contclauseid
                               select new { c.CompanyID, c.LocationID, gCust.CustomerID }).FirstOrDefault();
                if (qryComp != null)
                {
                    this.lookCompany.EditValue = qryComp.CompanyID;
                    this.lookUpEditCustomerID.EditValue = qryComp.CustomerID;
                    this.lookLocation.EditValue = qryComp.LocationID;
                }

                // to get other invoice details only credit note ravindra
                if (pInvoiceType == eInvoiceType.CreditNote)
                {
                    // string invoiceNo = chkcboInvoiceNo.Text.Trim();
                    string invoiceNo = invoiceNolookup.Text.Trim();
                    var qryinv = (from i in context.Invoices
                                  where i.InvoiceNo == invoiceNo
                                  select new { i.RentPerMonth, i.SCPerMonth, i.Naration }).FirstOrDefault();

                    if (qryinv != null)
                    {
                        txtRentAmount.Text = qryinv.RentPerMonth.ToString();
                        txtServiceChargeAmount.Text = qryinv.SCPerMonth.ToString();
                        narationMemoEdit.Text = qryinv.Naration;

                    }
                }
                // Querying tax info this form gets only rent invoices details. 

                if (invtypeid == 1)
                {
                    var qryContractTax = (from t in context.Taxes
                                          join tr in context.TaxRates on t.TaxID equals tr.TaxID
                                          where tr.IsActive == true
                                          select new { t.TaxID, tr.TaxRateID }).ToList();

                    if (invDetList.Count > 0) { invDetList.Clear(); }

                    foreach (var qry in qryContractTax)
                    {
                        Invoice_Details oInvDet = new Invoice_Details();
                        oInvDet.TaxID = qry.TaxID;
                        oInvDet.TaxRateID = qry.TaxRateID;
                        oInvDet.Amount = 0;
                        invDetList.Add(oInvDet);
                    }

                    this.invoice_DetailsBindingSource.DataSource = invDetList.ToList();
                }

            }

        }
        

        private void txtAmount_EditValueChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtAmount.Text.ToString()))
            //{              

            //    calTotal();
            //}
        }

        private void calTotal(decimal pVarianceAmt)
        {
            if (pInvoiceType == eInvoiceType.CreditNote)
            {
                if (pVarianceAmt > 0)
                {
                    pVarianceAmt = pVarianceAmt * -1;
                }
            }

            bool res = false;
            int contclauseid = 0;
            res = int.TryParse(this.lookContractClauseID.EditValue.ToString(), out contclauseid);
            if (res == false) { contclauseid = 0; }
            if (contclauseid == 0)
            {
                if (!pVarianceAmt.Equals(0))
                {
                    dxErrorProvider1.SetError(this.lookContractClauseID, "Invalid Shop");
                    return;
                }
            }

            invDetList.Clear();
            bool IsTaxCalApply = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicable(contclauseid);

            cMandatoryTax _mandatoryTax = cTaxCalculations.getAmountWithMandatoryTax(pVarianceAmt);
            Invoice_Details oInvDet = new Invoice_Details();
            oInvDet.TaxCode = _mandatoryTax.MandatoryTaxCode;
            oInvDet.TaxID = _mandatoryTax.MandatoryTaxID;
            oInvDet.TaxRate = _mandatoryTax.MandatoryTaxRate;
            oInvDet.TaxRateID = _mandatoryTax.MandatoryTaxRateID;
            if (IsTaxCalApply == true)
            {
                oInvDet.Amount = _mandatoryTax.MandatoryTaxAmount;
            }
            else { oInvDet.Amount = 0; }

            // record creation time 
            oInvDet.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
            oInvDet.CreatedDate = DateTime.Now;
            //

            invDetList.Add(oInvDet);

            decimal TotalwithMandatoryTax = _mandatoryTax.TotalWithMandatoryTax;

            List<cOtherTax> otherTaxList = cTaxCalculations.getOtherTax(TotalwithMandatoryTax);
            foreach (var qry in otherTaxList)
            {
                oInvDet = new Invoice_Details();
                oInvDet.TaxCode = qry.TaxCode;
                oInvDet.TaxID = qry.TaxID;
                oInvDet.TaxRateID = qry.TaxRateID;
                oInvDet.TaxRate = qry.TaxRate;
                if (IsTaxCalApply == true)
                {
                    oInvDet.Amount = qry.TaxAmount;
                }

                //record creation time 
                oInvDet.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                oInvDet.CreatedDate = DateTime.Now;

                invDetList.Add(oInvDet);
            }

            decimal totaltax = invDetList.Sum(x => x.Amount);

            decimal totalamount = totaltax + pVarianceAmt;
            this.txtAmount.EditValue = totalamount;

            if (!pVarianceAmt.Equals(0))
            {
                this.invoice_DetailsBindingSource.DataSource = invDetList;
            }
            else
            {
                this.invoice_DetailsBindingSource.DataSource = null;
            }

            this.invoice_DetailsGridControl.RefreshDataSource();
        }

        private decimal getAmount(int pTaxRateID, decimal totalwithSC)
        {
            decimal taxrate = 0;
            var qryTaxRate = (from tr in context.TaxRates
                              where tr.TaxRateID == pTaxRateID
                              select new { tr.TaxRate1 }).FirstOrDefault();

            if (qryTaxRate != null)
            {
                taxrate = qryTaxRate.TaxRate1;

            }

            decimal amount = 0;
            amount = (taxrate * totalwithSC) / 100;
            return amount;

        }

        private void txtAmount_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void lookUpEditInvoiceType_EditValueChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(this.lookUpEditInvoiceType.Text.ToString()))
            //{
            //    //int invtypeid = 0;
            //    //bool res = int.TryParse(lookUpEditInvoiceType.EditValue.ToString(), out invtypeid);
            //    //if (res == false) { invtypeid = 0; }

            //    //if (invtypeid == 2)
            //    //{
            //    //    lblUtilityInvType.Visible = true;
            //    //    lookUpEditUtilityType.Visible = true;
            //    //}
            //    //else
            //    //{
            //    //    lblUtilityInvType.Visible = false;
            //    //    lookUpEditUtilityType.Visible = false;
            //    //}

            //    if (invtypeid > 0)
            //    {
            //        var qryInvoices = (from i in context.Invoices
            //                           join exc in context.Extended_Customers on i.ExtendedCustomerID equals exc.ExtendedCustomerID
            //                           join loc in context.Locations on i.LocationID equals loc.LocationID
            //                           join comp in context.Companies on i.CompanyID equals comp.CompanyID
            //                           join gcust in context.Global_Customers on exc.CustomerID equals gcust.CustomerID
            //                           where i.InvoiceTypeID == invtypeid && i.IsConfirmed == true
            //                           select new { i.InvoiceID, i.InvoiceNo, gcust.CustomerName, loc.LocationCode, comp.CompanyCode, i.TotalAmount, i.TotalTax, GrandTotal = i.TotalAmount + i.TotalTax }).ToList();

            //        this.searchLookUpEditInvoiceNo.Properties.DataSource = qryInvoices;
            //        this.searchLookUpEditInvoiceNo.Properties.DisplayMember = "InvoiceNo";
            //        this.searchLookUpEditInvoiceNo.Properties.ValueMember = "InvoiceID";

            //    }

            //}
        }

        private string getShopNo(int pContractID)
        {
            string shopnos = string.Empty;
            var qryShopnos = (from cs in context.Contract_Shops
                              join s in context.Shops on cs.ShopID equals s.ShopID
                              where cs.ContractID == pContractID
                              select new { s.ShopNo }).ToList();

            foreach (var qry in qryShopnos)
            {
                if (qryShopnos.Count == 1)
                {
                    shopnos = qry.ShopNo;
                }
                else
                {
                    shopnos = shopnos + "," + qry.ShopNo;
                }
            }


            return shopnos;

        }

        private string getShopName(int pContractID)
        {
            string shopname = string.Empty;

            var qryShopName = (from s in context.Contracts
                               where s.ContractID == pContractID
                               select new { s.ShopName }).FirstOrDefault();
            if (qryShopName != null)
            {
                shopname = qryShopName.ShopName;
            }

            return shopname;
        }

        private void dtDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditLocationID_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
            {
                return;
            }

            int locid = 0;
            bool res = int.TryParse(this.lookLocation.EditValue.ToString(), out locid);
            if (res == false)
            {
                locid = 0;
            }

            if (locid > 0)
            {
                var qrySC = (from l in context.Locations
                             where l.LocationID == locid
                             select new { l.SCperSqFt }).FirstOrDefault();
                if (qrySC != null)
                {

                }

            }


        }

        private void searchLookUpEditInvoiceNo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dateEditTo_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditTo.Text.ToString()))
            {
                return;
            }
            else if (!(string.IsNullOrEmpty(this.dateEditTo.Text.ToString())) && !(string.IsNullOrEmpty(this.dateEditFrom.Text.ToString())))
            {
                
                getInvoiceNo(dateEditFrom.EditValue.ToString(), dateEditTo.EditValue.ToString());
            }



        }
       // List<cGen_Rent_Invoice> cGenInvList = new List<cGen_Rent_Invoice>();
        private void getInvoiceNo(string pFromDate, string pToDate)
        {
            DateTime dateFrom;
            DateTime dateTo;

            bool res = false;
            res = DateTime.TryParse(pFromDate, out dateFrom);
            if (res == false) { return; }

            res = DateTime.TryParse(pToDate, out dateTo);
            if (res == false) { return; }

            int LocId = int.Parse(lookUpEdit1.EditValue.ToString());
             int ComId = int.Parse(lookCompanies.EditValue.ToString());

            //load Invoice No
            if (pInvoiceType == eInvoiceType.CreditNote)
            {
                //var qryInv = (from i in context.Invoices
                //              where (i.DateFrom >= dateFrom && i.DateTo <= dateTo) && (i.InvoiceTypeID == 1 || i.InvoiceTypeID == 3) && i.SubInvTypeID == 3 && i.IsConfirmed == true //&& i.ContractClosureID!=0//&& i.ContractClosureID == contclauseid
                //              select new { i.InvoiceNo, i.InvoiceID, i.ShopName }).ToList();
                //var qryInv = (from i in context.Invoices
                //              where (i.DateFrom >= dateFrom && i.DateTo <= dateTo) && (i.InvoiceTypeID != 2) && i.SubInvTypeID == 3  
                //                     && i.IsConfirmed == true && i.LocationID == LocId && i.CompanyID == ComId
                //              select new { i.InvoiceNo, i.InvoiceID, i.ShopName }).ToList();
                var qryInv = (from i in context.Invoices
                              where (i.InvoiceDate >= dateFrom && i.InvoiceDate <= dateTo) && (i.InvoiceTypeID != 2) && i.SubInvTypeID == 3
                                     && i.IsConfirmed == true && i.LocationID == LocId && i.CompanyID == ComId
                              select new { i.InvoiceNo, i.InvoiceID, i.ShopName }).ToList();
 
                this.invoiceNolookup.Properties.DataSource = qryInv;
                this.invoiceNolookup.Properties.DisplayMember = "InvoiceNo";
                this.invoiceNolookup.Properties.ValueMember = "InvoiceID";
                this.searchLookUpEdit1View.BestFitColumns();

                this.lookupInvoiceno.Properties.DataSource = qryInv;
                this.lookupInvoiceno.Properties.DisplayMember = "InvoiceNo";
                this.lookupInvoiceno.Properties.ValueMember = "InvoiceID";
                
            }


        }

        private void dateEditFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(this.dateEditFrom.Text.ToString())) && !(string.IsNullOrEmpty(this.dateEditTo.Text.ToString())))
            {
                getInvoiceNo(dateEditFrom.EditValue.ToString(), dateEditTo.EditValue.ToString());
                
            }

        }

        //private void chkcboInvoiceNo_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
        //    { return; }

        //    int nosdays = 0;
        //    string sFromdate = this.dateEditFrom.EditValue.ToString();
        //    string sToDate = this.dateEditTo.EditValue.ToString();
        //    DateTime fromDate; DateTime toDate;
        //    bool res = false;

        //    if (string.IsNullOrEmpty(sFromdate.ToString().Trim()))
        //    {
        //        dxErrorProvider1.SetError(this.dateEditFrom, "Invalid From Date");
        //    }
        //    else { dxErrorProvider1.SetError(this.dateEditFrom, ""); }


        //    if (string.IsNullOrEmpty(sToDate.Trim()))
        //    { dxErrorProvider1.SetError(this.dateEditTo, "Invalid To Date"); }
        //    else { dxErrorProvider1.SetError(this.dateEditTo, ""); }



        //    res = DateTime.TryParse(sFromdate, out fromDate);
        //    if (res == false) { dxErrorProvider1.SetError(this.dateEditFrom, "Invalid From Date"); return; }
        //    else { dxErrorProvider1.SetError(this.dateEditFrom, ""); }

        //    res = DateTime.TryParse(sToDate, out toDate);
        //    if (res == false) { dxErrorProvider1.SetError(this.dateEditTo, "Invalid To Date"); }
        //    else { dxErrorProvider1.SetError(this.dateEditTo, ""); }

        //    nosdays = toDate.Subtract(fromDate).Days;

        //    string selected = this.chkcboInvoiceNo.Properties.GetCheckedItems().ToString();
        //    List<decimal> OldValueList = new List<decimal>();
        //    List<decimal> NewValueList = new List<decimal>();

        //    string theString = selected;
        //    if (string.IsNullOrEmpty(theString.ToString())) { return; }

        //    List<int> ints = theString.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));

        //    var qryInv = (from i in context.Invoices
        //                  where ints.Contains(i.InvoiceID)
        //                  select new { i.RentPerMonth, i.RentWithSCPerMonth, i.ContractClosureID, i.Contract_RentSchemeID }).ToList();
        //    foreach (var qry in qryInv)
        //    {
        //        decimal oldvalue = qry.RentPerMonth + qry.RentWithSCPerMonth;
        //        OldValueList.Add(oldvalue);

        //        decimal newvalue = 0;
        //        var qryNewRent = (from r in context.Contract_RentSchemes
        //                          join c in context.ContractClosures on r.ContractClosureID equals c.ContractClosureID
        //                          where r.ContractClosureID == qry.ContractClosureID && r.Contract_RentSchemeID > qry.Contract_RentSchemeID
        //                          select new { c.FloorArea, r.RentPerSqFeet, r.SCPerSqFeet }).FirstOrDefault();
        //        if (qryNewRent != null)
        //        {
        //            newvalue = qryNewRent.RentPerSqFeet + qryNewRent.SCPerSqFeet;
        //            //newvalue = newvalue * qryNewRent.FloorArea 
        //        }


        //    }

        //    //pass contractID to lookupcontractclouserID  ravindra
        //    if (pInvoiceType == eInvoiceType.CreditNote)
        //    {
        //        var reslt = (from i in context.Invoices
        //                     where ints.Contains(i.InvoiceID)
        //                     select new { i.ShopNo, i.ContractClosureID }).FirstOrDefault();

        //        this.lookContractClauseID.EditValue = reslt.ContractClosureID;

        //    }

        //}

        private void btnVarianceAmount_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.btnVarianceAmount.Text.ToString()))
            { return; }

            bool res = false;
            decimal varianceAmt = 0;
            res = decimal.TryParse(this.btnVarianceAmount.EditValue.ToString(), out varianceAmt);
            if (res == false)
            { dxErrorProvider1.SetError(this.btnVarianceAmount, "Invalid Amount"); return; }
            else { dxErrorProvider1.SetError(this.btnVarianceAmount, ""); }

            if (pInvoiceType == eInvoiceType.CreditNote)
            {
                if (varianceAmt > 0)
                {
                    varianceAmt = varianceAmt * -1;
                }
            }

            calTotal(varianceAmt);

        }

        private void btnVarianceAmount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                rentvariation = new Transaction.Rent.xRentVariation();
                //rentvariation.Load+=new EventHandler(rentvariation_Load);
                rentvariation.FormClosing += new FormClosingEventHandler(rentvariation_FormClosing);

                // contract id 
                int contclauseid = 0;
                bool res = false;
                res = int.TryParse(this.lookContractClauseID.EditValue.ToString(), out contclauseid);
               
                if (res == false) { contclauseid = 0; }

                //old contract id 
                int oldcontractid = 0;
                var qryoldcontract = (from c in context.ContractClosures
                                      where c.ContractClosureID == contclauseid
                                      select new { c.RefNo }).FirstOrDefault();
                if (qryoldcontract != null) { oldcontractid = qryoldcontract.RefNo; }

                rentvariation.NewContractID = contclauseid;
                rentvariation.OldContractID = oldcontractid;
                rentvariation.Show(this);
                // - 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void rentvariation_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                btnVarianceAmount.EditValue = rentvariation.DifferenceValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void c1ToolBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.ClearText();
            //this.enable_control(false, eRecStatus.eInit);
            load_data();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_data();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                ////validating fields..

                //// date validation
                if (string.IsNullOrEmpty(this.dtDate.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.dtDate, "Invalid Date");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.dtDate, "");
                }
                if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.dateEditFrom, "Invalid Date");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.dtDate, "");
                }
                if (string.IsNullOrEmpty(this.dateEditTo.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.dateEditTo, "Invalid Date");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.dtDate, "");
                }

                int contclauseid = 0;
                bool res = false;
                ////validating shop and contract
                if (pInvoiceType == eInvoiceType.Adjustment)
                {
                    if (string.IsNullOrEmpty(this.lookContractClauseID.Text.ToString()))
                    {
                        dxErrorProvider1.SetError(this.lookContractClauseID, "Invalid Shop");
                        return;
                    }
                    else
                    {
                        dxErrorProvider1.SetError(this.lookContractClauseID, "");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(this.txtshopno.Text.ToString()))
                    {
                        dxErrorProvider1.SetError(this.txtshopno, "Invalid Shop");
                        return;
                    }
                    else
                    {
                        dxErrorProvider1.SetError(this.txtshopno, "");
                    }


                }


                res = int.TryParse(this.lookContractClauseID.EditValue.ToString(), out contclauseid);


                if (res == false)
                {
                    contclauseid = 0;
                }
                if (contclauseid == 0)
                {
                    dxErrorProvider1.SetError(this.lookContractClauseID, "Invalid Shop");
                    return;
                }
                else { dxErrorProvider1.SetError(this.lookContractClauseID, ""); }

                //// amount validation
                if (string.IsNullOrEmpty(this.txtAmount.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.txtAmount, "Invalid Amount");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.txtAmount, "");
                }


                decimal totalAmount = 0;
                res = decimal.TryParse(this.txtAmount.EditValue.ToString(), out totalAmount);
                if (res == false)
                {
                    dxErrorProvider1.SetError(this.txtAmount, "Invalid Amount");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.txtAmount, "");
                }

                decimal amount = 0;
                res = decimal.TryParse(this.btnVarianceAmount.EditValue.ToString(), out amount);
                if (res == false)
                {
                    dxErrorProvider1.SetError(this.btnVarianceAmount, "Invalid Amount");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.btnVarianceAmount, "");
                }
                if (pInvoiceType == eInvoiceType.CreditNote)
                {
                    amount = amount * -1;
                }

                ////Comment below lines, due to add new text boxes for Rent and SC..17Nove2014 by Roshan..
                //// type validation
                ////if (radioGroup1.SelectedIndex < 0)
                ////{
                ////    dxErrorProvider1.SetError(this.radioGroup1, "Select Rent,Service Charge or All");
                ////    return;
                ////}
                ////else 
                ////{ 
                ////    dxErrorProvider1.SetError(this.radioGroup1, ""); 
                ////}

                //// End validations --

                Invoice oInvoice = new Invoice();
                oInvoice.ContractClosureID = contclauseid;
                oInvoice.ShopID = MMS.CustomClasses.cCommon_Functions.getShopID(contclauseid);
                oInvoice.ShopName = MMS.CustomClasses.cCommon_Functions.getShopName(contclauseid);
                oInvoice.ShopNo = MMS.CustomClasses.cCommon_Functions.getShopNo(contclauseid);
                oInvoice.CustomerID = int.Parse(lookUpEditCustomerID.EditValue.ToString());
                oInvoice.CustomerName = lookUpEditCustomerID.Text.ToString();
                bool IsTaxCalApply = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicable(contclauseid);
                oInvoice.IsTaxApplicable = IsTaxCalApply;

                //// var qryExtendedCustomerID 
                var qryExCust = (from c in context.ContractClosures
                                 where c.ContractClosureID == contclauseid
                                 select new { c.ExtendedCustomerID }).FirstOrDefault();
                int extendedCustID = qryExCust.ExtendedCustomerID;

                //// 
                oInvoice.TaxRegNo = MMS.CustomClasses.cCommon_Functions.getTaxRegNo(extendedCustID, true);
                //oInvoice.RefInvNo = chkcboInvoiceNo.Text.ToString();
                oInvoice.RefInvNo = invoiceNolookup.Text.ToString();
                oInvoice.IsTaxCustomer = MMS.CustomClasses.cCommon_Functions.IsTaxCustomer(oInvoice.CustomerID);
                oInvoice.FooterText1 = this.txtInvoiceFooter.Text.ToString();

                var qryCustAdd = (from c in context.Global_Customers
                                  where c.CustomerID == oInvoice.CustomerID
                                  select new { c.CompanyAddress }).FirstOrDefault();
                if (qryCustAdd != null)
                {
                    oInvoice.CustomerAddress = qryCustAdd.CompanyAddress;
                }
                var qryCont = (from c in context.ContractClosures
                               where c.ContractClosureID == oInvoice.ContractClosureID
                               select new { c.ExtendedCustomerID, c.LevelID, c.ShopID, c.ContractClosureID }).FirstOrDefault();
                if (qryCont != null)
                {
                    oInvoice.ExtendedCustomerID = qryCont.ExtendedCustomerID;
                    oInvoice.LevelID = qryCont.LevelID;
                    oInvoice.LevelName = context.Floor_Levels.Where(x => x.LevelID == qryCont.LevelID).FirstOrDefault().LevelName;

                    oInvoice.ShopID = qryCont.ShopID;

                    ////getting active rent scheme from Contract_RentScheme table 

                    var contclosureid = cActiveRentScheme.getDefaultOrLastRate(dtDate.DateTime, qryCont.ContractClosureID, dateEditFrom.DateTime, dateEditTo.DateTime);
                    oInvoice.ContractClosureID = contclosureid.ContractClosureID;
                    oInvoice.Contract_RentSchemeID = contclosureid.Contract_RentSchemeID;

                    oInvoice.RentPerSqFt = contclosureid.RentPerSqFeet;
                    oInvoice.SCPerSqFt = contclosureid.SCperSqFeet;

                    //// -- 
                }

                oInvoice.CompanyID = int.Parse(lookCompany.EditValue.ToString());
                oInvoice.CompanyCode = context.Companies.Where(x => x.CompanyID == oInvoice.CompanyID).FirstOrDefault().CompanyCode;
                oInvoice.LocationID = int.Parse(lookLocation.EditValue.ToString());
                oInvoice.LocationCode = context.Locations.Where(x => x.LocationID == oInvoice.LocationID).FirstOrDefault().LocationCode;
                oInvoice.ProcessYear = dtDate.DateTime.Year;
                oInvoice.ProcessMonth = dtDate.DateTime.Month;
                oInvoice.DateFrom = dateEditFrom.DateTime;
                oInvoice.DateTo = dateEditTo.DateTime;
                int nosdays = dateEditTo.DateTime.Subtract(dateEditTo.DateTime).Days;
                oInvoice.NosDay = nosdays;

                oInvoice.RentWithSCPerMonth = amount;

                ////////****To Add Rent and Service charge together **** by Roshan..17Nove2014//////
                decimal rentAmount = 0;
                decimal scamount = 0;

                oInvoice.IsRentVariance = false;
                oInvoice.IsSCVariance = false;

                bool isrent = decimal.TryParse(txtRentAmount.EditValue.ToString(), out rentAmount);
                if (isrent)
                {
                    oInvoice.RentPerMonth = rentAmount;
                    if (rentAmount > 0)
                    {
                        oInvoice.IsRentVariance = true;
                    }
                }

                bool isscAmount = decimal.TryParse(txtServiceChargeAmount.EditValue.ToString(), out scamount);
                if (isscAmount)
                {
                    oInvoice.SCPerMonth = scamount;
                    if (scamount > 0)
                    {
                        oInvoice.IsSCVariance = true;
                    }
                }

                ////below formula(@fRent) is removed from "rptRentalIncome.rpt" report, to display rent and service charge in one row
                ////curruently both values are displaying as "RentAmount" with adjustment

                //////if {DataTier_ReportClasses_ShopOccupancy.SubInvoiceTypeID} = 3 then
                //////{DataTier_ReportClasses_ShopOccupancy.RentPerMonth}
                //////else 
                //////{DataTier_ReportClasses_ShopOccupancy.RentWithSCperMonth}

                ////////****END--To Add Rent and Service charge together **** by roshan..17Nove2014//////


                //// mandatory tax 
                var qryMandatoryTax = (from m in invDetList
                                       join t in context.Taxes on m.TaxID equals t.TaxID
                                       where t.IsMandatory == true
                                       select new { MandatoryTaxAmount = m.Amount, MandatoryTaxCode = m.TaxCode, MandatoryTaxID = m.TaxID, MandatoryTaxRateID = m.TaxRateID }).FirstOrDefault();
                if (qryMandatoryTax != null)
                {
                    if (IsTaxCalApply == true) //// global tax
                    {
                        oInvoice.MandatoryTaxAmount = qryMandatoryTax.MandatoryTaxAmount;
                    }
                    else
                    {
                        oInvoice.MandatoryTaxAmount = 0;
                    }

                    oInvoice.MandatoryTaxCode = qryMandatoryTax.MandatoryTaxCode;
                    oInvoice.MandatoryTaxID = qryMandatoryTax.MandatoryTaxID;
                    oInvoice.MandatoryTaxRateID = qryMandatoryTax.MandatoryTaxRateID;

                    if (pInvoiceType == eInvoiceType.CreditNote)
                    {
                        if (IsTaxCalApply == true) //// global tax
                        {
                            oInvoice.MandatoryTaxAmount = oInvoice.MandatoryTaxAmount * -1;
                        }
                        else
                        {
                            oInvoice.MandatoryTaxAmount = 0;
                        }
                    }
                }

                var qryOtherTax = (from m in invDetList
                                   join t in context.Taxes on m.TaxID equals t.TaxID
                                   where t.IsMandatory == false
                                   select new { m.Amount }).Sum(x => x.Amount);
                decimal totalTax = invDetList.Sum(x => x.Amount);
                if (IsTaxCalApply == true)
                {
                    oInvoice.TotalTax = totalTax;
                }
                else
                {
                    oInvoice.TotalTax = 0;
                }


                if (qryOtherTax > 0)
                {
                    if (IsTaxCalApply == true)
                    {
                        oInvoice.OtherTax = qryOtherTax;
                    }
                    else
                    {
                        oInvoice.OtherTax = 0;
                    }

                    if (pInvoiceType == eInvoiceType.CreditNote)////////credite note
                    {
                        if (IsTaxCalApply == true)
                        {
                            oInvoice.OtherTax = oInvoice.OtherTax * -1;
                        }
                        else
                        {
                            oInvoice.OtherTax = 0;
                        }
                    }
                }

                if (pInvoiceType == eInvoiceType.CreditNote)////////credite note
                {
                    amount = amount * -1;
                    oInvoice.TotalWithMandatoryTax = amount + oInvoice.MandatoryTaxAmount;
                }
                else
                {
                    oInvoice.TotalWithMandatoryTax = amount + oInvoice.MandatoryTaxAmount;
                }

                oInvoice.TotalRentPerMonth = totalAmount;
                if (pInvoiceType == eInvoiceType.CreditNote)
                {
                    totalAmount = totalAmount * -1;
                    oInvoice.TotalRentPerMonth = totalAmount;
                    oInvoice.TotalTax = oInvoice.TotalTax * -1;
                }

                ////- 


                oInvoice.Naration = narationMemoEdit.Text;
                oInvoice.InvoiceDate = dtDate.DateTime;
                oInvoice.SAP_PstnDateInDoc = dtDate.DateTime;
                oInvoice.ModifiedDate = DateTime.Now;
                oInvoice.IsProcessed = true;
                oInvoice.IsConfirmed = false;

                string invoiceType = "";

                if (pInvoiceType == eInvoiceType.Adjustment)
                {
                    oInvoice.SubInvTypeID = 1; //// Adjustment (Invoice/CreditNote/Adjustment)
                    invoiceType = "Adjustment";
                }
                if (pInvoiceType == eInvoiceType.CreditNote)
                {
                    oInvoice.SubInvTypeID = 2; //// Credit Note (1-Invoice/2-CreditNote/3-Adjustment)
                    invoiceType = "Credit Note";
                }


                oInvoice.InvoiceTypeID = 1;  //// 1- RENT INVOICE 2 - Utility Invoice
                ////credit note values (-)

                if (pInvoiceType == eInvoiceType.CreditNote)
                {
                    if (oInvoice.RentPerSqFt > 0)
                    {
                        oInvoice.RentPerSqFt = oInvoice.RentPerSqFt * -1;
                    }
                    if (oInvoice.SCPerSqFt > 0)
                    {
                        oInvoice.SCPerSqFt = oInvoice.SCPerSqFt * -1;
                    }
                    if (oInvoice.RentPerMonth > 0)
                    {
                        oInvoice.RentPerMonth = oInvoice.RentPerMonth * -1;
                    }
                    if (oInvoice.SCPerMonth > 0)
                    {
                        oInvoice.SCPerMonth = oInvoice.SCPerMonth * -1;
                    }
                    if (oInvoice.RentWIthSCPerSqFt > 0)
                    {
                        oInvoice.RentWIthSCPerSqFt = oInvoice.RentWIthSCPerSqFt * -1;
                    }
                    if (oInvoice.TotalAmount > 0)
                    {
                        oInvoice.TotalAmount = oInvoice.TotalAmount * -1;
                    }
                    if (oInvoice.TotalTax > 0)
                    {
                        oInvoice.TotalTax = oInvoice.TotalTax * -1;
                    }
                    if (oInvoice.RentWithSCPerMonth > 0)
                    {
                        oInvoice.RentWithSCPerMonth = oInvoice.RentWithSCPerMonth * -1;
                    }
                    if (oInvoice.MandatoryTaxAmount > 0)
                    {
                        oInvoice.MandatoryTaxAmount = oInvoice.MandatoryTaxAmount * -1;
                    }
                    if (oInvoice.TotalWithMandatoryTax > 0)
                    {
                        oInvoice.TotalWithMandatoryTax = oInvoice.TotalWithMandatoryTax * -1;
                    }
                    if (oInvoice.TotalRentPerMonth > 0)
                    {
                        oInvoice.TotalRentPerMonth = oInvoice.TotalRentPerMonth * -1;
                    }

                }

                ////record creation time 
                oInvoice.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                oInvoice.CreatedDate = DateTime.Now;
                ////


                //// SAP field update
                //// document header update
                oInvoice.SAP_DocHeaderText = "R" + oInvoice.ShopNo + dtDate.DateTime.Month.ToString() + dtDate.DateTime.Year.ToString();

                ////SAP fields update

                oInvoice.SAP_Assignment = "RENT";
                //oInvoice.SAP_Text = "RENT" + "_" + oInvoice.ShopNo.ToString().Trim() + "_" + MMS.CustomClasses.cCommon_Functions.getMonthAbbrName(dtDate.DateTime.Month) + "_" + dtDate.DateTime.Year.ToString();
                string sapText = narationMemoEdit.Text.ToString();
                if (sapText.ToString().Length > 50)
                {
                    sapText = sapText.Substring(0, 50).ToString().Trim();
                }

                oInvoice.SAP_Text = sapText;
                oInvoice.SAP_RefKey1 = oInvoice.ShopNo;
                oInvoice.SAP_RefKey2 = oInvoice.ShopName;
                oInvoice.SAP_RefKey3 = "FIXED";
                //// document type
                var qryDT = (from dt in context.SAP_DocTypes
                             where dt.CompanyID == oInvoice.CompanyID && dt.InvoiceTypeID == 1
                             select dt).FirstOrDefault();
                if (qryDT != null)
                {
                    oInvoice.SAP_DocType = qryDT.DOCTYPE;
                }

                //// Comment below lines (implement inside above newlly added section), due to add new text boxes for Rent and SC..17Nove2014 by Roshan..
                ////if (radioGroup1.SelectedIndex == 0) /// rent variance
                ////{
                ////    oInvoice.IsRentVariance = true;

                ////}
                ////else  //// service charge variance 
                ////{
                ////    oInvoice.IsSCVariance = true;
                ////}

                context.Invoices.AddObject(oInvoice);

                foreach (var qry in invDetList)
                {
                    Invoice_Details oInvDet = new Invoice_Details();
                    oInvDet.Amount = qry.Amount;
                    if (pInvoiceType == eInvoiceType.CreditNote)
                    {
                        if (oInvDet.Amount > 0)
                        {
                            oInvDet.Amount = oInvDet.Amount * -1;
                        }
                    }
                    oInvDet.TaxRateID = qry.TaxRateID;
                    oInvDet.TaxID = qry.TaxID;
                    oInvDet.TaxCode = qry.TaxCode;
                    oInvDet.TaxRate = qry.TaxRate;
                    bool IsMandatory = MMS.CustomClasses.cCommon_Functions.IsMandatory(qry.TaxID);
                    if (IsMandatory == false)
                    {
                        oInvDet.IsPrint = true;
                    }
                    else { oInvDet.IsPrint = false; }

                    //record creation time 
                    oInvDet.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oInvDet.CreatedDate = DateTime.Now;
                    // -- 

                    oInvoice.Invoice_Details.Add(oInvDet);
                }

                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Save Success - Adjustment/Credit Note - Rent Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // email alert
                    int alertC = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.CreditNoteProcessedRenInvoice;
                    int alertA = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.AdjustmentProcessedRentInvoice;
                    if (pInvoiceType == eInvoiceType.Adjustment)
                    {
                        MMS.CustomClasses.cCommon_Functions.AddToEmailList(int.Parse(lookCompany.EditValue.ToString()), int.Parse(this.lookLocation.EditValue.ToString()), alertA, "Customer : " + this.lookUpEditCustomerID.Text.ToString() + System.Environment.NewLine + "Shop No : " + this.lookContractClauseID.Text.ToString(), MMS.CustomClasses.cCommon_Functions.LoggedUserID);
                    }
                    else // Credit Note
                    {
                        MMS.CustomClasses.cCommon_Functions.AddToEmailList(int.Parse(lookCompany.EditValue.ToString()), int.Parse(this.lookLocation.EditValue.ToString()), alertC, "Customer : " + this.lookUpEditCustomerID.Text.ToString() + System.Environment.NewLine + "Shop No : " + this.lookContractClauseID.Text.ToString(), MMS.CustomClasses.cCommon_Functions.LoggedUserID);
                    }
                }

                this.Clear();

                cEnable_Controls.ClearText(this);//05052014...to clear form controls
                dtDate.DateTime = DateTime.Now.Date;

                load_data();
                ////this.enable_control(false, eRecStatus.eSave);

                btnNew.Enabled = true;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                ////enable_control(true, eRecStatus.eAddNew);
                ////this.ClearText();

                cEnable_Controls.ClearText(this);//05052014...to clear form controls

                dtDate.DateTime = DateTime.Now.Date;

                btnNew.Enabled = false;
                btnSave.Enabled = true;
                ////btnDelete.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            dtDate.EditValue = null;

            this.lookContractClauseID.EditValue = string.Empty;
            this.lookUpEditCustomerID.EditValue = null;
            this.lookCompany.EditValue = null;
            this.lookLocation.EditValue = null;

            dateEditFrom.EditValue = null;
            dateEditTo.EditValue = null;
            //chkcboInvoiceNo.EditValue = null;
            invoiceNolookup.EditValue = null;
           
           
            btnVarianceAmount.EditValue = 0;
            txtAmount.EditValue = 0;

            narationMemoEdit.EditValue = null;

            invoice_DetailsBindingSource.DataSource = null;
            //this.invoice_DetailsGridControl.RefreshDataSource();
        }

        private void txtRentAmount_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtRentAmount.Text.ToString()))
            { 
                return; 
            }

            bool res = false;
            decimal varianceAmt = 0;
            res = decimal.TryParse(this.txtRentAmount.EditValue.ToString(), out varianceAmt);
            if (res == false)
            { 
                dxErrorProvider1.SetError(this.txtRentAmount, "Invalid Rent Amount"); 
                return; 
            }
            else 
            { 
                dxErrorProvider1.SetError(this.txtRentAmount, ""); 
            }

            decimal existingSCValue = 0;
            if (!string.IsNullOrEmpty(this.txtServiceChargeAmount.Text.ToString()))
            {
                existingSCValue = Convert.ToDecimal(txtServiceChargeAmount.EditValue.ToString());
            }

            btnVarianceAmount.EditValue = varianceAmt + existingSCValue;
            btnVarianceAmount_EditValueChanged(null, null);
        }

        private void txtServiceChargeAmount_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtServiceChargeAmount.Text.ToString()))
            {
                return;
            }

            bool res = false;
            decimal varianceAmt = 0;
            res = decimal.TryParse(this.txtServiceChargeAmount.EditValue.ToString(), out varianceAmt);
            if (res == false)
            {
                dxErrorProvider1.SetError(this.txtServiceChargeAmount, "Invalid Rent Amount");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.txtServiceChargeAmount, "");
            }

            decimal existingRentValue = 0;
            if (!string.IsNullOrEmpty(this.txtRentAmount.Text.ToString()))
            {
                existingRentValue = Convert.ToDecimal(txtRentAmount.EditValue.ToString());
            }

            btnVarianceAmount.EditValue = varianceAmt + existingRentValue;
            btnVarianceAmount_EditValueChanged(null, null);
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lookupInvoiceno_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
            { return; }

            int nosdays = 0;
            string sFromdate = this.dateEditFrom.EditValue.ToString();
            string sToDate = this.dateEditTo.EditValue.ToString();
            DateTime fromDate; DateTime toDate;
            bool res = false;

            if (string.IsNullOrEmpty(sFromdate.ToString().Trim()))
            {
                dxErrorProvider1.SetError(this.dateEditFrom, "Invalid From Date");
            }
            else { dxErrorProvider1.SetError(this.dateEditFrom, ""); }


            if (string.IsNullOrEmpty(sToDate.Trim()))
            { dxErrorProvider1.SetError(this.dateEditTo, "Invalid To Date"); }
            else { dxErrorProvider1.SetError(this.dateEditTo, ""); }



            res = DateTime.TryParse(sFromdate, out fromDate);
            if (res == false) { dxErrorProvider1.SetError(this.dateEditFrom, "Invalid From Date"); return; }
            else { dxErrorProvider1.SetError(this.dateEditFrom, ""); }

            res = DateTime.TryParse(sToDate, out toDate);
            if (res == false) { dxErrorProvider1.SetError(this.dateEditTo, "Invalid To Date"); }
            else { dxErrorProvider1.SetError(this.dateEditTo, ""); }

            nosdays = toDate.Subtract(fromDate).Days;

            string selected = this.lookupInvoiceno.EditValue.ToString();
            List<decimal> OldValueList = new List<decimal>();
            List<decimal> NewValueList = new List<decimal>();

            string theString = selected;
            if (string.IsNullOrEmpty(theString.ToString())) { return; }

            List<int> ints = theString.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));

            var qryInv = (from i in context.Invoices
                          where ints.Contains(i.InvoiceID)
                          select new { i.RentPerMonth, i.RentWithSCPerMonth, i.ContractClosureID, i.Contract_RentSchemeID }).ToList();
            foreach (var qry in qryInv)
            {
                decimal oldvalue = qry.RentPerMonth + qry.RentWithSCPerMonth;
                OldValueList.Add(oldvalue);

                decimal newvalue = 0;
                var qryNewRent = (from r in context.Contract_RentSchemes
                                  join c in context.ContractClosures on r.ContractClosureID equals c.ContractClosureID
                                  where r.ContractClosureID == qry.ContractClosureID && r.Contract_RentSchemeID > qry.Contract_RentSchemeID
                                  select new { c.FloorArea, r.RentPerSqFeet, r.SCPerSqFeet }).FirstOrDefault();
                if (qryNewRent != null)
                {
                    newvalue = qryNewRent.RentPerSqFeet + qryNewRent.SCPerSqFeet;
                    //newvalue = newvalue * qryNewRent.FloorArea 
                }


            }

            //pass contractID to lookupcontractclouserID  ravindra
            if (pInvoiceType == eInvoiceType.CreditNote)
            {
                var reslt = (from i in context.Invoices
                             where ints.Contains(i.InvoiceID)
                             select new { i.ShopNo, i.ContractClosureID }).FirstOrDefault();

                this.lookContractClauseID.EditValue = reslt.ContractClosureID;

            }
        }

        private void lookupInvoiceno_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void lookupInvoiceno_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
        }

        private void invoiceNolookup_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
            { return; }

            int nosdays = 0;
            string sFromdate = this.dateEditFrom.EditValue.ToString();
            string sToDate = this.dateEditTo.EditValue.ToString();
            DateTime fromDate; DateTime toDate;
            bool res = false;

            if (string.IsNullOrEmpty(sFromdate.ToString().Trim()))
            {
                dxErrorProvider1.SetError(this.dateEditFrom, "Invalid From Date");
            }
            else { dxErrorProvider1.SetError(this.dateEditFrom, ""); }


            if (string.IsNullOrEmpty(sToDate.Trim()))
            { dxErrorProvider1.SetError(this.dateEditTo, "Invalid To Date"); }
            else { dxErrorProvider1.SetError(this.dateEditTo, ""); }



            res = DateTime.TryParse(sFromdate, out fromDate);
            if (res == false) { dxErrorProvider1.SetError(this.dateEditFrom, "Invalid From Date"); return; }
            else { dxErrorProvider1.SetError(this.dateEditFrom, ""); }

            res = DateTime.TryParse(sToDate, out toDate);
            if (res == false) { dxErrorProvider1.SetError(this.dateEditTo, "Invalid To Date"); }
            else { dxErrorProvider1.SetError(this.dateEditTo, ""); }

            nosdays = toDate.Subtract(fromDate).Days;

            string selected = this.invoiceNolookup.EditValue.ToString();
            List<decimal> OldValueList = new List<decimal>();
            List<decimal> NewValueList = new List<decimal>();

            string theString = selected;
            if (string.IsNullOrEmpty(theString.ToString())) { return; }

            List<int> ints = theString.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));

            var qryInv = (from i in context.Invoices
                          where ints.Contains(i.InvoiceID)
                          select new { i.RentPerMonth, i.RentWithSCPerMonth, i.ContractClosureID, i.Contract_RentSchemeID }).ToList();
            foreach (var qry in qryInv)
            {
                decimal oldvalue = qry.RentPerMonth + qry.RentWithSCPerMonth;
                OldValueList.Add(oldvalue);

                decimal newvalue = 0;
                var qryNewRent = (from r in context.Contract_RentSchemes
                                  join c in context.ContractClosures on r.ContractClosureID equals c.ContractClosureID
                                  where r.ContractClosureID == qry.ContractClosureID && r.Contract_RentSchemeID > qry.Contract_RentSchemeID
                                  select new { c.FloorArea, r.RentPerSqFeet, r.SCPerSqFeet }).FirstOrDefault();
                if (qryNewRent != null)
                {
                    newvalue = qryNewRent.RentPerSqFeet + qryNewRent.SCPerSqFeet;
                    //newvalue = newvalue * qryNewRent.FloorArea 
                }


            }

            //pass contractID to lookupcontractclouserID  ravindra
            if (pInvoiceType == eInvoiceType.CreditNote)
            {
                var reslt = (from i in context.Invoices
                             where ints.Contains(i.InvoiceID)
                             select new { i.ShopNo, i.ContractClosureID }).FirstOrDefault();

                this.lookContractClauseID.EditValue = reslt.ContractClosureID;
                txtshopno.Text = reslt.ShopNo;

            }

            
        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void lookCompanies_EditValueChanged(object sender, EventArgs e)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                int comid = 0;
                bool res = false;
                res = int.TryParse(lookCompanies.EditValue.ToString(), out comid);
                if (res.Equals(true))
                {
                    var qryLoc = (from c in context.Companies
                                  join l in context.Locations on c.LocationID equals l.LocationID
                                  where c.CompanyID == comid
                                  select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();

                    this.locationBindingSource.DataSource = qryLoc;
                }
            }
        }

    }
}
