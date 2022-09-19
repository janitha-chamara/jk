namespace MMS.Print
{
    partial class xAllInvoicesForShopname
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
            this.lblMonthYear = new DevExpress.XtraEditors.LabelControl();
            this.lblShopNo = new DevExpress.XtraEditors.LabelControl();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.lblDateTo = new DevExpress.XtraEditors.LabelControl();
            this.dateEditMonthYear = new DevExpress.XtraEditors.DateEdit();
            this.searchLookUpShopNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnPrintSave = new DevExpress.XtraEditors.SimpleButton();
            this.chkSelectAll = new DevExpress.XtraEditors.CheckButton();
            this.btnPrintAll = new DevExpress.XtraEditors.SimpleButton();
            this.gvAllInvoicess = new DevExpress.XtraGrid.GridControl();
            this.InvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lookLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.chkSignature = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonthYear.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonthYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpShopNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllInvoicess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.Location = new System.Drawing.Point(47, 76);
            this.lblMonthYear.Margin = new System.Windows.Forms.Padding(4);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(109, 16);
            this.lblMonthYear.TabIndex = 4;
            this.lblMonthYear.Text = "Month/Year From :";
            // 
            // lblShopNo
            // 
            this.lblShopNo.Location = new System.Drawing.Point(47, 36);
            this.lblShopNo.Margin = new System.Windows.Forms.Padding(4);
            this.lblShopNo.Name = "lblShopNo";
            this.lblShopNo.Size = new System.Drawing.Size(97, 16);
            this.lblShopNo.TabIndex = 3;
            this.lblShopNo.Text = "Customer Name:";
            // 
            // dateEditTo
            // 
            this.dateEditTo.EditValue = null;
            this.dateEditTo.Location = new System.Drawing.Point(391, 73);
            this.dateEditTo.Margin = new System.Windows.Forms.Padding(4);
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
            this.dateEditTo.Size = new System.Drawing.Size(133, 22);
            this.dateEditTo.TabIndex = 13;
            this.dateEditTo.EditValueChanged += new System.EventHandler(this.dateEditTo_EditValueChanged);
            // 
            // lblDateTo
            // 
            this.lblDateTo.Location = new System.Drawing.Point(343, 76);
            this.lblDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(24, 16);
            this.lblDateTo.TabIndex = 12;
            this.lblDateTo.Text = "To :";
            // 
            // dateEditMonthYear
            // 
            this.dateEditMonthYear.EditValue = null;
            this.dateEditMonthYear.Location = new System.Drawing.Point(175, 73);
            this.dateEditMonthYear.Margin = new System.Windows.Forms.Padding(4);
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
            this.dateEditMonthYear.Size = new System.Drawing.Size(133, 22);
            this.dateEditMonthYear.TabIndex = 11;
            this.dateEditMonthYear.EditValueChanged += new System.EventHandler(this.dateEditMonthYear_EditValueChanged);
            // 
            // searchLookUpShopNo
            // 
            this.searchLookUpShopNo.EditValue = "";
            this.searchLookUpShopNo.EnterMoveNextControl = true;
            this.searchLookUpShopNo.Location = new System.Drawing.Point(175, 32);
            this.searchLookUpShopNo.Margin = new System.Windows.Forms.Padding(4);
            this.searchLookUpShopNo.Name = "searchLookUpShopNo";
            this.searchLookUpShopNo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.searchLookUpShopNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpShopNo.Properties.NullText = "";
            this.searchLookUpShopNo.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpShopNo.Size = new System.Drawing.Size(349, 22);
            this.searchLookUpShopNo.TabIndex = 10;
            this.searchLookUpShopNo.EditValueChanged += new System.EventHandler(this.searchLookUpShopNo_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // btnPrintSave
            // 
            this.btnPrintSave.Image = global::MMS.Properties.Resources.disk_blue2;
            this.btnPrintSave.Location = new System.Drawing.Point(928, 171);
            this.btnPrintSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintSave.Name = "btnPrintSave";
            this.btnPrintSave.Size = new System.Drawing.Size(136, 41);
            this.btnPrintSave.TabIndex = 16;
            this.btnPrintSave.Text = "Print / Save";
            this.btnPrintSave.Click += new System.EventHandler(this.btnPrintSave_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Location = new System.Drawing.Point(16, 181);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(100, 28);
            this.chkSelectAll.TabIndex = 15;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Image = global::MMS.Properties.Resources.printer1;
            this.btnPrintAll.Location = new System.Drawing.Point(779, 171);
            this.btnPrintAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(136, 41);
            this.btnPrintAll.TabIndex = 14;
            this.btnPrintAll.Text = "Email All";
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // gvAllInvoicess
            // 
            this.gvAllInvoicess.DataSource = this.InvoiceBindingSource;
            this.gvAllInvoicess.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gvAllInvoicess.Location = new System.Drawing.Point(8, 219);
            this.gvAllInvoicess.MainView = this.gridView1;
            this.gvAllInvoicess.Margin = new System.Windows.Forms.Padding(4);
            this.gvAllInvoicess.Name = "gvAllInvoicess";
            this.gvAllInvoicess.Size = new System.Drawing.Size(1199, 281);
            this.gvAllInvoicess.TabIndex = 17;
            this.gvAllInvoicess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // InvoiceBindingSource
            // 
            this.InvoiceBindingSource.DataSource = typeof(MMS.cGen_Rent_Invoice);
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lookLocation);
            this.groupControl1.Controls.Add(this.lookCompany);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(31, 26);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(339, 116);
            this.groupControl1.TabIndex = 18;
            this.groupControl1.Text = "Company / Location";
            // 
            // lookLocation
            // 
            this.lookLocation.Location = new System.Drawing.Point(108, 71);
            this.lookLocation.Margin = new System.Windows.Forms.Padding(4);
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
            this.lookLocation.Size = new System.Drawing.Size(199, 22);
            this.lookLocation.TabIndex = 4;
            this.lookLocation.EditValueChanged += new System.EventHandler(this.lookLocation_EditValueChanged);
            // 
            // locationBindingSource
            // 
            this.locationBindingSource.DataSource = typeof(DataTier.Location);
            // 
            // lookCompany
            // 
            this.lookCompany.Location = new System.Drawing.Point(108, 39);
            this.lookCompany.Margin = new System.Windows.Forms.Padding(4);
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
            this.lookCompany.Size = new System.Drawing.Size(199, 22);
            this.lookCompany.TabIndex = 3;
            this.lookCompany.EditValueChanged += new System.EventHandler(this.lookCompany_EditValueChanged);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(DataTier.Company);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 76);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Location :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 44);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Company :";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dateEditTo);
            this.groupControl2.Controls.Add(this.lblShopNo);
            this.groupControl2.Controls.Add(this.lblMonthYear);
            this.groupControl2.Controls.Add(this.searchLookUpShopNo);
            this.groupControl2.Controls.Add(this.dateEditMonthYear);
            this.groupControl2.Controls.Add(this.lblDateTo);
            this.groupControl2.Location = new System.Drawing.Point(401, 26);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(663, 116);
            this.groupControl2.TabIndex = 19;
            this.groupControl2.Text = "Customer ";
            // 
            // chkSignature
            // 
            this.chkSignature.AutoSize = true;
            this.chkSignature.Location = new System.Drawing.Point(549, 171);
            this.chkSignature.Margin = new System.Windows.Forms.Padding(4);
            this.chkSignature.Name = "chkSignature";
            this.chkSignature.Size = new System.Drawing.Size(156, 21);
            this.chkSignature.TabIndex = 22;
            this.chkSignature.Text = "Print With Signature";
            this.chkSignature.UseVisualStyleBackColor = true;
            this.chkSignature.CheckedChanged += new System.EventHandler(this.chkSignature_CheckedChanged);
            // 
            // xAllInvoicesForShopname
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 512);
            this.Controls.Add(this.chkSignature);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gvAllInvoicess);
            this.Controls.Add(this.btnPrintSave);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnPrintAll);
            this.Controls.Add(this.groupControl2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "xAllInvoicesForShopname";
            this.Text = "Invoices by Customer Name";
            this.Load += new System.EventHandler(this.xAllInvoicesForShopname_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonthYear.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonthYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpShopNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllInvoicess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblMonthYear;
        private DevExpress.XtraEditors.LabelControl lblShopNo;
        private DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.LabelControl lblDateTo;
        private DevExpress.XtraEditors.DateEdit dateEditMonthYear;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpShopNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SimpleButton btnPrintSave;
        private DevExpress.XtraEditors.CheckButton chkSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnPrintAll;
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
        private System.Windows.Forms.BindingSource InvoiceBindingSource;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit lookLocation;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private System.Windows.Forms.CheckBox chkSignature;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}