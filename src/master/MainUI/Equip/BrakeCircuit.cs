using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using RW.Modules;

namespace RWTEST.UI
{
    /// <summary>
    /// 力传感器 采值方式 被改为 上位机通过串口读取
    /// </summary>
    public class BrakeCircuit
    {

        public static SerialPort serialPortForce = new SerialPort(); //端口1


        static bool IsConnected = true;
        public static void Circuit_Init()
        {
            //注册串口 事件
            //serialPortForce.DataReceived += new SerialDataReceivedEventHandler(OnForceGrpChanged);
            OpenSP();

            //持续 发送力传感器读取指令
            //ThreadPool.QueueUserWorkItem(delegate(object state)
            //{

            //    while (IsConnected)
            //    {
            //        IsConnected = WriteCom(by);
            //    }
            //});

        }




        /// <summary>
        /// 打开串口
        /// </summary>
        public static void OpenSP()
        {

            if (!serialPortForce.IsOpen)
            {

                try
                {
                    serialPortForce.Open();
                    //Var.ForceStatus = true;
                }
                catch (Exception ex)
                {
                    // Var.ForceStatus = false;
                    //MessageBox.Show("力传感器读取端口打开异常！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show(ex.Message);
                }

            }
        }


        /// <summary>
        /// 串口指令
        /// 
        /// </summary>
        public static byte[] by = new Byte[] { 0xAA, 0x0AB, 0x00, 0x00, 0x00, 0x00, 0xFF };



        public static void SetBrakekPa(int kPa)
        {
            //删除压力因小于 350kPa  
            if (kPa > 350)
                kPa = 350;

            byte[] bytes = BitConverter.GetBytes(kPa);
            //Array.Reverse(bytes);
            by[2] = bytes[0];
            by[3] = bytes[1];
            by[4] = bytes[2];
            by[5] = bytes[3];

            WriteCom(by);


        }

        private static bool WriteCom(byte[] StartComand)
        {
            bool res = false;
            try
            {
                //if (serialPort2.IsOpen && (Convert.ToDouble(OpcClassHelp.AIVI.AIVI01.Value) > 100.0))
                if (serialPortForce.IsOpen)   //
                {
                    //通信开始
                    // byte[] tempreadbuffer1 = new byte[5];
                    serialPortForce.DiscardInBuffer();
                    serialPortForce.DiscardOutBuffer();
                    Thread.Sleep(200);
                    serialPortForce.Write(StartComand, 0, StartComand.Length);

                    res = true;
                }
                else
                {
                    //MessageBox.Show("请先打开串口！");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return res;

        }



        /// <summary>
        /// 串口 接收数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnForceGrpChanged(object sender, SerialDataReceivedEventArgs e)
        {
            string str = "";
            int count = serialPortForce.BytesToRead;
            if (count <= 0)
                return;
            byte[] databuff = new byte[count];
            serialPortForce.Read(databuff, 0, count);

        }



        #region 增加值改变事件

        public static event ValueHandler ValueChanged;

        public static void onValueChanged(double value)
        {
            if (ValueChanged != null) ValueChanged(null, value);
        }

        #endregion




    }






    public delegate void delegateHandler();
    public class my
    {
        public int i = 0;
        public delegateHandler myhandle;
        public int changeI
        {
            get { return i; }
            set
            {
                i = value;
                myhandle();
            }
        }
    }

    public class otherclass
    {
        public my o;
        public otherclass()
        {
            o = new my();
        }
        public void init()
        {
            o.myhandle += new delegateHandler(howtodeal);
        }
        public void howtodeal()
        {
            //你自己的处理程序   
        }


    }

}
