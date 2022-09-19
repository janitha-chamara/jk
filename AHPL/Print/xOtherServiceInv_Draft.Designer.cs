namespace MMS.Print
{
    partial class xOtherServiceInv_Draft
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInvoiceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.chkSignature = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(312, 73);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 34);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::MMS.Properties.Resources.printer1;
            this.btnPrint.Location = new System.Drawing.Point(227, 73);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(78, 34);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(37, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Invoice No :";
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.Location = new System.Drawing.Point(125, 28);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.NullText = "";
            this.searchLookUpEdit1.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(266, 20);
            this.searchLookUpEdit1.TabIndex = 4;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInvoiceID,
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colCompany,
            this.colLocation,
            this.colLevel,
            this.colShopNo,
            this.colShopName,
            this.colMonth,
            this.colYear,
            this.colDateFrom,
            this.colDateTo});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.searchLookUpEdit1View.OptionsFind.FindDelay = 100;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.AllowCellMerge = true;
            this.searchLookUpEdit1View.OptionsView.ColumnAutoWidth = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colInvoiceID
            // 
            this.colInvoiceID.Caption = "InvoiceID";
            this.colInvoiceID.FieldName = "InvoiceID";
            this.colInvoiceID.Name = "colInvoiceID";
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Caption = "Invoice No";
            this.colInvoiceNo.FieldName = "InvoiceNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 0;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Caption = "Invoice Date";
            this.colInvoiceDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colInvoiceDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colInvoiceDate.FieldName = "InvoiceDate";
            this.colInvoiceDate.Name = "colInvoiceDate";
            this.colInvoiceDate.Visible = true;
            this.colInvoiceDate.VisibleIndex = 1;
            // 
            // colCompany
            // 
            this.colCompany.Caption = "Company";
            this.colCompany.FieldName = "CompanyCode";
            this.colCompany.Name = "colCompany";
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 4;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "Location";
            this.colLocation.FieldName = "LocationCode";
            this.colLocation.Name = "colLocation";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 5;
            // 
            // colLevel
            // 
            this.colLevel.Caption = "Level";
            this.colLevel.FieldName = "LevelName";
            this.colLevel.Name = "colLevel";
            this.colLevel.Visible = true;
            this.colLevel.VisibleIndex = 6;
            // 
            // colShopNo
            // 
            this.colShopNo.Caption = "Shop No";
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 2;
            // 
            // colShopName
            // 
            this.colShopName.Caption = "Shop Name";
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 3;
            // 
            // colMonth
            // 
            this.colMonth.Caption = "Month";
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.Visible = true;
            this.colMonth.VisibleIndex = 7;
            // 
            // colYear
            // 
            this.colYear.Caption = "Year";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.Visible = true;
            this.colYear.VisibleIndex = 8;
            // 
            // colDateFrom
            // 
            this.colDateFrom.Caption = "Date From";
            this.colDateFrom.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDateFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateFrom.FieldName = "DateFrom";
            this.colDateFrom.Name = "colDateFrom";
            this.colDateFrom.Visible = true;
            this.colDateFrom.VisibleIndex = 9;
            // 
            // colDateTo
            // 
            this.colDateTo.Caption = "Date To";
            this.colDateTo.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDateTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateTo.FieldName = "DateTo";
            this.colDateTo.Name = "colDateTo";
            this.colDateTo.Visible = true;
            this.colDateTo.VisibleIndex = 10;
            // 
            // chkSignature
            // 
            this.chkSignature.AutoSize = true;
            this.chkSignature.Location = new System.Drawing.Point(125, 54);
            this.chkSignature.Name = "chkSignature";
            this.chkSignature.Size = new System.Drawing.Size(122, 17);
            this.chkSignature.TabIndex = 22;
            this.chkSignature.Text = "Print With Signature";
            this.chkSignature.UseVisualStyleBackColor = true;
            this.chkSignature.CheckedChanged += new System.EventHandler(this.chkSignature_CheckedChanged);
            // 
            // xOtherServiceInv_Draft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 134);
            this.Controls.Add(this.chkSignature);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.searchLookUpEdit1);
            this.Name = "xOtherServiceInv_Draft";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Other Service Invoice - Draft";
            this.Load += new System.EventHandler(this.xOtherServiceInv_Draft_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceID;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colDateFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colDateTo;
        private System.Windows.Forms.CheckBox chkSignature;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}