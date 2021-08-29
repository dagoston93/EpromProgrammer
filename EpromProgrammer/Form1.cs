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
        string readSelectedFolder = "";
        string writeSelectedFile = "";

        uint selChipMaxMemAddress = 0;
        uint selChipMemSizeBytes = 0;

        uint numOfBytesToRead = 0;
        uint readFinalAddress = 0;
        uint readStartAddress = 0;
        uint selectedFileSize = 0;

        bool isSelectedFileTooLarge = false;

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

                SetNumericUpDownMinMax(nuProgramStartAddress, 0, selChipMemSizeBytes - 1);
                SetNumericUpDownValue(nuProgramStartAddress, 0);

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
            ValidateProgramForm();
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
                    Exception result = fileManager.CreateFile(readSelectedFolder, tbFileNameRead.Text);

                    if (result is FileAlreadyExistsException)
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult dialogResult = MessageBox.Show(result.Message + "\r\nDo you want to overwrite?", "File already exists!", buttons);

                        if (dialogResult == DialogResult.Yes)
                        {
                            result = fileManager.CreateFile(readSelectedFolder, tbFileNameRead.Text, true);
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
                if (!string.IsNullOrEmpty(readSelectedFolder))
                {
                    dialog.SelectedPath = readSelectedFolder;
                }

                DialogResult result = dialog.ShowDialog();

                if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    SetControlText(tbFolderRead, dialog.SelectedPath);
                    readSelectedFolder = dialog.SelectedPath;

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

            if (string.IsNullOrEmpty(readSelectedFolder))
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
         * Validate program form
         */ 
        private void ValidateProgramForm()
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

            if (string.IsNullOrEmpty(writeSelectedFile))
            {
                isFormValid = false;
            }

            if(selectedFileSize == 0)
            {
                isFormValid = false;
            }

            // Check if file fits in ROM
            if (selectedFileSize > selChipMemSizeBytes)
            {
                isFormValid = false;

                SetControlText(lblFileSizeError, "Selected file is too large!");
                SetControlEnabled(nuProgramStartAddress, false);
                SetNumericUpDownValue(nuProgramStartAddress, 0);
            }
            else
            {
                // Calculate the max start address
                uint lastPossibleAddress = selChipMemSizeBytes - selectedFileSize;

                // If file is exactly same size as ROM, we start programming from address 0x00
                bool nuEnabled = true;
                if (selectedFileSize == selChipMemSizeBytes)
                {
                    nuEnabled = false;
                }
                SetControlEnabled(nuProgramStartAddress, nuEnabled);

                SetNumericUpDownValue(nuProgramStartAddress, 0);
                SetNumericUpDownMinMax(nuProgramStartAddress, 0, lastPossibleAddress);
                SetControlText(lblProgramLastAddress, (selectedFileSize - 1).ToString("X"));

                SetControlText(lblFileSizeError, "");
            }

            SetControlEnabled(btnProgram, isFormValid);
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
            ValidateProgramForm();
        }

        /**
         * Entered file name changed
         */ 
        private void tbFileNameRead_TextChanged(object sender, EventArgs e)
        {
            ValidateReadForm();
        }

        /**
         * Program button click
         */
        private void btnProgram_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt user to setup correctly
                DialogResult dialogRes = MessageBox.Show(
                    "1. Set voltage on PSU to +13V.\r\n" +
                    "2. Check the voltage.\r\n" +
                    "3. Connect PSU to programming shield.\r\n" +
                    "4. Insert IC to socket.\r\n" +
                    "5. Flip switches on shiled to Programming mode.", 
                    "Actions required", 
                    MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Information
                );

                if(dialogRes != DialogResult.OK)
                {
                    throw new Exception("Programming has been cancelled by user.");
                }

                Exception result = serialComm.SerialSendWriteRequest(selectedFileSize, (uint)nuProgramStartAddress.Value);
                ThrowIfFailed(result);

                Log("Programming in progress...");

                // Send file -> Programming
                result = SendFileToProgrammer();
                ThrowIfFailed(result);

                result = serialComm.ExpectOK();
                ThrowIfFailed(result);

                // Send file again -> Checking with VPP = 13 V
                result = SendFileToProgrammer();
                ThrowIfFailed(result);

                result = serialComm.ExpectOK();
                ThrowIfFailed(result);

                // Prompt user to set 5V
                dialogRes = MessageBox.Show(
                    "Set both switches on the shield to normal.",
                    "Set switches to normal.",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information
                );

                if (dialogRes != DialogResult.OK)
                {
                    throw new Exception("Final check has been cancelled by user.");
                }

                // Send file last time -> Checking with VPP = 5V
                result = SendFileToProgrammer();
                ThrowIfFailed(result);

                result = serialComm.ExpectOK();
                ThrowIfFailed(result);

                Log("Programming finished.");

            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        /**
         * Sends the file to the chip
         */
        private Exception SendFileToProgrammer()
        {
            Exception retVal = new ExOK();
            FileStream fs = null;

            try
            {
                fs = new FileStream(writeSelectedFile, FileMode.Open);

                for(uint i = 0; i < selectedFileSize; i++)
                {
                    byte data = (byte) fs.ReadByte();
                    serialComm.SendByte(data);
                }
            }
            catch (Exception ex)
            {
                retVal = ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            return retVal;
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


        /**
         * Test page control event handlers
         */ 
        private void btnTestSend_Click(object sender, EventArgs e)
        {
            serialComm.testSendByte((byte)nuTestSend.Value);
        }

        private void btnTestRead_Click(object sender, EventArgs e)
        {
            tbTestReadVal.Text += "  0x" + serialComm.testReadByte().ToString("X");
        }

        private void btnTestClear_Click(object sender, EventArgs e)
        {
            tbTestReadVal.Text = "";
        }

        private void btnTestNewLine_Click(object sender, EventArgs e)
        {
            tbTestReadVal.Text += "\r\n";
        }

        /**
         * Program -> File select button onClick()
         */ 
        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string initDir;
                if(writeSelectedFile != "")
                {
                    initDir = writeSelectedFile;
                }
                else
                {
                    initDir = "c:\\";
                }
                
                openFileDialog.InitialDirectory = initDir;
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    writeSelectedFile = openFileDialog.FileName;
                    SetControlText(tbFileName, writeSelectedFile);

                    // Get the file size
                    FileInfo info = new FileInfo(writeSelectedFile);
                    selectedFileSize = (uint) info.Length;
                    string lengthStr = selectedFileSize.ToString() + " bytes";
                    SetControlText(lblFileSize, lengthStr);

                    ValidateProgramForm();
                }
            }
        }

        /**
         * ProgramStartAddress numeric up/down value changed
         */
        private void nuProgramStartAddress_ValueChanged(object sender, EventArgs e)
        {
            uint finalAddress = (uint) nuProgramStartAddress.Value + selectedFileSize - 1;
            SetControlText(lblProgramLastAddress, finalAddress.ToString("X"));
        }

        
    }
}
