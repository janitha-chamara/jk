namespace MMS
{
    partial class xPrintOSInv
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
            this.cGen_Rent_InvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subInvoiceTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.globalCustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPrintSummary = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.cGen_Rent_InvoiceGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInvoiceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSequenceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colInvoiceTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubInvTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookSubInvTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookCustomerID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.optRent = new DevExpress.XtraEditors.RadioGroup();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.btnSelectAll = new DevExpress.XtraEditors.CheckButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkShowAllInv = new System.Windows.Forms.CheckBox();
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookLocaiton = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtMonthYear_2 = new DevExpress.XtraEditors.DateEdit();
            this.dtMonthYear = new DevExpress.XtraEditors.DateEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.chkSignature = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subInvoiceTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookSubInvTypeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optRent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocaiton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear_2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear_2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cGen_Rent_InvoiceBindingSource
            // 
            this.cGen_Rent_InvoiceBindingSource.DataSource = typeof(MMS.cGen_Rent_Invoice);
            // 
            // subInvoiceTypesBindingSource
            // 
            this.subInvoiceTypesBindingSource.DataSource = typeof(DataTier.Sub_Invoice_Types);
            // 
            // globalCustomersBindingSource
            // 
            this.globalCustomersBindingSource.DataSource = typeof(DataTier.Global_Customers);
            // 
            // invoiceBindingSource
            // 
            this.invoiceBindingSource.DataSource = typeof(DataTier.Invoice);
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintSummary.Image = global::MMS.Properties.Resources.printer2;
            this.btnPrintSummary.Location = new System.Drawing.Point(969, 45);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(102, 26);
            this.btnPrintSummary.TabIndex = 15;
            this.btnPrintSummary.Text = "Print Summary";
            this.btnPrintSummary.Click += new System.EventHandler(this.btnPrintSummary_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::MMS.Properties.Resources.printer2;
            this.btnPrint.Location = new System.Drawing.Point(969, 13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(102, 26);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cGen_Rent_InvoiceGridControl
            // 
            this.cGen_Rent_InvoiceGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cGen_Rent_InvoiceGridControl.DataSource = this.cGen_Rent_InvoiceBindingSource;
            this.cGen_Rent_InvoiceGridControl.Location = new System.Drawing.Point(12, 112);
            this.cGen_Rent_InvoiceGridControl.MainView = this.gridView1;
            this.cGen_Rent_InvoiceGridControl.Name = "cGen_Rent_InvoiceGridControl";
            this.cGen_Rent_InvoiceGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookCustomerID,
            this.lookSubInvTypeID});
            this.cGen_Rent_InvoiceGridControl.Size = new System.Drawing.Size(1059, 476);
            this.cGen_Rent_InvoiceGridControl.TabIndex = 13;
            this.cGen_Rent_InvoiceGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInvoiceID,
            this.colSequenceNo,
            this.colInvoiceNo,
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
            this.colInvoiceTypeID,
            this.colSelect,
            this.colSubInvTypeID,
            this.colCustomerID,
            this.gridColumn1});
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
            this.colSequenceNo.FieldName = "SequenceNo";
            this.colSequenceNo.Name = "colSequenceNo";
            this.colSequenceNo.OptionsColumn.AllowEdit = false;
            this.colSequenceNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colSequenceNo.OptionsColumn.ReadOnly = true;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.FieldName = "InvoiceNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colInvoiceNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.OptionsColumn.ReadOnly = true;
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 2;
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
            this.colCompanyCode.VisibleIndex = 5;
            this.colCompanyCode.Width = 107;
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
            this.colLocationCode.VisibleIndex = 6;
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
            this.colTotalRent.VisibleIndex = 8;
            this.colTotalRent.Width = 126;
            // 
            // colConfirm
            // 
            this.colConfirm.Caption = "Confirmed";
            this.colConfirm.FieldName = "Confirm";
            this.colConfirm.Name = "colConfirm";
            this.colConfirm.OptionsColumn.AllowEdit = false;
            this.colConfirm.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colConfirm.OptionsColumn.ReadOnly = true;
            this.colConfirm.Visible = true;
            this.colConfirm.VisibleIndex = 1;
            this.colConfirm.Width = 71;
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
            this.colInvDate.VisibleIndex = 4;
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
            this.colSubInvTypeID.Visible = true;
            this.colSubInvTypeID.VisibleIndex = 3;
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
            this.colCustomerID.Visible = true;
            this.colCustomerID.VisibleIndex = 7;
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Proforma";
            this.gridColumn1.FieldName = "IsProforma";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // optRent
            // 
            this.optRent.Location = new System.Drawing.Point(12, 13);
            this.optRent.Name = "optRent";
            this.optRent.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Confirmed"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Not Confirmed"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "All")});
            this.optRent.Size = new System.Drawing.Size(469, 27);
            this.optRent.TabIndex = 12;
            this.optRent.SelectedIndexChanged += new System.EventHandler(this.optRent_SelectedIndexChanged);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(12, 112);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(85, 23);
            this.btnSelectAll.TabIndex = 22;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.CheckedChanged += new System.EventHandler(this.btnSelectAll_CheckedChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkShowAllInv);
            this.panelControl1.Controls.Add(this.lookCompany);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lookLocaiton);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Location = new System.Drawing.Point(12, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(445, 61);
            this.panelControl1.TabIndex = 23;
            // 
            // chkShowAllInv
            // 
            this.chkShowAllInv.AutoSize = true;
            this.chkShowAllInv.Location = new System.Drawing.Point(74, 8);
            this.chkShowAllInv.Name = "chkShowAllInv";
            this.chkShowAllInv.Size = new System.Drawing.Size(108, 17);
            this.chkShowAllInv.TabIndex = 11;
            this.chkShowAllInv.Text = "Show all Invoices";
            this.chkShowAllInv.UseVisualStyleBackColor = true;
            this.chkShowAllInv.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lookCompany
            // 
            this.lookCompany.EditValue = "";
            this.lookCompany.Location = new System.Drawing.Point(72, 32);
            this.lookCompany.Name = "lookCompany";
            this.lookCompany.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.lookCompany.Properties.NullText = "";
            this.lookCompany.Size = new System.Drawing.Size(142, 20);
            this.lookCompany.TabIndex = 10;
            this.lookCompany.EditValueChanged += new System.EventHandler(this.lookCompany_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Company : ";
            // 
            // lookLocaiton
            // 
            this.lookLocaiton.EditValue = "";
            this.lookLocaiton.Location = new System.Drawing.Point(279, 32);
            this.lookLocaiton.Name = "lookLocaiton";
            this.lookLocaiton.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookLocaiton.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocaiton.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.lookLocaiton.Properties.NullText = "";
            this.lookLocaiton.Size = new System.Drawing.Size(142, 20);
            this.lookLocaiton.TabIndex = 8;
            this.lookLocaiton.EditValueChanged += new System.EventHandler(this.lookLocaiton_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(226, 36);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Location :";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dtMonthYear_2);
            this.groupControl1.Controls.Add(this.dtMonthYear);
            this.groupControl1.Location = new System.Drawing.Point(463, 44);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(419, 61);
            this.groupControl1.TabIndex = 24;
            this.groupControl1.Text = "Month / Year";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(221, 32);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(22, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "To : ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 32);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "From : ";
            // 
            // dtMonthYear_2
            // 
            this.dtMonthYear_2.EditValue = null;
            this.dtMonthYear_2.EnterMoveNextControl = true;
            this.dtMonthYear_2.Location = new System.Drawing.Point(253, 29);
            this.dtMonthYear_2.Name = "dtMonthYear_2";
            this.dtMonthYear_2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtMonthYear_2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtMonthYear_2.Properties.DisplayFormat.FormatString = "y";
            this.dtMonthYear_2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtMonthYear_2.Properties.EditFormat.FormatString = "y";
            this.dtMonthYear_2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtMonthYear_2.Properties.Mask.EditMask = "y";
            this.dtMonthYear_2.Size = new System.Drawing.Size(138, 20);
            this.dtMonthYear_2.TabIndex = 1;
            this.dtMonthYear_2.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // dtMonthYear
            // 
            this.dtMonthYear.EditValue = null;
            this.dtMonthYear.EnterMoveNextControl = true;
            this.dtMonthYear.Location = new System.Drawing.Point(50, 29);
            this.dtMonthYear.Name = "dtMonthYear";
            this.dtMonthYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtMonthYear.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtMonthYear.Properties.DisplayFormat.FormatString = "y";
            this.dtMonthYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtMonthYear.Properties.EditFormat.FormatString = "y";
            this.dtMonthYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtMonthYear.Properties.Mask.EditMask = "y";
            this.dtMonthYear.Size = new System.Drawing.Size(138, 20);
            this.dtMonthYear.TabIndex = 0;
            this.dtMonthYear.EditValueChanged += new System.EventHandler(this.dtMonthYear_EditValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(969, 77);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 26);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkSignature
            // 
            this.chkSignature.AutoSize = true;
            this.chkSignature.Location = new System.Drawing.Point(662, 23);
            this.chkSignature.Name = "chkSignature";
            this.chkSignature.Size = new System.Drawing.Size(122, 17);
            this.chkSignature.TabIndex = 26;
            this.chkSignature.Text = "Print With Signature";
            this.chkSignature.UseVisualStyleBackColor = true;
            this.chkSignature.CheckedChanged += new System.EventHandler(this.chkSignature_CheckedChanged);
            // 
            // xPrintOSInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 600);
            this.Controls.Add(this.chkSignature);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnPrintSummary);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cGen_Rent_InvoiceGridControl);
            this.Controls.Add(this.optRent);
            this.Name = "xPrintOSInv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print - Other Service Invoice";
            this.Load += new System.EventHandler(this.xPrintOSInv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subInvoiceTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookSubInvTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optRent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocaiton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear_2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear_2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource cGen_Rent_InvoiceBindingSource;
        private System.Windows.Forms.BindingSource subInvoiceTypesBindingSource;
        private System.Windows.Forms.BindingSource globalCustomersBindingSource;
        private System.Windows.Forms.BindingSource invoiceBindingSource;
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
        private DevExpress.XtraGrid.Columns.GridColumn colConfirm;
        private DevExpress.XtraGrid.Columns.GridColumn colInvDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colSubInvTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraEditors.RadioGroup optRent;
        private DevExpress.XtraEditors.CheckButton btnSelectAll;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookCustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookSubInvTypeID;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookLocaiton;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit dtMonthYear;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtMonthYear_2;
        private System.Windows.Forms.CheckBox chkShowAllInv;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.CheckBox chkSignature;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}