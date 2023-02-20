using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using iphelper;

namespace netwatch.IpTable
{
    public class TcpRowDictionary
    {
        private readonly Dictionary<int, TcpRow> _tcpRows;

        public TcpRowDictionary()
        {
            _tcpRows = new Dictionary<int, TcpRow>();
        }

        public void AddItem(TcpRow item)
        {
            _tcpRows.Add(item.GetHashCode(), item);
        }

        public void RemoveKey(int tcpRowHash)
        {
            try
            {
                if (_tcpRows.ContainsKey(tcpRowHash))
                    _tcpRows.Remove(tcpRowHash);
            }
            catch (Exception)
            {
                Trace.WriteLine("Cannot Delete Object with Key : {0}", tcpRowHash.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}