using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataTier;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;


namespace MMS.Transaction.Rent
{

    public partial class xRentVariation : DevExpress.XtraEditors.XtraForm
    {
        public xRentVariation()
        {
            InitializeComponent();
        }
        List<cRentSchemesV> oldrentSchemeList = new List<cRentSchemesV>();
        List<cRentSchemesV> newRentSchemeList = new List<cRentSchemesV>();
        private void btnVariance_Click(object sender, EventArgs e)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                if (this.lookContractOld.EditValue == null)
                {
                    this.DifferenceValue = 0;
                    return;
                }

                int oldcontrentschemeid = int.Parse(Convert.ToString(this.lookContractOld.EditValue));
                int newrentschemeid = int.Parse(this.lookNewContract.EditValue.ToString());
                DateTime todate = dateEditToDate.DateTime;
                DateTime todateOld = DateTime.Now.Date;

                // old contract rent schemes' from date
                var qryExpDateOld = (from cr in context.Contract_RentSchemes
                                     where cr.Contract_RentSchemeID == oldcontrentschemeid
                                     select new { ExpiryDate = cr.ToDate }).FirstOrDefault();
                if (qryExpDateOld != null)
                {
                    todateOld = qryExpDateOld.ExpiryDate;
                }


                // geting sum of old rent + SC
                decimal rentOld = 0;
                var qryRentOld = (from inv in context.Invoices
                                  where inv.Contract_RentSchemeID == oldcontrentschemeid && inv.InvoiceDate >= todateOld && inv.InvoiceDate <= todate && inv.SubInvTypeID == 3
                                  select inv).ToList();
                //select new { inv.RentPerSqFt }).Sum(x => x.RentPerSqFt);
                int totalNos = 0;
                decimal totalRentOld = 0;
                if (qryRentOld != null)
                {
                    totalRentOld = qryRentOld.Sum(x => x.RentWithSCPerMonth);
                    rentOld = totalRentOld;
                    totalNos = qryRentOld.Count;
                }

                var qryRentNew = (from c in context.Contract_RentSchemes
                                  where c.Contract_RentSchemeID == newrentschemeid
                                  select c).FirstOrDefault();

                decimal NewRentWithSCperSqFt = 0;
                decimal NewTotalSqFt = 0;
                if (qryRentNew != null)
                {
                    NewRentWithSCperSqFt = qryRentNew.RentPerSqFeet + qryRentNew.SCPerSqFeet;
                    NewTotalSqFt = qryRentNew.ContractClosure.FloorArea;
                }



                decimal newRentWithScForSelectedMonth = totalNos * (NewRentWithSCperSqFt * NewTotalSqFt);

                decimal differenceValue = 0;
                differenceValue = newRentWithScForSelectedMonth - totalRentOld;




                //// geting sum of old SC
                //decimal scOld = 0;
                //var qrySCold = (from inv in context.Invoices
                //                  where inv.Contract_RentSchemeID == oldcontrentschemeid && inv.InvoiceDate >= todateOld && inv.InvoiceDate <= todate
                //                  select inv).ToList();
                ////new { inv.RentPerSqFt }).Sum(x => x.RentPerSqFt)

                //var qrysctotal = qrySCold.Sum(x => x.SCPerSqFt);

                //scOld = qrysctotal;

                //// total 
                //decimal rentwithScTotal = 0;
                //rentwithScTotal = rentOld + scOld;
                ////

                //// number of days between new date and contract expiry date
                //decimal totaldays = todate.Subtract(todateOld).Days;
                //decimal TotalofOld = rentwithScTotal * totaldays;


                /// geting new rent sceme values
                /// 
                ////DateTime newContStartDay = DateTime.Now.Date;

                ////var qryContStartDayNew = (from cr in context.Contract_RentSchemes
                ////                         where cr.Contract_RentSchemeID == newrentschemeid
                ////                         select new { ContractStartDate = cr.FromDate }).FirstOrDefault();
                ////if (qryContStartDayNew != null)
                ////{
                ////    newContStartDay = qryContStartDayNew.ContractStartDate.Value;
                ////}


                ////// new Rent value total
                ////decimal renttotalNew = 0;
                ////var qryRentNew = (from inv in context.Invoices
                ////                  where inv.Contract_RentSchemeID == oldcontrentschemeid && inv.InvoiceDate >= newContStartDay && inv.InvoiceDate <= todate
                ////                  //select new { inv.RentPerSqFt }).Sum(x => x.RentPerSqFt);
                ////                  select inv).ToList();
                ////var qryrentnewtotal = qryRentNew.Sum(x => x.RentPerSqFt);


                ////renttotalNew = qryrentnewtotal;

                ////                // new SC value total 
                ////decimal sctotalNew = 0;
                ////var qrySCNew = (from inv in context.Invoices
                ////                where inv.Contract_RentSchemeID == oldcontrentschemeid && inv.InvoiceDate >= newContStartDay && inv.InvoiceDate <= todate
                ////                //select new { inv.SCPerSqFt }).Sum(x => x.SCPerSqFt);
                ////                select inv).ToList();

                ////var qryscnewtotal = qrySCNew.Sum(x => x.SCPerSqFt);

