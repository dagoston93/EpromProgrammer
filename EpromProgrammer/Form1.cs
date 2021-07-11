using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
         * Variable declatations
         */
        string selectedFolder = "";

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
            string path = selectedFolder + @"\" + tbFileNameRead.Text;
            /**
             * As test create an empty file
             */ 
            if(!File.Exists(path)){
                try
                {
                    File.Create(path);
                }
                catch(Exception ex)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(ex.Message, "File couldn't be created!", buttons);
                }
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(path + " already exists.\r\n Do you want to overwrite?", "File exists!", buttons);

                if(result == DialogResult.Yes)
                {
                    MessageBox.Show("Will overwrite!");
                }
            }

            if (isProgrammerConnected)
            {
                SerialRequestRead(131072); // Read 128 kB
            }
        }

        /**
         * Choose folder button clicked (Read)
         */ 
        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (!string.IsNullOrEmpty(selectedFolder))
                {
                    dialog.SelectedPath = selectedFolder;
                }

                DialogResult result = dialog.ShowDialog();

                if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    SetControlText(tbFolderRead, dialog.SelectedPath);
                    selectedFolder = dialog.SelectedPath;
                }
            }
        }
    }
}
