using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MMS.Transaction.ContractBasket
{
    public partial class xSpellChecker : DevExpress.XtraEditors.XtraForm
    {
        public xSpellChecker()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckSpelling_Click(object sender, EventArgs e)
        {
            try
            {
                spellChecker1.Check(richEditControl1);
                SpellChecked = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string TextToCheck { get; set; }

        private void xSpellChecker_Load(object sender, EventArgs e)
        {
            this.richEditControl1.RtfText = this.TextToCheck;
        }
               

        public string CorrectedText { get; set; }

        public bool SpellChecked { get; set; }

        private void xSpellChecker_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CorrectedText = this.richEditControl1.RtfText;
        }
    }
}