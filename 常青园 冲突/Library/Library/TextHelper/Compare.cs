using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Library.TextHelper
{
    /// <summary>
    /// 比较状态
    /// </summary>
    public enum CompareState
    {
        /// <summary>
        /// 未知，未经过比较
        /// </summary>
        UnKnows = 0,
        /// <summary>
        /// 两行相同
        /// </summary>
        Same = 1,
        /// <summary>
        /// 两行有差别
        /// </summary>
        Different = 2,
        /// <summary>
        /// 新插入的行
        /// </summary>
        Insert = 3,
        /// <summary>
        /// 被删除的行
        /// </summary>
        Delete = 4,
    }

    public class Compare
    {
        /// <summary>
        /// 获取不一致的字符脚标
        /// </summary>
        /// <param name="txt1">字符一</param>
        /// <param name="txt2">字符二</param>
        /// <returns>脚标数组</returns>
        public static int[] GetDiffrentIndexes(string txt1, string txt2)
        {
            char[] left = txt1.ToCharArray();
            char[] right = txt2.ToCharArray();
            char[] t1, t2;
            if (left.Length > right.Length)
            {
                t2 = new char[left.Length];
                t1 = left;
                for (int i = 0; i < t2.Length; i++)
                {
                    if (i < right.Length)
                    {
                        t2[i] = right[i];
                    }
                    else
                    {
                        t2[i] = ' ';
                    }
                }
            }
            else
            {
                t1 = new char[left.Length];
                t2 = left;
                for (int i = 0; i < t1.Length; i++)
                {
                    if (i < right.Length)
                    {
                        t1[i] = right[i];
                    }
                    else
                    {
                        t1[i] = ' ';
                    }
                }
            }

            List<int> index = new List<int>();

            for (int i = 0; i < t1.Length; i++)
            {
                if (t1[i] != t2[i])
                {
                    index.Add(i);
                }
            }

            int[] rst = new int[index.Count];
            for (int i = 0; i < rst.Length; i++)
            {
                rst[i] = index[i];
            }
            return rst;
        }

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

    internal class Diff
    {
        /// <summary>
        /// Shortest Middle Snake Return Data
        /// </summary>
        private struct SMSRD
        {
            internal int x, y;
            // internal int u, v;  // 2002.09.20: no need for 2 points 
        }

        /// <summary>
        /// Find the difference in 2 texts, comparing by textlines.
        /// </summary>
        /// <param name="TextA">A-version of the text (usualy the old one)</param>
        /// <param name="TextB">B-version of the text (usualy the new one)</param>
        /// <returns>Returns a array of Items that describe the differences.</returns>
        internal DifferentItem[] DiffText(string TextA, string TextB)
        {
            return (DiffText(TextA, TextB, false, false, false));
        } // DiffText


        /// <summary>
        /// Find the difference in 2 text documents, comparing by textlines.
        /// The algorithm itself is comparing 2 arrays of numbers so when comparing 2 text documents
        /// each line is converted into a (hash) number. This hash-value is computed by storing all
        /// textlines into a common hashtable so i can find dublicates in there, and generating a 
        /// new number each time a new textline is inserted.
        /// </summary>
        /// <param name="TextA">A-version of the text (usualy the old one)</param>
        /// <param name="TextB">B-version of the text (usualy the new one)</param>
        /// <param name="trimSpace">When set to true, all leading and trailing whitespace characters are stripped out before the comparation is done.</param>
        /// <param name="ignoreSpace">When set to true, all whitespace characters are converted to a single space character before the comparation is done.</param>
        /// <param name="ignoreCase">When set to true, all characters are converted to their lowercase equivivalence before the comparation is done.</param>
        /// <returns>Returns a array of Items that describe the differences.</returns>
        internal DifferentItem[] DiffText(string TextA, string TextB, bool trimSpace, bool ignoreSpace, bool ignoreCase)
        {
            // prepare the input-text and convert to comparable numbers.
            Hashtable h = new Hashtable(TextA.Length + TextB.Length);

            // The A-Version of the data (original data) to be compared.
            DiffData DataA = new DiffData(DiffCodes(TextA, h, trimSpace, ignoreSpace, ignoreCase));

            // The B-Version of the data (modified data) to be compared.
            DiffData DataB = new DiffData(DiffCodes(TextB, h, trimSpace, ignoreSpace, ignoreCase));

            h = null; // free up hashtable memory (maybe)

            LCS(DataA, 0, DataA.Length, DataB, 0, DataB.Length);
            return CreateDiffs(DataA, DataB);
        } // DiffText


        /// <summary>
        /// Find the difference in 2 arrays of integers.
        /// </summary>
        /// <param name="ArrayA">A-version of the numbers (usualy the old one)</param>
        /// <param name="ArrayB">B-version of the numbers (usualy the new one)</param>
        /// <returns>Returns a array of Items that describe the differences.</returns>
        internal DifferentItem[] DiffInt(int[] ArrayA, int[] ArrayB)
        {
            // The A-Version of the data (original data) to be compared.
            DiffData DataA = new DiffData(ArrayA);

            // The B-Version of the data (modified data) to be compared.
            DiffData DataB = new DiffData(ArrayB);

            LCS(DataA, 0, DataA.Length, DataB, 0, DataB.Length);
            return CreateDiffs(DataA, DataB);
        } // Diff


        /// <summary>
        /// This function converts all textlines of the text into unique numbers for every unique textline
        /// so further work can work only with simple numbers.
        /// </summary>
        /// <param name="aText">the input text</param>
        /// <param name="h">This extern initialized hashtable is used for storing all ever used textlines.</param>
        /// <param name="trimSpace">When set to true, all leading and trailing whitespace characters are stripped out before the comparation is done.</param>
        /// <param name="ignoreSpace">When set to true, all whitespace characters are converted to a single space character before the comparation is done.</param>
        /// <param name="ignoreCase">When set to true, all characters are converted to their lowercase equivivalence before the comparation is done.</param>
        /// <returns>a array of integers.</returns>
        private int[] DiffCodes(string aText, Hashtable h, bool trimSpace, bool ignoreSpace, bool ignoreCase)
        {
            // get all codes of the text
            string[] Lines;
            int[] Codes;
            int lastUsedCode = h.Count;
            object aCode;
            string s;

            // strip off all cr, only use lf as textline separator.
            aText = aText.Replace("\r", "");
            Lines = aText.Split('\n');

            Codes = new int[Lines.Length];

            for (int i = 0; i < Lines.Length; ++i)
            {
                s = Lines[i];
                if (trimSpace)
                    s = s.Trim();

                if (ignoreSpace)
                {
                    s = Regex.Replace(s, "\\s+", " ");            // TODO: optimization: faster blank removal.
                }

                if (ignoreCase)
                    s = s.ToLower();

                aCode = h[s];
                if (aCode == null)
                {
                    lastUsedCode++;
                    h[s] = lastUsedCode;
                    Codes[i] = lastUsedCode;
                }
                else
                {
                    Codes[i] = (int)aCode;
                } // if
            } // for
            return (Codes);
        } // DiffCodes


        /// <summary>
        /// This is the algorithm to find the Shortest Middle Snake (SMS).
        /// </summary>
        /// <param name="DataA">sequence A</param>
        /// <param name="LowerA">lower bound of the actual range in DataA</param>
        /// <param name="UpperA">upper bound of the actual range in DataA (exclusive)</param>
        /// <param name="DataB">sequence B</param>
        /// <param name="LowerB">lower bound of the actual range in DataB</param>
        /// <param name="UpperB">upper bound of the actual range in DataB (exclusive)</param>
        /// <returns>a MiddleSnakeData record containing x,y and u,v</returns>
        private SMSRD SMS(DiffData DataA, int LowerA, int UpperA, DiffData DataB, int LowerB, int UpperB)
        {
            SMSRD ret;
            int MAX = DataA.Length + DataB.Length + 1;

            int DownK = LowerA - LowerB; // the k-line to start the forward search
            int UpK = UpperA - UpperB; // the k-line to start the reverse search

            int Delta = (UpperA - LowerA) - (UpperB - LowerB);
            bool oddDelta = (Delta & 1) != 0;

            // vector for the (0,0) to (x,y) search
            int[] DownVector = new int[2 * MAX + 2];

            // vector for the (u,v) to (N,M) search
            int[] UpVector = new int[2 * MAX + 2];

            // The vectors in the publication accepts negative indexes. the vectors implemented here are 0-based
            // and are access using a specific offset: UpOffset UpVector and DownOffset for DownVektor
            int DownOffset = MAX - DownK;
            int UpOffset = MAX - UpK;

            int MaxD = ((UpperA - LowerA + UpperB - LowerB) / 2) + 1;

            // Debug.Write(2, "SMS", String.Format("Search the box: A[{0}-{1}] to B[{2}-{3}]", LowerA, UpperA, LowerB, UpperB));

            // init vectors
            DownVector[DownOffset + DownK + 1] = LowerA;
            UpVector[UpOffset + UpK - 1] = UpperA;

            for (int D = 0; D <= MaxD; D++)
            {

                // Extend the forward path.
                for (int k = DownK - D; k <= DownK + D; k += 2)
                {
                    // Debug.Write(0, "SMS", "extend forward path " + k.ToString());

                    // find the only or better starting point
                    int x, y;
                    if (k == DownK - D)
                    {
                        x = DownVector[DownOffset + k + 1]; // down
                    }
                    else
                    {
                        x = DownVector[DownOffset + k - 1] + 1; // a step to the right
                        if ((k < DownK + D) && (DownVector[DownOffset + k + 1] >= x))
                            x = DownVector[DownOffset + k + 1]; // down
                    }
                    y = x - k;

                    // find the end of the furthest reaching forward D-path in diagonal k.
                    while ((x < UpperA) && (y < UpperB) && (DataA.data[x] == DataB.data[y]))
                    {
                        x++; y++;
                    }
                    DownVector[DownOffset + k] = x;

                    // overlap ?
                    if (oddDelta && (UpK - D < k) && (k < UpK + D))
                    {
                        if (UpVector[UpOffset + k] <= DownVector[DownOffset + k])
                        {
                            ret.x = DownVector[DownOffset + k];
                            ret.y = DownVector[DownOffset + k] - k;
                            // ret.u = UpVector[UpOffset + k];      // 2002.09.20: no need for 2 points 
                            // ret.v = UpVector[UpOffset + k] - k;
                            return (ret);
                        } // if
                    } // if

                } // for k

                // Extend the reverse path.
                for (int k = UpK - D; k <= UpK + D; k += 2)
                {
                    // Debug.Write(0, "SMS", "extend reverse path " + k.ToString());

                    // find the only or better starting point
                    int x, y;
                    if (k == UpK + D)
                    {
                        x = UpVector[UpOffset + k - 1]; // up
                    }
                    else
                    {
                        x = UpVector[UpOffset + k + 1] - 1; // left
                        if ((k > UpK - D) && (UpVector[UpOffset + k - 1] < x))
                            x = UpVector[UpOffset + k - 1]; // up
                    } // if
                    y = x - k;

                    while ((x > LowerA) && (y > LowerB) && (DataA.data[x - 1] == DataB.data[y - 1]))
                    {
                        x--; y--; // diagonal
                    }
                    UpVector[UpOffset + k] = x;

                    // overlap ?
                    if (!oddDelta && (DownK - D <= k) && (k <= DownK + D))
                    {
                        if (UpVector[UpOffset + k] <= DownVector[DownOffset + k])
                        {
                            ret.x = DownVector[DownOffset + k];
                            ret.y = DownVector[DownOffset + k] - k;
                            // ret.u = UpVector[UpOffset + k];     // 2002.09.20: no need for 2 points 
                            // ret.v = UpVector[UpOffset + k] - k;
                            return (ret);
                        } // if
                    } // if

                } // for k

            } // for D

            throw new ApplicationException("the algorithm should never come here.");
        } // SMS


        /// <summary>
        /// This is the divide-and-conquer implementation of the longes common-subsequence (LCS) 
        /// algorithm.
        /// The published algorithm passes recursively parts of the A and B sequences.
        /// To avoid copying these arrays the lower and upper bounds are passed while the sequences stay constant.
        /// </summary>
        /// <param name="DataA">sequence A</param>
        /// <param name="LowerA">lower bound of the actual range in DataA</param>
        /// <param name="UpperA">upper bound of the actual range in DataA (exclusive)</param>
        /// <param name="DataB">sequence B</param>
        /// <param name="LowerB">lower bound of the actual range in DataB</param>
        /// <param name="UpperB">upper bound of the actual range in DataB (exclusive)</param>
        private void LCS(DiffData DataA, int LowerA, int UpperA, DiffData DataB, int LowerB, int UpperB)
        {
            // Debug.Write(2, "LCS", String.Format("Analyse the box: A[{0}-{1}] to B[{2}-{3}]", LowerA, UpperA, LowerB, UpperB));

            // Fast walkthrough equal lines at the start
            while (LowerA < UpperA && LowerB < UpperB && DataA.data[LowerA] == DataB.data[LowerB])
            {
                LowerA++; LowerB++;
            }

            // Fast walkthrough equal lines at the end
            while (LowerA < UpperA && LowerB < UpperB && DataA.data[UpperA - 1] == DataB.data[UpperB - 1])
            {
                --UpperA; --UpperB;
            }

            if (LowerA == UpperA)
            {
                // mark as inserted lines.
                while (LowerB < UpperB)
                    DataB.modified[LowerB++] = true;

            }
            else if (LowerB == UpperB)
            {
                // mark as deleted lines.
                while (LowerA < UpperA)
                    DataA.modified[LowerA++] = true;

            }
            else
            {
                // Find the middle snakea and length of an optimal path for A and B
                SMSRD smsrd = SMS(DataA, LowerA, UpperA, DataB, LowerB, UpperB);
                // Debug.Write(2, "MiddleSnakeData", String.Format("{0},{1}", smsrd.x, smsrd.y));

                // The path is from LowerX to (x,y) and (x,y) ot UpperX
                LCS(DataA, LowerA, smsrd.x, DataB, LowerB, smsrd.y);
                LCS(DataA, smsrd.x, UpperA, DataB, smsrd.y, UpperB);  // 2002.09.20: no need for 2 points 
            }
        } // LCS()


        /// <summary>Scan the tables of which lines are inserted and deleted,
        /// producing an edit script in forward order.  
        /// </summary>
        /// dynamic array
        private DifferentItem[] CreateDiffs(DiffData DataA, DiffData DataB)
        {
            ArrayList a = new ArrayList();
            DifferentItem aItem;
            DifferentItem[] result;

            int StartA, StartB;
            int LineA, LineB;

            LineA = 0;
            LineB = 0;
            while (LineA < DataA.Length || LineB < DataB.Length)
            {
                if ((LineA < DataA.Length) && (!DataA.modified[LineA])
                  && (LineB < DataB.Length) && (!DataB.modified[LineB]))
                {
                    // equal lines
                    LineA++;
                    LineB++;

                }
                else
                {
                    // maybe deleted and/or inserted lines
                    StartA = LineA;
                    StartB = LineB;

                    while (LineA < DataA.Length && (LineB >= DataB.Length || DataA.modified[LineA]))
                        // while (LineA < DataA.Length && DataA.modified[LineA])
                        LineA++;

                    while (LineB < DataB.Length && (LineA >= DataA.Length || DataB.modified[LineB]))
                        // while (LineB < DataB.Length && DataB.modified[LineB])
                        LineB++;

                    if ((StartA < LineA) || (StartB < LineB))
                    {
                        // store a new difference-item
                        aItem = new DifferentItem();
                        aItem.StartA = StartA;
                        aItem.StartB = StartB;
                        aItem.deletedA = LineA - StartA;
                        aItem.insertedB = LineB - StartB;
                        a.Add(aItem);
                    } // if
                } // if
            } // while

            result = new DifferentItem[a.Count];
            a.CopyTo(result);

            return (result);
        }

    } // class Diff

    /// <summary>Data on one input file being compared.  
    /// </summary>
    internal class DiffData
    {

        /// <summary>Number of elements (lines).</summary>
        internal int Length;

        /// <summary>Buffer of numbers that will be compared.</summary>
        internal int[] data;

        /// <summary>
        /// Array of booleans that flag for modified data.
        /// This is the result of the diff.
        /// This means deletedA in the first Data or inserted in the second Data.
        /// </summary>
        internal bool[] modified;

        /// <summary>
        /// Initialize the Diff-Data buffer.
        /// </summary>
        /// <param name="initData">reference to the buffer</param>
        internal DiffData(int[] initData)
        {
            data = initData;
            Length = initData.Length;
            modified = new bool[Length + 2];
        } // DiffData

    } // class DiffData

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

    public struct DetailUnit
    {
        public string UnitContent;
        public CompareState UnitState;
    }
}
