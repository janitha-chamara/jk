using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.ReportClasses
{
    public class PerformanceDetails
    {
        public Int64 PerformanceDetailID { get; set; }
        public int FinancialYearDetailID { get; set; }
        public int SortOrder { get; set; }
        public int ReportItemID { get; set; }
        public string ReportItemName { get; set; }
        public decimal ReforecastingValueM { get; set; }
        public decimal BudgetValueM { get; set; }
        public decimal ActualValueM { get; set; }
        public decimal ReforecastingValueYTD { get; set; }
        public decimal BudgetValueYTD { get; set; }
        public decimal ActualValueYTD { get; set; }
        public decimal LastYearActualValue { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
    }

    public class PerformanceDetail_OSIncome
    {
        public int OtherServiceCategoryID { get; set; }
        public decimal RentWithMandatoryTax { get; set; }

    }
}
