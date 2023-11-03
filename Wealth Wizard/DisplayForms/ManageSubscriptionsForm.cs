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

namespace Wealth_Wizard.DisplayForms
{
    public partial class ManageSubscriptionsForm : Form
    {
        public ManageSubscriptionsForm()
        {
            InitializeComponent();

            // Initialize table
            string[] columns = { "entry_date AS 'Start Date'", "entry_type AS 'Type'", "name AS 'Name'",
                "amount AS 'Amount'", "billing_cycle AS 'Billing Cycle'"};
            DataGridV_Subscriptions.DataSource = DatabaseHandler.GetValuesFromTable("subscriptions", columns);

            // Load Combo Box types
            foreach (string entryType in EntryTypesHandler.GetEntryTypes())
            {
                ComboB_Type.Items.Add(entryType);
            }
            ComboB_Type.SelectedIndex = 0;

            // Load billing cycle
            foreach (string billingCycle in DatabaseHandler.defaultBillingCycles)
            { 
                ComboB_BillingCycle.Items.Add(billingCycle);
            }
            ComboB_BillingCycle.SelectedIndex = 0;
        }

        public void AddSubscriptionToTable(DateTime startDate, string entryType, string name, float amount, string billingCycle)
        {
            int rowIdx = DataGridV_Subscriptions.Rows.Add();
        }

        // Events
        // Subscription buttons events
        private void Btn_AddSub_Click(object sender, EventArgs e)
        {
            // Add new subscription to the table
            
            // Check if all forms have been completed
            if (TxtB_EntryName.Text == "")
            {
                MessageBox.Show("Subscription Name field is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AddSubscriptionToTable(DateT_SubDate.Value, ComboB_Type.Text, TxtB_EntryName.Text,
                (float)NumTxtB_Amount.Value, ComboB_BillingCycle.Text);
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {

        }
    }
}
