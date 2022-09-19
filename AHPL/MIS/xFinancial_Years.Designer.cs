namespace MMS.MIS
{
    partial class xFinancial_Years
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
            System.Windows.Forms.Label financial_YearLabel;
            System.Windows.Forms.Label fromDateLabel;
            System.Windows.Forms.Label toDateLabel;
            System.Windows.Forms.Label companyIDLabel;
            System.Windows.Forms.Label locationIDLabel;
            System.Windows.Forms.Label isActiveLabel;
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.financial_YearsGridControl = new DevExpress.XtraGrid.GridControl();
            this.financial_YearsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFinancialYearID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinancial_Year = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookCompany = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookLocation = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.isActiveCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.locationIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.companyIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.financialYear_DetailsGridControl = new DevExpress.XtraGrid.GridControl();
            this.financialYear_DetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFinancialYearDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinancialYearID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonthID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookMonthID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCurrentYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinancial_Years = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fromDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.financial_YearSpinEdit = new DevExpress.XtraEditors.TextEdit();
            this.mISPerformanceDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            financial_YearLabel = new System.Windows.Forms.Label();
            fromDateLabel = new System.Windows.Forms.Label();
            toDateLabel = new System.Windows.Forms.Label();
            companyIDLabel = new System.Windows.Forms.Label();
            locationIDLabel = new System.Windows.Forms.Label();
            isActiveLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.financial_YearsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financial_YearsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isActiveCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialYear_DetailsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialYear_DetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMonthID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financial_YearSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mISPerformanceDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdNew
            // 
            this.cmdNew.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdNew_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdEdit_Click);
            // 
            // cmdFirst
            // 
            this.cmdFirst.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdFirst_Click);
            // 
            // cmdPrev
            // 
            this.cmdPrev.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdPrev_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdNext_Click);
            // 
            // cmdLast
            // 
            this.cmdLast.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdLast_Click);
            // 
            // cmdUndo
            // 
            this.cmdUndo.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdUndo_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Visible = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdRefresh_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdSave_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdClose_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelControl1.LookAndFeel.SkinName = "Caramel";
            this.labelControl1.Text = "Financial Years";
            // 
            // financial_YearLabel
            // 
            financial_YearLabel.AutoSize = true;
            financial_YearLabel.Location = new System.Drawing.Point(54, 32);
            financial_YearLabel.Name = "financial_YearLabel";
            financial_YearLabel.Size = new System.Drawing.Size(77, 13);
            financial_YearLabel.TabIndex = 0;
            financial_YearLabel.Text = "Financial Year:";
            // 
            // fromDateLabel
            // 
            fromDateLabel.AutoSize = true;
            fromDateLabel.Location = new System.Drawing.Point(70, 67);
            fromDateLabel.Name = "fromDateLabel";
            fromDateLabel.Size = new System.Drawing.Size(61, 13);
            fromDateLabel.TabIndex = 2;
            fromDateLabel.Text = "From Date:";
            // 
            // toDateLabel
            // 
            toDateLabel.AutoSize = true;
            toDateLabel.Location = new System.Drawing.Point(257, 67);
            toDateLabel.Name = "toDateLabel";
            toDateLabel.Size = new System.Drawing.Size(49, 13);
            toDateLabel.TabIndex = 4;
            toDateLabel.Text = "To Date:";
            // 
            // companyIDLabel
            // 
            companyIDLabel.AutoSize = true;
            companyIDLabel.Location = new System.Drawing.Point(70, 102);
            companyIDLabel.Name = "companyIDLabel";
            companyIDLabel.Size = new System.Drawing.Size(59, 13);
            companyIDLabel.TabIndex = 7;
            companyIDLabel.Text = "Company :";
            // 
            // locationIDLabel
            // 
            locationIDLabel.AutoSize = true;
            locationIDLabel.Location = new System.Drawing.Point(251, 102);
            locationIDLabel.Name = "locationIDLabel";
            locationIDLabel.Size = new System.Drawing.Size(54, 13);
            locationIDLabel.TabIndex = 9;
            locationIDLabel.Text = "Location :";
            // 
            // isActiveLabel
            // 
            isActiveLabel.AutoSize = true;
            isActiveLabel.Location = new System.Drawing.Point(445, 66);
            isActiveLabel.Name = "isActiveLabel";
            isActiveLabel.Size = new System.Drawing.Size(53, 13);
            isActiveLabel.TabIndex = 11;
            isActiveLabel.Text = "Is Active:";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 51);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel1.Controls.Add(this.financial_YearsGridControl);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "List of Financial Year";
            this.splitContainerControl1.Panel2.Controls.Add(isActiveLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.isActiveCheckEdit);
            this.splitContainerControl1.Panel2.Controls.Add(locationIDLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.locationIDLookUpEdit);
            this.splitContainerControl1.Panel2.Controls.Add(companyIDLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.companyIDLookUpEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.financialYear_DetailsGridControl);
            this.splitContainerControl1.Panel2.Controls.Add(toDateLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.toDateDateEdit);
            this.splitContainerControl1.Panel2.Controls.Add(fromDateLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.fromDateDateEdit);
            this.splitContainerControl1.Panel2.Controls.Add(financial_YearLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.financial_YearSpinEdit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(932, 385);
            this.splitContainerControl1.SplitterPosition = 370;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // financial_YearsGridControl
            // 
            this.financial_YearsGridControl.CausesValidation = false;
            this.financial_YearsGridControl.DataSource = this.financial_YearsBindingSource;
            this.financial_YearsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.financial_YearsGridControl.Location = new System.Drawing.Point(0, 0);
            this.financial_YearsGridControl.MainView = this.gridView1;
            this.financial_YearsGridControl.Name = "financial_YearsGridControl";
            this.financial_YearsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookLocation,
            this.lookCompany});
            this.financial_YearsGridControl.Size = new System.Drawing.Size(366, 362);
            this.financial_YearsGridControl.TabIndex = 0;
            this.financial_YearsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // financial_YearsBindingSource
            // 
            this.financial_YearsBindingSource.DataSource = typeof(DataTier.Financial_Years);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFinancialYearID,
            this.colFromDate,
            this.colToDate,
            this.colFinancial_Year,
            this.colCompanyID,
            this.colIsActive,
            this.colLocationID});
            this.gridView1.GridControl = this.financial_YearsGridControl;
            this.gridView1.GroupCount = 2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCompanyID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLocationID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colFinancialYearID
            // 
            this.colFinancialYearID.FieldName = "FinancialYearID";
            this.colFinancialYearID.Name = "colFinancialYearID";
            // 
            // colFromDate
            // 
            this.colFromDate.Caption = "From";
            this.colFromDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colFromDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFromDate.FieldName = "FromDate";
            this.colFromDate.Name = "colFromDate";
            this.colFromDate.Visible = true;
            this.colFromDate.VisibleIndex = 1;
            // 
            // colToDate
            // 
            this.colToDate.Caption = "To";
            this.colToDate.DisplayFormat.FormatString = "d";
            this.colToDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colToDate.FieldName = "ToDate";
            this.colToDate.Name = "colToDate";
            this.colToDate.Visible = true;
            this.colToDate.VisibleIndex = 2;
            // 
            // colFinancial_Year
            // 
            this.colFinancial_Year.Caption = "Year";
            this.colFinancial_Year.FieldName = "Financial_Year";
            this.colFinancial_Year.Name = "colFinancial_Year";
            this.colFinancial_Year.Visible = true;
            this.colFinancial_Year.VisibleIndex = 0;
            this.colFinancial_Year.Width = 120;
            // 
            // colCompanyID
            // 
            this.colCompanyID.Caption = "Company";
            this.colCompanyID.ColumnEdit = this.lookCompany;
            this.colCompanyID.FieldName = "CompanyID";
            this.colCompanyID.Name = "colCompanyID";
            this.colCompanyID.Visible = true;
            this.colCompanyID.VisibleIndex = 3;
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
            // colIsActive
            // 
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 3;
            this.colIsActive.Width = 56;
            // 
            // colLocationID
            // 
            this.colLocationID.Caption = "Location";
            this.colLocationID.ColumnEdit = this.lookLocation;
            this.colLocationID.FieldName = "LocationID";
            this.colLocationID.Name = "colLocationID";
            this.colLocationID.Visible = true;
            this.colLocationID.VisibleIndex = 4;
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
            // isActiveCheckEdit
            // 
            this.isActiveCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.financial_YearsBindingSource, "IsActive", true));
            this.isActiveCheckEdit.Location = new System.Drawing.Point(504, 63);
            this.isActiveCheckEdit.Name = "isActiveCheckEdit";
            this.isActiveCheckEdit.Properties.Caption = "";
            this.isActiveCheckEdit.Size = new System.Drawing.Size(35, 19);
            this.isActiveCheckEdit.TabIndex = 12;
            // 
            // locationIDLookUpEdit
            // 
            this.locationIDLookUpEdit.CausesValidation = false;
            this.locationIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.financial_YearsBindingSource, "LocationID", true));
            this.locationIDLookUpEdit.Location = new System.Drawing.Point(312, 98);
            this.locationIDLookUpEdit.Name = "locationIDLookUpEdit";
            this.locationIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.locationIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.locationIDLookUpEdit.Properties.NullText = "";
            this.locationIDLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.locationIDLookUpEdit.TabIndex = 10;
            this.locationIDLookUpEdit.EditValueChanged += new System.EventHandler(this.locationIDLookUpEdit_EditValueChanged);
            // 
            // companyIDLookUpEdit
            // 
            this.companyIDLookUpEdit.CausesValidation = false;
            this.companyIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.financial_YearsBindingSource, "CompanyID", true));
            this.companyIDLookUpEdit.Location = new System.Drawing.Point(137, 98);
            this.companyIDLookUpEdit.Name = "companyIDLookUpEdit";
            this.companyIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.companyIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.companyIDLookUpEdit.Properties.NullText = "";
            this.companyIDLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.companyIDLookUpEdit.TabIndex = 8;
            this.companyIDLookUpEdit.EditValueChanged += new System.EventHandler(this.companyIDLookUpEdit_EditValueChanged);
            // 
            // financialYear_DetailsGridControl
            // 
            this.financialYear_DetailsGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.financialYear_DetailsGridControl.CausesValidation = false;
            this.financialYear_DetailsGridControl.DataSource = this.financialYear_DetailsBindingSource;
            this.financialYear_DetailsGridControl.Location = new System.Drawing.Point(10, 187);
            this.financialYear_DetailsGridControl.MainView = this.gridView2;
            this.financialYear_DetailsGridControl.Name = "financialYear_DetailsGridControl";
            this.financialYear_DetailsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookMonthID});
            this.financialYear_DetailsGridControl.Size = new System.Drawing.Size(532, 186);
            this.financialYear_DetailsGridControl.TabIndex = 6;
            this.financialYear_DetailsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // financialYear_DetailsBindingSource
            // 
            this.financialYear_DetailsBindingSource.DataMember = "FinancialYear_Details";
            this.financialYear_DetailsBindingSource.DataSource = this.financial_YearsBindingSource;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFinancialYearDetailID,
            this.colFinancialYearID1,
            this.colMonthID,
            this.colCurrentYear,
            this.colFinancial_Years});
            this.gridView2.GridControl = this.financialYear_DetailsGridControl;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowViewCaption = true;
            this.gridView2.ViewCaption = "Month / Year";
            // 
            // colFinancialYearDetailID
            // 
            this.colFinancialYearDetailID.FieldName = "FinancialYearDetailID";
            this.colFinancialYearDetailID.Name = "colFinancialYearDetailID";
            // 
            // colFinancialYearID1
            // 
            this.colFinancialYearID1.FieldName = "FinancialYearID";
            this.colFinancialYearID1.Name = "colFinancialYearID1";
            // 
            // colMonthID
            // 
            this.colMonthID.Caption = "Month";
            this.colMonthID.ColumnEdit = this.lookMonthID;
            this.colMonthID.FieldName = "MonthID";
            this.colMonthID.Name = "colMonthID";
            this.colMonthID.Visible = true;
            this.colMonthID.VisibleIndex = 0;
            this.colMonthID.Width = 108;
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
            this.colCurrentYear.Visible = true;
            this.colCurrentYear.VisibleIndex = 1;
            this.colCurrentYear.Width = 107;
            // 
            // colFinancial_Years
            // 
            this.colFinancial_Years.FieldName = "Financial_Years";
            this.colFinancial_Years.Name = "colFinancial_Years";
            // 
            // toDateDateEdit
            // 
            this.toDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.financial_YearsBindingSource, "ToDate", true));
            this.toDateDateEdit.EditValue = null;
            this.toDateDateEdit.Location = new System.Drawing.Point(312, 63);
            this.toDateDateEdit.Name = "toDateDateEdit";
            this.toDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.toDateDateEdit.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.toDateDateEdit.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.toDateDateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.toDateDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toDateDateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.toDateDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toDateDateEdit.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.toDateDateEdit.Size = new System.Drawing.Size(100, 20);
            this.toDateDateEdit.TabIndex = 5;
            this.toDateDateEdit.EditValueChanged += new System.EventHandler(this.toDateDateEdit_EditValueChanged);
            // 
            // fromDateDateEdit
            // 
            this.fromDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.financial_YearsBindingSource, "FromDate", true));
            this.fromDateDateEdit.EditValue = null;
            this.fromDateDateEdit.Location = new System.Drawing.Point(137, 63);
            this.fromDateDateEdit.Name = "fromDateDateEdit";
            this.fromDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fromDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fromDateDateEdit.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.fromDateDateEdit.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.fromDateDateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.fromDateDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromDateDateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.fromDateDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromDateDateEdit.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.fromDateDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fromDateDateEdit.TabIndex = 3;
            this.fromDateDateEdit.EditValueChanged += new System.EventHandler(this.fromDateDateEdit_EditValueChanged);
            // 
            // financial_YearSpinEdit
            // 
            this.financial_YearSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.financial_YearsBindingSource, "Financial_Year", true));
            this.financial_YearSpinEdit.EditValue = "";
            this.financial_YearSpinEdit.Location = new System.Drawing.Point(137, 29);
            this.financial_YearSpinEdit.Name = "financial_YearSpinEdit";
            this.financial_YearSpinEdit.Properties.DisplayFormat.FormatString = "f0";
            this.financial_YearSpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.financial_YearSpinEdit.Properties.EditFormat.FormatString = "f0";
            this.financial_YearSpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.financial_YearSpinEdit.Properties.Mask.EditMask = "f0";
            this.financial_YearSpinEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.financial_YearSpinEdit.Size = new System.Drawing.Size(100, 20);
            this.financial_YearSpinEdit.TabIndex = 1;
            this.financial_YearSpinEdit.EditValueChanged += new System.EventHandler(this.financial_YearSpinEdit_EditValueChanged);
            // 
            // mISPerformanceDetailsBindingSource
            // 
            this.mISPerformanceDetailsBindingSource.DataMember = "MISPerformanceDetails";
            this.mISPerformanceDetailsBindingSource.DataSource = this.financialYear_DetailsBindingSource;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // xFinancial_Years
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(932, 436);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "xFinancial_Years";
            this.Text = "Financial Years";
            this.Load += new System.EventHandler(this.xFinancial_Years_Load);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.financial_YearsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financial_YearsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isActiveCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialYear_DetailsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialYear_DetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMonthID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financial_YearSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mISPerformanceDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl financial_YearsGridControl;
        private System.Windows.Forms.BindingSource financial_YearsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialYearID;
        private DevExpress.XtraGrid.Columns.GridColumn colFromDate;
        private DevExpress.XtraGrid.Columns.GridColumn colToDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancial_Year;
        private DevExpress.XtraEditors.DateEdit toDateDateEdit;
        private DevExpress.XtraEditors.DateEdit fromDateDateEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraGrid.GridControl financialYear_DetailsGridControl;
        private System.Windows.Forms.BindingSource financialYear_DetailsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialYearDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialYearID1;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookMonthID;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentYear;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancial_Years;
        private DevExpress.XtraEditors.TextEdit financial_YearSpinEdit;
        private System.Windows.Forms.BindingSource mISPerformanceDetailsBindingSource;
        private DevExpress.XtraEditors.LookUpEdit locationIDLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit companyIDLookUpEdit;
        private DevExpress.XtraEditors.CheckEdit isActiveCheckEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookLocation;
    }
}
