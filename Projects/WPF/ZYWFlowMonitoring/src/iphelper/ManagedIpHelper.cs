using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace iphelper
{
    public static class ManagedIpHelper
    {
        #region Public Methods

        public static TcpTable GetExtendedTcpTable(bool sorted)
        {
            var tcpRows = new List<TcpRow>();

            IntPtr tcpTable = IntPtr.Zero;
            int tcpTableLength = 0;

            if (
                IpHelper.GetExtendedTcpTable(tcpTable, ref tcpTableLength, sorted, IpHelper.AfInet,
                                             IpHelper.TcpTableType.OwnerPidAll, 0) != 0)
            {
                try
                {
                    tcpTable = Marshal.AllocHGlobal(tcpTableLength);
                    if (
                        IpHelper.GetExtendedTcpTable(tcpTable, ref tcpTableLength, true, IpHelper.AfInet,
                                                     IpHelper.TcpTableType.OwnerPidAll, 0) == 0)
                    {
                        var table = (IpHelper.TcpTable) Marshal.PtrToStructure(tcpTable, typeof (IpHelper.TcpTable));

                        var rowPtr = (IntPtr) ((long) tcpTable + Marshal.SizeOf(table.Length));
                        for (int i = 0; i < table.Length; ++i)
                        {
                            tcpRows.Add(
                                new TcpRow((IpHelper.TcpRow) Marshal.PtrToStructure(rowPtr, typeof (IpHelper.TcpRow))));
                            rowPtr = (IntPtr) ((long) rowPtr + Marshal.SizeOf(typeof (IpHelper.TcpRow)));
                        }
                    }
                }
                finally
                {
                    if (tcpTable != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(tcpTable);
                    }
                }
            }

            return new TcpTable(tcpRows);
        }

        public static UdpTable GetExtendedUdpTable(bool sorted)
        {
            var udpRows = new List<UdpRow>();

            IntPtr udpTable = IntPtr.Zero;
            int udpTableLength = 0;

            if (
                IpHelper.GetExtendedUdpTable(udpTable, ref udpTableLength, sorted, IpHelper.AfInet,
                                             IpHelper.UdpTableType.OwnerPid, 0) != 0)
            {
                try
                {
                    udpTable = Marshal.AllocHGlobal(udpTableLength);
                    if (
                        IpHelper.GetExtendedUdpTable(udpTable, ref udpTableLength, true, IpHelper.AfInet,
                                                     IpHelper.UdpTableType.OwnerPid, 0) == 0)
                    {
                        var table = (IpHelper.UdpTable) Marshal.PtrToStructure(udpTable, typeof (IpHelper.UdpTable));

                        var rowPtr = (IntPtr) ((long) udpTable + Marshal.SizeOf(table.Length));
                        for (int i = 0; i < table.Length; ++i)
                        {
                            udpRows.Add(
                                new UdpRow((IpHelper.UdpRow) Marshal.PtrToStructure(rowPtr, typeof (IpHelper.UdpRow))));
                            rowPtr = (IntPtr) ((long) rowPtr + Marshal.SizeOf(typeof (IpHelper.TcpRow)));
                        }
                    }
                }
                finally
                {
                    if (udpTable != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(udpTable);
                    }
                }
            }

            return new UdpTable(udpRows);
        }

        #endregion Public Methods
    }
}