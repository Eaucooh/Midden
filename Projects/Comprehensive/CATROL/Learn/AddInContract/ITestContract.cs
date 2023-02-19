using System;
using System.AddIn.Contract;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddInContract
{
    [AddInContract]
    public interface ITestContract : IContract
    {
        int ProcessNumber(int arg);
    }
}
