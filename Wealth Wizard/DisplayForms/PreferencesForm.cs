using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wealth_Wizard.HelperForms;
using Wealth_Wizard.Tools;

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

        public void LoadComboBoxTypes()
        {
            ListB_EntryTypes.Items.Clear();
            // Initialize entry types to the list box
            foreach (string entryType in DatabaseHandler.GetEntryTypes())
            {
                ListB_EntryTypes.Items.Add(entryType);
            }
        }

        // Save preferences from json
        public void SavePreferences()
        {
            preferences.defaultDatabase = @"data source=" + TxtB_DefaultDatabase.Text;

            PreferencesHandler.SavePreferences(preferences);
        }

        // Load preferences from json
        public void LoadPreferences()
        {
            preferences = PreferencesHandler.LoadPreferences();
            TxtB_DefaultDatabase.Text = preferences.defaultDatabase.Replace(@"data source=", "");
        }

        // Selected the default database
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
        // Adds a new entry type
        private void Btn_AddEntryType_Click(object sender, EventArgs e)
        {
            // Opens a dialogue box that receives a text value
            InputMessageBox entryTypeValue = new InputMessageBox("New Type Name");
            if (entryTypeValue.ShowDialog() == DialogResult.OK)
            {
                DatabaseHandler.AddEntryType(entryTypeValue._value);
            }

            LoadComboBoxTypes();
        }

        // Updates an entry type
        private void Btn_EditEntryType_Click(object sender, EventArgs e)
        {
            // Opens a dialogue box that receives a text value
            InputMessageBox entryTypeValue = new InputMessageBox("New Type Name", 
                ListB_EntryTypes.GetItemText(ListB_EntryTypes.SelectedItem));

            if (entryTypeValue.ShowDialog() == DialogResult.OK)
            {
                DatabaseHandler.UpdateEntryType(ListB_EntryTypes.GetItemText(ListB_EntryTypes.SelectedItem), 
                    entryTypeValue._value);
            }

            LoadComboBoxTypes();
        }

        private void Btn_DeleteEntryType_Click(object sender, EventArgs e)
        {
            DatabaseHandler.DeleteEntryTypes(ListB_EntryTypes.GetItemText(ListB_EntryTypes.SelectedItem));
            LoadComboBoxTypes();
        }

        // Ok, cancel, apply

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            SavePreferences();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            SavePreferences();
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            // Warning that you might not save your preferences
            DialogResult answer = MessageBox.Show("Do you want to save your changes?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes) SavePreferences();
            
            Close();
        }

        
    }
}
