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
using System.Transactions;

namespace MMS
{
    public partial class xContract_Terminate : DevExpress.XtraEditors.XtraForm
    {
        //AHPL_DBEntities context = new AHPL_DBEntities();
        public xContract_Terminate()
        {
            InitializeComponent();
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.searchLookUpEditContractID.Text.ToString()))
            {
                return;
            }
            int contid = 0;
            bool res = false; 
            res = int.TryParse(this.searchLookUpEditContractID.EditValue.ToString(),out contid);
            if (res == false) { contid = 0; }

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                if (contid > 0)
                {
                    //if (optContractType.SelectedIndex == 0) // Rent contract
                    {
                        var qryCont = (from c in context.ContractClosures
                                       join comp in context.Companies on c.CompanyID equals comp.CompanyID
                                       join loc in context.Locations on c.LocationID equals loc.LocationID
                                       join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                       join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                                       where c.ContractClosureID == contid
                                       select new { c.ContractClosureID, c.ShopID, c.CompanyID, c.LocationID, gcus.CustomerID, c.LevelID }).FirstOrDefault();
                        if (qryCont == null)
                        {
                            MessageBox.Show("There is no Value to show", "Error - Contract Terminate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        this.lookUpEditCompany.EditValue = qryCont.CompanyID;
                        this.lookUpEditLocation.EditValue = qryCont.LocationID;
                        this.lookUpEditLevel.EditValue = qryCont.LevelID;
                        this.lookUpEditCustomer.EditValue = qryCont.CustomerID;
                        this.lookUpEditShopID.EditValue = qryCont.ShopID;
                    }

                    if (optContractType.SelectedIndex == 1) // Other Service Contract
                    {



                    }


                }
            }

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                if (string.IsNullOrEmpty(this.searchLookUpEditContractID.Text.ToString()))
                {
                    return;
                }

                int contid = 0;
                bool res = false;

                res = int.TryParse(this.searchLookUpEditContractID.EditValue.ToString(), out contid);
                if (res == false) { contid = 0; }

                int locid = int.Parse(this.lookUpEditLocation.EditValue.ToString());
                if (locid == 0) 

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryUL = (from u in context.Permission_Users
                                 join ul in context.UserLocations on u.UserID equals ul.UserID
                                 where u.UserID == CustomClasses.cCommon_Functions.LoggedUserID && ul.LocationID == locid
                                 select ul).ToList();
                    if (qryUL.Count == 0)
                    {
                       throw new Exception("You dont have permission to terminate contract related with other company/location");
                    }                               

                }

                



