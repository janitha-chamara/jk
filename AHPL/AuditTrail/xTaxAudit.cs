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
    public partial class xTaxAudit : DevExpress.XtraEditors.XtraForm
    {
        public xTaxAudit()
        {
            InitializeComponent();
        }

        private void xTaxAudit_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryTaxAudit = (from t in context.Taxes_Audit
                                       select t).ToList();
                    this.taxes_AuditBindingSource.DataSource = qryTaxAudit;

                    var qryUser = (from u in context.Permission_Users
                                   select new { u.UserID, u.UserName }).ToList();

                    this.lookUserID.DataSource = lookUserID1.DataSource = qryUser;
                    this.lookUserID.DisplayMember = this.lookUserID.DisplayMember = "UserName";
                    this.lookUserID.ValueMember = this.lookUserID1.ValueMember = "UserID";


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}