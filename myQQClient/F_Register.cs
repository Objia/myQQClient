using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using QQClass;

namespace myQQClient
{
    public partial class frmRegister : Form
    {
        /// <summary>
        /// 负责收发数据的对象
        /// </summary>
        private ClassUDPSocket udpSocket1;
        /// <summary>
        /// 定义一个委托，本程序中用于在接收线程【子线程】上对控件执行异步操作（主要是更改控件属性）
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Ip"></param>
        /// <param name="Port"></param>
        private delegate void DataArrivaldelegate(byte[] Data, IPAddress Ip, int Port);

        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="section">段名</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filePath">INI文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">段名</param>
        /// <param name="key">键</param>
        /// <param name="def">指定键不存在时返回的默认值</param>
        /// <param name="retVal">存储读出值的缓冲区</param>
        /// <param name="size">缓冲区大小</param>
        /// <param name="filePath">INI文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmRegister()
        {
            InitializeComponent();
            
            //初始化收发数据对象和事件处理函数
            udpSocket1 = new ClassUDPSocket();
            udpSocket1.DataArrival += new ClassUDPSocket.DataArrivalEventHandle(sockUDP1_DataArrival);     
        }
        /// <summary>
        /// 窗口加载事件函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRegister_Load(object sender, EventArgs e)
        {
            udpSocket1.Active = true;//激活监听（开子线程阻塞监听）
        }
        /// <summary>
        /// DataArrival事件处理函数（本程序中该函数是在接收线程【子线程】上执行）
        /// </summary>
        /// <param name="Data">接收的字节数组</param>
        /// <param name="Ip">远程主机的IP地址</param>
        /// <param name="Port">远程主机的端口</param>
        private void sockUDP1_DataArrival(byte[] Data,IPAddress Ip,int Port)
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival);//初始化委托
            //在控件线程【主线程】上异步执行操作（这里的异步是相当于子线程而言：将委托从子线程发到主线程，由主线程执行，子线程不等待断续执行后续操作）
            //因为需要更改控件属性，所以使用this.BeginInvoke将委托发到控件线程异步执行,若使用outdelegate.BeginInvoke,则会将委托发送到一个新线程异步执行，在非控件线程上是无法更改控属性的
            this.BeginInvoke(outdelegate, new object[] { Data, Ip, Port });
        }
        /// <summary>
        /// 被子线程DataArrival事件处理函数发送到控件线程异步执行的函数
        /// </summary>
        /// <param name="Data">接收的字节数组</param>
        /// <param name="Ip">远程主机的IP地址</param>
        /// <param name="Port">远程主机的端口</param>
        private void DataArrival(byte[] Data,IPAddress Ip,int Port)
        {
            try
            {
                //将接收的字节数组反序列化
                ClassMsg msg = new ClassSerializers().DeSerializeBinary(new System.IO.MemoryStream(Data)) as ClassMsg;
                switch(msg.msgCommand)
                {
                    case MsgCommand.Registered://注册成功
                        DialogResult = DialogResult.OK;//设置注册窗口对话框结果属性
                        WritePrivateProfileString("MyQQ", "ID", this.txtServer.Text.Trim(), Public_Class.Get_windows() + @"\MyQQServer.ini");//向INI文件写入ID键值对
                        WritePrivateProfileString("MyQQ", "Port", this.txtPort.Text.Trim(), Public_Class.Get_windows() + @"\MyQQServer.ini");//向INI文件写入Port键值对
                        WritePrivateProfileString("MyQQ", "Name", this.txtUserName.Text.Trim(), Public_Class.Get_windows() + @"\MyQQServer.ini");//向INI文件写入Name键值对
                        break;
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 确定按键点击事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.txtPassword.Text.Trim()==this.txtPasswordVerify.Text.Trim())
            {
                RegisterMsg registermsg = new RegisterMsg();
                registermsg.UserName = this.txtUserName.Text.Trim();
                registermsg.UserName = this.txtPassword.Text.Trim();

                byte[] registerData = new ClassSerializers().SerializeBinary(registermsg).ToArray();//将用户信息对象序列化后存入Data
                
                //定义消息
                ClassMsg msg = new ClassMsg();
                msg.sendKind = SendKind.SendCommand;
                msg.msgCommand = MsgCommand.Registering;
                msg.Data = registerData;

                byte[] send_data = new ClassSerializers().SerializeBinary(msg).ToArray();//消息对象序列化
                //发送
                udpSocket1.Send(IPAddress.Parse(this.txtServer.Text.Trim()), Convert.ToInt32(txtPort.Text.Trim()), send_data);
            }
            else
            {
                this.txtPassword.Text = "";
                this.txtPasswordVerify.Text = "";
                MessageBox.Show("密码与确认密码不匹配，请重新输入。");
            }
        }
        /// <summary>
        /// 取消按钮点击事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
           this.DialogResult = DialogResult.Cancel;//设置注册窗口对话框结果属性
        }
        /// <summary>
        /// 注册窗口关闭事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            udpSocket1.Active = false;//关闭监听线程，结束监听
        }
    }
}
