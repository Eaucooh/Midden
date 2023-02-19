using System;
using System.Runtime.InteropServices;
using SlimDX;
using SlimDX.Direct3D9;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media;
using System.Windows.Forms;

namespace Renderer.Core
{
    public class D3DImageSource : IRenderSource
    {
        #region 常量

        private const VertexFormat CUSTOM_VERTEX = VertexFormat.Position | VertexFormat.Diffuse | VertexFormat.Texture1;

        public const int SM_CXVIRTUALSCREEN = 78;
        public const int SM_CYVIRTUALSCREEN = 79;

        public static Format D3DFormatYV12 = D3DX.MakeFourCC((byte)'Y', (byte)'V', (byte)'1', (byte)'2');

        public static Format D3DFormatNV12 = D3DX.MakeFourCC((byte)'N', (byte)'V', (byte)'1', (byte)'2');

        public static Color4 BlackColor = new Color4(GetArgb(0xFF, 0, 0, 0));


        #endregion

        #region 私有变量

        private D3DImage imageSource;
        private Int32Rect imageSourceRect;

        // 如果为Vista以上，则将实例化为Ex版本
        private Direct3D direct3D; 
        private int adapterId;
        private CreateFlags createFlag;

        private Device device;
        private IntPtr hwnd;
        private Form dummyWindow;

        private Surface inputSurface;
        private Texture texture;
        private Surface textureSurface;
        private VertexBuffer vertexBuffer;
        //private Surface renderTarget;

        private ShaderBytecode vertexShaderCode;
        private VertexShader vertexShader;
        private ConstantTable vertexConstantTable;

        // pixel shader
        private ShaderBytecode pixelShaderCode;
        private PixelShader pixelShader;
        private ConstantTable pixelShaderConstantTable;

        private DisplayMode displayMode;

        private object renderLock;

        // 视频格式信息
        private FrameFormat frameFormat;

        // 帧格式为非YV12, NV12时，uv变量无效. 此时yStride即为图像宽，yHeight即为图像高度，ySize即为图像Buffer大小
        private int yStride;
        private int yHeight;
        private int uvStride;
        private int uvHeight;
        private int ySize;
        private int uvSize;

        private bool isVistaOrBetter;

        #endregion

        #region 构造函数

        public D3DImageSource() : this(0) { }

        public D3DImageSource(int adapterId)
        {
            this.renderLock = new object();

            this.isVistaOrBetter = IsVistaOrBetter;

            this.imageSource = new D3DImage();
            this.imageSource.IsFrontBufferAvailableChanged += this.OnIsFrontBufferAvailableChanged;

            this.InitD3D(adapterId);

            this.dummyWindow = new Form();
            this.hwnd = this.dummyWindow.Handle;
        }

        #endregion

        #region IRenderSource接口

        public bool CheckFormat(FrameFormat format)
        {
            return this.CheckFormat(ConvertToD3D(format));
        }

        public bool SetupSurface(int videoWidth, int videoHeight, FrameFormat format)
        {
            Format d3dFormat = ConvertToD3D(format);
            if (!this.CheckFormat(d3dFormat))
            {
                // 显卡不支持该格式
                return false;
            }

            #region 初始化尺寸参数

            this.frameFormat = format;
            switch (format)
            {
                case FrameFormat.YV12:
                    this.yStride = videoWidth;
                    this.yHeight = videoHeight;
                    this.ySize = videoWidth * videoHeight;
                    this.uvStride = this.yStride >> 1;
                    this.uvHeight = this.yHeight >> 1;
                    this.uvSize = this.ySize >> 2;
                    break;

                case FrameFormat.NV12:
                    this.yStride = videoWidth;
                    this.yHeight = videoHeight;
                    this.ySize = videoWidth * videoHeight;
                    this.uvStride = this.yStride;
                    this.uvHeight = this.yHeight >> 1;
                    this.uvSize = this.ySize >> 1;
                    break;

                case FrameFormat.YUY2:
                case FrameFormat.UYVY:
                case FrameFormat.RGB15: // rgb555
                case FrameFormat.RGB16: // rgb565
                    this.yStride = videoWidth << 1;
                    this.yHeight = videoHeight;
                    this.ySize = this.yStride * this.yHeight;
                    this.uvStride = this.uvHeight = this.uvSize = 0;
                    break;

                case FrameFormat.RGB32:
                case FrameFormat.ARGB32:
                    this.yStride = videoWidth << 2;
                    this.yHeight = videoHeight;
                    this.ySize = this.yStride * this.yHeight;
                    this.uvStride = this.uvHeight = this.uvSize = 0;
                    break;

                default:
                    return false;
            }

            #endregion

            this.ReleaseResource();

            this.CreateResource(d3dFormat, videoWidth, videoHeight);

            return true;
        }

