using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMS.CustomClasses
{
  public  class cCreditNoteBatch
    {

        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; }
        public int ContractClauseID { get; set; }
        public int ShopID { get; set; }
        public string ShopNo { get; set; }
        public string ShopName { get; set; }
        public string ContractName { get; set; }
        public int LocationID { get; set; }
        public int CompanyID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int ProcessMonth { get; set; }
        public int ProcessYear { get; set; }
        public decimal TotalAmount { get; set; }
        public string InvoiceFooter1 { get; set; }
        

    }
}
