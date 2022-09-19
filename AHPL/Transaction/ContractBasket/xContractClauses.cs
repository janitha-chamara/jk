using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using DataTier;
using DataTier.Reports;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
//using DevExpress.XtraRichEdit.SpellChecker;
using DevExpress.XtraSpellChecker;
//using DevExpress.XtraSpellChecker.Native;
using DataTier.Reports.Contract;

namespace MMS
{
    public partial class xContractClauses : DevExpress.XtraEditors.XtraForm
    {
        List<cContractClosures> cCClosureList = new List<cContractClosures>();
        xImportContracts importC;

        AHPL_DBEntities context = new AHPL_DBEntities();
        bool bAddNew = false;
        bool bEdit = false;
        public bool IsFromAcc = false;
        private Transaction.ContractBasket.xSpellChecker spellcheck;

        public xContractClauses()
        {
            InitializeComponent();
        }

        private void xContractClosure_Load(object sender, EventArgs e)
        {
            try
            {
                //SpellCheckTextControllersManager.Default.RegisterClass(typeof(RichEditControl), typeof(RichEditSpellCheckController));
                //SpellCheckTextControllersManager.Default.RegisterClass(typeof(WinFormsRichEditViewRepository), typeof(RichEditSpellCheckController));
                //SpellCheckTextControllersManager.Default.RegisterClass(typeof(RichEditViewRepository), typeof(RichEditSpellCheckController));

                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void load_data()
        {
            //if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); 
            //    splashScreenManager2.SetWaitFormDescription("Connecting......"); }
            //bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
            //if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }

            if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); }
            //contract closure template
            this.conractClosureSubTemplatesBindingSource.DataSource = (from c in context.Conract_Closure_Sub_Templates
                                                                       join com in context.Companies on c.CompanyID equals com.CompanyID
                                                                       orderby com.CompanyCode ascending
                                                                       select new { c.ContractClosureTempID, c.TemplateName, c.PageNo, c.PageTitle, com.CompanyCode }).ToList();
            //closure items
            this.contractClosureItemsBindingSource.DataSource = (from c in context.Contract_Closure_Items
                                                                 orderby c.SortOrder ascending
                                                                 select new { c.ContractClosureItemID, c.ContractClosreItemName, c.SortOrder }).ToList();
            // contract closure
            this.contractClosureBindingSource.DataSource = (from c in context.ContractClosures
                                                            where c.IsPromotion == false && c.IsTerminated == false && c.IsActive==true
                                                            select c).ToList();


            // company
            this.companyBindingSource.DataSource = (from c in context.Companies
                                                    select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();

            // Location
            this.locationBindingSource.DataSource = (from l in context.Locations
                                                     select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
            // level 
            this.floorLevelsBindingSource.DataSource = (from l in context.Floor_Levels
                                                        select new { l.LevelID, l.LevelCode, l.LevelName }).ToList();

            // Content grid is visible=false when user clicks through Process Contract module
            if (IsFromAcc == true)
            {
                contractClosure_DetailsGridControl.Visible = false;
                richEditCustomerSign.Visible = false;
                //richEditCompanySign.Visible = false;


            }
            else
            {
                contractClosure_DetailsGridControl.Visible = true;
                richEditCustomerSign.Visible = true;
                //richEditCompanySign.Visible = true;
            }

            ////cEnable_Controls.enable_control(this, false);

            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = false;

            if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }

        }

        private void load_RelatedContract(int pContractClauseid)
        {
            if (pContractClauseid == 0)
            { return; }

            var qryRelatedCont = (from c in context.ContractClosures
                                  where c.RefNo == pContractClauseid
                                  select new { c.ContractClosureID, c.ContractClosureName }).ToList();
            this.gridRelatedContracts.DataSource = qryRelatedCont;

        }
        private void lookUpEditTempClosureID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (bAddNew == true)
                {
                    if (optSelection.SelectedIndex > 0)
                    { return; }


                    if (!string.IsNullOrEmpty(this.lookUpEditTempClosureID.Text.ToString()))
                    {
                        int closureTempid = 0;
                        bool res = false;
                        res = int.TryParse(lookUpEditTempClosureID.EditValue.ToString(), out closureTempid);
                        if (res == false) { closureTempid = 0; }
                        if (closureTempid > 0)
                        {
                            ContractClosure oContClosure = (ContractClosure)this.contractClosureBindingSource.Current;
                            load_templates(closureTempid);
                            if (oContClosure != null)
                            {
                                var qryContTemp = (from c in context.Conract_Closure_Sub_Templates
                                                   where c.ContractClosureTempID == closureTempid
                                                   select new { c.Signature1, c.TemplateName }).FirstOrDefault();
                                if (qryContTemp != null)
                                {
                                    //oContClosure.Signature1 = qryContTemp.Signature1;
                                    //this.lookUpEditTempClosureID.Text = qryContTemp.TemplateName;
                                }
                            }


                            var qryComp = (from c in context.Conract_Closure_Sub_Templates
                                           where c.ContractClosureTempID == closureTempid
                                           select new { c.CompanyID }).FirstOrDefault();
                            if (qryComp != null)
                            {
                                //ContractClosure oCClosure = (ContractClosure)this.contractClosureBindingSource.Current;
                                //oCClosure.CompanyID = qryComp.CompanyID.Value;
                                this.companyIDLookUpEdit.EditValue = qryComp.CompanyID;
                                this.contractClosureBindingSource.EndEdit();
                                if (qryComp.CompanyID > 0)
                                {
                                    //// Location..roshan..06oct2014
                                    this.locationBindingSource.DataSource = (from c in context.Companies
                                                                             join l in context.Locations on c.LocationID equals l.LocationID
                                                                             where c.CompanyID == qryComp.CompanyID
                                                                             select new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
                                }
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

        private void load_templates(int pContClosureTempID)
        {
            var qryClosureTemp = (from c in context.Conract_Closure_Sub_Templates
                                  join cd in context.ContractClosureTemplate_Details on c.ContractClosureTempID equals cd.ContractClosureTempID
                                  where c.ContractClosureTempID == pContClosureTempID
                                  select new { cd.ContractClosureTempDetailID, cd.ContractClosureItemID, cd.ContractClosureTempID, c.Signature1 }).ToList();
            ContractClosure oContClause = (ContractClosure)this.contractClosureBindingSource.Current;
            if (oContClause.ContractClosureID > 0)
            { return; }

            foreach (var qry in qryClosureTemp)
            {
                ContractClosure_Details oCDetail = new ContractClosure_Details();
                oCDetail.ContractClosureItemID = qry.ContractClosureItemID;
                oCDetail.IsSelected = true;
                oContClause.ContractClosure_Details.Add(oCDetail);

            }

            ////getting signature page from ContClauseTempID 
            //var qrySignPage = (from c in context.Conract_Closure_Sub_Templates
            //                   where c.ContractClosureTempID == pContClosureTempID
            //                   select new { c.Signature1 }).FirstOrDefault();
            //if (qrySignPage != null)
            //{
            //ContractClosure oContClause = (ContractClosure)this.contractClosureBindingSource.Current;
            //if (oContClause != null)
            //{
            //    oContClause.Signature1 = qrySignPage.Signature1;
            //}
            //oContClause.Signature1 = qrySignPage.Signature1;
            //this.richEditCompanySign.RtfText = qrySignPage.Signature1;
            //this.contractClosureBindingSource.EndEdit();
            //this.richEditCompanySign.Update();
            //this.richEditCompanySign.EndUpdate();
            //}

            //-


        }

        private bool findItem(int pContTempID, int pclosureid)
        {
            bool found = false;
            var qryfound = (from c in context.ContractClosure_Details
                            where c.ContractClosureID == pclosureid && c.ContractClosureItemID == pContTempID
                            select new { c.ContractClosureID }).ToList();
            if (qryfound.Count > 0)
            {
                found = true;
            }


            return found;
        }

        private bool getValueType(int pClosureItemID)
        {
            bool IsValueType = false;

            var qryValueType = (from c in context.Contract_Closure_Items
                                join m in context.ClosureMappingItems on c.ClosureMappingItemID equals m.ClosureMappingItemID
                                select new { m.IsValueType }).FirstOrDefault();
            if (qryValueType != null)
            {
                IsValueType = qryValueType.IsValueType;
            }


            return IsValueType;
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);


                cEnable_Controls.enable_control(this, true);
                this.contractClosureBindingSource.AddNew();
                bAddNew = true;
                bEdit = false;

                btnSave.Enabled = true;
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);


                this.Validate();

                this.contract_RentSchemesBindingSource.EndEdit();
                this.contractClosure_DetailsBindingSource.EndEdit();
                this.contractClosureBindingSource.EndEdit();

                ContractClosure contractObject = (ContractClosure)this.contractClosureBindingSource.Current;

                //validating contract closure name 
                if (string.IsNullOrEmpty(contractObject.ContractClosureName.ToString()))
                { dxErrorProvider1.SetError(this.textEditClosureName, "Invalid 3rd Schedule Name"); return; }
                else { dxErrorProvider1.SetError(this.textEditClosureName, ""); }
                //--

                //validating Contract Closure Template ID
                if (string.IsNullOrEmpty(contractObject.ContractClosureTempID.ToString()))
                { dxErrorProvider1.SetError(this.lookUpEditTempClosureID, "Invalid Template Name"); return; }
                else { dxErrorProvider1.SetError(this.lookUpEditTempClosureID, ""); }
                ///--

                using (TransactionScope trs = new TransactionScope())
                {

                    if (optSelection.SelectedIndex == 1)  // Renew 
                    {
                        contractObject.IsRenew = true;
                        contractObject.IsActive = false;
                    }
                    if (optSelection.SelectedIndex == 2) // Extention
                    {
                        contractObject.IsExtention = true;
                        contractObject.IsActive = true;
                    }

                    if (optSelection.SelectedIndex == 0)
                    {
                        contractObject.IsActive = true;
                        contractObject.IsNew = true;
                    }

                    // check duplication
                    if (contractObject.ContractClosureID == 0)
                    {

                        if (optSelection.SelectedIndex == 0 || optSelection.SelectedIndex == 2) // for New entity only the duplicate check is happening
                        {
                            var qryDuplcation = (from c in context.ContractClosures
                                                 where c.ContractClosureName == contractObject.ContractClosureName && c.ContractClosureTempID == contractObject.ContractClosureTempID && c.IsTerminated == false
                                                 select new { c.ContractClosureID }).ToList();
                            if (qryDuplcation.Count > 0)
                            { MessageBox.Show("Contract 3rd Schedule " + contractObject.ContractClosureName + " exist with the selected template, therefore you cannot create duplicate", "Dupplicate - 3rd Schedule", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        }
                        contractObject.CreatedBy = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                        contractObject.CreatedDate = DateTime.Now;
                        context.ContractClosures.AddObject(contractObject); // adding object to the context
                    }
                    else
                    {
                        contractObject.LastUpdated = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
                        contractObject.LastUpdateDate = DateTime.Now;
                        context.ContractClosures.ApplyOriginalValues(contractObject); // Or replacing current values 
                    }

                    // updating contract rent scheme's IncreasedRent/IncreasedSC

                    var qryRentSchemes = contractObject.Contract_RentSchemes.ToList();
                    decimal IncreasedRent = 0;
                    decimal IncreasedSC = 0;
                    decimal rent = 0;
                    decimal sc = 0;
                    decimal counter = 0;
                    foreach (var qry in qryRentSchemes)
                    {
                        if (counter > 0)
                        {
                            IncreasedRent = qry.RentPerSqFeet - rent;
                            IncreasedSC = qry.SCPerSqFeet - sc;
                            rent = qry.RentPerSqFeet;
                            sc = qry.SCPerSqFeet;
                            qry.IncreasedRent = IncreasedRent;
                            qry.IncreasedSC = IncreasedSC;
                        }

                        rent = qry.RentPerSqFeet;
                        sc = qry.SCPerSqFeet;
                        counter++;
                    }


                    // commiting changes to the database 
                    int succ = context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                    trs.Complete(); //completing transaciton after succeffull save 
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Saved Successfully...", "Save Success - 3rd Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                load_data();

                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                bAddNew = false;
                bEdit = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool searchItem(int pItemID, int pTempClosureID)
        {
            bool found = false;

            var qryFound = (from cd in context.ContractClosure_Details
                            where cd.ContractClosureItemID == pItemID && cd.ContractClosureID == pTempClosureID
                            select new { cd.ContractClosureItemID }).ToList();
            if (qryFound.Count > 0)
            {
                found = true;
            }



            return found;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                ContractClosure oClosure = (ContractClosure)this.contractClosureBindingSource.Current;

                if (oClosure != null)
                {
                    if (oClosure.IsProcessed == true)
                    {
                        MessageBox.Show("Contract is Already Processed", "Cannot Edit - Contract Closure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        cEnable_Controls.enable_control(this, true);
                        this.locationIDLookUpEdit.Properties.ReadOnly = true;
                        this.levelIDLookUpEdit.Properties.ReadOnly = true;
                        this.lookUpEditTempClosureID.Properties.ReadOnly = true;
                        btnSave.Enabled = true;
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = true;
                        bEdit = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.contractClosureBindingSource.CancelEdit();
            load_data();

            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            bAddNew = false;
            bEdit = false;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void contractClosureBindingSource_PositionChanged(object sender, EventArgs e)
        {
            ContractClosure oClosure = (ContractClosure)this.contractClosureBindingSource.Current;
            if (oClosure != null)
            {
                load_RelatedContract(oClosure.ContractClosureID);

                if (oClosure.IsProcessed == true)
                {
                    cEnable_Controls.enable_control(this, false);
                    this.optSelection.Enabled = false;
                }
                else
                {
                    cEnable_Controls.enable_control(this, true);
                    this.optSelection.Enabled = true;
                }

                //    if (oClosure.ContractClosureID > 0)
                //    {
                //        load_data(oClosure.ContractClosureID);
                //    }
                //    else
                //    {
                //        cCClosureList.Clear();
                //        this.cContractClosuresBindingSource.DataSource = cCClosureList;
                //        //this.cContractClosuresGridControl.RefreshDataSource();
                //    }
            }
        }

        private void load_data(int pContractClosureID)
        {
            cCClosureList.Clear();
            var qryDetail = (from cd in context.ContractClosure_Details
                             where cd.ContractClosureID == pContractClosureID
                             select cd).ToList();
            foreach (var qry in qryDetail)
            {
                cContractClosures oClosure = new cContractClosures();
                oClosure.ContractClosureID = qry.ContractClosureID;
                oClosure.ContractClosureDetailID = qry.ContractClosureDetailID;
                oClosure.ContractClosureItemID = qry.ContractClosureItemID;
                oClosure.ClosureMappingItemID = qry.ClosureMappingID;
                oClosure.Select = qry.IsSelected;
                oClosure.Contents = qry.Contents;
                oClosure.ContentValue = qry.ContentValue;
                cCClosureList.Add(oClosure);
            }

            this.cContractClosuresBindingSource.DataSource = cCClosureList;
            //this.cContractClosuresGridControl.RefreshDataSource();
        }

        private int getMappingID(int pContractClosureItemID)
        {
            int mappinid = 0;
            //var qryMapping = (from d in context.ContractClosure_Details
            //                  join m in context.ClosureMappingItems on d.ClosureMappingID equals m.ClosureMappingItemID 
            //                  where d.ContractClosureItemID == pContractClosureItemID 
            //                  select 
            var qryMapp = (from c in context.Contract_Closure_Items
                           where c.ContractClosureItemID == pContractClosureItemID
                           select new { c.ClosureMappingItemID }).FirstOrDefault();
            if (qryMapp != null)
            {
                mappinid = qryMapp.ClosureMappingItemID;
            }

            return mappinid;
        }

        private void locationIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.locationIDLookUpEdit.Text.ToString()))
            {
                return;
            }

            bool res = false; int locid = 0;
            res = int.TryParse(this.locationIDLookUpEdit.EditValue.ToString(), out locid);
            if (res == false) { locid = 0; }
            if (locid == 0) { return; }

            var qryLevel = (from l in context.Floor_Levels
                            where l.LocationID == locid
                            select new { l.LevelID, l.LevelCode, l.LevelName }).ToList();
            this.floorLevelsBindingSource.DataSource = qryLevel;

        }

        private void levelIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

            if (bAddNew == false)
            { return; }

            if (string.IsNullOrEmpty(companyIDLookUpEdit.Text.ToString()))
            {
                return;
            }

            if (string.IsNullOrEmpty(locationIDLookUpEdit.Text.ToString()))
            {
                return;
            }
            if (string.IsNullOrEmpty(this.levelIDLookUpEdit.Text.ToString()))
            {
                return;
            }

            bool res = false;

            int compid = 0;
            res = int.TryParse(this.companyIDLookUpEdit.EditValue.ToString(), out compid);
            if (res == false) { compid = 0; }
            if (compid == 0) { return; }

            int locid = 0;
            res = int.TryParse(this.locationIDLookUpEdit.EditValue.ToString(), out locid);
            if (res == false) { locid = 0; }
            if (locid == 0) { return; }

            int levelid = 0;
            res = int.TryParse(this.levelIDLookUpEdit.EditValue.ToString(), out levelid);
            if (res == false) { levelid = 0; }
            if (levelid == 0) { return; }

            //var qryShop = (from s in context.Shops
            //               join c in context.Companies on s.CompanyID equals c.CompanyID 
            //               join l in context.Locations on s.LocationID equals l.LocationID 
            //               join lvl in context.Floor_Levels on s.LevelID equals lvl.LevelID
            //               where s.CompanyID == compid && s.LocationID == locid && s.LevelID == levelid
            //               select new { s.ShopNo, s.ShopName, s.ShopID, s.SqFeet,c.CompanyCode,l.LocationCode,lvl.LevelName,s.CustomerID }).ToList();
            //this.shopBindingSource.DataSource = qryShop;
            //this.searchLookUpEditShop.Properties.DataSource = shopBindingSource;
            //this.searchLookUpEditShop.Properties.DisplayMember = "ShopNo";
            //this.searchLookUpEditShop.Properties.ValueMember = "ShopID";


        }

        private void companyIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //if (bAddNew == false)
            //{ return; }


            //if (string.IsNullOrEmpty(searchLookUpEditShop.Text.ToString()))
            //{
            //    return;
            //}

            //bool res = false;
            //int shopid = 0;
            //res = int.TryParse(this.searchLookUpEditShop.EditValue.ToString(), out shopid);
            //if (res == false) { shopid = 0; }
            //if (shopid == 0) { return; }

            //var qryShop = (from s in context.Shops
            //               where s.ShopID == shopid
            //               select new { s.SqFeet }).FirstOrDefault();
            //if (qryShop != null)
            //{
            //    //ContractClosure oCClosure = (ContractClosure)this.contractClosureBindingSource.Current;
            //    if (qryShop.SqFeet.HasValue)
            //    {
            //        floorAreaTextEdit.EditValue = qryShop.SqFeet.Value;
            //        this.contractClosureBindingSource.EndEdit();
            //        //oCClosure.FloorArea = qryShop.SqFeet.Value;
            //    }
            //}
        }

        private void rentPerSqFtTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (bAddNew == false)
            //{ return; }

            //double rentpersqft = 0;
            //bool res = false;

            //// rent per sq.feet
            //res = double.TryParse(this.rentPerSqFtTextEdit.EditValue.ToString(), out rentpersqft);
            //if (res == false) { rentpersqft = 0; }
            //if (rentpersqft <= 0) { rentpersqft =0; }

            //// floor area
            //double floorarea = 0;
            //res = double.TryParse(this.floorAreaTextEdit.EditValue.ToString(), out floorarea);
            //if (res == false) { floorarea = 0; }

            //double baserent = 0;
            //baserent = floorarea * rentpersqft;

            ////ContractClosure oCClosure = (ContractClosure)this.contractClosureBindingSource.Current;
            //this.rentTextEdit.EditValue = baserent;
            //this.contractClosureBindingSource.EndEdit();
            ////oCClosure.Rent = baserent;

            //// Rent per Square Foot of Mapping Item//
            //var qryMappingItem = (from c in cCClosureList
            //                      where c.ClosureMappingItemID == 9 
            //                      select c).FirstOrDefault();
            //if (rentpersqft == 0)
            //{
            //    qryMappingItem.Contents = string.Empty;
            //    qryMappingItem.ContentValue = 0;
            //    return;
            //}
            //if (qryMappingItem != null)
            //{
            //    rentpersqft = Math.Round(rentpersqft, 2);
            //    qryMappingItem.Contents = NumberToWordCurrency.NumWordsWrapper(rentpersqft);
            //    qryMappingItem.ContentValue = decimal.Parse(rentpersqft.ToString());
            //}
            ////

            //// Rent of Mapping Item//
            // qryMappingItem = (from c in cCClosureList
            //                      where c.ClosureMappingItemID == 8
            //                      select c).FirstOrDefault();
            // if (baserent == 0)
            //{
            //    qryMappingItem.Contents = string.Empty;
            //    qryMappingItem.ContentValue = 0;
            //    return;
            //}
            // if (qryMappingItem != null)
            // {
            //     baserent = Math.Round(baserent, 2);
            //     qryMappingItem.Contents = NumberToWordCurrency.NumWordsWrapper(baserent);
            //     qryMappingItem.ContentValue = decimal.Parse(baserent.ToString());
            // }
            ////


            //this.cContractClosuresGridControl.RefreshDataSource();


        }

        private void floorAreaTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (bAddNew == false)
            { return; }

            if (string.IsNullOrEmpty(this.floorAreaTextEdit.Text.ToString()))
            { return; }

            double floorarea = 0;
            bool res = double.TryParse(this.floorAreaTextEdit.EditValue.ToString(), out floorarea);
            if (res == false) { floorarea = 0; }


            var qryMappingItem = (from c in cCClosureList
                                  where c.ClosureMappingItemID == 5  // Floor Area of Mapping Item
                                  select c).FirstOrDefault();
            if (floorarea == 0)
            {
                if (qryMappingItem != null)
                {
                    qryMappingItem.Contents = "";
                    qryMappingItem.ContentValue = 0;
                    return;
                }
            }
            if (qryMappingItem != null)
            {
                qryMappingItem.Contents = NumberToWordSqFeet.NumWordsWrapper(floorarea);
                qryMappingItem.ContentValue = decimal.Parse(floorarea.ToString());
            }
            //this.cContractClosuresGridControl.RefreshDataSource();
        }

        private void serviceChargeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (bAddNew == false) { return; }
            //if (string.IsNullOrEmpty(this.serviceChargeTextEdit.Text.ToString()))
            //{ return; }

            //bool res = false;
            //decimal sc = 0;
            //res = decimal.TryParse(serviceChargeTextEdit.EditValue.ToString(), out sc);
            //if (res == false) { sc = 0; }

            //// Service Charge of Mapping Item
            //var qryMappingItem = (from c in cCClosureList
            //                      where c.ClosureMappingItemID == 11  
            //                      select c).FirstOrDefault();
            //if (sc == 0)
            //{
            //    qryMappingItem.Contents = string.Empty;
            //    qryMappingItem.ContentValue = sc;
            //    return;
            //}

            //if (qryMappingItem != null)
            //{
            //    qryMappingItem.Contents = NumberToWordCurrency.NumWordsWrapper(double.Parse(sc.ToString()));
            //    qryMappingItem.ContentValue = sc;
            //}
            //this.cContractClosuresGridControl.RefreshDataSource();
        }

        private void depositTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (bAddNew == false) { return; }
            //if (string.IsNullOrEmpty(this.depositTextEdit.Text.ToString()))
            //{ return; }

            //bool res = false;
            //decimal deposit = 0;
            //res = decimal.TryParse(depositTextEdit.EditValue.ToString(), out deposit);
            //if (res == false) { deposit = 0; }

            //// Deposit of Mapping Item
            //var qryMappingItem = (from c in cCClosureList
            //                      where c.ClosureMappingItemID == 12
            //                      select c).FirstOrDefault();
            //if (deposit == 0)
            //{
            //    qryMappingItem.Contents = string.Empty;
            //    qryMappingItem.ContentValue = deposit;
            //    return;
            //}
            //if (qryMappingItem != null)
            //{
            //    qryMappingItem.Contents = NumberToWordCurrency.NumWordsWrapper(double.Parse(deposit.ToString()));
            //    qryMappingItem.ContentValue = deposit;
            //}
            //this.cContractClosuresGridControl.RefreshDataSource();
        }

        private void rentTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void agreementNoLabel_Click(object sender, EventArgs e)
        {

        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (e.Column == colToDate)
            {
                DateTime fromdate;
                DateTime todate;

                bool res = false;
                //Validating To date
                if (e.Value == null)
                {
                    gridView3.SetColumnError(colToDate, "Invalid To Date"); return;
                }
                else { gridView3.SetColumnError(colToDate, ""); }

                res = DateTime.TryParse(e.Value.ToString(), out todate);
                if (res == false) { gridView3.SetColumnError(colToDate, "Invalid To Date"); return; }
                else { gridView3.SetColumnError(colToDate, ""); }
                //-- 

                //validating from date
                if (this.gridView3.GetRowCellValue(e.RowHandle, colFromDate) == null)
                {
                    gridView3.SetColumnError(colFromDate, "Invalid From Date");
                    return;
                }
                else { gridView3.SetColumnError(colFromDate, ""); }

                res = DateTime.TryParse(gridView3.GetRowCellValue(e.RowHandle, colFromDate).ToString(), out fromdate);
                if (res == false) { gridView3.SetColumnError(colFromDate, "Invalid From Date"); return; }
                else { gridView3.SetColumnError(colFromDate, ""); }
                //-- 

                int idays = todate.Subtract(fromdate).Days;
                if (idays < 0)
                {
                    this.gridView3.SetColumnError(colToDate, "From Date cannot be greater than To Date");
                    return;
                }
                else { this.gridView3.SetColumnError(colToDate, ""); }

                ////Initial developer implemented logic..comment by roshan...11August2014
                ////double dmonth = (idays / (365.25 / 12));    

                ////dmonth = Math.Ceiling(dmonth);
                ////dmonth = Math.Floor(dmonth);//roshan..

                ////if (dmonth <= 6)
                ////{
                ////    dmonth = 6;
                ////}
                ////else 
                ////{
                ////    dmonth = 12;
                ////}

                ////End..11August2014..

                ////11Audust2014..by roshan
                todate = todate.AddDays(1);////to avoid end date issue..eg:{ (2014-05-01 - 2015-04-30) = (2015-2014)*12+ (04-05)= 11 months => this should be 12}

                double dmonth = ((todate.Year - fromdate.Year) * 12) + todate.Month - fromdate.Month;
                this.gridView3.SetRowCellValue(e.RowHandle, colPeriod, dmonth);

                ////End..11August2014..

                ////fromdate = gridView3.GetRowCellValue(e.RowHandle, colFromDate);

            }

            if (e.Column == colRentPerSqFeet)
            {
                decimal rentpersqft = 0;
                bool res = false;
                res = decimal.TryParse(e.Value.ToString(), out rentpersqft);
                if (res == false)
                {
                    gridView3.SetColumnError(colRentPerSqFeet, "Invalid Value");
                    return;
                }
                else { gridView3.SetColumnError(colRentPerSqFeet, ""); }

                decimal floorarea = 0;
                res = decimal.TryParse(floorAreaTextEdit.EditValue.ToString(), out floorarea);
                if (res == false)
                {
                    dxErrorProvider1.SetError(floorAreaTextEdit, "Invalid Floor Area");
                    return;
                }
                else { dxErrorProvider1.SetError(floorAreaTextEdit, ""); }

                decimal baserent = rentpersqft * floorarea;
                this.gridView3.SetRowCellValue(e.RowHandle, colBaseRent, baserent);
                //this.gridView3.ClearColumnErrors();
            }

            if (e.Column == colSCPerSqFeet)
            {
                decimal SCperSqft = 0;
                bool res = false;

                res = decimal.TryParse(e.Value.ToString(), out SCperSqft);
                if (res == false)
                {
                    gridView3.SetColumnError(colSCPerSqFeet, "Invalid Service Charge");
                    return;
                }

            }

        }

        private void textEditClosureName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ContractClosure oClosure = (ContractClosure)this.contractClosureBindingSource.Current;
                if (oClosure == null)
                {
                    return;
                }
                if (splashScreenManager2.IsSplashFormVisible == false)
                {
                    splashScreenManager2.ShowWaitForm();
                    splashScreenManager2.SetWaitFormDescription("Generating Print");
                }


                int contclosureid = 0;
                contclosureid = oClosure.ContractClosureID;

                var qryCClosure = (from c in context.ContractClosures
                                   where c.ContractClosureID == contclosureid
                                   select new { c.ContractClosureID, c.ContractClosureTempID, c.ContractClosureName, c.Signature1, c.Signature2 }).ToList();
                var qryCClosreDet = (from c in context.ContractClosure_Details
                                     where c.ContractClosureID == contclosureid && c.IsSelected == true
                                     select new { c.ClosureMappingID, c.Contents, c.ContentValue, c.ContractClosureDetailID, c.ContractClosureID, c.ContractClosureItemID, c.IsSelected, c.PrintNumber }).ToList();
                var qryCItems = (from i in context.Contract_Closure_Items
                                 select new { i.ClosureMappingItemID, i.ContractClosreItemName, i.ContractClosureItemID, i.IsMapped, i.SortOrder }).ToList();

                var qryCSubTempl = (from s in context.Conract_Closure_Sub_Templates
                                    select new { s.CompanyID, s.ContractClosureTempID, s.PageNo, s.PageTitle, s.Signature1, s.Signature2, s.TemplateName }).ToList();

                rptMain _main = new rptMain();
                rptContractClosure rptContClosure = new rptContractClosure();
                _main.crystalReportViewer1.ReportSource = rptContClosure;

                rptContClosure.Database.Tables["DataTier_ContractClosure"].SetDataSource(qryCClosure);
                rptContClosure.Database.Tables["DataTier_ContractClosure_Details"].SetDataSource(qryCClosreDet);
                rptContClosure.Database.Tables["DataTier_Contract_Closure_Items"].SetDataSource(qryCItems);
                rptContClosure.Database.Tables["DataTier_Conract_Closure_Sub_Templates"].SetDataSource(qryCSubTempl);

                _main.Show(this);

                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsDelete(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);


                this.contractClosureBindingSource.EndEdit();

                ContractClosure oContClosure = (ContractClosure)this.contractClosureBindingSource.Current;
                if (oContClosure != null)
                {
                    if (oContClosure.ContractClosureID == 0) { return; }

                    var qryFound = (from c in context.ContractClosures
                                    where c.ContractClosureID == oContClosure.ContractClosureID
                                    select new { c.ContractClosureID, c.IsProcessed }).FirstOrDefault();
                    if (qryFound != null)
                    {
                        if (qryFound.IsProcessed == true)
                        {
                            MessageBox.Show("Contract is already processed for " + oContClosure.ContractClosureName + ", processed Contract cannot be deleted", "Cannot Delete - Contract Clause", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }

                    DialogResult dlg = MessageBox.Show("Do you want to delete current Contract Clause '" + oContClosure.ContractClosureName + "' ?", "Delete Confirmation - Contract Clause", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {

                        List<ContractClosure_Details> contdet = oContClosure.ContractClosure_Details.ToList();
                        foreach (var qry in contdet)
                        {
                            context.ContractClosure_Details.DeleteObject(qry);
                        }
                        List<Contract_RentSchemes> contrentsch = oContClosure.Contract_RentSchemes.ToList();
                        foreach (var qry in contrentsch)
                        {
                            context.Contract_RentSchemes.DeleteObject(qry);
                        }

                        context.ContractClosures.DeleteObject(oContClosure);
                        int succ = context.SaveChanges();
                        if (succ > 0)
                        {
                            MessageBox.Show("Contract Clause " + oContClosure.ContractClosureName + " deleted", "Contract Clause Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load_data();
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
            //    if (chkEnableSpellChecker.Checked == false)
            //    { return; }

            //    if (e.Column == colContents1)
            //    {
            //        DevExpress.XtraRichEdit.RichEditControl econtrol = new RichEditControl();
            //        econtrol.RtfText = e.Value.ToString();

            //        //DevExpress.XtraSpellChecker.Native.SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(DevExpress.XtraEditors.SmartTextEdit), GetType(DevExpress.XtraSpellChecker.Native.TextEditTextBoxFinder))
            //        spellChecker1.Check(econtrol);
            //        //string val = this.repositoryItemRichTextEdit1.ConvertEditValueToPlainText(e.Value);
            //        ////this.repositoryItemRichTextEdit1.Appearance.Font = Font.SystemFontName
            //        //spellChecker1.CheckText(val);

            //        //XtraSpellChekcer

            //        //DevExpress.XtraSpellChecker.SpellChecker dd = new SpellChecker();
            //        //dd.Check(this.repositoryItemRichTextEdit1);

            //    }
            //}

            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void textEditClosureName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {


            if (optSelection.SelectedIndex == 1 || optSelection.SelectedIndex == 2)
            {
                importC = new xImportContracts();
                importC.FormClosing += new FormClosingEventHandler(importC_FormClosing);

                importC.Show(this);
            }

            //if (optSelection.SelectedIndex == 2)
            //{

            //}
        }

        private void importC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (importC.import == true)
            {
                //if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Connecting......"); }
                //bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
                //if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }

                int ccid = importC.contractClauseID;
                var qryCC = (from c in context.ContractClosures
                             where c.ContractClosureID == ccid
                             select c).FirstOrDefault();
                if (qryCC != null)
                {
                    ContractClosure oContClauseNew = (ContractClosure)this.contractClosureBindingSource.AddNew();
                    oContClauseNew.ContractClosureName = qryCC.ContractClosureName;
                    oContClauseNew.ContractClosureTempID = qryCC.ContractClosureTempID;
                    oContClauseNew.ContractPeriod = qryCC.ContractPeriod;
                    oContClauseNew.CustomerAddress = qryCC.CustomerAddress;
                    oContClauseNew.CustomerName = qryCC.CustomerName;
                    oContClauseNew.Deposit = qryCC.Deposit;
                    oContClauseNew.ExtendedCustomerID = qryCC.ExtendedCustomerID;
                    oContClauseNew.FloorArea = qryCC.FloorArea;
                    oContClauseNew.GlobalCustomerID = qryCC.GlobalCustomerID;
                    oContClauseNew.LevelID = qryCC.LevelID;
                    oContClauseNew.LocationID = qryCC.LocationID;
                    oContClauseNew.PoRentTypeID = qryCC.PoRentTypeID;
                    oContClauseNew.ShopID = qryCC.ShopID;
                    oContClauseNew.ShopName = qryCC.ShopName;
                    oContClauseNew.ShopNo = qryCC.ShopNo;
                    oContClauseNew.Signature1 = qryCC.Signature1;
                    oContClauseNew.Signature2 = qryCC.Signature2;
                    oContClauseNew.CompanyID = qryCC.CompanyID;
                    oContClauseNew.RefNo = qryCC.ContractClosureID;

                    List<Contract_RentSchemes> rentScList = qryCC.Contract_RentSchemes.ToList();
                    foreach (var qry in rentScList)
                    {
                        Contract_RentSchemes oRentScheme = new Contract_RentSchemes();
                        oRentScheme.BaseRent = qry.BaseRent;
                        oRentScheme.ContractClosureID = qry.ContractClosureID;
                        oRentScheme.FromDate = qry.FromDate;
                        oRentScheme.Period = qry.Period;
                        oRentScheme.RentPerSqFeet = qry.RentPerSqFeet;
                        oRentScheme.SCPerSqFeet = qry.SCPerSqFeet;
                        oRentScheme.ToDate = qry.ToDate;
                        //Contract_RentSchemes oContRSC = 
                        oContClauseNew.Contract_RentSchemes.Add(oRentScheme);
                    }

                    List<ContractClosure_Details> contDetList = qryCC.ContractClosure_Details.ToList();
                    foreach (var qry in contDetList)
                    {
                        ContractClosure_Details oContClauseDet = new ContractClosure_Details();
                        oContClauseDet.ClosureMappingID = qry.ClosureMappingID;
                        oContClauseDet.Contents = qry.Contents;
                        oContClauseDet.ContractClosureID = qry.ContractClosureID;
                        oContClauseDet.ContractClosureItemID = qry.ContractClosureItemID;
                        oContClauseDet.IsSelected = qry.IsSelected;
                        oContClauseDet.PrintNumber = qry.PrintNumber;

                        oContClauseNew.ContractClosure_Details.Add(oContClauseDet);
                    }


                    this.contract_RentSchemesGridControl.RefreshDataSource();
                    this.contractClosure_DetailsGridControl.RefreshDataSource();

                }

            }

        }

        private void repositoryItemHyperLinkEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow focusrow = gridView1.GetFocusedDataRow();
            if (focusrow != null)
            {


            }

        }

        private void btnPrintSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    int contractid = 0;
                    ContractClosure contObj = (ContractClosure)this.contractClosureBindingSource.Current;
                    if (contObj == null) { return; }

                    if (splashScreenManager2.IsSplashFormVisible == false)
                    {
                        splashScreenManager2.ShowWaitForm();
                        splashScreenManager2.SetWaitFormDescription("Generating Print");
                    }



                    contractid = contObj.ContractClosureID;

                    var qryContract = (from c in context.ContractClosures
                                       where c.ContractClosureID == contractid
                                       select new { c.ContractClosureID, c.ContractClosureName, c.CompanyID, c.LocationID, c.LevelID, c.ExtendedCustomerID, c.ShopName, c.ShopNo, c.FloorArea, c.Deposit, c.AgreementNo, c.ContractPeriod }).ToList();
                    var qryRentSceme = (from cr in context.Contract_RentSchemes
                                        where cr.ContractClosureID == contractid
                                        select new { cr.FromDate, cr.ToDate, cr.RentPerSqFeet, cr.SCPerSqFeet, cr.BaseRent, cr.Period }).ToList();

                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode }).ToList();
                    var qryCom = (from c in context.Companies
                                  select new { c.CompanyID, c.CompanyCode }).ToList();

                    var qryLevel = (from l in context.Floor_Levels
                                    select new { l.LevelID, l.LevelCode, l.LevelName }).ToList();

                    var qryExc = (from ec in context.Extended_Customers
                                  select new { ec.ExtendedCustomerID, ec.CustomerID }).ToList();

                    var qryGc = (from gc in context.Global_Customers
                                 select new { gc.CustomerID, gc.CustomerName }).ToList();


                    rptMain _main = new rptMain();

                    rptContractSummary rptContractSummary = new rptContractSummary();
                    _main.crystalReportViewer1.ReportSource = rptContractSummary;

                    rptContractSummary.Database.Tables["DataTier_ContractClosure"].SetDataSource(qryContract);
                    rptContractSummary.Database.Tables["DataTier_Contract_RentSchemes"].SetDataSource(qryRentSceme);
                    rptContractSummary.Database.Tables["DataTier_Location"].SetDataSource(qryLoc);
                    rptContractSummary.Database.Tables["DataTier_Company"].SetDataSource(qryCom);
                    rptContractSummary.Database.Tables["DataTier_Floor_Levels"].SetDataSource(qryLevel);
                    rptContractSummary.Database.Tables["DataTier_Extended_Customers"].SetDataSource(qryExc);
                    rptContractSummary.Database.Tables["DataTier_Global_Customers"].SetDataSource(qryGc);

                    _main.Show(this);

                    if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }


                }


            }

            catch (Exception ex)
            {
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            spellChecker1.Check(shopNameTextEdit);

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ContractClosure_Details contdet = (ContractClosure_Details)this.contractClosure_DetailsBindingSource.Current;

            if (contdet != null)
            {
                var qryFocus = contdet.Contents;
                spellcheck = new Transaction.ContractBasket.xSpellChecker();
                spellcheck.FormClosing += new FormClosingEventHandler(spellcheck_FormClosing);
                spellcheck.TextToCheck = qryFocus;
                spellcheck.ShowDialog(this);



            }
            //var qryFocus = this.gridView4.GetFocusedDataRow();
            //string qry = qryFocus["Contents"].ToString();

        }

        private void spellcheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (spellcheck.SpellChecked == true)
            {
                ContractClosure_Details contdet = (ContractClosure_Details)this.contractClosure_DetailsBindingSource.Current;
                contdet.Contents = spellcheck.CorrectedText;
            }
        }

    }
}