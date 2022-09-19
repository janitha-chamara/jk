namespace MMS.MIS
{
    partial class xSalesAndPerformanceDet
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
            System.Windows.Forms.Label companyIDLabel;
            System.Windows.Forms.Label locationIDLabel;
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.locationIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.companyIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.lookMonthYear = new DevExpress.XtraEditors.LookUpEdit();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.performanceDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.performanceDetailsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerformanceDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinancialYearDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSortOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReforecastingValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBudgetValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReforecastingValueYTD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualValueYTD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastYearActualValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBudgetValueYTD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.performanceDetail_OSIncomeGridControl = new DevExpress.XtraGrid.GridControl();
            this.performanceDetail_OSIncomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOtherServiceCategoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookOSCategoryID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRentWithMandatoryTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            companyIDLabel = new System.Windows.Forms.Label();
            locationIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMonthYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceDetailsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.performanceDetail_OSIncomeGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceDetail_OSIncomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookOSCategoryID)).BeginInit();
            this.SuspendLayout();
            // 
            // companyIDLabel
            // 
            companyIDLabel.AutoSize = true;
            companyIDLabel.Location = new System.Drawing.Point(24, 38);
            companyIDLabel.Name = "companyIDLabel";
            companyIDLabel.Size = new System.Drawing.Size(59, 13);
            companyIDLabel.TabIndex = 9;
            companyIDLabel.Text = "Company :";
            // 
            // locationIDLabel
            // 
            locationIDLabel.AutoSize = true;
            locationIDLabel.Location = new System.Drawing.Point(29, 63);
            locationIDLabel.Name = "locationIDLabel";
            locationIDLabel.Size = new System.Drawing.Size(54, 13);
            locationIDLabel.TabIndex = 11;
            locationIDLabel.Text = "Location :";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnPrint);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(locationIDLabel);
            this.groupControl1.Controls.Add(this.locationIDLookUpEdit);
            this.groupControl1.Controls.Add(companyIDLabel);
            this.groupControl1.Controls.Add(this.companyIDLookUpEdit);
            this.groupControl1.Controls.Add(this.lookMonthYear);
            this.groupControl1.Controls.Add(this.btnPreview);
            this.groupControl1.Location = new System.Drawing.Point(13, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(446, 122);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Month ";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::MMS.Properties.Resources.printer2;
            this.btnPrint.Location = new System.Drawing.Point(347, 75);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 31);
            toolTipTitleItem1.Text = "Preview";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "After selecting Company , Location and Month click the Preview button.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnPrint.SuperTip = superToolTip1;
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(46, 89);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Month :";
            // 
            // locationIDLookUpEdit
            // 
            this.locationIDLookUpEdit.CausesValidation = false;
            this.locationIDLookUpEdit.Location = new System.Drawing.Point(91, 60);
            this.locationIDLookUpEdit.Name = "locationIDLookUpEdit";
            this.locationIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.locationIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.locationIDLookUpEdit.Properties.NullText = "";
            this.locationIDLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.locationIDLookUpEdit.TabIndex = 12;
            this.locationIDLookUpEdit.EditValueChanged += new System.EventHandler(this.locationIDLookUpEdit_EditValueChanged);
            // 
            // companyIDLookUpEdit
            // 
            this.companyIDLookUpEdit.CausesValidation = false;
            this.companyIDLookUpEdit.Location = new System.Drawing.Point(91, 34);
            this.companyIDLookUpEdit.Name = "companyIDLookUpEdit";
            this.companyIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.companyIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.companyIDLookUpEdit.Properties.NullText = "";
            this.companyIDLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.companyIDLookUpEdit.TabIndex = 10;
            this.companyIDLookUpEdit.EditValueChanged += new System.EventHandler(this.companyIDLookUpEdit_EditValueChanged);
            // 
            // lookMonthYear
            // 
            this.lookMonthYear.Location = new System.Drawing.Point(91, 86);
            this.lookMonthYear.Name = "lookMonthYear";
            this.lookMonthYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookMonthYear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FinancialYearDetailID", "FinancialYearDetailID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YearMonth", "Month-Year")});
            this.lookMonthYear.Properties.NullText = "";
            this.lookMonthYear.Size = new System.Drawing.Size(153, 20);
            this.lookMonthYear.TabIndex = 1;
            this.lookMonthYear.EditValueChanged += new System.EventHandler(this.lookMonthYear_EditValueChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.Image = global::MMS.Properties.Resources.view;
            this.btnPreview.Location = new System.Drawing.Point(266, 75);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 31);
            toolTipTitleItem2.Text = "Preview";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "After selecting Company , Location and Month click the Preview button.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnPreview.SuperTip = superToolTip2;
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // performanceDetailsBindingSource
            // 
            this.performanceDetailsBindingSource.DataSource = typeof(DataTier.ReportClasses.PerformanceDetails);
            // 
            // performanceDetailsGridControl
            // 
            this.performanceDetailsGridControl.DataSource = this.performanceDetailsBindingSource;
            this.performanceDetailsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.performanceDetailsGridControl.Location = new System.Drawing.Point(0, 0);
            this.performanceDetailsGridControl.MainView = this.gridView1;
            this.performanceDetailsGridControl.Name = "performanceDetailsGridControl";
            this.performanceDetailsGridControl.Size = new System.Drawing.Size(977, 263);
            this.performanceDetailsGridControl.TabIndex = 2;
            this.performanceDetailsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerformanceDetailID,
            this.colFinancialYearDetailID,
            this.colSortOrder,
            this.colReportItemID,
            this.colReportItemName,
            this.colReforecastingValue,
            this.colBudgetValue,
            this.colActualValue,
            this.colReforecastingValueYTD,
            this.colActualValueYTD,
            this.colLastYearActualValue,
            this.colBudgetValueYTD});
            this.gridView1.GridControl = this.performanceDetailsGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSortOrder, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colPerformanceDetailID
            // 
            this.colPerformanceDetailID.FieldName = "PerformanceDetailID";
            this.colPerformanceDetailID.Name = "colPerformanceDetailID";
            this.colPerformanceDetailID.Width = 127;
            // 
            // colFinancialYearDetailID
            // 
            this.colFinancialYearDetailID.FieldName = "FinancialYearDetailID";
            this.colFinancialYearDetailID.Name = "colFinancialYearDetailID";
            this.colFinancialYearDetailID.Width = 132;
            // 
            // colSortOrder
            // 
            this.colSortOrder.FieldName = "SortOrder";
            this.colSortOrder.Name = "colSortOrder";
            // 
            // colReportItemID
            // 
            this.colReportItemID.FieldName = "ReportItemID";
            this.colReportItemID.Name = "colReportItemID";
            this.colReportItemID.Width = 94;
            // 
            // colReportItemName
            // 
            this.colReportItemName.FieldName = "ReportItemName";
            this.colReportItemName.Name = "colReportItemName";
            this.colReportItemName.Visible = true;
            this.colReportItemName.VisibleIndex = 0;
            this.colReportItemName.Width = 110;
            // 
            // colReforecastingValue
            // 
            this.colReforecastingValue.AppearanceCell.BackColor = System.Drawing.Color.Orange;
            this.colReforecastingValue.AppearanceCell.Options.UseBackColor = true;
            this.colReforecastingValue.DisplayFormat.FormatString = "n2";
            this.colReforecastingValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colReforecastingValue.FieldName = "ReforecastingValueM";
            this.colReforecastingValue.Name = "colReforecastingValue";
            this.colReforecastingValue.Visible = true;
            this.colReforecastingValue.VisibleIndex = 1;
            this.colReforecastingValue.Width = 126;
            // 
            // colBudgetValue
            // 
            this.colBudgetValue.DisplayFormat.FormatString = "n2";
            this.colBudgetValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBudgetValue.FieldName = "BudgetValueM";
            this.colBudgetValue.Name = "colBudgetValue";
            this.colBudgetValue.Visible = true;
            this.colBudgetValue.VisibleIndex = 2;
            this.colBudgetValue.Width = 93;
            // 
            // colActualValue
            // 
            this.colActualValue.AppearanceCell.BackColor = System.Drawing.Color.Yellow;
            this.colActualValue.AppearanceCell.Options.UseBackColor = true;
            this.colActualValue.DisplayFormat.FormatString = "n2";
            this.colActualValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colActualValue.FieldName = "ActualValueM";
            this.colActualValue.Name = "colActualValue";
            this.colActualValue.Visible = true;
            this.colActualValue.VisibleIndex = 3;
            this.colActualValue.Width = 89;
            // 
            // colReforecastingValueYTD
            // 
            this.colReforecastingValueYTD.AppearanceCell.BackColor = System.Drawing.Color.Orange;
            this.colReforecastingValueYTD.AppearanceCell.Options.UseBackColor = true;
            this.colReforecastingValueYTD.Caption = "Re-Forecasting (YTD)";
            this.colReforecastingValueYTD.DisplayFormat.FormatString = "n2";
            this.colReforecastingValueYTD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colReforecastingValueYTD.FieldName = "ReforecastingValueYTD";
            this.colReforecastingValueYTD.Name = "colReforecastingValueYTD";
            this.colReforecastingValueYTD.Visible = true;
            this.colReforecastingValueYTD.VisibleIndex = 4;
            this.colReforecastingValueYTD.Width = 122;
            // 
            // colActualValueYTD
            // 
            this.colActualValueYTD.AppearanceCell.BackColor = System.Drawing.Color.Yellow;
            this.colActualValueYTD.AppearanceCell.Options.UseBackColor = true;
            this.colActualValueYTD.DisplayFormat.FormatString = "n2";
            this.colActualValueYTD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colActualValueYTD.FieldName = "ActualValueYTD";
            this.colActualValueYTD.Name = "colActualValueYTD";
            this.colActualValueYTD.Visible = true;
            this.colActualValueYTD.VisibleIndex = 6;
            this.colActualValueYTD.Width = 100;
            // 
            // colLastYearActualValue
            // 
            this.colLastYearActualValue.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen;
            this.colLastYearActualValue.AppearanceCell.Options.UseBackColor = true;
            this.colLastYearActualValue.DisplayFormat.FormatString = "n2";
            this.colLastYearActualValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLastYearActualValue.FieldName = "LastYearActualValue";
            this.colLastYearActualValue.Name = "colLastYearActualValue";
            this.colLastYearActualValue.Visible = true;
            this.colLastYearActualValue.VisibleIndex = 7;
            this.colLastYearActualValue.Width = 126;
            // 
            // colBudgetValueYTD
            // 
            this.colBudgetValueYTD.DisplayFormat.FormatString = "n2";
            this.colBudgetValueYTD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBudgetValueYTD.FieldName = "BudgetValueYTD";
            this.colBudgetValueYTD.Name = "colBudgetValueYTD";
            this.colBudgetValueYTD.Visible = true;
            this.colBudgetValueYTD.VisibleIndex = 5;
            this.colBudgetValueYTD.Width = 104;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 148);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(979, 288);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.performanceDetailsGridControl);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(977, 263);
            this.xtraTabPage1.Text = "Occupancy Detail";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.AutoScroll = true;
            this.xtraTabPage2.Controls.Add(this.performanceDetail_OSIncomeGridControl);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(977, 263);
            this.xtraTabPage2.Text = "Other Service Income";
            // 
            // performanceDetail_OSIncomeGridControl
            // 
            this.performanceDetail_OSIncomeGridControl.DataSource = this.performanceDetail_OSIncomeBindingSource;
            this.performanceDetail_OSIncomeGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.performanceDetail_OSIncomeGridControl.Location = new System.Drawing.Point(0, 0);
            this.performanceDetail_OSIncomeGridControl.MainView = this.gridView2;
            this.performanceDetail_OSIncomeGridControl.Name = "performanceDetail_OSIncomeGridControl";
            this.performanceDetail_OSIncomeGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookOSCategoryID});
            this.performanceDetail_OSIncomeGridControl.Size = new System.Drawing.Size(973, 260);
            this.performanceDetail_OSIncomeGridControl.TabIndex = 0;
            this.performanceDetail_OSIncomeGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // performanceDetail_OSIncomeBindingSource
            // 
            this.performanceDetail_OSIncomeBindingSource.DataSource = typeof(DataTier.ReportClasses.PerformanceDetail_OSIncome);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOtherServiceCategoryID,
            this.colRentWithMandatoryTax});
            this.gridView2.GridControl = this.performanceDetail_OSIncomeGridControl;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colOtherServiceCategoryID
            // 
            this.colOtherServiceCategoryID.Caption = "Other Service Category";
            this.colOtherServiceCategoryID.ColumnEdit = this.lookOSCategoryID;
            this.colOtherServiceCategoryID.FieldName = "OtherServiceCategoryID";
            this.colOtherServiceCategoryID.Name = "colOtherServiceCategoryID";
            this.colOtherServiceCategoryID.Visible = true;
            this.colOtherServiceCategoryID.VisibleIndex = 0;
            this.colOtherServiceCategoryID.Width = 177;
            // 
            // lookOSCategoryID
            // 
            this.lookOSCategoryID.AutoHeight = false;
            this.lookOSCategoryID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookOSCategoryID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OtherServiceID", "OtherServiceID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OtherServiceName", "OtherServiceName")});
            this.lookOSCategoryID.Name = "lookOSCategoryID";
            this.lookOSCategoryID.NullText = "";
            // 
            // colRentWithMandatoryTax
            // 
            this.colRentWithMandatoryTax.Caption = "Rent + Mandatory Tax";
            this.colRentWithMandatoryTax.DisplayFormat.FormatString = "n2";
            this.colRentWithMandatoryTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRentWithMandatoryTax.FieldName = "RentWithMandatoryTax";
            this.colRentWithMandatoryTax.Name = "colRentWithMandatoryTax";
            this.colRentWithMandatoryTax.Visible = true;
            this.colRentWithMandatoryTax.VisibleIndex = 1;
            this.colRentWithMandatoryTax.Width = 169;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(900, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // xSalesAndPerformanceDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 442);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "xSalesAndPerformanceDet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Performance & Sales Occupancy Detail";
            this.Load += new System.EventHandler(this.xSalesAndPerformanceDet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMonthYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceDetailsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.performanceDetail_OSIncomeGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceDetail_OSIncomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookOSCategoryID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.LookUpEdit lookMonthYear;
        private System.Windows.Forms.BindingSource performanceDetailsBindingSource;
        private DevExpress.XtraGrid.GridControl performanceDetailsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPerformanceDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialYearDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn colSortOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colReportItemID;
        private DevExpress.XtraGrid.Columns.GridColumn colReportItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colReforecastingValue;
        private DevExpress.XtraGrid.Columns.GridColumn colBudgetValue;
        private DevExpress.XtraGrid.Columns.GridColumn colActualValue;
        private DevExpress.XtraGrid.Columns.GridColumn colReforecastingValueYTD;
        private DevExpress.XtraGrid.Columns.GridColumn colActualValueYTD;
        private DevExpress.XtraGrid.Columns.GridColumn colLastYearActualValue;
        private DevExpress.XtraEditors.LookUpEdit companyIDLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit locationIDLookUpEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colBudgetValueYTD;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl performanceDetail_OSIncomeGridControl;
        private System.Windows.Forms.BindingSource performanceDetail_OSIncomeBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherServiceCategoryID;
        private DevExpress.XtraGrid.Columns.GridColumn colRentWithMandatoryTax;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookOSCategoryID;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}