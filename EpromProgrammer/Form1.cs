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

        uint selChipMaxMemAddress = 0;
        uint selChipMemSizeBytes = 0;

        uint numOfBytesToRead = 0;
        uint readFinalAddress = 0;
        uint readStartAddress = 0;

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
                uint memSizeInKb = supportedChips[cbSupportedChips.SelectedIndex].memorySizeKb;

                selChipMemSizeBytes = memSizeInKb * 1024;
                selChipMaxMemAddress = selChipMemSizeBytes - 1;
                readFinalAddress = selChipMaxMemAddress;
                readStartAddress = 0;
                numOfBytesToRead = selChipMemSizeBytes;

                SetControlText(lblChipMemSize, memSizeInKb + " kB (" + selChipMemSizeBytes + " bytes)");
                SetControlText(lblReadFinalMemoryAddress, "0x" + readFinalAddress.ToString("X"));

                SetControlEnabled(cbReadWholeChip, true);
                //SetControlEnabled(btnRead, true);
                SetControlEnabled(nuReadStartAddress, false);
                SetControlEnabled(nuBytesToRead, false);

                SetNumericUpDownMinMax(nuBytesToRead, 1, selChipMemSizeBytes);
                SetNumericUpDownMinMax(nuReadStartAddress, 0, selChipMemSizeBytes - 1);
                SetNumericUpDownValue(nuBytesToRead, selChipMemSizeBytes);
                SetNumericUpDownValue(nuReadStartAddress, 0);

                SetCheckBoxChecked(cbReadWholeChip, true);
            }
            else
            {
                SetControlEnabled(cbReadWholeChip, false);
                //SetControlEnabled(btnRead, false);
                SetControlEnabled(nuReadStartAddress, false);
                SetControlEnabled(nuBytesToRead, false);
                SetControlText(lblChipMemSize, "---");
            }

            ValidateReadForm();
            ValidateBlankCheckForm();
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

                    uint dataSize = numOfBytesToRead;

                    Log("Reading " + dataSize + " bytes of data from address 0x" + readStartAddress.ToString("X")  + " ...");

                    result = serialComm.SerialSendReadRequest(dataSize, readStartAddress);
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

                    ValidateReadForm();
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
                nuBytesToRead.Value = selChipMemSizeBytes;
                nuReadStartAddress.Value = 0;

                numOfBytesToRead = selChipMemSizeBytes;
                lblReadFinalMemoryAddress.Text = "0x" + selChipMaxMemAddress.ToString("X");

                readStartAddress = 0;
                readFinalAddress = selChipMaxMemAddress;
            }

            nuBytesToRead.Enabled = isEnabled;
            nuReadStartAddress.Enabled = isEnabled;
        }

        /**
         * Validate read form
         */
        private void ValidateReadForm()
        {
            bool isFormValid = true;

            if (string.IsNullOrEmpty(cbSupportedChips.Text))
            {
                isFormValid = false;
            }

            if (!serialComm.isProgrammerConnected)
            {
                isFormValid = false;
            }

            if (string.IsNullOrEmpty(selectedFolder))
            {
                isFormValid = false;
            }

            if (string.IsNullOrEmpty(tbFileNameRead.Text))
            {
                isFormValid = false;
            }

            SetControlEnabled(btnRead, isFormValid);
        }

        /**
         * Validate blank check form
         */ 
        private void ValidateBlankCheckForm()
        {
            bool isFormValid = true;

            if (string.IsNullOrEmpty(cbSupportedChips.Text))
            {
                isFormValid = false;
            }

            if (!serialComm.isProgrammerConnected)
            {
                isFormValid = false;
            }

            SetControlEnabled(btnCheckBlank, isFormValid);
        }

        /**
         * When num of bytes to read being changed
         */
        private void nuBytesToRead_ValueChanged(object sender, EventArgs e)
        {
            numOfBytesToRead = (uint)nuBytesToRead.Value;

            if ((readStartAddress + numOfBytesToRead) > selChipMemSizeBytes)
            {
                uint lowestAddress = selChipMemSizeBytes - numOfBytesToRead;
                readStartAddress = lowestAddress;
                SetNumericUpDownValue(nuReadStartAddress, lowestAddress);
                //nuReadStartAddress.Value = lowestAddress;
            }

            readFinalAddress = (readStartAddress + numOfBytesToRead) - 1;
            SetControlText(lblReadFinalMemoryAddress, "0x" + readFinalAddress.ToString("X"));
        }

        /**
         * When read start address being changed
         */
        private void nuReadStartAddress_ValueChanged(object sender, EventArgs e)
        {
            readStartAddress = (uint)nuReadStartAddress.Value;

            if ((readStartAddress + numOfBytesToRead) > selChipMemSizeBytes)
            {
                uint maxNumOfBytesToRead = selChipMemSizeBytes - (uint)nuReadStartAddress.Value;
                numOfBytesToRead = maxNumOfBytesToRead;
                //nuBytesToRead.Value = maxNumOfBytesToRead;
                SetNumericUpDownValue(nuBytesToRead, maxNumOfBytesToRead);
            }

            readFinalAddress = (readStartAddress + numOfBytesToRead) - 1;
            SetControlText(lblReadFinalMemoryAddress, "0x" + readFinalAddress.ToString("X"));
        }

        /**
         * Connection status label changed. - we need to validate form.
         */  
        private void lblConnStatus_TextChanged(object sender, EventArgs e)
        {
            ValidateReadForm();
            ValidateBlankCheckForm();
        }

        /**
         * Entered file name changed
         */ 
        private void tbFileNameRead_TextChanged(object sender, EventArgs e)
        {
            ValidateReadForm();
        }

        /**
         * Blank check button clicked
         */ 
        private void btnCheckBlank_Click(object sender, EventArgs e)
        {
            try
            {
                Exception result = serialComm.SerialSendReadRequest(selChipMemSizeBytes, 0);
                ThrowIfFailed(result);

                Log("Checking if chip is erased ("+ selChipMemSizeBytes +" bytes)...");

                byte data = 0;
                bool notErasedBlockStarted = false;
                uint firstByteNotErased = 0;
                byte erasedValue = (byte) nuBlankByte.Value;
                uint numOfNotErasedBytes = 0;

                for(uint i = 0; i < selChipMemSizeBytes; i++)
                {
                    result = serialComm.ReadByte(ref data);
                    ThrowIfFailed(result);

                    if(data != erasedValue)
                    {
                        numOfNotErasedBytes++;

                        if (!notErasedBlockStarted)
                        {
                            notErasedBlockStarted = true;
                            firstByteNotErased = i;
                        }
                    }
                    else
                    {
                        if (notErasedBlockStarted)
                        {
                            notErasedBlockStarted = false;
                            uint blockSize = i - firstByteNotErased;
                            if(blockSize == 1)
                            {
                                DiffLog("Not erased byte found: 0x" + firstByteNotErased.ToString("X"));
                            }
                            else
                            {
                                DiffLog("Block of not erased bytes found: 0x" + firstByteNotErased.ToString("X")
                                    + " - 0x" + i.ToString("X") + " (" + blockSize + " bytes)");
                            }
                            
                        }
                    }
                }

                if(numOfNotErasedBytes == 0)
                {
                    Log("Check complete. Chip is fully erased!");
                }
                else
                {
                    Log("Check complete. Total not erased bytes: " + numOfNotErasedBytes);
                }
                
            }
            catch(Exception ex)
            {
                Log(ex.Message);
            }
        }
    }
}
