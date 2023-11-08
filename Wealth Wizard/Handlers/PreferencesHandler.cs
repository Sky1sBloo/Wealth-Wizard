using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wealth_Wizard.Properties;

namespace Wealth_Wizard.Handlers
{
    /// <summary>
    /// Class that manages the preferences
    /// </summary>
    public static class PreferencesHandler
    {
        public static void SavePreferences(Preferences preferences)
        {
            Settings.Default.DefaultDatabase = preferences.DefaultDatabase;
            Settings.Default.Save();
        }

        public static Preferences LoadPreferences()
        {
            Preferences preferences = new Preferences();
            preferences.DefaultDatabase = Settings.Default.DefaultDatabase;
            return preferences;
        }
    }
}
