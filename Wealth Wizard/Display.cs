using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Wealth_Wizard
{
    public partial class Display : Form
    {
        int entrySelectionRowIndex = 0;
        string selectedFilterType;

        public Display()
        {
            InitializeComponent();
            DatabaseHandler.databaseLocation = @"data source=C:\Users\james\AppData\Roaming\SQLite 3\wealth_wizard.db";
            // Initialize defaults
            ComboB_FilterPreset.SelectedIndex = 0;

            // Get all entry types from database
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
                // Iterate through each database name and add it to the ComboBox
                ComboB_EntryType.Items.Add(row["name"].ToString());
                ComboB_FilterType.Items.Add(row["name"].ToString());
            }
            ComboB_FilterType.Items.Add("All");
            ComboB_FilterType.SelectedIndex = ComboB_FilterType.Items.Count - 1;

            con.Close();


            // Display all entries
            DisplayPurchases();
        }

        // Display purchases on the table with the filters
        public void DisplayPurchases()
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
            if (selectedFilterType != "All" &&  selectedFilterType != null)
            {
                // Add this condition to query to filter a specific type
                query += " AND purchases.type_idx = (SELECT types.type_idx FROM types WHERE types.name = @type_filter)";
            }

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.Add(new SQLiteParameter("@start_date", DatePick_FilterStartDate.Value.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SQLiteParameter("@end_date", DatePick_FilterEndDate.Value.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SQLiteParameter("@type_filter", selectedFilterType));

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);  // Execute command and return the results
            adapter.Fill(dt);

            DataGridV_Display.DataSource = dt;
            con.Close();
        }

        // Add new entry to the database
        public void AddNewEntry(DateTime date, string type, string name, float amount)
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

        // Delete a database row
        public void DeleteRowEntry(int rowIndex)
        {
            // Check if you have something to delete
            if (DataGridV_Display.Rows.Count == 0)
            {
                MessageBox.Show("No row has been selected for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Store selected row into variables
            DataRow selectedRow = ((DataRowView)DataGridV_Display.Rows[rowIndex].DataBoundItem).Row;
            DateTime selectedDate = selectedRow.Field<DateTime>("Date");
            string selectedType = selectedRow.Field<string>("Types");
            string selectedName = selectedRow.Field<string>("Name");
            double selectedAmount = selectedRow.Field<double>("Amount");

            DialogResult deleteChoice = MessageBox.Show("Would you want to delete " + selectedDate.ToString("yyyy/MM/dd") + " "+ selectedName + "?", "Warning", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            // Create final warning
            if (deleteChoice == DialogResult.Cancel || deleteChoice == DialogResult.No) return;

            // Open connection to database
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            // LMAO I actually made the edit query rather than the delete xD
            // Insert the data to database
            /*
            string queryUpdate = "UPDATE purchases" +
                "SET purchase_date = @new_date, type_idx = @new_type_idx, name = @new_name, amount = @new_amount" +
                "WHERE purchases.purchase_date = @old_date AND purchases.name = @old_name AND " +
                "purchases.amount = @old_amount AND" +
                "purchases.type_idx = (" +
                "SELECT types.type_idx" +
                "FROM types" +
                "WHERE types.name = @old_type_name)";
            SQLiteCommand updateToDatabase = new SQLiteCommand(queryUpdate, con); */

            // Create query for deletion
            string queryDelete = "DELETE FROM purchases \r\n" +
                "WHERE purchases.purchase_date = @date AND purchases.name = @name AND " +
                "purchases.amount = @amount AND " +
                "purchases.type_idx = (" +
                "SELECT types.type_idx " +
                "FROM types " +
                "WHERE types.name = @type_name)";
            
            SQLiteCommand deleteRowDb = new SQLiteCommand(queryDelete, con);
            deleteRowDb.Parameters.Add(new SQLiteParameter("@date", selectedDate.ToString("yyyy-MM-dd")));
            deleteRowDb.Parameters.Add(new SQLiteParameter("@name", selectedName));
            deleteRowDb.Parameters.Add(new SQLiteParameter("@amount", selectedAmount));
            deleteRowDb.Parameters.Add(new SQLiteParameter("@type_name", selectedType));

            // Delete row from query
            deleteRowDb.ExecuteNonQuery();

            con.Close();
        }

        private void RefreshBtn_Clicked(object sender, EventArgs e)
        {
            DisplayPurchases();
        }

        // Update the date time filters
        private void _SetFilter(object sender, EventArgs e)
        {
            ComboBox filterPreset = (ComboBox)sender;

            DateTime startDate;
            DateTime endDate;

            switch (filterPreset.SelectedIndex)
            {
                case 0:
                    // Get current year
                    startDate = new DateTime(DateTime.Now.Year, 1, 1);
                    endDate = new DateTime(DateTime.Now.Year, 12, 31);
                    break;
                case 1:
                    // Get current month
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
                        DateTime.DaysInMonth(startDate.Year, startDate.Month));
                    break;
                case 2:
                    // Get current week
                    startDate = DateTime.Now.AddDays(DayOfWeek.Sunday - DateTime.Now.DayOfWeek);
                    endDate = startDate.AddDays(7);
                    break;
                default:
                    startDate = DatePick_FilterStartDate.Value;
                    endDate = DatePick_FilterEndDate.Value;
                    break;
            }

            DatePick_FilterStartDate.Value = startDate;
            DatePick_FilterEndDate.Value = endDate;
        }

        // Refresh the page
        private void DateUpdated(object sender, EventArgs e)
        {
            DisplayPurchases();
        }

        // Add button click
        private void Btn_AddEntry_Click(object sender, EventArgs e)
        {
            // Final amount for negative handling of expenses
            float finalAmount = (float)NumTxtB_EntryAmount.Value;
            if (ChkB_Expenses.Checked) finalAmount *= -1;
            AddNewEntry(DatePick_EntryDate.Value, ComboB_EntryType.Text, TxtB_EntryName.Text, finalAmount);
            DisplayPurchases();  // Refresh table
        }

        // Delete selected row
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteRowEntry(entrySelectionRowIndex);
            DisplayPurchases();
        }

        // Alternate between expenses and income
        private void ChkB_Expenses_CheckedChanged(object sender, EventArgs e)
        {
            ChkB_Income.Checked = false;
        }
        private void ChkB_Income_CheckedChanged(object sender, EventArgs e)
        {
            ChkB_Expenses.Checked = false;
        }

        // Updates the row of the current selection
        private void SetCurrentSelection(object sender, EventArgs e)
        {
            if (DataGridV_Display.CurrentCell == null) return;
            entrySelectionRowIndex = DataGridV_Display.CurrentCell.RowIndex;
        }

        private void ComboB_FilterType_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedFilterType = ComboB_FilterType.SelectedItem.ToString();
        }

        private void PreferencesMenu_Click(object sender, EventArgs e)
        {
            Preferences preferenceWindow = new Preferences();
            preferenceWindow.Show();
        }
    }
}
