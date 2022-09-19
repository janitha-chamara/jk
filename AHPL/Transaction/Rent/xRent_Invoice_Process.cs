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
using DataTier;
using System.Globalization;
using DevExpress.XtraSplashScreen;
using DataTier.Reports.Rent;
using System.IO;
namespace MMS
{
    public partial class xRent_Invoice_Process : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<Invoice> invdetList = new List<Invoice>();
        List<cProcessContracts> ProcContList = new List<cProcessContracts>();
        List<cProcessContract2> ProcContList2 = new List<cProcessContract2>();

        public xRent_Invoice_Process()
        {
            InitializeComponent();
        }

        private void parentTopPanel_Click(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            //splashScreenManager2.ShowWaitForm();
            //splashScreenManager2.WaitForSplashFormClose();
            this.Close();

        }

        private void cmdNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            //this.enable_control(true, eRecStatus.eAddNew);
            //this.ClearText();
        }

        private void cmdUndo_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            //this.ClearText();
            //this.enable_control(false, eRecStatus.eInit);
        }

        private void cmdSave_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {

            //this.ClearText();
            //this.enable_control(false, eRecStatus.eSave);

        }

        private void xRentInvoice_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {

            dtMonthYear.DateTime = DateTime.Now.Date;
            dtInvoiceDate.DateTime = DateTime.Now.Date;
            int year = dtMonthYear.DateTime.Year;
            int month = dtMonthYear.DateTime.Month;

            //loading locaiton
            this.locationBindingSource.DataSource = (from l in context.Locations
                                                     select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();

            //laoading floor levels 
            this.floorLevelsBindingSource.DataSource = (from f in context.Floor_Levels
                                                        select new { f.LevelID, f.LevelCode, f.LevelName }).ToList();


            load_Contract();


            // loading customers
            this.globalCustomersBindingSource.DataSource = (from c in context.Global_Customers
                                                            select new { c.CustomerID, c.CustomerName, c.SAPCustomerCode }).ToList();

            // loading company
            this.companyBindingSource.DataSource = (from c in context.Companies
                                                    select new { c.CompanyID, c.CompanyName, c.CompanyCode }).ToList();

            this.repositoryItemLookUpEdit3.DataSource = (from c in context.Companies
                                                         select new { c.CompanyID, c.CompanyName, c.CompanyCode }).ToList();


            // querying processed invoices

            load_ProcessedContract();



            // Month
            var qryMonth = (from m in context.Months
                            orderby m.MonthID
                            select m);
            this.monthBindingSource.DataSource = qryMonth;

            // loading sub invoice types
            var qrysubInvType = (from si in context.Sub_Invoice_Types
                                 orderby si.StdOrder ascending
                                 select si).ToList();
            this.subInvoiceTypesBindingSource.DataSource = qrysubInvType;

            formatGrid();
            this.gridView1.BestFitColumns();
            //this.chkedCustomers.CheckAll();
        }

        private void load_ProcessedContract(int month = 0, int year = 0)
        {
            //cehck db connection is up - By Ravindra 13_11_2020
            if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Connecting......"); }
          //  bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
            if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
            
            ////int tempFlag = 0;
            if (month == 0)
            { 
                month = DateTime.Now.Date.Month;
                ////tempFlag = 1;
            }

            if (year == 0) { year = DateTime.Now.Year; }


            var qryInvProcessed = (from cc in context.ContractClosures
                                   join i in context.Invoices on cc.ContractClosureID equals i.ContractClosureID
                                   join exC in context.Extended_Customers on cc.ExtendedCustomerID equals exC.ExtendedCustomerID
                                   join gCust in context.Global_Customers on exC.CustomerID equals gCust.CustomerID
                                   where i.IsProcessed == true && i.ProcessMonth == month && i.ProcessYear == year && i.InvoiceTypeID == 1
                                   select new { i.LevelID, i.ShopNo, i.IsProcessed, i.ProcessMonth, i.ProcessYear, cc.ContractID, cc.ShopName, gCust.CustomerID, 
                                       cc.LocationID, cc.CompanyID, i.IsConfirmed, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceID, gCust.IsTaxCustomer, 
                                       i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.OtherTax, i.TotalAmount, i.RentWithSCPerMonth, i.MandatoryTaxAmount,
                                       i.TotalWithMandatoryTax, i.NosDay }).ToList();

            ProcContList.Clear();
            foreach (var qry in qryInvProcessed)
            {
                cProcessContracts oProcCont = new cProcessContracts();
                oProcCont.InvoiceID = qry.InvoiceID;
                oProcCont.ContractID = qry.ContractID;
                oProcCont.CustomerID = qry.CustomerID;
                oProcCont.CompanyID = qry.CompanyID;
                oProcCont.LocaitonID = qry.LocationID;
                oProcCont.Month = qry.ProcessMonth;
                oProcCont.Year = qry.ProcessYear;
                oProcCont.IsProcessed = qry.IsProcessed;
                oProcCont.ShopName = qry.ShopName;
                oProcCont.IsConfirmed = qry.IsConfirmed;
                oProcCont.FromDate = qry.DateFrom;
                oProcCont.ToDate = qry.DateTo;
                oProcCont.NosDays = qry.NosDay;
                oProcCont.TotalRentPerMonth = qry.TotalRentPerMonth;
                oProcCont.OtherTax = qry.OtherTax;
                oProcCont.MandatoryTaxAmount = qry.MandatoryTaxAmount;
                oProcCont.TotalWithMandatoryTax = qry.TotalWithMandatoryTax;
                oProcCont.RentPerMonth = qry.RentWithSCPerMonth;
                oProcCont.LevelID = qry.LevelID;
                oProcCont.ShopNo = qry.ShopNo;
                if (qry.IsConfirmed == true)
                {
                    oProcCont.Edit = "Cannot Edit";
                }
                else
                {
                    oProcCont.Edit = "Edit";
                }
                oProcCont.InvoiceTypeID = qry.InvoiceTypeID;
                oProcCont.SubInvTypeID = qry.SubInvTypeID;
                oProcCont.IsTaxCustomer = qry.IsTaxCustomer;
                ProcContList.Add(oProcCont);
            }

            var qryProcess = (from c in ProcContList
                              orderby c.CompanyID, c.LocaitonID
                              select c).ToList();

            ////if(tempFlag==1)
            ////{
            ////    qryProcess.Clear();////Temp fix for load Invoice again for same month...25Jan2016..remove this after this month 
            ////}

            this.cProcessContractsBindingSource.DataSource = qryProcess;
            this.cProcessContractsGridControl.RefreshDataSource();
        }

        private void load_Contract(bool pShowTerminatedContract = false)
        {
           if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Connecting......"); }
            //bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
            if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
            
            ProcContList2.Clear();
            var qryProcCont2 = (from c in context.ContractClosures
                                join co in context.Companies on c.CompanyID equals co.CompanyID
                                join loc in context.Locations on c.LocationID equals loc.LocationID
                                join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
                                join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                                join s in context.Shops on c.ShopID equals s.ShopID
                                join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                where c.IsPromotion == false && c.IsProcessed == true && c.IsTerminated == pShowTerminatedContract && ra.IsAdvertisement == false && c.IsActive == true

                                select new { lvl.LevelID, c.ExtendedCustomerID, c.IsTerminated, c.ContractClosureID, c.ContractClosureName, c.ShopName, c.ShopID, c.ShopNo, lvl.LevelName, loc.LocationCode, loc.LocationID, co.CompanyCode, co.CompanyID, gcus.CustomerName }).ToList();
            foreach (var qry in qryProcCont2)
            {
                cProcessContract2 oProcCont2 = new cProcessContract2();
                oProcCont2.CustomerName = qry.CustomerName;
                oProcCont2.CompanyCode = qry.CompanyCode;
                oProcCont2.CompanyID = qry.CompanyID;
                oProcCont2.LocationCode = qry.LocationCode;
                oProcCont2.ShopName = qry.ShopName;
                oProcCont2.ShopNo = qry.ShopNo;
                oProcCont2.LocationID = qry.LocationID;
                oProcCont2.LevelID = qry.LevelID;
                oProcCont2.FloorLevel = qry.LevelName;
                oProcCont2.ContractClosureID = qry.ContractClosureID;
                oProcCont2.ContractClosureName = qry.ContractClosureName;
                oProcCont2.Terminated = qry.IsTerminated;
                oProcCont2.ExtendedCustomerID = qry.ExtendedCustomerID;
                oProcCont2.Selected = false;
                ProcContList2.Add(oProcCont2);
            }

            this.cProcessContract2BindingSource.DataSource = ProcContList2;
            this.cProcessContract2GridControl.RefreshDataSource();
        }



        private void btnProcess_Click(object sender, EventArgs e)
        {

            try
            {
                //bool chkConn = true;
               if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Connecting......"); }
              //  chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
               if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
               
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                bool validated = ValidateFields();
                if (validated == false)
                { return; }

                if (splashScreenManager2.IsSplashFormVisible == false)
                {
                    splashScreenManager2.ShowWaitForm();
                    splashScreenManager2.SetWaitFormDescription("Processing Invoice");
                }

                int year = dtMonthYear.DateTime.Year;
                int month = dtMonthYear.DateTime.Month;

                var qryContracts = (from c in ProcContList2
                                    where c.Selected == true
                                    select c).ToList();

                int ss = 0;
                int yy = 0;

                foreach (var qry in qryContracts)
                {
                    if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Connecting......"); }
                    // chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
                    if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                    
                    ss++;
                    // SAP Rent DOC TYPE validattion
                    bool IsSAPDocValidated = SapDocValidate(qry.CompanyID);
                    if (IsSAPDocValidated == false)
                    { return; }
                    //

                    // check invoice weather exist 
                    int invid = getInvoiceID(qry.ContractClosureID, year, month);
                    
                    if (invid == 0)
                    {
                        // check weather the contract is renew and inactive
                        var qryCont = (from c in context.ContractClosures
                                       join co in context.Companies on c.CompanyID equals co.CompanyID
                                       join l in context.Locations on c.LocationID equals l.LocationID
                                       join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
                                       orderby lvl.StdOrder ascending
                                       where c.RefNo == qry.ContractClosureID && c.IsTerminated == false && c.IsProcessed == false && c.IsReleased == true && c.IsActive == false 
                                       select new { c.ContractClosureName, c.ShopName, c.ShopNo, co.CompanyCode, l.LocationCode, lvl.LevelName }).FirstOrDefault();
                        if (qryCont != null)
                        {
                            string msg = "Following Contracct has renewed and inactive , please activate and continue" + System.Environment.NewLine +
                                "Contract : " + qryCont.ContractClosureName + System.Environment.NewLine +
                                "Company : " + qryCont.CompanyCode + System.Environment.NewLine +
                                "Location : " + qryCont.LocationCode + System.Environment.NewLine +
                                "Level : " + qryCont.LevelName + System.Environment.NewLine +
                                "Shop Name : " + qryCont.ShopName + System.Environment.NewLine +
                                "Shop No : " + qryCont.ShopNo + System.Environment.NewLine + System.Environment.NewLine;

                            if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }

                            MessageBox.Show(msg, "Renewed and Inactive Contract Found - Rent Invoice Process", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        //
                        // check contract expiry 
                        var qryContractExpiry = (from r in context.Contract_RentSchemes
                                                 where r.ContractClosureID == qry.ContractClosureID
                                                 select r).AsEnumerable().LastOrDefault();
                        if (qryContractExpiry != null)
                        {
                            DateTime expiryDate = qryContractExpiry.ToDate;
                            if (expiryDate < DateTime.Now.Date)
                            {
                                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }

                                DialogResult dlg = MessageBox.Show("Following Contract already expired" + System.Environment.NewLine +
                                "Contract : " + qry.ContractClosureName + System.Environment.NewLine +
                                "Customer : " + qry.CustomerName + System.Environment.NewLine +
                                "Company : " + qry.CompanyCode + System.Environment.NewLine +
                                "Location : " + qry.LocationCode + System.Environment.NewLine +
                                "Shop Name : " + qry.ShopName + System.Environment.NewLine +
                                "Shop No : " + qry.ShopNo + System.Environment.NewLine +
                                "Expiry Date : " + qryContractExpiry.ToDate.ToString("dd/MM/yyyy") + System.Environment.NewLine + System.Environment.NewLine +
                                "Do you want to continue?", "Contract Expired - Process Rent Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                if (dlg == System.Windows.Forms.DialogResult.No)
                                {
                                    return;
                                }
                                else
                                {
                                    if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); }

                                }

                            }

                        }

                        yy++;


                        //--
                        Invoice oInv = new Invoice();
                        oInv.InvoiceTypeID = 1; // Rent Invoice
                        oInv.SubInvTypeID = 3; // Invoice ( Invoice/CreditNote/Adjustment)
                        oInv.ProcessMonth = dtMonthYear.DateTime.Month;
                        oInv.ProcessYear = dtMonthYear.DateTime.Year;
                        oInv.InvoiceDate = dtInvoiceDate.DateTime;
                        oInv.SAP_PstnDateInDoc = dateEditSapPostingDate.DateTime;
                        oInv.LocationID = qry.LocationID;
                        oInv.LocationCode = context.Locations.Where(x => x.LocationID == qry.LocationID).FirstOrDefault().LocationCode;
                        oInv.LevelID = qry.LevelID;
                        oInv.LevelName = context.Floor_Levels.Where(x => x.LevelID == qry.LevelID).FirstOrDefault().LevelName;


                        // check date Contract is within the range
                        //--
                        cRentScheme rentscheme = cActiveRentScheme.getDefaultOrLastRate(dtInvoiceDate.DateTime, qry.ContractClosureID, dateEditFrom.DateTime, dateEditTo.DateTime);

                        if (rentscheme.IsContractOutOfRange == true)
                        {
                            //if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                            //MessageBox.Show("'" +  rentscheme.ContractName + "'" + " contract is out of range or invalid contract" + System.Environment.NewLine + "Please Check the Contract's 3rd Schedule", " Invalid Contract - Process Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return; 
                            oInv.Naration = "Contract is out range! contract may have expired hence last rate of the contract's value is taken as defualt";

                        }
                        if (rentscheme.ContractClosureID > 0)
                        {

                            oInv.DateTo = dateEditTo.DateTime;
                            if (rentscheme.IsContractOutOfRange == true)
                            {
                                oInv.DateTo = dateEditTo.DateTime;
                                oInv.DateFrom = dateEditFrom.DateTime;
                            }
                            else
                            {
                                oInv.DateFrom = rentscheme.FromDate;
                            }
                            int nosdays = dateEditTo.DateTime.Subtract(oInv.DateFrom).Days;
                            oInv.NosDay = nosdays;
                            oInv.ContractID = rentscheme.ContractID;

                            oInv.CompanyID = qry.CompanyID;
                            oInv.CompanyCode = context.Companies.Where(x => x.CompanyID == qry.CompanyID).FirstOrDefault().CompanyCode;
                            oInv.SAP_CompanyCode = getSapCompanyCode(qry.CompanyID);

                            oInv.ModifiedDate = DateTime.Now.Date;
                            var qryCustID = (from exc in context.Extended_Customers
                                             join gc in context.Global_Customers on exc.CustomerID equals gc.CustomerID
                                             where exc.ExtendedCustomerID == qry.ExtendedCustomerID
                                             select new { gc.CustomerID, gc.CustomerName, gc.CompanyAddress, exc.ExtendedCustomerID, exc.IsTaxApplicable,
                                                 gc.IsTaxCustomer }).FirstOrDefault();


                            if (qryCustID.CustomerID == 99)
                            {

                                int custid = qryCustID.CustomerID;
                            }

                            oInv.CustomerID = qryCustID.CustomerID;
                            oInv.CustomerName = qryCustID.CustomerName;
                            oInv.CustomerAddress = qryCustID.CompanyAddress;
                            oInv.ExtendedCustomerID = qryCustID.ExtendedCustomerID;
                            oInv.IsTaxApplicable = qryCustID.IsTaxApplicable;
                            oInv.IsTaxCustomer = qryCustID.IsTaxCustomer;
                            oInv.AreaInSqFt = rentscheme.FloorArea;
                            oInv.RentPerSqFt = rentscheme.RentPerSqFeet;
                            oInv.RentPerMonth = rentscheme.FloorArea * rentscheme.RentPerSqFeet;
                            oInv.SCPerSqFt = rentscheme.SCperSqFeet;
                            oInv.RentWIthSCPerSqFt = rentscheme.RentWithSCperSqft;
                            oInv.SCPerMonth = rentscheme.SCperMonth;
                            oInv.RentWithSCPerMonth = rentscheme.RentWithSCperMonth;

                            //// check tax is applicable for the customer 
                            bool IsTaxCalApply = MMS.CustomClasses.cCommon_Functions.IsTaxCalApplicable(qry.ContractClosureID);
                            oInv.IsTaxApplicable = IsTaxCalApply;

                            cMandatoryTax mandatoryTax = cTaxCalculations.getAmountWithMandatoryTax(rentscheme.RentWithSCperMonth);
                            if (IsTaxCalApply == true) { oInv.MandatoryTaxAmount = mandatoryTax.MandatoryTaxAmount; } else { oInv.MandatoryTaxAmount = 0; }
                            if (IsTaxCalApply == true) { oInv.TotalWithMandatoryTax = mandatoryTax.TotalWithMandatoryTax; } else { oInv.TotalWithMandatoryTax = rentscheme.RentWithSCperMonth; }
                            oInv.MandatoryTaxCode = mandatoryTax.MandatoryTaxCode;
                            oInv.MandatoryTaxID = mandatoryTax.MandatoryTaxID;
                            oInv.MandatoryTaxRateID = mandatoryTax.MandatoryTaxRateID;

                            //adding Mandatory Taxes into the Invoice Detail
                            Invoice_Details oInvDet = new Invoice_Details();
                            if (IsTaxCalApply == true) { oInvDet.Amount = mandatoryTax.MandatoryTaxAmount; } else { oInvDet.Amount = 0; }
                            oInvDet.TaxID = mandatoryTax.MandatoryTaxID;
                            oInvDet.TaxRateID = mandatoryTax.MandatoryTaxRateID;
                            oInvDet.TaxCode = mandatoryTax.MandatoryTaxCode;
                            oInvDet.TaxRate = mandatoryTax.MandatoryTaxRate;
                            oInvDet.IsPrint = false;

                            /// record creation time
                            oInvDet.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                            oInvDet.CreatedDate = DateTime.Now;
                            //--

                            oInv.Invoice_Details.Add(oInvDet);
                            //--
                            //if (IsTaxCalApply == false) { oInv.IsTaxCustomer = false; }
                            //else { oInv.IsTaxCustomer = rentscheme.IsTaxCustomer; }
                            oInv.ContractClosureID = rentscheme.ContractClosureID;
                            oInv.Contract_RentSchemeID = rentscheme.Contract_RentSchemeID;
                            List<cOtherTax> otherTaxList = cTaxCalculations.getOtherTax(oInv.TotalWithMandatoryTax);

                            // tax details
                            foreach (var qryOT in otherTaxList)
                            {
                                oInvDet = new Invoice_Details();
                                if (IsTaxCalApply == false) { oInvDet.Amount = 0; }
                                else { oInvDet.Amount = qryOT.TaxAmount; }
                                oInvDet.TaxID = qryOT.TaxID;
                                oInvDet.TaxRateID = qryOT.TaxRateID;
                                oInvDet.TaxRate = qryOT.TaxRate;
                                oInvDet.TaxCode = qryOT.TaxCode;
                                oInvDet.IsPrint = true;
                                //record creation time
                                oInvDet.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                                oInvDet.CreatedDate = DateTime.Now;
                                //--
                                oInv.Invoice_Details.Add(oInvDet);

                            }

                            var qryOtherTax = (from det in oInv.Invoice_Details
                                               where det.IsPrint == true
                                               select det).Sum(x => x.Amount);
                            oInv.OtherTax = Math.Round(qryOtherTax, 4);
                            oInv.OtherTaxCodes = MMS.CustomClasses.cCommon_Functions.getOtherTaxCodes();
                            oInv.TotalRentPerMonth = Math.Round(oInv.OtherTax + oInv.TotalWithMandatoryTax, 4);

                            invdetList.Add(oInv);

                            oInv.ShopName = rentscheme.ShopName;
                            oInv.ShopNo = rentscheme.ShopNo;
                            oInv.ShopID = rentscheme.ShopID;
                            oInv.ExtendedCustomerID = rentscheme.ExtendedCustomerID;
                            oInv.FooterText1 = this.txtInvoiceFooter.Text.ToString();
                            oInv.ModifiedDate = DateTime.Now;
                            //Updating SAP fields 
                            oInv.SAP_Assignment = "RENT";
                            oInv.SAP_Text = "RENT_" + oInv.ShopNo.ToString().Trim() + "_" + MMS.CustomClasses.cCommon_Functions.getMonthAbbrName(dtMonthYear.DateTime.Month) + "_" + dtMonthYear.DateTime.Year.ToString();
                            oInv.SAP_RefKey1 = oInv.ShopNo;
                            oInv.SAP_RefKey2 = oInv.ShopName;
                            oInv.SAP_RefKey3 = "FIXED";
                            oInv.SAP_DocHeaderText = "R" + oInv.ShopNo + dtMonthYear.DateTime.Month.ToString() + dtMonthYear.DateTime.Year.ToString();
                            var qryDT = (from dt in context.SAP_DocTypes
                                         where dt.CompanyID == oInv.CompanyID && dt.InvoiceTypeID == 1
                                         select dt).FirstOrDefault();
                            if (qryDT != null)
                            {
                                oInv.SAP_DocType = qryDT.DOCTYPE;
                            }
                            //--
                            if (splashScreenManager2.IsSplashFormVisible == false)
                            {
                                splashScreenManager2.ShowWaitForm();
                                splashScreenManager2.SetWaitFormDescription(oInv.ShopNo);
                            }
                            oInv.TaxRegNo = getTaxInfo(oInv.ContractClosureID);

                            oInv.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                            oInv.CreatedDate = DateTime.Now;
                            context.Invoices.AddObject(oInv);
                        }
                        else
                        {

                        }
                    }

                    
                    this.gridView1.BestFitColumns();
                    //this.gridView1.ExportToXlsx(
                }

                int s = ss;
                int y = yy;

                int d = qryContracts.Count;

                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                    MessageBox.Show("Record(s) Saved Successfully", "Save Success - Process Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //load_data();
                    load_ProcessedContract(dtMonthYear.DateTime.Month, dtMonthYear.DateTime.Year);

                    //// email alert 
                    int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.RentInvoiceProcessed;
                    this.gridView1.OptionsPrint.ShowPrintExportProgress = false;
                    MMS.CustomClasses.cCommon_Functions.AddToEmailList(int.Parse(lookCompanies.EditValue.ToString()), int.Parse(this.lookLocation.EditValue.ToString()), alert, "", MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.gridView1);

                    //-
                }

                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                this.cProcessContractsGridControl.RefreshDataSource();

                //this.invoiceGridControl.RefreshDataSource();
                //this.gridView1.RefreshData();
            }
            catch (Exception ex)
            {
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getSapCompanyCode(int pCompanyID)
        {
            string sapCompanyCode = "";
            var qrySapCompanyCode = (from c in context.Companies
                                     where c.CompanyID == c.CompanyID
                                     select new { c.SA_CompanyCode }).FirstOrDefault();
            if (qrySapCompanyCode != null)
            {
                sapCompanyCode = qrySapCompanyCode.SA_CompanyCode;
            }

            return sapCompanyCode;

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
                    if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
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
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                MessageBox.Show("Please Setup the DOC TYPE in SAP Master Setting", "SAP DOC TYPE Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return validated;
        }

        private bool ValidateFields()
        {
            bool validated = false;

            // Month/Year
            if (string.IsNullOrEmpty(this.dtMonthYear.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.dtMonthYear, "Invalid Year - Month");
                return false;
            }
            else
            {
                dxErrorProvider1.SetError(this.dtMonthYear, "");
                validated = true;
            }

            // Invoice Date
            if (string.IsNullOrEmpty(this.dtInvoiceDate.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.dtInvoiceDate, "Invalid Date");
                return false;
            }
            else
            {
                dxErrorProvider1.SetError(this.dtInvoiceDate, "");
                validated = true;
            }

            // from date 
            if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.dateEditFrom, "Invalid Date");
                return false;
            }
            else
            {
                dxErrorProvider1.SetError(this.dateEditFrom, "");
                validated = true;
            }

            // To date
            if (string.IsNullOrEmpty(this.dateEditTo.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.dateEditTo, "Invalid Date");
                return false;
            }
            else
            {
                dxErrorProvider1.SetError(this.dateEditTo, "");
                validated = true;
            }

            // sap posting date
            if (string.IsNullOrEmpty(this.dateEditSapPostingDate.Text.ToString()))
            {
                dxErrorProvider1.SetError(this.dateEditSapPostingDate, "Invalid Sap Posting Date");
                return false;
            }
            else
            {
                dxErrorProvider1.SetError(this.dateEditSapPostingDate, "");
                validated = true;
            }


            return validated;
        }



        private void formatGrid()
        {
            var qryTaxM = (from t in context.Taxes
                           where t.IsMandatory == true
                           select new { t.TaxCode }).FirstOrDefault();
            if (qryTaxM != null)
            {
                this.gridView1.Columns["TotalWithMandatoryTax"].Caption = "Rent + " + qryTaxM.TaxCode;
                this.gridView1.Columns["MandatoryTaxAmount"].Caption = qryTaxM.TaxCode;
            }

            //
            string _oTaxcodes = string.Empty;
            var qryTaxO = (from t in context.Taxes
                           where t.IsMandatory == false
                           select new { t.TaxCode }).ToList();

            foreach (var qry in qryTaxO)
            {
                if (qryTaxO.Count > 1)
                {
                    _oTaxcodes = _oTaxcodes + " + " + qry.TaxCode;
                }
                else
                {
                    _oTaxcodes = qry.TaxCode;
                }
            }

            if (!string.IsNullOrEmpty(_oTaxcodes.Trim()))
            {

                this.gridView1.Columns["OtherTax"].Caption = _oTaxcodes;
            }
            //var qryTaxO = (from t in context.Taxes
            //               where t.IsMandatory == false
            //               select new {t.TaxCode}).FirstOrDefault
        }

        private int getMandatoryTaxID(Invoice oInv)
        {
            throw new NotImplementedException();
        }

        private DateTime getContStatDate(DateTime pDateTime, int pContractID)
        {
            DateTime mDateTime = pDateTime;


            var qryContStartDate = (from c in context.Contract_Rates
                                    where c.ContractID == pContractID && c.IsActive == true
                                    select new { c.ActiveFrom }).FirstOrDefault();
            if (qryContStartDate != null)
            {
                int laps = qryContStartDate.ActiveFrom.Subtract(pDateTime).Days;
                if (laps < 0)
                {
                    mDateTime = qryContStartDate.ActiveFrom.Date;
                }
            }


            return mDateTime;

        }

        private decimal getTotalAmtWithTaxExcludedMandTax(Invoice oInv)
        {
            decimal totaltax = 0;
            List<decimal> totalTaxList = new List<decimal>();
            var qryTax = (from tx in context.Taxes
                          join txr in context.TaxRates on tx.TaxID equals txr.TaxID
                          where txr.IsActive == true && tx.IsMandatory == false
                          select new { tx.TaxID, txr.TaxRateID, txr.TaxRate1 }).ToList();
            foreach (var qry in qryTax)
            {
                decimal taxamount = (oInv.TotalAmount * qry.TaxRate1) / 100;
                totalTaxList.Add(taxamount);
            }

            var qryTotal = totalTaxList.Sum();

            totaltax = qryTotal;

            return totaltax;

        }

        private bool getIsTaxCustomer(int pCustID)
        {
            bool IsTaxCustomer = false;
            var qryCustTax = (from ct in context.Customer_Taxes
                              join tx in context.Taxes on ct.TaxID equals tx.TaxID
                              where ct.CustomerID == pCustID && tx.IsMandatory != true
                              select new { ct.TaxID }).ToList();
            if (qryCustTax.Count == 0)
            {
                IsTaxCustomer = false;
            }
            else
            {
                IsTaxCustomer = true;
            }

            return IsTaxCustomer;
        }

        private decimal getMandatoryTaxAmount(Invoice oInv)
        {
            decimal mandatoryTaxAmount = 0;

            var qryTaxRate = (from tx in context.Taxes
                              join txr in context.TaxRates on tx.TaxID equals txr.TaxID
                              where tx.IsMandatory == true && txr.IsActive == true
                              select new { txr.TaxRate1, tx.TaxCode, tx.TaxID, txr.TaxRateID }).FirstOrDefault();
            if (qryTaxRate != null)
            {
                mandatoryTaxAmount = (qryTaxRate.TaxRate1 * oInv.RentWithSCPerMonth) / 100;
            }

            oInv.MandatoryTaxAmount = mandatoryTaxAmount;
            oInv.MandatoryTaxID = qryTaxRate.TaxID;
            oInv.MandatoryTaxRateID = qryTaxRate.TaxRateID;
            oInv.MandatoryTaxCode = qryTaxRate.TaxCode;
            return mandatoryTaxAmount;
        }


        private string getTaxInfo(int pContractClauseID)
        {
            string TaxRegInfo = string.Empty;
            // company tax reg no
            var qryCompanyTax = (from c in context.ContractClosures
                                 join comp in context.Companies on c.CompanyID equals comp.CompanyID
                                 join ctax in context.Company_Taxes on comp.CompanyID equals ctax.CompanyID
                                 join tax in context.Taxes on ctax.TaxID equals tax.TaxID
                                 where c.ContractClosureID == pContractClauseID
                                 select new { tax.TaxCode, ctax.TaxRegNo }).ToList();

            // customer tax reg no
            var qryCustomerTax = (from c in context.ContractClosures
                                  join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                  join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                                  join ctax in context.Customer_Taxes on gcus.CustomerID equals ctax.CustomerID
                                  join tax in context.Taxes on ctax.TaxID equals tax.TaxID
                                  where c.ContractClosureID == pContractClauseID
                                  select new { tax.TaxCode, ctax.TaxRegNo }).ToList();



            foreach (var qry in qryCompanyTax)
            {
                if (qryCustomerTax.Count > 0)
                {
                    TaxRegInfo = TaxRegInfo + System.Environment.NewLine + "Our " + qry.TaxCode + " Registration No " + qry.TaxRegNo;
                }
                else
                {
                    TaxRegInfo = TaxRegInfo + System.Environment.NewLine + qry.TaxCode + " Registration No " + qry.TaxRegNo;

                }
            }

            foreach (var qry in qryCustomerTax)
            {
                if (qryCustomerTax.Count > 0)
                {
                    TaxRegInfo = TaxRegInfo + System.Environment.NewLine + "Your " + qry.TaxCode + " Registraton No " + qry.TaxRegNo;
                }
            }

            //if (qryCustomerTax.Count > 0)
            //{
            //    oInv.IsTaxCustomer = true;
            //}
            //else
            //{
            //    oInv.IsTaxCustomer = false;
            //}

            return TaxRegInfo;
        }

        private int getInvoiceID(int pContractClauseID, int Year, int Month)
        {
            int invoiceid = 0;

            ////var qry = (from i in context.Invoices
            ////           where i.ContractClosureID == pContractClauseID && i.ProcessYear == Year && i.ProcessMonth == Month && i.InvoiceTypeID == 1
            ////           select new { i.InvoiceID }).FirstOrDefault();

            ////comment above code and add new filter criteria, i.SubInvTypeID==3 for aviod 19Feb2016 'k-12' invoice generating issue.
            ////Reason Eg: if CN is generated for January invoice on Feb month, unable to genarate Invoice for that shop for Feb 
            ////19Feb2016...
            var qry = (from i in context.Invoices
                       where i.ContractClosureID == pContractClauseID && i.ProcessYear == Year && i.ProcessMonth == Month && i.InvoiceTypeID == 1 && i.SubInvTypeID==3
                       select new { i.InvoiceID }).FirstOrDefault();

            if (qry != null)
            {
                invoiceid = qry.InvoiceID;
            }
            else
            {
                invoiceid = 0;
            }

            return invoiceid;

        }

        //private void addTax(int p, Invoice oInv)
        //{
        //    throw new NotImplementedException();
        //}

        private void addTax(int pCustomerID, int pContractRateID, Invoice oInv)
        {
            var qryCRate = (from t in context.Taxes
                            join txr in context.TaxRates on t.TaxID equals txr.TaxID
                            where txr.IsActive == true
                            select txr).ToList();
            foreach (var qry in qryCRate)
            {

                Invoice_Details oInvDet = new Invoice_Details();
                oInvDet.TaxID = qry.TaxID;
                oInvDet.TaxRateID = qry.TaxRateID;
                //oInvDet.Amount = qry.;

                var qryIsTaxApply = (from ct in context.Customer_Taxes
                                     where ct.CustomerID == pCustomerID && ct.TaxID == qry.TaxID
                                     select ct).FirstOrDefault();
                if (qryIsTaxApply != null)
                {
                    oInvDet.IsPrint = true;
                }
                else
                {
                    oInvDet.IsPrint = false;
                }






                oInv.Invoice_Details.Add(oInvDet);

            }


        }

        private string getshopNo(int pContractID)
        {
            string shopno = string.Empty;

            var qryshop = (from cs in context.Contract_Shops
                           join s in context.Shops on cs.ShopID equals s.ShopID
                           where cs.ContractID == pContractID
                           select new { s.ShopNo }).ToList();
            foreach (var qry in qryshop)
            {
                if (shopno != string.Empty)
                {
                    shopno = shopno + " , " + qry.ShopNo;
                }
                else
                {
                    shopno = qry.ShopNo;
                }
            }

            return shopno;
        }

        private void chkedCompany_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(this.lookCompanies.Text.ToString())) { return; }
                int compid = 0;
                bool res = false;
                res = int.TryParse(lookCompanies.EditValue.ToString(), out compid);
                if (res == false) { compid = 0; return; }


                //// Location..roshan..06oct2014
                this.locationBindingSource.DataSource = (from c in context.Companies
                                                         join l in context.Locations on c.LocationID equals l.LocationID
                                                         where c.CompanyID == compid
                                                         select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if (!string.IsNullOrEmpty(this.chkedCompany.Text.ToString()))
            //{
            //    chkedLocaiton.Properties.Items.Clear();
            //    chkedCustomers.Properties.Items.Clear();

            //    //Companies
            //    string selectedComp = this.chkedCompany.Properties.GetCheckedItems().ToString();
            //    if (string.IsNullOrEmpty(selectedComp.ToString().Trim()))
            //    { return; }

            //    string theStringComp = selectedComp;
            //    List<int> intCom = theStringComp.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));

            //    var qryComp = from comp in context.Companies
            //              where intCom.Contains(comp.CompanyID)
            //              select comp;

            //    //location
            //    var qryloc1 = (from c in qryComp
            //                   join l in context.Locations on c.LocationID equals l.LocationID
            //                   select l).ToList().Distinct();
            //    this.locationBindingSource.DataSource = qryloc1;
            //    this.chkedLocaiton.CheckAll();


            //    // selecting list of selected shops/booths
            //    string selectedLoc = this.chkedLocaiton.Properties.GetCheckedItems().ToString();
            //    if (string.IsNullOrEmpty(selectedLoc)) { return ; }

            //    List<int> intLoc = selectedLoc.Split(',').ToList().ConvertAll<int>(s=> Convert.ToInt32(s));

            //    var qrySelected = (from p in ProcContList2
            //                       where intLoc.Contains(p.LocationID) && intCom.Contains(p.CompanyID)
            //                       select p).ToList();
            //    foreach (var qry in qrySelected)
            //    {
            //        qry.Selected = true;
            //    }

            //    this.cProcessContract2GridControl.RefreshDataSource();


            //    // customers
            //    //var qrycust = (from c in context.Contracts
            //    //               join exc in context.Extended_Customers on c.CustomerID equals exc.ExtendedCustomerID
            //    //               join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
            //    //               select new {c.ContractID, c.ShopName, gcus.CustomerID, gcus.CustomerName,c.LocationID,c.CompanyID }).ToList();


            //    //var qryShop = (from c in qrycust
            //    //               where intLoc.Contains(c.LocationID) && intCom.Contains(c.CompanyID)
            //    //               orderby c.ShopName
            //    //               select c).Distinct();

            //    //this.chkedCustomers.Properties.DataSource = qryShop;
            //    //this.chkedCustomers.Properties.DisplayMember = "ShopName";
            //    //this.chkedCustomers.Properties.ValueMember = "ContractID";
            //    //this.chkedCustomers.CheckAll();


            //    //this.chkedLocaiton.Properties.DataSource = qryloc1;
            //    //this.chkedLocaiton.Properties.ValueMember = "LocationID";
            //    //this.chkedLocaiton.Properties.DisplayMember = "LocaitonCode";


            //    //var qryLoc = (from loc in context.Locations
            //    //              select new { loc.LocationID, loc.LocationCode, loc.LocationName }).ToList();


            //    //// location
            //    //string selectedLoc = this.chkedLocaiton.Properties.GetCheckedItems().ToString();
            //    //string theStringLoc = selectedLoc;
            //    //List<int> intLoc = theStringLoc.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));



            //    //int compid = 0;
            //    //bool res = int.TryParse(this.chkedCompany.EditValue.ToString(), out compid);
            //    //if (res == false) { compid = 0; }

            //    //if (compid > 0)
            //    //{

            //    //    var qryCompLoc = (from c in context.Companies
            //    //                      where c.CompanyID == compid
            //    //                      select new { c.LocationID }).FirstOrDefault();
            //    //    if (qryCompLoc != null)
            //    //    {
            //    //        this.chkedLocaiton.EditValue = qryCompLoc.LocationID;
            //    //    }
            //    //    else
            //    //    {
            //    //        this.chkedLocaiton.EditValue = 0;
            //    //    }

            //    //}

            //}
        }

        private void chkedLocaiton_EditValueChanged(object sender, EventArgs e)
        {
            btnSelectAll.Text = "Select All";
            if (string.IsNullOrEmpty(lookLocation.Text.ToString()))
            { return; }

            if (string.IsNullOrEmpty(lookCompanies.Text.ToString()))
            { return; }


            bool res = false;
            int locid = 0; int compid = 0;
            res = int.TryParse(this.lookLocation.EditValue.ToString(), out locid);
            if (res == false) { locid = 0; return; }

            res = int.TryParse(this.lookCompanies.EditValue.ToString(), out compid);
            if (res == false) { compid = 0; return; }

            ////uncheck all 
            foreach (var qry in ProcContList2)
            {
                qry.Selected = false;
            }

            var qrySelected = (from p in ProcContList2
                               where p.LocationID == locid && p.CompanyID == compid
                               select p).ToList();
            foreach (var qry in qrySelected)
            {
                qry.Selected = true;
            }

            //////below codes are not need, this functionality already implemented in above code lines...roshan..06Oct2014.. remove after fully tested
            ////var qryUnselect = (from p in ProcContList2
            ////                   where (p.LocationID != locid) && (p.CompanyID != compid)
            ////                   select p).ToList();
            ////foreach (var qry in qryUnselect)
            ////{
            ////    qry.Selected = false;
            ////}

            this.cProcessContract2GridControl.RefreshDataSource();

            ////roshan..29092014..to add select_unselectbutton
            if (qrySelected.Count > 0)
            {
                btnSelectAll.Checked = true;
                btnSelectAll.Text = "Unselect All";
            }

        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager2.IsSplashFormVisible == false)
                    splashScreenManager2.SetWaitFormDescription("Generating Print");
                {
                    splashScreenManager2.ShowWaitForm();
                }

                rptMain _main = new rptMain();
                rptRent_Invoice rptrentInv = new rptRent_Invoice();



                //string selected = this.chkedCustomers.Properties.GetCheckedItems().ToString();
                int year = dtMonthYear.DateTime.Year;
                int month = dtMonthYear.DateTime.Month;

                var qryInvoice = (from c in ProcContList2
                                  join i in context.Invoices on c.ContractClosureID equals i.ContractClosureID
                                  where i.ProcessMonth == month && i.ProcessYear == year
                                  select new { i.InvoiceID, i.InvoiceNo, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceDate, i.CustomerID, i.CustomerName, i.CustomerAddress, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.OtherTax, i.TaxRegNo, i.SAP_DocHeaderText, i.IsTaxCustomer, i.MandatoryTaxCode, i.ProcessMonth, i.ProcessYear, i.ShopNo, i.CompanyID, i.LocationID, i.ShopName, i.IsTaxApplicable, i.Naration, i.FooterText1 }).ToList();

                if (qryInvoice.Count == 0)
                {
                    if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                    return;
                }
                var qryInvDet = (from d in context.Invoice_Details
                                 select new { d.InvoiceDetailID, d.InvoiceID, d.IsPrint, d.TaxID, d.TaxCode, d.TaxRateID, d.TaxRate, d.Amount }).ToList();

                var qryCompany = (from c in context.Companies
                                  select new { c.CompanyID, c.CompanyCode, c.CompanyName, c.BusinessRegNo, c.InvoiceFooterText1, c.InvoiceFooterText2, c.Tele1, c.Tele2, c.Fax }).ToList();

                var qryMonth = (from m in context.Months
                                select m).ToList();

                var qryTax = (from t in context.Taxes
                              select new { t.TaxID, t.TaxCode, t.TaxName, t.IsMandatory }).ToList();

                var qryLocaiton = (from l in context.Locations
                                   select new { l.LocationID, l.LocationCode, l.LocationName, l.Address, l.Logo }).ToList();

                var qryInvType = (from it in context.Invoice_Types
                                  select new { it.InvoiceTypeID, it.InvoiceTypeName }).ToList();

                var qrySubInvType = (from sit in context.Sub_Invoice_Types
                                     select new { sit.SubInvTypeID, sit.SubInvTypeName }).ToList();



                rptrentInv.Database.Tables["DataTier_Invoice"].SetDataSource(qryInvoice);
                rptrentInv.Database.Tables["DataTier_Invoice_Details"].SetDataSource(qryInvDet);
                rptrentInv.Database.Tables["DataTier_Company"].SetDataSource(qryCompany);
                rptrentInv.Database.Tables["DataTier_Month"].SetDataSource(qryMonth);
                rptrentInv.Database.Tables["DataTier_Invoice_Types"].SetDataSource(qryInvType);
                rptrentInv.Database.Tables["DataTier_Sub_Invoice_Types"].SetDataSource(qrySubInvType);
                rptrentInv.Database.Tables["DataTier_Tax"].SetDataSource(qryTax);
                rptrentInv.Database.Tables["DataTier_Location"].SetDataSource(qryLocaiton);

                _main.crystalReportViewer1.ReportSource = rptrentInv;

                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }

                _main.Show(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var ifocusrow = this.gridView1.GetFocusedRow();
            cProcessContracts oProcCont = new cProcessContracts();
            oProcCont = (cProcessContracts)ifocusrow;
            if (oProcCont != null)
            {
                if (oProcCont.IsConfirmed == true)
                {
                    MessageBox.Show("Confirmed Invoice cannot be edited", "Cannot Edit - Invoice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    xRent_Invoice_Edit rentInvEdit = new xRent_Invoice_Edit();
                    rentInvEdit.FormClosing += new FormClosingEventHandler(rentInvEdit_FormClosing);

                    rentInvEdit.Show(this);
                    rentInvEdit.Fill_Data(oProcCont.InvoiceID);
                }
            }


        }

        private void rentInvEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            load_data();

        }

        private void cmdEdit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {

        }

        private void dtMonthYear_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dtMonthYear.Text.ToString()))
            { return; }
            if (string.IsNullOrEmpty(this.lookCompanies.Text.ToString()))
            { return; }

            int compid = 0;
            bool res = false;



            res = int.TryParse(this.lookCompanies.EditValue.ToString(), out compid);
            if (res == false) { compid = 0; return; }

            //var qryBCycle = (from b in context.Invoice_Cycles
            //                 where b.CompanyID == compid
            //                 select b).FirstOrDefault();
            //int toDay = 0;
            //if (qryBCycle == null)
            //{ return; }
            //else { toDay = qryBCycle.ToDay; }


            int year = dtMonthYear.DateTime.Year;
            int month = dtMonthYear.DateTime.Month;
            //DateTime todate = new DateTime(year, month, toDay);
            //double dayback = 30.41666666666667;

            //DateTime fromdate = todate.AddDays(-dayback);

            //dateEditFrom.DateTime = fromdate;
            //dateEditTo.DateTime = todate;
            load_ProcessedContract(month, year);

            ////sap positn date 
            //DateTime dtSapPostingdate = new DateTime(year, month, 1);
            //this.dateEditSapPostingDate.DateTime = dtSapPostingdate;
            ////


        }

        private void load_data(int year, int month)
        {
            // querying processed invoiceses for selected month and year
            var qryInvProcessed = (from cc in context.ContractClosures
                                   join c in context.Contracts on cc.ContractClosureID equals c.ContractClosureID
                                   join i in context.Invoices on c.ContractID equals i.ContractID
                                   join exC in context.Extended_Customers on c.CustomerID equals exC.ExtendedCustomerID
                                   join gCust in context.Global_Customers on exC.CustomerID equals gCust.CustomerID
                                   where i.IsProcessed == true && i.ProcessMonth == month && i.ProcessYear == year && i.InvoiceTypeID == 1 && cc.IsTerminated == false
                                   select new { i.IsProcessed, i.ProcessMonth, i.ProcessYear, c.ContractID, c.ShopName, gCust.CustomerID, c.LocationID, c.CompanyID, i.IsConfirmed, i.InvoiceTypeID, i.SubInvTypeID, i.InvoiceID, i.IsTaxCustomer, i.DateFrom, i.DateTo, i.TotalRentPerMonth, i.OtherTax, i.TotalAmount, i.RentWithSCPerMonth, i.MandatoryTaxAmount, i.TotalWithMandatoryTax, i.NosDay }).ToList();

            ProcContList.Clear();
            foreach (var qry in qryInvProcessed)
            {
                cProcessContracts oProcCont = new cProcessContracts();
                oProcCont.InvoiceID = qry.InvoiceID;
                oProcCont.ContractID = qry.ContractID;
                oProcCont.CustomerID = qry.CustomerID;
                oProcCont.CompanyID = qry.CompanyID;
                oProcCont.LocaitonID = qry.LocationID;
                oProcCont.Month = qry.ProcessMonth;
                oProcCont.Year = qry.ProcessYear;
                oProcCont.IsProcessed = qry.IsProcessed;
                oProcCont.ShopName = qry.ShopName;
                oProcCont.IsConfirmed = qry.IsConfirmed;
                oProcCont.FromDate = qry.DateFrom;
                oProcCont.ToDate = qry.DateTo;
                oProcCont.NosDays = qry.NosDay;
                oProcCont.TotalRentPerMonth = qry.TotalRentPerMonth;
                oProcCont.OtherTax = qry.OtherTax;
                oProcCont.MandatoryTaxAmount = qry.MandatoryTaxAmount;
                oProcCont.TotalWithMandatoryTax = qry.TotalWithMandatoryTax;
                oProcCont.RentPerMonth = qry.RentWithSCPerMonth;
                if (qry.IsConfirmed == true)
                {
                    oProcCont.Edit = "Cannot Edit";
                }
                else
                {
                    oProcCont.Edit = "Edit";
                }
                oProcCont.InvoiceTypeID = qry.InvoiceTypeID;
                oProcCont.SubInvTypeID = qry.SubInvTypeID;
                ProcContList.Add(oProcCont);
            }

            // ordering by company and location the query
            var qryProcess = (from c in ProcContList
                              orderby c.CompanyID, c.LocaitonID
                              select c).ToList();
            this.cProcessContractsBindingSource.DataSource = qryProcess;
            this.cProcessContractsGridControl.RefreshDataSource();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedlg = new SaveFileDialog();
            savedlg.ShowDialog();
            string filePath = savedlg.FileName;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.Export(DevExpress.XtraPrinting.ExportTarget.Xlsx, filePath + ".xlsx");

        }

        private void splitContainerControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkEditShowDiscontinued_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditShowDiscontinued.CheckState == CheckState.Checked)
            {
                load_Contract(true);
            }
            else
            {
                load_Contract(false);
            }

        }

        private void dateEditFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.dateEditFrom.Text.ToString()))
                { return; }

                DateTime postingDate = DateTime.Now.Date;
                bool res = DateTime.TryParse(this.dateEditFrom.EditValue.ToString(), out postingDate);

                dateEditSapPostingDate.DateTime = postingDate;


                dateEditTo.DateTime = dateEditFrom.DateTime.AddMonths(1).AddDays(-1).Date;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void dtInvoiceDate_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(this.dtInvoiceDate.Text.ToString()))
            //{
            //    return;
            //}

            //DateTime invoiceDate = DateTime.Now.Date;
            //bool res = false;

            //res = DateTime.TryParse(dtInvoiceDate.EditValue.ToString(), out invoiceDate);
            //if (res == false) { dtInvoiceDate.DateTime = DateTime.Now.Date; }







        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.cProcessContractsBindingSource.EndEdit();

                var qryNotConfirmedList = (from p in ProcContList
                                           where p.IsConfirmed == false
                                           select p);

                foreach (var qry in qryNotConfirmedList)
                {
                    Invoice invoiceObject = (from i in context.Invoices
                                             where i.InvoiceID == qry.InvoiceID
                                             select i).FirstOrDefault();
                    if (invoiceObject != null)
                    {
                        context.Invoices.DeleteObject(invoiceObject);

                        var qryInvDet = invoiceObject.Invoice_Details.ToList();
                        foreach (var qryD in qryInvDet)
                        {
                            Invoice_Details invoicedetailObject = (from d in context.Invoice_Details
                                                                   where d.InvoiceDetailID == qryD.InvoiceDetailID
                                                                   select d).FirstOrDefault();
                            if (invoicedetailObject != null)
                            {
                                context.Invoice_Details.DeleteObject(invoicedetailObject);
                            }
                        }
                    }

                }

                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    MessageBox.Show("Record(s) Deleted Successfully...", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void btnSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ////roshan..to select unselect option
            bool res = false;
            int locid = 0;
            int compid = 0;
            res = int.TryParse(Convert.ToString(this.lookLocation.EditValue), out locid);
            if (res == false)
            {
                locid = 0;
                return;
            }

            res = int.TryParse(Convert.ToString(this.lookCompanies.EditValue), out compid);
            if (res == false)
            {
                compid = 0;
                return;
            }

            var qrySelected = (from p in ProcContList2
                               where p.LocationID == locid && p.CompanyID == compid
                               select p).ToList();

            if (btnSelectAll.Checked == true)
            {
                btnSelectAll.Text = "Unselect All";
                foreach (var qry in qrySelected)
                {
                    qry.Selected = true;
                }
            }
            else
            {
                btnSelectAll.Text = "Select All";
                foreach (var qry in qrySelected)
                {
                    qry.Selected = false;
                }
            }

            this.cProcessContract2GridControl.RefreshDataSource();
        }

    }
}
