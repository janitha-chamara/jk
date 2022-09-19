namespace MMS.AuditTrail
{
    partial class xAddendumNote_Audit
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
            this.addendums_AuditGridControl = new DevExpress.XtraGrid.GridControl();
            this.addendums_AuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddendumIDAudit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddendumID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddendumDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddendumName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractClosureID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookContractClosureID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUserID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoggedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.addendum_Details_AuditGridControl = new DevExpress.XtraGrid.GridControl();
            this.addendum_Details_AuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddendumDetIDAudit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddendumDetID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddendumID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContract_RentSchemeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentperSqFeetO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentperSqFeetN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSCperSqFeetO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSCperSqFeetN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromDateO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromDateN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToDateO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToDateN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoggedDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddendums_Audit = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addendums_AuditGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addendums_AuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookContractClosureID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addendum_Details_AuditGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addendum_Details_AuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(784, 434);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.addendums_AuditGridControl);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(778, 406);
            this.xtraTabPage1.Text = "Addendum Note Header ";
            // 
            // addendums_AuditGridControl
            // 
            this.addendums_AuditGridControl.DataSource = this.addendums_AuditBindingSource;
            this.addendums_AuditGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addendums_AuditGridControl.Location = new System.Drawing.Point(0, 0);
            this.addendums_AuditGridControl.MainView = this.gridView1;
            this.addendums_AuditGridControl.Name = "addendums_AuditGridControl";
            this.addendums_AuditGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookContractClosureID,
            this.lookUserID});
            this.addendums_AuditGridControl.Size = new System.Drawing.Size(778, 406);
            this.addendums_AuditGridControl.TabIndex = 0;
            this.addendums_AuditGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // addendums_AuditBindingSource
            // 
            this.addendums_AuditBindingSource.DataSource = typeof(DataTier.Addendums_Audit);
            this.addendums_AuditBindingSource.PositionChanged += new System.EventHandler(this.addendums_AuditBindingSource_PositionChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddendumIDAudit,
            this.colAddendumID,
            this.colAddendumDate,
            this.colAddendumName,
            this.colContractClosureID,
            this.colRemarks,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colLastUpdated,
            this.colLastUpdateDate,
            this.colLoggedDate});
            this.gridView1.GridControl = this.addendums_AuditGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowPreview = true;
            // 
            // colAddendumIDAudit
            // 
            this.colAddendumIDAudit.FieldName = "AddendumIDAudit";
            this.colAddendumIDAudit.Name = "colAddendumIDAudit";
            this.colAddendumIDAudit.Width = 115;
            // 
            // colAddendumID
            // 
            this.colAddendumID.FieldName = "AddendumID";
            this.colAddendumID.Name = "colAddendumID";
            this.colAddendumID.Width = 87;
            // 
            // colAddendumDate
            // 
            this.colAddendumDate.FieldName = "AddendumDate";
            this.colAddendumDate.Name = "colAddendumDate";
            this.colAddendumDate.Visible = true;
            this.colAddendumDate.VisibleIndex = 0;
            this.colAddendumDate.Width = 99;
            // 
            // colAddendumName
            // 
            this.colAddendumName.FieldName = "AddendumName";
            this.colAddendumName.Name = "colAddendumName";
            this.colAddendumName.Visible = true;
            this.colAddendumName.VisibleIndex = 1;
            this.colAddendumName.Width = 103;
            // 
            // colContractClosureID
            // 
            this.colContractClosureID.Caption = "Contract Name";
            this.colContractClosureID.ColumnEdit = this.lookContractClosureID;
            this.colContractClosureID.FieldName = "ContractClosureID";
            this.colContractClosureID.Name = "colContractClosureID";
            this.colContractClosureID.Visible = true;
            this.colContractClosureID.VisibleIndex = 2;
            this.colContractClosureID.Width = 117;
            // 
            // lookContractClosureID
            // 
            this.lookContractClosureID.AutoHeight = false;
            this.lookContractClosureID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookContractClosureID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContractClosureID", "ContractClosureID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContractClosureName", "ContractClosureName")});
            this.lookContractClosureID.Name = "lookContractClosureID";
            this.lookContractClosureID.NullText = "";
            // 
            // colRemarks
            // 
            this.colRemarks.FieldName = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.Visible = true;
            this.colRemarks.VisibleIndex = 3;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.ColumnEdit = this.lookUserID;
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 4;
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
            this.colCreatedDate.VisibleIndex = 5;
            this.colCreatedDate.Width = 87;
            // 
            // colLastUpdated
            // 
            this.colLastUpdated.ColumnEdit = this.lookUserID;
            this.colLastUpdated.FieldName = "LastUpdated";
            this.colLastUpdated.Name = "colLastUpdated";
            this.colLastUpdated.Visible = true;
            this.colLastUpdated.VisibleIndex = 6;
            this.colLastUpdated.Width = 86;
            // 
            // colLastUpdateDate
            // 
            this.colLastUpdateDate.FieldName = "LastUpdateDate";
            this.colLastUpdateDate.Name = "colLastUpdateDate";
            this.colLastUpdateDate.Visible = true;
            this.colLastUpdateDate.VisibleIndex = 7;
            this.colLastUpdateDate.Width = 106;
            // 
            // colLoggedDate
            // 
            this.colLoggedDate.FieldName = "LoggedDate";
            this.colLoggedDate.Name = "colLoggedDate";
            this.colLoggedDate.Visible = true;
            this.colLoggedDate.VisibleIndex = 8;
            this.colLoggedDate.Width = 83;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.addendum_Details_AuditGridControl);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(778, 406);
            this.xtraTabPage2.Text = "Addendum Note Details";
            // 
            // addendum_Details_AuditGridControl
            // 
            this.addendum_Details_AuditGridControl.DataSource = this.addendum_Details_AuditBindingSource;
            this.addendum_Details_AuditGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addendum_Details_AuditGridControl.Location = new System.Drawing.Point(0, 0);
            this.addendum_Details_AuditGridControl.MainView = this.gridView2;
            this.addendum_Details_AuditGridControl.Name = "addendum_Details_AuditGridControl";
            this.addendum_Details_AuditGridControl.Size = new System.Drawing.Size(778, 406);
            this.addendum_Details_AuditGridControl.TabIndex = 0;
            this.addendum_Details_AuditGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // addendum_Details_AuditBindingSource
            // 
            this.addendum_Details_AuditBindingSource.DataMember = "Addendum_Details_Audit";
            this.addendum_Details_AuditBindingSource.DataSource = this.addendums_AuditBindingSource;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddendumDetIDAudit,
            this.colAddendumDetID,
            this.colAddendumID1,
            this.colContract_RentSchemeID,
            this.colRentperSqFeetO,
            this.colRentperSqFeetN,
            this.colSCperSqFeetO,
            this.colSCperSqFeetN,
            this.colContractID,
            this.colFromDateO,
            this.colFromDateN,
            this.colToDateO,
            this.colToDateN,
            this.colCreatedBy1,
            this.colCreatedDate1,
            this.colUpdatedBy,
            this.colUpdatedDate,
            this.colLoggedDate1,
            this.colAddendums_Audit});
            this.gridView2.GridControl = this.addendum_Details_AuditGridControl;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView2.OptionsFind.AlwaysVisible = true;
            this.gridView2.OptionsFind.FindDelay = 100;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            // 
            // colAddendumDetIDAudit
            // 
            this.colAddendumDetIDAudit.FieldName = "AddendumDetIDAudit";
            this.colAddendumDetIDAudit.Name = "colAddendumDetIDAudit";
            this.colAddendumDetIDAudit.Width = 135;
            // 
            // colAddendumDetID
            // 
            this.colAddendumDetID.FieldName = "AddendumDetID";
            this.colAddendumDetID.Name = "colAddendumDetID";
            this.colAddendumDetID.Width = 107;
            // 
            // colAddendumID1
            // 
            this.colAddendumID1.FieldName = "AddendumID";
            this.colAddendumID1.Name = "colAddendumID1";
            this.colAddendumID1.Width = 87;
            // 
            // colContract_RentSchemeID
            // 
            this.colContract_RentSchemeID.FieldName = "Contract_RentSchemeID";
            this.colContract_RentSchemeID.Name = "colContract_RentSchemeID";
            this.colContract_RentSchemeID.Width = 147;
            // 
            // colRentperSqFeetO
            // 
            this.colRentperSqFeetO.Caption = "Rent / SqFt OLD";
            this.colRentperSqFeetO.FieldName = "RentperSqFeetO";
            this.colRentperSqFeetO.Name = "colRentperSqFeetO";
            this.colRentperSqFeetO.Visible = true;
            this.colRentperSqFeetO.VisibleIndex = 0;
            this.colRentperSqFeetO.Width = 112;
            // 
            // colRentperSqFeetN
            // 
            this.colRentperSqFeetN.Caption = "Rent / SqFt NEW";
            this.colRentperSqFeetN.FieldName = "RentperSqFeetN";
            this.colRentperSqFeetN.Name = "colRentperSqFeetN";
            this.colRentperSqFeetN.Visible = true;
            this.colRentperSqFeetN.VisibleIndex = 1;
            this.colRentperSqFeetN.Width = 111;
            // 
            // colSCperSqFeetO
            // 
            this.colSCperSqFeetO.Caption = "SC/SqFt OLD";
            this.colSCperSqFeetO.FieldName = "SCperSqFeetO";
            this.colSCperSqFeetO.Name = "colSCperSqFeetO";
            this.colSCperSqFeetO.Visible = true;
            this.colSCperSqFeetO.VisibleIndex = 2;
            this.colSCperSqFeetO.Width = 102;
            // 
            // colSCperSqFeetN
            // 
            this.colSCperSqFeetN.Caption = "SC/SqFt NEW";
            this.colSCperSqFeetN.FieldName = "SCperSqFeetN";
            this.colSCperSqFeetN.Name = "colSCperSqFeetN";
            this.colSCperSqFeetN.Visible = true;
            this.colSCperSqFeetN.VisibleIndex = 3;
            this.colSCperSqFeetN.Width = 101;
            // 
            // colContractID
            // 
            this.colContractID.FieldName = "ContractID";
            this.colContractID.Name = "colContractID";
            this.colContractID.Width = 78;
            // 
            // colFromDateO
            // 
            this.colFromDateO.Caption = "From ";
            this.colFromDateO.FieldName = "FromDateO";
            this.colFromDateO.Name = "colFromDateO";
            this.colFromDateO.Visible = true;
            this.colFromDateO.VisibleIndex = 4;
            this.colFromDateO.Width = 83;
            // 
            // colFromDateN
            // 
            this.colFromDateN.FieldName = "FromDateN";
            this.colFromDateN.Name = "colFromDateN";
            this.colFromDateN.Width = 82;
            // 
            // colToDateO
            // 
            this.colToDateO.Caption = "To";
            this.colToDateO.FieldName = "ToDateO";
            this.colToDateO.Name = "colToDateO";
            this.colToDateO.Visible = true;
            this.colToDateO.VisibleIndex = 5;
            // 
            // colToDateN
            // 
            this.colToDateN.FieldName = "ToDateN";
            this.colToDateN.Name = "colToDateN";
            // 
            // colCreatedBy1
            // 
            this.colCreatedBy1.FieldName = "CreatedBy";
            this.colCreatedBy1.Name = "colCreatedBy1";
            this.colCreatedBy1.Visible = true;
            this.colCreatedBy1.VisibleIndex = 6;
            this.colCreatedBy1.Width = 76;
            // 
            // colCreatedDate1
            // 
            this.colCreatedDate1.FieldName = "CreatedDate";
            this.colCreatedDate1.Name = "colCreatedDate1";
            this.colCreatedDate1.Visible = true;
            this.colCreatedDate1.VisibleIndex = 7;
            this.colCreatedDate1.Width = 87;
            // 
            // colUpdatedBy
            // 
            this.colUpdatedBy.FieldName = "UpdatedBy";
            this.colUpdatedBy.Name = "colUpdatedBy";
            this.colUpdatedBy.Visible = true;
            this.colUpdatedBy.VisibleIndex = 8;
            this.colUpdatedBy.Width = 78;
            // 
            // colUpdatedDate
            // 
            this.colUpdatedDate.FieldName = "UpdatedDate";
            this.colUpdatedDate.Name = "colUpdatedDate";
            this.colUpdatedDate.Visible = true;
            this.colUpdatedDate.VisibleIndex = 9;
            this.colUpdatedDate.Width = 89;
            // 
            // colLoggedDate1
            // 
            this.colLoggedDate1.FieldName = "LoggedDate";
            this.colLoggedDate1.Name = "colLoggedDate1";
            this.colLoggedDate1.Visible = true;
            this.colLoggedDate1.VisibleIndex = 10;
            this.colLoggedDate1.Width = 83;
            // 
            // colAddendums_Audit
            // 
            this.colAddendums_Audit.FieldName = "Addendums_Audit";
            this.colAddendums_Audit.Name = "colAddendums_Audit";
            this.colAddendums_Audit.Width = 109;
            // 
            // xAddendumNote_Audit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 434);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "xAddendumNote_Audit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Addendum Note - Audit Trail";
            this.Load += new System.EventHandler(this.xAddendumNote_Audit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addendums_AuditGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addendums_AuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookContractClosureID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addendum_Details_AuditGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addendum_Details_AuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl addendums_AuditGridControl;
        private System.Windows.Forms.BindingSource addendums_AuditBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colAddendumIDAudit;
        private DevExpress.XtraGrid.Columns.GridColumn colAddendumID;
        private DevExpress.XtraGrid.Columns.GridColumn colAddendumDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAddendumName;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureID;
        private DevExpress.XtraGrid.Columns.GridColumn colRemarks;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdated;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLoggedDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookContractClosureID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUserID;
        private DevExpress.XtraGrid.GridControl addendum_Details_AuditGridControl;
        private System.Windows.Forms.BindingSource addendum_Details_AuditBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colAddendumDetIDAudit;
        private DevExpress.XtraGrid.Columns.GridColumn colAddendumDetID;
        private DevExpress.XtraGrid.Columns.GridColumn colAddendumID1;
        private DevExpress.XtraGrid.Columns.GridColumn colContract_RentSchemeID;
        private DevExpress.XtraGrid.Columns.GridColumn colRentperSqFeetO;
        private DevExpress.XtraGrid.Columns.GridColumn colRentperSqFeetN;
        private DevExpress.XtraGrid.Columns.GridColumn colSCperSqFeetO;
        private DevExpress.XtraGrid.Columns.GridColumn colSCperSqFeetN;
        private DevExpress.XtraGrid.Columns.GridColumn colContractID;
        private DevExpress.XtraGrid.Columns.GridColumn colFromDateO;
        private DevExpress.XtraGrid.Columns.GridColumn colFromDateN;
        private DevExpress.XtraGrid.Columns.GridColumn colToDateO;
        private DevExpress.XtraGrid.Columns.GridColumn colToDateN;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate1;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLoggedDate1;
        private DevExpress.XtraGrid.Columns.GridColumn colAddendums_Audit;

    }
}