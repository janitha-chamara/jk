using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMS
{
    public class cContracts
    {
        public string CompanyCode { get; set; }
        public int CompanyID { get; set; }
        public string LocationCode { get; set; }
        public int LocationID { get; set; }
        public string LevelName { get; set; }
        public int LevelID { get; set; }
        public string ShopName { get; set; }
        public string ShopNo { get; set; }
        public int ShopID { get; set; }
        public string CustomerName { get; set; }
        public int CustomerID { get; set; }
        public int ExtendedCustomerID { get; set; }
        public int ContractID { get; set; }
        public int ContractClauseID { get; set; }
        public int Contract_RentSchemeID { get; set; }
        public decimal Deposit { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Period { get; set; }
        public string AgreementNo { get; set; }
        public DateTime? AgreementSignDate { get; set; }
        public decimal RentPerSqFt { get; set; }
        public decimal SCperSqFt { get; set; }
        public decimal RentWithSCperSqFt { get; set; }
        public decimal RentPerMonth { get; set; }
        public decimal SCperMonth {get;set;}
        public decimal RentWithScPerMonth {get;set;}
        public decimal FloorArea { get; set; }
        public bool IsVacant { get; set; }


    }
}
