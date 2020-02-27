using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace QQClass
{
    /// <summary>
    /// 窗体集合
    /// </summary>
    class ClassForms:CollectionBase
    {
        /// <summary>
        /// 将窗体添加到窗体集合中
        /// </summary>
        /// <param name="f">要添加的窗体对象</param>
        public void add(Form f)
        {
            base.InnerList.Add(f);
        }
        /// <summary>
        /// 从窗体集合中移除指定的窗体
        /// </summary>
        /// <param name="f">要移除的窗体对象</param>
        public void Remove(Form f)
        {
            base.InnerList.Remove(f);
        }
        /// <summary>
        /// 窗体索引
        /// </summary>
        /// <param name="index">索引号</param>
        /// <returns>查找到的窗体对象</returns>
        public Form this[int index]
        {
            get
            {
                return (Form)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
