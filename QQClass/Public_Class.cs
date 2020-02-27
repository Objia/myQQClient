using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections;
using System.Runtime.InteropServices;

namespace QQClass
{
    /// <summary>
    /// 公共类，存储服务器和客户端的基本信息
    /// </summary>
    public class Public_Class
    {
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public static string ServerIP = "";
        /// <summary>
        /// 服务器端口号
        /// </summary>
        public static string ServerPort = "";
        /// <summary>
        /// 客户端IP地址
        /// </summary>
        public static string ClientIP = "";
        /// <summary>
        /// 客户端名称
        /// </summary>
        public static string ClientName = "";
        /// <summary>
        /// 用户名称
        /// </summary>
        public static string UserName = "";
        /// <summary>
        /// 用户ID号
        /// </summary>
        public static string UserID;
        /// <summary>
        /// 获取本机IP列表的第一个IP地址
        /// </summary>
        /// <returns>如果IP列表为空，则返回空字符串</returns>
        public string MyHostIP()
        {
            string hostname = Dns.GetHostName();//获取本机主机名
            IPHostEntry hostent = Dns.GetHostEntry(hostname);//通过主机名获取本机IPHostEntry信息
            Array addrs = hostent.AddressList;//通过本机IPHostEntry信息获取本机IP地址列表
            IEnumerator it = addrs.GetEnumerator();//获取迭代器
            while(it.MoveNext())//游标初始位置为-1
            {
                IPAddress ip = (IPAddress)it.Current;
                return ip.ToString();//获取到IP列表的第一个IP后就返回
            }
            return "";
        }
        /// <summary>
        /// 获取系统的windows目录，一般为c\:windows
        /// </summary>
        /// <param name="WinDir">用来存储windows目录完整路径的缓冲区</param>
        /// <param name="count">缓冲区的大小</param>
        [DllImport("kernel32")]
        public static extern void GetWindowsDirectory(StringBuilder WinDir, int count);
        /// <summary>
        /// 返回系统windows目录路径
        /// </summary>
        /// <returns></returns>
        public static string Get_windows()
        {
            const int nChars = 255;
            StringBuilder Buff = new StringBuilder(nChars);
            GetWindowsDirectory(Buff, nChars);
            return Buff.ToString();
        }
    }
}
