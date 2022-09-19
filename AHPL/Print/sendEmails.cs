using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using DataTier;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;


namespace MMS.Print
{
    public partial class frmsendEmails : Form
    {
        List<string> fileList = new List<string>();
        AHPL_DBEntities context = new AHPL_DBEntities();
        int locationId;
        List<string> filename = new List<string>();
        int cust_id;
        int attempts=0;
        public frmsendEmails(List<string> files,int location_id,int cust_id)
        {
            InitializeComponent();
            fileList = files;
            this.locationId = location_id;
            this.cust_id = cust_id;
            getUserDetails();
            
            
        }
        
        private void getUserDetails()
        {
            int userId = MMS.CustomClasses.cCommon_Functions.LoggedUserID;
            var current_user = (from usr in context.Permission_Users
                                where usr.UserID == userId
                                select new { usr.Email1 }
                          );
            
            //accountents' email
            string accountent_mails = null;
            string footer_text = null;
            if (locationId == 1) //crescat
            {
                
                var accountent_mail = (from mail in context.view_userRoleEmail
                                       where mail.LocationID == locationId && mail.UserGroupID == 2 && mail.Discontinued == false
                                       select new { mail.Email1 }
                ).ToList();
                foreach(var mail in accountent_mail)
                {
                    accountent_mails = accountent_mails + ';' + mail.Email1;
                    
                }
                footer_text = " Dear Customer,Please find attached invoices pertaining to the shop.This is a system generated e-mail and does not require any authorized signature."+
                               "If you find discrepancies of amounts or any clarification on this regard, please contact Niroshan Croos on 0717 880718 / Niroshan.jkp@keells.com";
            }
            else if (locationId == 2)//Moratuwa
            {
               
               var accountent_mail = (from mail in context.view_userRoleEmail
                                      where mail.LocationID == locationId && (mail.UserGroupID == 3 || mail.UserGroupID == 9) && mail.Discontinued == false
                                       select new { mail.Email1 }
                ).ToList();
               foreach (var mail in accountent_mail)
               {
                   accountent_mails = accountent_mails + ';' + mail.Email1;
               }
               footer_text = "Dear Customer,Please find attached invoices pertaining to the shop. This is a system generated e-mail and does not require any authorized signature."+
                              "If you find discrepancies of amounts or any clarification on this regard, please contact Sukith Weligamage on 0704340134 / sukith.jkp@keells.com";
            }
            else if (locationId == 3)//ja-ela
            {
               
                var accountent_mail = (from mail in context.view_userRoleEmail
                                       where mail.LocationID == locationId && mail.Discontinued == false && 
                                       (mail.UserGroupID == 5 || mail.UserGroupID == 9)
                                       select new { mail.Email1 }
                );
                foreach (var mail in accountent_mail)
                {
                    accountent_mails = accountent_mails + ';' + mail.Email1;
                }

                 footer_text = "Dear Customer,Please find attached invoices pertaining to the shop.This is a system generated e-mail and does not require any authorized signature."+
                                "If you find discrepancies of amounts or any clarification on this regard, please contact Manahari Perera on 0710556840 / manaharip.jkp@keells.com";
            }
            string spaces = Environment.NewLine;;
            for (int i = 0; i < 10; i++)
            {
                
                txtBodyMessage.Text = ""+ spaces +"";
            }
            txtBodyMessage.Text = footer_text;
            //client emails
            string client_name =null;
            if (cust_id > 0)
            {
                var client_mail = (from client in context.Global_Customers where client.CustomerID == cust_id 
                                   select new { client.EmailAddress,client.CustomerName }
                );
                client_name = client_mail.First().CustomerName;
                txtTo.Text = client_mail.First().EmailAddress;
            }
            string cc_string = current_user.First().Email1  + accountent_mails;
            txtcopyto.Text = cc_string.TrimEnd(';');
            for (int i = 0; i < fileList.Count;i++ )
            {
                string file_name = fileList[i];
                string[] splittedString = file_name.Split('\\');
                filename.Add(splittedString[2]);  
                
            }
            //email subject
            var loc_name = (from location in context.Locations where location.LocationID == locationId select new { location.LocationName});
            txtsubject.Text = loc_name.First().LocationName + "-" + client_name;
            showAttachments();

        }
        protected void removeAttachment(object sender, EventArgs e)
        {
            Button btnAdd = (sender as Button);
            int index = filename.IndexOf(btnAdd.Name);
            filename.RemoveAt(index);
            foreach (Control item in atachmentLayout.Controls.OfType<Control>().ToList())
            {
                if (item.Name == btnAdd.Name || item.Tag == btnAdd.Name)
                {
                    item.GetType();
                    atachmentLayout.Controls.Remove(item);  
                }
            }

           
        }
        private void showAttachments()
        {

            for (int i = 0; i < filename.Count; i++)
            {
                var cell_panel = new Panel();
                cell_panel.Tag = filename[i].ToString();
                cell_panel.BackColor = Color.LightGray;
                cell_panel.Size = new System.Drawing.Size(200,25);
                
                var btnAdd = new Button();
                var linkLabel = new LinkLabel { Text = filename[i].ToString(), Tag = filename[i].ToString() };
                
                btnAdd.Text = "X";
                btnAdd.Name = filename[i].ToString();
                btnAdd.BringToFront();
                linkLabel.Location = new Point(19, 5);
                btnAdd.Size = new System.Drawing.Size(18, 20);
                cell_panel.Controls.Add(btnAdd);
                cell_panel.Controls.Add(linkLabel);

                atachmentLayout.Controls.Add(cell_panel);
                
                linkLabel.Click += openFile;
                btnAdd.Click += new EventHandler(removeAttachment);


            }
           
           
        }
        private void openFile(object sender, EventArgs e)
        {
            var linkLabel = (LinkLabel)sender;
            string filename = linkLabel.Text.ToString();
            System.Diagnostics.Process.Start("C:\\MMS_files\\" + filename);
        }
        private void btnsend_Click(object sender, EventArgs e)
        {
            //validate email
            if (!string.IsNullOrEmpty(txtTo.Text) && !string.IsNullOrEmpty(txtsubject.Text))
            {
                if (filename.Count > 0)
                {
                    sendMails();
                }
                else
                {
                    MessageBox.Show("Please Attache Invoice(s)");
                }  
            }
            else {
                MessageBox.Show("Sender email / Subject Required..");
            }
    
        }
        private void sendMails()
        {
            try
            {
                bool sending = false;
                string[] emails = null;
                textBox1.Text = "";
                string mailstr = null; ;

                if (splashScreenManager1.IsSplashFormVisible == false)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Invoice(s)Sending.. ");
                }
                if (!string.IsNullOrEmpty(txtTo.Text))
                {
                    mailstr = txtTo.Text.Trim();
                    emails = mailstr.Split(new []{";"},StringSplitOptions.RemoveEmptyEntries);
                }
                
                
                foreach(var email in emails){
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(email);
                        sending = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Invalid email adress format -" + email);
                        textBox1.Text = "Invalid email adress format -" + email;
                        if (splashScreenManager1.IsSplashFormVisible == true)
                        {

                            splashScreenManager1.CloseWaitForm();
                        }
                        return;
                    }
                }
                if(sending)
                {


                    MailAddress from = new MailAddress("jkpmalls@jkintranet.com", "JKP MALL MANAGEMENT SYSTEM");
                        MailMessage mail = new MailMessage();
                        foreach (var email_to in emails)
                        {
                            if (!string.IsNullOrEmpty(email_to))
                            {
                                mail.To.Add(new MailAddress(email_to));
                            }
                            
                        }
                        mail.From = from;
                        if(!string.IsNullOrEmpty(txtcopyto.Text)){
                           
                            string[] copyTo = txtcopyto.Text.Split(';');
                            foreach(var copy in copyTo)
                            {
                                if (!string.IsNullOrEmpty(copy))
                                {
                                    mail.CC.Add(copy);
                                }
                                
                            }
                            
                        }
                        
                        using (SmtpClient client = new SmtpClient())
                        {

                            client.Host = "smtp.office365.com";
                            client.UseDefaultCredentials = false;
                            client.Port = 587;
                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            client.Credentials = new System.Net.NetworkCredential("jkpmalls@jkintranet.com", "Zmpa@34681");
                            client.EnableSsl = true;

                            
                            //client.Host = "smtp.gmail.com";
                            //client.Port = 587;
                            //client.UseDefaultCredentials = false;
                            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            //client.Credentials = new System.Net.NetworkCredential("devapptry@gmail.com", "devApp@try2020");
                            //client.EnableSsl = true;

                           

                            client.TargetName = "STARTTLS/smtp.office365.com";
                            mail.Subject = txtsubject.Text;
                            mail.Body = txtBodyMessage.Text;

                            //add attachments
                            if (filename.Count > 0)
                            {
                                foreach (var file in filename)
                                {
                                    System.Net.Mail.Attachment attachment;
                                    attachment = new System.Net.Mail.Attachment("C:\\MMS_files\\" + file);
                                    mail.Attachments.Add(attachment);
                                }

                            }

                            client.Send(mail);
                            //client.Dispose();
                        }
                        
                if (splashScreenManager1.IsSplashFormVisible == true)
                {
                    
                    splashScreenManager1.CloseWaitForm();
                    
                }

                MessageBox.Show("Invoice(s) Sent..");
                //client.Dispose();
                 
                this.Close();
                }
                
                
            }
            catch (Exception ex)
            {
                attempts++;
                if (attempts > 3)
                {
                    textBox1.Text += ex.ToString();
                    if (splashScreenManager1.IsSplashFormVisible == true)
                    {

                        splashScreenManager1.CloseWaitForm();

                    }


                }
                else
                {
                    sendMails();
                    
                }
                
            }
        }
        private void clearForm()
        {
            txtBodyMessage.Text = "";
            txtsubject.Text = "";
            txtTo.Text = "";
            fileList.Clear();
           
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnattachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.InitialDirectory = @"C:\MMS_files\";
            openFileDialog1.CheckFileExists = true;
            foreach (String file in openFileDialog1.FileNames)
            {
                string[] file_data = file.Split('\\');
                filename.Add(file_data[file_data.Length-1]);
            }
            atachmentLayout.Controls.Clear();
            showAttachments();
        }

        private void frmsendEmails_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool isDelete = CustomClasses.cCommon_Functions.removeUsedFiles();
        }
     
        


    }
}
