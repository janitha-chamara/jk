namespace MMS.Print
{
    partial class xInvoiceBulk_Draft
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
            this.lueShopName = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractClosureID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblShopName = new DevExpress.XtraEditors.LabelControl();
            this.luCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCompany = new DevExpress.XtraEditors.LabelControl();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.luLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.luCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.luShop = new DevExpress.XtraEditors.LookUpEdit();
            this.lblShopNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lueShopName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luShop.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lueShopName
            // 
            this.lueShopName.EnterMoveNextControl = true;
            this.lueShopName.Location = new System.Drawing.Point(153, 22);
            this.lueShopName.Name = "lueShopName";
            this.lueShopName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueShopName.Properties.NullText = "";
            this.lueShopName.Properties.View = this.searchLookUpEdit1View;
            this.lueShopName.Size = new System.Drawing.Size(167, 20);
            this.lueShopName.TabIndex = 47;
            this.lueShopName.EditValueChanged += new System.EventHandler(this.lueShopName_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractClosureID,
            this.colShopName,
            this.colCompanyCode,
            this.colLocationCode,
            this.colCustomerName,
            this.colShopNo1});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsBehavior.AutoExpandAllGroups = true;
            this.searchLookUpEdit1View.OptionsBehavior.Editable = false;
            this.searchLookUpEdit1View.OptionsBehavior.ReadOnly = true;
            this.searchLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.searchLookUpEdit1View.OptionsFind.FindDelay = 100;
            this.searchLookUpEdit1View.OptionsFind.SearchInPreview = true;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.AllowCellMerge = true;
            this.searchLookUpEdit1View.OptionsView.ColumnAutoWidth = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colContractClosureID
            // 
            this.colContractClosureID.Caption = "Contract Clause ID";
            this.colContractClosureID.Name = "colContractClosureID";
            // 
            // colShopName
            // 
            this.colShopName.Caption = "Shop Name";
            this.colShopName.FieldName = "ShopName";
            this.colShopName.Name = "colShopName";
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 1;
            this.colShopName.Width = 133;
            // 
            // colCompanyCode
            // 
            this.colCompanyCode.Caption = "Company";
            this.colCompanyCode.FieldName = "CompanyCode";
            this.colCompanyCode.Name = "colCompanyCode";
            this.colCompanyCode.Visible = true;
            this.colCompanyCode.VisibleIndex = 2;
            this.colCompanyCode.Width = 90;
            // 
            // colLocationCode
            // 
            this.colLocationCode.Caption = "Location";
            this.colLocationCode.FieldName = "LocationCode";
            this.colLocationCode.Name = "colLocationCode";
            this.colLocationCode.Visible = true;
            this.colLocationCode.VisibleIndex = 3;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "Customer Name";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 4;
            this.colCustomerName.Width = 195;
            // 
            // colShopNo1
            // 
            this.colShopNo1.Caption = "Shop No";
            this.colShopNo1.FieldName = "ShopNo";
            this.colShopNo1.Name = "colShopNo1";
            this.colShopNo1.Visible = true;
            this.colShopNo1.VisibleIndex = 0;
            this.colShopNo1.Width = 88;
            // 
            // lblShopName
            // 
            this.lblShopName.Location = new System.Drawing.Point(84, 25);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(61, 13);
            this.lblShopName.TabIndex = 48;
            this.lblShopName.Text = "Shop Name :";
            // 
            // luCompany
            // 
            this.luCompany.Enabled = false;
            this.luCompany.EnterMoveNextControl = true;
            this.luCompany.Location = new System.Drawing.Point(152, 60);
            this.luCompany.Name = "luCompany";
            this.luCompany.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.luCompany.Properties.Appearance.Options.UseBackColor = true;
            this.luCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "CompanyCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "CompanyName")});
            this.luCompany.Properties.NullText = "";
            this.luCompany.Properties.ReadOnly = true;
            this.luCompany.Size = new System.Drawing.Size(168, 20);
            this.luCompany.TabIndex = 49;
            this.luCompany.EditValueChanged += new System.EventHandler(this.luCompany_EditValueChanged);
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(93, 63);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(52, 13);
            this.lblCompany.TabIndex = 50;
            this.lblCompany.Text = "Company :";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(371, 63);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(47, 13);
            this.lblLocation.TabIndex = 52;
            this.lblLocation.Text = "Location :";
            // 
            // luLocation
            // 
            this.luLocation.Enabled = false;
            this.luLocation.EnterMoveNextControl = true;
            this.luLocation.Location = new System.Drawing.Point(426, 60);
            this.luLocation.Name = "luLocation";
            this.luLocation.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.luLocation.Properties.Appearance.Options.UseBackColor = true;
            this.luLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luLocation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "LocationCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationName", "LocationName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvoicePrefix", "InvoicePrefix")});
            this.luLocation.Properties.NullText = "";
            this.luLocation.Properties.ReadOnly = true;
            this.luLocation.Size = new System.Drawing.Size(168, 20);
            this.luLocation.TabIndex = 51;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(92, 100);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(53, 13);
            this.lblCustomer.TabIndex = 54;
            this.lblCustomer.Text = "Customer :";
            // 
            // luCustomer
            // 
            this.luCustomer.Enabled = false;
            this.luCustomer.EnterMoveNextControl = true;
            this.luCustomer.Location = new System.Drawing.Point(152, 96);
            this.luCustomer.Name = "luCustomer";
            this.luCustomer.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.luCustomer.Properties.Appearance.Options.UseBackColor = true;
            this.luCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luCustomer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Customer Name")});
            this.luCustomer.Properties.DisplayMember = "CustomerName";
            this.luCustomer.Properties.NullText = "";
            this.luCustomer.Properties.ReadOnly = true;
            this.luCustomer.Properties.ValueMember = "CustomerID";
            this.luCustomer.Size = new System.Drawing.Size(168, 20);
            this.luCustomer.TabIndex = 53;
            this.luCustomer.EditValueChanged += new System.EventHandler(this.luCustomer_EditValueChanged);
            // 
            // luShop
            // 
            this.luShop.EnterMoveNextControl = true;
            this.luShop.Location = new System.Drawing.Point(426, 97);
            this.luShop.Name = "luShop";
            this.luShop.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.luShop.Properties.Appearance.Options.UseBackColor = true;
            this.luShop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luShop.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShopID", "ShopID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShopNo", "Shop No")});
            this.luShop.Properties.NullText = "";
            this.luShop.Properties.ReadOnly = true;
            this.luShop.Size = new System.Drawing.Size(168, 20);
            this.luShop.TabIndex = 60;
            // 
            // lblShopNo
            // 
            this.lblShopNo.Location = new System.Drawing.Point(375, 101);
            this.lblShopNo.Name = "lblShopNo";
            this.lblShopNo.Size = new System.Drawing.Size(44, 13);
            this.lblShopNo.TabIndex = 61;
            this.lblShopNo.Text = "Shop No:";
            // 
            // xInvoiceBulk_Draft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 388);
            this.Controls.Add(this.luShop);
            this.Controls.Add(this.lblShopNo);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.luCustomer);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.luLocation);
            this.Controls.Add(this.luCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lueShopName);
            this.Controls.Add(this.lblShopName);
            this.Name = "xInvoiceBulk_Draft";
            this.Text = "Rent Invoice Bulk- Draft Email";
            ((System.ComponentModel.ISupportInitialize)(this.lueShopName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luShop.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit lueShopName;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colContractClosureID;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colShopNo1;
        private DevExpress.XtraEditors.LabelControl lblShopName;
        private DevExpress.XtraEditors.LookUpEdit luCompany;
        private DevExpress.XtraEditors.LabelControl lblCompany;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private DevExpress.XtraEditors.LookUpEdit luLocation;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
        private DevExpress.XtraEditors.LookUpEdit luCustomer;
        private DevExpress.XtraEditors.LookUpEdit luShop;
        private DevExpress.XtraEditors.LabelControl lblShopNo;
    }
}