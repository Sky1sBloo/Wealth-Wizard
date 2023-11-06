using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wealth_Wizard
{
    /// <summary>
    /// Form for creating a new database
    /// </summary>
    public partial class NewDatabaseForm : Form
    {
        public NewDatabaseForm()
        {
            InitializeComponent();
        }

        private void Btn_SaveLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveLocation = new FolderBrowserDialog();

            if (saveLocation.ShowDialog() == DialogResult.OK)
            {
                TxtB_Location.Text = saveLocation.SelectedPath;
            }
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            DatabaseHandler.CreateDatabase(TxtB_Name.Text, TxtB_Location.Text, ChkB_OpenDatabase.Checked);
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
            Close();
        }
    }
}
