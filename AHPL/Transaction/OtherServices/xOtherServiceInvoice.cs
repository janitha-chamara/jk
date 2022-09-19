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
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
namespace MMS
{
   
    
    public partial class xOtherServices : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<cGen_Rent_Invoice> InvList = new List<cGen_Rent_Invoice>();
        List<cGen_Rent_Invoice> InvListRecent = new List<cGen_Rent_Invoice>(); // Recent List of Invoice
        List<cGen_Rent_Invoice> InvListCustomer = new List<cGen_Rent_Invoice>(); // Customer Sales History
        List<Invoice_Details> InvDetList = new List<Invoice_Details>();
        List<cCustomersContract> CustList = new List<cCustomersContract>();// for list of Customers 
        List<cRentSchemeFromTo> RentSchemeList = new List<cRentSchemeFromTo>(); // for Rent schemes 
        
        public xOtherServices()
        {
            InitializeComponent();
        }

        private void xOtherServices_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {

            // Other service 
           
            if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
           
            var qryOS = (from os in context.OtherServiceCategories
                         select new { os.OtherServiceID, os.OtherServiceName }).ToList();
            lookOtherServiceCat.Properties.DataSource = qryOS;
            lookOtherServiceCat.Properties.DisplayMember = "OtherServiceName";
            lookOtherServiceCat.Properties.ValueMember = "OtherServiceID";

            // loading promotional contract
            var qryPromotion = (from c in context.ContractClosures
                                where c.IsPromotion == true && c.IsReleased == true && c.IsTerminated == false 
                                select new { c.ContractClosureID, c.ContractClosureName }).ToList();
            qryPromotion.Insert(0,(null));
            this.lookContractClauseID.Properties.DataSource = qryPromotion;
            this.lookContractClauseID.Properties.DisplayMember = "ContractClosureName";
            this.lookContractClauseID.Properties.ValueMember = "ContractClosureID";
           
            //Promotional Rent type 
            var qryPoRentType = (from r in context.Promotion_RentTypes
                                 select new { r.PoRentTypeID, r.RentTypeName }).ToList();
            lookUpEditPoRentType.Properties.DataSource = qryPoRentType;
            lookUpEditPoRentType.Properties.DisplayMember = "RentTypeName";
            lookUpEditPoRentType.Properties.ValueMember = "PoRentTypeID";

            // location
            var qryLoc = (from l in context.Locations 
                          select new {l.LocationID,l.LocationName,l.LocationCode}).ToList();
            this.locationBindingSource.DataSource = qryLoc;
            
            // company 
            var qryCom = (from c in context.Companies
                          select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
            this.companyBindingSource.DataSource = qryCom;
 
            // customer 
            CustList.Clear();
            var qryCust = (from c in context.Extended_Customers
                           join gcust in context.Global_Customers on c.CustomerID equals gcust.CustomerID
                           join comp in context.Companies on c.CompanyID equals comp.CompanyID
                           join loc in context.Locations on c.LocationID equals loc.LocationID
                           select new { c.CustomerID, gcust.CustomerName, comp.CompanyCode, loc.LocationCode,c.ExtendedCustomerID }).ToList();
           
            foreach (var qry in qryCust) 
           {
                cCustomersContract oCust = new cCustomersContract();
                oCust.ExtendedCustomerID = qry.ExtendedCustomerID;
                oCust.GlobalCustomerID = qry.CustomerID;
                oCust.CustomerName = qry.CustomerName;
                oCust.CompanyCode = qry.CompanyCode;
                oCust.LocationCode = qry.LocationCode;
                CustList.Add(oCust);            
           }

            this.lookUpEditCustomer.Properties.DataSource = CustList;
            this.lookUpEditCustomer.Properties.DisplayMember = "CustomerName";
            this.lookUpEditCustomer.Properties.ValueMember = "ExtendedCustomerID";

            this.globalCustomersBindingSource.DataSource = qryCust;

            // Tax 
            this.taxBindingSource.DataSource = (from t in context.Taxes
                                                select new { t.TaxID, t.TaxCode }).ToList();
            // 

            // Tax Rate
            this.taxRateBindingSource.DataSource = (from tr in context.TaxRates
                                                    select new { tr.TaxRateID, tr.TaxRate1 }).ToList();

            //--
            InvList.Clear();
            // Invoice 
            //var qryInv = (from i in context.Invoices
            //              where i.InvoiceTypeID == 3
            //              select i).ToList();
            //foreach (var qry in qryInv)
            //{
            //    cGen_Rent_Invoice oInvoice = new cGen_Rent_Invoice();
            //    oInvoice.CustomerID = qry.CustomerID;
            //    oInvoice.OtherServiceID = qry.OtherServiceID;
            //    oInvoice.InvoiceNo = qry.InvoiceNo;
            //    oInvoice.CompanyID = qry.CompanyID;
            //    oInvoice.LocationID = qry.LocationID;
            //    oInvoice.LevelID = qry.LevelID;
            //    oInvoice.InvDate = qry.InvoiceDate;
            //    oInvoice.InvoiceNo = qry.InvoiceNo;
            //    oInvoice.DateFrom = qry.DateFrom;
            //    oInvoice.DateTo = qry.DateTo;
            //    oInvoice.Naration = qry.Naration;
            //    oInvoice.TotalAmount = qry.TotalAmount;
            //    oInvoice.TotalTax = qry.TotalTax;
            //    oInvoice.GrandTotal = qry.TotalAmount + qry.TotalTax;
            //    oInvoice.SequenceNo = qry.SequenceNo;
            //    InvList.Add(oInvoice);                
            //}
           

            //load_contract_Baskets();




            //this.cGen_Rent_InvoiceBindingSource.DataSource = InvList;
            //this.cGen_Rent_InvoiceGridControl.RefreshDataSource();           

            cEnable_Controls.enable_control(this,false);


        }

        private void load_contract_Baskets()
        {
            //loading contract basket - promotional contract
            var qryCClause = (from c in context.ContractClosures
                              where c.IsReleased == true && c.IsPromotion == true && c.IsProcessed == false && c.IsTerminated == false
                              select c).ToList();
            this.cContract_BasketsBindingSource.DataSource = qryCClause;
            this.cContract_BasketsGridControl.RefreshDataSource();

            //--

            //loading contract basket - Processed Contracts
            var qryCClauseActive = (from c in context.ContractClosures
                              where c.IsPromotion == true && c.IsProcessed == true && c.IsTerminated == false
                              select c).ToList();
            gridControlActiveContracts.DataSource = qryCClauseActive;
            gridControlActiveContracts.RefreshDataSource();


            // --
        }

        private void barButtonNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);
               
