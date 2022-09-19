using DataTier;
namespace MMS
{
    partial class xTaxRates
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
            System.Windows.Forms.Label taxIDLabel;
            System.Windows.Forms.Label taxRate1Label;
            System.Windows.Forms.Label activeFromLabel;
            System.Windows.Forms.Label activeToLabel;
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.taxRatesGridControl = new DevExpress.XtraGrid.GridControl();
            this.taxRatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTaxRateID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.taxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colTaxRate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActiveFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActiveTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.activeToDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.activeFromDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.taxRate1TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.taxIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
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
            taxIDLabel = new System.Windows.Forms.Label();
            taxRate1Label = new System.Windows.Forms.Label();
            activeFromLabel = new System.Windows.Forms.Label();
            activeToLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxRatesGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxRatesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeToDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeToDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeFromDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeFromDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxRate1TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // taxIDLabel
            // 
            taxIDLabel.AutoSize = true;
            taxIDLabel.Location = new System.Drawing.Point(73, 37);
            taxIDLabel.Name = "taxIDLabel";
            taxIDLabel.Size = new System.Drawing.Size(57, 13);
            taxIDLabel.TabIndex = 0;
            taxIDLabel.Text = "Tax Code:";
            // 
            // taxRate1Label
            // 
            taxRate1Label.AutoSize = true;
            taxRate1Label.Location = new System.Drawing.Point(77, 63);
            taxRate1Label.Name = "taxRate1Label";
            taxRate1Label.Size = new System.Drawing.Size(55, 13);
            taxRate1Label.TabIndex = 2;
            taxRate1Label.Text = "Tax Rate:";
            // 
            // activeFromLabel
            // 
            activeFromLabel.AutoSize = true;
            activeFromLabel.Location = new System.Drawing.Point(64, 91);
            activeFromLabel.Name = "activeFromLabel";
            activeFromLabel.Size = new System.Drawing.Size(68, 13);
            activeFromLabel.TabIndex = 4;
            activeFromLabel.Text = "Active From:";
            // 
            // activeToLabel
            // 
            activeToLabel.AutoSize = true;
            activeToLabel.Location = new System.Drawing.Point(269, 91);
            activeToLabel.Name = "activeToLabel";
            activeToLabel.Size = new System.Drawing.Size(56, 13);
            activeToLabel.TabIndex = 6;
            activeToLabel.Text = "Active To:";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel1.Controls.Add(this.taxRatesGridControl);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "List of Tax";
            this.splitContainerControl1.Panel2.Controls.Add(activeToLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.activeToDateEdit);
            this.splitContainerControl1.Panel2.Controls.Add(activeFromLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.activeFromDateEdit);
            this.splitContainerControl1.Panel2.Controls.Add(taxRate1Label);
            this.splitContainerControl1.Panel2.Controls.Add(this.taxRate1TextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(taxIDLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.taxIDLookUpEdit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(932, 389);
            this.splitContainerControl1.SplitterPosition = 227;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // taxRatesGridControl
            // 
            this.taxRatesGridControl.CausesValidation = false;
            this.taxRatesGridControl.DataSource = this.taxRatesBindingSource;
            this.taxRatesGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taxRatesGridControl.Location = new System.Drawing.Point(0, 0);
            this.taxRatesGridControl.MainView = this.gridView1;
            this.taxRatesGridControl.Name = "taxRatesGridControl";
            this.taxRatesGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.taxRatesGridControl.Size = new System.Drawing.Size(223, 366);
            this.taxRatesGridControl.TabIndex = 0;
            this.taxRatesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // taxRatesBindingSource
            // 
            this.taxRatesBindingSource.DataSource = typeof(DataTier.TaxRate);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTaxRateID,
            this.colTaxID,
            this.colTaxRate1,
            this.colIsActive,
            this.colActiveFrom,
            this.colActiveTo,
            this.colTax});
            this.gridView1.GridControl = this.taxRatesGridControl;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTaxID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colTaxRateID
            // 
            this.colTaxRateID.FieldName = "TaxRateID";
            this.colTaxRateID.Name = "colTaxRateID";
            // 
            // colTaxID
            // 
            this.colTaxID.Caption = "Tax Name";
            this.colTaxID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colTaxID.FieldName = "TaxID";
            this.colTaxID.Name = "colTaxID";
            this.colTaxID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTaxID.Visible = true;
            this.colTaxID.VisibleIndex = 0;
            this.colTaxID.Width = 86;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.taxBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "TaxName";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "TaxID";
            // 
            // taxBindingSource
            // 
            this.taxBindingSource.DataSource = typeof(DataTier.Tax);
            // 
            // colTaxRate1
            // 
            this.colTaxRate1.Caption = "Rate";
            this.colTaxRate1.DisplayFormat.FormatString = "n4";
            this.colTaxRate1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxRate1.FieldName = "TaxRate1";
            this.colTaxRate1.Name = "colTaxRate1";
            this.colTaxRate1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTaxRate1.Visible = true;
            this.colTaxRate1.VisibleIndex = 0;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "Active";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 1;
            // 
            // colActiveFrom
            // 
            this.colActiveFrom.Caption = "From";
            this.colActiveFrom.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colActiveFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colActiveFrom.FieldName = "ActiveFrom";
            this.colActiveFrom.Name = "colActiveFrom";
            this.colActiveFrom.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colActiveFrom.Visible = true;
            this.colActiveFrom.VisibleIndex = 2;
            // 
            // colActiveTo
            // 
            this.colActiveTo.Caption = "To";
            this.colActiveTo.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colActiveTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colActiveTo.FieldName = "ActiveTo";
            this.colActiveTo.Name = "colActiveTo";
            this.colActiveTo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colActiveTo.Visible = true;
            this.colActiveTo.VisibleIndex = 3;
            // 
            // colTax
            // 
            this.colTax.FieldName = "Tax";
            this.colTax.Name = "colTax";
            // 
            // activeToDateEdit
            // 
            this.activeToDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taxRatesBindingSource, "ActiveTo", true));
            this.activeToDateEdit.EditValue = new System.DateTime(2014, 9, 29, 16, 44, 26, 463);
            this.activeToDateEdit.EnterMoveNextControl = true;
            this.activeToDateEdit.Location = new System.Drawing.Point(331, 87);
            this.activeToDateEdit.Name = "activeToDateEdit";
            this.activeToDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.activeToDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.activeToDateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.activeToDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.activeToDateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.activeToDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.activeToDateEdit.Size = new System.Drawing.Size(100, 20);
            this.activeToDateEdit.TabIndex = 3;
            // 
            // activeFromDateEdit
            // 
            this.activeFromDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taxRatesBindingSource, "ActiveFrom", true));
            this.activeFromDateEdit.EditValue = new System.DateTime(2013, 3, 22, 17, 11, 4, 38);
            this.activeFromDateEdit.EnterMoveNextControl = true;
            this.activeFromDateEdit.Location = new System.Drawing.Point(138, 87);
            this.activeFromDateEdit.Name = "activeFromDateEdit";
            this.activeFromDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.activeFromDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.activeFromDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.activeFromDateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.activeFromDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.activeFromDateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.activeFromDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.activeFromDateEdit.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.activeFromDateEdit.Size = new System.Drawing.Size(100, 20);
            this.activeFromDateEdit.TabIndex = 2;
            // 
            // taxRate1TextEdit
            // 
            this.taxRate1TextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taxRatesBindingSource, "TaxRate1", true));
            this.taxRate1TextEdit.EnterMoveNextControl = true;
            this.taxRate1TextEdit.Location = new System.Drawing.Point(138, 60);
            this.taxRate1TextEdit.Name = "taxRate1TextEdit";
            this.taxRate1TextEdit.Properties.DisplayFormat.FormatString = "n4";
            this.taxRate1TextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.taxRate1TextEdit.Properties.EditFormat.FormatString = "n4";
            this.taxRate1TextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.taxRate1TextEdit.Properties.Mask.EditMask = "n4";
            this.taxRate1TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.taxRate1TextEdit.Size = new System.Drawing.Size(100, 20);
            this.taxRate1TextEdit.TabIndex = 1;
            // 
            // taxIDLookUpEdit
            // 
            this.taxIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taxRatesBindingSource, "TaxID", true));
            this.taxIDLookUpEdit.EnterMoveNextControl = true;
            this.taxIDLookUpEdit.Location = new System.Drawing.Point(138, 34);
            this.taxIDLookUpEdit.Name = "taxIDLookUpEdit";
            this.taxIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.taxIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TaxID", "Tax ID", 55, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TaxCode", "Tax Code", 56, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TaxName", "Tax Name", 58, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TaxRates", "Tax Rates", 59, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.taxIDLookUpEdit.Properties.DataSource = this.taxBindingSource;
            this.taxIDLookUpEdit.Properties.DisplayMember = "TaxCode";
            this.taxIDLookUpEdit.Properties.NullText = "";
            this.taxIDLookUpEdit.Properties.ValueMember = "TaxID";
            this.taxIDLookUpEdit.Size = new System.Drawing.Size(175, 20);
            this.taxIDLookUpEdit.TabIndex = 0;
            this.taxIDLookUpEdit.EditValueChanged += new System.EventHandler(this.taxIDLookUpEdit_EditValueChanged);
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
            // xTaxRates
            // 
            this.ClientSize = new System.Drawing.Size(932, 436);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xTaxRates";
            this.Text = "Tax Rates";
            this.Load += new System.EventHandler(this.xTaxRates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taxRatesGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxRatesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeToDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeToDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeFromDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeFromDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxRate1TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl taxRatesGridControl;
        private System.Windows.Forms.BindingSource taxRatesBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRateID;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource taxBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRate1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colActiveFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colActiveTo;
        private DevExpress.XtraGrid.Columns.GridColumn colTax;
        private DevExpress.XtraEditors.LookUpEdit taxIDLookUpEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.TextEdit taxRate1TextEdit;
        private DevExpress.XtraEditors.DateEdit activeToDateEdit;
        private DevExpress.XtraEditors.DateEdit activeFromDateEdit;
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
