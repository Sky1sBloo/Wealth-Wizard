using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SQLite;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Wealth_Wizard.HelperForms;
using Wealth_Wizard.Handlers;

namespace Wealth_Wizard.DisplayForms
{
    // NOTE TO FUTURE, DOUBLE CHECK DOCUMENTATION SINCE I COPIED THIS FROM CHATGPT
    /// <summary>
    /// This form lets you manage your subscriptions
    /// </summary>
    public partial class ManageSubscriptionsForm : Form
    {
        private List<int> selectedRowIdx = new List<int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageSubscriptionsForm"/> class.
        /// </summary>
        public ManageSubscriptionsForm()
        {
            InitializeComponent();
            
            RefreshTable();

            // Load defaults and combo box types
            Panel_EndDate.Visible = ChkB_HasEndDate.Checked;

            foreach (string entryType in EntryTypesHandler.GetEntryTypes())
            {
                ComboB_Type.Items.Add(entryType);
            }
            ComboB_Type.SelectedIndex = 0;

            foreach (string billingCycle in DatabaseHandler.defaultBillingCycles)
            { 
                ComboB_BillingCycle.Items.Add(billingCycle);
            }
            ComboB_BillingCycle.SelectedIndex = 0;
        }

        /// <summary>
        /// Refreshes the data grid view with subscription data from the database.
        /// </summary>
        private void RefreshTable()
        {
            string[] columns = { "start_date AS 'Start Date'", "end_date AS 'End Date'", "entry_type AS 'Type'", "name AS 'Name'",
                "amount AS 'Amount'", "billing_cycle AS 'Billing Cycle'"};
            DataGridV_Subscriptions.DataSource = DatabaseHandler.GetValuesFromTable("subscriptions", columns);
        }

        /// <summary>
        /// Adds new subscription with message box dialog type checking
        /// </summary>
        /// <param name="newSub"></param>
        private void AddSubscription(Subscription newSub)
        {
            try
            {
                SubscriptionsHandler.AddNewSubscription(newSub);
            }
            catch (SQLiteException)
            {
                DialogResult existingEntryError = MessageBox.Show("Subscription matches an existing entry",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Events
        // Subscription buttons events
        private void Btn_AddSub_Click(object sender, EventArgs e)
        {
            // Check if all forms have been completed to avoid query errors
            if (TxtB_EntryName.Text == "")
            {
                MessageBox.Show("Subscription Name field is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Subscription newSub;
            if (ChkB_HasEndDate.Checked)
            {
                newSub = new Subscription(DateT_StartDate.Value, DateT_EndDate.Value, ComboB_Type.Text, TxtB_EntryName.Text,
                    (float)NumTxtB_Amount.Value, ComboB_BillingCycle.Text);
            }
            else
            {
                newSub = new Subscription(DateT_StartDate.Value, ComboB_Type.Text, TxtB_EntryName.Text,
                    (float)NumTxtB_Amount.Value, ComboB_BillingCycle.Text);
            }
            
            AddSubscription(newSub);

            RefreshTable();
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = ((DataRowView)DataGridV_Subscriptions.Rows[selectedRowIdx[0]].DataBoundItem).Row;

            Subscription selectedSub = new Subscription(selectedRow.Field<DateTime>("Start Date"),
               selectedRow.Field<Nullable<DateTime>>("End Date"),
               selectedRow.Field<string>("Type"),
               selectedRow.Field<string>("Name"),
               (float)selectedRow.Field<double>("Amount"),
               selectedRow.Field<string>("Billing Cycle"));

            EditSubscriptionForm editSubscriptionForm = new EditSubscriptionForm(selectedSub);
            editSubscriptionForm.ShowDialog();

            if (editSubscriptionForm.DialogResult == DialogResult.OK)
            {
                SubscriptionsHandler.EditSubscription(selectedSub, editSubscriptionForm.subscription);
            }

            RefreshTable();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            // Get selected value
            foreach (int idx in selectedRowIdx)
            {
                DataRow selectedRow = ((DataRowView)DataGridV_Subscriptions.Rows[idx].DataBoundItem).Row;
                Subscription selectedSub = new Subscription(selectedRow.Field<string>("Type"),
                   selectedRow.Field<string>("Name"),
                   (float)selectedRow.Field<double>("Amount"),
                   selectedRow.Field<string>("Billing Cycle"));

                SubscriptionsHandler.DeleteSubscription(selectedSub);
            }
            
            RefreshTable();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChkB_HasEndDate_CheckedChanged(object sender, EventArgs e)
        {
            Panel_EndDate.Visible = ChkB_HasEndDate.Checked;
        }

        private void DataGridV_Subscriptions_SelectionChanged(object sender, EventArgs e)
        {
            selectedRowIdx.Clear();

            for (int i = 0; i < DataGridV_Subscriptions.SelectedCells.Count; i++)
            {
                selectedRowIdx.Add(DataGridV_Subscriptions.SelectedCells[i].RowIndex);
            }
        }
    }
}
