using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMS
{
    public class cViewTaxRates
    {
        public int TaxID { get; set; }
        public string TaxCode { get; set; }
        public int TaxRateID { get; set; }
        public decimal TaxRate1 { get; set; }
        public bool IsActive { get; set; }
      
    }
}
