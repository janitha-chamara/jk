using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using System.Linq;
//using System.Data.Objects;
//using System.Linq.Expressions;
//using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking;
//using DevExpress.XtraEditors

namespace MMS
{
    public static class cEnable_Controls
    {
      
        public enum eRecStatus
        {
            eAddNew = 1,
            eEdit = 2,
            eSave = 3,
            eInit = 4
        }

        public static void enable_control(Form pForm, Boolean p)
        {
            Control ctrl;
            //var status = mRecStatus;

            //if (mRecStatus == eRecStatus.eInit)
            //{
            //    InitToolBar();
            //}
            //if (mRecStatus == eRecStatus.eEdit)
            //{
            //    EditToolBar();
            //}
            //if (mRecStatus == eRecStatus.eSave)
            //{
            //    SaveToolBar();
            //}
            //if (mRecStatus == eRecStatus.eAddNew)
            //{
            //    AddNewToolBar();
            //}


            

            int cnt =  pForm.Controls.Count - 1;

            for (int i = 0; i <= cnt; i++)
            {
                ctrl = pForm.Controls[i];


                childestControls(ctrl, p);

                if (ctrl is DevExpress.XtraEditors.GroupControl)
                {
                    DevExpress.XtraEditors.GroupControl parentctrl = (DevExpress.XtraEditors.GroupControl)ctrl;
                    for (int ii = 0; ii <= parentctrl.Controls.Count - 1; ii++)
                    {
                        Control containctrl = parentctrl.Controls[ii];
                        childestControls(containctrl, p);
                    }

                }

                if (ctrl is DevExpress.XtraEditors.PanelControl)
                {
                    DevExpress.XtraEditors.PanelControl parentctrl = (DevExpress.XtraEditors.PanelControl)ctrl;
                    for (int ii = 0; ii <= parentctrl.Controls.Count - 1; ii++)
                    {
                        Control containctrl = parentctrl.Controls[ii];
                        childestControls(containctrl, p);
                    }
                    //childestControls(ctrl, p);

                }

                if (ctrl is DevExpress.XtraEditors.SplitContainerControl)
                {

                    for (int ii = 0; ii <= ctrl.Controls.Count - 1; ii++)
                    {
                        Control containctrl = ctrl.Controls[ii];
                        if (containctrl is DevExpress.XtraEditors.PanelControl)
                        {
                            for (int iii = 0; iii <= containctrl.Controls.Count - 1; iii++)
                            {

                                if (containctrl.Controls[iii] is DevExpress.XtraEditors.PanelControl)
                                {
                                    DevExpress.XtraEditors.PanelControl containerctrl1 = (DevExpress.XtraEditors.PanelControl)containctrl.Controls[iii];
                                    for (int iiii = 0; iiii <= containerctrl1.Controls.Count - 1; iiii++)
                                    {
                                        childestControls(containerctrl1.Controls[iiii], p);
                                    }
                                }

                                if (containctrl.Controls[iii] is DevExpress.XtraTab.XtraTabControl)
                                {
                                    DevExpress.XtraTab.XtraTabControl tbctrl = (DevExpress.XtraTab.XtraTabControl)containctrl.Controls[iii];

                                    for (int iiii = 0; iiii <= tbctrl.TabPages.Count - 1; iiii++)
                                    {

                                        DevExpress.XtraTab.XtraTabPage tpage = tbctrl.TabPages[iiii];

                                        for (int iiiii = 0; iiiii <= tpage.Controls.Count - 1; iiiii++)
                                        {
                                            childestControls(tpage.Controls[iiiii], p);

                                            if (tpage.Controls[iiiii] is DevExpress.XtraEditors.SplitContainerControl)
                                            {
                                                DevExpress.XtraEditors.SplitContainerControl spltctnr = (DevExpress.XtraEditors.SplitContainerControl)tpage.Controls[iiiii];

                                                for (int ipnlcnt = 0; ipnlcnt <= spltctnr.Controls.Count - 1; ipnlcnt++)
                                                {
                                                    childestControls(spltctnr.Controls[ipnlcnt], p);

                                                    if (spltctnr.Controls[ipnlcnt] is DevExpress.XtraEditors.PanelControl)
                                                    {
                                                        DevExpress.XtraEditors.PanelControl panlcotrol = (DevExpress.XtraEditors.PanelControl)spltctnr.Controls[ipnlcnt];
                                                        for (int pnlctrlcnt = 0; pnlctrlcnt <= panlcotrol.Controls.Count - 1; pnlctrlcnt++)
                                                        {
                                                            childestControls(panlcotrol.Controls[pnlctrlcnt], p);
                                                        }
                                                    }

                                                }

                                            }

                                        }
                                    }
                                }

                                childestControls(containctrl.Controls[iii], p);
                            }

                        }

                        childestControls(containctrl, p);
                    }
                }

                if (ctrl is DevExpress.XtraEditors.PanelControl)
                {

                    for (int ii = 0; ii <= ctrl.Controls.Count - 1; ii++)
                    {
                        var ctrol = ctrl.Controls[ii];
                        childestControls(ctrl.Controls[ii], p);
                    }


                }

            }
        }

