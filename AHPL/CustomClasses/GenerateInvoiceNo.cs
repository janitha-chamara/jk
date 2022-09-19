using System;
using System.Collections.Generic;
using System.ComponentModel;
//using MMS.DataTier;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using System.Data.Linq.SqlClient;
using DataTier;
using MMS.CustomClasses;

namespace MMS
{
    public static class cGenerateInvoiceNo
    {
        public enum eInvoiceTypes
        {
            Rent = 1,
            Utility = 2,
            Credit_Note = 3,
            Adjustment = 4,
            Other_Services = 5
        }

        public static string generateUInvoce(int pLocationID, int pSubInvType = 0, int pCompID = 0, int pUtilityID = 0)
        {
            string strInvo = "";

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                // getting location's invoice prefix
                var qryInvPrefix = (from l in context.Locations
                                    where l.LocationID == pLocationID
                                    select new { l.InvoicePrefix }).First();
                string locInvPrefix = "";
                string InvoicePrefix = "";

                if (qryInvPrefix != null)
                {
                    locInvPrefix = qryInvPrefix.InvoicePrefix;
                }

                // getting Utility's Prefix
                var qryUtitlyInvPrefix = (from u in context.Utilities
                                          where u.UtilityID == pUtilityID
                                          select new { u.InvoicePrefix }).First();
                if (qryUtitlyInvPrefix != null)
                {
                    InvoicePrefix = qryUtitlyInvPrefix.InvoicePrefix;
                }

                if (pSubInvType == 1)
                {


                }

            }



            return strInvo;
        }

        public static string GenerateOtherServiceInvoice(int pLocationID, List<cGen_Rent_Invoice> recentInvoiceList, List<cGen_Rent_Invoice> tobeconfirmedInvoiceList, int pSubInvType = 3, int pCompID = 0, int pOtherServiceID = 0)
        {
            string strInvo = "";
            int intInvNo = 0;
            //bool res = false;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryInvPrefix = (from l in context.Locations
                                    where l.LocationID == pLocationID
                                    select new { l.InvoicePrefix }).First();
                string locInvPrefix = "";
                string InvoicePrefix = "";
                //string UtilityPrefix = "";

                if (qryInvPrefix != null)
                {
                    locInvPrefix = qryInvPrefix.InvoicePrefix;
                }


                /// Other Service Invoice Prefix 
                var qryOtherS = (from os in context.OtherServiceCategories
                                 where os.OtherServiceID == pOtherServiceID
                                 select new { os.InvoicePrefix }).FirstOrDefault();
                if (qryOtherS != null)
                {
                    InvoicePrefix = qryOtherS.InvoicePrefix;
                }

