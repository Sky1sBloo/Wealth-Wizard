using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wealth_Wizard
{
    public static class DatabaseHandler
    {
        public static string databaseLocation;

        // Returns all entries from "purchases" table in database
        // filterSpecificType parameters can accept "ALL" or null if you want all types to be displayed
        public static DataTable GetEntries(DateTime startDate, DateTime endDate, string filterSpecificType)
        {
            // Check if filter type is not null
            // Conenct to database
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            // Query object
            string query = "SELECT purchases.purchase_date AS 'Date', types.name AS Types, \r\n" +
                "purchases.name AS Name, purchases.amount As 'Amount' \r\n" +
                "FROM purchases \r\n" +
                "JOIN types \r\n" +
                "ON types.type_idx = purchases.type_idx\r\n" +
                "WHERE purchases.purchase_date BETWEEN @start_date AND @end_date";

            // Filter type is not ALL (which is alwys the size of the combobox - 1)
            if (filterSpecificType != "All" && filterSpecificType != null)
            {
                // Add this condition to query to filter a specific type
                query += " AND purchases.type_idx = (SELECT types.type_idx FROM types WHERE types.name = @type_filter)";
            }

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.Add(new SQLiteParameter("@start_date", startDate.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SQLiteParameter("@end_date", endDate.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SQLiteParameter("@type_filter", filterSpecificType));

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);  // Execute command and return the results
            adapter.Fill(dt);

            con.Close();
            return dt;
        }

        // Add new entry to the database
        public static void AddNewEntry(DateTime date, string type, string name, float amount)
        {
            // Required variables
            object typeIdx;

            // Conenct to database
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string querySelect = "SELECT type_idx FROM types WHERE name='" + type + "'";
            SQLiteCommand cmd = new SQLiteCommand(querySelect, con);
            DataTable entryTypeName = new DataTable();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd);

            dataAdapter.Fill(entryTypeName);

            typeIdx = entryTypeName.Rows[0][0];

            // Insert into database
            string queryInsert = "INSERT INTO purchases Values(@date, @type_idx, @name, @amount)";

            SQLiteCommand insertToDb = new SQLiteCommand(queryInsert, con);
            insertToDb.Parameters.Add(new SQLiteParameter("@date", date.ToString("yyyy-MM-dd")));
            insertToDb.Parameters.Add(new SQLiteParameter("@type_idx", typeIdx));
            insertToDb.Parameters.Add(new SQLiteParameter("@name", name));
            insertToDb.Parameters.Add(new SQLiteParameter("@amount", amount));
            try
            {
                insertToDb.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            con.Close();
        }

        // Delete an entry in the database
        public static void DeleteEntry(DateTime date,  string type, string name, double amount)
        {
            // Open connection to database
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            // Create query for deletion
            string queryDelete = "DELETE FROM purchases \r\n" +
                "WHERE purchases.purchase_date = @date AND purchases.name = @name AND " +
                "purchases.amount = @amount AND " +
                "purchases.type_idx = (" +
                "SELECT types.type_idx " +
                "FROM types " +
                "WHERE types.name = @type_name)";

            SQLiteCommand deleteRowDb = new SQLiteCommand(queryDelete, con);
            deleteRowDb.Parameters.Add(new SQLiteParameter("@date", date.ToString("yyyy-MM-dd")));
            deleteRowDb.Parameters.Add(new SQLiteParameter("@name", name));
            deleteRowDb.Parameters.Add(new SQLiteParameter("@amount", amount));
            deleteRowDb.Parameters.Add(new SQLiteParameter("@type_name", type));

            // Delete row from query
            deleteRowDb.ExecuteNonQuery();

            con.Close();
        }

        // Returns the entry type names
        public static List<string> GetEntryTypes()
        {
            List<string> entryTypes = new List<string>();

            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();
            string query = "SELECT name\r\n" +
                "FROM types";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            DataTable types = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(types);

            foreach (DataRow row in types.Rows)
            {
                entryTypes.Add(row["name"].ToString());
            }

            con.Close();
            return entryTypes;
        }
    }
}
