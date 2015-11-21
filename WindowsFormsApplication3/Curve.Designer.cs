namespace WindowsFormsApplication3
{
    partial class Curve
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
            this.btnShowDay = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.DTPStartTime = new System.Windows.Forms.DateTimePicker();
            this.DTPEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOnlyShowTemperature = new System.Windows.Forms.Button();
            this.btnOnlyShowHumidity = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowDay
            // 
            this.btnShowDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowDay.ForeColor = System.Drawing.Color.White;
            this.btnShowDay.Location = new System.Drawing.Point(891, 156);
            this.btnShowDay.Name = "btnShowDay";
            this.btnShowDay.Size = new System.Drawing.Size(109, 23);
            this.btnShowDay.TabIndex = 0;
            this.btnShowDay.Text = "查询";
            this.btnShowDay.UseVisualStyleBackColor = true;
            this.btnShowDay.Click += new System.EventHandler(this.btnShowDay_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(984, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 21);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // DTPStartTime
            // 
            this.DTPStartTime.Location = new System.Drawing.Point(891, 78);
            this.DTPStartTime.Name = "DTPStartTime";
            this.DTPStartTime.Size = new System.Drawing.Size(109, 21);
            this.DTPStartTime.TabIndex = 37;
            // 
            // DTPEndTime
            // 
            this.DTPEndTime.Location = new System.Drawing.Point(891, 120);
            this.DTPEndTime.Name = "DTPEndTime";
            this.DTPEndTime.Size = new System.Drawing.Size(109, 21);
            this.DTPEndTime.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(891, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "至";
            // 
            // btnOnlyShowTemperature
            // 
            this.btnOnlyShowTemperature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnlyShowTemperature.ForeColor = System.Drawing.Color.White;
            this.btnOnlyShowTemperature.Location = new System.Drawing.Point(891, 185);
            this.btnOnlyShowTemperature.Name = "btnOnlyShowTemperature";
            this.btnOnlyShowTemperature.Size = new System.Drawing.Size(109, 23);
            this.btnOnlyShowTemperature.TabIndex = 40;
            this.btnOnlyShowTemperature.Text = "只显示温度";
            this.btnOnlyShowTemperature.UseVisualStyleBackColor = true;
            this.btnOnlyShowTemperature.Click += new System.EventHandler(this.btnOnlyShowTemperature_Click);
            // 
            // btnOnlyShowHumidity
            // 
            this.btnOnlyShowHumidity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnlyShowHumidity.ForeColor = System.Drawing.Color.White;
            this.btnOnlyShowHumidity.Location = new System.Drawing.Point(891, 214);
            this.btnOnlyShowHumidity.Name = "btnOnlyShowHumidity";
            this.btnOnlyShowHumidity.Size = new System.Drawing.Size(109, 23);
            this.btnOnlyShowHumidity.TabIndex = 41;
            this.btnOnlyShowHumidity.Text = "只显示湿度";
            this.btnOnlyShowHumidity.UseVisualStyleBackColor = true;
            this.btnOnlyShowHumidity.Click += new System.EventHandler(this.btnOnlyShowHumidity_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Location = new System.Drawing.Point(891, 243);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(109, 23);
            this.btnShowAll.TabIndex = 42;
            this.btnShowAll.Text = "显示全部";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // Curve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1007, 400);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnOnlyShowHumidity);
            this.Controls.Add(this.btnOnlyShowTemperature);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTPEndTime);
            this.Controls.Add(this.DTPStartTime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShowDay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Curve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "线形图";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Curve_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Curve_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Curve_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowDay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker DTPStartTime;
        private System.Windows.Forms.DateTimePicker DTPEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOnlyShowTemperature;
        private System.Windows.Forms.Button btnOnlyShowHumidity;
        private System.Windows.Forms.Button btnShowAll;

    }
}