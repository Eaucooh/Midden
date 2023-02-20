using System.Collections;
using System.Collections.Generic;

namespace iphelper
{
    public class TcpTable : IEnumerable<TcpRow>
    {
        #region Private Fields

        private readonly IEnumerable<TcpRow> tcpRows;

        #endregion Private Fields

        #region Constructors

        public TcpTable(IEnumerable<TcpRow> tcpRows)
        {
            this.tcpRows = tcpRows;
        }

        #endregion Constructors

        #region Public Properties

        public IEnumerable<TcpRow> Rows
        {
            get { return tcpRows; }
        }

        #endregion Public Properties

        #region IEnumerable<TcpRow> Members

        public IEnumerator<TcpRow> GetEnumerator()
        {
            return tcpRows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return tcpRows.GetEnumerator();
        }

        #endregion
    }
}