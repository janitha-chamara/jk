namespace MMS.AuditTrail
{
    partial class xTaxAudit
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.taxes_AuditGridControl = new DevExpress.XtraGrid.GridControl();
            this.taxes_AuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTaxIDAudit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsMandatory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAP_GLCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUserID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoggedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxRates_Audit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.taxRates_AuditGridControl = new DevExpress.XtraGrid.GridControl();
            this.taxRates_AuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTaxRateIDAudit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxRateID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxRate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActiveFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActiveTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUserID1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCreatedDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdated1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdateDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoggedDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxes_Audit = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxes_AuditGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxes_AuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxRates_AuditGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxRates_AuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(790, 426);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.taxes_AuditGridControl);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(782, 397);
            this.xtraTabPage1.Text = "Tax ";
            // 
            // taxes_AuditGridControl
            // 
            this.taxes_AuditGridControl.DataSource = this.taxes_AuditBindingSource;
            this.taxes_AuditGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taxes_AuditGridControl.Location = new System.Drawing.Point(0, 0);
            this.taxes_AuditGridControl.MainView = this.gridView1;
            this.taxes_AuditGridControl.Name = "taxes_AuditGridControl";
            this.taxes_AuditGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookUserID});
            this.taxes_AuditGridControl.Size = new System.Drawing.Size(782, 397);
            this.taxes_AuditGridControl.TabIndex = 0;
            this.taxes_AuditGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // taxes_AuditBindingSource
            // 
            //TaxRates_Audit
            this.taxes_AuditBindingSource.DataSource = typeof(DataTier.Taxes_Audit);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTaxIDAudit,
            this.colTaxID,
            this.colTaxName,
            this.colTaxCode,
            this.colIsMandatory,
            this.colSAP_GLCode,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colLastUpdated,
            this.colLastUpdateDate,
            this.colLoggedDate,
            this.colTaxRates_Audit});
            this.gridView1.GridControl = this.taxes_AuditGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colTaxIDAudit
            // 
            this.colTaxIDAudit.FieldName = "TaxIDAudit";
            this.colTaxIDAudit.Name = "colTaxIDAudit";
            this.colTaxIDAudit.Width = 82;
            // 
            // colTaxID
            // 
            this.colTaxID.FieldName = "TaxID";
            this.colTaxID.Name = "colTaxID";
            // 
            // colTaxName
            // 
            this.colTaxName.FieldName = "TaxName";
            this.colTaxName.Name = "colTaxName";
            this.colTaxName.Visible = true;
            this.colTaxName.VisibleIndex = 0;
            // 
            // colTaxCode
            // 
            this.colTaxCode.FieldName = "TaxCode";
            this.colTaxCode.Name = "colTaxCode";
            this.colTaxCode.Visible = true;
            this.colTaxCode.VisibleIndex = 1;
            // 
            // colIsMandatory
            // 
            this.colIsMandatory.FieldName = "IsMandatory";
            this.colIsMandatory.Name = "colIsMandatory";
            this.colIsMandatory.Visible = true;
            this.colIsMandatory.VisibleIndex = 2;
            this.colIsMandatory.Width = 86;
            // 
            // colSAP_GLCode
            // 
            this.colSAP_GLCode.FieldName = "SAP_GLCode";
            this.colSAP_GLCode.Name = "colSAP_GLCode";
            this.colSAP_GLCode.Width = 87;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.ColumnEdit = this.lookUserID;
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 3;
            this.colCreatedBy.Width = 76;
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
            this.colCreatedDate.VisibleIndex = 4;
            this.colCreatedDate.Width = 87;
            // 
            // colLastUpdated
            // 
            this.colLastUpdated.ColumnEdit = this.lookUserID;
            this.colLastUpdated.FieldName = "LastUpdated";
            this.colLastUpdated.Name = "colLastUpdated";
            this.colLastUpdated.Visible = true;
            this.colLastUpdated.VisibleIndex = 5;
            this.colLastUpdated.Width = 86;
            // 
            // colLastUpdateDate
            // 
            this.colLastUpdateDate.FieldName = "LastUpdateDate";
            this.colLastUpdateDate.Name = "colLastUpdateDate";
            this.colLastUpdateDate.Visible = true;
            this.colLastUpdateDate.VisibleIndex = 6;
            this.colLastUpdateDate.Width = 106;
            // 
            // colLoggedDate
            // 
            this.colLoggedDate.FieldName = "LoggedDate";
            this.colLoggedDate.Name = "colLoggedDate";
            this.colLoggedDate.Visible = true;
            this.colLoggedDate.VisibleIndex = 7;
            this.colLoggedDate.Width = 83;
            // 
            // colTaxRates_Audit
            // 
            this.colTaxRates_Audit.FieldName = "TaxRates_Audit";
            this.colTaxRates_Audit.Name = "colTaxRates_Audit";
            this.colTaxRates_Audit.Width = 102;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.taxRates_AuditGridControl);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(782, 397);
            this.xtraTabPage2.Text = "Tax Rate";
            // 
            // taxRates_AuditGridControl
            // 
            this.taxRates_AuditGridControl.DataSource = this.taxRates_AuditBindingSource;
            this.taxRates_AuditGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taxRates_AuditGridControl.Location = new System.Drawing.Point(0, 0);
            this.taxRates_AuditGridControl.MainView = this.gridView2;
            this.taxRates_AuditGridControl.Name = "taxRates_AuditGridControl";
            this.taxRates_AuditGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookUserID1});
            this.taxRates_AuditGridControl.Size = new System.Drawing.Size(782, 397);
            this.taxRates_AuditGridControl.TabIndex = 0;
            this.taxRates_AuditGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // taxRates_AuditBindingSource
            // 
            this.taxRates_AuditBindingSource.DataMember = "TaxRates_Audit";
            this.taxRates_AuditBindingSource.DataSource = this.taxes_AuditBindingSource;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTaxRateIDAudit,
            this.colTaxRateID,
            this.colTaxID1,
            this.colTaxRate1,
            this.colIsActive,
            this.colActiveFrom,
            this.colActiveTo,
            this.colCreatedBy1,
            this.colCreatedDate1,
            this.colLastUpdated1,
            this.colLastUpdateDate1,
            this.colLoggedDate1,
            this.colTaxes_Audit});
            this.gridView2.GridControl = this.taxRates_AuditGridControl;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsFind.AlwaysVisible = true;
            this.gridView2.OptionsFind.FindDelay = 100;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.RowAutoHeight = true;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            // 
            // colTaxRateIDAudit
            // 
            this.colTaxRateIDAudit.FieldName = "TaxRateIDAudit";
            this.colTaxRateIDAudit.Name = "colTaxRateIDAudit";
            this.colTaxRateIDAudit.Width = 108;
            // 
            // colTaxRateID
            // 
            this.colTaxRateID.FieldName = "TaxRateID";
            this.colTaxRateID.Name = "colTaxRateID";
            this.colTaxRateID.Width = 80;
            // 
            // colTaxID1
            // 
            this.colTaxID1.FieldName = "TaxID";
            this.colTaxID1.Name = "colTaxID1";
            // 
            // colTaxRate1
            // 
            this.colTaxRate1.Caption = "Tax Rate";
            this.colTaxRate1.FieldName = "TaxRate1";
            this.colTaxRate1.Name = "colTaxRate1";
            this.colTaxRate1.Visible = true;
            this.colTaxRate1.VisibleIndex = 0;
            // 
            // colIsActive
            // 
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 1;
            // 
            // colActiveFrom
            // 
            this.colActiveFrom.FieldName = "ActiveFrom";
            this.colActiveFrom.Name = "colActiveFrom";
            this.colActiveFrom.Visible = true;
            this.colActiveFrom.VisibleIndex = 2;
            this.colActiveFrom.Width = 79;
            // 
            // colActiveTo
            // 
            this.colActiveTo.FieldName = "ActiveTo";
            this.colActiveTo.Name = "colActiveTo";
            this.colActiveTo.Visible = true;
            this.colActiveTo.VisibleIndex = 3;
            // 
            // colCreatedBy1
            // 
            this.colCreatedBy1.ColumnEdit = this.lookUserID1;
            this.colCreatedBy1.FieldName = "CreatedBy";
            this.colCreatedBy1.Name = "colCreatedBy1";
            this.colCreatedBy1.Visible = true;
            this.colCreatedBy1.VisibleIndex = 4;
            this.colCreatedBy1.Width = 76;
            // 
            // lookUserID1
            // 
            this.lookUserID1.AutoHeight = false;
            this.lookUserID1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUserID1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserID", "UserID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", "UserName")});
            this.lookUserID1.Name = "lookUserID1";
            this.lookUserID1.NullText = "";
            // 
            // colCreatedDate1
            // 
            this.colCreatedDate1.FieldName = "CreatedDate";
            this.colCreatedDate1.Name = "colCreatedDate1";
            this.colCreatedDate1.Visible = true;
            this.colCreatedDate1.VisibleIndex = 5;
            this.colCreatedDate1.Width = 87;
            // 
            // colLastUpdated1
            // 
            this.colLastUpdated1.ColumnEdit = this.lookUserID1;
            this.colLastUpdated1.FieldName = "LastUpdated";
            this.colLastUpdated1.Name = "colLastUpdated1";
            this.colLastUpdated1.Visible = true;
            this.colLastUpdated1.VisibleIndex = 6;
            this.colLastUpdated1.Width = 86;
            // 
            // colLastUpdateDate1
            // 
            this.colLastUpdateDate1.FieldName = "LastUpdateDate";
            this.colLastUpdateDate1.Name = "colLastUpdateDate1";
            this.colLastUpdateDate1.Visible = true;
            this.colLastUpdateDate1.VisibleIndex = 7;
            this.colLastUpdateDate1.Width = 106;
            // 
            // colLoggedDate1
            // 
            this.colLoggedDate1.FieldName = "LoggedDate";
            this.colLoggedDate1.Name = "colLoggedDate1";
            this.colLoggedDate1.Visible = true;
            this.colLoggedDate1.VisibleIndex = 8;
            this.colLoggedDate1.Width = 83;
            // 
            // colTaxes_Audit
            // 
            this.colTaxes_Audit.FieldName = "Taxes_Audit";
            this.colTaxes_Audit.Name = "colTaxes_Audit";
            // 
            // xTaxAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 426);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "xTaxAudit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tax - Audit";
            this.Load += new System.EventHandler(this.xTaxAudit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taxes_AuditGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxes_AuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taxRates_AuditGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxRates_AuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl taxes_AuditGridControl;
        private System.Windows.Forms.BindingSource taxes_AuditBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxIDAudit;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxID;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxName;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIsMandatory;
        private DevExpress.XtraGrid.Columns.GridColumn colSAP_GLCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdated;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLoggedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRates_Audit;
        private DevExpress.XtraGrid.GridControl taxRates_AuditGridControl;
        private System.Windows.Forms.BindingSource taxRates_AuditBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRateIDAudit;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRateID;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxID1;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRate1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colActiveFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colActiveTo;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUserID1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate1;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdated1;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdateDate1;
        private DevExpress.XtraGrid.Columns.GridColumn colLoggedDate1;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxes_Audit;
    }
}