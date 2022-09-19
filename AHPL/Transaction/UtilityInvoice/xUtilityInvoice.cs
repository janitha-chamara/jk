using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using MMS.CustomClasses;
using DataTier;
using DevExpress.XtraEditors;
using DataTier.Reports.Utility;
using System.Diagnostics;

namespace MMS
{
    public partial class xUtilityInvoice : DevExpress.XtraEditors.XtraForm //ParentForm.xParentDefault //
    {
        //AHPL_DBEntities context = new AHPL_DBEntities();
        List<Invoice_Details> invDetList = new List<Invoice_Details>();
        List<cGen_Rent_Invoice> InvList = new List<cGen_Rent_Invoice>();
        AHPL_DBEntities context = new AHPL_DBEntities();
        bool edit = false;
        bool addNew = false;

        public xUtilityInvoice()
        {
            InitializeComponent();
        }

        private void xUtilityInvoice_Load(object sender, EventArgs e)
        {
            cEnable_Controls.enable_control(this, true);
            cEnable_Controls.ClearText(this);

            load_data();

        }

        private void load_data()
        {
            try
            {
 
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    //utilities
                    var qryUti = (from u in context.Utilities
                                  select u).ToList();
                    this.lookUtilityID.Properties.DataSource = qryUti;
                    this.lookUtilityID.Properties.DisplayMember = "UtilityName";
                    this.lookUtilityID.Properties.ValueMember = "UtilityID";
                    this.lookUtilityID.Properties.ReadOnly = true;
                    //-- 

                    // Invoice Types 
                    var qryInvType = (from it in context.Invoice_Types
                                      select new { it.InvoiceTypeID, it.InvoiceTypeName }).ToList();
                    this.invoiceTypesBindingSource.DataSource = qryInvType;
                    //--

                    // Sub Invoice types 
                    subInvoiceTypesBindingSource.DataSource = (from it in context.Sub_Invoice_Types
                                                               select new { it.SubInvTypeID, it.SubInvTypeName }).ToList();
                    // -- 


                    var qrycomp = (from c in context.Companies
                                   select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
                    this.lookCompany.Properties.DataSource = qrycomp;
                    this.lookCompany.Properties.DisplayMember = "CompanyCode";
                    this.lookCompany.Properties.ValueMember = "CompanyID";
                    this.lookCompany.Properties.ReadOnly = true;

                    this.repositoryItemLookUpEditCompany.DataSource = qrycomp;
                    this.repositoryItemLookUpEditCompany.DisplayMember = "CompanyCode";
                    this.repositoryItemLookUpEditCompany.ValueMember = "CompanyID";
                  

                    //locaiton
                    var qryloc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
                    this.lookLocation.Properties.DataSource = qryloc;
                    this.lookLocation.Properties.ValueMember = "LocationID";
                    this.lookLocation.Properties.DisplayMember = "LocationCode";
                    //this.lookLocation.Properties.ReadOnly = true;

                    this.repositoryItemLookUpEditLocation.DataSource = qryloc;
                    this.repositoryItemLookUpEditLocation.DisplayMember = " LocationCode";
                    this.repositoryItemLookUpEditLocation.ValueMember = "LocationID";
                    //---

                    // Floor Level
                    var qryLevel = (from fl in context.Floor_Levels
                                    select new { fl.LevelID, fl.LevelName, fl.LevelCode }).ToList();

                    this.repositoryItemLookUpEditLevel.DataSource = qryLevel;
                    this.repositoryItemLookUpEditLevel.DisplayMember= "LevelName";
                    this.repositoryItemLookUpEditLevel.ValueMember = "LevelID";
                    // -- 
                                  
                  //// ShopName
                    var qryshopname = (from c in context.ContractClosures
                                       join comp in context.Companies on c.CompanyID equals comp.CompanyID
                                       join loc in context.Locations on c.LocationID equals loc.LocationID
                                       join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                       join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                                       where c.IsTerminated == false && c.IsPromotion == false && c.IsProcessed == true && c.IsActive == true
                                       orderby comp.CompanyCode, loc.LocationCode, c.ShopNo ascending
                                       select new { c.ContractClosureID, c.ContractClosureName, c.ShopName, comp.CompanyCode, loc.LocationCode, gcus.CustomerName, c.ShopNo }).ToList();

                    this.lookUpEditShopName.Properties.DataSource = qryshopname;
                    this.lookUpEditShopName.Properties.ValueMember = "ContractClosureID";
                    this.lookUpEditShopName.Properties.DisplayMember = "ShopName";
                    this.lookUpEditShopName.Properties.ReadOnly = true;

                    // shop no 
                    var qryShops = (from s in context.Shops
                                    select new { s.ShopID, s.ShopNo }).ToList();
                    this.lookShop.Properties.DataSource = qryShops;
                    this.lookShop.Properties.DisplayMember = "ShopNo";
                    this.lookShop.Properties.ValueMember = "ShopID";
                    this.lookShop.Properties.ReadOnly = true;
                    //-- 

                    //Extended Customers

                    var qryCustomer = (from c in context.Extended_Customers
                                       join gc in context.Global_Customers on c.CustomerID equals gc.CustomerID
                                       select new { c.CustomerID, c.ExtendedCustomerID, gc.CustomerName }).ToList();
                    this.lookCustomer.Properties.DataSource = qryCustomer;
                    this.lookCustomer.Properties.DisplayMember = "CustomerName";
                    this.lookCustomer.Properties.ValueMember = "ExtendedCustomerID";

                    //--


                    // Querying Utility Invoices 

                    load_Invoices();

                    // - 

                    //this.enable_control(false, eRecStatus.eInit);

                    cEnable_Controls.ClearText(this);//05052014...to clear form controls
                    btnNew_ItemClick(null, null);

                    btnNew.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void load_Invoices()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    InvList.Clear();
                    var qryInv = (from i in context.Invoices
                                  where i.InvoiceTypeID == 2 && i.IsConfirmed == false && i.IsProcessed == true
                                  select i).ToList();
                                  //select new { i.SubInvTypeID, i.UtilityUnitRate, i.InvoiceTypeID, i.InvoiceID, i.InvoiceNo, i.LocationID, i.CompanyID, i.CustomerID, i.LevelID, i.ShopNo, i.ShopName, i.ProcessYear, i.ProcessMonth, i.DateFrom, i.DateTo, i.InvoiceDate, i.TotalAmount, i.TotalTax, i.StartReading, i.EndReading, i.StartReading2, i.EndReading2, i.M_StartReading,i.M_EndReading, i.NosUnitsConsumed1,i.NosUnitsConsumed2,i.M_NosUnitsConsumed, i.UtilityID, i.IsConfirmed, i.IsProcessed }).ToList();
                    foreach (var qry in qryInv)
                    {
                        cGen_Rent_Invoice oCGenInv = new cGen_Rent_Invoice();

                        oCGenInv.InvoiceID = qry.InvoiceID;
                        oCGenInv.InvoiceTypeID = qry.InvoiceTypeID;
                        oCGenInv.SubInvTypeID = qry.SubInvTypeID;
                        oCGenInv.DateFrom = qry.DateFrom;
                        oCGenInv.DateTo = qry.DateTo;
                        oCGenInv.InvoiceNo = qry.InvoiceNo;
                        oCGenInv.InvDate = qry.InvoiceDate;
                        oCGenInv.UtilityID = qry.UtilityID;
                        oCGenInv.ProcessYear = qry.ProcessYear;
                        oCGenInv.ProcessMonth = qry.ProcessMonth;
                        oCGenInv.CompanyID = qry.CompanyID;
                        oCGenInv.LocationID = qry.LocationID;
                        oCGenInv.LevelID = qry.LevelID;
                        oCGenInv.CustomerID = qry.CustomerID;
                        oCGenInv.InvoiceTypeID = qry.InvoiceTypeID;
                        oCGenInv.ShopNo = qry.ShopNo;
                        oCGenInv.ShopName = qry.ShopName;
                        oCGenInv.CustomerName = qry.CustomerName;
                        oCGenInv.TotalAmount = qry.TotalAmount;
                        oCGenInv.TotalTax = qry.TotalTax;
                        oCGenInv.GrandTotal = qry.TotalAmount + qry.TotalTax;
                        oCGenInv.UtilityUnitRate = qry.UtilityUnitRate;

                        // utility reading 
                        oCGenInv.StartReading1 = qry.StartReading;
                        oCGenInv.EndReading1 = qry.EndReading;
                        oCGenInv.NosUnitConsumed1 = qry.NosUnitsConsumed1;
                        // --

                        // utility meter reset 
                        oCGenInv.StartReading2 = qry.StartReading2;
                        oCGenInv.EndReading2 = qry.EndReading2;                                       
                        oCGenInv.NosUnitConsumed2 = qry.NosUnitsConsumed2;
                        //--

                        // maintenance reading
                        oCGenInv.M_StartReading = qry.M_StartReading;
                        oCGenInv.M_EndReading = qry.M_EndReading;
                        oCGenInv.M_NosUnitConsumed = qry.M_NosUnitsConsumed;
                        //--
                        oCGenInv.Confirm = qry.IsConfirmed;
                        oCGenInv.IsProcessed = qry.IsProcessed;
                        InvList.Add(oCGenInv);
                    }

                    this.cGen_Rent_InvoiceBindingSource.DataSource = InvList;
                    this.cGen_Rent_InvoiceGridControl.RefreshDataSource();
                }
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
           
           

        }

        private int getContractRateID( Invoice oInv , int pContractID)
        {
            int contractrateid = 0;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qry = (from c in context.Contracts
                           join cr in context.Contract_Rates on c.ContractID equals cr.ContractID
                           where cr.IsActive == true && c.IsTerminated == false && c.ContractID == pContractID
                           select new { c.ShopName, c.ContractID, cr.ContractRateID, c.LevelID, c.LocationID, c.CustomerID, c.CompanyID }).FirstOrDefault();
                if (qry != null)
                {
                    oInv.ContractID = qry.ContractID;
                    oInv.ContractRateID = qry.ContractRateID;
                    oInv.LocationID = qry.LocationID;
                    oInv.LevelID = qry.LevelID;
                    oInv.ExtendedCustomerID = qry.CustomerID;
                    oInv.CompanyID = qry.CompanyID;
                    oInv.ShopName = qry.ShopName;
                    contractrateid = qry.ContractRateID;
                }
            }

            return contractrateid;
        }

