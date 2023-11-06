using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Wealth_Wizard.Handlers
{
    /// <summary>
    /// Class that manages the preferences
    /// </summary>
    public static class PreferencesHandler
    {
        public static void SavePreferences(Preferences preferences)
        {
            // Save into json
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string jsonPreferences = JsonSerializer.Serialize<Preferences>(preferences, options);
            File.WriteAllText("preferences.json", jsonPreferences);
        }

        public static Preferences LoadPreferences()
        {
            string jsonPreferences = File.ReadAllText("preferences.json");
            return JsonSerializer.Deserialize<Preferences>(jsonPreferences);
        }
    }
}
