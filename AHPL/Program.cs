using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ParentForm;
using DevExpress.Skins;
using MMS.UserPermission;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace MMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            
            Application.SetCompatibleTextRenderingDefault(false);


            SplashScreenManager.ShowForm(typeof(SplashScreen1));

            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(35);
            }

            SplashScreenManager.CloseForm(false);

            Application.Run(new xHomeScreen());

           
        }
    }
}
