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


namespace MMS.Print
{
    public partial class xMailAddresses : DevExpress.XtraEditors.XtraForm
    {
        List<Envelope> envelopeList = new List<Envelope>();
        public xMailAddresses()
        {
            InitializeComponent();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); } 
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    //envelopeList.Clear();

                    var qryExtCust = (from ec in context.Extended_Customers
                                      join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                      join s in context.Shops on ec.ExtendedCustomerID equals s.CustomerID 
                                      select new { ec.ExtendedCustomerID, ec.CompanyID, ec.LocationID, ec.CustomerID, gc.CompanyAddress,s.ShopNo,s.ShopName,s.LevelID}).ToList();

                    foreach (var qry in qryExtCust)
                    {
                        splashScreenManager1.SetWaitFormDescription(qry.ShopNo);


                        var qryFound = (from el in envelopeList
                                        where el.ExtendedCustomerID == qry.ExtendedCustomerID 
                                        select el).FirstOrDefault();
                        if (qryFound == null)
                        {
                            // invoice 
                           
                                Envelope envlope = new Envelope();
                                envlope.InvoiceTypeID = 1;
                                envlope.CategoryName = "RENT";
                                envlope.CompanyID = qry.CompanyID;
                                envlope.LocationID = qry.LocationID;
                                envlope.LocationCode = getLocationCode(qry.LocationID);
                                envlope.CompanyName = getCompanyName(qry.CompanyID);
                                envlope.CompanyAddress = getCompanyAddress(qry.LocationID);
                                envlope.CustomerCompanyName = getCustomerName(qry.CustomerID);
                                envlope.LevelID = qry.LevelID;
                                envlope.LevelName = getLevelName(qry.LevelID);
                                envlope.ExtendedCustomerID = qry.ExtendedCustomerID;
                                envlope.GlobalCustomerID = qry.CustomerID;
                                envlope.Adressee = "";
                                envlope.DeliveryOptionID = 1;
                                envlope.DeliveryOptionName = getDeliverOptionName(1);
                                envlope.ShopNo = qry.ShopNo;
                                envlope.ShopName = qry.ShopName;
                                envlope.PostalAddress = qry.CompanyAddress;
                                context.Envelopes.AddObject(envlope);
                                envelopeList.Add(envlope);
                                //--
                           

                            
                                // utilities entry 
                                var qryUtili = (from u in context.Utilities
                                                select new { u.UtilityName });
                                foreach (var qryU in qryUtili)
                                {

                                    envlope = new Envelope();
                                    envlope.InvoiceTypeID = 2;
                                    envlope.CategoryName = qryU.UtilityName;
                                    envlope.CompanyID = qry.CompanyID;
                                    envlope.CompanyName = getCompanyName(qry.CompanyID);
                                    envlope.CompanyAddress = getCompanyAddress(qry.LocationID);
                                    envlope.Adressee = "";
                                    envlope.DeliveryOptionID = 1;
                                    envlope.DeliveryOptionName = getDeliverOptionName(1);
                                    envlope.ExtendedCustomerID = qry.ExtendedCustomerID;
                                    envlope.LocationID = qry.LocationID;
                                    envlope.LocationCode = getLocationCode(qry.LocationID);
                                    envlope.LevelID = qry.LevelID;
                                    envlope.LevelName = getLevelName(qry.LevelID);
                                    envlope.PostalAddress = qry.CompanyAddress;
                                    envlope.ShopName = qry.ShopName;
                                    envlope.ShopNo = qry.ShopNo;
                                    envlope.GlobalCustomerID = qry.CustomerID;
                                    envlope.CustomerCompanyName = getCustomerName(qry.CustomerID);
                                    envlope.IsPrint = false;
                                    context.Envelopes.AddObject(envlope);
                                    envelopeList.Add(envlope);
                                }                           

                        }
                        else
                        {
                            if (qryFound.InvoiceTypeID != 1)
                            {
                                Envelope envlope = new Envelope();
                                envlope.InvoiceTypeID = 1;
                                envlope.CategoryName = "RENT";
                                envlope.CompanyID = qry.CompanyID;
                                envlope.LocationID = qry.LocationID;
                                envlope.LocationCode = getLocationCode(qry.LocationID);
                                envlope.CompanyName = getCompanyName(qry.CompanyID);
                                envlope.CompanyAddress = getCompanyAddress(qry.LocationID);
                                envlope.CustomerCompanyName = getCustomerName(qry.CustomerID);
                                envlope.LevelID = qry.LevelID;
                                envlope.LevelName = getLevelName(qry.LevelID);
                                envlope.ExtendedCustomerID = qry.ExtendedCustomerID;
                                envlope.GlobalCustomerID = qry.CustomerID;
                                envlope.Adressee = "";
                                envlope.DeliveryOptionID = 1;
                                envlope.DeliveryOptionName = getDeliverOptionName(1);
                                envlope.ShopNo = qry.ShopNo;
                                envlope.ShopName = qry.ShopName;
                                envlope.PostalAddress = qry.CompanyAddress;
                                context.Envelopes.AddObject(envlope);
                                envelopeList.Add(envlope);
                                //--
                            }

                            if (qryFound.InvoiceTypeID != 2)
                            {
                                // utilities entry 
                                var qryUtili = (from u in context.Utilities
                                                select new { u.UtilityName });
                                foreach (var qryU in qryUtili)
                                {

                                    Envelope envlope = new Envelope();
                                    envlope.InvoiceTypeID = 2;
                                    envlope.CategoryName = qryU.UtilityName;
                                    envlope.CompanyID = qry.CompanyID;
                                    envlope.CompanyName = getCompanyName(qry.CompanyID);
                                    envlope.CompanyAddress = getCompanyAddress(qry.LocationID);
                                    envlope.Adressee = "";
                                    envlope.DeliveryOptionID = 1;
                                    envlope.DeliveryOptionName = getDeliverOptionName(1);
                                    envlope.ExtendedCustomerID = qry.ExtendedCustomerID;
                                    envlope.LocationID = qry.LocationID;
                                    envlope.LocationCode = getLocationCode(qry.LocationID);
                                    envlope.LevelID = qry.LevelID;
                                    envlope.LevelName = getLevelName(qry.LevelID);
                                    envlope.PostalAddress = qry.CompanyAddress;
                                    envlope.ShopName = qry.ShopName;
                                    envlope.ShopNo = qry.ShopNo;
                                    envlope.GlobalCustomerID = qry.CustomerID;
                                    envlope.CustomerCompanyName = getCustomerName(qry.CustomerID);
                                    envlope.IsPrint = false;
                                    context.Envelopes.AddObject(envlope);
                                    envelopeList.Add(envlope);
                                }
                            }


                        }

                    }