                //cEnable_Controls.ClearText(this);
                //cEnable_Controls.enable_control(this, true);
                // loading promotional contract
                //var qryPromotion = (from c in context.ContractClosures
                //                    where c.IsPromotion == true && c.IsReleased == true && c.IsTerminated == false
                //                    select new { c.ContractClosureID, c.ContractClosureName }).ToList();
                //this.lookContractClauseID.Properties.DataSource = qryPromotion;
                //this.lookContractClauseID.Properties.DisplayMember = "ContractClosureName";
                //this.lookContractClauseID.Properties.ValueMember = "ContractClosureID";
               
                this.dtInvoiceDate.Properties.ReadOnly = false;
                dtInvoiceDate.DateTime = DateTime.Now.Date;
                btnSave.Enabled = true;
                barButtonNew.Enabled = false;
                
                lookContractClauseID.Properties.ReadOnly = false;
                memoExEditCustomerAddress.Properties.ReadOnly = false;
                this.memoEditNaration.Properties.ReadOnly = false;
                this.lookUpEditRentSchemeID.Properties.ReadOnly = false;

              
                this.lookOtherServiceCat.Properties.ReadOnly = false;
                this.chkMakeProforma.Properties.ReadOnly = false;
                this.chkMakeProforma.CheckState = CheckState.Indeterminate;
                this.textEditAmount.Properties.ReadOnly = false;
                this.lookOtherServiceCat.EditValue = null;
                this.memoEditNaration.Properties.ReadOnly = false;
                this.lookUpEditRentSchemeID.Properties.ReadOnly = false;

               // this.lookContractClauseID.Properties.ReadOnly = false;
              //  this.
              

