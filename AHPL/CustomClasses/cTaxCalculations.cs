using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using DataTier;

namespace MMS
{
    public static class cTaxCalculations
    {
        public static cMandatoryTax getAmountWithMandatoryTax(decimal pAmount)
        {
            cMandatoryTax mandatoryTax = new cMandatoryTax();
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryTaxM = (from t in context.Taxes
                               join tr in context.TaxRates on t.TaxID equals tr.TaxID
                               where t.IsMandatory == true && tr.IsActive == true
                               select new { t.TaxID, t.TaxCode, tr.TaxRateID, tr.TaxRate1 }).FirstOrDefault();
                if (qryTaxM != null)
                {
                    mandatoryTax.MandatoryTaxID = qryTaxM.TaxID;
                    mandatoryTax.MandatoryTaxCode = qryTaxM.TaxCode;
                    mandatoryTax.MandatoryTaxRateID = qryTaxM.TaxRateID;
                    decimal taxM = (qryTaxM.TaxRate1 * pAmount) / 100;
                    mandatoryTax.MandatoryTaxAmount = taxM;
                    decimal total = mandatoryTax.MandatoryTaxAmount + pAmount;
                    mandatoryTax.TotalWithMandatoryTax = total;
                    mandatoryTax.MandatoryTaxRate = qryTaxM.TaxRate1;
                    
                }
            }
            return mandatoryTax;
        }

        public static List<cOtherTax> getOtherTax(decimal pAmountWithMandatoryTax)
        {
            List<cOtherTax> otherTaxList = new List<cOtherTax>();

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryOtherTax = (from t in context.Taxes
                                   join tr in context.TaxRates on t.TaxID equals tr.TaxID
                                   where t.IsMandatory == false && tr.IsActive == true
                                   select new { t.TaxID, t.TaxCode, tr.TaxRate1, tr.TaxRateID }).ToList();
                foreach (var qry in qryOtherTax)
                {
                    cOtherTax oOtherTax = new cOtherTax();
                    oOtherTax.TaxID = qry.TaxID;
                    oOtherTax.TaxCode = qry.TaxCode;
                    decimal taxamount = (pAmountWithMandatoryTax * qry.TaxRate1) / 100;
                    oOtherTax.TaxAmount = taxamount;                    
                    oOtherTax.TaxRate = qry.TaxRate1;
                    oOtherTax.TaxRateID = qry.TaxRateID;
                    otherTaxList.Add(oOtherTax);
                }

            }


            return otherTaxList;


        }


    }

    public class cMandatoryTax
    {
        public int MandatoryTaxID { get; set; }
        public string MandatoryTaxCode { get; set; }
        public decimal MandatoryTaxAmount { get; set; }
        public int MandatoryTaxRateID { get; set; }
        public decimal MandatoryTaxRate { get; set; }
        public decimal TotalWithMandatoryTax { get; set; }

    }

  


    public class cOtherTax
    {
        public int TaxID { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; }
        public int TaxRateID { get; set; }
    }



}
