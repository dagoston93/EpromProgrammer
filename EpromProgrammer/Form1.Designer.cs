namespace EpromProgrammer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbSupportedChips = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.lblFwVer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblConnStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblChipMemSize = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nuReadStartAddress = new System.Windows.Forms.NumericUpDown();
            this.nuBytesToRead = new System.Windows.Forms.NumericUpDown();
            this.cbReadWholeChip = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblReadFinalMemoryAddress = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFileNameRead = new System.Windows.Forms.TextBox();
            this.btn_ChooseFolder = new System.Windows.Forms.Button();
            this.tbFolderRead = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnProgram = new System.Windows.Forms.Button();
            this.nuProgramStartAddress = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.lblProgramLastAddress = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbBlankCheckResult = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nuBlankByte = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCheckBlank = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnTestNewLine = new System.Windows.Forms.Button();
            this.tbTestReadVal = new System.Windows.Forms.TextBox();
            this.btnTestClear = new System.Windows.Forms.Button();
            this.lblTestRead = new System.Windows.Forms.Label();
            this.btnTestRead = new System.Windows.Forms.Button();
            this.nuTestSend = new System.Windows.Forms.NumericUpDown();
            this.btnTestSend = new System.Windows.Forms.Button();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatusLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatusRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.label17 = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.lblFileSizeError = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuReadStartAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuBytesToRead)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuProgramStartAddress)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuBlankByte)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuTestSend)).BeginInit();
            this.ssStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSupportedChips
            // 
            this.cbSupportedChips.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupportedChips.FormattingEnabled = true;
            this.cbSupportedChips.Location = new System.Drawing.Point(143, 22);
            this.cbSupportedChips.Margin = new System.Windows.Forms.Padding(4);
            this.cbSupportedChips.Name = "cbSupportedChips";
            this.cbSupportedChips.Size = new System.Drawing.Size(252, 24);
            this.cbSupportedChips.TabIndex = 0;
            this.cbSupportedChips.SelectedIndexChanged += new System.EventHandler(this.cbSupportedChips_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select chip:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.cbPort);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbLog);
            this.groupBox1.Controls.Add(this.lblFwVer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblConnStatus);
            this.groupBox1.Location = new System.Drawing.Point(20, 549);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1031, 293);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Programmer";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnRefresh.Location = new System.Drawing.Point(245, 18);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(33, 30);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(84, 58);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 28);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbPort
            // 
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(132, 21);
            this.cbPort.Margin = new System.Windows.Forms.Padding(4);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(103, 24);
            this.cbPort.TabIndex = 6;
            this.cbPort.SelectedIndexChanged += new System.EventHandler(this.cbPort_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Choose port:";
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.White;
            this.tbLog.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbLog.Location = new System.Drawing.Point(24, 100);
            this.tbLog.Margin = new System.Windows.Forms.Padding(4);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(984, 179);
            this.tbLog.TabIndex = 4;
            // 
            // lblFwVer
            // 
            this.lblFwVer.AutoSize = true;
            this.lblFwVer.Location = new System.Drawing.Point(501, 48);
            this.lblFwVer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFwVer.Name = "lblFwVer";
            this.lblFwVer.Size = new System.Drawing.Size(27, 17);
            this.lblFwVer.TabIndex = 3;
            this.lblFwVer.Text = " ---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Firmware version:";
            // 
            // lblConnStatus
            // 
            this.lblConnStatus.AutoSize = true;
            this.lblConnStatus.Location = new System.Drawing.Point(501, 25);
            this.lblConnStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnStatus.Name = "lblConnStatus";
            this.lblConnStatus.Size = new System.Drawing.Size(94, 17);
            this.lblConnStatus.TabIndex = 3;
            this.lblConnStatus.Text = "Disconnected";
            this.lblConnStatus.TextChanged += new System.EventHandler(this.lblConnStatus_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblChipMemSize);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbSupportedChips);
            this.groupBox2.Location = new System.Drawing.Point(9, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(445, 142);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chip";
            // 
            // lblChipMemSize
            // 
            this.lblChipMemSize.AutoSize = true;
            this.lblChipMemSize.Location = new System.Drawing.Point(139, 66);
            this.lblChipMemSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChipMemSize.Name = "lblChipMemSize";
            this.lblChipMemSize.Size = new System.Drawing.Size(23, 17);
            this.lblChipMemSize.TabIndex = 4;
            this.lblChipMemSize.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 66);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Memory size:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 160);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1037, 378);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.nuReadStartAddress);
            this.tabPage1.Controls.Add(this.nuBytesToRead);
            this.tabPage1.Controls.Add(this.cbReadWholeChip);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.lblReadFinalMemoryAddress);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbFileNameRead);
            this.tabPage1.Controls.Add(this.btn_ChooseFolder);
            this.tabPage1.Controls.Add(this.tbFolderRead);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnRead);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1029, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Read";
            // 
            // nuReadStartAddress
            // 
            this.nuReadStartAddress.Enabled = false;
            this.nuReadStartAddress.Hexadecimal = true;
            this.nuReadStartAddress.Location = new System.Drawing.Point(47, 149);
            this.nuReadStartAddress.Margin = new System.Windows.Forms.Padding(4);
            this.nuReadStartAddress.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nuReadStartAddress.Name = "nuReadStartAddress";
            this.nuReadStartAddress.Size = new System.Drawing.Size(160, 22);
            this.nuReadStartAddress.TabIndex = 10;
            this.nuReadStartAddress.ValueChanged += new System.EventHandler(this.nuReadStartAddress_ValueChanged);
            // 
            // nuBytesToRead
            // 
            this.nuBytesToRead.Enabled = false;
            this.nuBytesToRead.Location = new System.Drawing.Point(27, 206);
            this.nuBytesToRead.Margin = new System.Windows.Forms.Padding(4);
            this.nuBytesToRead.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nuBytesToRead.Name = "nuBytesToRead";
            this.nuBytesToRead.Size = new System.Drawing.Size(180, 22);
            this.nuBytesToRead.TabIndex = 9;
            this.nuBytesToRead.ValueChanged += new System.EventHandler(this.nuBytesToRead_ValueChanged);
            // 
            // cbReadWholeChip
            // 
            this.cbReadWholeChip.AutoSize = true;
            this.cbReadWholeChip.Checked = true;
            this.cbReadWholeChip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReadWholeChip.Enabled = false;
            this.cbReadWholeChip.Location = new System.Drawing.Point(248, 207);
            this.cbReadWholeChip.Margin = new System.Windows.Forms.Padding(4);
            this.cbReadWholeChip.Name = "cbReadWholeChip";
            this.cbReadWholeChip.Size = new System.Drawing.Size(158, 21);
            this.cbReadWholeChip.TabIndex = 8;
            this.cbReadWholeChip.Text = "Read the whole chip";
            this.cbReadWholeChip.UseVisualStyleBackColor = true;
            this.cbReadWholeChip.CheckedChanged += new System.EventHandler(this.cbReadWholeChip_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 151);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "0x";
            // 
            // lblReadFinalMemoryAddress
            // 
            this.lblReadFinalMemoryAddress.AutoSize = true;
            this.lblReadFinalMemoryAddress.Location = new System.Drawing.Point(244, 151);
            this.lblReadFinalMemoryAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReadFinalMemoryAddress.Name = "lblReadFinalMemoryAddress";
            this.lblReadFinalMemoryAddress.Size = new System.Drawing.Size(23, 17);
            this.lblReadFinalMemoryAddress.TabIndex = 7;
            this.lblReadFinalMemoryAddress.Text = "---";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(244, 126);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 17);
            this.label11.TabIndex = 7;
            this.label11.Text = "Final memory address:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 126);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Start memory address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 183);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Number of bytes to read:";
            // 
            // tbFileNameRead
            // 
            this.tbFileNameRead.Location = new System.Drawing.Point(27, 89);
            this.tbFileNameRead.Margin = new System.Windows.Forms.Padding(4);
            this.tbFileNameRead.Name = "tbFileNameRead";
            this.tbFileNameRead.Size = new System.Drawing.Size(431, 22);
            this.tbFileNameRead.TabIndex = 4;
            this.tbFileNameRead.TextChanged += new System.EventHandler(this.tbFileNameRead_TextChanged);
            // 
            // btn_ChooseFolder
            // 
            this.btn_ChooseFolder.Location = new System.Drawing.Point(467, 39);
            this.btn_ChooseFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ChooseFolder.Name = "btn_ChooseFolder";
            this.btn_ChooseFolder.Size = new System.Drawing.Size(41, 28);
            this.btn_ChooseFolder.TabIndex = 3;
            this.btn_ChooseFolder.Text = "...";
            this.btn_ChooseFolder.UseVisualStyleBackColor = true;
            this.btn_ChooseFolder.Click += new System.EventHandler(this.btn_ChooseFolder_Click);
            // 
            // tbFolderRead
            // 
            this.tbFolderRead.BackColor = System.Drawing.Color.White;
            this.tbFolderRead.Location = new System.Drawing.Point(27, 41);
            this.tbFolderRead.Margin = new System.Windows.Forms.Padding(4);
            this.tbFolderRead.Name = "tbFolderRead";
            this.tbFolderRead.ReadOnly = true;
            this.tbFolderRead.Size = new System.Drawing.Size(431, 22);
            this.tbFolderRead.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Filename:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folder:";
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point(27, 239);
            this.btnRead.Margin = new System.Windows.Forms.Padding(4);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(100, 28);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lblFileSizeError);
            this.tabPage2.Controls.Add(this.lblFileSize);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.btnProgram);
            this.tabPage2.Controls.Add(this.nuProgramStartAddress);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.lblProgramLastAddress);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.btnBrowseFile);
            this.tabPage2.Controls.Add(this.tbFileName);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1029, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Program";
            // 
            // btnProgram
            // 
            this.btnProgram.Enabled = false;
            this.btnProgram.Location = new System.Drawing.Point(11, 166);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(75, 28);
            this.btnProgram.TabIndex = 16;
            this.btnProgram.Text = "Program";
            this.btnProgram.UseVisualStyleBackColor = true;
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click);
            // 
            // nuProgramStartAddress
            // 
            this.nuProgramStartAddress.Enabled = false;
            this.nuProgramStartAddress.Hexadecimal = true;
            this.nuProgramStartAddress.Location = new System.Drawing.Point(32, 127);
            this.nuProgramStartAddress.Margin = new System.Windows.Forms.Padding(4);
            this.nuProgramStartAddress.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nuProgramStartAddress.Name = "nuProgramStartAddress";
            this.nuProgramStartAddress.Size = new System.Drawing.Size(160, 22);
            this.nuProgramStartAddress.TabIndex = 15;
            this.nuProgramStartAddress.ValueChanged += new System.EventHandler(this.nuProgramStartAddress_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 129);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 17);
            this.label16.TabIndex = 11;
            this.label16.Text = "0x";
            // 
            // lblProgramLastAddress
            // 
            this.lblProgramLastAddress.AutoSize = true;
            this.lblProgramLastAddress.Location = new System.Drawing.Point(229, 129);
            this.lblProgramLastAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgramLastAddress.Name = "lblProgramLastAddress";
            this.lblProgramLastAddress.Size = new System.Drawing.Size(23, 17);
            this.lblProgramLastAddress.TabIndex = 12;
            this.lblProgramLastAddress.Text = "---";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(229, 104);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(151, 17);
            this.label18.TabIndex = 13;
            this.label18.Text = "Final memory address:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 104);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(151, 17);
            this.label19.TabIndex = 14;
            this.label19.Text = "Start memory address:";
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(470, 29);
            this.btnBrowseFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(41, 28);
            this.btnBrowseFile.TabIndex = 4;
            this.btnBrowseFile.Text = "...";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.BackColor = System.Drawing.Color.White;
            this.tbFileName.Location = new System.Drawing.Point(11, 32);
            this.tbFileName.Margin = new System.Windows.Forms.Padding(4);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(431, 22);
            this.tbFileName.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 11);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 17);
            this.label15.TabIndex = 2;
            this.label15.Text = "File:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.tbBlankCheckResult);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.nuBlankByte);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.btnCheckBlank);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1029, 349);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Blank check";
            // 
            // tbBlankCheckResult
            // 
            this.tbBlankCheckResult.BackColor = System.Drawing.Color.White;
            this.tbBlankCheckResult.Location = new System.Drawing.Point(213, 32);
            this.tbBlankCheckResult.Margin = new System.Windows.Forms.Padding(4);
            this.tbBlankCheckResult.Multiline = true;
            this.tbBlankCheckResult.Name = "tbBlankCheckResult";
            this.tbBlankCheckResult.ReadOnly = true;
            this.tbBlankCheckResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBlankCheckResult.Size = new System.Drawing.Size(797, 174);
            this.tbBlankCheckResult.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(209, 9);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Report:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 34);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 17);
            this.label13.TabIndex = 3;
            this.label13.Text = "0x";
            // 
            // nuBlankByte
            // 
            this.nuBlankByte.Hexadecimal = true;
            this.nuBlankByte.Location = new System.Drawing.Point(41, 32);
            this.nuBlankByte.Margin = new System.Windows.Forms.Padding(4);
            this.nuBlankByte.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nuBlankByte.Name = "nuBlankByte";
            this.nuBlankByte.Size = new System.Drawing.Size(83, 22);
            this.nuBlankByte.TabIndex = 2;
            this.nuBlankByte.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 11);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Value of erased byte:";
            // 
            // btnCheckBlank
            // 
            this.btnCheckBlank.Enabled = false;
            this.btnCheckBlank.Location = new System.Drawing.Point(27, 64);
            this.btnCheckBlank.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckBlank.Name = "btnCheckBlank";
            this.btnCheckBlank.Size = new System.Drawing.Size(100, 28);
            this.btnCheckBlank.TabIndex = 0;
            this.btnCheckBlank.Text = "Check";
            this.btnCheckBlank.UseVisualStyleBackColor = true;
            this.btnCheckBlank.Click += new System.EventHandler(this.btnCheckBlank_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.btnTestNewLine);
            this.tabPage4.Controls.Add(this.tbTestReadVal);
            this.tabPage4.Controls.Add(this.btnTestClear);
            this.tabPage4.Controls.Add(this.lblTestRead);
            this.tabPage4.Controls.Add(this.btnTestRead);
            this.tabPage4.Controls.Add(this.nuTestSend);
            this.tabPage4.Controls.Add(this.btnTestSend);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1029, 349);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Test";
            // 
            // btnTestNewLine
            // 
            this.btnTestNewLine.Location = new System.Drawing.Point(270, 202);
            this.btnTestNewLine.Name = "btnTestNewLine";
            this.btnTestNewLine.Size = new System.Drawing.Size(75, 30);
            this.btnTestNewLine.TabIndex = 6;
            this.btnTestNewLine.Text = "New line";
            this.btnTestNewLine.UseVisualStyleBackColor = true;
            this.btnTestNewLine.Click += new System.EventHandler(this.btnTestNewLine_Click);
            // 
            // tbTestReadVal
            // 
            this.tbTestReadVal.BackColor = System.Drawing.Color.White;
            this.tbTestReadVal.Location = new System.Drawing.Point(270, 18);
            this.tbTestReadVal.Multiline = true;
            this.tbTestReadVal.Name = "tbTestReadVal";
            this.tbTestReadVal.ReadOnly = true;
            this.tbTestReadVal.Size = new System.Drawing.Size(742, 169);
            this.tbTestReadVal.TabIndex = 5;
            // 
            // btnTestClear
            // 
            this.btnTestClear.Location = new System.Drawing.Point(363, 202);
            this.btnTestClear.Name = "btnTestClear";
            this.btnTestClear.Size = new System.Drawing.Size(75, 30);
            this.btnTestClear.TabIndex = 4;
            this.btnTestClear.Text = "Clear";
            this.btnTestClear.UseVisualStyleBackColor = true;
            this.btnTestClear.Click += new System.EventHandler(this.btnTestClear_Click);
            // 
            // lblTestRead
            // 
            this.lblTestRead.AutoSize = true;
            this.lblTestRead.Location = new System.Drawing.Point(196, 181);
            this.lblTestRead.Name = "lblTestRead";
            this.lblTestRead.Size = new System.Drawing.Size(31, 17);
            this.lblTestRead.TabIndex = 3;
            this.lblTestRead.Text = "test";
            // 
            // btnTestRead
            // 
            this.btnTestRead.Location = new System.Drawing.Point(11, 46);
            this.btnTestRead.Name = "btnTestRead";
            this.btnTestRead.Size = new System.Drawing.Size(102, 29);
            this.btnTestRead.TabIndex = 2;
            this.btnTestRead.Text = "Read byte";
            this.btnTestRead.UseVisualStyleBackColor = true;
            this.btnTestRead.Click += new System.EventHandler(this.btnTestRead_Click);
            // 
            // nuTestSend
            // 
            this.nuTestSend.Hexadecimal = true;
            this.nuTestSend.Location = new System.Drawing.Point(11, 18);
            this.nuTestSend.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nuTestSend.Name = "nuTestSend";
            this.nuTestSend.Size = new System.Drawing.Size(120, 22);
            this.nuTestSend.TabIndex = 1;
            // 
            // btnTestSend
            // 
            this.btnTestSend.Location = new System.Drawing.Point(152, 18);
            this.btnTestSend.Name = "btnTestSend";
            this.btnTestSend.Size = new System.Drawing.Size(75, 23);
            this.btnTestSend.TabIndex = 0;
            this.btnTestSend.Text = "Send";
            this.btnTestSend.UseVisualStyleBackColor = true;
            this.btnTestSend.Click += new System.EventHandler(this.btnTestSend_Click);
            // 
            // ssStatus
            // 
            this.ssStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusLeft,
            this.pbProgress,
            this.lblStatusRight});
            this.ssStatus.Location = new System.Drawing.Point(0, 890);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ssStatus.Size = new System.Drawing.Size(1067, 26);
            this.ssStatus.TabIndex = 5;
            this.ssStatus.Text = "statusStrip1";
            // 
            // lblStatusLeft
            // 
            this.lblStatusLeft.AutoSize = false;
            this.lblStatusLeft.Name = "lblStatusLeft";
            this.lblStatusLeft.Size = new System.Drawing.Size(389, 21);
            this.lblStatusLeft.Spring = true;
            this.lblStatusLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbProgress
            // 
            this.pbProgress.AutoSize = false;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(267, 20);
            this.pbProgress.Step = 1;
            // 
            // lblStatusRight
            // 
            this.lblStatusRight.AutoSize = false;
            this.lblStatusRight.Name = "lblStatusRight";
            this.lblStatusRight.Size = new System.Drawing.Size(389, 21);
            this.lblStatusRight.Spring = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 62);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 17);
            this.label17.TabIndex = 17;
            this.label17.Text = "File size:";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(101, 62);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(23, 17);
            this.lblFileSize.TabIndex = 18;
            this.lblFileSize.Text = "---";
            // 
            // lblFileSizeError
            // 
            this.lblFileSizeError.AutoSize = true;
            this.lblFileSizeError.ForeColor = System.Drawing.Color.Red;
            this.lblFileSizeError.Location = new System.Drawing.Point(309, 62);
            this.lblFileSizeError.Name = "lblFileSizeError";
            this.lblFileSizeError.Size = new System.Drawing.Size(12, 17);
            this.lblFileSizeError.TabIndex = 19;
            this.lblFileSizeError.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 916);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EPROM Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuReadStartAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuBytesToRead)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuProgramStartAddress)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuBlankByte)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuTestSend)).EndInit();
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSupportedChips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFwVer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblConnStatus;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblChipMemSize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btn_ChooseFolder;
        private System.Windows.Forms.TextBox tbFolderRead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFileNameRead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusLeft;
        private System.Windows.Forms.ToolStripProgressBar pbProgress;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusRight;
        private System.Windows.Forms.CheckBox cbReadWholeChip;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nuBytesToRead;
        private System.Windows.Forms.NumericUpDown nuReadStartAddress;
        private System.Windows.Forms.Label lblReadFinalMemoryAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbBlankCheckResult;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nuTestSend;
        private System.Windows.Forms.Button btnTestSend;
        private System.Windows.Forms.Label lblTestRead;
        private System.Windows.Forms.Button btnTestRead;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nuBlankByte;
        private System.Windows.Forms.Button btnCheckBlank;
        private System.Windows.Forms.Button btnTestClear;
        private System.Windows.Forms.TextBox tbTestReadVal;
        private System.Windows.Forms.Button btnTestNewLine;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnProgram;
        private System.Windows.Forms.NumericUpDown nuProgramStartAddress;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblProgramLastAddress;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblFileSizeError;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Label label17;
    }
}

