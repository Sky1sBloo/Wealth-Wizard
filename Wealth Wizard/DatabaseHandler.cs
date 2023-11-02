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

        // Returns all the values from the specified table
        public static DataTable GetAllValuesFromTable(string tableName)
        {
            // Result variable
            DataTable result = new DataTable();

            // Open database
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string querySelect = "SELECT * FROM " + tableName;
            SQLiteCommand cmd = new SQLiteCommand(querySelect, con);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(result);

            con.Close();

            return result;
        }

        // Get values from the table that can be specified by columns and conditions
        // Columns can be used like: column AS type
        // Conditions are query based
        public static DataTable GetValuesFromTable(string tableName, string[] columns = null, string conditions = null)
        {
            // 
            string columnQuery = "*";
            string querySelection = "SELECT @columns FROM " + tableName;

            // Get return columns
            for (int i = 0; i < columns.Length; i++)
            {
                if (i == 0) columnQuery = columns[i];
                else columnQuery += ", " + columns[i];
            }

            if (conditions != null) querySelection += "\r\n WHERE @conditions";

            // Open the database
            SQLiteConnection con = new SQLiteConnection(databaseLocation);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(querySelection, con);
            cmd.Parameters.Add(new SQLiteParameter("@columns", columnQuery));
            cmd.Parameters.Add(new SQLiteParameter("@conditions", conditions));

            con.Close();
            return null;
        }

        // Returns all entries from "purchases" table in database
        // filterSpecificType parameters can accept "ALL" or null if you want all types to be displayed
        public static DataTable GetEntries(DateTime startDate, DateTime endDate, string filterSpecificType)
        {
            // Check if filter type is not null
            // Conenct to database
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            // Query object
            string query = "SELECT entry_date AS 'Date', type AS 'Type', name AS 'Name', amount AS 'Amount' " +
                "FROM entries;";

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
            // Conenct to database
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            // Insert into database
            string queryInsert = "INSERT INTO entries Values(@date, @type, @name, @amount)";

            SQLiteCommand insertToDb = new SQLiteCommand(queryInsert, con);
            insertToDb.Parameters.Add(new SQLiteParameter("@date", date.ToString("yyyy-MM-dd")));
            insertToDb.Parameters.Add(new SQLiteParameter("@type", type));
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
            string queryDelete = "DELETE FROM entries \r\n" +
                "WHERE entry_date = @date AND name = @name AND " +
                "amount = @amount AND " +
                "type = @type";

            SQLiteCommand deleteRowDb = new SQLiteCommand(queryDelete, con);
            deleteRowDb.Parameters.Add(new SQLiteParameter("@date", date.ToString("yyyy-MM-dd")));
            deleteRowDb.Parameters.Add(new SQLiteParameter("@name", name));
            deleteRowDb.Parameters.Add(new SQLiteParameter("@amount", amount));
            deleteRowDb.Parameters.Add(new SQLiteParameter("@type", type));

            // Delete row from query
            deleteRowDb.ExecuteNonQuery();

            con.Close();
        }

        // Entry types
        // Returns all entry type names
        public static List<string> GetEntryTypes()
        {
            List<string> entryTypes = new List<string>();

            foreach (DataRow row in GetAllValuesFromTable("entry_types").Rows)
            {
                entryTypes.Add(row["types"].ToString());
            }

            return entryTypes;
        }

        // Deletes the specific entry type on the database
        public static void DeleteEntryTypes(string type)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryDelete = "DELETE FROM entry_types \r\n" +
                "WHERE types = @type";

            SQLiteCommand cmd = new SQLiteCommand(queryDelete, con);
            cmd.Parameters.Add(new SQLiteParameter("@type", type));
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
