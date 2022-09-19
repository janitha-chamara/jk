namespace MMS.UserPermission
{
    partial class xEmailAlertItems
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
            this.emailAlertItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.emailAlertItemGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmailAlertItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailArertItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlertCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStdOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.emailAlertItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailAlertItemGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdNew
            // 
            this.cmdNew.Visible = false;
            this.cmdNew.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdNew_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdEdit_Click);
            // 
            // cmdFirst
            // 
            this.cmdFirst.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdFirst_Click);
            // 
            // cmdPrev
            // 
            this.cmdPrev.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdPrev_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdNext_Click);
            // 
            // cmdLast
            // 
            this.cmdLast.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdLast_Click);
            // 
            // cmdUndo
            // 
            this.cmdUndo.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdUndo_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Visible = false;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Visible = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdRefresh_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdSave_Click);
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
            this.labelControl1.Size = new System.Drawing.Size(926, 27);
            this.labelControl1.Text = "Email Alert Items";
            // 
            // parentTopPanel
            // 
            //this.parentTopPanel.Options.AllowDockFill = false;
            //this.parentTopPanel.Options.AllowDockLeft = false;
            //this.parentTopPanel.Options.AllowDockRight = false;
            //this.parentTopPanel.Options.AllowFloating = false;
            //this.parentTopPanel.Options.FloatOnDblClick = false;
            //this.parentTopPanel.Options.ShowCloseButton = false;
            //this.parentTopPanel.Options.ShowMaximizeButton = false;
            //this.parentTopPanel.Text = "Email Alert Items";
            // 
            // emailAlertItemBindingSource
            // 
            this.emailAlertItemBindingSource.DataSource = typeof(DataTier.EmailAlertItem);
            // 
            // emailAlertItemGridControl
            // 
            this.emailAlertItemGridControl.CausesValidation = false;
            this.emailAlertItemGridControl.DataSource = this.emailAlertItemBindingSource;
            this.emailAlertItemGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailAlertItemGridControl.Location = new System.Drawing.Point(0, 78);
            this.emailAlertItemGridControl.MainView = this.gridView1;
            this.emailAlertItemGridControl.Name = "emailAlertItemGridControl";
            this.emailAlertItemGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1});
            this.emailAlertItemGridControl.Size = new System.Drawing.Size(932, 358);
            this.emailAlertItemGridControl.TabIndex = 1;
            this.emailAlertItemGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmailAlertItemID,
            this.colEmailArertItemName,
            this.colAlertCycle,
            this.colIsEnabled,
            this.colStdOrder});
            this.gridView1.GridControl = this.emailAlertItemGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colEmailAlertItemID
            // 
            this.colEmailAlertItemID.FieldName = "EmailAlertItemID";
            this.colEmailAlertItemID.Name = "colEmailAlertItemID";
            // 
            // colEmailArertItemName
            // 
            this.colEmailArertItemName.FieldName = "EmailArertItemName";
            this.colEmailArertItemName.Name = "colEmailArertItemName";
            this.colEmailArertItemName.Visible = true;
            this.colEmailArertItemName.VisibleIndex = 2;
            this.colEmailArertItemName.Width = 489;
            // 
            // colAlertCycle
            // 
            this.colAlertCycle.Caption = "Recuring Cycle (Day)";
            this.colAlertCycle.FieldName = "AlertCycle";
            this.colAlertCycle.Name = "colAlertCycle";
            this.colAlertCycle.Visible = true;
            this.colAlertCycle.VisibleIndex = 3;
            this.colAlertCycle.Width = 131;
            // 
            // colIsEnabled
            // 
            this.colIsEnabled.Caption = "Enable";
            this.colIsEnabled.FieldName = "IsEnabled";
            this.colIsEnabled.Name = "colIsEnabled";
            this.colIsEnabled.Visible = true;
            this.colIsEnabled.VisibleIndex = 1;
            // 
            // colStdOrder
            // 
            this.colStdOrder.Caption = "#";
            this.colStdOrder.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colStdOrder.FieldName = "StdOrder";
            this.colStdOrder.Name = "colStdOrder";
            this.colStdOrder.Visible = true;
            this.colStdOrder.VisibleIndex = 0;
            this.colStdOrder.Width = 29;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // xEmailAlertItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(932, 436);
            this.Controls.Add(this.emailAlertItemGridControl);
            this.Name = "xEmailAlertItems";
            this.Text = "Email Alert Items";
            this.Load += new System.EventHandler(this.xEmailAlertSettings_Load);
            //this.Controls.SetChildIndex(this.parentTopPanel, 0);
            this.Controls.SetChildIndex(this.emailAlertItemGridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.emailAlertItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailAlertItemGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource emailAlertItemBindingSource;
        private DevExpress.XtraGrid.GridControl emailAlertItemGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailAlertItemID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailArertItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colAlertCycle;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEnabled;
        private DevExpress.XtraGrid.Columns.GridColumn colStdOrder;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
    }
}
