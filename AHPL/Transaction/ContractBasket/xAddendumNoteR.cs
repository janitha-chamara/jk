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
using System.Data.Linq.SqlClient;
using DataTier;
using DataTier.Reports;
using System.Transactions;
namespace MMS
{
    public partial class xAddendumNoteR : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        bool bAddNew = false;
        bool bEdit = false;
        int CCId = 0;
        //List<
        public xAddendumNoteR()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.addendumBindingSource.CancelEdit();
            cEnable_Controls.enable_control(this, false);
            btnNew.Enabled = true;
            btnSave.Enabled = false;
        }

        private void xAddendumNoteR_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        private void Load_data()
        {
            //ravindra 17-05-2019
            //loading locaiton
            this.locationBindingSource.DataSource = (from l in context.Locations
                                                     select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();

            //this.contractClosureBindingSource.DataSource = (from c in context.ContractClosures
            //                                                where c.IsTerminated ==false
            //                                                select new { c.ContractClosureID, c.ContractClosureName }).ToList();

            this.addendumBindingSource.DataSource = (from a in context.Addendums
                                                     select a).ToList();


           


            ////cEnable_Controls.enable_control(this, false);
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                 addendumBindingSource.AddNew();
                ////addendumDateDateEdit.EditValue = DateTime.Now.Date;

                ////cEnable_Controls.enable_control(this, true);


                bAddNew = true;
                btnNew.Enabled = false;
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void contractClosureIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (bAddNew == false) { return; }

            if (string.IsNullOrEmpty(this.addendumDateDateEdit.Text.ToString()))
            { return; }

            if (string.IsNullOrEmpty(this.contractClosureIDLookUpEdit.Text.ToString()))
            {
                return;
            }

            bool res = false;
            int contid = 0;
            res = int.TryParse(this.contractClosureIDLookUpEdit.EditValue.ToString(), out contid);
            if (res == false)
            {
                return;
            }
            Addendum oAddendum = (Addendum)this.addendumBindingSource.Current;

            //getting old contract clause 
            var qryCC = (from c in context.ContractClosures
                         where c.ContractClosureID == contid
                         select new { c.ContractClosureID }).FirstOrDefault();
            if (qryCC != null)
            {
                oAddendum.ContractClosureID = qryCC.ContractClosureID;                

            }
            

            //getting old rent schemes 
            var qryRentSchm = (from r in context.Contract_RentSchemes
                               where r.ContractClosureID == contid
                               select r).ToList();
            if (oAddendum.AddendumID == 0)
            {
                oAddendum.Addendum_Details.Clear();
                
                foreach (var qry in qryRentSchm)
                {
                    Addendum_Details oAddDet = new Addendum_Details();
                    oAddDet.Contract_RentSchemeID = qry.Contract_RentSchemeID;
                    oAddDet.FromDateO = qry.FromDate;
                    oAddDet.ToDateO = qry.ToDate;
                    oAddDet.RentperSqFeetO = qry.RentPerSqFeet;
                    oAddDet.SCperSqFeetO = qry.SCPerSqFeet;
                    oAddendum.Addendum_Details.Add(oAddDet);
                }


            }
            #region by ravindra
            //load shopname   

            CCId = qryCC.ContractClosureID;
            if (CCId != 0)
            {
                var qryRentSch = (from r in context.ContractClosures
                                  where r.ContractClosureID == qryCC.ContractClosureID
                                  select r.ShopName).FirstOrDefault();
                addendumShopname.Text = qryRentSch;
            }
            #endregion
            //cRentScheme oRentScheme = cActiveRentScheme.getDefaultOrLastRateByDate(addendumDateDateEdit.DateTime, contid);
            //this.sCperSqFeetOTextEdit.EditValue = oRentScheme.SCperSqFeet;
            //this.rentperSqFeetOTextEdit.EditValue = oRentScheme.RentPerSqFeet;
            //this.fromDateODateEdit.EditValue = oRentScheme.FromDate;
            //this.toDateODateEdit.EditValue = oRentScheme.ToDate;

            this.addendumBindingSource.EndEdit();
            this.gridView2.BestFitColumns();
            this.gridView1.BestFitColumns();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                this.Validate();
                if (chkShopNameOnly.Checked == true)
                { addendumBindingSource.EndEdit(); }

                bool res = false;

                //validating date 
                if (string.IsNullOrEmpty(this.addendumDateDateEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.addendumDateDateEdit, "Invalid Date");
                    return;
                }

                //
                //validating contract name 
                if (string.IsNullOrEmpty(this.addendumNameTextEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.addendumNameTextEdit, "Invalid Addendum Name");
                    return;
                }
                else { dxErrorProvider1.SetError(this.addendumNameTextEdit, ""); }

                //--


                //validating contract id
                int contid = 0;
                res = int.TryParse(this.contractClosureIDLookUpEdit.EditValue.ToString(), out contid);
                if (res == false)
                {
                    dxErrorProvider1.SetError(this.contractClosureIDLookUpEdit, "Invalid Contract Name");
                    return;
                }
                else { dxErrorProvider1.SetError(this.contractClosureIDLookUpEdit, ""); }
                //--



                // validating remarks 
                if (string.IsNullOrEmpty(this.remarksMemoEdit.Text.ToString()))
                {
                    dxErrorProvider1.SetError(this.remarksMemoEdit, "Invalid Remarks");
                    return;
                }
                else { dxErrorProvider1.SetError(this.remarksMemoEdit, ""); }
                //
                using (TransactionScope trs = new TransactionScope())
                {
                    Addendum oAddendum = (Addendum)this.addendumBindingSource.Current;

                    if (oAddendum == null)
                    { return; }

                    if (oAddendum.AddendumID == 0)
                    {
                        // check for duplication
                        if (checkDuplicate(oAddendum.AddendumName) == true)
                        {
                            dxErrorProvider1.SetError(this.addendumNameTextEdit, "Addendum Name alredy Exist");
                            return;
                        }
                        else { dxErrorProvider1.SetError(this.addendumNameTextEdit, ""); }

                        List<Addendum_Details> addnmList = oAddendum.Addendum_Details.ToList();
                        if (chkShopNameOnly.Checked == true)//ravi start
                        {
                            foreach (var qry in addnmList)
                            {

                                var qryRentSch = (from r in context.Contract_RentSchemes
                                                  where r.Contract_RentSchemeID == qry.Contract_RentSchemeID
                                                  select r).FirstOrDefault();
                                if (qryRentSch != null)
                                {
                                    // updating Contract Rent Scheme
                                    qryRentSch.RentPerSqFeet = qry.RentperSqFeetN;
                                    qryRentSch.SCPerSqFeet = qry.SCperSqFeetN;
                                    qryRentSch.BaseRent = qry.RentperSqFeetN * qryRentSch.ContractClosure.FloorArea;

                                    
                                    //chek only update all 
                                    if (chkShopNameOnly.Checked == true) 
                                    {
                                        ////roshan..21092014
                                        context.Contract_RentSchemes.ApplyCurrentValues(qryRentSch);
                                    }
                                }
                            }

                        }//ravi end

                        // adding object
                        var qryAddDet = oAddendum.Addendum_Details.ToList();
                        foreach (var qry in qryAddDet)
                        {
                            qry.CreatedBy = CustomClasses.cCommon_Functions.LoggedUserID;
                            qry.CreatedDate = DateTime.Now;
                        }


                        oAddendum.CreatedBy = CustomClasses.cCommon_Functions.LoggedUserID;
                        oAddendum.CreatedDate = DateTime.Now;
                        context.Addendums.AddObject(oAddendum);
                    }

                    else
                    {
                        //editing object
                        oAddendum.LastUpdated = CustomClasses.cCommon_Functions.LoggedUserID;
                        oAddendum.LastUpdateDate = DateTime.Now;

                        var qryAddDet = oAddendum.Addendum_Details.ToList();
                        foreach (var qry in qryAddDet)
                        {
                            qry.UpdatedBy = CustomClasses.cCommon_Functions.LoggedUserID;
                            qry.UpdatedDate = DateTime.Now;
                        }

                        if (chkShopNameOnly.Checked == true)
                        { context.Addendums.ApplyCurrentValues(oAddendum); }

                    }

                    //added by ravindra update contractclouser shopname
                    if (!string.IsNullOrEmpty(addendumShopname.Text))
                    {
                        var author = context.ContractClosures.First(a => a.ContractClosureID == CCId);
                        author.ShopName = addendumShopname.Text.Trim();

                    }

                    //-

                    int succ = context.SaveChanges();
                    trs.Complete();

                    MessageBox.Show("Record Saved Successfully...", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cEnable_Controls.enable_control(this, false);

                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    bAddNew = false; bEdit = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private bool checkDuplicate(string pName)
        {
            bool duplicated = false;

            var qryDupp = (from a in context.Addendums
                           where a.AddendumName == pName
                           select new { a.AddendumName }).ToList();
            if (qryDupp.Count > 0)
            {
                duplicated = true;
            }


            return duplicated;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Addendum addObj = (Addendum)this.addendumBindingSource.Current;
                if (addObj == null)
                {
                    return;
                }

                if (splashScreenManager1.IsSplashFormVisible == false) { splashScreenManager1.ShowWaitForm(); splashScreenManager1.SetWaitFormDescription("Generating Print..."); }
                
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    rptMain _main = new rptMain();
                    DataTier.Reports.Contract.rptAddendumNote addendumNote = new DataTier.Reports.Contract.rptAddendumNote();
                    

                    var qryComp = (from c in context.Companies
                                   select new { c.CompanyID, c.CompanyName }).ToList();
                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationName }).ToList();
                    var qryLevel = (from l in context.Floor_Levels
                                    select new { l.LevelID, l.LevelName }).ToList();
                    var qryExC = (from exc in context.Extended_Customers
                                  select new { exc.ExtendedCustomerID, exc.CustomerID }).ToList();
                    var qryCust = (from c in context.Global_Customers
                                   select new { c.CustomerID, c.CustomerName }).ToList();
                    var qryCont = (from c in context.ContractClosures
                                   select new { c.ContractClosureID, c.ContractClosureName, c.ExtendedCustomerID, c.CompanyID, c.LocationID, c.LevelID, c.ShopName, c.ShopNo }).ToList();
                    var qryAdd = (from a in context.Addendums
                                  where a.AddendumID == addObj.AddendumID
                                  select new { a.AddendumID, a.AddendumName, a.ContractClosureID,a.Remarks }).ToList();
                    var qryAddDet = (from d in context.Addendum_Details
                                     where d.AddendumID == addObj.AddendumID
                                     select new { d.AddendumID, d.AddendumDetID, d.RentperSqFeetN, d.RentperSqFeetO, d.SCperSqFeetN, d.SCperSqFeetO,d.FromDateO,d.ToDateO }).ToList();
                   
                    addendumNote.Database.Tables["DataTier_Company"].SetDataSource(qryComp);
                    addendumNote.Database.Tables["DataTier_Location"].SetDataSource(qryLoc);
                    addendumNote.Database.Tables["DataTier_Floor_Levels"].SetDataSource(qryLevel);
                    addendumNote.Database.Tables["DataTier_Extended_Customers"].SetDataSource(qryExC);
                    addendumNote.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryCust);
                    addendumNote.Database.Tables["DataTier_ContractClosure"].SetDataSource(qryCont);
                    addendumNote.Database.Tables["DataTier_Addendum"].SetDataSource(qryAdd);
                    addendumNote.Database.Tables["DataTier_Addendum_Details"].SetDataSource(qryAddDet);

                    _main.crystalReportViewer1.ReportSource = addendumNote;
                    _main.Show(this);

                    if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }



                }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true) { splashScreenManager1.CloseWaitForm(); }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lookLocation_EditValueChanged(object sender, EventArgs e)
        {
            //load contract by locations
            int locaid = 0;
            bool res = int.TryParse(this.lookLocation.EditValue.ToString(), out locaid);
            if (res == false) { locaid = 0; }

            if (locaid > 0)
            {
                this.contractClosureBindingSource.DataSource = (from c in context.ContractClosures
                                                                where c.IsTerminated == false && c.LocationID == locaid
                                                                select new { c.ContractClosureID, c.ContractClosureName }).ToList();
                
            }

            
        }
    }
}