using AddInContract;
using AddInView;
using System;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddInSideAdapter
{
    [AddInAdapter]
    public class TestAddInSideAdapter : ContractBase, ITestContract
    {
        private TestAddInView _view;

        public TestAddInSideAdapter(TestAddInView view)
        {
            _view = view;
        }

        public int ProcessNumber(int arg)
        {
            return _view.ProcessNumber(arg);
        }
    }
}