                    int save = context.SaveChanges();
                    if (save > 0)
                    {
                        MessageBox.Show(save.ToString() + " Record(s) Added", "Record Added - Envelopes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    envelopeBindingSource.DataSource = envelopeList;
                    this.envelopeGridControl.RefreshDataSource();
                    this.gridView1.BestFitColumns();
                    load_data();
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getCustomerName(int pCustomerID)
        {
            string customerName = "N/A";

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryCust = (from c in context.Global_Customers
                                      where c.CustomerID == pCustomerID
                                      select new { c.CustomerName }).FirstOrDefault();
                    if (qryCust != null)
                    {
                        customerName = qryCust.CustomerName;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customerName;
        }

        private string getCompanyAddress(int pLocationID)
        {
            string companyAddress = "N/A";

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryCompAdd = (from c in context.Locations
                                       where c.LocationID == pLocationID
                                       select new { c.Address }).FirstOrDefault();
                    if (qryCompAdd != null)
                    {
                        companyAddress = qryCompAdd.Address;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return companyAddress;
        }

        private string getCompanyName(int pCompanyID)
        {
            string companyName = "N/A";

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryCompName = (from c in context.Companies
                                       where c.CompanyID == pCompanyID
                                       select new { c.CompanyName }).FirstOrDefault();
                    if (qryCompName != null)
                    {
                        companyName = qryCompName.CompanyName;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return companyName;

        }

        private string getLocationCode(int pLocationID)
        {
            string locCode = "";
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryLoc = (from l in context.Locations
                                  where l.LocationID == pLocationID
                                  select new { l.LocationCode }).FirstOrDefault();
                    if (qryLoc != null)
                    {
                        locCode = qryLoc.LocationCode;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return locCode;
        }

        private string getLevelName(int pLevelID)
        {
            string levelName = "";

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryLevel = (from l in context.Floor_Levels
                                where l.LevelID == pLevelID
                                select new { l.LevelName }).FirstOrDefault();
                if (qryLevel != null)
                {
                    levelName = qryLevel.LevelName;
                }


            }

            return levelName;

        }

        private string getDeliverOptionName(int pDeliveryOptionID)
        {
            string deliveryOptionName = "";
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryDeliveryOption = (from d in context.DeliveryOptions
                                         where d.DeliveryOptionID == pDeliveryOptionID
                                         select new { d.DeliveryOptionName }).FirstOrDefault();
                if (qryDeliveryOption != null)
                {
                    deliveryOptionName = qryDeliveryOption.DeliveryOptionName;
                }


            }

            return deliveryOptionName;
        }

        private void xMailAddresses_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    // primary entity 

                    envelopeList = (from env in context.Envelopes
                                    orderby env.CompanyID, env.LocationID,env.GlobalCustomerID, env.ExtendedCustomerID
                                    select env).ToList();
                    this.envelopeBindingSource.DataSource = envelopeList;

                    var qryCategory = (from en in envelopeList
                                       select new { en.CategoryName }).Distinct().ToList();
                    cboCategory.Properties.Items.Clear();
                    foreach (var qry in qryCategory)
                    {
                        cboCategory.Properties.Items.Add(qry.CategoryName);
                    }


                    // company 
                    var qryComp = (from c in context.Companies
                                   select new { c.CompanyID, c.CompanyCode }).ToList();
                  this.chkCompany.Properties.DataSource = this.lookCompanyID.DataSource = qryComp;
                  this.chkCompany.Properties.DisplayMember = this.lookCompanyID.DisplayMember = "CompanyCode";
                  this.chkCompany.Properties.ValueMember = this.lookCompanyID.ValueMember = "CompanyID";

                    // location 
                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode }).ToList();
                    lookLocationID.DataSource = qryLoc;
                    lookLocationID.DisplayMember = "LocationCode";
                    lookLocationID.ValueMember = "LocationID";

                    // invoice type 
                    var qryInvType = (from i in context.Invoice_Types
                                      select new { i.InvoiceTypeID, i.InvoiceTypeName }).ToList();
                    this.lookupInvoiceTypeID.DataSource = qryInvType;
                    this.lookupInvoiceTypeID.DisplayMember = "InvoiceTypeName";
                    this.lookupInvoiceTypeID.ValueMember = "InvoiceTypeID";

                    // delivery option
                    var qryDelivery = (from d in context.DeliveryOptions
                                       select new { d.DeliveryOptionID, d.DeliveryOptionName }).ToList();
                    this.lookDeliveryOptionID.DataSource = qryDelivery;
                    this.lookDeliveryOptionID.DisplayMember = "DeliveryOptionName";
                    this.lookDeliveryOptionID.ValueMember = "DeliveryOptionID";

                    // customer // 

                    var qryglobalCust = (from c in context.Global_Customers
                                         select new { c.CustomerID, c.CustomerName }).ToList();
                    this.lookGlobalCustomerID.DataSource = qryglobalCust;
                    this.lookGlobalCustomerID.DisplayMember = "CustomerName";
                    this.lookGlobalCustomerID.ValueMember = "CustomerID";


                    this.gridView1.BestFitColumns();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                this.Validate();
                this.envelopeBindingSource.EndEdit();

              
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryselected = (from en in envelopeList
                                       where en.IsPrint == true
                                       select en).ToList();
                    if (qryselected.Count > 0)
                    {
                        if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }
                    }

                    foreach (var qry in qryselected)
                    {
                        var qryFound = (from env in context.Envelopes
                                        where env.EnvelopeID == qry.EnvelopeID
                                        select env).FirstOrDefault();
                        if (qryFound != null)
                        {
                            qryFound.CompanyID = qry.CompanyID;
                            qryFound.CompanyName = qry.CompanyName;
                            qryFound.CompanyAddress = qry.CompanyAddress;
                            qryFound.Adressee = qry.Adressee;                           
                            qryFound.DeliveryOptionID = qry.DeliveryOptionID;
                            qryFound.DeliveryOptionName = qry.DeliveryOptionName;
                            qryFound.ExtendedCustomerID = qry.ExtendedCustomerID;
                            qryFound.LocationID = qry.LocationID;
                            qryFound.LocationCode = qry.LocationCode;                            
                            qryFound.LevelID = qry.LevelID;
                            qryFound.LevelName = qry.LevelName;
                            qryFound.PostalAddress = qry.PostalAddress;
                            qryFound.ShopName = qry.ShopName;
                            qryFound.ShopNo = qry.ShopNo;
                            qryFound.IsPrint = qry.IsPrint;
                            qryFound.GlobalCustomerID = qry.GlobalCustomerID;
                            qryFound.CustomerCompanyName = qry.CustomerCompanyName;
                        }
                        else
                        {
                            // invoice entry 
                            Envelope envelopeObject = new Envelope();
                            envelopeObject.InvoiceTypeID = qry.InvoiceTypeID;
                            envelopeObject.CategoryName = qry.CategoryName;
                            envelopeObject.CompanyID = qry.CompanyID;
                            envelopeObject.CompanyName = qry.CompanyName;
                            envelopeObject.CompanyAddress = qry.CompanyAddress;
                            envelopeObject.Adressee = qry.Adressee;                          
                            envelopeObject.DeliveryOptionID = qry.DeliveryOptionID;
                            envelopeObject.DeliveryOptionName = qry.DeliveryOptionName;
                            envelopeObject.ExtendedCustomerID = qry.ExtendedCustomerID;
                            envelopeObject.LocationID = qry.LocationID;
                            envelopeObject.LocationCode = qry.LocationCode;
                            envelopeObject.LevelID = qry.LevelID;
                            envelopeObject.LevelName = qry.LevelName;
                            envelopeObject.PostalAddress = qry.PostalAddress;
                            envelopeObject.ShopName = qry.ShopName;
                            envelopeObject.ShopNo = qry.ShopNo;
                            envelopeObject.GlobalCustomerID = qry.GlobalCustomerID;
                            envelopeObject.CustomerCompanyName = qry.CustomerCompanyName;
                            envelopeObject.IsPrint = qry.IsPrint;
                            context.Envelopes.AddObject(envelopeObject);
                            //--

                            

                            //-

                        }
                        splashScreenManager1.SetWaitFormDescription(qry.ShopNo);

                    }


                    // saving objects to the database 
                    //if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                    splashScreenManager1.SetWaitFormDescription("Saving Data...");
                    int succ = context.SaveChanges();
                 

                    if (succ > 0)
                    {
                        if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                        MessageBox.Show("Record(s) Saved Successfully", "Save Success - Mail Address", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //load_data();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                chkSelectAll.Text = "Unselect All";
                foreach (var qry in envelopeList)
                {
                    qry.IsPrint = true;
                }
            }
            else
            {
                chkSelectAll.Text = "Select All";
                foreach (var qry in envelopeList)
                {
                    qry.IsPrint = false;
                }
            }

            this.envelopeGridControl.RefreshDataSource();
        }

        private void chkCompany_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(this.chkCompany.Text.ToString()))
            //{ return; }

