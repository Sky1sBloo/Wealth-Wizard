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


            // Create 2 tables: "entries" and "entry_types"
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
        public static void AddNewEntry(Entry entry)
        {
            // Conenct to database
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            // Insert into database
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

            // Create query command and fill parameters
            SQLiteCommand updateToDb = new SQLiteCommand(queryUpdate, con);
            updateToDb.Parameters.AddWithValue("@new_date", newEntry._date.ToString("yyyy-MM-dd"));
            updateToDb.Parameters.AddWithValue("@new_type", newEntry._type);
            updateToDb.Parameters.AddWithValue("@new_name", newEntry._name);
            updateToDb.Parameters.AddWithValue("@new_amount", newEntry._amount);

            updateToDb.Parameters.AddWithValue("@old_date", selectedEntry._date.ToString("yyyy-MM-dd"));
            updateToDb.Parameters.AddWithValue("@old_type", selectedEntry._type);
            updateToDb.Parameters.AddWithValue("@old_name", selectedEntry._name);
            updateToDb.Parameters.AddWithValue("@old_amount", selectedEntry._amount);

            // Execute the query
            updateToDb.ExecuteNonQuery();
            con.Close();
        }

        // Delete an entry in the database
        public  static void DeleteEntry(Entry entry)
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
            deleteRowDb.Parameters.AddWithValue("@date", entry._date.ToString("yyyy-MM-dd"));
            deleteRowDb.Parameters.AddWithValue("@name", entry._name);
            deleteRowDb.Parameters.AddWithValue("@amount", entry._amount);
            deleteRowDb.Parameters.AddWithValue("@type", entry._type);

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