        private int getContractID(int compid, int custid, int locid)
        {
            int contractid = 0;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
               
                var qry = (from c in context.Contracts
                           where c.CompanyID == compid && c.CustomerID == custid && c.LocationID == locid
                           select new { c.ContractID }).FirstOrDefault();
                if (qry != null)
                {
                    contractid = qry.ContractID;
                }
            }

            return contractid;
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void chkReset_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReset.Checked == true)
            {
                txtStartreadingReset.Properties.ReadOnly = false;
                txtEndReadingReset.Properties.ReadOnly = false;
                txtTotalReset.Properties.ReadOnly = false;

                txtStartreadingReset.EditValue = 0.0000;
                txtEndReadingReset.EditValue = 0.0000;
                txtTotalReset.EditValue = 0.000;
                dxErrorProvider1.SetError(this.txtTotal1, "");
            
                calReading();
            }
            else
            {
                txtStartreadingReset.Properties.ReadOnly = true;
                txtEndReadingReset.Properties.ReadOnly = true;
                txtTotalReset.Properties.ReadOnly = true;

                txtStartreadingReset.EditValue = 0.0000;
                txtEndReadingReset.EditValue = 0.0000;
                txtTotalReset.EditValue = 0.000;

                calReading();
            }
        }

        private void lblEndReading2_Click(object sender, EventArgs e)
        {

        }

        private void lblToal2_Click(object sender, EventArgs e)
        {

        }

        private void lookUpEditCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lookUtilityID.Text.ToString() != "DIESEL") {
                return;
            }
            //if (!string.IsNullOrEmpty(this.lookUpEditCompany.Text.ToString()))
            //{
            //    int compid = 0;
            //    bool res = int.TryParse(this.lookUpEditCompany.EditValue.ToString(), out compid);
            //    if (res == false) { compid = 0; }
            //    if (compid == 0)
            //    {
            //        return;
            //    }

            //    //var extended customers
            //    var qryexc = (from c in context.Contracts
            //                  join exc in context.Extended_Customers on c.CustomerID equals exc.ExtendedCustomerID
            //                  join gc in context.Global_Customers on exc.CustomerID equals gc.CustomerID
            //                  where c.CompanyID == compid
            //                  select new { exc.ExtendedCustomerID, gc.CustomerName }).ToList();
            //    this.CustomerListLookupEdit.Properties.DisplayMember = "CustomerName";
            //    this.CustomerListLookupEdit.Properties.ValueMember = "ExtendedCustomerID";
            //    this.CustomerListLookupEdit.Properties.DataSource = qryexc;
            //}

        }

        private void CustomerListLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(this.CustomerListLookupEdit.Text.ToString()))
            //{
            //    int customerid = 0;
            //    bool res = int.TryParse(CustomerListLookupEdit.EditValue.ToString(), out customerid);
            //    if (res == false) { customerid = 0; }
                
            //    int compid = 0;
            //    res = int.TryParse(this.lookUpEditCompany.EditValue.ToString(), out compid);
            //    if (res == false) { compid = 0; }
                
            //    if (customerid == 0)
            //    {
            //        return;
            //    }


            //    var qryexc = from c in context.Contracts
            //                  join exc in context.Extended_Customers on c.CustomerID equals exc.ExtendedCustomerID
            //                  join gc in context.Global_Customers on exc.CustomerID equals gc.CustomerID
            //                  join cshop in context.Contract_Shops on c.ContractID equals cshop.ContractID 
            //                  join shp in context.Shops on cshop.ShopID equals shp.ShopID
            //                  where c.CompanyID == compid && exc.ExtendedCustomerID == customerid
            //                  select new { shp.ShopID,shp.ShopNo,shp.ShopName,exc.LocationID};
            //    var qryList= qryexc.ToList();

            //    this.lookUpEditShopName.Properties.DataSource = qryList;
            //    this.lookUpEditShopName.Properties.DisplayMember = "ShopNo";
            //    this.lookUpEditShopName.Properties.ValueMember = "ShopID";

            //    //getting selected customer's locaiton
            //    var qryFirst = qryexc.FirstOrDefault();
            //    if (qryFirst != null)
            //    {
            //        this.lookUpEditLocationID.EditValue = qryFirst.LocationID;
            //    }
            //    else
            //    {
            //        this.lookUpEditLocationID.EditValue = 0;
            //    }
                
            //}
        }

        private void lookUpEditShopID_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lookUpEditShopName.Text.ToString()))
            {


                bool res = false;
                int utilityid = 0;
                int shopid = 0;

                res = int.TryParse(lookUtilityID.EditValue.ToString(), out utilityid);
                if (res == false) { utilityid = 0; }

                res = int.TryParse(lookUpEditShopName.EditValue.ToString(), out shopid);
                if (res == false) { shopid = 0; }

                if (shopid == 0 || utilityid == 0)
                {
                    return;
                }

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryshop = (from s in context.Shops_UtilityReadings
                                   join ur in context.Utility_Rates on s.UtilityID equals ur.UtilityID
                                   where s.ShopID == shopid && s.UtilityID == utilityid
                                   select new { s.LastReading, s.LastReadingDate, ur.UnitRate }).FirstOrDefault();
                    if (qryshop != null)
                    {
                        this.txtStartReading1.EditValue = qryshop.LastReading;
                        this.txtUnitRate.EditValue = qryshop.UnitRate;
                    }
                    else
                    {
                        this.txtStartReading1.EditValue = 0;
                        this.txtUnitRate.EditValue = 0;
                    }
                }

                //int customerid = 0;
                //bool res = int.TryParse(CustomerListLookupEdit.EditValue.ToString(), out customerid);
                //if (res == false) { customerid = 0; }

                //int compid = 0;
                //res = int.TryParse(this.lookUpEditCompany.EditValue.ToString(), out compid);
                //if (res == false) { compid = 0; }

                //int shopid = 0;
                //res = int.TryParse(this.lookUpEditShopID.EditValue.ToString(), out shopid);
                //if (res == false) { shopid = 0; }

                //if (customerid == 0)
                //{
                //    return;
                //}

                //if (compid == 0)
                //{ return; }
                //if (shopid == 0) { return; }



                //var qryshop = (from s in context.Shops



            }
        }

        private void txtEndreading1_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtEndreading1.Text.ToString()))
            { return; }
            bool res = false;
            decimal startR1 = 0; decimal endR1 = 0;
            
            res = decimal.TryParse(this.txtStartReading1.EditValue.ToString(), out startR1);
            if (res == false) { startR1 = 0; }

            res = decimal.TryParse(this.txtEndreading1.EditValue.ToString(), out endR1);
            if (res == false) { endR1 = 0; }

            //if (startR1 < endR1)
            //{
                calReading();
            //}
            //else
            //{
            //    this.txtTotal1.EditValue = 0.0000;
            //    this.txtTotalCharge.EditValue = 0.0000;
            //    txtTotalTax.EditValue = 0.0000;
            //    txtGrandTotal.EditValue = 0.0000;
            //    invDetList.Clear();
            //    this.invoice_DetailsGridControl.RefreshDataSource();

            //}


            
        }

        private void calReading()
        {
            decimal startR1 = 0; decimal endR1 = 0; decimal startR2 = 0; decimal endR2 = 0; decimal unitrate = 0;
            decimal mstart = 0, mend = 0;
            decimal ratio = 0;
            bool res = false;

            res = decimal.TryParse(this.txtStartReading1.EditValue.ToString(), out startR1);
            if (res == false) { startR1 = 0; }

            res = decimal.TryParse(this.txtEndreading1.EditValue.ToString(), out endR1);
            if (res == false) { endR1 = 0; }

            res = decimal.TryParse(this.txtUnitRate.EditValue.ToString(), out unitrate);
            if (res == false) { unitrate = 0; }

            res = decimal.TryParse(this.txtRatio.EditValue.ToString(), out ratio);
            if (res == false) { ratio = 0; }




            if (chkReset.Checked == true)
            {
                res = decimal.TryParse(this.txtStartreadingReset.EditValue.ToString(), out startR2);
                if (res == false) { startR2 = 0; }

                if (string.IsNullOrEmpty(this.txtEndReadingReset.Text.ToString()))
                {
                    txtEndReadingReset.EditValue = 0;
                }
                res = decimal.TryParse(this.txtEndReadingReset.EditValue.ToString(), out endR2);
                if (res == false) { endR2 = 0; }
            }
            else
            {

                startR2 = 0;
                endR2 = 0;
            }

            if (chkIsMaintenace.Checked == true)
            {
                res = decimal.TryParse(this.txtStartReading1.EditValue.ToString(), out mstart);
                if (res == false) { mstart = 0; }


                res = decimal.TryParse(this.txtEndreading1.EditValue.ToString(), out mend);
                if (res == false) { mend = 0; }
            }
            else {
                mstart = 0;
                mend = 0;
            }


            decimal total1 = endR1 - startR1;
            decimal total2 = endR2 - startR2;
            decimal mtotal = mend - mstart;


            decimal gtotal = total1 + total2;
            decimal m_gtotal = mtotal + total2;
            this.txtTotal1.EditValue = total1;
            this.txtTotalReset.EditValue = total2;
            decimal totalamount = 0;
            if (chkIsMaintenace.Checked == true)
            {
                this.txtGrandTotalUnits.EditValue = m_gtotal;
                if (ratio > 0)
                {
                    totalamount = m_gtotal * unitrate * ratio;
                    this.txtTotalCharge.EditValue = totalamount;
                }
                else
                {
                    totalamount = m_gtotal * unitrate;
                    this.txtTotalCharge.EditValue = totalamount;
                }
            }
            else
            {
                this.txtGrandTotalUnits.EditValue = gtotal;
                if (ratio > 0)
                {
                    totalamount = gtotal * unitrate * ratio;
                    this.txtTotalCharge.EditValue = totalamount;
                }
                else
                {
                    totalamount = gtotal * unitrate;
                    this.txtTotalCharge.EditValue = totalamount;
                }
            }
            
            

            int shopUtilityReadingID = 0;
            res = int.TryParse(this.lookMeter.EditValue.ToString(), out shopUtilityReadingID);
            if (res == false) { shopUtilityReadingID = 0; }
            if (shopUtilityReadingID == 0 && this.lookUtilityID.Text.ToString() != "DIESEL")
            { dxErrorProvider1.SetError(this.lookMeter, "Invalid Meter"); return; }

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                if (chkIsMaintenace.Checked == false)
                {
                    bool IsTaxApplicable = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicableByExtendedCustomerId(int.Parse(lookCustomer.EditValue.ToString()));
                    bool istaxApplicableforUtility = MMS.CustomClasses.cCommon_Functions.IsOtherTaxApplicableForUtility(shopUtilityReadingID);
                    bool ismandatoryTaxApplicable = MMS.CustomClasses.cCommon_Functions.IsMandatoryTaxApplicableForUtility(shopUtilityReadingID);
                    invDetList.Clear();

                    cMandatoryTax mandatoryTax = cTaxCalculations.getAmountWithMandatoryTax(totalamount);
                    decimal totalWithMandatoryTax = mandatoryTax.TotalWithMandatoryTax;
                    Invoice_Details oInvDet = new Invoice_Details();
                    oInvDet.TaxID = mandatoryTax.MandatoryTaxID;
                    oInvDet.TaxCode = mandatoryTax.MandatoryTaxCode;
                    oInvDet.TaxRate = mandatoryTax.MandatoryTaxRate;
                    oInvDet.TaxRateID = mandatoryTax.MandatoryTaxRateID;
                    if (ismandatoryTaxApplicable == true)
                    {
                        if (IsTaxApplicable == true)
                        {
                            oInvDet.Amount = mandatoryTax.MandatoryTaxAmount;
                            oInvDet.IsPrint = false;
                        }
                        else
                        {
                            oInvDet.Amount = 0;
                            oInvDet.IsPrint = false;

                        }
                    }
                    else
                    {
                        oInvDet.Amount = 0;
                        oInvDet.IsPrint = false;
                    }
                    invDetList.Add(oInvDet);


                    List<cOtherTax> otherTaxList = new List<cOtherTax>();
                    if (ismandatoryTaxApplicable == true)
                    {
                        otherTaxList = cTaxCalculations.getOtherTax(totalWithMandatoryTax);
                    }
                    else
                    {
                        otherTaxList = cTaxCalculations.getOtherTax(totalamount);
                    }

                    foreach (var qry in otherTaxList)
                    {

                        oInvDet = new Invoice_Details();
                        oInvDet.TaxID = qry.TaxID;
                        oInvDet.TaxCode = qry.TaxCode;
                        oInvDet.TaxRate = qry.TaxRate;
                        oInvDet.TaxRateID = qry.TaxRateID;
                        if (istaxApplicableforUtility == true)
                        {

                            if (IsTaxApplicable == true)
                            {
                                oInvDet.Amount = qry.TaxAmount;
                                oInvDet.IsPrint = true;
                            }
                            else
                            {
                                oInvDet.Amount = 0;
                                oInvDet.IsPrint = false;
                            }

                        }
                        else
                        {
                            oInvDet.Amount = 0;
                            oInvDet.IsPrint = false;
                        }
                        invDetList.Add(oInvDet);
                    }

                    invoice_DetailsGridControl.DataSource = invDetList;
                    invoice_DetailsGridControl.RefreshDataSource();


                    decimal totaltax = invDetList.Sum(x => x.Amount);
                    this.txtTotalTax.EditValue = totaltax;

                    decimal grandtotal = totalamount + totaltax;
                    this.txtGrandTotal.EditValue = grandtotal;
                }
                else
                {
                    invoice_DetailsGridControl.DataSource = null;
                    invoice_DetailsGridControl.RefreshDataSource();
                    
                    
                    this.txtTotalTax.EditValue = 0;
                    this.txtGrandTotal.EditValue = totalamount;

                }                             
            }
        }

        private decimal getAmount(int pTaxRateID, decimal pTotalamount)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
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
                amount = (taxrate * pTotalamount) / 100;
                return amount;
            }

        }

       
       
        private string getFooterText1(int utilityid)
        {
            string footerText = "";
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryUtility = (from u in context.Utilities
                                  where u.UtilityID == utilityid
                                  select new { u.InvoiceFooterText }).FirstOrDefault();
                if (qryUtility != null)
                {
                    footerText = qryUtility.InvoiceFooterText;
                }

            }
            return footerText;
        }

        private int getFloorLevel(int pContractID)
        {
            int levelid = 0;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryLevel = (from c in context.Contracts
                                where c.ContractID == pContractID
                                select new { c.LevelID }).FirstOrDefault();
                if (qryLevel != null)
                {
                    levelid = qryLevel.LevelID;
                }
            }

            return levelid;
        }

        

        private void txtEndReading2_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtEndReadingReset.Text.ToString()))
            {
                calReading();
            }
        }

        private void txtStartreading2_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtStartreadingReset.Text.ToString()))
            {
                calReading();
            }
        }

        private void UtilityID_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lookUtilityID.Text.ToString()))
            {
                //int utilityid = 0;
                //bool res = int.TryParse(LookUpEditUtilityID.EditValue.ToString(), out utilityid);
                //if (res == false) { utilityid = 0; }

                //if (utilityid > 0)
                //{

                //    var qryUtilityTax = (from ur in context.Utility_Rates
                //                         join urd in context.UtlityRate_Details on ur.UtilityRateID equals urd.UtilityRateID
                //                         where ur.UtilityID == utilityid
                //                         select new { urd.TaxID, urd.TaxRateID }).ToList();

                //    if (invDetList.Count > 0) { invDetList.Clear(); }

                //    foreach (var qry in qryUtilityTax)
                //    {
                //        Invoice_Details oInvDet = new Invoice_Details();
                //        oInvDet.TaxID = qry.TaxID;
                //        oInvDet.TaxRateID = qry.TaxRateID;
                //        oInvDet.Amount = 0;
                //        invDetList.Add(oInvDet);
                //    }

                //    this.invoice_DetailsBindingSource.DataSource = invDetList.ToList();
                //}
                

            }
        }

        private void dtMonthYear_EditValueChanged(object sender, EventArgs e)
        {

           // CheckIsProcessed();

            #region comments
            //if (!string.IsNullOrEmpty(this.dtMonthYear.EditValue.ToString()) && (!string.IsNullOrEmpty(this.UtilityID.Text.ToString())))
            //{
            //    //if (!string.IsNullOrEmpty(this.UtilityID.Text.ToString()))
            //    {
            //        int utilityid = 0;
            //        bool res = int.TryParse(this.UtilityID.EditValue.ToString(), out utilityid);
            //        if (res == false) { utilityid = 0; }

            //        if (utilityid > 0)
            //        {
            //            var qry = (from ic in context.Invoice_Cycles
            //                       where ic.InvoiceTypeID == 2 && ic.UtilityID == utilityid
            //                       select ic).FirstOrDefault();
            //            if (qry != null)
            //            {
            //                dtFrom.DateTime = new DateTime(dtMonthYear.DateTime.Year, dtMonthYear.DateTime.Month, qry.FromDay);
            //                DateTime _todate = dtFrom.DateTime;
            //                int month = 0;
            //                if (qry.FromDay > qry.ToDay)
            //                {
            //                    month = dtMonthYear.DateTime.AddMonths(-1).Month;
            //                }
            //                else
            //                {
            //                    month = dtMonthYear.DateTime.Month;
            //                }

            //                if (qry.ToDay< 28)
            //                {
            //                    dtTo.DateTime = new DateTime(_todate.Year, month, qry.ToDay);
            //                }
            //                else
            //                {
            //                    dtTo.DateTime = new DateTime(_todate.Year, month, _todate.AddMonths(1).AddDays(-1).Day);
            //                }

            //            }
            //            else
            //            {
            //                dtFrom.DateTime = new DateTime(dtMonthYear.DateTime.Year, dtMonthYear.DateTime.Month, 1);
            //                dtTo.DateTime = new DateTime(dtMonthYear.DateTime.Year, dtMonthYear.DateTime.AddMonths(1).Month, dtMonthYear.DateTime.AddMonths(1).AddDays(-1).Day);


            //            }
            //        }
            //    }
            //}

            #endregion 
            
            //check invoice is exist  ravindra 11-6-2019
            //try
            //{
            //    if (addNew == true)
            //    {
            //        if (string.IsNullOrEmpty(this.lookUtilityID.Text.ToString()))
            //        {
            //            dxErrorProvider1.SetError(this.lookUtilityID, "Invalid Utility Type");
            //            return;
            //        }
            //        else { dxErrorProvider1.SetError(this.lookUtilityID, ""); }

            //        if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
            //        {
            //            dxErrorProvider1.SetError(this.lookCompany, "Invalid company");
            //            return;
            //        }
            //        else { dxErrorProvider1.SetError(this.lookCompany, ""); }

            //        if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
            //        {
            //            dxErrorProvider1.SetError(this.lookLocation, "Invalid Location");
            //            return;
            //        }
            //        else { dxErrorProvider1.SetError(this.lookLocation, ""); }

            //        if (string.IsNullOrEmpty(this.lookMeter.Text.ToString()))
            //        {
            //            dxErrorProvider1.SetError(this.lookMeter, "Invalid Meter Name");
            //            return;
            //        }
            //        else { dxErrorProvider1.SetError(this.lookMeter, ""); }


            //        int month = dtMonthYear.DateTime.Month;
            //        int year = dtMonthYear.DateTime.Year;
            //        int invtypeId = int.Parse(lookUtilityID.EditValue.ToString());
            //        int compid = int.Parse(lookCompany.EditValue.ToString());
            //        int locid = int.Parse(lookLocation.EditValue.ToString());
            //        string meternm = lookMeter.Text.Trim();

            //        var qryInvProcessed = (from i in context.Invoices
            //                               where i.IsProcessed == true && i.ProcessMonth == month && i.ProcessYear == year && i.UtilityID == invtypeId &&
            //                                      i.CompanyID == compid && i.LocationID == locid && i.UtilityMeterName == meternm
            //                               select new { i.UtilityMeterName, i.IsProcessed }).FirstOrDefault();

            //        if (qryInvProcessed != null)//|| qryInvProcessed.IsProcessed==true
            //        {
            //            MessageBox.Show("Invoice Allready Processed for, Shop Name : " + lookUpEditShopName.Text + "\n" + "Meter Name:" + meternm);
            //            //btnSave.Enabled = false;
            //            //btnNew.Enabled = true;
            //            //btnEdit.Enabled = true;

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{ MessageBox.Show(ex.ToString()); }


        }

        private void invoice_DetailsGridControl_Click(object sender, EventArgs e)
        {

        }

        private void txtUnitRate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalCharge_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditLocationID_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void txtGrandTotal_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl12_Click(object sender, EventArgs e)
        {

        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }

        private void dtTo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dtFrom_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal1_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTotal1.Text.ToString()))
            { return; }

            bool res = false;
            decimal total = 0;
            res = decimal.TryParse(this.txtTotal1.EditValue.ToString(), out total);
            if (res == false) { total = 0; }
            if (total == 0)
            { dxErrorProvider1.SetError(this.txtTotal1, "Invalid Amount"); }
            else { dxErrorProvider1.SetError(this.txtTotal1, ""); }








        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void txtStartReading1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lblUtility_Click(object sender, EventArgs e)
        {

        }

        private void lblStartReading2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal2_EditValueChanged(object sender, EventArgs e)
        {

        }

        

        private void lookUpEditShopName_EditValueChanged(object sender, EventArgs e)
        {
            int utilityid = 0;
            int contractid = 0;
            bool res = int.TryParse(this.lookUpEditShopName.EditValue.ToString(), out contractid);
            if (res == false) { contractid = 0; }
            if (contractid > 0)  
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryShops = (from c in context.ContractClosures
                                    join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                    join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                                    where c.ContractClosureID == contractid
                                    select new { c.ShopID, c.CompanyID, c.LocationID, c.LevelID, gcus.CustomerID,ExtendedCustomerID = exc.ExtendedCustomerID }).FirstOrDefault();
                    if (qryShops != null)
                    {
                        this.lookShop.EditValue = qryShops.ShopID;
                        this.lookCompany.EditValue = qryShops.CompanyID;
                        this.lookLocation.EditValue = qryShops.LocationID;
                        this.lookCustomer.EditValue = qryShops.ExtendedCustomerID;

                    }

                    if (string.IsNullOrEmpty(this.lookUtilityID.Text.ToString()))
                    { return; }

                    res = int.TryParse(lookUtilityID.EditValue.ToString(), out utilityid);
                    if (res == false) { utilityid = 0; }


                    var qryshop = (from s in context.Shops_UtilityReadings
                                   where s.ShopID == qryShops.ShopID
                                   select new { s.LastReading, s.IsRatioApplied, s.RatioID }).FirstOrDefault();
                    if (qryshop != null)
                    {
                        this.txtStartReading1.EditValue = qryshop.LastReading;
                        txtStartReading1.Properties.ReadOnly = true;

                    }
                    else
                    {
                        this.txtStartReading1.EditValue = 0;
                        txtStartReading1.Properties.ReadOnly = true;
                    }


                    //// utility rate

                    var qryURate = (from ur in context.Utility_Rates
                                    where ur.UtilityID == utilityid && ur.CompanyID == qryShops.CompanyID
                                    select ur).FirstOrDefault();
                    if (qryURate != null)
                    {
                        this.txtUnitRate.EditValue = qryURate.UnitRate.Value;
                        if (qryshop != null)
                        {
                            if (qryshop.IsRatioApplied == true)
                            {
                                this.txtRatio.EditValue = context.Ratios.Where(x => x.RatioID == qryshop.RatioID).FirstOrDefault().RatioNo.Value;
                            }
                            else
                            {
                                this.txtRatio.EditValue = 0;
                            }
                        }
                    }
                }
                //this.lookUpEditShopID.Properties.DataSource = qryShops;
                //this.lookUpEditShopID.Properties.ValueMember = "ShopID";
                //this.lookUpEditShopID.Properties.DisplayMember = "ShopNo";

                //if (qryShops.ToList().Count == 1)
                //{

                //    this.lookUpEditShopID.EditValue = qryShops.FirstOrDefault().ShopID;
                //}


                //var qryother = (from c in context.Contracts
                //                join exc in context.Extended_Customers on c.CustomerID equals exc.ExtendedCustomerID
                //                join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                //                where c.ContractID == contractid
                //                select new { c.CompanyID, c.LocationID,gcus.CustomerID }).FirstOrDefault();
                //this.lookUpEditCompany.EditValue = qryother.CompanyID;
                //this.lookUpEditLocationID.EditValue = qryother.LocationID;
                //this.CustomerListLookupEdit.EditValue = qryother.CustomerID;

               
            }
            

        }

        private void lookUpEditShopID_EditValueChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lookShop.Text.ToString()) || string.IsNullOrEmpty(this.lookUtilityID.Text.ToString()))
            {
                return;
            }


            int shopid = 0;
            int utilityid = 0;
            bool res = int.TryParse(lookShop.EditValue.ToString(), out shopid);
            res = int.TryParse(lookUtilityID.EditValue.ToString(),out utilityid);
            if (res==false) { utilityid=0;}

            
            if (res == false) { shopid = 0; }

            if (shopid > 0)          
            {
                // Meter Name 
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryMeterNames = (from m in context.Shops_UtilityReadings
                                         join u in context.Utilities on m.UtilityID equals u.UtilityID
                                         where m.UtilityID == utilityid && m.ShopID == shopid
                                         select new { m.MeterName, m.ShopUtilityReadingID, m.ShopID, m.Shop.ShopNo, m.UtilityID, u.UtilityName }).ToList();
                    this.lookMeter.Properties.DataSource = qryMeterNames;
                    this.lookMeter.Properties.DisplayMember = "MeterName";
                    this.lookMeter.Properties.ValueMember = "ShopUtilityReadingID";
                }            


            }



        }

        

        private void optSubInvType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditMeterName_EditValueChanged(object sender, EventArgs e)
        {
            bool res = false;
            int utilityid = 0;
            int companyid = 0;

            if (string.IsNullOrEmpty(this.lookUtilityID.Text.ToString())) 
            {return;}

            res = int.TryParse(lookUtilityID.EditValue.ToString(),out utilityid);
            if (res==false) { utilityid=0;}
            
            if (string.IsNullOrEmpty(this.lookMeter.Text.ToString()))
            {
                return;
            }
            
            // company 
            res = int.TryParse(lookCompany.EditValue.ToString(), out companyid);
            if (res == false) { companyid = 0; }
            if (companyid == 0)
            {
                dxErrorProvider1.SetError(this.lookCompany, "Invalid Company");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.lookCompany, "");
            }


            

            int ureadid = 0;
            res = int.TryParse(this.lookMeter.EditValue.ToString(), out ureadid);
            if (res == false) { ureadid = 0; }
            if (ureadid==0) 
            {return;}

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryshop = (from s in context.Shops_UtilityReadings
                               where s.ShopUtilityReadingID == ureadid
                               select new { s.LastReading, s.IsRatioApplied, s.RatioID }).FirstOrDefault();
                if (qryshop != null)
                {
                    this.txtStartReading1.EditValue = qryshop.LastReading;
                    txtStartReading1.Properties.ReadOnly = true;

                }
                else
                {
                    this.txtStartReading1.EditValue = 0;
                    txtStartReading1.Properties.ReadOnly = true;
                }

               
                //// utility rate

                var qryURate = (from ur in context.Utility_Rates
                                where ur.UtilityID == utilityid && ur.CompanyID == companyid
                                select ur).FirstOrDefault();
                if (qryURate != null)
                {
                    this.txtUnitRate.EditValue = qryURate.UnitRate.Value;
                    if (qryshop != null)
                    {
                        if (qryshop.IsRatioApplied == true)
                        {
                            this.txtRatio.EditValue = context.Ratios.Where(x => x.RatioID == qryshop.RatioID).FirstOrDefault().RatioNo.Value;
                        }
                        else
                        {
                            this.txtRatio.EditValue = 0;
                        }
                    }
                }
            }
            //check already exist
           CheckIsProcessed();
           // dtMonthYear_EditValueChanged(null,null);
           
        }

        private void chkIsMaintenace_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsMaintenace.Checked == true)
            {
                this.invoice_DetailsGridControl.DataSource = null;
                this.invoice_DetailsGridControl.RefreshDataSource();
                //txtMaintenanceEnd.Properties.ReadOnly = false;
                //txtMaintenanceStart.Properties.ReadOnly = false;
                //txtMaintenanceTotal.Properties.ReadOnly = false;
               
                //txtMaintenanceTotal.EditValue = 0.0000;
                //txtMaintenanceStart.EditValue = 0.0000;
                //txtMaintenanceEnd.EditValue = 0.0000;
            }
            else
            {
                this.invoice_DetailsGridControl.DataSource = invDetList;
                this.invoice_DetailsGridControl.RefreshDataSource();
                //txtMaintenanceEnd.Properties.ReadOnly = true;
                //txtMaintenanceStart.Properties.ReadOnly = true;
                //txtMaintenanceTotal.Properties.ReadOnly = true;

                //txtMaintenanceTotal.EditValue = 0.0000;
                //txtMaintenanceStart.EditValue = 0.0000;
                //txtMaintenanceEnd.EditValue = 0.0000;
            }
        }

        private void txtMaintenanceEnd_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(this.txtMaintenanceEnd.Text.ToString()))
            //{ return; }

            //if (string.IsNullOrEmpty(this.txtMaintenanceStart.Text.ToString()))
            //{ return; }

            //decimal endReading = 0;
            //decimal startReading = 0;
            //decimal totalConsumed = 0;
            //bool res = false;

            //res = decimal.TryParse(this.txtMaintenanceStart.EditValue.ToString(), out startReading);
            //if (res == false) { startReading = 0; }

            //res = decimal.TryParse(this.txtMaintenanceEnd.EditValue.ToString(), out endReading);
            //if (res == false) { endReading = 0; }

            //totalConsumed = endReading - startReading;

            //this.txtMaintenanceTotal.EditValue = totalConsumed;

        }

        private void splitterControl1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void cGen_Rent_InvoiceBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                cGen_Rent_Invoice genRentInvoiceObject = (cGen_Rent_Invoice)  this.cGen_Rent_InvoiceBindingSource.Current;
                if (genRentInvoiceObject != null)
                {
                    using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {
                        var qryInvoice = (from i in context.Invoices
                                          where i.InvoiceID == genRentInvoiceObject.InvoiceID
                                          select i).FirstOrDefault();
                        if (qryInvoice != null)
                        {
                            this.lookUtilityID.EditValue = qryInvoice.UtilityID;
                            this.lookUpEditShopName.EditValue = qryInvoice.ContractClosureID;
                            this.lookCompany.EditValue = qryInvoice.CompanyID;
                            this.lookLocation.EditValue = qryInvoice.LocationID;
                            this.lookCustomer.EditValue = qryInvoice.ExtendedCustomerID;
                            this.lookShop.EditValue = qryInvoice.ShopID;
                            this.lookMeter.EditValue = qryInvoice.ShopUtilityReadingID;
                            this.txtStartReading1.EditValue = qryInvoice.StartReading;
                            this.txtEndreading1.EditValue = qryInvoice.EndReading;
                            this.txtTotal1.EditValue = qryInvoice.NosUnitsConsumed1;
                            this.txtStartreadingReset.EditValue = qryInvoice.StartReading2;
                            this.txtEndReadingReset.EditValue = qryInvoice.EndReading2;
                            this.txtTotalReset.EditValue = qryInvoice.NosUnitsConsumed2;
                            //this.txtMaintenanceStart.EditValue = qryInvoice.M_StartReading;
                            //this.txtMaintenanceEnd.EditValue = qryInvoice.M_EndReading;
                            //this.txtMaintenanceTotal.EditValue = qryInvoice.M_NosUnitsConsumed;
                            this.dtInvoiceDate.EditValue = qryInvoice.InvoiceDate;
                            this.dtFrom.EditValue = qryInvoice.DateFrom;
                            this.txtInvoiceFooter.EditValue = qryInvoice.FooterText1;
                            this.dtTo.EditValue = qryInvoice.DateTo;
                            this.dtMonthYear.DateTime = new DateTime(qryInvoice.ProcessYear, qryInvoice.ProcessMonth, 1);
                            if (qryInvoice.SubInvTypeID == 3)
                            {
                                optSubInvType.SelectedIndex = 0;
                            }
                            if (qryInvoice.SubInvTypeID == 2)
                            {
                                optSubInvType.SelectedIndex =2;
                            }
                            if (qryInvoice.SubInvTypeID == 1)
                            {
                                optSubInvType.SelectedIndex = 1;
                            }


                            /// Invoice Detail 
                            invDetList.Clear();

                            invDetList = qryInvoice.Invoice_Details.ToList();
                            this.invoice_DetailsGridControl.DataSource = invDetList;
                            this.invoice_DetailsGridControl.RefreshDataSource();

                            //--
                            
                        }

                    }

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cInvoiceBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        //private void cmdDelete_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        //{

        //}

        private void parentTopPanel_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    rptMain reportMain = new rptMain();
                    rptUtilityInvoice rptUtility = new rptUtilityInvoice();

                    var qryInvoice = (from i in context.Invoices
                                      where i.InvoiceNo == lblInvoiceNo.Text
                                      select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable }).ToList();

                    var qryInvDet = (from invdet in context.Invoice_Details
                                     join t in context.Taxes on invdet.TaxID equals t.TaxID
                                     where t.IsMandatory == false
                                     select new { invdet.Amount, invdet.InvoiceDetailID, invdet.InvoiceID, invdet.IsPrint, invdet.TaxCode, invdet.TaxID }).ToList();

                    var qryCompany = (from c in context.Companies
                                      select new { c.CompanyCode, c.CompanyID, c.DefaultTaxRegNo, c.CompanyName, c.Tele1, c.Tele2, c.Address, c.BusinessRegNo, c.InvoiceFooterText1, c.InvoiceFooterText2 }).ToList();

                    var qryMonth = (from m in context.Months
                                    select m).ToList();

                    var qryTax = (from t in context.Taxes
                                  select new { t.TaxID, t.TaxCode, t.IsMandatory }).ToList();


                    var qryLocaiton = (from l in context.Locations
                                       select new { l.LocationID, l.LocationName, l.Logo, l.Address }).ToList();


                    var qryInvType = (from it in context.Invoice_Types
                                      select new { it.InvoiceTypeID, it.InvoiceTypeName }).ToList();

                    var qrySubInvType = (from sit in context.Sub_Invoice_Types
                                         select new { sit.SubInvTypeID, sit.SubInvTypeName }).ToList();

                    var qryUtility = (from u in context.Utilities
                                      select new { u.UtilityID, u.UtilityName }).ToList();



                    rptUtility.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                    rptUtility.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                    rptUtility.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                    rptUtility.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                    rptUtility.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                    rptUtility.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                    rptUtility.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                    rptUtility.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);
                    rptUtility.Database.Tables["DataTier_Utility"].SetDataSource(qryUtility);
                    rptUtility.SetParameterValue("pHeaderText", "COPY");
                    rptUtility.SetParameterValue("pDetailText", "This is a computer generated copy. Signature is not required");

                    //rptrentInv.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGCust);
                    reportMain.crystalReportViewer1.ReportSource = rptUtility;

                    reportMain.Show(this);
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
            
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                

                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                int locid = 0; int utilityid = 0; decimal unitrate = 0; decimal totalunits = 0; int compid = 0; int extendedCustId = 0;
                decimal ratio = 0;
                int contractid = 0;


                bool res = int.TryParse(this.lookLocation.EditValue.ToString(), out locid);
                if (res == false) { locid = 0; }

                res = int.TryParse(this.lookUpEditShopName.EditValue.ToString(), out contractid);
                if (res == false) { contractid = 0; }

                res = int.TryParse(this.lookUtilityID.EditValue.ToString(), out utilityid);
                if (res == false) { utilityid = 0; }
                res = int.TryParse(this.lookCompany.EditValue.ToString(), out compid);
                if (res == false) { compid = 0; }
                res = int.TryParse(lookCustomer.EditValue.ToString(), out extendedCustId);
                if (res == false) { extendedCustId = 0; }
                res = decimal.TryParse(this.txtUnitRate.EditValue.ToString(), out unitrate);
                if (res == false) { unitrate = 0; }
                res = decimal.TryParse(this.txtGrandTotalUnits.EditValue.ToString(), out totalunits);
                if (res == false) { totalunits = 0; }
                res = decimal.TryParse(this.txtRatio.EditValue.ToString(), out ratio);
                if (res == false) { ratio = 0; }


                decimal start1 = 0; decimal end1 = 0; decimal start2 = 0; decimal end2 = 0;
                res = decimal.TryParse(txtStartReading1.EditValue.ToString(), out start1);
                if (res == false) { start1 = 0; }
                res = decimal.TryParse(txtEndreading1.EditValue.ToString(), out end1);
                if (res == false) { end1 = 0; }
                res = decimal.TryParse(this.txtStartreadingReset.Text.ToString(), out start2);
                if (res == false) { start2 = 0; }
                res = decimal.TryParse(this.txtEndReadingReset.Text.ToString(), out end2);
                if (res == false) { end2 = 0; }

                // maintanace varialbes 
                decimal mstart = 0; decimal mend = 0; decimal mtotalunits = 0;
                
                
                ///// units consumed for maintenance work/////
                if (chkIsMaintenace.Checked == true)
                {
                    mstart = start1;
                    mend = end1;
                    mtotalunits = mend - mstart;
                }




                int subinvtypeid = 3;


                //Validation 
                //check contractid 
                if (contractid == 0)
                {
                    dxErrorProvider1.SetError(this.lookUpEditShopName, "Invalid Shop or Contract");
                    return;
                }
                else
                {
                    dxErrorProvider1.SetError(this.lookUpEditShopName, "");
                }
                //--


                if (optSubInvType.SelectedIndex == 0)
                {
                    subinvtypeid = 3;
                }
                if (optSubInvType.SelectedIndex == 1)
                {
                    subinvtypeid = 1;
                }
                if (optSubInvType.SelectedIndex == 2)
                {
                    subinvtypeid = 2;
                }

                //validating utilityid
                if (string.IsNullOrEmpty(this.lookUtilityID.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.lookUtilityID, "Invalid Utiliy Name");
                    return;
                }
                {
                    dxErrorProvider1.SetError(this.lookUtilityID, "");
                }

                // validating shopname 
                if (string.IsNullOrEmpty(lookUpEditShopName.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.lookUpEditShopName, "Invalid Shop Name");
                    return;
                } { dxErrorProvider1.SetError(this.lookUpEditShopName, ""); }

                int contclauseid = 0;
                res = int.TryParse(this.lookUpEditShopName.EditValue.ToString(), out contclauseid);
                if (res == false) { contclauseid = 0; }
                if (contclauseid == 0)
                {
                    dxErrorProvider1.SetError(this.lookUpEditShopName, "Invalid Shop Name");
                    return;
                }
                else { dxErrorProvider1.SetError(this.lookUpEditShopName, ""); }


                // validating meter name 
                if (string.IsNullOrEmpty(this.lookMeter.Text.ToString()) && this.lookUtilityID.Text.ToString() != "DIESEL")
                {
                    dxErrorProvider1.SetError(this.lookMeter, "Invalid Meter Name");
                    return;
                }
                else { dxErrorProvider1.SetError(this.lookMeter, ""); }

                int shoputirateid = 0;
                res = int.TryParse(this.lookMeter.EditValue.ToString(), out shoputirateid);
                if (res == false) { shoputirateid = 0; }
                if (shoputirateid == 0 && this.lookUtilityID.Text.ToString() != "DIESEL")
                { dxErrorProvider1.SetError(this.lookMeter, "Invalid Meter"); return; }
                else { dxErrorProvider1.SetError(this.lookMeter, ""); }
                //--

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    using (TransactionScope trs = new TransactionScope())
                    {
                        if (addNew == true)
                        {

                            Invoice oInvoice = new Invoice();
                            lblInvoiceNo.Text = oInvoice.InvoiceNo;
                            oInvoice.InvoiceDate = dtInvoiceDate.DateTime.Date;
                            oInvoice.SAP_PstnDateInDoc = oInvoice.InvoiceDate;
                            oInvoice.ProcessYear = dtMonthYear.DateTime.Year;
                            oInvoice.ProcessMonth = dtMonthYear.DateTime.Month;
                            oInvoice.DateFrom = dtFrom.DateTime;
                            oInvoice.DateTo = dtTo.DateTime;
                            oInvoice.FooterText1 = this.txtInvoiceFooter.Text.ToString();
                            oInvoice.TotalAmount = decimal.Parse(this.txtTotalCharge.EditValue.ToString());
                            oInvoice.RentPerMonth = oInvoice.TotalAmount;
                            oInvoice.RentWithSCPerMonth = oInvoice.TotalAmount;
                            oInvoice.InvoiceTypeID = 2;
                            oInvoice.UtilityID = utilityid;

                            oInvoice.UtilityName = lookUtilityID.Text.ToString().Trim();
                            oInvoice.SubInvTypeID = subinvtypeid;
                            oInvoice.IsProcessed = true;
                            oInvoice.IsConfirmed = false;
                            oInvoice.ShopNo = this.lookShop.Text.ToString(); // shop no 
                            oInvoice.ContractClosureID = contclauseid; // Contract Clause ID
                            oInvoice.ShopName = this.lookUpEditShopName.Text.ToString();
                            oInvoice.CompanyID = cCommon_Functions.getCompanyID(contclauseid);
                            oInvoice.CompanyCode = context.Companies.Where(x => x.CompanyID == oInvoice.CompanyID).FirstOrDefault().CompanyCode;
                            oInvoice.LocationID = cCommon_Functions.getLocationID(contclauseid);
                            oInvoice.LocationCode = context.Locations.Where(x => x.LocationID == oInvoice.LocationID).FirstOrDefault().LocationCode;
                            oInvoice.LevelID = cCommon_Functions.getLevelID(contclauseid);
                            oInvoice.LevelName = context.Floor_Levels.Where(x => x.LevelID == oInvoice.LevelID).FirstOrDefault().LevelName;
                            oInvoice.ShopID = cCommon_Functions.getShopID(contclauseid);
                            oInvoice.CustomerAddress = cCommon_Functions.getCustomerAddress(contclauseid);
                            oInvoice.CustomerAddress2 = oInvoice.CustomerAddress;
                            oInvoice.ShopUtilityReadingID = int.Parse(lookMeter.EditValue.ToString());
                            //Ratio 
                            var qryRatio = (from s in context.Shops_UtilityReadings
                                            join r in context.Ratios on s.RatioID equals r.RatioID
                                            where s.ShopUtilityReadingID == oInvoice.ShopUtilityReadingID
                                            select new { r.RatioNo }).FirstOrDefault();
                            if (qryRatio != null)
                            {
                                if (qryRatio.RatioNo.HasValue)
                                {
                                    oInvoice.Ratio = qryRatio.RatioNo.Value;
                                }
                            }
                            //--
                            if (this.lookUtilityID.Text.ToString() != "DIESEL")
                            {
                                oInvoice.UtilityMeterName = context.Shops_UtilityReadings.Where(x => x.ShopUtilityReadingID == oInvoice.ShopUtilityReadingID).FirstOrDefault().MeterName;
                            }
                            oInvoice.UtilityMeterName = "N/A";
                            oInvoice.StartReading = start1;
                            oInvoice.EndReading = end1;
                            //oInvoice.EndReading = 1234567.1234m;
                            oInvoice.Reset = chkReset.Checked;
                            oInvoice.StartReading2 = start2;
                            oInvoice.EndReading2 = end2;
                            oInvoice.IsMaintenance = this.chkIsMaintenace.Checked;
                            oInvoice.M_StartReading = mstart;
                            oInvoice.M_EndReading = mend;
                            oInvoice.M_NosUnitsConsumed = mtotalunits;
                            oInvoice.CustomerID = context.Extended_Customers.Where(x => x.ExtendedCustomerID == extendedCustId).FirstOrDefault().CustomerID;
                            oInvoice.ExtendedCustomerID = extendedCustId;
                            oInvoice.UtilityUnitRate = unitrate;
                            oInvoice.NosUnitsConsumed1 = end1 - start1;
                            oInvoice.NosUnitsConsumed2 = end2 - start2;
                            //oInvoice.M_NosUnitsConsumed = mend - mstart;
                            oInvoice.TotalNosUnitConsumed = totalunits;
                            //oInvoice.Ratio = ratio;
                            var qryCust = (from ec in context.Extended_Customers
                                           join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                           where ec.ExtendedCustomerID == extendedCustId
                                           select new { gc.CustomerName, gc.IsTaxCustomer }).FirstOrDefault();

                            oInvoice.CustomerName = qryCust.CustomerName;
                            oInvoice.MandatoryTaxCode = "";
                            oInvoice.ModifiedDate = DateTime.Now;
                            oInvoice.IsTaxCustomer = qryCust.IsTaxCustomer;
                            //
                            bool istaxAppllicable = false;
                            bool isutilityTaxApplicable = false;
                            bool isMandatoryTaxApplicable = false;


                                istaxAppllicable = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicableByExtendedCustomerId(extendedCustId);

                                isutilityTaxApplicable = MMS.CustomClasses.cCommon_Functions.IsOtherTaxApplicableForUtility(shoputirateid);
                                oInvoice.IsUtilityTaxApplicable = isutilityTaxApplicable;

                                isMandatoryTaxApplicable = MMS.CustomClasses.cCommon_Functions.IsMandatoryTaxApplicableForUtility(shoputirateid);


                                cMandatoryTax mandatoryTax = cTaxCalculations.getAmountWithMandatoryTax(oInvoice.RentPerMonth);
                                List<cOtherTax> otherTaxList = new List<cOtherTax>();

                                if (chkIsMaintenace.Checked == false)
                                {
                                    if (istaxAppllicable == true)
                                    {
                                        if (oInvoice.IsTaxCustomer == true) // tax customer
                                        {
                                            if (isutilityTaxApplicable == true)
                                            {
                                                if (isMandatoryTaxApplicable == true)
                                                {
                                                    oInvoice.MandatoryTaxAmount = mandatoryTax.MandatoryTaxAmount;
                                                    oInvoice.TotalWithMandatoryTax = mandatoryTax.TotalWithMandatoryTax;
                                                    otherTaxList = cTaxCalculations.getOtherTax(mandatoryTax.TotalWithMandatoryTax);
                                                }
                                                else
                                                {
                                                    otherTaxList.Clear();
                                                    otherTaxList = cTaxCalculations.getOtherTax(oInvoice.RentPerMonth);
                                                    oInvoice.MandatoryTaxAmount = 0;
                                                    oInvoice.TotalWithMandatoryTax = oInvoice.TotalAmount;
                                                    decimal otherTaxTotal = otherTaxList.Sum(x => x.TaxAmount);
                                                    oInvoice.OtherTax = otherTaxTotal;
                                                }
                                            }
                                            else
                                            {
                                                ////oInvoice.TotalWithMandatoryTax = oInvoice.TotalAmount; ////Comment this for use grand total correcvtly for utilities.(NBT value is now applicable for Electricity)...16Dec2015
                                                ////oInvoice.MandatoryTaxAmount = 0;

                                                oInvoice.TotalWithMandatoryTax = Convert.ToDecimal(txtGrandTotal.Text);
                                                oInvoice.MandatoryTaxAmount = mandatoryTax.MandatoryTaxAmount;
                                            }
                                        }
                                        else // non tax customer
                                        {
                                            if (isutilityTaxApplicable == true)
                                            {
                                                if (isMandatoryTaxApplicable == true)
                                                {
                                                    oInvoice.MandatoryTaxAmount = mandatoryTax.MandatoryTaxAmount;
                                                    oInvoice.TotalWithMandatoryTax = mandatoryTax.TotalWithMandatoryTax;
                                                    otherTaxList = cTaxCalculations.getOtherTax(mandatoryTax.TotalWithMandatoryTax);
                                                }
                                                else
                                                {
                                                    otherTaxList.Clear();
                                                    otherTaxList = cTaxCalculations.getOtherTax(oInvoice.RentPerMonth);
                                                    oInvoice.MandatoryTaxAmount = 0;
                                                    oInvoice.TotalWithMandatoryTax = oInvoice.TotalAmount;
                                                    decimal otherTaxTotal = otherTaxList.Sum(x => x.TaxAmount);
                                                    oInvoice.OtherTax = otherTaxTotal;
                                                }
                                            }
                                            else
                                            {
                                                ////oInvoice.TotalWithMandatoryTax = oInvoice.TotalAmount; ////Comment this for use grand total correcvtly for utilities.(NBT value is now applicable for Electricity)
                                                ////oInvoice.MandatoryTaxAmount = 0;

                                                oInvoice.TotalWithMandatoryTax = Convert.ToDecimal(txtGrandTotal.Text);
                                                oInvoice.MandatoryTaxAmount = mandatoryTax.MandatoryTaxAmount;
                                            }

                                        }

                                    }
                                    else
                                    {
                                        oInvoice.TotalWithMandatoryTax = oInvoice.TotalAmount;
                                        oInvoice.MandatoryTaxAmount = 0;
                                    }


                                    oInvoice.MandatoryTaxCode = mandatoryTax.MandatoryTaxCode;
                                    oInvoice.MandatoryTaxID = mandatoryTax.MandatoryTaxID;
                                    oInvoice.MandatoryTaxRateID = mandatoryTax.MandatoryTaxRateID;

                                    // total tax 
                                    decimal totalTax = 0;
                                    totalTax = invDetList.Sum(x => x.Amount);
                                    oInvoice.TotalRentPerMonth = totalTax + oInvoice.RentPerMonth;

                                // 

                            }
                            else
                            {
                                //tax ID
                                oInvoice.MandatoryTaxCode = mandatoryTax.MandatoryTaxCode;
                                oInvoice.MandatoryTaxID = mandatoryTax.MandatoryTaxID;
                                oInvoice.MandatoryTaxRateID = mandatoryTax.MandatoryTaxRateID;

                                oInvoice.TotalWithMandatoryTax = oInvoice.TotalAmount;
                                oInvoice.MandatoryTaxAmount = 0;
                                oInvoice.OtherTax = 0;
                                oInvoice.TotalRentPerMonth = oInvoice.RentPerMonth;

                            }

                            //Updating SAP fields 
                            oInvoice.SAP_Assignment = lookUtilityID.Text.ToString().ToUpper();
                            //string sapText = "";
                            if (optSubInvType.SelectedIndex != 0)
                            {
                                oInvoice.SAP_Text = lookUtilityID.Text.ToString().ToUpper() + "_" + oInvoice.ShopNo.ToString().Trim() + "_" + MMS.CustomClasses.cCommon_Functions.getMonthAbbrName(dtMonthYear.DateTime.Month) + "_" + dtMonthYear.DateTime.Year.ToString();

                            }
                            else
                            {
                                oInvoice.SAP_Text = lookUtilityID.Text.ToString().ToUpper() + "_" + oInvoice.ShopNo.ToString().Trim() + "_" + MMS.CustomClasses.cCommon_Functions.getMonthAbbrName(dtMonthYear.DateTime.Month) + "_" + dtMonthYear.DateTime.Year.ToString();
                            }
                            oInvoice.SAP_RefKey1 = oInvoice.ShopNo;
                            oInvoice.SAP_RefKey2 = oInvoice.ShopName;
                            oInvoice.SAP_RefKey3 = "FIXED";
                            var qryInvPrefix = (from up in context.Utilities
                                                where up.UtilityID == utilityid
                                                select new { up.InvoicePrefix }).FirstOrDefault();

                            oInvoice.SAP_DocHeaderText = qryInvPrefix.InvoicePrefix + oInvoice.ShopNo + dtMonthYear.DateTime.Month.ToString() + dtMonthYear.DateTime.Year.ToString();
                            var qryDT = (from dt in context.SAP_DocTypes
                                         where dt.CompanyID == oInvoice.CompanyID && dt.InvoiceTypeID == 2 && dt.DocID == utilityid
                                         select dt).FirstOrDefault();
                            if (qryDT != null)
                            {
                                oInvoice.SAP_DocType = qryDT.DOCTYPE;
                            }
                            //--
                            oInvoice.TaxRegNo = MMS.CustomClasses.cCommon_Functions.getTaxRegNo(extendedCustId, istaxAppllicable, isutilityTaxApplicable);

                            //Credit note values 
                            if (oInvoice.SubInvTypeID == 2)
                            {
                                if (oInvoice.TotalAmount > 0)
                                {
                                    oInvoice.TotalAmount = oInvoice.TotalAmount * -1;
                                }
                                if (oInvoice.RentPerMonth > 0)
                                {
                                    oInvoice.RentPerMonth = oInvoice.RentPerMonth * -1;
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
                                if (oInvoice.OtherTax > 0)
                                {
                                    oInvoice.OtherTax = oInvoice.OtherTax * -1;
                                }
                                if (oInvoice.TotalRentPerMonth > 0)
                                {
                                    oInvoice.TotalRentPerMonth = oInvoice.TotalRentPerMonth * -1;
                                }

                            }

                            //--



                            // Invoice detail
                            if (chkIsMaintenace.Checked == false)
                            {
                                foreach (var qry in invDetList)
                                {
                                    Invoice_Details oInvDet = new Invoice_Details();
                                    oInvDet.Amount = qry.Amount;
                                    if (oInvoice.SubInvTypeID == 2)
                                    {
                                        if (oInvDet.Amount > 0)
                                        {
                                            oInvDet.Amount = oInvDet.Amount * -1;
                                        }
                                    }
                                    oInvDet.TaxRateID = qry.TaxRateID;
                                    oInvDet.TaxRate = qry.TaxRate;
                                    oInvDet.TaxCode = qry.TaxCode;
                                    oInvDet.TaxID = qry.TaxID;
                                    oInvDet.IsPrint = qry.IsPrint;

                                    // Record creation time 
                                    oInvDet.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                                    oInvDet.CreatedDate = DateTime.Now;

                                    //--
                                    oInvoice.Invoice_Details.Add(oInvDet);
                                }
                            

                            // other tax codes 

                            oInvoice.OtherTaxCodes = MMS.CustomClasses.cCommon_Functions.getOtherTaxCodes();
                            }// -- 

                            // record creation time
                            oInvoice.CreatedBy = cCommon_Functions.LoggedUserID;
                            oInvoice.CreatedDate = DateTime.Now;
                            // --
                            context.Invoices.AddObject(oInvoice);
                        }
                        else  // editing values 
                        {
                            cGen_Rent_Invoice invoiceObject = (cGen_Rent_Invoice)this.cGen_Rent_InvoiceBindingSource.Current;
                            if (invoiceObject != null)
                            {
                                var qryInvoice = (from i in context.Invoices
                                                  where i.InvoiceID == invoiceObject.InvoiceID
                                                  select i).FirstOrDefault();
                                if (qryInvoice != null)
                                {
                                    qryInvoice.InvoiceDate = dtInvoiceDate.DateTime.Date;
                                    qryInvoice.ProcessYear = dtMonthYear.DateTime.Year;
                                    qryInvoice.ProcessMonth = dtMonthYear.DateTime.Month;
                                    qryInvoice.DateFrom = dtFrom.DateTime;
                                    qryInvoice.DateTo = dtTo.DateTime;
                                    qryInvoice.TotalAmount = decimal.Parse(this.txtTotalCharge.EditValue.ToString());
                                    qryInvoice.RentPerMonth = qryInvoice.TotalAmount;
                                    qryInvoice.RentWithSCPerMonth = qryInvoice.TotalAmount;
                                    //qryInvoice.InvoiceTypeID = 2;
                                    //oInvoice.UtilityID = utilityid;
                                    qryInvoice.FooterText1 = this.txtInvoiceFooter.Text.ToString();
                                    //oInvoice.UtilityName = LookUpEditUtilityID.Text.ToString().Trim();
                                    //oInvoice.SubInvTypeID = subinvtypeid;
                                    //qryInvoice.IsProcessed = true;
                                    //oInvoice.IsConfirmed = false;
                                    qryInvoice.ShopNo = this.lookShop.Text.ToString(); // shop no 
                                    qryInvoice.ContractClosureID = contclauseid; // Contract Clause ID
                                    qryInvoice.ShopName = this.lookUpEditShopName.Text.ToString();
                                    qryInvoice.CompanyID = cCommon_Functions.getCompanyID(contclauseid);
                                    qryInvoice.LocationID = cCommon_Functions.getLocationID(contclauseid);
                                    qryInvoice.LevelID = cCommon_Functions.getLevelID(contclauseid);
                                    qryInvoice.ShopID = cCommon_Functions.getShopID(contclauseid);
                                    qryInvoice.CustomerAddress = cCommon_Functions.getCustomerAddress(contclauseid);
                                    qryInvoice.CustomerAddress2 = qryInvoice.CustomerAddress;
                                    qryInvoice.ShopUtilityReadingID = int.Parse(lookMeter.EditValue.ToString());
                                    if (this.lookUtilityID.Text.ToString() != "DIESEL") {
                                        qryInvoice.UtilityMeterName = context.Shops_UtilityReadings.Where(x => x.ShopUtilityReadingID == qryInvoice.ShopUtilityReadingID).FirstOrDefault().MeterName;
                                    }
                                    qryInvoice.UtilityMeterName = "N/A";
                                    qryInvoice.StartReading = start1;
                                    //qryInvoice.EndReading = end1;
                                    qryInvoice.EndReading = Convert.ToDecimal(123456.1234m);
                                    qryInvoice.Reset = chkReset.Checked;
                                    qryInvoice.StartReading2 = start2;
                                    qryInvoice.EndReading2 = end2;
                                    qryInvoice.IsMaintenance = this.chkIsMaintenace.Checked;
                                    qryInvoice.CustomerID = context.Extended_Customers.Where(x => x.ExtendedCustomerID == extendedCustId).FirstOrDefault().CustomerID;
                                    qryInvoice.ExtendedCustomerID = extendedCustId;
                                    qryInvoice.UtilityUnitRate = unitrate;
                                    qryInvoice.NosUnitsConsumed1 = end1 - start1;
                                    qryInvoice.NosUnitsConsumed2 = end2 - start2;
                                    qryInvoice.M_NosUnitsConsumed = mend - mstart;
                                    qryInvoice.TotalNosUnitConsumed = totalunits;
                                    //qryInvoice.Ratio = ratio;

                                    //Ratio 
                                    var qryRatio = (from s in context.Shops_UtilityReadings
                                                    join r in context.Ratios on s.RatioID equals r.RatioID
                                                    where s.ShopUtilityReadingID == qryInvoice.ShopUtilityReadingID
                                                    select new { r.RatioNo }).FirstOrDefault();
                                    if (qryRatio != null)
                                    {
                                        if (qryRatio.RatioNo.HasValue)
                                        {
                                            qryInvoice.Ratio = qryRatio.RatioNo.Value;
                                        }
                                    }
                                    //--

                                    var qryCust = (from ec in context.Extended_Customers
                                                   join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                                   where ec.ExtendedCustomerID == extendedCustId
                                                   select new { gc.CustomerName, gc.IsTaxCustomer }).FirstOrDefault();
                                    qryInvoice.CustomerName = qryCust.CustomerName;
                                    qryInvoice.MandatoryTaxCode = "";
                                    qryInvoice.ModifiedDate = DateTime.Now;


                                    //tax calculations
                                    
                                        bool istaxAppllicable = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicableByExtendedCustomerId(extendedCustId);
                                        bool isutilityTaxApplicable = MMS.CustomClasses.cCommon_Functions.IsOtherTaxApplicableForUtility(shoputirateid);
                                        bool isMandatoryTaxApplicable = MMS.CustomClasses.cCommon_Functions.IsMandatoryTaxApplicableForUtility(shoputirateid);
                                        cMandatoryTax mandatoryTax = cTaxCalculations.getAmountWithMandatoryTax(qryInvoice.TotalAmount);
                                        List<cOtherTax> otherTaxList = new List<cOtherTax>();


                                        if (chkIsMaintenace.Checked == false)
                                        {
                                            if (istaxAppllicable == true)
                                            {
                                                if (isMandatoryTaxApplicable == true)
                                                {
                                                    qryInvoice.MandatoryTaxAmount = mandatoryTax.MandatoryTaxAmount;
                                                    qryInvoice.TotalWithMandatoryTax = mandatoryTax.TotalWithMandatoryTax;
                                                    otherTaxList = cTaxCalculations.getOtherTax(mandatoryTax.TotalWithMandatoryTax);
                                                }
                                                else
                                                {
                                                    otherTaxList.Clear();
                                                    otherTaxList = cTaxCalculations.getOtherTax(qryInvoice.TotalAmount);
                                                    qryInvoice.MandatoryTaxAmount = 0;
                                                    qryInvoice.TotalWithMandatoryTax = qryInvoice.TotalAmount;
                                                }
                                            }
                                            else
                                            {
                                                qryInvoice.TotalWithMandatoryTax = qryInvoice.TotalAmount;
                                                qryInvoice.MandatoryTaxAmount = 0;
                                            }

                                            qryInvoice.MandatoryTaxCode = mandatoryTax.MandatoryTaxCode;
                                            qryInvoice.MandatoryTaxID = mandatoryTax.MandatoryTaxID;
                                            qryInvoice.MandatoryTaxRateID = mandatoryTax.MandatoryTaxRateID;

                                    }
                                    else 
                                    {
                                        qryInvoice.OtherTax = 0;
                                        qryInvoice.MandatoryTaxAmount = 0;
                                        qryInvoice.TotalWithMandatoryTax = qryInvoice.TotalAmount;

                                        qryInvoice.MandatoryTaxCode = mandatoryTax.MandatoryTaxCode;
                                        qryInvoice.MandatoryTaxID = mandatoryTax.MandatoryTaxID;
                                        qryInvoice.MandatoryTaxRateID = mandatoryTax.MandatoryTaxRateID;
 
                                    }

                                    //Credit Note values 
                                    if (qryInvoice.SubInvTypeID == 2)
                                    {
                                        if (qryInvoice.TotalAmount > 0)
                                        {
                                            qryInvoice.TotalAmount = qryInvoice.TotalAmount * -1;
                                        }
                                        if (qryInvoice.RentPerMonth > 0)
                                        {
                                            qryInvoice.RentPerMonth = qryInvoice.RentPerMonth * -1;
                                        }
                                        if (qryInvoice.RentWithSCPerMonth > 0)
                                        {
                                            qryInvoice.RentWithSCPerMonth = qryInvoice.RentWithSCPerMonth * -1;
                                        }
                                        if (qryInvoice.MandatoryTaxAmount > 0)
                                        {
                                            qryInvoice.MandatoryTaxAmount = qryInvoice.MandatoryTaxAmount * -1;
                                        }
                                        if (qryInvoice.TotalWithMandatoryTax > 0)
                                        {
                                            qryInvoice.TotalWithMandatoryTax = qryInvoice.TotalWithMandatoryTax * -1;
                                        }
                                        if (qryInvoice.OtherTax > 0)
                                        {
                                            qryInvoice.OtherTax = qryInvoice.OtherTax * -1;
                                        }
                                        if (qryInvoice.TotalRentPerMonth > 0)
                                        {
                                            qryInvoice.TotalRentPerMonth = qryInvoice.TotalRentPerMonth * -1;
                                        }

                                    }

                                    if(chkIsMaintenace.Checked==false)
                                    {                                    
                                        foreach (var qry in invDetList)
                                        {
                                            var qryInvDet = (from i in context.Invoice_Details
                                                             where i.InvoiceDetailID == qry.InvoiceDetailID
                                                             select i).FirstOrDefault();
                                            if (qryInvDet != null)
                                            {
                                                qryInvDet.TaxCode = qry.TaxCode;
                                                qryInvDet.TaxID = qry.TaxID;
                                                qryInvDet.TaxRate = qry.TaxRate;
                                                qryInvDet.Amount = qry.Amount;
                                                if (qryInvoice.SubInvTypeID == 2)
                                                {
                                                    if (qryInvDet.Amount > 0)
                                                    {
                                                        qryInvDet.Amount = qryInvDet.Amount * -1;
                                                    }
                                                }

                                                qryInvDet.IsPrint = qry.IsPrint;

                                                // Record modification time 
                                                qryInvDet.LastUpdated = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                                                qryInvDet.LastUpdateDate = DateTime.Now;
                                                //--                                      
                                            }
                                        }
                                    }

                                }
                            }

                        }  // end editing

                        
                        int succ = context.SaveChanges();

                        if (succ > 0)
                        {
                            MessageBox.Show("Record Saved succcessfully", "Save Success- Utility Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.UtilityInvoiceProcessed;
                            MMS.CustomClasses.cCommon_Functions.AddToEmailList(int.Parse(lookCompany.EditValue.ToString()), int.Parse(this.lookLocation.EditValue.ToString()), alert, "Customer : " + lookCustomer.Text.ToString() + System.Environment.NewLine + "Shop Name : " + this.lookUpEditShopName.Text.ToString() + System.Environment.NewLine + "Shop No : " + this.lookShop.Text.ToString() + System.Environment.NewLine + "Meter Name : " + lookMeter.Text.ToString(), MMS.CustomClasses.cCommon_Functions.LoggedUserID);


                        }
                        trs.Complete(); // completing tranasction
                    }

                    load_data();

                    addNew = false;
                    edit = false;
                    //this.ClearText();
                    //this.enable_control(false, eRecStatus.eSave);

                    cEnable_Controls.ClearText(this);//05052014...to clear form controls
                    btnNew_ItemClick(null, null);

                    btnNew.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                MessageBox.Show(line.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                cEnable_Controls.ClearText(this);//05052014...to clear form controls
                ////this.ClearText();
                lblInvoiceNo.Text = "<New>";
                dtInvoiceDate.DateTime = DateTime.Now.Date;
                ////this.enable_control(true, eRecStatus.eAddNew);
                dtMonthYear.DateTime = DateTime.Now.Date;
                dtFrom.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtTo.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                ////this.lookShop.Properties.ReadOnly = true;
                this.txtTotal1.Properties.ReadOnly = true;
                this.txtInvoiceFooter.EditValue = "Please Settle this invoice on or before ";
                ////this.txtMaintenanceTotal.Properties.ReadOnly = true;
                this.txtTotalReset.Properties.ReadOnly = true;
                this.lookUtilityID.Properties.ReadOnly = false;
                this.lookCompany.Properties.ReadOnly = false;
                this.lookShop.Properties.ReadOnly = false;
                this.lookUpEditShopName.Properties.ReadOnly = false;

                addNew = true;
                edit = false;

                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;


                this.chkcboInvoiceNo.Properties.DataSource = null;
                chkcboInvoiceNo.Enabled = false;
                dateEditFrom.Enabled = false;
                dateEditTo.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ClearText();
            //this.enable_control(false, eRecStatus.eInit);
            addNew = false;
            edit = false;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_data();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                //this.enable_control(true, eRecStatus.eEdit);
                edit = true;
                addNew = false;
                this.txtTotal1.Properties.ReadOnly = true;
                //this.txtMaintenanceTotal.Properties.ReadOnly = true;
                this.txtTotalReset.Properties.ReadOnly = true;

                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;

                chkcboInvoiceNo.Enabled = true;
                dateEditFrom.Enabled = true;
                dateEditTo.Enabled = true;
                this.chkcboInvoiceNo.Properties.DataSource = null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateEditFrom_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
        }

       

        private void dateEditTo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
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
                          where (i.DateFrom >= dateFrom && i.DateTo <= dateTo) && i.InvoiceTypeID == 2  && i.IsConfirmed == true //&& i.ContractClosureID == contclauseid
                          select new { i.InvoiceNo, i.InvoiceID,i.SubInvTypeID }).ToList();
            this.chkcboInvoiceNo.Properties.DataSource = qryInv;
            this.chkcboInvoiceNo.Properties.DisplayMember = "InvoiceNo";
            this.chkcboInvoiceNo.Properties.ValueMember = "InvoiceID";




        }

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

        private void chkcboInvoiceNo_EditValueChanged(object sender, EventArgs e)
        {
            
            //string selected = this.chkcboInvoiceNo.Properties.GetCheckedItems().ToString();
            //string theString = selected;
            //if (string.IsNullOrEmpty(theString.ToString())) { return; }

            //List<int> ints = theString.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));

            //var reslt = (from i in context.Invoices
            //             where ints.Contains(i.InvoiceID)
            //             select new { i.ShopNo, i.ContractClosureID,i.ContractID,i.UtilityID,i.SubInvTypeID,i.ShopUtilityReadingID}).FirstOrDefault();

            ////set invoice type
            //int SubInType = reslt.SubInvTypeID;

            //if (SubInType == 1)
            //    optSubInvType.SelectedIndex = 0;
            //if (SubInType == 2)
            //    optSubInvType.SelectedIndex = 1;
            //if (SubInType == 3)
            //    optSubInvType.SelectedIndex = 2;

            
            //this.lookUpEditShopName.EditValue = reslt.ContractClosureID;
            //this.lookUtilityID.EditValue = reslt.UtilityID;
            //this.lookMeter.EditValue = reslt.ShopUtilityReadingID;


        }
        //revert CheckIsProcessed() according to the request on 1-07-2019
        private void CheckIsProcessed()
        {
            try
            {
                if (addNew == true)
                {
                    if (string.IsNullOrEmpty(this.lookUtilityID.Text.ToString()))
                    {
                        dxErrorProvider1.SetError(this.lookUtilityID, "Invalid Utility Type");
                        return;
                    }
                    else { dxErrorProvider1.SetError(this.lookUtilityID, ""); }

                    if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                    {
                        dxErrorProvider1.SetError(this.lookCompany, "Invalid company");
                        return;
                    }
                    else { dxErrorProvider1.SetError(this.lookCompany, ""); }

                    if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
                    {
                        dxErrorProvider1.SetError(this.lookLocation, "Invalid Location");
                        return;
                    }
                    else { dxErrorProvider1.SetError(this.lookLocation, ""); }

                    if (string.IsNullOrEmpty(this.lookMeter.Text.ToString()) && this.lookUtilityID.Text.ToString() != "DIESEL")
                    {
                        dxErrorProvider1.SetError(this.lookMeter, "Invalid Meter Name");
                        return;
                    }
                    else { dxErrorProvider1.SetError(this.lookMeter, ""); }


                    int month = dtMonthYear.DateTime.Month;
                    int year = dtMonthYear.DateTime.Year;
                    int invtypeId = int.Parse(lookUtilityID.EditValue.ToString());
                    int compid = int.Parse(lookCompany.EditValue.ToString());
                    int locid = int.Parse(lookLocation.EditValue.ToString());
                    string meternm = lookMeter.Text.Trim();

                    var qryInvProcessed = (from i in context.Invoices
                                           where i.IsProcessed == true && i.ProcessMonth == month && i.ProcessYear == year && i.UtilityID == invtypeId &&
                                                  i.CompanyID == compid && i.LocationID == locid && i.UtilityMeterName == meternm
                                           select new { i.UtilityMeterName, i.IsProcessed }).FirstOrDefault();

                    if (qryInvProcessed != null)//|| qryInvProcessed.IsProcessed==true
                    {
                        MessageBox.Show("Invoice Allready Processed for, Shop Name : " + lookUpEditShopName.Text + "\n" + "Meter Name:" + meternm);
                        //btnSave.Enabled = false;
                        //btnNew.Enabled = true;
                        //btnEdit.Enabled = true;

                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }

        
        }

        private void cGen_Rent_InvoiceGridControl_Click(object sender, EventArgs e)
        {

        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }
       

     

      
    }
}