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
    public partial class xUtilityCreditAudit : DevExpress.XtraEditors.XtraForm
    {
        public xUtilityCreditAudit()
        {
            InitializeComponent();
        }

        private void xUtilityCreditAudit_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryInv = (from i in context.Invoices_Audit
                                  where i.InvoiceTypeID == 2 && i.SubInvTypeID == 2 || i.SubInvTypeID == 1
                                  select i).ToList();
                    this.invoices_AuditBindingSource.DataSource = qryInv;

                    var qrySubInv = (from s in context.Sub_Invoice_Types
                                     select s).ToList();
                    this.lookSubInvTypeID.DataSource = qrySubInv;
                    this.lookSubInvTypeID.DisplayMember = "SubInvTypeName";
                    this.lookSubInvTypeID.ValueMember = "SubInvTypeID";

                    var qryInvT = (from i in context.Invoice_Types
                                   select new { i.InvoiceTypeID, i.InvoiceTypeName }).ToList();
                    this.lookInvType.DataSource = qryInv;
                    this.lookInvType.DisplayMember = "InvoiceTypeName";
                    this.lookInvType.ValueMember = "InvoiceTypeID";

                    var qryOT = (from ot in context.OtherServiceCategories
                                 select new { ot.OtherServiceID, ot.OtherServiceName }).ToList();
                    this.lookOtherServiceType.DataSource = qryOT;
                    this.lookOtherServiceType.DisplayMember = "OtherServiceName";
                    this.lookOtherServiceType.ValueMember = "OtherServiceID";

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