namespace MMS.Transaction.ContractBasket
{
    partial class xPendingContractConfirmation
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
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.cPendingContConfirmationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractClauseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnActivate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cPendingContConfirmationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(29, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Contract :";
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.EditValue = "";
            this.searchLookUpEdit1.Location = new System.Drawing.Point(84, 45);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.DataSource = this.cPendingContConfirmationBindingSource;
            this.searchLookUpEdit1.Properties.DisplayMember = "ContractName";
            this.searchLookUpEdit1.Properties.NullText = "";
            this.searchLookUpEdit1.Properties.ValueMember = "ContractClauseID";
            this.searchLookUpEdit1.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(325, 20);
            this.searchLookUpEdit1.TabIndex = 5;
            // 
            // cPendingContConfirmationBindingSource
            // 
            this.cPendingContConfirmationBindingSource.DataSource = typeof(MMS.Transaction.ContractBasket.cPendingContConfirmation);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractClauseID,
            this.colContractName,
            this.colShopName,
            this.colShopNo,
            this.colCompany,
            this.colLocation,
            this.colLevel,
            this.colCustomer,
            this.colStartDate,
            this.colExpiryDate,
            this.colIsActive,
            this.colRefNo});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsBehavior.ReadOnly = true;
            this.searchLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.searchLookUpEdit1View.OptionsFind.FindDelay = 100;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colContractClauseID
            // 
            this.colContractClauseID.FieldName = "ContractClauseID";
            this.colContractClauseID.Name = "colContractClauseID";
            // 
            // colContractName
            // 
            this.colContractName.FieldName = "ContractName";
            this.colContractName.Name = "colContractName";
            this.colContractName.Visible = true;
            this.colContractName.VisibleIndex = 0;
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
            this.colShopNo.VisibleIndex = 2;
            // 
            // colCompany
            // 
            this.colCompany.FieldName = "Company";
            this.colCompany.Name = "colCompany";
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 3;
            // 
            // colLocation
            // 
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 4;
            // 
            // colLevel
            // 
            this.colLevel.FieldName = "Level";
            this.colLevel.Name = "colLevel";
            this.colLevel.Visible = true;
            this.colLevel.VisibleIndex = 5;
            // 
            // colCustomer
            // 
            this.colCustomer.FieldName = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.Visible = true;
            this.colCustomer.VisibleIndex = 6;
            // 
            // colStartDate
            // 
            this.colStartDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 7;
            // 
            // colExpiryDate
            // 
            this.colExpiryDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colExpiryDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colExpiryDate.FieldName = "ExpiryDate";
            this.colExpiryDate.Name = "colExpiryDate";
            this.colExpiryDate.Visible = true;
            this.colExpiryDate.VisibleIndex = 8;
            // 
            // colIsActive
            // 
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            // 
            // colRefNo
            // 
            this.colRefNo.FieldName = "RefNo";
            this.colRefNo.Name = "colRefNo";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::MMS.Properties.Resources.folder_into1;
            this.btnClose.Location = new System.Drawing.Point(306, 123);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.Image = global::MMS.Properties.Resources.check21;
            this.btnActivate.Location = new System.Drawing.Point(306, 88);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(101, 29);
            this.btnActivate.TabIndex = 6;
            this.btnActivate.Text = "Activate";
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // xPendingContractConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 174);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.searchLookUpEdit1);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(464, 213);
            this.MinimumSize = new System.Drawing.Size(456, 201);
            this.Name = "xPendingContractConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pending Contract Confirmation";
            this.Load += new System.EventHandler(this.xPendingContractConfirmation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cPendingContConfirmationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SimpleButton btnActivate;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.BindingSource cPendingContConfirmationBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClauseID;
        private DevExpress.XtraGrid.Columns.GridColumn colContractName;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colRefNo;

    }
}