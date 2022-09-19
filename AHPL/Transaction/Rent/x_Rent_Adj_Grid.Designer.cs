namespace MMS.Transaction.Rent
{
    partial class x_Rent_Adj_Grid
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
            this.splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.chkselect = new DevExpress.XtraEditors.CheckButton();
            this.txtInvoiceFooter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.gvallcreditnotes = new DevExpress.XtraGrid.GridControl();
            this.cInvoicesBindigSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colselect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Adjustment_amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.service_charge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.adjDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblToDate = new DevExpress.XtraEditors.LabelControl();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lookLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.taxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taxRateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invoice_DetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cachedrptInvoice1 = new MMS.Reports.CachedrptInvoice();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceFooter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvallcreditnotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cInvoicesBindigSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adjDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxRateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoice_DetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chkselect
            // 
            this.chkselect.Location = new System.Drawing.Point(14, 132);
            this.chkselect.Name = "chkselect";
            this.chkselect.Size = new System.Drawing.Size(75, 23);
            this.chkselect.TabIndex = 22;
            this.chkselect.Text = "Select All";
            this.chkselect.CheckedChanged += new System.EventHandler(this.chkselect_CheckedChanged);
            // 
            // txtInvoiceFooter
            // 
            this.txtInvoiceFooter.Location = new System.Drawing.Point(93, 550);
            this.txtInvoiceFooter.Name = "txtInvoiceFooter";
            this.txtInvoiceFooter.Size = new System.Drawing.Size(667, 20);
            this.txtInvoiceFooter.TabIndex = 21;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 553);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 13);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "Narration :";
            // 
            // gvallcreditnotes
            // 
            this.gvallcreditnotes.DataSource = this.cInvoicesBindigSource;
            this.gvallcreditnotes.Location = new System.Drawing.Point(9, 157);
            this.gvallcreditnotes.MainView = this.gridView1;
            this.gvallcreditnotes.Name = "gvallcreditnotes";
            this.gvallcreditnotes.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gvallcreditnotes.Size = new System.Drawing.Size(936, 377);
            this.gvallcreditnotes.TabIndex = 19;
            this.gvallcreditnotes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colselect,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn2,
            this.Adjustment_amount,
            this.service_charge,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gridView1.GridControl = this.gvallcreditnotes;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // colselect
            // 
            this.colselect.FieldName = "Confirm";
            this.colselect.Name = "colselect";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Customer";
            this.gridColumn4.FieldName = "CustomerName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Shop Name";
            this.gridColumn3.FieldName = "ShopName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Shop No";
            this.gridColumn2.FieldName = "ShopNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // Adjustment_amount
            // 
            this.Adjustment_amount.Caption = "Rent";
            this.Adjustment_amount.DisplayFormat.FormatString = "0000.0000";
            this.Adjustment_amount.FieldName = "TotalRentPerMonth";
            this.Adjustment_amount.Name = "Adjustment_amount";
            this.Adjustment_amount.Visible = true;
            this.Adjustment_amount.VisibleIndex = 3;
            // 
            // service_charge
            // 
            this.service_charge.Caption = "Service Charge";
            this.service_charge.DisplayFormat.FormatString = "0000.0000";
            this.service_charge.FieldName = "SCPerMonth";
            this.service_charge.Name = "service_charge";
            this.service_charge.Visible = true;
            this.service_charge.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "NBT";
            this.gridColumn8.FieldName = "MandatoryTaxAmount";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "VAT";
            this.gridColumn9.FieldName = "OtherTax";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Total";
            this.gridColumn10.FieldName = "TotalCreditValue";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.panelControl1.Controls.Add(this.btnclose);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Location = new System.Drawing.Point(9, 2);
            this.panelControl1.LookAndFeel.SkinName = "VS2010";
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(936, 124);
            this.panelControl1.TabIndex = 18;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(742, 63);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(176, 33);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Image = global::MMS.Properties.Resources.disk_blue1;
            this.btnSave.Appearance.Options.UseImage = true;
            this.btnSave.Location = new System.Drawing.Point(742, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(176, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.adjDate);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.dateEditTo);
            this.groupControl2.Controls.Add(this.dateEditFrom);
            this.groupControl2.Controls.Add(this.lblToDate);
            this.groupControl2.Controls.Add(this.lblFromDate);
            this.groupControl2.Location = new System.Drawing.Point(294, 6);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(239, 106);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Date";
            // 
            // adjDate
            // 
            this.adjDate.EditValue = null;
            this.adjDate.Location = new System.Drawing.Point(104, 20);
            this.adjDate.Name = "adjDate";
            this.adjDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.adjDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.adjDate.Size = new System.Drawing.Size(128, 20);
            this.adjDate.TabIndex = 13;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 24);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(87, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Adjustment date :";
            // 
            // dateEditTo
            // 
            this.dateEditTo.EditValue = null;
            this.dateEditTo.Location = new System.Drawing.Point(103, 77);
            this.dateEditTo.Name = "dateEditTo";
            this.dateEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Size = new System.Drawing.Size(128, 20);
            this.dateEditTo.TabIndex = 11;
            // 
            // dateEditFrom
            // 
            this.dateEditFrom.EditValue = null;
            this.dateEditFrom.Location = new System.Drawing.Point(103, 49);
            this.dateEditFrom.Name = "dateEditFrom";
            this.dateEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Size = new System.Drawing.Size(128, 20);
            this.dateEditFrom.TabIndex = 10;
            // 
            // lblToDate
            // 
            this.lblToDate.Location = new System.Drawing.Point(12, 80);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(45, 13);
            this.lblToDate.TabIndex = 9;
            this.lblToDate.Text = "To Date :";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(12, 52);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(57, 13);
            this.lblFromDate.TabIndex = 8;
            this.lblFromDate.Text = "From Date :";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lookLocation);
            this.groupControl1.Controls.Add(this.lookCompany);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(8, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(269, 106);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Company / Location";
            // 
            // lookLocation
            // 
            this.lookLocation.Location = new System.Drawing.Point(95, 56);
            this.lookLocation.Name = "lookLocation";
            this.lookLocation.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLocation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Location ID", 77, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "Location Code", 78, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationName", "Location Name", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookLocation.Properties.DataSource = this.locationBindingSource;
            this.lookLocation.Properties.DisplayMember = "LocationCode";
            this.lookLocation.Properties.NullText = "";
            this.lookLocation.Properties.ValueMember = "LocationID";
            this.lookLocation.Size = new System.Drawing.Size(149, 20);
            this.lookLocation.TabIndex = 8;
            this.lookLocation.EditValueChanged += new System.EventHandler(this.lookLocation_EditValueChanged);
            // 
            // locationBindingSource
            // 
            this.locationBindingSource.DataSource = typeof(DataTier.Location);
            // 
            // lookCompany
            // 
            this.lookCompany.Location = new System.Drawing.Point(95, 30);
            this.lookCompany.Name = "lookCompany";
            this.lookCompany.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "Company ID", 82, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "Company Code", 83, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Company Name", 85, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookCompany.Properties.DataSource = this.companyBindingSource;
            this.lookCompany.Properties.DisplayMember = "CompanyCode";
            this.lookCompany.Properties.NullText = "";
            this.lookCompany.Properties.ValueMember = "CompanyID";
            this.lookCompany.Size = new System.Drawing.Size(149, 20);
            this.lookCompany.TabIndex = 7;
            this.lookCompany.EditValueChanged += new System.EventHandler(this.lookCompany_EditValueChanged);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(DataTier.Company);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Location :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Company :";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // taxBindingSource
            // 
            this.taxBindingSource.DataSource = typeof(DataTier.Tax);
            // 
            // taxRateBindingSource
            // 
            this.taxRateBindingSource.DataSource = typeof(DataTier.TaxRate);
            // 
            // invoice_DetailsBindingSource
            // 
            this.invoice_DetailsBindingSource.DataSource = typeof(System.Data.Objects.DataClasses.EntityCollection<DataTier.Invoice_Details>);
            // 
            // x_Rent_Adj_Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 582);
            this.Controls.Add(this.chkselect);
            this.Controls.Add(this.txtInvoiceFooter);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.gvallcreditnotes);
            this.Controls.Add(this.panelControl1);
            this.Name = "x_Rent_Adj_Grid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rent Adjustment Grid";
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceFooter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvallcreditnotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cInvoicesBindigSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adjDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxRateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoice_DetailsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckButton chkselect;
        private DevExpress.XtraEditors.TextEdit txtInvoiceFooter;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.GridControl gvallcreditnotes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colselect;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn Adjustment_amount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.DateEdit adjDate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.DateEdit dateEditFrom;
        private DevExpress.XtraEditors.LabelControl lblToDate;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit lookLocation;
        private DevExpress.XtraEditors.LookUpEdit lookCompany;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn service_charge;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private System.Windows.Forms.BindingSource cInvoicesBindigSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private System.Windows.Forms.BindingSource taxBindingSource;
        private System.Windows.Forms.BindingSource taxRateBindingSource;
        private System.Windows.Forms.BindingSource invoice_DetailsBindingSource;
        private Reports.CachedrptInvoice cachedrptInvoice1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
    }
}