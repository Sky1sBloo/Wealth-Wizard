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
        public void RefreshTable()
        {
            string[] columns = { "start_date AS 'Start Date'", "end_date AS 'End Date'", "entry_type AS 'Type'", "name AS 'Name'",
                "amount AS 'Amount'", "billing_cycle AS 'Billing Cycle'"};
            DataGridV_Subscriptions.DataSource = DatabaseHandler.GetValuesFromTable("subscriptions", columns);
        }


        /// <summary>
        /// Adds a new subscription to the subscriptions database.
        /// </summary>
        /// <param name="subscription">The subscription to be added.</param>
        public void AddSubscriptionToDatabase(Subscription subscription) 
        {
            // In the future will move this to Subscriptions Handler
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryInsert = "INSERT INTO subscriptions VALUES(@start_date, @end_date, @type, @name, @amount, @billing_cycle)";

            SQLiteCommand cmd = new SQLiteCommand(queryInsert, con);
            cmd.Parameters.AddWithValue("@start_date", subscription._startDate);
            cmd.Parameters.AddWithValue("@end_date", subscription._endDate);
            cmd.Parameters.AddWithValue("@type", subscription._type);
            cmd.Parameters.AddWithValue("@name", subscription._name);
            cmd.Parameters.AddWithValue("@amount", subscription._amount);
            cmd.Parameters.AddWithValue("@billing_cycle", subscription._billingCycle);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// <summary>
        /// Deletes a subscription from the subscriptions database.
        /// </summary>
        /// <param name="sub">The subscription to be deleted.</param>
        public void DeleteSubscriptionOnDatabase(Subscription sub)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryDelete = "DELETE FROM subscriptions " +
                "WHERE entry_type = @type AND name = @name AND amount = @amount AND billing_cycle = @billing_cycle";

            SQLiteCommand cmd = new SQLiteCommand(queryDelete, con);
            cmd.Parameters.AddWithValue("@type", sub._type);
            cmd.Parameters.AddWithValue("@name", sub._name);
            cmd.Parameters.AddWithValue("@amount", sub._amount);
            cmd.Parameters.AddWithValue("@billing_cycle", sub._billingCycle);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// <summary>
        /// Edits a subscription in the subscriptions database.
        /// </summary>
        /// <param name="oldSub">The old subscription to be replaced.</param>
        /// <param name="newSub">The new subscription to replace the old one.</param>
        public void EditSubscriptionOnDatabase(Subscription oldSub, Subscription newSub)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryUpdate = "UPDATE subscriptions " +
                "SET start_date = @new_start_date, end_date = @new_end_date, entry_type = @new_type, name = @new_name, " +
                "amount = @new_amount, billing_cycle = @new_billing_cycle " +
                "WHERE entry_type = @old_type AND name = @old_name AND amount = @old_amount AND " +
                "billing_cycle = @old_billing_cycle";

            SQLiteCommand cmd = new SQLiteCommand(queryUpdate, con);
            cmd.Parameters.AddWithValue("@new_start_date", newSub._startDate);
            cmd.Parameters.AddWithValue("@new_end_date", newSub._endDate);
            cmd.Parameters.AddWithValue("@new_type", newSub._type);
            cmd.Parameters.AddWithValue("@new_name", newSub._name);
            cmd.Parameters.AddWithValue("@new_amount", newSub._amount);
            cmd.Parameters.AddWithValue("@new_billing_cycle", newSub._billingCycle);

            cmd.Parameters.AddWithValue("@old_type", oldSub._type);
            cmd.Parameters.AddWithValue("@old_name", oldSub._name);
            cmd.Parameters.AddWithValue("@old_amount", oldSub._amount);
            cmd.Parameters.AddWithValue("@old_billing_cycle", oldSub._billingCycle);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        // Events
        // Subscription buttons events

        // Add new subscription to the table
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
            
            AddSubscriptionToDatabase(newSub);

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
                EditSubscriptionOnDatabase(selectedSub, editSubscriptionForm.subscription);
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

                DeleteSubscriptionOnDatabase(selectedSub);
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
