using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication3.Service;

namespace WindowsFormsApplication3
{
    public partial class TmpManager : Form
    {
        #region 定义
        //串口类
        public SerialPort sp;
        //01  1A  31  15  03 设备号  温度 湿度 开合度   故障号
        //01  01    设备号 操作号  1代表强开 2代表强关 3代表停
        //COM口
        public String ComPortName = "COM1";
        //波特率
        public int BaudTate = 9600;
        //停止位
        public StopBits stopBit = StopBits.One;
        //数据位数
        public int DataBits = 8;
        //读取超时时间
        public int ReadTimeout = -1;
        public int DataLen = 10;
        public int RebackDataLen = 6;
        Thread t;
        byte[] b;
        //开始结束标志位
        public int[] Start = { 0xAA, 0xAA };
        public int[] End = { 17, 17 };
        //接收数据缓存
        char[] c;
        //接收到的数据长度
        int count = 0;
        //收到的设备
        List<Divice> ld = new List<Divice>();
        //临时参数
        bool isExist = false;
        int tickCount = 0;
        public int ClearTime = 100;
        //所有COM口列表
        public String[] Ports;
        //报警故障号
        public int[] Warning = new int[] { 1, 2, 3, 4, 5 };
        public String[] WarningName = new String[] { "高温报警", "低温报警", "电机过载", "过载60次", "接线故障" };
        public int[] MotorS = new int[] { 0, 1, 2, 3, 4 };
        public String[] MotorStateName = new String[] { "正常运行", "强制关闭", "强制开启", "关闭大棚", "设备故障" };
        //不识别故障号是否报警
        public bool isWarning;
        //报警标志
        bool waring = false;
        //声音播放
        SoundPlayer sPlayer;
        //拖拽
        bool isDrop = false;
        int X = 0, Y = 0;
        private string strFilePath = Application.StartupPath + "\\Setting.ini";
        private string strSec = "";
        //求平均的数值
        private Divice tmpDivice;
        //计时的计数
        private long tickTime = 0;

        #endregion


