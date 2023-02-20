using System;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;

namespace iphelper
{
    public class TcpRow
    {
        #region Private Fields

        private readonly IPEndPoint _localEndPoint;
        private readonly int _processId;
        private readonly IPEndPoint _remoteEndPoint;
        private readonly TcpState _state;

        #endregion Private Fields

        #region Constructors

        public TcpRow(IpHelper.TcpRow tcpRow)
        {
            _state = tcpRow.state;
            _processId = tcpRow.owningPid;

            int localPort = (tcpRow.localPort1 << 8) + (tcpRow.localPort2) + (tcpRow.localPort3 << 24) +
                            (tcpRow.localPort4 << 16);
            long localAddress = tcpRow.localAddr;
            _localEndPoint = new IPEndPoint(localAddress, localPort);

            int remotePort = (tcpRow.remotePort1 << 8) + (tcpRow.remotePort2) + (tcpRow.remotePort3 << 24) +
                             (tcpRow.remotePort4 << 16);
            long remoteAddress = tcpRow.remoteAddr;
            _remoteEndPoint = new IPEndPoint(remoteAddress, remotePort);
        }

        #endregion Constructors

        #region Public Properties

        public IPEndPoint LocalEndPoint
        {
            get { return _localEndPoint; }
        }

        public string LocalAddress
        {
            get { return LocalEndPoint.ToString(); }
        }

        public IPEndPoint RemoteEndPoint
        {
            get { return _remoteEndPoint; }
        }

        public string ForeignAddress
        {
            get { return RemoteEndPoint.ToString(); }
        }

        public TcpState State
        {
            get { return _state; }
        }

        public string StrState
        {
            get { return _state.ToString(); }
        }

        public int ProcessId
        {
            get { return _processId; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            try
            {
                var otherObject = obj as TcpRow;
                if (otherObject == null)
                    return false;
                if (otherObject.GetHashCode() == GetHashCode())
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            string mydata = _localEndPoint + _remoteEndPoint.ToString() +
                            _processId.ToString(CultureInfo.InvariantCulture) + _state.ToString();
            return mydata.GetHashCode();
        }

        public override string ToString()
        {
            string retunData = String.Format("Process id: {0}, LocalAddress : {1}, RemoteAddress : {2}, State : {3}",
                                             _processId.ToString(CultureInfo.InvariantCulture), _localEndPoint,
                                             _remoteEndPoint + _state.ToString());
            return retunData;
        }

        #endregion Public Properties
    }
}