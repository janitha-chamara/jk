using DataTier;
namespace MMS
{
    partial class xFloor_Levels
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
            System.Windows.Forms.Label levelCodeLabel;
            System.Windows.Forms.Label levelNameLabel;
            System.Windows.Forms.Label locationIDLabel;
            System.Windows.Forms.Label stdOrderLabel;
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.Floor_LevelsGridControl = new DevExpress.XtraGrid.GridControl();
            this.Floor_LevelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLevelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stdOrderSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.locationIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.levelNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.levelCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
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
            levelCodeLabel = new System.Windows.Forms.Label();
            levelNameLabel = new System.Windows.Forms.Label();
            locationIDLabel = new System.Windows.Forms.Label();
            stdOrderLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Floor_LevelsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Floor_LevelsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdOrderSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // levelCodeLabel
            // 
            levelCodeLabel.AutoSize = true;
            levelCodeLabel.Location = new System.Drawing.Point(70, 59);
            levelCodeLabel.Name = "levelCodeLabel";
            levelCodeLabel.Size = new System.Drawing.Size(64, 13);
            levelCodeLabel.TabIndex = 0;
            levelCodeLabel.Text = "Level Code:";
            // 
            // levelNameLabel
            // 
            levelNameLabel.AutoSize = true;
            levelNameLabel.Location = new System.Drawing.Point(68, 85);
            levelNameLabel.Name = "levelNameLabel";
            levelNameLabel.Size = new System.Drawing.Size(66, 13);
            levelNameLabel.TabIndex = 2;
            levelNameLabel.Text = "Level Name:";
            // 
            // locationIDLabel
            // 
            locationIDLabel.AutoSize = true;
            locationIDLabel.Location = new System.Drawing.Point(83, 33);
            locationIDLabel.Name = "locationIDLabel";
            locationIDLabel.Size = new System.Drawing.Size(51, 13);
            locationIDLabel.TabIndex = 4;
            locationIDLabel.Text = "Location:";
            // 
            // stdOrderLabel
            // 
            stdOrderLabel.AutoSize = true;
            stdOrderLabel.Location = new System.Drawing.Point(76, 111);
            stdOrderLabel.Name = "stdOrderLabel";
            stdOrderLabel.Size = new System.Drawing.Size(58, 13);
            stdOrderLabel.TabIndex = 6;
            stdOrderLabel.Text = "Std Order:";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel1.Controls.Add(this.Floor_LevelsGridControl);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "List of Levels with Location";
            this.splitContainerControl1.Panel2.Controls.Add(stdOrderLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.stdOrderSpinEdit);
            this.splitContainerControl1.Panel2.Controls.Add(locationIDLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.locationIDLookUpEdit);
            this.splitContainerControl1.Panel2.Controls.Add(levelNameLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.levelNameTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(levelCodeLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.levelCodeTextEdit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(932, 389);
            this.splitContainerControl1.SplitterPosition = 260;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // Floor_LevelsGridControl
            // 
            this.Floor_LevelsGridControl.CausesValidation = false;
            this.Floor_LevelsGridControl.DataSource = this.Floor_LevelsBindingSource;
            this.Floor_LevelsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Floor_LevelsGridControl.Location = new System.Drawing.Point(0, 0);
            this.Floor_LevelsGridControl.MainView = this.gridView1;
            this.Floor_LevelsGridControl.Name = "Floor_LevelsGridControl";
            this.Floor_LevelsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.Floor_LevelsGridControl.Size = new System.Drawing.Size(256, 366);
            this.Floor_LevelsGridControl.TabIndex = 0;
            this.Floor_LevelsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // Floor_LevelsBindingSource
            // 
            this.Floor_LevelsBindingSource.DataSource = typeof(DataTier.Floor_Levels);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLevelID,
            this.colLevelCode,
            this.colLevelName,
            this.colLocationID});
            this.gridView1.GridControl = this.Floor_LevelsGridControl;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLocationID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colLevelID
            // 
            this.colLevelID.Caption = "#";
            this.colLevelID.FieldName = "LevelID";
            this.colLevelID.Name = "colLevelID";
            this.colLevelID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colLevelID.Width = 31;
            // 
            // colLevelCode
            // 
            this.colLevelCode.FieldName = "LevelCode";
            this.colLevelCode.Name = "colLevelCode";
            this.colLevelCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colLevelCode.Visible = true;
            this.colLevelCode.VisibleIndex = 0;
            this.colLevelCode.Width = 169;
            // 
            // colLevelName
            // 
            this.colLevelName.FieldName = "LevelName";
            this.colLevelName.Name = "colLevelName";
            this.colLevelName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colLevelName.Visible = true;
            this.colLevelName.VisibleIndex = 1;
            this.colLevelName.Width = 144;
            // 
            // colLocationID
            // 
            this.colLocationID.Caption = "Location";
            this.colLocationID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colLocationID.FieldName = "LocationID";
            this.colLocationID.Name = "colLocationID";
            this.colLocationID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colLocationID.Visible = true;
            this.colLocationID.VisibleIndex = 0;
            this.colLocationID.Width = 100;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.locationBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "LocationCode";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "LocationID";
            // 
            // locationBindingSource
            // 
            this.locationBindingSource.DataSource = typeof(DataTier.Location);
            // 
            // stdOrderSpinEdit
            // 
            this.stdOrderSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Floor_LevelsBindingSource, "StdOrder", true));
            this.stdOrderSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.stdOrderSpinEdit.EnterMoveNextControl = true;
            this.stdOrderSpinEdit.Location = new System.Drawing.Point(140, 108);
            this.stdOrderSpinEdit.Name = "stdOrderSpinEdit";
            this.stdOrderSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.stdOrderSpinEdit.Size = new System.Drawing.Size(100, 20);
            this.stdOrderSpinEdit.TabIndex = 3;
            // 
            // locationIDLookUpEdit
            // 
            this.locationIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Floor_LevelsBindingSource, "LocationID", true));
            this.locationIDLookUpEdit.EnterMoveNextControl = true;
            this.locationIDLookUpEdit.Location = new System.Drawing.Point(140, 30);
            this.locationIDLookUpEdit.Name = "locationIDLookUpEdit";
            this.locationIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.locationIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Location ID", 77, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "Location Code", 78, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationName", "Location Name", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.locationIDLookUpEdit.Properties.DataSource = this.locationBindingSource;
            this.locationIDLookUpEdit.Properties.DisplayMember = "LocationCode";
            this.locationIDLookUpEdit.Properties.NullText = "";
            this.locationIDLookUpEdit.Properties.ValueMember = "LocationID";
            this.locationIDLookUpEdit.Size = new System.Drawing.Size(140, 20);
            this.locationIDLookUpEdit.TabIndex = 0;
            // 
            // levelNameTextEdit
            // 
            this.levelNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Floor_LevelsBindingSource, "LevelName", true));
            this.levelNameTextEdit.EnterMoveNextControl = true;
            this.levelNameTextEdit.Location = new System.Drawing.Point(140, 82);
            this.levelNameTextEdit.Name = "levelNameTextEdit";
            this.levelNameTextEdit.Properties.MaxLength = 50;
            this.levelNameTextEdit.Size = new System.Drawing.Size(348, 20);
            this.levelNameTextEdit.TabIndex = 2;
            // 
            // levelCodeTextEdit
            // 
            this.levelCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Floor_LevelsBindingSource, "LevelCode", true));
            this.levelCodeTextEdit.EnterMoveNextControl = true;
            this.levelCodeTextEdit.Location = new System.Drawing.Point(140, 56);
            this.levelCodeTextEdit.Name = "levelCodeTextEdit";
            this.levelCodeTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.levelCodeTextEdit.Properties.MaxLength = 20;
            this.levelCodeTextEdit.Size = new System.Drawing.Size(140, 20);
            this.levelCodeTextEdit.TabIndex = 1;
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
            // xFloor_Levels
            // 
            this.ClientSize = new System.Drawing.Size(932, 436);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xFloor_Levels";
            this.Text = "Floor Levels";
            this.Load += new System.EventHandler(this.xFloor_Levels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Floor_LevelsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Floor_LevelsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdOrderSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl Floor_LevelsGridControl;
        private System.Windows.Forms.BindingSource Floor_LevelsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelID;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelName;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private DevExpress.XtraEditors.TextEdit levelCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit levelNameTextEdit;
        private DevExpress.XtraEditors.LookUpEdit locationIDLookUpEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.SpinEdit stdOrderSpinEdit;
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
    }
}
