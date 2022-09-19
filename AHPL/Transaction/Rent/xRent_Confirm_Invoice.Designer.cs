namespace MMS
{
    partial class xRent_Confirm_Invoice
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.bsRecentRentList = new System.Windows.Forms.BindingSource(this.components);
            this.subInvoiceTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.globalCustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnGenInv = new DevExpress.XtraEditors.SimpleButton();
            this.bsUnConfirmedInvList = new System.Windows.Forms.BindingSource(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpInvoiceType = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSelectAllDelete = new DevExpress.XtraEditors.CheckButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.CheckButton();
            this.cGen_Rent_InvoiceGridControl = new DevExpress.XtraGrid.GridControl();
            this.cGen_Rent_InvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalRent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubInvTypeID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRecentRentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subInvoiceTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnConfirmedInvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpInvoiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // bsRecentRentList
            // 
            this.bsRecentRentList.DataSource = typeof(MMS.cGen_Rent_Invoice);
            // 
            // subInvoiceTypesBindingSource
            // 
            this.subInvoiceTypesBindingSource.DataSource = typeof(DataTier.Sub_Invoice_Types);
            // 
            // globalCustomersBindingSource
            // 
            this.globalCustomersBindingSource.DataSource = typeof(DataTier.Global_Customers);
            // 
            // lookLocation
            // 
            this.lookLocation.Location = new System.Drawing.Point(86, 47);
            this.lookLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookLocation.Name = "lookLocation";
            this.lookLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.lookLocation.Properties.NullText = "";
            this.lookLocation.Size = new System.Drawing.Size(199, 22);
            this.lookLocation.TabIndex = 6;
            this.lookLocation.EditValueChanged += new System.EventHandler(this.lookLocation_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 52);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 16);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Location :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 18);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Company :";
            // 
            // lookCompany
            // 
            this.lookCompany.Location = new System.Drawing.Point(86, 15);
            this.lookCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookCompany.Name = "lookCompany";
            this.lookCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.lookCompany.Properties.NullText = "";
            this.lookCompany.Size = new System.Drawing.Size(199, 22);
            this.lookCompany.TabIndex = 3;
            this.lookCompany.EditValueChanged += new System.EventHandler(this.lookCompany_EditValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::MMS.Properties.Resources.disk_blue1;
            this.btnSave.Location = new System.Drawing.Point(1092, 64);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(205, 44);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Generated Invoice No(s)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into;
            this.btnClose.Location = new System.Drawing.Point(1399, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 97);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGenInv
            // 
            this.btnGenInv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenInv.Image = global::MMS.Properties.Resources.document_check;
            this.btnGenInv.Location = new System.Drawing.Point(1092, 16);
            this.btnGenInv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenInv.Name = "btnGenInv";
            this.btnGenInv.Size = new System.Drawing.Size(205, 41);
            this.btnGenInv.TabIndex = 0;
            this.btnGenInv.Text = "Generate Invoice No(s)";
            this.btnGenInv.Click += new System.EventHandler(this.btnGenInv_Click);
            // 
            // bsUnConfirmedInvList
            // 
            this.bsUnConfirmedInvList.DataSource = typeof(MMS.cGen_Rent_Invoice);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.lookUpInvoiceType);
            this.panelControl1.Controls.Add(this.btnSelectAllDelete);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.lookLocation);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnGenInv);
            this.panelControl1.Controls.Add(this.btnSelectAll);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.cGen_Rent_InvoiceGridControl);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lookCompany);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1498, 772);
            this.panelControl1.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(377, 18);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(107, 16);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "Sub Invoice Type :";
            // 
            // lookUpInvoiceType
            // 
            this.lookUpInvoiceType.Location = new System.Drawing.Point(499, 15);
            this.lookUpInvoiceType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpInvoiceType.Name = "lookUpInvoiceType";
            this.lookUpInvoiceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpInvoiceType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeName", "SubInvTypeName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeID", "SubInvTypeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lookUpInvoiceType.Properties.NullText = "";
            this.lookUpInvoiceType.Size = new System.Drawing.Size(199, 22);
            this.lookUpInvoiceType.TabIndex = 14;
            this.lookUpInvoiceType.EditValueChanged += new System.EventHandler(this.lookUpInvoiceType_EditValueChanged);
            // 
            // btnSelectAllDelete
            // 
            this.btnSelectAllDelete.Location = new System.Drawing.Point(112, 140);
            this.btnSelectAllDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectAllDelete.Name = "btnSelectAllDelete";
            this.btnSelectAllDelete.Size = new System.Drawing.Size(142, 28);
            this.btnSelectAllDelete.TabIndex = 13;
            this.btnSelectAllDelete.Text = "Select All For Delete";
            this.btnSelectAllDelete.CheckedChanged += new System.EventHandler(this.btnSelectAllDelete_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::MMS.Properties.Resources.delete22;
            this.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(1304, 11);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 97);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete\r\nSelected\r\nInvoice(s)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(17, 140);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(87, 28);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.CheckedChanged += new System.EventHandler(this.btnSelectAll_CheckedChanged);
            // 
            // cGen_Rent_InvoiceGridControl
            // 
            this.cGen_Rent_InvoiceGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cGen_Rent_InvoiceGridControl.DataSource = this.cGen_Rent_InvoiceBindingSource;
            this.cGen_Rent_InvoiceGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cGen_Rent_InvoiceGridControl.Location = new System.Drawing.Point(2, 140);
            this.cGen_Rent_InvoiceGridControl.MainView = this.gridView1;
            this.cGen_Rent_InvoiceGridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cGen_Rent_InvoiceGridControl.Name = "cGen_Rent_InvoiceGridControl";
            this.cGen_Rent_InvoiceGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit4});
            this.cGen_Rent_InvoiceGridControl.Size = new System.Drawing.Size(1490, 625);
            this.cGen_Rent_InvoiceGridControl.TabIndex = 0;
            this.cGen_Rent_InvoiceGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cGen_Rent_InvoiceBindingSource
            // 
            this.cGen_Rent_InvoiceBindingSource.DataSource = typeof(MMS.cGen_Rent_Invoice);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCompanyID,
            this.colCompanyCode,
            this.colLocationID,
            this.colLocationCode,
            this.colLevelID,
            this.colLevelCode,
            this.colShopID,
            this.colShopNo,
            this.colShopName,
            this.colTotalRent,
            this.colConfirm,
            this.colInvDate,
            this.colInvoiceID,
            this.colInvoiceNo,
            this.colSubInvTypeID1,
            this.colCustomerID,
            this.colDelete});
            this.gridView1.GridControl = this.cGen_Rent_InvoiceGridControl;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSubInvTypeID1, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ViewCaption = "List of Invoices to be confirmed";
            // 
            // colCompanyID
            // 
            this.colCompanyID.FieldName = "CompanyID";
            this.colCompanyID.Name = "colCompanyID";
            this.colCompanyID.OptionsColumn.AllowEdit = false;
            this.colCompanyID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCompanyID.OptionsColumn.ReadOnly = true;
            // 
            // colCompanyCode
            // 
            this.colCompanyCode.Caption = "Company";
            this.colCompanyCode.FieldName = "CompanyCode";
            this.colCompanyCode.Name = "colCompanyCode";
            this.colCompanyCode.OptionsColumn.AllowEdit = false;
            this.colCompanyCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colCompanyCode.OptionsColumn.ReadOnly = true;
            this.colCompanyCode.Visible = true;
            this.colCompanyCode.VisibleIndex = 2;
            this.colCompanyCode.Width = 101;
            // 
            // colLocationID
            // 
            this.colLocationID.FieldName = "LocationID";
            this.colLocationID.Name = "colLocationID";
            this.colLocationID.OptionsColumn.AllowEdit = false;
            this.colLocationID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colLocationID.OptionsColumn.ReadOnly = true;
            // 
            // colLocationCode
            // 
            this.colLocationCode.Caption = "Location";
            this.colLocationCode.FieldName = "LocationCode";
            this.colLocationCode.Name = "colLocationCode";
            this.colLocationCode.OptionsColumn.AllowEdit = false;
            this.colLocationCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colLocationCode.OptionsColumn.ReadOnly = true;
            this.colLocationCode.Visible = true;
            this.colLocationCode.VisibleIndex = 3;
            this.colLocationCode.Width = 92;
            // 
            // colLevelID
            // 
            this.colLevelID.FieldName = "LevelID";
            this.colLevelID.Name = "colLevelID";
            this.colLevelID.OptionsColumn.AllowEdit = false;
            this.colLevelID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colLevelID.OptionsColumn.ReadOnly = true;
            // 
            // colLevelCode
            // 
            this.colLevelCode.FieldName = "LevelCode";
            this.colLevelCode.Name = "colLevelCode";
            this.colLevelCode.OptionsColumn.AllowEdit = false;
            this.colLevelCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colLevelCode.OptionsColumn.ReadOnly = true;
            this.colLevelCode.Width = 102;
            // 
            // colShopID
            // 
            this.colShopID.FieldName = "ShopID";
            this.colShopID.Name = "colShopID";
            this.colShopID.OptionsColumn.AllowEdit = false;
            this.colShopID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colShopID.OptionsColumn.ReadOnly = true;
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.OptionsColumn.AllowEdit = false;
            this.colShopNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colShopNo.OptionsColumn.ReadOnly = true;
            this.colShopNo.Width = 89;
            // 
            // colShopName
            // 
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.OptionsColumn.AllowEdit = false;
            this.colShopName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colShopName.OptionsColumn.ReadOnly = true;
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 4;
            this.colShopName.Width = 109;
            // 
            // colTotalRent
            // 
            this.colTotalRent.DisplayFormat.FormatString = "n4";
            this.colTotalRent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalRent.FieldName = "TotalRent";
            this.colTotalRent.Name = "colTotalRent";
            this.colTotalRent.OptionsColumn.AllowEdit = false;
            this.colTotalRent.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalRent.OptionsColumn.ReadOnly = true;
            this.colTotalRent.Visible = true;
            this.colTotalRent.VisibleIndex = 6;
            this.colTotalRent.Width = 99;
            // 
            // colConfirm
            // 
            this.colConfirm.FieldName = "Confirm";
            this.colConfirm.Name = "colConfirm";
            this.colConfirm.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colConfirm.Visible = true;
            this.colConfirm.VisibleIndex = 0;
            this.colConfirm.Width = 59;
            // 
            // colInvDate
            // 
            this.colInvDate.Caption = "Inv.Date";
            this.colInvDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colInvDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colInvDate.FieldName = "InvDate";
            this.colInvDate.Name = "colInvDate";
            this.colInvDate.OptionsColumn.AllowEdit = false;
            this.colInvDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvDate.OptionsColumn.ReadOnly = true;
            this.colInvDate.Visible = true;
            this.colInvDate.VisibleIndex = 7;
            this.colInvDate.Width = 88;
            // 
            // colInvoiceID
            // 
            this.colInvoiceID.FieldName = "InvoiceID";
            this.colInvoiceID.Name = "colInvoiceID";
            this.colInvoiceID.OptionsColumn.AllowEdit = false;
            this.colInvoiceID.OptionsColumn.ReadOnly = true;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.FieldName = "InvoiceNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colInvoiceNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.OptionsColumn.ReadOnly = true;
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 8;
            // 
            // colSubInvTypeID1
            // 
            this.colSubInvTypeID1.Caption = "Invoice Type";
            this.colSubInvTypeID1.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colSubInvTypeID1.FieldName = "SubInvTypeID";
            this.colSubInvTypeID1.Name = "colSubInvTypeID1";
            this.colSubInvTypeID1.OptionsColumn.AllowEdit = false;
            this.colSubInvTypeID1.OptionsColumn.ReadOnly = true;
            this.colSubInvTypeID1.Visible = true;
            this.colSubInvTypeID1.VisibleIndex = 9;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeID", "Sub Inv Type ID", 101, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeName", "Sub Inv Type Name", 104, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StdOrder", "Std Order", 57, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far)});
            this.repositoryItemLookUpEdit2.DataSource = this.subInvoiceTypesBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "SubInvTypeName";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.ValueMember = "SubInvTypeID";
            // 
            // colCustomerID
            // 
            this.colCustomerID.Caption = "Customer";
            this.colCustomerID.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.colCustomerID.FieldName = "CustomerID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.OptionsColumn.AllowEdit = false;
            this.colCustomerID.OptionsColumn.ReadOnly = true;
            this.colCustomerID.Visible = true;
            this.colCustomerID.VisibleIndex = 5;
            this.colCustomerID.Width = 211;
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.DataSource = this.globalCustomersBindingSource;
            this.repositoryItemLookUpEdit4.DisplayMember = "CustomerName";
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            this.repositoryItemLookUpEdit4.NullText = "";
            this.repositoryItemLookUpEdit4.ValueMember = "CustomerID";
            // 
            // colDelete
            // 
            this.colDelete.FieldName = "Delete";
            this.colDelete.Name = "colDelete";
            this.colDelete.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 1;
            // 
            // xRent_Confirm_Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1498, 772);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "xRent_Confirm_Invoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Invoice No - Rent";
            this.Load += new System.EventHandler(this.xRent_GenInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRecentRentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subInvoiceTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnConfirmedInvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpInvoiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl cGen_Rent_InvoiceGridControl;
        private System.Windows.Forms.BindingSource cGen_Rent_InvoiceBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelID;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelCode;
        private DevExpress.XtraGrid.Columns.GridColumn colShopID;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalRent;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirm;
        private DevExpress.XtraGrid.Columns.GridColumn colInvDate;
        private DevExpress.XtraEditors.SimpleButton btnGenInv;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceID;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.BindingSource bsRecentRentList;
        private System.Windows.Forms.BindingSource bsUnConfirmedInvList;
        private DevExpress.XtraGrid.Columns.GridColumn colSubInvTypeID1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private System.Windows.Forms.BindingSource subInvoiceTypesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private System.Windows.Forms.BindingSource globalCustomersBindingSource;
        private DevExpress.XtraEditors.CheckButton btnSelectAll;
        private DevExpress.XtraEditors.LookUpEdit lookLocation;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.CheckButton btnSelectAllDelete;
        private DevExpress.XtraEditors.LookUpEdit lookUpInvoiceType;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}