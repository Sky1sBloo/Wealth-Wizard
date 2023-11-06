using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wealth_Wizard.Handlers;

namespace Wealth_Wizard
{
    /// <summary>
    /// Form that creates the edit entry
    /// </summary>
    public partial class EditEntryForm : Form
    {
        /// <summary>
        /// Initialize edit entry form with default values
        /// Generally used for editing entries
        /// </summary>
        /// <param name="defaultValues"></param>
        public EditEntryForm(Entry defaultValues)
        {
            InitializeComponent();

            // Initialize type
            foreach (string type in EntryTypesHandler.GetEntryTypes())
            {
                ComboB_Types.Items.Add(type);
            }

            // Load default values
            DateT_Date.Value = defaultValues._date;
            ComboB_Types.Text = defaultValues._type;
            TxtB_Name.Text = defaultValues._name;

            ChkB_Expenses.Checked = defaultValues._amount < 0;
            ChkB_Income.Checked = defaultValues._amount >= 0;

            NumTxtB_EntryAmount.Value = Math.Abs((decimal)defaultValues._amount);
        }

        /// <summary>
        /// Constructor for entry forms
        /// </summary>
        public EditEntryForm()
        {
            InitializeComponent();

            foreach (string type in EntryTypesHandler.GetEntryTypes())
            {
                ComboB_Types.Items.Add(type);
            }
        }

        // Setters and getters
        // Returns all entry values
        public Entry GetEntryValues()
        {
            Entry entry = new Entry(GetEntryDate(), GetEntryType(), GetEntryName(), GetAmount());
            return entry;
        }

        public DateTime GetEntryDate()
        {
            return DateT_Date.Value;
        }

        public string GetEntryType()
        {
            return ComboB_Types.Text;
        }

        public string GetEntryName()
        {
            return TxtB_Name.Text;
        }

        public float GetAmount()
        {
            if (ChkB_Income.Checked) { return (float)NumTxtB_EntryAmount.Value; }
            return -(float)NumTxtB_EntryAmount.Value;
        }

        

        // Events
        // Toggle between income and expenses
        private void ChkB_Income_CheckedChanged(object sender, EventArgs e)
        {
            ChkB_Expenses.Checked = !ChkB_Income.Checked;
        }

        private void ChkB_Expenses_CheckedChanged(object sender, EventArgs e)
        {
            ChkB_Income.Checked = !ChkB_Expenses.Checked;
        }

        // Apply and cancel logic
        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
