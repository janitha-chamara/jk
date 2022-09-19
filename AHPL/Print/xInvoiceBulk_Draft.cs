using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DataTier;

namespace MMS.Print
{
    public partial class xInvoiceBulk_Draft : DevExpress.XtraEditors.XtraForm
    {
        public xInvoiceBulk_Draft()
        {
            InitializeComponent();

            load_data();
        }

        private void load_data()
        {
            try 
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                { 
                    
                }
            }
            catch (Exception ex) 
            {
            
            }
        }

        private void lueShopName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void luCompany_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void luCustomer_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