        public void Render(IntPtr buffer)
        {
            lock (this.renderLock)
            {
                this.FillBuffer(buffer);

                this.StretchSurface();

                this.CreateScene();
            }

            this.InvalidateImage();
        }

        public void Render(IntPtr yBuffer, IntPtr uBuffer, IntPtr vBuffer)
        {
            lock (this.renderLock)
            {
                this.FillBuffer(yBuffer, uBuffer, vBuffer);

                this.StretchSurface();

                this.CreateScene();
            }

            this.InvalidateImage();
        }

        public ImageSource ImageSource { get { return this.imageSource; } }

        public event EventHandler ImageSourceChanged;

        #endregion

        #region 公开接口

        /// <summary>
        /// 提供PixelShader接口对渲染进一步处理
        /// </summary>
        /// <param name="shaderbytes">编译出来的ps文件的bytes</param>
        public void SetPixelShader(byte[] shaderbytes)
        {
            this.SafeRelease(this.pixelShader);
            this.SafeRelease(this.pixelShaderConstantTable);
            this.SafeRelease(this.pixelShaderCode);

            this.pixelShaderCode = new ShaderBytecode(shaderbytes);
            this.pixelShader = new PixelShader(this.device, this.pixelShaderCode);
            this.pixelShaderConstantTable = this.pixelShaderCode.ConstantTable;
        }

        /// <summary>
        /// 提供VertexShader接口对渲染进行进一步
        /// </summary>
        /// <param name="shader">编译出来的shader文件的bytes</param>
        public void SetVertexShader(byte[] shaderbytes)
        {
            this.SafeRelease(this.vertexShader);
            this.SafeRelease(this.vertexConstantTable);
            this.SafeRelease(this.vertexShaderCode);

            this.vertexShaderCode = new ShaderBytecode(shaderbytes);
            this.vertexShader = new VertexShader(this.device, this.vertexShaderCode);
            this.vertexConstantTable = this.vertexShaderCode.ConstantTable;
        }


        public void Clear()
        {
            this.device.ColorFill(this.textureSurface, BlackColor);
        }

        public Surface RenderSurface
        {
            get
            {
                return this.textureSurface;
            }
        }

        public bool IsDeviceAvailable
        {
            get
            {
                return this.CheckDevice();
            }
        }

        #endregion

        #region 私有函数

        private void InitD3D(int adapterId = 0)
        {
            this.adapterId = adapterId;
            this.direct3D = this.isVistaOrBetter ? new Direct3DEx() : new Direct3D();

            this.displayMode = this.direct3D.GetAdapterDisplayMode(this.adapterId);
            Capabilities deviceCap = this.direct3D.GetDeviceCaps(this.adapterId, DeviceType.Hardware);
            this.createFlag = CreateFlags.Multithreaded;
            if ((int)deviceCap.VertexProcessingCaps != 0)
            {
                this.createFlag |= CreateFlags.HardwareVertexProcessing;
            }
            else
            {
                this.createFlag |= CreateFlags.SoftwareVertexProcessing;
            }
        }

