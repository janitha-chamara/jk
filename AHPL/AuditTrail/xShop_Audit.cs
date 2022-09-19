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
    public partial class xShop_Audit : DevExpress.XtraEditors.XtraForm
    {
        AHPL_DBEntities context = new AHPL_DBEntities();
        public xShop_Audit()
        {
            InitializeComponent();
        }

        private void xShop_Audit_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {
            try
            {
                //using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryLevel = (from l in context.Floor_Levels
                                    select new { l.LevelID, l.LevelName }).ToList();
                    this.lookLevelID.DataSource = qryLevel;
                    this.lookLevelID.DisplayMember = "LevelName";
                    this.lookLevelID.ValueMember = "LevelID";

                    var qryLocation = (from l in context.Locations
                                       select new { l.LocationID, l.LocationCode }).ToList();
                    this.lookLocationID.DataSource = qryLocation;
                    this.lookLocationID.DisplayMember = "LocationCode";
                    this.lookLocationID.ValueMember = "LocationID";

                    var qryCompany = (from c in context.Companies
                                      select new { c.CompanyCode, c.CompanyID }).ToList();
                    this.lookCompanyID.DataSource = qryCompany;
                    this.lookCompanyID.DisplayMember = "CompanyCode";
                    this.lookCompanyID.ValueMember = "CompanyID";

                    var qryRentAreType = (from r in context.Rent_Area_Types
                                          select new { r.RentAreaTypeID, r.RentAreaTypeName }).ToList();
                    this.lookRentAreaTypeID.DataSource = qryRentAreType;
                    this.lookRentAreaTypeID.DisplayMember = "RentAreaTypeName";
                    this.lookRentAreaTypeID.ValueMember = "RentAreaTypeID";

                    var qryUtility = (from u in context.Utilities
                                      select new { u.UtilityID, u.UtilityName }).ToList();
                    this.lookUtilityID.DataSource = qryUtility;
                    this.lookUtilityID.DisplayMember = "UtilityName";
                    this.lookUtilityID.ValueMember = "UtilityID";

                    var qryURate = (from ur in context.Utility_Rates
                                    select new { ur.UtilityRateID, ur.UnitRate }).ToList();
                    this.lookUtilityRate.DataSource = qryURate;
                    this.lookUtilityRate.DisplayMember = "UnitRate";
                    this.lookUtilityRate.ValueMember = "UtilityRateID";

                    var qryUser = (from u in context.Permission_Users
                                   select new { u.UserID, u.UserName }).ToList();
                  this.LookUserID1.DataSource= this.lookUserID.DataSource = qryUser;
                    this.LookUserID1.DisplayMember =  this.lookUserID.DisplayMember = "UserName";
                     this.LookUserID1.ValueMember =   this.lookUserID.ValueMember = "UserID";



                    var qryShop = (from s in context.Shops_Audit
                                   select s).ToList();
                    this.shops_AuditBindingSource.DataSource = qryShop;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shops_AuditBindingSource_PositionChanged(object sender, EventArgs e)
        {
            load_data_Detail();

        }

        private void load_data_Detail()
        {

            Shops_Audit shopAudit = (Shops_Audit)this.shops_AuditBindingSource.Current;
            if (shopAudit == null)
            {
                return;
            }

            var qryDet = (from s in context.Shops_UtilityReadings_Audit
                          where s.ShopID == shopAudit.ShopID
                          select s).ToList();
            this.shops_UtilityReadings_AuditBindingSource.DataSource = qryDet;





        }
    }
}