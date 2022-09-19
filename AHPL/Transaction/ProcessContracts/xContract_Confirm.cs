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
using System.Transactions;

namespace MMS
{
    public partial class xContract_Confirm : DevExpress.XtraEditors.XtraForm
    {
        //AHPL_DBEntities context = new AHPL_DBEntities();
        List<Contract_RentSchemes> cContRentSchemeList = new List<Contract_RentSchemes>();
        public xContract_Confirm()
        {
            InitializeComponent();
        }

        private void xContract_Confirm_Load(object sender, EventArgs e)
        {
            load_data();
            infoLbl.Text = string.Empty;
        }

        private void load_data()
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                //contract closure 
                this.lookContractClasuseID.Properties.DataSource = (from c in context.ContractClosures
                                                                    where c.IsActive == true
                                                                   select new { c.ContractClosureID, c.ContractClosureName }).ToList();


                this.lookContractClasuseID.Properties.DisplayMember = "ContractClosureName";
                this.lookContractClasuseID.Properties.ValueMember = "ContractClosureID";
                //--

                //company 
                this.lookUpEditCompanyN.Properties.DataSource = this.lookCompany.Properties.DataSource = (from c in context.Companies
                                                                                                                select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();

                this.lookUpEditCompanyN.Properties.DisplayMember = this.lookCompany.Properties.DisplayMember = "CompanyCode";
                this.lookUpEditCompanyN.Properties.ValueMember = this.lookCompany.Properties.ValueMember = "CompanyID";
                //
                // Location
                this.lookUpEditLocationN.Properties.DataSource = this.lookLocation.Properties.DataSource = (from l in context.Locations
                                                                                                                  select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
                this.lookUpEditLocationN.Properties.DisplayMember = this.lookLocation.Properties.DisplayMember = "LocationCode";
                this.lookUpEditLocationN.Properties.ValueMember = this.lookLocation.Properties.ValueMember = "LocationID";
                //-

                //Level 
                this.lookUpEditLevelN.Properties.DataSource = this.lookUpEditLevel.Properties.DataSource = (from l in context.Floor_Levels
                                                                                                            select new { l.LevelID, l.LevelName }).ToList();
                this.lookUpEditLevelN.Properties.DisplayMember = this.lookUpEditLevel.Properties.DisplayMember = "LevelName";
                this.lookUpEditLevelN.Properties.ValueMember = this.lookUpEditLevel.Properties.ValueMember = "LevelID";
                // - 

                ////shops
                ////this.lookUpEditShopN.Properties.DataSource = (from s in context.Shops
                ////                                              select new { s.ShopID, s.ShopNo }).ToList();
                ////this.lookUpEditShopN.Properties.DisplayMember = "ShopNo";
                ////this.lookUpEditShopN.Properties.ValueMember = "ShopID";
                ////roshan..23Oct2015..comment above all shop loading issue / to add validation for shop number using company
                load_shops();
                //-
            }

            //Extened Customer 
            //this.gridLookUpEditCustomer.Properties = ( from ec in context.Extended_Customers 

            //// 

        }

