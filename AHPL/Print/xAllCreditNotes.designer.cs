namespace MMS.Print
{
    partial class xAllCreditNotes
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
            this.btnPrintAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblToDate = new DevExpress.XtraEditors.LabelControl();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lookLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gvAllInvoicess = new DevExpress.XtraGrid.GridControl();
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllInvoicess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.chkSignature);
            this.groupControl3.Controls.Add(this.chkSelectAll);
            this.groupControl3.Controls.Add(this.btnPrintAll);
            this.groupControl3.Controls.Add(this.btnPrint);
            this.groupControl3.Controls.Add(this.dateEditTo);
            this.groupControl3.Controls.Add(this.dateEditFrom);
            this.groupControl3.Controls.Add(this.lblToDate);
            this.groupControl3.Controls.Add(this.lblFromDate);
            this.groupControl3.Controls.Add(this.groupControl2);
            this.groupControl3.Controls.Add(this.groupControl1);
            this.groupControl3.Location = new System.Drawing.Point(4, 5);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1208, 192);
            this.groupControl3.TabIndex = 3;
            this.groupControl3.Text = "Filter by Date";
            this.groupControl3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl3_Paint);
            // 
            // chkSignature
            // 
            this.chkSignature.AutoSize = true;
            this.chkSignature.Location = new System.Drawing.Point(825, 44);
            this.chkSignature.Margin = new System.Windows.Forms.Padding(4);
            this.chkSignature.Name = "chkSignature";
            this.chkSignature.Size = new System.Drawing.Size(156, 21);
            this.chkSignature.TabIndex = 23;
            this.chkSignature.Text = "Print With Signature";
            this.chkSignature.UseVisualStyleBackColor = true;
            this.chkSignature.CheckedChanged += new System.EventHandler(this.chkSignature_CheckedChanged);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Enabled = false;
            this.chkSelectAll.Location = new System.Drawing.Point(12, 158);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(100, 28);
            this.chkSelectAll.TabIndex = 18;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Enabled = false;
            this.btnPrintAll.Image = global::MMS.Properties.Resources.printer1;
            this.btnPrintAll.Location = new System.Drawing.Point(825, 118);
            this.btnPrintAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(165, 36);
            this.btnPrintAll.TabIndex = 15;
            this.btnPrintAll.Text = "Email All";
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::MMS.Properties.Resources.disk_blue2;
            this.btnPrint.Location = new System.Drawing.Point(1021, 118);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(165, 36);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print / Save";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dateEditTo
            // 
            this.dateEditTo.EditValue = null;
            this.dateEditTo.Location = new System.Drawing.Point(593, 100);
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
            // dateEditFrom
            // 
            this.dateEditFrom.EditValue = null;
            this.dateEditFrom.Location = new System.Drawing.Point(443, 101);
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
            // lblToDate
            // 
            this.lblToDate.Location = new System.Drawing.Point(593, 76);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(4);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(54, 16);
            this.lblToDate.TabIndex = 5;
            this.lblToDate.Text = "To Date :";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(444, 76);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(69, 16);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "From Date :";
            // 
            // groupControl2
            // 
            this.groupControl2.Location = new System.Drawing.Point(407, 30);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(339, 116);
            this.groupControl2.TabIndex = 17;
            this.groupControl2.Text = "Date";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lookLocation);
            this.groupControl1.Controls.Add(this.lookCompany);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 30);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(339, 116);
            this.groupControl1.TabIndex = 16;
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
            // gvAllInvoicess
            // 
            this.gvAllInvoicess.DataSource = this.invoiceBindingSource;
            this.gvAllInvoicess.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gvAllInvoicess.Location = new System.Drawing.Point(4, 204);
            this.gvAllInvoicess.MainView = this.gridView1;
            this.gvAllInvoicess.Margin = new System.Windows.Forms.Padding(4);
            this.gvAllInvoicess.Name = "gvAllInvoicess";
            this.gvAllInvoicess.Size = new System.Drawing.Size(1208, 364);
            this.gvAllInvoicess.TabIndex = 8;
            this.gvAllInvoicess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // invoiceBindingSource
            // 
            this.invoiceBindingSource.DataSource = typeof(MMS.cGen_Rent_Invoice);
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
            this.gridView1.OptionsSelection.MultiSelect = true;
            // 
            // colConfirm1
            // 
            this.colConfirm1.FieldName = "Select";
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
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MMS.cGen_Rent_Invoice);
            // 
            // xAllCreditNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 574);
            this.Controls.Add(this.gvAllInvoicess);
            this.Controls.Add(this.groupControl3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "xAllCreditNotes";
            this.Text = "All Credit Notes";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllInvoicess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.DateEdit dateEditFrom;
        private DevExpress.XtraEditors.LabelControl lblToDate;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
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
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.BindingSource invoiceBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnPrintAll;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit lookLocation;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private DevExpress.XtraEditors.CheckButton chkSelectAll;
        private System.Windows.Forms.CheckBox chkSignature;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}