                InvDetList.Clear();
                this.invoice_DetailsGridControl.RefreshDataSource();
                try
                {
                    //this.lookContractClauseID.EditValue = null;
                    lookContractClauseID.ItemIndex = 0;
                }
                catch (Exception exe)
                {

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                 //  if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Connecting......"); }
               // bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
                 if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                //if (!chkConn)
                //{
                //    MessageBox.Show("Connection Unstable,Please try again");
                //    return;
                //}
                int extendedCustomerID = 0; int globalCustomerID = 0; int compid = 0; int locid = 0; int levelid = 0; DateTime InvoiceDate = dtInvoiceDate.DateTime;
                //int catid = 0;     
                decimal amount = 0;
                decimal totaltax = 0;
                decimal grandtotal = 0;
                int contclauseid = 0;
                int contrentschemeid = 0;
                DateTime fromdate; DateTime todate;
                int otherserviceid = 0;
                bool res = false;

                //validating Other Service 
                if (string.IsNullOrEmpty(this.lookOtherServiceCat.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.lookOtherServiceCat, "Invalid Other Service");
                    return;
                }
                else { dxErrorProvider1.SetError(this.lookOtherServiceCat, ""); }

                res = int.TryParse(lookOtherServiceCat.EditValue.ToString(), out otherserviceid);
                if (res == false) { otherserviceid = 0; }
                if (otherserviceid == 0)
                {
                    dxErrorProvider1.SetError(this.lookOtherServiceCat, "Invalid Other Service");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.lookOtherServiceCat, "");

                    //


                    res = int.TryParse(this.lookUpEditCustomer.EditValue.ToString(), out extendedCustomerID);
                    if (res == false) { extendedCustomerID = 0; }

                    // Global Customer ID
                    var qryGcust = (from ec in context.Extended_Customers
                                    where ec.ExtendedCustomerID == extendedCustomerID
                                    select new { ec.CustomerID }).FirstOrDefault();
                    if (qryGcust != null)
                    {
                        globalCustomerID = qryGcust.CustomerID;
                    }
                    //--


                    res = int.TryParse(lookContractClauseID.EditValue.ToString(), out contclauseid);
                    if (res == false)
                    {
                        return;
                    }

                    res = int.TryParse(lookCompany.EditValue.ToString(), out compid);
                    if (res == false) { compid = 0; }

                    res = int.TryParse(lookLocation.EditValue.ToString(), out locid);
                    if (res == false) { locid = 0; }

                    res = int.TryParse(lookUpEditLevel.EditValue.ToString(), out levelid);
                    if (res == false) { levelid = 0; }

                    //res = int.TryParse(lookUpEditCategory.EditValue.ToString(), out catid);
                    //if (res == false) { catid = 0; }

                    res = decimal.TryParse(textEditAmount.EditValue.ToString(), out amount);
                    if (res == false) { amount = 0; }

                    res = decimal.TryParse(textEditTotalTax.EditValue.ToString(), out totaltax);
                    if (res == false) { totaltax = 0; }

                    res = decimal.TryParse(this.txtGrandTotal.EditValue.ToString(), out grandtotal);
                    if (res == false) { grandtotal = 0; }

                    //validating rent scheme 
                    res = int.TryParse(this.lookUpEditRentSchemeID.EditValue.ToString(), out contrentschemeid);
                    if (res == false) { contrentschemeid = 0; }
                    if (res == false || contrentschemeid == 0)
                    { return; }

                    var qryRentScheme = (from r in context.Contract_RentSchemes
                                         where r.Contract_RentSchemeID == contrentschemeid
                                         select new { r.FromDate, r.ToDate }).FirstOrDefault();
                    if (qryRentScheme != null)
                    {
                        fromdate = qryRentScheme.FromDate.Date;
                        todate = qryRentScheme.ToDate.Date;
                    }
                    else
                    {
                        fromdate = DateTime.Now.Date;
                        todate = DateTime.Now.Date;
                    }
                    //--

                                        
                    /// Adding object to Invoice
                    Invoice oInv = new Invoice();
                    oInv.InvoiceDate = InvoiceDate;
                    oInv.SAP_PstnDateInDoc = InvoiceDate;
                    cRentScheme _rentscheme = cActiveRentScheme.getDefaultOrLastRateByDate(InvoiceDate, contclauseid);
                    oInv.ContractClosureID = _rentscheme.ContractClosureID;
                    oInv.Contract_RentSchemeID = contrentschemeid; // selected rent scheme
                    //oInv.Contract_RentSchemeID = _rentscheme.Contract_RentSchemeID;
                    oInv.ContractName = _rentscheme.ContractName;
                    oInv.InvoiceTypeID = 3;
                    oInv.DateFrom = fromdate;
                    oInv.DateTo = todate;
                    oInv.ProcessMonth = dtInvoiceDate.DateTime.Month;
                    oInv.ProcessYear = dtInvoiceDate.DateTime.Year;
                    oInv.OtherServiceID = otherserviceid;
                    oInv.CompanyID = compid;
                    oInv.CompanyCode = context.Companies.Where(x => x.CompanyID == compid).FirstOrDefault().CompanyCode;
                    oInv.LocationID = locid;
                    oInv.LocationCode = context.Locations.Where(x => x.LocationID == locid).FirstOrDefault().LocationCode;
                    oInv.LevelID = levelid;
                    oInv.LevelName = context.Floor_Levels.Where(x => x.LevelID == levelid).FirstOrDefault().LevelName;
                    oInv.CustomerID = globalCustomerID;
                    oInv.ShopName = "-";
                    oInv.ShopNo = "-";
                    oInv.ShopID = 0;
                    oInv.CustomerName = lookUpEditCustomer.Text.ToString();
                    oInv.CustomerAddress = context.Global_Customers.Where(x => x.CustomerID == globalCustomerID).FirstOrDefault().CompanyAddress;
                    oInv.CustomerAddress2 = this.memoExEditCustomerAddress.Text.ToString(); // if customer billing address differ with master address
                    //amount / total tax / total
                    oInv.RentPerMonth = amount;
                    oInv.RentWithSCPerMonth = amount;                  
                    oInv.TotalRentPerMonth = grandtotal;
                    //--
                    oInv.Naration = this.memoEditNaration.Text.ToString().Trim();
                    oInv.IsTaxCustomer = MMS.CustomClasses.cCommon_Functions.IsTaxCustomer(globalCustomerID);
                    oInv.TaxRegNo = MMS.CustomClasses.cCommon_Functions.getTaxRegNo(extendedCustomerID,true);
                    oInv.ExtendedCustomerID = extendedCustomerID;

                    //SAP fields update
                    oInv.SAP_Assignment = lookOtherServiceCat.Text.ToString().ToUpper();
                    string sapText = this.memoEditNaration.Text.ToString().Trim();
                    if (sapText.Length > 50)
                    {
                        sapText = sapText.Substring(0, 50).ToString().Trim();
                    }
                    oInv.SAP_Text = sapText;

                    oInv.SAP_Text = this.memoEditNaration.Text.ToString().Trim();
                    oInv.SAP_RefKey1 = oInv.ShopNo;
                    oInv.SAP_RefKey2 = oInv.CustomerName;
                    if (oInv.SAP_RefKey2.Trim().Length > 12) 
                    {
                        oInv.SAP_RefKey2 = oInv.SAP_RefKey2.Substring(0,12).Trim().ToString();
                    }

                    oInv.SAP_RefKey3 = "FIXED";
                    var qryInvPrefix = (from os in context.OtherServiceCategories
                                        where os.OtherServiceID == otherserviceid
                                        select new { os.InvoicePrefix }).FirstOrDefault();

                    oInv.SAP_DocHeaderText = qryInvPrefix.InvoicePrefix + oInv.ShopNo + dtInvoiceDate.DateTime.Month.ToString() + dtInvoiceDate.DateTime.Year.ToString();
                    // document type
                    var qryDT = (from dt in context.SAP_DocTypes
                                 where dt.CompanyID == oInv.CompanyID && dt.InvoiceTypeID == 3
                                 select dt).FirstOrDefault();
                    if (qryDT != null)
                    {
                        oInv.SAP_DocType = qryDT.DOCTYPE;
                    }
                    //--

                    bool taxApplicable = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicable(oInv.ContractClosureID);

                    cMandatoryTax mandatoryTax = cTaxCalculations.getAmountWithMandatoryTax(amount);
                    if (taxApplicable == true) 
                    {
                        oInv.MandatoryTaxAmount = mandatoryTax.MandatoryTaxAmount; 
                    }
                    else
                    { 
                        oInv.MandatoryTaxAmount = 0;
                    }

                    oInv.MandatoryTaxCode = mandatoryTax.MandatoryTaxCode;
                    oInv.MandatoryTaxID = mandatoryTax.MandatoryTaxID;
                    oInv.MandatoryTaxRateID = mandatoryTax.MandatoryTaxRateID;
                    decimal amountWithMandatorytax = 0;
                    if (taxApplicable == true)
                    {
                        amountWithMandatorytax = amount + mandatoryTax.MandatoryTaxAmount;
                    }
                    else
                    {
                        amountWithMandatorytax = amount;
                    }
                    oInv.TotalWithMandatoryTax = amountWithMandatorytax;

                    List<cOtherTax> otherTaxList = cTaxCalculations.getOtherTax(amountWithMandatorytax);
                    decimal otherTax = otherTaxList.Sum(x => x.TaxAmount);
                    oInv.OtherTax = otherTax;
                    oInv.TotalTax = InvDetList.Sum(x => x.Amount);
                    if (taxApplicable == true)
                    {
                        oInv.TotalRentPerMonth = amountWithMandatorytax + otherTax;
                    }
                    else
                    {
                        oInv.TotalRentPerMonth = amount;
                    }

                    // Invoice 
                    if (optSubInvoiceType.SelectedIndex == 0)
                    { oInv.SubInvTypeID = 3; }

                    //Adjustment 
                    if (optSubInvoiceType.SelectedIndex == 1)
                    { oInv.SubInvTypeID = 1; }

                    // Credit Note
                    if (optSubInvoiceType.SelectedIndex == 2)
                    { oInv.SubInvTypeID = 2;
                    if (oInv.RentPerMonth > 0)
                    {
                        oInv.RentPerMonth = oInv.RentPerMonth * -1;
                    }
                    if (oInv.RentWithSCPerMonth > 0)
                    {
                        oInv.RentWithSCPerMonth = oInv.RentWithSCPerMonth * -1;
                    }
                    if (oInv.TotalRentPerMonth > 0)
                    {
                        oInv.TotalRentPerMonth = oInv.TotalRentPerMonth * -1;
                    }
                    if (oInv.MandatoryTaxAmount > 0)
                    {
                        oInv.MandatoryTaxAmount = oInv.MandatoryTaxAmount * -1;
                    }
                    if (oInv.TotalWithMandatoryTax > 0)//Added Hasith
                    {
                        oInv.TotalWithMandatoryTax = oInv.TotalWithMandatoryTax * -1;
                    }
                    if (oInv.TotalTax > 0)//Added Hasith
                    {
                        oInv.TotalTax = oInv.TotalTax * -1;
                    }

                    if (oInv.OtherTax > 0)
                    {
                        oInv.OtherTax = oInv.OtherTax * -1;
                    }
                    
                    }

                    oInv.IsProcessed = true;
                    oInv.IsConfirmed = false;
                    oInv.ModifiedDate = DateTime.Now;

                    /// Adding child objects Invoice Detail 
                    /// 
                    foreach (var qry in InvDetList)
                    {
                        Invoice_Details oInvDet = new Invoice_Details();
                        oInvDet.TaxID = qry.TaxID;
                        oInvDet.TaxCode = qry.TaxCode;
                        oInvDet.TaxRate = qry.TaxRate;
                        oInvDet.TaxRateID = qry.TaxRateID;
                        if (taxApplicable == true)
                        {
                            if (oInv.SubInvTypeID == 2)
                            {
                                if (qry.Amount > 0)
                                {
                                    oInvDet.Amount = qry.Amount * -1;
                                }
                            }
                            else
                            {
                                oInvDet.Amount = qry.Amount;
                            }
                          
                        oInvDet.IsPrint = true;
                        }
                        else
                        {
                            oInvDet.Amount = 0;
                            oInvDet.IsPrint = false;
                        }
                        oInv.Invoice_Details.Add(oInvDet);
                    }

                    // other tax codes 

                    oInv.OtherTaxCodes = MMS.CustomClasses.cCommon_Functions.getOtherTaxCodes();
                    // -- 

                    //Check Is Proforma 
                    if (chkMakeProforma.Checked)
                    {
                        oInv.IsProforma = true;
                        oInv.InvoiceState = MMS.CustomClasses.constants.ProformaStatus.PROFORMA_STATE_PENDING;
                        //string invoiceno = cGenerateInvoiceNo.generateProformainvoiceno(oInv);
                        //oInv.ProfomaNo = invoiceno;
                        //int index = invoiceno.ToString().LastIndexOf('/');
                        //oInv.ProfomaSequenceNo = int.Parse(invoiceno.Substring(index + 1, 12 - (index + 1)).ToString());
                    }
                    else
                    {
                        oInv.IsProforma = false;
                        oInv.InvoiceState = MMS.CustomClasses.constants.ProformaStatus.PROFORMA_STATE_CONFIRM;
                    }
                    
                    
                    context.Invoices.AddObject(oInv);

                 
                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Saved Successfully", "Save Success - Other Services "+succ, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // email alert 
                      //  int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.OtherServiceInvoiceProcesed;
                       // MMS.CustomClasses.cCommon_Functions.AddToEmailList(compid, locid, alert, "Contract : " + lookContractClauseID.Text + System.Environment.NewLine + "Customer : " + lookUpEditCustomer.Text.ToString(), MMS.CustomClasses.cCommon_Functions.LoggedUserID);

                        //AHPL.CustomClasses.cCommon_Functions.EmailAlert(" Other Service Invoice(s) Processed - " + this.lookOtherServiceCat.Text.ToString(), int.Parse(lookCompany.EditValue.ToString()), int.Parse(this.lookLocation.EditValue.ToString()), "", contclauseid, AHPL.CustomClasses.cCommon_Functions.LoggedDNSUserName, "", "", "Note : Next step is confirming other service invoice", "", false,true);

                    }

