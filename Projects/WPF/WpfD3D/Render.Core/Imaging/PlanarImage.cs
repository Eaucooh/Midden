using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Renderer.Core.Imaging
{
    /// <summary>
    /// Encapsulates planar image data.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("Width = {Width}, Height = {Height}, BitsPerPixel = {BitsPerPixel}, PixelType = {PixelType}")]
    public unsafe sealed class PlanarImage : ISerializable, IDisposable, ICloneable
    {
        private byte** m_pDataPtr = null;
        private Size m_size = Size.Empty;
        private int m_totalImageSize = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static PlanarImage Load(string fileName)
        {
            FileStream fs = File.OpenRead(fileName);
            PlanarImage image = Load(fs);
            fs.Close();
            return image;
        }

        /// <summary>
        /// Loads PlanarImage properties from provided stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static PlanarImage Load(Stream stream)
        {
            BinaryFormatter bf = new BinaryFormatter();
            PlanarImage yuv = (PlanarImage)bf.Deserialize(stream);
            return yuv;
        }

        /// <summary>
        /// Converts System.Drawing.Bitmap object into planar image
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="pixelType"></param>
        /// <returns></returns>
        public static PlanarImage Load(Bitmap bitmap, PixelAlignmentType pixelType)
        {
            VerifyIsSupported(bitmap.PixelFormat);
            return ConverterResizer.FromBitmap(bitmap, pixelType);
        }

        /// <summary>
        /// Constructor used for deserialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public PlanarImage(SerializationInfo info, StreamingContext context)
        {
            Width = info.GetInt32("Width");
            Height = info.GetInt32("Height");
            BitsPerPixel = info.GetInt32("BitsPerPixel");
            PixelType = (PixelAlignmentType)info.GetValue("PixelType", typeof(PixelAlignmentType));
            PlaneSizes = (int[])info.GetValue("PlaneSizes", typeof(int[]));
            Pitches = (int[])info.GetValue("Pitches", typeof(int[]));
            Lines = (int[])info.GetValue("Lines", typeof(int[]));
            byte[] pixelData = (byte[])info.GetValue("PixelData", typeof(byte[]));
            NumberOfPlanes = info.GetInt32("NumberOfPlanes");
            PixelData px = new PixelData(PlaneSizes, pixelData);
            Planes = px.Load();
        }

        /// <summary>
        /// Initializes new instance of planar image with no pixel data
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pixelType"></param>
        public PlanarImage(int width, int height, PixelAlignmentType pixelType)
        {
            Width = width;
            Height = height;
            PixelType = pixelType;
            Init();

            Planes = new IntPtr[PlaneSizes.Length];
            for (int i = 0; i < PlaneSizes.Length; i++)
            {
                Planes[i] = Marshal.AllocHGlobal(PlaneSizes[i] * sizeof(byte));
            }
        }

        /// <summary>
        /// Initializes new instance of planar image with pixel data
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pixelType"></param>
        /// <param name="planes"></param>
        public PlanarImage(int width, int height, PixelAlignmentType pixelType, IntPtr[] planes)
        {
            Width = width;
            Height = height;
            PixelType = pixelType;
            Init();

            Planes = new IntPtr[PlaneSizes.Length];
            for (int i = 0; i < PlaneSizes.Length; i++)
            {
                Planes[i] = Marshal.AllocHGlobal(PlaneSizes[i] * sizeof(byte));
                RtlMoveMemory(Planes[i], planes[i], PlaneSizes[i]);
            }

            if (this.PixelType == PixelAlignmentType.YV12)
            {
                SwapUVPlanes();
            }
        }

        /// <summary>
        /// Initializes new instance of planar image from pointer to flat memory buffer containing all pixel planes
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pixelType"></param>
        /// <param name="pixelData"></param>
        public PlanarImage(int width, int height, PixelAlignmentType pixelType, IntPtr pixelData, int pixelDataSize)
            : this(width, height, pixelType)
        {
            if (pixelDataSize < TotalImageLength)
            {
                throw new InvalidOperationException("Insufficient memory buffer size.");
            }

            RtlMoveMemory(Planes[0], pixelData, PlaneSizes[0]);
            if (NumberOfPlanes > 1)
            {
                RtlMoveMemory(Planes[1], pixelData + PlaneSizes[0], PlaneSizes[1]);
                if (NumberOfPlanes > 2)
                {
                    RtlMoveMemory(Planes[2], pixelData + PlaneSizes[0] + PlaneSizes[1], PlaneSizes[2]);
                }
            }
        }

        /// <summary>
        /// Swaps Cb and Cr planes (usually needed for YV12 format)
        /// </summary>
        public void SwapUVPlanes()
        {
            IntPtr temp = this.Planes[1];
            this.Planes[1] = this.Planes[2];
            this.Planes[2] = temp;
        }

        private void Init()
        {
            switch (PixelType)
            {
                case PixelAlignmentType.Y800:
                    BitsPerPixel = 8;
                    NumberOfPlanes = 1;
                    Pitches = new int[1] { Width };
                    Lines = new int[1] { Height };
                    PlaneSizes = new int[1] { Width * Height };
                    break;

                case PixelAlignmentType.Y16:
                    BitsPerPixel = 16;
                    NumberOfPlanes = 1;
                    Pitches = new int[1] { Width * 2};
                    Lines = new int[1] { Height };
                    PlaneSizes = new int[1] { Width * Height * 2};

                    break;
                case PixelAlignmentType.YUV:
                    BitsPerPixel = 24;
                    NumberOfPlanes = 3;
                    Pitches = new int[3] { Width, Width, Width };
                    Lines = new int[3] { Height, Height, Height };
                    PlaneSizes = new int[3] { Width * Height, Width * Height, Width * Height };

                    break;
                case PixelAlignmentType.YUY2:
                case PixelAlignmentType.UYVY:
                    BitsPerPixel = 16;
                    NumberOfPlanes = 1;
                    Pitches = new int[1] { Width * 2 };
                    Lines = new int[1] { Height };
                    PlaneSizes = new int[1] { Width * Height * 2 };

                    break;
                case PixelAlignmentType.YV12:
                case PixelAlignmentType.I420:
                    BitsPerPixel = 12;
                    NumberOfPlanes = 3;
                    Pitches = new int[3] { Width, Width / 2, Width / 2 };
                    Lines = new int[3] { Height, Height / 2, Height / 2 };
                    PlaneSizes = new int[3] { Width * Height, Width * Height / 4, Width * Height / 4 };

                    break;
                case PixelAlignmentType.NV12:
                case PixelAlignmentType.NV21:
                    BitsPerPixel = 12;
                    NumberOfPlanes = 2;
                    Pitches = new int[2] { Width, Width };
                    Lines = new int[2] { Height, Height / 2 };
                    PlaneSizes = new int[2] { Width * Height, Width * Height / 2 };

                    break;
                case PixelAlignmentType.Y411:
                    BitsPerPixel = 12;
                    NumberOfPlanes = 3;
                    Pitches = new int[3] { Width, Width / 4, Width / 4 };
                    Lines = new int[3] { Height, Height, Height };
                    PlaneSizes = new int[3] { Pitches[0] * Lines[0], Pitches[1] * Lines[1], Pitches[2] * Lines[2] };
                    break;

                case PixelAlignmentType.Y410:
                    BitsPerPixel = 9;
                    NumberOfPlanes = 3;
                    Pitches = new int[3] { Width, Width / 4, Width / 4 };
                    Lines = new int[3] { Height, Height / 4, Height / 4 };
                    PlaneSizes = new int[3] { Pitches[0] * Lines[0], Pitches[1] * Lines[1], Pitches[2] * Lines[2] };
                    break;
                
                case PixelAlignmentType.RGB24:
                    BitsPerPixel = 24;
                    NumberOfPlanes = 1;
                    Pitches = new int[1] { Width * 3 };
                    Lines = new int[1] { Height };
                    PlaneSizes = new int[1] { Pitches[0] * Lines[0] };
                    break;

                case PixelAlignmentType.BGRA:
                    BitsPerPixel = 32;
                    NumberOfPlanes = 1;
                    Pitches = new int[1] { Width * 4 };
                    Lines = new int[1] { Height };
                    PlaneSizes = new int[1] { Pitches[0] * Lines[0] };
                    break;

                case PixelAlignmentType.ABGR:
                    BitsPerPixel = 32;
                    NumberOfPlanes = 1;
                    Pitches = new int[1] { Width * 4 };
                    Lines = new int[1] { Height };
                    PlaneSizes = new int[1] { Pitches[0] * Lines[0] };
                    break;

                default:
                    throw new InvalidOperationException("Unknown pixel alignment type " + PixelType);
            }
        }

        private void VerifyPlanarFormat()
        {
            if (!IsPlanar)
            {
                throw new InvalidOperationException("Operation is valid for planar formats only !");
            }
        }

        /// <summary>
        /// Convert planar image to .NET Bitmap object
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public Bitmap ToBitmap(PixelFormat format)
        {
            VerifyIsSupported(format);
            return ConverterResizer.ToBitmap(this, format);
        }

        /// <summary>
        /// Converts planar image to another pixel alignment type
        /// </summary>
        /// <param name="newPixelType"></param>
        /// <returns></returns>
        public PlanarImage Convert(PixelAlignmentType newPixelType)
        {
            PlanarImage result = new PlanarImage(this.Width, this.Height, newPixelType);
            ConverterResizer.Apply(this, result);
            return result;
        }

        /// <summary>
        /// Resizes planar image
        /// </summary>
        /// <param name="newSize"></param>
        /// <returns></returns>
        public PlanarImage Resize(Size newSize)
        {
            PlanarImage result = new PlanarImage(newSize.Width, newSize.Height, this.PixelType);
            ConverterResizer.Apply(this, result);
            return result;
        }

        /// <summary>
        /// Performs both conversion and resize in a single operation
        /// </summary>
        /// <param name="newPixelType"></param>
        /// <param name="newSize"></param>
        /// <returns></returns>
        public PlanarImage ConvertAndResize(PixelAlignmentType newPixelType, Size newSize)
        {
            PlanarImage result = new PlanarImage(newSize.Width, newSize.Height, newPixelType);
            ConverterResizer.Apply(this, result);
            return result;
        }

        /// <summary>
        /// Creates a new instance of planar image by cropping current instance
        /// </summary>
        /// <param name="cropArea"></param>
        /// <returns></returns>
        public PlanarImage Crop(Rectangle cropArea)
        {
            if (cropArea.X + cropArea.Width > this.Width || cropArea.Y + cropArea.Height > this.Height)
            {
                throw new InvalidOperationException("Cropping size bigger than the image size");
            }

            return Cropper.Crop(this, cropArea);
        }

        /// <summary>
        /// Gets the width of the bitmap
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the height of the bitmap
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets number of bits used for a pixel according to ChromaType
        /// </summary>
        public int BitsPerPixel { get; private set; }

        /// <summary>
        /// Gets the pixel type
        /// </summary>
        public PixelAlignmentType PixelType { get; private set; }

        /// <summary>
        /// Gets array of pixel plane's sizes
        /// </summary>
        public int[] PlaneSizes { get; private set; }

        /// <summary>
        /// Gets array of pitch size per pixel plane
        /// </summary>
        public int[] Pitches { get; private set; }

        /// <summary>
        /// Gets array of scan lines (height) per pixel plane
        /// </summary>
        public int[] Lines { get; private set; }

        /// <summary>
        /// Gets pointer array to the pixel planes on the native heap 
        /// </summary>
        public IntPtr[] Planes { get; private set; }

        /// <summary>
        /// Gets number of pixel planes
        /// </summary>
        public int NumberOfPlanes { get; private set; }

        /// <summary>
        /// Gets image size
        /// </summary>
        public Size Size 
        { 
            get
            {
                if (m_size == Size.Empty)
                {
                    m_size = new Size(Width, Height);
                }
                return m_size;
            }
        }

        /// <summary>
        /// Get total image length in bytes
        /// </summary>
        public int TotalImageLength
        {
            get
            {
                if (m_totalImageSize == 0)
                {
                    Array.ForEach(PlaneSizes, p => m_totalImageSize += p);
                }
                return m_totalImageSize;
            }
        }

        private void Dispose(bool disposing)
        {
            for (int i = 0; i < Planes.Length; i++)
            {
                if (Planes[i] != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(Planes[i]);
                    Planes[i] = IntPtr.Zero;
                }
            }

            if (m_pDataPtr != null)
            {
                Marshal.FreeHGlobal((IntPtr)m_pDataPtr);
            }
        }

        ~PlanarImage()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposes unmanaged resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs deep cloning of this instance
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, this);
            ms.Position = 0;
            return bf.Deserialize(ms);
        }

        /// <summary>
        /// Used for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Width", Width);
            info.AddValue("Height", Height);
            info.AddValue("BitsPerPixel", BitsPerPixel);
            info.AddValue("PixelType", PixelType);
            info.AddValue("PlaneSizes", PlaneSizes);
            info.AddValue("Pitches", Pitches);
            info.AddValue("Lines", Lines);
            info.AddValue("NumberOfPlanes", NumberOfPlanes);
            PixelData px = new PixelData(this.PlaneSizes, this.Planes);
            info.AddValue("PixelData", px.Save());
        }


        /// <summary>
        /// Determines whether the bitmap is of planar type
        /// </summary>
        public bool IsPlanar
        {
            get
            {
                return NumberOfPlanes > 1;
            }
        }

        /// <summary>
        /// Serializes current instance into provided stream
        /// </summary>
        /// <param name="stream"></param>
        public void Save(Stream stream)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, this);
        }

        public void Save(string fileName)
        {
            using (FileStream fs = File.Create(fileName))
            { 
                Save(fs);
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern void RtlMoveMemory(IntPtr dest, IntPtr source, int size);

        private static void VerifyIsSupported(PixelFormat format)
        {
            if (format != PixelFormat.Format24bppRgb &&
                format != PixelFormat.Format32bppArgb &&
                format != PixelFormat.Format8bppIndexed)
            {
                throw new ArgumentException("Unsupported pixel format " + format.ToString(), "PixelFormat");
            }
        }

        internal byte** PixelDataPointer
        {
            get
            {
                if (m_pDataPtr == null)
                {
                    m_pDataPtr = (byte**)Marshal.AllocHGlobal(sizeof(byte*) * 4).ToPointer();
                    for (int i = 0; i < this.Planes.Length; i++)
                    {
                        m_pDataPtr[i] = (byte*)this.Planes[i].ToPointer();
                    }
                }

                return m_pDataPtr;
            }
        }

        private class PixelData
        {
            Dictionary<int, byte[]> m_buffers = new Dictionary<int, byte[]>();

            public PixelData(int[] planeSizes, IntPtr[] planes)
            {
                for (int i = 0; i < planeSizes.Length; i++)
                {
                    m_buffers[i] = new byte[planeSizes[i]];
                    Marshal.Copy(planes[i], m_buffers[i], 0, planeSizes[i]);
                }
            }

            public PixelData(int[] planeSizes, byte[] buffer)
            {
                int index = 0;
                for (int i = 0; i < planeSizes.Length; i++)
                {
                    m_buffers[i] = new byte[planeSizes[i]];
                    Array.Copy(buffer, index, m_buffers[i], 0, planeSizes[i]);
                    index += planeSizes[i];
                }
            }

            public byte[] Save()
            {
                MemoryStream stream = new MemoryStream();
                foreach (var plane in m_buffers.Values)
                {
                    stream.Write(plane, 0, plane.Length);
                }

                return stream.GetBuffer();
            }

            public IntPtr[] Load()
            {
                IntPtr[] planes = new IntPtr[m_buffers.Count];
                for (int i = 0; i < planes.Length; i++)
                {
                    planes[i] = Marshal.AllocHGlobal(m_buffers[i].Length);
                    Marshal.Copy(m_buffers[i], 0, planes[i], m_buffers[i].Length);
                }

                return planes;
            }
        }
    }
}
