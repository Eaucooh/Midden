using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ape_Network
{
    public class Download
    {
        public Image GetImageFromNetwork(string uri, string imageCookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            if (response.Headers.HasKeys() && null != response.Headers["Set-Cookie"])
            {
                imageCookie = response.Headers.Get("Set-Cookie");
            }
            return Image.FromStream(response.GetResponseStream());
        }

        public bool DownloadFile_ByWebClient(string from, string to)
        {
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(new Uri(from), to);
                client.Dispose();
                if (File.Exists(to))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
