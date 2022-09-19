﻿namespace MMS.Transaction.ContractBasket
{
    partial class xReleaseToAccounts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colIsPromotion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.cContract_BasketsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.globalCustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.cContract_BasketsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsProcessed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractClosureID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractClosureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colExtendedCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIsReleased = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookCompany = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookLocation = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIsReleasedToAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSelectAll = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_BasketsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_BasketsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // colIsPromotion
            // 
            this.colIsPromotion.FieldName = "IsPromotion";
            this.colIsPromotion.Name = "colIsPromotion";
            this.colIsPromotion.OptionsColumn.AllowEdit = false;
            this.colIsPromotion.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIsPromotion.OptionsColumn.ReadOnly = true;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNew,
            this.btnSave,
            this.btnClose,
            this.btnPrint,
            this.btnEdit,
            this.btnUndo,
            this.btnRefresh});
            this.barManager1.MaxItemId = 8;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(587, 151);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.Caption | DevExpress.XtraBars.BarLinkUserDefines.PaintStyle))), this.btnNew, "", false, true, false, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnEdit, false),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnUndo, false),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnPrint, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar1.Text = "Tools";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Glyph = global::MMS.Properties.Resources.note_new;
            this.btnNew.Id = 0;
            this.btnNew.Name = "btnNew";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Glyph = global::MMS.Properties.Resources.note_edit;
            this.btnEdit.Id = 5;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Glyph = global::MMS.Properties.Resources.undo;
            this.btnUndo.Id = 6;
            this.btnUndo.Name = "btnUndo";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Enabled = false;
            this.btnSave.Glyph = global::MMS.Properties.Resources.disk_blue;
            this.btnSave.Id = 1;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = global::MMS.Properties.Resources.refresh;
            this.btnRefresh.Id = 7;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Print";
            this.btnPrint.Glyph = global::MMS.Properties.Resources.printer;
            this.btnPrint.Id = 3;
            this.btnPrint.Name = "btnPrint";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Glyph = global::MMS.Properties.Resources.folder_into;
            this.btnClose.Id = 2;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(881, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 509);
            this.barDockControlBottom.Size = new System.Drawing.Size(881, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 468);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(881, 41);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 468);
            // 
            // cContract_BasketsBindingSource
            // 
            this.cContract_BasketsBindingSource.DataSource = typeof(MMS.cContract_Baskets);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // cContract_BasketsGridControl
            // 
            this.cContract_BasketsGridControl.DataSource = this.cContract_BasketsBindingSource;
            this.cContract_BasketsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cContract_BasketsGridControl.Location = new System.Drawing.Point(0, 41);
            this.cContract_BasketsGridControl.MainView = this.gridView1;
            this.cContract_BasketsGridControl.MenuManager = this.barManager1;
            this.cContract_BasketsGridControl.Name = "cContract_BasketsGridControl";
            this.cContract_BasketsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemLookUpEdit1,
            this.lookLocation,
            this.lookCompany});
            this.cContract_BasketsGridControl.Size = new System.Drawing.Size(881, 468);
            this.cContract_BasketsGridControl.TabIndex = 7;
            this.cContract_BasketsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsProcessed,
            this.colContractClosureID,
            this.colContractClosureName,
            this.colShopName,
            this.colPrint,
            this.colExtendedCustomerID,
            this.colIsReleased,
            this.colIsPromotion,
            this.colContractType,
            this.colCompanyID,
            this.colLocationID,
            this.colIsReleasedToAccount,
            this.colShopNo});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.PaleGoldenrod;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colIsPromotion;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "True";
            styleFormatCondition1.Value2 = "False";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.cContract_BasketsGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "List of Contracts To Be Released";
            // 
            // colIsProcessed
            // 
            this.colIsProcessed.Caption = "Processed";
            this.colIsProcessed.FieldName = "IsProcessed";
            this.colIsProcessed.Name = "colIsProcessed";
            this.colIsProcessed.OptionsColumn.AllowEdit = false;
            this.colIsProcessed.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIsProcessed.OptionsColumn.ReadOnly = true;
            this.colIsProcessed.Width = 65;
            // 
            // colContractClosureID
            // 
            this.colContractClosureID.FieldName = "ContractClosureID";
            this.colContractClosureID.Name = "colContractClosureID";
            this.colContractClosureID.OptionsColumn.AllowEdit = false;
            this.colContractClosureID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colContractClosureID.OptionsColumn.ReadOnly = true;
            // 
            // colContractClosureName
            // 
            this.colContractClosureName.Caption = "Contract Name";
            this.colContractClosureName.FieldName = "ContractClosureName";
            this.colContractClosureName.Name = "colContractClosureName";
            this.colContractClosureName.OptionsColumn.AllowEdit = false;
            this.colContractClosureName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colContractClosureName.OptionsColumn.ReadOnly = true;
            this.colContractClosureName.Visible = true;
            this.colContractClosureName.VisibleIndex = 3;
            this.colContractClosureName.Width = 204;
            // 
            // colShopName
            // 
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.OptionsColumn.AllowEdit = false;
            this.colShopName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colShopName.OptionsColumn.ReadOnly = true;
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 5;
            this.colShopName.Width = 140;
            // 
            // colPrint
            // 
            this.colPrint.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colPrint.FieldName = "Print";
            this.colPrint.Name = "colPrint";
            this.colPrint.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colPrint.Width = 38;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colExtendedCustomerID
            // 
            this.colExtendedCustomerID.Caption = "Customer Name";
            this.colExtendedCustomerID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colExtendedCustomerID.FieldName = "ExtendedCustomerID";
            this.colExtendedCustomerID.Name = "colExtendedCustomerID";
            this.colExtendedCustomerID.OptionsColumn.AllowEdit = false;
            this.colExtendedCustomerID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colExtendedCustomerID.OptionsColumn.ReadOnly = true;
            this.colExtendedCustomerID.Width = 257;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DisplayMember = "CustomerName";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "ExtendedCustomerID";
            // 
            // colIsReleased
            // 
            this.colIsReleased.Caption = "Released ";
            this.colIsReleased.FieldName = "IsReleased";
            this.colIsReleased.Name = "colIsReleased";
            this.colIsReleased.OptionsColumn.AllowEdit = false;
            this.colIsReleased.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIsReleased.OptionsColumn.ReadOnly = true;
            // 
            // colContractType
            // 
            this.colContractType.FieldName = "ContractType";
            this.colContractType.Name = "colContractType";
            this.colContractType.OptionsColumn.AllowEdit = false;
            this.colContractType.OptionsColumn.ReadOnly = true;
            this.colContractType.Width = 136;
            // 
            // colCompanyID
            // 
            this.colCompanyID.Caption = "Company";
            this.colCompanyID.ColumnEdit = this.lookCompany;
            this.colCompanyID.FieldName = "CompanyID";
            this.colCompanyID.Name = "colCompanyID";
            this.colCompanyID.Visible = true;
            this.colCompanyID.VisibleIndex = 1;
            // 
            // lookCompany
            // 
            this.lookCompany.AutoHeight = false;
            this.lookCompany.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompany.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.lookCompany.Name = "lookCompany";
            this.lookCompany.NullText = "";
            // 
            // colLocationID
            // 
            this.colLocationID.Caption = "Location";
            this.colLocationID.ColumnEdit = this.lookLocation;
            this.colLocationID.FieldName = "LocationID";
            this.colLocationID.Name = "colLocationID";
            this.colLocationID.Visible = true;
            this.colLocationID.VisibleIndex = 2;
            // 
            // lookLocation
            // 
            this.lookLocation.AutoHeight = false;
            this.lookLocation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocation.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.lookLocation.Name = "lookLocation";
            this.lookLocation.NullText = "";
            // 
            // colIsReleasedToAccount
            // 
            this.colIsReleasedToAccount.FieldName = "IsReleasedToAccount";
            this.colIsReleasedToAccount.Name = "colIsReleasedToAccount";
            this.colIsReleasedToAccount.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIsReleasedToAccount.Visible = true;
            this.colIsReleasedToAccount.VisibleIndex = 0;
            this.colIsReleasedToAccount.Width = 148;
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 4;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(0, 41);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 12;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.CheckedChanged += new System.EventHandler(this.btnSelectAll_CheckedChanged);
            // 
            // xReleaseToAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 509);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.cContract_BasketsGridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xReleaseToAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release to Accounts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.xReleaseToAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_BasketsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_BasketsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource cContract_BasketsBindingSource;
        private System.Windows.Forms.BindingSource globalCustomersBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraGrid.GridControl cContract_BasketsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsProcessed;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureID;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureName;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrint;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colExtendedCustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReleased;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPromotion;
        private DevExpress.XtraGrid.Columns.GridColumn colContractType;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookLocation;
        private DevExpress.XtraEditors.CheckButton btnSelectAll;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReleasedToAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
    }
}