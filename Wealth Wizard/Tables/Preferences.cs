using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Wealth_Wizard
{
    /// <summary>
    /// Class that contains all preferences settings
    /// </summary>
    public class Preferences
    {
        public string DefaultDatabase { get; set; }
        public int ExcelStartX { get; set; }
        public int ExcelStartY { get; set; }
    }
}
