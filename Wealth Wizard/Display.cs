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

            // Set combo boxes selections and feault values
            foreach (string entryType in DatabaseHandler.GetEntryTypes())
            {
                ComboB_EntryType.Items.Add(entryType);
                ComboB_FilterType.Items.Add(entryType);
            }
            ComboB_FilterType.Items.Add("All");
            ComboB_FilterType.SelectedIndex = ComboB_FilterType.Items.Count - 1;
            ComboB_EntryType.SelectedIndex = 0;

            // Display all entries
            DisplayPurchases();
        }

        // Display purchases on the table with the filters
        public void DisplayPurchases()
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
            string selectedType = selectedRow.Field<string>("Types");
            string selectedName = selectedRow.Field<string>("Name");
            double selectedAmount = selectedRow.Field<double>("Amount");

            DialogResult deleteChoice = MessageBox.Show("Would you want to delete " + selectedDate.ToString("yyyy/MM/dd") + " "+ selectedName + "?", "Warning", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Create final warning
            if (deleteChoice == DialogResult.No) return;

            // Delete the entry in the database handler
            DatabaseHandler.DeleteEntry(selectedDate, selectedType, selectedName, selectedAmount);
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
            DatabaseHandler.AddNewEntry(DatePick_EntryDate.Value, ComboB_EntryType.Text, TxtB_EntryName.Text, finalAmount);
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
