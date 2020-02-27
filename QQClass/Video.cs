using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace QQClass
{
    /// <summary>
    /// 导入dll函数，申明消息常量
    /// </summary>
    class VideoAPI
    {
        /// <summary>
        /// 创建摄像头窗口
        /// </summary>
        /// <param name="lpszWindowName">窗口名称</param>
        /// <param name="dwStyle">窗口风格</param>
        /// <param name="x">窗口x坐标</param>
        /// <param name="y">窗口y坐标</param>
        /// <param name="nWidth">窗口宽度</param>
        /// <param name="nHeight">窗口高度</param>
        /// <param name="hWndParent">父窗口句柄</param>
        /// <param name="nID">窗口ID</param>
        /// <returns>返回新建窗口句柄</returns>
        [DllImport("avicap32.dll")]
        public static extern IntPtr capCreateCaptureWindowA(byte[] lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, int nID);
        /// <summary>
        /// 获取摄像头驱动的版本描述
        /// </summary>
        /// <param name="wDriver">驱动程序索引（0到9）</param>
        /// <param name="lpszName">驱动程序名称</param>
        /// <param name="cbName">驱动程序名称大小</param>
        /// <param name="lpszVer">驱动程序版本描述</param>
        /// <param name="cbVer">驱动程序版本描述的大小</param>
        /// <returns>成功返回true，失败返回false</returns>
        [DllImport("avicap32.dll")]
        public static extern bool capGetDriverDescriptionA(short wDriver, byte[] lpszName, int cbName, byte[] lpszVer, int cbVer);
        /// <summary>
        /// 向指定窗口发送消息
        /// </summary>
        /// <param name="hWnd">接收消息的窗口</param>
        /// <param name="wMsg">发送的消息</param>
        /// <param name="wParam">消息的附加信息（可选）</param>
        /// <param name="lParam">消息的附加信息（可选）</param>
        /// <returns>成功返回true，失败返回false</returns>
        [DllImport("User32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);
        [DllImport("User32.dll")]
        /// <summary>
        /// 向指定窗口发送消息
        /// </summary>
        /// <param name="hWnd">接收消息的窗口</param>
        /// <param name="wMsg">发送的消息</param>
        /// <param name="wParam">消息的附加信息（可选）</param>
        /// <param name="lParam">消息的附加信息（可选）</param>
        /// <returns>成功返回true，失败返回false</returns>
        public static extern bool SendMessage(IntPtr hWnd, int wMsg, short wParam, int lParam);

        /// <summary>
        /// 为了防止用户定义的消息ID与系统的消息ID冲突，微软定义一个宏WM_USER（固定值0x0400），小于WM_USER的ID被系统使用，大于WM_USER的ID被用户使用。
        /// </summary>
        public const int WM_USER = 0x00000400;
        /// <summary>
        /// 窗口风格为子窗口（必须关闭子窗口，父窗口才能获得焦点）
        /// </summary>
        public const int WS_CHILD = 0x40000000;
        /// <summary>
        /// 窗口风格为可见
        /// </summary>
        public const int WS_VISIBLE = 0x10000000;
        /// <summary>
        /// 设置窗口位置属性为窗口大小不可改变
        /// </summary>
        public const int SWP_NOSIZE = 0x1;
        /// <summary>
        /// 设置窗口位置属性为窗口不可移动
        /// </summary>
        public const int SWP_NOMOVE = 0x2;
        /// <summary>
        /// 设置窗口位置属性为忽略设置窗口Z值的参数，保持窗口Z顺序
        /// </summary>
        public const int SWP_NOZORDER = 0x4;
        /// <summary>
        /// 启动摄像头
        /// </summary>
        public const int WM_CAP_START = WM_USER;
        /// <summary>
        /// 设置预览帧回调函数
        /// </summary>
        public const int WM_CAP_SET_CALLBACK_FRAME = WM_CAP_START + 5;
        /// <summary>
        /// 摄像头驱动连接
        /// </summary>
        public const int WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10;
        /// <summary>
        /// 摄像头驱动连接断开
        /// </summary>
        public const int WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11;
        /// <summary>
        /// 将当前帧保存到DIB文件中
        /// </summary>
        public const int WM_CAP_FILE_SAVEDIB = WM_CAP_START + 25;
        /// <summary>
        /// 设置视频格式
        /// </summary>
        public const int WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45;
        /// <summary>
        /// 设置预览模式
        /// </summary>
        public const int WM_CAP_SET_PREVIEW= WM_CAP_START + 50;
        /// <summary>
        /// 设置预览模式下的帧显示速率
        /// </summary>
        public const int WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52;
    }

    class cVideo
    {
        /// <summary>
        /// 视频控件句柄
        /// </summary>
        private IntPtr lwndC;
        /// <summary>
        /// 视频控件的父窗口句柄
        /// </summary>
        private IntPtr mControlPrt;
        /// <summary>
        /// 视频控件宽度
        /// </summary>
        private int mWidth;
        /// <summary>
        /// 视频控件高度
        /// </summary>
        private int mHeight;
        /// <summary>
        /// 初始化视频类
        /// </summary>
        /// <param name="handle">视频控件的父窗口句柄</param>
        /// <param name="width">视频控件宽度</param>
        /// <param name="height">视频控件高度</param>
        public cVideo(IntPtr handle,int width,int height)
        {
            mControlPrt = handle;
            mWidth = width;
            mHeight = height;
        }
        /// <summary>
        /// 打开视频设备
        /// </summary>
        public void StartWebCam()
        {
            byte[] lpszName= new byte[100];//视频设备驱动名称的缓存空间
            byte[] lpszVer = new byte[100];//视频设备驱动版本描述的缓存空间
            VideoAPI.capGetDriverDescriptionA(0, lpszName, 100, lpszVer, 100);
            this.lwndC = VideoAPI.capCreateCaptureWindowA(lpszName, VideoAPI.WS_CHILD | VideoAPI.WS_VISIBLE, 0, 0, mWidth, mHeight, mControlPrt, 0);
            if(VideoAPI.SendMessage(lwndC,VideoAPI.WM_CAP_DRIVER_CONNECT,0,0))
            {
                VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_SET_PREVIEWRATE, 100, 0);//设置帧速率为100
                VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_SET_PREVIEW, true, 0);//打开预览模式
            }
        }
        /// <summary>
        /// 关闭视频设备
        /// </summary>
        public void CloseWebcam()
        {
            VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_DRIVER_DISCONNECT, 0, 0);
        }
        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="path">要保存bmp文件的路径</param>
        public void GrabImage(string path)
        {
            IntPtr hBmp = Marshal.StringToHGlobalAnsi(path);//将托管字符串复制到非托管内存中，并返回内存地址
            VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_FILE_SAVEDIB, 0, hBmp.ToInt32());//将拍照图片以位图文件的方式存到硬盘指定路径
        }
    }
}
