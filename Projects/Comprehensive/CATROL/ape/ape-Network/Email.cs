using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_Network
{
    public class Email
    {
        public string ForeString { get; set; }
        public string BackString { get; set; }
        public string Domain { get; set; }

        public Email()
        {

        }

        public Email StringToEmail(string mail)
        {
            try
            {
                return new Email()
                {
                    ForeString = mail.Substring(0, mail.IndexOf('@') - 1),
                    BackString = mail.Substring(mail.IndexOf('@') + 1)
                };
            }
            catch
            {
                return new Email()
                {
                    ForeString = "ErrorTransition",
                    BackString = "Catrol.com"
                };
            }
        }

        public string ToString(Email email)
        {
            return $"{ForeString}@{BackString}";
        }
    }
}