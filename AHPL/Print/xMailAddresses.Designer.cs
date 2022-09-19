namespace MMS.Print
{
    partial class xMailAddresses
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
            this.btnBuild = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.envelopeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.envelopeGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEnvelopeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExtendedCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookCompanyID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookLocationID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colGlobalCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGlobalCustomerID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colAdressee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPostalAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.colDeliveryOptionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboDeliveryOption = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupInvoiceTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLevelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboLevelID = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryOptionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookDeliveryOptionID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.richTextAddress = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboCategory = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.chkSelectAll = new DevExpress.XtraEditors.CheckButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.envelopeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.envelopeGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompanyID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGlobalCustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDeliveryOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupInvoiceTypeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLevelID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookDeliveryOptionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richTextAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompany.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuild
            // 
            this.btnBuild.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBuild.Image = global::MMS.Properties.Resources.dot_chart;
            this.btnBuild.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnBuild.Location = new System.Drawing.Point(14, 18);
            this.btnBuild.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(114, 85);
            this.btnBuild.TabIndex = 0;
            this.btnBuild.Text = "Build Addresses";
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::MMS.Properties.Resources.disk_blue2;
            this.btnSave.Location = new System.Drawing.Point(1158, 18);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 42);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // envelopeBindingSource
            // 
            this.envelopeBindingSource.DataSource = typeof(DataTier.Envelope);
            // 
            // envelopeGridControl
            // 
            this.envelopeGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.envelopeGridControl.DataSource = this.envelopeBindingSource;
            this.envelopeGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.envelopeGridControl.Location = new System.Drawing.Point(14, 128);
            this.envelopeGridControl.MainView = this.gridView1;
            this.envelopeGridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.envelopeGridControl.Name = "envelopeGridControl";
            this.envelopeGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookupInvoiceTypeID,
            this.lookCompanyID,
            this.lookLocationID,
            this.lookGlobalCustomerID,
            this.lookDeliveryOptionID,
            this.richTextAddress,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemLookUpEdit1,
            this.cboDeliveryOption,
            this.cboLevelID});
            this.envelopeGridControl.Size = new System.Drawing.Size(1260, 528);
            this.envelopeGridControl.TabIndex = 3;
            this.envelopeGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEnvelopeID,
            this.colExtendedCustomerID,
            this.colCompanyID,
            this.colLocationID,
            this.colGlobalCustomerID,
            this.colAdressee,
            this.colPostalAddress,
            this.colDeliveryOptionID,
            this.colShopName,
            this.colShopNo,
            this.colIsPrint,
            this.colInvoiceTypeID,
            this.colLevelID,
            this.colCategoryName,
            this.colDeliveryOptionName,
            this.colLevelName});
            this.gridView1.GridControl = this.envelopeGridControl;
            this.gridView1.GroupCount = 2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCompanyID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLocationID, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ViewCaption = "List of Shops";
            // 
            // colEnvelopeID
            // 
            this.colEnvelopeID.FieldName = "EnvelopeID";
            this.colEnvelopeID.Name = "colEnvelopeID";
            // 
            // colExtendedCustomerID
            // 
            this.colExtendedCustomerID.FieldName = "ExtendedCustomerID";
            this.colExtendedCustomerID.Name = "colExtendedCustomerID";
            this.colExtendedCustomerID.Width = 121;
            // 
            // colCompanyID
            // 
            this.colCompanyID.Caption = "Company";
            this.colCompanyID.ColumnEdit = this.lookCompanyID;
            this.colCompanyID.FieldName = "CompanyID";
            this.colCompanyID.Name = "colCompanyID";
            this.colCompanyID.Visible = true;
            this.colCompanyID.VisibleIndex = 1;
            // 
            // lookCompanyID
            // 
            this.lookCompanyID.AutoHeight = false;
            this.lookCompanyID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompanyID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.lookCompanyID.Name = "lookCompanyID";
            this.lookCompanyID.NullText = "";
            // 
            // colLocationID
            // 
            this.colLocationID.Caption = "Location";
            this.colLocationID.ColumnEdit = this.lookLocationID;
            this.colLocationID.FieldName = "LocationID";
            this.colLocationID.Name = "colLocationID";
            this.colLocationID.Visible = true;
            this.colLocationID.VisibleIndex = 1;
            // 
            // lookLocationID
            // 
            this.lookLocationID.AutoHeight = false;
            this.lookLocationID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocationID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.lookLocationID.Name = "lookLocationID";
            this.lookLocationID.NullText = "";
            // 
            // colGlobalCustomerID
            // 
            this.colGlobalCustomerID.Caption = "Customer";
            this.colGlobalCustomerID.ColumnEdit = this.lookGlobalCustomerID;
            this.colGlobalCustomerID.FieldName = "GlobalCustomerID";
            this.colGlobalCustomerID.Name = "colGlobalCustomerID";
            this.colGlobalCustomerID.Visible = true;
            this.colGlobalCustomerID.VisibleIndex = 1;
            this.colGlobalCustomerID.Width = 94;
            // 
            // lookGlobalCustomerID
            // 
            this.lookGlobalCustomerID.AutoHeight = false;
            this.lookGlobalCustomerID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGlobalCustomerID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "CustomerName")});
            this.lookGlobalCustomerID.Name = "lookGlobalCustomerID";
            this.lookGlobalCustomerID.NullText = "";
            // 
            // colAdressee
            // 
            this.colAdressee.AppearanceCell.BackColor = System.Drawing.Color.PaleTurquoise;
            this.colAdressee.AppearanceCell.Options.UseBackColor = true;
            this.colAdressee.FieldName = "Adressee";
            this.colAdressee.Name = "colAdressee";
            this.colAdressee.Visible = true;
            this.colAdressee.VisibleIndex = 7;
            this.colAdressee.Width = 158;
            // 
            // colPostalAddress
            // 
            this.colPostalAddress.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colPostalAddress.FieldName = "PostalAddress";
            this.colPostalAddress.Name = "colPostalAddress";
            this.colPostalAddress.Visible = true;
            this.colPostalAddress.VisibleIndex = 8;
            this.colPostalAddress.Width = 234;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // colDeliveryOptionID
            // 
            this.colDeliveryOptionID.Caption = "Delivery Option";
            this.colDeliveryOptionID.ColumnEdit = this.cboDeliveryOption;
            this.colDeliveryOptionID.FieldName = "DeliveryOptionID";
            this.colDeliveryOptionID.Name = "colDeliveryOptionID";
            this.colDeliveryOptionID.Width = 108;
            // 
            // cboDeliveryOption
            // 
            this.cboDeliveryOption.AutoHeight = false;
            this.cboDeliveryOption.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDeliveryOption.Name = "cboDeliveryOption";
            // 
            // colShopName
            // 
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 6;
            this.colShopName.Width = 85;
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 5;
            this.colShopNo.Width = 84;
            // 
            // colIsPrint
            // 
            this.colIsPrint.FieldName = "IsPrint";
            this.colIsPrint.Name = "colIsPrint";
            this.colIsPrint.Visible = true;
            this.colIsPrint.VisibleIndex = 0;
            this.colIsPrint.Width = 152;
            // 
            // colInvoiceTypeID
            // 
            this.colInvoiceTypeID.Caption = "Invoice Type";
            this.colInvoiceTypeID.ColumnEdit = this.lookupInvoiceTypeID;
            this.colInvoiceTypeID.FieldName = "InvoiceTypeID";
            this.colInvoiceTypeID.Name = "colInvoiceTypeID";
            this.colInvoiceTypeID.Width = 90;
            // 
            // lookupInvoiceTypeID
            // 
            this.lookupInvoiceTypeID.AutoHeight = false;
            this.lookupInvoiceTypeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupInvoiceTypeID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoiceTypeID", "InvoiceTypeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoiceTypeName", "InvoiceTypeName")});
            this.lookupInvoiceTypeID.Name = "lookupInvoiceTypeID";
            this.lookupInvoiceTypeID.NullText = "";
            // 
            // colLevelID
            // 
            this.colLevelID.Caption = "Floor Level";
            this.colLevelID.ColumnEdit = this.cboLevelID;
            this.colLevelID.FieldName = "LevelID";
            this.colLevelID.Name = "colLevelID";
            this.colLevelID.Width = 84;
            // 
            // cboLevelID
            // 
            this.cboLevelID.AutoHeight = false;
            this.cboLevelID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLevelID.Name = "cboLevelID";
            // 
            // colCategoryName
            // 
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 2;
            this.colCategoryName.Width = 118;
            // 
            // colDeliveryOptionName
            // 
            this.colDeliveryOptionName.FieldName = "DeliveryOptionName";
            this.colDeliveryOptionName.Name = "colDeliveryOptionName";
            this.colDeliveryOptionName.Visible = true;
            this.colDeliveryOptionName.VisibleIndex = 3;
            this.colDeliveryOptionName.Width = 157;
            // 
            // colLevelName
            // 
            this.colLevelName.FieldName = "LevelName";
            this.colLevelName.Name = "colLevelName";
            this.colLevelName.Visible = true;
            this.colLevelName.VisibleIndex = 4;
            this.colLevelName.Width = 82;
            // 
            // lookDeliveryOptionID
            // 
            this.lookDeliveryOptionID.AutoHeight = false;
            this.lookDeliveryOptionID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookDeliveryOptionID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DeliveryOptionID", "DeliveryOptionID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DeliveryOptionName", "DeliveryOptionName")});
            this.lookDeliveryOptionID.Name = "lookDeliveryOptionID";
            this.lookDeliveryOptionID.NullText = "";
            // 
            // richTextAddress
            // 
            this.richTextAddress.Appearance.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextAddress.Appearance.Options.UseFont = true;
            this.richTextAddress.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
            this.richTextAddress.Name = "richTextAddress";
            this.richTextAddress.ShowCaretInReadOnly = false;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LevelID", "LevelID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LevelName", "LevelName")});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.cboCategory);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.chkCompany);
            this.groupControl1.Location = new System.Drawing.Point(429, 18);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(629, 87);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Print";
            // 
            // cboCategory
            // 
            this.cboCategory.Location = new System.Drawing.Point(394, 41);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCategory.Size = new System.Drawing.Size(117, 22);
            this.cboCategory.TabIndex = 10;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(327, 44);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 16);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Category :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 46);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Company :";
            // 
            // chkCompany
            // 
            this.chkCompany.Location = new System.Drawing.Point(90, 41);
            this.chkCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCompany.Name = "chkCompany";
            this.chkCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkCompany.Properties.NullText = "";
            this.chkCompany.Size = new System.Drawing.Size(203, 22);
            this.chkCompany.TabIndex = 1;
            this.chkCompany.EditValueChanged += new System.EventHandler(this.chkCompany_EditValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(1158, 68);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 38);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Location = new System.Drawing.Point(15, 128);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(93, 28);
            this.chkSelectAll.TabIndex = 6;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::MMS.Properties.Resources.printer;
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(1066, 18);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 85);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(115, 128);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 28);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // xMailAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 671);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.envelopeGridControl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBuild);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "xMailAddresses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mail Addresses";
            this.Load += new System.EventHandler(this.xMailAddresses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.envelopeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.envelopeGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompanyID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGlobalCustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDeliveryOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupInvoiceTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLevelID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookDeliveryOptionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richTextAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompany.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBuild;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.BindingSource envelopeBindingSource;
        private DevExpress.XtraGrid.GridControl envelopeGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEnvelopeID;
        private DevExpress.XtraGrid.Columns.GridColumn colExtendedCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlobalCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn colAdressee;
        private DevExpress.XtraGrid.Columns.GridColumn colPostalAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryOptionID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupInvoiceTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookCompanyID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookLocationID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGlobalCustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit richTextAddress;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookDeliveryOptionID;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPrint;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckButton chkSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboDeliveryOption;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboLevelID;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryOptionName;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelName;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.ComboBoxEdit cboCategory;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit chkCompany;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}