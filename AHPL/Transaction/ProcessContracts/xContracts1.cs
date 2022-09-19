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
using DataTier;
using DataTier.Reports;
using DevExpress.XtraEditors;
namespace MMS
{
    public partial class xContracts1 : DevExpress.XtraEditors.XtraForm
    {
        //AHPL_DBEntities context = new AHPL_DBEntities();
        List<Contract> contractList = new List<Contract>();
        List<Contract_Rates> contrateList = new List<Contract_Rates>();
        //List<Contract_TaxRates> conttaxrateList = new List<Contract_TaxRates>();
        List<Contract_Shops> contShopList = new List<Contract_Shops>();
        List<cContracts> cContractList = new List<cContracts>();
        List<cContractRate> cContractRateList = new List<cContractRate>();
        List<cContract_Baskets> cContractBasketList = new List<cContract_Baskets>();

        //public bool AddNew = false;
        //public bool Edit = false;
        int ContractID = 0;
        public xContracts1()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);
                ////cEnable_Controls.enable_control(this, true);

                cContractRateList.Clear();

                //conttaxrateList.Clear();
                contShopList.Clear();
                //contract_ShopsGridControl.RefreshDataSource();
                //contract_TaxRatesGridControl.RefreshDataSource();
                cContractRateGridControl.RefreshDataSource();
                cContractsGridControl.RefreshDataSource();
                //contract_TaxRatesBindingSource.Clear();
                //contract_ShopsBindingSource.Clear();
                //contract_RatesBindingSource.Clear();

                //contrateList.Clear();

                cEnable_Controls.ClearText(this);
                //AddNew = true;
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void contract_ShopsGridControl_Click(object sender, EventArgs e)
        {

        }

        private void dockPanel2_Click(object sender, EventArgs e)
        {

        }

        private void xContracts1_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {
            try
            {
                if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); }

                ////cEnable_Controls.enable_control(this, false);

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    using (TransactionScope trs = new TransactionScope())
                    {
                        //loading company
                        var qrycomp = (from c in context.Companies
                                       select new { c.CompanyID, c.CompanyCode }).ToList();
                        this.companyIDLookUpEdit.Properties.DataSource = qrycomp;
                        this.companyIDLookUpEdit.Properties.DisplayMember = "CompanyCode";
                        this.companyIDLookUpEdit.Properties.ValueMember = "CompanyID";

                        //loading extending customer
                        var qrycust = (from cust in context.Extended_Customers
                                       join gcust in context.Global_Customers on cust.CustomerID equals gcust.CustomerID
                                       select new { gcust.CustomerID, gcust.CustomerName, cust.ExtendedCustomerID }).ToList();
                        this.customerIDLookUpEdit.Properties.DataSource = qrycust;
                        this.customerIDLookUpEdit.Properties.DisplayMember = "CustomerName";
                        this.customerIDLookUpEdit.Properties.ValueMember = "ExtendedCustomerID";

                        // loading location
                        var qryloc = (from l in context.Locations
                                      select new { l.LocationID, l.LocationCode }).ToList();
                        this.locationIDLookUpEdit.Properties.DataSource = qryloc;
                        this.locationIDLookUpEdit.Properties.DisplayMember = "LocationCode";
                        this.locationIDLookUpEdit.Properties.ValueMember = "LocationID";

                        //loading levels
                        var qrylevels = (from l in context.Floor_Levels
                                         select new { l.LevelID, l.LevelName }).ToList();
                        this.levelIDLookUpEdit.Properties.DataSource = qrylevels;
                        this.levelIDLookUpEdit.Properties.DisplayMember = "LevelName";
                        this.levelIDLookUpEdit.Properties.ValueMember = "LevelID";



                        //loading shops
                        var qryshops = (from s in context.Shops
                                        select new { s.ShopID, s.ShopNo }).ToList();
                        this.lookUpEditShopID.Properties.DataSource = qryshops;
                        this.lookUpEditShopID.Properties.DisplayMember = "ShopNo";
                        this.lookUpEditShopID.Properties.ValueMember = "ShopID";


                        //loading contract list 
                        load_Contracts();

                        // loading contract closure 
                        var qryCClosure = (from c in context.ContractClosures
                                           where c.IsReleasedToAccounts == true && c.IsProcessed == false && c.IsCancelled == false && c.IsPromotion == false && c.IsTerminated == false && c.IsActive == true
                                           select new { c.IsProcessed, c.ContractClosureID, c.ContractClosureName, c.ExtendedCustomerID, c.ShopName, c.ShopID }).ToList();

                        cContractBasketList.Clear();
                        foreach (var qry in qryCClosure)
                        {
                            cContract_Baskets oCBasket = new cContract_Baskets();
                            oCBasket.ContractClosureID = qry.ContractClosureID;
                            oCBasket.ContractClosureName = qry.ContractClosureName;
                            oCBasket.IsProcessed = qry.IsProcessed;
                            oCBasket.ShopName = qry.ShopName;
                            cContractBasketList.Add(oCBasket);
                        }

                        this.cContract_BasketsBindingSource.DataSource = qryCClosure;
                        this.cContract_BasketsGridControl.RefreshDataSource();
                        trs.Complete();
                    }

