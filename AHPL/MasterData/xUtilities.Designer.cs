namespace MMS
{
    partial class xUtilities
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
            System.Windows.Forms.Label utilityNameLabel;
            System.Windows.Forms.Label invoicePrefixLabel;
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.utilityGridControl = new DevExpress.XtraGrid.GridControl();
            this.utilityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUtilityID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUtilityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoicePrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.invoicePrefixTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.utilityNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            utilityNameLabel = new System.Windows.Forms.Label();
            invoicePrefixLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utilityGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicePrefixTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilityNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // utilityNameLabel
            // 
            utilityNameLabel.AutoSize = true;
            utilityNameLabel.Location = new System.Drawing.Point(63, 36);
            utilityNameLabel.Name = "utilityNameLabel";
            utilityNameLabel.Size = new System.Drawing.Size(68, 13);
            utilityNameLabel.TabIndex = 0;
            utilityNameLabel.Text = "Utility Name:";
            // 
            // invoicePrefixLabel
            // 
            invoicePrefixLabel.AutoSize = true;
            invoicePrefixLabel.Location = new System.Drawing.Point(54, 62);
            invoicePrefixLabel.Name = "invoicePrefixLabel";
            invoicePrefixLabel.Size = new System.Drawing.Size(77, 13);
            invoicePrefixLabel.TabIndex = 2;
            invoicePrefixLabel.Text = "Invoice Prefix:";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel1.Controls.Add(this.utilityGridControl);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "List of Utilities";
            this.splitContainerControl1.Panel2.Controls.Add(invoicePrefixLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.invoicePrefixTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(utilityNameLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.utilityNameTextEdit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(932, 389);
            this.splitContainerControl1.SplitterPosition = 216;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // utilityGridControl
            // 
            this.utilityGridControl.CausesValidation = false;
            this.utilityGridControl.DataSource = this.utilityBindingSource;
            this.utilityGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.utilityGridControl.Location = new System.Drawing.Point(0, 0);
            this.utilityGridControl.MainView = this.gridView1;
            this.utilityGridControl.Name = "utilityGridControl";
            this.utilityGridControl.Size = new System.Drawing.Size(212, 366);
            this.utilityGridControl.TabIndex = 0;
            this.utilityGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // utilityBindingSource
            // 
            this.utilityBindingSource.DataSource = typeof(DataTier.Utility);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUtilityID,
            this.colUtilityName,
            this.colInvoicePrefix});
            this.gridView1.GridControl = this.utilityGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colUtilityID
            // 
            this.colUtilityID.FieldName = "UtilityID";
            this.colUtilityID.Name = "colUtilityID";
            // 
            // colUtilityName
            // 
            this.colUtilityName.FieldName = "UtilityName";
            this.colUtilityName.Name = "colUtilityName";
            this.colUtilityName.Visible = true;
            this.colUtilityName.VisibleIndex = 0;
            this.colUtilityName.Width = 116;
            // 
            // colInvoicePrefix
            // 
            this.colInvoicePrefix.FieldName = "InvoicePrefix";
            this.colInvoicePrefix.Name = "colInvoicePrefix";
            this.colInvoicePrefix.Visible = true;
            this.colInvoicePrefix.VisibleIndex = 1;
            this.colInvoicePrefix.Width = 84;
            // 
            // invoicePrefixTextEdit
            // 
            this.invoicePrefixTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.utilityBindingSource, "InvoicePrefix", true));
            this.invoicePrefixTextEdit.EnterMoveNextControl = true;
            this.invoicePrefixTextEdit.Location = new System.Drawing.Point(137, 59);
            this.invoicePrefixTextEdit.Name = "invoicePrefixTextEdit";
            this.invoicePrefixTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.invoicePrefixTextEdit.Properties.MaxLength = 1;
            this.invoicePrefixTextEdit.Size = new System.Drawing.Size(33, 20);
            this.invoicePrefixTextEdit.TabIndex = 1;
            // 
            // utilityNameTextEdit
            // 
            this.utilityNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.utilityBindingSource, "UtilityName", true));
            this.utilityNameTextEdit.EnterMoveNextControl = true;
            this.utilityNameTextEdit.Location = new System.Drawing.Point(137, 33);
            this.utilityNameTextEdit.Name = "utilityNameTextEdit";
            this.utilityNameTextEdit.Properties.MaxLength = 20;
            this.utilityNameTextEdit.Size = new System.Drawing.Size(191, 20);
            this.utilityNameTextEdit.TabIndex = 0;
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
            this.barDockControlTop.Size = new System.Drawing.Size(932, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 436);
            this.barDockControlBottom.Size = new System.Drawing.Size(932, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(932, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 389);
            // 
            // xUtilities
            // 
            this.ClientSize = new System.Drawing.Size(932, 436);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xUtilities";
            this.Text = "Utilities";
            this.Load += new System.EventHandler(this.xUtilities_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.utilityGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicePrefixTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilityNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl utilityGridControl;
        private System.Windows.Forms.BindingSource utilityBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUtilityID;
        private DevExpress.XtraGrid.Columns.GridColumn colUtilityName;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoicePrefix;
        private DevExpress.XtraEditors.TextEdit invoicePrefixTextEdit;
        private DevExpress.XtraEditors.TextEdit utilityNameTextEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
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
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnClose;
    }
}
