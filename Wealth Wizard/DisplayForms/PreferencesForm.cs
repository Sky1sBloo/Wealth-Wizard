﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wealth_Wizard.HelperForms;
using Wealth_Wizard.Handlers;
using System.Data.SQLite;

namespace Wealth_Wizard
{
    public partial class PreferencesForm : Form
    {
        private Preferences preferences = new Preferences();
        public PreferencesForm()
        {
            InitializeComponent();

            LoadComboBoxTypes();
            LoadPreferences();
        }

        /// <summary>
        /// Loads and initializes the available entry types into a list box.
        /// </summary>
        public void LoadComboBoxTypes()
        {
            ListB_EntryTypes.Items.Clear();
            // Initialize entry types to the list box
            foreach (string entryType in EntryTypesHandler.GetEntryTypes())
            {
                ListB_EntryTypes.Items.Add(entryType);
            }
        }

        /// <summary>
        /// Saves user preferences to a JSON file.
        /// </summary>
        public void SavePreferences()
        {
            preferences.DefaultDatabase = @"data source=" + TxtB_DefaultDatabase.Text;
            preferences.ExcelSheetName = TxtB_SheetName.Text;
            preferences.ExcelStartX = (int)Num_StartingCellX.Value;
            preferences.ExcelStartY = (int)Num_StartingCellY.Value;

            PreferencesHandler.SavePreferences(preferences);
        }

        /// <summary>
        /// Loads user preferences from a JSON file and updates the form controls accordingly.
        /// </summary>
        public void LoadPreferences()
        {
            preferences = PreferencesHandler.LoadPreferences();
            TxtB_DefaultDatabase.Text = preferences.DefaultDatabase.Replace(@"data source=", "");
            TxtB_SheetName.Text = preferences.ExcelSheetName;
            Num_StartingCellX.Value = preferences.ExcelStartX;
            Num_StartingCellY.Value = preferences.ExcelStartY;
            
        }

        /// <summary>
        /// Handles the event when the "Browse Database" button is clicked to select the default database file.
        /// </summary>
        private void Btn_BrowseDatabase_Click(object sender, EventArgs e)
        {
            OpenFileDialog defaultDatabaseDialog = new OpenFileDialog();

            defaultDatabaseDialog.Filter = "Wealth Wizard Database|*.wwiz";

            if (defaultDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                TxtB_DefaultDatabase.Text = defaultDatabaseDialog.FileName;
            }
        }

        // Entry types
        /// <summary>
        /// Adds a new entry type to the list of available entry types.
        /// </summary>
        private void Btn_AddEntryType_Click(object sender, EventArgs e)
        {
            // Opens a dialogue box that receives a text value
            InputMessageBox entryTypeValue = new InputMessageBox("New Type Name");
            if (entryTypeValue.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EntryTypesHandler.AddEntryType(entryTypeValue.Value);
                }
                catch (SQLiteException)
                {
                    DialogResult existingEntryError = MessageBox.Show("Entry matches an existing type",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadComboBoxTypes();
        }

        /// <summary>
        /// Updates an existing entry type in the list of available entry types.
        /// </summary>
        private void Btn_EditEntryType_Click(object sender, EventArgs e)
        {
            // Opens a dialogue box that receives a text value
            InputMessageBox entryTypeValue = new InputMessageBox("New Type Name", 
                ListB_EntryTypes.GetItemText(ListB_EntryTypes.SelectedItem));

            if (entryTypeValue.ShowDialog() == DialogResult.OK)
            {
                EntryTypesHandler.UpdateEntryType(ListB_EntryTypes.GetItemText(ListB_EntryTypes.SelectedItem), 
                    entryTypeValue.Value);
            }

            LoadComboBoxTypes();
        }

        /// <summary>
        /// Deletes the selected entry type from the list of available entry types.
        /// </summary>
        private void Btn_DeleteEntryType_Click(object sender, EventArgs e)
        {
            EntryTypesHandler.DeleteEntryTypes(ListB_EntryTypes.GetItemText(ListB_EntryTypes.SelectedItem));
            LoadComboBoxTypes();
        }

        // Ok, cancel, apply
        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            SavePreferences();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SavePreferences();
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            // Warning that you might not save your preferences
            DialogResult answer = MessageBox.Show("Do you want to save your changes?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
                SavePreferences();
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }

            Close();
        }
    }
}
