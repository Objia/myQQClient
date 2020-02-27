using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQClass
{
    /// <summary>
    /// 记录当前用户的编号、IP地址、端口号、用户名和用户状态（可序列化）
    /// </summary>
    [Serializable]
    class ClassUserInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        private string userID;
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// IP地址
        /// </summary>
        private string userIP;
        /// <summary>
        /// IP地址
        /// </summary>
        public string UserIP
        {
            get { return userIP; }
            set { userIP = value; }
        }

        /// <summary>
        /// 端口号
        /// </summary>
        private string userPort;
        /// <summary>
        /// 端口号
        /// </summary>
        public string UserPort
        {
            get { return userPort; }
            set { userPort = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        private string userName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// 当前用户状态
        /// </summary>
        private string state;
        /// <summary>
        /// 当前用户状态
        /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
