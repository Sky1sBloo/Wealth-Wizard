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

            // Set combo boxes items
            foreach (string entryType in DatabaseHandler.GetEntryTypes())
            {
                ComboB_EntryType.Items.Add(entryType);
                ComboB_FilterType.Items.Add(entryType);
            }
            ComboB_FilterType.Items.Add("All");

            // Set the default values of the combo boxes
            ComboB_FilterType.SelectedIndex = ComboB_FilterType.Items.Count - 1;
            if (ComboB_EntryType.Items.Count != 0) ComboB_EntryType.SelectedIndex = 0;

            // Display all entries
            DisplayEntries();
        }

        // Display purchases on the table with the filters
        public void DisplayEntries()
        {
            DataGridV_Display.DataSource = DatabaseHandler.GetEntries(DatePick_FilterStartDate.Value,
                DatePick_FilterEndDate.Value, selectedFilterType);
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
            string selectedType = selectedRow.Field<string>("Type");
            string selectedName = selectedRow.Field<string>("Name");
            double selectedAmount = selectedRow.Field<double>("Amount");  // Needed to use double since somehow the datatable type is float

            Entry entryToBeDeleted = new Entry(selectedDate, selectedType, selectedName, (float)selectedAmount);

            DialogResult deleteChoice = MessageBox.Show("Would you want to delete entry: " + selectedDate.ToString("yyyy/MM/dd") + ", "+ selectedName + "?", "Warning", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Create final warning
            if (deleteChoice == DialogResult.No) return;

            // Delete the entry in the database handler
            
            DatabaseHandler.DeleteEntry(entryToBeDeleted);
        }

        private void RefreshBtn_Clicked(object sender, EventArgs e)
        {
            DisplayEntries();
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
            DisplayEntries();
        }

        // Add button click
        private void Btn_AddEntry_Click(object sender, EventArgs e)
        {
            // IN THE FUTURE, ENSURE THAT YOU CHECK IF SOME SPACES ARE BLANK
            // Check if some of the input fields are empty
            if (TxtB_EntryName.Text == "")
            {
                MessageBox.Show("Add Entry Error, 'Name' field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Logic for expenses or income
            float finalAmount = (float)NumTxtB_EntryAmount.Value;
            if (ChkB_Expenses.Checked) finalAmount *= -1;

            Entry newEntry = new Entry(DatePick_EntryDate.Value, ComboB_EntryType.Text, TxtB_EntryName.Text, finalAmount);
            DatabaseHandler.AddNewEntry(newEntry);
            DisplayEntries();  // Refresh table
        }

        // Edit entry
        private void Btn_EditEntry_Click(object sender, EventArgs e)
        {
            // Check if you have any selection
            if (DataGridV_Display.Rows.Count == 0)
            {
                MessageBox.Show("No row has been selected for editing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get old values
            DataRow selectedRow = ((DataRowView)DataGridV_Display.Rows[entrySelectionRowIndex].DataBoundItem).Row;
            Entry selectedEntry = new Entry(selectedRow.Field<DateTime>("Date"),
                selectedRow.Field<string>("Type"),
                selectedRow.Field<string>("Name"),
                (float)selectedRow.Field<double>("Amount"));

            EditEntry editEntryForm = new EditEntry(selectedEntry);
            editEntryForm.ShowDialog();

            // Check if the entry is accepted
            if (editEntryForm.DialogResult == DialogResult.OK)
            {
                editEntryForm.Close();
                // Store new values
                Entry newEntry = editEntryForm.GetEntryValues();

                // Edit the database
                DatabaseHandler.EditEntry(selectedEntry, newEntry);
            }
            else if (editEntryForm.DialogResult == DialogResult.Cancel)
            {
                editEntryForm.Close();
            }

            // Refresh the table
            DisplayEntries();
        }

        // Delete selected row
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteRowEntry(entrySelectionRowIndex);
            DisplayEntries();
        }

        // Alternate between expenses and income
        private void ChkB_Expenses_CheckedChanged(object sender, EventArgs e)
        {
            ChkB_Income.Checked = !ChkB_Expenses.Checked;
        }
        private void ChkB_Income_CheckedChanged(object sender, EventArgs e)
        {
            ChkB_Expenses.Checked = !ChkB_Income.Checked;
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
            preferenceWindow.ShowDialog();
        }
    }
}
