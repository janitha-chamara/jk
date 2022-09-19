namespace MMS.MIS
{
    partial class xPerformanceDetails
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.financialYear_DetailsGridControl = new DevExpress.XtraGrid.GridControl();
            this.financialYear_DetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFinancialYearDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinancialYearID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookFinYear = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMonthID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookMonthID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCurrentYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinancial_Years = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookCompany = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookLocation = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.mISPerformanceDetailGridControl = new DevExpress.XtraGrid.GridControl();
            this.mISPerformanceDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerformanceDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinancialYearDetailID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookItemID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colReforecastingValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBudgetValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colActualValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinancialYear_Details = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.financialYear_DetailsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialYear_DetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookFinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMonthID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mISPerformanceDetailGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mISPerformanceDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookItemID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel1.Controls.Add(this.financialYear_DetailsGridControl);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "List of Reforecasting/Budget";
            this.splitContainerControl1.Panel2.Controls.Add(this.mISPerformanceDetailGridControl);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(799, 377);
            this.splitContainerControl1.SplitterPosition = 347;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // financialYear_DetailsGridControl
            // 
            this.financialYear_DetailsGridControl.CausesValidation = false;
            this.financialYear_DetailsGridControl.DataSource = this.financialYear_DetailsBindingSource;
            this.financialYear_DetailsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.financialYear_DetailsGridControl.Location = new System.Drawing.Point(0, 0);
            this.financialYear_DetailsGridControl.MainView = this.gridView1;
            this.financialYear_DetailsGridControl.Name = "financialYear_DetailsGridControl";
            this.financialYear_DetailsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookMonthID,
            this.lookFinYear,
            this.lookCompany,
            this.lookLocation});
            this.financialYear_DetailsGridControl.Size = new System.Drawing.Size(343, 354);
            this.financialYear_DetailsGridControl.TabIndex = 0;
            this.financialYear_DetailsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // financialYear_DetailsBindingSource
            // 
            this.financialYear_DetailsBindingSource.DataSource = typeof(DataTier.FinancialYear_Details);
            this.financialYear_DetailsBindingSource.PositionChanged += new System.EventHandler(this.financialYear_DetailsBindingSource_PositionChanged_1);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFinancialYearDetailID,
            this.colFinancialYearID,
            this.colMonthID,
            this.colCurrentYear,
            this.colFinancial_Years,
            this.colCompanyID,
            this.colLocationID});
            this.gridView1.GridControl = this.financialYear_DetailsGridControl;
            this.gridView1.GroupCount = 3;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCompanyID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLocationID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFinancialYearID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colFinancialYearDetailID
            // 
            this.colFinancialYearDetailID.FieldName = "FinancialYearDetailID";
            this.colFinancialYearDetailID.Name = "colFinancialYearDetailID";
            this.colFinancialYearDetailID.Width = 132;
            // 
            // colFinancialYearID
            // 
            this.colFinancialYearID.Caption = "Financial Year";
            this.colFinancialYearID.ColumnEdit = this.lookFinYear;
            this.colFinancialYearID.FieldName = "FinancialYearID";
            this.colFinancialYearID.Name = "colFinancialYearID";
            this.colFinancialYearID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colFinancialYearID.Visible = true;
            this.colFinancialYearID.VisibleIndex = 0;
            this.colFinancialYearID.Width = 102;
            // 
            // lookFinYear
            // 
            this.lookFinYear.AutoHeight = false;
            this.lookFinYear.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookFinYear.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FinancialYearID", "FinancialYearID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Financial_Year", "Financial_Year")});
            this.lookFinYear.Name = "lookFinYear";
            this.lookFinYear.NullText = "";
            // 
            // colMonthID
            // 
            this.colMonthID.Caption = "Month";
            this.colMonthID.ColumnEdit = this.lookMonthID;
            this.colMonthID.FieldName = "MonthID";
            this.colMonthID.Name = "colMonthID";
            this.colMonthID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colMonthID.Visible = true;
            this.colMonthID.VisibleIndex = 0;
            this.colMonthID.Width = 169;
            // 
            // lookMonthID
            // 
            this.lookMonthID.AutoHeight = false;
            this.lookMonthID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookMonthID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MonthID", "MonthID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MonthCode", "MonthCode")});
            this.lookMonthID.Name = "lookMonthID";
            this.lookMonthID.NullText = "";
            // 
            // colCurrentYear
            // 
            this.colCurrentYear.Caption = "Year";
            this.colCurrentYear.FieldName = "CurrentYear";
            this.colCurrentYear.Name = "colCurrentYear";
            this.colCurrentYear.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCurrentYear.Visible = true;
            this.colCurrentYear.VisibleIndex = 1;
            this.colCurrentYear.Width = 107;
            // 
            // colFinancial_Years
            // 
            this.colFinancial_Years.FieldName = "Financial_Years";
            this.colFinancial_Years.Name = "colFinancial_Years";
            this.colFinancial_Years.Width = 96;
            // 
            // colCompanyID
            // 
            this.colCompanyID.Caption = "Company";
            this.colCompanyID.ColumnEdit = this.lookCompany;
            this.colCompanyID.FieldName = "CompanyID";
            this.colCompanyID.Name = "colCompanyID";
            this.colCompanyID.Visible = true;
            this.colCompanyID.VisibleIndex = 2;
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
            // mISPerformanceDetailGridControl
            // 
            this.mISPerformanceDetailGridControl.DataSource = this.mISPerformanceDetailBindingSource;
            this.mISPerformanceDetailGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mISPerformanceDetailGridControl.Location = new System.Drawing.Point(0, 0);
            this.mISPerformanceDetailGridControl.MainView = this.gridView2;
            this.mISPerformanceDetailGridControl.Name = "mISPerformanceDetailGridControl";
            this.mISPerformanceDetailGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookItemID,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.mISPerformanceDetailGridControl.Size = new System.Drawing.Size(447, 377);
            this.mISPerformanceDetailGridControl.TabIndex = 0;
            this.mISPerformanceDetailGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // mISPerformanceDetailBindingSource
            // 
            this.mISPerformanceDetailBindingSource.DataSource = typeof(DataTier.MISPerformanceDetail);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerformanceDetailID,
            this.colFinancialYearDetailID1,
            this.colReportItemID,
            this.colReforecastingValue,
            this.colBudgetValue,
            this.colActualValue,
            this.colFinancialYear_Details});
            this.gridView2.GridControl = this.mISPerformanceDetailGridControl;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colPerformanceDetailID
            // 
            this.colPerformanceDetailID.FieldName = "PerformanceDetailID";
            this.colPerformanceDetailID.Name = "colPerformanceDetailID";
            this.colPerformanceDetailID.Width = 127;
            // 
            // colFinancialYearDetailID1
            // 
            this.colFinancialYearDetailID1.FieldName = "FinancialYearDetailID";
            this.colFinancialYearDetailID1.Name = "colFinancialYearDetailID1";
            this.colFinancialYearDetailID1.Width = 132;
            // 
            // colReportItemID
            // 
            this.colReportItemID.Caption = "Item";
            this.colReportItemID.ColumnEdit = this.lookItemID;
            this.colReportItemID.FieldName = "ReportItemID";
            this.colReportItemID.Name = "colReportItemID";
            this.colReportItemID.OptionsColumn.AllowEdit = false;
            this.colReportItemID.OptionsColumn.AllowFocus = false;
            this.colReportItemID.OptionsColumn.ReadOnly = true;
            this.colReportItemID.OptionsColumn.TabStop = false;
            this.colReportItemID.Visible = true;
            this.colReportItemID.VisibleIndex = 0;
            this.colReportItemID.Width = 239;
            // 
            // lookItemID
            // 
            this.lookItemID.AutoHeight = false;
            this.lookItemID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookItemID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportItemID", "ReportItemID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportItemName", "ReportItemName")});
            this.lookItemID.Name = "lookItemID";
            this.lookItemID.NullText = "";
            // 
            // colReforecastingValue
            // 
            this.colReforecastingValue.Caption = "Re-Forecasting";
            this.colReforecastingValue.ColumnEdit = this.repositoryItemTextEdit1;
            this.colReforecastingValue.FieldName = "ReforecastingValue";
            this.colReforecastingValue.Name = "colReforecastingValue";
            this.colReforecastingValue.Visible = true;
            this.colReforecastingValue.VisibleIndex = 1;
            this.colReforecastingValue.Width = 118;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n2";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "n2";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "n2";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // colBudgetValue
            // 
            this.colBudgetValue.Caption = "Budget";
            this.colBudgetValue.ColumnEdit = this.repositoryItemTextEdit2;
            this.colBudgetValue.FieldName = "BudgetValue";
            this.colBudgetValue.Name = "colBudgetValue";
            this.colBudgetValue.Visible = true;
            this.colBudgetValue.VisibleIndex = 2;
            this.colBudgetValue.Width = 85;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.DisplayFormat.FormatString = "n2";
            this.repositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.EditFormat.FormatString = "n2";
            this.repositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.Mask.EditMask = "n2";
            this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // colActualValue
            // 
            this.colActualValue.FieldName = "ActualValue";
            this.colActualValue.Name = "colActualValue";
            this.colActualValue.Width = 81;
            // 
            // colFinancialYear_Details
            // 
            this.colFinancialYear_Details.FieldName = "FinancialYear_Details";
            this.colFinancialYear_Details.Name = "colFinancialYear_Details";
            this.colFinancialYear_Details.Width = 126;
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
            this.btnSave,
            this.btnClose});
            this.barManager1.MaxItemId = 9;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar1.Text = "Tools";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Glyph = global::MMS.Properties.Resources.disk_blue;
            this.btnSave.Id = 2;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Glyph = global::MMS.Properties.Resources.folder_into;
            this.btnClose.Id = 3;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(799, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 424);
            this.barDockControlBottom.Size = new System.Drawing.Size(799, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 377);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(799, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 377);
            // 
            // xPerformanceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 424);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xPerformanceDetails";
            this.Text = "Perfomance & Sales - Reforecasting and Budget";
            this.Load += new System.EventHandler(this.xPerformanceDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.financialYear_DetailsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialYear_DetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookFinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMonthID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mISPerformanceDetailGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mISPerformanceDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookItemID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.BindingSource mISPerformanceDetailBindingSource;
        private DevExpress.XtraGrid.GridControl financialYear_DetailsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialYearDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialYearID;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthID;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentYear;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancial_Years;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookMonthID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookFinYear;
        private DevExpress.XtraGrid.GridControl mISPerformanceDetailGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colPerformanceDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialYearDetailID1;
        private DevExpress.XtraGrid.Columns.GridColumn colReportItemID;
        private DevExpress.XtraGrid.Columns.GridColumn colReforecastingValue;
        private DevExpress.XtraGrid.Columns.GridColumn colBudgetValue;
        private DevExpress.XtraGrid.Columns.GridColumn colActualValue;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialYear_Details;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookItemID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private System.Windows.Forms.BindingSource financialYear_DetailsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookCompany;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookLocation;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}