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
using System.Transactions;

namespace MMS.MasterData
{
    public partial class xLocation_Details : DevExpress.XtraEditors.XtraForm
    {
        public xLocation_Details()
        {
            InitializeComponent();
        }

        private void xLocation_Details_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryLocDet= (from l in context.Location_Details
                                      where l.LocationID == LocationID
                                      select l).ToList();
                    this.gridControl1.DataSource = qryLocDet;

                    this.txtLocationCode.EditValue = this.LocationCode;
                    this.dtDate.DateTime = DateTime.Now.Date;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public decimal SqFt { get; set; }
        public int LocationID { get; set; }
        public string LocationCode { get; set; }

        

        private void xLocation_Details_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSqFt.Text.ToString()))
            {
                decimal sqft = decimal.Parse(this.txtSqFt.EditValue.ToString());
                if (sqft > 0)
                {
                    this.SqFt = sqft;
                }

            }
        }

       

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (TransactionScope trs = new TransactionScope())
                {
                    using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {
                        if (string.IsNullOrEmpty(this.txtLocationCode.Text.ToString()) || string.IsNullOrEmpty(this.txtSqFt.Text.ToString()) || string.IsNullOrEmpty(this.dtDate.Text.ToString()))
                        { return; }

                        decimal sqft = decimal.Parse(txtSqFt.EditValue.ToString());
                        if (dtDate.DateTime == DateTime.MinValue)
                        { return; }

                        // checkdate
                        var qryDate = (from l in context.Location_Details
                                       where l.ActiveTo > dtDate.DateTime.Date && l.LocationID == LocationID
                                       select l).ToList();
                        if (qryDate.Count > 0)
                        {
                            throw new Exception("Entered date is not valid , since in the history there dates available greater than the entered date");
                        }

                        List<decimal> totalList = new List<decimal>();
                        var qryShopsTotal = (from s in context.Shops
                                             join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                             where s.LocationID == LocationID && ra.IsAdvertisement == false && s.SqFeet > 1
                                             select new { s.SqFeet }).ToList();
                        foreach (var qry in qryShopsTotal)
                        {
                            totalList.Add(qry.SqFeet);
                        }

                        decimal total = totalList.Sum();

                        if (total > sqft)
                        {
                            throw new Exception("You cant decrease the location's total squarefeet, since Total Shop's Occupied Area is " + qryShopsTotal.ToString());

                        }

                        Location_Details locdetailObj = new Location_Details();
                        locdetailObj.LocationID = LocationID;
                        locdetailObj.SqFeet = sqft;
                        locdetailObj.ActiveFrom = dtDate.DateTime.Date;
                        locdetailObj.IsActive = true;
                        context.Location_Details.AddObject(locdetailObj);

                        //saving location's sqfeet
                        var qryloc = (from l in context.Locations
                                      where l.LocationID == LocationID
                                      select l).FirstOrDefault();
                        qryloc.TotalFloorArea = sqft;



                        //inactivating previous location detail
                        Location_Details locdetailLast;
                        locdetailLast = (from sd in context.Location_Details
                                         where sd.LocationID == LocationID
                                         select sd).AsEnumerable().LastOrDefault();

                        if (locdetailLast != null)
                        {
                            var qryLast = (from sd in context.Location_Details
                                           where sd.LocationDetailID == locdetailLast.LocationDetailID
                                           select sd).FirstOrDefault();

                            qryLast.ActiveTo = dtDate.DateTime.Date;
                            qryLast.IsActive = false;
                        }


                        int succ = context.SaveChanges();

                        if (succ > 0)
                        {
                            MessageBox.Show("Record Saved Successfully...", "Save Success - Shop Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        load_data();
                        trs.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

    }
}