                    load_data();
                    this.lookContractClauseID.Properties.ReadOnly = true; ;
                    
                   // cEnable_Controls.enable_control(this, false);
                    btnSave.Enabled = false;
                    barButtonNew.Enabled = true;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //SubInvoiceType InvoiceType { get; set; }


        private int getMandatoryTaxID(Invoice oInv)
        {
            int taxid = 0;

            var qryTaxid = (from t in context.Taxes
                            join tr in context.TaxRates on t.TaxID equals tr.TaxID 
                            where t.IsMandatory == true && tr.IsActive == true
                            select new { t.TaxID, t.TaxCode,tr.TaxRate1 }).FirstOrDefault();
            if (qryTaxid != null)
            {
                taxid = qryTaxid.TaxID;
                oInv.MandatoryTaxCode = qryTaxid.TaxCode;
                oInv.MandatoryTaxAmount = (oInv.TotalAmount * qryTaxid.TaxRate1) / 100;
                oInv.TotalWithMandatoryTax = oInv.TotalAmount + oInv.MandatoryTaxAmount;               
               
                // calculating total tax excluding mandatory tax 
                List<decimal> TaxList = new List<decimal>();

                var qryTaxList = (from t in context.Taxes
                                  join tr in context.TaxRates on t.TaxID equals tr.TaxID
                                  where tr.IsActive == true && t.IsMandatory == false
                                  select new { tr.TaxRate1 }).ToList();
                foreach (var qry in qryTaxList)
                {
                    decimal taxamount = (qry.TaxRate1 * oInv.TotalAmount) / 100;
                    TaxList.Add(taxamount);
                }

                // finally geting sum of the List 

                decimal totaltax = TaxList.Sum();

                // 

                oInv.TotalAmtWithTaxExcludedMandatoryTax = oInv.TotalAmount + totaltax;

            }
            else
            {
                throw new System.InvalidOperationException("Please Set up the Mandatory Tax");
            }


            return taxid;
        }

