namespace MMS
{
    partial class xRolePermissions
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditRoleName = new DevExpress.XtraEditors.LookUpEdit();
            this.permissionRolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.permission_UserFormsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.permission_UserFormsGridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserFormID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFormID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.permissionFormsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colIsVisibile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookRoleID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModuleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubModuleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.btbSelectAll = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditRoleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionRolesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permission_UserFormsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permission_UserFormsGridControl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionFormsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookRoleID)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 37);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Role :";
            // 
            // lookUpEditRoleName
            // 
            this.lookUpEditRoleName.Location = new System.Drawing.Point(54, 33);
            this.lookUpEditRoleName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEditRoleName.Name = "lookUpEditRoleName";
            this.lookUpEditRoleName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditRoleName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoleID", "Role ID", 58, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoleName", "Role Name", 61, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpEditRoleName.Properties.DataSource = this.permissionRolesBindingSource;
            this.lookUpEditRoleName.Properties.DisplayMember = "RoleName";
            this.lookUpEditRoleName.Properties.NullText = "";
            this.lookUpEditRoleName.Properties.ValueMember = "RoleID";
            this.lookUpEditRoleName.Size = new System.Drawing.Size(237, 22);
            this.lookUpEditRoleName.TabIndex = 1;
            this.lookUpEditRoleName.EditValueChanged += new System.EventHandler(this.lookUpEditRoleName_EditValueChanged);
            // 
            // permissionRolesBindingSource
            // 
            this.permissionRolesBindingSource.DataSource = typeof(DataTier.Permission_Roles);
            // 
            // permission_UserFormsBindingSource
            // 
            this.permission_UserFormsBindingSource.DataSource = typeof(DataTier.Permission_UserForms);
            // 
            // permission_UserFormsGridControl
            // 
            this.permission_UserFormsGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.permission_UserFormsGridControl.ContextMenuStrip = this.contextMenuStrip1;
            this.permission_UserFormsGridControl.DataSource = this.permission_UserFormsBindingSource;
            this.permission_UserFormsGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.permission_UserFormsGridControl.Location = new System.Drawing.Point(14, 107);
            this.permission_UserFormsGridControl.MainView = this.gridView1;
            this.permission_UserFormsGridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.permission_UserFormsGridControl.Name = "permission_UserFormsGridControl";
            this.permission_UserFormsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.lookRoleID});
            this.permission_UserFormsGridControl.Size = new System.Drawing.Size(883, 345);
            this.permission_UserFormsGridControl.TabIndex = 3;
            this.permission_UserFormsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserFormID,
            this.colFormID,
            this.colIsVisibile,
            this.colC,
            this.colR,
            this.colU,
            this.colD,
            this.colRoleID,
            this.colModuleName,
            this.colSubModuleName});
            this.gridView1.GridControl = this.permission_UserFormsGridControl;
            this.gridView1.GroupCount = 3;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRoleID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colModuleName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSubModuleName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ViewCaption = "List of Forms";
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // colUserFormID
            // 
            this.colUserFormID.FieldName = "UserFormID";
            this.colUserFormID.Name = "colUserFormID";
            this.colUserFormID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colFormID
            // 
            this.colFormID.Caption = "Form Name";
            this.colFormID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colFormID.CustomizationCaption = "Form Name";
            this.colFormID.FieldName = "FormID";
            this.colFormID.Name = "colFormID";
            this.colFormID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colFormID.OptionsColumn.ReadOnly = true;
            this.colFormID.Visible = true;
            this.colFormID.VisibleIndex = 0;
            this.colFormID.Width = 337;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormID", "Form ID", 61, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormName", "Form Name", 64, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormDescriotion", "Form Descriotion", 90, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ModuleName", "Module Name", 74, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit1.DataSource = this.permissionFormsBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "FormDescriotion";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "FormID";
            // 
            // permissionFormsBindingSource
            // 
            this.permissionFormsBindingSource.DataSource = typeof(DataTier.Permission_Forms);
            // 
            // colIsVisibile
            // 
            this.colIsVisibile.FieldName = "IsVisibile";
            this.colIsVisibile.Name = "colIsVisibile";
            this.colIsVisibile.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIsVisibile.OptionsFilter.AllowFilter = false;
            this.colIsVisibile.Width = 78;
            // 
            // colC
            // 
            this.colC.Caption = "Add";
            this.colC.CustomizationCaption = "Create";
            this.colC.FieldName = "C";
            this.colC.Name = "colC";
            this.colC.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colC.OptionsFilter.AllowFilter = false;
            this.colC.Visible = true;
            this.colC.VisibleIndex = 2;
            this.colC.Width = 61;
            // 
            // colR
            // 
            this.colR.Caption = "Visible";
            this.colR.CustomizationCaption = "Visible";
            this.colR.FieldName = "R";
            this.colR.Name = "colR";
            this.colR.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colR.OptionsFilter.AllowFilter = false;
            this.colR.Visible = true;
            this.colR.VisibleIndex = 1;
            this.colR.Width = 89;
            // 
            // colU
            // 
            this.colU.Caption = "Add / Edit";
            this.colU.CustomizationCaption = "Update";
            this.colU.FieldName = "U";
            this.colU.Name = "colU";
            this.colU.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colU.OptionsFilter.AllowFilter = false;
            this.colU.Visible = true;
            this.colU.VisibleIndex = 3;
            this.colU.Width = 73;
            // 
            // colD
            // 
            this.colD.Caption = "Delete";
            this.colD.CustomizationCaption = "Delete";
            this.colD.FieldName = "D";
            this.colD.Name = "colD";
            this.colD.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colD.OptionsFilter.AllowFilter = false;
            this.colD.Visible = true;
            this.colD.VisibleIndex = 4;
            this.colD.Width = 59;
            // 
            // colRoleID
            // 
            this.colRoleID.Caption = "Role";
            this.colRoleID.ColumnEdit = this.lookRoleID;
            this.colRoleID.FieldName = "RoleID";
            this.colRoleID.Name = "colRoleID";
            this.colRoleID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colRoleID.Visible = true;
            this.colRoleID.VisibleIndex = 5;
            // 
            // lookRoleID
            // 
            this.lookRoleID.AutoHeight = false;
            this.lookRoleID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookRoleID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoleID", "RoleID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoleName", "RoleName")});
            this.lookRoleID.Name = "lookRoleID";
            this.lookRoleID.NullText = "";
            // 
            // colModuleName
            // 
            this.colModuleName.FieldName = "ModuleName";
            this.colModuleName.Name = "colModuleName";
            this.colModuleName.Visible = true;
            this.colModuleName.VisibleIndex = 0;
            this.colModuleName.Width = 205;
            // 
            // colSubModuleName
            // 
            this.colSubModuleName.FieldName = "SubModuleName";
            this.colSubModuleName.Name = "colSubModuleName";
            this.colSubModuleName.Visible = true;
            this.colSubModuleName.VisibleIndex = 1;
            this.colSubModuleName.Width = 273;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::MMS.Properties.Resources.disk_blue1;
            this.btnSave.Location = new System.Drawing.Point(777, 25);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(777, 66);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 33);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btbSelectAll
            // 
            this.btbSelectAll.Location = new System.Drawing.Point(14, 107);
            this.btbSelectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btbSelectAll.Name = "btbSelectAll";
            this.btbSelectAll.Size = new System.Drawing.Size(87, 28);
            this.btbSelectAll.TabIndex = 7;
            this.btbSelectAll.Text = "Select All";
            this.btbSelectAll.CheckedChanged += new System.EventHandler(this.btbSelectAll_CheckedChanged);
            // 
            // xRolePermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 466);
            this.Controls.Add(this.btbSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.permission_UserFormsGridControl);
            this.Controls.Add(this.lookUpEditRoleName);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "xRolePermissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Role Permission";
            this.Load += new System.EventHandler(this.xRolePermissions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditRoleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionRolesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permission_UserFormsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permission_UserFormsGridControl)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionFormsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookRoleID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditRoleName;
        private System.Windows.Forms.BindingSource permission_UserFormsBindingSource;
        private DevExpress.XtraGrid.GridControl permission_UserFormsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserFormID;
        private DevExpress.XtraGrid.Columns.GridColumn colFormID;
        private DevExpress.XtraGrid.Columns.GridColumn colIsVisibile;
        private DevExpress.XtraGrid.Columns.GridColumn colC;
        private DevExpress.XtraGrid.Columns.GridColumn colR;
        private DevExpress.XtraGrid.Columns.GridColumn colU;
        private DevExpress.XtraGrid.Columns.GridColumn colD;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource permissionFormsBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.BindingSource permissionRolesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleName;
        private DevExpress.XtraGrid.Columns.GridColumn colSubModuleName;
        private DevExpress.XtraEditors.CheckButton btbSelectAll;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookRoleID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}