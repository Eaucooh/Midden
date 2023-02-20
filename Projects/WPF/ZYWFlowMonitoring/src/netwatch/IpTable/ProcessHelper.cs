using System.Collections.Generic;

namespace netwatch.IpTable
{
    public class ProcessHelper
    {
        private readonly Dictionary<int, ProcessInfo> _processList;

        public ProcessHelper()
        {
            _processList = new Dictionary<int, ProcessInfo>();
        }

        public void AddKey(ProcessInfo processName, int processid)
        {
            _processList.Add(processid, processName);
        }

        public ProcessInfo PassMeDataofThisPid(int processid)
        {
            if (_processList.ContainsKey(processid))
                return _processList[processid];
            else
            {
                //Adding new Key to Db
                var requestedData = new ProcessInfo(processid);
                _processList.Add(processid, requestedData);
                return requestedData;
            }
        }
    }
}