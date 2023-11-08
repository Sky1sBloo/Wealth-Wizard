using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wealth_Wizard.Handlers
{
    /// <summary>
    /// Provides methods for setting and retrieving entry types
    /// </summary>
    public class EntryTypesHandler
    {
        /// <summary>
        /// Returns a list of all available entry type names.
        /// </summary>
        public static List<string> GetEntryTypes()
        {
            List<string> entryTypes = new List<string>();

            foreach (DataRow row in DatabaseHandler.GetAllValuesFromTable("entry_types").Rows)
            {
                entryTypes.Add(row["types"].ToString());
            }

            return entryTypes;
        }

        /// <summary>
        /// Adds a new entry type to the database.
        /// </summary>
        /// <param name="newType">The name of the new entry type to be added.</param>
        public static void AddEntryType(string newType)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryAdd = "INSERT INTO entry_types (types) VALUES (@entry_type)";
            SQLiteCommand cmd = new SQLiteCommand(queryAdd, con);
            cmd.Parameters.AddWithValue("@entry_type", newType);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// <summary>
        /// Updates the name of an existing entry type in the database.
        /// </summary>
        /// <param name="selectedType">The current name of the entry type to be updated.</param>
        /// <param name="newType">The new name for the entry type.</param>
        public static void UpdateEntryType(string selectedType, string newType)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryAdd = "UPDATE entry_types " +
                "SET types = @new_type " +
                "WHERE types = @selected_type";
            SQLiteCommand cmd = new SQLiteCommand(queryAdd, con);
            cmd.Parameters.AddWithValue("@selected_type", selectedType);
            cmd.Parameters.AddWithValue("@new_type", newType);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// <summary>
        /// Deletes a specific entry type from the database.
        /// </summary>
        /// <param name="type">The name of the entry type to be deleted.</param>
        public static void DeleteEntryTypes(string type)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryDelete = "DELETE FROM entry_types \r\n" +
                "WHERE types = @type";

            SQLiteCommand cmd = new SQLiteCommand(queryDelete, con);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
