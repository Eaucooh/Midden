using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Research.DynamicDataDisplay.Common;
using Color = System.Windows.Media.Color;

namespace netwatch.IpTable
{
    public class NetworkUsageDataCollection : RingArray<NetworkUsageData>
    {
        private const int TotalData = 60;
        public IntPtr CurrPointer = IntPtr.Zero;
        public IntPtr PrevPointer = IntPtr.Zero;

        public NetworkUsageDataCollection()
            : base(TotalData)
        {
        }

        public NetworkUsageDataCollection(int capacity)
            : base(capacity)
        {
        }

        public ImageSource GenerateBitmapSourceFromCollection()
        {
            return TrayImageGenerator.GenerateImage(this, Colors.Red, Colors.Blue);
        }

        public Int64 GetMaximumAtAll()
        {
            Int64 max = 0;
            foreach (NetworkUsageData collectionData in this)
            {
                if (collectionData.ByteReceived > max)
                    max = collectionData.ByteReceived;
                if (collectionData.ByteSent > max)
                    max = collectionData.ByteSent;
            }
            return max;
        }

        public Int64 GetMinimumAtAll()
        {
            long min1 = this.Select(item => item.ByteReceived).Concat(new[] {this[0].ByteReceived}).Min();
            long min2 = this.Select(item => item.ByteSent).Concat(new[] {this[0].ByteSent}).Min();

            if (min1 < min2)
                return min1;
            else
                return min2;
        }

        public Icon GenerateIconFromCollection()
        {
            try
            {
                Bitmap tempBitmap = TrayImageGenerator.ConvertBitmapSourceToBitmap(
                    TrayImageGenerator.GenerateImage(
                        this, Colors.Red, Colors.DeepSkyBlue
                        ));

                if (tempBitmap != null)
                {
                    IntPtr hicon = tempBitmap.GetHicon();
                    Icon bitmapIcon = Icon.FromHandle(hicon);

                    PrevPointer = CurrPointer;
                    CurrPointer = hicon;

                    return bitmapIcon;
                }
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.Message);
            }
            return null;
        }
    }

    public class NetworkUsageData
    {
        public NetworkUsageData(DateTime time, Int64 byteSent, Int64 byteReceived)
        {
            Time = time;
            ByteSent = byteSent;
            ByteReceived = byteReceived;
        }

        public DateTime Time { get; set; }

        public Int64 ByteSent { get; set; }

        public Int64 ByteReceived { get; set; }

        public Int64 TotalBytes
        {
            get { return ByteReceived + ByteSent; }
        }
    }

    public class TrayImageGenerator
    {
        public static BitmapSource GenerateImage(NetworkUsageDataCollection ncollection, Color sentColor,
                                                 Color receiveColor)
        {
            const int width = 16;
            const int height = 16;
            long receiveMaximums = ncollection.GetMaximumAtAll();

            PixelFormat pf = PixelFormats.Rgb24;
            const double dpi = 96;
            int rawStride = (width*pf.BitsPerPixel + 7)/8;
            var pixelData = new byte[rawStride*height];

            try
            {
                //Note : Initialize Palette

                Filler(height, ref pixelData, rawStride, Colors.Gray);

                for (int i = 0; i < width; i++)
                {
                    SetPixel(0, i, Colors.Black, ref pixelData, rawStride);
                    SetPixel(height - 1, i, Colors.Black, ref pixelData, rawStride);
                }
                for (int i = 0; i < height; i++)
                {
                    SetPixel(i, 0, Colors.Black, ref pixelData, rawStride);
                    SetPixel(i, width - 1, Colors.Black, ref pixelData, rawStride);
                }

                // End : Initialize Palette

                int counter = 1;

                for (int i = 0; i < 14; i++)
                {
                    ColumnFiller(ref pixelData, rawStride, counter, height - 2, ncollection[45 + i].ByteReceived,
                                 receiveMaximums, receiveColor);

                    ColumnFiller(ref pixelData, rawStride, counter, height - 2, ncollection[45 + i].ByteSent,
                                 receiveMaximums, sentColor);

                    counter++;
                }
            }
            catch (Exception)
            {
                Trace.WriteLine(String.Format("Something Went Wrong, Time : {0}",
                                              DateTime.Now.ToString(CultureInfo.InvariantCulture)));
            }

            BitmapSource returnValue = BitmapSource.Create(width, height, dpi, dpi, pf, null, pixelData, rawStride);

            return returnValue;
        }

        private static void SetPixel(int x, int y, Color c, ref byte[] buffer, int rawStride)
        {
            int xIndex = x*3;
            int yIndex = y*rawStride;
            buffer[xIndex + yIndex] = c.R;
            buffer[xIndex + yIndex + 1] = c.G;
            buffer[xIndex + yIndex + 2] = c.B;
        }

        private static void ColumnFiller(ref byte[] pixelData, int rawStride, int columnIndex, int columnHeight,
                                         double value, double maxValue, Color color)
        {
            if (value != 0 && maxValue != 0)
            {
                value = (value*8)/1000;
                maxValue = (maxValue*8)/1000;

                if (value > 0.1)
                {
                    double upper = ((value/maxValue))*(columnHeight);
                    upper = columnHeight - upper;
                    if (upper <= 0) upper = 0;
                    for (int i = columnHeight; i > upper; i--)
                    {
                        try
                        {
                            SetPixel(columnIndex, i, color, ref pixelData, rawStride);
                        }
                        catch
                        {
                            Trace.WriteLine("Failed to Colorize the Column!");

                            // DO Nothing!
                        }
                    }
                }
            }
        }

        private static void Filler(int height, ref byte[] pixelData, int rawStride, Color color)
        {
            for (int y = 0; y < height; y++)
            {
                int yIndex = y*rawStride;
                for (int x = 0; x < rawStride; x += 3)
                {
                    pixelData[x + yIndex] = color.R;
                    pixelData[x + yIndex + 1] = color.G;
                    pixelData[x + yIndex + 2] = color.B;
                }
            }
        }

        public static Bitmap ConvertBitmapSourceToBitmap(BitmapSource bitmapsource)
        {
            Bitmap bitmap;
            using (var stream = new MemoryStream())
            {
                var enc = new PngBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(stream);
                bitmap = new Bitmap(stream);
            }
            return bitmap;
        }
    }
}