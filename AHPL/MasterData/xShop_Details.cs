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
    public partial class xShop_Details : DevExpress.XtraEditors.XtraForm
    {
        public xShop_Details()
        {
            InitializeComponent();
        }

        public int ShopID { get; set; }

        public decimal SqFt { get; set; }

        

        private void xShop_Details_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryShopDet = (from sd in context.Shop_Details
                                      where sd.ShopID == ShopID
                                      select sd).ToList();
                    this.gridControl1.DataSource = qryShopDet;

                    this.txtShopNo.EditValue = this.ShopNo;
                    this.dtDate.DateTime = DateTime.Now.Date;

                                     
                 
                    decimal unallocatedarea = 0;

                    unallocatedarea = getUnallocatedArea();
                    this.txtUnallocatedSpace.EditValue = unallocatedarea;
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal getUnallocatedArea()
        {
            decimal unallocatedarea = 0;
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                decimal totalarea = 0;
                decimal allocatedShopsSqFt = 0;

                var qryLoc = (from l in context.Locations
                              where l.LocationID == this.LocationID
                              select new { l.TotalFloorArea }).FirstOrDefault();

                if (qryLoc != null)
                {
                    totalarea = qryLoc.TotalFloorArea;

                    // shops total allocated square feet
                    List<decimal> total = new List<decimal>();
                    var qryShop = (from s in context.Shops
                                   join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                   where s.LocationID == LocationID && ra.IsAdvertisement == false && s.SqFeet > 1
                                   select new { s.SqFeet }).ToList();
                    foreach (var qry in qryShop)
                    {
                        total.Add(qry.SqFeet);
                    }

                    allocatedShopsSqFt = total.Sum();
                    unallocatedarea = totalarea - allocatedShopsSqFt;
                }



            }
            return unallocatedarea;

        }

        

        private void xShop_Details_FormClosing(object sender, FormClosingEventArgs e)
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

        public string ShopNo { get; set; }

        public decimal LocTotalFloorArea { get; set; }

        public int LocationID { get; set; }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (TransactionScope trs = new TransactionScope())
                {
                    using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {
                        if (string.IsNullOrEmpty(this.txtShopNo.Text.ToString()) || string.IsNullOrEmpty(this.txtSqFt.Text.ToString()) || string.IsNullOrEmpty(this.dtDate.Text.ToString()))
                        { return; }

                        decimal sqft = decimal.Parse(txtSqFt.EditValue.ToString());
                        if (dtDate.DateTime == DateTime.MinValue)
                        { return; }

                        decimal totalFloorArea = 0;
                        decimal totalOccupiedArea = 0;
                        decimal totalshoparea = 0;

                        var qryTotalSqFtLoc = (from l in context.Locations
                                               where l.LocationID == LocationID
                                               select new { l.TotalFloorArea }).FirstOrDefault();
                        if (qryTotalSqFtLoc != null)
                        {
                            totalFloorArea = qryTotalSqFtLoc.TotalFloorArea;
                        }

                        List<decimal> totalList = new List<decimal>();

                        var qryShopTotalOcc = (from s in context.Shops
                                               join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                               where s.LocationID == LocationID && ra.IsAdvertisement == false && s.SqFeet > 1 && s.CustomerID > 0
                                               select new { s.SqFeet }).ToList();
                        foreach (var qry in qryShopTotalOcc)
                        {
                            totalList.Add(qry.SqFeet);
                        }

                        totalOccupiedArea = totalList.Sum();

                        totalList.Clear();
                        var qryShopTotalArea = (from s in context.Shops
                                                join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                                                where s.LocationID == LocationID && ra.IsAdvertisement == false && s.SqFeet > 1
                                                select new { s.SqFeet }).ToList();
                        foreach (var qry in qryShopTotalArea)
                        {
                            totalList.Add(qry.SqFeet);
                        }


                        totalshoparea = totalList.Sum();

                        decimal unoccupedArea = totalFloorArea - (totalshoparea - totalOccupiedArea);

                        //Original value 
                        var qryShopOriginal = (from s in context.Shops
                                               where s.ShopID == ShopID
                                               select new { s.SqFeet }).FirstOrDefault();
                        if (qryShopOriginal.SqFeet != sqft)
                        {

                            decimal difference = sqft - qryShopOriginal.SqFeet;
                            if (difference > 0)
                            {
                                if (difference > unoccupedArea)
                                {
                                    throw new Exception("Entered Square Feet is greater than the Location's total square feet");
                                }
                            }
                        }



                        // checkdate
                        var qryDate = (from sd in context.Shop_Details
                                       where sd.ActiveTo > dtDate.DateTime.Date && sd.ShopID == ShopID
                                       select sd).ToList();
                        if (qryDate.Count > 0)
                        {
                            throw new Exception("Entered date is not valid , since in the history there dates available greater than the entered date");
                        }


                        //getting location's total square feet
                        //var qryLocTotal = (from l in context.Locations
                        //                   where l.LocationID == LocationID
                        //                   select new { l.TotalFloorArea }).FirstOrDefault();
                        //var qryShopTotal = (from s in context.Shops
                        //                    join ra in context.Rent_Area_Types on s.RentAreaTypeID equals ra.RentAreaTypeID
                        //                    where s.LocationID == LocationID && s.SqFeet > 1 && ra.IsAdvertisement == false

                        //select new { s.SqFeet }).Sum(x => x.SqFeet);

                        //decimal availArea = qryLocTotal.TotalFloorArea - qryShopTotal;

                        //decimal totalwithEnterdValue = qryShopTotal +sqft;

                        //decimal unallocatedarea = 0;

                        //unallocatedarea = getUnallocatedArea();

                        //if (sqft > 1)
                        //{
                        //    if (sqft > unallocatedarea)
                        //    {
                        //        throw new Exception("Entered Square Feet is greater than the Location's total square feet");
                        //    }
                        //}

                        Shop_Details shopDetailObj = new Shop_Details();
                        shopDetailObj.ShopID = ShopID;
                        shopDetailObj.SqFeet = sqft;
                        shopDetailObj.ActiveFrom = dtDate.DateTime.Date;
                        shopDetailObj.IsActive = true;
                        context.Shop_Details.AddObject(shopDetailObj);

                        //saving shop's sqfeet
                        var qryShop = (from s in context.Shops
                                       where s.ShopID == ShopID
                                       select s).FirstOrDefault();
                        qryShop.SqFeet = sqft;



                        //inactivating previous shop detail
                        Shop_Details shopdetailLast;
                        shopdetailLast = (from sd in context.Shop_Details
                                          where sd.ShopID == ShopID
                                          select sd).AsEnumerable().LastOrDefault();

                        if (shopdetailLast != null)
                        {
                            var qryLast = (from sd in context.Shop_Details
                                           where sd.ShopDetailID == shopdetailLast.ShopDetailID
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
    }
}