        private decimal getTotalWithMandatoryTax(decimal amount)
        {
            decimal mandatorytax = 0;

            var qryMandTax = (from t in context.Taxes
                              join tr in context.TaxRates on t.TaxID equals tr.TaxID
                              where t.IsMandatory == true
                              select new { tr.TaxRate1 }).FirstOrDefault();
            if (qryMandTax != null)
            {
                mandatorytax = (amount * qryMandTax.TaxRate1) / 100;
            }


            return mandatorytax;
        }

        private string getTaxRegNoComp(int pCompID)
        {
            string sTaxRegNo = string.Empty;


            var qryComp = (from c in context.Company_Taxes
                           join t in context.Taxes on c.TaxID equals t.TaxID
                           orderby t.TaxCode descending
                           where c.CompanyID == pCompID
                           select new { t.TaxCode, c.TaxRegNo }).ToList();
            foreach (var qry in qryComp)
            {
                if (string.IsNullOrEmpty(sTaxRegNo))
                {
                    sTaxRegNo = qry.TaxCode + " " + "REGISTRATION NO : " + qry.TaxRegNo;
                }
                else
                {
                    sTaxRegNo = sTaxRegNo + System.Environment.NewLine + qry.TaxCode + " " + "REGISTRATION NO : " + qry.TaxRegNo;
                }
            }

            return sTaxRegNo;

        }

