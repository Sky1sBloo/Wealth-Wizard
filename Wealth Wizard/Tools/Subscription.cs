using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wealth_Wizard.Tools
{
    /// <summary>
    /// Class that can store subscriptions from the database
    /// </summary>
    public class Subscription
    {
        public DateTime _startDate { get; private set; }
        public Nullable<DateTime> _endDate { get; private set; }
        public string _type { get; private set; }
        public string _name { get; private set; }
        public float _amount { get; private set; }
        public string _billingCycle { get; private set; }

        /// <summary>
        /// Constructor with primary keys, generally used for searching rows
        /// </summary>
        /// <param name="type">The entry type listed on entry_types table</param>
        /// <param name="name">Name of the subscription</param>
        /// <param name="amount"></param>
        /// <param name="billingCycle">Cycle of daily, weekly, monthly, or yearly</param>
        public Subscription(string type, string name, float amount, string billingCycle)
        {
            _type = type;
            _name = name;
            _amount = amount;
            _billingCycle = billingCycle;
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
            _startDate = startDate;
            _type = type;
            _name = name;
            _amount = amount;
            _billingCycle = billingCycle;
        }

        /// <summary>
        /// Constructor with all the values
        /// </summary>
        /// <param name="startDate">Starting date of the subscription. All weekly, monthly, yearly subscription will base on this</param>
        /// <param name="endDate">Final day of subscription</param>
        /// <param name="type">The entry type listed on entry_types table</param>
        /// <param name="name"><Name of the subscription/param>
        /// <param name="amount"></param>
        /// <param name="billingCycle">ycle of daily, weekly, monthly, or yearly</param>
        public Subscription(DateTime startDate, Nullable<DateTime> endDate, string type, string name, float amount, string billingCycle)
        {
            _startDate = startDate;
            _endDate = endDate;
            _type = type;
            _name = name;
            _amount = amount;
            _billingCycle = billingCycle;
        }
    }
}
