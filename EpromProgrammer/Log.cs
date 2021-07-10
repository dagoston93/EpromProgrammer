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
        delegate void LogDelegate(string message, bool startNewLine);
        public void Log(string message, bool startNewLine = true)
        {
            if (tbLog.InvokeRequired) {
                LogDelegate d = new LogDelegate(Log);
                Invoke(d, new object[] { message, startNewLine });
            }
            else
            {
                string toAppend = message;
                if(startNewLine)
                {
                    toAppend += "\r\n";
                }

                tbLog.AppendText(toAppend);
            }
            
        }
    }
}
