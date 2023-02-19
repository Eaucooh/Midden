using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Library.BitmapImageHelper
{
    public class Converter
    {
        public static BitmapImage ByteArray2BitmapImage(byte[] byteArray)
        {
            BitmapImage bmp;

            try
            {
                bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(byteArray);
                bmp.EndInit();
                return bmp;
            }
            catch
            {
                bmp = null;
                return bmp;
            }
        }
    }
}