        private void CreateResource(Format format, int width, int height)
        {
            PresentParameters presentParameters = this.GetPresentParameters(width, height);

            #region 创建device

            this.device = this.isVistaOrBetter ?
                new DeviceEx((Direct3DEx)this.direct3D, this.adapterId, DeviceType.Hardware, this.hwnd, this.createFlag, presentParameters) :
                new Device(this.direct3D, this.adapterId, DeviceType.Hardware, this.hwnd, this.createFlag, presentParameters);

            this.device.SetRenderState(RenderState.CullMode, Cull.None);
            this.device.SetRenderState(RenderState.ZEnable, ZBufferType.DontUseZBuffer);
            this.device.SetRenderState(RenderState.Lighting, false);
            this.device.SetRenderState(RenderState.DitherEnable, true);
            this.device.SetRenderState(RenderState.MultisampleAntialias, true);
            this.device.SetRenderState(RenderState.AlphaBlendEnable, true);
            this.device.SetRenderState(RenderState.SourceBlend, Blend.SourceAlpha);
            this.device.SetRenderState(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
            this.device.SetSamplerState(0, SamplerState.MagFilter, TextureFilter.Linear);
            this.device.SetSamplerState(0, SamplerState.MinFilter, TextureFilter.Linear);
            this.device.SetSamplerState(0, SamplerState.AddressU, TextureAddress.Clamp);
            this.device.SetSamplerState(0, SamplerState.AddressV, TextureAddress.Clamp);
            this.device.SetTextureStageState(0, TextureStage.ColorOperation, TextureOperation.SelectArg1);
            this.device.SetTextureStageState(0, TextureStage.ColorArg1, TextureArgument.Texture);
            this.device.SetTextureStageState(0, TextureStage.ColorArg2, TextureArgument.Specular);
            this.device.SetTextureStageState(0, TextureStage.AlphaOperation, TextureOperation.Modulate);
            this.device.SetTextureStageState(0, TextureStage.AlphaArg1, TextureArgument.Texture);
            this.device.SetTextureStageState(0, TextureStage.AlphaArg2, TextureArgument.Diffuse);

            #endregion

            #region 创建RenderTarget

            //this.renderTarget = this.device.GetRenderTarget(0);
            int vertexSize = Marshal.SizeOf(typeof(VERTEX));
            this.texture = new Texture(this.device, width, height, 1, Usage.RenderTarget, this.displayMode.Format, Pool.Default);
            this.textureSurface = this.texture.GetSurfaceLevel(0);
            
            VERTEX[] vertexList = new VERTEX[]
            {
                new VERTEX(){ pos = new Vector3(0, 0, 0), texPos = new Vector2(0, 0), color = 0xFFFFFFFF}, // 左上
                new VERTEX(){ pos = new Vector3(width, 0, 0), texPos = new Vector2(1, 0), color = 0xFFFFFFFF}, // 右上
                new VERTEX(){ pos = new Vector3(width, height, 0), texPos = new Vector2(1, 1), color = 0xFFFFFFFF}, // 右下
                new VERTEX(){ pos = new Vector3(0, height, 0), texPos = new Vector2(0, 1), color = 0xFFFFFFFF}, // 左下
            };

            this.vertexBuffer = new VertexBuffer(this.device, vertexSize * 4, Usage.Dynamic | Usage.WriteOnly, CUSTOM_VERTEX, Pool.Default);
            DataStream stream = this.vertexBuffer.Lock(0, 0, LockFlags.Discard);

            // 左上
            IntPtr dataPointer = stream.DataPointer;
            Marshal.StructureToPtr(vertexList[0], dataPointer, true);

            // 右上
            dataPointer += vertexSize;
            Marshal.StructureToPtr(vertexList[1], dataPointer, true);

            // 右下
            dataPointer += vertexSize;
            Marshal.StructureToPtr(vertexList[2], dataPointer, true);

            // 左下
            dataPointer += vertexSize;
            Marshal.StructureToPtr(vertexList[3], dataPointer, true);

            this.vertexBuffer.Unlock();

            #endregion

            this.SetupMatrices(width, height);

            #region 创建input surface
            this.inputSurface = this.isVistaOrBetter ?
                Surface.CreateOffscreenPlainEx((DeviceEx)this.device, width, height, format, Pool.Default, Usage.None) :
                Surface.CreateOffscreenPlain(this.device, width, height, format, Pool.Default);

            this.device.ColorFill(this.inputSurface, BlackColor);

            this.SetImageSourceBackBuffer();

            #endregion
        }

        private void ReleaseResource()
        {
            this.SafeRelease(this.inputSurface);

            this.SafeRelease(this.vertexShader);
            this.SafeRelease(this.vertexConstantTable);
            this.SafeRelease(this.pixelShader);
            this.SafeRelease(this.pixelShaderConstantTable);

            this.SafeRelease(this.vertexBuffer);
            
            this.SafeRelease(this.texture);
            this.SafeRelease(this.textureSurface);
            //this.SafeRelease(this.renderTarget);

            this.SafeRelease(this.device);
        }

        private PresentParameters GetPresentParameters(int width, int height)
        {
            PresentParameters presentParams = new PresentParameters();
            presentParams.PresentFlags = PresentFlags.Video | PresentFlags.OverlayYCbCr_BT709;
            presentParams.Windowed = true;
            presentParams.DeviceWindowHandle = this.hwnd;
            presentParams.BackBufferWidth = width == 0 ? 1 : width;
            presentParams.BackBufferHeight = height == 0 ? 1 : height;
            presentParams.SwapEffect = SwapEffect.Discard;
            //presentParams.Multisample = MultisampleType.NonMaskable;
            presentParams.PresentationInterval = PresentInterval.Immediate;
            presentParams.BackBufferFormat = this.displayMode.Format;
            presentParams.BackBufferCount = 1;
            presentParams.EnableAutoDepthStencil = false;

            return presentParams;
        }

        private void FillBuffer(IntPtr bufferPtr)
        {
            if (this.inputSurface == null)
            {
                return;
            }

            DataRectangle rect = this.inputSurface.LockRectangle(LockFlags.None);
            IntPtr surfaceBufferPtr = rect.Data.DataPointer;
            switch (this.frameFormat)
            {
                case FrameFormat.YV12:
                    #region 填充YV12数据
                    if (rect.Pitch == this.yStride)
                    {
                        Interop.Memcpy(surfaceBufferPtr, bufferPtr, this.ySize + this.uvSize + this.uvSize);
                    }
                    else
                    {
                        IntPtr srcPtr = bufferPtr; // Y
                        int yPitch = rect.Pitch;
                        for (int i = 0; i < this.yHeight; i++)
                        {
                            Interop.Memcpy(surfaceBufferPtr, srcPtr, this.yStride);
                            surfaceBufferPtr += yPitch;
                            srcPtr += this.yStride;
                        }

                        int uvPitch = yPitch >> 1;
                        for (int i = 0; i < yHeight; i++) // UV一起copy, uHeight + vHeight = yHeight
                        {
                            Interop.Memcpy(surfaceBufferPtr, srcPtr, this.uvStride);
                            surfaceBufferPtr += uvPitch;
                            srcPtr += this.uvStride;
                        }
                    }
                    #endregion
                    break;

                case FrameFormat.NV12:
                    #region 填充NV12. uBuffer指向UV打包数据。vBuffer为空

                    if (rect.Pitch == this.yStride)
                    {
                        Interop.Memcpy(surfaceBufferPtr, bufferPtr, this.ySize + this.uvSize);
                    }
                    else
                    {
                        // uv打包保存，uvWidth与yWidth相同, 因此可以合并在一个循环
                        IntPtr srcPtr = bufferPtr; 
                        for (int i = 0; i < this.yHeight + this.uvHeight; i++)
                        {
                            Interop.Memcpy(surfaceBufferPtr, srcPtr, this.yStride);
                            surfaceBufferPtr += rect.Pitch;
                            srcPtr += this.yStride;
                        }
                    }
                    #endregion
                    break;

                // 打包格式
                case FrameFormat.YUY2:
                case FrameFormat.UYVY:
                case FrameFormat.RGB15:
                case FrameFormat.RGB16:
                case FrameFormat.RGB24:
                case FrameFormat.RGB32:
                case FrameFormat.ARGB32:
                default:
                    #region 填充buffer。此时，所有数据都在yBuffer里，其他两个buffer无效
                    if (rect.Pitch == this.yStride)
                    {
                        Interop.Memcpy(surfaceBufferPtr, bufferPtr, this.ySize); // ySize此时等于整个dataSize
                    }
                    else
                    {
                        IntPtr srcPtr = bufferPtr;
                        for (int i = 0; i < this.yHeight; i++)
                        {
                            Interop.Memcpy(surfaceBufferPtr, srcPtr, this.yStride);
                            surfaceBufferPtr += rect.Pitch;
                            srcPtr += this.yStride;
                        }
                    }
                    #endregion
                    break;
            }

            this.inputSurface.UnlockRectangle();
        }

        private void FillBuffer(IntPtr yBuffer, IntPtr uBuffer, IntPtr vBuffer)
        {
            if (this.inputSurface == null)
            {
                return;
            }

            DataRectangle rect = this.inputSurface.LockRectangle(LockFlags.None);
            IntPtr surfaceBufferPtr = rect.Data.DataPointer;
            switch (this.frameFormat)
            {
                case FrameFormat.YV12:
                    #region 填充YV12数据
                    if (rect.Pitch == this.yStride)
                    {
                        Interop.Memcpy(surfaceBufferPtr, yBuffer, this.ySize); // Y
                        surfaceBufferPtr += this.ySize;
                        Interop.Memcpy(surfaceBufferPtr, vBuffer, this.uvSize); // V 
                        surfaceBufferPtr += this.uvSize;
                        Interop.Memcpy(surfaceBufferPtr, uBuffer, this.uvSize); // U
                    }
                    else
                    {
                        IntPtr yPtr = yBuffer; // Y
                        int yPitch = rect.Pitch;
                        for (int i = 0; i < this.yHeight; i++)
                        {
                            Interop.Memcpy(surfaceBufferPtr, yPtr, this.yStride); 
                            surfaceBufferPtr += yPitch;
                            yPtr += this.yStride;
                        }

                        int uvPitch = yPitch >> 1;

                        IntPtr vPtr = vBuffer; // V
                        for (int i = 0; i < uvHeight; i++)
                        {
                            Interop.Memcpy(surfaceBufferPtr, vPtr, uvStride);
                            surfaceBufferPtr += uvPitch;
                            vPtr += uvStride;
                        }

                        IntPtr uPtr = uBuffer; // U
                        for (int i = 0; i < uvHeight; i++)
                        {
                            Interop.Memcpy(surfaceBufferPtr, uPtr, uvStride);
                            surfaceBufferPtr += uvPitch;
                            uPtr += uvStride;
                        }
                    }
                    #endregion
                    break;

                case FrameFormat.NV12:
                    #region 填充NV12. uBuffer指向UV打包数据。vBuffer为空

                    if (rect.Pitch == this.yStride)
                    {
                        Interop.Memcpy(surfaceBufferPtr, yBuffer, this.ySize); // Copy Y数据
                        surfaceBufferPtr += this.ySize;
                        Interop.Memcpy(surfaceBufferPtr, uBuffer, this.uvSize); // Copy UV打包数据
                    }
                    else
                    {
                        // Copy Y数据
                        IntPtr yPtr = yBuffer;
                        for (int i = 0; i < this.yHeight; i++)
                        {
                            Interop.Memcpy(surfaceBufferPtr, yPtr, this.yStride);
                            surfaceBufferPtr += rect.Pitch;
                            yPtr += this.yStride;
                        }

                        // Copy UV打包数据
                        IntPtr uvPtr = uBuffer;
                        for (int i = 0; i < this.uvHeight; i++) 
                        {
                            Interop.Memcpy(surfaceBufferPtr, uvPtr, this.uvStride);
                            surfaceBufferPtr += rect.Pitch; // 此时uv打包保存，每行数据与y相同
                            uvPtr += this.uvStride;
                        }
                    }
                    #endregion
                    break;

                case FrameFormat.YUY2:
                case FrameFormat.UYVY:
                case FrameFormat.RGB15:
                case FrameFormat.RGB16:
                case FrameFormat.RGB32:
                case FrameFormat.ARGB32:
                default:
                    #region 填充buffer。此时，所有数据都在yBuffer里，其他两个buffer无效
                    if (rect.Pitch == this.yStride)
                    {
                        Interop.Memcpy(surfaceBufferPtr, yBuffer, this.ySize); // ySize此时等于整个dataSize
                    }
                    else
                    {
                        IntPtr yPtr = yBuffer; 
                        for (int i = 0; i < this.yHeight; i++)
                        {
                            Interop.Memcpy(surfaceBufferPtr, yPtr, this.yStride);
                            surfaceBufferPtr += rect.Pitch;
                            yBuffer += this.yStride;  // yWidth即为每行图像stride
                        }
                    }
                    #endregion
                    break;
            }

            this.inputSurface.UnlockRectangle();
        }

        private void StretchSurface()
        {
            this.device.ColorFill(this.textureSurface, BlackColor);

            this.device.StretchRectangle(this.inputSurface, this.textureSurface, TextureFilter.Linear);
        }

        private void CreateScene()
        {
            this.device.Clear(ClearFlags.Target, BlackColor, 1.0f, 0);
            this.device.BeginScene();

            this.device.VertexFormat = CUSTOM_VERTEX;
            this.device.VertexShader = this.vertexShader;
            this.device.PixelShader = this.pixelShader;

            this.device.SetStreamSource(0, this.vertexBuffer, 0, Marshal.SizeOf(typeof(VERTEX)));

            this.device.SetTexture(0, this.texture);

            this.device.DrawPrimitives(PrimitiveType.TriangleFan, 0, 2);

            this.device.EndScene();
        }

        private void Present()
        {
            if (this.isVistaOrBetter)
            {
                ((DeviceEx)this.device).PresentEx(SlimDX.Direct3D9.Present.None);
            }
            else
            {
                this.device.Present();
            }
        }

        /// <summary>
        /// 检查d3d设备是否正常
        /// </summary>
        /// <returns></returns>
        private bool CheckDevice()
        {
            if (this.isVistaOrBetter)
            {
                DeviceState state = ((DeviceEx)this.device).CheckDeviceState(this.hwnd);
                return state == DeviceState.Ok;
            }
            else
            {
                return false; // xp无法支持ex
            }
        }

        private void SetupMatrices(int width, int height)
        {
            SlimDX.Matrix matOrtho = SlimDX.Matrix.OrthoOffCenterLH(0, width, height, 0, 0.0f, 1.0f);
            SlimDX.Matrix matIdentity = SlimDX.Matrix.Identity;

            this.device.SetTransform(TransformState.Projection, matOrtho);
            this.device.SetTransform(TransformState.World, matIdentity);
            this.device.SetTransform(TransformState.View, matIdentity);
        }

        private void OnIsFrontBufferAvailableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.imageSource.IsFrontBufferAvailable && this.textureSurface != null)
            {
                this.imageSource.Lock();
                this.imageSource.SetBackBuffer(D3DResourceType.IDirect3DSurface9, this.textureSurface.ComPointer);
                this.imageSource.Unlock();
            }
        }

