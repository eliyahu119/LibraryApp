using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libaryApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainWindow.Instance());
        }
        //Application.SetHighDpiMode(HighDpiMode.SystemAware);
        //Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new Form1());
        //var con = new SqlConnection();
        //con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; 
        //                        AttachDbFilename = C:\Users\eliyahu\source\repos\libaryApp\libaryApp\libaryDb.mdf; 
        //                        Integrated Security = True;
        //                        Connect Timeout=30;";

        //con.Open();
        //con.Close();

    }
}
