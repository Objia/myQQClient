using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace QQClass
{
    /// <summary>
    /// 用户信息列表类，存储所有注册用户信息（可序列化）
    /// </summary>
    [Serializable]
    class ClassUsers:CollectionBase
    {
        /// <summary>
        /// 将一个用户信息添加到列表中
        /// </summary>
        /// <param name="userInfo"></param>
        public void Add(ClassUserInfo userInfo)
        {
            base.InnerList.Add(userInfo);
        }
        /// <summary>
        /// 从列表中移除指定的用户
        /// </summary>
        /// <param name="userInfo"></param>
        public void Remove(ClassUserInfo userInfo)
        {
            base.InnerList.Remove(userInfo);
        }
        /// <summary>
        /// 根据索引号在列表中查找指定的用户
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ClassUserInfo this[int index]
        {
            get { return (ClassUserInfo)List[index]; }
            set { List[index] = value; }
        }

    }
}
