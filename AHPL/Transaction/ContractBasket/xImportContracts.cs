using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataTier;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;


namespace MMS
{
    public partial class xImportContracts : DevExpress.XtraEditors.XtraForm
    {
        public bool import = false;
        
        public xImportContracts()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.searchLookUpEditContractClauseID.Text.ToString()))
            {
                searchLookUpEditContractClauseID.ErrorText = "Invalid Contract Name";
                return;
            }
            else { searchLookUpEditContractClauseID.ErrorText = ""; }
            int ccontractid = 0;
            bool res = false;
            res = int.TryParse(this.searchLookUpEditContractClauseID.EditValue.ToString(), out ccontractid);
            if (res == false) { ccontractid = 0; }


            contractClauseID = ccontractid;
            import = true;
            this.Close();

        }

        private void xImportContracts_Load(object sender, EventArgs e)
        {
           
                try
                {
                    using (AHPL_DBEntities context = new AHPL_DBEntities())
                    {
                        var qryCC = (from c in context.ContractClosures
                                     join co in context.Companies on c.CompanyID equals co.CompanyID
                                     join loc in context.Locations on c.LocationID equals loc.LocationID
                                     where c.IsProcessed == true
                                     select new { c.ContractClosureID, c.ContractClosureName, c.ShopName, c.ShopNo, co.CompanyCode, loc.LocationCode,c.IsTerminated }).ToList();

                        this.searchLookUpEditContractClauseID.Properties.DataSource = qryCC;
                        this.searchLookUpEditContractClauseID.Properties.DisplayMember = "ContractClosureName";
                        this.searchLookUpEditContractClauseID.Properties.ValueMember = "ContractClosureID";
                        searchLookUpEdit1View.BestFitColumns();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error");
                }
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int contractClauseID { get; set; }
    }
}