        private static void childestControls(Control ctrl, bool p)
        {
            if (ctrl is TextBox)
            {
                ctrl.Enabled = p;
            }

            if (ctrl is DevExpress.XtraEditors.GridLookUpEdit)
            {
                DevExpress.XtraEditors.GridLookUpEdit frmgridlookupedit = (DevExpress.XtraEditors.GridLookUpEdit)ctrl;
                frmgridlookupedit.Properties.ReadOnly = !p;
                //frmgridlookupedit.Properties.AppearanceReadOnly.BackColor = myReadOnlyColour;
                //frmgridlookupedit.Properties.AppearanceFocused.BackColor = myFocusedColour;
                //frmgridlookupedit.Properties.AppearanceDisabled.BackColor = myDisabledColour;
                //frmgridlookupedit.BackColor = myDisabledColour;
            }

            if (ctrl is DevExpress.XtraEditors.SearchLookUpEdit)
            {
                DevExpress.XtraEditors.SearchLookUpEdit frmgridlookupedit = (DevExpress.XtraEditors.SearchLookUpEdit)ctrl;
                frmgridlookupedit.Properties.ReadOnly = !p;
                //frmgridlookupedit.Properties.AppearanceReadOnly.BackColor = myReadOnlyColour;
                //frmgridlookupedit.Properties.AppearanceFocused.BackColor = myFocusedColour;
                //frmgridlookupedit.Properties.AppearanceDisabled.BackColor = myDisabledColour;
                //frmgridlookupedit.BackColor = myDisabledColour;
            }


            if (ctrl is DevExpress.XtraEditors.LookUpEdit)
            {
                DevExpress.XtraEditors.LookUpEdit frmlookupedit = (DevExpress.XtraEditors.LookUpEdit)ctrl;
                frmlookupedit.Properties.ReadOnly = !p;
                //frmlookupedit.Properties.AppearanceReadOnly.BackColor = myReadOnlyColour;
                //frmlookupedit.Properties.AppearanceFocused.BackColor = myFocusedColour;
                //frmlookupedit.Properties.AppearanceDisabled.BackColor = myDisabledColour;
                //frmlookupedit.BackColor = myDisabledColour;
            }


            if (ctrl is DevExpress.XtraEditors.TextEdit)
            {
                DevExpress.XtraEditors.TextEdit frmtextbox = (DevExpress.XtraEditors.TextEdit)ctrl;

                frmtextbox.Properties.ReadOnly = !p;
                //frmtextbox.Properties.AppearanceReadOnly.BackColor = myReadOnlyColour;
                //frmtextbox.Properties.AppearanceFocused.BackColor = myFocusedColour;
                //frmtextbox.Properties.AppearanceDisabled.BackColor = myDisabledColour;
                //frmtextbox.BackColor = myDisabledColour;
            }

            if (ctrl is DevExpress.XtraGrid.GridControl)
            {
                DevExpress.XtraGrid.GridControl frmxgrid = (DevExpress.XtraGrid.GridControl)ctrl;
                int cntview = frmxgrid.ViewCollection.Count - 1;
                for (int intInc = 0; intInc <= cntview; intInc++)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView gridveiw = (DevExpress.XtraGrid.Views.Grid.GridView)frmxgrid.Views[cntview];
                    int colcnt = gridveiw.Columns.Count - 1;
                    for (int i = 0; i <= colcnt; i++)
                    {
                        gridveiw.Columns[i].OptionsColumn.ReadOnly = !p;
                    }
                }

            }

            if (ctrl is DevExpress.XtraEditors.MRUEdit)
            {
                DevExpress.XtraEditors.MRUEdit mruedit = (DevExpress.XtraEditors.MRUEdit)ctrl;
                mruedit.Properties.ReadOnly = !p;
            }

            if (ctrl is DevExpress.XtraEditors.ComboBoxEdit)
            {
                DevExpress.XtraEditors.ComboBoxEdit frmcbobox = (DevExpress.XtraEditors.ComboBoxEdit)ctrl;
                frmcbobox.Properties.ReadOnly = !p;
                //frmcbobox.Properties.AppearanceReadOnly.BackColor = myReadOnlyColour;
                //frmcbobox.Properties.AppearanceFocused.BackColor = myFocusedColour;
                //frmcbobox.Properties.AppearanceDisabled.BackColor = myDisabledColour;
                //frmcbobox.BackColor = myDisabledColour;
            }

