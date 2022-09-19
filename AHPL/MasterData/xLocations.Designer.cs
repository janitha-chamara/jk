using DataTier;
namespace MMS
{
    partial class xLocations
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
            System.Windows.Forms.Label locationCodeLabel;
            System.Windows.Forms.Label locationNameLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label logoLabel;
            System.Windows.Forms.Label invoicePrefixLabel;
            System.Windows.Forms.Label totalFloorAreaLabel;
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.locationGridControl = new DevExpress.XtraGrid.GridControl();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtFreeArea = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtAvailArea = new DevExpress.XtraEditors.ButtonEdit();
            this.txtOccupiedArea = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.invoicePrefixTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.logoPictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.addressMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.locationNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.locationCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.totalFloorAreaTextEdit = new DevExpress.XtraEditors.ButtonEdit();
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
            locationCodeLabel = new System.Windows.Forms.Label();
            locationNameLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            logoLabel = new System.Windows.Forms.Label();
            invoicePrefixLabel = new System.Windows.Forms.Label();
            totalFloorAreaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFreeArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvailArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOccupiedArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicePrefixTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalFloorAreaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // locationCodeLabel
            // 
            locationCodeLabel.AutoSize = true;
            locationCodeLabel.Location = new System.Drawing.Point(46, 35);
            locationCodeLabel.Name = "locationCodeLabel";
            locationCodeLabel.Size = new System.Drawing.Size(101, 17);
            locationCodeLabel.TabIndex = 0;
            locationCodeLabel.Text = "Location Code:";
            // 
            // locationNameLabel
            // 
            locationNameLabel.AutoSize = true;
            locationNameLabel.Location = new System.Drawing.Point(44, 62);
            locationNameLabel.Name = "locationNameLabel";
            locationNameLabel.Size = new System.Drawing.Size(104, 17);
            locationNameLabel.TabIndex = 2;
            locationNameLabel.Text = "Location Name:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(75, 88);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(61, 17);
            addressLabel.TabIndex = 4;
            addressLabel.Text = "Address:";
            // 
            // logoLabel
            // 
            logoLabel.AutoSize = true;
            logoLabel.Location = new System.Drawing.Point(91, 145);
            logoLabel.Name = "logoLabel";
            logoLabel.Size = new System.Drawing.Size(44, 17);
            logoLabel.TabIndex = 6;
            logoLabel.Text = "Logo:";
            // 
            // invoicePrefixLabel
            // 
            invoicePrefixLabel.AutoSize = true;
            invoicePrefixLabel.Location = new System.Drawing.Point(383, 35);
            invoicePrefixLabel.Name = "invoicePrefixLabel";
            invoicePrefixLabel.Size = new System.Drawing.Size(95, 17);
            invoicePrefixLabel.TabIndex = 8;
            invoicePrefixLabel.Text = "Invoice Prefix:";
            // 
            // totalFloorAreaLabel
            // 
            totalFloorAreaLabel.AutoSize = true;
            totalFloorAreaLabel.Location = new System.Drawing.Point(37, 348);
            totalFloorAreaLabel.Name = "totalFloorAreaLabel";
            totalFloorAreaLabel.Size = new System.Drawing.Size(108, 17);
            totalFloorAreaLabel.TabIndex = 10;
            totalFloorAreaLabel.Text = "Total Floor Area:";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 55);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel1.Controls.Add(this.locationGridControl);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "List of Locations";
            this.splitContainerControl1.Panel2.Controls.Add(this.txtFreeArea);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtAvailArea);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtOccupiedArea);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(totalFloorAreaLabel);
            this.splitContainerControl1.Panel2.Controls.Add(invoicePrefixLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.invoicePrefixTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(logoLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.logoPictureEdit);
            this.splitContainerControl1.Panel2.Controls.Add(addressLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.addressMemoEdit);
            this.splitContainerControl1.Panel2.Controls.Add(locationNameLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.locationNameTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(locationCodeLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.locationCodeTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.totalFloorAreaTextEdit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(932, 471);
            this.splitContainerControl1.SplitterPosition = 240;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // locationGridControl
            // 
            this.locationGridControl.CausesValidation = false;
            this.locationGridControl.DataSource = this.locationBindingSource;
            this.locationGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locationGridControl.Location = new System.Drawing.Point(0, 0);
            this.locationGridControl.MainView = this.gridView1;
            this.locationGridControl.Name = "locationGridControl";
            this.locationGridControl.Size = new System.Drawing.Size(236, 445);
            this.locationGridControl.TabIndex = 0;
            this.locationGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // locationBindingSource
            // 
            this.locationBindingSource.DataSource = typeof(DataTier.Location);
            this.locationBindingSource.PositionChanged += new System.EventHandler(this.locationBindingSource_PositionChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLocationID,
            this.colLocationName,
            this.colAddress,
            this.colLocationCode});
            this.gridView1.GridControl = this.locationGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colLocationID
            // 
            this.colLocationID.Caption = "#";
            this.colLocationID.FieldName = "LocationID";
            this.colLocationID.Name = "colLocationID";
            this.colLocationID.Width = 30;
            // 
            // colLocationName
            // 
            this.colLocationName.FieldName = "LocationName";
            this.colLocationName.Name = "colLocationName";
            this.colLocationName.Visible = true;
            this.colLocationName.VisibleIndex = 1;
            this.colLocationName.Width = 200;
            // 
            // colAddress
            // 
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Width = 371;
            // 
            // colLocationCode
            // 
            this.colLocationCode.FieldName = "LocationCode";
            this.colLocationCode.Name = "colLocationCode";
            this.colLocationCode.Visible = true;
            this.colLocationCode.VisibleIndex = 0;
            this.colLocationCode.Width = 102;
            // 
            // txtFreeArea
            // 
            this.txtFreeArea.Enabled = false;
            this.txtFreeArea.Location = new System.Drawing.Point(399, 397);
            this.txtFreeArea.Name = "txtFreeArea";
            this.txtFreeArea.Properties.DisplayFormat.FormatString = "n4";
            this.txtFreeArea.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtFreeArea.Properties.EditFormat.FormatString = "n4";
            this.txtFreeArea.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtFreeArea.Size = new System.Drawing.Size(100, 22);
            this.txtFreeArea.TabIndex = 17;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(296, 400);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(112, 16);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "Un-Allocated Area :";
            // 
            // txtAvailArea
            // 
            this.txtAvailArea.Location = new System.Drawing.Point(399, 370);
            this.txtAvailArea.Name = "txtAvailArea";
            this.txtAvailArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtAvailArea.Size = new System.Drawing.Size(100, 22);
            this.txtAvailArea.TabIndex = 15;
            // 
            // txtOccupiedArea
            // 
            this.txtOccupiedArea.EnterMoveNextControl = true;
            this.txtOccupiedArea.Location = new System.Drawing.Point(399, 345);
            this.txtOccupiedArea.Name = "txtOccupiedArea";
            this.txtOccupiedArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtOccupiedArea.Size = new System.Drawing.Size(100, 22);
            this.txtOccupiedArea.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(263, 373);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(154, 16);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Vacant Shop\'s Total Area :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(313, 348);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(92, 16);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Occupied Area :";
            // 
            // invoicePrefixTextEdit
            // 
            this.invoicePrefixTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.locationBindingSource, "InvoicePrefix", true));
            this.invoicePrefixTextEdit.EnterMoveNextControl = true;
            this.invoicePrefixTextEdit.Location = new System.Drawing.Point(466, 31);
            this.invoicePrefixTextEdit.Name = "invoicePrefixTextEdit";
            this.invoicePrefixTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.invoicePrefixTextEdit.Properties.MaxLength = 2;
            this.invoicePrefixTextEdit.Size = new System.Drawing.Size(33, 22);
            this.invoicePrefixTextEdit.TabIndex = 1;
            // 
            // logoPictureEdit
            // 
            this.logoPictureEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.locationBindingSource, "Logo", true));
            this.logoPictureEdit.EnterMoveNextControl = true;
            this.logoPictureEdit.Location = new System.Drawing.Point(131, 142);
            this.logoPictureEdit.Name = "logoPictureEdit";
            this.logoPictureEdit.Properties.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.logoPictureEdit.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            this.logoPictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.logoPictureEdit.Size = new System.Drawing.Size(329, 197);
            this.logoPictureEdit.TabIndex = 4;
            // 
            // addressMemoEdit
            // 
            this.addressMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.locationBindingSource, "Address", true));
            this.addressMemoEdit.EnterMoveNextControl = true;
            this.addressMemoEdit.Location = new System.Drawing.Point(131, 85);
            this.addressMemoEdit.Name = "addressMemoEdit";
            this.addressMemoEdit.Properties.MaxLength = 70;
            this.addressMemoEdit.Size = new System.Drawing.Size(243, 51);
            this.addressMemoEdit.TabIndex = 3;
            this.addressMemoEdit.UseOptimizedRendering = true;
            // 
            // locationNameTextEdit
            // 
            this.locationNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.locationBindingSource, "LocationName", true));
            this.locationNameTextEdit.EnterMoveNextControl = true;
            this.locationNameTextEdit.Location = new System.Drawing.Point(131, 59);
            this.locationNameTextEdit.Name = "locationNameTextEdit";
            this.locationNameTextEdit.Properties.MaxLength = 50;
            this.locationNameTextEdit.Size = new System.Drawing.Size(368, 22);
            this.locationNameTextEdit.TabIndex = 2;
            // 
            // locationCodeTextEdit
            // 
            this.locationCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.locationBindingSource, "LocationCode", true));
            this.locationCodeTextEdit.EnterMoveNextControl = true;
            this.locationCodeTextEdit.Location = new System.Drawing.Point(131, 31);
            this.locationCodeTextEdit.Name = "locationCodeTextEdit";
            this.locationCodeTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.locationCodeTextEdit.Properties.MaxLength = 20;
            this.locationCodeTextEdit.Size = new System.Drawing.Size(160, 22);
            this.locationCodeTextEdit.TabIndex = 0;
            // 
            // totalFloorAreaTextEdit
            // 
            this.totalFloorAreaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.locationBindingSource, "TotalFloorArea", true));
            this.totalFloorAreaTextEdit.EnterMoveNextControl = true;
            this.totalFloorAreaTextEdit.Location = new System.Drawing.Point(131, 345);
            this.totalFloorAreaTextEdit.Name = "totalFloorAreaTextEdit";
            this.totalFloorAreaTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.totalFloorAreaTextEdit.Properties.DisplayFormat.FormatString = "n4";
            this.totalFloorAreaTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.totalFloorAreaTextEdit.Properties.EditFormat.FormatString = "n4";
            this.totalFloorAreaTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.totalFloorAreaTextEdit.Properties.Mask.EditMask = "n4";
            this.totalFloorAreaTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.totalFloorAreaTextEdit.Size = new System.Drawing.Size(100, 22);
            this.totalFloorAreaTextEdit.TabIndex = 5;
            this.totalFloorAreaTextEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.totalFloorAreaTextEdit_ButtonClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(932, 55);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 526);
            this.barDockControlBottom.Size = new System.Drawing.Size(932, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 471);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(932, 55);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 471);
            // 
            // xLocations
            // 
            this.ClientSize = new System.Drawing.Size(932, 526);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xLocations";
            this.Text = "Locations";
            this.Load += new System.EventHandler(this.xLocations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.locationGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFreeArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvailArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOccupiedArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicePrefixTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalFloorAreaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl locationGridControl;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationCode;
        private DevExpress.XtraEditors.TextEdit locationCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit locationNameTextEdit;
        private DevExpress.XtraEditors.MemoEdit addressMemoEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.PictureEdit logoPictureEdit;
        private DevExpress.XtraEditors.TextEdit invoicePrefixTextEdit;
        private DevExpress.XtraEditors.ButtonEdit txtAvailArea;
        private DevExpress.XtraEditors.ButtonEdit txtOccupiedArea;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit totalFloorAreaTextEdit;
        private DevExpress.XtraEditors.TextEdit txtFreeArea;
        private DevExpress.XtraEditors.LabelControl labelControl4;
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
