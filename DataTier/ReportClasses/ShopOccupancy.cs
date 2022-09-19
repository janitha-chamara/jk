using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.ReportClasses
{
    public class ShopOccupancy
    {
        public int ShopID { get; set; }
        public string ShopNo { get; set; }
        public string RentAreaType { get; set; }
        public string LevelName { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string SAPCustomerCode { get; set; }
        public string CustomerName { get; set; }
        public decimal OccupiedAreaSqFt { get; set; }
        public decimal UnOccupiedAreaSqft { get; set; }
        public decimal RentPerSqFt { get; set; }
        public decimal OldRentPerSqFt { get; set; }
        public decimal ScPerSqFt { get; set; }
        public decimal OldSCperSqFt { get; set; }
        public string UnoccupiedFrom { get; set; }
        public string UnoccupiedTo { get; set; }
        public decimal UnOccupiedMonth { get; set; }
        public decimal LossOfRentperSqFt { get; set; }
        public decimal LossOfSCperSqFt { get; set; }
        public string RentPeriod { get; set; }
        public decimal IncreaseOfRent { get; set; }
        public decimal IncreaseRentPercentage { get; set; }
        public decimal IncreaseOfSC { get; set; }
        public decimal IncreaseSCPercentage { get; set; }
        public string NewApplicablePeriod { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public decimal StartReading { get; set; }
        public decimal EndReading { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public string UtilityName { get; set; }

        public decimal RentPerMonth { get; set; }

        public decimal SCperMonth { get; set; }

        public decimal RentWithSCperMonth { get; set; }

        public string MandatoryTaxCode { get; set; }

        public decimal MandatoryTaxAmount { get; set; }

        public decimal TotalWithMandatoryTax { get; set; }

        public string OtherTaxCodes { get; set; }

        public decimal OtherTax { get; set; }

        public decimal TotalRentPerMonth { get; set; }

        public bool IsVacant { get; set; }

        public decimal NosUnitsConsumed1 { get; set; }

        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal UtilityUnitRate { get; set; }

        public string SubInvoiceType { get; set; }

        public string Naration { get; set; }

        public string OtherServiceName { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal TotalSqFtInLevel { get; set; }

        public decimal TotalSqFtInCompany { get; set; }

        public decimal TotalSqFtInLocation { get; set; }

        public decimal ShopSqFt { get; set; }

        public int ExtendedCustomerID { get; set; }

        public string MeterName { get; set; }

        public int ContractClauseID { get; set; }

        public decimal Ratio { get; set; }

        public int SubInvoiceTypeOrder { get; set; }

        public int SubInvoiceTypeID { get; set; }
    }
}