        private string getTaxRegNoCust(int pCompID, int Gcustid)
        {
            string sTaxRegNo = string.Empty;

            //geting Company Tax Reg No 
            var qryComp = (from c in context.Company_Taxes
                           join t in context.Taxes on c.TaxID equals t.TaxID
                           orderby t.TaxCode descending
                           where c.CompanyID == pCompID
                           select new { t.TaxCode, c.TaxRegNo }).ToList();
            foreach (var qry in qryComp)
            {
                if (string.IsNullOrEmpty(sTaxRegNo))
                {
                    sTaxRegNo = "OUR " + qry.TaxCode + " " + "REGISTRATION NO : " + qry.TaxRegNo;
                }
                else
                {
                    sTaxRegNo = sTaxRegNo + System.Environment.NewLine + "OUR " + qry.TaxCode + " " + "REGISTRATION NO : " + qry.TaxRegNo;
                }
            }
            // -- 

            // geting Customer Tax Reg no
            var qryCust = (from c in context.Customer_Taxes
                           join t in context.Taxes on c.TaxID equals t.TaxID
                           orderby t.TaxCode descending
                           where t.IsMandatory ==false
                           select new { t.TaxCode, c.TaxRegNo }).ToList();
            foreach (var qry in qryCust)
            {
                sTaxRegNo = sTaxRegNo + System.Environment.NewLine + "YOUR " + qry.TaxCode + " " + "REGISTRATION NO : " + qry.TaxRegNo;

            }

            // --

            


            return sTaxRegNo;
        }

     

        private void textEditAmount_EditValueChanged(object sender, EventArgs e)
        {
            
           this.textEditAmount.Properties.ReadOnly = false;
          

            if (!string.IsNullOrEmpty(this.textEditAmount.Text.ToString()))
            {
                decimal amount = 0;
                bool res = decimal.TryParse(this.textEditAmount.EditValue.ToString(), out amount);
                if (res == false) { amount = 0; }

                if (amount >= 0)
                {
                    cal_total(amount);
                }
                else
                {
                    InvDetList.Clear();
                    this.invoice_DetailsGridControl.RefreshDataSource();
                }
            }

           
        }

