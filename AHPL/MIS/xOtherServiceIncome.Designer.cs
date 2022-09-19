namespace MMS.MIS
{
    partial class xOtherServiceIncome
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
            this.lookLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.shopOccupancyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.shopOccupancyGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLevelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAPCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOccupiedAreaSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnOccupiedAreaSqft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentPerSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScPerSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnoccupiedFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnoccupiedTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLossOfRentperSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLossOfSCperSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentAreaType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNaration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalRentPerMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditFrom = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lookCompany);
            this.panelControl1.Controls.Add(this.lookLocation);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(386, 103);
            this.panelControl1.TabIndex = 15;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Location :";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Company : ";
            // 
            // lookCompany
            // 
            this.lookCompany.Location = new System.Drawing.Point(73, 33);
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
            // lookLocation
            // 
            this.lookLocation.Location = new System.Drawing.Point(73, 60);
            this.lookLocation.Name = "lookLocation";
            this.lookLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.lookLocation.Properties.NullText = "";
            this.lookLocation.Size = new System.Drawing.Size(286, 20);
            this.lookLocation.TabIndex = 4;
            this.lookLocation.EditValueChanged += new System.EventHandler(this.lookLocation_EditValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(923, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 63);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::MMS.Properties.Resources.printer1;
            this.btnPrint.Location = new System.Drawing.Point(793, 59);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 29);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Image = global::MMS.Properties.Resources.document_view;
            this.btnPreview.Location = new System.Drawing.Point(793, 25);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(124, 29);
            this.btnPreview.TabIndex = 17;
            this.btnPreview.Text = "Preview ";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // shopOccupancyBindingSource
            // 
            this.shopOccupancyBindingSource.DataSource = typeof(DataTier.ReportClasses.ShopOccupancy);
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
            this.shopOccupancyGridControl.DataSource = this.shopOccupancyBindingSource;
            this.shopOccupancyGridControl.Location = new System.Drawing.Point(12, 121);
            this.shopOccupancyGridControl.MainView = this.gridView1;
            this.shopOccupancyGridControl.Name = "shopOccupancyGridControl";
            this.shopOccupancyGridControl.Size = new System.Drawing.Size(994, 379);
            this.shopOccupancyGridControl.TabIndex = 21;
            this.shopOccupancyGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.colNaration,
            this.colMonth,
            this.colYear,
            this.colTotalRentPerMonth,
            this.colOtherServiceName});
            this.gridView1.GridControl = this.shopOccupancyGridControl;
            this.gridView1.GroupCount = 2;
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLocationCode, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ViewCaption = "View Promotional Income Summary";
            // 
            // colLevelName
            // 
            this.colLevelName.FieldName = "LevelName";
            this.colLevelName.Name = "colLevelName";
            this.colLevelName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
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
            this.colCustomerName.Width = 157;
            // 
            // colOccupiedAreaSqFt
            // 
            this.colOccupiedAreaSqFt.Caption = "Sq.Ft";
            this.colOccupiedAreaSqFt.DisplayFormat.FormatString = "n4";
            this.colOccupiedAreaSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOccupiedAreaSqFt.FieldName = "OccupiedAreaSqFt";
            this.colOccupiedAreaSqFt.Name = "colOccupiedAreaSqFt";
            this.colOccupiedAreaSqFt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OccupiedAreaSqFt", "{0:n4}")});
            this.colOccupiedAreaSqFt.Width = 88;
            // 
            // colUnOccupiedAreaSqft
            // 
            this.colUnOccupiedAreaSqft.FieldName = "UnOccupiedAreaSqft";
            this.colUnOccupiedAreaSqft.Name = "colUnOccupiedAreaSqft";
            this.colUnOccupiedAreaSqft.Width = 131;
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
            this.colShopNo.Width = 225;
            // 
            // colRentAreaType
            // 
            this.colRentAreaType.FieldName = "RentAreaType";
            this.colRentAreaType.Name = "colRentAreaType";
            this.colRentAreaType.Width = 139;
            // 
            // colNaration
            // 
            this.colNaration.FieldName = "Naration";
            this.colNaration.Name = "colNaration";
            this.colNaration.Width = 223;
            // 
            // colMonth
            // 
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            // 
            // colYear
            // 
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            // 
            // colTotalRentPerMonth
            // 
            this.colTotalRentPerMonth.Caption = "Total";
            this.colTotalRentPerMonth.FieldName = "TotalRentPerMonth";
            this.colTotalRentPerMonth.Name = "colTotalRentPerMonth";
            this.colTotalRentPerMonth.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalRentPerMonth", "{0:n2}")});
            this.colTotalRentPerMonth.Visible = true;
            this.colTotalRentPerMonth.VisibleIndex = 1;
            this.colTotalRentPerMonth.Width = 124;
            // 
            // colOtherServiceName
            // 
            this.colOtherServiceName.FieldName = "OtherServiceName";
            this.colOtherServiceName.Name = "colOtherServiceName";
            this.colOtherServiceName.Visible = true;
            this.colOtherServiceName.VisibleIndex = 0;
            this.colOtherServiceName.Width = 300;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.dateEditTo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.dateEditFrom);
            this.groupControl1.Location = new System.Drawing.Point(404, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(157, 102);
            this.groupControl1.TabIndex = 22;
            this.groupControl1.Text = "Date Range";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(22, 66);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(19, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "To :";
            // 
            // dateEditTo
            // 
            this.dateEditTo.EditValue = null;
            this.dateEditTo.Location = new System.Drawing.Point(47, 63);
            this.dateEditTo.Name = "dateEditTo";
            this.dateEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEditTo.Size = new System.Drawing.Size(92, 20);
            this.dateEditTo.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 40);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "From :";
            // 
            // dateEditFrom
            // 
            this.dateEditFrom.EditValue = null;
            this.dateEditFrom.Location = new System.Drawing.Point(47, 37);
            this.dateEditFrom.Name = "dateEditFrom";
            this.dateEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEditFrom.Size = new System.Drawing.Size(92, 20);
            this.dateEditFrom.TabIndex = 0;
            // 
            // xOtherServiceIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 512);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.shopOccupancyGridControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.panelControl1);
            this.Name = "xOtherServiceIncome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Other Service Income - Summary";
            this.Load += new System.EventHandler(this.xOtherServiceIncome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LookUpEdit lookLocation;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private System.Windows.Forms.BindingSource shopOccupancyBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
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
        private DevExpress.XtraGrid.Columns.GridColumn colNaration;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalRentPerMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherServiceName;
        protected DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        protected DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        protected DevExpress.XtraEditors.DateEdit dateEditFrom;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}