namespace MMS.AuditTrail
{
    partial class xSecurityUsersAudit
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
            this.securityAudit_GridControl = new DevExpress.XtraGrid.GridControl();
            this.securityAudit_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAuditRowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsUserHead = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscontinued = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscontinuedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDNSUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colR3_UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colR3_Password = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISR_UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISR_Password = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.securityAudit_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityAudit_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // securityAudit_GridControl
            // 
            this.securityAudit_GridControl.DataSource = this.securityAudit_BindingSource;
            this.securityAudit_GridControl.Location = new System.Drawing.Point(-1, -1);
            this.securityAudit_GridControl.MainView = this.gridView1;
            this.securityAudit_GridControl.Name = "securityAudit_GridControl";
            this.securityAudit_GridControl.Size = new System.Drawing.Size(911, 448);
            this.securityAudit_GridControl.TabIndex = 0;
            this.securityAudit_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // securityAudit_BindingSource
            // 
            this.securityAudit_BindingSource.DataSource = typeof(DataTier.Permission_Users_Audit);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAuditRowID,
            this.colUserID,
            this.colUserName,
            this.colPassword,
            this.colRoleID,
            this.colUserGroupID,
            this.colIsUserHead,
            this.colDiscontinued,
            this.colDiscontinuedDate,
            this.colDNSUserName,
            this.colEmail1,
            this.colEmail2,
            this.colR3_UserName,
            this.colR3_Password,
            this.colISR_UserName,
            this.colISR_Password,
            this.colUpdatedBy,
            this.colUpdatedDate});
            this.gridView1.GridControl = this.securityAudit_GridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colAuditRowID
            // 
            this.colAuditRowID.FieldName = "AuditRowID";
            this.colAuditRowID.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colAuditRowID.Name = "colAuditRowID";
            this.colAuditRowID.Visible = true;
            this.colAuditRowID.VisibleIndex = 0;
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 1;
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 2;
            // 
            // colPassword
            // 
            this.colPassword.FieldName = "Password";
            this.colPassword.Name = "colPassword";
            this.colPassword.Visible = true;
            this.colPassword.VisibleIndex = 3;
            // 
            // colRoleID
            // 
            this.colRoleID.FieldName = "RoleID";
            this.colRoleID.Name = "colRoleID";
            this.colRoleID.Visible = true;
            this.colRoleID.VisibleIndex = 4;
            // 
            // colUserGroupID
            // 
            this.colUserGroupID.FieldName = "UserGroupID";
            this.colUserGroupID.Name = "colUserGroupID";
            this.colUserGroupID.Visible = true;
            this.colUserGroupID.VisibleIndex = 5;
            // 
            // colIsUserHead
            // 
            this.colIsUserHead.FieldName = "IsUserHead";
            this.colIsUserHead.Name = "colIsUserHead";
            this.colIsUserHead.Visible = true;
            this.colIsUserHead.VisibleIndex = 6;
            // 
            // colDiscontinued
            // 
            this.colDiscontinued.FieldName = "Discontinued";
            this.colDiscontinued.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colDiscontinued.Name = "colDiscontinued";
            this.colDiscontinued.Visible = true;
            this.colDiscontinued.VisibleIndex = 15;
            // 
            // colDiscontinuedDate
            // 
            this.colDiscontinuedDate.FieldName = "DiscontinuedDate";
            this.colDiscontinuedDate.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colDiscontinuedDate.Name = "colDiscontinuedDate";
            this.colDiscontinuedDate.Visible = true;
            this.colDiscontinuedDate.VisibleIndex = 14;
            // 
            // colDNSUserName
            // 
            this.colDNSUserName.FieldName = "DNSUserName";
            this.colDNSUserName.Name = "colDNSUserName";
            this.colDNSUserName.Visible = true;
            this.colDNSUserName.VisibleIndex = 7;
            // 
            // colEmail1
            // 
            this.colEmail1.FieldName = "Email1";
            this.colEmail1.Name = "colEmail1";
            this.colEmail1.Visible = true;
            this.colEmail1.VisibleIndex = 8;
            // 
            // colEmail2
            // 
            this.colEmail2.FieldName = "Email2";
            this.colEmail2.Name = "colEmail2";
            this.colEmail2.Visible = true;
            this.colEmail2.VisibleIndex = 9;
            // 
            // colR3_UserName
            // 
            this.colR3_UserName.FieldName = "R3_UserName";
            this.colR3_UserName.Name = "colR3_UserName";
            this.colR3_UserName.Visible = true;
            this.colR3_UserName.VisibleIndex = 10;
            // 
            // colR3_Password
            // 
            this.colR3_Password.FieldName = "R3_Password";
            this.colR3_Password.Name = "colR3_Password";
            this.colR3_Password.Visible = true;
            this.colR3_Password.VisibleIndex = 11;
            // 
            // colISR_UserName
            // 
            this.colISR_UserName.FieldName = "ISR_UserName";
            this.colISR_UserName.Name = "colISR_UserName";
            this.colISR_UserName.Visible = true;
            this.colISR_UserName.VisibleIndex = 12;
            // 
            // colISR_Password
            // 
            this.colISR_Password.FieldName = "ISR_Password";
            this.colISR_Password.Name = "colISR_Password";
            this.colISR_Password.Visible = true;
            this.colISR_Password.VisibleIndex = 13;
            // 
            // colUpdatedBy
            // 
            this.colUpdatedBy.FieldName = "UpdatedBy";
            this.colUpdatedBy.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colUpdatedBy.Name = "colUpdatedBy";
            this.colUpdatedBy.Visible = true;
            this.colUpdatedBy.VisibleIndex = 16;
            // 
            // colUpdatedDate
            // 
            this.colUpdatedDate.FieldName = "UpdatedDate";
            this.colUpdatedDate.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colUpdatedDate.Name = "colUpdatedDate";
            this.colUpdatedDate.Visible = true;
            this.colUpdatedDate.VisibleIndex = 17;
            // 
            // xSecurityUsersAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 447);
            this.Controls.Add(this.securityAudit_GridControl);
            this.Name = "xSecurityUsersAudit";
            this.Text = "Security Users - Audit";
            this.Load += new System.EventHandler(this.xSecurityUsersAudit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.securityAudit_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityAudit_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl securityAudit_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource securityAudit_BindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditRowID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colIsUserHead;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscontinued;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscontinuedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDNSUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail2;
        private DevExpress.XtraGrid.Columns.GridColumn colR3_UserName;
        private DevExpress.XtraGrid.Columns.GridColumn colR3_Password;
        private DevExpress.XtraGrid.Columns.GridColumn colISR_UserName;
        private DevExpress.XtraGrid.Columns.GridColumn colISR_Password;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedDate;
    }
}