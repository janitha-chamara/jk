namespace MMS.Print
{
    partial class xAllProformas
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
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.chkSignature = new System.Windows.Forms.CheckBox();
            this.chkSelectAll = new DevExpress.XtraEditors.CheckButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblToDate = new DevExpress.XtraEditors.LabelControl();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.dateEditFrom = new DevExpress.XtraEditors.DateEdit();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lookLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnPrintAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.promotiondatabinding = new System.Windows.Forms.BindingSource(this.components);
            this.cPromotionInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.gvpromotions = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonthName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProcessYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateTo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.promotiondatabinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cPromotionInvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvpromotions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.chkSignature);
            this.groupControl3.Controls.Add(this.chkSelectAll);
            this.groupControl3.Controls.Add(this.groupControl2);
            this.groupControl3.Controls.Add(this.groupControl1);
            this.groupControl3.Controls.Add(this.btnPrintAll);
            this.groupControl3.Controls.Add(this.btnPrint);
            this.groupControl3.Location = new System.Drawing.Point(0, 5);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1331, 181);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "Filter by Date";
            // 
            // chkSignature
            // 
            this.chkSignature.AutoSize = true;
            this.chkSignature.Location = new System.Drawing.Point(940, 52);
            this.chkSignature.Margin = new System.Windows.Forms.Padding(4);
            this.chkSignature.Name = "chkSignature";
            this.chkSignature.Size = new System.Drawing.Size(156, 21);
            this.chkSignature.TabIndex = 24;
            this.chkSignature.Text = "Print With Signature";
            this.chkSignature.UseVisualStyleBackColor = true;
            this.chkSignature.CheckedChanged += new System.EventHandler(this.chkSignature_CheckedChanged);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Location = new System.Drawing.Point(15, 146);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(136, 28);
            this.chkSelectAll.TabIndex = 7;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lblToDate);
            this.groupControl2.Controls.Add(this.lblFromDate);
            this.groupControl2.Controls.Add(this.dateEditFrom);
            this.groupControl2.Controls.Add(this.dateEditTo);
            this.groupControl2.Location = new System.Drawing.Point(443, 23);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(325, 116);
            this.groupControl2.TabIndex = 20;
            this.groupControl2.Text = "Date";
            // 
            // lblToDate
            // 
            this.lblToDate.Location = new System.Drawing.Point(176, 30);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(4);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(54, 16);
            this.lblToDate.TabIndex = 5;
            this.lblToDate.Text = "To Date :";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(27, 30);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(69, 16);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "From Date :";
            // 
            // dateEditFrom
            // 
            this.dateEditFrom.EditValue = null;
            this.dateEditFrom.Location = new System.Drawing.Point(25, 54);
            this.dateEditFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateEditFrom.Name = "dateEditFrom";
            this.dateEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Size = new System.Drawing.Size(133, 22);
            this.dateEditFrom.TabIndex = 6;
            this.dateEditFrom.EditValueChanged += new System.EventHandler(this.dateEditFrom_EditValueChanged);
            // 
            // dateEditTo
            // 
            this.dateEditTo.EditValue = null;
            this.dateEditTo.Location = new System.Drawing.Point(176, 53);
            this.dateEditTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateEditTo.Name = "dateEditTo";
            this.dateEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Size = new System.Drawing.Size(133, 22);
            this.dateEditTo.TabIndex = 7;
            this.dateEditTo.EditValueChanged += new System.EventHandler(this.dateEditTo_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lookLocation);
            this.groupControl1.Controls.Add(this.lookCompany);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(52, 23);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(339, 116);
            this.groupControl1.TabIndex = 19;
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
            this.lookCompany.Properties.DisplayMember = "CompanyCode";
            this.lookCompany.Properties.NullText = "";
            this.lookCompany.Properties.ValueMember = "CompanyID";
            this.lookCompany.Size = new System.Drawing.Size(199, 22);
            this.lookCompany.TabIndex = 3;
            this.lookCompany.EditValueChanged += new System.EventHandler(this.lookCompany_EditValueChanged);
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
            // btnPrintAll
            // 
            this.btnPrintAll.Enabled = false;
            this.btnPrintAll.Image = global::MMS.Properties.Resources.document_text;
            this.btnPrintAll.Location = new System.Drawing.Point(940, 128);
            this.btnPrintAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(165, 47);
            this.btnPrintAll.TabIndex = 15;
            this.btnPrintAll.Text = "Email All";
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::MMS.Properties.Resources.disk_blue;
            this.btnPrint.Location = new System.Drawing.Point(1137, 128);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(165, 47);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print / Save";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // promotiondatabinding
            // 
            this.promotiondatabinding.DataSource = typeof(MMS.cPromotionInvoice);
            // 
            // cPromotionInvoiceBindingSource
            // 
            this.cPromotionInvoiceBindingSource.DataSource = typeof(MMS.cPromotionInvoice);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(DataTier.Company);
            // 
            // gvpromotions
            // 
            this.gvpromotions.DataSource = this.cPromotionInvoiceBindingSource;
            this.gvpromotions.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gvpromotions.Location = new System.Drawing.Point(0, 187);
            this.gvpromotions.MainView = this.gridView1;
            this.gvpromotions.Margin = new System.Windows.Forms.Padding(4);
            this.gvpromotions.Name = "gvpromotions";
            this.gvpromotions.Size = new System.Drawing.Size(1331, 431);
            this.gvpromotions.TabIndex = 6;
            this.gvpromotions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelect,
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colShopNo,
            this.colShopName,
            this.colcusName,
            this.colCompanyCode,
            this.colLocationCode,
            this.colLevelName,
            this.colMonthName,
            this.colProcessYear,
            this.colDateFrom,
            this.colDateTo});
            this.gridView1.GridControl = this.gvpromotions;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            // 
            // colSelect
            // 
            this.colSelect.FieldName = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.Visible = true;
            this.colSelect.VisibleIndex = 0;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.FieldName = "ProfomaNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 1;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.FieldName = "InvoiceDate";
            this.colInvoiceDate.Name = "colInvoiceDate";
            this.colInvoiceDate.Visible = true;
            this.colInvoiceDate.VisibleIndex = 10;
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 2;
            // 
            // colShopName
            // 
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 3;
            // 
            // colcusName
            // 
            this.colcusName.Caption = "Customer";
            this.colcusName.FieldName = "CustomerName";
            this.colcusName.Name = "colcusName";
            this.colcusName.Visible = true;
            this.colcusName.VisibleIndex = 4;
            // 
            // colCompanyCode
            // 
            this.colCompanyCode.FieldName = "CompanyCode";
            this.colCompanyCode.Name = "colCompanyCode";
            this.colCompanyCode.Visible = true;
            this.colCompanyCode.VisibleIndex = 5;
            // 
            // colLocationCode
            // 
            this.colLocationCode.FieldName = "LocationCode";
            this.colLocationCode.Name = "colLocationCode";
            this.colLocationCode.Visible = true;
            this.colLocationCode.VisibleIndex = 6;
            // 
            // colLevelName
            // 
            this.colLevelName.FieldName = "LevelName";
            this.colLevelName.Name = "colLevelName";
            this.colLevelName.Visible = true;
            this.colLevelName.VisibleIndex = 7;
            // 
            // colMonthName
            // 
            this.colMonthName.FieldName = "MonthName";
            this.colMonthName.Name = "colMonthName";
            this.colMonthName.Visible = true;
            this.colMonthName.VisibleIndex = 8;
            // 
            // colProcessYear
            // 
            this.colProcessYear.FieldName = "ProcessYear";
            this.colProcessYear.Name = "colProcessYear";
            this.colProcessYear.Visible = true;
            this.colProcessYear.VisibleIndex = 9;
            // 
            // colDateFrom
            // 
            this.colDateFrom.FieldName = "DateFrom";
            this.colDateFrom.Name = "colDateFrom";
            this.colDateFrom.Visible = true;
            this.colDateFrom.VisibleIndex = 11;
            // 
            // colDateTo
            // 
            this.colDateTo.FieldName = "DateTo";
            this.colDateTo.Name = "colDateTo";
            this.colDateTo.Visible = true;
            this.colDateTo.VisibleIndex = 12;
            // 
            // xAllProformas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 598);
            this.Controls.Add(this.gvpromotions);
            this.Controls.Add(this.groupControl3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "xAllProformas";
            this.Text = "AllProformas";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.promotiondatabinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cPromotionInvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvpromotions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.CheckButton chkSelectAll;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl lblToDate;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private DevExpress.XtraEditors.DateEdit dateEditFrom;
        private DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit lookLocation;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnPrintAll;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.BindingSource promotiondatabinding;
        private System.Windows.Forms.BindingSource cPromotionInvoiceBindingSource;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private DevExpress.XtraGrid.GridControl gvpromotions;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraGrid.Columns.GridColumn colcusName;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelName;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthName;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessYear;
        private DevExpress.XtraGrid.Columns.GridColumn colDateFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colDateTo;
        private System.Windows.Forms.CheckBox chkSignature;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}