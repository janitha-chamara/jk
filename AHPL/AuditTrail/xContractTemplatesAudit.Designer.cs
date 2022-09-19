namespace MMS.AuditTrail
{
    partial class xContractTemplatesAudit
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
            this.conract_Closure_Sub_Templates_AuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conract_Closure_Sub_Templates_AuditGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractClosureTempIDAudit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractClosureTempID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTemplateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPageTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPageNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignature1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignature2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoggedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookCompanyID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookUserID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.conract_Closure_Sub_Templates_AuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conract_Closure_Sub_Templates_AuditGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompanyID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).BeginInit();
            this.SuspendLayout();
            // 
            // conract_Closure_Sub_Templates_AuditBindingSource
            // 
            this.conract_Closure_Sub_Templates_AuditBindingSource.DataSource = typeof(DataTier.Conract_Closure_Sub_Templates_Audit);
            // 
            // conract_Closure_Sub_Templates_AuditGridControl
            // 
            this.conract_Closure_Sub_Templates_AuditGridControl.DataSource = this.conract_Closure_Sub_Templates_AuditBindingSource;
            this.conract_Closure_Sub_Templates_AuditGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conract_Closure_Sub_Templates_AuditGridControl.Location = new System.Drawing.Point(0, 0);
            this.conract_Closure_Sub_Templates_AuditGridControl.MainView = this.gridView1;
            this.conract_Closure_Sub_Templates_AuditGridControl.Name = "conract_Closure_Sub_Templates_AuditGridControl";
            this.conract_Closure_Sub_Templates_AuditGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookCompanyID,
            this.lookUserID});
            this.conract_Closure_Sub_Templates_AuditGridControl.Size = new System.Drawing.Size(644, 447);
            this.conract_Closure_Sub_Templates_AuditGridControl.TabIndex = 1;
            this.conract_Closure_Sub_Templates_AuditGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractClosureTempIDAudit,
            this.colContractClosureTempID,
            this.colCompanyID,
            this.colTemplateName,
            this.colPageTitle,
            this.colPageNo,
            this.colSignature1,
            this.colSignature2,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colLastUpdated,
            this.colLastUpdateDate,
            this.colLoggedDate});
            this.gridView1.GridControl = this.conract_Closure_Sub_Templates_AuditGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colContractClosureTempIDAudit
            // 
            this.colContractClosureTempIDAudit.FieldName = "ContractClosureTempIDAudit";
            this.colContractClosureTempIDAudit.Name = "colContractClosureTempIDAudit";
            this.colContractClosureTempIDAudit.Width = 164;
            // 
            // colContractClosureTempID
            // 
            this.colContractClosureTempID.FieldName = "ContractClosureTempID";
            this.colContractClosureTempID.Name = "colContractClosureTempID";
            this.colContractClosureTempID.Width = 136;
            // 
            // colCompanyID
            // 
            this.colCompanyID.Caption = "Company ";
            this.colCompanyID.ColumnEdit = this.lookCompanyID;
            this.colCompanyID.FieldName = "CompanyID";
            this.colCompanyID.Name = "colCompanyID";
            this.colCompanyID.Visible = true;
            this.colCompanyID.VisibleIndex = 0;
            // 
            // colTemplateName
            // 
            this.colTemplateName.FieldName = "TemplateName";
            this.colTemplateName.Name = "colTemplateName";
            this.colTemplateName.Visible = true;
            this.colTemplateName.VisibleIndex = 1;
            this.colTemplateName.Width = 96;
            // 
            // colPageTitle
            // 
            this.colPageTitle.FieldName = "PageTitle";
            this.colPageTitle.Name = "colPageTitle";
            this.colPageTitle.Visible = true;
            this.colPageTitle.VisibleIndex = 2;
            // 
            // colPageNo
            // 
            this.colPageNo.FieldName = "PageNo";
            this.colPageNo.Name = "colPageNo";
            this.colPageNo.Visible = true;
            this.colPageNo.VisibleIndex = 3;
            // 
            // colSignature1
            // 
            this.colSignature1.Caption = "Signature";
            this.colSignature1.FieldName = "Signature1";
            this.colSignature1.Name = "colSignature1";
            this.colSignature1.Visible = true;
            this.colSignature1.VisibleIndex = 4;
            // 
            // colSignature2
            // 
            this.colSignature2.FieldName = "Signature2";
            this.colSignature2.Name = "colSignature2";
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.ColumnEdit = this.lookUserID;
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 5;
            this.colCreatedBy.Width = 76;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 6;
            this.colCreatedDate.Width = 87;
            // 
            // colLastUpdated
            // 
            this.colLastUpdated.ColumnEdit = this.lookUserID;
            this.colLastUpdated.FieldName = "LastUpdated";
            this.colLastUpdated.Name = "colLastUpdated";
            this.colLastUpdated.Visible = true;
            this.colLastUpdated.VisibleIndex = 7;
            this.colLastUpdated.Width = 86;
            // 
            // colLastUpdateDate
            // 
            this.colLastUpdateDate.FieldName = "LastUpdateDate";
            this.colLastUpdateDate.Name = "colLastUpdateDate";
            this.colLastUpdateDate.Visible = true;
            this.colLastUpdateDate.VisibleIndex = 8;
            this.colLastUpdateDate.Width = 106;
            // 
            // colLoggedDate
            // 
            this.colLoggedDate.FieldName = "LoggedDate";
            this.colLoggedDate.Name = "colLoggedDate";
            this.colLoggedDate.Visible = true;
            this.colLoggedDate.VisibleIndex = 9;
            this.colLoggedDate.Width = 83;
            // 
            // lookCompanyID
            // 
            this.lookCompanyID.AutoHeight = false;
            this.lookCompanyID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompanyID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.lookCompanyID.Name = "lookCompanyID";
            this.lookCompanyID.NullText = "";
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
            // xContractTemplatesAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 447);
            this.Controls.Add(this.conract_Closure_Sub_Templates_AuditGridControl);
            this.Name = "xContractTemplatesAudit";
            this.Text = "Contract Templates - Audit";
            this.Load += new System.EventHandler(this.xContractTemplatesAudit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.conract_Closure_Sub_Templates_AuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conract_Closure_Sub_Templates_AuditGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompanyID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource conract_Closure_Sub_Templates_AuditBindingSource;
        private DevExpress.XtraGrid.GridControl conract_Closure_Sub_Templates_AuditGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureTempIDAudit;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureTempID;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookCompanyID;
        private DevExpress.XtraGrid.Columns.GridColumn colTemplateName;
        private DevExpress.XtraGrid.Columns.GridColumn colPageTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colPageNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSignature1;
        private DevExpress.XtraGrid.Columns.GridColumn colSignature2;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdated;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLoggedDate;
    }
}