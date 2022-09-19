namespace MMS.Transaction.OtherServices
{
    partial class xProformaInvoice
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
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnPrintSummary = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.cGen_Rent_InvoiceGridControl = new DevExpress.XtraGrid.GridControl();
            this.cGen_Rent_InvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInvoiceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSequenceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalRent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubInvTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookSubInvTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookCustomerID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnSaveGenProformas = new DevExpress.XtraEditors.SimpleButton();
            this.chkBtnConfirm = new DevExpress.XtraEditors.CheckButton();
            this.chkcancel = new DevExpress.XtraEditors.CheckButton();
            this.globalCustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subInvoiceTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bsRecentRentList = new System.Windows.Forms.BindingSource(this.components);
            this.chkSelectAll = new DevExpress.XtraEditors.CheckButton();
            this.btnCancelProf = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirmProf = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookSubInvTypeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subInvoiceTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRecentRentList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(1088, 106);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 32);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lookCompany);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lookLocation);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Location = new System.Drawing.Point(7, 15);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(467, 87);
            this.panelControl1.TabIndex = 31;
            // 
            // lookCompany
            // 
            this.lookCompany.EditValue = "";
            this.lookCompany.Location = new System.Drawing.Point(12, 50);
            this.lookCompany.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lookCompany.Name = "lookCompany";
            this.lookCompany.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.lookCompany.Properties.NullText = "";
            this.lookCompany.Size = new System.Drawing.Size(189, 22);
            this.lookCompany.TabIndex = 10;
            this.lookCompany.EditValueChanged += new System.EventHandler(this.lookCompany_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 31);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 16);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Company : ";
            // 
            // lookLocation
            // 
            this.lookLocation.EditValue = "";
            this.lookLocation.Location = new System.Drawing.Point(223, 50);
            this.lookLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lookLocation.Name = "lookLocation";
            this.lookLocation.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.lookLocation.Properties.NullText = "";
            this.lookLocation.Size = new System.Drawing.Size(189, 22);
            this.lookLocation.TabIndex = 8;
            this.lookLocation.EditValueChanged += new System.EventHandler(this.lookLocation_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(223, 32);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(56, 16);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Location :";
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintSummary.Image = global::MMS.Properties.Resources.printer2;
            this.btnPrintSummary.Location = new System.Drawing.Point(1088, 66);
            this.btnPrintSummary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(136, 32);
            this.btnPrintSummary.TabIndex = 29;
            this.btnPrintSummary.Text = "Print Summary";
            this.btnPrintSummary.Click += new System.EventHandler(this.btnPrintSummary_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::MMS.Properties.Resources.printer2;
            this.btnPrint.Location = new System.Drawing.Point(1088, 27);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(136, 32);
            this.btnPrint.TabIndex = 28;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cGen_Rent_InvoiceGridControl
            // 
            this.cGen_Rent_InvoiceGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cGen_Rent_InvoiceGridControl.DataSource = this.cGen_Rent_InvoiceBindingSource;
            this.cGen_Rent_InvoiceGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cGen_Rent_InvoiceGridControl.Location = new System.Drawing.Point(7, 177);
            this.cGen_Rent_InvoiceGridControl.MainView = this.gridView1;
            this.cGen_Rent_InvoiceGridControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cGen_Rent_InvoiceGridControl.Name = "cGen_Rent_InvoiceGridControl";
            this.cGen_Rent_InvoiceGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookCustomerID,
            this.lookSubInvTypeID});
            this.cGen_Rent_InvoiceGridControl.Size = new System.Drawing.Size(1168, 388);
            this.cGen_Rent_InvoiceGridControl.TabIndex = 27;
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
            this.colInvoiceID,
            this.colSequenceNo,
            this.colInvoiceNo,
            this.colCompanyID,
            this.colCompanyCode,
            this.gridColumn1,
            this.colLocationID,
            this.colLocationCode,
            this.colLevelID,
            this.colLevelCode,
            this.colShopID,
            this.colShopNo,
            this.colShopName,
            this.colTotalRent,
            this.colInvDate,
            this.colInvoiceTypeID,
            this.colSelect,
            this.colSubInvTypeID,
            this.colCustomerID});
            this.gridView1.GridControl = this.cGen_Rent_InvoiceGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "List of Invoices";
            // 
            // colInvoiceID
            // 
            this.colInvoiceID.FieldName = "InvoiceID";
            this.colInvoiceID.Name = "colInvoiceID";
            this.colInvoiceID.OptionsColumn.AllowEdit = false;
            this.colInvoiceID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceID.OptionsColumn.ReadOnly = true;
            // 
            // colSequenceNo
            // 
            this.colSequenceNo.FieldName = "ProfomaSequenceNo";
            this.colSequenceNo.Name = "colSequenceNo";
            this.colSequenceNo.OptionsColumn.AllowEdit = false;
            this.colSequenceNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colSequenceNo.OptionsColumn.ReadOnly = true;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.FieldName = "ProfomaNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colInvoiceNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.OptionsColumn.ReadOnly = true;
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 1;
            this.colInvoiceNo.Width = 80;
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
            this.colCompanyCode.FieldName = "CompanyCode";
            this.colCompanyCode.Name = "colCompanyCode";
            this.colCompanyCode.OptionsColumn.AllowEdit = false;
            this.colCompanyCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colCompanyCode.OptionsColumn.ReadOnly = true;
            this.colCompanyCode.Visible = true;
            this.colCompanyCode.VisibleIndex = 3;
            this.colCompanyCode.Width = 107;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Customer Name";
            this.gridColumn1.FieldName = "CustomerName";
            this.gridColumn1.MaxWidth = 200;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 200;
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
            this.colLocationCode.FieldName = "LocationCode";
            this.colLocationCode.Name = "colLocationCode";
            this.colLocationCode.OptionsColumn.AllowEdit = false;
            this.colLocationCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colLocationCode.OptionsColumn.ReadOnly = true;
            this.colLocationCode.Visible = true;
            this.colLocationCode.VisibleIndex = 4;
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
            this.colLevelCode.Width = 87;
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
            this.colShopNo.Width = 85;
            // 
            // colShopName
            // 
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.OptionsColumn.AllowEdit = false;
            this.colShopName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colShopName.OptionsColumn.ReadOnly = true;
            this.colShopName.Width = 99;
            // 
            // colTotalRent
            // 
            this.colTotalRent.Caption = "Total Rent";
            this.colTotalRent.DisplayFormat.FormatString = "n4";
            this.colTotalRent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalRent.FieldName = "TotalRent";
            this.colTotalRent.Name = "colTotalRent";
            this.colTotalRent.OptionsColumn.AllowEdit = false;
            this.colTotalRent.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalRent.OptionsColumn.ReadOnly = true;
            this.colTotalRent.Visible = true;
            this.colTotalRent.VisibleIndex = 6;
            this.colTotalRent.Width = 126;
            // 
            // colInvDate
            // 
            this.colInvDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colInvDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colInvDate.FieldName = "InvDate";
            this.colInvDate.Name = "colInvDate";
            this.colInvDate.OptionsColumn.AllowEdit = false;
            this.colInvDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvDate.OptionsColumn.ReadOnly = true;
            this.colInvDate.Visible = true;
            this.colInvDate.VisibleIndex = 2;
            this.colInvDate.Width = 79;
            // 
            // colInvoiceTypeID
            // 
            this.colInvoiceTypeID.FieldName = "InvoiceTypeID";
            this.colInvoiceTypeID.Name = "colInvoiceTypeID";
            this.colInvoiceTypeID.OptionsColumn.AllowEdit = false;
            this.colInvoiceTypeID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceTypeID.OptionsColumn.ReadOnly = true;
            // 
            // colSelect
            // 
            this.colSelect.FieldName = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colSelect.Visible = true;
            this.colSelect.VisibleIndex = 0;
            this.colSelect.Width = 44;
            // 
            // colSubInvTypeID
            // 
            this.colSubInvTypeID.Caption = "Invoice Type";
            this.colSubInvTypeID.ColumnEdit = this.lookSubInvTypeID;
            this.colSubInvTypeID.FieldName = "SubInvTypeID";
            this.colSubInvTypeID.Name = "colSubInvTypeID";
            this.colSubInvTypeID.OptionsColumn.AllowEdit = false;
            this.colSubInvTypeID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colSubInvTypeID.OptionsColumn.ReadOnly = true;
            // 
            // lookSubInvTypeID
            // 
            this.lookSubInvTypeID.AutoHeight = false;
            this.lookSubInvTypeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookSubInvTypeID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeID", "SubInvTypeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeName", "SubInvTypeName")});
            this.lookSubInvTypeID.Name = "lookSubInvTypeID";
            this.lookSubInvTypeID.NullText = "";
            // 
            // colCustomerID
            // 
            this.colCustomerID.Caption = "Customer";
            this.colCustomerID.ColumnEdit = this.lookCustomerID;
            this.colCustomerID.FieldName = "CustomerID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.OptionsColumn.AllowEdit = false;
            this.colCustomerID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCustomerID.OptionsColumn.ReadOnly = true;
            this.colCustomerID.Width = 171;
            // 
            // lookCustomerID
            // 
            this.lookCustomerID.AutoHeight = false;
            this.lookCustomerID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCustomerID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "CustomerName")});
            this.lookCustomerID.Name = "lookCustomerID";
            this.lookCustomerID.NullText = "";
            // 
            // btnSaveGenProformas
            // 
            this.btnSaveGenProformas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveGenProformas.Image = global::MMS.Properties.Resources.disk_blue1;
            this.btnSaveGenProformas.Location = new System.Drawing.Point(887, 106);
            this.btnSaveGenProformas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveGenProformas.Name = "btnSaveGenProformas";
            this.btnSaveGenProformas.Size = new System.Drawing.Size(193, 32);
            this.btnSaveGenProformas.TabIndex = 38;
            this.btnSaveGenProformas.Text = "Save Profrmas";
            this.btnSaveGenProformas.Click += new System.EventHandler(this.btnSaveGenProformas_Click);
            // 
            // chkBtnConfirm
            // 
            this.chkBtnConfirm.Image = global::MMS.Properties.Resources.check2;
            this.chkBtnConfirm.Location = new System.Drawing.Point(531, 15);
            this.chkBtnConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkBtnConfirm.Name = "chkBtnConfirm";
            this.chkBtnConfirm.Size = new System.Drawing.Size(193, 32);
            this.chkBtnConfirm.TabIndex = 38;
            this.chkBtnConfirm.Text = "Confirm Proforma ";
            this.chkBtnConfirm.Visible = false;
            this.chkBtnConfirm.CheckedChanged += new System.EventHandler(this.chkBtnConfirm_CheckedChanged);
            // 
            // chkcancel
            // 
            this.chkcancel.Image = global::MMS.Properties.Resources.delete2;
            this.chkcancel.Location = new System.Drawing.Point(531, 54);
            this.chkcancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkcancel.Name = "chkcancel";
            this.chkcancel.Size = new System.Drawing.Size(193, 32);
            this.chkcancel.TabIndex = 39;
            this.chkcancel.Text = "Cancel Proforma";
            this.chkcancel.Visible = false;
            this.chkcancel.CheckedChanged += new System.EventHandler(this.chkcancel_CheckedChanged);
            // 
            // globalCustomersBindingSource
            // 
            this.globalCustomersBindingSource.DataSource = typeof(DataTier.Global_Customers);
            // 
            // subInvoiceTypesBindingSource
            // 
            this.subInvoiceTypesBindingSource.DataSource = typeof(DataTier.Sub_Invoice_Types);
            // 
            // bsRecentRentList
            // 
            this.bsRecentRentList.DataSource = typeof(MMS.cGen_Rent_Invoice);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Location = new System.Drawing.Point(7, 143);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(136, 28);
            this.chkSelectAll.TabIndex = 37;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnCancelProf
            // 
            this.btnCancelProf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelProf.Image = global::MMS.Properties.Resources.delete2;
            this.btnCancelProf.Location = new System.Drawing.Point(887, 66);
            this.btnCancelProf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelProf.Name = "btnCancelProf";
            this.btnCancelProf.Size = new System.Drawing.Size(193, 32);
            this.btnCancelProf.TabIndex = 40;
            this.btnCancelProf.Text = "Cancel Proforma";
            this.btnCancelProf.Click += new System.EventHandler(this.btnCancelProf_Click);
            // 
            // btnConfirmProf
            // 
            this.btnConfirmProf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmProf.Image = global::MMS.Properties.Resources.check2;
            this.btnConfirmProf.Location = new System.Drawing.Point(887, 27);
            this.btnConfirmProf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfirmProf.Name = "btnConfirmProf";
            this.btnConfirmProf.Size = new System.Drawing.Size(193, 32);
            this.btnConfirmProf.TabIndex = 41;
            this.btnConfirmProf.Text = "Confirm Proforma ";
            this.btnConfirmProf.Click += new System.EventHandler(this.btnConfirmProf_Click);
            // 
            // xProformaInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 740);
            this.Controls.Add(this.btnConfirmProf);
            this.Controls.Add(this.btnCancelProf);
            this.Controls.Add(this.btnSaveGenProformas);
            this.Controls.Add(this.chkBtnConfirm);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.chkcancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btnPrintSummary);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cGen_Rent_InvoiceGridControl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "xProformaInvoice";
            this.Text = "Proforma Invoice [Promotion]";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookSubInvTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subInvoiceTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRecentRentList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookLocation;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnPrintSummary;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.GridControl cGen_Rent_InvoiceGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceID;
        private DevExpress.XtraGrid.Columns.GridColumn colSequenceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
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
        private DevExpress.XtraGrid.Columns.GridColumn colInvDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colSubInvTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookSubInvTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookCustomerID;
        private System.Windows.Forms.BindingSource cGen_Rent_InvoiceBindingSource;
        private System.Windows.Forms.BindingSource globalCustomersBindingSource;
        private System.Windows.Forms.BindingSource subInvoiceTypesBindingSource;
        private System.Windows.Forms.BindingSource bsRecentRentList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.CheckButton chkSelectAll;
        private DevExpress.XtraEditors.CheckButton chkBtnConfirm;
        private DevExpress.XtraEditors.CheckButton chkcancel;
        private DevExpress.XtraEditors.SimpleButton btnSaveGenProformas;
        private DevExpress.XtraEditors.SimpleButton btnCancelProf;
        private DevExpress.XtraEditors.SimpleButton btnConfirmProf;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;

    }
}