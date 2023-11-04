using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wealth_Wizard.Tools;

namespace Wealth_Wizard.DisplayForms
{
    public partial class ManageSubscriptionsForm : Form
    {
        public List<int> selectedRowIdx = new List<int>();
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

        public void RefreshTable()
        {
            string[] columns = { "start_date AS 'Start Date'", "end_date AS 'End Date'", "entry_type AS 'Type'", "name AS 'Name'",
                "amount AS 'Amount'", "billing_cycle AS 'Billing Cycle'"};
            DataGridV_Subscriptions.DataSource = DatabaseHandler.GetValuesFromTable("subscriptions", columns);
        }


        // Add new subscription to database
        public void AddSubscriptionToDatabase(DateTime startDate, DateTime endDate, string entryType, string name, 
            float amount, string billingCycle)
        {
            // In the future will move this to Subscriptions Handler
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryInsert = "INSERT INTO subscriptions VALUES(@start_date, @end_date, @type, @name, @amount, @billing_cycle)";

            SQLiteCommand cmd = new SQLiteCommand(queryInsert, con);
            cmd.Parameters.AddWithValue("@start_date", startDate);
            cmd.Parameters.AddWithValue("@end_date", endDate);
            cmd.Parameters.AddWithValue("@type", entryType);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@billing_cycle", billingCycle);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void DeleteSubscriptionOnDatabase(int rowIdx)
        {
            // Selected values for deletion
            DataRow selectedRow = ((DataRowView)DataGridV_Subscriptions.Rows[rowIdx].DataBoundItem).Row;
            Subscription selectedSub = new Subscription(selectedRow.Field<string>("Type"),
               selectedRow.Field<string>("Name"),
               (float)selectedRow.Field<double>("Amount"),
               selectedRow.Field<string>("Billing Cycle"));


            // Execute command on database
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryDelete = "DELETE FROM subscriptions " +
                "WHERE entry_type = @type AND name = @name AND amount = @amount AND billing_cycle = @cycle";

            SQLiteCommand cmd = new SQLiteCommand(queryDelete, con);
            cmd.Parameters.AddWithValue("@type", selectedSub._type);
            cmd.Parameters.AddWithValue("@name", selectedSub._name);
            cmd.Parameters.AddWithValue("@amount", selectedSub._amount);
            cmd.Parameters.AddWithValue("@cycle", selectedSub._billingCycle);

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
            AddSubscriptionToDatabase(DateT_StartDate.Value, DateT_EndDate.Value, ComboB_Type.Text, TxtB_EntryName.Text,
                (float)NumTxtB_Amount.Value, ComboB_BillingCycle.Text);

            RefreshTable();
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            // Get selected value
            foreach (int idx in selectedRowIdx)
            {
                DeleteSubscriptionOnDatabase(idx);
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