                if (pSubInvType == 1 || pSubInvType == 3) // Invoice or Adjustment
                {
                    //querying other service 
                    var qryMaxInvNo = (from inv in tobeconfirmedInvoiceList
                                       where inv.InvoiceTypeID == 3 && inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.OtherServiceID == pOtherServiceID && (inv.SubInvTypeID == 1 || inv.SubInvTypeID == 3)
                                       group inv by inv.InvoiceTypeID into g
                                       select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();



                    if (qryMaxInvNo == null)
                    {
                        intInvNo = 1;
                    }
                    else
                    {
                        intInvNo = qryMaxInvNo.maxnum;

                        if (intInvNo == 0) // if current list containts sequence No is 0 or null , then qyuerying from Context.Invoice
                        {
                            var qryMaxInvNoContext = (from inv in context.Invoices
                                                      where inv.InvoiceTypeID == 3 && inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.OtherServiceID == pOtherServiceID && (inv.SubInvTypeID == 1 || inv.SubInvTypeID == 3)
                                                      group inv by inv.InvoiceTypeID into g
                                                      select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                            if (qryMaxInvNoContext == null)
                            { intInvNo = 0; }
                            else
                            {
                                if (qryMaxInvNoContext.maxnum == 0)
                                {
                                    intInvNo = qryMaxInvNoContext.maxnum;
                                }
                                else
                                {
                                    var qryMaxInvNoContext1 = (from inv in context.Invoices
                                                               where inv.InvoiceTypeID == 3 && inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.OtherServiceID == pOtherServiceID && (inv.SubInvTypeID == 1 || inv.SubInvTypeID == 3)
                                                               group inv by inv.InvoiceTypeID into g
                                                               select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();
                                    if (qryMaxInvNoContext1 == null)
                                    {
                                        intInvNo = 0;
                                    }
                                    else
                                    {
                                        if (qryMaxInvNoContext1.maxnum == 0)
                                        {
                                            intInvNo = 0;
                                        }
                                        else
                                        {
                                            intInvNo = qryMaxInvNoContext1.maxnum;
                                        }

                                    }

                                }
                            }
                        }

                        intInvNo++;
                        //maxinvno++;
                    }
                }

                //-----

                #region CreditNote
                if (pSubInvType == 2) // Credit Note 
                {
                    InvoicePrefix = "CN";

                    var qryMaxInvNo = (from inv in tobeconfirmedInvoiceList
                                       where inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID == pSubInvType
                                       group inv by inv.InvoiceTypeID into g
                                       select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();


                    if (qryMaxInvNo != null)
                    {
                        if (qryMaxInvNo.maxnum == 0)
                        {

                            // querying max invoice number from recent invoice list
                            var qryMaxInvNoContext = (from inv in context.Invoices
                                                      where inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID == pSubInvType
                                                      group inv by inv.SubInvTypeID into g
                                                      select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                            if (qryMaxInvNoContext != null)
                            {
                                if (qryMaxInvNoContext.maxnum == 0)
                                {
                                    intInvNo = 0;
                                }
                                else
                                {
                                    intInvNo = qryMaxInvNoContext.maxnum;

                                }
                            }
                            else
                            {
                                intInvNo = 0;
                            }
                        }
                        else
                        {
                            intInvNo = qryMaxInvNo.maxnum;
                        }

                    }
                    else
                    {
                        intInvNo = 0;

                        //intInvNo = qryMaxInvNo.maxnum;
                        //intInvNo++;
                        //maxinvno++;
                    }

                    intInvNo++;

                }
                #endregion


                ////formating the invoice 
                string formatedInvNo = FormatInvoiceNo(intInvNo, locInvPrefix, InvoicePrefix);

                ////26June2014..to avoid duplicates..roshan..nimal's request
                formatedInvNo = CheckInvoiceNoExist(intInvNo, context, formatedInvNo, locInvPrefix, InvoicePrefix);

                strInvo = formatedInvNo;


            }

            return strInvo;
        }

        public static string generateInvoce(int pInvoiceType, int pLocationID, int pUtilityType = 0, int pCompID = 0)
        {
            string strInvo = "";

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryInvPrefix = (from l in context.Locations
                                    where l.LocationID == pLocationID
                                    select new { l.InvoicePrefix }).First();
                string locInvPrefix = "";
                string InvoicePrefix = "";
                //string UtilityPrefix = "";

                if (qryInvPrefix != null)
                {
                    locInvPrefix = qryInvPrefix.InvoicePrefix;
                }

                if (pInvoiceType == 1)
                {
                    InvoicePrefix = "R";
                }

                if (pInvoiceType == 2)
                {
                    var qryUtitlyInvPrefix = (from u in context.Utilities
                                              where u.UtilityID == pUtilityType
                                              select new { u.InvoicePrefix }).First();
                    if (qryUtitlyInvPrefix != null)
                    {
                        InvoicePrefix = qryUtitlyInvPrefix.InvoicePrefix;
                    }
                }
                if (pUtilityType > 0)
                {
                    var qryMaxInvNo = (from inv in context.Invoices
                                       where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.UtilityID == pUtilityType
                                       group inv by inv.InvoiceTypeID into g
                                       select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();
                    int intInvNo = 0;


                    if (qryMaxInvNo == null)
                    {
                        intInvNo = 1;
                    }
                    else
                    {
                        intInvNo = qryMaxInvNo.maxnum;
                        intInvNo++;
                        //maxinvno++;
                    }

                    ////formating the invoice 
                    string formatedInvNo = FormatInvoiceNo(intInvNo, locInvPrefix, InvoicePrefix);

                    ////26June2014..to avoid duplicates..roshan..nimal's request
                    formatedInvNo = CheckInvoiceNoExist(intInvNo, context, formatedInvNo, locInvPrefix, InvoicePrefix);

                    strInvo = formatedInvNo;


                }
                else
                {
                    var qryMaxInvNo = (from inv in context.Invoices
                                       where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                       group inv by inv.InvoiceTypeID into g
                                       select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();
                    int intInvNo = 0;


                    if (qryMaxInvNo == null)
                    {
                        intInvNo = 1;
                    }
                    else
                    {
                        intInvNo = qryMaxInvNo.maxnum;
                        intInvNo++;
                        //maxinvno++;
                    }


                    ////formating the invoice 
                    string formatedInvNo = FormatInvoiceNo(intInvNo, locInvPrefix, InvoicePrefix);

                    ////26June2014..to avoid duplicates..roshan..nimal's request
                    formatedInvNo = CheckInvoiceNoExist(intInvNo, context, formatedInvNo, locInvPrefix, InvoicePrefix);

                    strInvo = formatedInvNo;

                }


            }

            return strInvo;

        }


        public static string generateInvoice(int pInvoiceType, int pLocationID, List<cGen_Rent_Invoice> _GenInvList, List<cGen_Rent_Invoice> _GenInvList1, int pCompID = 0, int SubInvType = 3, int pUtilityID = 0)
        {
            string strInvo = "";
            int intInvNo = 0;
            bool res = false;

            ////20Oct2014..log invoice gen process..to capture duplicating issue
            Suport.LogEntry("generateInvoice start");

            ////20Oct2014..log invoice gen process..to capture duplicating issue
            Suport.LogEntry("Invoice Type:" + pInvoiceType + ", Location ID:" + pLocationID + ", Company ID:" + pCompID + ", SubInv Type ID:" + SubInvType
                + ", Utility ID:" + pUtilityID + ", Invoice C1:" + _GenInvList.Count + ", Invoice C2:" + _GenInvList1.Count);

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryInvPrefix = (from l in context.Locations
                                    where l.LocationID == pLocationID
                                    select new { l.InvoicePrefix }).First();
                string locInvPrefix = "";
                string InvoicePrefix = "";

                if (qryInvPrefix != null)
                {
                    locInvPrefix = qryInvPrefix.InvoicePrefix;
                }

                if (pInvoiceType == 1)
                {
                    if (SubInvType == 1 || SubInvType == 3)  // Adjustment OR invoice
                    {
                        InvoicePrefix = "R";
                    }

                    if (SubInvType == 2)
                    {
                        InvoicePrefix = "CN";
                    }
                }

                if (pInvoiceType == 2)
                {
                    var qryUtitlyInvPrefix = (from u in context.Utilities
                                              where u.UtilityID == pUtilityID
                                              select new { u.InvoicePrefix }).First();
                    if (qryUtitlyInvPrefix != null)
                    {
                        InvoicePrefix = qryUtitlyInvPrefix.InvoicePrefix;
                    }
                }


                if (pUtilityID > 0)
                {

                    if (_GenInvList.Count == 0)
                    {
                        var qryMaxInvNo = (from inv in _GenInvList1
                                           where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                           group inv by inv.InvoiceTypeID into g
                                           select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                        res = int.TryParse(qryMaxInvNo.maxnum.ToString(), out intInvNo);

                        if (res == false) { intInvNo = 0; }

                        if (intInvNo == 0)
                        {
                            var qryMaxNo = (from inv in context.Invoices
                                            where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                            group inv by inv.InvoiceTypeID into g
                                            select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();
                            intInvNo = qryMaxNo.maxnum;
                            intInvNo++;

                        }
                        else
                        {

                            intInvNo = qryMaxInvNo.maxnum;
                            intInvNo++;
                        }
                    }
                    else
                    {
                        if (SubInvType == 1 || SubInvType == 3) // Adjustment Or Invoice
                        {
                            ////var qryMaxInvNo = (from inv in _GenInvList
                            ////                   where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID ==SubInvType
                            ////                   group inv by inv.InvoiceTypeID into g
                            ////                   select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                            ////Comment above query and implemented below(remove inv.SubInvTypeID ) to avoid dupplicate invoice no issue for Adjustment Or Invoice..25March2014..roshan
                            ////01December2014 added '&& inv.SubInvTypeID != 2' to below query  
                            var qryMaxInvNo = (from inv in _GenInvList
                                               where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                               && inv.SubInvTypeID != 2
                                               group inv by inv.InvoiceTypeID into g
                                               select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                            if (qryMaxInvNo != null)
                            {
                                res = int.TryParse(qryMaxInvNo.maxnum.ToString(), out intInvNo);

                                if (res == false) { intInvNo = 0; }
                            }


                            intInvNo = qryMaxInvNo.maxnum;
                            intInvNo++;

                        }

                        if (SubInvType == 2) // Credit Note 
                        {
                            InvoicePrefix = "CN";
                            ////01December2014 added '&& inv.SubInvTypeID== SubInvType' to blow query 
                            var qryMaxInvNo = (from inv in _GenInvList
                                               where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                               && inv.SubInvTypeID == SubInvType
                                               group inv by inv.SubInvTypeID into g
                                               select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                            if (qryMaxInvNo != null)
                            {
                                res = int.TryParse(qryMaxInvNo.maxnum.ToString(), out intInvNo);
                                if (res == false) { intInvNo = 0; }

                                intInvNo = qryMaxInvNo.maxnum;
                                intInvNo++;
                            }
                            else
                            {
                                var qryMaxInvNoContext = (from inv in context.Invoices
                                                          where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID == SubInvType
                                                          group inv by inv.SubInvTypeID into g
                                                          select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                                intInvNo = qryMaxInvNoContext.maxnum;

                                intInvNo++;
                            }

                        }


                    }

                    ////20Oct2014..log invoice gen process..to capture duplicating issue
                    Suport.LogEntry("InvNo:" + intInvNo + ",locInvPrefix:" + locInvPrefix + ", InvoicePrefix:" + InvoicePrefix);

                    ////formating the invoice 
                    string formatedInvNo = FormatInvoiceNo(intInvNo, locInvPrefix, InvoicePrefix);

                    ////20Oct2014..log invoice gen process..to capture duplicating issue
                    Suport.LogEntry("BF formatedInvNo:" + formatedInvNo);

                    ////26June2014..to avoid duplicates..roshan..nimal's request
                    formatedInvNo = CheckInvoiceNoExist(intInvNo, context, formatedInvNo, locInvPrefix, InvoicePrefix);

                    ////20Oct2014..log invoice gen process..to capture duplicating issue
                    Suport.LogEntry("AF formatedInvNo:" + formatedInvNo);

                    strInvo = formatedInvNo;
                }
                else
                {
                    if (SubInvType == 1 || SubInvType == 3)
                    {
                        ////var qryMaxInvNo = (from inv in _GenInvList1
                        ////                   where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                        ////                   group inv by inv.InvoiceTypeID into g
                        ////                   select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                        ////Comment above and implement below to avoid invoice no duplication issue..01December2014..
                        ////Add new filter critaria to filter 'SubInvTypeID !=2'
                        ////If want to remove above hardcoded value('SubInvTypeID !=2') need to call db , after removing below code

                        var qryMaxInvNo = (from inv in _GenInvList1
                                           where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                           && inv.SubInvTypeID != 2
                                           group inv by inv.InvoiceTypeID into g
                                           select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                        if (qryMaxInvNo == null)
                        {
                            intInvNo = 1;
                        }
                        else
                        {
                            intInvNo = qryMaxInvNo.maxnum;
                            if (intInvNo == 0) // if current list containts sequence No is 0 or null , then qyuerying from Context.Invoice
                            {
                                ////var qryMaxInvNoContext = (from inv in context.Invoices
                                ////                          where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                ////                          group inv by inv.InvoiceTypeID into g
                                ////                          select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                                var qryMaxInvNoContext = (from inv in context.Invoices
                                                          where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                                          && inv.SubInvTypeID != 2
                                                          group inv by inv.InvoiceTypeID into g
                                                          select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                                intInvNo = qryMaxInvNoContext.maxnum;
                            }

                            intInvNo++;
                        }
                    }

                    if (SubInvType == 2) // Credit Note 
                    {
                        var qryMaxInvNo = (from inv in _GenInvList1
                                           where inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID == SubInvType
                                           group inv by inv.SubInvTypeID into g
                                           select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();



                        if (qryMaxInvNo.maxnum > 0)
                        {
                            intInvNo = qryMaxInvNo.maxnum;
                        }
                        else
                        {
                            var qryMaxInvNoContext = (from inv in context.Invoices
                                                      where inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID == SubInvType
                                                      group inv by inv.SubInvTypeID into g
                                                      select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                            if (qryMaxInvNoContext == null)
                            {
                                intInvNo = 0;
                            }
                            else
                            {

                                intInvNo = qryMaxInvNoContext.maxnum;
                            }
                        }

                        intInvNo++;
                    }


                    ////20Oct2014..log invoice gen process..to capture duplicating issue
                    Suport.LogEntry("InvNo:" + intInvNo + ",locInvPrefix:" + locInvPrefix + ", InvoicePrefix:" + InvoicePrefix);

                    ////formating the invoice 
                    string formatedInvNo = FormatInvoiceNo(intInvNo, locInvPrefix, InvoicePrefix);

                    ////20Oct2014..log invoice gen process..to capture duplicating issue
                    Suport.LogEntry("BF formatedInvNo:" + formatedInvNo);

                    ////26June2014..to avoid duplicates..roshan..nimal's request
                    formatedInvNo = CheckInvoiceNoExist(intInvNo, context, formatedInvNo, locInvPrefix, InvoicePrefix);

                    ////20Oct2014..log invoice gen process..to capture duplicating issue
                    Suport.LogEntry("AF formatedInvNo:" + formatedInvNo);

                    strInvo = formatedInvNo;

                }


            }

            return strInvo;

        }

        private static string FormatInvoiceNo(int intInvNo, string locInvPrefix, string InvoicePrefix)
        {
            string strConcatPrefix = locInvPrefix.Trim() + "/" + InvoicePrefix.Trim() + "/";
            char pad = '0';
            string formatedInvNo = strConcatPrefix.PadRight(10 - intInvNo.ToString().Trim().Length, pad) + intInvNo.ToString().Trim();
            return formatedInvNo;
        }
        private static string FormatProformaInvoiceNo(int intInvNo, string locInvPrefix, string InvoicePrefix)
        {
            string strConcatPrefix = locInvPrefix.Trim() + "/" + InvoicePrefix.Trim() + "/";
            char pad = '0';
            string formatedInvNo = strConcatPrefix.PadRight(12- intInvNo.ToString().Trim().Length, pad) + intInvNo.ToString().Trim();
            return formatedInvNo;
        }

        private static string CheckInvoiceNoExist(int intInvNo, AHPL_DBEntities context, string formatedInvNo, string locInvPrefix, string InvoicePrefix)
        {
            bool invoiceExist = CheckInvoiceNoExist(context, formatedInvNo);
            if (invoiceExist)
            {
                intInvNo += 1;

                formatedInvNo = FormatInvoiceNo(intInvNo, locInvPrefix, InvoicePrefix);
                CheckInvoiceNoExist(intInvNo, context, formatedInvNo, locInvPrefix, InvoicePrefix);
            }

            return formatedInvNo;
        }
        //start profroma 
        private static bool CheckInvoiceNoExist(AHPL_DBEntities context, string formatedInvNo)
        {
            List<Invoice> invExist = context.Invoices.Where(w => w.InvoiceNo.Equals(formatedInvNo)).ToList();
            if (invExist.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        private static string CheckProformaNoisExist(int intInvNo, AHPL_DBEntities context, string formatedInvNo, string locInvPrefix, string InvoicePrefix)
        {
            bool invoiceExist = CheckProformaNoisExist(context, formatedInvNo);
            if (invoiceExist)
            {
                intInvNo += 1;

                formatedInvNo = FormatProformaInvoiceNo(intInvNo, locInvPrefix, InvoicePrefix);
                CheckProformaNoisExist(intInvNo, context, formatedInvNo, locInvPrefix, InvoicePrefix);
            }

            return formatedInvNo;
        }
        private static bool CheckProformaNoisExist(AHPL_DBEntities context, string formatedInvNo)
        {
            List<Invoice> invExist = context.Invoices.Where(w => w.ProfomaNo.Equals(formatedInvNo)).ToList();
            if (invExist.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //-----end proforma

        public static string generateUtilityInvoice(int pInvoiceType, int pLocationID, List<cGen_Rent_Invoice> _GenInvList, List<cGen_Rent_Invoice> _GenInvList1, int pCompID = 0, int SubInvType = 3, int pUtilityID = 0)
        {
            
            string strInvo = "";
            int intInvNo = 0;
            bool res = false;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryInvPrefix = (from l in context.Locations
                                    where l.LocationID == pLocationID
                                    select new { l.InvoicePrefix }).First();
                string locInvPrefix = "";
                string InvoicePrefix = "";
                //string UtilityPrefix = "";

                if (qryInvPrefix != null)
                {
                    locInvPrefix = qryInvPrefix.InvoicePrefix;
                }

                if (pInvoiceType == 1)
                {
                    if (SubInvType == 1 || SubInvType == 3)  // Adjustment OR invoice
                    {
                        InvoicePrefix = "R";
                    }

                    if (SubInvType == 2)
                    {
                        InvoicePrefix = "CN";
                    }
                }

                if (pInvoiceType == 2)
                {
                    var qryUtitlyInvPrefix = (from u in context.Utilities
                                              where u.UtilityID == pUtilityID
                                              select new { u.InvoicePrefix }).First();
                    if (qryUtitlyInvPrefix != null)
                    {
                        InvoicePrefix = qryUtitlyInvPrefix.InvoicePrefix;
                    }
                }


                if (pUtilityID > 0)
                {
                    if (_GenInvList.Count == 0)
                    {
                        var qryMaxInvNo = (from inv in _GenInvList1
                                           where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                           group inv by inv.InvoiceTypeID into g
                                           select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                        res = int.TryParse(qryMaxInvNo.maxnum.ToString(), out intInvNo);

                        if (res == false) { intInvNo = 0; }

                        if (intInvNo == 0)
                        {
                            var qryMaxNo = (from inv in context.Invoices
                                            where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                            group inv by inv.InvoiceTypeID into g
                                            select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();
                            intInvNo = qryMaxNo.maxnum;
                            intInvNo++;

                        }
                        else
                        {

                            intInvNo = qryMaxInvNo.maxnum;
                            intInvNo++;
                        }
                    }
                    else
                    {
                        if (SubInvType == 1 || SubInvType == 3) // Adjustment Or Invoice
                        {
                            var qryMaxInvNo = (from inv in _GenInvList
                                               where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID != 2 && inv.UtilityID == pUtilityID
                                               group inv by inv.InvoiceTypeID into g
                                               select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();
                            if (qryMaxInvNo != null)
                            {

                                res = int.TryParse(qryMaxInvNo.maxnum.ToString(), out intInvNo);

                                if (res == false) { intInvNo = 0; }
                            }

                            if (intInvNo == 0)
                            {

                                var qryMaxInvNoFromGeneratedInv = (from inv in _GenInvList1
                                                                   where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID != 2 && inv.UtilityID == pUtilityID
                                                                   group inv by inv.InvoiceTypeID into g
                                                                   select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();
                                if (qryMaxInvNoFromGeneratedInv != null)
                                {
                                    intInvNo = qryMaxInvNoFromGeneratedInv.maxnum;

                                }


                            }

                            if (intInvNo == 0)
                            {
                                var qryMaxInvnofromContext = (from inv in context.Invoices
                                                              where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID != 2 && inv.UtilityID == pUtilityID
                                                              group inv by inv.InvoiceTypeID into g
                                                              select new { maximum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                                if (qryMaxInvnofromContext != null)
                                {
                                    intInvNo = qryMaxInvnofromContext.maximum;
                                }
                            }

                            intInvNo++;
                        }

                        if (SubInvType == 2) // Credit Note 
                        {
                            InvoicePrefix = "CN";
                            var qryMaxInvNo = (from inv in _GenInvList
                                               where inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID == SubInvType
                                               group inv by inv.SubInvTypeID into g
                                               select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                            if (qryMaxInvNo.maxnum > 0)
                            {
                                res = int.TryParse(qryMaxInvNo.maxnum.ToString(), out intInvNo);
                                if (res == false) { intInvNo = 0; }

                                intInvNo = qryMaxInvNo.maxnum;
                                intInvNo++;
                            }
                            else
                            {
                                var qryMaxInvNoContext = (from inv in context.Invoices
                                                          where inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID == SubInvType
                                                          group inv by inv.SubInvTypeID into g
                                                          select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();
                                if (qryMaxInvNoContext == null)
                                {
                                    intInvNo = 0;
                                }
                                else
                                {
                                    intInvNo = qryMaxInvNoContext.maxnum;
                                }

                                //intInvNo = 0;
                                intInvNo++;
                            }

                        }


                    }

                    ////formating the invoice 
                    string formatedInvNo = FormatInvoiceNo(intInvNo, locInvPrefix, InvoicePrefix);

                    ////26June2014..to avoid duplicates..roshan..nimal's request
                    formatedInvNo = CheckInvoiceNoExist(intInvNo, context, formatedInvNo, locInvPrefix, InvoicePrefix);
                    strInvo = formatedInvNo;

                }
                else
                {
                    if (SubInvType == 1 || SubInvType == 3)
                    {
                        var qryMaxInvNo = (from inv in _GenInvList1
                                           where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                           group inv by inv.InvoiceTypeID into g
                                           select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();



                        if (qryMaxInvNo == null)
                        {
                            intInvNo = 1;
                        }
                        else
                        {
                            intInvNo = qryMaxInvNo.maxnum;
                            if (intInvNo == 0) // if current list containts sequence No is 0 or null , then qyuerying from Context.Invoice
                            {
                                var qryMaxInvNoContext = (from inv in context.Invoices
                                                          where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID
                                                          group inv by inv.InvoiceTypeID into g
                                                          select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();

                                intInvNo = qryMaxInvNoContext.maxnum;
                            }

                            intInvNo++;
                        }
                    }

                    if (SubInvType == 2) // Credit Note 
                    {
                        var qryMaxInvNo = (from inv in _GenInvList1
                                           where inv.InvoiceTypeID == pInvoiceType && inv.CompanyID == pCompID && inv.LocationID == pLocationID && inv.SubInvTypeID == SubInvType
                                           group inv by inv.InvoiceTypeID into g
                                           select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();



                        if (qryMaxInvNo == null)
                        {
                            intInvNo = 1;
                        }
                        else
                        {
                            intInvNo = qryMaxInvNo.maxnum;
                            intInvNo++;
                        }


                    }

                    ////formating the invoice 
                    string formatedInvNo = FormatInvoiceNo(intInvNo, locInvPrefix, InvoicePrefix);

                    ////26June2014..to avoid duplicates..roshan..nimal's request
                    formatedInvNo = CheckInvoiceNoExist(intInvNo, context, formatedInvNo, locInvPrefix, InvoicePrefix);
                    strInvo = formatedInvNo;

                }


            }

            return strInvo;

        }

        public static string genOtherServiceInvoice(Invoice oInv, int pCategoryID)
        {
            string strInvo = "";
            string locInvPrefix = "";
            string OSInvPrefix = "";

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                //string InvoicePrefix = "";

                //if (SubInvType == 2)
                //{
                //    InvoicePrefix = "CN";
                //}

                //Location's Invoice Prefix
                var qryLocPrefix = (from l in context.Locations
                                    where l.LocationID == oInv.LocationID
                                    select new { l.InvoicePrefix }).FirstOrDefault();
                if (qryLocPrefix != null)
                {
                    locInvPrefix = qryLocPrefix.InvoicePrefix;
                }
                //---

                // Other Service Category's Invoice Prefix
                var qryOtherS = (from o in context.OtherServiceCategories
                                 where o.OtherServiceID == oInv.OtherServiceID
                                 select new { o.InvoicePrefix }).FirstOrDefault();
                if (qryOtherS != null)
                {
                    OSInvPrefix = qryOtherS.InvoicePrefix;
                }
                //---

                int intInvNo = 0;
                var qryMaxNo = (from inv in context.Invoices
                                where inv.OtherServiceID == oInv.OtherServiceID && inv.CompanyID == oInv.CompanyID && inv.LocationID == oInv.LocationID
                                group inv by inv.InvoiceTypeID into g
                                select new { maxnum = g.Max(x => x.SequenceNo) }).FirstOrDefault();
                if (qryMaxNo != null)
                {
                    intInvNo = qryMaxNo.maxnum;
                }

                intInvNo++;


                ////formating the invoice 
                string formatedInvNo = FormatInvoiceNo(intInvNo, locInvPrefix, OSInvPrefix);

                ////26June2014..to avoid duplicates..roshan..nimal's request
                formatedInvNo = CheckInvoiceNoExist(intInvNo, context, formatedInvNo, locInvPrefix, OSInvPrefix);

                strInvo = formatedInvNo;



            }
            return strInvo;

        }
        public static string generateProformainvoiceno(int OserviceId,int OcompID,int OLocationID, List<cGen_Rent_Invoice> tobeconfirmedInvoiceList)
        {
            string strInvo = "";
            string locInvPrefix = "";
            string OSInvPrefix = "";
            int intInvNo = 0;
            //inv.OtherServiceID == OserviceId && 
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                var qryMaxInvNo = (from inv in tobeconfirmedInvoiceList
                                   where inv.CompanyID == OcompID && inv.LocationID == OLocationID
                                   group inv by inv.InvoiceTypeID into g
                                   select new { maxnum = g.Max(x => x.ProfomaSequenceNo) }).FirstOrDefault();


                if (qryMaxInvNo.maxnum == 0)
                {
                    var qryMaxNo = (from inv in context.Invoices
                                    where  inv.CompanyID == OcompID && inv.LocationID == OLocationID
                                    group inv by inv.InvoiceTypeID into g
                                    select new { maxnum = g.Max(x => x.ProfomaSequenceNo) }).FirstOrDefault();

                    intInvNo = qryMaxNo.maxnum;

                }
                else
                {

                    intInvNo = qryMaxInvNo.maxnum;
                
                }

                intInvNo++;
                //Location's Invoice Prefix
                var qryLocPrefix = (from l in context.Locations
                                    where l.LocationID == OLocationID
                                    select new { l.InvoicePrefix }).FirstOrDefault();
                if (qryLocPrefix != null)
                {
                    locInvPrefix = qryLocPrefix.InvoicePrefix;
                }
                //---
                OSInvPrefix = "PROF";
                ////formating the invoice 
                string formatedInvNo = FormatProformaInvoiceNo(intInvNo, locInvPrefix, OSInvPrefix);
                formatedInvNo = CheckProformaNoisExist(intInvNo, context, formatedInvNo, locInvPrefix, OSInvPrefix);
                strInvo = formatedInvNo;

                

                

            }


            return strInvo;
        }

       
        
    }
}