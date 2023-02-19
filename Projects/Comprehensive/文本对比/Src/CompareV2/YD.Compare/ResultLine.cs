using System;
using System.Collections.Generic;
using System.Text;

namespace YD.Compare
{
    /// <summary>
    /// 表示一个比较结果行
    /// </summary>
    public struct ResultLine
    {
        /// <summary>
        /// 对应数据A中的行号，如果无对应行，则为-1
        /// </summary>
        public long LineNumberA;
        /// <summary>
        /// 对应数据B中的行号，如果无对应行，则为-1
        /// </summary>
        public long LineNumberB;
        /// <summary>
        /// 对应数据A中的内容
        /// </summary>
        public string LineContentA;
        /// <summary>
        /// 对应数据B中的内容
        /// </summary>
        public string LineContentB;
        /// <summary>
        /// 该行的状态
        /// </summary>
        public CompareState ResultState;
    }
}
