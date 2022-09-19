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

namespace MMS.MIS
{
    public partial class xExceptionItem : DevExpress.XtraEditors.XtraForm
    {
        public xExceptionItem()
        {
            InitializeComponent();
        }

        private void xExceptionItem_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryRptItem = (from r in context.MisReportItems
                                      where r.ReportItemID == 8
                                      select r).FirstOrDefault();
                    if (qryRptItem != null)
                    {
                        this.txtCustomerName.EditValue = qryRptItem.ReportItemName;
                        this.lookExtendedCustomerID.EditValue = qryRptItem.ExceptionItem;

                    }


                    var qryCust = (from ec in context.Extended_Customers
                                   join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                   join c in context.Companies on ec.CompanyID equals c.CompanyID
                                   join l in context.Locations on ec.LocationID equals l.LocationID
                                   select new { gc.CustomerName, ec.ExtendedCustomerID, c.CompanyCode, l.LocationCode }).ToList();
                    this.lookExtendedCustomerID.Properties.DataSource = qryCust;
                    this.lookExtendedCustomerID.Properties.DisplayMember = "CustomerName";
                    this.lookExtendedCustomerID.Properties.ValueMember = "ExtendedCustomerID";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtCustomerName.Text.ToString()))
                { throw new Exception("Invalid Item Name"); }

                if (string.IsNullOrEmpty(this.lookExtendedCustomerID.Text.ToString()))
                { throw new Exception("Invalid Customer Mapping"); }


                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryRptItem = (from r in context.MisReportItems
                                      where r.ReportItemID == 8
                                      select r).FirstOrDefault();
                    if (qryRptItem != null)
                    {
                        qryRptItem.ReportItemName = this.txtCustomerName.Text;
                        qryRptItem.ExceptionItem = int.Parse(this.lookExtendedCustomerID.EditValue.ToString());

                    }
                    

                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Saved Successfully...", "Save Success - Exception Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}