            if (ctrl is DevExpress.XtraEditors.MemoEdit)
            {
                DevExpress.XtraEditors.MemoEdit frmmemoedit = (DevExpress.XtraEditors.MemoEdit)ctrl;
                frmmemoedit.Properties.ReadOnly = !p;
                //frmmemoedit.Properties.AppearanceReadOnly.BackColor = myReadOnlyColour;
                //frmmemoedit.Properties.AppearanceFocused.BackColor = myFocusedColour;
                //frmmemoedit.Properties.AppearanceDisabled.BackColor = myDisabledColour;
                //frmmemoedit.BackColor = myDisabledColour;
            }

            if (ctrl is DevExpress.XtraEditors.CheckEdit)
            {
                DevExpress.XtraEditors.CheckEdit frmcontrol = (DevExpress.XtraEditors.CheckEdit)ctrl;
                frmcontrol.Properties.ReadOnly = !p;
                //frmcontrol.Properties.AppearanceReadOnly.BackColor = myReadOnlyColour;
                //frmcontrol.Properties.AppearanceFocused.BackColor = myFocusedColour;
                //frmcontrol.Properties.AppearanceDisabled.BackColor = myDisabledColour;
                //frmcontrol.BackColor = myDisabledColour;
            }



            if (ctrl is System.Windows.Forms.ComboBox)
            {
                System.Windows.Forms.ComboBox frmcontrol = (System.Windows.Forms.ComboBox)ctrl;
                frmcontrol.Enabled = p;
            }

        }


        private static void childestControlsClearText(Control ctrl)
        {
            if (ctrl is TextBox)
            {
                ctrl.Text = "";
            }

            if (ctrl is DevExpress.XtraEditors.GridLookUpEdit)
            {
                DevExpress.XtraEditors.GridLookUpEdit frmgridlookupedit = (DevExpress.XtraEditors.GridLookUpEdit)ctrl;
                frmgridlookupedit.EditValue = 0;

            }

            if (ctrl is DevExpress.XtraEditors.SearchLookUpEdit)
            {
                DevExpress.XtraEditors.SearchLookUpEdit frmgridlookupedit = (DevExpress.XtraEditors.SearchLookUpEdit)ctrl;
                frmgridlookupedit.EditValue = 0;

            }


            if (ctrl is DevExpress.XtraEditors.LookUpEdit)
            {
                DevExpress.XtraEditors.LookUpEdit frmlookupedit = (DevExpress.XtraEditors.LookUpEdit)ctrl;
                frmlookupedit.EditValue = 0;
            }


            if (ctrl is DevExpress.XtraEditors.TextEdit)
            {
                DevExpress.XtraEditors.TextEdit frmtextbox = (DevExpress.XtraEditors.TextEdit)ctrl;

                frmtextbox.EditValue = string.Empty;
            }

            if (ctrl is DevExpress.XtraGrid.GridControl)
            {
                //DevExpress.XtraGrid.GridControl frmxgrid = (DevExpress.XtraGrid.GridControl)ctrl;
                //int cntview = frmxgrid.ViewCollection.Count - 1;
                //for (int intInc = 0; intInc <= cntview; intInc++)
                //{
                //    DevExpress.XtraGrid.Views.Grid.GridView gridveiw = (DevExpress.XtraGrid.Views.Grid.GridView)frmxgrid.Views[cntview];
                //    //int colcnt = gridveiw.Columns.Count - 1;
                //    //for (int i = 0; i <= colcnt; i++)
                //    //{
                //    //    gridveiw.Columns[i]. = !p;
                //    //}

                //}

            }

            if (ctrl is DevExpress.XtraEditors.MRUEdit)
            {
                DevExpress.XtraEditors.MRUEdit mruedit = (DevExpress.XtraEditors.MRUEdit)ctrl;
                mruedit.EditValue = string.Empty;
            }

            if (ctrl is DevExpress.XtraEditors.ComboBoxEdit)
            {
                DevExpress.XtraEditors.ComboBoxEdit frmcbobox = (DevExpress.XtraEditors.ComboBoxEdit)ctrl;
                frmcbobox.EditValue = string.Empty;
            }

            if (ctrl is DevExpress.XtraEditors.MemoEdit)
            {
                DevExpress.XtraEditors.MemoEdit frmmemoedit = (DevExpress.XtraEditors.MemoEdit)ctrl;
                frmmemoedit.EditValue = string.Empty;
            }

            if (ctrl is DevExpress.XtraEditors.CheckEdit)
            {
                DevExpress.XtraEditors.CheckEdit frmcontrol = (DevExpress.XtraEditors.CheckEdit)ctrl;
                frmcontrol.Checked = false;
            }



            if (ctrl is System.Windows.Forms.ComboBox)
            {
                System.Windows.Forms.ComboBox frmcontrol = (System.Windows.Forms.ComboBox)ctrl;
                frmcontrol.Text = string.Empty;
            }

        }

