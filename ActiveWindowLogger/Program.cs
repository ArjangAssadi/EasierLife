using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveWindowLogger
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
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LogOnlyActiveWindowChanged());
            //Application.Run(new LogEveryChangeInWindowsForground());
            Application.Run(new LogWinEvents());
        }
    }
}
