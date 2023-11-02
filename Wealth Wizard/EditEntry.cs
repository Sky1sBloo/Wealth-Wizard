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

namespace Wealth_Wizard
{
    public partial class EditEntry : Form
    {
        public EditEntry()
        {
            InitializeComponent();
        }

        // Setters and getters
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

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void ChkB_Income_CheckedChanged(object sender, EventArgs e)
        {
            ChkB_Expenses.Checked = !ChkB_Income.Checked;
        }

        private void ChkB_Expenses_CheckedChanged(object sender, EventArgs e)
        {
            ChkB_Income.Checked = !ChkB_Expenses.Checked;
        }
    }
}
