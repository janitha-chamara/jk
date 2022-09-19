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
    public partial class xCustomers_Audit : DevExpress.XtraEditors.XtraForm
    {
        public xCustomers_Audit()
        {
            InitializeComponent();
        }

        private void xCustomers_Audit_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryCustAudit = (from c in context.Global_Customers_Audit
                                        select c).ToList();
                    this.global_Customers_AuditBindingSource.DataSource = qryCustAudit;

                    var qryUser = (from u in context.Permission_Users
                                   select new { u.UserID, u.UserName }).ToList();
                    this.lookUserID.DataSource = qryUser;
                    this.lookUserID.DisplayMember = "UserName";
                    this.lookUserID.ValueMember = "UserID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Excel (*.xlsx)|*.xlsx";
                saveDlg.ShowDialog(this);
                string filename = saveDlg.FileName;
                this.gridView1.OptionsPrint.AutoWidth = false;
                this.gridView1.ExportToXlsx(filename);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
        }
    }
}