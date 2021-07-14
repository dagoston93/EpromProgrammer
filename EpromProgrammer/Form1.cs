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
         * Variable declatations
         */
        string selectedFolder = "";
        int startMemoryReadAddress = 0;
        int numOfBytesToRead = 0;

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
            int memSizeInKb = supportedChips[cbSupportedChips.SelectedIndex].memorySizeKb;
            int memSizeInBytes = memSizeInKb * 1024;
            SetControlText(lblChipMemSize, memSizeInKb + " kB (" + memSizeInBytes + " bytes)");
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
            FileStream fs = null;
            Exception ex = createFile(selectedFolder, tbFileNameRead.Text, ref fs);
            
            if(!(ex is ExOK)){
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(ex.Message, "File couldn't be created!", buttons);
            }
            
            if(fs != null)
            {
                //Log("NotNull");
                try
                {
                    if(isProgrammerConnected)
                    {
                        uint dataSize = 131072;

                        SerialSendReadRequest(dataSize); // Read 128 kB
                        byte data = 0;

                        for(int i = 0; i< dataSize; i++)
                        {
                            data = (byte) serialPort.ReadByte();
                            fs.WriteByte(data);
                            SetToolStripStatusLabelText(lblStatusRight, "Reading byte: " + (i+1).ToString() + "/" + dataSize.ToString());
                        }

                        
                    }
                }
                catch(Exception exc)
                {
                    Log(exc.Message);
                }
                finally
                {
                    fs.Dispose();
                }
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

        /**
         * Read whole chip CheckBox checked changed
         */ 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool isEnabled = true;

            if (((CheckBox)sender).Checked)
            {
                isEnabled = false;
            }

            nuBytesToRead.Enabled = isEnabled;
            nuReadStartAddress.Enabled = isEnabled;
        }
    }
}
