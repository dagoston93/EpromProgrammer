using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace EpromProgrammer
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;

        /**
         * Find available serial ports
         */
        public void FindSerialPorts()
        {
            cbPort.Items.Clear();
            string[] availablePorts = SerialPort.GetPortNames();
            cbPort.Items.AddRange(availablePorts);
        }
    }
}