        #region 初始化
        /// <summary>
        /// 窗口初始化
        /// </summary>
        public TmpManager()
        {
            InitializeComponent();
            init();
            Start1();
            GetSetting();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {

            //初始化串口
            try
            {
                tmpDivice = new Divice();
                //Control.CheckForIllegalCrossThreadCalls = false;
                this.MaximizeBox = false;
                b = new byte[RebackDataLen];
                for (int i = 0; i < b.Length; i++)
                {
                    if (i < Start.Length)
                    {
                        b[i] = Convert.ToByte(Start[i]);
                    }

                    if (i > RebackDataLen - End.Length - 1)
                    {
                        b[i] = Convert.ToByte(End[i - RebackDataLen + End.Length]);
                    }
                }
                try
                {
                    Ports = SerialPort.GetPortNames();
                }
                catch
                {
                    Ports = new String[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", };
                }
                c = new char[DataLen];
                sp = new SerialPort();
                sp.BaudRate = BaudTate;
                sp.StopBits = stopBit;
                sp.DataBits = DataBits;
                sp.ReadTimeout = ReadTimeout;
                sp.PortName = ComPortName;
                sp.Open();
                labStatus.Text = ComPortName + STATUS.已连接.ToString();
                lbRoll.Visible = true;
                //sp.Write(new Byte[] { 0xaa }, 0, 1);

            }
            catch
            {
                MessageBox.Show("串口打开失败, 请检查是否选择正确或已被占用.");
                labStatus.Text = ComPortName + STATUS.未连接.ToString();
                lbRoll.Visible = false;
            }

        }
        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="section">节点名称[如[TypeName]]</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="def">值</param>
        /// <param name="retval">stringbulider对象</param>
        /// <param name="size">字节大小</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        /// <summary>
        /// 自定义读取INI文件中的内容方法
        /// </summary>
        /// <param name="Section">键</param>
        /// <param name="key">值</param>
        /// <returns></returns>
        private string ContentValue(string Section, string key)
        {

            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, key, "", temp, 1024, strFilePath);
            if (String.IsNullOrEmpty(temp.ToString()))
            {
                throw new Exception();
            }
            return temp.ToString();
        }

        /// <summary>
        /// 获得设置
        /// </summary>
        private void GetSetting()
        {
            strSec = Path.GetFileNameWithoutExtension(strFilePath);
            try
            {
                ComPortName = ContentValue(strSec, "ComPortName");
                BaudTate = int.Parse(ContentValue(strSec, "BaudTate"));
                stopBit = getSB(ContentValue(strSec, "StopBit"));
                DataBits = int.Parse(ContentValue(strSec, "DataBits"));
                ReadTimeout = int.Parse(ContentValue(strSec, "ReadTimeout"));
                DataLen = int.Parse(ContentValue(strSec, "DataLen"));
                RebackDataLen = int.Parse(ContentValue(strSec, "RebackDataLen"));
                Start = getDataList(ContentValue(strSec, "Start"));
                End = getDataList(ContentValue(strSec, "End"));
                Warning = getDataList(ContentValue(strSec, "Warning"));
                WarningName = getSDataList(ContentValue(strSec, "WarningName"));
                MotorS = getDataList(ContentValue(strSec, "MotorS"));
                MotorStateName = getSDataList(ContentValue(strSec, "MotorStateName"));
                isWarning = bool.Parse(ContentValue(strSec, "isWarning"));
            }
            catch
            {
                //创建setting文件
                SaveSetting();
            }
        }


        /// <summary>
        /// 启动初始化双缓冲刷新与线程的启动
        /// </summary>
        private void Start1()
        {
            try
            {
                Type dgvType = this.dgvDate.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(this.dgvDate, true, null);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
                this.UpdateStyles();
            }
            catch (Exception e)
            {
                String msg = e.Message;
                MessageBox.Show(msg);
            }
            try
            {
                t = new Thread(new ThreadStart(run));
                t.Start();
            }
            catch
            {
                MessageBox.Show("线程启动失败, 请重启程序.-=");
            }
        }

        #endregion


        #region 外部设置调用函数
        public void SaveSetting()
        {
            WritePrivateProfileString(strSec, "ComPortName", ComPortName, strFilePath);
            WritePrivateProfileString(strSec, "BaudTate", BaudTate.ToString(), strFilePath);
            WritePrivateProfileString(strSec, "StopBit", getStrBySB(stopBit), strFilePath);
            WritePrivateProfileString(strSec, "DataBits", DataBits.ToString(), strFilePath);
            WritePrivateProfileString(strSec, "ReadTimeout", ReadTimeout.ToString(), strFilePath);
            WritePrivateProfileString(strSec, "DataLen", DataLen.ToString(), strFilePath);
            WritePrivateProfileString(strSec, "RebackDataLen", RebackDataLen.ToString(), strFilePath);
            WritePrivateProfileString(strSec, "Start", getStrByList(Start), strFilePath);
            WritePrivateProfileString(strSec, "End", getStrByList(End), strFilePath);
            WritePrivateProfileString(strSec, "Warning", getStrByList(Warning), strFilePath);
            WritePrivateProfileString(strSec, "WarningName", getStrByList(WarningName), strFilePath);
            WritePrivateProfileString(strSec, "MotorS", getStrByList(MotorS), strFilePath);
            WritePrivateProfileString(strSec, "MotorStateName", getStrByList(MotorStateName), strFilePath);
            WritePrivateProfileString(strSec, "isWarning", isWarning.ToString(), strFilePath);
        }


        /// <summary>
        /// 设置用接口
        /// </summary>
        /// <param name="com">com口名称</param>
        /// <param name="baudTate">波特率</param>
        /// <param name="sb">停止位</param>
        /// <param name="databits">数据位长度</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="datalen">数据长度(包括开始位停止位)</param>
        /// <param name="start">数据开始位</param>
        /// <param name="end">数据停止位</param>
        /// <param name="ClearTime">刷新时间</param>
        public void set(String com, int baudTate, double sb, int databits, int timeout, int datalen, int[] start, int[] end, int ClearTime, bool isWaring, int[] MotorS)
        {
            this.isWarning = isWaring;
            this.ComPortName = com;
            this.BaudTate = baudTate;
            this.stopBit = sb == 0 ? StopBits.None : (sb == 1 ? StopBits.One : (sb == 1.5 ? StopBits.OnePointFive : StopBits.Two));
            this.DataBits = databits;
            this.ReadTimeout = timeout;
            this.DataLen = datalen;
            this.Start = start;
            this.End = end;
            this.ClearTime = ClearTime;
            this.MotorS = MotorS;
            c = new char[DataLen];
            init();
            SaveSetting();
        }

        #endregion


        #region 数据接收进程
        /// <summary>
        ///  进程方法, 开始接收串口数据
        /// </summary>
        private void run()
        {
        w: while (true)
            {
                count = 0;
                c = new char[DataLen];
                try
                {
                    for (int i = 0; i < DataLen; i++)
                    {
                        //度一个字节
                        int Data = sp.ReadByte();
                        //存入缓存
                        c[i] = (char)Data;
                        //如果有头
                        if (i < Start.Length)
                        {
                            if (Data != Start[i])
                            {
                                sp.DiscardInBuffer();
                                sp.DiscardOutBuffer();
                                goto w;
                            }
                        }

                        //如果有尾
                        if (i >= DataLen - End.Length)
                        {
                            if (Data != End[i - DataLen + End.Length])
                            {
                                sp.DiscardInBuffer();
                                sp.DiscardOutBuffer();
                                goto w;
                            }
                        }
                        count++;
                    }
                    isExist = false;
                    foreach (var d in ld)
                    {
                        if (d.DiviceNum == (int)c[2])
                        {
                            isExist = true;
                            d.Temperature = c[3];
                            d.Hum = c[4];
                            d.Wo = c[5];
                            d.ErrorNum = c[6];
                            d.MotorState = c[7];
                            break;
                        }
                    }

                    if (!isExist)
                    {
                        Divice d = new Divice();
                        d.DiviceNum = c[2];
                        d.Temperature = c[3];
                        d.Hum = c[4];
                        d.Wo = c[5];
                        d.ErrorNum = c[6];
                        d.MotorState = c[7];
                        ld.Add(d);
                    }

                }
                catch
                {

                }
                Thread.Sleep(10);
            }
        }
        #endregion


        #region 控件事件
        /// <summary>
        /// 关闭大棚
        /// </summary>
        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否关确认闭大棚?", "是否关闭大棚?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                b[2] = Convert.ToByte(0xFF);
                b[3] = Convert.ToByte(2);
                sp.Write(b, 0, 6);
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sp != null)
            {
                try
                {
                    sp.Close();
                }
                catch { }
                try
                {
                    t.Abort();
                }
                catch { }
            }
        }

