using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wealth_Wizard.Tools
{
    public class EntryTypesHandler
    {
        // Entry types
        // Returns all entry type names
        public static List<string> GetEntryTypes()
        {
            List<string> entryTypes = new List<string>();

            foreach (DataRow row in DatabaseHandler.GetAllValuesFromTable("entry_types").Rows)
            {
                entryTypes.Add(row["types"].ToString());
            }

            return entryTypes;
        }

        // Adds a new entry type
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

        // Edits an entry type
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

        // Deletes the specific entry type on the database
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
