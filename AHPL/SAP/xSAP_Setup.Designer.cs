namespace MMS
{
    partial class xSAP_Setup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xSAP_Setup));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlDocType = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvTypeCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colInvPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colGLCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostCenter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfitCenter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlTaxGL = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTaxID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaxCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGLCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlLineItem = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStdOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubInvTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubInvTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerLineItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colGLLineItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditCompany = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaxGL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLineItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCompany.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 67);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(830, 285);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControlDocType);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(824, 257);
            this.xtraTabPage1.Text = "Doc Types";
            // 
            // gridControlDocType
            // 
            this.gridControlDocType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlDocType.Location = new System.Drawing.Point(18, 15);
            this.gridControlDocType.MainView = this.gridView1;
            this.gridControlDocType.Name = "gridControlDocType";
            this.gridControlDocType.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemLookUpEdit1});
            this.gridControlDocType.Size = new System.Drawing.Size(790, 225);
            this.gridControlDocType.TabIndex = 0;
            this.gridControlDocType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocID,
            this.colInvoiceTypeID,
            this.colInvoiceType,
            this.colInvTypeCategory,
            this.colDocType,
            this.colInvPrefix,
            this.colCompanyID,
            this.colGLCode1,
            this.colCostCenter,
            this.colProfitCenter});
            this.gridView1.GridControl = this.gridControlDocType;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colDocID
            // 
            this.colDocID.Caption = "DocID";
            this.colDocID.FieldName = "DocID";
            this.colDocID.Name = "colDocID";
            this.colDocID.OptionsColumn.AllowEdit = false;
            this.colDocID.OptionsColumn.AllowFocus = false;
            this.colDocID.OptionsColumn.ReadOnly = true;
            this.colDocID.OptionsColumn.TabStop = false;
            // 
            // colInvoiceTypeID
            // 
            this.colInvoiceTypeID.Caption = "InvoiceTypeID";
            this.colInvoiceTypeID.FieldName = "InvoiceTypeID";
            this.colInvoiceTypeID.Name = "colInvoiceTypeID";
            this.colInvoiceTypeID.OptionsColumn.AllowEdit = false;
            this.colInvoiceTypeID.OptionsColumn.AllowFocus = false;
            this.colInvoiceTypeID.OptionsColumn.ReadOnly = true;
            this.colInvoiceTypeID.OptionsColumn.TabStop = false;
            // 
            // colInvoiceType
            // 
            this.colInvoiceType.Caption = "InvoiceType";
            this.colInvoiceType.FieldName = "InvoiceType";
            this.colInvoiceType.Name = "colInvoiceType";
            this.colInvoiceType.OptionsColumn.AllowEdit = false;
            this.colInvoiceType.OptionsColumn.AllowFocus = false;
            this.colInvoiceType.OptionsColumn.ReadOnly = true;
            this.colInvoiceType.OptionsColumn.TabStop = false;
            this.colInvoiceType.Visible = true;
            this.colInvoiceType.VisibleIndex = 2;
            this.colInvoiceType.Width = 151;
            // 
            // colInvTypeCategory
            // 
            this.colInvTypeCategory.Caption = "Inoice Type Category";
            this.colInvTypeCategory.FieldName = "InvTypeCategory";
            this.colInvTypeCategory.Name = "colInvTypeCategory";
            this.colInvTypeCategory.OptionsColumn.AllowEdit = false;
            this.colInvTypeCategory.OptionsColumn.AllowFocus = false;
            this.colInvTypeCategory.OptionsColumn.ReadOnly = true;
            this.colInvTypeCategory.OptionsColumn.TabStop = false;
            this.colInvTypeCategory.Visible = true;
            this.colInvTypeCategory.VisibleIndex = 1;
            this.colInvTypeCategory.Width = 170;
            // 
            // colDocType
            // 
            this.colDocType.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDocType.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colDocType.AppearanceCell.Options.UseFont = true;
            this.colDocType.AppearanceCell.Options.UseForeColor = true;
            this.colDocType.Caption = "SAP Doc.Type";
            this.colDocType.ColumnEdit = this.repositoryItemTextEdit1;
            this.colDocType.FieldName = "DocType";
            this.colDocType.Name = "colDocType";
            this.colDocType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDocType.Visible = true;
            this.colDocType.VisibleIndex = 4;
            this.colDocType.Width = 215;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.repositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.repositoryItemTextEdit1.MaxLength = 10;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // colInvPrefix
            // 
            this.colInvPrefix.Caption = "Invoice Prefix";
            this.colInvPrefix.FieldName = "InvoicePrefix";
            this.colInvPrefix.Name = "colInvPrefix";
            this.colInvPrefix.OptionsColumn.AllowEdit = false;
            this.colInvPrefix.OptionsColumn.AllowFocus = false;
            this.colInvPrefix.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvPrefix.OptionsColumn.ReadOnly = true;
            this.colInvPrefix.OptionsColumn.TabStop = false;
            this.colInvPrefix.Visible = true;
            this.colInvPrefix.VisibleIndex = 3;
            this.colInvPrefix.Width = 171;
            // 
            // colCompanyID
            // 
            this.colCompanyID.Caption = "Company";
            this.colCompanyID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colCompanyID.FieldName = "CompID";
            this.colCompanyID.Name = "colCompanyID";
            this.colCompanyID.OptionsColumn.AllowEdit = false;
            this.colCompanyID.OptionsColumn.AllowFocus = false;
            this.colCompanyID.OptionsColumn.FixedWidth = true;
            this.colCompanyID.OptionsColumn.ReadOnly = true;
            this.colCompanyID.OptionsColumn.TabStop = false;
            this.colCompanyID.Visible = true;
            this.colCompanyID.VisibleIndex = 0;
            this.colCompanyID.Width = 108;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "Company ID", 82, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "Company Code", 83, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Company Name", 85, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Location ID", 64, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DefaultTaxID", "Default Tax ID", 80, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DefaultTaxRegNo", "Default Tax Reg No", 104, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Address", 49, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoiceFooterText1", "Invoice Footer Text1", 111, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BusinessRegNo", "Business Reg No", 89, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoiceFooterText2", "Invoice Footer Text2", 111, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Company_Taxes", "Company_Taxes", 90, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
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
            // colGLCode1
            // 
            this.colGLCode1.Caption = "GL Code (Income Acc)";
            this.colGLCode1.FieldName = "GL_Code";
            this.colGLCode1.Name = "colGLCode1";
            this.colGLCode1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colGLCode1.Visible = true;
            this.colGLCode1.VisibleIndex = 5;
            this.colGLCode1.Width = 365;
            // 
            // colCostCenter
            // 
            this.colCostCenter.Caption = "Cost Center";
            this.colCostCenter.FieldName = "CostCenter";
            this.colCostCenter.Name = "colCostCenter";
            this.colCostCenter.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCostCenter.Visible = true;
            this.colCostCenter.VisibleIndex = 6;
            // 
            // colProfitCenter
            // 
            this.colProfitCenter.Caption = "Profit Center";
            this.colProfitCenter.FieldName = "ProfitCenter";
            this.colProfitCenter.Name = "colProfitCenter";
            this.colProfitCenter.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colProfitCenter.Visible = true;
            this.colProfitCenter.VisibleIndex = 7;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControlTaxGL);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(824, 257);
            this.xtraTabPage2.Text = "Tax - GL Codes";
            // 
            // gridControlTaxGL
            // 
            this.gridControlTaxGL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlTaxGL.Location = new System.Drawing.Point(16, 18);
            this.gridControlTaxGL.MainView = this.gridView2;
            this.gridControlTaxGL.Name = "gridControlTaxGL";
            this.gridControlTaxGL.Size = new System.Drawing.Size(621, 207);
            this.gridControlTaxGL.TabIndex = 0;
            this.gridControlTaxGL.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTaxID,
            this.TaxCode,
            this.colGLCode});
            this.gridView2.GridControl = this.gridControlTaxGL;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colTaxID
            // 
            this.colTaxID.Caption = "Tax ID";
            this.colTaxID.FieldName = "TaxID";
            this.colTaxID.Name = "colTaxID";
            this.colTaxID.OptionsColumn.AllowEdit = false;
            this.colTaxID.OptionsColumn.AllowFocus = false;
            this.colTaxID.OptionsColumn.ReadOnly = true;
            this.colTaxID.OptionsColumn.TabStop = false;
            // 
            // TaxCode
            // 
            this.TaxCode.Caption = "Tax Code";
            this.TaxCode.FieldName = "TaxCode";
            this.TaxCode.Name = "TaxCode";
            this.TaxCode.OptionsColumn.AllowEdit = false;
            this.TaxCode.OptionsColumn.AllowFocus = false;
            this.TaxCode.OptionsColumn.ReadOnly = true;
            this.TaxCode.OptionsColumn.TabStop = false;
            this.TaxCode.Visible = true;
            this.TaxCode.VisibleIndex = 0;
            this.TaxCode.Width = 535;
            // 
            // colGLCode
            // 
            this.colGLCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colGLCode.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colGLCode.AppearanceCell.Options.HighPriority = true;
            this.colGLCode.AppearanceCell.Options.UseFont = true;
            this.colGLCode.AppearanceCell.Options.UseForeColor = true;
            this.colGLCode.Caption = "SAP GL Code";
            this.colGLCode.FieldName = "GL_Code";
            this.colGLCode.Name = "colGLCode";
            this.colGLCode.Visible = true;
            this.colGLCode.VisibleIndex = 1;
            this.colGLCode.Width = 645;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.gridControlLineItem);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(824, 257);
            this.xtraTabPage3.Text = "Line Item Codes";
            // 
            // gridControlLineItem
            // 
            this.gridControlLineItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlLineItem.Location = new System.Drawing.Point(13, 25);
            this.gridControlLineItem.MainView = this.gridView3;
            this.gridControlLineItem.Name = "gridControlLineItem";
            this.gridControlLineItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3});
            this.gridControlLineItem.Size = new System.Drawing.Size(625, 246);
            this.gridControlLineItem.TabIndex = 0;
            this.gridControlLineItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStdOrder,
            this.colSubInvTypeID,
            this.colSubInvTypeName,
            this.colCustomerLineItem,
            this.colGLLineItem});
            this.gridView3.GridControl = this.gridControlLineItem;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // colStdOrder
            // 
            this.colStdOrder.Caption = "Std.Order";
            this.colStdOrder.FieldName = "StdOrder";
            this.colStdOrder.Name = "colStdOrder";
            // 
            // colSubInvTypeID
            // 
            this.colSubInvTypeID.Caption = "SubInvTypeID";
            this.colSubInvTypeID.FieldName = "SubInvTypeID";
            this.colSubInvTypeID.Name = "colSubInvTypeID";
            // 
            // colSubInvTypeName
            // 
            this.colSubInvTypeName.Caption = "Invoice Type";
            this.colSubInvTypeName.FieldName = "SubInvTypeName";
            this.colSubInvTypeName.Name = "colSubInvTypeName";
            this.colSubInvTypeName.OptionsColumn.AllowEdit = false;
            this.colSubInvTypeName.OptionsColumn.ReadOnly = true;
            this.colSubInvTypeName.OptionsColumn.TabStop = false;
            this.colSubInvTypeName.Visible = true;
            this.colSubInvTypeName.VisibleIndex = 0;
            // 
            // colCustomerLineItem
            // 
            this.colCustomerLineItem.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerLineItem.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colCustomerLineItem.AppearanceCell.Options.HighPriority = true;
            this.colCustomerLineItem.AppearanceCell.Options.UseFont = true;
            this.colCustomerLineItem.AppearanceCell.Options.UseForeColor = true;
            this.colCustomerLineItem.Caption = "Customer Line Item Code";
            this.colCustomerLineItem.ColumnEdit = this.repositoryItemTextEdit2;
            this.colCustomerLineItem.FieldName = "CustomerLineItem";
            this.colCustomerLineItem.Name = "colCustomerLineItem";
            this.colCustomerLineItem.Visible = true;
            this.colCustomerLineItem.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.repositoryItemTextEdit2.MaxLength = 10;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // colGLLineItem
            // 
            this.colGLLineItem.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colGLLineItem.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colGLLineItem.AppearanceCell.Options.HighPriority = true;
            this.colGLLineItem.AppearanceCell.Options.UseFont = true;
            this.colGLLineItem.AppearanceCell.Options.UseForeColor = true;
            this.colGLLineItem.Caption = "GL Line Item Code";
            this.colGLLineItem.ColumnEdit = this.repositoryItemTextEdit3;
            this.colGLLineItem.FieldName = "GLLineItem";
            this.colGLLineItem.Name = "colGLLineItem";
            this.colGLLineItem.Visible = true;
            this.colGLLineItem.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.repositoryItemTextEdit3.MaxLength = 10;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Image = global::MMS.Properties.Resources.disk_blue1;
            this.btnUpdate.Location = new System.Drawing.Point(679, 358);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(82, 39);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(767, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 39);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Company :";
            // 
            // lookUpEditCompany
            // 
            this.lookUpEditCompany.Location = new System.Drawing.Point(71, 30);
            this.lookUpEditCompany.Name = "lookUpEditCompany";
            this.lookUpEditCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "Company ID", 82, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "Company Code", 83, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Company Name", 85, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Location ID", 64, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DefaultTaxID", "Default Tax ID", 80, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DefaultTaxRegNo", "Default Tax Reg No", 104, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Address", 49, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoiceFooterText1", "Invoice Footer Text1", 111, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BusinessRegNo", "Business Reg No", 89, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoiceFooterText2", "Invoice Footer Text2", 111, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Company_Taxes", "Company_Taxes", 90, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpEditCompany.Properties.DataSource = this.companyBindingSource;
            this.lookUpEditCompany.Properties.DisplayMember = "CompanyCode";
            this.lookUpEditCompany.Properties.NullText = "";
            this.lookUpEditCompany.Properties.ValueMember = "CompanyID";
            this.lookUpEditCompany.Size = new System.Drawing.Size(203, 20);
            this.lookUpEditCompany.TabIndex = 4;
            this.lookUpEditCompany.EditValueChanged += new System.EventHandler(this.lookUpEditCompany_EditValueChanged);
            // 
            // xSAP_Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 409);
            this.Controls.Add(this.lookUpEditCompany);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.xtraTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "xSAP_Setup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAP Upload - Master Setup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.xSAP_Setup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaxGL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLineItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCompany.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gridControlDocType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDocID;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceType;
        private DevExpress.XtraGrid.Columns.GridColumn colInvTypeCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colDocType;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colInvPrefix;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.GridControl gridControlTaxGL;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxID;
        private DevExpress.XtraGrid.Columns.GridColumn TaxCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGLCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl gridControlLineItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colStdOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colSubInvTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colSubInvTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerLineItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colGLLineItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCompany;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colGLCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colCostCenter;
        private DevExpress.XtraGrid.Columns.GridColumn colProfitCenter;
    }
}