using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace QQClass
{
    public partial class UDPSocket : Component
    {
        //定义私有数据
        /// <summary>
        /// 一个网络端点对象,用来记录给本机发送数据的远程主机地址和端口，默认为null
        /// </summary>
        private IPEndPoint ServerEndPoint = null;
        /// <summary>
        /// UDP数据通信对象
        /// </summary>
        private UdpClient UDP_Server = new UdpClient();
        /// <summary>
        /// 子线程对象
        /// </summary>
        private Thread thdUdp;

        //定义公有数据
        /// <summary>
        /// DataArrival事件委托类型
        /// </summary>
        /// <param name="Data">数据内容</param>
        /// <param name="Ip">接收数据的IP地址</param>
        /// <param name="port">接收数据的端口</param>
        public delegate void DataArrivalEventHandle(byte[] Data, IPAddress Ip, int port);
        /// <summary>
        /// 一个DataArrival事件对象
        /// </summary>
        public event DataArrivalEventHandle DataArrival;

        #region 字段和属性
        /// <summary>
        /// 本地IP地址字段，默认为127.0.0.1
        /// </summary>
        private string localHost = "127.0.0.1";
        /// <summary>
        /// 本地IP地址
        /// </summary>
        [Browsable(true),Category("Local"),Description("本地IP地址")]//在“属性”窗口中显示localHost属性
        public string LocalHost
        {
            get { return localHost; }
            set { localHost = value; }
        }
        /// <summary>
        /// 本地端口号
        /// </summary>
        private int localPort = 11000;
        /// <summary>
        /// 本地端口号
        /// </summary>
        [Browsable(true),Category("Local"),Description("本地端口号")]//在“属性”窗口中显示localHost属性
        public int LocalPort
        {
            get { return LocalPort; }
            set { LocalPort = value; }
        }
        /// <summary>
        /// 是否激活监听状态
        /// </summary>
        private bool active = false;
        /// <summary>
        /// 监听状态
        /// </summary>
        [Browsable(true),Category("Local"),Description("激活监听")]
        public bool Active
        {
            get { return active; }
            set
            {
                active = value;
                if (active)
                {
                    OpenSocket();//打开监听
                }
                else
                {
                    CloseSocket();//关闭监听
                }
            }
        }
        #endregion

        public UDPSocket()
        {
            InitializeComponent();
        }

        public UDPSocket(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// 打开监听udpclient对象，在本地指定端口开始监听线程（阻塞方式）
        /// </summary>
        private void OpenSocket()
        {
            Listener();//创建子线程开始监听
        }
        /// <summary>
        /// 关闭监听
        /// </summary>
        private void CloseSocket()
        {
            if(UDP_Server!=null)
            {
                UDP_Server.Close();//在主线程中关闭Socket，准备中断子线程
            }
            if(thdUdp!=null)//如果子线程正在使用
            {
                Thread.Sleep(30);//主线程睡眠，确保子线程关闭后才断续执行后续代码
                thdUdp.Abort();//中断子线程
            }
        }
        /// <summary>
        /// 创建子线程开始监听
        /// </summary>
        protected void Listener()
        {
            ServerEndPoint = new IPEndPoint(IPAddress.Any, localPort);//指定IP地址和端口号
            if(UDP_Server!=null)
            {
                UDP_Server.Close();//关闭Socket
            }
            UDP_Server = new UdpClient(localPort);//给UDP_Server重新赋值新对象，原对象丢弃后系统自动回收

            try
            {
                thdUdp = new Thread(new ThreadStart(GetUDPData));//创建一个线程，使用ThreadStart类型初始化，线程开始时执行GetUDPData函数
                thdUdp.Start();//开始执行线程
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());//显示线程错误信息
            }
        }
        /// <summary>
        /// 循环监听，有数据到则调用DataArrival事件处理函数处理数据
        /// </summary>
        private void GetUDPData()
        {
            while(active)
            {
                try
                {
                    byte[] Data = UDP_Server.Receive(ref ServerEndPoint);//接收数据并记录远程主机信息，使用阻塞方式，所以无法使用close,只能强制中断线程达到关闭的目的
                    if(DataArrival!=null)
                    {
                        DataArrival(Data, ServerEndPoint.Address, ServerEndPoint.Port);//调用事件处理函数
                    }
                    Thread.Sleep(0);//挂起此线程，使其他等待线程能够执行
                }
                catch { }//捕获所有异常，但不做任何操作
            }
        }
        /// <summary>
        /// 数据发送函数，在主线程中发送，在子线程中接收
        /// </summary>
        /// <param name="Host">目标主机IP地址</param>
        /// <param name="Port">目标主机端口</param>
        /// <param name="Data">要发送的数据</param>
        public void Send(IPAddress Host,int Port,byte[] Data)
        {
            try
            {
                IPEndPoint server = new IPEndPoint(Host, Port);
                UDP_Server.Send(Data, Data.Length, server);//调用UDP数据通信对象发送数据
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
