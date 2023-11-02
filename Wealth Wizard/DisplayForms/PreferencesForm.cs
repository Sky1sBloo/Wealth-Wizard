using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wealth_Wizard.Tools;

namespace Wealth_Wizard
{
    public partial class PreferencesForm : Form
    {
        private Preferences preferences = new Preferences();
        public PreferencesForm()
        {
            InitializeComponent();

            // Initialize entry types to the list box
            foreach (string entryType in DatabaseHandler.GetEntryTypes())
            {
                ListB_EntryTypes.Items.Add(entryType);
            }

            LoadPreferences();
        }

        // Save preferences from json
        public void SavePreferences()
        {
            preferences.defaultDatabase = TxtB_DefaultDatabase.Text;

            PreferencesHandler.SavePreferences(preferences);
        }

        // Load preferences from json
        public void LoadPreferences()
        {
            preferences = PreferencesHandler.LoadPreferences();

            TxtB_DefaultDatabase.Text = preferences.defaultDatabase;
        }

        private void Btn_AddEntryType_Click(object sender, EventArgs e)
        {
            
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
