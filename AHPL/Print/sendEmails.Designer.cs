namespace MMS.Print
{
    partial class frmsendEmails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsendEmails));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsubject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBodyMessage = new System.Windows.Forms.TextBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MMS.WaitForm1), true, true);
            this.label7 = new System.Windows.Forms.Label();
            this.txtcopyto = new System.Windows.Forms.TextBox();
            this.btnattachment = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.atachmentLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "To";
            // 
            // txtTo
            // 
            this.txtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.ForeColor = System.Drawing.Color.DimGray;
            this.txtTo.Location = new System.Drawing.Point(142, 18);
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(1091, 52);
            this.txtTo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Subject";
            // 
            // txtsubject
            // 
            this.txtsubject.Location = new System.Drawing.Point(142, 174);
            this.txtsubject.Multiline = true;
            this.txtsubject.Name = "txtsubject";
            this.txtsubject.Size = new System.Drawing.Size(1091, 31);
            this.txtsubject.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Attachments";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 384);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Message";
            // 
            // txtBodyMessage
            // 
            this.txtBodyMessage.Location = new System.Drawing.Point(133, 384);
            this.txtBodyMessage.Multiline = true;
            this.txtBodyMessage.Name = "txtBodyMessage";
            this.txtBodyMessage.Size = new System.Drawing.Size(1091, 235);
            this.txtBodyMessage.TabIndex = 1;
            this.txtBodyMessage.Text = resources.GetString("txtBodyMessage.Text");
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(781, 641);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(216, 52);
            this.btnsend.TabIndex = 3;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(1017, 641);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(216, 52);
            this.btncancel.TabIndex = 3;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(150, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(856, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Seperate email addresses with semicolon Ex: client@mail.com;client2@mail.com";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 721);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1215, 103);
            this.textBox1.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 701);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Error Log";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "CC";
            // 
            // txtcopyto
            // 
            this.txtcopyto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcopyto.ForeColor = System.Drawing.Color.DimGray;
            this.txtcopyto.Location = new System.Drawing.Point(142, 79);
            this.txtcopyto.Multiline = true;
            this.txtcopyto.Name = "txtcopyto";
            this.txtcopyto.Size = new System.Drawing.Size(1091, 52);
            this.txtcopyto.TabIndex = 1;
            // 
            // btnattachment
            // 
            this.btnattachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnattachment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnattachment.Location = new System.Drawing.Point(1246, 218);
            this.btnattachment.Name = "btnattachment";
            this.btnattachment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnattachment.Size = new System.Drawing.Size(33, 85);
            this.btnattachment.TabIndex = 6;
            this.btnattachment.Text = "A";
            this.btnattachment.UseVisualStyleBackColor = true;
            this.btnattachment.Click += new System.EventHandler(this.btnattachment_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\MMS_files";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // atachmentLayout
            // 
            this.atachmentLayout.AutoScroll = true;
            this.atachmentLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.atachmentLayout.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.atachmentLayout.ColumnCount = 5;
            this.atachmentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.atachmentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.atachmentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.atachmentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.atachmentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 298F));
            this.atachmentLayout.Location = new System.Drawing.Point(142, 211);
            this.atachmentLayout.Name = "atachmentLayout";
            this.atachmentLayout.RowCount = 4;
            this.atachmentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.atachmentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.atachmentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.atachmentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.atachmentLayout.Size = new System.Drawing.Size(1098, 139);
            this.atachmentLayout.TabIndex = 7;
            // 
            // frmsendEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 834);
            this.Controls.Add(this.atachmentLayout);
            this.Controls.Add(this.btnattachment);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.txtsubject);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBodyMessage);
            this.Controls.Add(this.txtcopyto);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "frmsendEmails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmsendEmails_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBodyMessage;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcopyto;
        private System.Windows.Forms.Button btnattachment;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel atachmentLayout;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}