                ////sctotalNew = qryscnewtotal;


                ////// total value of new rent + sc 
                ////decimal rentwithScTotalNew = renttotalNew + sctotalNew;
                ////// 

                ////// getting total number of days New Contracts start date to todate
                ////int nosdaysNew = todate.Subtract(newContStartDay).Days;

                ////decimal totalOfNew = rentwithScTotalNew * nosdaysNew;

                ////decimal differenceValue = totalOfNew - TotalofOld;
                ////differenceValue = Math.Round(differenceValue, 4);


                textEditTotal.EditValue = differenceValue;


                this.DifferenceValue = differenceValue;

            }


        }

        private void load_data()
        {
            dateEditToDate.DateTime = DateTime.Now.Date;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                var qryOldContractID = (from c in context.ContractClosures
                                        where c.ContractClosureID == NewContractID
                                        select new { OldContractID = c.RefNo }).FirstOrDefault();
                if (qryOldContractID != null)
                {
                    if (qryOldContractID.OldContractID > 0)
                    {
                        this.OldContractID = qryOldContractID.OldContractID;
                    }

                }



                DateTime oldcontractExpiryDate = oldContractExpiryDate;
                int oldcontractid = OldContractID;

                DateTime newcontractStartDate = newContractStartDate;
                int newcontractid = NewContractID;

                DateTime todate = ToDate;


                //bool res = false;
                ////geting total value of old rate contract's value ( Rent per sqft , sc persqft);
                //// calculating number of days

                //old contract rent schemes
                oldrentSchemeList.Clear();
                var qryRentSchemesOld = (from cr in context.Contract_RentSchemes
                                         where cr.ContractClosureID == OldContractID
                                         orderby cr.Contract_RentSchemeID descending
                                         select cr).ToList();
                foreach (var qry in qryRentSchemesOld)
                {
                    cRentSchemesV oRentScheme = new cRentSchemesV();
                    oRentScheme.Contract_RentSchemeID = qry.Contract_RentSchemeID;
                    oRentScheme.ContractClosureID = qry.ContractClosureID;
                    oRentScheme.FromDateToDate = qry.FromDate.ToString("dd/MM/yyyy") + " - " + qry.ToDate.ToString("dd/MM/yyyy");
                    oRentScheme.RentPerSqFeet = qry.RentPerSqFeet;
                    oRentScheme.SCPerSqFeet = qry.SCPerSqFeet;

                    //int period = 0;
                    //res = int.TryParse(qry.Period.ToString(), out period);
                    //if (res == false) { period = 0; }
                    oRentScheme.Period = qry.Period;
                    oldrentSchemeList.Add(oRentScheme);
                }

                this.lookContractOld.Properties.DataSource = oldrentSchemeList;
                this.lookContractOld.Properties.DisplayMember = "FromDateToDate";
                this.lookContractOld.Properties.ValueMember = "Contract_RentSchemeID";
                //--


                // new rent schemes 
                newRentSchemeList.Clear();
                var qryRentShemesNew = (from cr in context.Contract_RentSchemes
                                        where cr.ContractClosureID == NewContractID
                                        orderby cr.Contract_RentSchemeID descending
                                        select cr).ToList();
                foreach (var qry in qryRentShemesNew)
                {
                    cRentSchemesV oRentScheme = new cRentSchemesV();
                    oRentScheme.Contract_RentSchemeID = qry.Contract_RentSchemeID;
                    oRentScheme.ContractClosureID = qry.ContractClosureID;
                    oRentScheme.FromDateToDate = qry.FromDate.ToString("dd/MM/yyyy") + " - " + qry.ToDate.ToString("dd/MM/yyyy");
                    oRentScheme.RentPerSqFeet = qry.RentPerSqFeet;
                    oRentScheme.SCPerSqFeet = qry.SCPerSqFeet;
                    oRentScheme.Period = qry.Period;
                    newRentSchemeList.Add(oRentScheme);
                }

                this.lookNewContract.Properties.DataSource = newRentSchemeList;
                this.lookNewContract.Properties.DisplayMember = "FromDateToDate";
                this.lookNewContract.Properties.ValueMember = "Contract_RentSchemeID";
                //--
            }
        }




        public DateTime oldContractExpiryDate { get; set; }

        public int OldContractID { get; set; }

        public DateTime newContractStartDate { get; set; }

        public int NewContractID { get; set; }

        public DateTime ToDate { get; set; }

        private void xRentVariation_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void lookOldContract_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dateEditToDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        public decimal DifferenceValue { get; set; }

        private void xRentVariation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(this.textEditTotal.Text.ToString()))
            { this.textEditTotal.EditValue = 0; }

            decimal totalVal = 0;
            bool res = false;

            res = decimal.TryParse(this.textEditTotal.EditValue.ToString(), out totalVal);
            if (res == false) { totalVal = 0; }

            this.DifferenceValue = totalVal;
        }
    }

    class cRentSchemesV
    {
        public int Contract_RentSchemeID { get; set; }
        public int ContractClosureID { get; set; }
        public string FromDateToDate { get; set; }
        public decimal RentPerSqFeet { get; set; }
        public decimal SCPerSqFeet { get; set; }
        public decimal Period { get; set; }
    }

}