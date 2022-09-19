namespace MMS
{
    partial class AllInvoicesForShop
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
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.cachedrptInvoice1 = new MMS.Reports.CachedrptInvoice();
            this.cachedrptInvoice2 = new MMS.Reports.CachedrptInvoice();
            this.lblShopNo = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpShopNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblMonthYear = new DevExpress.XtraEditors.LabelControl();
            this.dateEditMonthYear = new DevExpress.XtraEditors.DateEdit();
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPrintAll = new DevExpress.XtraEditors.SimpleButton();
            this.chkSelectAll = new DevExpress.XtraEditors.CheckButton();
            this.colConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAllInvoicess = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colConfirm1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalRent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblDateTo = new DevExpress.XtraEditors.LabelControl();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.btnsaveToDisk = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lookLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cachedrptInvoice3 = new MMS.Reports.CachedrptInvoice();
            this.cachedrptInvoice4 = new MMS.Reports.CachedrptInvoice();
            this.chkSignature = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpShopNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonthYear.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonthYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllInvoicess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblShopNo
            // 
            this.lblShopNo.Location = new System.Drawing.Point(398, 53);
            this.lblShopNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblShopNo.Name = "lblShopNo";
            this.lblShopNo.Size = new System.Drawing.Size(57, 16);
            this.lblShopNo.TabIndex = 0;
            this.lblShopNo.Text = "Shop No :";
            // 
            // searchLookUpShopNo
            // 
            this.searchLookUpShopNo.EditValue = "";
            this.searchLookUpShopNo.EnterMoveNextControl = true;
            this.searchLookUpShopNo.Location = new System.Drawing.Point(510, 49);
            this.searchLookUpShopNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchLookUpShopNo.Name = "searchLookUpShopNo";
            this.searchLookUpShopNo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.searchLookUpShopNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpShopNo.Properties.NullText = "";
            this.searchLookUpShopNo.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpShopNo.Size = new System.Drawing.Size(304, 22);
            this.searchLookUpShopNo.TabIndex = 1;
            this.searchLookUpShopNo.EditValueChanged += new System.EventHandler(this.searchLookUpShopNo_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.Location = new System.Drawing.Point(398, 87);
            this.lblMonthYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(109, 16);
            this.lblMonthYear.TabIndex = 2;
            this.lblMonthYear.Text = "Month/Year From :";
            // 
            // dateEditMonthYear
            // 
            this.dateEditMonthYear.EditValue = null;
            this.dateEditMonthYear.Location = new System.Drawing.Point(510, 84);
            this.dateEditMonthYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditMonthYear.Name = "dateEditMonthYear";
            this.dateEditMonthYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditMonthYear.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditMonthYear.Properties.DisplayFormat.FormatString = "y";
            this.dateEditMonthYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditMonthYear.Properties.EditFormat.FormatString = "y";
            this.dateEditMonthYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditMonthYear.Properties.Mask.EditMask = "y";
            this.dateEditMonthYear.Size = new System.Drawing.Size(117, 22);
            this.dateEditMonthYear.TabIndex = 3;
            this.dateEditMonthYear.EditValueChanged += new System.EventHandler(this.dateEditMonthYear_EditValueChanged);
            // 
            // invoiceBindingSource
            // 
            this.invoiceBindingSource.DataSource = typeof(MMS.cGen_Rent_Invoice);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Enabled = false;
            this.btnPrintAll.Image = global::MMS.Properties.Resources.printer1;
            this.btnPrintAll.Location = new System.Drawing.Point(895, 28);
            this.btnPrintAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(103, 41);
            this.btnPrintAll.TabIndex = 5;
            this.btnPrintAll.Text = "Email All";
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Enabled = false;
            this.chkSelectAll.Location = new System.Drawing.Point(14, 138);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(87, 28);
            this.chkSelectAll.TabIndex = 6;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // colConfirm
            // 
            this.colConfirm.Name = "colConfirm";
            this.colConfirm.OptionsColumn.TabStop = false;
            // 
            // gvAllInvoicess
            // 
            this.gvAllInvoicess.DataSource = this.invoiceBindingSource;
            this.gvAllInvoicess.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gvAllInvoicess.Location = new System.Drawing.Point(14, 174);
            this.gvAllInvoicess.MainView = this.gridView1;
            this.gvAllInvoicess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gvAllInvoicess.Name = "gvAllInvoicess";
            this.gvAllInvoicess.Size = new System.Drawing.Size(1049, 350);
            this.gvAllInvoicess.TabIndex = 7;
            this.gvAllInvoicess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colConfirm1,
            this.colInvoiceNo,
            this.colLocationCode,
            this.colLevelCode,
            this.colShopNo,
            this.colShopName,
            this.colCustomerName,
            this.colTotalRent,
            this.colInvDate});
            this.gridView1.GridControl = this.gvAllInvoicess;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // colConfirm1
            // 
            this.colConfirm1.FieldName = "Confirm";
            this.colConfirm1.Name = "colConfirm1";
            this.colConfirm1.Visible = true;
            this.colConfirm1.VisibleIndex = 0;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.FieldName = "InvoiceNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 1;
            // 
            // colLocationCode
            // 
            this.colLocationCode.FieldName = "LocationCode";
            this.colLocationCode.Name = "colLocationCode";
            this.colLocationCode.Visible = true;
            this.colLocationCode.VisibleIndex = 2;
            // 
            // colLevelCode
            // 
            this.colLevelCode.FieldName = "LevelCode";
            this.colLevelCode.Name = "colLevelCode";
            this.colLevelCode.Visible = true;
            this.colLevelCode.VisibleIndex = 3;
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 4;
            // 
            // colShopName
            // 
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 5;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 6;
            // 
            // colTotalRent
            // 
            this.colTotalRent.FieldName = "TotalRent";
            this.colTotalRent.Name = "colTotalRent";
            this.colTotalRent.Visible = true;
            this.colTotalRent.VisibleIndex = 7;
            // 
            // colInvDate
            // 
            this.colInvDate.FieldName = "InvDate";
            this.colInvDate.Name = "colInvDate";
            this.colInvDate.Visible = true;
            this.colInvDate.VisibleIndex = 8;
            // 
            // lblDateTo
            // 
            this.lblDateTo.Location = new System.Drawing.Point(645, 87);
            this.lblDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(24, 16);
            this.lblDateTo.TabIndex = 8;
            this.lblDateTo.Text = "To :";
            // 
            // dateEditTo
            // 
            this.dateEditTo.EditValue = null;
            this.dateEditTo.Location = new System.Drawing.Point(698, 84);
            this.dateEditTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditTo.Name = "dateEditTo";
            this.dateEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Properties.DisplayFormat.FormatString = "y";
            this.dateEditTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditTo.Properties.EditFormat.FormatString = "y";
            this.dateEditTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditTo.Properties.Mask.EditMask = "y";
            this.dateEditTo.Size = new System.Drawing.Size(117, 22);
            this.dateEditTo.TabIndex = 9;
            this.dateEditTo.EditValueChanged += new System.EventHandler(this.dateEditTo_EditValueChanged);
            // 
            // btnsaveToDisk
            // 
            this.btnsaveToDisk.Enabled = false;
            this.btnsaveToDisk.Image = global::MMS.Properties.Resources.disk_blue1;
            this.btnsaveToDisk.Location = new System.Drawing.Point(895, 76);
            this.btnsaveToDisk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsaveToDisk.Name = "btnsaveToDisk";
            this.btnsaveToDisk.Size = new System.Drawing.Size(103, 41);
            this.btnsaveToDisk.TabIndex = 10;
            this.btnsaveToDisk.Text = "Save to disk";
            this.btnsaveToDisk.Click += new System.EventHandler(this.btnsaveToDisk_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lookLocation);
            this.groupControl1.Controls.Add(this.lookCompany);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(48, 15);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(296, 116);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Company / Location";
            // 
            // lookLocation
            // 
            this.lookLocation.Location = new System.Drawing.Point(94, 71);
            this.lookLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookLocation.Name = "lookLocation";
            this.lookLocation.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Location ID", 77, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "Location Code", 78, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationName", "Location Name", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookLocation.Properties.DataSource = this.locationBindingSource;
            this.lookLocation.Properties.DisplayMember = "LocationCode";
            this.lookLocation.Properties.NullText = "";
            this.lookLocation.Properties.ValueMember = "LocationID";
            this.lookLocation.Size = new System.Drawing.Size(174, 22);
            this.lookLocation.TabIndex = 4;
            this.lookLocation.EditValueChanged += new System.EventHandler(this.lookLocation_EditValueChanged);
            // 
            // locationBindingSource
            // 
            this.locationBindingSource.DataSource = typeof(DataTier.Location);
            // 
            // lookCompany
            // 
            this.lookCompany.Location = new System.Drawing.Point(94, 39);
            this.lookCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookCompany.Name = "lookCompany";
            this.lookCompany.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "Company ID", 82, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "Company Code", 83, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Company Name", 85, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookCompany.Properties.DataSource = this.companyBindingSource;
            this.lookCompany.Properties.DisplayMember = "CompanyCode";
            this.lookCompany.Properties.NullText = "";
            this.lookCompany.Properties.ValueMember = "CompanyID";
            this.lookCompany.Size = new System.Drawing.Size(174, 22);
            this.lookCompany.TabIndex = 3;
            this.lookCompany.EditValueChanged += new System.EventHandler(this.lookCompany_EditValueChanged);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(DataTier.Company);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 76);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Location :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 44);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Company :";
            // 
            // groupControl2
            // 
            this.groupControl2.Location = new System.Drawing.Point(379, 15);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(464, 116);
            this.groupControl2.TabIndex = 12;
            this.groupControl2.Text = "Shop Name /Month /Year";
            // 
            // chkSignature
            // 
            this.chkSignature.AutoSize = true;
            this.chkSignature.Location = new System.Drawing.Point(698, 145);
            this.chkSignature.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSignature.Name = "chkSignature";
            this.chkSignature.Size = new System.Drawing.Size(153, 21);
            this.chkSignature.TabIndex = 22;
            this.chkSignature.Text = "Print With Signature";
            this.chkSignature.UseVisualStyleBackColor = true;
            this.chkSignature.CheckedChanged += new System.EventHandler(this.chkSignature_CheckedChanged);
            // 
            // AllInvoicesForShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 538);
            this.Controls.Add(this.chkSignature);
            this.Controls.Add(this.btnsaveToDisk);
            this.Controls.Add(this.dateEditTo);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.gvAllInvoicess);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnPrintAll);
            this.Controls.Add(this.dateEditMonthYear);
            this.Controls.Add(this.lblMonthYear);
            this.Controls.Add(this.searchLookUpShopNo);
            this.Controls.Add(this.lblShopNo);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AllInvoicesForShop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multiple Invoices For Email";
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpShopNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonthYear.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonthYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllInvoicess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Reports.CachedrptInvoice cachedrptInvoice1;
        private Reports.CachedrptInvoice cachedrptInvoice2;
        private DevExpress.XtraEditors.LabelControl lblShopNo;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpShopNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl lblMonthYear;
        private DevExpress.XtraEditors.DateEdit dateEditMonthYear;
        private System.Windows.Forms.BindingSource invoiceBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnPrintAll;
        private DevExpress.XtraEditors.CheckButton chkSelectAll;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirm;
        private DevExpress.XtraGrid.GridControl gvAllInvoicess;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirm1;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelCode;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalRent;
        private DevExpress.XtraGrid.Columns.GridColumn colInvDate;
        private DevExpress.XtraEditors.LabelControl lblDateTo;
        private DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.SimpleButton btnsaveToDisk;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit lookLocation;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private Reports.CachedrptInvoice cachedrptInvoice3;
        private Reports.CachedrptInvoice cachedrptInvoice4;
        private System.Windows.Forms.CheckBox chkSignature;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}