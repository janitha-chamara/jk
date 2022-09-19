using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.ReportClasses
{
    public class InvoiceSummeryDetail
    {
        public string Customer { get; set; }

        public string ShopNo { get; set; }

        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate {get;set;}

        public decimal InvoiceValue { get; set; }

        public string Naration { get; set; }

        public decimal RentalDiscount { get; set; }

        public decimal SCDiscount { get; set; }

    }
}
