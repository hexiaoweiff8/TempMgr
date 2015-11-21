namespace WindowsFormsApplication3
{
    partial class Set
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Set));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NDDataBits = new System.Windows.Forms.NumericUpDown();
            this.NDTimeOut = new System.Windows.Forms.NumericUpDown();
            this.NDDataLen = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.CBCom = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.NDFlushTime = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.CbBaudRate = new System.Windows.Forms.ComboBox();
            this.CbStopBits = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbHead = new System.Windows.Forms.TextBox();
            this.tbFoot = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbWarning = new System.Windows.Forms.TextBox();
            this.cbIsWarning = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.tbMotorStateName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbMotorState = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbWaringName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NDDataBits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NDTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NDDataLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NDFlushTime)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Com口:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "停止位:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(40, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据位:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(50, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "超时:";
            // 
            // NDDataBits
            // 
            this.NDDataBits.Location = new System.Drawing.Point(93, 102);
            this.NDDataBits.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NDDataBits.Name = "NDDataBits";
            this.NDDataBits.Size = new System.Drawing.Size(120, 21);
            this.NDDataBits.TabIndex = 10;
            this.NDDataBits.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // NDTimeOut
            // 
            this.NDTimeOut.Location = new System.Drawing.Point(93, 129);
            this.NDTimeOut.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NDTimeOut.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NDTimeOut.Name = "NDTimeOut";
            this.NDTimeOut.Size = new System.Drawing.Size(120, 21);
            this.NDTimeOut.TabIndex = 11;
            this.NDTimeOut.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // NDDataLen
            // 
            this.NDDataLen.Location = new System.Drawing.Point(93, 156);
            this.NDDataLen.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NDDataLen.Name = "NDDataLen";
            this.NDDataLen.Size = new System.Drawing.Size(120, 21);
            this.NDDataLen.TabIndex = 13;
            this.NDDataLen.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "数据长度:";
            // 
            // CBCom
            // 
            this.CBCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCom.FormattingEnabled = true;
            this.CBCom.Location = new System.Drawing.Point(92, 23);
            this.CBCom.Name = "CBCom";
            this.CBCom.Size = new System.Drawing.Size(121, 20);
            this.CBCom.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(173, 466);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(254, 466);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NDFlushTime
            // 
            this.NDFlushTime.Location = new System.Drawing.Point(93, 183);
            this.NDFlushTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NDFlushTime.Name = "NDFlushTime";
            this.NDFlushTime.Size = new System.Drawing.Size(120, 21);
            this.NDFlushTime.TabIndex = 18;
            this.NDFlushTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(2, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "设备数据刷新:";
            // 
            // CbBaudRate
            // 
            this.CbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbBaudRate.FormattingEnabled = true;
            this.CbBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.CbBaudRate.Location = new System.Drawing.Point(92, 49);
            this.CbBaudRate.Name = "CbBaudRate";
            this.CbBaudRate.Size = new System.Drawing.Size(121, 20);
            this.CbBaudRate.TabIndex = 19;
            // 
            // CbStopBits
            // 
            this.CbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbStopBits.FormattingEnabled = true;
            this.CbStopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.CbStopBits.Location = new System.Drawing.Point(92, 74);
            this.CbStopBits.Name = "CbStopBits";
            this.CbStopBits.Size = new System.Drawing.Size(121, 20);
            this.CbStopBits.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(219, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "(毫秒,-1不超时)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(219, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "(发送接收数据的总长度)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(219, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "(秒)";
            // 
            // tbHead
            // 
            this.tbHead.Location = new System.Drawing.Point(92, 210);
            this.tbHead.Name = "tbHead";
            this.tbHead.Size = new System.Drawing.Size(256, 21);
            this.tbHead.TabIndex = 24;
            // 
            // tbFoot
            // 
            this.tbFoot.Location = new System.Drawing.Point(92, 237);
            this.tbFoot.Name = "tbFoot";
            this.tbFoot.Size = new System.Drawing.Size(256, 21);
            this.tbFoot.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(38, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "数据头:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(38, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "数据尾:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(91, 261);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(233, 12);
            this.label13.TabIndex = 28;
            this.label13.Text = "数据头与尾每字节请用十进制半角逗号分隔";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(90, 282);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(191, 12);
            this.label14.TabIndex = 29;
            this.label14.Text = "例:170,170,01,22,24,16,00,17,17";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(4, 309);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 12);
            this.label16.TabIndex = 32;
            this.label16.Text = "报警的故障号:";
            // 
            // tbWarning
            // 
            this.tbWarning.Location = new System.Drawing.Point(92, 306);
            this.tbWarning.Name = "tbWarning";
            this.tbWarning.Size = new System.Drawing.Size(256, 21);
            this.tbWarning.TabIndex = 30;
            // 
            // cbIsWarning
            // 
            this.cbIsWarning.AutoSize = true;
            this.cbIsWarning.BackColor = System.Drawing.Color.Transparent;
            this.cbIsWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbIsWarning.ForeColor = System.Drawing.Color.Black;
            this.cbIsWarning.Location = new System.Drawing.Point(92, 361);
            this.cbIsWarning.Name = "cbIsWarning";
            this.cbIsWarning.Size = new System.Drawing.Size(153, 16);
            this.cbIsWarning.TabIndex = 34;
            this.cbIsWarning.Text = "其他故障号情况是否报警";
            this.cbIsWarning.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(347, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 21);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.tbMotorStateName);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.tbMotorState);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.tbWaringName);
            this.panel1.Controls.Add(this.CBCom);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NDTimeOut);
            this.panel1.Controls.Add(this.CbBaudRate);
            this.panel1.Controls.Add(this.tbFoot);
            this.panel1.Controls.Add(this.cbIsWarning);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.CbStopBits);
            this.panel1.Controls.Add(this.NDDataLen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NDDataBits);
            this.panel1.Controls.Add(this.NDFlushTime);
            this.panel1.Controls.Add(this.tbHead);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbWarning);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 504);
            this.panel1.TabIndex = 36;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(28, 414);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 41;
            this.label17.Text = "状态名称:";
            // 
            // tbMotorStateName
            // 
            this.tbMotorStateName.Location = new System.Drawing.Point(92, 411);
            this.tbMotorStateName.Name = "tbMotorStateName";
            this.tbMotorStateName.Size = new System.Drawing.Size(256, 21);
            this.tbMotorStateName.TabIndex = 40;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(14, 386);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 12);
            this.label18.TabIndex = 39;
            this.label18.Text = "电机状态号:";
            // 
            // tbMotorState
            // 
            this.tbMotorState.Location = new System.Drawing.Point(92, 383);
            this.tbMotorState.Name = "tbMotorState";
            this.tbMotorState.Size = new System.Drawing.Size(256, 21);
            this.tbMotorState.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(28, 337);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 37;
            this.label15.Text = "故障名称:";
            // 
            // tbWaringName
            // 
            this.tbWaringName.Location = new System.Drawing.Point(92, 334);
            this.tbWaringName.Name = "tbWaringName";
            this.tbWaringName.Size = new System.Drawing.Size(256, 21);
            this.tbWaringName.TabIndex = 36;
            // 
            // Set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(373, 504);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Set";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set";
            ((System.ComponentModel.ISupportInitialize)(this.NDDataBits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NDTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NDDataLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NDFlushTime)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NDDataBits;
        private System.Windows.Forms.NumericUpDown NDTimeOut;
        private System.Windows.Forms.NumericUpDown NDDataLen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CBCom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown NDFlushTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbBaudRate;
        private System.Windows.Forms.ComboBox CbStopBits;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbHead;
        private System.Windows.Forms.TextBox tbFoot;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbWarning;
        private System.Windows.Forms.CheckBox cbIsWarning;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbWaringName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbMotorStateName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbMotorState;
    }
}