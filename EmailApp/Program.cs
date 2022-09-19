using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress;

namespace EmailApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // DevExpress.UserSkins.OfficeSkins.Register();
            //DevExpress.UserSkins.BonusSkins.Register();
            //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            Application.Run(new xEmailApp());
        }
    }
}
