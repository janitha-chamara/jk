using DataTier;
namespace MMS
{
    partial class xTaxes
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
            System.Windows.Forms.Label taxNameLabel;
            System.Windows.Forms.Label taxCodeLabel;
            System.Windows.Forms.Label isDefaultLabel;
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.taxGridControl = new DevExpress.XtraGrid.GridControl();
            this.taxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTaxID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxRates = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.isDefaultCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.taxCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.taxNameTextEdit = new DevExpress.XtraEditors.TextEdit();
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
            taxNameLabel = new System.Windows.Forms.Label();
            taxCodeLabel = new System.Windows.Forms.Label();
            isDefaultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isDefaultCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // taxNameLabel
            // 
            taxNameLabel.AutoSize = true;
            taxNameLabel.Location = new System.Drawing.Point(31, 60);
            taxNameLabel.Name = "taxNameLabel";
            taxNameLabel.Size = new System.Drawing.Size(59, 13);
            taxNameLabel.TabIndex = 0;
            taxNameLabel.Text = "Tax Name:";
            // 
            // taxCodeLabel
            // 
            taxCodeLabel.AutoSize = true;
            taxCodeLabel.Location = new System.Drawing.Point(33, 34);
            taxCodeLabel.Name = "taxCodeLabel";
            taxCodeLabel.Size = new System.Drawing.Size(57, 13);
            taxCodeLabel.TabIndex = 2;
            taxCodeLabel.Text = "Tax Code:";
            // 
            // isDefaultLabel
            // 
            isDefaultLabel.AutoSize = true;
            isDefaultLabel.Location = new System.Drawing.Point(15, 84);
            isDefaultLabel.Name = "isDefaultLabel";
            isDefaultLabel.Size = new System.Drawing.Size(75, 13);
            isDefaultLabel.TabIndex = 4;
            isDefaultLabel.Text = "Is Mandatory:";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel1.Controls.Add(this.taxGridControl);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "List of Taxes";
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(isDefaultLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.isDefaultCheckEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.taxCodeTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(taxCodeLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.taxNameTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(taxNameLabel);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(932, 389);
            this.splitContainerControl1.SplitterPosition = 247;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // taxGridControl
            // 
            this.taxGridControl.CausesValidation = false;
            this.taxGridControl.DataSource = this.taxBindingSource;
            this.taxGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taxGridControl.Location = new System.Drawing.Point(0, 0);
            this.taxGridControl.MainView = this.gridView1;
            this.taxGridControl.Name = "taxGridControl";
            this.taxGridControl.Size = new System.Drawing.Size(243, 366);
            this.taxGridControl.TabIndex = 0;
            this.taxGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // taxBindingSource
            // 
            this.taxBindingSource.DataSource = typeof(DataTier.Tax);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTaxID,
            this.colTaxCode,
            this.colTaxName,
            this.colTaxRates});
            this.gridView1.GridControl = this.taxGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colTaxID
            // 
            this.colTaxID.FieldName = "TaxID";
            this.colTaxID.Name = "colTaxID";
            // 
            // colTaxCode
            // 
            this.colTaxCode.FieldName = "TaxCode";
            this.colTaxCode.Name = "colTaxCode";
            this.colTaxCode.Visible = true;
            this.colTaxCode.VisibleIndex = 0;
            // 
            // colTaxName
            // 
            this.colTaxName.FieldName = "TaxName";
            this.colTaxName.Name = "colTaxName";
            this.colTaxName.Visible = true;
            this.colTaxName.VisibleIndex = 1;
            this.colTaxName.Width = 173;
            // 
            // colTaxRates
            // 
            this.colTaxRates.FieldName = "TaxRates";
            this.colTaxRates.Name = "colTaxRates";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(52, 123);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(219, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Note : E.g. Is Mandatory applied for NBT only";
            // 
            // isDefaultCheckEdit
            // 
            this.isDefaultCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taxBindingSource, "IsMandatory", true));
            this.isDefaultCheckEdit.EnterMoveNextControl = true;
            this.isDefaultCheckEdit.Location = new System.Drawing.Point(96, 82);
            this.isDefaultCheckEdit.Name = "isDefaultCheckEdit";
            this.isDefaultCheckEdit.Properties.Caption = "";
            this.isDefaultCheckEdit.Size = new System.Drawing.Size(50, 19);
            this.isDefaultCheckEdit.TabIndex = 2;
            // 
            // taxCodeTextEdit
            // 
            this.taxCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taxBindingSource, "TaxCode", true));
            this.taxCodeTextEdit.EnterMoveNextControl = true;
            this.taxCodeTextEdit.Location = new System.Drawing.Point(98, 31);
            this.taxCodeTextEdit.Name = "taxCodeTextEdit";
            this.taxCodeTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.taxCodeTextEdit.Properties.MaxLength = 20;
            this.taxCodeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.taxCodeTextEdit.TabIndex = 0;
            // 
            // taxNameTextEdit
            // 
            this.taxNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taxBindingSource, "TaxName", true));
            this.taxNameTextEdit.EnterMoveNextControl = true;
            this.taxNameTextEdit.Location = new System.Drawing.Point(98, 57);
            this.taxNameTextEdit.Name = "taxNameTextEdit";
            this.taxNameTextEdit.Properties.MaxLength = 50;
            this.taxNameTextEdit.Size = new System.Drawing.Size(173, 20);
            this.taxNameTextEdit.TabIndex = 1;
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
            // xTaxes
            // 
            this.ClientSize = new System.Drawing.Size(932, 436);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xTaxes";
            this.Text = "Taxes";
            this.Load += new System.EventHandler(this.xTaxes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taxGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isDefaultCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl taxGridControl;
        private System.Windows.Forms.BindingSource taxBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxID;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxName;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRates;
        private DevExpress.XtraEditors.TextEdit taxNameTextEdit;
        private DevExpress.XtraEditors.TextEdit taxCodeTextEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxCode;
        private DevExpress.XtraEditors.CheckEdit isDefaultCheckEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
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
