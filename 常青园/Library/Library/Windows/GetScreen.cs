using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library.Windows
{
    public class GetScreen
    {
        public Bitmap GetScreenSnapshot()
        {
            try
            {
                Rectangle rc = SystemInformation.VirtualScreen;
                var bitmap = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics memoryGrahics = Graphics.FromImage(bitmap))
                {
                    memoryGrahics.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);
                }
                return bitmap;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
