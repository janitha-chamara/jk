namespace MMS.UserPermission
{
    partial class xSmtpSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.txthost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtport = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtenckey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host";
            // 
            // txthost
            // 
            this.txthost.Location = new System.Drawing.Point(155, 45);
            this.txthost.Name = "txthost";
            this.txthost.Size = new System.Drawing.Size(298, 22);
            this.txthost.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port";
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(155, 73);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(85, 22);
            this.txtport.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "User";
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(155, 101);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(298, 22);
            this.txtuser.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(155, 129);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(298, 22);
            this.txtpassword.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Confrim Password";
            // 
            // txtconfirm
            // 
            this.txtconfirm.Location = new System.Drawing.Point(155, 157);
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.PasswordChar = '*';
            this.txtconfirm.Size = new System.Drawing.Size(298, 22);
            this.txtconfirm.TabIndex = 1;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(141, 237);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(145, 39);
            this.btnsave.TabIndex = 2;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(308, 237);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(145, 39);
            this.btncancel.TabIndex = 2;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Enc Key";
            // 
            // txtenckey
            // 
            this.txtenckey.Location = new System.Drawing.Point(155, 188);
            this.txtenckey.Name = "txtenckey";
            this.txtenckey.PasswordChar = '*';
            this.txtenckey.Size = new System.Drawing.Size(298, 22);
            this.txtenckey.TabIndex = 1;
            // 
            // xSmtpSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 312);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtenckey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtconfirm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txthost);
            this.Controls.Add(this.label1);
            this.Name = "xSmtpSettings";
            this.Text = "SMTP Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txthost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtconfirm;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtenckey;
    }
}