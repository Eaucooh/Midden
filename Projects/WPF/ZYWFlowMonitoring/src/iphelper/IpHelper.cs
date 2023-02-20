using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace iphelper
{
    public static class IpHelper
    {
        #region Public Fields

        public const string DllName = "iphlpapi.dll";
        public const int AfInet = 2;

        #endregion Public Fields

        #region Public Methods

        /// <summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/library/aa365928.aspx"/>
        /// </summary>
        [DllImport(DllName, SetLastError = true)]
        public static extern uint GetExtendedTcpTable(IntPtr tcpTable, ref int tcpTableLength, bool sort, int ipVersion,
                                                      TcpTableType tcpTableType, int reserved);

        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/aa365930%28v=vs.85%29"/>
        /// </summary>
        [DllImport(DllName, SetLastError = true)]
        public static extern uint GetExtendedUdpTable(IntPtr udpTable, ref int udpTableLength, bool sort, int ipVersion,
                                                      UdpTableType udpTableType, int reserved);

        #endregion Public Methods

        #region Public Enums

        #region TcpTableType enum

        /// <summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/library/aa366386.aspx"/>
        /// </summary>
        public enum TcpTableType
        {
            BasicListener,
            BasicConnections,
            BasicAll,
            OwnerPidListener,
            OwnerPidConnections,
            OwnerPidAll,
            OwnerModuleListener,
            OwnerModuleConnections,
            OwnerModuleAll,
        }

        #endregion

        #region UdpTableType enum

        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/aa366388%28v=vs.85%29"/>
        /// </summary>
        public enum UdpTableType
        {
            Basic,
            OwnerPid,
            OwnerModule
        }

        #endregion

        #endregion Public Enums

        #region Public Structs

        #region Nested type: TcpRow

        /// <summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/library/aa366913.aspx"/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TcpRow
        {
            public TcpState state;
            public uint localAddr;
            public byte localPort1;
            public byte localPort2;
            public byte localPort3;
            public byte localPort4;
            public uint remoteAddr;
            public byte remotePort1;
            public byte remotePort2;
            public byte remotePort3;
            public byte remotePort4;
            public int owningPid;
        }

        #endregion

        #region Nested type: TcpTable

        /// <summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/library/aa366921.aspx"/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TcpTable
        {
            public uint Length;
            public TcpRow row;
        }

        #endregion

        #region Nested type: UdpRow

        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/aa366928%28v=vs.85%29"/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct UdpRow
        {
            public uint localAddr;
            public byte localPort1;
            public byte localPort2;
            public byte localPort3;
            public byte localPort4;
            public int owningPid;
        }

        #endregion

        #region Nested type: UdpTable

        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/aa366932%28v=vs.85%29"/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct UdpTable
        {
            public uint Length;
            public UdpRow row;
        }

        #endregion

        #endregion Public Structs
    }
}