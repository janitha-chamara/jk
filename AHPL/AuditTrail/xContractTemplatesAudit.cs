using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Linq.Expressions;
using DataTier;

namespace MMS.AuditTrail
{
    public partial class xContractTemplatesAudit : DevExpress.XtraEditors.XtraForm
    {
        public xContractTemplatesAudit()
        {
            InitializeComponent();
        }

        private void xContractTemplatesAudit_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryContTemplates = (from c in context.Conract_Closure_Sub_Templates_Audit
                                            select c).ToList();
                    this.conract_Closure_Sub_Templates_AuditBindingSource.DataSource = qryContTemplates;

                    var qryUser = (from u in context.Permission_Users
                                   select new { u.UserID, u.UserName }).ToList();
                    this.lookUserID.DataSource = qryUser;
                    this.lookUserID.DisplayMember = "UserName";
                    this.lookUserID.ValueMember = "UserID";


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}