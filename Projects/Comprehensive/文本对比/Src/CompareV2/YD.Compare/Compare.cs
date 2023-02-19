using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace YD.Compare
{
    /// <summary>
    /// 比较两端文本
    /// </summary>
    public class Compare
    {
        private string dataA;
        private string dataB;
        string[] aLines;
        string[] bLines;

        private Diff diff = new Diff();

        private bool isTrimSpace;
        private bool isIgnoreSpace;
        private bool isIgnoreCase;
        private ResultLine[] result;

        /// <summary>
        /// 构造一次比较
        /// </summary>
        /// <param name="dataA">数据A，通常为旧版本</param>
        /// <param name="dataB">数据A，通常为新版本</param>
        public Compare(string dataA, string dataB)
        {
            if (dataA == null)
                throw new ArgumentNullException("dataA");
            if (dataB == null)
                throw new ArgumentNullException("dataB");

            this.dataA = dataA;
            this.dataB = dataB;

            this.aLines = dataA.Replace("\r", string.Empty).Split('\n');
            this.bLines = dataB.Replace("\r", string.Empty).Split('\n');
        }

        /// <summary>
        /// 取得比较结果
        /// </summary>
        /// <param name="isTrimSpace">是否忽略每行首位的空白</param>
        /// <param name="isIgnoreSpace">是否忽略所有的空白</param>
        /// <param name="isIgnoreCase">是否忽略大小写</param>
        /// <returns>比较结果，结果行的集合</returns>
        public ResultLine[] GetResult(bool isTrimSpace, bool isIgnoreSpace, bool isIgnoreCase)
        {
            //检查此次比较的参数是否与上次比较相同，如果相同且已经存在数据，则直接返回结果
            if (this.isTrimSpace == isTrimSpace && this.isIgnoreSpace == isIgnoreSpace && this.isIgnoreCase == isIgnoreCase)
                if (result != null)
                    return result;

            //签名
            this.isTrimSpace = isTrimSpace;
            this.isIgnoreSpace = isIgnoreSpace;
            this.isIgnoreCase = isIgnoreCase;

            //返回比较结果
            result = getResultLineByDifferentItems();
            return result;
        }
        /// <summary>
        /// 取得比较结果，采用默认的参数，即：不忽略任何空白，大小写敏感
        /// </summary>
        /// <returns>比较结果，结果行的集合</returns>
        public ResultLine[] GetResult()
        {
            return GetResult(false, false, false);
        }

        private ResultLine[] getResultLineByDifferentItems()
        {
            List<ResultLine> resultLineList = new List<ResultLine>();

            //取得不同之处
            DifferentItem[] differentItems = diff.DiffText(dataA, dataB, isTrimSpace, isIgnoreCase, isIgnoreSpace);
            //以B的行数为基准
            long lineNumberInB = 0;
            //遍历每一个不同之处
            for (long differentItemIndex = 0; differentItemIndex < differentItems.LongLength; differentItemIndex++)
            {
                //对于当前不同之处
                DifferentItem differentItem = differentItems[differentItemIndex];
                //取得相同的行
                lineNumberInB = AddSameLines(resultLineList, lineNumberInB, differentItem);
                //取得不同的行
                lineNumberInB = AddChangedLines(resultLineList, lineNumberInB, differentItem);

            } // 对不同之处的遍历结束

            //添加余下的相同的行
            AddLastLines(resultLineList, lineNumberInB, differentItems[differentItems.LongLength - 1]);

            //返回结果
            return resultLineList.ToArray();
        }

        /// <summary>
        /// 取得相同的行
        /// </summary>
        /// <param name="resultLineList">结果行列表</param>
        /// <param name="lineNumberInB">当前B中的行数</param>
        /// <param name="differentItem">当前的不同之处</param>
        /// <returns>完成后重设的B的行数</returns>
        private long AddSameLines(List<ResultLine> resultLineList, long lineNumberInB, DifferentItem differentItem)
        {
            //在A和B中行数的差别
            long offset = differentItem.StartB - differentItem.StartA;
            // 生成相同的行
            while ((lineNumberInB < differentItem.StartB) && (lineNumberInB < bLines.Length))
            {
                //求得A对应的行数
                long lineNumberInA = lineNumberInB - offset;
                //构造该“相同”类结果行，并加入到集合中
                resultLineList.Add(getSameResultLine(lineNumberInB - offset, lineNumberInB));
                //下一行
                lineNumberInB++;
            } // while

            return lineNumberInB;
        }
        /// <summary>
        /// 取得不相同的行
        /// </summary>
        /// <param name="resultLineList">结果行列表</param>
        /// <param name="lineNumberInB">当前B中的行数</param>
        /// <param name="differentItem">当前的不同之处</param>
        /// <returns>完成后重设的B的行数</returns>
        private long AddChangedLines(List<ResultLine> resultLineList, long lineNumberInB, DifferentItem differentItem)
        {
            //不同行的索引
            int differentLineIndex = 0;
            //插入修改的行
            while (differentLineIndex < differentItem.deletedA && differentLineIndex < differentItem.insertedB)
            {
                //求得A对应的行数
                int lineNumberInA = differentItem.StartA + differentLineIndex;
                //构造该“不同”类结果行，并加入到集合中
                resultLineList.Add(getDefferentResultLine(lineNumberInA, lineNumberInB));
                //下一行个不同行
                differentLineIndex++;
                //B的行数同时加一
                lineNumberInB++;
            }

            //如果A中的行数仍有剩余，则说明有些行是从A中删除的，构造删除类的结果行
            while (differentLineIndex < differentItem.deletedA)
            {
                //求得A对应的行数
                int lineNumberInA = differentItem.StartA + differentLineIndex;
                //构造该结果行，并加入到集合中
                resultLineList.Add(getDeleteResultLine(lineNumberInA));
                //下一个删除行，B的行数保持不变
                differentLineIndex++;
            }
            //如果B中的行数仍有剩余，则说明有些行是新插入到B中的，构造插入类的结果行
            while (lineNumberInB < differentItem.StartB + differentItem.insertedB)
            {
                //构造该“插入”类结果行，并加入到集合中
                resultLineList.Add(getInsertResultLine(lineNumberInB));
                //B的行数加一
                lineNumberInB++;
            }

            //返回修改后的行数
            return lineNumberInB++;
        }
        /// <summary>
        /// 添加剩余的行（相同）
        /// </summary>
        /// <param name="resultLineList">结果行列表</param>
        /// <param name="lineNumberInB">当前B中的行数</param>
        /// <param name="lastDifferentItem">最后一个不同之处</param>
        private void AddLastLines(List<ResultLine> resultLineList, long lineNumberInB, DifferentItem lastDifferentItem)
        {
            //在A和B中行数的差别
            long offset = (lastDifferentItem.StartB - lastDifferentItem.StartA) + (lastDifferentItem.insertedB - lastDifferentItem.deletedA);
            // 生成相同的行
            while ((lineNumberInB < bLines.Length))
            {
                //求得A对应的行数
                long lineNumberInA = lineNumberInB - offset;
                //构造该“相同”类结果行，并加入到集合中
                resultLineList.Add(getSameResultLine(lineNumberInB - offset, lineNumberInB));
                //下一行
                lineNumberInB++;
            } // while
        }

        private ResultLine getInsertResultLine(long lineNumberInB)
        {
            ResultLine line = new ResultLine();
            line.LineNumberA = -1;
            line.LineContentA = string.Empty;
            line.LineNumberB = lineNumberInB;
            line.LineContentB = bLines[lineNumberInB];
            line.ResultState = CompareState.Insert;
            return line;

        }
        private ResultLine getDeleteResultLine(long lineNumberInA)
        {
            ResultLine line = new ResultLine();
            line.LineNumberA = lineNumberInA;
            line.LineContentA = aLines[lineNumberInA];
            line.LineNumberB = -1;
            line.LineContentB = string.Empty;
            line.ResultState = CompareState.Delete;
            return line;
        }
        private ResultLine getDefferentResultLine(long lineNumberInA, long lineNumberInB)
        {
            ResultLine line = new ResultLine();
            line.LineNumberA = lineNumberInA;
            line.LineContentA = aLines[lineNumberInA];
            line.LineNumberB = lineNumberInB;
            line.LineContentB = bLines[lineNumberInB];
            line.ResultState = CompareState.Different;
            return line;
        }
        private ResultLine getSameResultLine(long lineNumberInA, long lineNumberInB)
        {
            ResultLine line = new ResultLine();
            line.LineNumberA = lineNumberInA;
            line.LineContentA = aLines[lineNumberInA];
            line.LineNumberB = lineNumberInB;
            line.LineContentB = bLines[lineNumberInB];
            line.ResultState = CompareState.Same;
            return line;
        }

    }
}
