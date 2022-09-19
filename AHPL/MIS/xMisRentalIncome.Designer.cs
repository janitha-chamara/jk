namespace MMS.MIS
{
    partial class xMisRentalIncome
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
            this.colIsVacant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dateEditDate = new DevExpress.XtraEditors.DateEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.lookLocaiton = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
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
            this.colSAPCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentPerMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSCperMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandatoryTaxAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalWithMandatoryTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentWithSCperMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalRentPerMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopSqFt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubInvoiceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocaiton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopOccupancyGridControl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // colIsVacant
            // 
            this.colIsVacant.FieldName = "IsVacant";
            this.colIsVacant.Name = "colIsVacant";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dateEditDate);
            this.groupControl1.Location = new System.Drawing.Point(256, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(172, 75);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Month / Year";
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
            this.dateEditDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dateEditDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dateEditDate.Properties.DisplayFormat.FormatString = "y";
            this.dateEditDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDate.Properties.EditFormat.FormatString = "y";
            this.dateEditDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDate.Properties.Mask.EditMask = "y";
            this.dateEditDate.Size = new System.Drawing.Size(132, 20);
            this.dateEditDate.TabIndex = 0;
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
            this.panelControl1.TabIndex = 4;
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
            this.lookLocaiton.EditValueChanged += new System.EventHandler(this.lookLocaiton_EditValueChanged);
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
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(1013, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 63);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::MMS.Properties.Resources.printer1;
            this.btnPrint.Location = new System.Drawing.Point(883, 52);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 29);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Image = global::MMS.Properties.Resources.document_view;
            this.btnPreview.Location = new System.Drawing.Point(883, 18);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(124, 29);
            this.btnPreview.TabIndex = 10;
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
            this.shopOccupancyGridControl.Size = new System.Drawing.Size(1084, 377);
            this.shopOccupancyGridControl.TabIndex = 13;
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
            this.colSAPCustomerCode,
            this.colRentPerMonth,
            this.colSCperMonth,
            this.colMandatoryTaxAmount,
            this.colTotalWithMandatoryTax,
            this.colOtherTax,
            this.colRentWithSCperMonth,
            this.colTotalRentPerMonth,
            this.colMonth,
            this.colYear,
            this.colIsVacant,
            this.colShopSqFt,
            this.colSubInvoiceType});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colIsVacant;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
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
            this.gridView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCompanyCode, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLocationCode, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLevelName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSubInvoiceType, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ViewCaption = "Rental Income for the Month";
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
            this.colOccupiedAreaSqFt.DisplayFormat.FormatString = "n4";
            this.colOccupiedAreaSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOccupiedAreaSqFt.FieldName = "OccupiedAreaSqFt";
            this.colOccupiedAreaSqFt.Name = "colOccupiedAreaSqFt";
            this.colOccupiedAreaSqFt.Visible = true;
            this.colOccupiedAreaSqFt.VisibleIndex = 5;
            this.colOccupiedAreaSqFt.Width = 66;
            // 
            // colRentPerSqFt
            // 
            this.colRentPerSqFt.AppearanceCell.BackColor = System.Drawing.Color.PaleTurquoise;
            this.colRentPerSqFt.AppearanceCell.Options.UseBackColor = true;
            this.colRentPerSqFt.Caption = "Rent per Sq.Ft";
            this.colRentPerSqFt.DisplayFormat.FormatString = "n2";
            this.colRentPerSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRentPerSqFt.FieldName = "RentPerSqFt";
            this.colRentPerSqFt.Name = "colRentPerSqFt";
            this.colRentPerSqFt.Visible = true;
            this.colRentPerSqFt.VisibleIndex = 6;
            this.colRentPerSqFt.Width = 93;
            // 
            // colScPerSqFt
            // 
            this.colScPerSqFt.AppearanceCell.BackColor = System.Drawing.Color.PaleTurquoise;
            this.colScPerSqFt.AppearanceCell.Options.UseBackColor = true;
            this.colScPerSqFt.Caption = "S.C. per Sq.Ft";
            this.colScPerSqFt.DisplayFormat.FormatString = "n2";
            this.colScPerSqFt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colScPerSqFt.FieldName = "ScPerSqFt";
            this.colScPerSqFt.Name = "colScPerSqFt";
            this.colScPerSqFt.Visible = true;
            this.colScPerSqFt.VisibleIndex = 8;
            this.colScPerSqFt.Width = 91;
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 0;
            this.colShopNo.Width = 160;
            // 
            // colRentAreaType
            // 
            this.colRentAreaType.FieldName = "RentAreaType";
            this.colRentAreaType.Name = "colRentAreaType";
            this.colRentAreaType.Visible = true;
            this.colRentAreaType.VisibleIndex = 1;
            this.colRentAreaType.Width = 105;
            // 
            // colSAPCustomerCode
            // 
            this.colSAPCustomerCode.Caption = "SAP Code";
            this.colSAPCustomerCode.FieldName = "SAPCustomerCode";
            this.colSAPCustomerCode.Name = "colSAPCustomerCode";
            this.colSAPCustomerCode.Visible = true;
            this.colSAPCustomerCode.VisibleIndex = 2;
            this.colSAPCustomerCode.Width = 84;
            // 
            // colRentPerMonth
            // 
            this.colRentPerMonth.Caption = "Rent per Month";
            this.colRentPerMonth.DisplayFormat.FormatString = "n2";
            this.colRentPerMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRentPerMonth.FieldName = "RentPerMonth";
            this.colRentPerMonth.Name = "colRentPerMonth";
            this.colRentPerMonth.Visible = true;
            this.colRentPerMonth.VisibleIndex = 7;
            this.colRentPerMonth.Width = 97;
            // 
            // colSCperMonth
            // 
            this.colSCperMonth.Caption = "S.C. per Month";
            this.colSCperMonth.DisplayFormat.FormatString = "n2";
            this.colSCperMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSCperMonth.FieldName = "SCperMonth";
            this.colSCperMonth.Name = "colSCperMonth";
            this.colSCperMonth.Visible = true;
            this.colSCperMonth.VisibleIndex = 9;
            this.colSCperMonth.Width = 95;
            // 
            // colMandatoryTaxAmount
            // 
            this.colMandatoryTaxAmount.Caption = "NBT";
            this.colMandatoryTaxAmount.DisplayFormat.FormatString = "n2";
            this.colMandatoryTaxAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMandatoryTaxAmount.FieldName = "MandatoryTaxAmount";
            this.colMandatoryTaxAmount.Name = "colMandatoryTaxAmount";
            this.colMandatoryTaxAmount.Visible = true;
            this.colMandatoryTaxAmount.VisibleIndex = 10;
            this.colMandatoryTaxAmount.Width = 74;
            // 
            // colTotalWithMandatoryTax
            // 
            this.colTotalWithMandatoryTax.Caption = "Rent + SC + NBT";
            this.colTotalWithMandatoryTax.DisplayFormat.FormatString = "n2";
            this.colTotalWithMandatoryTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalWithMandatoryTax.FieldName = "TotalWithMandatoryTax";
            this.colTotalWithMandatoryTax.Name = "colTotalWithMandatoryTax";
            this.colTotalWithMandatoryTax.Visible = true;
            this.colTotalWithMandatoryTax.VisibleIndex = 11;
            this.colTotalWithMandatoryTax.Width = 99;
            // 
            // colOtherTax
            // 
            this.colOtherTax.Caption = "VAT";
            this.colOtherTax.DisplayFormat.FormatString = "n2";
            this.colOtherTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOtherTax.FieldName = "OtherTax";
            this.colOtherTax.Name = "colOtherTax";
            this.colOtherTax.Visible = true;
            this.colOtherTax.VisibleIndex = 12;
            this.colOtherTax.Width = 61;
            // 
            // colRentWithSCperMonth
            // 
            this.colRentWithSCperMonth.Caption = "Rent + SC ";
            this.colRentWithSCperMonth.DisplayFormat.FormatString = "n2";
            this.colRentWithSCperMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRentWithSCperMonth.FieldName = "RentWithSCperMonth";
            this.colRentWithSCperMonth.Name = "colRentWithSCperMonth";
            this.colRentWithSCperMonth.Visible = true;
            this.colRentWithSCperMonth.VisibleIndex = 13;
            this.colRentWithSCperMonth.Width = 89;
            // 
            // colTotalRentPerMonth
            // 
            this.colTotalRentPerMonth.Caption = "Total";
            this.colTotalRentPerMonth.DisplayFormat.FormatString = "n2";
            this.colTotalRentPerMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalRentPerMonth.FieldName = "TotalRentPerMonth";
            this.colTotalRentPerMonth.Name = "colTotalRentPerMonth";
            this.colTotalRentPerMonth.Visible = true;
            this.colTotalRentPerMonth.VisibleIndex = 14;
            this.colTotalRentPerMonth.Width = 86;
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
            // colShopSqFt
            // 
            this.colShopSqFt.FieldName = "ShopSqFt";
            this.colShopSqFt.Name = "colShopSqFt";
            this.colShopSqFt.Visible = true;
            this.colShopSqFt.VisibleIndex = 4;
            // 
            // colSubInvoiceType
            // 
            this.colSubInvoiceType.FieldName = "SubInvoiceType";
            this.colSubInvoiceType.Name = "colSubInvoiceType";
            this.colSubInvoiceType.Visible = true;
            this.colSubInvoiceType.VisibleIndex = 15;
            // 
            // xMisRentalIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 482);
            this.Controls.Add(this.shopOccupancyGridControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "xMisRentalIncome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rental Income for the Month";
            this.Load += new System.EventHandler(this.xMisRentalIncome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.GroupControl groupControl1;
        protected DevExpress.XtraEditors.DateEdit dateEditDate;
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
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colOccupiedAreaSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colRentPerSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colScPerSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colRentAreaType;
        private DevExpress.XtraGrid.Columns.GridColumn colSAPCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRentPerMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colSCperMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colMandatoryTaxAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalWithMandatoryTax;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherTax;
        private DevExpress.XtraGrid.Columns.GridColumn colRentWithSCperMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalRentPerMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colIsVacant;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LookUpEdit lookLocaiton;
        private DevExpress.XtraGrid.Columns.GridColumn colShopSqFt;
        private DevExpress.XtraGrid.Columns.GridColumn colSubInvoiceType;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}