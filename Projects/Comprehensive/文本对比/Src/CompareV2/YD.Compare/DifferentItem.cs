using System;
using System.Collections.Generic;
using System.Text;

namespace YD.Compare
{
    /// <summary>
    /// 一项不同之处
    /// </summary>
    internal struct DifferentItem
    {
        /// <summary>
        /// 该不同之处在数据A中的起始行
        /// </summary>
        public int StartA;
        /// <summary>
        /// 该不同之处在数据B中的起始行
        /// </summary>
        public int StartB;

        /// <summary>
        /// 在A中删掉的行数
        /// </summary>
        public int deletedA;
        /// <summary>
        /// 在B中插入的行数
        /// </summary>
        public int insertedB;
    }
}
