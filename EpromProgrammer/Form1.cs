using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpromProgrammer
{
    public partial class Form1 : Form
    {
        /**
         * Define the supported chips
         */
        private List<Chip> supportedChips = new List<Chip> {
            new Chip(0, "TMS 27C0A10-12", 128)
        };

        /**
         * The constructor
         */ 
        public Form1()
        {
            // Initialize the components
            InitializeComponent();

            // Add supported chips to combo box
            ClearComboBox(cbSupportedChips);

            foreach(Chip chip in supportedChips)
            {
                AddItemComboBox(cbSupportedChips, chip.name);
            }

            //Initializes serial communication
            SerialInit();

            // Find serial ports
            FindSerialPorts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /**
         * Chip type select combo box - Selection changed
         */
        private void cbSupportedChips_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetControlText(lblChipMemSize, supportedChips[cbSupportedChips.SelectedIndex].memorySizeKb.ToString() + " kB");
        }

        /**
         * Serial Port Refresh Button click
         */ 
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FindSerialPorts();
            SetControlEnabled(btnConnect, false);
        }

        /**
         * Selected port changed
         */
        private void cbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.Empty != cbPort.Text)
            {
                SetControlEnabled(btnConnect, true);
            }
            else
            {
                SetControlEnabled(btnConnect, false);
            }
        }

        /**
         * Connect button clicked
         */
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (isProgrammerConnected)
            {
                SerialDisconnect();
            }
            else
            {
                SerialConnect();
            }
        }

        /**
         * Window is closing...
         */
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isProgrammerConnected)
            {
                SerialDisconnect();
            }
        }

        /**
         * Read button clicked
         */
        private void btnRead_Click(object sender, EventArgs e)
        {
            SerialRequestRead(131072); // Read 128 kB
        }
    }
}
