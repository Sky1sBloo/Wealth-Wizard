using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wealth_Wizard
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            // Initialize entry types to the list box
            foreach (string entryType in DatabaseHandler.GetEntryTypes())
            {
                ListB_EntryTypes.Items.Add(entryType);
            }
        }

        private void Btn_AddEntryType_Click(object sender, EventArgs e)
        {

        }
    }
}
