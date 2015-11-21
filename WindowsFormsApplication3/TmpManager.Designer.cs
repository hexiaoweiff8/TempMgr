namespace WindowsFormsApplication3
{
    partial class TmpManager
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TmpManager));
            this.dgvDate = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotorState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Open = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Close = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Stop = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labStatus = new System.Windows.Forms.Label();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.btnCon = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbRoll = new System.Windows.Forms.Label();
            this.lbPoint = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbWaring = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tick = new System.Windows.Forms.Timer(this.components);
            this.btnCurve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWaring)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDate
            // 
            this.dgvDate.AllowUserToAddRows = false;
            this.dgvDate.AllowUserToDeleteRows = false;
            this.dgvDate.AllowUserToResizeColumns = false;
            this.dgvDate.AllowUserToResizeRows = false;
            this.dgvDate.BackgroundColor = System.Drawing.Color.LightSeaGreen;
            this.dgvDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.tmp,
            this.hum,
            this.wo,
            this.wNum,
            this.MotorState,
            this.Open,
            this.Close,
            this.Stop});
            this.dgvDate.Location = new System.Drawing.Point(11, 137);
            this.dgvDate.Name = "dgvDate";
            this.dgvDate.ReadOnly = true;
            this.dgvDate.RowTemplate.Height = 23;
            this.dgvDate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDate.Size = new System.Drawing.Size(638, 317);
            this.dgvDate.TabIndex = 0;
            this.dgvDate.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDate_CellMouseClick);
            this.dgvDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDate_MouseDown);
            this.dgvDate.MouseLeave += new System.EventHandler(this.dgvDate_MouseLeave);
            this.dgvDate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvDate_MouseMove);
            this.dgvDate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvDate_MouseDown);
            // 
            // Num
            // 
            dataGridViewCellStyle1.NullValue = "--";
            this.Num.DefaultCellStyle = dataGridViewCellStyle1;
            this.Num.HeaderText = "设备号";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.Width = 70;
            // 
            // tmp
            // 
            dataGridViewCellStyle2.NullValue = "--";
            this.tmp.DefaultCellStyle = dataGridViewCellStyle2;
            this.tmp.HeaderText = "温度";
            this.tmp.Name = "tmp";
            this.tmp.ReadOnly = true;
            this.tmp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tmp.Width = 62;
            // 
            // hum
            // 
            dataGridViewCellStyle3.NullValue = "--";
            this.hum.DefaultCellStyle = dataGridViewCellStyle3;
            this.hum.HeaderText = "湿度";
            this.hum.Name = "hum";
            this.hum.ReadOnly = true;
            this.hum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.hum.Width = 62;
            // 
            // wo
            // 
            dataGridViewCellStyle4.NullValue = "--";
            this.wo.DefaultCellStyle = dataGridViewCellStyle4;
            this.wo.HeaderText = "风口开合度";
            this.wo.Name = "wo";
            this.wo.ReadOnly = true;
            this.wo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.wo.Width = 80;
            // 
            // wNum
            // 
            dataGridViewCellStyle5.NullValue = "--";
            this.wNum.DefaultCellStyle = dataGridViewCellStyle5;
            this.wNum.HeaderText = "报警信息";
            this.wNum.Name = "wNum";
            this.wNum.ReadOnly = true;
            this.wNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MotorState
            // 
            this.MotorState.HeaderText = "电机状态";
            this.MotorState.Name = "MotorState";
            this.MotorState.ReadOnly = true;
            // 
            // Open
            // 
            this.Open.HeaderText = "强开";
            this.Open.Name = "Open";
            this.Open.ReadOnly = true;
            this.Open.Text = "强开";
            this.Open.ToolTipText = "强开";
            this.Open.Width = 40;
            // 
            // Close
            // 
            this.Close.HeaderText = "强关";
            this.Close.Name = "Close";
            this.Close.ReadOnly = true;
            this.Close.Text = "强关";
            this.Close.ToolTipText = "强关";
            this.Close.Width = 40;
            // 
            // Stop
            // 
            this.Stop.HeaderText = "停止";
            this.Stop.Name = "Stop";
            this.Stop.ReadOnly = true;
            this.Stop.Text = "停止";
            this.Stop.ToolTipText = "停止";
            this.Stop.Width = 40;
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseAll.ForeColor = System.Drawing.Color.White;
            this.btnCloseAll.Location = new System.Drawing.Point(78, 70);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(75, 23);
            this.btnCloseAll.TabIndex = 1;
            this.btnCloseAll.Text = "关闭大棚";
            this.btnCloseAll.UseVisualStyleBackColor = false;
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.Transparent;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.ForeColor = System.Drawing.Color.White;
            this.btnSet.Location = new System.Drawing.Point(78, 101);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 5;
            this.btnSet.Text = "设置";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(240, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "设备状态:";
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.ForeColor = System.Drawing.Color.White;
            this.labStatus.Location = new System.Drawing.Point(305, 106);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(41, 12);
            this.labStatus.TabIndex = 7;
            this.labStatus.Text = "未连接";
            // 
            // tmr
            // 
            this.tmr.Enabled = true;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // btnCon
            // 
            this.btnCon.BackColor = System.Drawing.Color.Transparent;
            this.btnCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCon.ForeColor = System.Drawing.Color.White;
            this.btnCon.Location = new System.Drawing.Point(159, 101);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(75, 23);
            this.btnCon.TabIndex = 8;
            this.btnCon.Text = "重连";
            this.btnCon.UseVisualStyleBackColor = false;
            this.btnCon.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(628, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbRoll
            // 
            this.lbRoll.AutoSize = true;
            this.lbRoll.BackColor = System.Drawing.Color.Transparent;
            this.lbRoll.ForeColor = System.Drawing.Color.White;
            this.lbRoll.Location = new System.Drawing.Point(13, 457);
            this.lbRoll.Name = "lbRoll";
            this.lbRoll.Size = new System.Drawing.Size(101, 12);
            this.lbRoll.TabIndex = 11;
            this.lbRoll.Text = "正在监视设备情况";
            this.lbRoll.Visible = false;
            // 
            // lbPoint
            // 
            this.lbPoint.AutoSize = true;
            this.lbPoint.BackColor = System.Drawing.Color.Transparent;
            this.lbPoint.ForeColor = System.Drawing.Color.White;
            this.lbPoint.Location = new System.Drawing.Point(114, 457);
            this.lbPoint.Name = "lbPoint";
            this.lbPoint.Size = new System.Drawing.Size(0, 12);
            this.lbPoint.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication3.Properties.Resources.世纪天成_02_22;
            this.pictureBox1.Location = new System.Drawing.Point(549, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pbWaring
            // 
            this.pbWaring.Image = global::WindowsFormsApplication3.Properties.Resources.War;
            this.pbWaring.Location = new System.Drawing.Point(11, 53);
            this.pbWaring.Name = "pbWaring";
            this.pbWaring.Size = new System.Drawing.Size(61, 71);
            this.pbWaring.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWaring.TabIndex = 9;
            this.pbWaring.TabStop = false;
            this.pbWaring.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 17F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "世纪天成智能温室远程监控系统";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnCurve);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.lbPoint);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.lbRoll);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dgvDate);
            this.panel2.Controls.Add(this.labStatus);
            this.panel2.Controls.Add(this.btnCon);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pbWaring);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnCloseAll);
            this.panel2.Controls.Add(this.btnSet);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(662, 476);
            this.panel2.TabIndex = 16;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(601, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "_";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tick
            // 
            this.tick.Enabled = true;
            this.tick.Interval = 1000;
            this.tick.Tick += new System.EventHandler(this.tick_Tick);
            // 
            // btnCurve
            // 
            this.btnCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurve.ForeColor = System.Drawing.Color.White;
            this.btnCurve.Location = new System.Drawing.Point(159, 70);
            this.btnCurve.Name = "btnCurve";
            this.btnCurve.Size = new System.Drawing.Size(75, 23);
            this.btnCurve.TabIndex = 16;
            this.btnCurve.Text = "数据曲线";
            this.btnCurve.UseVisualStyleBackColor = false;
            this.btnCurve.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // TmpManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(662, 476);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TmpManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "温度控制";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TmpManager_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TmpManager_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TmpManager_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWaring)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDate;
        private System.Windows.Forms.Button btnCloseAll;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.PictureBox pbWaring;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbRoll;
        private System.Windows.Forms.Label lbPoint;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn hum;
        private System.Windows.Forms.DataGridViewTextBoxColumn wo;
        private System.Windows.Forms.DataGridViewTextBoxColumn wNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotorState;
        private System.Windows.Forms.DataGridViewButtonColumn Open;
        private System.Windows.Forms.DataGridViewButtonColumn Close;
        private System.Windows.Forms.DataGridViewButtonColumn Stop;
        private System.Windows.Forms.Timer tick;
        private System.Windows.Forms.Button btnCurve;
    }
}

