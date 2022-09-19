using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MMS.CustomClasses
{
    public static class Suport
    {
        public static void LogEntry(string logText)
        {
            try
            {
                //// Set a variable to the My Documents path. 
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                string logFilePath = mydocpath + "/LogFiles";
                if (!Directory.Exists(logFilePath)) 
                {
                    Directory.CreateDirectory(logFilePath);
                }

                //// Open a streamwriter to a new text file named "UserInputFile.txt"and write the contents of 
                DateTime today = DateTime.Now;
                using (StreamWriter outfile = new StreamWriter(logFilePath + @"\InvoiceDetailsLog_" + today.Year + "_" + today.Month + "_" + today.Day + ".txt", true))
                {
                    outfile.WriteLine("***" + DateTime.Now + "***");
                    outfile.WriteLine(logText);
                    outfile.WriteLine("---End---");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
