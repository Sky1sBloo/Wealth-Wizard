using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Wealth_Wizard.Handlers
{
    /// <summary>
    /// Class used to selecting and retrieving subscriptions in the dataabase
    /// </summary>
    public static class SubscriptionsHandler
    {
        /// <summary>
        /// Adds a new subscription to the subscriptions database.
        /// </summary>
        /// <param name="subscription">The subscription to be added.</param>
        public static void AddNewSubscription(Subscription subscription)
        {
            // In the future will move this to Subscriptions Handler
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryInsert = "INSERT INTO subscriptions VALUES(@start_date, @end_date, @type, @name, @amount, @billing_cycle)";

            SQLiteCommand cmd = new SQLiteCommand(queryInsert, con);
            cmd.Parameters.AddWithValue("@start_date", subscription.StartDate);
            cmd.Parameters.AddWithValue("@end_date", subscription.EndDate);
            cmd.Parameters.AddWithValue("@type", subscription.Type);
            cmd.Parameters.AddWithValue("@name", subscription.Name);
            cmd.Parameters.AddWithValue("@amount", subscription.Amount);
            cmd.Parameters.AddWithValue("@billing_cycle", subscription.BillingCycle);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// <summary>
        /// Edits a subscription in the subscriptions database.
        /// </summary>
        /// <param name="oldSub">The old subscription to be replaced.</param>
        /// <param name="newSub">The new subscription to replace the old one.</param>
        public static void EditSubscription(Subscription oldSub, Subscription newSub)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryUpdate = "UPDATE subscriptions " +
                "SET start_date = @new_start_date, end_date = @new_end_date, entry_type = @new_type, name = @new_name, " +
                "amount = @new_amount, billing_cycle = @new_billing_cycle " +
                "WHERE entry_type = @old_type AND name = @old_name AND amount = @old_amount AND " +
                "billing_cycle = @old_billing_cycle";

            SQLiteCommand cmd = new SQLiteCommand(queryUpdate, con);
            cmd.Parameters.AddWithValue("@new_start_date", newSub.StartDate);
            cmd.Parameters.AddWithValue("@new_end_date", newSub.EndDate);
            cmd.Parameters.AddWithValue("@new_type", newSub.Type);
            cmd.Parameters.AddWithValue("@new_name", newSub.Name);
            cmd.Parameters.AddWithValue("@new_amount", newSub.Amount);
            cmd.Parameters.AddWithValue("@new_billing_cycle", newSub.BillingCycle);

            cmd.Parameters.AddWithValue("@old_type", oldSub.Type);
            cmd.Parameters.AddWithValue("@old_name", oldSub.Name);
            cmd.Parameters.AddWithValue("@old_amount", oldSub.Amount);
            cmd.Parameters.AddWithValue("@old_billing_cycle", oldSub.BillingCycle);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// <summary>
        /// Deletes a subscription from the subscriptions database.
        /// </summary>
        /// <param name="sub">The subscription to be deleted.</param>
        public static void DeleteSubscription(Subscription sub)
        {
            SQLiteConnection con = new SQLiteConnection(DatabaseHandler.databaseLocation);
            con.Open();

            string queryDelete = "DELETE FROM subscriptions " +
                "WHERE entry_type = @type AND name = @name AND amount = @amount AND billing_cycle = @billing_cycle";

            SQLiteCommand cmd = new SQLiteCommand(queryDelete, con);
            cmd.Parameters.AddWithValue("@type", sub.Type);
            cmd.Parameters.AddWithValue("@name", sub.Name);
            cmd.Parameters.AddWithValue("@amount", sub.Amount);
            cmd.Parameters.AddWithValue("@billing_cycle", sub.BillingCycle);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// <summary>
        /// Retrieves all subscriptions in the database
        /// </summary>
        /// <returns>Returns a list of subscriptions</returns>
        public static List<Subscription> GetAllSubscriptions() 
        {
            DataTable subsTable = DatabaseHandler.GetAllValuesFromTable("subscriptions");
            List<Subscription> subs = new List<Subscription>();

            foreach (DataRow row in subsTable.Rows)
            {
                Subscription sub = new Subscription(
                    row.Field<DateTime>("start_date"),
                    row.Field<DateTime>("end_date"),
                    row.Field<string>("entry_type"),
                    row.Field<string>("name"),
                    (float)row.Field<double>("amount"),
                    row.Field<string>("billing_cycle")
                    );

                subs.Add(sub);
            }

            return subs;
        }
    }
}