        public void load_data(int pCClosureID)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                var qryCClosure = (from c in context.ContractClosures
                                   where c.ContractClosureID == pCClosureID
                                   select c).FirstOrDefault();
                if (qryCClosure != null)
                {

                    lookContractClasuseID.EditValue = qryCClosure.ContractClosureID;
                    this.lookUpEditCompanyN.EditValue = lookCompany.EditValue = qryCClosure.CompanyID;
                    this.lookUpEditLocationN.EditValue = lookLocation.EditValue = qryCClosure.LocationID;
                    this.lookUpEditLevelN.EditValue = lookUpEditLevel.EditValue = qryCClosure.LevelID;
                    //lookUpEditShopN.EditValue = qryCClosure.ShopID;

                    textEditFloorArea.EditValue = qryCClosure.FloorArea;
                    this.textEditShopNameN.EditValue = textEditShopName.EditValue = qryCClosure.ShopName;
                    this.textEditShopNo.EditValue = qryCClosure.ShopNo;
                    this.lookUpEditShopN.EditValue = qryCClosure.ShopID;
                    this.textEditContractPeriod.EditValue = qryCClosure.ContractPeriod;
                    //textEditRentPerSqFt.EditValue = qryCClosure.RentPerSqFt;
                    //textEditBaseRent.EditValue = qryCClosure.Rent;
                    //textEditSC.EditValue = qryCClosure.ServiceCharge;
                    this.textEditDepositN.EditValue = textEditDeposit.EditValue = qryCClosure.Deposit;
                    //dateEditStartDate.EditValue = qryCClosure.StartDate;
                    //dateEditEndDate.EditValue = qryCClosure.EndDate;
                    this.dateEditAgreementSignDateN.EditValue = dateEditAgreementSignDate.EditValue = qryCClosure.AgreementSignDate;
                    textEditAgreementNo.EditValue = qryCClosure.AgreementNo;
                    gridLookUpEditCustomer.EditValue = qryCClosure.ExtendedCustomerID;

                    this.textEditFloorAreaN.EditValue = qryCClosure.FloorArea;////16Nov2015..to asign edit floor area

                    load_shops();

                    ////To avoid asign contract for shop without terminate prev contract in that shop.
                    string shopNo = qryCClosure.ShopNo;
                    int companyId = qryCClosure.CompanyID;
                    List<ContractClosure> contracts = context.ContractClosures.Where(w => w.ShopNo == shopNo && w.CompanyID == companyId && w.IsTerminated.Equals(false)).ToList();
                    if (contracts.Count > 1) 
                    {
                        btnCreateContract.Enabled = false;
                        infoLbl.Text = "Another contract is asigned for this shop";
                        infoLbl.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lookCompany.EditValue = 0;
                    lookLocation.EditValue = 0;
                    lookUpEditLevel.EditValue = 0;
                    lookUpEditShopN.EditValue = 0;
                    textEditShopName.EditValue = 0;
                    //textEditRentPerSqFt.EditValue =0;
                    //textEditBaseRent.EditValue = 0;
                    //textEditSC.EditValue = 0;
                    textEditDeposit.EditValue = 0;
                    //dateEditStartDate.EditValue = null;
                    //dateEditEndDate.EditValue =null;
                    dateEditAgreementSignDate.EditValue = null;
                    textEditAgreementNo.EditValue = string.Empty;
                    gridLookUpEditCustomer.EditValue = 0;

                    this.textEditFloorAreaN.EditValue = 0;
                }


                //Loading contract rate schemes 
                cContRentSchemeList.Clear();

                var qryRentScheme = (from r in context.Contract_RentSchemes
                                     where r.ContractClosureID == pCClosureID
                                     select r).ToList();
                this.contract_RentSchemesBindingSource.DataSource = qryRentScheme;
                this.contract_RentSchemesGridControl.RefreshDataSource();
            }
        }

        private void lookUpEditLocation_EditValueChanged(object sender, EventArgs e)
        {
            

            load_extendedCustomer();


        }

