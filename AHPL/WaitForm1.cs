using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace MMS
{
    public partial class WaitForm1 : WaitForm
    {
        public WaitForm1()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }

        //public  void SetMaximumValue(int maxVal)
        //{
        //    this.progressBarControl1.Properties.Maximum = maxVal;
        //    this.progressBarControl1.Properties.Step = 1;
        //}

        //public  void PerformStep()
        //{
        //    this.progressBarControl1.PerformStep();
        //}

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}