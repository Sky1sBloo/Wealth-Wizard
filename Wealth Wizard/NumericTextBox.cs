using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NumericTextBox : System.Windows.Forms.NumericUpDown
{
    public NumericTextBox()
    {
        Controls[0].Visible = false;
        DecimalPlaces = 2;
        Maximum = Decimal.MaxValue;
    }
}
