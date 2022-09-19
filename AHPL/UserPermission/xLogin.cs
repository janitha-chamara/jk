using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MMS.CustomClasses;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace MMS.UserPermission
{
    public partial class xLogin : DevExpress.XtraEditors.XtraForm
    {
        public xLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           string strUserName  = "";
           string strPass = "";
           strUserName = this.txtUser.Text.ToString();
           strPass = this.txtPass.Text.ToString();

            // Validating user
           if (string.IsNullOrEmpty(strUserName.Trim()))
           {
               dxErrorProvider1.SetError(this.txtUser, "User Name Cannot Be Blanked");
               return;
           }
           else
           {
               dxErrorProvider1.SetError(this.txtUser, "");  
           }
            // --- 

           // validating password
            if (string.IsNullOrEmpty(strPass.Trim())) 
            {
                dxErrorProvider1.SetError(this.txtPass,"Password Cannot Be Blanked");
                return;
            } else { dxErrorProvider1.SetError(this.txtPass,"");}

           ///--



            bool authenticated = MMS.CustomClasses.cCommon_Functions.IsAuthenticated(strUserName);
            if (authenticated == false)
            {
                dxErrorProvider1.SetError(this.txtUser, "User Name not found");
                return;
            }
            else { dxErrorProvider1.SetError(this.txtUser, ""); }

            if (authenticated == true)
            {
                bool authUserPass = MMS.CustomClasses.cCommon_Functions.IsAuthUserandPass(strUserName, strPass);
                if (authUserPass == false)
                {
                    dxErrorProvider1.SetError(this.txtPass, "Invalid Password");
                    UserAuthenticated = false;
                    return;
                }
                else
                {
                    UserAuthenticated = true;
                    //this.Hide();
                    //SplashScreenManager.ShowForm(typeof(SplashScreen1));

                    //for (int i = 1; i <= 100; i++)
                    //{
                    //    Thread.Sleep(25);
                    //}
                    //SplashScreenManager.CloseForm(false);

                    this.Close();



               
                }




            }


        }

        private void xLogin_Load(object sender, EventArgs e)
        {

        }

        public bool UserAuthenticated { get; set; }
    }
}