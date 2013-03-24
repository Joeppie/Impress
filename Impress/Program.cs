using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Impress
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] //Thread appartment for COM interop to work properly
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Impress.UIElements.Forms.MainForm());
        }
    }
}
