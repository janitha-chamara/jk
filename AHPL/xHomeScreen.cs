using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DataTier;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Configuration;
using System.Deployment.Application;
using System.Data.EntityClient;
using System.Data.SqlClient;
using DevExpress.XtraSplashScreen;
using MMS.Print;
using MMS.Transaction.Rent;
using MMS.Transaction.OtherServices;
using System.IO;
//using MMS.Transaction.Rent;


namespace MMS
{
    public partial class xHomeScreen : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public xHomeScreen()
        {
            InitializeComponent();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
            //HomeS.SetWaitFormDescription("Loading Electricity Rates Form");
            //xElectricityRates erates = new xElectricityRates();
            //erates.MdiParent = this;
            //erates.Show();
            //if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();

        }

        private void xHomeScreen_Load(object sender, EventArgs e)
        {
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo("C:\\MMS_files\\");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                //getActiveConnection();
                string WindowsUserName = System.Environment.UserName;
                bool userExist = MMS.CustomClasses.cCommon_Functions.IsWindowsUserExist(WindowsUserName);
                if (userExist == false)
                {
                    MMS.UserPermission.xLogin login = new UserPermission.xLogin();
                    login.ShowDialog(this);
                    if (login.UserAuthenticated == false)
                    {
                        Application.Exit();
                    }
                }


                SplashScreenManager.ShowForm(this,typeof(SplashScreen1),true,true,false);
                //initalizing user permission
                MMS.CustomClasses.cCommon_Functions.initUserPermission(this);
                //--
               

                this.txtUser.Caption = MMS.CustomClasses.cCommon_Functions.LoggedSystemUserName;
                MMS.CustomClasses.cCommon_Functions.MachineName = System.Environment.MachineName;
                this.txtMachine.Caption = MMS.CustomClasses.cCommon_Functions.MachineName;
                getDomainName();
                

                //Version myVersion;
                //if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                //{
                //    myVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                //}
                if (ApplicationDeployment.IsNetworkDeployed)
                { var ver = ApplicationDeployment.CurrentDeployment.CurrentVersion; }

                SplashScreenManager.CloseForm(false);                
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void getActiveConnection()
        //{
        //    try
        //    {
        //        using (localDBEntities localContext = new localDBEntities())
        //        {
        //            var qryServerSett = (from s in localContext.CommonSettings
        //                                 select s).FirstOrDefault();
        //            if (qryServerSett == null)
        //            {
        //                ServerSettings.xServerSettings serverSett = new ServerSettings.xServerSettings();
        //                serverSett.ShowDialog(this);
        //                return;
        //            }
        //            else
        //            {
        //                if (string.IsNullOrEmpty(qryServerSett.IsServer1Active.ToString()) && string.IsNullOrEmpty(qryServerSett.IsServer2Active.ToString()) && string.IsNullOrEmpty(qryServerSett.IsServer3Active.ToString()))
        //                {
        //                    MessageBox.Show("Invalid Server Configuration", "Server Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    ServerSettings.xServerSettings serverSett = new ServerSettings.xServerSettings();
        //                    serverSett.ShowDialog(this);
        //                    return;

        //                }
        //                else
        //                {


        //                }

        //                if (qryServerSett.IsServer1Active == true)
        //                {

        //                    if (string.IsNullOrEmpty(qryServerSett.DataSource1.ToString()) || string.IsNullOrEmpty(qryServerSett.InitialCatalog1.ToString()) || string.IsNullOrEmpty(qryServerSett.Password1.ToString()) || string.IsNullOrEmpty(qryServerSett.UserID1.ToString()))
        //                    {
        //                        MessageBox.Show("Invalid Server Configuration", "Server Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                        ServerSettings.xServerSettings serverSett = new ServerSettings.xServerSettings();
        //                        serverSett.ShowDialog(this);
        //                        return;
        //                    }
        //                    else
        //                    {

        //                    }

        //                }
        //                if (qryServerSett.IsServer2Active == true)
        //                {
        //                    this.defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Liquid Sky");
        //                    if (string.IsNullOrEmpty(qryServerSett.DataSource2.ToString()) || string.IsNullOrEmpty(qryServerSett.InitialCatalog2.ToString()) || string.IsNullOrEmpty(qryServerSett.Password2.ToString()) || string.IsNullOrEmpty(qryServerSett.UserID2.ToString()))
        //                    {
        //                        MessageBox.Show("Invalid Server Configuration", "Server Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                        ServerSettings.xServerSettings serverSett = new ServerSettings.xServerSettings();
        //                        serverSett.ShowDialog(this);
        //                        return;
        //                    }
        //                    else 
        //                    {

        //                    }

        //                }

        //                if (qryServerSett.IsServer3Active == true)
        //                {
        //                    this.defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Money Twins");


        //                    if (string.IsNullOrEmpty(qryServerSett.DataSource3.ToString()) || string.IsNullOrEmpty(qryServerSett.InitialCatalog3.ToString()) || string.IsNullOrEmpty(qryServerSett.Password3.ToString()) || string.IsNullOrEmpty(qryServerSett.UserID3.ToString()))
        //                    {
        //                        MessageBox.Show("Invalid Server Configuration", "Server Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                        ServerSettings.xServerSettings serverSett = new ServerSettings.xServerSettings();
        //                        serverSett.ShowDialog(this);
        //                        return;
        //                    }
        //                    else
        //                    {


        //                    }


        //                }
        //            }


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
            
        //}

        private void getDomainName()
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                //context.Connection.Open();
                //var qry = (from c in context.Locations
                //           select c).ToList();

                //ConnectionInfo 
                this.lblDomain.Caption = this.lblDomain.Caption + context.Connection.DataSource;
                //var qryEx = context.Global_Customers.ToList();
                //context.Connection.Open();
                this.lblDataSource.Caption = context.Connection.Database.ToString();
                EntityConnection ec = (EntityConnection)context.Connection;
                SqlConnection sc = (SqlConnection)ec.StoreConnection;
                lblDatabase.Caption = sc.Database;
                
               

                //EntityConnectionStringBuilder entityBuilder = (EntityConnectionStringBuilder) sc; ;

               
                string db = sc.Database;
                string ds = sc.DataSource;

                string connstring = sc.ConnectionString;

                //context.Connection.Close();
               
                //this.lblDatabase.Caption = this.lblDatabase.Caption + context.Connection.Database;
                //var connectionString = ConfigurationManager.ConnectionStrings["AHPL_DBEntities"].ConnectionString;
                
 
                //context.Connection.Close();
            }

