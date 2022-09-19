using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MMS
{
    public partial class rptMain : DevExpress.XtraEditors.XtraForm
    {
        public rptMain()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void rptMain_Load(object sender, EventArgs e)
        {
            this.crystalReportViewer1.Refresh();
        }
    }
}
