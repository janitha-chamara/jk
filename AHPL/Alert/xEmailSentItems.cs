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
    public partial class xEmailSentItems : DevExpress.XtraEditors.XtraForm
    {
        public xEmailSentItems()
        {
            InitializeComponent();
        }

        private void xEmailSentItems_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryLog = (from em in context.EmailSentItems
                                  join m in context.EmailsToBeSents on em.EmailToBeSendID equals m.EmailTobeSendID
                                  join a in context.EmailAlertItems on m.EmailAlertItemID equals a.EmailAlertItemID
                                  join c in context.Companies on m.CompanyID equals c.CompanyID
                                  join l in context.Locations on m.LocationID equals l.LocationID
                                  select new { a.EmailArertItemName, m.Subject, m.IsMonthly, m.IsHourly, m.Body, c.CompanyCode, l.LocationCode, m.EmailSentDate, m.IsEmailSent, em.Email }).ToList();
                    this.gridControl1.DataSource = qryLog;
                    this.gridView1.BestFitColumns();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}