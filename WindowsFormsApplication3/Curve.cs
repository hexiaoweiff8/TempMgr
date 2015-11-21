using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication3.Service;

namespace WindowsFormsApplication3
{
    public partial class Curve : Form
    {
        //线形图类
        CurveBusiness curve2D = null;
        public Curve()
        {
            InitializeComponent();
            curve2D = new CurveBusiness();
            SQLiteHelper.CreateDataBase();
            curve2D.GetDataByDate(DTPStartTime.Value, DTPEndTime.Value.AddDays(1).AddSeconds(-1));
            DateTime Now = DateTime.Now;
            Now = new DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0);
            DTPStartTime.Value = Now;
            DTPEndTime.Value = Now;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (e.Graphics != null && curve2D != null)
            {
                Graphics g = e.Graphics;
                curve2D.InitializeGraph(ref g);
                curve2D.DrawCurve();
            }
        }

        /// <summary>
        /// 显示一天的温度, 温度记录点间隔为半小时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowDay_Click(object sender, EventArgs e)
        {
            //Curve2D.Display = DisplayState.DAY;
            if (DTPStartTime.Value.CompareTo(DTPEndTime.Value) > 0)
            {
                MessageBox.Show("开始日期不能比结束日期大!");
                return;
            }
            if (DTPEndTime.Value.Subtract(DTPStartTime.Value).Days > 31)
            {
                MessageBox.Show("时间跨度超过月的统计没有意义");
                return;
            }

            curve2D.GetDataByDate(DTPStartTime.Value, DTPEndTime.Value.AddDays(1).AddSeconds(-1));

            this.Refresh();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        //----------------------------------------拖拽----------------------------------------
        //拖拽
        bool isDrop = false;
        int MDX = 0, MDY = 0;

        private void Curve_MouseDown(object sender, MouseEventArgs e)
        {
            MDX = e.X;
            MDY = e.Y;
            isDrop = true;
        }

        private void Curve_MouseUp(object sender, MouseEventArgs e)
        {
            isDrop = false;
        }

        private void Curve_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrop)
            {
                this.Location = new Point(this.Location.X + (e.X - MDX), this.Location.Y + (e.Y - MDY));
            }
        }

        private void btnOnlyShowTemperature_Click(object sender, EventArgs e)
        {
            curve2D.PIsShowHumidity = false;
            curve2D.PIsShowTemperature = true;
            this.Refresh();
        }

        private void btnOnlyShowHumidity_Click(object sender, EventArgs e)
        {
            curve2D.PIsShowTemperature = false;
            curve2D.PIsShowHumidity = true;
            this.Refresh();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            curve2D.PIsShowTemperature = true;
            curve2D.PIsShowHumidity = true;
            this.Refresh();
        }
        //----------------------------------------拖拽----------------------------------------

        /// <summary>
        /// 比较两个日期的大小
        /// </summary>
        /// <param name="GreateDate">大的日期</param>
        /// <param name="LowDate">小的日期</param>
        /// <returns>是否第一个比第二个参数大</returns>
        public bool DateGreat(DateTime GreateDate, DateTime LowDate)
        {
            if (GreateDate.Year <= LowDate.Year)
            {
                return false;
            }
            if (GreateDate.Month <= LowDate.Month)
            {
                return false;
            }
            if (GreateDate.Day <= LowDate.Day)
            {
                return false;
            }
            return true;
        }

    }
}
