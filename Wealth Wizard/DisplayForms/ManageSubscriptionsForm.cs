using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wealth_Wizard.DisplayForms
{
    public partial class ManageSubscriptionsForm : Form
    {
        public ManageSubscriptionsForm()
        {
            InitializeComponent();

            RefreshTable();
        }

        public void RefreshTable()
        {
            string[] columns = { "entry_date AS 'Start Date'", "entry_type AS 'Type'", "name AS 'Name'", 
                "amount AS 'Amount'", "billing_cycle AS 'Cycle'"};
            DataGridV_Subscriptions.DataSource = DatabaseHandler.GetValuesFromTable("subscriptions", columns);
        }
    }
}
