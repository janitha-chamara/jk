using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class cContract_Ageing
    {
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public int LevelID { get; set; }
        public int CustomerID { get; set; }
        public string ShopName { get; set; }
        public DateTime CommencedDate { get; set; }
        public DateTime ExpiryDate { get; set; }        
        public int LapsDays { get; set; }
        public int AgeGroup { get; set; }
        public string AgeName { get; set; }
        public string ShopNo { get; set; }
        public string ContractClosureName { get; set; }
        public string CustomerName { get; set; }

    }
}
