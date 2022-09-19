namespace MMS
{
    partial class xContractPromotionExpiry_Ageing
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colAgeGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkCompany = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.cContract_AgeingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cContract_AgeingGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colLevelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.floorLevelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.globalCustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCommencedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLapsDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dateEditDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_AgeingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_AgeingGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorLevelsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colAgeGroup
            // 
            this.colAgeGroup.FieldName = "AgeGroup";
            this.colAgeGroup.Name = "colAgeGroup";
            this.colAgeGroup.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colExpiryDate
            // 
            this.colExpiryDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colExpiryDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colExpiryDate.FieldName = "ExpiryDate";
            this.colExpiryDate.Name = "colExpiryDate";
            this.colExpiryDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colExpiryDate.Visible = true;
            this.colExpiryDate.VisibleIndex = 7;
            this.colExpiryDate.Width = 84;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkCompany);
            this.groupControl1.Location = new System.Drawing.Point(12, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(574, 63);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Company";
            // 
            // chkCompany
            // 
            this.chkCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCompany.Location = new System.Drawing.Point(14, 29);
            this.chkCompany.Name = "chkCompany";
            this.chkCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkCompany.Size = new System.Drawing.Size(548, 20);
            this.chkCompany.TabIndex = 0;
            this.chkCompany.EditValueChanged += new System.EventHandler(this.chkCompany_EditValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(1041, 564);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 31);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::MMS.Properties.Resources.printer1;
            this.btnPrint.Location = new System.Drawing.Point(945, 564);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 32);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cContract_AgeingBindingSource
            // 
            this.cContract_AgeingBindingSource.DataSource = typeof(DataTier.cContract_Ageing);
            // 
            // cContract_AgeingGridControl
            // 
            this.cContract_AgeingGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cContract_AgeingGridControl.DataSource = this.cContract_AgeingBindingSource;
            this.cContract_AgeingGridControl.Location = new System.Drawing.Point(12, 93);
            this.cContract_AgeingGridControl.MainView = this.gridView1;
            this.cContract_AgeingGridControl.Name = "cContract_AgeingGridControl";
            this.cContract_AgeingGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit3,
            this.repositoryItemLookUpEdit4});
            this.cContract_AgeingGridControl.Size = new System.Drawing.Size(1115, 464);
            this.cContract_AgeingGridControl.TabIndex = 5;
            this.cContract_AgeingGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCompanyID,
            this.gridColumn1,
            this.colLocationID,
            this.colLevelID,
            this.colCustomerID,
            this.colCommencedDate,
            this.colExpiryDate,
            this.colLapsDays,
            this.colAgeGroup,
            this.colAgeName});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            styleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Black;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colAgeGroup;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = ((short)(1));
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            styleFormatCondition2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Black;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colAgeGroup;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = ((short)(2));
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            styleFormatCondition3.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            styleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.Black;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.Appearance.Options.UseForeColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.colAgeGroup;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = ((short)(3));
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            styleFormatCondition4.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            styleFormatCondition4.Appearance.ForeColor = System.Drawing.Color.Black;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.Appearance.Options.UseForeColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Column = this.colAgeGroup;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition4.Value1 = ((short)(4));
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4});
            this.gridView1.GridControl = this.cContract_AgeingGridControl;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "AgeGroup", this.colAgeName, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colCompanyID
            // 
            this.colCompanyID.Caption = "Company";
            this.colCompanyID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colCompanyID.FieldName = "CompanyID";
            this.colCompanyID.Name = "colCompanyID";
            this.colCompanyID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCompanyID.Visible = true;
            this.colCompanyID.VisibleIndex = 2;
            this.colCompanyID.Width = 140;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "Company ID", 82, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "Company Code", 83, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Company Name", 85, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit1.DataSource = this.companyBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "CompanyCode";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "CompanyID";
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(DataTier.Company);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Contract Name";
            this.gridColumn1.FieldName = "ContractClosureName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 206;
            // 
            // colLocationID
            // 
            this.colLocationID.Caption = "Location";
            this.colLocationID.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colLocationID.FieldName = "LocationID";
            this.colLocationID.Name = "colLocationID";
            this.colLocationID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colLocationID.Visible = true;
            this.colLocationID.VisibleIndex = 3;
            this.colLocationID.Width = 132;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Location ID", 77, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationName", "Location Name", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Address", 49, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "Location Code", 78, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Logo", "Logo", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoicePrefix", "Invoice Prefix", 76, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SCperSqFt", "SCper Sq Ft", 67, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far)});
            this.repositoryItemLookUpEdit2.DataSource = this.locationBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "LocationCode";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.ValueMember = "LocationID";
            // 
            // locationBindingSource
            // 
            this.locationBindingSource.DataSource = typeof(DataTier.Location);
            // 
            // colLevelID
            // 
            this.colLevelID.Caption = "Level";
            this.colLevelID.ColumnEdit = this.repositoryItemLookUpEdit3;
            this.colLevelID.FieldName = "LevelID";
            this.colLevelID.Name = "colLevelID";
            this.colLevelID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colLevelID.Visible = true;
            this.colLevelID.VisibleIndex = 4;
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.DataSource = this.floorLevelsBindingSource;
            this.repositoryItemLookUpEdit3.DisplayMember = "LevelName";
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            this.repositoryItemLookUpEdit3.NullText = "";
            this.repositoryItemLookUpEdit3.ValueMember = "LevelID";
            // 
            // floorLevelsBindingSource
            // 
            this.floorLevelsBindingSource.DataSource = typeof(DataTier.Floor_Levels);
            // 
            // colCustomerID
            // 
            this.colCustomerID.Caption = "Customer";
            this.colCustomerID.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.colCustomerID.FieldName = "CustomerID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCustomerID.Visible = true;
            this.colCustomerID.VisibleIndex = 5;
            this.colCustomerID.Width = 208;
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
            // globalCustomersBindingSource
            // 
            this.globalCustomersBindingSource.DataSource = typeof(DataTier.Global_Customers);
            // 
            // colCommencedDate
            // 
            this.colCommencedDate.Caption = "Com.Date";
            this.colCommencedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colCommencedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCommencedDate.FieldName = "CommencedDate";
            this.colCommencedDate.Name = "colCommencedDate";
            this.colCommencedDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCommencedDate.Visible = true;
            this.colCommencedDate.VisibleIndex = 6;
            this.colCommencedDate.Width = 85;
            // 
            // colLapsDays
            // 
            this.colLapsDays.DisplayFormat.FormatString = "n0";
            this.colLapsDays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLapsDays.FieldName = "LapsDays";
            this.colLapsDays.Name = "colLapsDays";
            this.colLapsDays.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colLapsDays.Visible = true;
            this.colLapsDays.VisibleIndex = 8;
            // 
            // colAgeName
            // 
            this.colAgeName.FieldName = "AgeName";
            this.colAgeName.Name = "colAgeName";
            this.colAgeName.Visible = true;
            this.colAgeName.VisibleIndex = 0;
            this.colAgeName.Width = 92;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dateEditDate);
            this.groupControl2.Location = new System.Drawing.Point(592, 24);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(154, 63);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Date";
            // 
            // dateEditDate
            // 
            this.dateEditDate.EditValue = null;
            this.dateEditDate.Location = new System.Drawing.Point(23, 29);
            this.dateEditDate.Name = "dateEditDate";
            this.dateEditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEditDate.Size = new System.Drawing.Size(113, 20);
            this.dateEditDate.TabIndex = 0;
            this.dateEditDate.EditValueChanged += new System.EventHandler(this.dateEditDate_EditValueChanged);
            // 
            // xContractPromotionExpiry_Ageing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 610);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.cContract_AgeingGridControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupControl1);
            this.MinimumSize = new System.Drawing.Size(473, 278);
            this.Name = "xContractPromotionExpiry_Ageing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promotion Contract Expiry Ageing-Report";
            this.Load += new System.EventHandler(this.xContractExpiry_Ageing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_AgeingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_AgeingGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorLevelsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkCompany;
        private System.Windows.Forms.BindingSource cContract_AgeingBindingSource;
        private DevExpress.XtraGrid.GridControl cContract_AgeingGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelID;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn colCommencedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLapsDays;
        private DevExpress.XtraGrid.Columns.GridColumn colAgeGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colAgeName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private System.Windows.Forms.BindingSource floorLevelsBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private System.Windows.Forms.BindingSource globalCustomersBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        protected DevExpress.XtraEditors.GroupControl groupControl2;
        protected DevExpress.XtraEditors.DateEdit dateEditDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;

    }
}