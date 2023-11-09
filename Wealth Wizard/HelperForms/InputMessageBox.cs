using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wealth_Wizard.HelperForms
{
    /// <summary>
    /// Creates a dialog message box that accepts a text
    /// </summary>
    public partial class InputMessageBox : Form
    {
        public string Value;
        public InputMessageBox(string message = "", string defaultValue = "", string title = "Message Box")
        {
            InitializeComponent();

            Lbl_Display.Text = message;
            TxtB_Value.Text = defaultValue;
            Text = title;
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            Value = TxtB_Value.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