        private void SetImageSourceBackBuffer()
        {
            if (!this.imageSource.Dispatcher.CheckAccess())
            {
                this.imageSource.Dispatcher.Invoke((Action)(() => this.SetImageSourceBackBuffer()));
                return;
            }

            this.imageSource.Lock();
            this.imageSource.SetBackBuffer(D3DResourceType.IDirect3DSurface9, this.textureSurface.ComPointer);
            this.imageSource.Unlock();

            this.imageSourceRect = new Int32Rect(0, 0, this.imageSource.PixelWidth, this.imageSource.PixelHeight);
        }

        private void InvalidateImage()
        {
            if (!this.imageSource.Dispatcher.CheckAccess())
            {
                this.imageSource.Dispatcher.Invoke((Action)(() => this.InvalidateImage()));
                return;
            }

            if (!this.imageSource.IsFrontBufferAvailable)
            {
                return;
            }

            try
            {
                this.imageSource.Lock();
                this.imageSource.AddDirtyRect(this.imageSourceRect);
                this.imageSource.Unlock();
            }
            catch
            {
            }
        }

        private bool CheckFormat(Format d3dFormat)
        {
            if (!this.direct3D.CheckDeviceFormat(this.adapterId, DeviceType.Hardware, this.displayMode.Format, Usage.None, ResourceType.Surface, d3dFormat))
            {
                return false;
            }

            return this.direct3D.CheckDeviceFormatConversion(this.adapterId, DeviceType.Hardware, d3dFormat, this.displayMode.Format);            

        }

