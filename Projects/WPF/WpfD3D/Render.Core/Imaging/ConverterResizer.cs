using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Renderer.Core.Imaging
{
    public unsafe sealed class ConverterResizer : IDisposable
    {
        Size m_sourceSize, m_targetSize;
        PixelAlignmentType m_sourceType, m_targetType;
        IntPtr m_context = IntPtr.Zero;
        static Dictionary<PixelAlignmentType, SwScale.SwsPixelFormat> m_pixelTypeMapper = new Dictionary<PixelAlignmentType, SwScale.SwsPixelFormat>();
        static Dictionary<PixelFormat, SwScale.SwsPixelFormat> m_rgbMapper = new Dictionary<PixelFormat, SwScale.SwsPixelFormat>();
        static byte** pInput;

        static ConverterResizer()
        {
            m_pixelTypeMapper.Add(PixelAlignmentType.I420, SwScale.SwsPixelFormat.PIX_FMT_YUV420P);
            m_pixelTypeMapper.Add(PixelAlignmentType.Y800, SwScale.SwsPixelFormat.PIX_FMT_GRAY8);
            m_pixelTypeMapper.Add(PixelAlignmentType.NV12, SwScale.SwsPixelFormat.PIX_FMT_NV12);
            m_pixelTypeMapper.Add(PixelAlignmentType.NV21, SwScale.SwsPixelFormat.PIX_FMT_NV21);
            m_pixelTypeMapper.Add(PixelAlignmentType.UYVY, SwScale.SwsPixelFormat.PIX_FMT_UYVY422);
            m_pixelTypeMapper.Add(PixelAlignmentType.Y410, SwScale.SwsPixelFormat.PIX_FMT_YUV410P);
            m_pixelTypeMapper.Add(PixelAlignmentType.Y411, SwScale.SwsPixelFormat.PIX_FMT_YUV411P);
            m_pixelTypeMapper.Add(PixelAlignmentType.YUV, SwScale.SwsPixelFormat.PIX_FMT_YUV444P);
            m_pixelTypeMapper.Add(PixelAlignmentType.YUY2, SwScale.SwsPixelFormat.PIX_FMT_YUYV422);
            m_pixelTypeMapper.Add(PixelAlignmentType.YV12, SwScale.SwsPixelFormat.PIX_FMT_YUV420P);
            m_pixelTypeMapper.Add(PixelAlignmentType.Y16, SwScale.SwsPixelFormat.PIX_FMT_GRAY16BE);
            m_pixelTypeMapper.Add(PixelAlignmentType.RGB24, SwScale.SwsPixelFormat.PIX_FMT_BGR24);
            m_pixelTypeMapper.Add(PixelAlignmentType.BGRA, SwScale.SwsPixelFormat.PIX_FMT_RGBA);
            m_pixelTypeMapper.Add(PixelAlignmentType.ABGR, SwScale.SwsPixelFormat.PIX_FMT_ARGB);

            m_rgbMapper.Add(PixelFormat.Format8bppIndexed, SwScale.SwsPixelFormat.PIX_FMT_GRAY8);
            m_rgbMapper.Add(PixelFormat.Format32bppArgb, SwScale.SwsPixelFormat.PIX_FMT_BGRA);
            m_rgbMapper.Add(PixelFormat.Format24bppRgb, SwScale.SwsPixelFormat.PIX_FMT_BGR24);

            pInput = (byte**)Marshal.AllocHGlobal(sizeof(byte*) * 4).ToPointer();
            for (int i = 0; i < 4; i++)
            {
                pInput[i] = null;
            }
        }

        public ConverterResizer(Size sourceSize, PixelAlignmentType sourceType, Size targetSize, PixelAlignmentType targetType)
        {
            if (SwScale.sws_isSupportedInput(m_pixelTypeMapper[m_sourceType]) == 0)
            {
                throw new InvalidOperationException("Unsupported source type " + sourceType);
            }

            if (SwScale.sws_isSupportedOutput(m_pixelTypeMapper[targetType]) == 0)
            {
                throw new InvalidOperationException("Unsupported target type " + targetType);
            }
                 
            m_sourceSize = sourceSize;
            m_targetSize = targetSize;
            m_sourceType = sourceType;
            m_targetType = targetType;

            m_context = SwScale.sws_getContext(m_sourceSize.Width, m_sourceSize.Height, m_pixelTypeMapper[m_sourceType],
                                            m_targetSize.Width, m_targetSize.Height, m_pixelTypeMapper[m_targetType],
                                            SwScale.ConvertionFlags.SWS_BICUBIC, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            if (m_context == IntPtr.Zero)
            {
                throw new InvalidOperationException("Context initialization failed. Supplied arguments may be invalid");
            }
        }

        public PlanarImage DoTheWork(PlanarImage source)
        {
            PlanarImage target = new PlanarImage(m_targetSize.Width, m_targetSize.Height, m_targetType);
            int result = SwScale.sws_scale(m_context, source.PixelDataPointer, source.Pitches, 0, source.Height, target.PixelDataPointer, target.Pitches);
            if (result != target.Height)
            {
                throw new InvalidOperationException();
            }

            return target;
        }

        public static void Apply(PlanarImage source, PlanarImage target)
        {
            IntPtr context = SwScale.sws_getContext(source.Width, source.Height, m_pixelTypeMapper[source.PixelType],
                                            target.Width, target.Height, m_pixelTypeMapper[target.PixelType],
                                            SwScale.ConvertionFlags.SWS_BICUBIC, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            int result = SwScale.sws_scale(context, source.PixelDataPointer, source.Pitches, 0, source.Height, target.PixelDataPointer, target.Pitches);
            if (result != target.Height)
            {
                throw new InvalidOperationException();
            }

            SwScale.sws_freeContext(context);
        }

        public static Bitmap ToBitmap(PlanarImage source, PixelFormat format, ColorSpace colorspace = ColorSpace.DEFAULT)
        {
            IntPtr context = SwScale.sws_getContext(source.Width, source.Height, m_pixelTypeMapper[source.PixelType],
                                             source.Width, source.Height, m_rgbMapper[format],
                                             SwScale.ConvertionFlags.SWS_BICUBIC, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);


            int* pCoef = SwScale.sws_getCoefficients(colorspace);
            int* inv_table;
            int* table;
            int srcRange, dstRange, brightness, contrast, saturation;

            int result = SwScale.sws_getColorspaceDetails(context, out inv_table, out srcRange, out table, out dstRange, out brightness, out contrast, out saturation);
            if (result != -1)
            {
                result = SwScale.sws_setColorspaceDetails(context, pCoef, srcRange, pCoef, dstRange, brightness, contrast, saturation);
            }

            Bitmap bmp = new Bitmap(source.Width, source.Height, format);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, format);

            unsafe
            {
                pInput[0] = (byte*)data.Scan0.ToPointer();

                result = SwScale.sws_scale(context, source.PixelDataPointer, source.Pitches, 0, source.Height, pInput, new int[] { data.Stride, 0, 0, 0 });
                if (result != source.Height)
                {
                    throw new InvalidOperationException();
                }
            }

            bmp.UnlockBits(data);
            if (bmp.Palette != null && bmp.Palette.Entries != null && bmp.Palette.Entries.Length > 0)
            {
                ColorPalette cp = bmp.Palette;
                for (int i = 0; i < cp.Entries.Length; i++)
                {
                    cp.Entries[i] = Color.FromArgb(i, i, i);
                }
                bmp.Palette = cp;
            }

            SwScale.sws_freeContext(context);
            return bmp;
        }

        public static PlanarImage FromBitmap(Bitmap source, PixelAlignmentType format, ColorSpace colorspace = ColorSpace.DEFAULT)
        {
            IntPtr context = SwScale.sws_getContext(source.Width, source.Height, m_rgbMapper[source.PixelFormat],
                                             source.Width, source.Height, m_pixelTypeMapper[format],
                                             SwScale.ConvertionFlags.SWS_BICUBIC, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            int* pCoef = SwScale.sws_getCoefficients(colorspace);
            int* inv_table;
            int* table;
            int srcRange, dstRange, brightness, contrast, saturation;

            int result = SwScale.sws_getColorspaceDetails(context, out inv_table, out srcRange, out table, out dstRange, out brightness, out contrast, out saturation);
            if (result != -1)
            {
                result = SwScale.sws_setColorspaceDetails(context, pCoef, srcRange, table, dstRange, brightness, contrast, saturation);
            }

            PlanarImage yuv = new PlanarImage(source.Width, source.Height, format);
            BitmapData data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, source.PixelFormat);

            unsafe
            {
                pInput[0] = (byte*)data.Scan0.ToPointer();
                result = SwScale.sws_scale(context, pInput, new int[] { data.Stride, 0, 0, 0 }, 0, source.Height, yuv.PixelDataPointer, yuv.Pitches);
                if (result != yuv.Height)
                {
                    throw new InvalidOperationException();
                }
            }

            source.UnlockBits(data);
            SwScale.sws_freeContext(context);
            return yuv;
        }

        public void Dispose()
        {
            SwScale.sws_freeContext(m_context);
            Marshal.FreeHGlobal(new IntPtr(pInput));               
        }
    }
}
