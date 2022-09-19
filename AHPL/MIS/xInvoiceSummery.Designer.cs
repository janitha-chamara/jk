namespace MMS.MIS
{
    partial class xInvoiceSummery
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkLocation = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.lblCompany = new DevExpress.XtraEditors.LabelControl();
            this.chkCompany = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.chkInvoiceType = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblToDate = new DevExpress.XtraEditors.LabelControl();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.invoiceSummeryGridView = new DevExpress.XtraGrid.GridControl();
            this.invoiceSummerybindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkInvoiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceSummeryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceSummerybindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkLocation);
            this.groupControl1.Controls.Add(this.lblLocation);
            this.groupControl1.Controls.Add(this.lblCompany);
            this.groupControl1.Controls.Add(this.chkCompany);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(411, 89);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Company / Location";
            // 
            // chkLocation
            // 
            this.chkLocation.Location = new System.Drawing.Point(110, 56);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkLocation.Size = new System.Drawing.Size(281, 20);
            this.chkLocation.TabIndex = 3;
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(20, 59);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(50, 13);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location : ";
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(14, 27);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(55, 13);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "Company : ";
            // 
            // chkCompany
            // 
            this.chkCompany.Location = new System.Drawing.Point(110, 24);
            this.chkCompany.Name = "chkCompany";
            this.chkCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkCompany.Size = new System.Drawing.Size(281, 20);
            this.chkCompany.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.chkInvoiceType);
            this.groupControl2.Location = new System.Drawing.Point(430, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(200, 89);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Invoice Type";
            // 
            // chkInvoiceType
            // 
            this.chkInvoiceType.Location = new System.Drawing.Point(21, 39);
            this.chkInvoiceType.Name = "chkInvoiceType";
            this.chkInvoiceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkInvoiceType.Size = new System.Drawing.Size(152, 20);
            this.chkInvoiceType.TabIndex = 1;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.dateEditTo);
            this.groupControl3.Controls.Add(this.dateEditFrom);
            this.groupControl3.Controls.Add(this.lblToDate);
            this.groupControl3.Controls.Add(this.lblFromDate);
            this.groupControl3.Location = new System.Drawing.Point(638, 12);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(276, 89);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Date";
            // 
            // dateEditTo
            // 
            this.dateEditTo.EditValue = null;
            this.dateEditTo.Location = new System.Drawing.Point(141, 56);
            this.dateEditTo.Name = "dateEditTo";
            this.dateEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Size = new System.Drawing.Size(100, 20);
            this.dateEditTo.TabIndex = 7;
            // 
            // dateEditFrom
            // 
            this.dateEditFrom.EditValue = null;
            this.dateEditFrom.Location = new System.Drawing.Point(31, 57);
            this.dateEditFrom.Name = "dateEditFrom";
            this.dateEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Size = new System.Drawing.Size(100, 20);
            this.dateEditFrom.TabIndex = 6;
            // 
            // lblToDate
            // 
            this.lblToDate.Location = new System.Drawing.Point(149, 31);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(45, 13);
            this.lblToDate.TabIndex = 5;
            this.lblToDate.Text = "To Date :";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(40, 31);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(57, 13);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "From Date :";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(1050, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 62);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::MMS.Properties.Resources.printer1;
            this.btnPrint.Location = new System.Drawing.Point(920, 57);
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
            this.btnPreview.Location = new System.Drawing.Point(920, 23);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(124, 29);
            this.btnPreview.TabIndex = 10;
            this.btnPreview.Text = "Preview ";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // invoiceSummeryGridView
            // 
            this.invoiceSummeryGridView.DataSource = this.invoiceSummerybindingSource;
            this.invoiceSummeryGridView.Location = new System.Drawing.Point(12, 122);
            this.invoiceSummeryGridView.MainView = this.gridView1;
            this.invoiceSummeryGridView.Name = "invoiceSummeryGridView";
            this.invoiceSummeryGridView.Size = new System.Drawing.Size(1153, 342);
            this.invoiceSummeryGridView.TabIndex = 13;
            this.invoiceSummeryGridView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // invoiceSummerybindingSource
            // 
            this.invoiceSummerybindingSource.DataSource = typeof(DataTier.ReportClasses.InvoiceSummeryDetail);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomer,
            this.colShopNo,
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colInvoiceValue});
            this.gridView1.GridControl = this.invoiceSummeryGridView;
            this.gridView1.Name = "gridView1";
            // 
            // colCustomer
            // 
            this.colCustomer.FieldName = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.Visible = true;
            this.colCustomer.VisibleIndex = 0;
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 1;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.FieldName = "InvoiceNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 2;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.FieldName = "InvoiceDate";
            this.colInvoiceDate.Name = "colInvoiceDate";
            this.colInvoiceDate.Visible = true;
            this.colInvoiceDate.VisibleIndex = 3;
            // 
            // colInvoiceValue
            // 
            this.colInvoiceValue.FieldName = "InvoiceValue";
            this.colInvoiceValue.Name = "colInvoiceValue";
            this.colInvoiceValue.Visible = true;
            this.colInvoiceValue.VisibleIndex = 4;
            // 
            // xInvoiceSummery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1172, 452);
            this.Controls.Add(this.invoiceSummeryGridView);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "xInvoiceSummery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credit Notes Summery";
            this.Load += new System.EventHandler(this.xInvoiceSummery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkInvoiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceSummeryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceSummerybindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkCompany;
        private DevExpress.XtraEditors.LabelControl lblCompany;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkLocation;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkInvoiceType;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl lblToDate;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private DevExpress.XtraEditors.DateEdit dateEditFrom;
        private DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraGrid.GridControl invoiceSummeryGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource invoiceSummerybindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceValue;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}