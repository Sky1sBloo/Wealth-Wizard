using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Wealth_Wizard.Handlers;
using Wealth_Wizard.HelperForms;
using Wealth_Wizard.DisplayForms;

namespace Wealth_Wizard
{
    /// <summary>
    /// The main form for displaying and managing entries and subscriptions in the Wealth Wizard application.
    /// </summary>
    public partial class Display : Form
    {
        private List<int> entrySelectionRowIndex = new List<int>();
        private string selectedFilterType;

        public Display()
        {
            InitializeComponent();

            // Check if default database location exists
            string fileLocation = (PreferencesHandler.LoadPreferences().defaultDatabase).Replace(@"data source=", "");

            if (File.Exists(fileLocation))
            {
                DatabaseHandler.databaseLocation = PreferencesHandler.LoadPreferences().defaultDatabase;
            }
            else
            {
                NewDatabaseForm newDatabaseForm = new NewDatabaseForm();

                if (newDatabaseForm.ShowDialog() != DialogResult.OK)
                {
                    System.Environment.Exit(1);
                    return;
                }

                // Save into preferences
                Preferences preferences = PreferencesHandler.LoadPreferences();
                preferences.defaultDatabase = DatabaseHandler.databaseLocation;

                PreferencesHandler.SavePreferences(preferences);
            }

            RefreshInformation(true);  // Refresh the page with all the information
        }