        private void load_extendedCustomer()
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()))
                { return; }
                if (string.IsNullOrEmpty(this.lookLocation.Text.ToString()))
                { return; }

                bool res = false;
                int compid = 0; int locid = 0;
                res = int.TryParse(this.lookCompany.EditValue.ToString(), out compid);
                if (res == false) { compid = 0; }

                res = int.TryParse(this.lookLocation.EditValue.ToString(), out locid);
                if (res == false) { locid = 0; }

                var qryExC = (from exc in context.Extended_Customers
                              join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                              join com in context.Companies on exc.CompanyID equals com.CompanyID
                              join loc in context.Locations on exc.LocationID equals loc.LocationID
                              where exc.CompanyID == compid && exc.LocationID == locid
                              select new { exc.ExtendedCustomerID, gcus.CustomerName, loc.LocationCode, com.CompanyCode }).ToList();

                this.gridLookUpEditCustomer.Properties.DataSource = qryExC;
                this.gridLookUpEditCustomer.Properties.DisplayMember = "CustomerName";
                this.gridLookUpEditCustomer.Properties.ValueMember = "ExtendedCustomerID";
            }
        }

        private void btnCreateContract_Click(object sender, EventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);


            //validating fields 
              bool res = false;

            //validating contract closure id 
            if (string.IsNullOrEmpty(this.lookContractClasuseID.Text.ToString()))
            { dxErrorProvider1.SetError(lookContractClasuseID, "Invalid Contract Closure"); return; }
            else { dxErrorProvider1.SetError(this.lookContractClasuseID, ""); }

            int contclosureid = 0;
            res = int.TryParse(this.lookContractClasuseID.EditValue.ToString(),out contclosureid);
            if (res==false) {dxErrorProvider1.SetError(this.lookContractClasuseID,"Invalid Contract Closure"); return ;}

            //validating Customer 
            if (string.IsNullOrEmpty(this.gridLookUpEditCustomer.Text.ToString()))
            { dxErrorProvider1.SetError(gridLookUpEditCustomer, "Invalid Customer"); return; }
            else { dxErrorProvider1.SetError(gridLookUpEditCustomer, ""); }

            int extcustid = 0;
            int compid = 0; int locid = 0;
            int levelid = 0;
            decimal floorareaN = 0;
            decimal floorarea = 0;
            decimal deposit = 0;
            int shopid = 0;

            res = int.TryParse(this.lookUpEditCompanyN.EditValue.ToString(), out compid);
            if (res == false) { dxErrorProvider1.SetError(this.lookUpEditCompanyN, "Invalid Company"); return; }
            else { dxErrorProvider1.SetError(this.lookUpEditCompanyN, ""); }

            res = int.TryParse(this.lookUpEditLocationN.EditValue.ToString(), out locid);
            if (res == false) { dxErrorProvider1.SetError(this.lookUpEditLocationN, "Invalid Location"); return; }
            else { dxErrorProvider1.SetError(this.lookUpEditLocationN, ""); }

            res = int.TryParse(this.lookUpEditLevelN.EditValue.ToString(), out levelid);
            if (res == false) { dxErrorProvider1.SetError(this.lookUpEditLevelN, "Invalid Floor Level"); return; }
            else { dxErrorProvider1.SetError(this.lookUpEditLevelN, ""); }

            res = int.TryParse(this.lookUpEditShopN.EditValue.ToString(), out shopid);
            if (res == false) { dxErrorProvider1.SetError(this.lookUpEditShopN, "Invalid Shop"); return; }
            else { dxErrorProvider1.SetError(this.lookUpEditShopN, ""); }

            res = decimal.TryParse(this.textEditFloorAreaN.EditValue.ToString(), out floorareaN);
            if (res == false) { dxErrorProvider1.SetError(this.textEditFloorAreaN, "Invalid Floor Area"); return; }
            else { dxErrorProvider1.SetError(this.textEditFloorAreaN, ""); }

            res = decimal.TryParse(this.textEditFloorArea.EditValue.ToString(), out floorarea);
            if (res == false) { dxErrorProvider1.SetError(this.textEditFloorArea, "Invalid Floor Area"); return; }
            else { dxErrorProvider1.SetError(this.textEditFloorArea, ""); }

            if (dateEditAgreementSignDate.DateTime.Equals(null))////10July2014..to avoid null Agreement Sign Date
            {
                dxErrorProvider1.SetError(this.textEditFloorAreaN, "Invalid Agreement Sign Date");
                return;
            }

            if (dateEditAgreementSignDateN.DateTime.Equals(null))////10July2014..to avoid null Agreement Sign Date
            {
                dxErrorProvider1.SetError(this.textEditFloorAreaN, "Invalid Agreement Sign Date");
                return;
            }

            if(shopid == 0)
            {
                dxErrorProvider1.SetError(this.lookUpEditShopN, "Please Select Shop");
                return;    
            }
               
            // validating floor area with New value and agreement value
            if (floorarea != floorareaN)
            {
                dxErrorProvider1.SetError(this.textEditFloorAreaN, "Floor Area is Mismatched with agreement value");
                return;
            }
            else { dxErrorProvider1.SetError(this.textEditFloorAreaN, ""); }
            //--

            // 

            res = decimal.TryParse(this.textEditDepositN.EditValue.ToString(), out deposit);
            if (res == false) { dxErrorProvider1.SetError(this.textEditDepositN, "Invalid Value"); return; }
            else { dxErrorProvider1.SetError(this.textEditDepositN, ""); }
            
            res = int.TryParse(this.gridLookUpEditCustomer.EditValue.ToString(), out extcustid);
            if (res == false) { extcustid = 0; }
            if (extcustid ==0)             
                { dxErrorProvider1.SetError(gridLookUpEditCustomer, "Invalid Customer"); return; }
            else { dxErrorProvider1.SetError(gridLookUpEditCustomer, ""); }
         
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    using (TransactionScope trs = new TransactionScope())
                    {

                        var qryCustomerFound = (from c in context.ContractClosures
                                                join shop in context.Shops on c.ShopID equals shop.ShopID
                                                join comp in context.Companies on c.CompanyID equals comp.CompanyID
                                                join loc in context.Locations on c.LocationID equals loc.LocationID
                                                join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                                join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                                                where c.IsTerminated == false && c.IsProcessed ==true && shop.ShopID == shopid
                                                select new { gcus.CustomerID, gcus.CustomerName, loc.LocationCode, comp.CompanyCode, c.ShopName, shop.ShopNo }).FirstOrDefault();
                        if (qryCustomerFound == null)
                        {
                            // if not found creating new contracts

                            // updating contract closure 
                            var qryCClosure = (from c in context.ContractClosures
                                               where c.ContractClosureID == contclosureid
                                               select c).FirstOrDefault();
                            qryCClosure.CompanyID = compid;
                            qryCClosure.LocationID = locid;
                            qryCClosure.LevelID = levelid;
                            qryCClosure.ShopID = shopid;
                            qryCClosure.FloorArea = floorareaN;
                            qryCClosure.AgreementNo = this.textEditAgreementNoN.Text.ToString();
                            qryCClosure.AgreementSignDate = this.dateEditAgreementSignDateN.DateTime;
                            qryCClosure.Deposit = deposit;
                            qryCClosure.ShopName = this.textEditShopNameN.Text.ToString();
                            qryCClosure.ExtendedCustomerID = extcustid;
                            qryCClosure.IsProcessed = true;

                     
                            {

                                //creating Contract objects
                                DateTime dtAgrSignDate;
                                Contract oCont = new Contract();
                                oCont.AgreementNo = qryCClosure.AgreementNo;
                                res = DateTime.TryParse(qryCClosure.AgreementSignDate.ToString(), out dtAgrSignDate);
                                if (dtAgrSignDate != DateTime.MinValue)
                                {
                                    oCont.AgreementSignDate = qryCClosure.AgreementSignDate.Value;
                                    

                                }
                                
                                

                                oCont.CompanyID = qryCClosure.CompanyID;
                                oCont.CustomerID = qryCClosure.ExtendedCustomerID;
                                oCont.Deposit = qryCClosure.Deposit;
                                oCont.LocationID = qryCClosure.LocationID;
                                oCont.LevelID = qryCClosure.LevelID;
                                oCont.ShopName = qryCClosure.ShopName;
                                oCont.ShopID = qryCClosure.ShopID;
                                oCont.ContractClosureID = qryCClosure.ContractClosureID;
                                qryCClosure.ContractID = oCont.ContractID;
                                //adding contract's shop 
                                if (oCont.ShopID > 0)
                                {
                                    Contract_Shops oShop = new Contract_Shops();
                                    oShop.ShopID = qryCClosure.ShopID;
                                    oShop.AreaInSqFt = qryCClosure.FloorArea;
                                    bool reserved = cReserveShop.ReserveShop(oShop.ShopID, extcustid, oCont.ShopName);
                                    if (reserved == true)
                                    {
                                        dxErrorProvider1.SetError(this.lookUpEditShopN, "Shop Already reserved with another customer");
                                        return;
                                    }
                                    else { dxErrorProvider1.SetError(this.lookUpEditShopN, ""); }
                                    oCont.Contract_Shops.Add(oShop); // adding object's to contract's 
                                }
                                //--

                                //Adding object's to Contract Rates
                                //if (context.Connection.State == ConnectionState.Closed) { context.Connection.Open(); }
                                var qryRentScheme = (from rs in context.Contract_RentSchemes
                                                     where rs.ContractClosureID == qryCClosure.ContractClosureID
                                                     select rs).ToList();
                                foreach (var qry in qryRentScheme)
                                {
                                    Contract_Rates oContRate = new Contract_Rates();
                                    oContRate.ActiveFrom = qry.FromDate;
                                    oContRate.ActiveTo = qry.ToDate;
                                    oContRate.AreaInSqFt = qryCClosure.FloorArea;
                                    oContRate.Period = (int)qry.Period;
                                    oContRate.RentPerSqFt = qry.RentPerSqFeet;
                                    oContRate.SCPerSqFt = qry.SCPerSqFeet;
                                    oContRate.RentPerMonth = oContRate.RentPerSqFt * oContRate.AreaInSqFt;
                                    oContRate.SCPerMonth = oContRate.SCPerSqFt * oContRate.AreaInSqFt;
                                    oContRate.RentWithSCPerMonth = oContRate.RentPerMonth + oContRate.SCPerMonth;
                                    oContRate.RentWIthSCPerSqFt = oContRate.RentPerSqFt + oContRate.SCPerSqFt;
                                    oContRate.IsActive = cActiveRentScheme.IsActiveRentScheme(qry.ContractClosureID, DateTime.Now.Date, qry.FromDate, qry.ToDate);
                                    //oContRate.IsActive = IsContractActive(qry.FromDate,qry.ToDate,
                                    oCont.Contract_Rates.Add(oContRate);
                                }


                                //finally adding Contract Object to the context
                                context.AddToContracts(oCont);

                                //AHPL.CustomClasses.cCommon_Functions.EmailAlert("Contract Assigned", oCont.CompanyID, oCont.LocationID, oCont.ShopName, oCont.ContractClosureID, AHPL.CustomClasses.cCommon_Functions.LoggedSystemUserName,"Contract Assigned","","");

                                //saving context 
                                //if (context.Connection.State == ConnectionState.Closed) { context.Connection.Open(); }
                                int succ = context.SaveChanges();

                                int alert = (int) MMS.CustomClasses.cCommon_Functions.AlertItem.ContractAssigned;
                                MMS.CustomClasses.cCommon_Functions.AddToEmailList(int.Parse(lookCompany.EditValue.ToString()), int.Parse(this.lookLocation.EditValue.ToString()), alert, "Customer : " + gridLookUpEditCustomer.Text.ToString() + System.Environment.NewLine + "Shop Name : " + this.textEditShopNameN.Text.ToString() + System.Environment.NewLine + "Shop No : " + this.lookUpEditShopN.Text.ToString(), MMS.CustomClasses.cCommon_Functions.LoggedUserID);


                                trs.Complete();
                                //trs.Dispose();
                                if (succ > 0)
                                {
                                    MessageBox.Show("Record Saved Successfully..", "Save Success - Contract Confirmtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }



                            }


                        }
                        else
                        {   // if found the customer with existing values 

                            DialogResult dlg = MessageBox.Show("The Selected Customer's Contract Exist With Following Information " + System.Environment.NewLine + "Customer Name : " + qryCustomerFound.CustomerName + System.Environment.NewLine + "Company : " + qryCustomerFound.CompanyCode + System.Environment.NewLine + "Location : " + qryCustomerFound.LocationCode + System.Environment.NewLine + "Shop Name : " + qryCustomerFound.ShopName + System.Environment.NewLine + "Please Terminate the Contract 1st and Create New ...?", "Exist Contract", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                }
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //--
        }

        private void lookUpEditLevel_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditLocationN_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lookUpEditLocationN.Text.ToString()))
            {
                return;
            }

            bool res = false; int locid = 0;
            res = int.TryParse(this.lookUpEditLocationN.EditValue.ToString(), out locid);
            if (res == false) { locid = 0; }
            if (locid == 0) { return; }
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryLevel = (from l in context.Floor_Levels
                                where l.LocationID == locid
                                select new { l.LevelID, l.LevelCode, l.LevelName }).ToList();
                //this.floorLevelsBindingSource.DataSource = qryLevel;
                this.lookUpEditLevelN.Properties.DataSource = qryLevel;
                this.lookUpEditLevelN.Properties.DisplayMember = "LevelName";
                this.lookUpEditLevelN.Properties.ValueMember = "LevelID";
            }
        }

        private void lookUpEditLevelN_EditValueChanged(object sender, EventArgs e)
        {
            ////load_shops();...18July2014 to avoid pass invalid level

            //load_shops(compid, locid, levelid); // querying shops 

            
        }

        private void load_shops()
        {
            if (string.IsNullOrEmpty(lookUpEditCompanyN.Text.ToString()))
            {
                return;
            }

            if (string.IsNullOrEmpty(this.lookUpEditLocationN.Text.ToString()))
            {
                return;
            }
            if (string.IsNullOrEmpty(this.lookUpEditLevelN.Text.ToString()))
            {
                return;
            }

            bool res = false;

            int compid = 0;
            res = int.TryParse(this.lookUpEditCompanyN.EditValue.ToString(), out compid);
            if (res == false) { compid = 0; }
            if (compid == 0) { return; }

            int locid = 0;
            res = int.TryParse(this.lookUpEditLocationN.EditValue.ToString(), out locid);
            if (res == false) { locid = 0; }
            if (locid == 0) { return; }

            int levelid = 0;
            res = int.TryParse(this.lookUpEditLevelN.EditValue.ToString(), out levelid);
            if (res == false) { levelid = 0; }
            if (levelid == 0) { return; }

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryShop = (from s in context.Shops
                               join c in context.Companies on s.CompanyID equals c.CompanyID
                               join l in context.Locations on s.LocationID equals l.LocationID
                               join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                               where s.CompanyID == compid && s.LocationID == locid && s.LevelID == levelid
                               select new { s.ShopNo, s.ShopName, s.ShopID, s.SqFeet, c.CompanyCode, l.LocationCode, lvl.LevelName, s.CustomerID }).ToList();
                this.lookUpEditShopN.Properties.DataSource = qryShop;
                this.lookUpEditShopN.Properties.DisplayMember = "ShopNo";
                this.lookUpEditShopN.Properties.ValueMember = "ShopID";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          //  cAmountWithMandatoryTax_Instance _amount = new cAmountWithMandatoryTax_Instance();
          //_amount=  cAmountWithMandatoryTax.getAmountWithMandatoryTax(1000);
        }

        private void xContract_Confirm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void lookUpEditShopN_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lookUpEditShopN.Text.ToString()))
            { return; }

            int shopid = 0;
            bool res = false;

            res = int.TryParse(this.lookUpEditShopN.EditValue.ToString(), out shopid);
            if (res == false) { dxErrorProvider1.SetError(this.lookUpEditShopN, "Invalid Shop"); return; }
            else { dxErrorProvider1.SetError(this.lookUpEditShopN, ""); }

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryShop = (from s in context.Shops
                               where s.ShopID == shopid
                               select new { s.SqFeet }).FirstOrDefault();
                if (qryShop != null)
                {
                    this.textEditFloorAreaN.EditValue = qryShop.SqFeet;
                }
                else
                {
                    this.textEditFloorAreaN.EditValue = 0;
                }
            }

        }

        private void linkShop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xShops shop = new xShops();
            shop.FormClosing+=new FormClosingEventHandler(shop_FormClosing);
            shop.Show(this);

           
        }
        private void shop_FormClosing(object sender, FormClosingEventArgs e)
        {
            load_shops();

        }

        private void linkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xExtended_Customers extcust = new xExtended_Customers();
            extcust.FormClosing+=new FormClosingEventHandler(extcust_FormClosing);
            extcust.Show(this);
        }
        private void extcust_FormClosing(object sender, FormClosingEventArgs e)
        {
            load_extendedCustomer();

        }
       
    }
}