        public static void ClearText(Form pForm)
        {
            Control ctrl;
            #region cleartext
            int cnt = pForm.Controls.Count - 1;

            for (int i = 0; i <= cnt; i++)
            {
                ctrl = pForm.Controls[i];


                childestControlsClearText(ctrl);

                if (ctrl is DevExpress.XtraEditors.GroupControl)
                {
                    DevExpress.XtraEditors.GroupControl parentctrl = (DevExpress.XtraEditors.GroupControl)ctrl;
                    for (int ii = 0; ii <= parentctrl.Controls.Count - 1; ii++)
                    {
                        Control containctrl = parentctrl.Controls[ii];
                        childestControlsClearText(containctrl);
                    }

                }

                if (ctrl is DevExpress.XtraEditors.PanelControl)
                {
                    DevExpress.XtraEditors.PanelControl parentctrl = (DevExpress.XtraEditors.PanelControl)ctrl;
                    for (int ii = 0; ii <= parentctrl.Controls.Count - 1; ii++)
                    {
                        Control containctrl = parentctrl.Controls[ii];
                        childestControlsClearText(containctrl);
                    }
                    //childestControls(ctrl, p);

                }

                if (ctrl is DevExpress.XtraEditors.SplitContainerControl)
                {

                    for (int ii = 0; ii <= ctrl.Controls.Count - 1; ii++)
                    {
                        Control containctrl = ctrl.Controls[ii];
                        if (containctrl is DevExpress.XtraEditors.PanelControl)
                        {
                            for (int iii = 0; iii <= containctrl.Controls.Count - 1; iii++)
                            {

                                if (containctrl.Controls[iii] is DevExpress.XtraEditors.PanelControl)
                                {
                                    DevExpress.XtraEditors.PanelControl containerctrl1 = (DevExpress.XtraEditors.PanelControl)containctrl.Controls[iii];
                                    for (int iiii = 0; iiii <= containerctrl1.Controls.Count - 1; iiii++)
                                    {
                                        childestControlsClearText(containerctrl1.Controls[iiii]);
                                    }
                                }

                                if (containctrl.Controls[iii] is DevExpress.XtraTab.XtraTabControl)
                                {
                                    DevExpress.XtraTab.XtraTabControl tbctrl = (DevExpress.XtraTab.XtraTabControl)containctrl.Controls[iii];

                                    for (int iiii = 0; iiii <= tbctrl.TabPages.Count - 1; iiii++)
                                    {

                                        DevExpress.XtraTab.XtraTabPage tpage = tbctrl.TabPages[iiii];

                                        for (int iiiii = 0; iiiii <= tpage.Controls.Count - 1; iiiii++)
                                        {
                                            childestControlsClearText(tpage.Controls[iiiii]);

                                            if (tpage.Controls[iiiii] is DevExpress.XtraEditors.SplitContainerControl)
                                            {
                                                DevExpress.XtraEditors.SplitContainerControl spltctnr = (DevExpress.XtraEditors.SplitContainerControl)tpage.Controls[iiiii];

                                                for (int ipnlcnt = 0; ipnlcnt <= spltctnr.Controls.Count - 1; ipnlcnt++)
                                                {
                                                    childestControlsClearText(spltctnr.Controls[ipnlcnt]);

                                                    if (spltctnr.Controls[ipnlcnt] is DevExpress.XtraEditors.PanelControl)
                                                    {
                                                        DevExpress.XtraEditors.PanelControl panlcotrol = (DevExpress.XtraEditors.PanelControl)spltctnr.Controls[ipnlcnt];
                                                        for (int pnlctrlcnt = 0; pnlctrlcnt <= panlcotrol.Controls.Count - 1; pnlctrlcnt++)
                                                        {
                                                            childestControlsClearText(panlcotrol.Controls[pnlctrlcnt]);
                                                        }
                                                    }

                                                }

                                            }

                                        }




                                    }



                                }




                                childestControlsClearText(containctrl.Controls[iii]);
                            }

                        }

                        childestControlsClearText(containctrl);
                    }
                }

                if (ctrl is DevExpress.XtraEditors.PanelControl)
                {

                    for (int ii = 0; ii <= ctrl.Controls.Count - 1; ii++)
                    {
                        var ctrol = ctrl.Controls[ii];
                        childestControlsClearText(ctrl.Controls[ii]);
                    }


                }

            }
            #endregion

        }
    }
}
