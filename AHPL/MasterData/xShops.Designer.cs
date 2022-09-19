using DataTier;
namespace MMS
{
    partial class xShops
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
            System.Windows.Forms.Label levelIDLabel;
            System.Windows.Forms.Label shopNoLabel;
            System.Windows.Forms.Label sqFeetLabel;
            System.Windows.Forms.Label zoneIDLabel;
            System.Windows.Forms.Label rentAreaTypeIDLabel;
            this.repositoryItemLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemLookUpEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ratioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shopGridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colShopID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.floorLevelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colShop_Details = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSqFeet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentAreaTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookRentAreaTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cExtendedCustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.locationIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.levelIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.shopNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.shops_UtilityReadingsGridControl = new DevExpress.XtraGrid.GridControl();
            this.shops_UtilityReadingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colShopUtilityReadingID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUtilityID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLastReading = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colLastReadingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsRatioApplied = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRatioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colShop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeterName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colUtilityRateID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rentAreaTypeIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.rentAreaTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zoneIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.zoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqFeetTextEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            companyIDLabel = new System.Windows.Forms.Label();
            locationIDLabel = new System.Windows.Forms.Label();
            levelIDLabel = new System.Windows.Forms.Label();
            shopNoLabel = new System.Windows.Forms.Label();
            sqFeetLabel = new System.Windows.Forms.Label();
            zoneIDLabel = new System.Windows.Forms.Label();
            rentAreaTypeIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopGridControl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorLevelsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookRentAreaTypeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cExtendedCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shops_UtilityReadingsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shops_UtilityReadingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentAreaTypeIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentAreaTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqFeetTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // companyIDLabel
            // 
            companyIDLabel.AutoSize = true;
            companyIDLabel.Location = new System.Drawing.Point(58, 22);
            companyIDLabel.Name = "companyIDLabel";
            companyIDLabel.Size = new System.Drawing.Size(56, 13);
            companyIDLabel.TabIndex = 4;
            companyIDLabel.Text = "Company:";
            // 
            // locationIDLabel
            // 
            locationIDLabel.AutoSize = true;
            locationIDLabel.Location = new System.Drawing.Point(63, 46);
            locationIDLabel.Name = "locationIDLabel";
            locationIDLabel.Size = new System.Drawing.Size(51, 13);
            locationIDLabel.TabIndex = 6;
            locationIDLabel.Text = "Location:";
            // 
            // levelIDLabel
            // 
            levelIDLabel.AutoSize = true;
            levelIDLabel.Location = new System.Drawing.Point(78, 72);
            levelIDLabel.Name = "levelIDLabel";
            levelIDLabel.Size = new System.Drawing.Size(36, 13);
            levelIDLabel.TabIndex = 8;
            levelIDLabel.Text = "Level:";
            // 
            // shopNoLabel
            // 
            shopNoLabel.AutoSize = true;
            shopNoLabel.Location = new System.Drawing.Point(63, 149);
            shopNoLabel.Name = "shopNoLabel";
            shopNoLabel.Size = new System.Drawing.Size(51, 13);
            shopNoLabel.TabIndex = 8;
            shopNoLabel.Text = "Shop No:";
            // 
            // sqFeetLabel
            // 
            sqFeetLabel.AutoSize = true;
            sqFeetLabel.Location = new System.Drawing.Point(66, 175);
            sqFeetLabel.Name = "sqFeetLabel";
            sqFeetLabel.Size = new System.Drawing.Size(48, 13);
            sqFeetLabel.TabIndex = 9;
            sqFeetLabel.Text = "Sq Feet:";
            // 
            // zoneIDLabel
            // 
            zoneIDLabel.AutoSize = true;
            zoneIDLabel.Location = new System.Drawing.Point(79, 98);
            zoneIDLabel.Name = "zoneIDLabel";
            zoneIDLabel.Size = new System.Drawing.Size(35, 13);
            zoneIDLabel.TabIndex = 12;
            zoneIDLabel.Text = "Zone:";
            // 
            // rentAreaTypeIDLabel
            // 
            rentAreaTypeIDLabel.AutoSize = true;
            rentAreaTypeIDLabel.Location = new System.Drawing.Point(27, 124);
            rentAreaTypeIDLabel.Name = "rentAreaTypeIDLabel";
            rentAreaTypeIDLabel.Size = new System.Drawing.Size(87, 13);
            rentAreaTypeIDLabel.TabIndex = 14;
            rentAreaTypeIDLabel.Text = "Rent Area Type:";
            // 
            // repositoryItemLookUpEdit5
            // 
            this.repositoryItemLookUpEdit5.AutoHeight = false;
            this.repositoryItemLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit5.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShopID", "Shop ID", 61, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShopName", "Shop Name", 64, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LevelID", "Level ID", 49, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Location ID", 64, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "Company ID", 69, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "Customer ID", 70, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShopNo", "Shop No", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SqFeet", "Sq Feet", 47, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Shops_UtilityReadings", "Shops_Utility Readings", 119, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit5.DisplayMember = "ShopNo";
            this.repositoryItemLookUpEdit5.Name = "repositoryItemLookUpEdit5";
            this.repositoryItemLookUpEdit5.NullText = "";
            this.repositoryItemLookUpEdit5.ValueMember = "ShopID";
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
            // repositoryItemLookUpEdit6
            // 
            this.repositoryItemLookUpEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit6.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UtilityID", "Utility ID", 64, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UtilityName", "Utility Name", 67, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoicePrefix", "Invoice Prefix", 76, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit6.DisplayMember = "UtilityName";
            this.repositoryItemLookUpEdit6.Name = "repositoryItemLookUpEdit6";
            this.repositoryItemLookUpEdit6.NullText = "";
            this.repositoryItemLookUpEdit6.ValueMember = "UtilityID";
            // 
            // repositoryItemLookUpEdit7
            // 
            this.repositoryItemLookUpEdit7.AutoHeight = false;
            this.repositoryItemLookUpEdit7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit7.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RatioID", "Ratio ID", 62, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RatioNo", "Ratio No", 51, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit7.DataSource = this.ratioBindingSource;
            this.repositoryItemLookUpEdit7.DisplayMember = "RatioNo";
            this.repositoryItemLookUpEdit7.Name = "repositoryItemLookUpEdit7";
            this.repositoryItemLookUpEdit7.NullText = "";
            this.repositoryItemLookUpEdit7.ValueMember = "RatioID";
            // 
            // ratioBindingSource
            // 
            this.ratioBindingSource.DataSource = typeof(DataTier.Ratio);
            // 
            // shopBindingSource
            // 
            this.shopBindingSource.DataSource = typeof(DataTier.Shop);
            // 
            // shopGridControl
            // 
            this.shopGridControl.ContextMenuStrip = this.contextMenuStrip1;
            this.shopGridControl.DataSource = this.shopBindingSource;
            this.shopGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shopGridControl.Location = new System.Drawing.Point(0, 0);
            this.shopGridControl.MainView = this.gridView1;
            this.shopGridControl.Name = "shopGridControl";
            this.shopGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit3,
            this.repositoryItemLookUpEdit4,
            this.lookRentAreaTypeID});
            this.shopGridControl.Size = new System.Drawing.Size(373, 613);
            this.shopGridControl.TabIndex = 1;
            this.shopGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.hideToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 54);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 6);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShopID,
            this.colLevelID,
            this.colLocationID,
            this.colCompanyID,
            this.colShop_Details,
            this.colShopNo,
            this.colSqFeet,
            this.colRentAreaTypeID});
            this.gridView1.GridControl = this.shopGridControl;
            this.gridView1.GroupCount = 4;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office2003;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCompanyID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLocationID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLevelID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRentAreaTypeID, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ViewCaption = "List of Shops/Booths";
            // 
            // colShopID
            // 
            this.colShopID.FieldName = "ShopID";
            this.colShopID.Name = "colShopID";
            // 
            // colLevelID
            // 
            this.colLevelID.Caption = "Level";
            this.colLevelID.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.colLevelID.FieldName = "LevelID";
            this.colLevelID.Name = "colLevelID";
            this.colLevelID.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.colLevelID.Visible = true;
            this.colLevelID.VisibleIndex = 2;
            this.colLevelID.Width = 81;
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LevelID", "Level ID", 62, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LevelCode", "Level Code", 63, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LevelName", "Level Name", 65, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit4.DataSource = this.floorLevelsBindingSource;
            this.repositoryItemLookUpEdit4.DisplayMember = "LevelCode";
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            this.repositoryItemLookUpEdit4.NullText = "";
            this.repositoryItemLookUpEdit4.ValueMember = "LevelID";
            // 
            // floorLevelsBindingSource
            // 
            this.floorLevelsBindingSource.DataSource = typeof(DataTier.Floor_Levels);
            // 
            // colLocationID
            // 
            this.colLocationID.Caption = "Location";
            this.colLocationID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colLocationID.FieldName = "LocationID";
            this.colLocationID.Name = "colLocationID";
            this.colLocationID.OptionsColumn.AllowEdit = false;
            this.colLocationID.OptionsColumn.ReadOnly = true;
            this.colLocationID.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.colLocationID.Visible = true;
            this.colLocationID.VisibleIndex = 3;
            this.colLocationID.Width = 79;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.locationBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "LocationCode";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "LocationID";
            // 
            // locationBindingSource
            // 
            this.locationBindingSource.DataSource = typeof(DataTier.Location);
            // 
            // colCompanyID
            // 
            this.colCompanyID.Caption = "Company";
            this.colCompanyID.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colCompanyID.FieldName = "CompanyID";
            this.colCompanyID.Name = "colCompanyID";
            this.colCompanyID.OptionsColumn.AllowEdit = false;
            this.colCompanyID.OptionsColumn.ReadOnly = true;
            this.colCompanyID.Visible = true;
            this.colCompanyID.VisibleIndex = 4;
            this.colCompanyID.Width = 81;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.DataSource = this.companyBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "CompanyCode";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.ValueMember = "CompanyID";
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(DataTier.Company);
            // 
            // colShop_Details
            // 
            this.colShop_Details.FieldName = "Shop_Details";
            this.colShop_Details.Name = "colShop_Details";
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 0;
            this.colShopNo.Width = 227;
            // 
            // colSqFeet
            // 
            this.colSqFeet.Caption = "Sq.Ft.";
            this.colSqFeet.FieldName = "SqFeet";
            this.colSqFeet.Name = "colSqFeet";
            this.colSqFeet.OptionsColumn.AllowEdit = false;
            this.colSqFeet.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colSqFeet.OptionsColumn.ReadOnly = true;
            this.colSqFeet.Visible = true;
            this.colSqFeet.VisibleIndex = 1;
            this.colSqFeet.Width = 81;
            // 
            // colRentAreaTypeID
            // 
            this.colRentAreaTypeID.Caption = "Rent Area Type";
            this.colRentAreaTypeID.ColumnEdit = this.lookRentAreaTypeID;
            this.colRentAreaTypeID.FieldName = "RentAreaTypeID";
            this.colRentAreaTypeID.Name = "colRentAreaTypeID";
            this.colRentAreaTypeID.Visible = true;
            this.colRentAreaTypeID.VisibleIndex = 2;
            this.colRentAreaTypeID.Width = 140;
            // 
            // lookRentAreaTypeID
            // 
            this.lookRentAreaTypeID.AutoHeight = false;
            this.lookRentAreaTypeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookRentAreaTypeID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RentAreaTypeID", "RentAreaTypeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RentAreaTypeName", "RentAreaTypeName")});
            this.lookRentAreaTypeID.Name = "lookRentAreaTypeID";
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.DataSource = this.cExtendedCustomersBindingSource;
            this.repositoryItemLookUpEdit3.DisplayMember = "CustomerName";
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            this.repositoryItemLookUpEdit3.NullText = "";
            this.repositoryItemLookUpEdit3.ValueMember = "ExtendedCustomerID";
            // 
            // cExtendedCustomersBindingSource
            // 
            this.cExtendedCustomersBindingSource.DataSource = typeof(MMS.cView_Extended_Customers);
            // 
            // companyIDLookUpEdit
            // 
            this.companyIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.shopBindingSource, "CompanyID", true));
            this.companyIDLookUpEdit.EnterMoveNextControl = true;
            this.companyIDLookUpEdit.Location = new System.Drawing.Point(122, 19);
            this.companyIDLookUpEdit.Name = "companyIDLookUpEdit";
            this.companyIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.companyIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "Company ID", 82, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "Company Code", 83, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Company Name", 85, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Location ID", 64, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far)});
            this.companyIDLookUpEdit.Properties.DataSource = this.companyBindingSource;
            this.companyIDLookUpEdit.Properties.DisplayMember = "CompanyCode";
            this.companyIDLookUpEdit.Properties.NullText = "";
            this.companyIDLookUpEdit.Properties.ValueMember = "CompanyID";
            this.companyIDLookUpEdit.Size = new System.Drawing.Size(144, 20);
            this.companyIDLookUpEdit.TabIndex = 0;
            this.companyIDLookUpEdit.EditValueChanged += new System.EventHandler(this.companyIDLookUpEdit_EditValueChanged);
            // 
            // locationIDLookUpEdit
            // 
            this.locationIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.shopBindingSource, "LocationID", true));
            this.locationIDLookUpEdit.EnterMoveNextControl = true;
            this.locationIDLookUpEdit.Location = new System.Drawing.Point(122, 43);
            this.locationIDLookUpEdit.Name = "locationIDLookUpEdit";
            this.locationIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.locationIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Location ID", 77, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationName", "Location Name", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "Location Code", 78, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.locationIDLookUpEdit.Properties.DataSource = this.locationBindingSource;
            this.locationIDLookUpEdit.Properties.DisplayMember = "LocationCode";
            this.locationIDLookUpEdit.Properties.NullText = "";
            this.locationIDLookUpEdit.Properties.ValueMember = "LocationID";
            this.locationIDLookUpEdit.Size = new System.Drawing.Size(144, 20);
            this.locationIDLookUpEdit.TabIndex = 1;
            this.locationIDLookUpEdit.EditValueChanged += new System.EventHandler(this.locationIDLookUpEdit_EditValueChanged);
            // 
            // levelIDLookUpEdit
            // 
            this.levelIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.shopBindingSource, "LevelID", true));
            this.levelIDLookUpEdit.EnterMoveNextControl = true;
            this.levelIDLookUpEdit.Location = new System.Drawing.Point(122, 69);
            this.levelIDLookUpEdit.Name = "levelIDLookUpEdit";
            this.levelIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.levelIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LevelID", "Level ID", 62, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LevelCode", "Level Code", 63, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LevelName", "Level Name", 65, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Location ID", 64, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far)});
            this.levelIDLookUpEdit.Properties.DataSource = this.floorLevelsBindingSource;
            this.levelIDLookUpEdit.Properties.DisplayMember = "LevelCode";
            this.levelIDLookUpEdit.Properties.NullText = "";
            this.levelIDLookUpEdit.Properties.ValueMember = "LevelID";
            this.levelIDLookUpEdit.Size = new System.Drawing.Size(144, 20);
            this.levelIDLookUpEdit.TabIndex = 2;
            this.levelIDLookUpEdit.EditValueChanged += new System.EventHandler(this.levelIDLookUpEdit_EditValueChanged);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // shopNoTextEdit
            // 
            this.shopNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.shopBindingSource, "ShopNo", true));
            this.shopNoTextEdit.EditValue = "";
            this.shopNoTextEdit.EnterMoveNextControl = true;
            this.shopNoTextEdit.Location = new System.Drawing.Point(122, 146);
            this.shopNoTextEdit.Name = "shopNoTextEdit";
            this.shopNoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.shopNoTextEdit.TabIndex = 5;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.shopGridControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.shops_UtilityReadingsGridControl);
            this.splitContainerControl1.Panel2.Controls.Add(rentAreaTypeIDLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.companyIDLookUpEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.rentAreaTypeIDLookUpEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.shopNoTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(zoneIDLabel);
            this.splitContainerControl1.Panel2.Controls.Add(companyIDLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.zoneIDLookUpEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.locationIDLookUpEdit);
            this.splitContainerControl1.Panel2.Controls.Add(shopNoLabel);
            this.splitContainerControl1.Panel2.Controls.Add(sqFeetLabel);
            this.splitContainerControl1.Panel2.Controls.Add(levelIDLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.levelIDLookUpEdit);
            this.splitContainerControl1.Panel2.Controls.Add(locationIDLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.sqFeetTextEdit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1126, 613);
            this.splitContainerControl1.SplitterPosition = 373;
            this.splitContainerControl1.TabIndex = 10;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // shops_UtilityReadingsGridControl
            // 
            this.shops_UtilityReadingsGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.shops_UtilityReadingsGridControl.DataSource = this.shops_UtilityReadingsBindingSource;
            this.shops_UtilityReadingsGridControl.Location = new System.Drawing.Point(308, 22);
            this.shops_UtilityReadingsGridControl.MainView = this.gridView2;
            this.shops_UtilityReadingsGridControl.Name = "shops_UtilityReadingsGridControl";
            this.shops_UtilityReadingsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit8,
            this.repositoryItemLookUpEdit9,
            this.repositoryItemTextEdit2,
            this.repositoryItemLookUpEdit10,
            this.repositoryItemTextEdit3});
            this.shops_UtilityReadingsGridControl.Size = new System.Drawing.Size(356, 184);
            this.shops_UtilityReadingsGridControl.TabIndex = 0;
            this.shops_UtilityReadingsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // shops_UtilityReadingsBindingSource
            // 
            this.shops_UtilityReadingsBindingSource.DataMember = "Shops_UtilityReadings";
            this.shops_UtilityReadingsBindingSource.DataSource = this.shopBindingSource;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShopUtilityReadingID,
            this.colShopID1,
            this.colUtilityID,
            this.colLastReading,
            this.colLastReadingDate,
            this.colIsRatioApplied,
            this.colRatioID,
            this.colShop,
            this.colMeterName,
            this.colUtilityRateID,
            this.colIsDeleted});
            this.gridView2.GridControl = this.shops_UtilityReadingsGridControl;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowViewCaption = true;
            this.gridView2.ViewCaption = "Utility Last Reading";
            this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            this.gridView2.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView2_ValidateRow);
            // 
            // colShopUtilityReadingID
            // 
            this.colShopUtilityReadingID.FieldName = "ShopUtilityReadingID";
            this.colShopUtilityReadingID.Name = "colShopUtilityReadingID";
            // 
            // colShopID1
            // 
            this.colShopID1.FieldName = "ShopID";
            this.colShopID1.Name = "colShopID1";
            // 
            // colUtilityID
            // 
            this.colUtilityID.Caption = "Utility";
            this.colUtilityID.ColumnEdit = this.repositoryItemLookUpEdit8;
            this.colUtilityID.FieldName = "UtilityID";
            this.colUtilityID.Name = "colUtilityID";
            // 
            // repositoryItemLookUpEdit8
            // 
            this.repositoryItemLookUpEdit8.AutoHeight = false;
            this.repositoryItemLookUpEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit8.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UtilityID", "Utility ID", 64, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UtilityName", "Utility Name", 67, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoicePrefix", "Invoice Prefix", 76, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoiceFooterText", "Invoice Footer Text", 105, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit8.DisplayMember = "UtilityName";
            this.repositoryItemLookUpEdit8.Name = "repositoryItemLookUpEdit8";
            this.repositoryItemLookUpEdit8.NullText = "";
            this.repositoryItemLookUpEdit8.ValueMember = "UtilityID";
            // 
            // colLastReading
            // 
            this.colLastReading.ColumnEdit = this.repositoryItemTextEdit3;
            this.colLastReading.DisplayFormat.FormatString = "n4";
            this.colLastReading.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLastReading.FieldName = "LastReading";
            this.colLastReading.Name = "colLastReading";
            this.colLastReading.Visible = true;
            this.colLastReading.VisibleIndex = 1;
            this.colLastReading.Width = 109;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.DisplayFormat.FormatString = "n4";
            this.repositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit3.EditFormat.FormatString = "n4";
            this.repositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit3.Mask.EditMask = "n4";
            this.repositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // colLastReadingDate
            // 
            this.colLastReadingDate.FieldName = "LastReadingDate";
            this.colLastReadingDate.Name = "colLastReadingDate";
            this.colLastReadingDate.Width = 119;
            // 
            // colIsRatioApplied
            // 
            this.colIsRatioApplied.FieldName = "IsRatioApplied";
            this.colIsRatioApplied.Name = "colIsRatioApplied";
            this.colIsRatioApplied.Visible = true;
            this.colIsRatioApplied.VisibleIndex = 3;
            this.colIsRatioApplied.Width = 88;
            // 
            // colRatioID
            // 
            this.colRatioID.Caption = "Ratio";
            this.colRatioID.ColumnEdit = this.repositoryItemLookUpEdit9;
            this.colRatioID.FieldName = "RatioID";
            this.colRatioID.Name = "colRatioID";
            this.colRatioID.Visible = true;
            this.colRatioID.VisibleIndex = 4;
            // 
            // repositoryItemLookUpEdit9
            // 
            this.repositoryItemLookUpEdit9.AutoHeight = false;
            this.repositoryItemLookUpEdit9.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit9.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RatioID", "Ratio ID", 62, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RatioNo", "Value", 51, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RatioCode", "Name", 63, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit9.DataSource = this.ratioBindingSource;
            this.repositoryItemLookUpEdit9.DisplayMember = "RatioNo";
            this.repositoryItemLookUpEdit9.Name = "repositoryItemLookUpEdit9";
            this.repositoryItemLookUpEdit9.NullText = "";
            this.repositoryItemLookUpEdit9.ValueMember = "RatioID";
            // 
            // colShop
            // 
            this.colShop.FieldName = "Shop";
            this.colShop.Name = "colShop";
            // 
            // colMeterName
            // 
            this.colMeterName.ColumnEdit = this.repositoryItemTextEdit2;
            this.colMeterName.FieldName = "MeterName";
            this.colMeterName.Name = "colMeterName";
            this.colMeterName.Visible = true;
            this.colMeterName.VisibleIndex = 2;
            this.colMeterName.Width = 98;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.MaxLength = 50;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // colUtilityRateID
            // 
            this.colUtilityRateID.Caption = "Utility Profile Name";
            this.colUtilityRateID.ColumnEdit = this.repositoryItemLookUpEdit10;
            this.colUtilityRateID.FieldName = "UtilityRateID";
            this.colUtilityRateID.Name = "colUtilityRateID";
            this.colUtilityRateID.Visible = true;
            this.colUtilityRateID.VisibleIndex = 0;
            this.colUtilityRateID.Width = 185;
            // 
            // repositoryItemLookUpEdit10
            // 
            this.repositoryItemLookUpEdit10.AutoHeight = false;
            this.repositoryItemLookUpEdit10.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemLookUpEdit10.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit10.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UtilityRateID", "UtilityRateID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UtilityName", "UtilityName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UtilityRateProfileName", "UtilityRateProfileName")});
            this.repositoryItemLookUpEdit10.Name = "repositoryItemLookUpEdit10";
            this.repositoryItemLookUpEdit10.NullText = "";
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.Caption = "Delete";
            this.colIsDeleted.FieldName = "IsDeleted";
            this.colIsDeleted.Name = "colIsDeleted";
            this.colIsDeleted.Visible = true;
            this.colIsDeleted.VisibleIndex = 5;
            // 
            // rentAreaTypeIDLookUpEdit
            // 
            this.rentAreaTypeIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.shopBindingSource, "RentAreaTypeID", true));
            this.rentAreaTypeIDLookUpEdit.EnterMoveNextControl = true;
            this.rentAreaTypeIDLookUpEdit.Location = new System.Drawing.Point(122, 121);
            this.rentAreaTypeIDLookUpEdit.Name = "rentAreaTypeIDLookUpEdit";
            this.rentAreaTypeIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rentAreaTypeIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RentAreaTypeID", "Rent Area Type ID", 113, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RentAreaTypeName", "Rent Area Type Name", 116, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.rentAreaTypeIDLookUpEdit.Properties.DataSource = this.rentAreaTypesBindingSource;
            this.rentAreaTypeIDLookUpEdit.Properties.DisplayMember = "RentAreaTypeName";
            this.rentAreaTypeIDLookUpEdit.Properties.NullText = "";
            this.rentAreaTypeIDLookUpEdit.Properties.ValueMember = "RentAreaTypeID";
            this.rentAreaTypeIDLookUpEdit.Size = new System.Drawing.Size(144, 20);
            this.rentAreaTypeIDLookUpEdit.TabIndex = 4;
            this.rentAreaTypeIDLookUpEdit.EditValueChanged += new System.EventHandler(this.rentAreaTypeIDLookUpEdit_EditValueChanged);
            // 
            // rentAreaTypesBindingSource
            // 
            this.rentAreaTypesBindingSource.DataSource = typeof(DataTier.Rent_Area_Types);
            // 
            // zoneIDLookUpEdit
            // 
            this.zoneIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.shopBindingSource, "ZoneID", true));
            this.zoneIDLookUpEdit.EnterMoveNextControl = true;
            this.zoneIDLookUpEdit.Location = new System.Drawing.Point(122, 95);
            this.zoneIDLookUpEdit.Name = "zoneIDLookUpEdit";
            this.zoneIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.zoneIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ZoneID", "Zone ID", 61, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ZoneName", "Zone Name", 64, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Location ID", 64, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far)});
            this.zoneIDLookUpEdit.Properties.DataSource = this.zoneBindingSource;
            this.zoneIDLookUpEdit.Properties.DisplayMember = "ZoneName";
            this.zoneIDLookUpEdit.Properties.NullText = "";
            this.zoneIDLookUpEdit.Properties.ValueMember = "ZoneID";
            this.zoneIDLookUpEdit.Size = new System.Drawing.Size(144, 20);
            this.zoneIDLookUpEdit.TabIndex = 3;
            // 
            // zoneBindingSource
            // 
            this.zoneBindingSource.DataSource = typeof(DataTier.Zone);
            // 
            // sqFeetTextEdit
            // 
            this.sqFeetTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.shopBindingSource, "SqFeet", true));
            this.sqFeetTextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sqFeetTextEdit.Location = new System.Drawing.Point(122, 172);
            this.sqFeetTextEdit.Name = "sqFeetTextEdit";
            this.sqFeetTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.sqFeetTextEdit.Properties.DisplayFormat.FormatString = "n4";
            this.sqFeetTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.sqFeetTextEdit.Properties.EditFormat.FormatString = "n4";
            this.sqFeetTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.sqFeetTextEdit.Properties.Mask.EditMask = "n4";
            this.sqFeetTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.sqFeetTextEdit.Size = new System.Drawing.Size(100, 20);
            this.sqFeetTextEdit.TabIndex = 6;
            this.sqFeetTextEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.sqFeetTextEdit_ButtonPressed);
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
            this.btnNew,
            this.btnEdit,
            this.btnSave,
            this.btnClose,
            this.btnDelete,
            this.btnRefresh,
            this.btnUndo});
            this.barManager1.MaxItemId = 9;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUndo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar1.Text = "Tools";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Glyph = global::MMS.Properties.Resources.note_new;
            this.btnNew.Id = 0;
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Glyph = global::MMS.Properties.Resources.note_edit;
            this.btnEdit.Id = 1;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Glyph = global::MMS.Properties.Resources.disk_blue;
            this.btnSave.Id = 2;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Glyph = global::MMS.Properties.Resources.undo;
            this.btnUndo.Id = 7;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndo_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Glyph = global::MMS.Properties.Resources.delete2;
            this.btnDelete.Id = 5;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = global::MMS.Properties.Resources.refresh;
            this.btnRefresh.Id = 6;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1126, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 660);
            this.barDockControlBottom.Size = new System.Drawing.Size(1126, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 613);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1126, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 613);
            // 
            // xShops
            // 
            this.ClientSize = new System.Drawing.Size(1126, 660);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xShops";
            this.Text = "Shops / Booths";
            this.Load += new System.EventHandler(this.xShops_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopGridControl)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorLevelsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookRentAreaTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cExtendedCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shops_UtilityReadingsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shops_UtilityReadingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentAreaTypeIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentAreaTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqFeetTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource shopBindingSource;
        private DevExpress.XtraGrid.GridControl shopGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colShopID;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelID;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraEditors.LookUpEdit companyIDLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit locationIDLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit levelIDLookUpEdit;
        private System.Windows.Forms.BindingSource cExtendedCustomersBindingSource;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private System.Windows.Forms.BindingSource floorLevelsBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colShop_Details;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraEditors.TextEdit shopNoTextEdit;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl shops_UtilityReadingsGridControl;
        private System.Windows.Forms.BindingSource shops_UtilityReadingsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.BindingSource ratioBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSqFeet;
        private DevExpress.XtraEditors.LookUpEdit rentAreaTypeIDLookUpEdit;
        private System.Windows.Forms.BindingSource rentAreaTypesBindingSource;
        private DevExpress.XtraEditors.LookUpEdit zoneIDLookUpEdit;
        private System.Windows.Forms.BindingSource zoneBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit7;
        private DevExpress.XtraGrid.Columns.GridColumn colShopUtilityReadingID;
        private DevExpress.XtraGrid.Columns.GridColumn colShopID1;
        private DevExpress.XtraGrid.Columns.GridColumn colUtilityID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit8;
        private DevExpress.XtraGrid.Columns.GridColumn colLastReading;
        private DevExpress.XtraGrid.Columns.GridColumn colLastReadingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsRatioApplied;
        private DevExpress.XtraGrid.Columns.GridColumn colRatioID;
        private DevExpress.XtraGrid.Columns.GridColumn colShop;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit9;
        private DevExpress.XtraGrid.Columns.GridColumn colMeterName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colUtilityRateID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit10;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private DevExpress.XtraEditors.ButtonEdit sqFeetTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colRentAreaTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookRentAreaTypeID;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnClose;

    }
}
