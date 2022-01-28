using AddInView;
using System;
using System.AddIn;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plug_in_A
{
    [AddIn("Plug-in-A", Description = "插件A", Publisher = "Catrol", Version = "0.1.0")]
    public class Plug_in_A : TestAddInView
    {
        public override int ProcessNumber(int arg)
        {
            return arg * 100;
        }
    }
}
