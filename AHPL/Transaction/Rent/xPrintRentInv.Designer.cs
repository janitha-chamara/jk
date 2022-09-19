namespace MMS
{
    partial class xPrintRentInv
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
            this.optRent = new DevExpress.XtraEditors.RadioGroup();
            this.cGen_Rent_InvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubInvTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.subInvoiceTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.globalCustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colProcessMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditMonth = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProcessYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPrintSummary = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkCompany = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.chkSelect = new DevExpress.XtraEditors.CheckButton();
            this.dtMonthYear = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtMonthYear_2 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkShowAllInv = new System.Windows.Forms.CheckBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpInvoiceType = new DevExpress.XtraEditors.LookUpEdit();
            this.btnDirectPrint = new DevExpress.XtraEditors.SimpleButton();
            this.chkSignature = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.optRent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subInvoiceTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear_2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear_2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpInvoiceType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // optRent
            // 
            this.optRent.Location = new System.Drawing.Point(14, 15);
            this.optRent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optRent.Name = "optRent";
            this.optRent.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Confirmed"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Not Confirmed"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "All")});
            this.optRent.Size = new System.Drawing.Size(547, 33);
            this.optRent.TabIndex = 0;
            this.optRent.SelectedIndexChanged += new System.EventHandler(this.optRent_SelectedIndexChanged);
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
            this.cGen_Rent_InvoiceGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cGen_Rent_InvoiceGridControl.Location = new System.Drawing.Point(15, 213);
            this.cGen_Rent_InvoiceGridControl.MainView = this.gridView1;
            this.cGen_Rent_InvoiceGridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cGen_Rent_InvoiceGridControl.Name = "cGen_Rent_InvoiceGridControl";
            this.cGen_Rent_InvoiceGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEditMonth});
            this.cGen_Rent_InvoiceGridControl.Size = new System.Drawing.Size(1184, 489);
            this.cGen_Rent_InvoiceGridControl.TabIndex = 2;
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
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.colConfirm,
            this.colInvDate,
            this.colInvoiceTypeID,
            this.colSelect,
            this.colSubInvTypeID,
            this.colCustomerID,
            this.colProcessMonth,
            this.colProcessYear});
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
            this.colCompanyCode.VisibleIndex = 9;
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
            this.colLocationCode.VisibleIndex = 10;
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
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 7;
            this.colShopNo.Width = 85;
            // 
            // colShopName
            // 
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.OptionsColumn.AllowEdit = false;
            this.colShopName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colShopName.OptionsColumn.ReadOnly = true;
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 8;
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
            this.colTotalRent.VisibleIndex = 13;
            this.colTotalRent.Width = 126;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Rental Disc (%)";
            this.gridColumn1.FieldName = "RentalDiscount";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 12;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Service Charge";
            this.gridColumn2.FieldName = "SCPerMonth";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 14;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "SC Disc (%)";
            this.gridColumn3.FieldName = "SCDiscount";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 15;
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
            this.colInvDate.VisibleIndex = 6;
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
            this.colSubInvTypeID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colSubInvTypeID.FieldName = "SubInvTypeID";
            this.colSubInvTypeID.Name = "colSubInvTypeID";
            this.colSubInvTypeID.OptionsColumn.AllowEdit = false;
            this.colSubInvTypeID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colSubInvTypeID.OptionsColumn.ReadOnly = true;
            this.colSubInvTypeID.Visible = true;
            this.colSubInvTypeID.VisibleIndex = 3;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeID", "Sub Inv Type ID", 101, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeName", "Sub Inv Type Name", 104, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StdOrder", "Std Order", 57, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far)});
            this.repositoryItemLookUpEdit1.DataSource = this.subInvoiceTypesBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "SubInvTypeName";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "SubInvTypeID";
            // 
            // subInvoiceTypesBindingSource
            // 
            this.subInvoiceTypesBindingSource.DataSource = typeof(DataTier.Sub_Invoice_Types);
            // 
            // colCustomerID
            // 
            this.colCustomerID.Caption = "Customer";
            this.colCustomerID.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colCustomerID.FieldName = "CustomerID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.OptionsColumn.AllowEdit = false;
            this.colCustomerID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCustomerID.OptionsColumn.ReadOnly = true;
            this.colCustomerID.Visible = true;
            this.colCustomerID.VisibleIndex = 11;
            this.colCustomerID.Width = 171;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "Customer ID", 83, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Customer Name", 86, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit2.DataSource = this.globalCustomersBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "CustomerName";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.ValueMember = "CustomerID";
            // 
            // globalCustomersBindingSource
            // 
            this.globalCustomersBindingSource.DataSource = typeof(DataTier.Global_Customers);
            // 
            // colProcessMonth
            // 
            this.colProcessMonth.Caption = "Month";
            this.colProcessMonth.ColumnEdit = this.repositoryItemLookUpEditMonth;
            this.colProcessMonth.FieldName = "ProcessMonth";
            this.colProcessMonth.Name = "colProcessMonth";
            this.colProcessMonth.OptionsColumn.ReadOnly = true;
            this.colProcessMonth.Visible = true;
            this.colProcessMonth.VisibleIndex = 5;
            this.colProcessMonth.Width = 55;
            // 
            // repositoryItemLookUpEditMonth
            // 
            this.repositoryItemLookUpEditMonth.AutoHeight = false;
            this.repositoryItemLookUpEditMonth.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditMonth.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MonthID", "MonthID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MonthCode", "Month")});
            this.repositoryItemLookUpEditMonth.Name = "repositoryItemLookUpEditMonth";
            // 
            // colProcessYear
            // 
            this.colProcessYear.Caption = "Year";
            this.colProcessYear.FieldName = "ProcessYear";
            this.colProcessYear.Name = "colProcessYear";
            this.colProcessYear.OptionsColumn.ReadOnly = true;
            this.colProcessYear.Visible = true;
            this.colProcessYear.VisibleIndex = 4;
            this.colProcessYear.Width = 56;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::MMS.Properties.Resources.printer2;
            this.btnPrint.Location = new System.Drawing.Point(741, 17);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(119, 32);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // invoiceBindingSource
            // 
            this.invoiceBindingSource.DataSource = typeof(DataTier.Invoice);
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.Image = global::MMS.Properties.Resources.printer2;
            this.btnPrintSummary.Location = new System.Drawing.Point(999, 16);
            this.btnPrintSummary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(119, 32);
            this.btnPrintSummary.TabIndex = 5;
            this.btnPrintSummary.Text = "Print Summary";
            this.btnPrintSummary.Click += new System.EventHandler(this.btnPrintSummary_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 118);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Company :";
            // 
            // chkCompany
            // 
            this.chkCompany.Location = new System.Drawing.Point(80, 113);
            this.chkCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCompany.Name = "chkCompany";
            this.chkCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkCompany.Size = new System.Drawing.Size(373, 22);
            this.chkCompany.TabIndex = 7;
            this.chkCompany.EditValueChanged += new System.EventHandler(this.chkCompany_EditValueChanged);
            // 
            // chkSelect
            // 
            this.chkSelect.Location = new System.Drawing.Point(15, 213);
            this.chkSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(105, 28);
            this.chkSelect.TabIndex = 12;
            this.chkSelect.Text = "Select All";
            this.chkSelect.CheckedChanged += new System.EventHandler(this.chkSelect_CheckedChanged);
            // 
            // dtMonthYear
            // 
            this.dtMonthYear.EditValue = null;
            this.dtMonthYear.Location = new System.Drawing.Point(623, 114);
            this.dtMonthYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtMonthYear.Name = "dtMonthYear";
            this.dtMonthYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtMonthYear.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtMonthYear.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dtMonthYear.Properties.DisplayFormat.FormatString = "y";
            this.dtMonthYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtMonthYear.Properties.EditFormat.FormatString = "y";
            this.dtMonthYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtMonthYear.Properties.Mask.EditMask = "y";
            this.dtMonthYear.Size = new System.Drawing.Size(163, 22);
            this.dtMonthYear.TabIndex = 13;
            this.dtMonthYear.EditValueChanged += new System.EventHandler(this.dtMonthYear_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(504, 118);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(123, 16);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "From (Month / Year):";
            // 
            // dtMonthYear_2
            // 
            this.dtMonthYear_2.EditValue = null;
            this.dtMonthYear_2.Location = new System.Drawing.Point(624, 162);
            this.dtMonthYear_2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtMonthYear_2.Name = "dtMonthYear_2";
            this.dtMonthYear_2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtMonthYear_2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtMonthYear_2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dtMonthYear_2.Properties.DisplayFormat.FormatString = "y";
            this.dtMonthYear_2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtMonthYear_2.Properties.EditFormat.FormatString = "y";
            this.dtMonthYear_2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtMonthYear_2.Properties.Mask.EditMask = "y";
            this.dtMonthYear_2.Size = new System.Drawing.Size(163, 22);
            this.dtMonthYear_2.TabIndex = 15;
            this.dtMonthYear_2.EditValueChanged += new System.EventHandler(this.dtMonthYear_2_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(504, 166);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(104, 16);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "To (Month/ Year):";
            // 
            // chkShowAllInv
            // 
            this.chkShowAllInv.AutoSize = true;
            this.chkShowAllInv.Location = new System.Drawing.Point(80, 71);
            this.chkShowAllInv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowAllInv.Name = "chkShowAllInv";
            this.chkShowAllInv.Size = new System.Drawing.Size(133, 21);
            this.chkShowAllInv.TabIndex = 17;
            this.chkShowAllInv.Text = "Show all Invoices";
            this.chkShowAllInv.UseVisualStyleBackColor = true;
            this.chkShowAllInv.CheckedChanged += new System.EventHandler(this.chkShowAllInv_CheckedChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(876, 118);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(107, 16);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Sub Invoice Type :";
            // 
            // lookUpInvoiceType
            // 
            this.lookUpInvoiceType.Location = new System.Drawing.Point(999, 114);
            this.lookUpInvoiceType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpInvoiceType.Name = "lookUpInvoiceType";
            this.lookUpInvoiceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpInvoiceType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeName", "SubInvTypeName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeID", "SubInvTypeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lookUpInvoiceType.Properties.NullText = "";
            this.lookUpInvoiceType.Size = new System.Drawing.Size(199, 22);
            this.lookUpInvoiceType.TabIndex = 18;
            this.lookUpInvoiceType.EditValueChanged += new System.EventHandler(this.lookUpInvoiceType_EditValueChanged);
            // 
            // btnDirectPrint
            // 
            this.btnDirectPrint.Image = global::MMS.Properties.Resources.printer2;
            this.btnDirectPrint.Location = new System.Drawing.Point(873, 16);
            this.btnDirectPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDirectPrint.Name = "btnDirectPrint";
            this.btnDirectPrint.Size = new System.Drawing.Size(119, 33);
            this.btnDirectPrint.TabIndex = 20;
            this.btnDirectPrint.Text = "Print";
            this.btnDirectPrint.Click += new System.EventHandler(this.btnDirectPrint_Click);
            // 
            // chkSignature
            // 
            this.chkSignature.AutoSize = true;
            this.chkSignature.Location = new System.Drawing.Point(302, 71);
            this.chkSignature.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSignature.Name = "chkSignature";
            this.chkSignature.Size = new System.Drawing.Size(153, 21);
            this.chkSignature.TabIndex = 21;
            this.chkSignature.Text = "Print With Signature";
            this.chkSignature.UseVisualStyleBackColor = true;
            this.chkSignature.CheckedChanged += new System.EventHandler(this.chkSignature_CheckedChanged);
            // 
            // xPrintRentInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 716);
            this.Controls.Add(this.chkSignature);
            this.Controls.Add(this.btnDirectPrint);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lookUpInvoiceType);
            this.Controls.Add(this.chkShowAllInv);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dtMonthYear_2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.dtMonthYear);
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.chkCompany);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnPrintSummary);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cGen_Rent_InvoiceGridControl);
            this.Controls.Add(this.optRent);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "xPrintRentInv";
            this.Text = "Print RENT Invoice ";
            this.Load += new System.EventHandler(this.xPrintRentInv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.optRent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGen_Rent_InvoiceGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subInvoiceTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear_2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthYear_2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpInvoiceType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup optRent;
        private System.Windows.Forms.BindingSource cGen_Rent_InvoiceBindingSource;
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
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.Columns.GridColumn colSubInvTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource subInvoiceTypesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private System.Windows.Forms.BindingSource globalCustomersBindingSource;
        private System.Windows.Forms.BindingSource invoiceBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnPrintSummary;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessYear;
        private DevExpress.XtraEditors.CheckButton chkSelect;
        private DevExpress.XtraEditors.DateEdit dtMonthYear;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtMonthYear_2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.CheckBox chkShowAllInv;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lookUpInvoiceType;
        private DevExpress.XtraEditors.SimpleButton btnDirectPrint;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.CheckBox chkSignature;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}