namespace MMS.MIS
{
    partial class xUtilityConsumption
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lookUtility = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditFrom = new DevExpress.XtraEditors.DateEdit();
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
            this.colSAPCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentAreaType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartReading = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndReading = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUtilityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNosUnitsConsumed1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUtilityUnitRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubInvoiceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeterName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRatio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.lookLocaiton = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUtility.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyGridControl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocaiton.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lookUtility);
            this.groupControl2.Location = new System.Drawing.Point(256, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(200, 75);
            this.groupControl2.TabIndex = 14;
            this.groupControl2.Text = "Utility";
            // 
            // lookUtility
            // 
            this.lookUtility.EditValue = "";
            this.lookUtility.Location = new System.Drawing.Point(12, 38);
            this.lookUtility.Name = "lookUtility";
            this.lookUtility.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUtility.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UtilityID", "UtilityID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UtilityName", "UtilityName")});
            this.lookUtility.Properties.NullText = "";
            this.lookUtility.Size = new System.Drawing.Size(174, 20);
            this.lookUtility.TabIndex = 0;
            this.lookUtility.EditValueChanged += new System.EventHandler(this.lookUtility_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.dateEditTo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.dateEditFrom);
            this.groupControl1.Location = new System.Drawing.Point(462, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(286, 75);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "Date";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(153, 40);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(19, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "To :";
            // 
            // dateEditTo
            // 
            this.dateEditTo.EditValue = null;
            this.dateEditTo.Location = new System.Drawing.Point(175, 37);
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
            this.dateEditFrom.EditValueChanged += new System.EventHandler(this.dateEditFrom_EditValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(1137, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 62);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::MMS.Properties.Resources.printer1;
            this.btnPrint.Location = new System.Drawing.Point(1007, 52);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 29);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Image = global::MMS.Properties.Resources.document_view;
            this.btnPreview.Location = new System.Drawing.Point(1007, 18);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(124, 29);
            this.btnPreview.TabIndex = 15;
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
            this.shopOccupancyGridControl.Location = new System.Drawing.Point(12, 93);
            this.shopOccupancyGridControl.MainView = this.gridView1;
            this.shopOccupancyGridControl.Name = "shopOccupancyGridControl";
            this.shopOccupancyGridControl.Size = new System.Drawing.Size(1203, 435);
            this.shopOccupancyGridControl.TabIndex = 18;
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
            this.colShopNo,
            this.colRentAreaType,
            this.colMonth,
            this.colYear,
            this.colStartReading,
            this.colEndReading,
            this.colUtilityName,
            this.colOtherTax,
            this.colAmount,
            this.colTotalAmount,
            this.colNosUnitsConsumed1,
            this.colUtilityUnitRate,
            this.colSubInvoiceType,
            this.colMeterName,
            this.colRatio});
            this.gridView1.GridControl = this.shopOccupancyGridControl;
            this.gridView1.GroupCount = 3;
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUtilityName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ViewCaption = "Utility Consumption";
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
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
            this.colCustomerName.Width = 232;
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 0;
            this.colShopNo.Width = 142;
            // 
            // colRentAreaType
            // 
            this.colRentAreaType.FieldName = "RentAreaType";
            this.colRentAreaType.Name = "colRentAreaType";
            this.colRentAreaType.Width = 139;
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
            // colStartReading
            // 
            this.colStartReading.DisplayFormat.FormatString = "n2";
            this.colStartReading.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStartReading.FieldName = "StartReading";
            this.colStartReading.Name = "colStartReading";
            this.colStartReading.Visible = true;
            this.colStartReading.VisibleIndex = 3;
            this.colStartReading.Width = 93;
            // 
            // colEndReading
            // 
            this.colEndReading.DisplayFormat.FormatString = "n2";
            this.colEndReading.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEndReading.FieldName = "EndReading";
            this.colEndReading.Name = "colEndReading";
            this.colEndReading.Visible = true;
            this.colEndReading.VisibleIndex = 4;
            this.colEndReading.Width = 88;
            // 
            // colUtilityName
            // 
            this.colUtilityName.FieldName = "UtilityName";
            this.colUtilityName.Name = "colUtilityName";
            this.colUtilityName.Visible = true;
            this.colUtilityName.VisibleIndex = 1;
            this.colUtilityName.Width = 92;
            // 
            // colOtherTax
            // 
            this.colOtherTax.Caption = "VAT";
            this.colOtherTax.DisplayFormat.FormatString = "n2";
            this.colOtherTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOtherTax.FieldName = "OtherTax";
            this.colOtherTax.Name = "colOtherTax";
            this.colOtherTax.Visible = true;
            this.colOtherTax.VisibleIndex = 9;
            this.colOtherTax.Width = 61;
            // 
            // colAmount
            // 
            this.colAmount.DisplayFormat.FormatString = "n2";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 8;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalAmount.AppearanceCell.Options.UseFont = true;
            this.colTotalAmount.DisplayFormat.FormatString = "n2";
            this.colTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalAmount.FieldName = "TotalAmount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.Visible = true;
            this.colTotalAmount.VisibleIndex = 10;
            this.colTotalAmount.Width = 86;
            // 
            // colNosUnitsConsumed1
            // 
            this.colNosUnitsConsumed1.Caption = "Units";
            this.colNosUnitsConsumed1.DisplayFormat.FormatString = "n2";
            this.colNosUnitsConsumed1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNosUnitsConsumed1.FieldName = "NosUnitsConsumed1";
            this.colNosUnitsConsumed1.Name = "colNosUnitsConsumed1";
            this.colNosUnitsConsumed1.Visible = true;
            this.colNosUnitsConsumed1.VisibleIndex = 5;
            this.colNosUnitsConsumed1.Width = 74;
            // 
            // colUtilityUnitRate
            // 
            this.colUtilityUnitRate.Caption = "Unit Rate";
            this.colUtilityUnitRate.DisplayFormat.FormatString = "n2";
            this.colUtilityUnitRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUtilityUnitRate.FieldName = "UtilityUnitRate";
            this.colUtilityUnitRate.Name = "colUtilityUnitRate";
            this.colUtilityUnitRate.Visible = true;
            this.colUtilityUnitRate.VisibleIndex = 6;
            // 
            // colSubInvoiceType
            // 
            this.colSubInvoiceType.Caption = "Doc.Type";
            this.colSubInvoiceType.FieldName = "SubInvoiceType";
            this.colSubInvoiceType.Name = "colSubInvoiceType";
            this.colSubInvoiceType.Width = 81;
            // 
            // colMeterName
            // 
            this.colMeterName.FieldName = "MeterName";
            this.colMeterName.Name = "colMeterName";
            this.colMeterName.Visible = true;
            this.colMeterName.VisibleIndex = 2;
            this.colMeterName.Width = 90;
            // 
            // colRatio
            // 
            this.colRatio.FieldName = "Ratio";
            this.colRatio.Name = "colRatio";
            this.colRatio.Visible = true;
            this.colRatio.VisibleIndex = 7;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lookCompany);
            this.panelControl1.Controls.Add(this.lookLocaiton);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(238, 75);
            this.panelControl1.TabIndex = 19;
            // 
            // lookCompany
            // 
            this.lookCompany.EditValue = "";
            this.lookCompany.Location = new System.Drawing.Point(79, 14);
            this.lookCompany.Name = "lookCompany";
            this.lookCompany.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.lookCompany.Properties.NullText = "";
            this.lookCompany.Size = new System.Drawing.Size(142, 20);
            this.lookCompany.TabIndex = 5;
            this.lookCompany.EditValueChanged += new System.EventHandler(this.lookCompany_EditValueChanged);
            // 
            // lookLocaiton
            // 
            this.lookLocaiton.EditValue = "";
            this.lookLocaiton.Location = new System.Drawing.Point(79, 40);
            this.lookLocaiton.Name = "lookLocaiton";
            this.lookLocaiton.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookLocaiton.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocaiton.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.lookLocaiton.Properties.NullText = "";
            this.lookLocaiton.Size = new System.Drawing.Size(142, 20);
            this.lookLocaiton.TabIndex = 6;
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
            // xUtilityConsumption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 540);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.shopOccupancyGridControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "xUtilityConsumption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utility Consumption  - MIS";
            this.Load += new System.EventHandler(this.xUtilityConsumption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUtility.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyGridControl)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocaiton.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        protected DevExpress.XtraEditors.GroupControl groupControl1;
        protected DevExpress.XtraEditors.DateEdit dateEditFrom;
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
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colRentAreaType;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colStartReading;
        private DevExpress.XtraGrid.Columns.GridColumn colEndReading;
        private DevExpress.XtraGrid.Columns.GridColumn colUtilityName;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherTax;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colNosUnitsConsumed1;
        private DevExpress.XtraGrid.Columns.GridColumn colUtilityUnitRate;
        private DevExpress.XtraGrid.Columns.GridColumn colSubInvoiceType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private DevExpress.XtraEditors.LookUpEdit lookUtility;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        protected DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        protected DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LookUpEdit lookLocaiton;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colMeterName;
        private DevExpress.XtraGrid.Columns.GridColumn colRatio;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}