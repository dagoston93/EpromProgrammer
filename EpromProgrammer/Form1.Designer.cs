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
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFileNameRead = new System.Windows.Forms.TextBox();
            this.btn_ChooseFolder = new System.Windows.Forms.Button();
            this.tbFolderRead = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatusLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatusRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuReadStartAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuBytesToRead)).BeginInit();
            this.ssStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSupportedChips
            // 
            this.cbSupportedChips.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupportedChips.FormattingEnabled = true;
            this.cbSupportedChips.Location = new System.Drawing.Point(107, 18);
            this.cbSupportedChips.Name = "cbSupportedChips";
            this.cbSupportedChips.Size = new System.Drawing.Size(190, 21);
            this.cbSupportedChips.TabIndex = 0;
            this.cbSupportedChips.SelectedIndexChanged += new System.EventHandler(this.cbSupportedChips_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
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
            this.groupBox1.Location = new System.Drawing.Point(15, 446);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(773, 238);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Programmer";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnRefresh.Location = new System.Drawing.Point(184, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 24);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(63, 47);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbPort
            // 
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(99, 17);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(78, 21);
            this.cbPort.TabIndex = 6;
            this.cbPort.SelectedIndexChanged += new System.EventHandler(this.cbPort_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Choose port:";
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.White;
            this.tbLog.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbLog.Location = new System.Drawing.Point(18, 81);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(739, 146);
            this.tbLog.TabIndex = 4;
            // 
            // lblFwVer
            // 
            this.lblFwVer.AutoSize = true;
            this.lblFwVer.Location = new System.Drawing.Point(376, 39);
            this.lblFwVer.Name = "lblFwVer";
            this.lblFwVer.Size = new System.Drawing.Size(19, 13);
            this.lblFwVer.TabIndex = 3;
            this.lblFwVer.Text = " ---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Firmware version:";
            // 
            // lblConnStatus
            // 
            this.lblConnStatus.AutoSize = true;
            this.lblConnStatus.Location = new System.Drawing.Point(376, 20);
            this.lblConnStatus.Name = "lblConnStatus";
            this.lblConnStatus.Size = new System.Drawing.Size(73, 13);
            this.lblConnStatus.TabIndex = 3;
            this.lblConnStatus.Text = "Disconnected";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblChipMemSize);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbSupportedChips);
            this.groupBox2.Location = new System.Drawing.Point(7, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 115);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chip";
            // 
            // lblChipMemSize
            // 
            this.lblChipMemSize.AutoSize = true;
            this.lblChipMemSize.Location = new System.Drawing.Point(104, 54);
            this.lblChipMemSize.Name = "lblChipMemSize";
            this.lblChipMemSize.Size = new System.Drawing.Size(16, 13);
            this.lblChipMemSize.TabIndex = 4;
            this.lblChipMemSize.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Memory size:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 130);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 307);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.nuReadStartAddress);
            this.tabPage1.Controls.Add(this.nuBytesToRead);
            this.tabPage1.Controls.Add(this.cbReadWholeChip);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbFileNameRead);
            this.tabPage1.Controls.Add(this.btn_ChooseFolder);
            this.tabPage1.Controls.Add(this.tbFolderRead);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnRead);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(770, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Read";
            // 
            // nuReadStartAddress
            // 
            this.nuReadStartAddress.Enabled = false;
            this.nuReadStartAddress.Hexadecimal = true;
            this.nuReadStartAddress.Location = new System.Drawing.Point(35, 121);
            this.nuReadStartAddress.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nuReadStartAddress.Name = "nuReadStartAddress";
            this.nuReadStartAddress.Size = new System.Drawing.Size(120, 20);
            this.nuReadStartAddress.TabIndex = 10;
            // 
            // nuBytesToRead
            // 
            this.nuBytesToRead.Enabled = false;
            this.nuBytesToRead.Location = new System.Drawing.Point(20, 167);
            this.nuBytesToRead.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nuBytesToRead.Name = "nuBytesToRead";
            this.nuBytesToRead.Size = new System.Drawing.Size(135, 20);
            this.nuBytesToRead.TabIndex = 9;
            // 
            // cbReadWholeChip
            // 
            this.cbReadWholeChip.AutoSize = true;
            this.cbReadWholeChip.Checked = true;
            this.cbReadWholeChip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReadWholeChip.Enabled = false;
            this.cbReadWholeChip.Location = new System.Drawing.Point(176, 122);
            this.cbReadWholeChip.Name = "cbReadWholeChip";
            this.cbReadWholeChip.Size = new System.Drawing.Size(124, 17);
            this.cbReadWholeChip.TabIndex = 8;
            this.cbReadWholeChip.Text = "Read the whole chip";
            this.cbReadWholeChip.UseVisualStyleBackColor = true;
            this.cbReadWholeChip.CheckedChanged += new System.EventHandler(this.cbReadWholeChip_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "0x";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Start memory address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Number of bytes to read:";
            // 
            // tbFileNameRead
            // 
            this.tbFileNameRead.Location = new System.Drawing.Point(20, 72);
            this.tbFileNameRead.Name = "tbFileNameRead";
            this.tbFileNameRead.Size = new System.Drawing.Size(324, 20);
            this.tbFileNameRead.TabIndex = 4;
            // 
            // btn_ChooseFolder
            // 
            this.btn_ChooseFolder.Location = new System.Drawing.Point(350, 32);
            this.btn_ChooseFolder.Name = "btn_ChooseFolder";
            this.btn_ChooseFolder.Size = new System.Drawing.Size(31, 23);
            this.btn_ChooseFolder.TabIndex = 3;
            this.btn_ChooseFolder.Text = "...";
            this.btn_ChooseFolder.UseVisualStyleBackColor = true;
            this.btn_ChooseFolder.Click += new System.EventHandler(this.btn_ChooseFolder_Click);
            // 
            // tbFolderRead
            // 
            this.tbFolderRead.BackColor = System.Drawing.Color.White;
            this.tbFolderRead.Location = new System.Drawing.Point(20, 33);
            this.tbFolderRead.Name = "tbFolderRead";
            this.tbFolderRead.ReadOnly = true;
            this.tbFolderRead.Size = new System.Drawing.Size(324, 20);
            this.tbFolderRead.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Filename:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folder:";
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point(20, 194);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(770, 281);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Program";
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusLeft,
            this.pbProgress,
            this.lblStatusRight});
            this.ssStatus.Location = new System.Drawing.Point(0, 722);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(800, 22);
            this.ssStatus.TabIndex = 5;
            this.ssStatus.Text = "statusStrip1";
            // 
            // lblStatusLeft
            // 
            this.lblStatusLeft.AutoSize = false;
            this.lblStatusLeft.Name = "lblStatusLeft";
            this.lblStatusLeft.Size = new System.Drawing.Size(291, 17);
            this.lblStatusLeft.Spring = true;
            this.lblStatusLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbProgress
            // 
            this.pbProgress.AutoSize = false;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(200, 16);
            this.pbProgress.Step = 1;
            // 
            // lblStatusRight
            // 
            this.lblStatusRight.AutoSize = false;
            this.lblStatusRight.Name = "lblStatusRight";
            this.lblStatusRight.Size = new System.Drawing.Size(291, 17);
            this.lblStatusRight.Spring = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 744);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}

