using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMS
{
   public class cProcessContracts
    {
       public int ContractID { get; set; }
       public string ShopName { get; set; }
       public int CustomerID { get; set; }     
       public int LocaitonID { get; set; }      
       public int CompanyID { get; set; }
       public int LevelID { get; set; }
       public string ShopNo { get; set; }
       public bool IsProcessed { get; set; }
       public int Year { get; set; }
       public int Month { get; set; }
       public bool IsConfirmed { get; set; }      
       public int InvoiceTypeID { get; set; }  
       public int SubInvTypeID { get; set; }
       public int InvoiceID { get; set; }
       public string Edit { get; set; }
       public decimal TotalSqFt { get; set; }
       public decimal RentPerSqFt { get; set; }
       public decimal SCPerSqFt { get; set; }
       public decimal RentWithScPerSqft { get; set; }
       public decimal RentPerMonth { get; set; }
       public decimal SCPerMonth { get; set; }
       public decimal MandatoryTaxAmount { get; set; }
       public decimal TotalWithMandatoryTax { get; set; }
       public decimal RentSCPerMonth { get; set; }
       public decimal OtherTax { get; set; }
       public decimal TotalRentPerMonth { get; set; }
       public DateTime FromDate { get; set; }
       public DateTime ToDate { get; set; }
       public bool IsTaxCustomer { get; set; }
       public int NosDays { get; set; }
       public bool IsDelete { get; set; }
       public decimal RentalDiscount { get; set; }
       public decimal SCDiscount { get; set; }
    


    }
}
