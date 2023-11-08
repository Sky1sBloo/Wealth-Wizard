using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wealth_Wizard.Properties;

namespace Wealth_Wizard.Handlers
{
    /// <summary>
    /// Class for setting and retrieving entries on the database
    /// </summary>
    public static class EntriesHandler
    {
        /// <summary>
        /// Returns all entries from "purchases" table in database
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="filterSpecificType">
        /// can accept "ALL" or null if you want all types to be displayed
        /// </param>
        /// <returns>Returns a DataTable containing the entries</returns>
        public static DataTable GetEntriesAsTable(DateTime startDate, DateTime endDate, string filterSpecificType = null)
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

        /// <summary>
        /// Returns all entries from "purchases" table in database
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="filterSpecificType">
        /// can accept "ALL" or null if you want all types to be displayed
        /// </param>
        /// <returns>Returns a List containing the entries</returns>
        public static List<Entry> GetEntries(DateTime startDate, DateTime endDate, string filterSpecificType = null)
        { 
            List<Entry> selectedEntries = new List<Entry>();
            foreach (DataRow row in GetEntriesAsTable(startDate, endDate, filterSpecificType).Rows)
            {
                Entry selectedEntry = new Entry(
                    row.Field<DateTime>("entry_date"),
                    row.Field<string>("type"),
                    row.Field<string>("name"),
                    (float)row.Field<double>("amount")
                    );

                selectedEntries.Add(selectedEntry);
            }
            return selectedEntries;
        }
        

        /// <summary>
        /// Creates a new entry on the database on tables entries
        /// </summary>
        /// <param name="entry"></param>
        /// <exception cref="Exception"></exception>
        public static void AddNewEntry(Entry entry)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryInsert = "INSERT INTO entries Values(@date, @type, @name, @amount)";

            SQLiteCommand insertToDb = new SQLiteCommand(queryInsert, con);
            insertToDb.Parameters.Add(new SQLiteParameter("@date", entry.Date.ToString("yyyy-MM-dd")));
            insertToDb.Parameters.Add(new SQLiteParameter("@type", entry.Type));
            insertToDb.Parameters.Add(new SQLiteParameter("@name", entry.Name));
            insertToDb.Parameters.Add(new SQLiteParameter("@amount", entry.Amount));

            insertToDb.ExecuteNonQuery();

            con.Close();
        }

        /// <summary>
        /// Modifies an entry on the database
        /// </summary>
        /// <param name="selectedEntry">Entry to be changed</param>
        /// <param name="newEntry">New values of the entry</param>
        public static void EditEntry(Entry selectedEntry, Entry newEntry)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryUpdate = "UPDATE entries " +
                "SET entry_date = @new_date, type = @new_type, name = @new_name, amount = @new_amount " +
                "WHERE entry_date = @old_date AND type = @old_type AND name = @old_name AND amount = @old_amount";

            SQLiteCommand updateToDb = new SQLiteCommand(queryUpdate, con);
            updateToDb.Parameters.AddWithValue("@new_date", newEntry.Date.ToString("yyyy-MM-dd"));
            updateToDb.Parameters.AddWithValue("@new_type", newEntry.Type);
            updateToDb.Parameters.AddWithValue("@new_name", newEntry.Name);
            updateToDb.Parameters.AddWithValue("@new_amount", newEntry.Amount);

            updateToDb.Parameters.AddWithValue("@old_date", selectedEntry.Date.ToString("yyyy-MM-dd"));
            updateToDb.Parameters.AddWithValue("@old_type", selectedEntry.Type);
            updateToDb.Parameters.AddWithValue("@old_name", selectedEntry.Name);
            updateToDb.Parameters.AddWithValue("@old_amount", selectedEntry.Amount);

            updateToDb.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Removes an entry on the database
        /// </summary>
        /// <param name="entry"></param>
        public static void DeleteEntry(Entry entry)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryDelete = "DELETE FROM entries \r\n" +
                "WHERE entry_date = @date AND name = @name AND " +
                "amount = @amount AND " +
                "type = @type";

            SQLiteCommand deleteRowDb = new SQLiteCommand(queryDelete, con);
            deleteRowDb.Parameters.AddWithValue("@date", entry.Date.ToString("yyyy-MM-dd"));
            deleteRowDb.Parameters.AddWithValue("@name", entry.Name);
            deleteRowDb.Parameters.AddWithValue("@amount", entry.Amount);
            deleteRowDb.Parameters.AddWithValue("@type", entry.Type);

            deleteRowDb.ExecuteNonQuery();

            con.Close();
        }

        /// <summary>
        /// Checks if an entry exists in the database
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public static bool EntryExists(Entry entry)
        {
            return GetEntries(entry.Date, entry.Date).Count == 0;
        }

        /// <summary>
        /// Adds entries from the subscription from last opened
        /// </summary>
        public static void AddEntriesFromSubscriptions()
        {
            foreach (Subscription sub in SubscriptionsHandler.GetAllSubscriptions())
            {
                TimeSpan timeSinceLastOpened = SystemClock.Now.Subtract(Settings.Default.LastOpened);

                switch (sub.BillingCycle)
                {
                    case "Daily":
                        for (int i = 0; i < timeSinceLastOpened.Days; i++)
                        {
                            DateTime newSubDate = Settings.Default.LastOpened.AddDays(i);
                            if (sub.EndDate < newSubDate) return;

                            Entry subEntry = new Entry(
                                newSubDate,
                                sub.Type, sub.Name, sub.Amount);

                            try
                            {
                                AddNewEntry(subEntry);
                            }
                            catch (SQLiteException)
                            {
                                continue;
                            }
                        }
                        break;
                    case "Weekly":
                        for (int i = 0; i < timeSinceLastOpened.Days / 7; i += 7)
                        {
                            DateTime newSubDate = Settings.Default.LastOpened.AddDays(i);
                            if (sub.EndDate < newSubDate) return;

                            Entry subEntry = new Entry(
                                newSubDate,
                                sub.Type, sub.Name, sub.Amount);
                            try
                            {
                                AddNewEntry(subEntry);
                            }
                            catch (SQLiteException)
                            {
                                continue;
                            }
                        }
                        break;
                    case "Monthly":
                        
                        break;
                    case "Yearly":
                        for (int i = 0; i <= SystemClock.Now.Year - Settings.Default.LastOpened.Year; i++)
                        {
                            DateTime newSubDate = sub.StartDate.AddYears(i);
                            if (SystemClock.Now < newSubDate) return;

                            Entry subEntry = new Entry(
                                newSubDate,
                                sub.Type, sub.Name, sub.Amount);

                            try
                            {
                                AddNewEntry(subEntry);
                            }
                            catch (SQLiteException)
                            {
                                continue;
                            }
                        }
                        break;
                }
            }
        }
    }
}
