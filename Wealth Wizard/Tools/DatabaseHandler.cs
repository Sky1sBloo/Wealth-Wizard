using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wealth_Wizard
{
    public static class DatabaseHandler
    {
        // In the future check if database location exists
        public static string databaseLocation;

        public static string[] defaultEntryTypes = {
            "Personal Needs",
            "Utilities",
            "Healthcare",
            "School",
            "Groceries",
            "Vehicle Expenses",
            "Household Repair",
            "Entertainment",
            "Salary",
            "Miscellaneous"
        };
        public static string[] defaultBillingCycles =
        {
            "Daily",
            "Weekly",
            "Monthly",
            "Yearly"
        };

        // Creates a new database
        public static void CreateDatabase(string name, string fileLocation, bool openDatabase = false)
        {
            SQLiteConnection.CreateFile(fileLocation + "\\" + name + ".wwiz");

            // Create the table
            string sqlitePath = @"data source=" + fileLocation + "\\" + name + ".wwiz";
            SQLiteConnection con = new SQLiteConnection(sqlitePath);

            if (openDatabase) { databaseLocation = sqlitePath; }

            con.Open();
            string queryCreateEntriesTable = "CREATE TABLE entries( " +
                "entry_date DATE NOT NULL, " +
                "type VARCHAR(30), " +
                "name VARCHAR(30), " +
                "amount FLOAT, " +
                "PRIMARY KEY(entry_date, type, name), " +
                "FOREIGN KEY(type) REFERENCES entry_types(types) ON DELETE SET NULL)";

            string queryCreateEntryTypesTable = "CREATE TABLE entry_types( " +
                "types VARCHAR(30) PRIMARY KEY NOT NULL)";

            string queryCreateSubscriptionsTable = "CREATE TABLE subscriptions(" +
                "entry_date DATE NOT NULL, " +
                "entry_type VARCHAR(30), " +
                "name VARCHAR(30), " +
                "amount FLOAT, " + 
                "billing_cycle VARCHAR(30), " +
                "PRIMARY KEY (entry_type, entry_type, name, amount), " +
                "FOREIGN KEY (entry_type) REFERENCES entry_type(types) ON DELETE SET NULL)";

            // Create 3 tables: "entries", "entry_types", and "subscriptions"
            SQLiteCommand cmd = new SQLiteCommand(queryCreateEntryTypesTable, con);
            cmd.ExecuteNonQuery();

            cmd = new SQLiteCommand(queryCreateEntriesTable, con);
            cmd.ExecuteNonQuery();

            // Insert default entry types
            foreach (string entryType in defaultEntryTypes)
            {
                string insertQuery = "INSERT INTO entry_types VALUES (@type)";
                cmd = new SQLiteCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@type", entryType);
                cmd.ExecuteNonQuery();
            }

            cmd = new SQLiteCommand(queryCreateSubscriptionsTable, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

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
            string columnQuery = "*";
            
            // This condition checks if the user wants to return a specific column
            if (columns != null)
            {
                // Get return columns
                for (int i = 0; i < columns.Length; i++)
                {
                    if (i == 0) columnQuery = columns[i];
                    else columnQuery += ", " + columns[i];
                }
            }

            string querySelection = "SELECT " + columnQuery + " FROM " + tableName;

            if (conditions != null) querySelection += "\r\n WHERE " + conditions;

            // Open the database
            SQLiteConnection con = new SQLiteConnection(databaseLocation);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(querySelection, con);

            DataTable dataTable = new DataTable();
            SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
            sQLiteDataAdapter.Fill(dataTable);

            con.Close();
            return dataTable;
        }

        // Returns the number of count
        public static int GetNumberOfRowsOnTable(string tableName, string[] columns = null, string conditions = null)
        {
            string columnQuery = "*";
            string querySelection = "SELECT COUNT(@columns) FROM " + tableName;

            // This condition checks if the user wants to return a specific column
            if (columns != null)
            {
                // Get return columns
                for (int i = 0; i < columns.Length; i++)
                {
                    if (i == 0) columnQuery = columns[i];
                    else columnQuery += ", " + columns[i];
                }
            }

            // This condition checks if the user wants to add any conditions
            if (conditions != null)
            {
                querySelection += "\r\n WHERE @conditions";
            }

            // Open the database
            SQLiteConnection con = new SQLiteConnection(databaseLocation);
            con.Open();

            // Create the command
            SQLiteCommand cmd = new SQLiteCommand(querySelection, con);
            cmd.Parameters.Add(new SQLiteParameter("@columns", columnQuery));
            cmd.Parameters.Add(new SQLiteParameter("@conditions", conditions));

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return count;
        }

        // Deletes selected items on table
        public static void DeleteRowFromTable(string tableName, string conditions = null)
        {
            string deleteQuery = "DELETE * FROM @table_name";
            if (conditions != null)
            {
                deleteQuery += " WHERE @conditions";
            }

            // Open the database
            SQLiteConnection con = new SQLiteConnection(databaseLocation);
            con.Open();

            // Create the delete command
            SQLiteCommand cmd = new SQLiteCommand(deleteQuery, con);
            cmd.Parameters.AddWithValue("@table_name", tableName);
            cmd.Parameters.AddWithValue("@conditions", conditions);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