        /// <summary>
        /// 设置
        /// </summary>
        private void btnSet_Click(object sender, EventArgs e)
        {
            Set set = new Set(this);
            set.Show();
        }

        /// <summary>
        /// 刷新数据显示
        /// </summary>
        private void tmr_Tick(object sender, EventArgs e)
        {

            dgvDate.Rows.Clear();
            for (int x = 0; x < ld.Count; x++)
            {
                Divice d = ld[x];
                SumData(d);
                String MS = "";
                try
                {
                    for (int i = 0; i < MotorS.Length; i++)
                    {
                        if (d.MotorState == MotorS[i])
                        {
                            MS = MotorStateName[i];
                            break;
                        }
                    }
                }
                catch
                {
                    MS = "未知状态:" + d.MotorState;
                }
                String WS = "";
                try
                {
                    for (int i = 0; i < Warning.Length; i++)
                    {
                        if (d.ErrorNum == Warning[i])
                        {
                            WS = WarningName[i];
                            break;
                        }
                    }
                }
                catch
                {
                    WS = "未知状态:" + d.ErrorNum;
                }
                dgvDate.Rows.Add();
                DataGridViewRow dgr = dgvDate.Rows[dgvDate.Rows.Count - 1];
                dgr.Cells["Num"].Value = d.DiviceNum == 0 ? "--" : d.DiviceNum.ToString();
                dgr.Cells["tmp"].Value = d.Temperature.ToString();
                dgr.Cells["Hum"].Value = d.Hum.ToString();
                dgr.Cells["wo"].Value = d.Wo.ToString();
                dgr.Cells["MotorState"].Value = (String.IsNullOrEmpty(MS) ? "未知状态:" + d.MotorState : MS);
                dgr.Cells["wNum"].Value = d.ErrorNum == 0 ? "正常" : (String.IsNullOrEmpty(WS) ? "未知故障:" + d.ErrorNum : WS);
                dgr.Cells["Open"].Value = "强开";
                dgr.Cells["Close"].Value = "强关";
                dgr.Cells["Stop"].Value = "停止";
                waring = false;
                if (Warning != null)
                {
                    for (int i = 0; i < Warning.Length; i++)
                    {
                        if (Warning[i] == d.ErrorNum)
                        {
                            waring = true;
                            break;
                        }

                        if (isWarning && d.ErrorNum != 0)
                        {
                            waring = true;
                            break;
                        }
                    }
                }
            }

            if (ClearTime > 0)
            {
                tickCount++;
                if (tickCount >= ClearTime)
                {
                    tickCount = 0;
                    ld.Clear();
                    lbPoint.Text = "";
                    if (sPlayer != null)
                    {
                        sPlayer.Stop();
                        sPlayer.Dispose();
                        sPlayer = null;
                        waring = false;
                    }
                }
                if (tickCount % 10 == 0)
                { lbPoint.Text += "."; }

            }
            //是否显示报警
            if (waring)
            {
                try
                {
                    if (sPlayer == null)
                    {
                        sPlayer = new SoundPlayer(WindowsFormsApplication3.Properties.Resources.warWav);
                        sPlayer.PlayLooping();
                    }
                }
                catch
                { }
                pbWaring.Visible = true;
            }
            else
            {
                if (sPlayer != null)
                {
                    sPlayer.Stop();
                    sPlayer.Dispose();
                    sPlayer = null;
                }
                pbWaring.Visible = false;
            }

        }

