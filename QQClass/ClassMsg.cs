using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQClass
{
    /// <summary>
    /// 消息类（可序列化）
    /// </summary>
    [Serializable]
    public class ClassMsg
    {
        /// <summary>
        /// 发送方编号
        /// </summary>
        public string SID = "";
        /// <summary>
        /// 发送方IP
        /// </summary>
        public string SIP = "";
        /// <summary>
        /// 发送方端口
        /// </summary>
        public string SPort = "";
        /// <summary>
        /// 接收方编号民
        /// </summary>
        public string RID = "";
        /// <summary>
        /// 接收方IP
        /// </summary>
        public string RIP = "";
        /// <summary>
        /// 接收方端口
        /// </summary>
        public string RPort = "";
        /// <summary>
        /// 消息类型
        /// </summary>
        public SendKind sendKind = SendKind.SendNone;
        /// <summary>
        /// 消息中的命令类型
        /// </summary>
        public MsgCommand msgCommand = MsgCommand.None;
        /// <summary>
        /// 消息发送状态
        /// </summary>
        public SendState sendState = SendState.None;
        /// <summary>
        /// 消息ID，GUID
        /// </summary>
        public string msgID = "";
        /// <summary>
        /// 消息数据内容
        /// </summary>
        public byte[] Data;
    }
    /// <summary>
    /// 用户注册信息类（可序列化）
    /// </summary>
    [Serializable]
    public class RegisterMsg
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password;
    }


    /// <summary>
    /// 发送类型
    /// </summary>
    public enum SendKind
    {
        /// <summary>
        /// 无类型
        /// </summary>
        SendNone,
        /// <summary>
        /// 命令
        /// </summary>
        SendCommand,
        /// <summary>
        /// 消息
        /// </summary>
        SendMsg,
        /// <summary>
        /// 文件
        /// </summary>
        SendFile
    }
    /// <summary>
    /// 命令类型
    /// </summary>
    public enum MsgCommand
    {
        /// <summary>
        /// 无命令
        /// </summary>
        None,
        /// <summary>
        /// 注册
        /// </summary>
        Registering,
        /// <summary>
        /// 注册结束
        /// </summary>
        Registered,
        /// <summary>
        /// 登录
        /// </summary>
        Logining,
        /// <summary>
        /// 登录结束（上线）
        /// </summary>
        Logined,
        /// <summary>
        /// 单发消息
        /// </summary>
        SendToOne,
        /// <summary>
        /// 群发消息
        /// </summary>
        SendToAll,
        /// <summary>
        /// 获取用户列表
        /// </summary>
        UserList,
        /// <summary>
        /// 更新用户状态
        /// </summary>
        UpdateState,
        /// <summary>
        /// 打开视频
        /// </summary>
        VideoOpen,
        /// <summary>
        /// 正在视频
        /// </summary>
        Videoing,
        /// <summary>
        /// 下线
        /// </summary>
        Close
    }
    /// <summary>
    /// 发送状态
    /// </summary>
    public enum SendState
    {
        /// <summary>
        /// 无状态
        /// </summary>
        None,
        /// <summary>
        /// 单消息或文件
        /// </summary>
        Single,
        /// <summary>
        /// 开始发送生成文件
        /// </summary>
        Start,
        /// <summary>
        /// 正在发送中，写入文件
        /// </summary>
        Sending,
        /// <summary>
        /// 发送结束
        /// </summary>
        End
    }
}
