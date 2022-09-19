using System;
using System.Collections.Generic;
using System.Linq;
using DataTier;
using System.Windows.Forms;
using System.Transactions;
using System.Net.Mail;
using MMS;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace MMS.CustomClasses
{
    public static class cCommon_Functions
    {

        public enum AlertItem
        {
            ContractExpiry = 1,
            ContractReleased = 2,
            ContractReleasedToAccounts = 3,
            ContractAssigned = 4,
            RentInvoiceProcessed = 5,
            RentInvoiceConfirmed = 6,
            ContractTerminated = 7,
            OtherServiceInvoiceConfirmed = 8,
            OtherServiceContractProcessed = 9,
            OtherServiceContractAssigned = 10,
            UtilityInvoiceConfirmed = 11,
            UtilityInvoiceProcessed = 12,
            OtherServiceInvoiceProcesed = 13,
            CreditNoteProcessedRenInvoice = 14,
            AdjustmentProcessedRentInvoice = 15,
            SapUpload = 16,
            ContractRenewed = 17



        }


        public static string getTaxRegNo(int pExtendedCustomerID, bool pIsGlobalTaxApply, bool pIsUtilityTaxApply = true)
        {
            string TaxRegInfo = string.Empty;
            // company tax reg no
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCompanyTax = (from ec in context.Extended_Customers
                                     join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                     join ctax in context.Company_Taxes on ec.CompanyID equals ctax.CompanyID
                                     join tax in context.Taxes on ctax.TaxID equals tax.TaxID
                                     where ec.ExtendedCustomerID == pExtendedCustomerID
                                     select new { tax.TaxCode, ctax.TaxRegNo }).ToList();

                // customer tax reg no
                var qryCustomerTax = (from exc in context.Extended_Customers
                                      join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                                      join ctax in context.Customer_Taxes on gcus.CustomerID equals ctax.CustomerID
                                      join tax in context.Taxes on ctax.TaxID equals tax.TaxID
                                      where exc.ExtendedCustomerID == pExtendedCustomerID
                                      select new { tax.TaxCode, ctax.TaxRegNo }).ToList();



                foreach (var qry in qryCompanyTax)
                {
                    if (qryCustomerTax.Count > 0)
                    {
                        if (pIsUtilityTaxApply == true)
                        {
                            TaxRegInfo = TaxRegInfo + System.Environment.NewLine + "Our " + qry.TaxCode + " Registration No " + qry.TaxRegNo;
                        }
                        else
                        {
                            TaxRegInfo = TaxRegInfo + System.Environment.NewLine + qry.TaxCode + " Registration No " + qry.TaxRegNo;

                        }
                    }
                    else
                    {
                        TaxRegInfo = TaxRegInfo + System.Environment.NewLine + qry.TaxCode + " Registration No " + qry.TaxRegNo;
                    }
                }

                if (pIsGlobalTaxApply == true)
                {
                    foreach (var qry in qryCustomerTax)
                    {
                        if (qryCustomerTax.Count > 0)
                        {
                            if (pIsUtilityTaxApply == true)
                            {

                                TaxRegInfo = TaxRegInfo + System.Environment.NewLine + "Your " + qry.TaxCode + " Registraton No " + qry.TaxRegNo;
                            }
                        }
                    }
                }
            }



            return TaxRegInfo;
        }

        public static decimal getTotalOccArea(int pLocID)
        {
            decimal totFloorArea = 0;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                List<decimal> totalList = new List<decimal>();

                var qryTotOcc = (from s in context.Shops
                                 where s.LocationID == pLocID && s.CustomerID > 0 && s.SqFeet > 1
                                 select new { s.SqFeet }).ToList();
                foreach (var qry in qryTotOcc)
                {
                    totalList.Add(qry.SqFeet);
                }

                totFloorArea = totalList.Sum();

            }

            return totFloorArea;

        }

        public static decimal getAvailableArea(int pLocID)
        {


            decimal totavailable = 0;
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    //total occupied area 

                    List<decimal> totalOccList = new List<decimal>();
                    var qryTotOcc = (from s in context.Shops
                                     where s.LocationID == pLocID && s.CustomerID > 0 && s.SqFeet > 1
                                     select new { s.SqFeet }).ToList();
                    foreach (var qry in qryTotOcc)
                    {
                        totalOccList.Add(qry.SqFeet);
                    }
                    decimal totalOcc = totalOccList.Sum();

                    //-

                    var qryAvail = (from l in context.Locations
                                    where l.LocationID == pLocID
                                    select new { l.TotalFloorArea }).FirstOrDefault();
                    if (qryAvail != null)
                    {
                        decimal total = qryAvail.TotalFloorArea;
                        totavailable = total - totalOcc;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totavailable;
        }
        public static int getCompanyID(int pContractClauseID)
        {
            int compid = 0;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCont = (from c in context.ContractClosures
                               where c.ContractClosureID == pContractClauseID
                               select new { c.CompanyID }).FirstOrDefault();
                if (qryCont != null)
                {
                    compid = qryCont.CompanyID;
                }
            }

            return compid;

        }

        public static int getLocationID(int pContractClauseID)
        {
            int locid = 0;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCont = (from c in context.ContractClosures
                               where c.ContractClosureID == pContractClauseID
                               select new { c.LocationID }).FirstOrDefault();
                if (qryCont != null)
                {
                    locid = qryCont.LocationID;
                }
            }

            return locid;
        }

        public static int getLevelID(int pContractClauseID)
        {
            int levelid = 0;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCont = (from c in context.ContractClosures
                               where c.ContractClosureID == pContractClauseID
                               select new { c.LevelID }).FirstOrDefault();
                if (qryCont != null)
                {
                    levelid = qryCont.LevelID;
                }
            }

            return levelid;
        }

        public static int getShopID(int pContractClauseID)
        {
            int shopid = 0;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCont = (from c in context.ContractClosures
                               where c.ContractClosureID == pContractClauseID
                               select new { c.ShopID }).FirstOrDefault();
                if (qryCont != null)
                {
                    shopid = qryCont.ShopID;
                }
            }


            return shopid;

        }

        public static bool IsTaxCustomer(int Gcustid)
        {
            bool bIsTaxCustome = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryTaxCust = (from ct in context.Customer_Taxes
                                  where ct.CustomerID == Gcustid
                                  select ct).ToList();
                if (qryTaxCust.Count > 0)
                {
                    bIsTaxCustome = true;
                }
                else
                {
                    bIsTaxCustome = false;
                }
            }


            return bIsTaxCustome;
        }
        public static string getShopName(int pContractClauseID)
        {
            string shopname = "";
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCont = (from c in context.ContractClosures
                               where c.ContractClosureID == pContractClauseID
                               select new { c.ShopName }).FirstOrDefault();
                if (qryCont != null)
                {
                    shopname = qryCont.ShopName;
                }
            }
            return shopname;
        }

        public static string getShopNo(int pContractClauseID)
        {
            string shopno = "";
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCont = (from c in context.ContractClosures
                               where c.ContractClosureID == pContractClauseID
                               select new { c.ShopNo }).FirstOrDefault();
                if (qryCont != null)
                {
                    shopno = qryCont.ShopNo;
                }
            }
            return shopno;
        }

        public static bool IsMandatory(int pTaxID)
        {
            bool ismandatory = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryTax = (from t in context.Taxes
                              where t.TaxID == pTaxID
                              select new { t.IsMandatory }).FirstOrDefault();
                if (qryTax != null)
                {
                    ismandatory = qryTax.IsMandatory;
                }

            }

            return ismandatory;
        }

        public static bool IsAuthenticated(string pUserName)
        {
            bool authenticated = false;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryUserFound = (from u in context.Permission_Users
                                    select new { u.UserName }).ToList();
                if (qryUserFound.Count > 0)
                {
                    authenticated = true;
                }

            }

            return authenticated;
        }

        public static bool IsAuthUserandPass(string pUserName, string pPass)
        {
            bool authenticated = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                ////u.Discontinued == false , added for block inactive users..18May2015

                var qryUser = (from u in context.Permission_Users
                               where u.UserName == pUserName && u.Password == pPass && u.Discontinued == false
                               select u).FirstOrDefault();
                if (qryUser != null)
                {
                    LoggedSystemUserName = qryUser.UserName;
                    LoggedDNSUserName = qryUser.DNSUserName;
                    LoggedUserID = qryUser.UserID;
                    authenticated = true;

                }

            }

            return authenticated;

        }

        public static bool IsWindowsUserExist(string pUserName)
        {
            bool userexist = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryUserFound = (from u in context.Permission_Users
                                    where u.DNSUserName == pUserName
                                    select u).FirstOrDefault();
                if (qryUserFound != null)
                {
                    userexist = true;
                    LoggedSystemUserName = qryUserFound.UserName;
                    LoggedDNSUserName = qryUserFound.DNSUserName;
                    LoggedUserID = qryUserFound.UserID;

                }
                else { userexist = false; }

            }

            return userexist;

        }

        public static bool IsOtherTaxApplicableForUtility(int pShopUtilityReadingID)
        {
            bool IsTaxApply = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                //var qryTax = (from sur in context.Shops_UtilityReadings
                //              join ur in context.UtlityRate_Details on sur.UtilityRateID equals ur.UtilityRateID
                //              join t in context.Taxes on ur.TaxID equals t.TaxID
                //              where sur.ShopUtilityReadingID == pShopUtilityReadingID && t.IsMandatory == false
                //              select new { t.TaxID, t.IsMandatory }).ToList();
               // var qryTax= context.view_aplicable_tax_utility

                var qryTax = (from vtax in context.view_aplicable_tax_utility
                           where vtax.ShopUtilityReadingID == pShopUtilityReadingID && vtax.IsMandatory == false
                           select new { vtax.IsMandatory,vtax.TaxID}).ToList();

                if (qryTax.Count > 0)
                {
                    IsTaxApply = true;
                }
            }

            return IsTaxApply;

        }

      
        public static bool IsMandatoryTaxApplicableForUtility(int pShopUtilityReadingID)
        {
            bool IsMandatoryTaxApply = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
              
                //var qryTax = (from sur in context.Shops_UtilityReadings
                //              join ur in context.UtlityRate_Details on sur.UtilityRateID equals ur.UtilityRateID
                //              join t in context.Taxes on ur.TaxID equals t.TaxID
                //              where sur.ShopUtilityReadingID == pShopUtilityReadingID && t.IsMandatory == true
                //              select new { t.TaxID, t.IsMandatory }).ToList();
                var qryTax = (from vtax in context.view_aplicable_tax_utility
                              where vtax.ShopUtilityReadingID == pShopUtilityReadingID && vtax.IsMandatory == true
                              select new { vtax.IsMandatory, vtax.TaxID }).ToList();
                if (qryTax.Count > 0)
                {
                    IsMandatoryTaxApply = true;
                }
            }

            return IsMandatoryTaxApply;

        }
        public static string getCustomerName(int pContractClauseID)
        {
            string customerName = "";
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCont = (from c in context.ContractClosures
                               join ec in context.Extended_Customers on c.ExtendedCustomerID equals ec.ExtendedCustomerID
                               join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                               where c.ContractClosureID == pContractClauseID
                               select new { gc.CustomerName }).FirstOrDefault();
                if (qryCont != null)
                {
                    customerName = qryCont.CustomerName;
                }
            }
            return customerName;

        }

        public static string getCustomerAddress(int pContractClauseID)
        {
            string customerAdd = "";
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                // var qryCont = (from c in context.ContractClosures
                //                where c.ContractClosureID == pContractClauseID
                //                select new { c.CustomerAddress }).FirstOrDefault();
                ////var globalCustomer;

                // //customerAdd = qryCont.CustomerAddress;

                //if (qryCont != null)
                //{
                //    if (qryCont.CustomerAddress == null)
                //{
                var globalCustomer = (from c in context.ContractClosures
                                      join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                      join gc in context.Global_Customers on exc.CustomerID equals gc.CustomerID
                                      where c.ContractClosureID == pContractClauseID
                                      select new { gc.CompanyAddress }).FirstOrDefault();
                customerAdd = globalCustomer.CompanyAddress;

                //}

                //}
            }
            return customerAdd;
        }
        public static bool IsTaxCalApplicable(int contractClauseID)
        {
            bool IsTaxApply = false;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryTaxApply = (from c in context.ContractClosures
                                   join ec in context.Extended_Customers on c.ExtendedCustomerID equals ec.ExtendedCustomerID
                                   where c.ContractClosureID == contractClauseID
                                   select new { ec.IsTaxApplicable }).FirstOrDefault();
                if (qryTaxApply != null)
                {
                    IsTaxApply = qryTaxApply.IsTaxApplicable;
                }
            }

            return IsTaxApply;

        }

        public static bool IsTaxCalAppllicableByShopUtilityReadingID(int shoputilityReadingID)
        {
            bool taxApply = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryTaxApply = (from u in context.Shops_UtilityReadings
                                   join urd in context.UtlityRate_Details on u.UtilityRateID equals urd.UtilityRateID
                                   join t in context.Taxes on urd.TaxID equals t.TaxID
                                   where t.IsMandatory == true
                                   select urd).ToList();
                if (qryTaxApply.Count > 0)
                {
                    taxApply = true;
                }

            }

            return taxApply;
        }

        public static int getExtendedCustomerID(int pContractClauseID)
        {
            int extendedCustomerID = 0;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCust = (from c in context.ContractClosures
                               where c.ContractClosureID == pContractClauseID
                               select new { c.ExtendedCustomerID }).FirstOrDefault();
                if (qryCust != null)
                {
                    extendedCustomerID = qryCust.ExtendedCustomerID;
                }

            }

            return extendedCustomerID;


        }

        public static string LoggedSystemUserName { get; set; }
        public static string LoggedDNSUserName { get; set; }
        public static string MachineName { get; set; }
        public static int LoggedUserID { get; set; }




        public static void updateShopLastReading(int pShopUtilityReadingID, decimal pendReading)
        {
            try
            {
                using (TransactionScope trs = new TransactionScope())
                {
                    using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {
                        var qryShopUR = (from ur in context.Shops_UtilityReadings
                                         where ur.ShopUtilityReadingID == pShopUtilityReadingID
                                         select ur).FirstOrDefault();
                        if (qryShopUR != null)
                        {
                            qryShopUR.LastReading = pendReading;
                        }

                        context.SaveChanges();
                        trs.Complete();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void initUserPermission(xHomeScreen homescreen)
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    for (int i = 0; i < homescreen.Ribbon.Items.Count; i++)
                    {
                        ////string menuName = homescreen.Ribbon.Items[i].Caption.ToString();////19June2014..roshan..implement below line to avoid permision issue
                        string menuName = homescreen.Ribbon.Items[i].Description.Trim();

                        //if (menuName == "Invoice Summery") 
                        //{

                        //}
                        var qryUserForms = (from u in context.Permission_UserForms
                                            join up in context.Permission_Forms on u.FormID equals up.FormID
                                            join r in context.Permission_Roles on u.RoleID equals r.RoleID
                                            join usr in context.Permission_Users on r.RoleID equals usr.RoleID
                                            where usr.UserID == LoggedUserID && up.MenuName == menuName
                                            select new { u.R, up.MenuName }).FirstOrDefault();
                        if (qryUserForms != null)
                        {
                            if (qryUserForms.R == false)
                            {
                                homescreen.Ribbon.Items[i].Enabled = false;
                            }
                            else
                            {
                                homescreen.Ribbon.Items[i].Enabled = true;
                            }
                        }
                        else
                        {
                            homescreen.Ribbon.Items[i].Enabled = false;////19June2014..roshan
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static List<DataTier.ReportClasses.ShopOccupancy> MisShopOccupancy(int compid, int locid, DateTime currentDate, DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = null)
        {
            List<DataTier.ReportClasses.ShopOccupancy> shopocclist = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {
                DateTime dateFrom = currentDate.AddMonths(-1).AddDays(1);


                decimal totalInLoc = getTotalSqFtInLocation(compid, locid, currentDate);
                decimal totalInComp = getTotalSqFtInCompany(compid, currentDate);

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryCont = (from c in context.ContractClosures
                                   join s in context.Shops on c.ShopID equals s.ShopID
                                   join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                   join co in context.Companies on c.CompanyID equals co.CompanyID
                                   join l in context.Locations on c.LocationID equals l.LocationID
                                   join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
                                   join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                   join gc in context.Global_Customers on exc.CustomerID equals gc.CustomerID
                                   orderby c.CompanyID, c.LocationID, c.LevelID, c.ShopNo
                                   where c.IsCancelled == false && c.IsProcessed == true && c.IsPromotion == false && c.CompanyID == compid && c.LocationID == locid
                                   select new { c.ContractClosureID, c.CompanyID, c.LocationID, c.LevelID, c.FloorArea, c.ShopID, c.ShopNo, c.ShopName, gc.CustomerName, co.CompanyCode, co.CompanyName, l.LocationCode, l.LocationName, lvl.LevelName, c.IsTerminated, c.TerminatedDate, ra.RentAreaTypeName, SAPCustomerCode = exc.SAPAlternateCode, c.IsNew, c.IsRenew, c.IsActive, c.IsPromotion, c.IsProcessed }).Distinct().ToList();
                    List<decimal> total = new List<decimal>();
                    //WaitForm1 x = new WaitForm1();
                    //x.SetMaximumValue(qryCont.Count);

                    foreach (var qry in qryCont)
                    {

                        DateTime contStartDate = getContStartDate(qry.ContractClosureID);
                        DateTime contExpDate = getContExpiryDate(qry.ContractClosureID);


                        if (contStartDate <= currentDate && contExpDate >= currentDate && qry.IsPromotion == false && qry.IsProcessed == true)
                        {
                            if (qry.IsTerminated == true && qry.TerminatedDate >= currentDate)
                            {
                                DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();

                                shopOcc.CompanyName = qry.CompanyName;
                                shopOcc.LocationName = qry.LocationName;
                                shopOcc.LevelName = qry.LevelName;
                                shopOcc.CompanyCode = qry.CompanyCode;
                                shopOcc.LocationCode = qry.LocationCode;
                                if (qry.FloorArea == 1)
                                {
                                    shopOcc.OccupiedAreaSqFt = 0;
                                }
                                else
                                {
                                    shopOcc.OccupiedAreaSqFt = qry.FloorArea;
                                }
                                shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, currentDate);
                                shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, currentDate);
                                shopOcc.SAPCustomerCode = qry.SAPCustomerCode;
                                shopOcc.CustomerName = qry.CustomerName;
                                shopOcc.ShopNo = qry.ShopNo;
                                shopOcc.ShopID = qry.ShopID;
                                shopOcc.RentAreaType = qry.RentAreaTypeName;

                                shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, currentDate);
                                shopOcc.TotalSqFtInCompany = totalInComp;
                                shopOcc.TotalSqFtInLocation = totalInLoc;
                                if (splashScreenManager1 != null)
                                {
                                    if (splashScreenManager1.IsSplashFormVisible == true)
                                    {
                                        splashScreenManager1.SetWaitFormDescription(qry.ShopNo);
                                    }
                                }

                                shopocclist.Add(shopOcc);
                            }
                            else if (qry.IsTerminated == false)
                            {
                                DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                                shopOcc.CompanyName = qry.CompanyName;
                                shopOcc.LocationName = qry.LocationName;
                                shopOcc.LevelName = qry.LevelName;
                                shopOcc.CompanyCode = qry.CompanyCode;
                                shopOcc.LocationCode = qry.LocationCode;
                                if (qry.FloorArea == 1)
                                {
                                    shopOcc.OccupiedAreaSqFt = 0;
                                }
                                else
                                {
                                    shopOcc.OccupiedAreaSqFt = qry.FloorArea;
                                }
                                shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, currentDate);
                                shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, currentDate);
                                shopOcc.SAPCustomerCode = qry.SAPCustomerCode;
                                shopOcc.CustomerName = qry.CustomerName;
                                shopOcc.ShopNo = qry.ShopNo;
                                shopOcc.ShopID = qry.ShopID;
                                shopOcc.RentAreaType = qry.RentAreaTypeName;

                                shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, currentDate);
                                shopOcc.TotalSqFtInCompany = totalInComp;
                                shopOcc.TotalSqFtInLocation = totalInLoc;

                                if (splashScreenManager1 != null)
                                {
                                    if (splashScreenManager1.IsSplashFormVisible == true)
                                    {
                                        splashScreenManager1.SetWaitFormDescription(qry.ShopNo);
                                    }
                                }

                                shopocclist.Add(shopOcc);

                            }
                        }


                        else
                        {
                            // for the contracts which are expired but still in active 
                            if (contStartDate <= currentDate && qry.IsTerminated == false && qry.IsPromotion == false && qry.IsProcessed == true)
                            {
                                DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                                shopOcc.CompanyName = qry.CompanyName;
                                shopOcc.LocationName = qry.LocationName;
                                shopOcc.LevelName = qry.LevelName;
                                shopOcc.CompanyCode = qry.CompanyCode;
                                shopOcc.LocationCode = qry.LocationCode;
                                if (qry.FloorArea == 1)
                                {
                                    shopOcc.OccupiedAreaSqFt = 0;
                                }
                                else
                                {
                                    shopOcc.OccupiedAreaSqFt = qry.FloorArea;
                                }
                                shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, currentDate);
                                shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, currentDate);
                                shopOcc.SAPCustomerCode = qry.SAPCustomerCode;
                                shopOcc.CustomerName = qry.CustomerName;
                                shopOcc.ShopNo = qry.ShopNo;
                                shopOcc.ShopID = qry.ShopID;
                                shopOcc.RentAreaType = qry.RentAreaTypeName;


                                shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, currentDate);
                                shopOcc.TotalSqFtInCompany = totalInComp;
                                shopOcc.TotalSqFtInLocation = totalInLoc;

                                if (splashScreenManager1 != null)
                                {
                                    if (splashScreenManager1.IsSplashFormVisible == true)
                                    {
                                        splashScreenManager1.SetWaitFormDescription(qry.ShopNo);
                                    }
                                }
                                shopocclist.Add(shopOcc);


                            }

                        }


                        Application.DoEvents();
                        //x.PerformStep();
                    }

                    decimal totalsqft = total.Sum();
                }

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return shopocclist;
        }
        public static decimal MisShopOccupancy_Summmary(int locid, DateTime pDateAsAt, DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = null)
        {
            //List<DataTier.ReportClasses.ShopOccupancy> shopocclist = new List<DataTier.ReportClasses.ShopOccupancy>();
            decimal totalval = 0;
            List<decimal> totalValList = new List<decimal>();

            try
            {
                DateTime dateFrom = pDateAsAt.AddMonths(-1).AddDays(1);
                //pDateAsAt = pDateAsAt.AddMonths(1).AddDays(-1);


                //decimal totalInLoc = getTotalSqFtInLocation(compid, locid, currentDate);
                //decimal totalInComp = getTotalSqFtInCompany(compid, currentDate);

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryCont = (from c in context.ContractClosures
                                   join s in context.Shops on c.ShopID equals s.ShopID
                                   join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                   join co in context.Companies on c.CompanyID equals co.CompanyID
                                   join l in context.Locations on c.LocationID equals l.LocationID
                                   join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
                                   join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                   join gc in context.Global_Customers on exc.CustomerID equals gc.CustomerID
                                   orderby c.CompanyID, c.LocationID, c.LevelID, c.ShopNo
                                   where c.IsCancelled == false && c.IsProcessed == true && c.IsPromotion == false && c.LocationID == locid
                                   select new { c.ContractClosureID, c.CompanyID, c.LocationID, c.LevelID, c.FloorArea, c.ShopID, c.ShopNo, c.ShopName, gc.CustomerName, co.CompanyCode, co.CompanyName, l.LocationCode, l.LocationName, lvl.LevelName, c.IsTerminated, c.TerminatedDate, ra.RentAreaTypeName, SAPCustomerCode = exc.SAPAlternateCode, c.IsNew, c.IsRenew, c.IsActive, c.IsPromotion, c.IsProcessed }).Distinct().ToList();
                    List<decimal> total = new List<decimal>();
                    //WaitForm1 x = new WaitForm1();
                    //x.SetMaximumValue(qryCont.Count);

                    foreach (var qry in qryCont)
                    {

                        DateTime contStartDate = getContStartDate(qry.ContractClosureID);
                        DateTime contExpDate = getContExpiryDate(qry.ContractClosureID);


                        if (contStartDate <= pDateAsAt && contExpDate >= pDateAsAt && qry.IsPromotion == false && qry.IsProcessed == true)
                        {
                            if (qry.IsTerminated == true && qry.TerminatedDate >= pDateAsAt)
                            {
                                DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();

                                shopOcc.CompanyName = qry.CompanyName;
                                shopOcc.LocationName = qry.LocationName;
                                shopOcc.LevelName = qry.LevelName;
                                shopOcc.CompanyCode = qry.CompanyCode;
                                shopOcc.LocationCode = qry.LocationCode;
                                if (qry.FloorArea == 1)
                                {
                                    shopOcc.OccupiedAreaSqFt = 0;
                                }
                                else
                                {
                                    shopOcc.OccupiedAreaSqFt = qry.FloorArea;
                                }
                                shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, pDateAsAt);
                                shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, pDateAsAt);
                                shopOcc.SAPCustomerCode = qry.SAPCustomerCode;
                                shopOcc.CustomerName = qry.CustomerName;
                                shopOcc.ShopNo = qry.ShopNo;
                                shopOcc.ShopID = qry.ShopID;
                                shopOcc.RentAreaType = qry.RentAreaTypeName;

                                //shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, currentDate);
                                //shopOcc.TotalSqFtInCompany = totalInComp;
                                //shopOcc.
                                //TotalSqFtInLocation = totalInLoc;
                                //totalValList.Add(qry.FloorArea);
                                totalValList.Add(shopOcc.OccupiedAreaSqFt);
                                //shopocclist.Add(shopOcc);
                            }
                            else if (qry.IsTerminated == false)
                            {
                                DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                                shopOcc.CompanyName = qry.CompanyName;
                                shopOcc.LocationName = qry.LocationName;
                                shopOcc.LevelName = qry.LevelName;
                                shopOcc.CompanyCode = qry.CompanyCode;
                                shopOcc.LocationCode = qry.LocationCode;
                                if (qry.FloorArea == 1)
                                {
                                    shopOcc.OccupiedAreaSqFt = 0;
                                }
                                else
                                {
                                    shopOcc.OccupiedAreaSqFt = qry.FloorArea;
                                }
                                shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, pDateAsAt);
                                shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, pDateAsAt);
                                shopOcc.SAPCustomerCode = qry.SAPCustomerCode;
                                shopOcc.CustomerName = qry.CustomerName;
                                shopOcc.ShopNo = qry.ShopNo;
                                shopOcc.ShopID = qry.ShopID;
                                shopOcc.RentAreaType = qry.RentAreaTypeName;

                                //shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, currentDate);
                                //shopOcc.TotalSqFtInCompany = totalInComp;
                                //shopOcc.TotalSqFtInLocation = totalInLoc;

                                if (splashScreenManager1 != null)
                                {
                                    if (splashScreenManager1.IsSplashFormVisible == true)
                                    {
                                        splashScreenManager1.SetWaitFormDescription(qry.ShopNo);
                                    }
                                }

                                totalValList.Add(shopOcc.OccupiedAreaSqFt);
                                //shopocclist.Add(shopOcc);

                            }
                        }


                        else
                        {
                            // for the contracts which are expired but still in active 
                            if (contStartDate <= pDateAsAt && qry.IsTerminated == false && qry.IsPromotion == false && qry.IsProcessed == true)
                            {
                                DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                                shopOcc.CompanyName = qry.CompanyName;
                                shopOcc.LocationName = qry.LocationName;
                                shopOcc.LevelName = qry.LevelName;
                                shopOcc.CompanyCode = qry.CompanyCode;
                                shopOcc.LocationCode = qry.LocationCode;
                                if (qry.FloorArea == 1)
                                {
                                    shopOcc.OccupiedAreaSqFt = 0;
                                }
                                else
                                {
                                    shopOcc.OccupiedAreaSqFt = qry.FloorArea;
                                }
                                shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, pDateAsAt);
                                shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, pDateAsAt);
                                shopOcc.SAPCustomerCode = qry.SAPCustomerCode;
                                shopOcc.CustomerName = qry.CustomerName;
                                shopOcc.ShopNo = qry.ShopNo;
                                shopOcc.ShopID = qry.ShopID;
                                shopOcc.RentAreaType = qry.RentAreaTypeName;


                                //shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, pDateAsAt);
                                //shopOcc.TotalSqFtInCompany = totalInComp;
                                //shopOcc.TotalSqFtInLocation = totalInLoc;


                                //shopocclist.Add(shopOcc);
                                totalValList.Add(shopOcc.OccupiedAreaSqFt);


                            }

                        }


                        Application.DoEvents();
                        //x.PerformStep();
                    }

                    decimal totalsqft = totalValList.Sum();
                    totalval = totalsqft;
                }

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalval;
        }
        private static DateTime getContExpiryDate(int pContractID)
        {
            DateTime expDate = DateTime.Now.Date;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryRentScheme = (from c in context.Contract_RentSchemes
                                         orderby c.ToDate ascending
                                         where c.ContractClosureID == pContractID
                                         select new { c.ToDate }).AsEnumerable().LastOrDefault();
                    if (qryRentScheme != null)
                    {
                        expDate = qryRentScheme.ToDate;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            return expDate;


        }

        private static DateTime getContStartDate(int pContractID)
        {
            DateTime startDate = DateTime.Now.Date;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryRentScheme = (from c in context.Contract_RentSchemes
                                         orderby c.ToDate ascending
                                         where c.ContractClosureID == pContractID
                                         select new { c.FromDate }).FirstOrDefault();
                    if (qryRentScheme != null)
                    {
                        startDate = qryRentScheme.FromDate;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            return startDate;
        }

        private static decimal getTotalAreaAsAt(int pShopID, DateTime pCurrentDate)
        {
            decimal totArea = 0;
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    Shop_Details shopObj = (from d in context.Shop_Details
                                            where d.ShopID == pShopID && d.ActiveFrom <= pCurrentDate && d.IsActive == true
                                            select d).FirstOrDefault();
                    if (shopObj == null)
                    {
                        Shop_Details shopObj2 = (from d in context.Shop_Details
                                                 where d.ShopID == pShopID && d.ActiveFrom <= pCurrentDate
                                                 select d).AsEnumerable().LastOrDefault();

                        if (shopObj2 != null)
                        {
                            totArea = shopObj2.SqFeet;
                        }
                    }
                    else
                    {
                        totArea = shopObj.SqFeet;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return totArea;

        }

        public static decimal getTotalSqFtInLocation(int pCompanyID, int pLocationID, DateTime currentDate)
        {
            decimal totalSqft = 0;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    List<decimal> total = new List<decimal>();

                    List<Shop> shopList = (from s in context.Shops
                                           join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                           where s.CompanyID == pCompanyID && s.LocationID == pLocationID && s.SqFeet > 1 && ra.IsAdvertisement == false
                                           select s).ToList();
                    foreach (var qry in shopList)
                    {
                        decimal sqft = getTotalAreaAsAt(qry.ShopID, currentDate);
                        total.Add(sqft);
                    }


                    totalSqft = total.Sum();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return totalSqft;
        }

        private static decimal getTotalSqFtInCompany(int pCompanyID, DateTime currentDate)
        {
            decimal totalSqft = 0;
            DateTime dateFrom = currentDate.AddMonths(-1).AddDays(1);
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    List<decimal> total = new List<decimal>();

                    List<Shop> shopList;
                    shopList = (from s in context.Shops
                                join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                where s.CompanyID == pCompanyID && s.SqFeet > 1 && ra.IsAdvertisement == false
                                select s).ToList();
                    foreach (var qry in shopList)
                    {
                        decimal sqft = getTotalAreaAsAt(qry.ShopID, currentDate);
                        total.Add(sqft);
                    }

                    totalSqft = total.Sum();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return totalSqft;
        }

        private static decimal getTotalSqFtInlevel(int pCompanyID, int pLocationID, int pLevelID, DateTime currentDate)
        {
            decimal totalSqft = 0;

            //DateTime dateFrom = currentDate.AddMonths(-1).AddDays(1);
            //try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    List<decimal> total = new List<decimal>();
                    List<Shop> shopList;
                    shopList = (from s in context.Shops
                                join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                where s.CompanyID == pCompanyID && s.LocationID == pLocationID && s.LevelID == pLevelID && s.SqFeet > 1 && ra.IsAdvertisement == false
                                select s).ToList();
                    foreach (var qry in shopList)
                    {
                        //decimal totalSqFtAsAt = getOccuiedAreaAsAt(qry.ShopID, currentDate);

                        decimal occArea = 0;
                        Shop_Details qryDet1 = (from d in context.Shop_Details
                                                where d.ShopID == qry.ShopID && d.ActiveFrom <= currentDate && d.IsActive == true
                                                select d).FirstOrDefault();
                        if (qryDet1 == null)
                        {
                            Shop_Details qryDet2 = (from d in context.Shop_Details
                                                    where d.ShopID == qry.ShopID && d.ActiveFrom >= currentDate && d.ActiveTo <= currentDate
                                                    select d).AsEnumerable().LastOrDefault();

                            if (qryDet2 != null)
                            {
                                occArea = qryDet2.SqFeet;
                            }
                        }
                        else
                        {
                            occArea = qryDet1.SqFeet;
                        }


                        total.Add(occArea);
                    }

                    totalSqft = total.Sum();

                }

            }
            //catch (Exception ex)
            //{
            //    throw ex;
            //}


            return totalSqft;


        }



        private static decimal getActiveSCByShopID(int pShopID, DateTime currentDate)
        {
            decimal serviceCharge = 0;


            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryCont = (from c in context.ContractClosures
                                   join cr in context.Contract_RentSchemes on c.ContractClosureID equals cr.ContractClosureID
                                   where c.ShopID == pShopID && cr.FromDate <= currentDate && cr.ToDate >= currentDate
                                   select new { cr.SCPerSqFeet }).FirstOrDefault();

                    if (qryCont != null)
                    {
                        serviceCharge = qryCont.SCPerSqFeet;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return serviceCharge;


        }

        private static decimal getActiveRentByShopID(int pShopID, DateTime currentDate)
        {
            decimal rentPerSqft = 0;
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    //Contract_RentSchemes oCRentScheme;

                    var qryCont = (from c in context.ContractClosures
                                   join cr in context.Contract_RentSchemes on c.ContractClosureID equals cr.ContractClosureID
                                   where c.ShopID == pShopID && cr.FromDate <= currentDate && cr.ToDate >= currentDate
                                   select new { cr.RentPerSqFeet }).FirstOrDefault();

                    if (qryCont != null)
                    {
                        rentPerSqft = qryCont.RentPerSqFeet;

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rentPerSqft;


        }

        public static List<DataTier.ReportClasses.ShopOccupancy> MisShopUnOccupancy(int comps, int locs, DateTime pDateAsAt, DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = null)
        {
            List<DataTier.ReportClasses.ShopOccupancy> shopocclist = new List<DataTier.ReportClasses.ShopOccupancy>();
            List<DataTier.ReportClasses.ShopOccupancy> ShopOccupancyList = new List<DataTier.ReportClasses.ShopOccupancy>();
            try
            {
                //List<int> intComps = comps.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                //List<int> intLocs = locs.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                DateTime dateFrom = pDateAsAt.AddMonths(-1).AddDays(1);
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    // list of shops which are not in the contracts
                    List<int> NotAssignedshopList = new List<int>();
                    NotAssignedshopList = getShopListAsAt(pDateAsAt, comps, locs);

                    var qryShopsNotAssigned = (from s1 in NotAssignedshopList
                                               join s in context.Shops on s1 equals s.ShopID
                                               join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                               join c in context.Companies on s.CompanyID equals c.CompanyID
                                               join l in context.Locations on s.LocationID equals l.LocationID
                                               join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                                               where s.CustomerID == 0 && s.CompanyID == comps && s.LocationID == locs && ra.IsAdvertisement == false
                                               select new { c.CompanyID, c.CompanyCode, c.CompanyName, l.LocationID, l.LocationCode, l.LocationName, lvl.LevelID, lvl.LevelName, s.ShopNo, s.SqFeet, s.ShopID, ra.RentAreaTypeName }).ToList();

                    foreach (var qry in qryShopsNotAssigned)
                    {
                        DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                        shopOcc.CompanyCode = qry.CompanyCode;
                        shopOcc.CompanyName = qry.CompanyName;
                        shopOcc.LocationCode = qry.LocationCode;
                        shopOcc.LocationName = qry.LocationName;
                        shopOcc.LevelName = qry.LevelName;
                        if (qry.SqFeet == 1)
                        {
                            shopOcc.OccupiedAreaSqFt = 0;
                        }
                        else
                        {
                            decimal sqft = getTotalAreaAsAt(qry.ShopID, pDateAsAt);
                            shopOcc.OccupiedAreaSqFt = sqft;
                        }
                        shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, pDateAsAt);
                        shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, pDateAsAt);
                        DateTime? lastDate = getLastContractDateOfShop(qry.ShopID);
                        int nosdays = 0;
                        if (lastDate == DateTime.MinValue)
                        { lastDate = null; }
                        else
                        {
                            nosdays = pDateAsAt.Date.Subtract(lastDate.Value).Days;
                            shopOcc.UnoccupiedFrom = lastDate.Value.ToString("dd/MM/yyyy");
                            shopOcc.UnOccupiedMonth = nosdays;

                            shopOcc.LossOfRentperSqFt = shopOcc.RentPerSqFt;
                            shopOcc.LossOfSCperSqFt = shopOcc.ScPerSqFt;
                        }
                        shopOcc.SAPCustomerCode = "-";
                        shopOcc.CustomerName = "-";
                        shopOcc.ShopNo = qry.ShopNo;
                        shopOcc.RentAreaType = qry.RentAreaTypeName;
                        shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, pDateAsAt);
                        shopOcc.TotalSqFtInCompany = getTotalSqFtInCompany(qry.CompanyID, pDateAsAt);
                        shopOcc.TotalSqFtInLocation = getTotalSqFtInLocation(qry.CompanyID, qry.LocationID, pDateAsAt);

                        if (splashScreenManager1 != null)
                        {
                            if (splashScreenManager1.IsSplashFormVisible == true)
                            {
                                splashScreenManager1.SetWaitFormDescription(qry.ShopNo);
                            }
                        }
                        shopocclist.Add(shopOcc);

                    }

                    ///--


                    //ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisShopOccupancy(comps, locs, pDateAsAt);

                    var qryContTerminated = (from c in context.ContractClosures
                                             where c.IsTerminated == true && c.TerminatedDate <= pDateAsAt && c.CompanyID == comps && c.LocationID == locs
                                             select c).ToList();
                    List<int> terminatedShopList = new List<int>();


                    foreach (var qry in qryContTerminated)
                    {
                        ////search through active contracts 

                        DateTime contStartDate = getContStartDate(qry.ContractClosureID);
                        DateTime contExpDate = getContExpiryDate(qry.ContractClosureID);
                        var qryCont = (from c in context.ContractClosures
                                       join r in context.Contract_RentSchemes on c.ContractClosureID equals r.ContractClosureID
                                       where c.ShopID == qry.ShopID && r.FromDate <= pDateAsAt && c.IsTerminated == false
                                       select new { c.ShopID }).ToList();
                        if (qryCont.Count == 0)
                        {
                            terminatedShopList.Add(qry.ShopID);
                        }
                    }

                    // search through active contracts 
                    //var qryCont = (from c in context.ContractClosures 
                    //               where c.IsTerminated == false && c.CompanyID ==comps && c.LocationID ==locs 




                    var qryShops = (from s1 in terminatedShopList
                                    join s in context.Shops on s1 equals s.ShopID
                                    join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                    join c in context.Companies on s.CompanyID equals c.CompanyID
                                    join l in context.Locations on s.LocationID equals l.LocationID
                                    join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                                    where s.CustomerID == 0 && s.CompanyID == comps && s.LocationID == locs && ra.IsAdvertisement == false
                                    select new { c.CompanyID, c.CompanyCode, c.CompanyName, l.LocationID, l.LocationCode, l.LocationName, lvl.LevelID, lvl.LevelName, s.ShopNo, s.SqFeet, s.ShopID, ra.RentAreaTypeName }).ToList();
                    foreach (var qry in qryShops)
                    {
                        DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                        shopOcc.CompanyCode = qry.CompanyCode;
                        shopOcc.CompanyName = qry.CompanyName;
                        shopOcc.LocationCode = qry.LocationCode;
                        shopOcc.LocationName = qry.LocationName;
                        shopOcc.LevelName = qry.LevelName;
                        if (qry.SqFeet == 1)
                        {
                            shopOcc.OccupiedAreaSqFt = 0;
                        }
                        else
                        {
                            decimal sqft = getTotalAreaAsAt(qry.ShopID, pDateAsAt);
                            shopOcc.OccupiedAreaSqFt = sqft;
                        }
                        shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, pDateAsAt);
                        shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, pDateAsAt);
                        DateTime? lastDate = getLastContractDateOfShop(qry.ShopID);
                        int nosdays = 0;
                        if (lastDate == DateTime.MinValue)
                        { lastDate = null; }
                        else
                        {
                            nosdays = pDateAsAt.Date.Subtract(lastDate.Value).Days;
                            shopOcc.UnoccupiedFrom = lastDate.Value.ToString("dd/MM/yyyy");
                            shopOcc.UnOccupiedMonth = nosdays;

                            shopOcc.LossOfRentperSqFt = shopOcc.RentPerSqFt;
                            shopOcc.LossOfSCperSqFt = shopOcc.ScPerSqFt;
                        }
                        shopOcc.SAPCustomerCode = "-";
                        shopOcc.CustomerName = "-";
                        shopOcc.ShopNo = qry.ShopNo;
                        shopOcc.RentAreaType = qry.RentAreaTypeName;
                        shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, pDateAsAt);
                        shopOcc.TotalSqFtInCompany = getTotalSqFtInCompany(qry.CompanyID, pDateAsAt);
                        shopOcc.TotalSqFtInLocation = getTotalSqFtInLocation(qry.CompanyID, qry.LocationID, pDateAsAt);

                        if (splashScreenManager1 != null)
                        {
                            if (splashScreenManager1.IsSplashFormVisible == true)
                            {
                                splashScreenManager1.SetWaitFormDescription(qry.ShopNo);
                            }
                        }

                        shopocclist.Add(shopOcc);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return shopocclist;
        }

        public static decimal MisShopUnOccupancy_Summary(int comps, int locs, DateTime pDateAsAt, DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = null)
        {
            List<DataTier.ReportClasses.ShopOccupancy> shopocclist = new List<DataTier.ReportClasses.ShopOccupancy>();
            List<DataTier.ReportClasses.ShopOccupancy> ShopOccupancyList = new List<DataTier.ReportClasses.ShopOccupancy>();
            List<decimal> total = new List<decimal>();

            try
            {
                //List<int> intComps = comps.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                //List<int> intLocs = locs.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                DateTime dateFrom = pDateAsAt.AddMonths(-1).AddDays(1);
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    // list of shops which are not in the contracts
                    List<int> NotAssignedshopList = new List<int>();
                    NotAssignedshopList = getShopListAsAt(pDateAsAt, comps, locs);

                    var qryShopsNotAssigned = (from s1 in NotAssignedshopList
                                               join s in context.Shops on s1 equals s.ShopID
                                               join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                               join c in context.Companies on s.CompanyID equals c.CompanyID
                                               join l in context.Locations on s.LocationID equals l.LocationID
                                               join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                                               where s.CustomerID == 0 && s.CompanyID == comps && s.LocationID == locs && ra.IsAdvertisement == false
                                               select new { c.CompanyID, c.CompanyCode, c.CompanyName, l.LocationID, l.LocationCode, l.LocationName, lvl.LevelID, lvl.LevelName, s.ShopNo, s.SqFeet, s.ShopID, ra.RentAreaTypeName }).ToList();

                    foreach (var qry in qryShopsNotAssigned)
                    {
                        DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                        shopOcc.CompanyCode = qry.CompanyCode;
                        shopOcc.CompanyName = qry.CompanyName;
                        shopOcc.LocationCode = qry.LocationCode;
                        shopOcc.LocationName = qry.LocationName;
                        shopOcc.LevelName = qry.LevelName;
                        if (qry.SqFeet == 1)
                        {
                            shopOcc.OccupiedAreaSqFt = 0;
                        }
                        else
                        {
                            decimal sqft = getTotalAreaAsAt(qry.ShopID, pDateAsAt);
                            shopOcc.OccupiedAreaSqFt = sqft;
                        }
                        //shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, pDateAsAt);
                        //shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, pDateAsAt);
                        DateTime? lastDate = getLastContractDateOfShop(qry.ShopID);
                        int nosdays = 0;
                        if (lastDate == DateTime.MinValue)
                        { lastDate = null; }
                        else
                        {
                            nosdays = pDateAsAt.Date.Subtract(lastDate.Value).Days;
                            shopOcc.UnoccupiedFrom = lastDate.Value.ToString("dd/MM/yyyy");
                            shopOcc.UnOccupiedMonth = nosdays;

                            shopOcc.LossOfRentperSqFt = shopOcc.RentPerSqFt;
                            shopOcc.LossOfSCperSqFt = shopOcc.ScPerSqFt;
                        }
                        shopOcc.SAPCustomerCode = "-";
                        shopOcc.CustomerName = "-";
                        shopOcc.ShopNo = qry.ShopNo;
                        shopOcc.RentAreaType = qry.RentAreaTypeName;
                        //shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, pDateAsAt);
                        //shopOcc.TotalSqFtInCompany = getTotalSqFtInCompany(qry.CompanyID, pDateAsAt);
                        //shopOcc.TotalSqFtInLocation = getTotalSqFtInLocation(qry.CompanyID, qry.LocationID, pDateAsAt);

                        //if (splashScreenManager1 != null)
                        //{
                        //    if (splashScreenManager1.IsSplashFormVisible == true)
                        //    {
                        //        splashScreenManager1.SetWaitFormDescription(qry.ShopNo);
                        //    }
                        //}
                        //shopocclist.Add(shopOcc);
                        total.Add(shopOcc.OccupiedAreaSqFt);

                    }

                    ///--


                    //ShopOccupancyList = MMS.CustomClasses.cCommon_Functions.MisShopOccupancy(comps, locs, pDateAsAt);

                    var qryContTerminated = (from c in context.ContractClosures
                                             where c.IsTerminated == true && c.TerminatedDate <= pDateAsAt && c.CompanyID == comps && c.LocationID == locs
                                             select c).ToList();
                    List<int> terminatedShopList = new List<int>();


                    foreach (var qry in qryContTerminated)
                    {
                        ////search through active contracts 

                        DateTime contStartDate = getContStartDate(qry.ContractClosureID);
                        DateTime contExpDate = getContExpiryDate(qry.ContractClosureID);
                        var qryCont = (from c in context.ContractClosures
                                       join r in context.Contract_RentSchemes on c.ContractClosureID equals r.ContractClosureID
                                       where c.ShopID == qry.ShopID && r.FromDate <= pDateAsAt && c.IsTerminated == false
                                       select new { c.ShopID }).ToList();
                        if (qryCont.Count == 0)
                        {
                            terminatedShopList.Add(qry.ShopID);
                        }
                    }

                    // search through active contracts 
                    //var qryCont = (from c in context.ContractClosures 
                    //               where c.IsTerminated == false && c.CompanyID ==comps && c.LocationID ==locs 




                    var qryShops = (from s1 in terminatedShopList
                                    join s in context.Shops on s1 equals s.ShopID
                                    join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                    join c in context.Companies on s.CompanyID equals c.CompanyID
                                    join l in context.Locations on s.LocationID equals l.LocationID
                                    join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                                    where s.CustomerID == 0 && s.CompanyID == comps && s.LocationID == locs && ra.IsAdvertisement == false
                                    select new { c.CompanyID, c.CompanyCode, c.CompanyName, l.LocationID, l.LocationCode, l.LocationName, lvl.LevelID, lvl.LevelName, s.ShopNo, s.SqFeet, s.ShopID, ra.RentAreaTypeName }).ToList();
                    foreach (var qry in qryShops)
                    {
                        DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                        shopOcc.CompanyCode = qry.CompanyCode;
                        shopOcc.CompanyName = qry.CompanyName;
                        shopOcc.LocationCode = qry.LocationCode;
                        shopOcc.LocationName = qry.LocationName;
                        shopOcc.LevelName = qry.LevelName;
                        if (qry.SqFeet == 1)
                        {
                            shopOcc.OccupiedAreaSqFt = 0;
                        }
                        else
                        {
                            decimal sqft = getTotalAreaAsAt(qry.ShopID, pDateAsAt);
                            shopOcc.OccupiedAreaSqFt = sqft;
                        }
                        //shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, pDateAsAt);
                        //shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, pDateAsAt);
                        DateTime? lastDate = getLastContractDateOfShop(qry.ShopID);
                        int nosdays = 0;
                        if (lastDate == DateTime.MinValue)
                        { lastDate = null; }
                        else
                        {
                            nosdays = pDateAsAt.Date.Subtract(lastDate.Value).Days;
                            shopOcc.UnoccupiedFrom = lastDate.Value.ToString("dd/MM/yyyy");
                            shopOcc.UnOccupiedMonth = nosdays;

                            shopOcc.LossOfRentperSqFt = shopOcc.RentPerSqFt;
                            shopOcc.LossOfSCperSqFt = shopOcc.ScPerSqFt;
                        }
                        shopOcc.SAPCustomerCode = "-";
                        shopOcc.CustomerName = "-";
                        shopOcc.ShopNo = qry.ShopNo;
                        shopOcc.RentAreaType = qry.RentAreaTypeName;
                        //shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, pDateAsAt);
                        //shopOcc.TotalSqFtInCompany = getTotalSqFtInCompany(qry.CompanyID, pDateAsAt);
                        //shopOcc.TotalSqFtInLocation = getTotalSqFtInLocation(qry.CompanyID, qry.LocationID, pDateAsAt);

                        //if (splashScreenManager1 != null)
                        //{
                        //    if (splashScreenManager1.IsSplashFormVisible == true)
                        //    {
                        //        splashScreenManager1.SetWaitFormDescription(qry.ShopNo);
                        //    }
                        //}

                        //shopocclist.Add(shopOcc);
                        total.Add(shopOcc.OccupiedAreaSqFt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            decimal totalval = total.Sum();

            return totalval;
        }
        private static List<int> getShopListAsAt(DateTime currentDate, int pCompID, int pLocID)
        {

            List<int> shopList = new List<int>();

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                // search with inactive values 
                var qryShops = (from s in context.Shop_Details
                                join ss in context.Shops on s.ShopID equals ss.ShopID
                                where s.ActiveFrom <= currentDate && s.ActiveTo >= currentDate && s.IsActive == false && ss.LocationID == pLocID && ss.CompanyID == pCompID
                                select new { s.ShopID }).ToList();
                if (qryShops.Count > 0)
                {
                    foreach (var qry in qryShops)
                    {
                        var qryCont = (from c in context.ContractClosures
                                       where c.ShopID == qry.ShopID
                                       select new { c.ShopID }).ToList();
                        if (qryCont.Count == 0)
                        {
                            shopList.Add(qry.ShopID);
                        }
                    }

                }
                else
                {
                    var qryShops1 = (from s in context.Shop_Details
                                     join ss in context.Shops on s.ShopID equals ss.ShopID
                                     where s.ActiveFrom <= currentDate && s.IsActive == true && ss.LocationID == pLocID && ss.CompanyID == pCompID
                                     select new { s.ShopID }).ToList();
                    if (qryShops1.Count > 0)
                    {
                        foreach (var qry in qryShops1)
                        {

                            var qryCont = (from c in context.ContractClosures
                                           where c.ShopID == qry.ShopID
                                           select new { c.ShopID }).ToList();
                            if (qryCont.Count == 0)
                            {
                                shopList.Add(qry.ShopID);
                            }
                        }
                    }
                }
            }

            shopList = shopList.Distinct().ToList();

            return shopList;


        }

        private static DateTime? getLastContractDateOfShop(int pShopID)
        {
            DateTime? lastDate = DateTime.MinValue;
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryCont = (from c in context.ContractClosures
                                   where c.ShopID == pShopID && c.IsTerminated == true
                                   select new { c.TerminatedDate }).FirstOrDefault();

                    if (qryCont != null)
                    {
                        lastDate = qryCont.TerminatedDate;
                    }
                    else
                    {
                        var qryShopDet = (from sd in context.Shop_Details
                                          where sd.ShopID == pShopID
                                          select new { sd.ActiveFrom }).AsEnumerable().LastOrDefault();
                        if (qryShopDet != null)
                        {
                            lastDate = qryShopDet.ActiveFrom;
                        }
                        else
                        {
                            lastDate = DateTime.MinValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lastDate;

        }

        internal static List<DataTier.ReportClasses.ShopOccupancy> MisShopOccupiedAndUnOccupied(int pCompID, int pLocID, DateTime currentDate, DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = null)
        {
            List<DataTier.ReportClasses.ShopOccupancy> shopocclist = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    List<DataTier.ReportClasses.ShopOccupancy> shopocclist_Occupied = cCommon_Functions.MisShopOccupancy(pCompID, pLocID, currentDate, splashScreenManager1);
                    List<DataTier.ReportClasses.ShopOccupancy> shopocclist_Unoccupied = cCommon_Functions.MisShopUnOccupancy(pCompID, pLocID, currentDate, splashScreenManager1);

                    foreach (var qry in shopocclist_Occupied)
                    {
                        shopocclist.Add(qry);
                    }

                    // Unoccupied area 
                    foreach (var qry in shopocclist_Unoccupied)
                    {
                        DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                        shopOcc.CompanyCode = qry.CompanyCode;
                        shopOcc.CompanyName = qry.CompanyName;
                        shopOcc.LocationCode = qry.LocationCode;
                        shopOcc.LocationName = qry.LocationName;
                        shopOcc.LevelName = qry.LevelName;
                        shopOcc.UnOccupiedAreaSqft = qry.OccupiedAreaSqFt;
                        shopOcc.UnoccupiedFrom = qry.UnoccupiedFrom;
                        shopOcc.Naration = qry.Naration;
                        shopOcc.CustomerName = qry.CustomerName;
                        shopOcc.CustomerName = "VACANT";
                        shopOcc.ShopNo = qry.ShopNo;
                        shopOcc.RentAreaType = qry.RentAreaType;
                        shopocclist.Add(shopOcc);

                    }

                    shopocclist = (from s in shopocclist
                                   orderby s.ShopNo
                                   select s).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return shopocclist;
        }
        //internal static List<DataTier.ReportClasses.ShopOccupancy> MisShopOccupiedAndUnOccupied(int pCompID, int pLocID, DateTime currentDate, DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = null)
        //{
        //    List<DataTier.ReportClasses.ShopOccupancy> shopocclist = new List<DataTier.ReportClasses.ShopOccupancy>();

        //    try
        //    {

        //        using (AHPL_DBEntities context = new AHPL_DBEntities())
        //        {

        //            List<DataTier.ReportClasses.ShopOccupancy> shopocclist_Occupied = cCommon_Functions.MisShopOccupancy(pCompID, pLocID, currentDate, splashScreenManager1);
        //            List<DataTier.ReportClasses.ShopOccupancy> shopocclist_Unoccupied = cCommon_Functions.MisShopUnOccupancy(pCompID, pLocID, currentDate, splashScreenManager1);

        //            foreach (var qry in shopocclist_Occupied)
        //            {
        //                shopocclist.Add(qry);
        //            }

        //            // Unoccupied area 
        //            foreach (var qry in shopocclist_Unoccupied)
        //            {
        //                DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
        //                shopOcc.CompanyCode = qry.CompanyCode;
        //                shopOcc.CompanyName = qry.CompanyName;
        //                shopOcc.LocationCode = qry.LocationCode;
        //                shopOcc.LocationName = qry.LocationName;
        //                shopOcc.LevelName = qry.LevelName;
        //                shopOcc.UnOccupiedAreaSqft = qry.OccupiedAreaSqFt;
        //                shopOcc.UnoccupiedFrom = qry.UnoccupiedFrom;
        //                shopOcc.Naration = qry.Naration;
        //                shopOcc.CustomerName = qry.CustomerName;
        //                shopOcc.CustomerName = "VACANT";
        //                shopOcc.ShopNo = qry.ShopNo;
        //                shopOcc.RentAreaType = qry.RentAreaType;
        //                shopocclist.Add(shopOcc);

        //            }

        //            shopocclist = (from s in shopocclist
        //                           orderby s.ShopNo
        //                           select s).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    return shopocclist;
        //}
        private static string getSAPCustomerCodeByExtendedCustomerID(int? extendedCustomerID)
        {
            string sapCustomerCode = "";

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryCust = (from ec in context.Extended_Customers
                                   join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                   where ec.ExtendedCustomerID == extendedCustomerID
                                   select new { gc.SAPCustomerCode }).FirstOrDefault();
                    if (qryCust != null)
                    {
                        sapCustomerCode = qryCust.SAPCustomerCode;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return sapCustomerCode;
        }

        private static string getCustomerNameByExtendedCustomerID(int? extendedCustomerID)
        {
            string customerName = "";

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryCust = (from ec in context.Extended_Customers
                                   join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                   where ec.ExtendedCustomerID == extendedCustomerID
                                   select new { gc.CustomerName }).FirstOrDefault();
                    if (qryCust != null)
                    {
                        customerName = qryCust.CustomerName;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return customerName;


        }

        public static List<DataTier.ReportClasses.ShopOccupancy> MisCustomerRentChargeHistory(int compid, int locid, int exCustID)
        {
            List<DataTier.ReportClasses.ShopOccupancy> customerRentHistory = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    {
                        //look in contract
                        var qryContract = (from c in context.ContractClosures.AsEnumerable()
                                           join cr in context.Contract_RentSchemes on c.ContractClosureID equals cr.ContractClosureID
                                           where c.ExtendedCustomerID == exCustID
                                           group c by new { c.ShopNo } into g
                                           select new { g.Key, g.Key.ShopNo }).ToList();
                        foreach (var qryC in qryContract)
                        {
                            var qryContRent = (from c in context.ContractClosures
                                               join s in context.Shops on c.ShopID equals s.ShopID
                                               join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                               join com in context.Companies on c.CompanyID equals com.CompanyID
                                               join loc in context.Locations on c.LocationID equals loc.LocationID
                                               join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
                                               join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                               join gc in context.Global_Customers on exc.CustomerID equals gc.CustomerID
                                               join cr in context.Contract_RentSchemes on c.ContractClosureID equals cr.ContractClosureID
                                               where c.ShopNo == qryC.ShopNo && c.ExtendedCustomerID == exCustID
                                               orderby c.ShopNo ascending, cr.ToDate ascending
                                               select new { cr.Contract_RentSchemeID, ra.RentAreaTypeName, c.ContractClosureID, gc.CustomerName, c.FloorArea, c.ShopID, c.ShopNo, c.ShopName, cr.FromDate, cr.ToDate, cr.RentPerSqFeet, cr.SCPerSqFeet, com.CompanyCode, com.CompanyID, com.CompanyName, loc.LocationID, loc.LocationCode, loc.LocationName, lvl.LevelID, lvl.LevelCode, lvl.LevelName }).ToList();
                            decimal RentPerSqFt = 0;
                            decimal ScPerSqFt = 0;
                            int count = 0;
                            foreach (var qryContR in qryContRent)
                            {
                                DataTier.ReportClasses.ShopOccupancy renthistoryObject = new DataTier.ReportClasses.ShopOccupancy();
                                renthistoryObject.ContractClauseID = qryContR.ContractClosureID;
                                renthistoryObject.CompanyName = qryContR.CompanyName;
                                renthistoryObject.CompanyCode = qryContR.CompanyCode;
                                renthistoryObject.CustomerName = qryContR.CustomerName;
                                //renthistoryObject.SAPCustomerCode = qryContRent.SAPCustomerCode;
                                renthistoryObject.LocationName = qryContR.LocationName;
                                renthistoryObject.LocationCode = qryContR.LocationCode;
                                renthistoryObject.LevelName = qryContR.LevelName;
                                renthistoryObject.OccupiedAreaSqFt = qryContR.FloorArea;

                                decimal rentperSqFt = SearchInAddendum_rent(qryContR.Contract_RentSchemeID);
                                decimal scperSqft = SearchInAddendum_SC(qryContR.Contract_RentSchemeID);

                                if (rentperSqFt > 0)
                                { renthistoryObject.RentPerSqFt = rentperSqFt; }
                                else
                                {
                                    renthistoryObject.RentPerSqFt = qryContR.RentPerSqFeet;
                                }

                                if (scperSqft > 0)
                                {
                                    renthistoryObject.ScPerSqFt = scperSqft;
                                }
                                else
                                {
                                    renthistoryObject.ScPerSqFt = qryContR.SCPerSqFeet;
                                }
                                if (count > 0)
                                {
                                    renthistoryObject.IncreaseOfRent = renthistoryObject.RentPerSqFt - RentPerSqFt;
                                    renthistoryObject.IncreaseOfSC = renthistoryObject.ScPerSqFt - ScPerSqFt;
                                }



                                //renthistoryObject.IncreaseOfSC = qryContRent.IncreasedSC;
                                renthistoryObject.FromDate = qryContR.FromDate.ToString("dd/MM/yyyy");
                                renthistoryObject.ToDate = qryContR.ToDate.ToString("dd/MM/yyyy");
                                renthistoryObject.RentPeriod = qryContR.FromDate.ToString("dd/MM/yyyy") + " - " + qryContR.ToDate.ToString("dd/MM/yyyy");
                                renthistoryObject.ShopNo = qryContR.ShopNo;
                                renthistoryObject.RentAreaType = qryContR.RentAreaTypeName;

                                RentPerSqFt = renthistoryObject.RentPerSqFt;
                                ScPerSqFt = renthistoryObject.ScPerSqFt;

                                customerRentHistory.Add(renthistoryObject);
                                count++;
                            }


                        }
                        //select new { c.ShopID, c.ShopName, c.ShopNo, cr.FromDate, cr.ToDate, cr.RentPerSqFeet, cr.SCPerSqFeet }).ToList();

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customerRentHistory;
        }

        private static decimal SearchInAddendum_SC(int pContractRentSchemeID)
        {
            decimal amount = 0;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryAddendum = (from ad in context.Addendum_Details
                                       where ad.Contract_RentSchemeID == pContractRentSchemeID
                                       select new { ad.RentperSqFeetO, ad.SCperSqFeetO }).FirstOrDefault();
                    if (qryAddendum != null)
                    {
                        amount = qryAddendum.SCperSqFeetO;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return amount;

        }

        private static decimal SearchInAddendum_rent(int pContractRentSchemeID)
        {
            decimal amount = 0;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryAddendum = (from ad in context.Addendum_Details
                                       where ad.Contract_RentSchemeID == pContractRentSchemeID
                                       select new { ad.RentperSqFeetO, ad.SCperSqFeetO }).FirstOrDefault();
                    if (qryAddendum != null)
                    {
                        amount = qryAddendum.RentperSqFeetO;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return amount;


        }

        internal static List<DataTier.ReportClasses.ShopOccupancy> MisRentalIncreasedCustomers(int compid, int locid, DateTime currentDate)
        {


            List<DataTier.ReportClasses.ShopOccupancy> rentIncreasedCustList = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    DateTime currdate = currentDate;
                    int currentYear = currentDate.Date.Year;
                    int currMonth = currentDate.Date.Month;
                    DateTime currdate1 = new DateTime(currentYear, currMonth, 1);
                    DateTime prevMonthDate = currdate1.AddMonths(-1);

                    int prevYear = prevMonthDate.Date.Year;
                    int prevMonth = prevMonthDate.Date.Month;

                    decimal oldRent = 0; decimal oldSC = 0;
                    decimal newRent = 0; decimal newSC = 0;


                    var qryInv = (from i in context.Invoices
                                  where i.InvoiceTypeID == 1 && i.SubInvTypeID == 3 && i.SAP_PstnDateInDoc.Value.Year == currentYear && i.SAP_PstnDateInDoc.Value.Month == currMonth && i.LocationID == locid && i.CompanyID == compid && i.IsConfirmed == true
                                  select i).ToList();
                    foreach (var qry in qryInv)
                    {
                        newRent = 0; newSC = 0; oldRent = 0; oldSC = 0;

                        // new rent && New Service Charge
                        newRent = qry.RentPerMonth;
                        newSC = qry.SCPerMonth;
                        // --

                        // previous month Rent && SC 

                        var qryInvOld = (from i in context.Invoices
                                         join c in context.Companies on i.CompanyID equals c.CompanyID
                                         join l in context.Locations on i.LocationID equals l.LocationID
                                         join lvl in context.Floor_Levels on i.LevelID equals lvl.LevelID
                                         join s in context.Shops on i.ShopID equals s.ShopID
                                         join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                         where i.InvoiceTypeID == 1 && i.SubInvTypeID == 3 && i.SAP_PstnDateInDoc.Value.Year == prevYear && i.SAP_PstnDateInDoc.Value.Month == prevMonth && i.IsConfirmed == true && i.ExtendedCustomerID == qry.ExtendedCustomerID && i.ShopNo == qry.ShopNo && ra.IsAdvertisement == false
                                         select new { ra.RentAreaTypeName, i.ShopNo, i.ShopName, i.AreaInSqFt, i.CustomerName, i.RentPerMonth, i.SCPerMonth, c.CompanyCode, c.CompanyName, l.LocationCode, l.LocationName, lvl.LevelCode, lvl.LevelName }).FirstOrDefault();
                        if (qryInvOld != null)
                        {
                            oldRent = qryInvOld.RentPerMonth;
                            oldSC = qryInvOld.SCPerMonth;
                        }

                        if (qryInvOld != null)
                        {
                            if (oldRent != newRent || oldSC != oldRent)
                            {
                                decimal rentIncreasePrcntg = 0;
                                decimal scIncreasePrcntg = 0;
                                decimal rentDifference = 0;
                                decimal scDifference = 0;
                                if (oldSC > 0 && newSC > 0)
                                {
                                    scDifference = newSC - oldSC;
                                    scIncreasePrcntg = Math.Round((scDifference / oldSC) * 100, 2);
                                }

                                if (oldRent > 0 && newRent > 0)
                                {
                                    rentDifference = newRent - oldRent;
                                    rentIncreasePrcntg = Math.Round((rentDifference / oldRent) * 100, 2);
                                }

                                if (rentDifference > 0 || scDifference > 0)
                                {
                                    DataTier.ReportClasses.ShopOccupancy custrentIncreaseObj = new DataTier.ReportClasses.ShopOccupancy();

                                    custrentIncreaseObj.CompanyName = qryInvOld.CompanyName;
                                    custrentIncreaseObj.CompanyCode = qryInvOld.CompanyCode;
                                    custrentIncreaseObj.CustomerName = qryInvOld.CustomerName;
                                    //renthistoryObject.SAPCustomerCode = qryContRent.SAPCustomerCode;
                                    custrentIncreaseObj.LocationName = qryInvOld.LocationName;
                                    custrentIncreaseObj.LocationCode = qryInvOld.LocationCode;
                                    custrentIncreaseObj.LevelName = qryInvOld.LevelName;
                                    custrentIncreaseObj.ShopNo = qryInvOld.ShopNo;
                                    custrentIncreaseObj.OccupiedAreaSqFt = qryInvOld.AreaInSqFt;
                                    custrentIncreaseObj.OldRentPerSqFt = oldRent;
                                    custrentIncreaseObj.OldSCperSqFt = oldSC;
                                    custrentIncreaseObj.RentPerSqFt = newRent;
                                    custrentIncreaseObj.ScPerSqFt = newSC;
                                    custrentIncreaseObj.IncreaseOfRent = rentDifference;
                                    custrentIncreaseObj.IncreaseOfSC = scDifference;
                                    custrentIncreaseObj.IncreaseRentPercentage = rentIncreasePrcntg;
                                    custrentIncreaseObj.IncreaseSCPercentage = scIncreasePrcntg;
                                    custrentIncreaseObj.RentAreaType = qryInvOld.RentAreaTypeName;

                                    rentIncreasedCustList.Add(custrentIncreaseObj);
                                }
                            }
                        }




                    }




                    //{
                    //    //look in contract
                    //    var qryContract = (from c in context.ContractClosures.AsEnumerable()
                    //                       join cr in context.Contract_RentSchemes on c.ContractClosureID equals cr.ContractClosureID
                    //                       where cr.ToDate.Month == currentDate.Date.Month && c.IsPromotion == false && c.CompanyID == compid && c.LocationID == locid
                    //                       group c by new { c.ShopNo,c.ExtendedCustomerID } into g
                    //                       select new { g.Key, g.Key.ShopNo,g.Key.ExtendedCustomerID }).ToList();
                    //    foreach (var qryC in qryContract)
                    //    {
                    //        var qryContRent = (from c in context.ContractClosures
                    //                           join s in context.Shops on c.ShopID equals s.ShopID
                    //                           join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                    //                           join com in context.Companies on c.CompanyID equals com.CompanyID
                    //                           join loc in context.Locations on c.LocationID equals loc.LocationID
                    //                           join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
                    //                           join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                    //                           join gc in context.Global_Customers on exc.CustomerID equals gc.CustomerID
                    //                           join cr in context.Contract_RentSchemes on c.ContractClosureID equals cr.ContractClosureID
                    //                           where (c.ExtendedCustomerID == qryC.ExtendedCustomerID && c.ShopNo == qryC.ShopNo && c.IsPromotion==false )
                    //                           orderby c.ShopNo ascending, cr.ToDate ascending
                    //                           select new { ra.RentAreaTypeName, c.ContractClosureID, gc.CustomerName, c.FloorArea, c.ShopID, c.ShopNo, c.ShopName, cr.FromDate, cr.ToDate, cr.RentPerSqFeet, cr.SCPerSqFeet, com.CompanyCode, com.CompanyID, com.CompanyName, loc.LocationID, loc.LocationCode, loc.LocationName, lvl.LevelID, lvl.LevelCode, lvl.LevelName }).ToList();
                    //        decimal RentPerMonth = 0;
                    //        decimal ScPerMonth = 0;
                    //        int count = 0;
                    //        foreach (var qryContR in qryContRent)
                    //        {
                    //            DataTier.ReportClasses.ShopOccupancy renthistoryObject = new DataTier.ReportClasses.ShopOccupancy();
                    //            renthistoryObject.ContractClauseID = qryContR.ContractClosureID;
                    //            renthistoryObject.CompanyName = qryContR.CompanyName;
                    //            renthistoryObject.CompanyCode = qryContR.CompanyCode;
                    //            renthistoryObject.CustomerName = qryContR.CustomerName;
                    //            //renthistoryObject.SAPCustomerCode = qryContRent.SAPCustomerCode;
                    //            renthistoryObject.LocationName = qryContR.LocationName;
                    //            renthistoryObject.LocationCode = qryContR.LocationCode;
                    //            renthistoryObject.LevelName = qryContR.LevelName;
                    //            renthistoryObject.OccupiedAreaSqFt = qryContR.FloorArea;
                    //            renthistoryObject.RentPerSqFt = Math.Round(qryContR.RentPerSqFeet * qryContR.FloorArea,2); // New Rent/Month
                    //            renthistoryObject.ScPerSqFt = Math.Round(qryContR.SCPerSqFeet * qryContR.FloorArea,2);

                    //            renthistoryObject.ScPerSqFt = Math.Round(qryContR.SCPerSqFeet * qryContR.FloorArea,2); // New SC/Month

                    //            if (count > 0)
                    //            {
                    //                renthistoryObject.OldRentPerSqFt = RentPerMonth; // Old Rent/Month
                    //                renthistoryObject.OldSCperSqFt = ScPerMonth; // Old SC/Month
                    //                renthistoryObject.IncreaseOfRent = Math.Round(qryContR.RentPerSqFeet * qryContR.FloorArea,2)  - RentPerMonth; // Increse of Rent

                    //                if (renthistoryObject.IncreaseOfRent != 0)
                    //                {
                    //                    renthistoryObject.IncreaseRentPercentage = Math.Round((renthistoryObject.IncreaseOfRent / renthistoryObject.OldRentPerSqFt)*100,2);
                    //                }
                    //                renthistoryObject.IncreaseOfSC = Math.Round(qryContR.SCPerSqFeet * qryContR.FloorArea,2) - ScPerMonth;
                    //                if (renthistoryObject.IncreaseOfSC != 0)
                    //                {
                    //                    renthistoryObject.IncreaseSCPercentage = Math.Round((renthistoryObject.IncreaseOfSC / renthistoryObject.OldSCperSqFt)*100,2);
                    //                }

                    //            }

                    //            //renthistoryObject.IncreaseOfSC = qryContRent.IncreasedSC;
                    //            renthistoryObject.FromDate = qryContR.FromDate.ToString("dd/MM/yyyy");
                    //            renthistoryObject.ToDate = qryContR.ToDate.ToString("dd/MM/yyyy");
                    //            renthistoryObject.RentPeriod = qryContR.FromDate.ToString("dd/MM/yyyy") + " - " + qryContR.ToDate.ToString("dd/MM/yyyy");
                    //            renthistoryObject.ShopNo = qryContR.ShopNo;
                    //            renthistoryObject.RentAreaType = qryContR.RentAreaTypeName;

                    //            RentPerMonth = qryContR.RentPerSqFeet * qryContR.FloorArea;
                    //            ScPerMonth = qryContR.SCPerSqFeet * qryContR.FloorArea; 

                    //            customerRentHistory.Add(renthistoryObject);
                    //            count++;
                    //        }


                    //    }
                    //    //select new { c.ShopID, c.ShopName, c.ShopNo, cr.FromDate, cr.ToDate, cr.RentPerSqFeet, cr.SCPerSqFeet }).ToList();

                    //}
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rentIncreasedCustList;


            //List<DataTier.ReportClasses.ShopOccupancy> rentIncreasedCust = new List<DataTier.ReportClasses.ShopOccupancy>();

            //try
            //{
            //    List<int> intComps = comps.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
            //    List<int> intLocs = locs.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
            //    int selectedMonth = currentDate.Date.Month;
            //    int selectedYear = currentDate.Date.Year;


            //    using (AHPL_DBEntities context = new AHPL_DBEntities())
            //    {
            //        var qryCustomerHistory = (from s in context.Shops
            //                                  join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
            //                                  join comp in context.Companies on s.CompanyID equals comp.CompanyID
            //                                  join loc in context.Locations on s.LocationID equals loc.LocationID
            //                                  join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
            //                                  join c in context.ContractClosures on s.ShopID equals c.ShopID
            //                                  join ec in context.Extended_Customers on s.CustomerID equals ec.ExtendedCustomerID
            //                                  join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
            //                                  join cr in context.Contract_RentSchemes on c.ContractClosureID equals cr.ContractClosureID
            //                                  where s.CustomerID > 0 && intComps.Contains(s.CompanyID) && intLocs.Contains(s.LocationID) && (cr.IncreasedSC > 0 || cr.IncreasedRent > 0) && cr.ToDate.Value.Month == selectedMonth && cr.ToDate.Value.Year == selectedYear
            //                                  select new { ra.RentAreaTypeName, gc.CustomerName, gc.SAPCustomerCode, s.ShopID, s.ShopName, s.ShopNo, s.SqFeet, comp.CompanyCode, loc.LocationCode, lvl.LevelName, c.ContractClosureID, cr.FromDate, cr.ToDate, cr.RentPerSqFeet, cr.IncreasedRent, cr.SCPerSqFeet, cr.IncreasedSC }).ToList();
            //        foreach (var qry in qryCustomerHistory)
            //        {
            //            DataTier.ReportClasses.ShopOccupancy rentIncreasedObject = new DataTier.ReportClasses.ShopOccupancy();
            //            rentIncreasedObject.CompanyCode = qry.CompanyCode;
            //            rentIncreasedObject.CustomerName = qry.CustomerName;
            //            rentIncreasedObject.SAPCustomerCode = qry.SAPCustomerCode;
            //            rentIncreasedObject.LocationCode = qry.LocationCode;
            //            rentIncreasedObject.LevelName = qry.LevelName;
            //            rentIncreasedObject.OccupiedAreaSqFt = qry.SqFeet;
            //            decimal  newRent =  rentIncreasedObject.RentPerSqFt = qry.RentPerSqFeet;
            //            decimal oldRent =   rentIncreasedObject.OldRentPerSqFt = qry.RentPerSqFeet - qry.IncreasedRent;
            //            decimal prcntg = Math.Round((newRent / oldRent),2);
            //            if (prcntg == 1) { prcntg = 0; }
            //            rentIncreasedObject.IncreaseRentPercentage = prcntg;
            //            rentIncreasedObject.IncreaseOfRent = qry.IncreasedRent;

            //            newRent = rentIncreasedObject.ScPerSqFt = qry.SCPerSqFeet;
            //            oldRent = rentIncreasedObject.OldSCperSqFt = qry.SCPerSqFeet - qry.IncreasedSC;
            //            prcntg = Math.Round((newRent / oldRent),2) ;
            //            if (prcntg == 1) { prcntg = 0; }
            //            rentIncreasedObject.IncreaseSCPercentage = prcntg;
            //            rentIncreasedObject.IncreaseOfSC = qry.IncreasedSC;
            //            rentIncreasedObject.FromDate = qry.FromDate.Value.ToString("dd/MM/yyyy");
            //            rentIncreasedObject.ToDate = qry.ToDate.Value.ToString("dd/MM/yyyy");
            //            rentIncreasedObject.ShopNo = qry.ShopNo;                      
            //            rentIncreasedObject.RentAreaType = qry.RentAreaTypeName;
            //            rentIncreasedCust.Add(rentIncreasedObject);
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            //return rentIncreasedCust;
        }

        public static List<DataTier.ReportClasses.ShopOccupancy> MisUtilityReading(object comps, object locs, int pUtilityID, DateTime currentDate)
        {
            List<DataTier.ReportClasses.ShopOccupancy> utilityReadingList = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {
                List<int> intComps = comps.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                List<int> intLocs = locs.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                //List<int> intUti= pUtilityID.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));


                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryUtilityReading = (from s in context.Shops
                                             join sur in context.Shops_UtilityReadings on s.ShopID equals sur.ShopID
                                             join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                             join comp in context.Companies on s.CompanyID equals comp.CompanyID
                                             join loc in context.Locations on s.LocationID equals loc.LocationID
                                             join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                                             where intComps.Contains(s.CompanyID) && intLocs.Contains(s.LocationID) && sur.UtilityID == pUtilityID
                                             select new { ra.RentAreaTypeName, s.ShopID, s.ShopName, s.ShopNo, s.SqFeet, comp.CompanyName, comp.CompanyCode, loc.LocationName, loc.LocationCode, lvl.LevelName, sur.LastReading, sur.MeterName }).ToList();

                    foreach (var qry in qryUtilityReading)
                    {
                        


                        DataTier.ReportClasses.ShopOccupancy rentutilityObject = new DataTier.ReportClasses.ShopOccupancy();
                       
                        #region added on 02-Apr-2019 by ravinda.

                        rentutilityObject.CustomerName = getCustomerNameofShop(qry.ShopID);
                        string CustomerName = getCustomerNameofShop(qry.ShopID);
                        //filter only non vacant shops
                        if (CustomerName != "VACANT")
                        {


                            rentutilityObject.CompanyCode = qry.CompanyCode;
                            rentutilityObject.CompanyName = qry.CompanyName;
                           //  rentutilityObject.CustomerName = getCustomerNameofShop(qry.ShopID);//check here 
                            rentutilityObject.CustomerName = CustomerName;
                            rentutilityObject.SAPCustomerCode = getSapCodeByShop(qry.ShopID);
                            rentutilityObject.LocationName = qry.LocationName;
                            rentutilityObject.LocationCode = qry.LocationCode;
                            rentutilityObject.LevelName = qry.LevelName;
                            rentutilityObject.OccupiedAreaSqFt = qry.SqFeet;
                            rentutilityObject.RentAreaType = qry.RentAreaTypeName;
                            rentutilityObject.ShopNo = qry.ShopNo;
                            rentutilityObject.StartReading = qry.LastReading;
                            rentutilityObject.EndReading = 0;
                            rentutilityObject.MeterName = qry.MeterName;
                            ////rentutilityObject.UtilityName = qry.UtilityName;
                            ////rentutilityObject.UtilityUnitRate = qry.UtilityUnitRate;
                            
                            //to remove vacant shops from report
                          
                               utilityReadingList.Add(rentutilityObject);

                       }
                        #endregion 
                    }


                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

            return utilityReadingList;

        }

        private static string getSapCodeByShop(int pShopID)
        {
            string sapCode = "";

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryShop = (from s in context.Shops
                                   where s.ShopID == pShopID
                                   select new { s.CustomerID }).FirstOrDefault();
                    if (qryShop != null)
                    {
                        if (qryShop.CustomerID > 0)
                        {
                            var qryCust = (from ec in context.Extended_Customers
                                           where ec.ExtendedCustomerID == qryShop.CustomerID
                                           select new { ec.SAPAlternateCode }).FirstOrDefault();
                            if (qryCust != null)
                            {
                                sapCode = qryCust.SAPAlternateCode;
                            }

                        }
                        else
                        {
                            sapCode = "-";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return sapCode;
        }

        private static string getCustomerNameofShop(int pShopID)
        {
            string customerName = "";

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryShop = (from s in context.Shops
                                   where s.ShopID == pShopID
                                   select new { s.CustomerID }).FirstOrDefault();
                    if (qryShop != null)
                    {
                        if (qryShop.CustomerID > 0)
                        {
                            var qryCust = (from ec in context.Extended_Customers
                                           join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                           where ec.ExtendedCustomerID == qryShop.CustomerID
                                           select new { gc.CustomerName }).FirstOrDefault();
                            if (qryCust != null)
                            {
                                customerName = qryCust.CustomerName;
                            }

                        }
                        else
                        {
                            customerName = "VACANT";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return customerName;



        }

        internal static List<DataTier.ReportClasses.ShopOccupancy> MisRentalIncome(int compid, int locid, DateTime currentDate, int pExtendedCustomerID = 0, DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = null)
        {
            List<DataTier.ReportClasses.ShopOccupancy> rentalIncomeList = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryOccupiedList = (from inv in context.Invoices
                                           join ec in context.Extended_Customers on inv.ExtendedCustomerID equals ec.ExtendedCustomerID
                                           join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                           join s in context.Shops on inv.ShopID equals s.ShopID
                                           join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                           join comp in context.Companies on s.CompanyID equals comp.CompanyID
                                           join loc in context.Locations on s.LocationID equals loc.LocationID
                                           join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                                           join mnth in context.Months on inv.ProcessMonth equals mnth.MonthID
                                           join it in context.Sub_Invoice_Types on inv.SubInvTypeID equals it.SubInvTypeID
                                           join tr in context.TaxRates on inv.MandatoryTaxRateID equals tr.TaxRateID
                                           where inv.CompanyID == compid && inv.LocationID == locid && (inv.SAP_PstnDateInDoc.Value.Month == currentDate.Date.Month &&
                                           inv.SAP_PstnDateInDoc.Value.Year == currentDate.Year) && inv.InvoiceTypeID == 1 && ra.IsAdvertisement == false
                                           select new
                                           {
                                               it.SubInvTypeID,
                                               SubInvTypeOrder = it.StdOrder,
                                               it.SubInvTypeName,
                                               ec.ExtendedCustomerID,
                                               ra.RentAreaTypeName,
                                               gc.CustomerName,
                                               gc.SAPCustomerCode,
                                               s.ShopID,
                                               s.ShopName,
                                               s.ShopNo,
                                               s.SqFeet,
                                               comp.CompanyName,
                                               comp.CompanyCode,
                                               loc.LocationCode,
                                               loc.LocationName,
                                               lvl.LevelName,
                                               inv.ProcessYear,
                                               mnth.MonthCode,
                                               inv.RentPerMonth,
                                               inv.SCPerMonth,
                                               inv.RentWithSCPerMonth,
                                               inv.MandatoryTaxCode,
                                               inv.MandatoryTaxAmount,
                                               inv.TotalWithMandatoryTax,
                                               inv.OtherTaxCodes,
                                               inv.OtherTax,
                                               inv.RentPerSqFt,
                                               inv.SCPerSqFt,
                                               inv.Naration,
                                               inv.InvoiceNo,
                                               TaxRate = tr.TaxRate1
                                           }).ToList();

                    DataTier.ReportClasses.ShopOccupancy rentalIncome;
                    foreach (var qry in qryOccupiedList)
                    {
                        rentalIncome = new DataTier.ReportClasses.ShopOccupancy();


                        rentalIncome.CompanyCode = qry.CompanyCode;
                        rentalIncome.CompanyName = qry.CompanyName;
                        rentalIncome.LocationCode = qry.LocationCode;
                        rentalIncome.LocationName = qry.LocationName;
                        rentalIncome.LevelName = qry.LevelName;
                        rentalIncome.RentAreaType = qry.RentAreaTypeName;
                        rentalIncome.ShopNo = qry.ShopNo + ":" + qry.InvoiceNo + "(" + qry.SubInvTypeName + ")";
                        rentalIncome.SubInvoiceTypeOrder = qry.SubInvTypeOrder;
                        rentalIncome.SubInvoiceTypeID = qry.SubInvTypeID;
                        if (qry.SubInvTypeID == 1 || qry.SubInvTypeID == 2)
                        {
                            rentalIncome.CustomerName = qry.CustomerName + " (" + qry.Naration.Trim() + ")";

                        }
                        else
                        {

                            rentalIncome.CustomerName = qry.CustomerName;
                        }
                        rentalIncome.SAPCustomerCode = qry.SAPCustomerCode;
                        if (qry.SqFeet == 1)
                        {
                            rentalIncome.OccupiedAreaSqFt = 0;
                            rentalIncome.ShopSqFt = 0;
                        }
                        else
                        {
                            rentalIncome.OccupiedAreaSqFt = qry.SqFeet;
                            rentalIncome.ShopSqFt = qry.SqFeet;
                        }

                        rentalIncome.RentPerSqFt = qry.RentPerSqFt;
                        rentalIncome.ScPerSqFt = qry.SCPerSqFt;

                        ////////rentalIncome.RentPerMonth = qry.RentPerMonth * (100+ qry.TaxRate)/100;
                        ////////rentalIncome.SCperMonth = qry.SCPerMonth * (100 + qry.TaxRate) / 100;
                        ////////rentalIncome.RentWithSCperMonth = qry.RentWithSCPerMonth * (100 + qry.TaxRate) / 100;

                        ////Comment above wrong lines , because NBT values already added seperatlly.. by Roshan..17Nove2014
                        rentalIncome.RentPerMonth = qry.RentPerMonth;
                        rentalIncome.SCperMonth = qry.SCPerMonth;
                        rentalIncome.RentWithSCperMonth = qry.RentWithSCPerMonth;

                        rentalIncome.MandatoryTaxCode = qry.MandatoryTaxCode;
                        rentalIncome.MandatoryTaxAmount = qry.MandatoryTaxAmount;
                        rentalIncome.TotalWithMandatoryTax = qry.TotalWithMandatoryTax;
                        rentalIncome.OtherTaxCodes = qry.OtherTaxCodes;
                        rentalIncome.OtherTax = qry.OtherTax;
                        rentalIncome.TotalRentPerMonth = qry.TotalWithMandatoryTax + qry.OtherTax;
                        rentalIncome.Month = qry.MonthCode;
                        rentalIncome.Year = qry.ProcessYear;
                        rentalIncome.ExtendedCustomerID = qry.ExtendedCustomerID;
                        rentalIncome.SubInvoiceType = qry.SubInvTypeName;

                        rentalIncomeList.Add(rentalIncome);
                        splashScreenManager1.SetWaitFormDescription(rentalIncome.ShopNo);

                    }


                    var qryVacant = cCommon_Functions.MisShopUnOccupancy(compid, locid, currentDate, splashScreenManager1);
                    //// vacant shop list
                    //var qryVacant = (from s in context.Shops
                    //                 join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                    //                 join comp in context.Companies on s.CompanyID equals comp.CompanyID
                    //                 join loc in context.Locations on s.LocationID equals loc.LocationID
                    //                 join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                    //                 where s.CustomerID == 0 && s.CompanyID == compid && s.LocationID == locid
                    //                 select new {s.SqFeet, s.ShopNo, ra.RentAreaTypeName,comp.CompanyName, comp.CompanyCode, loc.LocationName,loc.LocationCode, lvl.LevelName }).ToList();

                    foreach (var qry in qryVacant)
                    {
                        rentalIncome = new DataTier.ReportClasses.ShopOccupancy();
                        rentalIncome.CompanyCode = qry.CompanyCode;
                        rentalIncome.CompanyName = qry.CompanyName;
                        rentalIncome.LocationCode = qry.LocationCode;
                        rentalIncome.LocationName = qry.LocationName;
                        rentalIncome.LevelName = qry.LevelName;
                        rentalIncome.RentAreaType = qry.RentAreaType;
                        rentalIncome.ShopNo = qry.ShopNo;
                        rentalIncome.CustomerName = "VACANT";
                        if (qry.OccupiedAreaSqFt == 1) { rentalIncome.UnOccupiedAreaSqft = 0; rentalIncome.ShopSqFt = 0; }
                        else
                        {
                            rentalIncome.UnOccupiedAreaSqft = qry.OccupiedAreaSqFt;
                            rentalIncome.ShopSqFt = qry.OccupiedAreaSqFt;
                        }
                        rentalIncome.IsVacant = true;
                        rentalIncomeList.Add(rentalIncome);
                        splashScreenManager1.SetWaitFormDescription(rentalIncome.ShopNo);
                    }

                }
            }
            catch (Exception ex)
            { throw ex; }

            rentalIncomeList = (from s in rentalIncomeList
                                orderby s.SubInvoiceTypeOrder, s.ShopNo
                                select s).ToList();

            return rentalIncomeList;

        }

        internal static string getOtherTaxCodes()
        {
            string otherTaxCodes = "";
            try
            {
                using (AHPL_DBEntities contexxt = new AHPL_DBEntities())
                {
                    var qryOtherTaxCodes = (from t in contexxt.Taxes
                                            where t.IsMandatory == false
                                            select t).ToList();
                    if (qryOtherTaxCodes.Count > 1)
                    {
                        foreach (var qry in qryOtherTaxCodes)
                        {
                            otherTaxCodes = otherTaxCodes + qry.TaxCode;
                        }
                    }
                    else
                    {
                        foreach (var qry in qryOtherTaxCodes)
                        {
                            otherTaxCodes = qry.TaxCode;
                        }
                    }
                    otherTaxCodes = otherTaxCodes.Trim();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return otherTaxCodes;

        }

        internal static List<DataTier.ReportClasses.ShopOccupancy> MisUtilityConsumption(int compid, int locid, int putilityID, DateTime pFromdate, DateTime pToDate)
        {
            List<DataTier.ReportClasses.ShopOccupancy> utilityReadingList = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {
                //List<int> intComps = comps.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                //List<int> intLocs = locs.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                //List<int> intUti = utilities.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));



                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryTax = (from c in context.Taxes
                                  join t in context.TaxRates on c.TaxID equals t.TaxID
                                  where c.IsMandatory == false
                                  select new { c.TaxCode, t.TaxRate1 }).FirstOrDefault();
                    string strTaxRate = "";
                    if (qryTax != null)
                    {
                        strTaxRate = qryTax.TaxRate1.ToString();
                    }



                    var qryUtilityReading = (from s in context.Shops
                                             join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                             join comp in context.Companies on s.CompanyID equals comp.CompanyID
                                             join loc in context.Locations on s.LocationID equals loc.LocationID
                                             join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                                             join inv in context.Invoices on s.ShopID equals inv.ShopID
                                             join ec in context.Extended_Customers on inv.ExtendedCustomerID equals ec.ExtendedCustomerID
                                             join mnth in context.Months on inv.ProcessMonth equals mnth.MonthID
                                             join si in context.Sub_Invoice_Types on inv.SubInvTypeID equals si.SubInvTypeID
                                             where s.CompanyID == compid && s.LocationID == locid && inv.UtilityID == putilityID && (inv.InvoiceDate >= pFromdate && inv.InvoiceDate <= pToDate) && inv.InvoiceTypeID == 2 && ra.IsAdvertisement == false && inv.IsMaintenance == false
                                             select new { ra.RentAreaTypeName, inv.CustomerName, SAPCustomerCode = ec.SAPAlternateCode, s.ShopID, s.ShopName, s.ShopNo, s.SqFeet, comp.CompanyName, comp.CompanyCode, loc.LocationName, loc.LocationCode, lvl.LevelName, inv.StartReading, inv.Ratio, inv.EndReading, inv.ProcessYear, mnth.MonthCode, inv.UtilityName, inv.NosUnitsConsumed1, inv.UtilityUnitRate, inv.RentPerMonth, inv.OtherTax, inv.OtherTaxCodes, Total = inv.TotalRentPerMonth, SubInvoiceType = si.SubInvTypeName, inv.UtilityMeterName }).ToList();

                    foreach (var qry in qryUtilityReading)
                    {
                        DataTier.ReportClasses.ShopOccupancy rentutilityObject = new DataTier.ReportClasses.ShopOccupancy();
                        rentutilityObject.CompanyCode = qry.CompanyCode;
                        rentutilityObject.CompanyName = qry.CompanyName;
                        rentutilityObject.CustomerName = qry.CustomerName;
                        rentutilityObject.SAPCustomerCode = qry.SAPCustomerCode;
                        rentutilityObject.LocationCode = qry.LocationCode;
                        rentutilityObject.LocationName = qry.LocationName;
                        rentutilityObject.LevelName = qry.LevelName;
                        rentutilityObject.OccupiedAreaSqFt = qry.SqFeet;
                        rentutilityObject.RentAreaType = qry.RentAreaTypeName;
                        rentutilityObject.ShopNo = qry.ShopNo;
                        rentutilityObject.StartReading = qry.StartReading;
                        rentutilityObject.EndReading = qry.EndReading;
                        rentutilityObject.NosUnitsConsumed1 = qry.NosUnitsConsumed1;
                        rentutilityObject.Amount = qry.RentPerMonth;
                        rentutilityObject.OtherTax = qry.OtherTax;
                        rentutilityObject.OtherTaxCodes = qry.OtherTaxCodes + " " + strTaxRate;
                        rentutilityObject.RentPerMonth = qry.RentPerMonth;
                        rentutilityObject.TotalAmount = qry.Total;
                        rentutilityObject.Year = qry.ProcessYear;
                        rentutilityObject.Month = qry.MonthCode;
                        rentutilityObject.UtilityName = qry.UtilityName;
                        rentutilityObject.UtilityUnitRate = qry.UtilityUnitRate;
                        rentutilityObject.SubInvoiceType = qry.SubInvoiceType;
                        rentutilityObject.Ratio = qry.Ratio;
                        rentutilityObject.MeterName = qry.UtilityMeterName;
                        utilityReadingList.Add(rentutilityObject);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return utilityReadingList;
        }


        public static bool Is_ISR(int pCompanyID)
        {
            bool is_isr = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryComp = (from c in context.Companies
                               where c.CompanyID == pCompanyID
                               select new { c.SAP_ISR, c.SAP_R3 }).FirstOrDefault();
                if (qryComp.SAP_ISR == true)
                {
                    is_isr = qryComp.SAP_ISR;
                }

            }
            return is_isr;

        }
        public static bool Is_R3(int pCompanyID)
        {
            bool is_R3 = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryComp = (from c in context.Companies
                               where c.CompanyID == pCompanyID
                               select new { c.SAP_ISR, c.SAP_R3 }).FirstOrDefault();
                if (qryComp.SAP_R3 == true)
                {
                    is_R3 = qryComp.SAP_R3;
                }

            }
            return is_R3;

        }

        internal static string getUtilityMeterName(int pShopUtilityReadingID)
        {
            string utilityMeterName = "";
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {


                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return utilityMeterName;

        }

        internal static int getContractClauseIDbyShopID(int pShopID)
        {
            int contractClauseID = 0;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryCont = (from c in context.ContractClosures
                               where c.ShopID == pShopID
                               select c).AsEnumerable().LastOrDefault();
                if (qryCont != null)
                {
                    contractClauseID = qryCont.ContractClosureID;
                }

            }

            return contractClauseID;
        }





        internal static List<DataTier.ReportClasses.ShopOccupancy> MisPromotionalIncome(int compid, int locid, DateTime pFromDate, DateTime pToDate)
        {
            List<DataTier.ReportClasses.ShopOccupancy> promotionalIncomeList = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {
                //List<int> intComps = comps.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                //List<int> intLocs = locs.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                //List<int> intMonths = pMonths.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {


                    //// promotonal income 
                    var qryPromoIncome = (from inv in context.Invoices
                                          join os in context.OtherServiceCategories on inv.OtherServiceID equals os.OtherServiceID
                                          join comp in context.Companies on inv.CompanyID equals comp.CompanyID
                                          join loc in context.Locations on inv.LocationID equals loc.LocationID
                                          join gc in context.Global_Customers on inv.CustomerID equals gc.CustomerID
                                          join mnth in context.Months on inv.ProcessMonth equals mnth.MonthID
                                          where inv.CompanyID == compid && inv.LocationID == locid && (inv.InvoiceDate >= pFromDate && inv.InvoiceDate <= pToDate) && inv.InvoiceTypeID == 3
                                          group inv by new { os.OtherServiceName } into g
                                          select new { g.Key.OtherServiceName, TotalRentPerMonth = g.Sum(x => x.TotalRentPerMonth) }).ToList();
                    //if (qryPromoIncome.Count > 0)
                    //{

                    foreach (var qryP in qryPromoIncome)
                    {

                        DataTier.ReportClasses.ShopOccupancy promoIncome = new DataTier.ReportClasses.ShopOccupancy();
                        promoIncome.OtherServiceName = qryP.OtherServiceName;
                        promoIncome.TotalRentPerMonth = qryP.TotalRentPerMonth;

                        var qryComp = (from c in context.Companies
                                       where c.CompanyID == compid
                                       select new { c.CompanyCode, c.CompanyName, c.CompanyID }).FirstOrDefault();

                        var qryLoc = (from l in context.Locations
                                      where l.LocationID == locid
                                      select new { l.LocationID, l.LocationCode, l.LocationName }).FirstOrDefault();

                        promoIncome.CompanyCode = qryComp.CompanyCode;
                        promoIncome.CompanyName = qryComp.CompanyName;

                        promoIncome.LocationCode = qryLoc.LocationCode;
                        promoIncome.LocationName = qryLoc.LocationName;

                        promotionalIncomeList.Add(promoIncome);


                    }
                    ////foreach (var qryP in qryPromoIncome)
                    ////{
                    ////    // promotion categories  
                    ////    var qryPromoCat = (from p in context.OtherServiceCategories
                    ////                       select new { p.OtherServiceID, p.OtherServiceName }).ToList();
                    ////    foreach (var qryPC in qryPromoCat)
                    ////    {

                    ////        // get the total for month wise 
                    ////        //foreach (var qryM in intMonths)
                    ////        {
                    ////            decimal? totalforMonth = null;

                    ////            var qrytotal = (from i in context.Invoices
                    ////                                    where i.InvoiceTypeID == 3 && (i.InvoiceDate >= pFromDate && i.InvoiceDate<=i.InvoiceDate)  && i.ExtendedCustomerID == qryP.ExtendedCustomerID && i.OtherServiceID == qryPC.OtherServiceID
                    ////                                    select new { i.TotalRentPerMonth }).ToList();
                    ////           if (qrytotal.Count > 0)
                    ////           {
                    ////               totalforMonth = (from i in context.Invoices
                    ////                                where i.InvoiceTypeID == 3 && (i.InvoiceDate >= pFromDate && i.InvoiceDate <= pToDate) && i.ExtendedCustomerID == qryP.ExtendedCustomerID && i.OtherServiceID == qryPC.OtherServiceID
                    ////                                select new { i.TotalRentPerMonth }).Sum(x => x.TotalRentPerMonth);
                    ////           }

                    ////           if (totalforMonth.HasValue)
                    ////           {
                    ////               DataTier.ReportClasses.ShopOccupancy promoIncome = new DataTier.ReportClasses.ShopOccupancy();
                    ////               promoIncome.OtherServiceName = qryPC.OtherServiceName;

                    ////               promoIncome.TotalRentPerMonth = totalforMonth.Value;


                    ////               //promoIncome.Month = context.Months.Where(x => x.MonthID == qryM).FirstOrDefault().MonthCode;

                    ////               // customer name 
                    ////               var qryCustname = (from ec in context.Extended_Customers
                    ////                                  join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                    ////                                  join c in context.Companies on ec.CompanyID equals c.CompanyID 
                    ////                                  join l in context.Locations on ec.LocationID equals l.LocationID
                    ////                                  where ec.ExtendedCustomerID == qryP.ExtendedCustomerID
                    ////                                  select new {c.CompanyCode,c.CompanyName,l.LocationCode,l.LocationName, gc.CustomerName }).FirstOrDefault();
                    ////               promoIncome.CustomerName = qryCustname.CustomerName;
                    ////               promoIncome.CompanyName = qryCustname.CompanyName;
                    ////               promoIncome.LocationName = qryCustname.LocationName;

                    ////               promotionalIncomeList.Add(promoIncome);
                    ////           }

                    ////        }
                    ////    }                            

                    //}
                    //}
                    //--                    
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }


            return promotionalIncomeList;


        }

        internal static List<DataTier.ReportClasses.ShopOccupancy> MisAdSpaceUtilization(int compid, int locid, DateTime currentDate, DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = null)
        {
            List<DataTier.ReportClasses.ShopOccupancy> shopocclist = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {
                DateTime dateFrom = currentDate.AddMonths(-1).AddDays(1);

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryCont = (from c in context.ContractClosures
                                   join s in context.Shops on c.ShopID equals s.ShopID
                                   join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                   join co in context.Companies on c.CompanyID equals co.CompanyID
                                   join l in context.Locations on c.LocationID equals l.LocationID
                                   join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
                                   join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                   join gc in context.Global_Customers on exc.CustomerID equals gc.CustomerID
                                   orderby c.CompanyID, c.LocationID, c.LevelID, c.ShopNo
                                   where c.IsCancelled == false && c.IsProcessed == true && c.IsPoAdvertisement == true && c.CompanyID == compid && c.LocationID == locid
                                   select new { c.ContractClosureID, c.CompanyID, c.LocationID, c.LevelID, FloorArea = s.SqFeet, c.ShopID, c.ShopNo, c.ShopName, gc.CustomerName, co.CompanyCode, co.CompanyName, l.LocationCode, l.LocationName, lvl.LevelName, c.IsTerminated, c.TerminatedDate, ra.RentAreaTypeName, SAPCustomerCode = exc.SAPAlternateCode, c.IsNew, c.IsRenew, c.IsActive, c.IsPromotion, c.IsProcessed, c.IsPoAdvertisement }).Distinct().ToList();
                    List<decimal> total = new List<decimal>();

                    foreach (var qry in qryCont)
                    {

                        DateTime contStartDate = getContStartDate(qry.ContractClosureID);
                        DateTime contExpDate = getContExpiryDate(qry.ContractClosureID);

                        string rentPeriod = contStartDate.ToString("dd/MM/yyyy") + " - " + contExpDate.ToString("dd/MM/yyyy");

                        if (contStartDate <= currentDate && contExpDate >= currentDate && qry.IsPoAdvertisement == true && qry.IsProcessed == true)
                        {
                            if (qry.IsTerminated == true && qry.TerminatedDate >= currentDate)
                            {
                                DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();

                                shopOcc.CompanyName = qry.CompanyName;
                                shopOcc.LocationName = qry.LocationName;
                                shopOcc.LevelName = qry.LevelName;
                                shopOcc.CompanyCode = qry.CompanyCode;
                                shopOcc.LocationCode = qry.LocationCode;
                                if (qry.FloorArea == 1)
                                {
                                    shopOcc.OccupiedAreaSqFt = 0;
                                }
                                else
                                {
                                    shopOcc.OccupiedAreaSqFt = qry.FloorArea;
                                }
                                shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, currentDate);
                                shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, currentDate);
                                shopOcc.SAPCustomerCode = qry.SAPCustomerCode;
                                shopOcc.CustomerName = qry.CustomerName;
                                shopOcc.ShopNo = qry.ShopNo;
                                shopOcc.ShopID = qry.ShopID;
                                shopOcc.RentAreaType = qry.RentAreaTypeName;
                                shopOcc.RentPeriod = rentPeriod;

                                if (splashScreenManager1 != null)
                                {
                                    if (splashScreenManager1.IsSplashFormVisible == true)
                                    {
                                        splashScreenManager1.SetWaitFormDescription(qry.ShopNo);
                                    }
                                }

                                shopocclist.Add(shopOcc);
                            }
                            else if (qry.IsTerminated == false)
                            {
                                DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                                shopOcc.CompanyName = qry.CompanyName;
                                shopOcc.LocationName = qry.LocationName;
                                shopOcc.LevelName = qry.LevelName;
                                shopOcc.CompanyCode = qry.CompanyCode;
                                shopOcc.LocationCode = qry.LocationCode;
                                if (qry.FloorArea == 1)
                                {
                                    shopOcc.OccupiedAreaSqFt = 0;
                                }
                                else
                                {
                                    shopOcc.OccupiedAreaSqFt = qry.FloorArea;
                                }
                                shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, currentDate);
                                shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, currentDate);
                                shopOcc.SAPCustomerCode = qry.SAPCustomerCode;
                                shopOcc.CustomerName = qry.CustomerName;
                                shopOcc.ShopNo = context.Shops.Where(x => x.ShopID == qry.ShopID).FirstOrDefault().ShopNo;
                                shopOcc.ShopID = qry.ShopID;
                                shopOcc.RentAreaType = qry.RentAreaTypeName;
                                shopOcc.RentPeriod = rentPeriod;
                                //shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, currentDate);
                                //shopOcc.TotalSqFtInCompany = totalInComp;
                                //shopOcc.TotalSqFtInLocation = totalInLoc;

                                if (splashScreenManager1 != null)
                                {
                                    if (splashScreenManager1.IsSplashFormVisible == true)
                                    {
                                        splashScreenManager1.SetWaitFormDescription(qry.ShopNo);
                                    }
                                }

                                shopocclist.Add(shopOcc);

                            }
                        }


                        else
                        {
                            // for the contracts which are expired but still in active 
                            if (contStartDate <= currentDate && qry.IsTerminated == false && qry.IsPromotion == false && qry.IsProcessed == true)
                            {
                                DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                                shopOcc.CompanyName = qry.CompanyName;
                                shopOcc.LocationName = qry.LocationName;
                                shopOcc.LevelName = qry.LevelName;
                                shopOcc.CompanyCode = qry.CompanyCode;
                                shopOcc.LocationCode = qry.LocationCode;
                                if (qry.FloorArea == 1)
                                {
                                    shopOcc.OccupiedAreaSqFt = 0;
                                }
                                else
                                {
                                    shopOcc.OccupiedAreaSqFt = qry.FloorArea;
                                }
                                shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, currentDate);
                                shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, currentDate);
                                shopOcc.SAPCustomerCode = qry.SAPCustomerCode;
                                shopOcc.CustomerName = qry.CustomerName;
                                shopOcc.ShopNo = qry.ShopNo;
                                shopOcc.ShopID = qry.ShopID;
                                shopOcc.RentAreaType = qry.RentAreaTypeName;


                                shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID, currentDate);
                                //shopOcc.TotalSqFtInCompany = totalInComp;
                                //shopOcc.TotalSqFtInLocation = totalInLoc;

                                if (splashScreenManager1 != null)
                                {
                                    if (splashScreenManager1.IsSplashFormVisible == true)
                                    {
                                        splashScreenManager1.SetWaitFormDescription(qry.ShopNo);
                                    }
                                }
                                shopocclist.Add(shopOcc);


                            }

                        }


                        Application.DoEvents();
                        //x.PerformStep();
                    }

                    decimal totalsqft = total.Sum();
                }

            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return shopocclist;

        }

        private static string getTotalChargePeriodAD(int p, DateTime fromdate, DateTime todate)
        {
            throw new NotImplementedException();
        }

        //private static decimal getTotalChargeAD(int pshopID, DateTime fromdate, DateTime todate)
        //{
        //    decimal totalCharge = 0;

        //    try
        //    {
        //        using (AHPL_DBEntities context = new AHPL_DBEntities())
        //        {
        //            var qryCont = (from c in context.ContractClosures
        //                           join cr in context.Contract_RentSchemes on c.ContractID equals cr.ContractClosureID
        //                           where c.ShopID == pshopID && (cr.FromDate >= fromdate && cr.ToDate <=todate)
        //                           select new {cr.


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }



        //    return totalCharge;


        //}

        internal static List<DataTier.ReportClasses.ShopOccupancy> MisAdSpaceUnutilizied(int compid, int locid, DateTime currDate)
        {
            List<DataTier.ReportClasses.ShopOccupancy> adpsaceUtiList = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {
                //List<int> intComps = comps.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                //List<int> intLocs = locs.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryAdSpace = (from s in context.Shops
                                      join c in context.Companies on s.CompanyID equals c.CompanyID
                                      join l in context.Locations on s.LocationID equals l.LocationID
                                      join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                      where s.CustomerID == 0 && s.CompanyID == compid && s.LocationID == locid && ra.IsAdvertisement == true
                                      select new
                                      {
                                          c.CompanyID,
                                          c.CompanyCode,
                                          c.LocationID,
                                          l.LocationCode,
                                          ra.RentAreaTypeName,
                                          s.SqFeet,
                                          s.ShopNo,
                                          s.ShopID
                                      }).ToList();

                    DataTier.ReportClasses.ShopOccupancy adspaceObject;
                    foreach (var qry in qryAdSpace)
                    {
                        adspaceObject = new DataTier.ReportClasses.ShopOccupancy();
                        adspaceObject.CompanyCode = qry.CompanyCode;
                        adspaceObject.LocationCode = qry.LocationCode;
                        adspaceObject.ShopNo = qry.ShopNo;
                        adspaceObject.UnOccupiedAreaSqft = qry.SqFeet;
                        adspaceObject.UnoccupiedFrom = getUnOccupiedFrom(qry.ShopID);
                        adspaceObject.UnOccupiedMonth = getUnOccupiedMonth(adspaceObject.UnoccupiedFrom, DateTime.Now.Date);
                        adspaceObject.RentPerMonth = getLastRate(qry.ShopID);
                        adspaceObject.RentAreaType = qry.RentAreaTypeName;
                        adpsaceUtiList.Add(adspaceObject);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return adpsaceUtiList;
        }

        private static decimal getUnOccupiedMonth(string pFromDate, DateTime pToDate)
        {
            decimal nosmonth = 0;
            try
            {
                bool res = false;
                DateTime fromDate;
                res = DateTime.TryParse(pFromDate.ToString(), out fromDate);
                if (res == false) { fromDate = DateTime.Now.Date; }

                int nosdays = pToDate.Subtract(fromDate).Days;

                decimal monthdays = 365 / 12;


                if (nosdays > 0)
                {
                    nosmonth = nosdays / monthdays;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return nosmonth;
        }

        private static decimal getLastRate(int pShopID)
        {
            decimal rentPerMonth = 0;
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryInv = (from i in context.Invoices
                                  orderby i.InvoiceDate descending
                                  where i.ShopID == pShopID
                                  select new { i.RentPerMonth, i.InvoiceDate }).FirstOrDefault();
                    if (qryInv != null)
                    {
                        rentPerMonth = qryInv.RentPerMonth;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rentPerMonth;
        }

        private static string getUnOccupiedFrom(int pShopID)
        {
            string datefrom = "";
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryInv = (from i in context.ContractClosures
                                  where i.ShopID == pShopID
                                  select i).AsEnumerable().LastOrDefault();


                    if (qryInv != null)
                    {
                        if (qryInv.IsTerminated == true)
                        {
                            datefrom = qryInv.TerminatedDate.Value.ToString("dd/MM/yyyy");

                        }
                        //datefrom = qryInv.InvoiceDate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        var qryShop = (from s in context.Shops
                                       join sd in context.Shop_Details on s.ShopID equals sd.ShopID
                                       select new { sd.ActiveFrom }).FirstOrDefault();
                        if (qryShop != null)
                        {
                            datefrom = qryShop.ActiveFrom.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            datefrom = "-";

                        }


                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datefrom;

        }



        internal static void EmailAlert(string pEmailAlertItemName, int pCompanyID = 0, int pLocationID = 0, string pShopName = "", int pContactClauseID = 0, string pLoggedUserName = "", string mailSubject = "", string mailBody = "", string note = "", string pAttachmentPath = "", bool IsUtility = false, bool IsOtherService = false)
        {

            try
            {

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryEmailConfig = (from em in context.EmailConfigurations
                                          select em).FirstOrDefault();
                    if (qryEmailConfig == null)
                    {
                        throw new Exception("Email Configuration is Empty,Contact System Administrator");
                    }

                    string FromEmail = qryEmailConfig.FromEmail;
                    string ClientHost = qryEmailConfig.ClientHost;
                    string PortNo = qryEmailConfig.PorNo;
                    int intPortNo = 25;
                    bool res = int.TryParse(PortNo.ToString(), out intPortNo);
                    if (res == false) { intPortNo = 25; }

                    /// 
                    string companyCode = "";
                    string locationCode = "";
                    string contractClauseName = "";

                    // 

                    if (pCompanyID > 0)
                    {
                        var qryComp = (from c in context.Companies
                                       where c.CompanyID == pCompanyID
                                       select new { c.CompanyCode }).FirstOrDefault();
                        companyCode = qryComp.CompanyCode;
                    }

                    if (pLocationID > 0)
                    {
                        var qryLoc = (from c in context.Locations
                                      where c.LocationID == pLocationID
                                      select new { c.LocationCode }).FirstOrDefault();
                        locationCode = qryLoc.LocationCode;
                    }

                    if (pContactClauseID > 0)
                    {
                        var qryContClause = (from c in context.ContractClosures
                                             where c.ContractClosureID == pContactClauseID
                                             select new { c.ContractClosureName }).FirstOrDefault();
                        contractClauseName = qryContClause.ContractClosureName;
                    }

                    var qryUserList = (from ul in context.UserLocations
                                       join u in context.Permission_Users on ul.UserID equals u.UserID
                                       where ul.LocationID == pLocationID
                                       select new { u.UserID, u.UserName, u.Email1, ul.IsHead, ul.LocationID }).ToList();
                    if (qryUserList.Count == 0) { return; }

                    foreach (var qry in qryUserList)
                    {
                        MailAddress from = new MailAddress(FromEmail, "Shopping Mall System");
                        MailAddress to = new MailAddress(qry.Email1, qry.UserName.ToString());
                        MailMessage mail = new MailMessage(from, to);

                        SmtpClient client = new SmtpClient();
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Host = ClientHost;
                        client.Port = intPortNo;

                        string body = "";
                        string subject = "";



                        if (pEmailAlertItemName == "Rent Invoice Processed")
                        {
                            subject = "Attention : Rent Invoice Processed";

                            body = body = "Dear " + qry.UserName + "," + System.Environment.NewLine
                                + System.Environment.NewLine + pEmailAlertItemName + " with attched file information " + System.Environment.NewLine + "Company : " + companyCode + System.Environment.NewLine + "Location : " + locationCode + System.Environment.NewLine + "Processed By : " + LoggedSystemUserName
                                + System.Environment.NewLine
                                + System.Environment.NewLine + "Note : Next step is confirming rent invoice."
                                + System.Environment.NewLine
                                + System.Environment.NewLine + "This is an automated email generated by Shopping Mall System, If already taken the steps please ignore this email."
                                + System.Environment.NewLine
                                + System.Environment.NewLine
                                + System.Environment.NewLine + "---T H A N K   Y O U ---"
                                + System.Environment.NewLine + "-JKCS Developer-";
                        }

                        if (pEmailAlertItemName == "Rent Invoice(s) Confirmed")
                        {
                            subject = "Attention : Rent Invoice(s) Confirmed";

                            body = body = "Dear " + qry.UserName + "," + System.Environment.NewLine
                                + System.Environment.NewLine + "Rent Invoice(s) confirmed by " + LoggedDNSUserName
                               + System.Environment.NewLine
                               + System.Environment.NewLine + "Note : Please see the attachment."
                               + System.Environment.NewLine
                               + System.Environment.NewLine + "This is an automated email generated by Shopping Mall System, If already taken the steps please ignore this email."
                               + System.Environment.NewLine
                               + System.Environment.NewLine
                               + System.Environment.NewLine + "---T H A N K   Y O U ---"
                               + System.Environment.NewLine + "-JKCS Developer-";
                        }

                        if (IsUtility == true)
                        {
                            subject = "Attention : " + pEmailAlertItemName;

                            body = body = "Dear " + qry.UserName + "," + System.Environment.NewLine
                                + System.Environment.NewLine + pEmailAlertItemName + " by " + LoggedDNSUserName
                               + System.Environment.NewLine
                               + System.Environment.NewLine + note
                               + System.Environment.NewLine
                               + System.Environment.NewLine + "This is an automated email generated by Shopping Mall System, If already taken the steps please ignore this email."
                               + System.Environment.NewLine
                               + System.Environment.NewLine
                               + System.Environment.NewLine + "---T H A N K   Y O U ---"
                               + System.Environment.NewLine + "-JKCS Developer-";
                        }

                        if (IsOtherService == true)
                        {

                            subject = "Attention : " + pEmailAlertItemName;

                            if (pContactClauseID > 0)
                            {

                                body = body = "Dear " + qry.UserName + "," + System.Environment.NewLine
                                    + System.Environment.NewLine + pEmailAlertItemName + " with following information " + System.Environment.NewLine + "Contract Name : " + contractClauseName + System.Environment.NewLine + "Company : " + companyCode + System.Environment.NewLine + "Location : " + locationCode + System.Environment.NewLine + "Processed By : " + LoggedSystemUserName
                                   + System.Environment.NewLine
                                   + System.Environment.NewLine + note
                                   + System.Environment.NewLine
                                   + System.Environment.NewLine + "This is an automated email generated by Shopping Mall System, If already taken the steps please ignore this email."
                                   + System.Environment.NewLine
                                   + System.Environment.NewLine
                                   + System.Environment.NewLine + "---T H A N K   Y O U ---"
                                   + System.Environment.NewLine + "-JKCS Developer-";
                            }
                            else
                            {
                                body = body = "Dear " + qry.UserName + "," + System.Environment.NewLine
                                   + System.Environment.NewLine + pEmailAlertItemName + " Confrimed By : " + LoggedSystemUserName
                                  + System.Environment.NewLine
                                  + System.Environment.NewLine + note
                                  + System.Environment.NewLine
                                  + System.Environment.NewLine + "This is an automated email generated by Shopping Mall System, If already taken the steps please ignore this email."
                                  + System.Environment.NewLine
                                  + System.Environment.NewLine
                                  + System.Environment.NewLine + "---T H A N K   Y O U ---"
                                  + System.Environment.NewLine + "-JKCS Developer-";


                            }

                        }


                        if (pEmailAlertItemName == "Contract Released" || pEmailAlertItemName == "Contract Assigned")
                        {
                            subject = "Attention : " + pEmailAlertItemName + " - " + contractClauseName + "'";

                            body = "Dear " + qry.UserName + "," + System.Environment.NewLine
                                + System.Environment.NewLine + pEmailAlertItemName + " with following information " + System.Environment.NewLine + "Company : " + companyCode + System.Environment.NewLine + "Location : " + locationCode + System.Environment.NewLine + " By : " + LoggedSystemUserName
                                + System.Environment.NewLine
                                + System.Environment.NewLine + note
                                + System.Environment.NewLine
                                + System.Environment.NewLine + "This is an automated email generated by Shopping Mall System, If already taken the steps please ignore this email."
                                + System.Environment.NewLine
                                + System.Environment.NewLine
                                + System.Environment.NewLine + "---T H A N K   Y O U ---"
                                + System.Environment.NewLine + "-JKCS Developer-";
                        }

                        mail.Subject = subject;
                        mail.Body = body;

                        if (!string.IsNullOrEmpty(pAttachmentPath.ToString().Trim()))
                        {
                            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pAttachmentPath);
                            mail.Attachments.Add(attachment);
                        }
                        client.Send(mail);




                    }



                }


            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void AddToEmailList(int pCompanyID, int pLocationID, int pAlertItemId, string pBody, int createdBy, DevExpress.XtraGrid.Views.Grid.GridView pGridView = null, string pSubject = "")
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    string Subject = "";
                    var qryAlertItem = (from a in context.EmailAlertItems
                                        where a.EmailAlertItemID == pAlertItemId
                                        select a).FirstOrDefault();
                    if (qryAlertItem == null)
                    { throw new Exception("Alert Item is not defined"); }

                    if (!string.IsNullOrEmpty(pSubject))
                    {
                        Subject = pSubject + " : " + qryAlertItem.EmailArertItemName;
                    }
                    else
                    {
                        Subject = qryAlertItem.EmailArertItemName;
                    }

                    EmailsToBeSent emailtobeSent = new EmailsToBeSent();
                    emailtobeSent.EmailAlertItemID = pAlertItemId;
                    emailtobeSent.CompanyID = pCompanyID;
                    emailtobeSent.LocationID = pLocationID;

                    emailtobeSent.Subject = Subject;
                    emailtobeSent.Body = pBody;
                    emailtobeSent.CreatedBy = createdBy;
                    emailtobeSent.CreatedDate = DateTime.Now;


                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                    if (pGridView != null)
                    {
                        pGridView.ExportToXlsx(memoryStream);
                        byte[] buffer = memoryStream.ToArray();
                        emailtobeSent.Attachment = buffer;
                    }

                    context.EmailsToBeSents.AddObject(emailtobeSent);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void AddToEmailListContractExpiry(int pCompanyID, int pLocationID, int pAlertItemId, string pSubject, string pBody, int pContractClauseID = 0, int pAlertSequence = 0, int pLapsDays = 0, string pCommencedDate = "", string pExpiryDate = "", bool pIsPoContract = false)
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    string Subject = "";
                    string ContractName = "";


                    string Body = "";
                    var qryAlertItem = (from a in context.EmailAlertItems
                                        where a.EmailAlertItemID == pAlertItemId
                                        select a).FirstOrDefault();
                    if (qryAlertItem == null)
                    { throw new Exception("Alert Item is not defined"); }


                    ////////search in the emails to be sent

                    var qryEmail = (from a in context.EmailsToBeSents
                                    where a.IsMonthly == true && a.ContractClauseID == pContractClauseID && a.AlertSequence == pAlertSequence
                                    select a).ToList();
                    if (qryEmail.Count > 0)
                    { return; }



                    var qryContract = (from c in context.ContractClosures
                                       join co in context.Companies on c.CompanyID equals co.CompanyID
                                       join l in context.Locations on c.LocationID equals l.LocationID
                                       join lvl in context.Floor_Levels on c.LevelID equals lvl.LevelID
                                       join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                       join gc in context.Global_Customers on exc.CustomerID equals gc.CustomerID
                                       where c.ContractClosureID == pContractClauseID
                                       select new { c.ContractClosureID, c.ContractClosureName, c.ShopName, c.ShopNo, gc.CustomerName, co.CompanyCode, l.LocationCode, lvl.LevelName }).FirstOrDefault();
                    if (qryContract != null)
                    {
                        ContractName = qryContract.ContractClosureName;

                        if (pIsPoContract == false)
                        {
                            Body = "Contract Name : " + qryContract.ContractClosureName + System.Environment.NewLine +
                                "Customer Name : " + qryContract.CustomerName + System.Environment.NewLine +
                                "Shop Name : " + qryContract.ShopName + System.Environment.NewLine +
                                "Shop No : " + qryContract.ShopNo + System.Environment.NewLine +
                                "Company : " + qryContract.CompanyCode + System.Environment.NewLine +
                                "Location : " + qryContract.LocationCode + System.Environment.NewLine +
                                "Level : " + qryContract.LevelName + System.Environment.NewLine +
                                "Commence Date : " + pCommencedDate + System.Environment.NewLine +
                                "Expiry Date : " + pExpiryDate + System.Environment.NewLine +
                                "Laps Days : " + pLapsDays.ToString() + System.Environment.NewLine;
                        }
                        else
                        {
                            Body = "Contract Name : " + qryContract.ContractClosureName + System.Environment.NewLine +
                               "Customer Name : " + qryContract.CustomerName + System.Environment.NewLine +
                               "Company : " + qryContract.CompanyCode + System.Environment.NewLine +
                               "Location : " + qryContract.LocationCode + System.Environment.NewLine +
                               "Commence Date : " + pCommencedDate + System.Environment.NewLine +
                               "Expiry Date : " + pExpiryDate + System.Environment.NewLine +
                               "Laps Days : " + pLapsDays.ToString() + System.Environment.NewLine;


                        }

                    }





                    Subject = pSubject + " : " + ContractName;

                    EmailsToBeSent emailtobeSent = new EmailsToBeSent();
                    emailtobeSent.EmailAlertItemID = pAlertItemId;
                    emailtobeSent.CompanyID = pCompanyID;
                    emailtobeSent.LocationID = pLocationID;
                    emailtobeSent.Subject = Subject;
                    emailtobeSent.Body = Body;
                    emailtobeSent.IsMonthly = true;
                    emailtobeSent.IsHourly = false;
                    emailtobeSent.AlertSequence = pAlertSequence;
                    emailtobeSent.ContractClauseID = pContractClauseID;
                    emailtobeSent.CreatedBy = 2; // Administrator
                    emailtobeSent.CreatedDate = DateTime.Now;


                    context.EmailsToBeSents.AddObject(emailtobeSent);




                    context.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        internal static List<DataTier.ReportClasses.ShopOccupancy> MisServiceCharge(int compid, int locid, DateTime pDateAsAt)
        {
            List<DataTier.ReportClasses.ShopOccupancy> shopocclist = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryShops = (from i in context.Invoices
                                    join s in context.Shops on i.ShopID equals s.ShopID
                                    join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                    join c in context.Companies on s.CompanyID equals c.CompanyID
                                    join l in context.Locations on s.LocationID equals l.LocationID
                                    join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                                    join exc in context.Extended_Customers on s.CustomerID equals exc.ExtendedCustomerID
                                    join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                                    where s.CompanyID == compid && s.LocationID == locid && ra.IsAdvertisement == false && i.InvoiceDate <= pDateAsAt && i.ProcessMonth == pDateAsAt.Month && i.ProcessYear == pDateAsAt.Year
                                    select new { c.CompanyID, c.CompanyName, c.CompanyCode, l.LocationID, l.LocationName, l.LocationCode, lvl.LevelID, lvl.LevelName, gcus.SAPCustomerCode, gcus.CustomerName, s.ShopNo, s.SqFeet, s.ShopID, ra.RentAreaTypeName, i.SCPerMonth, i.SCPerSqFt, i.RentPerSqFt, i.SAP_PstnDateInDoc }).ToList();
                    foreach (var qry in qryShops)
                    {
                        DataTier.ReportClasses.ShopOccupancy shopOcc = new DataTier.ReportClasses.ShopOccupancy();
                        shopOcc.CompanyCode = qry.CompanyCode;
                        shopOcc.CompanyName = qry.CompanyName;
                        shopOcc.LocationCode = qry.LocationCode;
                        shopOcc.LocationName = qry.LocationName;
                        shopOcc.LevelName = qry.LevelName;
                        shopOcc.InvoiceDate = qry.SAP_PstnDateInDoc.Value;
                        if (qry.SqFeet == 1)
                        {
                            shopOcc.OccupiedAreaSqFt = 0;
                        }
                        else
                        {
                            shopOcc.OccupiedAreaSqFt = qry.SqFeet;
                        }
                        shopOcc.ScPerSqFt = qry.SCPerSqFt;
                        shopOcc.RentPerSqFt = qry.RentPerSqFt;
                        //shopOcc.RentPerSqFt = getActiveRentByShopID(qry.ShopID, currentDate);
                        //shopOcc.ScPerSqFt = getActiveSCByShopID(qry.ShopID, currentDate);
                        shopOcc.SAPCustomerCode = qry.SAPCustomerCode;
                        shopOcc.CustomerName = qry.CustomerName;
                        shopOcc.ShopNo = qry.ShopNo;
                        shopOcc.RentAreaType = qry.RentAreaTypeName;
                        //shopOcc.TotalSqFtInLevel = getTotalSqFtInlevel(qry.CompanyID, qry.LocationID, qry.LevelID,currDate);
                        //shopOcc.TotalSqFtInCompany = getTotalSqFtInCompany(qry.CompanyID,currDate);
                        //shopOcc.TotalSqFtInLocation = getTotalSqFtInLocation(qry.CompanyID, qry.LocationID,currDate);
                        shopocclist.Add(shopOcc);
                    }



                }


                shopocclist = (from s in shopocclist
                               orderby s.CompanyCode, s.LocationCode, s.LevelName
                               select s).ToList();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return shopocclist;
        }

        internal static void UpdateRentSchemeIncreasedRentandSC()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryContract = (from c in context.ContractClosures
                                       select c).ToList();
                    foreach (var qry in qryContract)
                    {
                        if (qry.Contract_RentSchemes.Count > 1)
                        {
                            var qryRentSchemeList = qry.Contract_RentSchemes.ToList();
                            decimal oldrent = 0;


                            decimal increaseRent = 0;


                            foreach (var qryRC in qryRentSchemeList)
                            {

                                increaseRent = oldrent - qryRC.RentPerSqFeet;
                                oldrent = qryRC.RentPerSqFeet;
                            }


                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        internal static List<DataTier.ReportClasses.ShopOccupancy> MisUtilityConsumptionCustomerWise(int compid, int locid, int utilityID, DateTime pFromdate, DateTime pToDate, int pExtendedCustomerID)
        {
            List<DataTier.ReportClasses.ShopOccupancy> utilityReadingList = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {


                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryUtilityReading = (from s in context.Shops
                                             join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                             join comp in context.Companies on s.CompanyID equals comp.CompanyID
                                             join loc in context.Locations on s.LocationID equals loc.LocationID
                                             join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
                                             join inv in context.Invoices on s.ShopID equals inv.ShopID
                                             join ec in context.Extended_Customers on inv.ExtendedCustomerID equals ec.ExtendedCustomerID
                                             join mnth in context.Months on inv.ProcessMonth equals mnth.MonthID
                                             join si in context.Sub_Invoice_Types on inv.SubInvTypeID equals si.SubInvTypeID
                                             where inv.ExtendedCustomerID == pExtendedCustomerID && s.CompanyID == compid && s.LocationID == locid && inv.UtilityID == utilityID && (inv.InvoiceDate >= pFromdate && inv.InvoiceDate <= pToDate) && inv.InvoiceTypeID == 2 && ra.IsAdvertisement == false && inv.IsMaintenance == false
                                             select new { inv.UtilityMeterName, ra.RentAreaTypeName, inv.CustomerName, SAPCustomerCode = ec.SAPAlternateCode, s.ShopID, s.ShopName, s.ShopNo, s.SqFeet, comp.CompanyName, comp.CompanyCode, loc.LocationName, loc.LocationCode, lvl.LevelName, inv.StartReading, inv.EndReading, inv.ProcessYear, mnth.MonthCode, inv.UtilityName, inv.NosUnitsConsumed1, inv.UtilityUnitRate, inv.RentPerMonth, inv.OtherTax, inv.OtherTaxCodes, Total = inv.TotalRentPerMonth, SubInvoiceType = si.SubInvTypeName }).ToList();

                    foreach (var qry in qryUtilityReading)
                    {
                        DataTier.ReportClasses.ShopOccupancy rentutilityObject = new DataTier.ReportClasses.ShopOccupancy();
                        rentutilityObject.CompanyCode = qry.CompanyCode;
                        rentutilityObject.CompanyName = qry.CompanyName;
                        rentutilityObject.CustomerName = qry.CustomerName;
                        rentutilityObject.SAPCustomerCode = qry.SAPCustomerCode;
                        rentutilityObject.LocationCode = qry.LocationCode;
                        rentutilityObject.LocationName = qry.LocationName;
                        rentutilityObject.LevelName = qry.LevelName;
                        rentutilityObject.OccupiedAreaSqFt = qry.SqFeet;
                        rentutilityObject.RentAreaType = qry.RentAreaTypeName;
                        rentutilityObject.ShopNo = qry.ShopNo;
                        rentutilityObject.MeterName = qry.UtilityMeterName;
                        rentutilityObject.StartReading = qry.StartReading;
                        rentutilityObject.EndReading = qry.EndReading;
                        rentutilityObject.NosUnitsConsumed1 = qry.NosUnitsConsumed1;
                        rentutilityObject.Amount = qry.RentPerMonth;
                        rentutilityObject.OtherTax = qry.OtherTax;
                        rentutilityObject.OtherTaxCodes = qry.OtherTaxCodes;
                        rentutilityObject.TotalAmount = qry.Total;
                        rentutilityObject.Year = qry.ProcessYear;
                        rentutilityObject.Month = qry.MonthCode;
                        rentutilityObject.UtilityName = qry.UtilityName;
                        rentutilityObject.UtilityUnitRate = qry.UtilityUnitRate;
                        rentutilityObject.SubInvoiceType = qry.SubInvoiceType;
                        rentutilityObject.RentPeriod = qry.MonthCode + " - " + qry.ProcessYear.ToString();
                        utilityReadingList.Add(rentutilityObject);

                    }


                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

            return utilityReadingList;
        }

        internal static List<DataTier.ReportClasses.ShopOccupancy> MisPromotionalIncomeCW(int compid, int locid, DateTime fromDate, DateTime toDate, int pEextendedCustomerID)
        {
            List<DataTier.ReportClasses.ShopOccupancy> promotionalIncomeList = new List<DataTier.ReportClasses.ShopOccupancy>();

            try
            {
                //List<int> intComps = comps.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                //List<int> intLocs = locs.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));


                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryMonth = (from m in context.Months
                                    select new { m.MonthID }).ToList();

                    //List<int> intMonths = toDate.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));


                    //// promotonal income 
                    var qryPromoIncome = (from inv in context.Invoices
                                          join os in context.OtherServiceCategories on inv.OtherServiceID equals os.OtherServiceID
                                          join comp in context.Companies on inv.CompanyID equals comp.CompanyID
                                          join loc in context.Locations on inv.LocationID equals loc.LocationID
                                          join gc in context.Global_Customers on inv.CustomerID equals gc.CustomerID
                                          join mnth in context.Months on inv.ProcessMonth equals mnth.MonthID
                                          where inv.CompanyID == compid && inv.LocationID == locid && inv.InvoiceDate >= fromDate && inv.InvoiceDate <= toDate && inv.InvoiceTypeID == 3 && inv.ExtendedCustomerID == pEextendedCustomerID
                                          group inv by new { inv.OtherServiceID, inv.ExtendedCustomerID, inv.ProcessYear, inv.ProcessMonth } into g
                                          select new { g.Key.OtherServiceID, ExtendedCustomerID = g.Key.ExtendedCustomerID, Year = g.Key.ProcessYear, Month = g.Key.ProcessMonth, TotalRentPerMonth = g.Sum(x => x.TotalRentPerMonth) }).ToList();
                    if (qryPromoIncome.Count > 0)
                    {
                        foreach (var qryP in qryPromoIncome)
                        {


                            //// promotion categories  
                            //var qryPromoCat = (from p in context.OtherServiceCategories
                            //                   select new { p.OtherServiceID, p.OtherServiceName }).ToList();

                            decimal? totalforMonth = null;

                            var qrytotalforMonth = (from i in context.Invoices
                                                    where i.InvoiceTypeID == 3 && i.ProcessMonth == qryP.Month && i.ProcessYear == qryP.Year && i.ExtendedCustomerID == qryP.ExtendedCustomerID && i.OtherServiceID == qryP.OtherServiceID
                                                    select new { i.TotalRentPerMonth }).ToList();

                            if (qrytotalforMonth.Count > 0)
                            {

                                totalforMonth = qrytotalforMonth.Sum(x => x.TotalRentPerMonth);
                                if (totalforMonth.HasValue)
                                {

                                    DataTier.ReportClasses.ShopOccupancy promoIncome = new DataTier.ReportClasses.ShopOccupancy();
                                    //otherservice name 
                                    var qryOtherService = (from os in context.OtherServiceCategories
                                                           where os.OtherServiceID == qryP.OtherServiceID
                                                           select new { os.OtherServiceName }).FirstOrDefault();

                                    promoIncome.OtherServiceName = qryOtherService.OtherServiceName;

                                    promoIncome.TotalRentPerMonth = totalforMonth.Value;


                                    promoIncome.Month = context.Months.Where(x => x.MonthID == qryP.Month).FirstOrDefault().MonthCode + " - " + qryP.Year.ToString();

                                    // customer name 
                                    var qryCustname = (from ec in context.Extended_Customers
                                                       join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                                       join c in context.Companies on ec.CompanyID equals c.CompanyID
                                                       join l in context.Locations on ec.LocationID equals l.LocationID
                                                       where ec.ExtendedCustomerID == qryP.ExtendedCustomerID
                                                       select new { c.CompanyCode, c.CompanyName, l.LocationCode, l.LocationName, gc.CustomerName }).FirstOrDefault();
                                    promoIncome.CustomerName = qryCustname.CustomerName;
                                    promoIncome.CompanyName = qryCustname.CompanyName;
                                    promoIncome.CompanyCode = qryCustname.CompanyCode;
                                    promoIncome.LocationCode = qryCustname.LocationCode;
                                    promoIncome.LocationName = qryCustname.LocationName;

                                    promotionalIncomeList.Add(promoIncome);
                                }

                            }

                            

                        }
                    }
                                      
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }


            return promotionalIncomeList;
        }

        internal static bool IsTaxCalApplicableByExtendedCustomerId(int p)
        {
            bool istaxapplicable = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                var qryExtendedCust = (from c in context.Extended_Customers
                                       where c.ExtendedCustomerID == p
                                       select new { c.IsTaxApplicable }).FirstOrDefault();
                if (qryExtendedCust != null)
                {
                    istaxapplicable = qryExtendedCust.IsTaxApplicable;
                }


            }
            return istaxapplicable;
        }

        public static string getMonthAbbrName(int pMonth)
        {

            var dtf = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
            string monthName = dtf.GetMonthName(pMonth);
            string abbrvation = dtf.GetAbbreviatedMonthName(pMonth);

            return abbrvation;
        }

        public static decimal getRentperMonth(int pLocID, int pCompID, DateTime pDateAsAt)
        {


            decimal rentPerMonth = 0;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                DateTime fromDate = new DateTime(pDateAsAt.Year, pDateAsAt.Month, 1);
                DateTime toDate = fromDate.AddMonths(1).AddDays(-1).Date;


                List<decimal> total = new List<decimal>();

                var qryRent = (from i in context.Invoices
                               join tr in context.TaxRates on i.MandatoryTaxRateID equals tr.TaxRateID
                               where i.IsConfirmed == true && i.CompanyID == pCompID && i.LocationID == pLocID && i.InvoiceTypeID == 1 && i.SAP_PstnDateInDoc >= fromDate && i.SAP_PstnDateInDoc <= toDate
                               orderby i.InvoiceNo ascending
                               select new { i.InvoiceNo, i.RentPerMonth, tr.TaxRate1 }).ToList();

                foreach (var qry in qryRent)
                {
                    total.Add(qry.RentPerMonth * ((100 + qry.TaxRate1) / 100));
                }

                rentPerMonth = total.Sum();
            }
            return rentPerMonth;
        }


        public static decimal getSCperMonth(int pLocID, int pCompID, DateTime pDateAsAt)
        {
            decimal scperMonth = 0;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    DateTime fromDate = new DateTime(pDateAsAt.Year, pDateAsAt.Month, 1);
                    DateTime toDate = fromDate.AddMonths(1).AddDays(-1).Date;


                    List<decimal> total = new List<decimal>();
                    var qryServiceCharge = (from i in context.Invoices
                                            join tr in context.TaxRates on i.MandatoryTaxRateID equals tr.TaxRateID
                                            where i.IsConfirmed == true && i.CompanyID == pCompID && i.LocationID == pLocID && i.InvoiceTypeID == 1 && (i.SAP_PstnDateInDoc >= fromDate && i.SAP_PstnDateInDoc <= toDate)
                                            select new { i.SCPerMonth, tr.TaxRate1 }).ToList();

                    foreach (var qry in qryServiceCharge)
                    {
                        total.Add(qry.SCPerMonth * ((100 + qry.TaxRate1) / 100));
                    }

                    scperMonth = total.Sum();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }


            return scperMonth;


        }

        public static decimal getTotalRentWithSC(int pLocID, int pCompID, DateTime pDateAsAt)
        {
            decimal totalRentWithSc = 0;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    decimal rentPerMonth = CustomClasses.cCommon_Functions.getRentperMonth(pLocID, pCompID, pDateAsAt);
                    decimal scPerMonth = CustomClasses.cCommon_Functions.getSCperMonth(pLocID, pCompID, pDateAsAt);

                    totalRentWithSc = rentPerMonth + scPerMonth;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return totalRentWithSc;
        }

        public static decimal getRentperSqFtWithout(int pLocID, int pCompID, DateTime pDateAsAt, int? pExtendedCustomerID, decimal totalOccupiedSqFt = 0, decimal rentperMonth = 0)
        {
            decimal renperSqFtWithout = 0;

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    int month = pDateAsAt.Date.Month;
                    int year = pDateAsAt.Date.Year;

                    DateTime dateFrom = new DateTime(pDateAsAt.Year, pDateAsAt.Month, 1);
                    DateTime dateTo = dateFrom.AddMonths(1).AddDays(-1).Date;

                    List<decimal> total = new List<decimal>();
                    decimal rentPerMonth = 0;

                    var qryRent = (from i in context.Invoices
                                   join tr in context.TaxRates on i.MandatoryTaxRateID equals tr.TaxRateID
                                   where i.IsConfirmed == true && i.CompanyID == pCompID && i.LocationID == pLocID && i.InvoiceTypeID == 1 && i.SAP_PstnDateInDoc >= dateFrom && i.SAP_PstnDateInDoc <= dateTo && i.ExtendedCustomerID != pExtendedCustomerID
                                   orderby i.InvoiceNo ascending
                                   select new { i.InvoiceNo, i.RentPerMonth, tr.TaxRate1 }).ToList();

                    foreach (var qry in qryRent)
                    {
                        total.Add(qry.RentPerMonth * ((100 + qry.TaxRate1) / 100));
                    }

                    rentPerMonth = total.Sum();


                    // total exceptional square foots
                    var qryTotalSqFtException = (from i in context.Invoices
                                                 where i.IsConfirmed == true && i.CompanyID == pCompID && i.LocationID == pLocID && i.InvoiceTypeID == 1 && (i.SAP_PstnDateInDoc >= dateFrom && i.SAP_PstnDateInDoc <= dateTo) && i.ExtendedCustomerID == pExtendedCustomerID
                                                 select new { i.AreaInSqFt }).ToList();
                    List<decimal> totalSqFtExcptList = new List<decimal>();
                    foreach (var qry in qryTotalSqFtException)
                    {
                        totalSqFtExcptList.Add(qry.AreaInSqFt);
                    }
                    //--


                    decimal totalSqFtExcpt = totalSqFtExcptList.Sum();




                    //total occupied area 
                    decimal totalOccupied = totalOccupiedSqFt - totalSqFtExcpt;
                    //--
                    if (totalOccupied > 0 && rentperMonth > 0)
                    {
                        renperSqFtWithout = Math.Round(rentPerMonth / totalOccupied, 2);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return renperSqFtWithout;
        }

        public static List<DataTier.ReportClasses.InvoiceSummeryDetail> MisInvoiceSummery(object comps, object locs, object utilityids, DateTime fromDate, DateTime todate)
        {
            try
            {
                List<DataTier.ReportClasses.InvoiceSummeryDetail> listInvoice = new List<DataTier.ReportClasses.InvoiceSummeryDetail>();

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    List<int> intComps = comps.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                    List<int> intLocs = locs.ToString().Split(',').ToList().ConvertAll<int>(x => Convert.ToInt32(x));
                    List<string> intUti = utilityids.ToString().Split(',').ToList().ConvertAll<string>(x => Convert.ToString(x));

                    List<Invoice> invoiceList = new List<Invoice>();
                    invoiceList = context.Invoices.Where(w => intComps.Contains(w.CompanyID) && intLocs.Contains(w.LocationID) && w.SAP_PstnDateInDoc > fromDate && w.SAP_PstnDateInDoc < todate && w.SubInvTypeID.Equals(2) && w.IsConfirmed.Equals(true)).ToList();

                    List<Invoice> invoiceListForReport = new List<Invoice>();
                    foreach (string utiString in intUti)
                    {
                        string prefix = utiString.Split('_')[0].Trim();
                        int mapID = Convert.ToInt32(utiString.Split('_')[1].Trim());

                        switch (prefix)
                        {
                            case "UT":
                                invoiceListForReport.AddRange(invoiceList.Where(w => w.UtilityID.Equals(mapID)).ToList());
                                break;
                            case "RN":
                                invoiceListForReport.AddRange(invoiceList.Where(w => w.InvoiceTypeID.Equals(mapID)).ToList());
                                break;
                            case "OS":
                                invoiceListForReport.AddRange(invoiceList.Where(w => w.OtherServiceID.Equals(mapID)).ToList());
                                break;
                            default:
                                break;
                        }
                    }

                    listInvoice = invoiceListForReport.Select(s => new DataTier.ReportClasses.InvoiceSummeryDetail
                    {
                        Customer = s.CustomerName,
                        InvoiceDate = s.SAP_PstnDateInDoc == null ? DateTime.Now : s.SAP_PstnDateInDoc.Value,
                        InvoiceNo = s.InvoiceNo,
                        InvoiceValue = s.RentPerMonth,
                        ShopNo = s.ShopNo,
                        Naration = s.Naration

                    }).OrderBy(o => o.InvoiceNo).ToList();

                    return listInvoice;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int GetContractCouserIdByInvoiceNo(string invoiceno)
        {
            int contractclouserid = 0;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                //get contactclouserIDby invoiceno
                contractclouserid = (from u in context.Invoices
                                     where u.InvoiceNo == invoiceno
                                     select u.ContractClosureID).FirstOrDefault();


                return contractclouserid;
            }
        }
        public static int GetContractCouserIdByShopNo(int shopId, int LocationID, int CompanyID)
        {
            int contractclouserid = 0;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                //get contactclouserIDby shop
                contractclouserid = (from c in context.ContractClosures
                                     where c.ShopID == shopId && c.LocationID == LocationID && c.CompanyID == CompanyID
                                     select c.ContractClosureID).FirstOrDefault();


                return contractclouserid;
            }
        }
        
        public static bool removeUsedFiles()
        {
            try {
                System.IO.DirectoryInfo di = new DirectoryInfo("C:\\MMS_files");
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                return true;
            }catch(Exception e){
                return false;
            }
            

            
        }
        public static bool writeToTextfile(List<string> pdflist)
        {
            try {
                if ((!File.Exists("smtp.txt"))) //Checking if scores.txt exists or not
                {
                    FileStream fs = File.Create("smtp.txt");
                    fs.Close();
                }
                File.WriteAllText("smtp.txt", String.Empty);
                System.IO.File.WriteAllLines("smtp.txt", pdflist.Select(tb => tb));
                return true;
            
            }catch(Exception e){
                return false;
            }
            
        }
        public static string Encrypt(string clearText, string EncryptionKey)
        {
           // string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText, string EncryptionKey)
        {
            //string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

    }
}