            //string selected = this.chkCompany.Properties.GetCheckedItems().ToString();

            //string theString = selected;
            //List<int> intComps = theString.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));

            //var qrySelected = (from env in envelopeList
            //                  where intComps.Contains(env.CompanyID)
            //                  select env).ToList();
            //foreach (var qry in qrySelected)
            //{
            //    qry.IsPrint = true;
            //}
            //this.envelopeGridControl.RefreshDataSource();

            getSelected();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); }
                splashScreenManager1.SetWaitFormDescription("Generating Print...");
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    rptMain reportMain = new rptMain();
                    DataTier.Reports.Print.rptEnvelopes envelopes = new DataTier.Reports.Print.rptEnvelopes();
                    reportMain.crystalReportViewer1.ReportSource = envelopes;


                    
                    var qrySelected = (from en in envelopeList
                                       where en.IsPrint == true
                                       select en).ToList();
                    //var qryCheck = (from s in qrySelected
                    //                where s.EnvelopeID == 0
                    //                select s).ToList();
                    //if (qryCheck.Count > 0)
                    //{
                    //    MessageBox.Show("Save The Address List 1st", "Cannot Print", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                    // delivery option
                    var qryDelivery = (from d in context.DeliveryOptions
                                       select new { d.DeliveryOptionID, d.DeliveryOptionName }).ToList();

                    // floor level
                    var qryFloorLevel = (from l in context.Floor_Levels
                                         select new { l.LevelID, l.LevelName }).ToList();
                        

                    envelopes.Database.Tables["DataTier_Envelope"].SetDataSource(qrySelected);
                    envelopes.Database.Tables["DataTier_DeliveryOption"].SetDataSource(qryDelivery);
                    envelopes.Database.Tables["DataTier_Floor_Levels"].SetDataSource(qryFloorLevel);

                    reportMain.Show(this);
                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.envelopeBindingSource.EndEdit();
                var qrySelected = (from en in envelopeList
                                   where en.IsPrint == true
                                   select en).ToList();
                if (qrySelected.Count > 0)
                {

                    DialogResult dlg = MessageBox.Show("Do you want to delete selected item?", "Delete Confirmation - Envelopes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == System.Windows.Forms.DialogResult.No)
                    { return; }
                }

                if (splashScreenManager1.IsSplashFormVisible == false)
                { splashScreenManager1.ShowWaitForm(); }
                   
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    foreach (var qry in qrySelected)
                    {

                        var qryEnvelop = (from en in context.Envelopes
                                          where en.EnvelopeID == qry.EnvelopeID
                                          select en).FirstOrDefault();
                        context.Envelopes.DeleteObject(qryEnvelop);
                        splashScreenManager1.SetWaitFormDescription("Deleteing " + qry.ShopNo.ToString());
                    }

                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                        MessageBox.Show("Record(s) Deleted Successfully...", "Delete Success - Envelopes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }


                load_data();
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSelected();
        }

        private void getSelected()
        {
            if (string.IsNullOrEmpty(this.cboCategory.Text.ToString()))
            { return; }

            if (string.IsNullOrEmpty(this.chkCompany.Text.ToString()))
            { return; }

            string category = this.cboCategory.Text.ToString();
            int compid = int.Parse(this.chkCompany.EditValue.ToString());

            foreach (var qry in envelopeList)
            {
                if (qry.CompanyID == compid && qry.CategoryName == category)
                {

                    qry.IsPrint = true;
                }
                else
                {
                    qry.IsPrint = false;
                }

            }

            this.envelopeGridControl.RefreshDataSource();


        }
    }
}