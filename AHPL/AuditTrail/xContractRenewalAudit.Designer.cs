namespace MMS.AuditTrail
{
    partial class xContractRenewalAudit
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
            this.contractClosures_AuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contractClosures_AuditGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractClosureIDAudit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractClosureID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractClosureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractClosureTempID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsProcessed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsReleased = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsReleasedToAccounts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCancelled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookCompany = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookLocationID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLevelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookLevelID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFloorArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeposit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastModDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgreementNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgreementSignDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExtendedCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlobalCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNaration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPromotion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPoRentTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignature1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignature2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsRenew = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsExtention = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsNew = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsTerminated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTerminatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUserID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoggedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.contractClosures_AuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractClosures_AuditGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLevelID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).BeginInit();
            this.SuspendLayout();
            // 
            // contractClosures_AuditBindingSource
            // 
            this.contractClosures_AuditBindingSource.DataSource = typeof(DataTier.ContractClosures_Audit);
            // 
            // contractClosures_AuditGridControl
            // 
            this.contractClosures_AuditGridControl.DataSource = this.contractClosures_AuditBindingSource;
            this.contractClosures_AuditGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contractClosures_AuditGridControl.Location = new System.Drawing.Point(0, 0);
            this.contractClosures_AuditGridControl.MainView = this.gridView1;
            this.contractClosures_AuditGridControl.Name = "contractClosures_AuditGridControl";
            this.contractClosures_AuditGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookCompany,
            this.lookLocationID,
            this.lookLevelID,
            this.lookUserID});
            this.contractClosures_AuditGridControl.Size = new System.Drawing.Size(839, 399);
            this.contractClosures_AuditGridControl.TabIndex = 2;
            this.contractClosures_AuditGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractClosureIDAudit,
            this.colContractClosureID,
            this.colContractClosureName,
            this.colContractClosureTempID,
            this.colIsProcessed,
            this.colIsReleased,
            this.colIsReleasedToAccounts,
            this.colContractID,
            this.colIsCancelled,
            this.colCompanyID,
            this.colLocationID,
            this.colLevelID,
            this.colShopNo,
            this.colShopID,
            this.colFloorArea,
            this.colDeposit,
            this.colContractPeriod,
            this.colLastModDate,
            this.colAgreementNo,
            this.colAgreementSignDate,
            this.colShopName,
            this.colExtendedCustomerID,
            this.colGlobalCustomerID,
            this.colCustomerName,
            this.colNaration,
            this.colIsPromotion,
            this.colPoRentTypeID,
            this.colCustomerAddress,
            this.colSignature1,
            this.colSignature2,
            this.colIsRenew,
            this.colIsExtention,
            this.colIsNew,
            this.colRefNo,
            this.colIsActive,
            this.colIsTerminated,
            this.colTerminatedDate,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colLastUpdated,
            this.colLastUpdateDate,
            this.colLoggedDate});
            this.gridView1.GridControl = this.contractClosures_AuditGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colContractClosureIDAudit
            // 
            this.colContractClosureIDAudit.FieldName = "ContractClosureIDAudit";
            this.colContractClosureIDAudit.Name = "colContractClosureIDAudit";
            this.colContractClosureIDAudit.Width = 145;
            // 
            // colContractClosureID
            // 
            this.colContractClosureID.FieldName = "ContractClosureID";
            this.colContractClosureID.Name = "colContractClosureID";
            this.colContractClosureID.Width = 117;
            // 
            // colContractClosureName
            // 
            this.colContractClosureName.FieldName = "ContractClosureName";
            this.colContractClosureName.Name = "colContractClosureName";
            this.colContractClosureName.Visible = true;
            this.colContractClosureName.VisibleIndex = 0;
            this.colContractClosureName.Width = 133;
            // 
            // colContractClosureTempID
            // 
            this.colContractClosureTempID.FieldName = "ContractClosureTempID";
            this.colContractClosureTempID.Name = "colContractClosureTempID";
            this.colContractClosureTempID.Width = 146;
            // 
            // colIsProcessed
            // 
            this.colIsProcessed.FieldName = "IsProcessed";
            this.colIsProcessed.Name = "colIsProcessed";
            this.colIsProcessed.Visible = true;
            this.colIsProcessed.VisibleIndex = 1;
            this.colIsProcessed.Width = 83;
            // 
            // colIsReleased
            // 
            this.colIsReleased.FieldName = "IsReleased";
            this.colIsReleased.Name = "colIsReleased";
            this.colIsReleased.Visible = true;
            this.colIsReleased.VisibleIndex = 2;
            this.colIsReleased.Width = 78;
            // 
            // colIsReleasedToAccounts
            // 
            this.colIsReleasedToAccounts.FieldName = "IsReleasedToAccounts";
            this.colIsReleasedToAccounts.Name = "colIsReleasedToAccounts";
            this.colIsReleasedToAccounts.Visible = true;
            this.colIsReleasedToAccounts.VisibleIndex = 3;
            this.colIsReleasedToAccounts.Width = 140;
            // 
            // colContractID
            // 
            this.colContractID.FieldName = "ContractID";
            this.colContractID.Name = "colContractID";
            this.colContractID.Width = 78;
            // 
            // colIsCancelled
            // 
            this.colIsCancelled.FieldName = "IsCancelled";
            this.colIsCancelled.Name = "colIsCancelled";
            this.colIsCancelled.Width = 80;
            // 
            // colCompanyID
            // 
            this.colCompanyID.Caption = "Company";
            this.colCompanyID.ColumnEdit = this.lookCompany;
            this.colCompanyID.FieldName = "CompanyID";
            this.colCompanyID.Name = "colCompanyID";
            this.colCompanyID.Visible = true;
            this.colCompanyID.VisibleIndex = 4;
            this.colCompanyID.Width = 81;
            // 
            // lookCompany
            // 
            this.lookCompany.AutoHeight = false;
            this.lookCompany.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompany.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode")});
            this.lookCompany.Name = "lookCompany";
            this.lookCompany.NullText = "";
            // 
            // colLocationID
            // 
            this.colLocationID.Caption = "Location";
            this.colLocationID.ColumnEdit = this.lookLocationID;
            this.colLocationID.FieldName = "LocationID";
            this.colLocationID.Name = "colLocationID";
            this.colLocationID.Visible = true;
            this.colLocationID.VisibleIndex = 5;
            this.colLocationID.Width = 76;
            // 
            // lookLocationID
            // 
            this.lookLocationID.AutoHeight = false;
            this.lookLocationID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocationID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.lookLocationID.Name = "lookLocationID";
            this.lookLocationID.NullText = "";
            // 
            // colLevelID
            // 
            this.colLevelID.Caption = "Level";
            this.colLevelID.ColumnEdit = this.lookLevelID;
            this.colLevelID.FieldName = "LevelID";
            this.colLevelID.Name = "colLevelID";
            this.colLevelID.Visible = true;
            this.colLevelID.VisibleIndex = 6;
            // 
            // lookLevelID
            // 
            this.lookLevelID.AutoHeight = false;
            this.lookLevelID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLevelID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LevelID", "LevelID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LevelName", "LevelName")});
            this.lookLevelID.Name = "lookLevelID";
            this.lookLevelID.NullText = "";
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 7;
            // 
            // colShopID
            // 
            this.colShopID.FieldName = "ShopID";
            this.colShopID.Name = "colShopID";
            // 
            // colFloorArea
            // 
            this.colFloorArea.FieldName = "FloorArea";
            this.colFloorArea.Name = "colFloorArea";
            this.colFloorArea.Visible = true;
            this.colFloorArea.VisibleIndex = 8;
            // 
            // colDeposit
            // 
            this.colDeposit.FieldName = "Deposit";
            this.colDeposit.Name = "colDeposit";
            this.colDeposit.Visible = true;
            this.colDeposit.VisibleIndex = 9;
            // 
            // colContractPeriod
            // 
            this.colContractPeriod.FieldName = "ContractPeriod";
            this.colContractPeriod.Name = "colContractPeriod";
            this.colContractPeriod.Visible = true;
            this.colContractPeriod.VisibleIndex = 10;
            this.colContractPeriod.Width = 97;
            // 
            // colLastModDate
            // 
            this.colLastModDate.FieldName = "LastModDate";
            this.colLastModDate.Name = "colLastModDate";
            this.colLastModDate.Width = 91;
            // 
            // colAgreementNo
            // 
            this.colAgreementNo.FieldName = "AgreementNo";
            this.colAgreementNo.Name = "colAgreementNo";
            this.colAgreementNo.Visible = true;
            this.colAgreementNo.VisibleIndex = 11;
            this.colAgreementNo.Width = 91;
            // 
            // colAgreementSignDate
            // 
            this.colAgreementSignDate.FieldName = "AgreementSignDate";
            this.colAgreementSignDate.Name = "colAgreementSignDate";
            this.colAgreementSignDate.Visible = true;
            this.colAgreementSignDate.VisibleIndex = 12;
            this.colAgreementSignDate.Width = 124;
            // 
            // colShopName
            // 
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 13;
            this.colShopName.Width = 76;
            // 
            // colExtendedCustomerID
            // 
            this.colExtendedCustomerID.FieldName = "ExtendedCustomerID";
            this.colExtendedCustomerID.Name = "colExtendedCustomerID";
            this.colExtendedCustomerID.Width = 131;
            // 
            // colGlobalCustomerID
            // 
            this.colGlobalCustomerID.FieldName = "GlobalCustomerID";
            this.colGlobalCustomerID.Name = "colGlobalCustomerID";
            this.colGlobalCustomerID.Width = 114;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 14;
            this.colCustomerName.Width = 98;
            // 
            // colNaration
            // 
            this.colNaration.FieldName = "Naration";
            this.colNaration.Name = "colNaration";
            this.colNaration.Visible = true;
            this.colNaration.VisibleIndex = 15;
            // 
            // colIsPromotion
            // 
            this.colIsPromotion.FieldName = "IsPromotion";
            this.colIsPromotion.Name = "colIsPromotion";
            this.colIsPromotion.Visible = true;
            this.colIsPromotion.VisibleIndex = 16;
            this.colIsPromotion.Width = 82;
            // 
            // colPoRentTypeID
            // 
            this.colPoRentTypeID.FieldName = "PoRentTypeID";
            this.colPoRentTypeID.Name = "colPoRentTypeID";
            this.colPoRentTypeID.Width = 101;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.FieldName = "CustomerAddress";
            this.colCustomerAddress.Name = "colCustomerAddress";
            this.colCustomerAddress.Visible = true;
            this.colCustomerAddress.VisibleIndex = 17;
            this.colCustomerAddress.Width = 110;
            // 
            // colSignature1
            // 
            this.colSignature1.FieldName = "Signature1";
            this.colSignature1.Name = "colSignature1";
            this.colSignature1.Visible = true;
            this.colSignature1.VisibleIndex = 18;
            // 
            // colSignature2
            // 
            this.colSignature2.FieldName = "Signature2";
            this.colSignature2.Name = "colSignature2";
            this.colSignature2.Visible = true;
            this.colSignature2.VisibleIndex = 19;
            // 
            // colIsRenew
            // 
            this.colIsRenew.FieldName = "IsRenew";
            this.colIsRenew.Name = "colIsRenew";
            this.colIsRenew.Visible = true;
            this.colIsRenew.VisibleIndex = 20;
            // 
            // colIsExtention
            // 
            this.colIsExtention.FieldName = "IsExtention";
            this.colIsExtention.Name = "colIsExtention";
            this.colIsExtention.Visible = true;
            this.colIsExtention.VisibleIndex = 21;
            this.colIsExtention.Width = 80;
            // 
            // colIsNew
            // 
            this.colIsNew.FieldName = "IsNew";
            this.colIsNew.Name = "colIsNew";
            this.colIsNew.Visible = true;
            this.colIsNew.VisibleIndex = 22;
            // 
            // colRefNo
            // 
            this.colRefNo.FieldName = "RefNo";
            this.colRefNo.Name = "colRefNo";
            this.colRefNo.Visible = true;
            this.colRefNo.VisibleIndex = 23;
            // 
            // colIsActive
            // 
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 24;
            // 
            // colIsTerminated
            // 
            this.colIsTerminated.FieldName = "IsTerminated";
            this.colIsTerminated.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colIsTerminated.Name = "colIsTerminated";
            this.colIsTerminated.Width = 88;
            // 
            // colTerminatedDate
            // 
            this.colTerminatedDate.FieldName = "TerminatedDate";
            this.colTerminatedDate.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colTerminatedDate.Name = "colTerminatedDate";
            this.colTerminatedDate.Width = 102;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.ColumnEdit = this.lookUserID;
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 28;
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
            this.colCreatedDate.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 27;
            this.colCreatedDate.Width = 87;
            // 
            // colLastUpdated
            // 
            this.colLastUpdated.ColumnEdit = this.lookUserID;
            this.colLastUpdated.FieldName = "LastUpdated";
            this.colLastUpdated.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colLastUpdated.Name = "colLastUpdated";
            this.colLastUpdated.Visible = true;
            this.colLastUpdated.VisibleIndex = 26;
            this.colLastUpdated.Width = 86;
            // 
            // colLastUpdateDate
            // 
            this.colLastUpdateDate.FieldName = "LastUpdateDate";
            this.colLastUpdateDate.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colLastUpdateDate.Name = "colLastUpdateDate";
            this.colLastUpdateDate.Visible = true;
            this.colLastUpdateDate.VisibleIndex = 25;
            this.colLastUpdateDate.Width = 106;
            // 
            // colLoggedDate
            // 
            this.colLoggedDate.FieldName = "LoggedDate";
            this.colLoggedDate.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colLoggedDate.Name = "colLoggedDate";
            this.colLoggedDate.Visible = true;
            this.colLoggedDate.VisibleIndex = 29;
            this.colLoggedDate.Width = 83;
            // 
            // xContractRenewalAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 399);
            this.Controls.Add(this.contractClosures_AuditGridControl);
            this.Name = "xContractRenewalAudit";
            this.Text = "Contract Renewal - Audit";
            this.Load += new System.EventHandler(this.xContractRenewalAudit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contractClosures_AuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractClosures_AuditGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLevelID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource contractClosures_AuditBindingSource;
        private DevExpress.XtraGrid.GridControl contractClosures_AuditGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureIDAudit;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureID;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureName;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureTempID;
        private DevExpress.XtraGrid.Columns.GridColumn colIsProcessed;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReleased;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReleasedToAccounts;
        private DevExpress.XtraGrid.Columns.GridColumn colContractID;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCancelled;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookLocationID;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookLevelID;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colShopID;
        private DevExpress.XtraGrid.Columns.GridColumn colFloorArea;
        private DevExpress.XtraGrid.Columns.GridColumn colDeposit;
        private DevExpress.XtraGrid.Columns.GridColumn colContractPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn colLastModDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAgreementNo;
        private DevExpress.XtraGrid.Columns.GridColumn colAgreementSignDate;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraGrid.Columns.GridColumn colExtendedCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlobalCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colNaration;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPromotion;
        private DevExpress.XtraGrid.Columns.GridColumn colPoRentTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colSignature1;
        private DevExpress.XtraGrid.Columns.GridColumn colSignature2;
        private DevExpress.XtraGrid.Columns.GridColumn colIsRenew;
        private DevExpress.XtraGrid.Columns.GridColumn colIsExtention;
        private DevExpress.XtraGrid.Columns.GridColumn colIsNew;
        private DevExpress.XtraGrid.Columns.GridColumn colRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colIsTerminated;
        private DevExpress.XtraGrid.Columns.GridColumn colTerminatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdated;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLoggedDate;
    }
}