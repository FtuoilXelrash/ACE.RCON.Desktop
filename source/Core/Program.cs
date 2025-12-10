using System;
using System.Windows.Forms;
using ACE.RCON.Desktop.Utilities;

namespace ACE.RCON.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize logger
            Logger.Initialize("logs");
            Logger.Info("ACE RCON Desktop starting...");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

            Logger.Info("ACE RCON Desktop exiting");
        }
    }
}
