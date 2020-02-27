using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace QQClass
{
    /// <summary>
    /// 序列化或反序列化的类
    /// </summary>
    public class ClassSerializers
    {
        /// <summary>
        /// 将对象序列化为二进制内存流
        /// </summary>
        /// <param name="request">需要序列化的对象</param>
        /// <returns></returns>
        public MemoryStream SerializeBinary(object request)
        {
            BinaryFormatter serializer = new BinaryFormatter();//创建一个具有序列化和反序列化功能的对象
            MemoryStream memStream = new MemoryStream();///创建一个内存流存储区
            serializer.Serialize(memStream, request);//将对象序列化为二进制流
            return memStream;
        }
        /// <summary>
        /// 将二进制内存流反序列化为对象
        /// </summary>
        /// <param name="memStream"></param>
        /// <returns></returns>
        public object DeSerializeBinary(MemoryStream memStream)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            object newobj = deserializer.Deserialize(memStream);//将二进制流反序列化为对象
            memStream.Close();//关闭内存流，释放内存
            return newobj;
        }
    }
}
