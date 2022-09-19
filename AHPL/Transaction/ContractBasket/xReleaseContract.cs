using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using DataTier;
using DataTier.Reports;
using DataTier.Reports.Contract;

namespace MMS
{
    public partial class xReleaseContract : DevExpress.XtraEditors.XtraForm
    {
        List<cContract_Baskets> cContBasketList = new List<cContract_Baskets>();
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xReleaseContract()
        {
            InitializeComponent();
        }

        private void xReleaseContract_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            
            // location
            var qryLoc = (from l in context.Locations
                          select new { l.LocationID, l.LocationCode }).ToList();
            this.lookLocation.DataSource = qryLoc;
            this.lookLocation.DisplayMember = "LocationCode";
            this.lookLocation.ValueMember = "LocationID";

            // company 
            var qryComp = (from c in context.Companies
                           select new { c.CompanyID, c.CompanyCode }).ToList();
            this.lookCompany.DataSource = qryComp;
            this.lookCompany.DisplayMember = "CompanyCode";
            this.lookCompany.ValueMember = "CompanyID";


            // extended customer 
            var qryExC = (from exC in context.Extended_Customers
                          join gCus in context.Global_Customers on exC.CustomerID equals gCus.CustomerID
                          select new { exC.ExtendedCustomerID, gCus.CustomerName }).ToList();
            this.globalCustomersBindingSource.DataSource = qryExC;


            //gridView1.Columns["IsReleased"].ReadOnly == false;
            gridView1.Columns["IsReleased"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["IsReleased"].OptionsColumn.ReadOnly = false;
            btnSave.Enabled = true;


            var qryCont = (from c in context.ContractClosures
                           where c.IsCancelled == false && c.IsReleased == false && c.IsPromotion == IsPromotion 
                           select new { c.ShopName, c.ContractClosureID, c.ContractClosureName, c.IsProcessed, c.ExtendedCustomerID, c.IsReleased, c.IsPromotion,c.CompanyID,c.LocationID,c.LevelID,c.ShopNo }).ToList();

            cContBasketList.Clear();

            foreach (var qry in qryCont)
            {
                cContract_Baskets oContBasket = new cContract_Baskets();
                oContBasket.ContractClosureID = qry.ContractClosureID;
                oContBasket.ShopName = qry.ShopName;
                oContBasket.ShopNo = qry.ShopNo;
                oContBasket.CompanyID = qry.CompanyID;
                oContBasket.LocationID = qry.LocationID;                
                oContBasket.ContractClosureName = qry.ContractClosureName;
                oContBasket.ExtendedCustomerID = qry.ExtendedCustomerID;
                oContBasket.IsProcessed = qry.IsProcessed;
                oContBasket.IsReleased = qry.IsReleased;
                oContBasket.IsPromotion = qry.IsPromotion;
                if (qry.IsPromotion == true)
                { oContBasket.ContractType = "Promotional Contract"; }
                else { oContBasket.ContractType = "Rent Contract"; }
                oContBasket.Print = false;
                cContBasketList.Add(oContBasket);
            }

           
            this.cContract_BasketsBindingSource.DataSource = cContBasketList;
            this.cContract_BasketsGridControl.RefreshDataSource();
            this.gridView1.BestFitColumns();

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.cContract_BasketsBindingSource.EndEdit();

                var qrySelected = (from c in cContBasketList
                                   where c.IsReleased == true
                                   select c).ToList();
                foreach (var qry in qrySelected)
                {

                    var contcloauseObject = (from c in context.ContractClosures
                                             where c.ContractClosureID == qry.ContractClosureID
                                             select c).FirstOrDefault();
                    contcloauseObject.IsReleased = qry.IsReleased;

                    // email alert 
                     string msgBody ="";
                    int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.ContractReleased;

                    if (contcloauseObject.IsPromotion == true)
                    {
                        msgBody = "Other Service Contract Released " + System.Environment.NewLine + 
                            contcloauseObject.CustomerName + System.Environment.NewLine +
                         contcloauseObject.Naration + System.Environment.NewLine;
                       

                    }
                    else
                    {
                        msgBody = contcloauseObject.CustomerName + System.Environment.NewLine +
                                  contcloauseObject.ShopNo.ToString() + System.Environment.NewLine +
                                  contcloauseObject.ShopName + System.Environment.NewLine;
                    }


                    

                 
                    MMS.CustomClasses.cCommon_Functions.AddToEmailList(contcloauseObject.CompanyID, contcloauseObject.LocationID, alert, msgBody, MMS.CustomClasses.cCommon_Functions.LoggedUserID);

                }
                
                int succ = context.SaveChanges();

                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully...", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                load_data();
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

        public bool IsPromotion { get; set; }

        private void btnSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSelectAll.Checked == true)
            {
                btnSelectAll.Text = "Unselect All";

                foreach (var qry in cContBasketList)
                {
                    qry.IsReleased = true;
                }

            }
            else
            {
                btnSelectAll.Text = "Select All";

                foreach (var qry in cContBasketList)
                {
                    qry.IsReleased = false;
                }
            }

            cContract_BasketsGridControl.RefreshDataSource();

        }
    }
}