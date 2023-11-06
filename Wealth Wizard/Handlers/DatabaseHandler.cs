using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wealth_Wizard.Handlers
{
    /// <summary>
    /// A utility class for managing SQLite databases and performing database operations.
    /// </summary>
    public static class DatabaseHandler
    {
        /// <summary>
        /// Location of the SQLite database file.
        /// </summary>
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

        /// <summary>
        /// Creates a new SQLite database with the specified name and location.
        /// </summary>
        /// <param name="name">Name of the database.</param>
        /// <param name="fileLocation">File location where the database will be created.</param>
        /// <param name="openDatabase">Flag to load the database after creating.</param>
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
                "start_date DATE NOT NULL, " +
                "end_date DATE, " +
                "entry_type VARCHAR(30), " +
                "name VARCHAR(30), " +
                "amount FLOAT, " + 
                "billing_cycle VARCHAR(30), " +
                "PRIMARY KEY (entry_type, name, amount, billing_cycle), " +
                "FOREIGN KEY (entry_type) REFERENCES entry_type(types) ON DELETE SET NULL)";

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

        /// <summary>
        /// Retrieves all the values from a specified table and returns them in a DataTable.
        /// </summary>
        /// <param name="tableName">Name of the table to retrieve data from.</param>
        /// <returns>A DataTable containing the retrieved data.</returns>
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

        /// <summary>
        /// Retrieves specific values from a table based on columns and conditions and returns them in a DataTable.
        /// </summary>
        /// <param name="tableName">Name of the table to retrieve data from.</param>
        /// <param name="columns">Array of columns to select (optional). 
        /// You can create custom names of the column by {'column_name AS 'Column New Name'}
        /// </param>
        /// <param name="conditions">Conditions for filtering (optional).
        /// Conditions are query based and are in SQL Langfuage
        /// </param>
        /// <returns>A DataTable containing the retrieved data.</returns>
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

        /// <summary>
        /// Retrieves the number of rows in a table based on columns and conditions.
        /// </summary>
        /// <param name="tableName">Name of the table to count rows from.</param>
        /// <param name="columns">Array of columns to count (optional).</param>
        /// <param name="conditions">Conditions for filtering (optional).</param>
        /// <returns>The number of rows that meet the specified criteria.</returns>
        public static int GetNumberOfRowsOnTable(string tableName, string[] columns = null, string conditions = null)
        {
            string columnQuery = "*";
            string querySelection = "SELECT COUNT(@columns) FROM " + tableName;

            if (columns != null)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    if (i == 0) columnQuery = columns[i];
                    else columnQuery += ", " + columns[i];
                }
            }

            if (conditions != null)
            {
                querySelection += "\r\n WHERE @conditions";
            }

            SQLiteConnection con = new SQLiteConnection(databaseLocation);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(querySelection, con);
            cmd.Parameters.Add(new SQLiteParameter("@columns", columnQuery));
            cmd.Parameters.Add(new SQLiteParameter("@conditions", conditions));

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return count;
        }

        /// <summary>
        /// Deletes selected rows from a specified database table based on optional conditions.
        /// </summary>
        /// <param name="tableName">Name of the table from which rows will be deleted.</param>
        /// <param name="conditions">Optional conditions for row deletion. If not specified, all rows in the table will be deleted.</param>
        public static void DeleteRowFromTable(string tableName, string conditions = null)
        {
            string deleteQuery = "DELETE * FROM @table_name";
            if (conditions != null)
            {
                deleteQuery += " WHERE @conditions";
            }

            SQLiteConnection con = new SQLiteConnection(databaseLocation);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(deleteQuery, con);
            cmd.Parameters.AddWithValue("@table_name", tableName);
            cmd.Parameters.AddWithValue("@conditions", conditions);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
