using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMS
{
   public class cCustomersContract
    {
       public int ContractID { get; set; }
       public int ExtendedCustomerID { get; set; }
       public int GlobalCustomerID { get; set; }
       public string CustomerName { get; set; }
       public string LocationCode { get; set; }
       public string CompanyCode { get; set; }
       public string LevelCode { get; set; }
       public string ShopName { get; set; }
    }
}
