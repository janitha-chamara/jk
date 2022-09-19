using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class cOccupancyDetails
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public string ItemName { get; set; }
        public decimal Monthly_Actual { get; set; }
        public decimal YTD_Actual { get; set; }
    }

    public static class enumOccupancyDetails
    {
        public enum enumOccDetails
        {
            TotalArea=1,
            UnOccupied=2,
            OccupiedArea=3,
            Occupancy=4,
            Rent=5,
            ServiceCharge=6,
            TotalRentWithServiceCharge=7,
            RentPerSqFt=8,
            ServiceChargePerSqFt = 9,
            TotalPerSqFt=10
            
        }

    }

}
