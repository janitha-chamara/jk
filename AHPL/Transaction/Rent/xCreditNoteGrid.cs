using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataTier;
using MMS.CustomClasses;
using DevExpress.XtraGrid.Columns;
using System.Transactions;

namespace MMS.Transaction.Rent
{
    public partial class xCreditNoteGrid : Form
    {
        List<cGen_Rent_Invoice> cGenList = new List<cGen_Rent_Invoice>();
        List<Invoice_Details> invDetList = new List<Invoice_Details>();
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xCreditNoteGrid()
        {
            InitializeComponent();
            load_data();
        }
        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    //locaiton 
                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
                    this.locationBindingSource.DataSource = qryLoc;
                    // Company 
                    var qryCom = (from c in context.Companies
                                  select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
                    this.companyBindingSource.DataSource = qryCom;

                    dateeditCNodate.DateTime = DateTime.Now;
                   
                    //taxes
                    //int invtypeid = 0;
                    //if (invtypeid == 1)
                    //{
                    //    var qryContractTax = (from t in context.Taxes
                    //                          join tr in context.TaxRates on t.TaxID equals tr.TaxID
                    //                          where tr.IsActive == true
                    //                          select new { t.TaxID, tr.TaxRateID }).ToList();

                    //    if (invDetList.Count > 0) { invDetList.Clear(); }

                    //    foreach (var qry in qryContractTax)
                    //    {
                    //        Invoice_Details oInvDet = new Invoice_Details();
                    //        oInvDet.TaxID = qry.TaxID;
                    //        oInvDet.TaxRateID = qry.TaxRateID;
                    //        oInvDet.Amount = 0;
                    //        invDetList.Add(oInvDet);
                    //    }

                       
                    //}



                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
           
        
        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                int comid = 0;
                bool res = false;
                res = int.TryParse(lookCompany.EditValue.ToString(), out comid);
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

        private void dateEditTo_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditTo.Text.ToString()))
            {
                return;
            }
            else if (!(string.IsNullOrEmpty(this.dateEditTo.Text.ToString())) && !(string.IsNullOrEmpty(this.dateEditFrom.Text.ToString())))
            {

                loadInvoices(dateEditFrom.EditValue.ToString(), dateEditTo.EditValue.ToString());
            }
            
        }
        private void loadInvoices(string pFromDate, string pToDate)
        {

            try
            {
                bool res = false;
                int compid = 0; int locid = 0;
                DateTime dateFrom;
                DateTime dateTo;
                cGenList.Clear();

                res = int.TryParse(lookCompany.EditValue.ToString(), out compid);
                if (res == false) { compid = 0; return; }

                // location
                res = int.TryParse(lookLocation.EditValue.ToString(), out locid);
                if (res == false) { locid = 0; return; }

                res = DateTime.TryParse(pFromDate, out dateFrom);
                if (res == false) { return; }

                res = DateTime.TryParse(pToDate, out dateTo);
                if (res == false) { return; }

                cGenList.Clear();

                //get invoices

            
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {


                    var qryresult = (from i in context.Invoices
                                     where i.IsConfirmed == true && i.InvoiceTypeID ==1 && i.SubInvTypeID != 2 &&
                                            i.CompanyID == compid && i.LocationID == locid && (i.DateFrom >= dateFrom && i.DateTo <= dateTo)
                                     select new {i.ShopID,i.ShopNo, i.ShopName, i.CustomerName, i.CustomerID, i.InvoiceNo , i.TotalRentPerMonth,
                                     i.ContractClosureID,i.MandatoryTaxID,i.MandatoryTaxRateID,i.OtherTax,i.MandatoryTaxAmount}).ToList();



                    foreach (var qry in qryresult)
                    {
                        cGen_Rent_Invoice invoiceobject = new cGen_Rent_Invoice();
                        invoiceobject.ShopID = qry.ShopID;
                        invoiceobject.ShopName = qry.ShopName;
                        invoiceobject.ShopNo = qry.ShopNo;
                        invoiceobject.CustomerName = qry.CustomerName;
                        invoiceobject.CustomerID = qry.CustomerID;
                        invoiceobject.InvoiceNo = qry.InvoiceNo;
                        invoiceobject.TotalRentPerMonth = qry.TotalRentPerMonth;
                        invoiceobject.CreditNoteValue = 0;
                        invoiceobject.OtherTax =qry.OtherTax; //VAT
                        invoiceobject.MandatoryTaxAmount = qry.MandatoryTaxAmount; //NBT

                        
                        cGenList.Add(invoiceobject);


                    }

                    this.cInvoicesBindigSource.DataSource = cGenList;
                    this.gvallcreditnotes.RefreshDataSource();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }

            
        
        }

        private void dateEditFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
            {
                return;
            }
            else if (!(string.IsNullOrEmpty(this.dateEditTo.Text.ToString())) && !(string.IsNullOrEmpty(this.dateEditFrom.Text.ToString())))
            {

                loadInvoices(dateEditFrom.EditValue.ToString(), dateEditTo.EditValue.ToString());
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        decimal NewCValue = 0;

        private int GetContractCouserIdByInvoiceNo(string invoiceno)
        {
            int contractclouserid = 0;

            //get contactclouserIDby invoiceno
            contractclouserid = (from u in context.Invoices
                                 where u.InvoiceNo == invoiceno
                                 select u.ContractClosureID).FirstOrDefault();


            return contractclouserid;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            try
            {
                if (e.Column == CnoteValue)
                {
                    using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {
                        
                        cGen_Rent_Invoice oInvoicebatch = (cGen_Rent_Invoice)gridView1.GetFocusedRow();
                        decimal CurentInvoiceValue = 0;
                       // decimal  NewCValue = 0;
                        int contractclouserid = 0;

                        //get contactclouserIDby invoiceno
                        contractclouserid = GetContractCouserIdByInvoiceNo(oInvoicebatch.InvoiceNo);

                        //--invoice details

                        
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
                        //--


                        bool res = false;

                        if (oInvoicebatch != null)
                        {
                            res = decimal.TryParse(oInvoicebatch.TotalRentPerMonth.ToString(), out CurentInvoiceValue);
                            if (res == false) { CurentInvoiceValue = 0; }

                            res = decimal.TryParse(oInvoicebatch.CreditNoteValue.ToString(), out NewCValue);
                            if (res == false) { NewCValue = 0; }


                            //check Is Tax applicable
                            
                            bool IsTaxCalApply = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicable(contractclouserid);
                            //get tax latest rates
                            //NBT
                            cMandatoryTax mandatoryTax = new cMandatoryTax();
                            mandatoryTax = cTaxCalculations.getAmountWithMandatoryTax(NewCValue);
                            decimal totalwithmandetorytax = mandatoryTax.TotalWithMandatoryTax;
                            
                            if (IsTaxCalApply == true)
                            {
                               // oInvoicebatch.MandatoryTaxAmount =(decimal.Parse(string.Format("{0:0.##}", mandatoryTax.MandatoryTaxAmount.ToString())))*-1;
                                
                                oInvoicebatch.MandatoryTaxAmount = Math.Round((mandatoryTax.MandatoryTaxAmount)*-1, 4);
                            }
                            else {
                                oInvoicebatch.CreditNoteValue = NewCValue;
                                oInvoicebatch.MandatoryTaxAmount = 0; }

                            //VAT
                            List<cOtherTax> otherTaxList = cTaxCalculations.getOtherTax(mandatoryTax.TotalWithMandatoryTax);

                            // tax details
                            

                            foreach (var qryOT in otherTaxList)
                            {
                                //oInvDet = new Invoice_Details();
                                if (IsTaxCalApply == false)
                                { oInvoicebatch.OtherTax = 0; }
                                else 
                                {
                                    
                                   // oInvoicebatch.OtherTax = (decimal.Parse(string.Format("{0:0.##}", qryOT.TaxAmount.ToString())))*-1;
                                    oInvoicebatch.OtherTax = Math.Round((qryOT.TaxAmount)*-1, 4); 
                                } 

                            }

                            if (IsTaxCalApply == true)
                            {
                                decimal othertax = oInvoicebatch.OtherTax * -1;
                                decimal totalcreditvalue = othertax + mandatoryTax.TotalWithMandatoryTax;
                                // oInvoicebatch.TotalCreditValue = (decimal.Parse(string.Format("{0:0.##}", totalcreditvalue.ToString())))*-1;
                                oInvoicebatch.TotalCreditValue = Math.Round((totalcreditvalue) * -1, 4);
                            }
                            else
                            {
                                oInvoicebatch.TotalCreditValue = Math.Round( (NewCValue)*-1,4);
                            }

                        
                        }


                    }
                     
                
                
                }
            }
            catch (Exception)
            {
                
                throw;
            }


        }

        private void btnselectall_Click(object sender, EventArgs e)
        {
          
        }

        private void chkselect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkselect.Checked == true)
            {
                chkselect.Text = "Unselect All";
                foreach (var qry in cGenList)
                {
                    qry.Confirm = true;
                }
                gvallcreditnotes.RefreshDataSource();
            }
            else
            {
                chkselect.Text = "Select All";
                foreach (var qry in cGenList)
                {
                    qry.Confirm = false;
                }
                gvallcreditnotes.RefreshDataSource();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveNewCreditInvoice();
        }

        private void SaveNewCreditInvoice()
        {
            try
            {

                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);
                //validation
                if (string.IsNullOrEmpty(this.dateeditCNodate.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.dateeditCNodate, "Invalid Date");
                    return;
                }
                else
                { dxErrorProvider1.SetError(this.dateeditCNodate, ""); }

                if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.dateEditFrom, "Invalid Date");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.dateEditFrom, "");
                }
                if (string.IsNullOrEmpty(this.dateEditTo.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.dateEditTo, "Invalid Date");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.dateEditTo, "");
                }

                if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.lookCompany, "Invalid Company");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.lookCompany, "");
                }
                if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.lookLocation, "Invalid Company");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.lookLocation, "");
                }

                //--
                var qryContracts = (from c in cGenList
                                    where c.CreditNoteValue>0
                                    select c).ToList();

                if (qryContracts.Count == 0)
                {
                    MessageBox.Show("No invoice(s) selected or Invalid credit value");
                    return;
                }
               
                foreach (var row in qryContracts)
                {
                    //SAP doc validate
                    //bool IsSAPDocValidated = SapDocValidate(row.CompanyID);
                    //if (IsSAPDocValidated == false)
                    //{ return; }
                    int contclauseid = 0;
                    contclauseid = GetContractCouserIdByInvoiceNo(row.InvoiceNo);


                    Invoice oInvoice = new Invoice();
                    oInvoice.ContractClosureID = contclauseid;
                    oInvoice.ShopID = MMS.CustomClasses.cCommon_Functions.getShopID(contclauseid);
                    oInvoice.ShopName = MMS.CustomClasses.cCommon_Functions.getShopName(contclauseid);
                    oInvoice.ShopNo = MMS.CustomClasses.cCommon_Functions.getShopNo(contclauseid);
                    oInvoice.CustomerID = row.CustomerID;
                    oInvoice.CustomerName = row.CustomerName;
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
                    oInvoice.RefInvNo = row.InvoiceNo;
                    oInvoice.IsTaxCustomer = MMS.CustomClasses.cCommon_Functions.IsTaxCustomer(oInvoice.CustomerID);
                    oInvoice.Naration = this.textEdit1.Text.ToString();

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

                        var contclosureid = cActiveRentScheme.getDefaultOrLastRate(dateeditCNodate.DateTime, qryCont.ContractClosureID, dateEditFrom.DateTime, dateEditTo.DateTime);
                        oInvoice.ContractClosureID = contclosureid.ContractClosureID;
                        oInvoice.Contract_RentSchemeID = contclosureid.Contract_RentSchemeID;

                        oInvoice.RentPerSqFt = contclosureid.RentPerSqFeet*-1;
                        oInvoice.SCPerSqFt = contclosureid.SCperSqFeet*-1;

                        //// -- 
                    }

                    oInvoice.CompanyID = int.Parse(lookCompany.EditValue.ToString());
                    oInvoice.CompanyCode = context.Companies.Where(x => x.CompanyID == oInvoice.CompanyID).FirstOrDefault().CompanyCode;
                    oInvoice.LocationID = int.Parse(lookLocation.EditValue.ToString());
                    oInvoice.LocationCode = context.Locations.Where(x => x.LocationID == oInvoice.LocationID).FirstOrDefault().LocationCode;
                    oInvoice.ProcessYear = dateeditCNodate.DateTime.Year;
                    oInvoice.ProcessMonth = dateeditCNodate.DateTime.Month;
                    oInvoice.DateFrom = dateEditFrom.DateTime;
                    oInvoice.DateTo = dateEditTo.DateTime;
                    int nosdays = dateEditTo.DateTime.Subtract(dateEditFrom.DateTime).Days;
                    oInvoice.NosDay = nosdays;

                    

                    decimal rentAmount = 0;
                    decimal scamount = 0;
                    decimal floorarea = 0;
                    oInvoice.IsRentVariance = false;
                    oInvoice.IsSCVariance = false;

                    //get rental area ContractClosures
                    floorarea = (from c in context.ContractClosures
                                 where c.ContractClosureID == contclauseid
                                 select c.FloorArea).FirstOrDefault();


                    rentAmount = floorarea * oInvoice.RentPerSqFt;
                    scamount = floorarea * oInvoice.SCPerSqFt;

                    oInvoice.IsRentVariance = false;
                    oInvoice.IsSCVariance = false;

                    oInvoice.RentPerMonth = rentAmount; //row.CreditNoteValue;// rentAmount;
                        if ((rentAmount*-1) > 0)
                        {
                            oInvoice.IsRentVariance = true;
                        }
                  
                     //   oInvoice.SCPerMonth = scamount;
                        oInvoice.SCPerMonth = 0;
                        if ((oInvoice.SCPerMonth) > 0)
                        {
                            oInvoice.IsSCVariance = true;
                        }

                       // oInvoice.RentWithSCPerMonth = (rentAmount + scamount)*-1;
                      oInvoice.RentWithSCPerMonth = (row.CreditNoteValue) * -1;

                    //if (IsTaxCalApply == true) //// global tax
                    //{
                    //    oInvoice.MandatoryTaxAmount = row.MandatoryTaxAmount;
 
                    //}
                    //else
                    //{
                    //    oInvoice.MandatoryTaxAmount = 0;
                    //}

                    cMandatoryTax mandatoryTax = new cMandatoryTax();

                    mandatoryTax=  cTaxCalculations.getAmountWithMandatoryTax(row.CreditNoteValue);

                    if (IsTaxCalApply == true) //// global tax
                    {
                        oInvoice.MandatoryTaxAmount = mandatoryTax.MandatoryTaxAmount*-1;
                    }
                    else
                    { oInvoice.MandatoryTaxAmount = 0;  }



                    oInvoice.MandatoryTaxCode = mandatoryTax.MandatoryTaxCode;
                    oInvoice.MandatoryTaxID = mandatoryTax.MandatoryTaxID;
                    oInvoice.MandatoryTaxRateID = mandatoryTax.MandatoryTaxRateID;



                    List<cOtherTax> otherTaxList = new List<cOtherTax>();
                    otherTaxList.Clear();
                    otherTaxList = cTaxCalculations.getOtherTax(mandatoryTax.TotalWithMandatoryTax);
                    decimal totalTax = 0;
                    // other tax details
                    foreach (var tx in otherTaxList)
                    {
                        totalTax += tx.TaxAmount;
                     
                    }

                    
                    var qryOtherTax = (from det in otherTaxList select det).Sum(x => x.TaxAmount);

                    //--
                    totalTax = (qryOtherTax + mandatoryTax.MandatoryTaxAmount) * -1;

                    if (IsTaxCalApply == true)
                    {
                        oInvoice.TotalTax = totalTax;
                    }
                    else
                    {
                        oInvoice.TotalTax = 0;
                    }

                   



                    oInvoice.TotalWithMandatoryTax = (row.CreditNoteValue * -1) + oInvoice.MandatoryTaxAmount;
                    oInvoice.TotalRentPerMonth = oInvoice.TotalTax + (row.CreditNoteValue * -1);
                    

                    if (IsTaxCalApply == false)
                    {
                        oInvoice.TotalWithMandatoryTax = (row.CreditNoteValue * -1);
                        oInvoice.TotalRentPerMonth = (row.CreditNoteValue * -1);
                        oInvoice.TotalTax = 0;
                        oInvoice.MandatoryTaxAmount = 0;
                        oInvoice.RentWithSCPerMonth = (row.CreditNoteValue * -1);
                        oInvoice.TotalAmount = (row.CreditNoteValue * -1);
                        oInvoice.RentPerMonth = (row.CreditNoteValue * -1);
                    }
                   
                    
                    oInvoice.InvoiceDate = dateeditCNodate.DateTime;
                    oInvoice.SAP_PstnDateInDoc = dateeditCNodate.DateTime;
                    oInvoice.ModifiedDate = DateTime.Now;
                    oInvoice.IsProcessed = true;
                    oInvoice.IsConfirmed = false;

                    oInvoice.SubInvTypeID = 2; //// Credit Note (1-Invoice/2-CreditNote/3-Adjustment)
                    oInvoice.InvoiceTypeID = 1;  //// 1- RENT INVOICE 2 - Utility Invoice


                    ////record creation time 
                    oInvoice.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                    oInvoice.CreatedDate = DateTime.Now;
                    ////

                    //// SAP field update
                    //// document header update
                    oInvoice.SAP_DocHeaderText = "R" + oInvoice.ShopNo + dateeditCNodate.DateTime.Month.ToString() + dateeditCNodate.DateTime.Year.ToString();

                    ////SAP fields update

                    oInvoice.SAP_Assignment = "RENT";
                    ////oInvoice.SAP_Text = "RENT" + "_" + oInvoice.ShopNo.ToString().Trim() + "_" + MMS.CustomClasses.cCommon_Functions.getMonthAbbrName(dtDate.DateTime.Month) + "_" + dtDate.DateTime.Year.ToString();
                    string sapText = textEdit1.Text.ToString();
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

                    context.Invoices.AddObject(oInvoice);

                    //--
                    //invoice details



                    List<Invoice_Details> alltaxdetail = new List<Invoice_Details>();
                    alltaxdetail.Clear();
                    Invoice_Details invodete = new Invoice_Details();

                    invodete.Amount =Math.Round( mandatoryTax.MandatoryTaxAmount,4);
                    invodete.TaxRateID = mandatoryTax.MandatoryTaxRateID;
                    invodete.TaxID = mandatoryTax.MandatoryTaxID;
                    invodete.TaxCode = mandatoryTax.MandatoryTaxCode;
                    invodete.TaxRate = mandatoryTax.MandatoryTaxRate;
                    alltaxdetail.Add(invodete);

                    foreach (var txs in otherTaxList)
                    {
                        Invoice_Details invdetvat = new Invoice_Details();

                       
                        invdetvat.Amount = Math.Round(txs.TaxAmount, 4);
                        invdetvat.TaxRateID = txs.TaxRateID;
                        invdetvat.TaxID = txs.TaxID;
                        invdetvat.TaxCode = txs.TaxCode;
                        invdetvat.TaxRate = txs.TaxRate;

                        alltaxdetail.Add(invdetvat);
                    }



                    foreach (var qry in alltaxdetail)
                    {
                        Invoice_Details oInvDet = new Invoice_Details();
                        oInvDet.Amount = qry.Amount;
                        
                            if (oInvDet.Amount > 0)
                            {
                                if (IsTaxCalApply == true)
                                {

                                    oInvDet.Amount = oInvDet.Amount * -1;
                                }
                                else
                                {
                                    oInvDet.Amount = 0;
                                
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
               
                }
                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully", "Credit Note Grid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    btnSave.Enabled = false;
                }
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        private bool SapDocValidate(int pCompanyID)
        {
            bool validated = false;

            var qryDT = (from dt in context.SAP_DocTypes
                         where dt.InvoiceTypeID == 1 && dt.CompanyID == pCompanyID
                         select dt).FirstOrDefault();
            if (qryDT != null)
            {
                if (string.IsNullOrEmpty(qryDT.DOCTYPE.ToString()))
                {
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                    MessageBox.Show("Please Setup the DOC TYPE in SAP Master Setting", "SAP DOC TYPE Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    validated = true;
                }
            }
            else
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show("Please Setup the DOC TYPE in SAP Master Setting", "SAP DOC TYPE Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return validated;
        }

       

        private void ClearForm()
        {
            load_data();

            for (int i = 0; i < gridView1.RowCount; )
            { gridView1.DeleteRow(i); }

            
            textEdit1.Text = "";
            dateeditCNodate.DateTime = DateTime.Now;
            dateEditFrom.Text = "";
            dateEditTo.Text = "";
            cEnable_Controls.ClearText(this);
            dateeditCNodate.DateTime = DateTime.Now.Date;
            btnSave.Enabled = true;

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearForm();

        }

        private void gvallcreditnotes_Click(object sender, EventArgs e)
        {

        }




    }
}
