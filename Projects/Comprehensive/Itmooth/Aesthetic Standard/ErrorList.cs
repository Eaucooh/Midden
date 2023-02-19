using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aesthetic_Standard
{
    public class ErrorList
    {
        public string ReturnErrorCode(Errors errorName)
        {
            switch (errorName)
            {
                case Errors.MessageBox_Icon_Lost:
                    return "0x110000";
            }
            return null;
        }

        public enum Errors
        { 
            MessageBox_Icon_Lost
        }
    }
}
