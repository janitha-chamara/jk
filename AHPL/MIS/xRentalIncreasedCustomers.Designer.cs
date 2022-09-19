namespace MMS.MIS
{
    partial class xRentalIncreasedCustomers
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.lookLocaiton = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dateEditDate = new DevExpress.XtraEditors.DateEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.shopOccupancyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.shopOccupancyGridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLevelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOccupiedAreaSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentPerSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScPerSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentAreaType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncreaseOfRent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncreaseOfSC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncreaseRentPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOldRentPerSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOldSCperSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncreaseSCPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocaiton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyGridControl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lookCompany);
            this.panelControl1.Controls.Add(this.lookLocaiton);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(386, 75);
            this.panelControl1.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Location :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Company : ";
            // 
            // lookCompany
            // 
            this.lookCompany.Location = new System.Drawing.Point(82, 15);
            this.lookCompany.Name = "lookCompany";
            this.lookCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.lookCompany.Properties.NullText = "";
            this.lookCompany.Size = new System.Drawing.Size(286, 20);
            this.lookCompany.TabIndex = 3;
            this.lookCompany.EditValueChanged += new System.EventHandler(this.lookCompany_EditValueChanged);
            // 
            // lookLocaiton
            // 
            this.lookLocaiton.Location = new System.Drawing.Point(82, 41);
            this.lookLocaiton.Name = "lookLocaiton";
            this.lookLocaiton.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocaiton.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.lookLocaiton.Properties.NullText = "";
            this.lookLocaiton.Size = new System.Drawing.Size(286, 20);
            this.lookLocaiton.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dateEditDate);
            this.groupControl1.Location = new System.Drawing.Point(404, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(172, 75);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Month/Year";
            // 
            // dateEditDate
            // 
            this.dateEditDate.EditValue = null;
            this.dateEditDate.Location = new System.Drawing.Point(23, 34);
            this.dateEditDate.Name = "dateEditDate";
            this.dateEditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditDate.Properties.DisplayFormat.FormatString = "y";
            this.dateEditDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDate.Properties.EditFormat.FormatString = "y";
            this.dateEditDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDate.Properties.Mask.EditMask = "y";
            this.dateEditDate.Size = new System.Drawing.Size(132, 20);
            this.dateEditDate.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(1008, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 63);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::MMS.Properties.Resources.printer1;
            this.btnPrint.Location = new System.Drawing.Point(878, 52);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 29);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Image = global::MMS.Properties.Resources.document_view;
            this.btnPreview.Location = new System.Drawing.Point(878, 18);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(124, 29);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "Preview ";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // shopOccupancyBindingSource
            // 
            this.shopOccupancyBindingSource.DataSource = typeof(DataTier.ReportClasses.ShopOccupancy);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // shopOccupancyGridControl
            // 
            this.shopOccupancyGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.shopOccupancyGridControl.ContextMenuStrip = this.contextMenuStrip1;
            this.shopOccupancyGridControl.DataSource = this.shopOccupancyBindingSource;
            this.shopOccupancyGridControl.Location = new System.Drawing.Point(12, 95);
            this.shopOccupancyGridControl.MainView = this.gridView1;
            this.shopOccupancyGridControl.Name = "shopOccupancyGridControl";
            this.shopOccupancyGridControl.Size = new System.Drawing.Size(1076, 426);
            this.shopOccupancyGridControl.TabIndex = 10;
            this.shopOccupancyGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.hideToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 54);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLevelName,
            this.colLocationCode,
            this.colCompanyCode,
            this.colCustomerName,
            this.colOccupiedAreaSqFt,
            this.colRentPerSqFt,
            this.colScPerSqFt,
            this.colShopNo,
            this.colRentAreaType,
            this.colIncreaseOfRent,
            this.colIncreaseOfSC,
            this.colIncreaseRentPercentage,
            this.colOldRentPerSqFt,
            this.colOldSCperSqFt,
            this.colFromDate,
            this.colToDate,
            this.colIncreaseSCPercentage,
            this.colRentPeriod});
            this.gridView1.GridControl = this.shopOccupancyGridControl;
            this.gridView1.GroupCount = 3;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCompanyCode, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLocationCode, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLevelName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ViewCaption = "List of Rental Increased Customers";
            // 
            // colLevelName
            // 
            this.colLevelName.FieldName = "LevelName";
            this.colLevelName.Name = "colLevelName";
            this.colLevelName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colLevelName.Visible = true;
            this.colLevelName.VisibleIndex = 1;
            this.colLevelName.Width = 134;
            // 
            // colLocationCode
            // 
            this.colLocationCode.FieldName = "LocationCode";
            this.colLocationCode.Name = "colLocationCode";
            this.colLocationCode.Visible = true;
            this.colLocationCode.VisibleIndex = 0;
            this.colLocationCode.Width = 150;
            // 
            // colCompanyCode
            // 
            this.colCompanyCode.FieldName = "CompanyCode";
            this.colCompanyCode.Name = "colCompanyCode";
            this.colCompanyCode.Visible = true;
            this.colCompanyCode.VisibleIndex = 0;
            this.colCompanyCode.Width = 138;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "Customer";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 3;
            this.colCustomerName.Width = 209;
            // 
            // colOccupiedAreaSqFt
            // 
            this.colOccupiedAreaSqFt.Caption = "Sq.Ft";
            this.colOccupiedAreaSqFt.DisplayFormat.FormatString = "n2";
            this.colOccupiedAreaSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOccupiedAreaSqFt.FieldName = "OccupiedAreaSqFt";
            this.colOccupiedAreaSqFt.Name = "colOccupiedAreaSqFt";
            this.colOccupiedAreaSqFt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colOccupiedAreaSqFt.Visible = true;
            this.colOccupiedAreaSqFt.VisibleIndex = 2;
            this.colOccupiedAreaSqFt.Width = 66;
            // 
            // colRentPerSqFt
            // 
            this.colRentPerSqFt.AppearanceCell.BackColor = System.Drawing.Color.PaleTurquoise;
            this.colRentPerSqFt.AppearanceCell.Options.UseBackColor = true;
            this.colRentPerSqFt.Caption = "New Rent / Month";
            this.colRentPerSqFt.DisplayFormat.FormatString = "n2";
            this.colRentPerSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRentPerSqFt.FieldName = "RentPerSqFt";
            this.colRentPerSqFt.Name = "colRentPerSqFt";
            this.colRentPerSqFt.Visible = true;
            this.colRentPerSqFt.VisibleIndex = 6;
            this.colRentPerSqFt.Width = 106;
            // 
            // colScPerSqFt
            // 
            this.colScPerSqFt.AppearanceCell.BackColor = System.Drawing.Color.PaleTurquoise;
            this.colScPerSqFt.AppearanceCell.Options.UseBackColor = true;
            this.colScPerSqFt.Caption = "New S.C./Month";
            this.colScPerSqFt.DisplayFormat.FormatString = "n2";
            this.colScPerSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colScPerSqFt.FieldName = "ScPerSqFt";
            this.colScPerSqFt.Name = "colScPerSqFt";
            this.colScPerSqFt.Visible = true;
            this.colScPerSqFt.VisibleIndex = 7;
            this.colScPerSqFt.Width = 98;
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 0;
            this.colShopNo.Width = 108;
            // 
            // colRentAreaType
            // 
            this.colRentAreaType.FieldName = "RentAreaType";
            this.colRentAreaType.Name = "colRentAreaType";
            this.colRentAreaType.Visible = true;
            this.colRentAreaType.VisibleIndex = 1;
            this.colRentAreaType.Width = 95;
            // 
            // colIncreaseOfRent
            // 
            this.colIncreaseOfRent.Caption = "Increase of Rent";
            this.colIncreaseOfRent.DisplayFormat.FormatString = "n2";
            this.colIncreaseOfRent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIncreaseOfRent.FieldName = "IncreaseOfRent";
            this.colIncreaseOfRent.Name = "colIncreaseOfRent";
            this.colIncreaseOfRent.Visible = true;
            this.colIncreaseOfRent.VisibleIndex = 8;
            this.colIncreaseOfRent.Width = 105;
            // 
            // colIncreaseOfSC
            // 
            this.colIncreaseOfSC.Caption = "Increase of SC";
            this.colIncreaseOfSC.DisplayFormat.FormatString = "n2";
            this.colIncreaseOfSC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIncreaseOfSC.FieldName = "IncreaseOfSC";
            this.colIncreaseOfSC.Name = "colIncreaseOfSC";
            this.colIncreaseOfSC.Visible = true;
            this.colIncreaseOfSC.VisibleIndex = 10;
            this.colIncreaseOfSC.Width = 90;
            // 
            // colIncreaseRentPercentage
            // 
            this.colIncreaseRentPercentage.Caption = "Increment of Rent %";
            this.colIncreaseRentPercentage.DisplayFormat.FormatString = "n2";
            this.colIncreaseRentPercentage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIncreaseRentPercentage.FieldName = "IncreaseRentPercentage";
            this.colIncreaseRentPercentage.Name = "colIncreaseRentPercentage";
            this.colIncreaseRentPercentage.Visible = true;
            this.colIncreaseRentPercentage.VisibleIndex = 9;
            this.colIncreaseRentPercentage.Width = 134;
            // 
            // colOldRentPerSqFt
            // 
            this.colOldRentPerSqFt.Caption = "Old Rent";
            this.colOldRentPerSqFt.DisplayFormat.FormatString = "n2";
            this.colOldRentPerSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOldRentPerSqFt.FieldName = "OldRentPerSqFt";
            this.colOldRentPerSqFt.Name = "colOldRentPerSqFt";
            this.colOldRentPerSqFt.Visible = true;
            this.colOldRentPerSqFt.VisibleIndex = 4;
            this.colOldRentPerSqFt.Width = 71;
            // 
            // colOldSCperSqFt
            // 
            this.colOldSCperSqFt.Caption = "Old S.C.";
            this.colOldSCperSqFt.DisplayFormat.FormatString = "n2";
            this.colOldSCperSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOldSCperSqFt.FieldName = "OldSCperSqFt";
            this.colOldSCperSqFt.Name = "colOldSCperSqFt";
            this.colOldSCperSqFt.Visible = true;
            this.colOldSCperSqFt.VisibleIndex = 5;
            this.colOldSCperSqFt.Width = 64;
            // 
            // colFromDate
            // 
            this.colFromDate.Caption = "From";
            this.colFromDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colFromDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFromDate.FieldName = "FromDate";
            this.colFromDate.Name = "colFromDate";
            // 
            // colToDate
            // 
            this.colToDate.Caption = "To";
            this.colToDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colToDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colToDate.FieldName = "ToDate";
            this.colToDate.Name = "colToDate";
            // 
            // colIncreaseSCPercentage
            // 
            this.colIncreaseSCPercentage.Caption = "Increment  of SC%";
            this.colIncreaseSCPercentage.DisplayFormat.FormatString = "n2";
            this.colIncreaseSCPercentage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIncreaseSCPercentage.FieldName = "IncreaseSCPercentage";
            this.colIncreaseSCPercentage.Name = "colIncreaseSCPercentage";
            this.colIncreaseSCPercentage.Visible = true;
            this.colIncreaseSCPercentage.VisibleIndex = 11;
            this.colIncreaseSCPercentage.Width = 111;
            // 
            // colRentPeriod
            // 
            this.colRentPeriod.DisplayFormat.FormatString = "n2";
            this.colRentPeriod.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRentPeriod.FieldName = "RentPeriod";
            this.colRentPeriod.Name = "colRentPeriod";
            this.colRentPeriod.Width = 179;
            // 
            // xRentalIncreasedCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 534);
            this.Controls.Add(this.shopOccupancyGridControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "xRentalIncreasedCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rental Increased Customers";
            this.Load += new System.EventHandler(this.xRentalIncreasedCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocaiton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyGridControl)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        protected DevExpress.XtraEditors.GroupControl groupControl1;
        protected DevExpress.XtraEditors.DateEdit dateEditDate;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private System.Windows.Forms.BindingSource shopOccupancyBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        public DevExpress.XtraGrid.GridControl shopOccupancyGridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelName;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colOccupiedAreaSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colRentPerSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colScPerSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colRentAreaType;
        private DevExpress.XtraGrid.Columns.GridColumn colIncreaseOfRent;
        private DevExpress.XtraGrid.Columns.GridColumn colIncreaseOfSC;
        private DevExpress.XtraGrid.Columns.GridColumn colOldRentPerSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colOldSCperSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colFromDate;
        private DevExpress.XtraGrid.Columns.GridColumn colToDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIncreaseRentPercentage;
        private DevExpress.XtraGrid.Columns.GridColumn colIncreaseSCPercentage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colRentPeriod;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LookUpEdit lookLocaiton;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}