using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMS.CustomClasses
{
    public class cUtilityInvoiceBatch
    {
       public int InvoiceID { get; set; }
       public string InvoiceNo { get; set; }
       public int ContractClauseID { get; set; }
       public int ShopID { get; set; }
       public string ShopNo { get; set; }
       public string ShopName { get; set; }
       public string ContractName { get; set; }
       public int LocationID { get; set; }
       public int FloorLevelID { get; set; }
       public int CompanyID { get; set; }
       public int CustomerID { get; set; }
       public int ExtendedCustomerID { get; set; }
       public int ShopUtilityReadingID { get; set; }
       public int UtilityID { get; set; }
       public DateTime DateFrom { get; set; }
       public DateTime DateTo { get; set; }
       public int ProcessMonth { get; set; }
       public int ProcessYear { get; set; }
       public decimal StartReading1 { get; set; }
       public decimal EndReading1 { get; set; }
       public decimal StartReading2 { get; set; }
       public decimal EndReading2 { get; set; }
       public decimal NosUnitConsumed { get; set; }
       public bool IsReset { get; set; }
       public bool IsMaintenance { get; set; }
       public decimal M_StartReading1 { get; set; } //Maintenance -  Start Reading
       public decimal M_EndReading1 { get; set; } // Maintenance - End reading
       public int UtilityRateID { get; set; }
       public decimal UnitRate { get; set; }
       public decimal Amount { get; set; }
       public decimal MandatoryTaxCode { get; set; }
       public decimal MandatoryTaxAmount { get; set; }
       public string OtherTaxCodes { get; set; }
       public decimal OtherTax { get; set; }
       public decimal TotalAmount { get; set; }
       public string InvoiceFooter1 { get; set; }
       public string MeterName { get; set; }
    }
}
