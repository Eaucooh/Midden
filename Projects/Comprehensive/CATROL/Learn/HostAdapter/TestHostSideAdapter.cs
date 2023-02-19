using AddInContract;
using HostView;
using System;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostSideAdapter
{
    [HostAdapter]
    public class TestHostSideAdapter : TestHostView
    {
        private ITestContract _contract;
        private ContractHandle contractHandle;
        public TestHostSideAdapter(ITestContract contract)
        {
            _contract = contract;
            contractHandle = new ContractHandle(_contract);
        }
        public override int ProcessNumber(int arg)
        {
            return _contract.ProcessNumber(arg);
        }
    }
}
