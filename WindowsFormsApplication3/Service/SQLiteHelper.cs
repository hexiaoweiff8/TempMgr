using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace WindowsFormsApplication3.Service
{
    class SQLiteHelper
    {
        //数据库路径
        private static string DataFileName = "Data.db3";
        private static string DataPath = System.Environment.CurrentDirectory + @"/" + DataFileName;
        private static string ConnStr = "Data Source=" + DataPath + ";Initial Catalog=ReceiveData;";
        //数据连接
        private static DbConnection conn;
        private static DbCommand comm;
        /// <summary>
        /// 初次使用创建数据库
        /// </summary>
        public static void CreateDataBase()
        {
            try
            {
                bool isExist = File.Exists(DataPath);
                if (!isExist)
                {
                    SQLiteConnection.CreateFile(DataPath);
                }
                conn = new SQLiteConnection(ConnStr);
                conn.Open();
                comm = conn.CreateCommand();
                if (!isExist)
                {
                    String sql = "Create table ReceiveData(DeviceNum INTEGER , Temperature INTEGER , Humidity INTEGER , Tyrere INTEGER , MotorState INTEGER , ErrorNum INTEGER , CreateDate DateTime);";
                    comm.CommandText = sql;
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// 将设备编号, 温度, 湿度, 和报警号存入数据库以备查询
        /// </summary>
        /// <param name="DeviceNum">设备号</param>
        /// <param name="Temperature">温度</param>
        /// <param name="Humidity">湿度</param>
        /// <param name="WarningNum">警报号</param>
        public static void SaveData(int DeviceNum, int Temperature, int Humidity, int Tyrere, int MotorState, int ErrorNum)
        {
            //根据时间区间查询
            if ((conn == null) || (comm == null))
            {
                CreateDataBase();
            }
            String sqlStr = "Insert into ReceiveData(DeviceNum,Temperature,Humidity,Tyrere,MotorState,ErrorNum,CreateDate) values(" + DeviceNum + "," + Temperature + "," + Humidity + "," + Tyrere + "," + MotorState + "," + ErrorNum + ",Datetime('now','+8 hour'))";
            comm.CommandText = sqlStr;
            comm.ExecuteNonQuery();
        }

        /// <summary>
        /// 根据时间区间查询
        /// </summary>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        public static List<Divice> GetDataByTime(DateTime StartTime, DateTime EndTime)
        {
            //根据时间区间查询
            if ((conn != null && conn.State == ConnectionState.Open) && (comm != null))
            {
                CreateDataBase();
            }

            String sqlStr = "select * from ReceiveData where CreateDate>=datetime('" + StartTime.Year + "-" + (StartTime.Month > 9 ? ("" + StartTime.Month) : ("0" + StartTime.Month)) +
                "-" + (StartTime.Day > 9 ? ("" + StartTime.Day) : ("0" + StartTime.Day)) + "') and " +
                   "CreateDate<= datetime('" + EndTime.Year + "-" + (EndTime.Month > 9 ? ("" + EndTime.Month) : ("0" + EndTime.Month)) +
                "-" + (EndTime.Day > 9 ? ("" + EndTime.Day) : ("0" + EndTime.Day)) + "') order by CreateDate;";
            Console.Write(sqlStr);
            comm.CommandText = sqlStr;
            DbDataReader dr = comm.ExecuteReader();
            List<Divice> lDivice = new List<Divice>();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Divice divice = new Divice();
                    divice.DiviceNum = dr.GetInt32(0);
                    divice.Temperature = dr.GetInt32(1);
                    divice.Hum = dr.GetInt32(2);
                    divice.Wo = dr.GetInt32(3);
                    divice.MotorState = dr.GetInt32(4);
                    divice.ErrorNum = dr.GetInt32(5);
                    String tmp = dr.GetString(6);

                    divice.CreateTime = Convert.ToDateTime(tmp);
                    lDivice.Add(divice);
                }
            }

            return lDivice;
        }

    }
}
