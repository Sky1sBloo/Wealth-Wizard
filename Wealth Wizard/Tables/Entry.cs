using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wealth_Wizard
{
    /// <summary>
    /// Class that can hold information of entries from the database
    /// </summary>
    public class Entry
    {
        public DateTime _date { get; private set; }
        public string _type { get; private set; }
        public string _name { get; private set; }
        public float _amount { get; private set; }

        public Entry(DateTime date, string type, string name, float amount)
        {
            _date = date;
            _type = type;
            _name = name;
            _amount = amount;
        }
    }
}
