using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace WindowsFormsApplication3.Service
{
    /// <summary>
    /// 曲线图类
    /// </summary>
    public class CurveBusiness
    {
        //画笔
        private Graphics objGraphics;
        //图像宽度
        private int Width = 880;
        //图像高度
        private int Height = 380;
        //边距
        private int Padding = 10;
        //X轴刻度宽度
        private float XSlice = 60;
        //Y轴刻度宽度
        private float YSlice = 50;
        //Y轴刻度的数值宽度
        private float YSliceValue = 20;
        //Y轴刻度开始位置
        private float YSliceBegin = 0;
        //X轴刻度开始位置
        private float XSliceBegin = 60;
        //刻度条长度
        private float SliceLen = 5;
        //大刻度相对于刻度的增量
        private float OfferLen = 2;
        //线条曲率
        private float Tension = 0.0f;
        //坐标标题
        private String Title = "温度湿度曲线图";
        //X轴说明文字
        private String XTitleForTemperature = "温度";
        private String XTitleForHumidity = "湿度";
        //底部Y轴说明
        private String[] DisplayDay = { "1点", "3点", "5点", "7点", "9点", "11点", "13点", "15点", "17点", "19点", "21点", "23点" };
        //private String[] DisplayWeek = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        //private String[] DisplayMonth = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
        //private String[] DisplayYear = { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };
        //显示下标数量
        private int DisplayCount = 0;
        //字体
        Font font;
        //背景色
        private Color BgColor = Color.Snow;
        //文字颜色
        private Color FontColor = Color.Black;
        //整体边框颜色
        private Color BorderColor = Color.Black;
        //轴线颜色
        private Color AxisColor = Color.Black;
        //轴线说明颜色
        private Color AxisTextColor = Color.Black;
        //刻度文字颜色
        private Color SliceTextColor = Color.Black;
        //刻度颜色
        private Color SliceColor = Color.Black;
        //定位线颜色
        private Color DottedColor = Color.Gray;
        //不同曲线的颜色
        private Color[] CurveColor = { Color.Red, Color.Blue, Color.Black };
        //图像左右边距距离
        private float XSpace = 60;
        //图像上下边距距离
        private float YSpace = 40;
        //字体大小
        private int fontSize = 9;
        //X轴文字旋转角度
        private float XRotateAngle = 30;
        //Y轴文字旋转角度
        private float YRotateAngle = 0;
        //温度的Y轴位置偏量
        private float TemperatureOff = 1.1f;
        //湿度的Y轴位置偏量
        private float HumidityOff = 0.9f;
        //曲线宽度
        private int CurveSize = 2;
        //定位线宽度
        private int DottedLineSize = 1;
        //字体距离
        private int FontSpace = 0;
        //曲线顶点的圆的参数
        private int EllipseH = 10;
        private int EllipseW = 10;
        //右上角说明的长宽
        private int DirectionWidth = 55;
        private int DirectionHeight = 40;
        //是否显示温度
        private bool IsShowTemperature = true;
        private bool IsShowHumidity = true;
        //曲线中温度的点列表
        private static List<CurvePoint> lTemperatureCurvePoint = new List<CurvePoint>();
        //曲线中湿度的点列表
        private static List<CurvePoint> lHumidityCurvePoint = new List<CurvePoint>();
        //当前的显示状态
        private static DisplayState display = DisplayState.DAY;
        CurveLine curve = new CurveLine();

        #region 公共属性

        /// <summary>
        /// 显示方式
        /// </summary>
        public static DisplayState Display
        {
            get { return CurveBusiness.display; }
            set { CurveBusiness.display = value; }
        }

        /// <summary>
        /// Y轴刻度宽度
        /// </summary>
        public float PYSlice
        {
            get { return YSlice; }
            set { YSlice = value; }
        }
        /// <summary>
        /// Y轴刻度的数值宽度
        /// </summary>
        public float PYSliceValue
        {
            get { return YSliceValue; }
            set { YSliceValue = value; }
        }

        /// <summary>
        /// X轴刻度宽度
        /// </summary>
        public float PXSlice
        {
            get { return XSlice; }
            set { XSlice = value; }
        }

        /// <summary>
        /// Y轴起始点
        /// </summary>
        public float PYSliceBigen
        {
            get { return YSliceBegin; }
            set { YSliceBegin = value; }
        }

        /// <summary>
        /// X轴左右边距
        /// </summary>
        public float PXSpace
        {
            get { return XSpace; }
            set { XSpace = value; }
        }

        /// <summary>
        /// Y轴左右边距
        /// </summary>
        public float PYSpace
        {
            get { return YSpace; }
            set { YSpace = value; }
        }
        /// <summary>
        /// 图像的宽度
        /// </summary>
        public int PWidth
        {
            set
            {
                if (value < 100)
                {
                    Width = 100;
                }
                else
                {
                    Width = value;
                }
            }
            get
            {
                if (Width <= 100)
                {
                    return 100;
                }
                else
                {
                    return Width;
                }
            }
        }

        /// <summary>
        /// 图像的高度
        /// </summary>
        public int PHeight
        {
            set
            {
                if (value < 100)
                {
                    Height = 100;
                }
                else
                {
                    Height = value;
                }
            }
            get
            {
                if (Height <= 100)
                {
                    return 100;
                }
                else
                {
                    return Height;
                }
            }
        }

        /// <summary>
        /// 张力系数
        /// </summary>
        public float PTension
        {
            set
            {
                if (value < 0.0f && value > 1.0f)
                {
                    Tension = 0.5f;
                }
                else
                {
                    Tension = value;
                }
            }
            get
            {
                return Tension;
            }
        }


        public bool PIsShowHumidity
        {
            get { return IsShowHumidity; }
            set { IsShowHumidity = value; }
        }
        public bool PIsShowTemperature
        {
            get { return IsShowTemperature; }
            set { IsShowTemperature = value; }
        }

        /// <summary>
        /// 温度曲线列表
        /// </summary>
        public static List<CurvePoint> LTemperatureCurvePoint
        {
            get { return CurveBusiness.lTemperatureCurvePoint; }
            set { CurveBusiness.lTemperatureCurvePoint = value; }
        }

        /// <summary>
        /// 湿度曲线列表
        /// </summary>
        public static List<CurvePoint> LHumidityCurvePoint
        {
            get { return CurveBusiness.lHumidityCurvePoint; }
            set { CurveBusiness.lHumidityCurvePoint = value; }
        }
        #endregion

        ///// <summary>
        ///// 根据参数调整宽度
        ///// </summary>
        public void Fit(int count)
        {
            //Random r = new Random();
            //for (int i = 0; i < 50; i++)
            //{
            //    int X = (int)(XSlice * i);
            //    int tmp = r.Next(0, 100);
            //    int Y = tmp;
            //    curve.LCurvePoint.Add(new CurvePoint("" + tmp + "°", X, Y));
            //}
            //int maxCount = lTemperatureCurvePoint.Count > lHumidityCurvePoint.Count ? lTemperatureCurvePoint.Count : lHumidityCurvePoint.Count;
            float tmpXSlice = (Width - XSpace * 2) / count;
            if (tmpXSlice < XSlice)
            {
                XSlice = tmpXSlice;
            }
            curve.Fit();

        }

        public void FitXSlice(List<Divice> lDivice)
        {
            if (lDivice == null)
            {
                return;
            }

            XSlice = (Width - XSpace * 2) / lDivice.Count;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitializeGraph(ref Graphics FormGraphics)
        {
            curve.PTension = Tension;
            curve.InitializeGraph(ref FormGraphics);
        }

        /// <summary>
        /// 画线形
        /// </summary>
        public void DrawCurve()
        {
            curve.DrawTitle("温度、湿度曲线图", Color.Black);
            if (IsShowTemperature)
            {
                curve.LCurvePoint.AddRange(lTemperatureCurvePoint);
                curve.PCurveColor = CurveColor[0];
                curve.DrawCurve();
                curve.DrawExmp(0, "温度");
                curve.Clear();
            }
            if (IsShowHumidity)
            {
                curve.LCurvePoint.AddRange(lHumidityCurvePoint);
                curve.PCurveColor = CurveColor[1];
                curve.DrawCurve();
                curve.DrawExmp(1, "湿度");
                curve.Clear();
            }
        }

        /// <summary>
        /// 将数据涂在画面上
        /// </summary>
        /// <param name="lDivice"></param>
        public void SetData(List<Divice> lDivice)
        {
            if (lDivice == null)
            {
                return;
            }
            this.Fit(lDivice.Count);
            lTemperatureCurvePoint.Clear();
            lHumidityCurvePoint.Clear();
            FitXSlice(lDivice);
            //根据时间分开显示-这里的逻辑会比较复杂, 存数据时增加惰性计算, 去绝对平均值.
            for (int i = 0; i < lDivice.Count; i++)
            {
                var divice = lDivice[i];
                int X = (int)(XSlice * i);
                int YTemperature = (int)(divice.Temperature * TemperatureOff);
                int YHumidity = (int)(divice.Hum * HumidityOff);
                CurvePoint CPTemperature = new CurvePoint(divice.Temperature + "°", X, YTemperature);
                CurvePoint CPHumidity = new CurvePoint(divice.Hum + "%", X, YHumidity);
                lTemperatureCurvePoint.Add(CPTemperature);
                lHumidityCurvePoint.Add(CPHumidity);
            }
        }

        /// <summary>
        /// 根据日期进行查询,并根据时间跨度修改统计数据点之间的跨度
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        public void GetDataByDate(DateTime StartTime, DateTime EndTime)
        {
            //根据时间区间获得数据列表
            List<Divice> lDivice = SQLiteHelper.GetDataByTime(StartTime, EndTime.AddDays(1));

            //获得两个日期相差天数
            int Days = EndTime.Subtract(StartTime).Days + 1;

            //如果是当天
            if (Days == 1)
            {
                //修改List, 将数据中对应时间无值的情况填0
                FillNullData(lDivice, DisplayState.TIME, StartTime, EndTime);
                SetData(lDivice);
            }
            else
                if (Days <= 32)
                {
                    //根据每日求平均温度
                    FillNullData(lDivice, DisplayState.DAY, StartTime, EndTime);
                    SetData(lDivice);
                }
            //else
            //    if (Days <= 365 * 3)
            //    {
            //        //根据月求平均值
            //        FillNullData(lDivice, DisplayState.MONTH, StartTime, EndTime);
            //    }
            //else
            //{
            //    //不能显示
            //}

        }

        /// <summary>
        /// 获得差数
        /// </summary>
        /// <param name="Minuend">被减数</param>
        /// <param name="Meiosis">减数</param>
        /// <returns>差</returns>
        public int GetDifference(int Minuend, int Meiosis)
        {
            return Minuend - Meiosis;
        }

        private void FillNullData(List<Divice> lDivice, DisplayState State, DateTime StartTime, DateTime EndTime)
        {
            if (lDivice == null || lDivice.Count == 0)
            {
                return;
            }
            List<Divice> tmpLDivice = new List<Divice>(); ;
            //根据不同的显示状态对数据进行显示的格式化
            switch (State)
            {
                //根据时间显示
                case DisplayState.TIME:
                    //设置时间下标
                    curve.PSubscript = DisplayDay;
                    //将数据根据小时格式化
                    int minHour = lDivice[0].CreateTime.Hour;
                    int maxHour = lDivice[lDivice.Count - 1].CreateTime.Hour;
                    //根据小时数循环
                    for (int i = 0; i < 24; i++)
                    {

                        //循环所有数据
                        for (int j = 0; j < lDivice.Count; j++)
                        {
                            //若该数据是该时间区域的
                            if (lDivice[j].CreateTime.Hour == i)
                            {
                                tmpLDivice.Add(lDivice[j]);
                            }
                        }
                        //该时间段内的数据为0则增加一个0点数据
                        if (tmpLDivice.Count == 0)
                        {
                            //若最小不如当前时间小, 则增加在头
                            if (minHour > i)
                            {
                                Divice tmpDivice = new Divice();
                                tmpDivice.CreateTime = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, i, 0, 0);
                                tmpDivice.Hum = 0;
                                tmpDivice.Temperature = 0;
                                tmpDivice.Wo = 0;
                                lDivice.Insert(0, tmpDivice);
                            }
                            else
                                //若最大时间不如当前时间大,则增加在尾.
                                if (maxHour < i)
                                {
                                    Divice tmpDivice = new Divice();
                                    tmpDivice.CreateTime = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, i, 0, 0);
                                    tmpDivice.Hum = 0;
                                    tmpDivice.Temperature = 0;
                                    tmpDivice.Wo = 0;
                                    lDivice.Add(tmpDivice);
                                }
                                else
                                //否则在中间,需要循环所有数据插入数据
                                //算法:根据时间区间插入0数据
                                {
                                    for (int l = 0; l < lDivice.Count - 1; l++)
                                    {
                                        if (lDivice[l].CreateTime.Hour < i && lDivice[l + 1].CreateTime.Hour > i)
                                        {
                                            Divice tmpDivice = new Divice();
                                            tmpDivice.CreateTime = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, i, 0, 0);
                                            tmpDivice.Hum = 0;
                                            tmpDivice.Temperature = 0;
                                            tmpDivice.Wo = 0;
                                            lDivice.Insert(l + 1, tmpDivice);
                                        }
                                    }
                                }

                        }
                        else
                            //该时间段内的数据多于1则取一个平均值
                            //可能有问题, 待测试-------------------------------
                            if (tmpLDivice.Count > 1)
                            {
                                int count = tmpLDivice.Count;
                                for (int k = 1; k < tmpLDivice.Count; k++)
                                {
                                    tmpLDivice[0].Hum = (tmpLDivice[0].Hum + tmpLDivice[k].Hum);
                                    tmpLDivice[0].Temperature = (tmpLDivice[0].Temperature + tmpLDivice[k].Temperature);
                                    lDivice.Remove(tmpLDivice[k]);
                                }
                                tmpLDivice[0].Hum = tmpLDivice[0].Hum / count;
                                tmpLDivice[0].Temperature = tmpLDivice[0].Temperature / count;
                            }

                        tmpLDivice.Clear();
                    }
                    break;
                //根据天显示
                case DisplayState.DAY:
                    //设置动态日期的下标
                    //在这里直接操作startTime可能会有问题------------------------------------
                    int days = EndTime.Subtract(StartTime).Days + 1;
                    String[] DisplayDays = new String[days];
                    DateTime tmpDate = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day);
                    //List<Divice> DiviceBackUp = new List<Divice>();
                    //DiviceBackUp.AddRange(lDivice);
                    //将月日加入下标
                    for (int i = 0; i < DisplayDays.Length; i++)
                    {
                        DisplayDays[i] = "" + tmpDate.Month + "-" + tmpDate.Day;
                        tmpDate = tmpDate.AddDays(1);
                    }
                    //第一个加上年份,  若中间有其他年份的日期(跨年)则在这几天的1月1号加上年份
                    DisplayDays[0] = "" + StartTime.Year + "-" + DisplayDays[0];
                    curve.PSubscript = DisplayDays;
                    int daysCount = EndTime.Subtract(StartTime).Days + 1;
                    //将数据根据日格式化
                    for (int i = 1; i <= daysCount; i++)
                    {
                        for (int j = 0; j < lDivice.Count; j++)
                        {
                            DateTime tmpDiviceTime = new DateTime(lDivice[j].CreateTime.Year, lDivice[j].CreateTime.Month, lDivice[j].CreateTime.Day);
                            //若日期等于今天则加入临时list
                            if (tmpDiviceTime.CompareTo(StartTime) == 0)
                            {
                                tmpLDivice.Add(lDivice[j]);
                            }
                        }
                        //若没有数据则补0数据
                        if (tmpLDivice.Count == 0)
                        {
                            int index = 0;
                            for (int l = 0; l < lDivice.Count; l++)
                            {
                                if (lDivice[l].CreateTime.CompareTo(StartTime) < 0 && l < lDivice.Count - 1)//&& lDivice[l + 1].CreateTime.CompareTo(StartTime) > 0)
                                {
                                    index = l;
                                }
                                else
                                    if (l == lDivice.Count - 1)
                                    {
                                        index = l + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                            }
                            Divice tmpDivice = new Divice();
                            tmpDivice.CreateTime = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, 0, 0, 0);
                            tmpDivice.Hum = 0;
                            tmpDivice.Temperature = 0;
                            tmpDivice.Wo = 0;
                            lDivice.Insert(index, tmpDivice);
                            //InsertZeroData(lDivice, index, 0, i, StartTime);
                        }
                        else
                            //循环处理同一天数据
                            if (tmpLDivice.Count > 1)
                            {
                                int count = tmpLDivice.Count;
                                int index = lDivice.IndexOf(tmpLDivice[0], 0);
                                //将同一天数据求平均值存为1条
                                lDivice.Remove(tmpLDivice[0]);
                                for (int k = 1; k < tmpLDivice.Count; k++)
                                {
                                    tmpLDivice[0].Hum = (tmpLDivice[0].Hum + tmpLDivice[k].Hum);
                                    tmpLDivice[0].Temperature = (tmpLDivice[0].Temperature + tmpLDivice[k].Temperature);
                                    lDivice.Remove(tmpLDivice[k]);
                                }
                                //将数据替换为days个数个平均值加入list
                                //tmpLDivice = GetAverByCount(tmpLDivice, days);
                                //lDivice.InsertRange(index, tmpLDivice);
                                tmpLDivice[0].Hum = tmpLDivice[0].Hum / count;
                                tmpLDivice[0].Temperature = tmpLDivice[0].Temperature / count;
                                lDivice.Insert(index, tmpLDivice[0]);
                            }

                        StartTime = StartTime.AddDays(1);
                        tmpLDivice.Clear();
                    }
                    break;
                //根据月显示
                //case DisplayState.MONTH:
                //    //设置动态月下标
                //    int years = EndTime.Year - StartTime.Year;
                //    int year = StartTime.Year;
                //    int months = EndTime.Month - StartTime.Month + (years * 12);
                //    String[] DisplayMonth = new String[months];
                //    for (int i = 0; i < months; i++)
                //    {
                //        DisplayMonth[i] = "";
                //    }
                //    //将数据根据月格式化

                //    break;
            }

            ////由于根据时间进行从小到大排序多以第一个是几点就将几个0数据放入头当空数据
            //Divice firstDivice = lDivice[0];
            ////获得零点时间
            //DateTime date = new DateTime(firstDivice.CreateTime.Year, firstDivice.CreateTime.Month, firstDivice.CreateTime.Day);
            //int hours = firstDivice.CreateTime.Subtract(date).Hours;
            //hours = hours > 0 ? hours - 1 : 0;
            ////根据时间间隔为1小时增加零点数据
            //for (int i = 0; i < hours; i++)
            //{
            //    Divice tmpDivice = new Divice();
            //    tmpDivice.CreateTime = new DateTime(firstDivice.CreateTime.Year, firstDivice.CreateTime.Month, firstDivice.CreateTime.Day, i, 0, 0);
            //    tmpDivice.Hum = 0;
            //    tmpDivice.Temperature = 0;
            //    tmpDivice.Wo = 0;
            //    lDivice.Insert(i, tmpDivice);
            //}

            ////循环数据监测数据间时间的差距, 差距过大插0数据
            //for (int i = 0; i < lDivice.Count - 1; i++)
            //{
            //    Divice divice = lDivice[i];
            //    //若两个数据点在同一个时间段(1小时)内则取平均值
            //    if (lDivice[i].CreateTime.Hour == lDivice[i + 1].CreateTime.Hour)
            //    {
            //        lDivice[i].Hum = (lDivice[i].Hum + lDivice[i + 1].Hum) / 2;
            //        lDivice[i].Temperature = (lDivice[i].Temperature + lDivice[i + 1].Temperature) / 2;
            //        lDivice.Remove(lDivice[i + 1]);
            //    }
            //    //若两个数据点之间的时间超过1个小时(2小时以上)则在中间补0数据
            //    if (lDivice[i].CreateTime.Hour - lDivice[i + 1].CreateTime.Hour > 1)
            //    { }

            //}

            ////由于根据时间进行从小到大排序多以最后一个是几点就将几个0数据放入尾当空数据
            //Divice lastDivice = lDivice[lDivice.Count - 1];
            ////获得零点时间
            //date = new DateTime(firstDivice.CreateTime.Year, firstDivice.CreateTime.Month, firstDivice.CreateTime.Day);
            //hours = lastDivice.CreateTime.Subtract(date).Hours + 1;
            //int count = 24 - hours;
            ////根据时间间隔为1小时增加零点数据
            //for (int i = 0; i < count; i++)
            //{
            //    Divice tmpDivice = new Divice();
            //    tmpDivice.CreateTime = new DateTime(lastDivice.CreateTime.Year, lastDivice.CreateTime.Month, lastDivice.CreateTime.Day, hours + i, 0, 0);
            //    tmpDivice.Hum = 0;
            //    tmpDivice.Temperature = 0;
            //    tmpDivice.Wo = 0;
            //    lDivice.Add(tmpDivice);
            //}

        }


        /// <summary>
        /// 根据参数返回对应数量的平均值
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="AverCount"></param>
        /// <returns></returns>
        //private List<Divice> GetAverByCount(List<Divice> ld, int AverCount)
        //{
        //    if (ld == null || AverCount < 0)
        //    {
        //        return null;
        //    }
        //    if (ld.Count <= AverCount)
        //    {
        //        return ld;
        //    }

        //    List<Divice> tmpDivices = new List<Divice>();
        //    //获得返回列表数据的数量
        //    int count = ld.Count / AverCount;
        //    //余数
        //    int remainder = ld.Count - AverCount * count;
        //    for (int x = 0; x < count; x++)
        //    {
        //        Divice tmpDivice = new Divice();
        //        for (int i = x * AverCount; i < (x + 1) * AverCount; i++)
        //        {
        //            Divice divice = ld[i];
        //            tmpDivice.Temperature += divice.Temperature;
        //            tmpDivice.Hum += divice.Hum;
        //            tmpDivice.CreateTime = divice.CreateTime;
        //        }
        //        tmpDivice.Hum /= AverCount;
        //        tmpDivice.Temperature /= AverCount;
        //        tmpDivices.Add(tmpDivice);
        //    }

        //    for (int j = ld.Count - remainder; j < ld.Count; j++)
        //    {
        //        tmpDivices[tmpDivices.Count - 1].Hum += ld[j].Hum;
        //        tmpDivices[tmpDivices.Count - 1].Temperature += ld[j].Temperature;
        //    }
        //    tmpDivices[tmpDivices.Count - 1].Hum /= (remainder + 1);
        //    tmpDivices[tmpDivices.Count - 1].Temperature /= (remainder + 1);
        //    return tmpDivices;
        //}

        /// <summary>
        /// 插入0数据
        /// </summary>
        /// <param name="ld">数据list</param>
        /// <param name="index">插入的位置</param>
        /// <param name="count">插入的数量</param>
        /// <param name="hour">插入数据的小时</param>
        /// <param name="date">插入数据的日期</param>
        //private void InsertZeroData(List<Divice> ld, int index, int count, int hour, DateTime date)
        //{
        //    if (ld == null || index < 0 || count < 0)
        //    {
        //        return;
        //    }

        //    if (ld.Count < index)
        //    {
        //        return;
        //    }
        //    //循环插入数据
        //    for (int i = 0; i < count; i++)
        //    {
        //        Divice tmpDivice = new Divice();
        //        tmpDivice.CreateTime = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
        //        tmpDivice.Hum = 0;
        //        tmpDivice.Temperature = 0;
        //        tmpDivice.Wo = 0;
        //        ld.Insert(index, tmpDivice);
        //    }

        //}

    }

    public enum DisplayState
    {
        TIME, //根据时间显示
        DAY,  //根据日显示
        MONTH //根据月显示
    }


}
