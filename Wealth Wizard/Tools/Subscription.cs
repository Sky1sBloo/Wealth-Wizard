using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wealth_Wizard.Tools
{
    internal class Subscription
    {
        public string _type { get; private set; }
        public string _name { get; private set; }
        public float _amount { get; private set; }
        public string _billingCycle { get; private set; }

        public Subscription(string type, string name, float amount, string billingCycle)
        {
            _type = type;
            _name = name;
            _amount = amount;
            _billingCycle = billingCycle;
        }
    }
}
