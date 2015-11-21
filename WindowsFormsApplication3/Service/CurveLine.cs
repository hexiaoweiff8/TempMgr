using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace WindowsFormsApplication3.Service
{
    class CurveLine
    {
        //画笔
        private Graphics objGraphics;
        //图像宽度
        private int Width = 870;
        //图像高度
        private int Height = 380;
        //边距
        private int Padding = 15;
        //
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
        private float Tension = 0.2f;
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
        private Color CurveColor = Color.Red;
        //图像左右边距距离
        private float XSpace = 60;
        //图像上下边距距离
        private float YSpace = 40;
        //字体
        Font font = new Font("宋体", 9);
        //X轴文字旋转角度
        private float XRotateAngle = 40;
        //Y轴文字旋转角度
        private float YRotateAngle = 0;
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
        //private int DirectionWidth = 55;
        //private int DirectionHeight = 40;
        //显示上限
        private int UpSize = 100;
        //是否显示温度
        //private bool IsShowTemperature = true;
        //private bool IsShowHumidity = true;
        //下标数组
        private String[] Subscript = { };
        //下标间距
        private float SubSlice = 50;
        //下标Y轴便宜
        private float SubOffY = 10;
        //曲线中的点列表
        private List<CurvePoint> lCurvePoint = new List<CurvePoint>();

        #region 公共属性

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
        /// 曲线颜色
        /// </summary>
        public Color PCurveColor
        {
            get { return CurveColor; }
            set { CurveColor = value; }
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


        public Font Font
        {
            get { return font; }
            set { font = value; }
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

        /// <summary>
        /// 下标数组
        /// </summary>
        public String[] PSubscript
        {
            get { return Subscript; }
            set { Subscript = value; }
        }


        //public bool PIsShowHumidity
        //{
        //    get { return IsShowHumidity; }
        //    set { IsShowHumidity = value; }
        //}
        //public bool PIsShowTemperature
        //{
        //    get { return IsShowTemperature; }
        //    set { IsShowTemperature = value; }
        //}

        public List<CurvePoint> LCurvePoint
        {
            get { return lCurvePoint; }
            set { lCurvePoint = value; }
        }

        #endregion

        ///// <summary>
        ///// 根据参数调整宽度
        ///// </summary>
        public void Fit()
        {
            //适配Y轴曲线顶点之间的宽度
            float maxY = 0;

            for (int i = 0; i < lCurvePoint.Count; i++)
            {
                if (lCurvePoint[i].Y > maxY)
                {
                    maxY = lCurvePoint[i].Y;
                }
            }


            float tmpYSlice = (Height - YSpace) + YSliceBegin - YSlice * (maxY / YSliceValue);
            if (tmpYSlice < (YSpace))
            {
                YSlice = ((Height - YSpace * 2)) / (YSlice * (maxY / YSliceValue)) * YSlice;
            }

            float tmpSlice = (Width - XSpace * 2);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitializeGraph(ref Graphics FormGraphics)
        {

            objGraphics = FormGraphics;
            //填背景
            objGraphics.FillRectangle(new SolidBrush(BgColor), Padding, Padding, Width - 1, Height - 1);

            //画X轴
            int X1 = (int)XSpace;
            int Y1 = (int)(Height - YSpace);
            int X2 = (int)(Width - XSpace + XSlice / 2);
            int Y2 = Y1;
            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), X1, Y1, X2, Y2);
            //X轴的刻度
            int iSliceCount = (int)(((X2 - XSpace) / SliceLen));
            for (int i = 0; i < iSliceCount; i++)
            {
                float tmpX = X1 + (i + 1) * SliceLen;
                objGraphics.DrawLine(new Pen(AxisColor), tmpX, Y1, tmpX, Y1 - SliceLen);
            }
            //X轴的下标
            if (Subscript != null && Subscript.Length > 0)
            {
                SubSlice = (Width - XSpace * 2) / Subscript.Length;

                for (int i = 0; i < Subscript.Length; i++)
                {
                    float tmpx = X1 + i * SubSlice;
                    float tmpy = Y1 + SubOffY;
                    //旋转文字
                    objGraphics.TranslateTransform(tmpx, tmpy);
                    objGraphics.RotateTransform(XRotateAngle);
                    objGraphics.DrawString(Subscript[i], font, new SolidBrush(FontColor), 0, 0);
                    objGraphics.ResetTransform();
                }
            }

            //画Y轴
            X1 = (int)XSpace;
            Y1 = (int)(Height - YSpace);
            X2 = (int)XSpace;
            Y2 = (int)(YSpace);
            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), X1, Y1, X2, Y2);
            //Y轴的刻度
            iSliceCount = (int)((Y1 - Y2) / SliceLen);
            for (int i = 0; i < iSliceCount; i++)
            {
                float tmpY = Y2 + i * SliceLen;
                objGraphics.DrawLine(new Pen(AxisColor), X1, tmpY, X1 + SliceLen, tmpY);
            }
        }

        /// <summary>
        /// 画线形
        /// </summary>
        public void DrawCurve()
        {
            if (objGraphics == null)
            {
                return;
            }
            //创建画笔x
            Pen CurvePen = new Pen(CurveColor, CurveSize);
            //定位虚线画笔
            Pen DottedPen = new Pen(DottedColor, DottedLineSize);
            DottedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            int tmpCount = lCurvePoint.Count;

            if (tmpCount > 0)
            {
                //温度各个点
                PointF[] CurvePointF = new PointF[tmpCount];
                float X = 0;
                float Y = 0;
                float ZeroX = XSliceBegin;
                float ZeroY = (Height - YSpace) + YSliceBegin;
                float scale = (Height - YSpace * 2) / UpSize;

                for (int i = 0; i < tmpCount; i++)
                {
                    //if (PIsShowTemperature)
                    //{
                    X = lCurvePoint[i].X + ZeroX;
                    Y = ZeroY - lCurvePoint[i].Y * scale;
                    //X = XSlice * i + XSliceBegin;
                    //Y = (Height - YSpace) + YSliceBegin - YSlice * (lCurvePoint[i].Temperature / YSliceValue);
                    CurvePointF[i] = new PointF(X, Y);
                    objGraphics.FillRectangle(new SolidBrush(CurveColor), X - (EllipseW / 2), Y - (EllipseH / 2), EllipseW, EllipseH);
                    //定位虚线
                    objGraphics.DrawLine(DottedPen, ZeroX, Y, X, Y);
                    objGraphics.DrawLine(DottedPen, X, Y, X, ZeroY);
                    objGraphics.DrawString(lCurvePoint[i].DisplayText, font, new SolidBrush(CurveColor), X + 4, Y);
                    //}
                }
                //画上画布
                objGraphics.DrawCurve(CurvePen, CurvePointF, Tension);
            }
        }


        /// <summary>
        /// 画标题
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="color"></param>
        public void DrawTitle(String Text, Color color)
        {
            Font TitleFont = new Font("黑体", 30);
            float TitleWidth = objGraphics.MeasureString(Text, TitleFont).Width;
            int X = (int)((Width - XSpace * 2) / 2 - TitleWidth / 3);
            int Y = (int)YSpace;
            objGraphics.DrawString(Text, TitleFont, new SolidBrush(color), X, Y);
        }

        /// <summary>
        /// 画右上角说明
        /// </summary>
        /// <param name="Position">编号</param>
        /// <param name="Text">文字</param>
        public void DrawExmp(int Position, String Text)
        {
            float X = (Width - XSpace * 2);
            float Y = YSpace + Padding * Position;
            objGraphics.DrawString(Text, font, new SolidBrush(CurveColor), X + 40, Y);
            objGraphics.DrawLine(new Pen(CurveColor, CurveSize), X, Y + 5, X + 40, Y + 5);
            objGraphics.FillRectangle(new SolidBrush(CurveColor), X + 40 / 2 - EllipseW / 2, Y - CurveSize / 2, EllipseW, EllipseH);
        }

        public void Clear()
        {
            lCurvePoint.Clear();
        }

    }
    /// <summary>
    /// 曲线点
    /// </summary>
    public class CurvePoint
    {
        public CurvePoint(String displayText, int x, int y)
        {
            this.DisplayText = displayText;
            this.X = x;
            this.Y = y;
        }
        /// <summary>
        /// 显示文字
        /// </summary>
        public String DisplayText
        { get; set; }


        public int X { get; set; }

        public int Y { get; set; }
    }

}
