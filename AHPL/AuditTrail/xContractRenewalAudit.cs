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
    public partial class xContractRenewalAudit : DevExpress.XtraEditors.XtraForm
    {
        public xContractRenewalAudit()
        {
            InitializeComponent();
        }

        private void xContractRenewalAudit_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryCont = (from c in context.ContractClosures_Audit
                                   where c.IsRenew == true
                                   select c).ToList();
                    this.contractClosures_AuditBindingSource.DataSource = qryCont;

                    var qryComp = (from c in context.Companies
                                   select new { c.CompanyID, c.CompanyCode }).ToList();
                    var qryLoc = (from l in context.Locations
                                  select new { l.LocationID, l.LocationCode }).ToList();
                    var qryFl = (from f in context.Floor_Levels
                                 select new { f.LevelID, f.LevelCode }).ToList();
                    var qryUser = (from u in context.Permission_Users
                                   select new { u.UserID, u.UserName }).ToList();

                    this.lookCompany.DataSource = qryComp;
                    this.lookCompany.DisplayMember = "CompanyCode";
                    this.lookCompany.ValueMember = "CompanyID";

                    this.lookLocationID.DataSource = qryLoc;
                    this.lookLocationID.DisplayMember = "LocationCode";
                    this.lookLocationID.ValueMember = "LocationID";

                    this.lookLevelID.DataSource = qryFl;
                    this.lookLevelID.DisplayMember = "LevelName";
                    this.lookLevelID.ValueMember = "LevelID";

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