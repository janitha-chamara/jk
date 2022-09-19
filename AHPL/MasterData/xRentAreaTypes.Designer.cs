namespace MMS
{
    partial class xRentAreaTypes
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
            System.Windows.Forms.Label rentAreaTypeNameLabel;
            System.Windows.Forms.Label isSqFeetApplyLabel;
            System.Windows.Forms.Label isAdvertisementLabel;
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.rent_Area_TypesGridControl = new DevExpress.XtraGrid.GridControl();
            this.rent_Area_TypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRentAreaTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentAreaTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSqFeetApply = new DevExpress.XtraGrid.Columns.GridColumn();
            this.isAdvertisementCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.isSqFeetApplyCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.rentAreaTypeNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            rentAreaTypeNameLabel = new System.Windows.Forms.Label();
            isSqFeetApplyLabel = new System.Windows.Forms.Label();
            isAdvertisementLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rent_Area_TypesGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rent_Area_TypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isAdvertisementCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isSqFeetApplyCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentAreaTypeNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // rentAreaTypeNameLabel
            // 
            rentAreaTypeNameLabel.AutoSize = true;
            rentAreaTypeNameLabel.Location = new System.Drawing.Point(46, 33);
            rentAreaTypeNameLabel.Name = "rentAreaTypeNameLabel";
            rentAreaTypeNameLabel.Size = new System.Drawing.Size(117, 13);
            rentAreaTypeNameLabel.TabIndex = 0;
            rentAreaTypeNameLabel.Text = "Rent Area Type Name:";
            // 
            // isSqFeetApplyLabel
            // 
            isSqFeetApplyLabel.AutoSize = true;
            isSqFeetApplyLabel.Location = new System.Drawing.Point(46, 59);
            isSqFeetApplyLabel.Name = "isSqFeetApplyLabel";
            isSqFeetApplyLabel.Size = new System.Drawing.Size(115, 13);
            isSqFeetApplyLabel.TabIndex = 2;
            isSqFeetApplyLabel.Text = "Is Sq. Feet Applicable:";
            // 
            // isAdvertisementLabel
            // 
            isAdvertisementLabel.AutoSize = true;
            isAdvertisementLabel.Location = new System.Drawing.Point(70, 84);
            isAdvertisementLabel.Name = "isAdvertisementLabel";
            isAdvertisementLabel.Size = new System.Drawing.Size(93, 13);
            isAdvertisementLabel.TabIndex = 4;
            isAdvertisementLabel.Text = "Is Advertisement:";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.splitContainerControl1.Panel1.Controls.Add(this.rent_Area_TypesGridControl);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "List of Rent Area Types";
            this.splitContainerControl1.Panel2.Controls.Add(isAdvertisementLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.isAdvertisementCheckEdit);
            this.splitContainerControl1.Panel2.Controls.Add(isSqFeetApplyLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.isSqFeetApplyCheckEdit);
            this.splitContainerControl1.Panel2.Controls.Add(rentAreaTypeNameLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.rentAreaTypeNameTextEdit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(932, 389);
            this.splitContainerControl1.SplitterPosition = 264;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // rent_Area_TypesGridControl
            // 
            this.rent_Area_TypesGridControl.DataSource = this.rent_Area_TypesBindingSource;
            this.rent_Area_TypesGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rent_Area_TypesGridControl.Location = new System.Drawing.Point(0, 0);
            this.rent_Area_TypesGridControl.MainView = this.gridView1;
            this.rent_Area_TypesGridControl.Name = "rent_Area_TypesGridControl";
            this.rent_Area_TypesGridControl.Size = new System.Drawing.Size(260, 366);
            this.rent_Area_TypesGridControl.TabIndex = 0;
            this.rent_Area_TypesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // rent_Area_TypesBindingSource
            // 
            this.rent_Area_TypesBindingSource.DataSource = typeof(DataTier.Rent_Area_Types);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRentAreaTypeID,
            this.colRentAreaTypeName,
            this.colIsSqFeetApply});
            this.gridView1.GridControl = this.rent_Area_TypesGridControl;
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
            // colRentAreaTypeID
            // 
            this.colRentAreaTypeID.FieldName = "RentAreaTypeID";
            this.colRentAreaTypeID.Name = "colRentAreaTypeID";
            this.colRentAreaTypeID.Width = 149;
            // 
            // colRentAreaTypeName
            // 
            this.colRentAreaTypeName.FieldName = "RentAreaTypeName";
            this.colRentAreaTypeName.Name = "colRentAreaTypeName";
            this.colRentAreaTypeName.Visible = true;
            this.colRentAreaTypeName.VisibleIndex = 0;
            this.colRentAreaTypeName.Width = 124;
            // 
            // colIsSqFeetApply
            // 
            this.colIsSqFeetApply.Caption = "Is Sq.Feet Applicapable";
            this.colIsSqFeetApply.FieldName = "IsSqFeetApply";
            this.colIsSqFeetApply.Name = "colIsSqFeetApply";
            this.colIsSqFeetApply.Visible = true;
            this.colIsSqFeetApply.VisibleIndex = 1;
            this.colIsSqFeetApply.Width = 127;
            // 
            // isAdvertisementCheckEdit
            // 
            this.isAdvertisementCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rent_Area_TypesBindingSource, "IsAdvertisement", true));
            this.isAdvertisementCheckEdit.Location = new System.Drawing.Point(169, 81);
            this.isAdvertisementCheckEdit.Name = "isAdvertisementCheckEdit";
            this.isAdvertisementCheckEdit.Properties.Caption = "";
            this.isAdvertisementCheckEdit.Size = new System.Drawing.Size(75, 19);
            this.isAdvertisementCheckEdit.TabIndex = 5;
            // 
            // isSqFeetApplyCheckEdit
            // 
            this.isSqFeetApplyCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rent_Area_TypesBindingSource, "IsSqFeetApply", true));
            this.isSqFeetApplyCheckEdit.Location = new System.Drawing.Point(169, 56);
            this.isSqFeetApplyCheckEdit.Name = "isSqFeetApplyCheckEdit";
            this.isSqFeetApplyCheckEdit.Properties.Caption = "";
            this.isSqFeetApplyCheckEdit.Size = new System.Drawing.Size(75, 19);
            this.isSqFeetApplyCheckEdit.TabIndex = 3;
            // 
            // rentAreaTypeNameTextEdit
            // 
            this.rentAreaTypeNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rent_Area_TypesBindingSource, "RentAreaTypeName", true));
            this.rentAreaTypeNameTextEdit.Location = new System.Drawing.Point(169, 30);
            this.rentAreaTypeNameTextEdit.Name = "rentAreaTypeNameTextEdit";
            this.rentAreaTypeNameTextEdit.Properties.MaxLength = 50;
            this.rentAreaTypeNameTextEdit.Size = new System.Drawing.Size(214, 20);
            this.rentAreaTypeNameTextEdit.TabIndex = 1;
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
            this.btnSave,
            this.btnClose,
            this.btnDelete,
            this.btnRefresh,
            this.btnUndo});
            this.barManager1.MaxItemId = 8;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUndo),
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
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Glyph = global::MMS.Properties.Resources.disk_blue;
            this.btnSave.Id = 2;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
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
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Glyph = global::MMS.Properties.Resources.undo;
            this.btnUndo.Id = 7;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndo_ItemClick);
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
            // xRentAreaTypes
            // 
            this.ClientSize = new System.Drawing.Size(932, 436);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xRentAreaTypes";
            this.Text = "Rent Area Types";
            this.Load += new System.EventHandler(this.xRentAreaTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rent_Area_TypesGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rent_Area_TypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isAdvertisementCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isSqFeetApplyCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentAreaTypeNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl rent_Area_TypesGridControl;
        private System.Windows.Forms.BindingSource rent_Area_TypesBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colRentAreaTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colRentAreaTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSqFeetApply;
        private DevExpress.XtraEditors.CheckEdit isSqFeetApplyCheckEdit;
        private DevExpress.XtraEditors.TextEdit rentAreaTypeNameTextEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.CheckEdit isAdvertisementCheckEdit;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
    }
}
