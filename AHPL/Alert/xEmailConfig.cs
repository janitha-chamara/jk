using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataTier;
using System.Linq;
using System.Linq.Expressions;

namespace MMS.Alert
{
    public partial class xEmailConfig : DevExpress.XtraEditors.XtraForm
    {
        public xEmailConfig()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xEmailConfig_Load(object sender, EventArgs e)
        {
            Load_data();

        }

        private void Load_data()
        {
            try
            {

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryEmailConfig = (from ec in context.EmailConfigurations
                                          select ec).FirstOrDefault();
                    if (qryEmailConfig != null)
                    {
                        this.txtFrom.EditValue = qryEmailConfig.FromEmail;
                        this.txtHost.EditValue = qryEmailConfig.ClientHost;
                        this.txtPortNo.EditValue = qryEmailConfig.PorNo;
                        this.txtpassword.Text =
                            MMS.CustomClasses.cCommon_Functions.Decrypt(qryEmailConfig.SmtpPassword, qryEmailConfig.EncKey);
                        this.txtenckey.Text = qryEmailConfig.EncKey;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if(!string.IsNullOrEmpty(txtpassword.Text))
                {
                    if (String.Equals(txtpassword.Text.Trim(), txtconfirm.Text.Trim()) && !string.IsNullOrEmpty(txtenckey.Text))
                    {
                        using (AHPL_DBEntities context = new AHPL_DBEntities())
                        {
                            var qryEmailConfig = (from em in context.EmailConfigurations
                                                  select em).ToList();
                            if (qryEmailConfig.Count == 0)
                            {
                                EmailConfiguration emailConfigObject = new EmailConfiguration();
                                emailConfigObject.FromEmail = this.txtFrom.EditValue.ToString();
                                emailConfigObject.ClientHost = this.txtHost.EditValue.ToString();
                                emailConfigObject.PorNo = this.txtPortNo.EditValue.ToString();
                                emailConfigObject.SmtpPassword = 
                                    MMS.CustomClasses.cCommon_Functions.Encrypt(txtpassword.Text.Trim(),txtenckey.Text.Trim());
                                emailConfigObject.EncKey = txtenckey.Text.Trim();
                                context.EmailConfigurations.AddObject(emailConfigObject);
                            }
                            else
                            {
                                EmailConfiguration emailConfigObjectEdit = (from em in context.EmailConfigurations
                                                                            select em).FirstOrDefault();
                                emailConfigObjectEdit.FromEmail = this.txtFrom.EditValue.ToString();
                                emailConfigObjectEdit.ClientHost = this.txtHost.EditValue.ToString();
                                emailConfigObjectEdit.PorNo = this.txtPortNo.EditValue.ToString();
                                emailConfigObjectEdit.SmtpPassword =
                                    MMS.CustomClasses.cCommon_Functions.Encrypt(txtpassword.Text.Trim(), txtenckey.Text.Trim());                
                                emailConfigObjectEdit.EncKey = txtenckey.Text.Trim();
                                context.EmailConfigurations.ApplyCurrentValues(emailConfigObjectEdit);
                            }

                            int succ = context.SaveChanges();
                            if (succ > 0)
                            {
                                MessageBox.Show("Record Saved Successfully...", "Save Success - Email Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                        }

                    }
                    else {
                        MessageBox.Show("Password Confirmation Fail.! ");
                    }
                   
                   
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}