using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renderer.Core.Imaging
{
    public enum PixelAlignmentType
    {
        NotSupported = -1,

        /// <summary>
        /// 8 bits per pixel gray scale bitmap
        /// </summary>
        Y800,

        /// <summary>
        /// 16 bits per pixel gray scale bitmap
        /// </summary>
        Y16,

        /// <summary>
        /// 24 bits per pixel packed with 8 bits for each of the Y, U and V values
        /// </summary>
        YUV,

        /// <summary>
        /// 16 bits per pixel packed YUYV array
        /// </summary>
        YUY2,

        /// <summary>
        /// 16 bits per pixel packed UYVY array 
        /// </summary>
        UYVY,

        /// <summary>
        /// 12 bits per pixel planar format with Y plane followed by V and U planes
        /// </summary>
        YV12,

        /// <summary>
        /// Same as YV12 but V and U are swapped
        /// </summary>
        I420,

        /// <summary>
        /// 12 bits per pixel planar format with Y plane and interleaved UV plane
        /// </summary>
        NV12,

        /// <summary>
        /// 12 bits per pixel planar format with Y plane and interleaved VU plane
        /// </summary>
        NV21,

        /// <summary>
        /// 12 bits per pixel YUV 4:1:1 planar format
        /// </summary>
        Y411,

        /// <summary>
        /// 9 bits per pixel planar format
        /// </summary>
        Y410,

        /// <summary>
        /// 24 bits per pixel blue, green and red
        /// </summary>
        RGB24,

        /// <summary>
        /// 32 bits per pixel blue, green, red and alpha
        /// </summary>
        BGRA,

        /// <summary>
        /// 32 bits per pixel alpha, blue, green, and red
        /// </summary>
        ABGR
    }
}
