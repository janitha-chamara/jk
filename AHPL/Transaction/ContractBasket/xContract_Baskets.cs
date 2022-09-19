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
    public partial class xContract_Baskets : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        List<cContract_Baskets> cContBasketList = new List<cContract_Baskets>();
        public xContract_Baskets()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void xContract_Baskets_Load(object sender, EventArgs e)
        {
            this.radioGroupProcessStatus.SelectedIndex = 4;
            //load_data(ProcessStatus.All);
        }
        enum ProcessStatus
        {
            Processed = 1,
            Unprocessed = 2,
            Released = 3,          
            All = 4
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
                //ContractClosure contcloauseObject = new ContractClosure();
                //IQueryable<ContractClosure> contclauseObj = context.ContractClosures.AsQueryable().FirstOrDefault();
                foreach (var qry in qrySelected)
                {
                    //contcloauseObject = new ContractClosure();

                    var contcloauseObject = (from c in context.ContractClosures
                                         where c.ContractClosureID == qry.ContractClosureID
                                         select c).FirstOrDefault();
                    contcloauseObject.IsReleased = qry.IsReleased;

                    int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.ContractReleased;
                    MMS.CustomClasses.cCommon_Functions.AddToEmailList(contcloauseObject.CompanyID, contcloauseObject.LocationID, alert, "", MMS.CustomClasses.cCommon_Functions.LoggedUserID);

                   //AHPL.CustomClasses.cCommon_Functions.EmailAlert("Contract Released", contcloauseObject.CompanyID, contcloauseObject.LocationID, contcloauseObject.ShopName, contcloauseObject.ContractClosureID, AHPL.CustomClasses.cCommon_Functions.LoggedSystemUserName,"Contract Released","","Note : Please take necessary steps to proceed the contract");

                }




                int succ = context.SaveChanges();
                if (succ > 0)
                {
                    MessageBox.Show("Record Saved Successfully...", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                load_data(ProcessStatus.Released);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioGroupProcessStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroupProcessStatus.SelectedIndex == 0) // unprocess items
            {
                load_data(ProcessStatus.Unprocessed);
            }
            if (radioGroupProcessStatus.SelectedIndex == 1) // process items
            {
                load_data(ProcessStatus.Processed);
            }

            if (radioGroupProcessStatus.SelectedIndex ==2) // Released Items
            {
                load_data(ProcessStatus.Released);
            }

            //if (radioGroupProcessStatus.SelectedIndex == 3) // --Unreleased
            //{
            //    load_data(ProcessStatus.Unreleased);

            //}

            if (radioGroupProcessStatus.SelectedIndex == 3) // All Items
            {
                load_data(ProcessStatus.All);
            }



        }

        private void load_data(ProcessStatus processStatus)
        {
            var qryExC = (from exC in context.Extended_Customers
                          join gCus in context.Global_Customers on exC.CustomerID equals gCus.CustomerID
                          select new { exC.ExtendedCustomerID, gCus.CustomerName }).ToList();
            this.globalCustomersBindingSource.DataSource = qryExC;
            
            
            cContBasketList.Clear();
            if (processStatus == ProcessStatus.Unprocessed)
            {
                gridView1.Columns["IsReleased"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["IsReleased"].OptionsColumn.ReadOnly = true;
                btnSave.Enabled = false;
                //btnSave.Visibility = false;


                var qryCont = (from c in context.ContractClosures
                               where c.IsProcessed == false && c.IsCancelled ==false && c.IsPromotion == IsPromotion && c.IsActive == true
                               select new { c.ShopName, c.ContractClosureID, c.ContractClosureName, c.IsProcessed, c.IsReleased,c.IsPromotion, c.ExtendedCustomerID }).ToList();
                foreach (var qry in qryCont)
                {
                    cContract_Baskets oContBasket = new cContract_Baskets();
                    oContBasket.ContractClosureID = qry.ContractClosureID;
                    oContBasket.ShopName = qry.ShopName;
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


            }
            if (processStatus == ProcessStatus.Processed)
            {
                gridView1.Columns["IsReleased"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["IsReleased"].OptionsColumn.ReadOnly = true;
                btnSave.Enabled = false;
                var qryCont = (from c in context.ContractClosures
                               where c.IsProcessed == true && c.IsCancelled == false && c.IsPromotion == IsPromotion && c.IsActive == true
                               select new { c.ShopName, c.ContractClosureID, c.ContractClosureName, c.IsProcessed, c.ExtendedCustomerID, c.IsReleased, c.IsPromotion }).ToList();
                foreach (var qry in qryCont)
                {
                    cContract_Baskets oContBasket = new cContract_Baskets();
                    oContBasket.ContractClosureID = qry.ContractClosureID;
                    oContBasket.ShopName = qry.ShopName;
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

            }
            if (processStatus == ProcessStatus.All)
            {
                gridView1.Columns["IsReleased"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["IsReleased"].OptionsColumn.ReadOnly = true;
                btnSave.Enabled = false;
                var qryCont = (from c in context.ContractClosures
                               where c.IsCancelled == false && c.IsPromotion == IsPromotion && c.IsActive == true
                               select new { c.ShopName, c.ContractClosureID, c.ContractClosureName, c.IsProcessed, c.ExtendedCustomerID, c.IsReleased, c.IsPromotion }).ToList();
                foreach (var qry in qryCont)
                {
                    cContract_Baskets oContBasket = new cContract_Baskets();
                    oContBasket.ContractClosureID = qry.ContractClosureID;
                    oContBasket.ShopName = qry.ShopName;
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

            }

            if (processStatus == ProcessStatus.Released) // released
            {
                gridView1.Columns["IsReleased"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["IsReleased"].OptionsColumn.ReadOnly = true;
                btnSave.Enabled = false;
                var qryCont = (from c in context.ContractClosures
                               where c.IsCancelled == false && c.IsReleased == true && c.IsPromotion == IsPromotion
                               select new { c.ShopName, c.ContractClosureID, c.ContractClosureName, c.IsProcessed, c.ExtendedCustomerID, c.IsReleased, c.IsPromotion }).ToList();
                foreach (var qry in qryCont)
                {
                    cContract_Baskets oContBasket = new cContract_Baskets();
                    oContBasket.ContractClosureID = qry.ContractClosureID;
                    oContBasket.ShopName = qry.ShopName;
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

            }

            //if (processStatus == ProcessStatus.Unreleased) // unreleased
            //{
            //    //gridView1.Columns["IsReleased"].ReadOnly == false;
            //    gridView1.Columns["IsReleased"].OptionsColumn.AllowEdit = true;
            //    gridView1.Columns["IsReleased"].OptionsColumn.ReadOnly = false;
            //    btnSave.Enabled = true;


            //    var qryCont = (from c in context.ContractClosures
            //                   where c.IsCancelled == false && c.IsReleased == false
            //                   select new { c.ShopName, c.ContractClosureID, c.ContractClosureName, c.IsProcessed, c.ExtendedCustomerID,c.IsReleased,c.IsPromotion }).ToList();
            //    foreach (var qry in qryCont)
            //    {
            //        cContract_Baskets oContBasket = new cContract_Baskets();
            //        oContBasket.ContractClosureID = qry.ContractClosureID;
            //        oContBasket.ShopName = qry.ShopName;
            //        oContBasket.ContractClosureName = qry.ContractClosureName;
            //        oContBasket.ExtendedCustomerID = qry.ExtendedCustomerID;
            //        oContBasket.IsProcessed = qry.IsProcessed;
            //        oContBasket.IsReleased = qry.IsReleased;
            //        oContBasket.IsPromotion = qry.IsPromotion;
            //        if (qry.IsPromotion == true)
            //        { oContBasket.ContractType = "Promotional Contract"; }
            //        else { oContBasket.ContractType = "Rent Contract"; }
            //        oContBasket.Print = false;
            //        cContBasketList.Add(oContBasket);
            //    }

            //}

            this.cContract_BasketsBindingSource.DataSource = cContBasketList;
            this.cContract_BasketsGridControl.RefreshDataSource();

        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                this.Validate();
                this.cContract_BasketsGridControl.RefreshDataSource();

                this.cContract_BasketsBindingSource.EndEdit();

                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Generating Print");
                }

                var qryCClosure = (from c in cContBasketList
                                   join cont in context.ContractClosures on c.ContractClosureID equals cont.ContractClosureID
                                   where c.Print == true
                                   select new { cont.ContractClosureID, cont.ContractClosureTempID, cont.ContractClosureName }).ToList();
                if (qryCClosure.Count == 0)
                {
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                    return;
                }


                var qryCClosreDet = (from c in context.ContractClosure_Details
                                     where c.IsSelected == true
                                     select new { c.ClosureMappingID, c.Contents, c.ContentValue, c.ContractClosureDetailID, c.ContractClosureID, c.ContractClosureItemID, c.IsSelected, c.PrintNumber }).ToList();
                var qryCItems = (from i in context.Contract_Closure_Items
                                 select i).ToList();

                var qryCSubTempl = (from s in context.Conract_Closure_Sub_Templates
                                    select new { s.CompanyID, s.ContractClosureTempID, s.ContractClosureTemplate_Details, s.PageNo, s.PageTitle, s.Signature1, s.Signature2, s.TemplateName }).ToList();

                rptMain reportMain = new rptMain();
                rptContractClosure rptContClosure = new rptContractClosure();
                reportMain.crystalReportViewer1.ReportSource = rptContClosure;

                rptContClosure.Database.Tables["DataTier_ContractClosure"].SetDataSource(qryCClosure);
                rptContClosure.Database.Tables["DataTier_ContractClosure_Details"].SetDataSource(qryCClosreDet);
                rptContClosure.Database.Tables["DataTier_Contract_Closure_Items"].SetDataSource(qryCItems);
                rptContClosure.Database.Tables["DataTier_Conract_Closure_Sub_Templates"].SetDataSource(qryCSubTempl);

                reportMain.Show();

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool IsPromotion { get; set; }
    }
}