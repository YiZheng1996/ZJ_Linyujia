using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using RW.Driver;
using System.ComponentModel;

namespace RWTEST.UI
{
    public class TH2516B
    {
        /// <summary>
        /// 读取电阻的串口
        /// </summary>
        public SerialPort serialPort2516B = new SerialPort();
        static object locker = new object();

        public TH2516B(SerialPort port)
        {
            this.serialPort2516B = port;
        }

        // 《TH2516系列直流低电阻测试仪使用说明书.pdf》 第48页，测量速度设定命令 APERture Fast/SLOW1

        public void Init(SerialPortConfig config)
        {
            serialPort2516B.PortName = config.PortName;
            serialPort2516B.BaudRate = config.BaudRate;
            serialPort2516B.DataBits = config.DataBits;
            serialPort2516B.Parity = config.Parity;
            serialPort2516B.StopBits = config.StopBits;

        }

        // ----------读取TH2516B的电阻--RS232通讯，2,3，5脚接通。//2,3脚接线必须对调。//2,3脚接线必须对调。//2,3脚接线必须对调。
        //2,3脚接线必须对调。见《TH2516系列中文说明书.pdf》第38页。
        // RS:Recommended Standard，推荐标准。 2发送，3接受，5接地

        /// <summary>
        /// 线路内阻
        /// </summary>
        double InnerDianzu = 0.0;



        // -------------------------------------
        [DisplayName("开始测试")]
        public string PortRead_TH2516B()
        {
            lock (locker)
            {
                int num = 0;//循环执行次数
                bool readdata = false;//是否读取到数据
                string rst = "";
                string rst2 = "";
                string rst3 = "";
                while (num < 5 && readdata == false)
                {
                    num++;
                    string str = "";
                    try
                    {
                        if (!serialPort2516B.IsOpen)
                        {
                            serialPort2516B.Open();
                        }
                        serialPort2516B.DiscardInBuffer();
                        serialPort2516B.DiscardOutBuffer();
                        Thread.Sleep(80);
                        serialPort2516B.Write("FETC:IMP?\r\n");
                        Thread.Sleep(350);
                        str = serialPort2516B.ReadExisting();

                        rst = Read_2516B(str);

                        if (rst != "999999" && rst != "0" && rst2 == "")
                        {
                            rst2 = rst;
                        }
                        else if (rst != "999999" && rst != "0" && rst2 != "" && rst3 == "")
                        {
                            rst3 = rst;
                        }
                        if (rst2 != ""& rst3 != "")
                        {
                            if (Math.Abs(Convert.ToDouble(rst2) - Convert.ToDouble(rst3)) <= 0.1)
                            {
                                readdata = true;
                            }
                            else
                            {
                                rst2 = rst3;
                                rst3 = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        num++;
                        string err = ex.Message;
                        Debug.WriteLine("触点电阻测量异常：" + err);
                    }
                }
                if (rst2 == "")
                {
                    rst2 = "999999";
                }

                return rst2;

            }
        }


        private string Read_2516B(string data)
        {
            // 正常传入参数  +1.998670E+03,+0,
            //+9.900000E+37    返回值错误代码
            // 1E+03,+0,+1.999911E+03,+0

            string tbdz_2516 = "";
            if (data.Length >= 16)
            {
                string value1 = data.Substring(0, 1);//起始符号+
                string value2 = data.Substring(1, 8);//电阻值小数部分
                string value3 = data.Substring(10, 3);//电阻值系数部分E
                int mul = 0;//系数
                double value = 0;
                double vlaue_2516 = 0;
                if (value1 != "+")
                {
                    if (value1 == "-")
                    {
                        value = double.Parse(value2);
                        string xs = value3.Substring(1, 2);
                        mul = int.Parse(xs);
                        vlaue_2516 = value / Math.Pow(10, mul) * 1000;
                        tbdz_2516 = vlaue_2516.ToString("#0.0#");
                    }
                    else
                    {
                        //tbdz_2516.Text = "error";
                    }
                    return "0";
                }
                if (value3 == "+37")
                {
                    //tbdz_2516.Text = "error";
                    return "999999";
                }
                else
                {
                    string xs = value3.Substring(1, 2);
                    string ss = value3.Substring(0, 1);
                    mul = int.Parse(xs);
                    value = double.Parse(value2);
                    if (ss == "-")
                    {
                        vlaue_2516 = value / Math.Pow(10, mul) * 1000;
                        //vlaue_2516 = value / Math.Pow(10, mul);
                        tbdz_2516 = vlaue_2516.ToString();// ("#0.0#");
                        //tbdz_2516 += "mΩ";
                    }
                    if (ss == "+")
                    {
                        vlaue_2516 = value * Math.Pow(10, mul);
                        tbdz_2516 = vlaue_2516.ToString();// ("#0.0#");
                        //tbdz_2516 += "Ω";
                    }
                }
            }
            return tbdz_2516;
        }
    }
}
