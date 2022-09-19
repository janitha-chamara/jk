namespace MMS.Alert
{
    partial class xEmailConfig
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
            this.txtHost = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtFrom = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPortNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtenckey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHost
            // 
            this.txtHost.EditValue = "";
            this.txtHost.Location = new System.Drawing.Point(143, 89);
            this.txtHost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHost.Name = "txtHost";
            this.txtHost.Properties.MaxLength = 100;
            this.txtHost.Size = new System.Drawing.Size(310, 22);
            this.txtHost.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(61, 93);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 16);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Client Host ";
            // 
            // txtFrom
            // 
            this.txtFrom.EditValue = "";
            this.txtFrom.Location = new System.Drawing.Point(143, 59);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Properties.MaxLength = 100;
            this.txtFrom.Size = new System.Drawing.Size(310, 22);
            this.txtFrom.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(59, 62);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 16);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Email From ";
            // 
            // txtPortNo
            // 
            this.txtPortNo.EditValue = "";
            this.txtPortNo.Location = new System.Drawing.Point(143, 119);
            this.txtPortNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.Properties.MaxLength = 50;
            this.txtPortNo.Size = new System.Drawing.Size(117, 22);
            this.txtPortNo.TabIndex = 12;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(80, 128);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 16);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Port No ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(197, 256);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 28);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(371, 256);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 28);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtenckey
            // 
            this.txtenckey.Location = new System.Drawing.Point(143, 212);
            this.txtenckey.Name = "txtenckey";
            this.txtenckey.Size = new System.Drawing.Size(438, 23);
            this.txtenckey.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Enc Key";
            // 
            // txtconfirm
            // 
            this.txtconfirm.Location = new System.Drawing.Point(143, 181);
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.PasswordChar = '*';
            this.txtconfirm.Size = new System.Drawing.Size(298, 23);
            this.txtconfirm.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Confrim Password";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(143, 150);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(298, 23);
            this.txtpassword.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Password";
            // 
            // xEmailConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 312);
            this.Controls.Add(this.txtenckey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtconfirm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPortNo);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.labelControl2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "xEmailConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMTP Configuration";
            this.Load += new System.EventHandler(this.xEmailConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtHost;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtFrom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPortNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.TextBox txtenckey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtconfirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label4;
    }
}