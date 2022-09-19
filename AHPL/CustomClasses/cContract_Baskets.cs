using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Objects;
//using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using DataTier;

namespace MMS
{
   public class cContract_Baskets
    {
       public bool IsProcessed { get; set; }
       public bool IsReleased { get; set; }
       public bool IsReleasedToAccount { get; set; }
       public int ContractClosureID { get; set; }
       public string ContractClosureName { get; set; }
       public int ExtendedCustomerID { get; set; }
       public string ShopName { get; set; }
       public bool Print { get; set; }
       public bool IsPromotion { get; set; }
       public int CompanyID { get; set; }
       public int LocationID { get; set; }
       public string ContractType { get; set; }
       public string ShopNo { get; set; }
    }
}
