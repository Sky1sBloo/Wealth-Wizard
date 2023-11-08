using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wealth_Wizard.Handlers;
using Wealth_Wizard.Properties;

namespace Wealth_Wizard
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check if default database location exists
            string fileLocation = (Settings.Default.DefaultDatabase.Replace(@"data source=", ""));

            if (File.Exists(fileLocation))
            {
                DatabaseHandler.databaseLocation = Settings.Default.DefaultDatabase;
            }
            else
            {
                NewDatabaseForm newDatabaseForm = new NewDatabaseForm();

                if (newDatabaseForm.ShowDialog() != DialogResult.OK)
                {
                    System.Environment.Exit(1);
                    return;
                }

                // Save into preferences
                Settings.Default.DefaultDatabase = DatabaseHandler.databaseLocation;
            }

            SystemClock.Now = DateTime.Now;

            // Setup arguments
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-setdate")
                {
                    string year = args[i + 1];
                    string month = args[i + 2];
                    string day = args[i + 3];

                    SystemClock.Now = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));

                    i += 3;
                }
            }

            Application.Run(new Display());
        }
    }
}