                    // 
                }

                ////cEnable_Controls.enable_control(this, false);
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                //cEnable_Controls.ClearText(this);   
            }
            catch (Exception ex)
            {
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load_Contracts()
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                //context.Refresh(RefreshMode.StoreWins, context.Shops);
                cContractList.Clear();
                var qryContList = (from c in context.ContractClosures
                                   join s in context.Shops on c.ShopID equals s.ShopID
                                   join com in context.Companies on c.CompanyID equals com.CompanyID
                                   join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
                                   join l in context.Locations on c.LocationID equals l.LocationID
                                   join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                   join gcust in context.Global_Customers on exc.CustomerID equals gcust.CustomerID
                                   where c.IsTerminated == false && c.IsCancelled == false && c.IsProcessed == true && c.IsActive == true
                                   select new { c.ExtendedCustomerID, c.ShopNo, c.AgreementNo, c.AgreementSignDate, c.Deposit, c.ContractClosureID, c.ShopID, c.ContractID, c.ShopName, l.LocationCode, l.LocationID, gcust.CustomerName, com.CompanyCode, com.CompanyID, lvl.LevelName }).ToList();

                foreach (var qry in qryContList)
                {

                    cContracts oCont = new cContracts();
                    oCont.ContractClauseID = qry.ContractClosureID;
                    oCont.LocationID = qry.LocationID;
                    oCont.LocationCode = qry.LocationCode;
                    oCont.CompanyID = qry.CompanyID;
                    oCont.CompanyCode = qry.CompanyCode;
                    oCont.LevelName = qry.LevelName;
                    oCont.CustomerName = qry.CustomerName;
                    oCont.ExtendedCustomerID = qry.ExtendedCustomerID;
                    oCont.ShopID = qry.ShopID;
                    oCont.ShopName = qry.ShopName;
                    oCont.ShopNo = qry.ShopNo;
                    oCont.ContractID = qry.ContractID;
                    oCont.ShopName = qry.ShopName;
                    oCont.AgreementNo = qry.AgreementNo;
                    oCont.IsVacant = false;
                    if (qry.AgreementSignDate == DateTime.MinValue || qry.AgreementSignDate == null)
                    { oCont.AgreementSignDate = null; }
                    else { oCont.AgreementSignDate = qry.AgreementSignDate.Value; }

                    //getting active contract scheme rate

                    cRentScheme _rentscheme = cActiveRentScheme.getDefaultOrLastRateByDate(DateTime.Now.Date, qry.ContractClosureID);
                    if (_rentscheme != null)
                    {
                        oCont.StartDate = _rentscheme.FromDate;
                        oCont.EndDate = _rentscheme.ToDate;
                        oCont.Period = _rentscheme.Period;
                        //oCont.AgreementNo = _rentscheme..
                        oCont.FloorArea = _rentscheme.FloorArea;
                        oCont.RentPerSqFt = _rentscheme.RentPerSqFeet;
                        oCont.SCperSqFt = _rentscheme.SCperSqFeet;
                        oCont.RentWithSCperSqFt = _rentscheme.RentWithSCperSqft;
                        oCont.RentPerMonth = _rentscheme.RentPerMonth;
                        oCont.SCperMonth = _rentscheme.SCperMonth;
                        oCont.RentWithScPerMonth = _rentscheme.RentWithSCperMonth;
                        oCont.Contract_RentSchemeID = _rentscheme.Contract_RentSchemeID;
                    }

                    //--
                    cContractList.Add(oCont);
                }


                //// loading vacant shop list
                var qryVacantshop = (from s in context.Shops
                                     join l in context.Locations on s.LocationID equals l.LocationID
                                     join c in context.Companies on s.CompanyID equals c.CompanyID
                                     join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                                     where s.CustomerID == 0
                                     select new { s.ShopNo, s.ShopID, l.LocationCode, c.CompanyCode, lvl.LevelName }).ToList();

                foreach (var qry in qryVacantshop)
                {
                    cContracts oCont = new cContracts();
                    oCont.LocationCode = qry.LocationCode;
                    oCont.CompanyCode = qry.CompanyCode;
                    oCont.LevelName = qry.LevelName;
                    oCont.CustomerName = "VACANT";
                    oCont.ContractID = 0;
                    oCont.ShopID = qry.ShopID;
                    oCont.ShopName = qry.ShopNo + " - VACANT";
                    oCont.ShopNo = qry.ShopNo;
                    oCont.IsVacant = true;
                    cContractList.Add(oCont);
                }




                cContractList.OrderBy(x => x.CompanyCode);

                this.cContractsBindingSource.DataSource = cContractList;
                this.cContractsGridControl.RefreshDataSource();
                this.gridViewContracts.BestFitColumns();
                this.Refresh();
            }
        }


        private void companyIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

            ////06oct2014..to add filter option..roshan
            //// loading location

            AHPL_DBEntities context = new AHPL_DBEntities();

            ////validating company
            int companyid = 0;
            bool res = int.TryParse(this.companyIDLookUpEdit.EditValue.ToString(), out companyid);
            if (res.Equals(false))
            {
                return;
            }

            var qryloc = (from c in context.Companies
                          join l in context.Locations on c.LocationID equals l.LocationID
                          where c.CompanyID == companyid
                          select new { l.LocationID, l.LocationCode }).ToList();

            this.locationIDLookUpEdit.Properties.DataSource = qryloc;
            this.locationIDLookUpEdit.Properties.DisplayMember = "LocationCode";
            this.locationIDLookUpEdit.Properties.ValueMember = "LocationID";
        }

        private void levelIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                if (this.levelIDLookUpEdit.ItemIndex == 0 || this.levelIDLookUpEdit.ItemIndex > 0)
                {
                    int levelid = 0;
                    int locid = 0;
                    bool res = int.TryParse(this.levelIDLookUpEdit.EditValue.ToString(), out levelid);
                    if (res == false)
                    {
                        levelid = 0;
                    }
                    res = int.TryParse(this.locationIDLookUpEdit.EditValue.ToString(), out locid);

                    if (levelid > 0)
                    {

                        var qryshops = (from s in context.Shops
                                        where s.LevelID == levelid && s.LocationID == locid
                                        select s).ToList();

                        this.lookUpEditShopID.Properties.DataSource = qryshops;
                        this.lookUpEditShopID.Properties.DisplayMember = "ShopNo";
                        this.lookUpEditShopID.Properties.ValueMember = "ShopID";

                    }

                }
            }
        }

        private void customerIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            ////if (AddNew == false)
            ////{
            ////    return;
            ////}

            if (!string.IsNullOrEmpty(this.customerIDLookUpEdit.Text.ToString()))
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    int custid = 0;
                    bool res = int.TryParse(customerIDLookUpEdit.EditValue.ToString(), out custid);
                    if (res == false) { custid = 0; }
                    if (custid > 0)
                    {
                        var qryCust = (from exc in context.Extended_Customers
                                       where exc.ExtendedCustomerID == custid
                                       select new { exc.LocationID, exc.CompanyID }).FirstOrDefault();

                        if (qryCust != null)
                        {
                            this.companyIDLookUpEdit.EditValue = qryCust.CompanyID;
                            this.locationIDLookUpEdit.EditValue = qryCust.LocationID;

                            // getting defualt service charge
                            decimal scpersqft = getServiceCharge(qryCust.LocationID);

                            this.sCPerSqFtTextEdit.EditValue = scpersqft;


                            {
                                var qryLocFloor = (from f in context.Floor_Levels
                                                   where f.LocationID == qryCust.LocationID
                                                   select f).ToList();
                                this.levelIDLookUpEdit.Properties.DataSource = qryLocFloor;
                                this.levelIDLookUpEdit.Properties.DisplayMember = "LevelCode";
                                this.levelIDLookUpEdit.Properties.ValueMember = "LevelID";
                            }

                        }
                        else
                        {
                            this.companyIDLookUpEdit.EditValue = 0;
                            this.locationIDLookUpEdit.EditValue = 0;
                        }



                    }

                    //check weather tax is applicable from the RentTaxProfile table 
                    //var qryrenttax = (from rt in context.RentTax_Profiles
                    //                  join rtd in context.RentTaxProfile_Details on rt.RentTaxProfileID equals rtd.RentTaxProfileID
                    //                  join tx in context.Taxes on rtd.TaxID equals tx.TaxID
                    //                  join txr in context.TaxRates on tx.TaxID equals txr.TaxID
                    //                  where rt.IsActive == true && txr.IsActive == true
                    //                  select new { txr.TaxID, txr.TaxRateID, txr.TaxRate1 });
                    //conttaxrateList.Clear();
                    //foreach (var qry in qryrenttax) 
                    //{
                    //     Contract_TaxRates oContTaxRate = new Contract_TaxRates();
                    //     oContTaxRate.TaxID = qry.TaxID;
                    //     oContTaxRate.TaxRateID = qry.TaxRateID;
                    //     conttaxrateList.Add(oContTaxRate);
                    //}

                    //gridView1.RefreshData();

                }
            }
        }

        private decimal getServiceCharge(int locid)
        {
            decimal scpersqft = 0;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                var qry = (from l in context.Locations
                           where l.LocationID == locid
                           select new { l.SCperSqFt }).FirstOrDefault();

                if (qry != null)
                {

                    scpersqft = qry.SCperSqFt;
                }
                else
                {
                    scpersqft = 0;
                }


                //var qryservicecharge = (from sc in context.ServiceCharges
                //                        select sc).FirstOrDefault();
                //if (qryservicecharge != null)
                //{
                //    scpersqft = qryservicecharge.ServiceCharge1.Value;
                //};
            }
            return scpersqft;




        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int customerid = 0; int companyid = 0; int locationid = 0; int levelid = 0; int period = 0;
            decimal deposit = 0; decimal rentpersqft = 0; decimal scpersqft = 0; decimal rentwithscpersqft = 0;
            decimal rentpermonth = 0; decimal scpermonth = 0; decimal rentwithscpermonth = 0;
            //decimal totalrentpermonth = 0;

            //validating customer
            bool res = int.TryParse(this.customerIDLookUpEdit.EditValue.ToString(), out customerid);
            if (res == false) { customerid = 0; }
            if (customerid == 0)
            {
                dxErrorProvider1.SetError(customerIDLookUpEdit, "Invalid Customer");
                return;
            }
            else { dxErrorProvider1.SetError(customerIDLookUpEdit, ""); }

            // validating company
            res = int.TryParse(this.companyIDLookUpEdit.EditValue.ToString(), out companyid);
            if (res == false) { companyid = 0; }

            if (companyid == 0)
            {
                dxErrorProvider1.SetError(this.companyIDLookUpEdit, "Invalid Company");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.companyIDLookUpEdit, "");
            }


            // validating locaiton
            res = int.TryParse(this.locationIDLookUpEdit.EditValue.ToString(), out locationid);
            if (res == false) { locationid = 0; }

            if (locationid == 0)
            {
                dxErrorProvider1.SetError(this.locationIDLookUpEdit, "Invalid Locaiton");
                return;
            }
            else { dxErrorProvider1.SetError(this.locationIDLookUpEdit, ""); }


            // Floor level validating
            res = int.TryParse(this.levelIDLookUpEdit.EditValue.ToString(), out levelid);
            if (res == false) { levelid = 0; }
            if (levelid == 0)
            {
                dxErrorProvider1.SetError(this.levelIDLookUpEdit, "Invalid Floor Level");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.levelIDLookUpEdit, "");
            }

            //validating total area in square feet
            decimal totalarea = contShopList.Sum(x => x.AreaInSqFt);
            if (totalarea == 0)
            {
                dxErrorProvider1.SetError(rentPerSqFtTextEdit, "Area In Square Feet cannot be empty or 0");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(rentPerSqFtTextEdit, "");

            }

            if (string.IsNullOrEmpty(this.shopNameTextEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.shopNameTextEdit, "Invalid Shop Name");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.shopNameTextEdit, "");
            }

            if (string.IsNullOrEmpty(this.agreementSignDateDateEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.agreementSignDateDateEdit, "Invalid Date of Agreement Sign date");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.agreementSignDateDateEdit, "");
            }



            // deposit validating
            res = decimal.TryParse(this.depositTextEdit.EditValue.ToString(), out deposit);
            if (res == false) { deposit = 0; }
            if (deposit == 0)
            {
                dxErrorProvider1.SetError(this.depositTextEdit, "Invalid Deposit");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.depositTextEdit, "");
            }


            //validating Start date 

            if (string.IsNullOrEmpty(this.startDateDateEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.startDateDateEdit, "Invalid Start Date");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.startDateDateEdit, "");
            }


            //validating End date
            if (string.IsNullOrEmpty(this.endDateDateEdit.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.endDateDateEdit, "Invalid End Date");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.endDateDateEdit, "");
            }

            // Rent Per Square feet validating
            res = decimal.TryParse(this.rentPerSqFtTextEdit.EditValue.ToString(), out rentpersqft);
            if (res == false) { rentpersqft = 0; }
            if (rentpersqft == 0)
            {
                dxErrorProvider1.SetError(this.rentPerSqFtTextEdit, "Invalid Rent Per Square Feet");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.rentPerSqFtTextEdit, "");
            }

            //validating Service charge per square feet
            res = decimal.TryParse(this.sCPerSqFtTextEdit.EditValue.ToString(), out scpersqft);
            if (res == false) { scpersqft = 0; }
            if (scpersqft == 0)
            {
                dxErrorProvider1.SetError(this.sCPerSqFtTextEdit, "Invalid Service Charge per Square Feet");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(this.sCPerSqFtTextEdit, "");
            }

            res = decimal.TryParse(this.rentWIthSCPerSqFtTextEdit.EditValue.ToString(), out rentwithscpersqft);
            if (res == false) { rentwithscpersqft = 0; }

            res = decimal.TryParse(this.rentPerMonthTextEdit.EditValue.ToString(), out rentpermonth);
            if (res == false) { rentpermonth = 0; }

            res = decimal.TryParse(this.sCPerMonthTextEdit.EditValue.ToString(), out scpermonth);
            if (res == false) { scpermonth = 0; }

            res = decimal.TryParse(this.rentWithSCPerMonthTextEdit.EditValue.ToString(), out rentwithscpermonth);
            if (res == false) { rentwithscpermonth = 0; }

            //res = decimal.TryParse(this.totalRentPerMonthTextEdit.EditValue.ToString(), out totalrentpermonth);
            //if (res == false) { totalrentpermonth = 0; }

            // validating period
            res = int.TryParse(this.periodTextEdit.EditValue.ToString(), out period);
            if (res == false) { period = 0; }

            if (period == 0)
            {
                dxErrorProvider1.SetError(this.periodTextEdit, "Invalid period");
            }
            else
            {
                dxErrorProvider1.SetError(this.periodTextEdit, "");
            }


            // saving 
            using (TransactionScope trs = new TransactionScope())
            {

                try
                {
                    using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {

                        Contract oCont = new Contract();
                        oCont.CompanyID = companyid;
                        oCont.CustomerID = customerid;
                        oCont.LocationID = locationid;
                        oCont.LevelID = levelid;
                        oCont.ShopName = shopNameTextEdit.EditValue.ToString();
                        oCont.AgreementNo = agreementNoTextEdit.EditValue.ToString();
                        oCont.AgreementSignDate = agreementSignDateDateEdit.DateTime;
                        oCont.Deposit = deposit;
                        //oCont.TotalRentPerMonth = totalrentpermonth;

                        // contract rate 
                        Contract_Rates oContRate = new Contract_Rates();
                        oContRate.ActiveFrom = startDateDateEdit.DateTime;
                        oContRate.ActiveTo = endDateDateEdit.DateTime;
                        oContRate.AreaInSqFt = contShopList.Sum(x => x.AreaInSqFt);
                        oContRate.IsActive = true;
                        oContRate.RentPerMonth = rentpermonth;
                        oContRate.RentPerSqFt = rentpersqft;
                        oContRate.RentWithSCPerMonth = rentwithscpermonth;
                        oContRate.RentWIthSCPerSqFt = rentwithscpersqft;
                        oContRate.SCPerMonth = scpermonth;
                        oContRate.SCPerSqFt = scpersqft;
                        //oContRate.TotalRentPerMonth = totalrentpermonth;
                        oContRate.Period = period;
                        //oContRate.TotalTax = conttaxrateList.Sum(x => x.PerMonth);
                        oCont.Contract_Rates.Add(oContRate);


                        // contract shop 
                        foreach (var qry in contShopList)
                        {
                            Contract_Shops oContShop = new Contract_Shops();
                            oContShop.AreaInSqFt = qry.AreaInSqFt;
                            oContShop.ShopID = qry.ShopID;
                            oCont.Contract_Shops.Add(oContShop);
                            reserveShop(qry.ShopID, this.shopNameTextEdit.EditValue.ToString(), customerid); // reserving shop
                        }

                        // contract taxes 
                        //foreach (var qry in conttaxrateList)
                        //{
                        //    Contract_TaxRates oContTaxRate = new Contract_TaxRates();
                        //    oContTaxRate.TaxID = qry.TaxID;
                        //    oContTaxRate.TaxRateID = qry.TaxRateID;
                        //    oContTaxRate.PerMonth = qry.PerMonth;
                        //    oContTaxRate.PerSqFeet = qry.PerSqFeet;
                        //    oContRate.Contract_TaxRates.Add(oContTaxRate);
                        //}


                        context.Contracts.AddObject(oCont);


                        int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                        trs.Complete();


                        if (succ > 0)
                        {
                            MessageBox.Show("Record Saved Successfully", "Save Success - Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////Edit = false;
                            ////AddNew = false;
                        }
                    }

                }

                catch (Exception ex)
                {
                    if (ex.GetType() != typeof(UpdateException))
                    {
                        Console.WriteLine("An error occured. "
                            + "The operation cannot be retried."
                            + ex.Message);
                        //break;
                    }
                }

            }

            load_data();
            btnSave.Enabled = false;
            btnNew.Enabled = true;

        }

        private void reserveShop(int pShopID, string pShopName, int pCustomerID)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryshop = (from s in context.Shops
                               where s.ShopID == pShopID
                               select s).FirstOrDefault();
                if (qryshop != null)
                {
                    qryshop.ShopName = pShopName;
                    qryshop.CustomerID = pCustomerID;
                }
            }

        }

        private void locationIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            ////roshan..06oct2014
            AHPL_DBEntities context = new AHPL_DBEntities();

            ////validating company
            int locid = 0;
            bool res = int.TryParse(this.locationIDLookUpEdit.EditValue.ToString(), out locid);
            if (res.Equals(false))
            {
                return;
            }

            ////loading levels
            var qrylevels = (from l in context.Floor_Levels
                             where l.LocationID == locid
                             select new { l.LevelID, l.LevelName }).ToList();

            this.levelIDLookUpEdit.Properties.DataSource = qrylevels;
            this.levelIDLookUpEdit.Properties.DisplayMember = "LevelName";
            this.levelIDLookUpEdit.Properties.ValueMember = "LevelID";


        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column == colShopID)
            //{
            //    int shopid = 0;
            //    if (e.Value == null) { return; }
            //    var val = this.gridView2.GetRowCellValue(e.RowHandle, colShopID);

            //    bool res = int.TryParse(e.Value.ToString(), out shopid);
            //    if (res == false) { shopid = 0; }

            //    if (shopid > 0)
            //    {
            //        var qryshop = (from s in context.Shops
            //                       where s.ShopID == shopid
            //                       select new { s.SqFeet }).FirstOrDefault();
            //        if (qryshop != null)
            //        {
            //            this.gridView2.SetRowCellValue(e.RowHandle, colAreaInSqFt, qryshop.SqFeet);

            //        }
            //    }


            //}
        }

        private void rentPerSqFtTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (AddNew == false)
            //{
            //    return;
            //}


            //if (AddNew == true || Edit == true)
            //{

            //    decimal val = 0;
            //    bool res = decimal.TryParse(rentPerSqFtTextEdit.EditValue.ToString(), out val);
            //    if (res == false) { val = 0; }
            //    if (val > 0)
            //    {
            //        calculate();
            //    }
            //}




        }

        private void calculate()
        {
            //decimal rentpersqft = 0; decimal scpersqft = 0; decimal rentwithscpersqft = 0;
            //decimal rentpermonth = 0; decimal scpermonth = 0; decimal rentwithscpermonth = 0; 
            ////decimal totalrentpermonth = 0;

            //bool res = false;

            //res = decimal.TryParse(this.rentPerSqFtTextEdit.EditValue.ToString(), out rentpersqft);
            //if (res == false) { rentpersqft = 0; }

            //res = decimal.TryParse(this.sCPerSqFtTextEdit.EditValue.ToString(), out scpersqft);
            //if (res == false) { scpersqft = 0; }

            //res = decimal.TryParse(this.rentWIthSCPerSqFtTextEdit.EditValue.ToString(), out rentwithscpersqft);
            //if (res == false) { rentwithscpersqft = 0; }

            //res = decimal.TryParse(this.rentPerMonthTextEdit.EditValue.ToString(), out rentpermonth);
            //if (res == false) { rentpermonth = 0; }

            //res = decimal.TryParse(this.sCPerMonthTextEdit.EditValue.ToString(), out scpermonth);
            //if (res == false) { scpermonth = 0; }

            //res = decimal.TryParse(this.rentWithSCPerMonthTextEdit.EditValue.ToString(), out rentwithscpermonth);
            //if (res == false) { rentwithscpermonth = 0; }

            ////res = decimal.TryParse(this.totalRentPerMonthTextEdit.EditValue.ToString(), out totalrentpermonth);
            ////if (res == false) { totalrentpermonth = 0; }




            //decimal totalsqft = contShopList.Sum(x => x.AreaInSqFt);
            //rentpermonth = totalsqft * rentpersqft;
            //scpermonth = totalsqft * scpersqft;
            //rentwithscpersqft = rentpersqft + scpersqft;
            //rentwithscpermonth = rentpermonth + scpermonth;

            //this.rentPerMonthTextEdit.EditValue = rentpermonth;
            //this.sCPerMonthTextEdit.EditValue = scpermonth;
            //this.rentWithSCPerMonthTextEdit.EditValue = rentwithscpermonth;
            //this.rentWIthSCPerSqFtTextEdit.EditValue = rentwithscpersqft;

            //foreach (var qry in conttaxrateList)
            //{
            //    var qrytaxrate = (from tx in context.TaxRates
            //                       where tx.TaxRateID == qry.TaxRateID
            //                       select new { tx.TaxRate1 }).FirstOrDefault();

            //    if (qrytaxrate != null)
            //    {
            //        decimal taxrate = qrytaxrate.TaxRate1;
            //        decimal taxpermonth = (rentwithscpermonth * taxrate) / 100;
            //        qry.PerMonth = taxpermonth;
            //    }
            //}
            // updating grid 
            //contract_TaxRatesBindingSource.DataSource = conttaxrateList.ToList() ;
            //gridView1.RefreshData();
            //contract_TaxRatesGridControl.RefreshDataSource();


            //decimal totaltax = conttaxrateList.Sum(x => x.PerMonth);
            //this.txtTotalTax.EditValue = Math.Round(totaltax, 2);


            //totalrentpermonth = totaltax + rentwithscpermonth;

            //this.totalRentPerMonthTextEdit.EditValue = totalrentpermonth;

        }



        private void endDateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            getMonth();

        }

        private void getMonth()
        {
            DateTime fromdate;
            DateTime todate;
            bool res = DateTime.TryParse(startDateDateEdit.Text, out fromdate);
            if (res == false)
            {
                return;
            }

            res = DateTime.TryParse(endDateDateEdit.Text, out todate);
            if (res == false)
            {
                return;
            }

            DateTime dtFrom = startDateDateEdit.DateTime.Date;
            DateTime dtTo = endDateDateEdit.DateTime.Date;
            double dmonth = (dtTo.Subtract(dtFrom).Days / (365.25 / 12));

            double month = Math.Ceiling(dmonth);

            this.periodTextEdit.EditValue = month;


        }

        private void startDateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            getMonth();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show(ContractID.ToString());
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                if (splashScreenManager1.IsSplashFormVisible == false) splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormDescription("Print Preview of Contract");

                rptMain _main = new rptMain();
                rptContracts _cont = new rptContracts();
                _main.crystalReportViewer1.ReportSource = _cont;

                var qrycontract = (from c in context.Contracts
                                   where c.ContractID == ContractID
                                   select new { c.ContractID, c.CustomerID, c.CompanyID, c.Deposit, c.AgreementNo, c.LevelID, c.LocationID, c.ShopName, c.AgreementSignDate }).ToList();
                var qryContRate = (from cr in context.Contract_Rates
                                   where cr.ContractID == ContractID && cr.IsActive == true
                                   select new { cr.IsActive, cr.Period, cr.RentPerMonth, cr.RentPerSqFt, cr.RentWithSCPerMonth, cr.RentWIthSCPerSqFt, cr.SCPerMonth, cr.SCPerSqFt, cr.AreaInSqFt, cr.ContractID, cr.ContractRateID, cr.ActiveFrom, cr.ActiveTo }).ToList();

                var qryLoc = (from l in context.Locations
                              select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();

                var qryExC = (from exc in context.Extended_Customers
                              select new { exc.ExtendedCustomerID, exc.CustomerID }).ToList();

                var qryGcus = (from gcust in context.Global_Customers
                               select new { gcust.CustomerID, gcust.CustomerName, gcust.CompanyAddress }).ToList();

                var qrycontshop = (from contshop in context.Contract_Shops
                                   where contshop.ContractID == ContractID
                                   select new { contshop.ContractID, contshop.ShopID, contshop.ContractShopID }).ToList();

                //var qryconttaxrate = (from ctxrate in context.Contract_TaxRates
                //                      select new { ctxrate.ContractID, ctxrate.ContractRateID, ctxrate.PerMonth, ctxrate.PerSqFeet, ctxrate.TaxID, ctxrate.TaxRateID }).ToList();

                var qrycomp = (from c in context.Companies
                               select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();

                var qryshop = (from s in context.Shops
                               select new { s.ShopID, s.ShopNo }).ToList();
                var qryTax = (from t in context.Taxes
                              select new { t.TaxID, t.TaxCode, t.TaxName }).ToList();

                var qryTaxRate = (from tr in context.TaxRates
                                  select new { tr.TaxID, tr.TaxRateID, tr.TaxRate1 }).ToList();


                _cont.Database.Tables["DataTier_Contract"].SetDataSource(qrycontract);
                _cont.Database.Tables["DataTier_Contract_Rates"].SetDataSource(qryContRate);
                _cont.Database.Tables["DataTier_Extended_Customers"].SetDataSource(qryExC);
                _cont.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGcus);
                _cont.Database.Tables["DataTier_Location"].SetDataSource(qryLoc);
                //_cont.Database.Tables["DataTier_Contract_TaxRates"].SetDataSource(qryconttaxrate);
                _cont.Database.Tables["DataTier_Contract_Shops"].SetDataSource(qrycontshop);
                _cont.Database.Tables["DataTier_Company"].SetDataSource(qrycomp);
                _cont.Database.Tables["DataTier_Shop"].SetDataSource(qryshop);
                //_cont.Subreports[0].Database.Tables["DataTier_Contract_TaxRates"].SetDataSource(qryconttaxrate);
                _cont.Subreports[0].Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                _cont.Subreports[0].Database.Tables["DataTier_TaxRate"].SetDataSource(qryTaxRate);

                if (splashScreenManager1.IsSplashFormVisible == true) splashScreenManager1.CloseWaitForm();
                _main.Show(this);

            }
        }


        private void rentWIthSCPerSqFtTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);
                ////Edit = true;
                this.btnEdit.Enabled = false;
                this.btnSave.Enabled = true;
                this.btnNew.Enabled = false;

                ////cEnable_Controls.enable_control(this, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;

        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //    this.cContract_BasketsBindingSource.EndEdit();

            //    cContract_Baskets oBaseket = (cContract_Baskets)this.cContract_BasketsBindingSource.Current;

            //DataRow row = gridView5.GetFocusedDataRow();
            object row = gridView5.GetFocusedRowCellValue(colContractClosureID);
            int contclosureid = 0;
            if (row != null)
            {
                contclosureid = int.Parse(row.ToString());
            }

            if (row != null)
            {

                xContract_Confirm cconfirm = new xContract_Confirm();
                cconfirm.FormClosing += new FormClosingEventHandler(cconfirm_FormClosing);
                cconfirm.Show(this);
                cconfirm.load_data(contclosureid);
                //load_data();
                //load_Contracts();
                //this.cContractsBindingSource.DataSource = cContractList;
                //this.cContractsGridControl.RefreshDataSource();
            }

        }
        private void cconfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (splashScreenManager2.IsSplashFormVisible == false)
                { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Closing Form..."); }

                load_data();
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }

            }
            catch (Exception ex)
            {
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_data();
        }

        private void customerIDLookUpEdit_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void lookUpEditShopID_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void rentPerMonthTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void sCPerMonthTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void rentWithSCPerMonthTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}