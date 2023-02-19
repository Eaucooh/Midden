using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Renderer.Core.Imaging
{
    static class Cropper 
    {
        public static PlanarImage Crop(PlanarImage source, Rectangle cropArea)
        {
            PlanarImage result = new PlanarImage(cropArea.Width, cropArea.Height, source.PixelType);
            switch (source.PixelType)
            {
                case PixelAlignmentType.I420:
                case PixelAlignmentType.YV12:
                    IntPtr dest = result.Planes[0];
                    IntPtr src = source.Planes[0] + cropArea.Y * source.Width + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width);
                        dest += cropArea.Width;
                        src += source.Width;
                    }

                    dest = result.Planes[1];
                    src = source.Planes[1] + cropArea.Y / 2 * source.Width / 2 + cropArea.X / 2;
                    for (int i = 0; i < cropArea.Height / 2; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width / 2);
                        dest += cropArea.Width / 2;
                        src += source.Width / 2;
                    }

                    dest = result.Planes[2];
                    src = source.Planes[2] + cropArea.Y / 2 * source.Width / 2 + cropArea.X / 2;
                    for (int i = 0; i < cropArea.Height / 2; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width / 2);
                        dest += cropArea.Width / 2;
                        src += source.Width / 2;
                    }

                    break;
                case PixelAlignmentType.NV12:
                case PixelAlignmentType.NV21:
                    dest = result.Planes[0];
                    src = source.Planes[0] + cropArea.Y * source.Width + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width);
                        dest += cropArea.Width;
                        src += source.Width;
                    }

                    dest = result.Planes[1];
                    src = source.Planes[1] + cropArea.Y * source.Width / 2 + cropArea.X;
                    for (int i = 0; i < cropArea.Height / 2; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width);
                        dest += cropArea.Width;
                        src += source.Width;
                    }

                    break;

                case PixelAlignmentType.YUY2:
                case PixelAlignmentType.UYVY:
                    dest = result.Planes[0];
                    src = source.Planes[0] + cropArea.Y * source.Pitches[0] + cropArea.X * 2;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, source.Pitches[0]);
                        dest += result.Pitches[0];
                        src += source.Pitches[0];
                    }
                    break;

                case PixelAlignmentType.YUV:
                    dest = result.Planes[0];
                    src = source.Planes[0] + cropArea.Y * source.Width + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width);
                        dest += cropArea.Width;
                        src += source.Width;
                    }

                    dest = result.Planes[1];
                    src = source.Planes[1] + cropArea.Y * source.Width + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width);
                        dest += cropArea.Width;
                        src += source.Width;
                    }

                    dest = result.Planes[2];
                    src = source.Planes[2] + cropArea.Y * source.Width + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width);
                        dest += cropArea.Width;
                        src += source.Width;
                    }
                    break;

                case PixelAlignmentType.Y800:
                    dest = result.Planes[0];
                    src = source.Planes[0] + cropArea.Y * source.Width + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width);
                        dest += cropArea.Width;
                        src += source.Width;
                    }
                    break;

                case PixelAlignmentType.Y411:
                    dest = result.Planes[0];
                    src = source.Planes[0] + cropArea.Y * source.Pitches[0] + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, result.Pitches[0]);
                        dest += result.Pitches[0];
                        src += source.Pitches[0];
                    }

                    dest = result.Planes[1];
                    src = source.Planes[1] + cropArea.Y * source.Pitches[1] + cropArea.X / 4;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, result.Pitches[1]);
                        dest += result.Pitches[1];
                        src += source.Pitches[1];
                    }

                    dest = result.Planes[2];
                    src = source.Planes[2] + cropArea.Y * source.Pitches[2] + cropArea.X / 4;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, result.Pitches[2]);
                        dest += result.Pitches[2];
                        src += source.Pitches[2];
                    }
                    break;

                case PixelAlignmentType.Y410:
                    dest = result.Planes[0];
                    src = source.Planes[0] + cropArea.Y * source.Width + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width);
                        dest += cropArea.Width;
                        src += source.Width;
                    }

                    dest = result.Planes[1];
                    src = source.Planes[1] + cropArea.Y / 4 * source.Width / 4 + cropArea.X / 4;
                    for (int i = 0; i < cropArea.Height / 4; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width / 4);
                        dest += cropArea.Width / 4;
                        src += source.Width / 4;
                    }

                    dest = result.Planes[2];
                    src = source.Planes[2] + cropArea.Y / 4 * source.Width / 4 + cropArea.X / 4;
                    for (int i = 0; i < cropArea.Height / 4; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width / 4);
                        dest += cropArea.Width / 4;
                        src += source.Width / 4;
                    }
                    break;

                case PixelAlignmentType.Y16:
                    dest = result.Planes[0];
                    src = source.Planes[0] + cropArea.Y * source.Pitches[0] + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width * 2);
                        dest += cropArea.Width * 2;
                        src += source.Width * 2;
                    }
                    break;

                case PixelAlignmentType.RGB24:
                    dest = result.Planes[0];
                    src = source.Planes[0] + cropArea.Y * source.Pitches[0] + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width * 3);
                        dest += cropArea.Width * 3;
                        src += source.Width * 3;
                    }
                    break;

                case PixelAlignmentType.BGRA:
                    dest = result.Planes[0];
                    src = source.Planes[0] + cropArea.Y * source.Pitches[0] + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width * 4);
                        dest += cropArea.Width * 4;
                        src += source.Width * 4;
                    }
                    break;

                case PixelAlignmentType.ABGR:
                    dest = result.Planes[0];
                    src = source.Planes[0] + cropArea.Y * source.Pitches[0] + cropArea.X;
                    for (int i = 0; i < cropArea.Height; i++)
                    {
                        RtlMoveMemory(dest, src, cropArea.Width * 4);
                        dest += cropArea.Width * 4;
                        src += source.Width * 4;
                    }
                    break;

                default:
                    throw new InvalidOperationException("Unknown pixel alignment type " + source.PixelType);
            }

            return result;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern void RtlMoveMemory(IntPtr dest, IntPtr source, int size);
    }
}
