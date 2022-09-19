namespace MMS.MIS
{
    partial class xOccupancyAndUnoccupancy
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
            this.colUnOccupiedAreaSqft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.lookLocaiton = new DevExpress.XtraEditors.LookUpEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.shopOccupancyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.shopOccupancyGridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLevelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAPCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOccupiedAreaSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentPerSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScPerSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnoccupiedFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnoccupiedTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLossOfRentperSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLossOfSCperSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentAreaType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnOccupiedMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNaration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dateEditDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocaiton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyGridControl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colUnOccupiedAreaSqft
            // 
            this.colUnOccupiedAreaSqft.Caption = "Unoccupied Sq.Ft.";
            this.colUnOccupiedAreaSqft.DisplayFormat.FormatString = "n2";
            this.colUnOccupiedAreaSqft.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnOccupiedAreaSqft.FieldName = "UnOccupiedAreaSqft";
            this.colUnOccupiedAreaSqft.Name = "colUnOccupiedAreaSqft";
            this.colUnOccupiedAreaSqft.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UnOccupiedAreaSqft", "{0:n2}")});
            this.colUnOccupiedAreaSqft.Visible = true;
            this.colUnOccupiedAreaSqft.VisibleIndex = 4;
            this.colUnOccupiedAreaSqft.Width = 131;
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
            this.lookCompany.EditValue = "";
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
            this.lookCompany.EditValueChanged += new System.EventHandler(this.chkCompany_EditValueChanged);
            // 
            // lookLocaiton
            // 
            this.lookLocaiton.EditValue = "";
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
            this.lookLocaiton.EditValueChanged += new System.EventHandler(this.chkLocaiton_EditValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(1023, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 63);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::MMS.Properties.Resources.printer1;
            this.btnPrint.Location = new System.Drawing.Point(893, 52);
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
            this.btnPreview.Location = new System.Drawing.Point(893, 18);
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
            this.shopOccupancyGridControl.Location = new System.Drawing.Point(12, 101);
            this.shopOccupancyGridControl.MainView = this.gridView1;
            this.shopOccupancyGridControl.Name = "shopOccupancyGridControl";
            this.shopOccupancyGridControl.Size = new System.Drawing.Size(1100, 331);
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
            this.colSAPCustomerCode,
            this.colCustomerName,
            this.colOccupiedAreaSqFt,
            this.colUnOccupiedAreaSqft,
            this.colRentPerSqFt,
            this.colScPerSqFt,
            this.colUnoccupiedFrom,
            this.colUnoccupiedTo,
            this.colLossOfRentperSqFt,
            this.colLossOfSCperSqFt,
            this.colShopNo,
            this.colRentAreaType,
            this.colUnOccupiedMonth,
            this.colNaration,
            this.colShopSqFt});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colCustomerName;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "VACANT";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.shopOccupancyGridControl;
            this.gridView1.GroupCount = 4;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLevelName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRentAreaType, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ViewCaption = "View List of Occupied/Unoccupied Shops";
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
            // colSAPCustomerCode
            // 
            this.colSAPCustomerCode.Caption = "SAP Code";
            this.colSAPCustomerCode.FieldName = "SAPCustomerCode";
            this.colSAPCustomerCode.Name = "colSAPCustomerCode";
            this.colSAPCustomerCode.Width = 143;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "Customer";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
            this.colCustomerName.Width = 232;
            // 
            // colOccupiedAreaSqFt
            // 
            this.colOccupiedAreaSqFt.Caption = "Occupied Sq.Ft.";
            this.colOccupiedAreaSqFt.DisplayFormat.FormatString = "n2";
            this.colOccupiedAreaSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOccupiedAreaSqFt.FieldName = "OccupiedAreaSqFt";
            this.colOccupiedAreaSqFt.Name = "colOccupiedAreaSqFt";
            this.colOccupiedAreaSqFt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OccupiedAreaSqFt", "{0:n4}")});
            this.colOccupiedAreaSqFt.Visible = true;
            this.colOccupiedAreaSqFt.VisibleIndex = 3;
            this.colOccupiedAreaSqFt.Width = 99;
            // 
            // colRentPerSqFt
            // 
            this.colRentPerSqFt.Caption = "Rent/Sq.Ft";
            this.colRentPerSqFt.DisplayFormat.FormatString = "n2";
            this.colRentPerSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRentPerSqFt.FieldName = "RentPerSqFt";
            this.colRentPerSqFt.Name = "colRentPerSqFt";
            this.colRentPerSqFt.Width = 92;
            // 
            // colScPerSqFt
            // 
            this.colScPerSqFt.Caption = "SC/Sq.Ft";
            this.colScPerSqFt.DisplayFormat.FormatString = "n2";
            this.colScPerSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colScPerSqFt.FieldName = "ScPerSqFt";
            this.colScPerSqFt.Name = "colScPerSqFt";
            this.colScPerSqFt.Width = 80;
            // 
            // colUnoccupiedFrom
            // 
            this.colUnoccupiedFrom.FieldName = "UnoccupiedFrom";
            this.colUnoccupiedFrom.Name = "colUnoccupiedFrom";
            this.colUnoccupiedFrom.Visible = true;
            this.colUnoccupiedFrom.VisibleIndex = 5;
            this.colUnoccupiedFrom.Width = 104;
            // 
            // colUnoccupiedTo
            // 
            this.colUnoccupiedTo.FieldName = "UnoccupiedTo";
            this.colUnoccupiedTo.Name = "colUnoccupiedTo";
            this.colUnoccupiedTo.Width = 92;
            // 
            // colLossOfRentperSqFt
            // 
            this.colLossOfRentperSqFt.FieldName = "LossOfRentperSqFt";
            this.colLossOfRentperSqFt.Name = "colLossOfRentperSqFt";
            this.colLossOfRentperSqFt.Width = 128;
            // 
            // colLossOfSCperSqFt
            // 
            this.colLossOfSCperSqFt.FieldName = "LossOfSCperSqFt";
            this.colLossOfSCperSqFt.Name = "colLossOfSCperSqFt";
            this.colLossOfSCperSqFt.Width = 118;
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 0;
            this.colShopNo.Width = 225;
            // 
            // colRentAreaType
            // 
            this.colRentAreaType.FieldName = "RentAreaType";
            this.colRentAreaType.Name = "colRentAreaType";
            this.colRentAreaType.Visible = true;
            this.colRentAreaType.VisibleIndex = 1;
            this.colRentAreaType.Width = 139;
            // 
            // colUnOccupiedMonth
            // 
            this.colUnOccupiedMonth.Caption = "Unoccupied Period (Month)";
            this.colUnOccupiedMonth.DisplayFormat.FormatString = "n2";
            this.colUnOccupiedMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnOccupiedMonth.FieldName = "UnOccupiedMonth";
            this.colUnOccupiedMonth.Name = "colUnOccupiedMonth";
            this.colUnOccupiedMonth.Width = 151;
            // 
            // colNaration
            // 
            this.colNaration.FieldName = "Naration";
            this.colNaration.Name = "colNaration";
            this.colNaration.Visible = true;
            this.colNaration.VisibleIndex = 6;
            // 
            // colShopSqFt
            // 
            this.colShopSqFt.DisplayFormat.FormatString = "n2";
            this.colShopSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colShopSqFt.FieldName = "ShopSqFt";
            this.colShopSqFt.Name = "colShopSqFt";
            this.colShopSqFt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ShopSqFt", "{0:n2}")});
            this.colShopSqFt.Visible = true;
            this.colShopSqFt.VisibleIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dateEditDate);
            this.groupControl1.Location = new System.Drawing.Point(404, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(172, 75);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Date";
            // 
            // dateEditDate
            // 
            this.dateEditDate.EditValue = null;
            this.dateEditDate.Location = new System.Drawing.Point(23, 34);
            this.dateEditDate.Name = "dateEditDate";
            this.dateEditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEditDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditDate.Size = new System.Drawing.Size(132, 20);
            this.dateEditDate.TabIndex = 0;
            // 
            // xOccupancyAndUnoccupancy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 444);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.shopOccupancyGridControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.panelControl1);
            this.Name = "xOccupancyAndUnoccupancy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Occupancy and Unoccupancy Report";
            this.Load += new System.EventHandler(this.xOccupancyAndUnoccupancy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocaiton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyGridControl)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
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
        private DevExpress.XtraGrid.Columns.GridColumn colSAPCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colOccupiedAreaSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colUnOccupiedAreaSqft;
        private DevExpress.XtraGrid.Columns.GridColumn colRentPerSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colScPerSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colUnoccupiedFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colUnoccupiedTo;
        private DevExpress.XtraGrid.Columns.GridColumn colLossOfRentperSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colLossOfSCperSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colRentAreaType;
        private DevExpress.XtraGrid.Columns.GridColumn colUnOccupiedMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colNaration;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colShopSqFt;
        protected DevExpress.XtraEditors.GroupControl groupControl1;
        protected DevExpress.XtraEditors.DateEdit dateEditDate;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LookUpEdit lookLocaiton;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}