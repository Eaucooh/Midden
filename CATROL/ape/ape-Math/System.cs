using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ape_Math
{
    public class System
    {
        public byte DecToBin(double Dec)
        {
            byte bin = 000000000;
            bool IsKeeping = true;
            StringBuilder Array_bin = new StringBuilder();
            double dec = Dec;
            do
            {
                double shang = dec / 2;
                double yu = dec % 2;
                dec = shang;
                if (shang >= 1)
                {
                    Array_bin.Append(yu);
                }
                else
                {
                    IsKeeping = false;
                }
            } while (IsKeeping);
            string[] Array_LastBin = new string[Array_bin.Length];
            int length = Array_bin.Length;
            for (int i = 0; i < Array_LastBin.Length; i++)
            {
                Array_LastBin[i] = Array_bin[length - 1].ToString();
                length--;
            }
            string oops = "";
            for (int i = 0; i < Array_LastBin.Length; i++)
            {
                oops += Array_LastBin[i];
            }
            bin = Convert.ToByte(oops, 2);
            return bin;
        }
    }
}
