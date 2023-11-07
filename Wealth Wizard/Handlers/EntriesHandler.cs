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
    /// Class for setting and retrieving entries on the database
    /// </summary>
    public static class EntriesHandler
    {
        // Returns all entries from "purchases" table in database
        // filterSpecificType parameters can accept "ALL" or null if you want all types to be displayed
        public static DataTable GetEntries(DateTime startDate, DateTime endDate, string filterSpecificType)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string query = "SELECT entry_date AS 'Date', type AS 'Type', name AS 'Name', amount AS 'Amount' " +
                "FROM entries;";

            if (filterSpecificType != "All" && filterSpecificType != null)
            {
                query += " AND purchases.type_idx = (SELECT types.type_idx FROM types WHERE types.name = @type_filter)";
            }

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.Add(new SQLiteParameter("@start_date", startDate.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SQLiteParameter("@end_date", endDate.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SQLiteParameter("@type_filter", filterSpecificType));

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            con.Close();
            return dt;
        }

        // Add new entry to the database
        public static void AddNewEntry(Entry entry)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryInsert = "INSERT INTO entries Values(@date, @type, @name, @amount)";

            SQLiteCommand insertToDb = new SQLiteCommand(queryInsert, con);
            insertToDb.Parameters.Add(new SQLiteParameter("@date", entry._date.ToString("yyyy-MM-dd")));
            insertToDb.Parameters.Add(new SQLiteParameter("@type", entry._type));
            insertToDb.Parameters.Add(new SQLiteParameter("@name", entry._name));
            insertToDb.Parameters.Add(new SQLiteParameter("@amount", entry._amount));
            try
            {
                insertToDb.ExecuteNonQuery();
            }
            catch (SQLiteException)
            {
                DialogResult existingEntryError = MessageBox.Show("Entry matches an existing entry", 
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            con.Close();
        }

        // Edit an entry to the database
        public static void EditEntry(Entry selectedEntry, Entry newEntry)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryUpdate = "UPDATE entries " +
                "SET entry_date = @new_date, type = @new_type, name = @new_name, amount = @new_amount " +
                "WHERE entry_date = @old_date AND type = @old_type AND name = @old_name AND amount = @old_amount";

            SQLiteCommand updateToDb = new SQLiteCommand(queryUpdate, con);
            updateToDb.Parameters.AddWithValue("@new_date", newEntry._date.ToString("yyyy-MM-dd"));
            updateToDb.Parameters.AddWithValue("@new_type", newEntry._type);
            updateToDb.Parameters.AddWithValue("@new_name", newEntry._name);
            updateToDb.Parameters.AddWithValue("@new_amount", newEntry._amount);

            updateToDb.Parameters.AddWithValue("@old_date", selectedEntry._date.ToString("yyyy-MM-dd"));
            updateToDb.Parameters.AddWithValue("@old_type", selectedEntry._type);
            updateToDb.Parameters.AddWithValue("@old_name", selectedEntry._name);
            updateToDb.Parameters.AddWithValue("@old_amount", selectedEntry._amount);

            updateToDb.ExecuteNonQuery();
            con.Close();
        }

        // Delete an entry in the database
        public static void DeleteEntry(Entry entry)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryDelete = "DELETE FROM entries \r\n" +
                "WHERE entry_date = @date AND name = @name AND " +
                "amount = @amount AND " +
                "type = @type";

            SQLiteCommand deleteRowDb = new SQLiteCommand(queryDelete, con);
            deleteRowDb.Parameters.AddWithValue("@date", entry._date.ToString("yyyy-MM-dd"));
            deleteRowDb.Parameters.AddWithValue("@name", entry._name);
            deleteRowDb.Parameters.AddWithValue("@amount", entry._amount);
            deleteRowDb.Parameters.AddWithValue("@type", entry._type);

            // Delete row from query
            deleteRowDb.ExecuteNonQuery();

            con.Close();
        }

        /// <summary>
        /// Adds entries from the subscription from last opened
        /// </summary>
        public static void AddEntryFromSubscriptions()
        {
            
        }
    }
}
