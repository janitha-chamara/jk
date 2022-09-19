namespace MMS.AuditTrail
{
    partial class xCustomers_Audit
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
            this.global_Customers_AuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.global_Customers_AuditGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerIDAudit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelNos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaxNos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMajShareName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYearOfInc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameOfPrinciple = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaidUpShareCapital = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuthShareCaptial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUserID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAPCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefaultTaxRegNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefaultTaxID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlternateEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKnownAs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscontinued = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscontinuedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsTaxCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.global_Customers_AuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.global_Customers_AuditGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // global_Customers_AuditBindingSource
            // 
            this.global_Customers_AuditBindingSource.DataSource = typeof(DataTier.Global_Customers_Audit);
            // 
            // global_Customers_AuditGridControl
            // 
            this.global_Customers_AuditGridControl.DataSource = this.global_Customers_AuditBindingSource;
            this.global_Customers_AuditGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.global_Customers_AuditGridControl.Location = new System.Drawing.Point(0, 0);
            this.global_Customers_AuditGridControl.MainView = this.gridView1;
            this.global_Customers_AuditGridControl.Name = "global_Customers_AuditGridControl";
            this.global_Customers_AuditGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookUserID});
            this.global_Customers_AuditGridControl.Size = new System.Drawing.Size(720, 473);
            this.global_Customers_AuditGridControl.TabIndex = 1;
            this.global_Customers_AuditGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerIDAudit,
            this.colCustomerID,
            this.colCustomerName,
            this.colCompanyAddress,
            this.colTelNos,
            this.colFaxNos,
            this.colEmailAddress,
            this.colRegNo,
            this.colMajShareName,
            this.colYearOfInc,
            this.colNameOfPrinciple,
            this.colPaidUpShareCapital,
            this.colAuthShareCaptial,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colUpdatedBy,
            this.colUpdatedDate,
            this.colSAPCustomerCode,
            this.colDefaultTaxRegNo,
            this.colDefaultTaxID,
            this.colAlternateEmail,
            this.colKnownAs,
            this.colDiscontinued,
            this.colDiscontinuedDate,
            this.colIsTaxCustomer,
            this.colIsDeleted,
            this.colLogDate});
            this.gridView1.GridControl = this.global_Customers_AuditGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsPrint.ExpandAllDetails = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // colCustomerIDAudit
            // 
            this.colCustomerIDAudit.FieldName = "CustomerIDAudit";
            this.colCustomerIDAudit.Name = "colCustomerIDAudit";
            this.colCustomerIDAudit.Width = 107;
            // 
            // colCustomerID
            // 
            this.colCustomerID.FieldName = "CustomerID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.Width = 105;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
            this.colCustomerName.Width = 111;
            // 
            // colCompanyAddress
            // 
            this.colCompanyAddress.FieldName = "CompanyAddress";
            this.colCompanyAddress.Name = "colCompanyAddress";
            this.colCompanyAddress.Visible = true;
            this.colCompanyAddress.VisibleIndex = 2;
            this.colCompanyAddress.Width = 106;
            // 
            // colTelNos
            // 
            this.colTelNos.FieldName = "TelNos";
            this.colTelNos.Name = "colTelNos";
            this.colTelNos.Visible = true;
            this.colTelNos.VisibleIndex = 3;
            // 
            // colFaxNos
            // 
            this.colFaxNos.FieldName = "FaxNos";
            this.colFaxNos.Name = "colFaxNos";
            this.colFaxNos.Visible = true;
            this.colFaxNos.VisibleIndex = 4;
            // 
            // colEmailAddress
            // 
            this.colEmailAddress.FieldName = "EmailAddress";
            this.colEmailAddress.Name = "colEmailAddress";
            this.colEmailAddress.Visible = true;
            this.colEmailAddress.VisibleIndex = 5;
            this.colEmailAddress.Width = 85;
            // 
            // colRegNo
            // 
            this.colRegNo.FieldName = "RegNo";
            this.colRegNo.Name = "colRegNo";
            this.colRegNo.Visible = true;
            this.colRegNo.VisibleIndex = 6;
            // 
            // colMajShareName
            // 
            this.colMajShareName.FieldName = "MajShareName";
            this.colMajShareName.Name = "colMajShareName";
            this.colMajShareName.Visible = true;
            this.colMajShareName.VisibleIndex = 7;
            this.colMajShareName.Width = 97;
            // 
            // colYearOfInc
            // 
            this.colYearOfInc.FieldName = "YearOfInc";
            this.colYearOfInc.Name = "colYearOfInc";
            this.colYearOfInc.Visible = true;
            this.colYearOfInc.VisibleIndex = 8;
            // 
            // colNameOfPrinciple
            // 
            this.colNameOfPrinciple.FieldName = "NameOfPrinciple";
            this.colNameOfPrinciple.Name = "colNameOfPrinciple";
            this.colNameOfPrinciple.Visible = true;
            this.colNameOfPrinciple.VisibleIndex = 9;
            this.colNameOfPrinciple.Width = 103;
            // 
            // colPaidUpShareCapital
            // 
            this.colPaidUpShareCapital.FieldName = "PaidUpShareCapital";
            this.colPaidUpShareCapital.Name = "colPaidUpShareCapital";
            this.colPaidUpShareCapital.Visible = true;
            this.colPaidUpShareCapital.VisibleIndex = 10;
            this.colPaidUpShareCapital.Width = 122;
            // 
            // colAuthShareCaptial
            // 
            this.colAuthShareCaptial.FieldName = "AuthShareCaptial";
            this.colAuthShareCaptial.Name = "colAuthShareCaptial";
            this.colAuthShareCaptial.Visible = true;
            this.colAuthShareCaptial.VisibleIndex = 11;
            this.colAuthShareCaptial.Width = 109;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.ColumnEdit = this.lookUserID;
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 17;
            // 
            // lookUserID
            // 
            this.lookUserID.AutoHeight = false;
            this.lookUserID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUserID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserID", "UserID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", "UserName")});
            this.lookUserID.Name = "lookUserID";
            this.lookUserID.NullText = "";
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 18;
            this.colCreatedDate.Width = 84;
            // 
            // colUpdatedBy
            // 
            this.colUpdatedBy.ColumnEdit = this.lookUserID;
            this.colUpdatedBy.FieldName = "UpdatedBy";
            this.colUpdatedBy.Name = "colUpdatedBy";
            this.colUpdatedBy.Visible = true;
            this.colUpdatedBy.VisibleIndex = 19;
            // 
            // colUpdatedDate
            // 
            this.colUpdatedDate.FieldName = "UpdatedDate";
            this.colUpdatedDate.Name = "colUpdatedDate";
            this.colUpdatedDate.Visible = true;
            this.colUpdatedDate.VisibleIndex = 20;
            this.colUpdatedDate.Width = 86;
            // 
            // colSAPCustomerCode
            // 
            this.colSAPCustomerCode.FieldName = "SAPCustomerCode";
            this.colSAPCustomerCode.Name = "colSAPCustomerCode";
            this.colSAPCustomerCode.Visible = true;
            this.colSAPCustomerCode.VisibleIndex = 0;
            this.colSAPCustomerCode.Width = 115;
            // 
            // colDefaultTaxRegNo
            // 
            this.colDefaultTaxRegNo.FieldName = "DefaultTaxRegNo";
            this.colDefaultTaxRegNo.Name = "colDefaultTaxRegNo";
            this.colDefaultTaxRegNo.Width = 113;
            // 
            // colDefaultTaxID
            // 
            this.colDefaultTaxID.FieldName = "DefaultTaxID";
            this.colDefaultTaxID.Name = "colDefaultTaxID";
            this.colDefaultTaxID.Width = 89;
            // 
            // colAlternateEmail
            // 
            this.colAlternateEmail.FieldName = "AlternateEmail";
            this.colAlternateEmail.Name = "colAlternateEmail";
            this.colAlternateEmail.Visible = true;
            this.colAlternateEmail.VisibleIndex = 12;
            this.colAlternateEmail.Width = 91;
            // 
            // colKnownAs
            // 
            this.colKnownAs.FieldName = "KnownAs";
            this.colKnownAs.Name = "colKnownAs";
            // 
            // colDiscontinued
            // 
            this.colDiscontinued.FieldName = "Discontinued";
            this.colDiscontinued.Name = "colDiscontinued";
            this.colDiscontinued.Visible = true;
            this.colDiscontinued.VisibleIndex = 13;
            this.colDiscontinued.Width = 80;
            // 
            // colDiscontinuedDate
            // 
            this.colDiscontinuedDate.FieldName = "DiscontinuedDate";
            this.colDiscontinuedDate.Name = "colDiscontinuedDate";
            this.colDiscontinuedDate.Visible = true;
            this.colDiscontinuedDate.VisibleIndex = 14;
            this.colDiscontinuedDate.Width = 106;
            // 
            // colIsTaxCustomer
            // 
            this.colIsTaxCustomer.FieldName = "IsTaxCustomer";
            this.colIsTaxCustomer.Name = "colIsTaxCustomer";
            this.colIsTaxCustomer.Visible = true;
            this.colIsTaxCustomer.VisibleIndex = 15;
            this.colIsTaxCustomer.Width = 98;
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.FieldName = "IsDeleted";
            this.colIsDeleted.Name = "colIsDeleted";
            this.colIsDeleted.Visible = true;
            this.colIsDeleted.VisibleIndex = 16;
            // 
            // colLogDate
            // 
            this.colLogDate.FieldName = "LogDate";
            this.colLogDate.Name = "colLogDate";
            this.colLogDate.Visible = true;
            this.colLogDate.VisibleIndex = 21;
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
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // xCustomers_Audit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 473);
            this.Controls.Add(this.global_Customers_AuditGridControl);
            this.Name = "xCustomers_Audit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Master - Audit Trail";
            this.Load += new System.EventHandler(this.xCustomers_Audit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.global_Customers_AuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.global_Customers_AuditGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource global_Customers_AuditBindingSource;
        private DevExpress.XtraGrid.GridControl global_Customers_AuditGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerIDAudit;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colTelNos;
        private DevExpress.XtraGrid.Columns.GridColumn colFaxNos;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colRegNo;
        private DevExpress.XtraGrid.Columns.GridColumn colMajShareName;
        private DevExpress.XtraGrid.Columns.GridColumn colYearOfInc;
        private DevExpress.XtraGrid.Columns.GridColumn colNameOfPrinciple;
        private DevExpress.XtraGrid.Columns.GridColumn colPaidUpShareCapital;
        private DevExpress.XtraGrid.Columns.GridColumn colAuthShareCaptial;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSAPCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDefaultTaxRegNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDefaultTaxID;
        private DevExpress.XtraGrid.Columns.GridColumn colAlternateEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colKnownAs;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscontinued;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscontinuedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsTaxCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted;
        private DevExpress.XtraGrid.Columns.GridColumn colLogDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
    }
}