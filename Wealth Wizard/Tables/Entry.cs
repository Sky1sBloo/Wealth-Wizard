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
        public DateTime Date { get; private set; }
        public string Type { get; private set; }
        public string Name { get; private set; }
        public float Amount { get; private set; }

        public Entry(DateTime date, string type, string name, float amount)
        {
            Date = date;
            Type = type;
            Name = name;
            Amount = amount;
        }
    }
}
