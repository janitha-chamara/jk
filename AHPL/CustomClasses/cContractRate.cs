using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMS
{
    public class cContractRate
    {
        public int ContractRateID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentPerSqft { get; set; }
        public decimal RentPerMonth { get; set; }
        public decimal SCperMonth { get; set; }
        public decimal SCperSqFt { get; set; }
        public decimal RentWithSCperSqFt { get; set; }
        public decimal RentWithSCperMonth { get; set; }
        public int Period { get; set; }
        public decimal TotalRentPerMonth { get; set; }
        public bool IsActive { get; set; }
    }
}
