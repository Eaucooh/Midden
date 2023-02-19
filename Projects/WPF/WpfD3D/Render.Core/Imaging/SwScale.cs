using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace Renderer.Core
{
    [SuppressUnmanagedCodeSecurity]
    internal static class SwScale
    {
        const string libraryName = "swscale-2.dll";
        
        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int swscale_version();

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* sws_getCoefficients(ColorSpace colorspace);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sws_isSupportedInput(SwsPixelFormat pix_fmt);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sws_isSupportedOutput(SwsPixelFormat pix_fmt);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr sws_alloc_context();

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sws_init_context(IntPtr sws_context, IntPtr srcFilter, IntPtr dstFilter);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void sws_freeContext(IntPtr swsContext);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr sws_getContext(int srcW, int srcH, SwsPixelFormat srcFormat,
                                            int dstW, int dstH, SwsPixelFormat dstFormat,
                                            SwScale.ConvertionFlags flags, IntPtr srcFilter, IntPtr dstFilter, IntPtr param);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr sws_getCachedContext(IntPtr context, int srcW, int srcH, SwsPixelFormat srcFormat,
                                                  int dstW, int dstH, SwsPixelFormat dstFormat,
                                                  SwScale.ConvertionFlags flags, IntPtr srcFilter, IntPtr dstFilter, IntPtr param);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int sws_scale(IntPtr context, byte** srcSlice, int[] srcStride,
                                           int srcSliceY, int srcSliceH, byte** dst, int[] dstStride);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int sws_setColorspaceDetails(IntPtr c, int* inv_table,
                             int srcRange, int* table, int dstRange,
                             int brightness, int contrast, int saturation);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int sws_getColorspaceDetails(IntPtr c, out int* inv_table,
                             out int srcRange, out int* table, out int dstRange,
                             out int brightness, out int contrast, out int saturation);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern SwsVector sws_allocVec(int length);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern SwsVector sws_getGaussianVec(double variance, double quality);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern SwsVector sws_getConstVec(double c, int length);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern SwsVector sws_getIdentityVec();

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void sws_scaleVec(SwsVector a, double scalar);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void sws_normalizeVec(SwsVector a, double height);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void sws_convVec(SwsVector a, SwsVector b);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void sws_addVec(SwsVector a, SwsVector b);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void sws_subVec(SwsVector a, SwsVector b);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void sws_shiftVec(SwsVector a, int shift);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern SwsVector sws_cloneVec(SwsVector* a);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void sws_freeVec(SwsVector a);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern SwsFilter sws_getDefaultFilter(float lumaGBlur, float chromaGBlur,
                                        float lumaSharpen, float chromaSharpen,
                                        float chromaHShift, float chromaVShift,
                                        int verbose);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void sws_freeFilter(SwsFilter filter);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void sws_convertPalette8ToPacked32(byte* src, byte* dst, int num_pixels, byte* palette);

        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void sws_convertPalette8ToPacked24(byte* src, byte* dst, int num_pixels, byte* palette);

        [StructLayout(LayoutKind.Sequential)]
        public struct SwsVector
        {
            IntPtr coeff;              ///< pointer to the list of coefficients
            int length;                 ///< number of coefficients in the vector
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SwsFilter
        {
            SwsVector lumH;
            SwsVector lumV;
            SwsVector chrH;
            SwsVector chrV;
        }

        [Flags]
        public enum ConvertionFlags : int
        {
            SWS_FAST_BILINEAR = 1,
            SWS_BILINEAR = 2,
            SWS_BICUBIC = 4,
            SWS_X = 8,
            SWS_POINT = 0x10,
            SWS_AREA = 0x20,
            SWS_BICUBLIN = 0x40,
            SWS_GAUSS = 0x80,
            SWS_SINC = 0x100,
            SWS_LANCZOS = 0x200,
            SWS_SPLINE = 0x400
        }

        public enum SwsPixelFormat
        {
            PIX_FMT_NONE = -1,
            /// <summary>
            /// planar YUV 4:2:0, 12bpp, (1 Cr & Cb sample per 2x2 Y samples)
            /// </summary>
            PIX_FMT_YUV420P,
            /// <summary>
            /// packed YUV 4:2:2, 16bpp, Y0 Cb Y1 Cr
            /// </summary>
            PIX_FMT_YUYV422,
            /// <summary>
            /// packed RGB 8:8:8, 24bpp, RGBRGB...
            /// </summary>
            PIX_FMT_RGB24, 
            /// <summary>
            /// packed RGB 8:8:8, 24bpp, BGRBGR...
            /// </summary>
            PIX_FMT_BGR24,     
            /// <summary>
            /// planar YUV 4:2:2, 16bpp, (1 Cr & Cb sample per 2x1 Y samples)
            /// </summary>
            PIX_FMT_YUV422P,
            /// <summary>
            /// planar YUV 4:4:4, 24bpp, (1 Cr & Cb sample per 1x1 Y samples)
            /// </summary>
            PIX_FMT_YUV444P,   
            /// <summary>
            /// planar YUV 4:1:0,  9bpp, (1 Cr & Cb sample per 4x4 Y samples)
            /// </summary>
            PIX_FMT_YUV410P,   
            /// <summary>
            /// planar YUV 4:1:1, 12bpp, (1 Cr & Cb sample per 4x1 Y samples)
            /// </summary>
            PIX_FMT_YUV411P,  
            /// <summary>
            /// Y, 8bpp
            /// </summary>
            PIX_FMT_GRAY8,     
            /// <summary>
            /// Y, 1bpp, 0 is white, 1 is black, in each byte pixels are ordered from the msb to the lsb
            /// </summary>
            PIX_FMT_MONOWHITE, 
            /// <summary>
            /// Y, 1bpp, 0 is black, 1 is white, in each byte pixels are ordered from the msb to the lsb
            /// </summary>
            PIX_FMT_MONOBLACK,         
            PIX_FMT_PAL8,      ///< 8 bit with PIX_FMT_RGB32 palette
            PIX_FMT_YUVJ420P,  ///< planar YUV 4:2:0, 12bpp, full scale (JPEG), deprecated in favor of PIX_FMT_YUV420P and setting color_range
            PIX_FMT_YUVJ422P,  ///< planar YUV 4:2:2, 16bpp, full scale (JPEG), deprecated in favor of PIX_FMT_YUV422P and setting color_range
            PIX_FMT_YUVJ444P,  ///< planar YUV 4:4:4, 24bpp, full scale (JPEG), deprecated in favor of PIX_FMT_YUV444P and setting color_range
            PIX_FMT_XVMC_MPEG2_MC,///< XVideo Motion Acceleration via common packet passing
            PIX_FMT_XVMC_MPEG2_IDCT,
            /// <summary>
            /// packed YUV 4:2:2, 16bpp, Cb Y0 Cr Y1
            /// </summary>
            PIX_FMT_UYVY422,  
            /// <summary>
            /// packed YUV 4:1:1, 12bpp, Cb Y0 Y1 Cr Y2 Y3
            /// </summary>
            PIX_FMT_UYYVYY411, 
            /// <summary>
            /// packed RGB 3:3:2,  8bpp, (msb)2B 3G 3R(lsb)
            /// </summary>
            PIX_FMT_BGR8,     
            /// <summary>
            /// packed RGB 1:2:1 bitstream,  4bpp, (msb)1B 2G 1R(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits
            /// </summary>
            PIX_FMT_BGR4,      
            /// <summary>
            /// packed RGB 1:2:1,  8bpp, (msb)1B 2G 1R(lsb)
            /// </summary>
            PIX_FMT_BGR4_BYTE, 
            /// <summary>
            /// packed RGB 3:3:2,  8bpp, (msb)2R 3G 3B(lsb)
            /// </summary>
            PIX_FMT_RGB8,     
            /// <summary>
            /// packed RGB 1:2:1 bitstream,  4bpp, (msb)1R 2G 1B(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits
            /// </summary>
            PIX_FMT_RGB4,      
            /// <summary>
            /// packed RGB 1:2:1,  8bpp, (msb)1R 2G 1B(lsb)
            /// </summary>
            PIX_FMT_RGB4_BYTE, 
            /// <summary>
            /// planar YUV 4:2:0, 12bpp, 1 plane for Y and 1 plane for the UV components, which are interleaved (first byte U and the following byte V)
            /// </summary>
            PIX_FMT_NV12,      
            /// <summary>
            /// as above, but U and V bytes are swapped
            /// </summary>
            PIX_FMT_NV21,     
            /// <summary>
            /// packed ARGB 8:8:8:8, 32bpp, ARGBARGB...
            /// </summary>
            PIX_FMT_ARGB,     
            /// <summary>
            /// packed RGBA 8:8:8:8, 32bpp, RGBARGBA...
            /// </summary>
            PIX_FMT_RGBA,     
            /// <summary>
            /// packed ABGR 8:8:8:8, 32bpp, ABGRABGR...
            /// </summary>
            PIX_FMT_ABGR,      
            /// <summary>
            /// packed BGRA 8:8:8:8, 32bpp, BGRABGRA...
            /// </summary>
            PIX_FMT_BGRA,

            PIX_FMT_GRAY16BE,  ///<        Y        , 16bpp, big-endian
            PIX_FMT_GRAY16LE,  ///<        Y        , 16bpp, little-endian
            PIX_FMT_YUV440P,   ///< planar YUV 4:4:0 (1 Cr & Cb sample per 1x2 Y samples)
            PIX_FMT_YUVJ440P,  ///< planar YUV 4:4:0 full scale (JPEG), deprecated in favor of PIX_FMT_YUV440P and setting color_range
            PIX_FMT_YUVA420P,  ///< planar YUV 4:2:0, 20bpp, (1 Cr & Cb sample per 2x2 Y & A samples)
            PIX_FMT_VDPAU_H264,///< H.264 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
            PIX_FMT_VDPAU_MPEG1,///< MPEG-1 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
            PIX_FMT_VDPAU_MPEG2,///< MPEG-2 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
            PIX_FMT_VDPAU_WMV3,///< WMV3 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
            PIX_FMT_VDPAU_VC1, ///< VC-1 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
            PIX_FMT_RGB48BE,   ///< packed RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as big-endian
            PIX_FMT_RGB48LE,   ///< packed RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as little-endian

            PIX_FMT_RGB565BE,  ///< packed RGB 5:6:5, 16bpp, (msb)   5R 6G 5B(lsb), big-endian
            PIX_FMT_RGB565LE,  ///< packed RGB 5:6:5, 16bpp, (msb)   5R 6G 5B(lsb), little-endian
            PIX_FMT_RGB555BE,  ///< packed RGB 5:5:5, 16bpp, (msb)1A 5R 5G 5B(lsb), big-endian, most significant bit to 0
            PIX_FMT_RGB555LE,  ///< packed RGB 5:5:5, 16bpp, (msb)1A 5R 5G 5B(lsb), little-endian, most significant bit to 0

            PIX_FMT_BGR565BE,  ///< packed BGR 5:6:5, 16bpp, (msb)   5B 6G 5R(lsb), big-endian
            PIX_FMT_BGR565LE,  ///< packed BGR 5:6:5, 16bpp, (msb)   5B 6G 5R(lsb), little-endian
            PIX_FMT_BGR555BE,  ///< packed BGR 5:5:5, 16bpp, (msb)1A 5B 5G 5R(lsb), big-endian, most significant bit to 1
            PIX_FMT_BGR555LE,  ///< packed BGR 5:5:5, 16bpp, (msb)1A 5B 5G 5R(lsb), little-endian, most significant bit to 1

            PIX_FMT_VAAPI_MOCO, ///< HW acceleration through VA API at motion compensation entry-point, Picture.data[3] contains a vaapi_render_state struct which contains macroblocks as well as various fields extracted from headers
            PIX_FMT_VAAPI_IDCT, ///< HW acceleration through VA API at IDCT entry-point, Picture.data[3] contains a vaapi_render_state struct which contains fields extracted from headers
            PIX_FMT_VAAPI_VLD,  ///< HW decoding through VA API, Picture.data[3] contains a vaapi_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers

            PIX_FMT_YUV420P16LE,  ///< planar YUV 4:2:0, 24bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian
            PIX_FMT_YUV420P16BE,  ///< planar YUV 4:2:0, 24bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian
            PIX_FMT_YUV422P16LE,  ///< planar YUV 4:2:2, 32bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian
            PIX_FMT_YUV422P16BE,  ///< planar YUV 4:2:2, 32bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian
            PIX_FMT_YUV444P16LE,  ///< planar YUV 4:4:4, 48bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian
            PIX_FMT_YUV444P16BE,  ///< planar YUV 4:4:4, 48bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian
            PIX_FMT_VDPAU_MPEG4,  ///< MPEG4 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
            PIX_FMT_DXVA2_VLD,    ///< HW decoding through DXVA2, Picture.data[3] contains a LPDIRECT3DSURFACE9 pointer

            PIX_FMT_RGB444LE,  ///< packed RGB 4:4:4, 16bpp, (msb)4A 4R 4G 4B(lsb), little-endian, most significant bits to 0
            PIX_FMT_RGB444BE,  ///< packed RGB 4:4:4, 16bpp, (msb)4A 4R 4G 4B(lsb), big-endian, most significant bits to 0
            PIX_FMT_BGR444LE,  ///< packed BGR 4:4:4, 16bpp, (msb)4A 4B 4G 4R(lsb), little-endian, most significant bits to 1
            PIX_FMT_BGR444BE,  ///< packed BGR 4:4:4, 16bpp, (msb)4A 4B 4G 4R(lsb), big-endian, most significant bits to 1
            PIX_FMT_GRAY8A,    ///< 8bit gray, 8bit alpha
            PIX_FMT_BGR48BE,   ///< packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as big-endian
            PIX_FMT_BGR48LE,   ///< packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as little-endian

            //the following 10 formats have the disadvantage of needing 1 format for each bit depth, thus
            //If you want to support multiple bit depths, then using PIX_FMT_YUV420P16* with the bpp stored seperately
            //is better
            PIX_FMT_YUV420P9BE, ///< planar YUV 4:2:0, 13.5bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian
            PIX_FMT_YUV420P9LE, ///< planar YUV 4:2:0, 13.5bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian
            PIX_FMT_YUV420P10BE,///< planar YUV 4:2:0, 15bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian
            PIX_FMT_YUV420P10LE,///< planar YUV 4:2:0, 15bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian
            PIX_FMT_YUV422P10BE,///< planar YUV 4:2:2, 20bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian
            PIX_FMT_YUV422P10LE,///< planar YUV 4:2:2, 20bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian
            PIX_FMT_YUV444P9BE, ///< planar YUV 4:4:4, 27bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian
            PIX_FMT_YUV444P9LE, ///< planar YUV 4:4:4, 27bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian
            PIX_FMT_YUV444P10BE,///< planar YUV 4:4:4, 30bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian
            PIX_FMT_YUV444P10LE,///< planar YUV 4:4:4, 30bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian
            PIX_FMT_NB,        ///< number of pixel formats, DO NOT USE THIS if you want to link with shared libav* because the number of formats might differ between versions
        }      
    }

    public enum ColorSpace : int
    {
        ITU709 = 1,
        FCC = 4,
        ITU601 = 5,
        ITU624 = 5,
        SMPTE170M = 5,
        SMPTE240M = 7,
        DEFAULT = 5,
    }
}
