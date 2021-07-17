using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpromProgrammer
{
    public partial class Form1 : Form
    {
        /**
         * Theese methods are needed to manipulate controls in a threadsafe manner.
         */ 
        delegate void SetControlTextDelegate(Control control, string text);
        public void SetControlText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetControlTextDelegate d = new SetControlTextDelegate(SetControlText);
                Invoke(d, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        delegate void SetCheckBoxCheckedDelegate(CheckBox cb, bool isChecked);
        public void SetCheckBoxChecked(CheckBox cb, bool isChecked)
        {
            if (cb.InvokeRequired)
            {
                SetCheckBoxCheckedDelegate d = new SetCheckBoxCheckedDelegate(SetCheckBoxChecked);
                Invoke(d, new object[] { cb, isChecked });
            }
            else
            {
                cb.Checked = isChecked;
            }
        }

        delegate void SetNumericUpDownValueDelegate(NumericUpDown control, uint value);
        public void SetNumericUpDownValue(NumericUpDown control, uint value)
        {
            if (control.InvokeRequired)
            {
                SetNumericUpDownValueDelegate d = new SetNumericUpDownValueDelegate(SetNumericUpDownValue);
                Invoke(d, new object[] { control, value });
            }
            else
            {
                control.Value = value;
            }
        }

        delegate void SetNumericUpDownMinMaxDelegate(NumericUpDown control, uint min, uint max);
        public void SetNumericUpDownMinMax(NumericUpDown control, uint min, uint max)
        {
            if (control.InvokeRequired)
            {
                SetNumericUpDownMinMaxDelegate d = new SetNumericUpDownMinMaxDelegate(SetNumericUpDownMinMax);
                Invoke(d, new object[] { control, min, max });
            }
            else
            {
                control.Minimum = min;
                control.Maximum = max;
            }
        }

        delegate void SetToolStripStatusLabelTextDelegate(ToolStripStatusLabel label, string text);
        public void SetToolStripStatusLabelText(ToolStripStatusLabel label, string text)
        {
            if (ssStatus.InvokeRequired)
            {
                SetToolStripStatusLabelTextDelegate d = new SetToolStripStatusLabelTextDelegate(SetToolStripStatusLabelText);
                BeginInvoke(d, new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }

        delegate void SetControlEnabledDelegate(Control control, bool isEnabled);
        public void SetControlEnabled(Control control, bool isEnabled)
        {
            if (control.InvokeRequired)
            {
                SetControlEnabledDelegate d = new SetControlEnabledDelegate(SetControlEnabled);
                Invoke(d, new object[] { control, isEnabled });
            }
            else
            {
                control.Enabled = isEnabled;
            }
        }

        delegate void AddRangeComboBoxDelegate(ComboBox cb, string[] range);
        public void AddRangeComboBox(ComboBox cb, string[] range)
        {
            if (cb.InvokeRequired)
            {
                AddRangeComboBoxDelegate d = new AddRangeComboBoxDelegate(AddRangeComboBox);
                Invoke(d, new object[] { cb, range });
            }
            else
            {
                cb.Items.AddRange(range);
            }
        }

        delegate void AddItemComboBoxDelegate(ComboBox cb, string item);
        public void AddItemComboBox(ComboBox cb, string item)
        {
            if (cb.InvokeRequired)
            {
                AddItemComboBoxDelegate d = new AddItemComboBoxDelegate(AddItemComboBox);
                Invoke(d, new object[] { cb, item });
            }
            else
            {
                cb.Items.Add(item);
            }
        }

        public delegate void ClearComboBoxDelegate(ComboBox cb);
        public void ClearComboBox(ComboBox cb)
        {
            if (cb.InvokeRequired)
            {
                ClearComboBoxDelegate d = new ClearComboBoxDelegate(ClearComboBox);
                Invoke(d, new object[] { cb });
            }
            else
            {
                cb.Items.Clear();
            }
        }
    }
}
