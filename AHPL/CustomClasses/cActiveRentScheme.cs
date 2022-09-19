using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using DataTier;
using System.Windows.Forms;
using System.Transactions;
namespace MMS
{
   public static class cActiveRentScheme
    {
       public static int ContractClosureID { get; set; }
       public static int Contract_RentSchemeID { get; set; }


       public static Contract_RentSchemes getActiveRentScheme(int pContractClosureID, DateTime pDate)
       {
           Contract_RentSchemes oCRentScheme;
           using (AHPL_DBEntities context = new AHPL_DBEntities())
           {
               oCRentScheme = (from c in context.Contract_RentSchemes
                               where c.ContractClosureID == pContractClosureID && c.FromDate >= pDate && c.ToDate <= pDate
                               select c).LastOrDefault();
               if (oCRentScheme == null)
               {

                   oCRentScheme = (from c in context.Contract_RentSchemes
                                   where c.ContractClosureID == pContractClosureID
                                   select c).LastOrDefault();
               }

           }

           return oCRentScheme;
       }

       public static bool IsActiveRentScheme(int pContractClosureID,DateTime pDate,DateTime pFromdate, DateTime pToDate) 
       {
           bool IsActive = true;
           try
           {
               using (AHPL_DBEntities context = new AHPL_DBEntities())
               {

                   using (TransactionScope trs = new TransactionScope())
                   {
                       //if (context.Connection.State == System.Data.ConnectionState.Closed) { context.Connection.Open(); }
                       var qryIsActive = (from c in context.Contract_RentSchemes
                                          where c.ContractClosureID == pContractClosureID && (c.FromDate <= pFromdate.Date && c.ToDate >= pToDate && c.FromDate <= pFromdate && c.ToDate >= pDate.Date)
                                          select c).ToList();
                       if (qryIsActive.Count > 0)
                       { 
                           IsActive = true;
                           //trs.Complete();
                       }
                       else 
                       { 
                           IsActive = false;
                           //trs.Complete();
                       }
                       trs.Complete();
                   }

               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           return IsActive;

       }


       public static cRentScheme getDefaultOrLastRate(DateTime pDate, int pContractClauseID,DateTime pFromDate, DateTime pTodate)
       {
           cRentScheme rentscheme = new cRentScheme();

           using (AHPL_DBEntities context = new AHPL_DBEntities())
           {
               bool isTaxCustomer = false;

               ////var qryRentScheme = (from c in context.ContractClosures
               ////                     join cd in context.Contract_RentSchemes on c.ContractClosureID equals cd.ContractClosureID
               ////                     where (cd.FromDate <= pFromDate && cd.ToDate >= pTodate) && c.ContractClosureID == pContractClauseID
               ////                     orderby cd.Contract_RentSchemeID descending
               ////                     select new
               ////                     {
               ////                         c.ContractClosureID,
               ////                         c.ExtendedCustomerID,
               ////                         c.FloorArea,
               ////                         c.ShopID,
               ////                         c.ShopNo,
               ////                         c.ShopName,
               ////                         c.LevelID,
               ////                         c.LocationID,
               ////                         c.CompanyID,
               ////                         cd.Contract_RentSchemeID,
               ////                         cd.FromDate,
               ////                         cd.RentPerSqFeet,
               ////                         cd.SCPerSqFeet,
               ////                         c.ContractClosureName,
               ////                         RentPerMonth = (c.FloorArea * cd.RentPerSqFeet) + (c.FloorArea * cd.SCPerSqFeet),
               ////                         SCperMonth = c.FloorArea * cd.SCPerSqFeet,
               ////                         RentWithSCperSqFeet = cd.RentPerSqFeet + cd.SCPerSqFeet,
               ////                         RentWithSCperMonth = (cd.RentPerSqFeet + cd.SCPerSqFeet) * c.FloorArea
               ////                     }).FirstOrDefault();

               /////Roshan..25Feb2015..
               /////Comment above to avoid, wrong contract period selecting issue.
               /////using below method,invoicess are generating to lowest rates.Then have to put adjestment to collect less amount. Ajith is agreed to way. 

               var qryRentScheme = (from c in context.ContractClosures
                                    join cd in context.Contract_RentSchemes on c.ContractClosureID equals cd.ContractClosureID
                                    where (cd.FromDate <= pFromDate && cd.ToDate >= pFromDate) && c.ContractClosureID == pContractClauseID
                                    orderby cd.Contract_RentSchemeID descending
                                    select new
                                    {
                                        c.ContractClosureID,
                                        c.ExtendedCustomerID,
                                        c.FloorArea,
                                        c.ShopID,
                                        c.ShopNo,
                                        c.ShopName,
                                        c.LevelID,
                                        c.LocationID,
                                        c.CompanyID,
                                        cd.Contract_RentSchemeID,
                                        cd.FromDate,
                                        cd.RentPerSqFeet,
                                        cd.SCPerSqFeet,
                                        c.ContractClosureName,
                                        RentPerMonth = (c.FloorArea * cd.RentPerSqFeet) + (c.FloorArea * cd.SCPerSqFeet),
                                        SCperMonth = c.FloorArea * cd.SCPerSqFeet,
                                        RentWithSCperSqFeet = cd.RentPerSqFeet + cd.SCPerSqFeet,
                                        RentWithSCperMonth = (cd.RentPerSqFeet + cd.SCPerSqFeet) * c.FloorArea  
                                    }).FirstOrDefault();
               
               if (qryRentScheme == null)
               {
                   var qryRentScheme1 = (from c in context.ContractClosures                                   
                                    join cd in context.Contract_RentSchemes on c.ContractClosureID equals cd.ContractClosureID
                                    where c.ContractClosureID == pContractClauseID
                                         orderby cd.Contract_RentSchemeID descending
                                         select new
                                         {
                                             c.ContractClosureID,
                                             //cont.ContractID,
                                             c.ExtendedCustomerID,
                                             c.FloorArea,
                                             c.ShopID,
                                             c.ShopNo,
                                             c.ShopName,
                                             c.LevelID,
                                             c.LocationID,
                                             c.CompanyID,
                                             cd.Contract_RentSchemeID,
                                             cd.FromDate,
                                             cd.ToDate,
                                             cd.RentPerSqFeet,
                                             cd.SCPerSqFeet,
                                             c.ContractClosureName,
                                             RentPerMonth = (c.FloorArea * cd.RentPerSqFeet) + (c.FloorArea * cd.SCPerSqFeet),
                                             SCperMonth = c.FloorArea * cd.SCPerSqFeet,
                                             RentWithSCperSqFeet = cd.RentPerSqFeet + cd.SCPerSqFeet,
                                             RentWithSCperMonth = (cd.RentPerSqFeet + cd.SCPerSqFeet) * c.FloorArea
                                         }).FirstOrDefault();
                   if (qryRentScheme1 == null)
                   {
                       rentscheme = null;
                       return rentscheme;
                   }
                   else
                   {

                       rentscheme.CompanyID = qryRentScheme1.CompanyID;
                       rentscheme.Contract_RentSchemeID = qryRentScheme1.Contract_RentSchemeID;
                       rentscheme.ContractClosureID = qryRentScheme1.ContractClosureID;
                       //rentscheme.ContractID = qryRentScheme1.ContractID;
                       rentscheme.ExtendedCustomerID = qryRentScheme1.ExtendedCustomerID;
                       rentscheme.FloorArea = qryRentScheme1.FloorArea;
                       rentscheme.IsTaxCustomer = isTaxCustomer;
                       rentscheme.LevelID = qryRentScheme1.LevelID;
                       rentscheme.LocationID = qryRentScheme1.LocationID;
                       rentscheme.RentPerMonth = qryRentScheme1.RentPerMonth;
                       rentscheme.RentPerSqFeet = qryRentScheme1.RentPerSqFeet;
                       rentscheme.SCperSqFeet = qryRentScheme1.SCPerSqFeet;
                       rentscheme.SCperMonth = qryRentScheme1.SCperMonth;
                       rentscheme.RentWithSCperMonth = qryRentScheme1.RentWithSCperMonth;
                       rentscheme.RentWithSCperSqft = qryRentScheme1.RentWithSCperSqFeet;

                       rentscheme.ShopID = qryRentScheme1.ShopID;
                       rentscheme.ShopName = qryRentScheme1.ShopName;
                       rentscheme.ShopNo = qryRentScheme1.ShopNo;
                       rentscheme.ContractName = qryRentScheme1.ContractClosureName; // contract's nam
                       if (qryRentScheme1.ToDate < pFromDate)
                       {
                           rentscheme.IsContractOutOfRange = true;
                           rentscheme.FromDate = qryRentScheme1.FromDate;
                       }
                       else
                       {
                           rentscheme.IsContractOutOfRange = false;
                           rentscheme.FromDate = pFromDate;
                       }
                   }
               }
               
               
               if (qryRentScheme != null)
               {
                   if (qryRentScheme.ExtendedCustomerID > 0)
                   {
                       var qryCust = (from ec in context.Extended_Customers
                                      join c in context.Global_Customers on ec.CustomerID equals c.CustomerID
                                      join ctx in context.Customer_Taxes on c.CustomerID equals ctx.CustomerID
                                      join t in context.Taxes on ctx.TaxID equals t.TaxID 
                                      where ec.ExtendedCustomerID == qryRentScheme.ExtendedCustomerID && t.IsMandatory ==false
                                      select new { ec.ExtendedCustomerID }).ToList();
                       if (qryCust.Count > 0)
                       {
                           isTaxCustomer = true;
                       }                         

                   }
               }
               
               if (qryRentScheme != null)
               {
                   rentscheme.CompanyID = qryRentScheme.CompanyID;
                   rentscheme.Contract_RentSchemeID = qryRentScheme.Contract_RentSchemeID;
                   rentscheme.ContractClosureID = qryRentScheme.ContractClosureID;
                   //rentscheme.ContractID = qryRentScheme.ContractID;
                   rentscheme.ExtendedCustomerID = qryRentScheme.ExtendedCustomerID;
                   rentscheme.FloorArea = qryRentScheme.FloorArea;
                   rentscheme.IsTaxCustomer = isTaxCustomer;
                   rentscheme.LevelID = qryRentScheme.LevelID;
                   rentscheme.LocationID = qryRentScheme.LocationID;
                   rentscheme.RentPerMonth = qryRentScheme.RentPerMonth;
                   rentscheme.RentPerSqFeet = qryRentScheme.RentPerSqFeet;
                   rentscheme.SCperSqFeet = qryRentScheme.SCPerSqFeet;
                   rentscheme.SCperMonth = qryRentScheme.SCperMonth;
                   rentscheme.RentWithSCperMonth = qryRentScheme.RentWithSCperMonth;
                   rentscheme.RentWithSCperSqft = qryRentScheme.RentWithSCperSqFeet;

                   rentscheme.ShopID = qryRentScheme.ShopID;
                   rentscheme.ShopName = qryRentScheme.ShopName;
                   rentscheme.ShopNo = qryRentScheme.ShopNo;
                   rentscheme.ContractName = qryRentScheme.ContractClosureName; // contract's nam
                   if (qryRentScheme.FromDate >= pFromDate)
                   {
                       rentscheme.FromDate = qryRentScheme.FromDate;
                   }
                   else
                   {
                       rentscheme.FromDate = pFromDate;
                   }
               }
           }

           return rentscheme;

       }

       public static cRentScheme getDefaultOrLastRateByDate(DateTime pCurrentDate, int pContractClauseID)
       {
           cRentScheme _rentscheme = new cRentScheme();

           using (AHPL_DBEntities context = new AHPL_DBEntities())
           {
               var qryRentScheme = (from  c in context.ContractClosures 
                                    join cd in context.Contract_RentSchemes on c.ContractClosureID equals cd.ContractClosureID
                                    where cd.FromDate <= pCurrentDate && cd.ToDate >= pCurrentDate  &&  c.ContractClosureID == pContractClauseID
                                    select new
                                    {
                                        c.ContractClosureID,
                                        c.ContractID,
                                        c.ExtendedCustomerID,
                                        c.FloorArea,
                                        c.ShopID,
                                        c.ShopNo,
                                        c.ShopName,
                                        c.LevelID,
                                        c.LocationID,
                                        c.CompanyID,
                                        cd.Contract_RentSchemeID,
                                        cd.FromDate,
                                        cd.ToDate,
                                        cd.Period,
                                        cd.RentPerSqFeet,
                                        cd.SCPerSqFeet,
                                        c.IsPromotion,
                                        c.ContractClosureName,
                                        RentPerMonth = (c.FloorArea * cd.RentPerSqFeet) + (c.FloorArea * cd.SCPerSqFeet),
                                        SCperMonth = c.FloorArea * cd.SCPerSqFeet,
                                        RentWithSCperSqFeet = cd.RentPerSqFeet + cd.SCPerSqFeet,
                                        RentWithSCperMonth = (cd.RentPerSqFeet + cd.SCPerSqFeet) * c.FloorArea
                                    }).FirstOrDefault();
               if (qryRentScheme != null)
               {
                   _rentscheme.ContractClosureID = qryRentScheme.ContractClosureID;
                   _rentscheme.Contract_RentSchemeID = qryRentScheme.Contract_RentSchemeID;
                   _rentscheme.ContractID = qryRentScheme.ContractID;
                   _rentscheme.FloorArea = qryRentScheme.FloorArea;
                   _rentscheme.ShopID = qryRentScheme.ShopID;
                   _rentscheme.ShopName = qryRentScheme.ShopName;
                   _rentscheme.ShopNo = qryRentScheme.ShopNo;
                   _rentscheme.RentPerSqFeet = qryRentScheme.RentPerSqFeet;
                   _rentscheme.RentPerMonth = qryRentScheme.FloorArea * qryRentScheme.RentPerSqFeet;
                   _rentscheme.SCperSqFeet = qryRentScheme.SCPerSqFeet;
                   _rentscheme.SCperMonth = qryRentScheme.FloorArea * qryRentScheme.SCPerSqFeet;
                   _rentscheme.LocationID = qryRentScheme.LocationID;
                   _rentscheme.LevelID = qryRentScheme.LevelID;
                   _rentscheme.FromDate = qryRentScheme.FromDate;
                   _rentscheme.ToDate = qryRentScheme.ToDate;
                   //_rentscheme.Period = (int) qryRentScheme.Period.Value; 

                   _rentscheme.ExtendedCustomerID = qryRentScheme.ExtendedCustomerID;
                   _rentscheme.RentWithSCperSqft = qryRentScheme.RentPerSqFeet + qryRentScheme.SCPerSqFeet;
                   _rentscheme.RentWithSCperMonth = (qryRentScheme.RentPerSqFeet + qryRentScheme.SCPerSqFeet) * qryRentScheme.FloorArea;
                   if (qryRentScheme.IsPromotion == true)
                   {
                       _rentscheme.RentPerSqFeet = qryRentScheme.RentPerSqFeet;
                       _rentscheme.RentPerMonth = qryRentScheme.RentPerSqFeet;
                       _rentscheme.RentWithSCperSqft = qryRentScheme.RentPerSqFeet;
                       _rentscheme.RentWithSCperMonth = qryRentScheme.RentPerSqFeet;
                       _rentscheme.ContractName = qryRentScheme.ContractClosureName;
                   }
               }

               else
               {
                   var qryRentSchemeLast = (from c in context.ContractClosures
                                            join cd in context.Contract_RentSchemes on c.ContractClosureID equals cd.ContractClosureID
                                            where c.ContractClosureID == pContractClauseID
                                            select new
                                            {
                                                c.ContractClosureID,
                                                c.ContractID,
                                                c.ExtendedCustomerID,
                                                c.FloorArea,
                                                c.ShopID,
                                                c.ShopNo,
                                                c.ShopName,
                                                c.LevelID,
                                                c.LocationID,
                                                c.CompanyID,
                                                cd.Contract_RentSchemeID,
                                                cd.FromDate,
                                                cd.ToDate,
                                                cd.Period,
                                                c.IsPromotion,
                                                c.ContractClosureName,
                                                cd.RentPerSqFeet,
                                                cd.SCPerSqFeet,
                                                RentPerMonth = (c.FloorArea * cd.RentPerSqFeet) + (c.FloorArea * cd.SCPerSqFeet),
                                                SCperMonth = c.FloorArea * cd.SCPerSqFeet,
                                                RentWithSCperSqFeet = cd.RentPerSqFeet + cd.SCPerSqFeet,
                                                RentWithSCperMonth = (cd.RentPerSqFeet + cd.SCPerSqFeet) * c.FloorArea
                                            }).AsEnumerable().LastOrDefault();

                   if (qryRentSchemeLast != null)
                   {
                       _rentscheme.ContractClosureID = qryRentSchemeLast.ContractClosureID;
                       _rentscheme.Contract_RentSchemeID = qryRentSchemeLast.Contract_RentSchemeID;
                       _rentscheme.ContractID = qryRentSchemeLast.ContractID;
                       _rentscheme.FloorArea = qryRentSchemeLast.FloorArea;
                       _rentscheme.ShopID = qryRentSchemeLast.ShopID;
                       _rentscheme.ShopName = qryRentSchemeLast.ShopName;
                       _rentscheme.ShopNo = qryRentSchemeLast.ShopNo;
                       if (qryRentSchemeLast.IsPromotion == true)
                       {
                           _rentscheme.RentPerSqFeet = qryRentSchemeLast.RentPerSqFeet;
                           _rentscheme.RentPerMonth = qryRentSchemeLast.RentPerSqFeet;
                           _rentscheme.SCperSqFeet = qryRentSchemeLast.RentPerSqFeet;
                           _rentscheme.SCperMonth = qryRentSchemeLast.RentPerSqFeet;
                           _rentscheme.RentWithSCperSqft = qryRentSchemeLast.RentPerSqFeet;
                           _rentscheme.RentWithSCperMonth = qryRentSchemeLast.RentPerSqFeet;
                           _rentscheme.ContractName = qryRentSchemeLast.ContractClosureName;
                       }
                       else
                       {
                           _rentscheme.RentPerSqFeet = qryRentSchemeLast.RentPerSqFeet;
                           _rentscheme.RentPerMonth = qryRentSchemeLast.FloorArea * qryRentSchemeLast.RentPerSqFeet;
                           _rentscheme.SCperSqFeet = qryRentSchemeLast.SCPerSqFeet;
                           _rentscheme.SCperMonth = qryRentSchemeLast.FloorArea * qryRentSchemeLast.SCPerSqFeet;
                           _rentscheme.RentWithSCperSqft = qryRentSchemeLast.RentPerSqFeet + qryRentSchemeLast.SCPerSqFeet;
                           _rentscheme.RentWithSCperMonth = (qryRentSchemeLast.RentPerSqFeet + qryRentSchemeLast.SCPerSqFeet) * qryRentSchemeLast.FloorArea;

                       }
                       _rentscheme.LocationID = qryRentSchemeLast.LocationID;
                       _rentscheme.LevelID = qryRentSchemeLast.LevelID;
                       _rentscheme.FromDate = qryRentSchemeLast.FromDate;
                       _rentscheme.ToDate = qryRentSchemeLast.ToDate;
                       _rentscheme.Period = (int) qryRentSchemeLast.Period;
                       _rentscheme.ExtendedCustomerID = qryRentSchemeLast.ExtendedCustomerID;

                   }
               }
           }
          
           return _rentscheme;

       }
    }

   public class cRentScheme
   {
       public int ContractClosureID { get; set; }
       public int Contract_RentSchemeID { get; set; }
       public decimal RentPerSqFeet { get; set; }
       public decimal SCperSqFeet { get; set; }
       public decimal RentPerMonth { get; set; }
       public decimal SCperMonth { get; set; }
       public decimal RentWithSCperSqft { get; set; }
       public decimal RentWithSCperMonth { get; set; }
       public int ContractID { get; set; }
       public int ShopID { get; set; }
       public string ShopNo { get; set; }
       public string ShopName { get; set; }
       public decimal FloorArea { get; set; }
       public int CompanyID { get; set; }       
       public int LocationID { get; set; }
       public int LevelID { get; set; }
       public int ExtendedCustomerID { get; set; }
       public bool IsTaxCustomer { get; set; }
       public DateTime FromDate { get; set; }
       public DateTime ToDate { get; set; }
       public int Period { get; set; }
       public string ContractName { get; set; }
       public bool IsContractOutOfRange { get; set; }

   }
}
