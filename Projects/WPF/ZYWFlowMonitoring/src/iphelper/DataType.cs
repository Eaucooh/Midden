using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace iphelper
{
    public class TcpDataType
    {
        public string Protocol
        {
            get { return "TCP"; }
        }

        public string State { get; set; }

        public string LocalAddress { get; set; }

        public string ForeignAddress { get; set; }

        public int Pid { get; set; }

        public string ImageName { get; set; }

        public TcpDataType()
        {
        }

        public TcpDataType(TcpRow data)
        {
            State = data.State.ToString();
            LocalAddress = data.LocalEndPoint.ToString();
            ForeignAddress = data.RemoteEndPoint.ToString();

            Pid = data.ProcessId;

            //try to get ImageName
            ImageName = "Skipped";
            try
            {
                //Process process = Process.GetProcessById(data.ProcessId);
                //ImageName = process.MainModule.FileName;
            }
            catch (Exception)
            {
                Debug.WriteLine("Oops! Something went wrong brother :D");
            }
        }
    }

    public class UdpDataType
    {
        public string Protocol
        {
            get { return "UDP"; }
        }

        public string LocalAddress { get; set; }

        public int Pid { get; set; }

        public string ImageName { get; set; }

        public UdpDataType()
        {
        }

        public UdpDataType(UdpRow data)
        {
            if (data.LocalEndPoint != null)
            {
                LocalAddress = data.LocalEndPoint.ToString();
                Pid = data.ProcessId;
            }
            else
            {
                LocalAddress = "x:Null";
                Pid = 0;
            }

            //try to get ImageName
            ImageName = "Skipped";
            try
            {
                //Process process = Process.GetProcessById(data.ProcessId);
                //ImageName = process.MainModule.FileName;
            }
            catch (Exception)
            {
                Debug.WriteLine("Oops! Something went wrong brother :D");
            }
        }
    }

    public class ApplicationTCPActivityLogData
    {
        private readonly int _pid;
        private readonly string _imageName;
        private readonly string _workingdirectory;

        public List<TCPActivityLog> LogData { get; set; }

        public ApplicationTCPActivityLogData(int pid)
        {
            _pid = pid;
            _imageName = Helper.GetProcessProcessName(pid);
            _workingdirectory = Helper.GetProcessFullPath(pid);
        }

        public ApplicationTCPActivityLogData(int pid, IEnumerable<TCPActivityLog> logdata)
        {
            _pid = pid;
            LogData = new List<TCPActivityLog>(logdata);

            _imageName = Helper.GetProcessProcessName(pid);
            _workingdirectory = Helper.GetProcessFullPath(pid);
        }

        public int Pid
        {
            get { return _pid; }
        }

        public string ImageName
        {
            get { return _imageName; }
        }

        public string WorkingDiectory
        {
            get { return _workingdirectory; }
        }

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class ApplicationUDPActivityLogData
    {
        private readonly int _pid;
        private readonly string _imageName;
        private readonly string _workingdirectory;

        public List<UDPActivityLog> LogData { get; set; }

        public ApplicationUDPActivityLogData(int pid)
        {
            _pid = pid;
            _imageName = Helper.GetProcessProcessName(pid);
            _workingdirectory = Helper.GetProcessFullPath(pid);
        }

        public ApplicationUDPActivityLogData(int pid, IEnumerable<UDPActivityLog> logdata)
        {
            _pid = pid;
            LogData = new List<UDPActivityLog>(logdata);

            _imageName = Helper.GetProcessProcessName(pid);
            _workingdirectory = Helper.GetProcessFullPath(pid);
        }

        public int Pid
        {
            get { return _pid; }
        }

        public string ImageName
        {
            get { return _imageName; }
        }

        public string WorkingDiectory
        {
            get { return _workingdirectory; }
        }

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class TCPActivityLog
    {
        public IPEndPoint LocalAddress { get; set; }

        public IPEndPoint RemoteEndPoint { get; set; }

        public TCPActivityLog(IPEndPoint localaddress, IPEndPoint remoteaddress)
        {
            if (localaddress == null || remoteaddress == null)
                throw new InvalidDataException();
            LocalAddress = localaddress;
            RemoteEndPoint = remoteaddress;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var passedObject = obj as TCPActivityLog;
            if (passedObject == null)
                return false;
            if (passedObject.LocalAddress.ToString() == LocalAddress.ToString() &&
                passedObject.RemoteEndPoint.ToString() == RemoteEndPoint.ToString())
                return true;
            else
                return false;
        }
    }

    public class UDPActivityLog
    {
        public IPEndPoint LocalAddress { get; set; }

        public UDPActivityLog(IPEndPoint localaddress)
        {
            if (localaddress == null)
                throw new InvalidDataException();
            LocalAddress = localaddress;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var passedObject = obj as UDPActivityLog;
            if (passedObject == null)
                return false;
            if (passedObject.LocalAddress.ToString() == LocalAddress.ToString())
                return true;
            else
                return false;
        }
    }
}