        private void cal_total(decimal pAmount)
        {
            InvDetList.Clear();

            cMandatoryTax _mandatoryTax = cTaxCalculations.getAmountWithMandatoryTax(pAmount);
            Invoice_Details oInvDet = new Invoice_Details();
            oInvDet.TaxID = _mandatoryTax.MandatoryTaxID;
            oInvDet.TaxCode = _mandatoryTax.MandatoryTaxCode;
            oInvDet.TaxRateID = _mandatoryTax.MandatoryTaxRateID;
            oInvDet.TaxRate = _mandatoryTax.MandatoryTaxRate;
            oInvDet.Amount = _mandatoryTax.MandatoryTaxAmount;
            decimal _amountwithMandtoryTax = _mandatoryTax.MandatoryTaxAmount + pAmount;
            InvDetList.Add(oInvDet); // adding Mandatory tax info 

            List<cOtherTax> _otherTaxList = cTaxCalculations.getOtherTax(_amountwithMandtoryTax);
            foreach (var qry in _otherTaxList)
            {
                oInvDet = new Invoice_Details();
                oInvDet.TaxID = qry.TaxID;
                oInvDet.TaxCode = qry.TaxCode;
                oInvDet.TaxRate = qry.TaxRate;
                oInvDet.TaxRateID = qry.TaxRateID;
                oInvDet.Amount = qry.TaxAmount;
                InvDetList.Add(oInvDet); 
            }



            //var qryTax = (from t in context.Taxes
            //              join tr in context.TaxRates on t.TaxID equals tr.TaxID
            //              where tr.IsActive == true
            //              select tr).ToList();
            
            //foreach (var qry in qryTax) 
            //{
            //    Invoice_Details oInvDet = new Invoice_Details();
            //    oInvDet.TaxID = qry.TaxID;
            //    oInvDet.TaxRateID = qry.TaxRateID;
            //    oInvDet.Amount = (pAmount * qry.TaxRate1) / 100;
            //    InvDetList.Add(oInvDet);
            //}

            decimal _otherTaxAmount = _otherTaxList.Sum(x => x.TaxAmount);
            var qryTotalTax = InvDetList.Sum(x => x.Amount);
            this.textEditTotalTax.EditValue = qryTotalTax;

            this.txtGrandTotal.EditValue = qryTotalTax + pAmount;

            this.invoice_DetailsGridControl.DataSource = InvDetList;
            this.invoice_DetailsGridControl.RefreshDataSource();

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void lookUpEditCompany_EditValueChanged(object sender, EventArgs e)
        {
            //// Location..roshan..06oct2014
            int comid = 0;
            bool res = false;
            res = int.TryParse(lookCompany.EditValue.ToString(), out comid);
            if (res.Equals(true))
            {
                this.locationBindingSource.DataSource = (from c in context.Companies
                                                         join l in context.Locations on c.LocationID equals l.LocationID
                                                         where c.CompanyID == comid
                                                         select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
            }
        }

      

        private void lookUpEditLocation_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
            {
                int locid = 0;
                bool res = false;

                res = int.TryParse(this.lookLocation.EditValue.ToString(), out locid);
                if (res == false) { locid = 0; }
                if (locid > 0)
                {
                    var qryLevel = (from l in context.Floor_Levels
                                    where l.LocationID == locid
                                    select new { l.LevelID, l.LevelCode, l.LevelName }).ToList();
                    this.floorLevelsBindingSource.DataSource = qryLevel;
                }




            }
        }

        private void lookUpEditCustomer_EditValueChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lookUpEditCustomer.Text.ToString()))
            {
                int excustid = 0;
                bool res = false;

                res = int.TryParse(this.lookUpEditCustomer.EditValue.ToString(), out excustid);
                if (res == false) { excustid = 0; }

                if (excustid > 0)
                {
                    var qryECust = (from ec in context.Extended_Customers
                                    where ec.ExtendedCustomerID == excustid
                                    select new { ec.LocationID, ec.CompanyID, ec.CustomerID }).FirstOrDefault();
                    if (qryECust != null)
                    {
                        this.lookCompany.EditValue = qryECust.CompanyID;
                        this.lookLocation.EditValue = qryECust.LocationID;
                    }
                }
                    // Querying Customer sales history 
                //    InvListCustomer.Clear();
                //    // Invoice 
                //    var qryInv = (from i in context.Invoices
                //                  where i.InvoiceTypeID == 3 && i.CustomerID == qryECust.CustomerID
                //                  select i).ToList();
                //    foreach (var qry in qryInv)
                //    {
                //        cGen_Rent_Invoice oInv = new cGen_Rent_Invoice();
                //        oInv.CustomerID = qry.CustomerID;
                //        oInv.OtherServiceID = qry.OtherServiceID;
                //        oInv.InvoiceNo = qry.InvoiceNo;
                //        oInv.CompanyID = qry.CompanyID;
                //        oInv.LocationID = qry.LocationID;
                //        oInv.LevelID = qry.LevelID;
                //        oInv.InvDate = qry.InvoiceDate;
                //        oInv.InvoiceNo = qry.InvoiceNo;
                //        oInv.DateFrom = qry.DateFrom;
                //        oInv.DateTo = qry.DateTo;
                //        oInv.Naration = qry.Naration;
                //        oInv.TotalAmount = qry.TotalAmount;
                //        oInv.TotalTax = qry.TotalTax;
                //        oInv.GrandTotal = qry.TotalAmount + qry.TotalTax;
                //        InvListCustomer.Add(oInv);
                //    }

                //    // -- 

                //    gridCustomerSales.DataSource = InvListCustomer;
                //    gridCustomerSales.RefreshDataSource();
                //}



            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            xPoContract_Confirm poconfirm = new xPoContract_Confirm();
            poconfirm.FormClosing+=new FormClosingEventHandler(poconfirm_FormClosing);
            poconfirm.Show(this);

            ContractClosure _focusRow = (ContractClosure) gridView4.GetFocusedRow();
            if (_focusRow != null)
            {
                poconfirm.Load_DataByPoContractClauseID(_focusRow.ContractClosureID);
            }
            //var focusrow = gridView4.GetFocusedDataRow();
            //var cclauseid = focusrow["ContractClosureID"];
           
        }

        private void poconfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            load_data();

        }

        private void dockPanel2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "(http://www.skippercoatings.com)"))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        Console.WriteLine("First Name: " + de.Properties["givenName"].Value);
                        Console.WriteLine("Last Name : " + de.Properties["sn"].Value);
                        Console.WriteLine("SAM account name   : " + de.Properties["samAccountName"].Value);
                        Console.WriteLine("User principal name: " + de.Properties["userPrincipalName"].Value);
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadLine();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        public enum SubInvoiceType
        {
           
            Adjustment = 1 ,
            CreditNote = 2,
            Invoice = 3
        };

        private void optSubInvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optSubInvoiceType.SelectedIndex == 0)
            {
                InvoiceType = SubInvoiceType.Invoice;
            }
            if (optSubInvoiceType.SelectedIndex == 1)
            {
                InvoiceType = SubInvoiceType.Adjustment;
            }
            if (optSubInvoiceType.SelectedIndex == 2)
            {
                InvoiceType = SubInvoiceType.CreditNote;
                
            }


        }

        private void lookUpEditCCClauseID_EditValueChanged(object sender, EventArgs e)
        {
           // if (!string.IsNullOrEmpty(this.lookContractClauseID.Text.ToString()))
           // {
                bool res = false;
                int contclauseid = 0;
                res = int.TryParse(this.lookContractClauseID.EditValue.ToString(), out contclauseid);
                if (res == false)
                {
                    return;
                }

                var qryCont = (from c in context.ContractClosures
                               where c.ContractClosureID == contclauseid
                               select c).FirstOrDefault();

                this.lookUpEditCustomer.EditValue = qryCont.ExtendedCustomerID;
                this.lookCompany.EditValue = qryCont.CompanyID;
                this.lookLocation.EditValue = qryCont.LocationID;
                this.lookUpEditLevel.EditValue = qryCont.LevelID;                
                this.lookUpEditPoRentType.EditValue = qryCont.PoRentTypeID;
                this.memoExEditCustomerAddress.EditValue = qryCont.CustomerAddress;

               cRentScheme _rentscheme =  cActiveRentScheme.getDefaultOrLastRateByDate(dtInvoiceDate.DateTime, contclauseid);

               this.textEditAmount.EditValue = _rentscheme.RentPerMonth;
               //dateEditFrom.EditValue = _rentscheme.FromDate;
               //dateEditTo.EditValue = _rentscheme.ToDate;

               RentSchemeList.Clear();
               var qryRentScheme = (from r in context.Contract_RentSchemes
                                    where r.ContractClosureID == contclauseid
                                    select r).ToList();
               foreach (var qry in qryRentScheme)
               {
                   cRentSchemeFromTo oRentScheme = new cRentSchemeFromTo();
                   oRentScheme.Contract_RentSchemeID = qry.Contract_RentSchemeID;
                   oRentScheme.ContractClosureID = qry.ContractClosureID;
                   oRentScheme.FromDay_ToDay = qry.FromDate.Date.ToString("dd/MM/yyyy") + " - " + qry.ToDate.Date.ToString("dd/MM/yyyy");
                   oRentScheme.Rent = qry.RentPerSqFeet;
                   RentSchemeList.Add(oRentScheme);
               }

               this.cRentSchemeFromToBindingSource.DataSource = RentSchemeList;

                //geting active Rent Scheme ID 
               this.lookUpEditRentSchemeID.EditValue = _rentscheme.Contract_RentSchemeID;

               //generate proforma invoice number
               //string invoiceno = cGenerateInvoiceNo.generateProformainvoiceno(oInv);
               //lblproformano.Text = invoiceno;
                


            //}


        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cEnable_Controls.ClearText(this);
            cEnable_Controls.enable_control(this, false);
            load_data();
            btnNew.Enabled = true;
            btnSave.Enabled = false;


        }

        private void lookUpEditRentSchemeID_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lookUpEditRentSchemeID.Text.ToString()))
            {
                return;
            }

            bool res = false;
            int rentschemeid = 0;
            res = int.TryParse(this.lookUpEditRentSchemeID.EditValue.ToString(), out rentschemeid);
            if (res == false) { rentschemeid = 0; }
            if (rentschemeid == 0) { return; }


            var qryRentScheme = (from r in context.Contract_RentSchemes
                                 where r.Contract_RentSchemeID == rentschemeid
                                 select new { r.RentPerSqFeet }).FirstOrDefault();
            if (qryRentScheme != null)
            {
                this.textEditAmount.EditValue = qryRentScheme.RentPerSqFeet;
            }

            memoEditNaration.Text = this.lookUpEditRentSchemeID.Text.ToString().Trim();

        }

        public SubInvoiceType InvoiceType { get; set; }

        private void dateEditFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(this.dateEditFrom.Text.ToString())) && !(string.IsNullOrEmpty(this.dateEditTo.Text.ToString())))
            {
                getInvoiceNo(dateEditFrom.EditValue.ToString(), dateEditTo.EditValue.ToString());

            }
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
        private void getInvoiceNo(string pFromDate, string pToDate)
        {
            DateTime dateFrom;
            DateTime dateTo;

            bool res = false;
            res = DateTime.TryParse(pFromDate, out dateFrom);
            if (res == false) { return; }

            res = DateTime.TryParse(pToDate, out dateTo);
            if (res == false) { return; }

            //load Invoice No
            var qryInv = (from i in context.Invoices
                          where (i.DateFrom >= dateFrom && i.DateTo <= dateTo) && i.InvoiceTypeID == 3 && i.IsConfirmed == true //&& i.ContractClosureID == contclauseid
                          select new { i.InvoiceNo, i.InvoiceID, i.SubInvTypeID }).ToList();
            this.chkcboInvoiceNo.Properties.DataSource = qryInv;
            this.chkcboInvoiceNo.Properties.DisplayMember = "InvoiceNo";
            this.chkcboInvoiceNo.Properties.ValueMember = "InvoiceID";




        }

        private void chkcboInvoiceNo_EditValueChanged(object sender, EventArgs e)
        {
            //
            string selected = this.chkcboInvoiceNo.Properties.GetCheckedItems().ToString();
            string theString = selected;
            if (string.IsNullOrEmpty(theString.ToString())) { return; }

            List<int> ints = theString.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));

            var reslt = (from i in context.Invoices
                         where ints.Contains(i.InvoiceID)
                         select new { i.ShopNo, i.ContractClosureID, i.ContractID,i.OtherServiceID,i.SubInvTypeID }).FirstOrDefault();

            //set invoice type
            int SubInType = reslt.SubInvTypeID;

            if (SubInType == 1)
                optSubInvoiceType.SelectedIndex = 0;
            if (SubInType == 2)
                optSubInvoiceType.SelectedIndex = 1;
            if (SubInType == 3)
                optSubInvoiceType.SelectedIndex = 2;
            
           // this.lookContractClauseID.EditValue = reslt.ContractClosureID;
           // this.lookOtherServiceCat.EditValue = reslt.OtherServiceID;



        }

        private void lookOtherServiceCat_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private string genarateProformaInvoice()
        {


            return null;
        }

        private void textEditAmount_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("aasasas");
        }

        private void dtInvoiceDate_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dockPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            load_contract_Baskets();
        }
    }
}