namespace MMS
{
    partial class xContract_Baskets
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colIsPromotion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            this.cContract_BasketsBindingSource = new System.Windows.Forms.BindingSource();
            this.cContract_BasketsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsProcessed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractClosureID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractClosureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colExtendedCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.globalCustomersBindingSource = new System.Windows.Forms.BindingSource();
            this.colIsReleased = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.radioGroupProcessStatus = new DevExpress.XtraEditors.RadioGroup();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_BasketsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_BasketsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupProcessStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colIsPromotion
            // 
            this.colIsPromotion.FieldName = "IsPromotion";
            this.colIsPromotion.Name = "colIsPromotion";
            this.colIsPromotion.OptionsColumn.AllowEdit = false;
            this.colIsPromotion.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIsPromotion.OptionsColumn.ReadOnly = true;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNew,
            this.btnSave,
            this.btnClose,
            this.btnPrint,
            this.btnEdit,
            this.btnUndo,
            this.btnRefresh});
            this.barManager1.MaxItemId = 8;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(587, 151);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.Caption | DevExpress.XtraBars.BarLinkUserDefines.PaintStyle))), this.btnNew, "", false, true, false, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnEdit, false),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnUndo, false),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnSave, false),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar1.Text = "Tools";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Glyph = global::MMS.Properties.Resources.note_new;
            this.btnNew.Id = 0;
            this.btnNew.Name = "btnNew";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Glyph = global::MMS.Properties.Resources.note_edit;
            this.btnEdit.Id = 5;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Glyph = global::MMS.Properties.Resources.undo;
            this.btnUndo.Id = 6;
            this.btnUndo.Name = "btnUndo";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Enabled = false;
            this.btnSave.Glyph = global::MMS.Properties.Resources.disk_blue;
            this.btnSave.Id = 1;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = global::MMS.Properties.Resources.refresh;
            this.btnRefresh.Id = 7;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Print";
            this.btnPrint.Glyph = global::MMS.Properties.Resources.printer;
            this.btnPrint.Id = 3;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Glyph = global::MMS.Properties.Resources.folder_into;
            this.btnClose.Id = 2;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(967, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 437);
            this.barDockControlBottom.Size = new System.Drawing.Size(967, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 396);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(967, 41);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 396);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // cContract_BasketsBindingSource
            // 
            this.cContract_BasketsBindingSource.DataSource = typeof(MMS.cContract_Baskets);
            // 
            // cContract_BasketsGridControl
            // 
            this.cContract_BasketsGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cContract_BasketsGridControl.DataSource = this.cContract_BasketsBindingSource;
            this.cContract_BasketsGridControl.Location = new System.Drawing.Point(12, 139);
            this.cContract_BasketsGridControl.MainView = this.gridView1;
            this.cContract_BasketsGridControl.MenuManager = this.barManager1;
            this.cContract_BasketsGridControl.Name = "cContract_BasketsGridControl";
            this.cContract_BasketsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemLookUpEdit1});
            this.cContract_BasketsGridControl.Size = new System.Drawing.Size(943, 286);
            this.cContract_BasketsGridControl.TabIndex = 5;
            this.cContract_BasketsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsProcessed,
            this.colContractClosureID,
            this.colContractClosureName,
            this.colShopName,
            this.colPrint,
            this.colExtendedCustomerID,
            this.colIsReleased,
            this.colIsPromotion,
            this.colContractType});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.PaleGoldenrod;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colIsPromotion;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "True";
            styleFormatCondition1.Value2 = "False";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.cContract_BasketsGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            // 
            // colIsProcessed
            // 
            this.colIsProcessed.Caption = "Processed";
            this.colIsProcessed.FieldName = "IsProcessed";
            this.colIsProcessed.Name = "colIsProcessed";
            this.colIsProcessed.OptionsColumn.AllowEdit = false;
            this.colIsProcessed.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIsProcessed.OptionsColumn.ReadOnly = true;
            this.colIsProcessed.Visible = true;
            this.colIsProcessed.VisibleIndex = 2;
            this.colIsProcessed.Width = 65;
            // 
            // colContractClosureID
            // 
            this.colContractClosureID.FieldName = "ContractClosureID";
            this.colContractClosureID.Name = "colContractClosureID";
            this.colContractClosureID.OptionsColumn.AllowEdit = false;
            this.colContractClosureID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colContractClosureID.OptionsColumn.ReadOnly = true;
            // 
            // colContractClosureName
            // 
            this.colContractClosureName.Caption = "Contract Name";
            this.colContractClosureName.FieldName = "ContractClosureName";
            this.colContractClosureName.Name = "colContractClosureName";
            this.colContractClosureName.OptionsColumn.AllowEdit = false;
            this.colContractClosureName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colContractClosureName.OptionsColumn.ReadOnly = true;
            this.colContractClosureName.Visible = true;
            this.colContractClosureName.VisibleIndex = 4;
            this.colContractClosureName.Width = 204;
            // 
            // colShopName
            // 
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.OptionsColumn.AllowEdit = false;
            this.colShopName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colShopName.OptionsColumn.ReadOnly = true;
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 5;
            this.colShopName.Width = 140;
            // 
            // colPrint
            // 
            this.colPrint.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colPrint.FieldName = "Print";
            this.colPrint.Name = "colPrint";
            this.colPrint.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colPrint.Visible = true;
            this.colPrint.VisibleIndex = 3;
            this.colPrint.Width = 38;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colExtendedCustomerID
            // 
            this.colExtendedCustomerID.Caption = "Customer Name";
            this.colExtendedCustomerID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colExtendedCustomerID.FieldName = "ExtendedCustomerID";
            this.colExtendedCustomerID.Name = "colExtendedCustomerID";
            this.colExtendedCustomerID.OptionsColumn.AllowEdit = false;
            this.colExtendedCustomerID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colExtendedCustomerID.OptionsColumn.ReadOnly = true;
            this.colExtendedCustomerID.Visible = true;
            this.colExtendedCustomerID.VisibleIndex = 6;
            this.colExtendedCustomerID.Width = 257;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.globalCustomersBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "CustomerName";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "ExtendedCustomerID";
            // 
            // colIsReleased
            // 
            this.colIsReleased.Caption = "Released ";
            this.colIsReleased.FieldName = "IsReleased";
            this.colIsReleased.Name = "colIsReleased";
            this.colIsReleased.OptionsColumn.AllowEdit = false;
            this.colIsReleased.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIsReleased.OptionsColumn.ReadOnly = true;
            this.colIsReleased.Visible = true;
            this.colIsReleased.VisibleIndex = 1;
            // 
            // colContractType
            // 
            this.colContractType.FieldName = "ContractType";
            this.colContractType.Name = "colContractType";
            this.colContractType.OptionsColumn.AllowEdit = false;
            this.colContractType.OptionsColumn.ReadOnly = true;
            this.colContractType.Visible = true;
            this.colContractType.VisibleIndex = 0;
            this.colContractType.Width = 136;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.radioGroupProcessStatus);
            this.groupControl1.Location = new System.Drawing.Point(12, 63);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(890, 53);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Unprocessed / Processed";
            // 
            // radioGroupProcessStatus
            // 
            this.radioGroupProcessStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroupProcessStatus.Location = new System.Drawing.Point(2, 21);
            this.radioGroupProcessStatus.MenuManager = this.barManager1;
            this.radioGroupProcessStatus.Name = "radioGroupProcessStatus";
            this.radioGroupProcessStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Unprocessed"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Processed"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Released"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "All")});
            this.radioGroupProcessStatus.Size = new System.Drawing.Size(886, 30);
            this.radioGroupProcessStatus.TabIndex = 0;
            this.radioGroupProcessStatus.SelectedIndexChanged += new System.EventHandler(this.radioGroupProcessStatus_SelectedIndexChanged);
            // 
            // xContract_Baskets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 437);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.cContract_BasketsGridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xContract_Baskets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contract Basket";
            this.Load += new System.EventHandler(this.xContract_Baskets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_BasketsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cContract_BasketsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupProcessStatus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraGrid.GridControl cContract_BasketsGridControl;
        private System.Windows.Forms.BindingSource cContract_BasketsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsProcessed;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureID;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureName;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroupProcessStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPrint;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colExtendedCustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource globalCustomersBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReleased;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPromotion;
        private DevExpress.XtraGrid.Columns.GridColumn colContractType;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}