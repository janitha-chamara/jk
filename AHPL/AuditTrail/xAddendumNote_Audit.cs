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

namespace MMS.AuditTrail
{
    public partial class xAddendumNote_Audit : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xAddendumNote_Audit()
        {
            InitializeComponent();
        }

        private void xAddendumNote_Audit_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    //var qryAddendum = (from a in context.Addendums_Audit
                    //                   join ad in context.Addendum_Details_Audit on a.AddendumID equals ad.AddendumID
                    //                   select new { a.AddendumID, a.AddendumDate, a.AddendumName, a.ContractClosureID, a.Remarks, ad.FromDateO, ad.ToDateO, ad.RentperSqFeetN, ad.RentperSqFeetO, ad.SCperSqFeetN, ad.SCperSqFeetO, ad.CreatedBy, ad.UpdatedBy, ad.UpdatedDate, ad.LoggedDate }).ToList();
                    //this.gridControl1.DataSource = qryAddendum;

                    var qryAddendum = (from a in context.Addendums_Audit
                                       select a).ToList();
                 
                    this.addendums_AuditBindingSource.DataSource = qryAddendum;

                    var qryContract = (from c in context.ContractClosures
                                       select new { c.ContractClosureID, c.ContractClosureName }).ToList();
                    this.lookContractClosureID.DataSource = qryContract;
                    this.lookContractClosureID.DisplayMember = "ContractClosureName";
                    this.lookContractClosureID.ValueMember = "ContractClosureID";

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

        private void addendums_AuditBindingSource_PositionChanged(object sender, EventArgs e)
        {
            Addendums_Audit addendumAuOb = (Addendums_Audit)this.addendums_AuditBindingSource.Current;
            if (addendumAuOb != null)
            {

               
                {
                    var qryAddDet = (from d in context.Addendum_Details_Audit
                                     where d.AddendumID == addendumAuOb.AddendumID
                                     select d).ToList();
                    this.addendum_Details_AuditBindingSource.DataSource = qryAddDet;

                }
               

            }
        }
    }
}