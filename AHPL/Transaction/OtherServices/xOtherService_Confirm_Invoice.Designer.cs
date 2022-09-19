namespace MMS
{
    partial class xOtherService_Confirm_Invoice
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
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.lookLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnGenInv = new DevExpress.XtraEditors.SimpleButton();
            this.cGen_Rent_InvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cGen_Rent_InvoiceGridControl = new DevExpress.XtraGrid.GridControl();
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
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubInvTypeID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceTypeID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookInvoiceTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnSelectAll = new DevExpress.XtraEditors.CheckButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.btnDeleteSelectAll = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRecentRentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subInvoiceTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookInvoiceTypeID)).BeginInit();
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
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::MMS.Properties.Resources.delete22;
            this.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(835, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 69);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete \r\nSelected\r\nInvoice(s)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lookLocation
            // 
            this.lookLocation.Location = new System.Drawing.Point(103, 46);
            this.lookLocation.Name = "lookLocation";
            this.lookLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.lookLocation.Properties.NullText = "";
            this.lookLocation.Size = new System.Drawing.Size(171, 20);
            this.lookLocation.TabIndex = 14;
            this.lookLocation.EditValueChanged += new System.EventHandler(this.lookLocation_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(49, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Location :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Company :";
            // 
            // lookCompany
            // 
            this.lookCompany.Location = new System.Drawing.Point(103, 20);
            this.lookCompany.Name = "lookCompany";
            this.lookCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.lookCompany.Properties.NullText = "";
            this.lookCompany.Size = new System.Drawing.Size(171, 20);
            this.lookCompany.TabIndex = 11;
            this.lookCompany.EditValueChanged += new System.EventHandler(this.lookCompany_EditValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into;
            this.btnClose.Location = new System.Drawing.Point(913, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 69);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::MMS.Properties.Resources.disk_blue1;
            this.btnSave.Location = new System.Drawing.Point(652, 48);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save Generated Invoice No(s)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGenInv
            // 
            this.btnGenInv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenInv.Image = global::MMS.Properties.Resources.document_check;
            this.btnGenInv.Location = new System.Drawing.Point(652, 12);
            this.btnGenInv.Name = "btnGenInv";
            this.btnGenInv.Size = new System.Drawing.Size(177, 32);
            this.btnGenInv.TabIndex = 3;
            this.btnGenInv.Text = "Generate Invoice No(s)";
            this.btnGenInv.Click += new System.EventHandler(this.btnGenInv_Click);
            // 
            // cGen_Rent_InvoiceBindingSource
            // 
            this.cGen_Rent_InvoiceBindingSource.DataSource = typeof(MMS.cGen_Rent_Invoice);
            // 
            // cGen_Rent_InvoiceGridControl
            // 
            this.cGen_Rent_InvoiceGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cGen_Rent_InvoiceGridControl.DataSource = this.cGen_Rent_InvoiceBindingSource;
            this.cGen_Rent_InvoiceGridControl.Location = new System.Drawing.Point(0, 98);
            this.cGen_Rent_InvoiceGridControl.MainView = this.gridView1;
            this.cGen_Rent_InvoiceGridControl.Name = "cGen_Rent_InvoiceGridControl";
            this.cGen_Rent_InvoiceGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit4,
            this.lookInvoiceTypeID});
            this.cGen_Rent_InvoiceGridControl.Size = new System.Drawing.Size(1011, 296);
            this.cGen_Rent_InvoiceGridControl.TabIndex = 1;
            this.cGen_Rent_InvoiceGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.gridColumn1,
            this.colInvoiceNo,
            this.colSubInvTypeID1,
            this.colCustomerName,
            this.colContractName,
            this.colInvoiceTypeID1,
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
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSubInvTypeID1, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.colCompanyCode.VisibleIndex = 5;
            this.colCompanyCode.Width = 66;
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
            this.colLocationCode.VisibleIndex = 6;
            this.colLocationCode.Width = 73;
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
            this.colShopName.VisibleIndex = 8;
            this.colShopName.Width = 109;
            // 
            // colTotalRent
            // 
            this.colTotalRent.DisplayFormat.FormatString = "n2";
            this.colTotalRent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalRent.FieldName = "TotalRent";
            this.colTotalRent.Name = "colTotalRent";
            this.colTotalRent.OptionsColumn.AllowEdit = false;
            this.colTotalRent.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalRent.OptionsColumn.ReadOnly = true;
            this.colTotalRent.Visible = true;
            this.colTotalRent.VisibleIndex = 10;
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
            this.colInvDate.VisibleIndex = 4;
            this.colInvDate.Width = 88;
            // 
            // colInvoiceID
            // 
            this.colInvoiceID.FieldName = "InvoiceID";
            this.colInvoiceID.Name = "colInvoiceID";
            this.colInvoiceID.OptionsColumn.AllowEdit = false;
            this.colInvoiceID.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Profoma #";
            this.gridColumn1.FieldName = "ProfomaNo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.FieldName = "InvoiceNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colInvoiceNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.OptionsColumn.ReadOnly = true;
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 3;
            this.colInvoiceNo.Width = 99;
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
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 9;
            this.colCustomerName.Width = 144;
            // 
            // colContractName
            // 
            this.colContractName.Caption = "Contract Name";
            this.colContractName.Name = "colContractName";
            this.colContractName.Visible = true;
            this.colContractName.VisibleIndex = 7;
            this.colContractName.Width = 124;
            // 
            // colInvoiceTypeID1
            // 
            this.colInvoiceTypeID1.Caption = "Invoice Type";
            this.colInvoiceTypeID1.ColumnEdit = this.lookInvoiceTypeID;
            this.colInvoiceTypeID1.FieldName = "InvoiceTypeID";
            this.colInvoiceTypeID1.Name = "colInvoiceTypeID1";
            // 
            // lookInvoiceTypeID
            // 
            this.lookInvoiceTypeID.AutoHeight = false;
            this.lookInvoiceTypeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookInvoiceTypeID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoiceTypeID", "InvoiceTypeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoiceTypeName", "Invoice Type Name")});
            this.lookInvoiceTypeID.Name = "lookInvoiceTypeID";
            // 
            // colDelete
            // 
            this.colDelete.Caption = "Delete?";
            this.colDelete.FieldName = "Delete";
            this.colDelete.Name = "colDelete";
            this.colDelete.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 1;
            this.colDelete.Width = 50;
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "Customer ID", 83, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Customer Name", 86, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyAddress", "Company Address", 97, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TelNos", "Tel Nos", 45, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FaxNos", "Fax Nos", 49, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmailAddress", "Email Address", 76, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RegNo", "Reg No", 45, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MajShareName", "Maj Share Name", 88, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YearOfInc", "Year Of Inc", 65, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameOfPrinciple", "Name Of Principle", 94, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PaidUpShareCapital", "Paid Up Share Capital", 113, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AuthShareCaptial", "Auth Share Captial", 100, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CreatedBy", "Created By", 64, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CreatedDate", "Created Date", 75, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UpdatedBy", "Updated By", 66, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UpdatedDate", "Updated Date", 77, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SAPCustomerCode", "SAP Customer Code", 106, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DefaultTaxRegNo", "Default Tax Reg No", 104, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DefaultTaxID", "Default Tax ID", 80, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KnownAs", "Known As", 57, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AlternateEmail", "Alternate Email", 82, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Discontinued", "Discontinued", 71, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DiscontinuedDate", "Discontinued Date", 97, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Customer_Attachments", "Customer_Attachments", 123, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Customer_Taxes", "Customer_Taxes", 91, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit4.DataSource = this.globalCustomersBindingSource;
            this.repositoryItemLookUpEdit4.DisplayMember = "CustomerName";
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            this.repositoryItemLookUpEdit4.NullText = "";
            this.repositoryItemLookUpEdit4.ValueMember = "CustomerID";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(0, 98);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.CheckedChanged += new System.EventHandler(this.btnSelectAll_CheckedChanged);
            // 
            // btnDeleteSelectAll
            // 
            this.btnDeleteSelectAll.Location = new System.Drawing.Point(103, 98);
            this.btnDeleteSelectAll.Name = "btnDeleteSelectAll";
            this.btnDeleteSelectAll.Size = new System.Drawing.Size(124, 23);
            this.btnDeleteSelectAll.TabIndex = 16;
            this.btnDeleteSelectAll.Text = "Select All For Delete";
            this.btnDeleteSelectAll.CheckedChanged += new System.EventHandler(this.btnDeleteSelectAll_CheckedChanged);
            // 
            // xOtherService_Confirm_Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 394);
            this.Controls.Add(this.btnDeleteSelectAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.lookLocation);
            this.Controls.Add(this.cGen_Rent_InvoiceGridControl);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lookCompany);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenInv);
            this.Controls.Add(this.btnSave);
            this.Name = "xOtherService_Confirm_Invoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Other Service - Confirm Rent Invoice";
            this.Load += new System.EventHandler(this.xOtherService_Confirm_Invoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRecentRentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subInvoiceTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookInvoiceTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnGenInv;
        private System.Windows.Forms.BindingSource cGen_Rent_InvoiceBindingSource;
        private DevExpress.XtraGrid.GridControl cGen_Rent_InvoiceGridControl;
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
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceID;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSubInvTypeID1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.BindingSource globalCustomersBindingSource;
        private System.Windows.Forms.BindingSource subInvoiceTypesBindingSource;
        private System.Windows.Forms.BindingSource bsRecentRentList;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colContractName;
        private DevExpress.XtraEditors.CheckButton btnSelectAll;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceTypeID1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookInvoiceTypeID;
        private DevExpress.XtraEditors.LookUpEdit lookLocation;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.CheckButton btnDeleteSelectAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}