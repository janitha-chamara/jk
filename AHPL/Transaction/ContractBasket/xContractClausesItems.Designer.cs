namespace MMS
{
    partial class xContractClausesItems
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
            System.Windows.Forms.Label contractClosreItemNameLabel;
            System.Windows.Forms.Label sortOrderLabel;
            System.Windows.Forms.Label closureMappingItemIDLabel;
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.contract_Closure_ItemsGridControl = new DevExpress.XtraGrid.GridControl();
            this.contract_Closure_ItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractClosureItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractClosreItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSortOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.closureMappingItemIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.closureMappingItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.isMappedCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.sortOrderSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.contractClosreItemNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            contractClosreItemNameLabel = new System.Windows.Forms.Label();
            sortOrderLabel = new System.Windows.Forms.Label();
            closureMappingItemIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contract_Closure_ItemsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contract_Closure_ItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closureMappingItemIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closureMappingItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isMappedCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortOrderSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractClosreItemNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // contractClosreItemNameLabel
            // 
            contractClosreItemNameLabel.AutoSize = true;
            contractClosreItemNameLabel.Location = new System.Drawing.Point(23, 40);
            contractClosreItemNameLabel.Name = "contractClosreItemNameLabel";
            contractClosreItemNameLabel.Size = new System.Drawing.Size(134, 13);
            contractClosreItemNameLabel.TabIndex = 0;
            contractClosreItemNameLabel.Text = "Master Clause Item Name:";
            // 
            // sortOrderLabel
            // 
            sortOrderLabel.AutoSize = true;
            sortOrderLabel.Location = new System.Drawing.Point(95, 69);
            sortOrderLabel.Name = "sortOrderLabel";
            sortOrderLabel.Size = new System.Drawing.Size(62, 13);
            sortOrderLabel.TabIndex = 2;
            sortOrderLabel.Text = "Sort Order:";
            // 
            // closureMappingItemIDLabel
            // 
            closureMappingItemIDLabel.AutoSize = true;
            closureMappingItemIDLabel.Location = new System.Drawing.Point(555, 21);
            closureMappingItemIDLabel.Name = "closureMappingItemIDLabel";
            closureMappingItemIDLabel.Size = new System.Drawing.Size(82, 13);
            closureMappingItemIDLabel.TabIndex = 5;
            closureMappingItemIDLabel.Text = " Mapping Item :";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel1.Controls.Add(this.contract_Closure_ItemsGridControl);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "List of Master Clause(s)";
            this.splitContainerControl1.Panel2.Controls.Add(closureMappingItemIDLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.closureMappingItemIDLookUpEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.isMappedCheckEdit);
            this.splitContainerControl1.Panel2.Controls.Add(sortOrderLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.sortOrderSpinEdit);
            this.splitContainerControl1.Panel2.Controls.Add(contractClosreItemNameLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.contractClosreItemNameTextEdit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1184, 389);
            this.splitContainerControl1.SplitterPosition = 254;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // contract_Closure_ItemsGridControl
            // 
            this.contract_Closure_ItemsGridControl.DataSource = this.contract_Closure_ItemsBindingSource;
            this.contract_Closure_ItemsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contract_Closure_ItemsGridControl.Location = new System.Drawing.Point(0, 0);
            this.contract_Closure_ItemsGridControl.MainView = this.gridView1;
            this.contract_Closure_ItemsGridControl.Name = "contract_Closure_ItemsGridControl";
            this.contract_Closure_ItemsGridControl.Size = new System.Drawing.Size(250, 366);
            this.contract_Closure_ItemsGridControl.TabIndex = 0;
            this.contract_Closure_ItemsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contract_Closure_ItemsBindingSource
            // 
            this.contract_Closure_ItemsBindingSource.DataSource = typeof(DataTier.Contract_Closure_Items);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractClosureItemID,
            this.colContractClosreItemName,
            this.colSortOrder});
            this.gridView1.GridControl = this.contract_Closure_ItemsGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colContractClosureItemID
            // 
            this.colContractClosureItemID.FieldName = "ContractClosureItemID";
            this.colContractClosureItemID.Name = "colContractClosureItemID";
            // 
            // colContractClosreItemName
            // 
            this.colContractClosreItemName.Caption = "Master Clause Item Name";
            this.colContractClosreItemName.FieldName = "ContractClosreItemName";
            this.colContractClosreItemName.Name = "colContractClosreItemName";
            this.colContractClosreItemName.Visible = true;
            this.colContractClosreItemName.VisibleIndex = 1;
            this.colContractClosreItemName.Width = 294;
            // 
            // colSortOrder
            // 
            this.colSortOrder.FieldName = "SortOrder";
            this.colSortOrder.Name = "colSortOrder";
            this.colSortOrder.Visible = true;
            this.colSortOrder.VisibleIndex = 0;
            this.colSortOrder.Width = 71;
            // 
            // closureMappingItemIDLookUpEdit
            // 
            this.closureMappingItemIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.contract_Closure_ItemsBindingSource, "ClosureMappingItemID", true));
            this.closureMappingItemIDLookUpEdit.Location = new System.Drawing.Point(559, 37);
            this.closureMappingItemIDLookUpEdit.Name = "closureMappingItemIDLookUpEdit";
            this.closureMappingItemIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.closureMappingItemIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ClosureMappingItemID", "Closure Mapping Item ID", 141, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ClosureMappingItemName", "Closure Mapping Item Name", 144, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsValueType", "Is Value Type", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.closureMappingItemIDLookUpEdit.Properties.DataSource = this.closureMappingItemBindingSource;
            this.closureMappingItemIDLookUpEdit.Properties.DisplayMember = "ClosureMappingItemName";
            this.closureMappingItemIDLookUpEdit.Properties.NullText = "";
            this.closureMappingItemIDLookUpEdit.Properties.ValueMember = "ClosureMappingItemID";
            this.closureMappingItemIDLookUpEdit.Size = new System.Drawing.Size(218, 20);
            this.closureMappingItemIDLookUpEdit.TabIndex = 6;
            this.closureMappingItemIDLookUpEdit.EditValueChanged += new System.EventHandler(this.closureMappingItemIDLookUpEdit_EditValueChanged);
            // 
            // closureMappingItemBindingSource
            // 
            this.closureMappingItemBindingSource.DataSource = typeof(DataTier.ClosureMappingItem);
            // 
            // isMappedCheckEdit
            // 
            this.isMappedCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.contract_Closure_ItemsBindingSource, "IsMapped", true));
            this.isMappedCheckEdit.Location = new System.Drawing.Point(475, 38);
            this.isMappedCheckEdit.Name = "isMappedCheckEdit";
            this.isMappedCheckEdit.Properties.Caption = "Is Mapped";
            this.isMappedCheckEdit.Size = new System.Drawing.Size(75, 19);
            this.isMappedCheckEdit.TabIndex = 5;
            this.isMappedCheckEdit.CheckedChanged += new System.EventHandler(this.isMappedCheckEdit_CheckedChanged);
            // 
            // sortOrderSpinEdit
            // 
            this.sortOrderSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.contract_Closure_ItemsBindingSource, "SortOrder", true));
            this.sortOrderSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sortOrderSpinEdit.EnterMoveNextControl = true;
            this.sortOrderSpinEdit.Location = new System.Drawing.Point(163, 66);
            this.sortOrderSpinEdit.Name = "sortOrderSpinEdit";
            this.sortOrderSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.sortOrderSpinEdit.Size = new System.Drawing.Size(100, 20);
            this.sortOrderSpinEdit.TabIndex = 1;
            // 
            // contractClosreItemNameTextEdit
            // 
            this.contractClosreItemNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.contract_Closure_ItemsBindingSource, "ContractClosreItemName", true));
            this.contractClosreItemNameTextEdit.EnterMoveNextControl = true;
            this.contractClosreItemNameTextEdit.Location = new System.Drawing.Point(163, 37);
            this.contractClosreItemNameTextEdit.Name = "contractClosreItemNameTextEdit";
            this.contractClosreItemNameTextEdit.Properties.MaxLength = 400;
            this.contractClosreItemNameTextEdit.Size = new System.Drawing.Size(297, 20);
            this.contractClosreItemNameTextEdit.TabIndex = 0;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
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
            this.btnEdit,
            this.btnSave,
            this.btnClose,
            this.btnPrint,
            this.btnDelete,
            this.btnRefresh,
            this.btnUndo});
            this.barManager1.MaxItemId = 9;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUndo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar1.Text = "Tools";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Glyph = global::MMS.Properties.Resources.note_new;
            this.btnNew.Id = 0;
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Glyph = global::MMS.Properties.Resources.note_edit;
            this.btnEdit.Id = 1;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Glyph = global::MMS.Properties.Resources.disk_blue;
            this.btnSave.Id = 2;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Glyph = global::MMS.Properties.Resources.undo;
            this.btnUndo.Id = 7;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndo_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Print";
            this.btnPrint.Glyph = global::MMS.Properties.Resources.printer;
            this.btnPrint.Id = 4;
            this.btnPrint.Name = "btnPrint";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Glyph = global::MMS.Properties.Resources.delete2;
            this.btnDelete.Id = 5;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = global::MMS.Properties.Resources.refresh;
            this.btnRefresh.Id = 6;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Glyph = global::MMS.Properties.Resources.folder_into;
            this.btnClose.Id = 3;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1184, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 436);
            this.barDockControlBottom.Size = new System.Drawing.Size(1184, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 389);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1184, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 389);
            // 
            // xContractClausesItems
            // 
            this.ClientSize = new System.Drawing.Size(1184, 436);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xContractClausesItems";
            this.Text = "Master Clause(s)";
            this.Load += new System.EventHandler(this.xContractClosureItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contract_Closure_ItemsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contract_Closure_ItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closureMappingItemIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closureMappingItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isMappedCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortOrderSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractClosreItemNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl contract_Closure_ItemsGridControl;
        private System.Windows.Forms.BindingSource contract_Closure_ItemsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureItemID;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosreItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colSortOrder;
        private DevExpress.XtraEditors.SpinEdit sortOrderSpinEdit;
        private DevExpress.XtraEditors.TextEdit contractClosreItemNameTextEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.LookUpEdit closureMappingItemIDLookUpEdit;
        private System.Windows.Forms.BindingSource closureMappingItemBindingSource;
        private DevExpress.XtraEditors.CheckEdit isMappedCheckEdit;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}
