namespace MMS
{
    partial class xSAP_Process
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xSAP_Process));
            this.colIsCustomerEntry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsGLEntriy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGenerate = new DevExpress.XtraEditors.SimpleButton();
            this.cSAP_UploadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cSAP_UploadGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvDetID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBusAct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPostingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefDocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocHeaderText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExchRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransltDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCode_GLAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmtInDocCur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colAmtInLocCur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssignment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBusinessArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostCenter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternalOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfitCenter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefKey1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefKey2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefKey3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPostingKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGLaccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAPUploadMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCusomterAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lookLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAutoBalance = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dateToPosting = new DevExpress.XtraEditors.DateEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dateFromPosting = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lookSubInvTypeID = new DevExpress.XtraEditors.LookUpEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditInvType = new DevExpress.XtraEditors.LookUpEdit();
            this.lblUType = new DevExpress.XtraEditors.LabelControl();
            this.dateEditCurDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUType = new DevExpress.XtraEditors.LookUpEdit();
            this.chkSelectAll = new DevExpress.XtraEditors.CheckButton();
            this.splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.cSAP_UploadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSAP_UploadGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateToPosting.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateToPosting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFromPosting.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFromPosting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookSubInvTypeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditInvType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCurDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCurDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colIsCustomerEntry
            // 
            this.colIsCustomerEntry.FieldName = "IsCustomerEntry";
            this.colIsCustomerEntry.Name = "colIsCustomerEntry";
            // 
            // colIsGLEntriy
            // 
            this.colIsGLEntriy.FieldName = "IsGLEntriy";
            this.colIsGLEntriy.Name = "colIsGLEntriy";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Image = global::MMS.Properties.Resources.list__1_;
            this.btnGenerate.Location = new System.Drawing.Point(1010, 18);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(132, 41);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cSAP_UploadBindingSource
            // 
            this.cSAP_UploadBindingSource.DataSource = typeof(MMS.cSAP_Upload);
            // 
            // cSAP_UploadGridControl
            // 
            this.cSAP_UploadGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSAP_UploadGridControl.DataSource = this.cSAP_UploadBindingSource;
            this.cSAP_UploadGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cSAP_UploadGridControl.Location = new System.Drawing.Point(0, 160);
            this.cSAP_UploadGridControl.MainView = this.gridView1;
            this.cSAP_UploadGridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cSAP_UploadGridControl.Name = "cSAP_UploadGridControl";
            this.cSAP_UploadGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
            this.cSAP_UploadGridControl.Size = new System.Drawing.Size(1272, 597);
            this.cSAP_UploadGridControl.TabIndex = 2;
            this.cSAP_UploadGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colInvoiceID,
            this.colInvDetID,
            this.colBusAct,
            this.colUserName,
            this.colCompanyCode,
            this.colCurrKey,
            this.colDocDate,
            this.colPostingDate,
            this.colRefDocNo,
            this.colDocHeaderText,
            this.colDocType,
            this.colExchRate,
            this.colTransltDate,
            this.colCustomerCode_GLAccount,
            this.colAmtInDocCur,
            this.colAmtInLocCur,
            this.colAssignment,
            this.colText,
            this.colBusinessArea,
            this.colCostCenter,
            this.colInternalOrder,
            this.colProfitCenter,
            this.colRefKey1,
            this.colRefKey2,
            this.colRefKey3,
            this.colPostingKey,
            this.colGLaccDesc,
            this.colIsCustomerEntry,
            this.colIsGLEntriy,
            this.colSAPUploadMessage,
            this.colCusomterAmount,
            this.colIsSelected,
            this.colSelect});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colIsCustomerEntry;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colIsGLEntriy;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = true;
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gridView1.GridControl = this.cSAP_UploadGridControl;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmtInDocCur", null, "{0:n2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsPrint.PrintSelectedRowsOnly = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRefDocNo, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ViewCaption = "List of Items to be uploaded";
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colInvoiceID
            // 
            this.colInvoiceID.FieldName = "InvoiceID";
            this.colInvoiceID.Name = "colInvoiceID";
            // 
            // colInvDetID
            // 
            this.colInvDetID.FieldName = "InvDetID";
            this.colInvDetID.Name = "colInvDetID";
            // 
            // colBusAct
            // 
            this.colBusAct.FieldName = "BusAct";
            this.colBusAct.Name = "colBusAct";
            this.colBusAct.Visible = true;
            this.colBusAct.VisibleIndex = 2;
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 3;
            // 
            // colCompanyCode
            // 
            this.colCompanyCode.FieldName = "CompanyCode";
            this.colCompanyCode.Name = "colCompanyCode";
            this.colCompanyCode.Visible = true;
            this.colCompanyCode.VisibleIndex = 4;
            this.colCompanyCode.Width = 92;
            // 
            // colCurrKey
            // 
            this.colCurrKey.FieldName = "CurrKey";
            this.colCurrKey.Name = "colCurrKey";
            this.colCurrKey.Visible = true;
            this.colCurrKey.VisibleIndex = 5;
            // 
            // colDocDate
            // 
            this.colDocDate.FieldName = "DocDate";
            this.colDocDate.Name = "colDocDate";
            this.colDocDate.Visible = true;
            this.colDocDate.VisibleIndex = 6;
            // 
            // colPostingDate
            // 
            this.colPostingDate.FieldName = "PostingDate";
            this.colPostingDate.Name = "colPostingDate";
            this.colPostingDate.Visible = true;
            this.colPostingDate.VisibleIndex = 7;
            this.colPostingDate.Width = 80;
            // 
            // colRefDocNo
            // 
            this.colRefDocNo.FieldName = "RefDocNo";
            this.colRefDocNo.Name = "colRefDocNo";
            this.colRefDocNo.Visible = true;
            this.colRefDocNo.VisibleIndex = 1;
            this.colRefDocNo.Width = 86;
            // 
            // colDocHeaderText
            // 
            this.colDocHeaderText.FieldName = "DocHeaderText";
            this.colDocHeaderText.Name = "colDocHeaderText";
            this.colDocHeaderText.Visible = true;
            this.colDocHeaderText.VisibleIndex = 8;
            this.colDocHeaderText.Width = 100;
            // 
            // colDocType
            // 
            this.colDocType.FieldName = "DocType";
            this.colDocType.Name = "colDocType";
            this.colDocType.Visible = true;
            this.colDocType.VisibleIndex = 9;
            // 
            // colExchRate
            // 
            this.colExchRate.FieldName = "ExchRate";
            this.colExchRate.Name = "colExchRate";
            // 
            // colTransltDate
            // 
            this.colTransltDate.FieldName = "TransltDate";
            this.colTransltDate.Name = "colTransltDate";
            this.colTransltDate.Width = 78;
            // 
            // colCustomerCode_GLAccount
            // 
            this.colCustomerCode_GLAccount.Caption = "Customer Code / GL Account";
            this.colCustomerCode_GLAccount.FieldName = "CustomerCode_GLAccount";
            this.colCustomerCode_GLAccount.Name = "colCustomerCode_GLAccount";
            this.colCustomerCode_GLAccount.Visible = true;
            this.colCustomerCode_GLAccount.VisibleIndex = 12;
            this.colCustomerCode_GLAccount.Width = 180;
            // 
            // colAmtInDocCur
            // 
            this.colAmtInDocCur.ColumnEdit = this.repositoryItemTextEdit1;
            this.colAmtInDocCur.DisplayFormat.FormatString = "n2";
            this.colAmtInDocCur.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmtInDocCur.FieldName = "AmtInDocCur";
            this.colAmtInDocCur.Name = "colAmtInDocCur";
            this.colAmtInDocCur.OptionsColumn.AllowEdit = false;
            this.colAmtInDocCur.OptionsColumn.ReadOnly = true;
            this.colAmtInDocCur.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmtInDocCur", "{0:n2}")});
            this.colAmtInDocCur.Visible = true;
            this.colAmtInDocCur.VisibleIndex = 14;
            this.colAmtInDocCur.Width = 92;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "n2";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // colAmtInLocCur
            // 
            this.colAmtInLocCur.FieldName = "AmtInLocCur";
            this.colAmtInLocCur.Name = "colAmtInLocCur";
            this.colAmtInLocCur.Width = 90;
            // 
            // colAssignment
            // 
            this.colAssignment.FieldName = "Assignment";
            this.colAssignment.Name = "colAssignment";
            this.colAssignment.Visible = true;
            this.colAssignment.VisibleIndex = 15;
            // 
            // colText
            // 
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 16;
            // 
            // colBusinessArea
            // 
            this.colBusinessArea.FieldName = "BusinessArea";
            this.colBusinessArea.Name = "colBusinessArea";
            this.colBusinessArea.Visible = true;
            this.colBusinessArea.VisibleIndex = 17;
            this.colBusinessArea.Width = 86;
            // 
            // colCostCenter
            // 
            this.colCostCenter.FieldName = "CostCenter";
            this.colCostCenter.Name = "colCostCenter";
            this.colCostCenter.Visible = true;
            this.colCostCenter.VisibleIndex = 18;
            this.colCostCenter.Width = 77;
            // 
            // colInternalOrder
            // 
            this.colInternalOrder.FieldName = "InternalOrder";
            this.colInternalOrder.Name = "colInternalOrder";
            this.colInternalOrder.Visible = true;
            this.colInternalOrder.VisibleIndex = 19;
            this.colInternalOrder.Width = 88;
            // 
            // colProfitCenter
            // 
            this.colProfitCenter.FieldName = "ProfitCenter";
            this.colProfitCenter.Name = "colProfitCenter";
            this.colProfitCenter.Visible = true;
            this.colProfitCenter.VisibleIndex = 20;
            this.colProfitCenter.Width = 81;
            // 
            // colRefKey1
            // 
            this.colRefKey1.FieldName = "RefKey1";
            this.colRefKey1.Name = "colRefKey1";
            this.colRefKey1.Visible = true;
            this.colRefKey1.VisibleIndex = 21;
            // 
            // colRefKey2
            // 
            this.colRefKey2.FieldName = "RefKey2";
            this.colRefKey2.Name = "colRefKey2";
            this.colRefKey2.Visible = true;
            this.colRefKey2.VisibleIndex = 22;
            // 
            // colRefKey3
            // 
            this.colRefKey3.FieldName = "RefKey3";
            this.colRefKey3.Name = "colRefKey3";
            this.colRefKey3.Visible = true;
            this.colRefKey3.VisibleIndex = 23;
            // 
            // colPostingKey
            // 
            this.colPostingKey.FieldName = "PostingKey";
            this.colPostingKey.Name = "colPostingKey";
            this.colPostingKey.OptionsColumn.AllowEdit = false;
            this.colPostingKey.OptionsColumn.ReadOnly = true;
            this.colPostingKey.Visible = true;
            this.colPostingKey.VisibleIndex = 10;
            // 
            // colGLaccDesc
            // 
            this.colGLaccDesc.FieldName = "GLaccDesc";
            this.colGLaccDesc.Name = "colGLaccDesc";
            this.colGLaccDesc.Visible = true;
            this.colGLaccDesc.VisibleIndex = 11;
            // 
            // colSAPUploadMessage
            // 
            this.colSAPUploadMessage.FieldName = "SAPUploadMessage";
            this.colSAPUploadMessage.Name = "colSAPUploadMessage";
            this.colSAPUploadMessage.Visible = true;
            this.colSAPUploadMessage.VisibleIndex = 24;
            // 
            // colCusomterAmount
            // 
            this.colCusomterAmount.Caption = "Customer Amount";
            this.colCusomterAmount.DisplayFormat.FormatString = "n2";
            this.colCusomterAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCusomterAmount.FieldName = "CusomterAmount";
            this.colCusomterAmount.Name = "colCusomterAmount";
            this.colCusomterAmount.OptionsColumn.AllowEdit = false;
            this.colCusomterAmount.OptionsColumn.ReadOnly = true;
            this.colCusomterAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CusomterAmount", "{0:n2}")});
            this.colCusomterAmount.Visible = true;
            this.colCusomterAmount.VisibleIndex = 13;
            // 
            // colIsSelected
            // 
            this.colIsSelected.Caption = "Select";
            this.colIsSelected.FieldName = "IsSelected";
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIsSelected.Visible = true;
            this.colIsSelected.VisibleIndex = 0;
            this.colIsSelected.Width = 134;
            // 
            // colSelect
            // 
            this.colSelect.Caption = "Select New";
            this.colSelect.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colSelect.FieldName = "IsSelected";
            this.colSelect.Name = "colSelect";
            this.colSelect.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AllowGrayed = true;
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Caption = "Check";
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(47, 20);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Company :";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(52, 55);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(56, 16);
            this.labelControl7.TabIndex = 28;
            this.labelControl7.Text = "Location :";
            // 
            // lookLocation
            // 
            this.lookLocation.Location = new System.Drawing.Point(114, 52);
            this.lookLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookLocation.Name = "lookLocation";
            this.lookLocation.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode")});
            this.lookLocation.Properties.NullText = "";
            this.lookLocation.Size = new System.Drawing.Size(205, 22);
            this.lookLocation.TabIndex = 27;
            // 
            // btnAutoBalance
            // 
            this.btnAutoBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoBalance.Image = global::MMS.Properties.Resources.table_sql_check;
            this.btnAutoBalance.Location = new System.Drawing.Point(1010, 68);
            this.btnAutoBalance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAutoBalance.Name = "btnAutoBalance";
            this.btnAutoBalance.Size = new System.Drawing.Size(131, 41);
            this.btnAutoBalance.TabIndex = 24;
            this.btnAutoBalance.Text = "Auto Balance";
            this.btnAutoBalance.Click += new System.EventHandler(this.btnAutoBalance_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dateToPosting);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.dateFromPosting);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Location = new System.Drawing.Point(681, 47);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(233, 105);
            this.groupControl1.TabIndex = 23;
            this.groupControl1.Text = "Posting Date";
            // 
            // dateToPosting
            // 
            this.dateToPosting.EditValue = null;
            this.dateToPosting.Location = new System.Drawing.Point(73, 69);
            this.dateToPosting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateToPosting.Name = "dateToPosting";
            this.dateToPosting.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateToPosting.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateToPosting.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateToPosting.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateToPosting.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateToPosting.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateToPosting.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateToPosting.Size = new System.Drawing.Size(143, 22);
            this.dateToPosting.TabIndex = 17;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(48, 73);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(20, 16);
            this.labelControl6.TabIndex = 16;
            this.labelControl6.Text = "To:";
            // 
            // dateFromPosting
            // 
            this.dateFromPosting.EditValue = null;
            this.dateFromPosting.Location = new System.Drawing.Point(73, 37);
            this.dateFromPosting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateFromPosting.Name = "dateFromPosting";
            this.dateFromPosting.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFromPosting.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateFromPosting.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateFromPosting.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFromPosting.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateFromPosting.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFromPosting.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateFromPosting.Size = new System.Drawing.Size(143, 22);
            this.dateFromPosting.TabIndex = 15;
            this.dateFromPosting.EditValueChanged += new System.EventHandler(this.dateFromPosting_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(31, 41);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 16);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "From :";
            // 
            // lookSubInvTypeID
            // 
            this.lookSubInvTypeID.Location = new System.Drawing.Point(446, 15);
            this.lookSubInvTypeID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookSubInvTypeID.Name = "lookSubInvTypeID";
            this.lookSubInvTypeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookSubInvTypeID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeID", "SubInvTypeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubInvTypeName", "SubInvTypeName")});
            this.lookSubInvTypeID.Properties.NullText = "";
            this.lookSubInvTypeID.Size = new System.Drawing.Size(168, 22);
            this.lookSubInvTypeID.TabIndex = 22;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(1148, 116);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 34);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "&Close";
            this.btnClose.ToolTip = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(355, 20);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 16);
            this.labelControl2.TabIndex = 21;
            this.labelControl2.Text = "Sub Inv.Type :";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Image = global::MMS.Properties.Resources.document_text;
            this.simpleButton1.Location = new System.Drawing.Point(1009, 116);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(132, 34);
            this.simpleButton1.TabIndex = 20;
            this.simpleButton1.Text = "Export";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.Image = global::MMS.Properties.Resources.Upload;
            this.btnUpload.Location = new System.Drawing.Point(1148, 18);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(111, 90);
            this.btnUpload.TabIndex = 19;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lookUpEditInvType
            // 
            this.lookUpEditInvType.Location = new System.Drawing.Point(114, 89);
            this.lookUpEditInvType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEditInvType.Name = "lookUpEditInvType";
            this.lookUpEditInvType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditInvType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoiceTypeID", "InvoiceTypeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoiceTypeName", "Invoice Type")});
            this.lookUpEditInvType.Properties.NullText = "";
            this.lookUpEditInvType.Size = new System.Drawing.Size(205, 22);
            this.lookUpEditInvType.TabIndex = 16;
            this.lookUpEditInvType.EditValueChanged += new System.EventHandler(this.lookUpEditInvType_EditValueChanged);
            // 
            // lblUType
            // 
            this.lblUType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblUType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUType.Location = new System.Drawing.Point(304, 55);
            this.lblUType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblUType.Name = "lblUType";
            this.lblUType.Size = new System.Drawing.Size(134, 16);
            this.lblUType.TabIndex = 15;
            this.lblUType.Text = "Utility Type :";
            this.lblUType.Visible = false;
            // 
            // dateEditCurDate
            // 
            this.dateEditCurDate.EditValue = null;
            this.dateEditCurDate.Location = new System.Drawing.Point(755, 11);
            this.dateEditCurDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditCurDate.Name = "dateEditCurDate";
            this.dateEditCurDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditCurDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditCurDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditCurDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditCurDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditCurDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditCurDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEditCurDate.Size = new System.Drawing.Size(143, 22);
            this.dateEditCurDate.TabIndex = 13;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(713, 15);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(35, 16);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Date :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(27, 92);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(81, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Invoice Type :";
            // 
            // lookCompany
            // 
            this.lookCompany.Location = new System.Drawing.Point(114, 16);
            this.lookCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookCompany.Name = "lookCompany";
            this.lookCompany.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "CompanyName")});
            this.lookCompany.Properties.NullText = "";
            this.lookCompany.Size = new System.Drawing.Size(205, 22);
            this.lookCompany.TabIndex = 0;
            this.lookCompany.EditValueChanged += new System.EventHandler(this.lookCompany_EditValueChanged);
            // 
            // lookUType
            // 
            this.lookUType.Location = new System.Drawing.Point(446, 50);
            this.lookUType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUType.Name = "lookUType";
            this.lookUType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OtherServiceID", "OtherServiceID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OtherServiceName", "OtherServiceName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UtilityID", "UtilityID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UtilityName", "UtilityName")});
            this.lookUType.Properties.NullText = "";
            this.lookUType.Size = new System.Drawing.Size(168, 22);
            this.lookUType.TabIndex = 8;
            this.lookUType.EditValueChanged += new System.EventHandler(this.chkUType_EditValueChanged);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Location = new System.Drawing.Point(0, 178);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(87, 26);
            this.chkSelectAll.TabIndex = 25;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.hideToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 58);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.hideToolStripMenuItem.Text = "Hide";
            // 
            // xSAP_Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 750);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.lookLocation);
            this.Controls.Add(this.lookSubInvTypeID);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lookUpEditInvType);
            this.Controls.Add(this.lblUType);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lookCompany);
            this.Controls.Add(this.lookUType);
            this.Controls.Add(this.btnAutoBalance);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.dateEditCurDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.cSAP_UploadGridControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "xSAP_Process";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAP Upload";
            this.Load += new System.EventHandler(this.xSAP_Upload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cSAP_UploadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSAP_UploadGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateToPosting.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateToPosting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFromPosting.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFromPosting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookSubInvTypeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditInvType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCurDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCurDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnGenerate;
        private System.Windows.Forms.BindingSource cSAP_UploadBindingSource;
        private DevExpress.XtraGrid.GridControl cSAP_UploadGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceID;
        private DevExpress.XtraGrid.Columns.GridColumn colInvDetID;
        private DevExpress.XtraGrid.Columns.GridColumn colBusAct;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrKey;
        private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPostingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRefDocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDocHeaderText;
        private DevExpress.XtraGrid.Columns.GridColumn colDocType;
        private DevExpress.XtraGrid.Columns.GridColumn colExchRate;
        private DevExpress.XtraGrid.Columns.GridColumn colTransltDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCode_GLAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colAmtInDocCur;
        private DevExpress.XtraGrid.Columns.GridColumn colAmtInLocCur;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignment;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colBusinessArea;
        private DevExpress.XtraGrid.Columns.GridColumn colCostCenter;
        private DevExpress.XtraGrid.Columns.GridColumn colInternalOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colProfitCenter;
        private DevExpress.XtraGrid.Columns.GridColumn colRefKey1;
        private DevExpress.XtraGrid.Columns.GridColumn colRefKey2;
        private DevExpress.XtraGrid.Columns.GridColumn colRefKey3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateEditCurDate;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditInvType;
        private DevExpress.XtraEditors.LabelControl lblUType;
        private DevExpress.XtraGrid.Columns.GridColumn colPostingKey;
        private DevExpress.XtraGrid.Columns.GridColumn colGLaccDesc;
        private DevExpress.XtraEditors.SimpleButton btnUpload;
        //private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCustomerEntry;
        private DevExpress.XtraGrid.Columns.GridColumn colIsGLEntriy;
        private DevExpress.XtraGrid.Columns.GridColumn colSAPUploadMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colCusomterAmount;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LookUpEdit lookUType;
        private DevExpress.XtraEditors.LookUpEdit lookSubInvTypeID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit dateToPosting;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit dateFromPosting;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.SimpleButton btnAutoBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSelected;
        private DevExpress.XtraEditors.CheckButton chkSelectAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit lookLocation;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
    }
}