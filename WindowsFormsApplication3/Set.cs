using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Set : Form
    {
        TmpManager tm;
        //拖拽
        bool isDrop = false;
        int X = 0, Y = 0;

        public Set(TmpManager tm)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.tm = tm;
            CBCom.Items.AddRange(tm.Ports);
            this.CBCom.Text = tm.ComPortName;
            this.CbBaudRate.Text = "" + tm.BaudTate;
            this.NDDataBits.Value = tm.DataBits;
            this.NDTimeOut.Value = tm.ReadTimeout;
            this.NDDataLen.Value = tm.DataLen;
            this.NDFlushTime.Value = tm.ClearTime / 10;
            cbIsWarning.Checked = tm.isWarning;
            //根据stopbit的到相应的位数显示
            CbStopBits.Text = (getStopBitsName(tm.stopBit));

            //数据头与数据尾
            if (tm.Start.Length > 0)
            {
                tbHead.Text = getStrByList(tm.Start);
            }
            if (tm.End.Length > 0)
            {
                tbFoot.Text = getStrByList(tm.End);
            }
            //故障号
            if (tm.WarningName.Length > 0)
            {
                tbWaringName.Text = getStrByList(tm.WarningName);
            }
            //故障名
            if (tm.Warning.Length > 0)
            {
                tbWarning.Text = getStrByList(tm.Warning);
            }
            //电机状态号
            if (tm.MotorS.Length > 0)
            {
                tbMotorState.Text = getStrByList(tm.MotorS);
            }
            //电机状态名
            if (tm.MotorStateName.Length > 0)
            {
                tbMotorStateName.Text = getStrByList(tm.MotorStateName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //数据头与尾
            int[] ihead = getDataList(tbHead.Text);
            int[] ifoot = getDataList(tbFoot.Text);
            //处理报警与不报警故障号
            int[] iwar = getDataList(tbWarning.Text);
            int[] moterStatus = getDataList(tbMotorState.Text);

            //关闭串口
            tm.sp.Close();
            tm.sp.Dispose();
            tm.set(CBCom.Text, int.Parse(CbBaudRate.Text), double.Parse(CbBaudRate.Text), (int)NDDataBits.Value, (int)NDTimeOut.Value, (int)NDDataLen.Value, ihead, ifoot, (int)NDFlushTime.Value * 10, cbIsWarning.Checked, moterStatus);
            tm.SaveSetting();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //----------------------------------------拖拽----------------------------------------

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrop = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            isDrop = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrop)
            {
                this.Location = new Point(this.Location.X + (e.X - X), this.Location.Y + (e.Y - Y));
            }
        }
        //----------------------------------------拖拽----------------------------------------
        /// <summary>
        /// 根据String数据获得int[]对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private int[] getDataList(String data)
        {
            String[] ds = data.Split(',');
            int[] di = new int[ds.Length];
            for (int i = 0; i < ds.Length; i++)
            {
                di[i] = int.Parse(ds[i].Trim());
            }
            return di;
        }
        /// <summary>
        /// 根据int[]获得String
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String getStrByList(int[] data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i] + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// 根据String数据获得int[]对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String[] getSDataList(String data)
        {
            String[] ds = data.Split(',');
            for (int i = 0; i < ds.Length; i++)
            {
                ds[i] = ds[i].Trim();
            }
            return ds;
        }

        /// <summary>
        /// 根据int[]获得String
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String getStrByList(String[] data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].Trim() + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// 根据StopBits对象获得对应String显示
        /// </summary>
        /// <param name="sb">串口StopBits对象</param>
        /// <returns>String对应值</returns>
        private String getStopBitsName(StopBits sb)
        {
            if (sb == StopBits.None)
            {
                return "0";
            }
            if (sb == StopBits.One)
            {
                return "1";
            }
            if (sb == StopBits.OnePointFive)
            {
                return "1.5";
            }
            if (sb == StopBits.Two)
            {
                return "2";
            }
            return "1";
        }
    }
}