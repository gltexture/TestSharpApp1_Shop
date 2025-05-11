using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSharp1
{
    internal static class Program
    {
        public static Page currentPage = Page.Main;

        [STAThread]
        static void Main()
        {
            DataBase.Connect();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            DataBase.Disconnect();
        }
    }
}
