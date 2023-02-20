using System;
using System.Globalization;
using System.Net;

namespace iphelper
{
    public class UdpRow
    {
        #region Private Fields

        private readonly IPEndPoint _localEndPoint;
        private readonly int _processId;

        #endregion Private Fields

        public UdpRow(IpHelper.UdpRow udpRow)
        {
            try
            {
                _processId = udpRow.owningPid;

                int localPort = (udpRow.localPort1 << 8) + (udpRow.localPort2) + (udpRow.localPort3 << 24) +
                                (udpRow.localPort4 << 16);
                long localAddress = udpRow.localAddr;
                _localEndPoint = new IPEndPoint(localAddress, localPort);
            }
            catch (Exception)
            {
            }
        }

        public IPEndPoint LocalEndPoint
        {
            get { return _localEndPoint; }
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
            string mydata = _localEndPoint + _processId.ToString(CultureInfo.InvariantCulture);
            return mydata.GetHashCode();
        }

        public override string ToString()
        {
            string retunData = String.Format("Process id: {0}, Address : {1}",
                                             _processId.ToString(CultureInfo.InvariantCulture), _localEndPoint);
            return retunData;
        }
    }
}