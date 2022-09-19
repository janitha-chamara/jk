using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using System.Data.Linq.SqlClient;
using DataTier;
using DataTier.Reports;
namespace MMS
{
    public class cSAP_Upload
    {

        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public int InvDetID { get; set; }
        public string BusAct { get; set; }
        public string UserName { get; set; }
        public string CompanyCode { get; set; }
        public string CurrKey { get; set; }
        public DateTime DocDate { get; set; }
        public string PostingKey { get; set; }
        public DateTime PostingDate { get; set; }
        public string RefDocNo { get; set; }
        public string DocHeaderText { get; set; }
        public string DocType { get; set; }
        public string ExchRate { get; set; }
        public DateTime TransltDate { get; set; }
        public string CustomerCode_GLAccount { get; set; }
        public string GLaccDesc { get; set; }
        public decimal AmtInDocCur { get; set; }
        public decimal AmtInLocCur { get; set; }
        public string Assignment { get; set; }
        public string Text { get; set; }
        public string BusinessArea { get; set; }
        public string CostCenter { get; set; }
        public string InternalOrder { get; set; }
        public string ProfitCenter { get; set; }
        public string RefKey1 { get; set; }
        public string RefKey2 { get; set; }
        public string RefKey3 { get; set; }
        public bool IsGLEntriy { get; set; }
        public bool IsCustomerEntry { get; set; }
        public string SAPUploadMessage { get; set; }
        public decimal CusomterAmount { get; set; }
        public bool IsSelected { get; set; }
    }
}