            this.lblVersionVal.Caption = this.lblVersionVal.Caption + Assembly.GetExecutingAssembly().GetName().Version;
           
            //this.lblVersion.Caption = AHPL.Properties.Settings.Default.




        }

         


     



    

       


        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
            HomeS.SetWaitFormDescription("Loading Renew Contract Form");
            xRenew_Contracts xRenew = new xRenew_Contracts();
            //xRenew.MdiParent = this;
            xRenew.Show(this);
            if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();

        }

     

      

      

       

      

     


        private void btnChangeDataSource_ItemClick(object sender, ItemClickEventArgs e)
        {
            //xAdHocQry addhoq = new xAdHocQry();
            //addhoq.Show();
            
            
            //MessageBox.Show("data base has been changed");
            //AHPL_DBEntities context = new AHPL_DBEntities();
            //string db = context.Connection.Database;
            //string ds1 = context.Connection.DataSource;
            //context.Connection.ConnectionString = "Data Source = 121212;";

            
            //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //connectionStringsSection.ConnectionStrings["AHPL_DBEntities"].ConnectionString = "Data Source=blah;Initial Catalog=blah;UID=blah;password=blah";
            //config.Save();
            //ConfigurationManager.RefreshSection("connectionStrings");
            //Properties.Settings.Default.Reload();
            
            //var dd = context.Connection.ConnectionString = "Data Source=blah;Initial Catalog=blah;UID=blah;password=blah";
           
        }

     

       

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Credit Note");
                xRent_Adj_Credit creditnote = new xRent_Adj_Credit();
                creditnote.pInvoiceType = xRent_Adj_Credit.eInvoiceType.CreditNote;
                creditnote.MdiParent = this;    
                //creditnote.WindowState = FormWindowState.Maximized;
                creditnote.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
            HomeS.SetWaitFormDescription("Loading Other Service Invoice");

            xOtherServices otherS = new xOtherServices();
            //otherS.MdiParent = this;
            //otherS.MdiParent = this;
            otherS.WindowState = FormWindowState.Maximized;
            otherS.Show(this);
            if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();

        }

       

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
            HomeS.SetWaitFormDescription("Loading Contract Age Expiry Form");
            xContractExpiry_Ageing age = new xContractExpiry_Ageing();
            age.MdiParent = this;
            age.Show();
            if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
        }

        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
            HomeS.SetWaitFormDescription("Loading Occupancy Detail");
            MIS.xSalesAndPerformanceDet occdet = new MIS.xSalesAndPerformanceDet();
         
            occdet.Show();
            occdet.MdiParent = this;
            if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();

        }

     

        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
            //HomeS.SetWaitFormDescription("Loading Contract Closure");

            //xContract_Closures closure = new xContract_Closures();
            //closure.MdiParent = this;
            //closure.Show();
            //if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();

        }

     

     

        

             
        private void btnAddendum_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Addendum Note");

                xAddendumNoteR addendum = new xAddendumNoteR();
                addendum.WindowState = FormWindowState.Maximized;
                addendum.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

     

       

       
     

       

      

        private void barButtonItem33_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading SAP Master Setup");
                xSAP_Setup sapsetup = new xSAP_Setup();
                sapsetup.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void barButtonItem33_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Process SAP Document");
                xSAP_Process procsap = new xSAP_Process();
                procsap.WindowState = FormWindowState.Maximized;
                procsap.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Role Center");
                xRoles roles = new xRoles();
                roles.MdiParent = this;
                roles.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading User Management");
                xUsers users = new xUsers();
                users.MdiParent = this;
                users.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRolePermission_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Role Permission");
                xRolePermissions permission = new xRolePermissions();
                permission.WindowState = FormWindowState.Maximized;
                permission.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void barButtonItem12_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //xAdHocQry adhoqqry = new xAdHocQry();
            //adhoqqry.Show(this);
        }

      

       

      

        private void btnRentInvoiceDraft_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Rent Invoice Draft");
                xInvoice_Draft rentInvDraft = new xInvoice_Draft();
                rentInvDraft.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUserGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading User Group");
                MMS.UserPermission.xUserGroups userGroup = new UserPermission.xUserGroups();
                userGroup.MdiParent = this;
                userGroup.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void mnuMasterClauses_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Master Clause Items");
                xContractClausesItems closureitems = new xContractClausesItems();
                closureitems.MdiParent = this;
                closureitems.Show();

                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuContractTemplates_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Contract Templates");

                xContractClausesTemplates contractTemplates = new xContractClausesTemplates();
                contractTemplates.MdiParent = this;
                contractTemplates.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnu3rdShedule_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
              
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading 3rd Schedule");

                xContractClauses closure = new xContractClauses();
                //closure.MdiParent = this;
                closure.WindowState = FormWindowState.Maximized;
                closure.Show(this);

                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void mnuPrintReleaseContracts_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Contract Basket");

                xContract_Baskets contbasket = new xContract_Baskets();
                contbasket.WindowState = FormWindowState.Maximized;
                contbasket.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuAcc3rdSchedule_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading 3rd Schedule");

                xContractClauses closure = new xContractClauses();
                closure.WindowState = FormWindowState.Maximized;
                closure.IsFromAcc = true;
                closure.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuAccPrintReleaseCont_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Print/Release Contract");

                xContract_Baskets contbasket = new xContract_Baskets();
                contbasket.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuAssignContracts_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Assign Contract");
                xContracts1 contracts = new xContracts1();
                contracts.WindowState = FormWindowState.Maximized;
                contracts.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();

            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuTerminateContracts_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Contract Terminate ");

                xContract_Terminate terminate = new xContract_Terminate();
                terminate.WindowState = FormWindowState.Maximized;
                terminate.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();

            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuProcessRentInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Rent Invoice");
                xRent_Invoice_Process inv = new xRent_Invoice_Process();
                inv.WindowState = FormWindowState.Maximized;
                inv.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuAdjustmentRent_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Adjustment Note");
                xRent_Adj_Credit adjustment = new xRent_Adj_Credit();
                adjustment.pInvoiceType = xRent_Adj_Credit.eInvoiceType.Adjustment;
                adjustment.MdiParent = this;
                //adjustment.MdiParent = this;
                adjustment.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuConfirmRentInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Confirm Rent Invoice(s)");
                xRent_Confirm_Invoice genrent = new xRent_Confirm_Invoice();
                genrent.MdiParent = this;
                genrent.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuPrintRentInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Print Rent");
                xPrintRentInv printRent = new xPrintRentInv();
                printRent.MdiParent = this;
                printRent.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuProcessUtilityInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Utility Invoice");

                xUtilityInvoice utinv = new xUtilityInvoice();

                utinv.WindowState = FormWindowState.Maximized;
                utinv.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuUtilityInvoiceBatch_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Utility Invoice Grid");
                xUtitlityInvoice_Batch ubatch = new xUtitlityInvoice_Batch();
                ubatch.WindowState = FormWindowState.Maximized;
                ubatch.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuConfirmUtilityInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Utility Invoice Confirmation");

                xUtilityInvoice_Confirm utilityConfirm = new xUtilityInvoice_Confirm();
                utilityConfirm.MdiParent = this;
                utilityConfirm.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuPrintUtilityInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Print Utility");

                xPrintUtilites printuti = new xPrintUtilites();
                printuti.MdiParent = this;
                printuti.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();

            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void mnuPromotionalContract_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Promotional Contract");

                xPromotional_Contract promc = new xPromotional_Contract();

                promc.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void mnuPrintReleaseProContract_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Release Promotional Contract");

                xReleaseContract promoContractRelease = new xReleaseContract();
                promoContractRelease.IsPromotion = true;
                promoContractRelease.WindowState = FormWindowState.Maximized;
                promoContractRelease.Text = "Release Promotional Contract";
                promoContractRelease.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();

            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuOtherServiceCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Other Service Category");
                xOtherServiceCategories otherservice = new xOtherServiceCategories();
                otherservice.MdiParent = this;
                otherservice.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuConfirmOSInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Other Service Confirm");

                xOtherService_Confirm_Invoice otherSconfirm = new xOtherService_Confirm_Invoice();
                otherSconfirm.WindowState = FormWindowState.Maximized;
                otherSconfirm.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuPrintOSInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Print Other Service Invoice");


                xPrintOSInv otherServicePrint = new xPrintOSInv();
                otherServicePrint.WindowState = FormWindowState.Maximized;
                otherServicePrint.Show(this);
                if (HomeS.IsSplashFormVisible == true)
                { HomeS.CloseWaitForm(); }

            }

            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void mnuEmailAlertProfiles_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false)
                {
                    HomeS.ShowWaitForm();
                    HomeS.SetWaitFormDescription("Loading Email Profiles");
                }
                UserPermission.xEmailAlertProfiles emailAlert = new UserPermission.xEmailAlertProfiles();
                emailAlert.MdiParent = this;
                emailAlert.Show();
                if (HomeS.IsSplashFormVisible == true)
                {
                    HomeS.CloseWaitForm();
                }

            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true)
                {
                    HomeS.CloseWaitForm();
                }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuShopOccupancy_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Loading Occupied Shops"); }
                MIS.xShopOccupied occupancy = new MIS.xShopOccupied();
                occupancy.IsShopOccupiedReport = true;
                occupancy.WindowState = FormWindowState.Maximized;
                occupancy.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuShopUnOccupancy_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Loading Unoccupied Shops"); }

                MIS.xShopUnOccupancy occupancy = new MIS.xShopUnOccupancy();
                //occupancy.IsShopUnoccupiedReport = true;
                occupancy.WindowState = FormWindowState.Maximized;
                occupancy.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuOccupiedAndUnoccupied_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Loading Unoccupied Shops"); }
                MIS.xOccupancyAndUnoccupancy occupancy = new MIS.xOccupancyAndUnoccupancy();             
                occupancy.WindowState = FormWindowState.Maximized;
                occupancy.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuServiceCharge_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Loading Unoccupied Shops"); }
                MIS.xServiceChargeMIS serviceCharge = new MIS.xServiceChargeMIS();                
                serviceCharge.WindowState = FormWindowState.Maximized;
                serviceCharge.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuCustomerRentChargeHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Loading Customer Rent History"); }
                MIS.xCustomerRentChargeHistory customerrentHistory = new MIS.xCustomerRentChargeHistory();
                customerrentHistory.WindowState = FormWindowState.Maximized;
                customerrentHistory.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUtilityReading_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Loading Customer Rent History"); }
                MIS.xMisUtilityReadings utilityReading = new MIS.xMisUtilityReadings();
                utilityReading.WindowState = FormWindowState.Maximized;
                utilityReading.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRentalIncreasedCustomers_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Loading Rental Increased Customer"); }
                MIS.xRentalIncreasedCustomers rentalIncreasedCust = new MIS.xRentalIncreasedCustomers();
                rentalIncreasedCust.WindowState = FormWindowState.Maximized;
                rentalIncreasedCust.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuOtherServiceIncome_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Other Service Income - MIS"); }
                MIS.xOtherServiceIncome otherServiceIncome = new MIS.xOtherServiceIncome();
                otherServiceIncome.WindowState = FormWindowState.Maximized;
                otherServiceIncome.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRentalIncome_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Loading Rental Income"); }
                MIS.xMisRentalIncome rentalIncome = new MIS.xMisRentalIncome();
                rentalIncome.WindowState = FormWindowState.Maximized;
                rentalIncome.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUtilityConsumption_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Loading Utility Consumption"); }
                MIS.xUtilityConsumption utilityConsumption = new MIS.xUtilityConsumption();
                utilityConsumption.WindowState = FormWindowState.Maximized;
                utilityConsumption.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void mnuMailAddress_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Mail Addresses"); }
                Print.xMailAddresses mailAddresses= new Print.xMailAddresses();
                mailAddresses.WindowState = FormWindowState.Maximized;
                mailAddresses.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuAdSpaceUtilized_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Advetising Space Utilized"); }
                MIS.xAdSpaceUtilized adspaceUtilized = new MIS.xAdSpaceUtilized();
                adspaceUtilized.WindowState = FormWindowState.Maximized;
                adspaceUtilized.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuAdSpaceUnutilized_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Advetising Space Unutilized"); }
                MIS.xAdSpaceUnutilized adspaceUnUtilized = new MIS.xAdSpaceUnutilized();
                adspaceUnUtilized.WindowState = FormWindowState.Maximized;
                adspaceUnUtilized.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuEmailAlertItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Email Alert Items"); }
                // = new MIS.xAdSpaceUnutilized();
                UserPermission.xEmailAlertItems emailAlertItem = new UserPermission.xEmailAlertItems();
                emailAlertItem.MdiParent = this;
                emailAlertItem.Show();
                //adspaceUnUtilized.WindowState = FormWindowState.Maximized;
                //adspaceUnUtilized.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuEmailConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Email Configuration"); }
                Alert.xEmailConfig emailConfig = new Alert.xEmailConfig();              
                emailConfig.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuGlobalCustomers_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Global Customers");
                xCustomers gcust = new xCustomers();
                gcust.MdiParent = this;
                gcust.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuCompanies_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Companies");
                xCompanies comp = new xCompanies();
                comp.MdiParent = this;
                comp.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuLocations_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Locations");
                xLocations loc = new xLocations();
                loc.MdiParent = this;
                loc.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void mnuFloorLevels_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Floor Levels");
                xFloor_Levels flevel = new xFloor_Levels();
                flevel.MdiParent = this;
                flevel.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }

            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuShopsBooths_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Shops/Booths");
                xShops shops = new xShops();
                shops.MdiParent = this;
                shops.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRentAreaTypes_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Rent Area Types");

                xRentAreaTypes rentA = new xRentAreaTypes();
                rentA.MdiParent = this;
                rentA.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuZones_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Shopping Mall Zone");
                xZones zone = new xZones();
                zone.MdiParent = this;
                zone.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void mnuCustomerExtentions_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Extended Customers");
                xExtended_Customers extendedcust = new xExtended_Customers();
                extendedcust.MdiParent = this;
                extendedcust.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void mnuTax_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Taxes");
                xTaxes taxes = new xTaxes();
                taxes.MdiParent = this;
                taxes.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void mnuTaxRates_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Tax Rates");
                xTaxRates taxrates = new xTaxRates();
                taxrates.MdiParent = this;
                taxrates.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUtilities_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Utilities");

                xUtilities utility = new xUtilities();
                utility.MdiParent = this;
                utility.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUtilityRateProfiles_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Utility Rate Profiles");
                xUtilityRates utlityrate = new xUtilityRates();
                utlityrate.MdiParent = this;
                utlityrate.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuOtherSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Other Settings");
                xOtherSettings othersettings = new xOtherSettings();
                othersettings.MdiParent = this;
                othersettings.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();

            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRatioMeter_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Ratios");

                xRatio ratio = new xRatio() { MdiParent = this };
                ratio.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuReleaseContract_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Release Rent Contracts");

                xReleaseContract releaseRentContract = new xReleaseContract();

                releaseRentContract.IsPromotion = false;
                releaseRentContract.WindowState = FormWindowState.Maximized;
                releaseRentContract.Text = "Release Rent Contract";
                releaseRentContract.Show(this);

                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();


            }

            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void mnuUtilityConsumptionCW_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Loading Utility Consumption Customer Wise"); }
                MIS.xUtilityConsumptionCustomerWise utilityConsumptionCW = new MIS.xUtilityConsumptionCustomerWise();
                utilityConsumptionCW.WindowState = FormWindowState.Maximized;
                utilityConsumptionCW.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuOtherServiceIncomeCW_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Other Service Income - MIS"); }
                MIS.xOtherServiceIncomeCW otherServiceIncome = new MIS.xOtherServiceIncomeCW();
                otherServiceIncome.WindowState = FormWindowState.Maximized;
                otherServiceIncome.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuServerSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Other Service Income - MIS"); }
                ////ServerSettings.xServerSettings serverSetting = new ServerSettings.xServerSettings();
                ////serverSetting.WindowState = FormWindowState.Maximized;
                ////serverSetting.Show(this);
                //if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuReleasedToAccounts_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Release to Account - Contracts"); }
                Transaction.ContractBasket.xReleaseToAccounts releasedToAcc = new Transaction.ContractBasket.xReleaseToAccounts();
                //serverSetting.WindowState = FormWindowState.Maximized;

                releasedToAcc.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuEmailAlertProfile_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Email Alert Profiles"); }
                UserPermission.xEmailAlertProfiles alerProf = new UserPermission.xEmailAlertProfiles();
                //serverSetting.WindowState = FormWindowState.Maximized;
                alerProf.MdiParent = this;
                alerProf.Show();
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuPendingContractConfirmtion_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Pending Contract Confirmation"); }
                MMS.Transaction.ContractBasket.xPendingContractConfirmation pendingContract = new Transaction.ContractBasket.xPendingContractConfirmation();

                pendingContract.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuReforecasting_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Re-Forecasting"); }

                MIS.xFinancial_Years finYears = new MIS.xFinancial_Years();
                finYears.MdiParent = this;
                finYears.Show();
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuCustomerMasterAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Customer Master-Audit Trail"); }

                AuditTrail.xCustomers_Audit custAudit = new AuditTrail.xCustomers_Audit();
                custAudit.MdiParent = this;
                custAudit.Show();

                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuAddendumNoteAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Addendum Note-Audit Trail"); }

                AuditTrail.xAddendumNote_Audit addendumAudit = new AuditTrail.xAddendumNote_Audit();
                addendumAudit.MdiParent = this;
                addendumAudit.Show();

                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuShopsAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Shops/Booths-Audit Trail"); }

                AuditTrail.xShop_Audit shopAudit = new AuditTrail.xShop_Audit();
                shopAudit.MdiParent = this;
                shopAudit.Show();

                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuTaxAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Tax-Audit Trail"); }

                AuditTrail.xTaxAudit taxAudit = new AuditTrail.xTaxAudit();
                taxAudit.MdiParent = this;
                taxAudit.Show();

                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuContractTemplateAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Contract Template-Audit Trail"); }

                AuditTrail.xContractTemplatesAudit contTemplAudit = new AuditTrail.xContractTemplatesAudit();
                contTemplAudit.MdiParent = this;
                contTemplAudit.Show();

                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuContractTerminateAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Contract Terminate-Audit Trail"); }

                AuditTrail.xContractTerminateAudit contTermAudit = new AuditTrail.xContractTerminateAudit();
                contTermAudit.MdiParent = this;
                contTermAudit.Show();

                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuContractRenewalAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Contract Terminate-Audit Trail"); }

                AuditTrail.xContractRenewalAudit contRenewAudit = new AuditTrail.xContractRenewalAudit();
                contRenewAudit.MdiParent = this;
                contRenewAudit.Show();

                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUtilityCreditNoteAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Utility Credit/Adjutment-Audit Trail"); }

                AuditTrail.xUtilityCreditAudit utilityAudit = new AuditTrail.xUtilityCreditAudit();
                utilityAudit.MdiParent = this;
                utilityAudit.Show();

                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRentCreditNoteAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Rent/Promotion Credit Note-Audit Trail"); }

                AuditTrail.xRentInvoice_Audit rentInvAudit = new AuditTrail.xRentInvoice_Audit();
                rentInvAudit.MdiParent = this;
                rentInvAudit.Show();

                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuReforecastingBudget_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Perfomance Detail Setup - MIS"); }

                MIS.xPerformanceDetails performanceDet = new MIS.xPerformanceDetails();
                performanceDet.MdiParent = this;
                performanceDet.Show();
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuExceptionItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Exceptional Item Setup - MIS"); }

                MIS.xExceptionItem excepItem = new MIS.xExceptionItem();
                //excepItem.MdiParent = this;
                excepItem.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Mall Management System.chm");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUtilityInvoiceDraft_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Utility Invoice - Draft"); }

                Print.xUtilityInv_Draft uinv = new Print.xUtilityInv_Draft();
                uinv.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }

            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void mnuOtherServiceInvoiceDraft_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Utility Invoice - Draft"); }

                Print.xOtherServiceInv_Draft otherServiceInv = new Print.xOtherServiceInv_Draft();
                otherServiceInv.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }

            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuEmailSentLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Email Sent Log"); }

                Alert.xEmailSentItems emailsentLog = new Alert.xEmailSentItems();
                emailsentLog.MdiParent = this;
                emailsentLog.Show();
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }

            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void xHomeScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dlg = MessageBox.Show("Do you want to exit from Mall Management System?" + System.Environment.NewLine + "Note : Please save all the opened documents to avoid data lost"  , "MMS - Quit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            //if (dlg == System.Windows.Forms.DialogResult.No)
            //{
            //    e.Cancel = true;

            //}
            //else
            //{
            //    e.Cancel = false;
            //    Application.Exit();
            //}
        }

        private void mnuOSCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Other Service Category");
                xOtherServiceCategories otherservice = new xOtherServiceCategories();
                otherservice.MdiParent = this;
                otherservice.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuSecurityUserAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Users Audit-Audit Trail"); }

                //AuditTrail.xUtilityCreditAudit utilityAudit = new AuditTrail.xUtilityCreditAudit();
                //utilityAudit.MdiParent = this;
                //utilityAudit.Show();

                AuditTrail.xSecurityUsersAudit userAudit = new AuditTrail.xSecurityUsersAudit();
                userAudit.MdiParent = this;
                userAudit.Show();

                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuInvoiceSummery_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) { HomeS.ShowWaitForm(); HomeS.SetWaitFormDescription("Loading Invoice Summery"); }
                MIS.xInvoiceSummery invoiceSummery = new MIS.xInvoiceSummery();
                invoiceSummery.WindowState = FormWindowState.Maximized;
                invoiceSummery.Show(this);
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) { HomeS.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuSCPerArea_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Shopping Mall SC per Sq");
                xSCPerSq scperSq = new xSCPerSq();
                scperSq.MdiParent = this;
                scperSq.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAllInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Email All Invoices");
                AllInvoicesForShop allInvoices = new AllInvoicesForShop();
                allInvoices.MdiParent = this;
                allInvoices.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region added by ravindra - list all credit notes
        private void btnCreditNotes_ItemClick(object sender, ItemClickEventArgs e)
        {
            ////To Do: Display All credit note in gridview(rent/utility/other)
            ////       Add filter using date range
            ////       Print option for selected credit notes
           
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading All Credit Notes");
                xAllCreditNotes allInvoices = new xAllCreditNotes();
                allInvoices.MdiParent = this;
                allInvoices.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnallinvoicescustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading All Invoices");
                xAllInvoicesForShopname allInvoices = new xAllInvoicesForShopname();
                allInvoices.MdiParent = this;
                allInvoices.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
            #endregion

        private void btnpromotioninvoices_ItemClick(object sender, ItemClickEventArgs e)
        {


            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading All Invoices");
                xAllPromotionInvoices allInvoices = new xAllPromotionInvoices();
                allInvoices.WindowState = FormWindowState.Maximized;
                //allInvoices.MdiParent = this;
                allInvoices.Show();
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrDiscount_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Rent Invoice");
                xRent_Invoice_Discount_Process inv = new xRent_Invoice_Discount_Process();
                inv.WindowState = FormWindowState.Maximized;
                inv.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btncrditnotegrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            //try
            //{
            //    if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
            //    HomeS.SetWaitFormDescription("Loading Credit Note");
            //    xCreditNoteGrid inv = new xCreditNoteGrid();
                
            //    inv.WindowState = FormWindowState.Maximized;
            //    inv.Show(this);
            //    if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            //}
            //catch (Exception ex)
            //{
            //    if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btncreditnotegrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Credit Note");
                xCreditNoteGrid inv = new xCreditNoteGrid();

               // inv.WindowState = FormWindowState.Maximized;
                inv.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xbtnproformas_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void xbtnproforma_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Promotion Proformas");
                xProformaInvoice inv = new xProformaInvoice();

                inv.WindowState = FormWindowState.Maximized;
                inv.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAllProforma_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading All Proformas");
                xAllProformas inv = new xAllProformas(2);

                inv.WindowState = FormWindowState.Maximized;
                inv.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintAllProfoma_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading All Proformas");
                xAllProformas inv = new xAllProformas(1);

                inv.WindowState = FormWindowState.Maximized;
                inv.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuPromotionExpiryAgeing_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
            HomeS.SetWaitFormDescription("Loading Promotion Contract Age Expiry Window");
            xContractPromotionExpiry_Ageing age = new xContractPromotionExpiry_Ageing();
            age.MdiParent = this;
            age.Show();
            if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
        }

        private void btnadjgrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (HomeS.IsSplashFormVisible == false) HomeS.ShowWaitForm();
                HomeS.SetWaitFormDescription("Loading Rent Adjustment");
                x_Rent_Adj_Grid adj = new x_Rent_Adj_Grid();
                // inv.WindowState = FormWindowState.Maximized;
                adj.Show(this);
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (HomeS.IsSplashFormVisible == true) HomeS.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        

       

    }
}