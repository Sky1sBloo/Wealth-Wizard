using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wealth_Wizard
{
    /// <summary>
    /// Class that can store subscriptions from the database
    /// </summary>
    public class Subscription
    {
        public DateTime StartDate { get; private set; }
        public Nullable<DateTime> EndDate { get; private set; }
        public string Type { get; private set; }
        public string Name { get; private set; }
        public float Amount { get; private set; }
        public string BillingCycle { get; private set; }

        /// <summary>
        /// Constructor with primary keys, generally used for searching rows
        /// </summary>
        /// <param name="type">The entry type listed on entry_types table</param>
        /// <param name="name">Name of the subscription</param>
        /// <param name="amount"></param>
        /// <param name="billingCycle">Cycle of daily, weekly, monthly, or yearly</param>
        public Subscription(string type, string name, float amount, string billingCycle)
        {
            Type = type;
            Name = name;
            Amount = amount;
            BillingCycle = billingCycle;
        }

        /// <summary>
        /// Constructor without the end date
        /// </summary>
        /// <param name="startDate">Starting date of the subscription. All weekly, monthly, yearly subscription will base on this</param>
        /// <param name="type">The entry type listed on entry_types table</param>
        /// <param name="name"><Name of the subscription/param>
        /// <param name="amount"></param>
        /// <param name="billingCycle">ycle of daily, weekly, monthly, or yearly</param>
        public Subscription(DateTime startDate, string type, string name, float amount, string billingCycle)
        {
            StartDate = startDate;
            Type = type;
            Name = name;
            Amount = amount;
            BillingCycle = billingCycle;
        }

        /// <summary>
        /// Constructor with all the values
        /// </summary>
        /// <param name="startDate">Starting date of the subscription. All weekly, monthly, yearly subscription 
        /// will base on this</param>
        /// <param name="endDate">Final day of subscription</param>
        /// <param name="type">The entry type listed on entry_types table</param>
        /// <param name="name"><Name of the subscription/param>
        /// <param name="amount"></param>
        /// <param name="billingCycle">ycle of daily, weekly, monthly, or yearly</param>
        public Subscription(DateTime startDate, Nullable<DateTime> endDate, string type, string name, float amount, 
            string billingCycle)
        {
            StartDate = startDate;
            EndDate = endDate;
            Type = type;
            Name = name;
            Amount = amount;
            BillingCycle = billingCycle;
        }
    }
}
