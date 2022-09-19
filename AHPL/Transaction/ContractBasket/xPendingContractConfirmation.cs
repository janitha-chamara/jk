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
    public partial class xPendingContractConfirmation : DevExpress.XtraEditors.XtraForm
    {
        List<cPendingContConfirmation> pendingList = new List<cPendingContConfirmation>();
        public xPendingContractConfirmation()
        {
            InitializeComponent();
        }

        private void xPendingContractConfirmation_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryNewContract = (from c in context.ContractClosures
                                          where c.IsTerminated == false && c.IsActive == false && c.IsReleased ==true && c.IsProcessed==false && c.RefNo > 0
                                          select c).ToList();
                    foreach (var qry in qryNewContract)
                    {


                        // New contract
                        cPendingContConfirmation pendingObj = new cPendingContConfirmation();
                        pendingObj.ContractClauseID = qry.ContractClosureID;
                        pendingObj.ContractName = qry.ContractClosureName;
                        pendingObj.Company = context.Companies.Where(x => x.CompanyID == qry.CompanyID).FirstOrDefault().CompanyCode;
                        pendingObj.Location = context.Locations.Where(x => x.LocationID == qry.LocationID).FirstOrDefault().LocationCode;
                        pendingObj.Level = context.Floor_Levels.Where(x => x.LevelID == qry.LevelID).FirstOrDefault().LevelName;
                        pendingObj.ShopName = qry.ShopName;
                        pendingObj.ShopNo = qry.ShopNo;
                        //customer 
                        var qryCust = (from ec in context.Extended_Customers
                                       join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                       where ec.ExtendedCustomerID == qry.ExtendedCustomerID
                                       select new { gc.CustomerName }).FirstOrDefault();
                        pendingObj.Customer = qryCust.CustomerName;

                        var qryRentScheme = qry.Contract_RentSchemes.FirstOrDefault();

                        pendingObj.StartDate = qryRentScheme.FromDate;
                        pendingObj.ExpiryDate = qryRentScheme.ToDate;
                        pendingList.Add(pendingObj);
                        //--old contract 

                        this.cPendingContConfirmationBindingSource.DataSource = pendingList;
                        searchLookUpEdit1View.BestFitColumns();
                        searchLookUpEdit1View.RefreshData();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.searchLookUpEdit1.Text.ToString())) 
                { return;}
                int contractid = int.Parse(this.searchLookUpEdit1.EditValue.ToString());

                DateTime currDate = DateTime.Now.Date;
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryContractNew = (from c in context.ContractClosures
                                       where c.ContractClosureID == contractid
                                       select c).FirstOrDefault();
                    var qryContractOld = (from c in context.ContractClosures
                                          where c.ContractClosureID == qryContractNew.RefNo 
                                          select c).FirstOrDefault();
                    var qryRentSchemeOld = qryContractOld.Contract_RentSchemes.LastOrDefault();
                    var qryRentSchemeNew = qryContractNew.Contract_RentSchemes.FirstOrDefault();


                    if (qryContractOld.IsTerminated == false)
                    {

                        if (qryRentSchemeOld.ToDate < currDate)
                        {
                            string msg = "New Contract (Activating Contract)  " + System.Environment.NewLine +
                                "Contract : " + qryContractNew.ContractClosureName + System.Environment.NewLine +
                                "Shop Name : " + qryContractNew.ShopName + System.Environment.NewLine +
                                "Shop No : " + qryContractNew.ShopNo + System.Environment.NewLine +
                                "From Date : " + qryRentSchemeNew.FromDate.ToString("dd/MM/yyyy") + System.Environment.NewLine +
                                "Expiry Date : " + qryRentSchemeNew.ToDate.ToString("dd/MM/yyyy") + System.Environment.NewLine + System.Environment.NewLine +
                                "Old Contract (Terminating Contract) " + System.Environment.NewLine +
                                "Contract : " + qryContractOld.ContractClosureName + System.Environment.NewLine +
                                "Shop Name : " + qryContractOld.ShopName + System.Environment.NewLine +
                                "Shop No : " + qryContractOld.ShopNo + System.Environment.NewLine +
                                "From Date : " + qryRentSchemeOld.FromDate.ToString("dd/MM/yyyy") + System.Environment.NewLine +
                                "Expiry Date : " + qryRentSchemeOld.ToDate.ToString("dd/MM/yyyy") + System.Environment.NewLine + System.Environment.NewLine +
                                "Do you want to continue ? ";
                            DialogResult dlg = MessageBox.Show(msg, "Activating Contract - Pending Contract Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlg == System.Windows.Forms.DialogResult.Yes)
                            {
                                // updating old contract
                                qryContractOld.IsTerminated = true;
                                qryContractOld.TerminatedDate = DateTime.Now;
                                qryContractOld.IsActive = false;
                                qryContractOld.LastUpdated = CustomClasses.cCommon_Functions.LoggedUserID;
                                qryContractOld.LastUpdateDate = DateTime.Now;
                                cReserveShop.ReleaseShop(qryContractOld.ShopID); // releasing shop
                                // updating new contract 
                                qryContractNew.IsActive = true;
                                qryContractNew.LastUpdated = CustomClasses.cCommon_Functions.LoggedUserID;
                                qryContractNew.LastUpdateDate = DateTime.Now;

                                int succ = context.SaveChanges();
                                if (succ > 0)
                                {
                                    MessageBox.Show("Record(s) saved successfully...", "Save Success - Pending Contract Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.ContractRenewed;
                                    CustomClasses.cCommon_Functions.AddToEmailList(qryContractNew.CompanyID, qryContractNew.LocationID, alert, msg, CustomClasses.cCommon_Functions.LoggedUserID, null, "Contract Renewed : " + qryContractNew.ShopName);
                                }
                                load_data();

                            }





                        }
                        else
                        {
                            string msg = "Contract : " + qryContractOld.ContractClosureName + System.Environment.NewLine +
                                "Shop Name : " + qryContractOld.ShopName + System.Environment.NewLine +
                                "Shop No : " + qryContractOld.ShopNo + System.Environment.NewLine +
                                "From Date : " + qryRentSchemeOld.FromDate.ToString("dd/MM/yyyy") + System.Environment.NewLine +
                                "Expiry Date : " + qryRentSchemeOld.ToDate.ToString("dd/MM/yyyy") + System.Environment.NewLine + System.Environment.NewLine +
                                "The above contract not expired yet, therefore cannot be activated.";
                            MessageBox.Show(msg, "Cannot Acitvate - Pending Contract Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        }
                    }

                    else // if terminated true
                    {

                        string msg = "New Contract (Activating Contract)  " + System.Environment.NewLine +
                               "Contract : " + qryContractNew.ContractClosureName + System.Environment.NewLine +
                               "Shop Name : " + qryContractNew.ShopName + System.Environment.NewLine +
                               "Shop No : " + qryContractNew.ShopNo + System.Environment.NewLine +
                               "From Date : " + qryRentSchemeNew.FromDate.ToString("dd/MM/yyyy") + System.Environment.NewLine +
                               "Expiry Date : " + qryRentSchemeNew.ToDate.ToString("dd/MM/yyyy") + System.Environment.NewLine + System.Environment.NewLine +
                               "Old Contract (Terminating Contract) " + System.Environment.NewLine +
                               "Contract : " + qryContractOld.ContractClosureName + System.Environment.NewLine +
                               "Shop Name : " + qryContractOld.ShopName + System.Environment.NewLine +
                               "Shop No : " + qryContractOld.ShopNo + System.Environment.NewLine +
                               "From Date : " + qryRentSchemeOld.FromDate.ToString("dd/MM/yyyy") + System.Environment.NewLine +
                               "Expiry Date : " + qryRentSchemeOld.ToDate.ToString("dd/MM/yyyy") + System.Environment.NewLine + System.Environment.NewLine +
                               "Do you want to continue ? ";
                        DialogResult dlg = MessageBox.Show(msg, "Activating Contract - Pending Contract Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlg == System.Windows.Forms.DialogResult.Yes)
                        {
                            // updating old contract
                            qryContractOld.IsTerminated = true;
                            qryContractOld.TerminatedDate = DateTime.Now;
                            qryContractOld.IsActive = false;
                            qryContractOld.LastUpdated = CustomClasses.cCommon_Functions.LoggedUserID;
                            qryContractOld.LastUpdateDate = DateTime.Now;
                            cReserveShop.ReleaseShop(qryContractOld.ShopID); // releasing shop
                            // updating new contract 
                            qryContractNew.IsActive = true;
                            qryContractNew.LastUpdated = CustomClasses.cCommon_Functions.LoggedUserID;
                            qryContractNew.LastUpdateDate = DateTime.Now;

                            int succ = context.SaveChanges();
                            if (succ > 0)
                            {
                                MessageBox.Show("Record(s) saved successfully...", "Save Success - Pending Contract Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.ContractRenewed;
                                CustomClasses.cCommon_Functions.AddToEmailList(qryContractNew.CompanyID, qryContractNew.LocationID, alert, msg, CustomClasses.cCommon_Functions.LoggedUserID, null, "Contract Renewed : " + qryContractNew.ShopName);
                            }
                            load_data();

                        }

                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class cPendingContConfirmation
    {
       public int ContractClauseID { get; set; }
       public string ContractName { get; set; }
       public string ShopName { get; set; }
       public string ShopNo { get; set; }
       public string Company { get; set; }
       public string Location { get; set; }
       public string Level { get; set; }
       public string Customer { get; set; }
       public DateTime StartDate { get; set; }
       public DateTime ExpiryDate { get; set; }
       public bool IsActive { get; set; }
       public int RefNo { get; set; }
    }
}