        /// <summary>
        /// 数据中三个按钮
        /// </summary>
        private void dgvDate_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (MessageBox.Show("是否关确认打开设备?", "是否关确认打开设备?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    b[2] = Convert.ToByte(dgvDate.Rows[e.RowIndex].Cells["Num"].Value);
                    b[3] = Convert.ToByte(1);
                    sp.Write(b, 0, 6);
                }
            }

            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("是否关确认关闭设备?", "是否关确认关闭设备?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b[2] = Convert.ToByte(dgvDate.Rows[e.RowIndex].Cells["Num"].Value);
                    b[3] = Convert.ToByte(2);
                    sp.Write(b, 0, 6);
                }
            }

            if (e.ColumnIndex == 8)
            {
                if (MessageBox.Show("是否关确认停止设备?", "是否关确认停止设备?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b[2] = Convert.ToByte(dgvDate.Rows[e.RowIndex].Cells["Num"].Value);
                    b[3] = Convert.ToByte(3);
                    sp.Write(b, 0, 6);
                }
            }
        }

        //----------------------------------防止刷新数据阻碍点击事件----------------------------------
        private void dgvDate_MouseDown(object sender, MouseEventArgs e)
        {
            tmr.Enabled = false;
        }

        private void dgvDate_MouseUp(object sender, MouseEventArgs e)
        {
            tmr.Enabled = true;
        }
        //----------------------------------防止刷新数据阻碍点击事件----------------------------------


        /// <summary>
        /// 重连
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!sp.IsOpen)
            {
                init();
            }
            else
            {
                MessageBox.Show("已经连接");
            }
        }


        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //----------------------------------------拖拽----------------------------------------
        private void TmpManager_MouseUp(object sender, MouseEventArgs e)
        {
            isDrop = false;
        }

        private void TmpManager_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrop)
            {
                this.Location = new Point(this.Location.X + (e.X - X), this.Location.Y + (e.Y - Y));
            }
        }

        private void TmpManager_MouseDown(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            isDrop = true;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            isDrop = false;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            isDrop = true;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrop)
            {
                this.Location = new Point(this.Location.X + (e.X - X), this.Location.Y + (e.Y - Y));
            }
        }

        //----------------------------------------拖拽----------------------------------------
        /// <summary>
        /// 最小化
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 鼠标移动时不进行数据刷新
        /// </summary>
        private void dgvDate_MouseMove(object sender, MouseEventArgs e)
        {
            tmr.Enabled = false;
            TickCount = 0;
        }

        /// <summary>
        /// 鼠标离开时开始刷新
        /// </summary>
        private void dgvDate_MouseLeave(object sender, EventArgs e)
        {
            tmr.Enabled = true;
        }

        /// <summary>
        /// 当鼠标不移动3秒后数据开始刷新
        /// </summary>
        int TickCount = 0;
        private void tick_Tick(object sender, EventArgs e)
        {
            TickCount++;
            if (tmr.Enabled == false && TickCount >= 3)
            {
                tmr.Enabled = true;
            }
        }
        #endregion


        #region 通用参数
        //---------------------------------------通用参数------------------------------------
        /// <summary>
        /// 根据停止位String获得StopBits对象
        /// </summary>
        /// <param name="sb"></param>
        /// <returns></returns>
        private StopBits getSB(String sb)
        {
            double s = double.Parse(sb);
            if (s == 0)
            {
                return StopBits.None;
            }
            if (s == 1)
            {
                return StopBits.One;
            }
            if (s == 1.5)
            {
                return StopBits.OnePointFive;
            }
            if (s == 2)
            {
                return StopBits.Two;
            }
            return StopBits.One;
        }

        /// <summary>
        /// 根据StopBits获得String
        /// </summary>
        /// <param name="sb"></param>
        /// <returns></returns>
        private String getStrBySB(StopBits sb)
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
        /// 向数据库存数据
        /// </summary>
        private void SaveData()
        {
            SQLiteHelper.SaveData(tmpDivice.DiviceNum, tmpDivice.Temperature, tmpDivice.Hum, tmpDivice.Wo, tmpDivice.MotorState, tmpDivice.ErrorNum);
            tmpDivice = new Divice();
        }

        /// <summary>
        /// 求数据平均数, 根据时间存入数据库
        /// </summary>
        /// <param name="divice"></param>
        private void SumData(Divice divice)
        {
            tmpDivice.Temperature = (tmpDivice.Temperature + divice.Temperature) / 2;
            tmpDivice.Hum = (tmpDivice.Hum + divice.Hum) / 2;
            tmpDivice.ErrorNum = divice.ErrorNum;
            tickTime++;
            //半小时存一次
            if (tickTime >= 1800)
            {
                tickTime = 0;
                SaveData();
            }
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            Curve curve = new Curve();
            curve.Show();
        }
        //---------------------------------------通用参数------------------------------------
        #endregion
    }

    enum STATUS { 已连接, 未连接, 错误 }

    /// <summary>
    /// 设备类
    /// </summary>
    public class Divice
    {
        public int DiviceNum { set; get; }
        public int Temperature { set; get; }
        public int Hum { set; get; }
        public int Wo { set; get; }
        public int MotorState { get; set; }
        public int ErrorNum { set; get; }
        public DateTime CreateTime { set; get; }

    }
}