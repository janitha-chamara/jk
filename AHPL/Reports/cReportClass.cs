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

namespace MMS
{
    public class cInvoice
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; }
        public string RefNo { get; set; }
        public DateTime InvDate { get; set; }
        public string ShopNo { get; set; }
        public string OurTaxRegNo1 { get; set; }
        public string OurTaxRegNo2 { get; set; }
        public string DefaultTaxRegNo { get; set; }
        public string YourTaxRegNo1 { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string LocaitonName { get; set; }
        public string LocationAddress { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal TotalAmountWithSC { get; set; }
        public decimal DefaultTaxName { get; set; }
        public decimal DefaultTaxAmount { get; set; }
        public decimal TotalwithSCwithTax { get; set; }
        public string DefaultTaxTextDisplay { get; set; }
        public string DisplayText1 { get; set; }
        public string DisplayText2 { get; set; }
        public bool IsTaxApplied { get; set; }
        public string TaxName1 { get; set; }
        public decimal TaxAmount1 { get; set; }
        public string TaxName2 { get; set; }
        public decimal TaxAmount2 { get; set; }
        public string InvoiceName { get; set; }
       
    }

    public class cInvoice_Details
    {
        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public string ItemName { get; set; }
        public int TaxID { get; set; }
        public int TaxRateID { get; set; }
        public decimal Amount { get; set; }

    }


}
