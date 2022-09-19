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

namespace MMS.Transaction.ContractBasket
{
    public partial class xReleaseToAccounts : DevExpress.XtraEditors.XtraForm
    {
        List<cContract_Baskets> cContBasketList = new List<cContract_Baskets>();
        AHPL_DBEntities context = new AHPL_DBEntities();
        public bool IsPromotion { get; set; }

        public xReleaseToAccounts()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void xReleaseToAccounts_Load(object sender, EventArgs e)
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
            gridView1.Columns["IsReleasedToAccount"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["IsReleasedToAccount"].OptionsColumn.ReadOnly = false;


            btnSave.Enabled = true;

            // location wise filter 
            List<int> userLocList = new List<int>();

            var qryUserLoc = (from ul in context.UserLocations
                              where ul.UserID == MMS.CustomClasses.cCommon_Functions.LoggedUserID
                              select new { ul.LocationID }).ToList();
            foreach (var qry in qryUserLoc)
            {
                userLocList.Add(qry.LocationID);
            }
            
            ///--


            var qryCont = (from c in context.ContractClosures
                           where c.IsCancelled == false && c.IsReleased == true && c.IsReleasedToAccounts ==false && c.IsPromotion == IsPromotion && userLocList.Contains(c.LocationID) && c.IsActive == true
                           select new {c.ShopNo, c.ShopName, c.ContractClosureID, c.ContractClosureName, c.IsProcessed, c.ExtendedCustomerID, c.IsReleased,c.IsReleasedToAccounts, c.IsPromotion,c.CompanyID,c.LocationID }).ToList();

            cContBasketList.Clear();

            foreach (var qry in qryCont)
            {
                cContract_Baskets oContBasket = new cContract_Baskets();
                oContBasket.ContractClosureID = qry.ContractClosureID;
                oContBasket.CompanyID = qry.CompanyID;
                oContBasket.LocationID = qry.LocationID;
                oContBasket.ShopName = qry.ShopName;
                oContBasket.ShopNo = qry.ShopNo;
                oContBasket.ContractClosureName = qry.ContractClosureName;
                oContBasket.ExtendedCustomerID = qry.ExtendedCustomerID;
                oContBasket.IsProcessed = qry.IsProcessed;
                oContBasket.IsReleased = qry.IsReleased;
                oContBasket.IsReleasedToAccount = qry.IsReleasedToAccounts;
                oContBasket.IsPromotion = qry.IsPromotion;
                if (qry.IsPromotion == true)
                { oContBasket.ContractType = "Promotional Contract"; }
                else { oContBasket.ContractType = "Rent Contract"; }
                oContBasket.Print = false;
                cContBasketList.Add(oContBasket);
            }

            cContBasketList = (from c in cContBasketList
                               orderby c.CompanyID, c.LocationID,c.ShopNo
                               select c).ToList();

            this.gridView1.BestFitColumns();
            this.cContract_BasketsBindingSource.DataSource = cContBasketList;
            this.cContract_BasketsGridControl.RefreshDataSource();

            this.gridView1.BestFitColumns();
        }

        private void btnSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSelectAll.Checked == true)
            {
                btnSelectAll.Text = "Unselect All";

                foreach (var qry in cContBasketList)
                {
                    qry.IsReleasedToAccount = true;
                }

            }
            else
            {
                btnSelectAll.Text = "Select All";

                foreach (var qry in cContBasketList)
                {
                    qry.IsReleasedToAccount = false;
                }
            }

            cContract_BasketsGridControl.RefreshDataSource();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.cContract_BasketsBindingSource.EndEdit();

                var qrySelected = (from c in cContBasketList
                                   where c.IsReleasedToAccount == true
                                   select c).ToList();
                foreach (var qry in qrySelected)
                {

                    var contcloauseObject = (from c in context.ContractClosures
                                             where c.ContractClosureID == qry.ContractClosureID
                                             select c).FirstOrDefault();
                    contcloauseObject.IsReleasedToAccounts = qry.IsReleasedToAccount;

                    // email alert 
                    int alert = (int) MMS.CustomClasses.cCommon_Functions.AlertItem.ContractReleasedToAccounts;
                    MMS.CustomClasses.cCommon_Functions.AddToEmailList(contcloauseObject.CompanyID, contcloauseObject.LocationID, alert, "", MMS.CustomClasses.cCommon_Functions.LoggedUserID);

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
    }
}