        private void GetWindowSize(IntPtr hwnd, out int width, out int height)
        {
            RECT rect = new RECT();
            Interop.GetWindowRect(hwnd, ref rect);
            height = rect.Bottom - rect.Top;
            width = rect.Right - rect.Left;
        }

        private static Format ConvertToD3D(FrameFormat format)
        {
            switch (format)
            {
                case FrameFormat.YV12:
                    return D3DFormatYV12;

                case FrameFormat.NV12:
                    return D3DFormatNV12;

                case FrameFormat.YUY2:
                    return Format.Yuy2;

                case FrameFormat.UYVY:
                    return Format.Uyvy;

                case FrameFormat.RGB15:
                    return Format.X1R5G5B5;

                case FrameFormat.RGB16:
                    return Format.R5G6B5;

                case FrameFormat.RGB32:
                    return Format.X8R8G8B8;

                case FrameFormat.ARGB32:
                    return Format.A8R8G8B8;

                case FrameFormat.RGB24:
                    return Format.R8G8B8;

                default:
                    throw new ArgumentException("Unknown pixel format", "format");
            }
        }

        private static int GetArgb(byte a, byte r, byte g, byte b)
        {
            return a << 24 + r << 16 + g << 8 + b;
        }

        private static bool IsVistaOrBetter
        {
            get
            {
                return Environment.OSVersion.Version.Major >= 6;
            }
        }

        #endregion

        #region IDisposable

        private bool isDisposed = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                this.isDisposed = true;

                if (disposing)
                {
                    this.ReleaseResource();

                    this.SafeRelease(this.vertexShader);
                    this.SafeRelease(this.vertexConstantTable);
                    this.SafeRelease(this.vertexShaderCode);

                    this.SafeRelease(this.pixelShader);
                    this.SafeRelease(this.pixelShaderConstantTable);
                    this.SafeRelease(this.pixelShaderCode);

                    this.SafeRelease(this.direct3D);
                    this.SafeRelease(this.dummyWindow);
                }
            }
        }

        private void SafeRelease(IDisposable item)
        {
            try
            {
                if (item != null)
                {
                    item.Dispose();
                }
            }
            catch
            {
            }
        }

        #endregion
    }
}
