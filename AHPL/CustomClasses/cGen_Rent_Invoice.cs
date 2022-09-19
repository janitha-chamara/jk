using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MMS
{
   public class cGen_Rent_Invoice
    {
       public int InvoiceID { get; set; }
       public int SequenceNo { get; set; }
       public string InvoiceNo { get; set; }
       public int CompanyID { get; set; }
       public string CompanyCode { get; set; }
       public int LocationID { get; set; }
       public string LocationCode { get; set; }
       public int LevelID { get; set; }
       public string LevelCode { get; set; }
       public int ShopID { get; set; }
       public string ShopNo { get; set; }
       public string ShopName { get; set; }
       public string CustomerName { get; set; }
       public decimal TotalRent { get; set; }
       public bool Confirm { get; set; }
       public DateTime InvDate { get; set; }
       public int InvoiceTypeID { get; set; }    
       public int CustomerID { get; set; }
       public bool Select { get; set; }     
       public int SubInvTypeID { get; set; }
       public int UtilityID { get; set; }
       public bool IsInvoiceNoGenerated { get; set; }
       public int ProcessYear { get; set; }
       public int ProcessMonth { get; set; }
       public DateTime DateFrom { get; set; }
       public DateTime DateTo { get; set; }
       public decimal TotalAmount { get; set; }
       public decimal TotalTax { get; set; }
       public decimal GrandTotal { get; set; }
       public decimal StartReading1 { get; set; }
       public decimal EndReading1 { get; set; }
       public decimal StartReading2 { get; set; }
       public decimal EndReading2 { get; set; }
       public decimal M_StartReading { get; set; }
       public decimal M_EndReading { get; set; }
       public decimal NosUnitConsumed1 { get; set; }
       public decimal NosUnitConsumed2 { get; set; }
       public decimal M_NosUnitConsumed { get; set; }
       public decimal TotalNosUnitConsumed { get; set; }
       public decimal UtilityUnitRate { get; set; }
       public bool IsProcessed { get; set; }
       public string Naration { get; set; }
       public int OtherServiceID { get; set; }
       public string ContractName { get; set; }
       public string Edit { get; set; }
       public bool Delete { get; set; }
       public decimal RentalDiscount { get; set; }
       public decimal SCDiscount { get; set; }
       public decimal SCPerMonth { get; set; }
       public decimal TotalRentPerMonth { get; set; }
       public decimal CreditNoteValue { get; set; }
       public int ContractClosureID { get; set; }
       public decimal  MandatoryTaxAmount{ get; set; }
       public decimal OtherTax { get; set; }
       public decimal TotalCreditValue { get; set; }
       public bool IsProforma { get; set; }
       public int InvoiceState { get; set; }
       public string ProfomaNo { get; set; }
       public int ProfomaSequenceNo { get; set; }

    }
}
