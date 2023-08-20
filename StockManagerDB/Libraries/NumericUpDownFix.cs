using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagerDB.Libraries
{
    /// <summary>
    /// Fix for mouse whell only doing the increment value
    /// </summary>
    public class NumericUpDownFix : System.Windows.Forms.NumericUpDown
    {
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            HandledMouseEventArgs hme = e as HandledMouseEventArgs;
            if (hme != null)
                hme.Handled = true;

            if (e.Delta > 0)
            {
                if ((this.Value + this.Increment) <= this.Maximum)
                    this.Value += this.Increment;
                else
                    this.Value = this.Maximum;
            }
            else if (e.Delta < 0)
            {
                if ((this.Value - this.Increment) >= this.Minimum)
                    this.Value -= this.Increment;
                else
                    this.Value = this.Minimum;
            }
        }
    }
}
