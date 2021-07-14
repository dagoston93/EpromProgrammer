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
         * Objects
         */
        SerialComm serialComm;

        /**
         * Variable declatations
         */
        string selectedFolder = "";
        uint startMemoryReadAddress = 0;
        uint numOfBytesToRead = 0;

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
            serialComm = new SerialComm();

            // Find serial ports
            RefreshAvailableSerialPorts();
        }

        private void Form1_Load(object sender, EventArgs e) {}

        /**
         * Refresh available serial ports
         */ 
        private void RefreshAvailableSerialPorts()
        {
            string[] availablePorts = serialComm.FindPorts();
            ClearComboBox(cbPort);
            AddRangeComboBox(cbPort, availablePorts);
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
            RefreshAvailableSerialPorts();
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
            if (serialComm.isProgrammerConnected)
            {
                Exception result = serialComm.Disconnect();

                if (IsSuccessful(result))
                {
                    Log("Disconnected from port " + cbPort.Text + ". ");
                }
                else
                {
                    Log(result.Message);
                }

                SetControlEnabled(cbPort, true);
                SetControlEnabled(btnRefresh, true);
                SetControlText(btnConnect, "Connect");
                SetControlText(lblConnStatus, "Disconnected");
            }
            else
            {
                Log("Connecting to " + cbPort.Text + "...");

                Exception result = serialComm.Connect(cbPort.Text);

                if (IsSuccessful(result))
                {
                    Log("Connected succesfully!");
                    SetControlText(lblConnStatus, "Conencted");
                    SetControlText(btnConnect, "Disconnect");
                    SetControlEnabled(cbPort, false);
                    SetControlEnabled(btnRefresh, false);
                }
                else
                {
                    Log(result.Message);
                }
            }
        }

        /**
         * Window is closing...
         */
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialComm.isProgrammerConnected)
            {
                serialComm.Disconnect();
            }
        }

        /**
         * Read button clicked
         */
        private void btnRead_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            Exception result = createFile(selectedFolder, tbFileNameRead.Text, ref fs);
            
            if(!IsSuccessful(result)){
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(result.Message, "File couldn't be created!", buttons);
            }
            
            if(fs != null) // Refactor
            {
                try
                {
                    if(serialComm.isProgrammerConnected) // TODO: Refactor this check to SerialComm
                    {
                        uint dataSize = 131072; // Read 128 kB

                        Log("Reading " + dataSize + " bytes of data...");

                        result = serialComm.SerialSendReadRequest(dataSize);
                        ThrowIfFailed(result);

                        byte data = 0;

                        for(int i = 0; i< dataSize; i++)
                        {
                            result = serialComm.ReadByte(ref data);
                            ThrowIfFailed(result);

                            fs.WriteByte(data);
                            SetToolStripStatusLabelText(lblStatusRight, "Reading byte: " + (i+1).ToString() + "/" + dataSize.ToString());
                        }

                        Log("Reading " + dataSize + " bytes of data successful.");
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
         * Determines whether the operation was successful or not
         */ 
        private bool IsSuccessful(Exception e)
        {
            return (e is ExOK);
        }

        /**
         * Throws exception further if operation was not successful
         */
        private void ThrowIfFailed(Exception e)
        {
            if(!(e is ExOK))
            {
                throw e;
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