                if (contid == 0)
                {
                    MessageBox.Show("Please Select the Contract", "Contract Delete?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult dlg = MessageBox.Show("Are you sure, you want to terminate this contract?", "Terminate Contract?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.No)
                { return; }

                using (TransactionScope trs = new TransactionScope())
                {

                    using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {

                        if (contid > 0)
                        {
                            var qryCont = (from c in context.ContractClosures
                                           where c.ContractClosureID == contid
                                           select c).FirstOrDefault();
                            qryCont.IsTerminated = true;
                            qryCont.TerminatedDate = dateEditterminateDate.DateTime;

                            if (optContractType.SelectedIndex == 0)
                            {
                                cReserveShop.ReleaseShop(qryCont.ShopID); // releaseing the shop in the shop table  
                            }
                            else
                            {
                                if (qryCont.IsPoAdvertisement == true)
                                {
                                    cReserveShop.ReleaseShop(qryCont.ShopID);
                                }
                            }
                            int suc = context.SaveChanges();

                            int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.ContractTerminated;
                            MMS.CustomClasses.cCommon_Functions.AddToEmailList(int.Parse(lookUpEditCompany.EditValue.ToString()), int.Parse(lookUpEditLocation.EditValue.ToString()), alert, "Customer : " + this.lookUpEditCustomer.Text.ToString() + System.Environment.NewLine + "Shop Name : " + this.searchLookUpEditContractID.Text.ToString(), MMS.CustomClasses.cCommon_Functions.LoggedUserID);

                            if (suc > 0)
                            {
                                MessageBox.Show("Contract Terminated Successfully...", "Contract Termination", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                load_data();
                                trs.Complete(); // completeing transction after successfull save

                            }

                        }
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
                

            
        }

        private void xContract_Terminate_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
           // loading contracts
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                // terminated Contrats 
                var qryContTerminated = (from c in context.ContractClosures
                                          join comp in context.Companies on c.CompanyID equals comp.CompanyID
                                          join loc in context.Locations on c.LocationID equals loc.LocationID
                                         join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                         join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                                         where c.IsTerminated == true
                                         select new { c.ContractClosureID, c.TerminatedDate, c.ShopName, comp.CompanyCode, loc.LocationCode, gcus.CustomerName, c.ShopNo,c.ContractClosureName,c.Naration,c.IsPromotion,c.FloorArea }).ToList();
                this.gridTerminatedContracts.DataSource = qryContTerminated;
                this.gridTerminatedContracts.RefreshDataSource();
                this.gridView1.BestFitColumns();
                





                // company 
                var qryComp = (from com in context.Companies
                               select new { com.CompanyID, com.CompanyCode, com.CompanyName }).ToList();
                this.lookUpEditCompany.Properties.DataSource = qryComp;
                this.lookUpEditCompany.Properties.DisplayMember = "CompanyName";
                this.lookUpEditCompany.Properties.ValueMember = "CompanyID";

                // Locaiton
                var qryLoc = (from l in context.Locations
                              select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
                this.lookUpEditLocation.Properties.DataSource = qryLoc;
                this.lookUpEditLocation.Properties.DisplayMember = "LocationName";
                this.lookUpEditLocation.Properties.ValueMember = "LocationID";

                // level 
                var qryLevel = (from l in context.Floor_Levels
                                select new { l.LevelID, l.LevelCode, l.LevelName }).ToList();
                this.lookUpEditLevel.Properties.DataSource = qryLevel;
                this.lookUpEditLevel.Properties.DisplayMember = "LevelName";
                this.lookUpEditLevel.Properties.ValueMember = "LevelID";

                // customer
                var qryCust = (from c in context.Global_Customers
                               select new { c.CustomerID, c.SAPCustomerCode, c.CustomerName }).ToList();
                this.lookUpEditCustomer.Properties.DataSource = qryCust;
                this.lookUpEditCustomer.Properties.DisplayMember = "CustomerName";
                this.lookUpEditCustomer.Properties.ValueMember = "CustomerID";

                // shops 
                var qryShop = (from s in context.Shops
                               select new { s.ShopID, s.ShopNo }).ToList();
                this.lookUpEditShopID.Properties.DataSource = qryShop;
                this.lookUpEditShopID.Properties.DisplayMember = "ShopNo";
                this.lookUpEditShopID.Properties.ValueMember = "ShopID";


                this.gridView1.BestFitColumns();
                this.searchLookUpEdit1View.BestFitColumns();
                load_contracts();

                this.dateEditterminateDate.DateTime = DateTime.Now.Date; // system current date
            }

        }

        private void load_contracts(bool pIsOtherService = false)
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                   
                        var qryCont = (from c in context.ContractClosures
                                       join comp in context.Companies on c.CompanyID equals comp.CompanyID
                                       join loc in context.Locations on c.LocationID equals loc.LocationID
                                       join exc in context.Extended_Customers on c.ExtendedCustomerID equals exc.ExtendedCustomerID
                                       join gcus in context.Global_Customers on exc.CustomerID equals gcus.CustomerID
                                       where c.IsTerminated == false && c.IsProcessed == true && c.IsPromotion == pIsOtherService
                                       select new { c.ContractClosureID, c.ShopName, comp.CompanyCode, loc.LocationCode, gcus.CustomerName, c.ShopNo,c.ContractClosureName }).ToList();


                        this.searchLookUpEditContractID.Properties.DataSource = qryCont;
                        if (pIsOtherService == false)
                        { this.searchLookUpEditContractID.Properties.DisplayMember = "ShopName"; }
                        if (pIsOtherService == true)
                        {
                            this.searchLookUpEditContractID.Properties.DisplayMember = "ContractClosureName";
                        }
                        this.searchLookUpEditContractID.Properties.ValueMember = "ContractClosureID";
                        if (pIsOtherService == true)
                        {
                            colShopNo.Visible = false;
                            colShopName.Visible = false;

                        }
                        else
                        {
                            colShopNo.Visible = true;
                            colShopName.Visible = true;

                        }


                    this.gridView1.BestFitColumns();
                    this.searchLookUpEdit1View.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void optContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optContractType.SelectedIndex == 0)
            {
              
                //cEnable_Controls.ClearText(this);
                load_contracts();
                this.searchLookUpEdit1View.BestFitColumns();

            }
            if (optContractType.SelectedIndex == 1)
            {
                ///promotional contracts
                load_contracts(true);
                searchLookUpEdit1View.BestFitColumns();
            }
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Excel (*.xlsx)|*.xlsx";
                saveDlg.ShowDialog();
                string filename = saveDlg.FileName;
                this.gridView1.OptionsPrint.AutoWidth = false;
                if (string.IsNullOrEmpty(filename)) { return; }
                this.gridView1.ExportToXlsx(filename);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                   

                    List<ContractClosure> contList = (from c in context.ContractClosures
                                                      where c.IsTerminated == true
                                                      select c).ToList();
                    foreach (var qry in contList)
                    {
                        var qryInvFound = (from i in context.Invoices
                                           where i.ContractClosureID == qry.ContractClosureID
                                           select i).ToList();
                        if (qryInvFound.Count == 0)
                        {

                            ContractClosure contclosure = (from c in context.ContractClosures
                                                           where c.ContractClosureID == qry.ContractClosureID
                                                           select c).FirstOrDefault();
                            context.ContractClosures.DeleteObject(contclosure);
                            
                            /// deleting contract closure detail
                             var qryContDet = contclosure.ContractClosure_Details.ToList();
                            foreach (var qryC in qryContDet)
                            {
                                ContractClosure_Details contDet = (from c in context.ContractClosure_Details
                                                                   where c.ContractClosureID == qryC.ContractClosureID
                                                                   select c).FirstOrDefault();
                                context.ContractClosure_Details.DeleteObject(contDet);
                            }

                            /// deleting contract rent schemes 
                            var qryContRentSchem = contclosure.Contract_RentSchemes.ToList();
                            foreach (var qryR in qryContRentSchem)
                            {
                                Contract_RentSchemes contRentSc = (from c in context.Contract_RentSchemes
                                                                   where c.ContractClosureID == qryR.ContractClosureID
                                                                   select c).FirstOrDefault();
                                context.Contract_RentSchemes.DeleteObject(contRentSc);

                            }


                         
                        }



                    }

                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Deleted Successfully...", "Delete Success  - Terminated Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    load_data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}