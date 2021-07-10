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
            cbSupportedChips.Items.Clear();

            foreach(Chip chip in supportedChips)
            {
                cbSupportedChips.Items.Add(chip.name);
            }

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
            lblChipMemSize.Text = supportedChips[cbSupportedChips.SelectedIndex].memorySizeKb.ToString() + " kB";
        }

        /**
         * Serial Port Refresh Button click
         */ 
        private void button1_Click(object sender, EventArgs e)
        {
            FindSerialPorts();
        }
    }
}
