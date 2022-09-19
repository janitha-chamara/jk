namespace MMS.Transaction.Rent
{
    partial class xRentVariation
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditToDate = new DevExpress.XtraEditors.DateEdit();
            this.btnVariance = new DevExpress.XtraEditors.SimpleButton();
            this.textEditTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lookNewContract = new DevExpress.XtraEditors.LookUpEdit();
            this.lookContractOld = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookNewContract.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookContractOld.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(131, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Old Contract Rent Scheme:";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(139, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "New Contract Rent Scheme: ";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(415, 66);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "To Date:";
            this.labelControl3.Click += new System.EventHandler(this.labelControl3_Click);
            // 
            // dateEditToDate
            // 
            this.dateEditToDate.EditValue = null;
            this.dateEditToDate.EnterMoveNextControl = true;
            this.dateEditToDate.Location = new System.Drawing.Point(463, 63);
            this.dateEditToDate.Name = "dateEditToDate";
            this.dateEditToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEditToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditToDate.Size = new System.Drawing.Size(100, 20);
            this.dateEditToDate.TabIndex = 5;
            this.dateEditToDate.EditValueChanged += new System.EventHandler(this.dateEditToDate_EditValueChanged);
            // 
            // btnVariance
            // 
            this.btnVariance.Location = new System.Drawing.Point(464, 127);
            this.btnVariance.Name = "btnVariance";
            this.btnVariance.Size = new System.Drawing.Size(99, 38);
            this.btnVariance.TabIndex = 6;
            this.btnVariance.Text = "Get Variance";
            this.btnVariance.Click += new System.EventHandler(this.btnVariance_Click);
            // 
            // textEditTotal
            // 
            this.textEditTotal.Location = new System.Drawing.Point(169, 97);
            this.textEditTotal.Name = "textEditTotal";
            this.textEditTotal.Properties.DisplayFormat.FormatString = "n2";
            this.textEditTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditTotal.Properties.EditFormat.FormatString = "n2";
            this.textEditTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditTotal.Properties.Mask.EditMask = "n4";
            this.textEditTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditTotal.Properties.NullText = "0.00";
            this.textEditTotal.Properties.NullValuePrompt = "0.00";
            this.textEditTotal.Size = new System.Drawing.Size(100, 20);
            this.textEditTotal.TabIndex = 7;
            this.textEditTotal.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(118, 100);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(44, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Amount :";
            this.labelControl4.Click += new System.EventHandler(this.labelControl4_Click);
            // 
            // lookNewContract
            // 
            this.lookNewContract.Location = new System.Drawing.Point(169, 45);
            this.lookNewContract.Name = "lookNewContract";
            this.lookNewContract.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookNewContract.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookNewContract.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Contract_RentSchemeID", "Contract_RentSchemeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContractClosureID", "ContractClosureID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FromDateToDate", "FromDate-ToDate"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RentPerSqFeet", "RentPerSqFeet"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SCPerSqFeet", "SCPerSqFeet")});
            this.lookNewContract.Properties.NullText = "";
            this.lookNewContract.Size = new System.Drawing.Size(208, 20);
            this.lookNewContract.TabIndex = 10;
            // 
            // lookContractOld
            // 
            this.lookContractOld.Location = new System.Drawing.Point(169, 70);
            this.lookContractOld.Name = "lookContractOld";
            this.lookContractOld.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookContractOld.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Contract_RentSchemeID", "Contract_RentSchemeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContractClosureID", "ContractClosureID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FromDateToDate", "FromDateToDate"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RentPerSqFeet", "RentPerSqFeet"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SCPerSqFeet", "SCPerSqFeet")});
            this.lookContractOld.Properties.NullText = "";
            this.lookContractOld.Size = new System.Drawing.Size(207, 20);
            this.lookContractOld.TabIndex = 11;
            // 
            // xRentVariation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 208);
            this.Controls.Add(this.lookContractOld);
            this.Controls.Add(this.lookNewContract);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.textEditTotal);
            this.Controls.Add(this.btnVariance);
            this.Controls.Add(this.dateEditToDate);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "xRentVariation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rent Variation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.xRentVariation_FormClosing);
            this.Load += new System.EventHandler(this.xRentVariation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookNewContract.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookContractOld.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateEditToDate;
        private DevExpress.XtraEditors.SimpleButton btnVariance;
        private DevExpress.XtraEditors.TextEdit textEditTotal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lookNewContract;
        private DevExpress.XtraEditors.LookUpEdit lookContractOld;
    }
}