using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Reports.Master
{
    public class ExtendedCustomers
    {
        public int ExtendedCustomerID { get; set; }
        public int GlobalCustomerID { get; set; }      
        public string Company { get; set; }
        public string Location { get; set; }
        public string CustomerName { get; set; }
        public string Adddress { get; set; }
        public string SAPCustomerCode { get; set; }
        public string RegNo { get; set; }


    }
}
