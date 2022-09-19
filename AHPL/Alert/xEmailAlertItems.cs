using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataTier;
using System.Linq;
using System.Linq.Expressions;
namespace MMS.UserPermission
{
    public partial class xEmailAlertItems : ParentForm.xParentDefault
    {
        List<EmailAlertItem> emailAlertItemList = new List<EmailAlertItem>();
        public xEmailAlertItems()
        {
            InitializeComponent();
            
        }

        private void xEmailAlertSettings_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                   emailAlertItemList.Clear();

                   emailAlertItemList = (from em in context.EmailAlertItems
                                             select em).ToList();
                   this.emailAlertItemBindingSource.DataSource = emailAlertItemList;

                    this.enable_control(false, eRecStatus.eInit);

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdEdit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                this.enable_control(true, eRecStatus.eEdit);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdClose_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void cmdFirst_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.emailAlertItemBindingSource.MoveFirst();
        }

        private void cmdPrev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.emailAlertItemBindingSource.MovePrevious();
        }

        private void cmdNext_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.emailAlertItemBindingSource.MoveNext();
        }

        private void cmdLast_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.emailAlertItemBindingSource.MoveLast();
        }

        private void cmdUndo_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            try
            {
                this.emailAlertItemBindingSource.CancelEdit();
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void cmdRefresh_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            load_data();

        }

        private void cmdSave_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            try
            {
                this.emailAlertItemBindingSource.EndEdit();
                using (AHPL_DBEntities context= new AHPL_DBEntities()) 
                {

                    foreach (var qry in emailAlertItemList)
                    {
                        EmailAlertItem emailAlertItemObject = (from em in context.EmailAlertItems
                                                               where em.EmailAlertItemID == qry.EmailAlertItemID
                                                               select em).FirstOrDefault();
                        emailAlertItemObject.AlertCycle = qry.AlertCycle;


                    }

                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record(s) Saved Successfully...", "Save Success - Email Alert Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

                load_data();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {

        }
    }
}
