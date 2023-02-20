using System.Collections;
using System.Collections.Generic;

namespace iphelper
{
    public class UdpTable : IEnumerable<UdpRow>
    {
        #region Private Fields

        private readonly IEnumerable<UdpRow> _udpRows;

        #endregion Private Fields

        #region Constructors

        public UdpTable(IEnumerable<UdpRow> udpRows)
        {
            this._udpRows = udpRows;
        }

        #endregion Constructors

        #region Public Properties

        public IEnumerable<UdpRow> Rows
        {
            get { return _udpRows; }
        }

        #endregion Public Properties

        #region IEnumerable<UdpRow> Members

        public IEnumerator<UdpRow> GetEnumerator()
        {
            return _udpRows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _udpRows.GetEnumerator();
        }

        #endregion
    }
}