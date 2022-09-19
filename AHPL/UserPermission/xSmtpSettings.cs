using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTier;

namespace MMS.UserPermission
{
    public partial class xSmtpSettings : Form
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xSmtpSettings()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            try
            {
                var qryCom = (from smtp in context.tbl_smtp
                              select new { smtp.host, smtp.password,smtp.username,smtp.EntityKey,smtp.port }).ToList();

                txthost.Text = qryCom[0].host;
                txtport.Text = qryCom[0].port.ToString();
                txtuser.Text = qryCom[0].username;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
