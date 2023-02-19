using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renderer.Core
{
    // render 支持的帧类型
    public enum FrameFormat
    {
        YV12 = 0,
		NV12 = 1,
		YUY2 = 2,
		UYVY = 3,

		RGB15 = 10,
		RGB16 = 11,
        RGB24 = 12,  //D3D通常不支持RGB24
		RGB32 = 13,
		ARGB32 = 14
    }
}
