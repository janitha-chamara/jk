namespace MMS.UserPermission
{
    partial class xEmailAlertProfiles
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
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookRoleID = new DevExpress.XtraEditors.LookUpEdit();
            this.emailAlertRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.emailAlertRoleGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmailAlertRoleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailAlertItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookAlertItemID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIsEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookRoleID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailAlertRoleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailAlertRoleGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookAlertItemID)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdNew
            // 
            this.cmdNew.Enabled = false;
            this.cmdNew.Visible = false;
            this.cmdNew.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdNew_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Enabled = false;
            this.cmdEdit.Visible = false;
            this.cmdEdit.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdEdit_Click);
            // 
            // cmdFirst
            // 
            this.cmdFirst.Enabled = false;
            this.cmdFirst.Visible = false;
            this.cmdFirst.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdFirst_Click);
            // 
            // cmdPrev
            // 
            this.cmdPrev.Enabled = false;
            this.cmdPrev.Visible = false;
            this.cmdPrev.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdPrev_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Enabled = false;
            this.cmdNext.Visible = false;
            this.cmdNext.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdNext_Click);
            // 
            // cmdLast
            // 
            this.cmdLast.Enabled = false;
            this.cmdLast.Visible = false;
            // 
            // cmdUndo
            // 
            this.cmdUndo.Enabled = false;
            this.cmdUndo.Visible = false;
            this.cmdUndo.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdUndo_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Visible = false;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Visible = false;
            this.cmdDelete.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdDelete_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Visible = false;
            // 
            // cmdSave
            // 
            this.cmdSave.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdSave_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdClose_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelControl1.LookAndFeel.SkinName = "Caramel";
            this.labelControl1.Size = new System.Drawing.Size(794, 27);
            this.labelControl1.Text = "Email Alert Profiles";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 96);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Role :";
            // 
            // lookRoleID
            // 
            this.lookRoleID.Location = new System.Drawing.Point(60, 93);
            this.lookRoleID.Name = "lookRoleID";
            this.lookRoleID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookRoleID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoleID", "RoleID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoleName", "RoleName")});
            this.lookRoleID.Properties.NullText = "";
            this.lookRoleID.Size = new System.Drawing.Size(198, 20);
            this.lookRoleID.TabIndex = 2;
            this.lookRoleID.EditValueChanged += new System.EventHandler(this.lookRoleID_EditValueChanged);
            // 
            // emailAlertRoleBindingSource
            // 
            this.emailAlertRoleBindingSource.DataSource = typeof(DataTier.EmailAlertRole);
            // 
            // emailAlertRoleGridControl
            // 
            this.emailAlertRoleGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailAlertRoleGridControl.DataSource = this.emailAlertRoleBindingSource;
            this.emailAlertRoleGridControl.Location = new System.Drawing.Point(18, 128);
            this.emailAlertRoleGridControl.MainView = this.gridView1;
            this.emailAlertRoleGridControl.Name = "emailAlertRoleGridControl";
            this.emailAlertRoleGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookAlertItemID});
            this.emailAlertRoleGridControl.Size = new System.Drawing.Size(758, 286);
            this.emailAlertRoleGridControl.TabIndex = 4;
            this.emailAlertRoleGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmailAlertRoleID,
            this.colRoleID,
            this.colEmailAlertItemID,
            this.colIsEnabled});
            this.gridView1.GridControl = this.emailAlertRoleGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "List of Alert Items";
            // 
            // colEmailAlertRoleID
            // 
            this.colEmailAlertRoleID.FieldName = "EmailAlertRoleID";
            this.colEmailAlertRoleID.Name = "colEmailAlertRoleID";
            // 
            // colRoleID
            // 
            this.colRoleID.FieldName = "RoleID";
            this.colRoleID.Name = "colRoleID";
            // 
            // colEmailAlertItemID
            // 
            this.colEmailAlertItemID.Caption = "Alert Item";
            this.colEmailAlertItemID.ColumnEdit = this.lookAlertItemID;
            this.colEmailAlertItemID.FieldName = "EmailAlertItemID";
            this.colEmailAlertItemID.Name = "colEmailAlertItemID";
            this.colEmailAlertItemID.OptionsColumn.AllowEdit = false;
            this.colEmailAlertItemID.OptionsColumn.ReadOnly = true;
            this.colEmailAlertItemID.Visible = true;
            this.colEmailAlertItemID.VisibleIndex = 0;
            this.colEmailAlertItemID.Width = 1023;
            // 
            // lookAlertItemID
            // 
            this.lookAlertItemID.AutoHeight = false;
            this.lookAlertItemID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookAlertItemID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmailAlertItemID", "EmailAlertItemID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmailArertItemName", "EmailArertItemName")});
            this.lookAlertItemID.Name = "lookAlertItemID";
            this.lookAlertItemID.NullText = "";
            // 
            // colIsEnabled
            // 
            this.colIsEnabled.Caption = "Enabled";
            this.colIsEnabled.FieldName = "IsEnabled";
            this.colIsEnabled.Name = "colIsEnabled";
            this.colIsEnabled.Visible = true;
            this.colIsEnabled.VisibleIndex = 1;
            this.colIsEnabled.Width = 154;
            // 
            // xEmailAlertProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 425);
            this.Controls.Add(this.emailAlertRoleGridControl);
            this.Controls.Add(this.lookRoleID);
            this.Controls.Add(this.labelControl2);
            this.Name = "xEmailAlertProfiles";
            this.Text = "Email Alert Profiles";
            this.Load += new System.EventHandler(this.xEmailAlertProfiles_Load);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.lookRoleID, 0);
            this.Controls.SetChildIndex(this.emailAlertRoleGridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookRoleID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailAlertRoleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailAlertRoleGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookAlertItemID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.LookUpEdit lookRoleID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl emailAlertRoleGridControl;
        private System.Windows.Forms.BindingSource emailAlertRoleBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailAlertRoleID;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailAlertItemID;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEnabled;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookAlertItemID;
    }
}