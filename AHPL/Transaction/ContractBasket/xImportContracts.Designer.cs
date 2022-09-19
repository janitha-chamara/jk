namespace MMS
{
    partial class xImportContracts
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpEditContractClauseID = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractClosureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractClauseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.colIsTerminated = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditContractClauseID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Contract Name :";
            // 
            // searchLookUpEditContractClauseID
            // 
            this.searchLookUpEditContractClauseID.Location = new System.Drawing.Point(99, 41);
            this.searchLookUpEditContractClauseID.Name = "searchLookUpEditContractClauseID";
            this.searchLookUpEditContractClauseID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.searchLookUpEditContractClauseID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditContractClauseID.Properties.DisplayMember = "ContractClosureName";
            this.searchLookUpEditContractClauseID.Properties.NullText = "";
            this.searchLookUpEditContractClauseID.Properties.ValueMember = "ContractClosureID";
            this.searchLookUpEditContractClauseID.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpEditContractClauseID.Size = new System.Drawing.Size(320, 20);
            this.searchLookUpEditContractClauseID.TabIndex = 1;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractClosureName,
            this.colShopName,
            this.colShopNo,
            this.colLocation,
            this.colCompany,
            this.colContractClauseID,
            this.colIsTerminated});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colIsTerminated;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
            this.searchLookUpEdit1View.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.searchLookUpEdit1View.OptionsFind.FindDelay = 100;
            this.searchLookUpEdit1View.OptionsFind.ShowClearButton = false;
            this.searchLookUpEdit1View.OptionsFind.ShowCloseButton = false;
            this.searchLookUpEdit1View.OptionsFind.ShowFindButton = false;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ColumnAutoWidth = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colContractClosureName
            // 
            this.colContractClosureName.Caption = "Contract Name";
            this.colContractClosureName.FieldName = "ContractClosureName";
            this.colContractClosureName.Name = "colContractClosureName";
            this.colContractClosureName.Visible = true;
            this.colContractClosureName.VisibleIndex = 2;
            this.colContractClosureName.Width = 91;
            // 
            // colShopName
            // 
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 1;
            // 
            // colShopNo
            // 
            this.colShopNo.FieldName = "ShopNo";
            this.colShopNo.Name = "colShopNo";
            this.colShopNo.Visible = true;
            this.colShopNo.VisibleIndex = 0;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "Location";
            this.colLocation.FieldName = "LocationCode";
            this.colLocation.Name = "colLocation";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 3;
            // 
            // colCompany
            // 
            this.colCompany.Caption = "Company";
            this.colCompany.FieldName = "CompanyCode";
            this.colCompany.Name = "colCompany";
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 4;
            // 
            // colContractClauseID
            // 
            this.colContractClauseID.Caption = "ContractClosureID";
            this.colContractClauseID.FieldName = "ContractClosureID";
            this.colContractClauseID.Name = "colContractClauseID";
            this.colContractClauseID.Width = 98;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(344, 94);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 29);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(263, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // colIsTerminated
            // 
            this.colIsTerminated.Caption = "Terminated";
            this.colIsTerminated.FieldName = "IsTerminated";
            this.colIsTerminated.Name = "colIsTerminated";
            // 
            // xImportContracts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 138);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.searchLookUpEditContractClauseID);
            this.Controls.Add(this.labelControl1);
            this.Name = "xImportContracts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Contracts";
            this.Load += new System.EventHandler(this.xImportContracts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditContractClauseID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditContractClauseID;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureName;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClauseID;
        private DevExpress.XtraGrid.Columns.GridColumn colIsTerminated;
    }
}