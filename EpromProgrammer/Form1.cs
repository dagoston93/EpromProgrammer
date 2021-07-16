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
            if (string.Empty != cbSupportedChips.Text)
            {
                int memSizeInKb = supportedChips[cbSupportedChips.SelectedIndex].memorySizeKb;
                int memSizeInBytes = memSizeInKb * 1024;
                SetControlText(lblChipMemSize, memSizeInKb + " kB (" + memSizeInBytes + " bytes)");

                SetControlEnabled(cbReadWholeChip, true);
                SetControlEnabled(btnRead, true);
                SetControlEnabled(nuReadStartAddress, false);
                SetControlEnabled(nuBytesToRead, false);

                SetCheckBoxChecked(cbReadWholeChip, true);

                SetNumericUpDownMinMax(nuBytesToRead, 1, memSizeInBytes);
                SetNumericUpDownMinMax(nuReadStartAddress, 0, memSizeInBytes - 1);
                SetNumericUpDownValue(nuBytesToRead, memSizeInBytes);
                SetNumericUpDownValue(nuReadStartAddress, 0);
            }
            else
            {
                SetControlEnabled(cbReadWholeChip, false);
                SetControlEnabled(btnRead, false);
                SetControlEnabled(nuReadStartAddress, false);
                SetControlEnabled(nuBytesToRead, false);
                SetControlText(lblChipMemSize, "---");
            }
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
            try
            {
                using (FileManager fileManager = new FileManager())
                {
                    Exception result = fileManager.CreateFile(selectedFolder, tbFileNameRead.Text);

                    if (result is FileAlreadyExistsException)
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult dialogResult = MessageBox.Show(result.Message + "\r\nDo you want to overwrite?", "File already exists!", buttons);

                        if (dialogResult == DialogResult.Yes)
                        {
                            result = fileManager.CreateFile(selectedFolder, tbFileNameRead.Text, true);
                        }
                        else
                        {
                            throw result;
                        }
                    }

                    if (!IsSuccessful(result))
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(result.Message, "File couldn't be created!", buttons);
                        throw result;
                    }

                    uint dataSize = 131072; // Read 128 kB

                    Log("Reading " + dataSize + " bytes of data...");

                    result = serialComm.SerialSendReadRequest(dataSize);
                    ThrowIfFailed(result);

                    byte data = 0;

                    for (int i = 0; i < dataSize; i++)
                    {
                        SetToolStripStatusLabelText(lblStatusRight, "Reading byte: " + (i + 1).ToString() + "/" + dataSize.ToString());

                        result = serialComm.ReadByte(ref data);
                        ThrowIfFailed(result);

                        result = fileManager.WriteByte(data);
                        ThrowIfFailed(result);
                    }

                    Log("Reading " + dataSize + " bytes of data successful.");
                }    
            }
            catch(Exception ex)
            {
                Log(ex.Message);
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
        private void btn_ChooseFolder_Click(object sender, EventArgs e)
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
        private void cbReadWholeChip_CheckedChanged(object sender, EventArgs e)
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
