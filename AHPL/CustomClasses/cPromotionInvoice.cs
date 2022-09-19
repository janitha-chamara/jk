using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMS
{
  public  class cPromotionInvoice
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; }
        public string ShopNo { get; set; }
        public string ShopName { get; set; }
        public string LocationCode { get; set; }
        public string LevelName { get; set; }
        public string CompanyCode { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int ProcessYear { get; set; }
        public string MonthName { get; set; }
        public bool Select { get; set; }
        public string CustomerName{ get; set; }
        public string ProfomaNo { get; set; }
        
    }
}