        /// <summary>
        /// Refreshes the information displayed on the form based on selected filters and settings.
        /// </summary>
        /// <param name="refreshDatabaseSettings">A flag indicating whether to refresh database settings. Use when loading a new database.</param>
        public void RefreshInformation(bool refreshDatabaseSettings = false)
        {
            // Display all subscriptions
            string[] subscriptionColumns = { "amount AS 'Amount'", "billing_cycle AS 'Billing Cycle'" };
            DataGridV_Subscriptions.DataSource = DatabaseHandler.GetValuesFromTable("subscriptions", subscriptionColumns);

            // Display Entries
            DataGridV_Display.DataSource = EntriesHandler.GetEntries(DatePick_FilterStartDate.Value,
                DatePick_FilterEndDate.Value, selectedFilterType);

            // Disable or enable buttons when selection is available
            Btn_Delete.Enabled = (DataGridV_Display.Rows.Count > 0 && DataGridV_Display.Rows != null);
            Btn_EditEntry.Enabled = (DataGridV_Display.Rows.Count > 0 && DataGridV_Display.Rows != null);


            // Set combo box items list and database name when refreshSelection is true
            // Usually used when loading a new database
            if (refreshDatabaseSettings)
            {
                Lbl_DatabaseName.Text = Path.GetFileName(DatabaseHandler.databaseLocation);

                ComboB_EntryType.Items.Clear();
                ComboB_FilterType.Items.Clear();
                foreach (string entryType in EntryTypesHandler.GetEntryTypes())
                {
                    ComboB_EntryType.Items.Add(entryType);
                    ComboB_FilterType.Items.Add(entryType);
                }

                ComboB_FilterType.Items.Add("All");

                ComboB_FilterPreset.SelectedIndex = 0;

                ComboB_FilterType.SelectedIndex = ComboB_FilterType.Items.Count - 1;
                if (ComboB_EntryType.Items.Count != 0) ComboB_EntryType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Checks if all add entry fields are completed
        /// </summary>
        public bool IsEntryDataUploadable(Entry entry)
        {
            // Check if some of the input fields are empty
            if (entry._name == "")
            {
                MessageBox.Show("Add Entry Error, 'Name' field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Edits the entry based on selection on table
        /// </summary>
        public void EditEntry()
        {
            // Get old values
            DataRow selectedRow = ((DataRowView)DataGridV_Display.Rows[entrySelectionRowIndex[0]].DataBoundItem).Row;
            Entry selectedEntry = new Entry(selectedRow.Field<DateTime>("Date"),
                selectedRow.Field<string>("Type"),
                selectedRow.Field<string>("Name"),
                (float)selectedRow.Field<double>("Amount"));

            EditEntryForm editEntryForm = new EditEntryForm(selectedEntry);
            editEntryForm.ShowDialog();

            if (editEntryForm.DialogResult == DialogResult.OK)
            {
                Entry newEntry = editEntryForm.GetEntryValues();

                EntriesHandler.EditEntry(selectedEntry, newEntry);
            }

            RefreshInformation();
        }

        /// <summary>
        /// Deletes a selected row from the entries table in the database.
        /// </summary>
        /// <param name="rowIndex">The index of the row to be deleted.</param>
        public void DeleteRowEntry(int rowIndex)
        {
            // Store selected row into variables
            DataRow selectedRow = ((DataRowView)DataGridV_Display.Rows[rowIndex].DataBoundItem).Row;
            DateTime selectedDate = selectedRow.Field<DateTime>("Date");
            string selectedType = selectedRow.Field<string>("Type");
            string selectedName = selectedRow.Field<string>("Name");
            double selectedAmount = selectedRow.Field<double>("Amount");  // Needed to use double since somehow the datatable type is float

            Entry entryToBeDeleted = new Entry(selectedDate, selectedType, selectedName, (float)selectedAmount);

            // Delete the entry in the database handler
            EntriesHandler.DeleteEntry(entryToBeDeleted);
        }

        // Events

        /// <summary>
        /// Handles the click event for the "Refresh" button.
        /// </summary>
        private void RefreshBtn_Clicked(object sender, EventArgs e)
        {
            RefreshInformation();
        }

        /// <summary>
        /// Sets the date-time filters based on the selected filter preset in the combo box.
        /// </summary>
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

        /// <summary>
        /// Handles the event when the date is updated.
        /// </summary>
        private void DateUpdated(object sender, EventArgs e)
        {
            RefreshInformation();
        }

        /// <summary>
        /// Handles the click event for the "Add Entry" button.
        /// </summary>
        private void Btn_AddEntry_Click(object sender, EventArgs e)
        {
            float finalAmount = (float)NumTxtB_EntryAmount.Value;
            if (ChkB_Expenses.Checked) finalAmount *= -1;

            Entry newEntry = new Entry(DatePick_EntryDate.Value, ComboB_EntryType.Text, TxtB_EntryName.Text, finalAmount);

            if (!IsEntryDataUploadable(newEntry)) return;

            EntriesHandler.AddNewEntry(newEntry);
            RefreshInformation();
        }

        /// <summary>
        /// Handles the click event for the "Edit Entry" button.
        /// </summary>
        private void Btn_EditEntry_Click(object sender, EventArgs e)
        {
            EditEntry();
        }

        /// <summary>
        /// Handles the click event for the "Delete" button.
        /// </summary>
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult deleteChoice = MessageBox.Show("Would you want to delete " + entrySelectionRowIndex.Count.ToString() + " enties?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Create final warning
            if (deleteChoice == DialogResult.No) return;

            for (int i = 0; i < entrySelectionRowIndex.Count; i++)
            {
                DeleteRowEntry(entrySelectionRowIndex[i]);
            }

            RefreshInformation();
        }

        /// <summary>
        /// Handles the CheckedChanged event for the "Expenses" checkbox.
        /// </summary>
        private void ChkB_Expenses_CheckedChanged(object sender, EventArgs e)
        {
            ChkB_Income.Checked = !ChkB_Expenses.Checked;
        }
        /// <summary>
        /// Handles the CheckedChanged event for the "Income" checkbox.
        /// </summary>
        private void ChkB_Income_CheckedChanged(object sender, EventArgs e)
        {
            ChkB_Expenses.Checked = !ChkB_Income.Checked;
        }

        /// <summary>
        /// Updates the row of the current selection in the DataGridV_Display.
        /// </summary>
        private void SetCurrentSelection(object sender, EventArgs e)
        {
            if (DataGridV_Display.CurrentCell == null) return;

            entrySelectionRowIndex.Clear();
            for (int i = 0; i < DataGridV_Display.SelectedCells.Count; i++)
            {
                entrySelectionRowIndex.Add(DataGridV_Display.SelectedCells[i].RowIndex);
            }
        }

        /// <summary>
        /// Handles the SelectedValueChanged event for the "Filter Type" combo box.
        /// </summary>
        private void ComboB_FilterType_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedFilterType = ComboB_FilterType.SelectedItem.ToString();
        }

        private void PreferencesMenu_Click(object sender, EventArgs e)
        {
            // Opens the preference window
            PreferencesForm preferenceWindow = new PreferencesForm();
            preferenceWindow.ShowDialog();

            RefreshInformation(true);
        }

        private void OpenDatabaseMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog databaseDialog = new OpenFileDialog();
            databaseDialog.Filter = "Wealth Wizard Database|*.wwiz";

            if (databaseDialog.ShowDialog() == DialogResult.OK)
            {
                DatabaseHandler.databaseLocation = @"data source=" + databaseDialog.FileName;
            }

            RefreshInformation(true);  // Refresh the page
        }

        private void NewDatabaseMenu_Click(object sender, EventArgs e)
        {
            NewDatabaseForm newDatabaseForm = new NewDatabaseForm();
            newDatabaseForm.ShowDialog();

            RefreshInformation(true); 
        }

        private void NewEntryMenu_Click(object sender, EventArgs e)
        {
            EditEntryForm editEntryForm = new EditEntryForm();
            editEntryForm.ShowDialog();

            if (editEntryForm.DialogResult == DialogResult.Cancel) return;
            
            Entry newEntry = editEntryForm.GetEntryValues();
            EntriesHandler.AddNewEntry(newEntry);
            RefreshInformation();
        }

        private void EditEntryMenu_Click(object sender, EventArgs e)
        {
            EditEntry();
        }

        /// <summary>
        /// Handles the click event for the "Manage Subscriptions" menu item.
        /// </summary>
        private void ManageSubscriptions_Click(object sender, EventArgs e)
        {
            ManageSubscriptionsForm subscriptionsForm = new ManageSubscriptionsForm();
            subscriptionsForm.ShowDialog();

            RefreshInformation(true);
        }
    }
}
