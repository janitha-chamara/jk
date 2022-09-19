using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTier;

namespace MMS.AuditTrail
{
    public partial class xSecurityUsersAudit : Form
    {
        public xSecurityUsersAudit()
        {
            InitializeComponent();
        }

        private void xSecurityUsersAudit_Load(object sender, EventArgs e)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                List<Permission_Users_Audit> auditList= context.Permission_Users_Audit.ToList();
                securityAudit_BindingSource.DataSource = auditList;
            }
        }
    }
}
