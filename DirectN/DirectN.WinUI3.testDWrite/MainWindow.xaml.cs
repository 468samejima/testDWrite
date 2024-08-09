using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.UI.Composition;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Windows.Devices.Sms;
using Windows.Graphics;
using WinRT;

namespace DirectN.WinUI3.testDWrite
{
    public sealed partial class MainWindow : Window
    {
        #region Members
        private IComObject<ID3D11DeviceContext> _deviceContext;
        private IComObject<ID3D11Device> _d3d11device;
        private IComObject<IDXGIDevice1> _dxgiDevice;
        private IComObject<IDXGISwapChain1> _swapChain;
        private IComObject<ID3D11Texture2D> _framebufferTexture;
        private IComObject<ID3D11RenderTargetView> _framebufferRTV;
        private IComObject<ID3D11DepthStencilView> _framebufferDSV;
        private IComObject<ID3D11DepthStencilView> _shadowmapDSV;
        private IComObject<ID3D11ShaderResourceView> _shadowmapSRV;
        private IComObject<ID3D11Buffer> _constantBuffer;
        private IComObject<ID3D11Buffer> _vertexBuffer;
        private IComObject<ID3D11ShaderResourceView> _vertexBufferSRV;
        private IComObject<ID3D11DepthStencilState> _depthStencilState;
        private IComObject<ID3D11RasterizerState> _cullBackRS;
        private IComObject<ID3D11RasterizerState> _cullFrontRS;
        private IComObject<ID3D11VertexShader> _framebufferVS;
        private IComObject<ID3D11PixelShader> _framebufferPS;
        private IComObject<ID3D11VertexShader> _shadowmapVS;
        private Constants _constants;
        private D3D11_VIEWPORT _shadowmapVP;
        private D3D11_VIEWPORT _framebufferVP;
        private float[] _framebufferClear;
        private bool _disposed;
        private bool _rendering;
        #endregion

        private RendererDirectWrite RendererDW;

        public MainWindow()
        {
            InitializeComponent();
            Title = "minimal d3d11 pt3 by d7samurai - On WinUI3 and .NET 6.0";

            var size = 1000;
            AppWindow.Resize(new SizeInt32(size, size));

            // we dispose on another thread or a lock will happen when closing under Visual Studio debugger for some reason... (doesn't happen under WinDbg)
            Closed += (s, e) => Task.Run(Dispose);
            panel.SizeChanged += OnSizeChanged;
        }

        private bool isPanelLoaded = false;
        private void panel_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
            isPanelLoaded = true;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Dispose();
            //Init();
            if (!isPanelLoaded) return;

            CompositionTarget.Rendering -= Render;

            _framebufferRTV?.Dispose();
            _framebufferDSV?.Dispose();

            if (_framebufferTexture != null) _framebufferTexture.Dispose();

            _swapChain.Object.ResizeBuffers(
                2u,
                (uint)panel.ActualWidth,
                (uint)panel.ActualHeight,
                DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,    // SwapChainFormat
                (uint)DXGI_SWAP_CHAIN_FLAG.DXGI_SWAP_CHAIN_FLAG_ALLOW_MODE_SWITCH    // Flags
             );


            // get new backbuffer
            _framebufferTexture = _swapChain.GetBuffer<ID3D11Texture2D>(0);

            // create new rendertargetview
            var framebufferDesc = new D3D11_RENDER_TARGET_VIEW_DESC
            {
                Format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB,
                ViewDimension = D3D11_RTV_DIMENSION.D3D11_RTV_DIMENSION_TEXTURE2D
            };
            _framebufferRTV = _d3d11device.CreateRenderTargetView(_framebufferTexture, framebufferDesc);

            // create new depthstencilview
            D3D11_TEXTURE2D_DESC depthBufferDesc = new()
            {
                Width = (uint)panel.ActualWidth,
                Height = (uint)panel.ActualHeight,
                MipLevels = 1,
                ArraySize = 1,
                Format = DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT,
                SampleDesc = new() { Count = 1, Quality = 0 },
                Usage = D3D11_USAGE.D3D11_USAGE_DEFAULT,
                BindFlags = (uint)D3D11_BIND_FLAG.D3D11_BIND_DEPTH_STENCIL,
                CPUAccessFlags = 0,
                MiscFlags = 0
            };
            using IComObject<ID3D11Texture2D> depthBuffer = _d3d11device.CreateTexture2D<ID3D11Texture2D>(depthBufferDesc);
            D3D11_DEPTH_STENCIL_VIEW_DESC descDSV = new()
            {
                Format = depthBufferDesc.Format,
                ViewDimension = DirectN.D3D11_DSV_DIMENSION.D3D11_DSV_DIMENSION_TEXTURE2D,
                __union_3 = new D3D11_DEPTH_STENCIL_VIEW_DESC__union_0()
                {
                    Texture2D = new() { MipSlice = 0 }
                }
            };
            _framebufferDSV = _d3d11device.CreateDepthStencilView(depthBuffer, descDSV);
            depthBuffer.Dispose();

            // update viewport
            _framebufferVP = new D3D11_VIEWPORT
            {
                Width = depthBufferDesc.Width,
                Height = depthBufferDesc.Height,
                MaxDepth = 1
            };

            RendererDW.ResizeDirectWriteResources(_framebufferTexture);

            CompositionTarget.Rendering += Render;
        }

        private void Init()
        {
            #region Initialize Original
            // this code is ported from https://gist.github.com/d7samurai/abab8a580d0298cb2f34a44eec41d39d
            // with slight changes to use CreateSwapChainForComposition to accomodate with WinUI3's SwapChainPanel
            var flags = D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT;

#if DEBUG
            flags |= D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_DEBUG;
#endif

            _d3d11device = D3D11Functions.D3D11CreateDevice(null, D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE, flags, out _deviceContext);
            _dxgiDevice = ComObject.From(_d3d11device.As<IDXGIDevice1>(true));
            using var dxgiAdapter = _dxgiDevice.GetAdapter();
            using var dxgiFactory = dxgiAdapter.GetFactory2();

            var swapChainDesc = new DXGI_SWAP_CHAIN_DESC1
            {
                Width = (uint)panel.ActualWidth,
                Height = (uint)panel.ActualHeight,
                Format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM
            };
            swapChainDesc.SampleDesc.Count = 1;
            swapChainDesc.BufferUsage = DirectN.Constants.DXGI_USAGE_RENDER_TARGET_OUTPUT;
            swapChainDesc.BufferCount = 2;
            swapChainDesc.Scaling = DXGI_SCALING.DXGI_SCALING_STRETCH;
            swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT.DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL;
            swapChainDesc.AlphaMode = DXGI_ALPHA_MODE.DXGI_ALPHA_MODE_UNSPECIFIED;

            _swapChain = dxgiFactory.CreateSwapChainForComposition(_dxgiDevice, swapChainDesc);
            _framebufferTexture = _swapChain.GetBuffer<ID3D11Texture2D>(0);

            var framebufferDesc = new D3D11_RENDER_TARGET_VIEW_DESC
            {
                Format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB,
                ViewDimension = D3D11_RTV_DIMENSION.D3D11_RTV_DIMENSION_TEXTURE2D
            };

            _framebufferRTV = _d3d11device.CreateRenderTargetView(_framebufferTexture, framebufferDesc);

            var framebufferDepthDesc = _framebufferTexture.GetDesc();
            framebufferDepthDesc.Format = DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT;
            framebufferDepthDesc.BindFlags = (uint)D3D11_BIND_FLAG.D3D11_BIND_DEPTH_STENCIL;

            using var framebufferDepthTexture = _d3d11device.CreateTexture2D(framebufferDepthDesc);
            _framebufferDSV = _d3d11device.CreateDepthStencilView(framebufferDepthTexture);

            var shadowmapDepthDesc = new D3D11_TEXTURE2D_DESC
            {
                Width = 2048,
                Height = 2048,
                MipLevels = 1,
                ArraySize = 1,
                Format = DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS
            };
            shadowmapDepthDesc.SampleDesc.Count = 1;
            shadowmapDepthDesc.Usage = D3D11_USAGE.D3D11_USAGE_DEFAULT;
            shadowmapDepthDesc.BindFlags = (uint)(D3D11_BIND_FLAG.D3D11_BIND_DEPTH_STENCIL | D3D11_BIND_FLAG.D3D11_BIND_SHADER_RESOURCE);

            using var shadowmapDepthTexture = _d3d11device.CreateTexture2D(shadowmapDepthDesc);
            var shadowmapDSVdesc = new D3D11_DEPTH_STENCIL_VIEW_DESC
            {
                Format = DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT,
                ViewDimension = D3D11_DSV_DIMENSION.D3D11_DSV_DIMENSION_TEXTURE2D
            };

            _shadowmapDSV = _d3d11device.CreateDepthStencilView(shadowmapDepthTexture, shadowmapDSVdesc);

            var shadowmapSRVdesc = new D3D11_SHADER_RESOURCE_VIEW_DESC
            {
                Format = DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT,
                ViewDimension = D3D_SRV_DIMENSION.D3D11_SRV_DIMENSION_TEXTURE2D
            };
            var t2D = new D3D11_TEX2D_SRV
            {
                MipLevels = 1
            };
            shadowmapSRVdesc.__union_2.Texture2D = t2D;

            _shadowmapSRV = _d3d11device.CreateShaderResourceView(shadowmapDepthTexture, shadowmapSRVdesc);

            var constantBufferDesc = new D3D11_BUFFER_DESC
            {
                ByteWidth = (uint)Marshal.SizeOf<Constants>(),
                Usage = D3D11_USAGE.D3D11_USAGE_DYNAMIC,
                BindFlags = (uint)D3D11_BIND_FLAG.D3D11_BIND_CONSTANT_BUFFER,
                CPUAccessFlags = (uint)D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_WRITE
            };

            _constantBuffer = _d3d11device.CreateBuffer(constantBufferDesc);

            var vertexData = new float[] { -1, 1, -1, 0, 0, 1, 1, -1, 9.5f, 0, -0.58f, 0.58f, -1, 2, 2, 0.58f, 0.58f, -1, 7.5f, 2, -0.58f, 0.58f, -1, 0, 0, 0.58f, 0.58f, -1, 0, 0, -0.58f, 0.58f, -0.58f, 0, 0, 0.58f, 0.58f, -0.58f, 0, 0 };

            var vertexBufferDesc = new D3D11_BUFFER_DESC
            {
                ByteWidth = (uint)vertexData.SizeOf(),
                Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE,
                BindFlags = (uint)D3D11_BIND_FLAG.D3D11_BIND_SHADER_RESOURCE,
                MiscFlags = (uint)D3D11_RESOURCE_MISC_FLAG.D3D11_RESOURCE_MISC_BUFFER_STRUCTURED,
                StructureByteStride = 5 * sizeof(float)
            };

            var gc = GCHandle.Alloc(vertexData, GCHandleType.Pinned);
            var vData = new D3D11_SUBRESOURCE_DATA
            {
                pSysMem = gc.AddrOfPinnedObject()
            };
            _vertexBuffer = _d3d11device.CreateBuffer(vertexBufferDesc, vData);
            gc.Free();

            var vertexBufferSRVdesc = new D3D11_SHADER_RESOURCE_VIEW_DESC
            {
                Format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,
                ViewDimension = D3D_SRV_DIMENSION.D3D11_SRV_DIMENSION_BUFFER
            };
            var bf = new D3D11_BUFFER_SRV();
            bf.__union_1.NumElements = vertexBufferDesc.ByteWidth / vertexBufferDesc.StructureByteStride;
            vertexBufferSRVdesc.__union_2.Buffer = bf;

            _vertexBufferSRV = _d3d11device.CreateShaderResourceView(_vertexBuffer, vertexBufferSRVdesc);

            var depthStencilDesc = new D3D11_DEPTH_STENCIL_DESC
            {
                DepthEnable = true,
                DepthWriteMask = D3D11_DEPTH_WRITE_MASK.D3D11_DEPTH_WRITE_MASK_ALL,
                DepthFunc = D3D11_COMPARISON_FUNC.D3D11_COMPARISON_LESS
            };

            _depthStencilState = _d3d11device.CreateDepthStencilState(depthStencilDesc);

            var rasterizerDesc = new D3D11_RASTERIZER_DESC
            {
                FillMode = D3D11_FILL_MODE.D3D11_FILL_SOLID,
                CullMode = D3D11_CULL_MODE.D3D11_CULL_BACK
            };

            _cullBackRS = _d3d11device.CreateRasterizerState(rasterizerDesc);

            rasterizerDesc.CullMode = D3D11_CULL_MODE.D3D11_CULL_FRONT;
            _cullFrontRS = _d3d11device.CreateRasterizerState(rasterizerDesc);

            var hlslFilePath = Path.Combine(Path.GetDirectoryName(Environment.ProcessPath), "shaders.hlsl");
            using var framebufferVSBlob = D3D11Functions.D3DCompileFromFile(hlslFilePath, "framebuffer_vs", "vs_5_0");
            _framebufferVS = _d3d11device.CreateVertexShader(framebufferVSBlob);

            using var framebufferPSBlob = D3D11Functions.D3DCompileFromFile(hlslFilePath, "framebuffer_ps", "ps_5_0");
            _framebufferPS = _d3d11device.CreatePixelShader(framebufferPSBlob);

            using var shadowmapVSBlob = D3D11Functions.D3DCompileFromFile(hlslFilePath, "shadowmap_vs", "vs_5_0");
            _shadowmapVS = _d3d11device.CreateVertexShader(shadowmapVSBlob);

            _framebufferClear = new float[] { 0.025f, 0.025f, 0.025f, 1 };

            _framebufferVP = new D3D11_VIEWPORT
            {
                Width = framebufferDepthDesc.Width,
                Height = framebufferDepthDesc.Height,
                MaxDepth = 1
            };

            _shadowmapVP = new D3D11_VIEWPORT
            {
                Width = shadowmapDepthDesc.Width,
                Height = shadowmapDepthDesc.Height,
                MaxDepth = 1
            };

            _constants = new Constants
            {
                CameraProjection = new float[] { 2.0f / (_framebufferVP.Width / _framebufferVP.Height), 0, 0, 0, 0, 2, 0, 0, 0, 0, 1.125f, 1, 0, 0, -1.125f, 0 },
                LightProjection = new float[] { 0.5f, 0, 0, 0, 0, 0.5f, 0, 0, 0, 0, 0.125f, 0, 0, 0, -0.125f, 1 },

                LightRotation = new XMFLOAT4(0.8f, 0.6f, 0.0f, 0),
                ModelRotation = new XMFLOAT4(0.0f, 0.0f, 0.0f, 0),
                ModelTranslation = new XMFLOAT4(0.0f, 0.0f, 4.0f, 0),
                ShadowmapSize = new XMFLOAT4(_shadowmapVP.Width, _shadowmapVP.Height, 0, 0)
            };

            var nativePanel = panel.As<ISwapChainPanelNative>();
            nativePanel.SetSwapChain(_swapChain.Object).ThrowOnError();

            #endregion

            // Initialization for DirectWrite
            RendererDW = new();
            RendererDW.Width = (uint)panel.ActualWidth;
            RendererDW.Height = (uint)panel.ActualHeight;
            RendererDW.InitDirectWrite(_dxgiDevice, _framebufferTexture);

            _disposed = false;
            CompositionTarget.Rendering += Render;
        }

        private void Render(object sender, object e)
        {
            if (_disposed)
                return;

            _rendering = true;
            try
            {
                #region Original Renderer
                _constants.ModelRotation.x += 0.001f;
                _constants.ModelRotation.y += 0.005f;
                _constants.ModelRotation.z += 0.003f;

                _deviceContext.WithMapCopyTo(_constantBuffer, 0, D3D11_MAP.D3D11_MAP_WRITE_DISCARD, _constants);

                _deviceContext.ClearDepthStencilView(_shadowmapDSV, D3D11_CLEAR_FLAG.D3D11_CLEAR_DEPTH, 1.0f, 0);

                _deviceContext.OMSetRenderTargets(null, _shadowmapDSV);
                _deviceContext.OMSetDepthStencilState(_depthStencilState);

                _deviceContext.IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY.D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP);

                _deviceContext.VSSetConstantBuffers(0, new[] { _constantBuffer });
                _deviceContext.VSSetShaderResources(0, new[] { _vertexBufferSRV });
                _deviceContext.VSSetShader(_shadowmapVS);

                _deviceContext.RSSetViewports(new[] { _shadowmapVP });
                _deviceContext.RSSetState(_cullFrontRS);

                _deviceContext.PSSetShader(null);

                _deviceContext.DrawInstanced(8, 24, 0, 0);

                _deviceContext.ClearRenderTargetView(_framebufferRTV, _framebufferClear);
                _deviceContext.ClearDepthStencilView(_framebufferDSV, D3D11_CLEAR_FLAG.D3D11_CLEAR_DEPTH, 1.0f, 0);

                _deviceContext.OMSetRenderTargets(new[] { _framebufferRTV }, _framebufferDSV);

                _deviceContext.VSSetShader(_framebufferVS);

                _deviceContext.RSSetViewports(new[] { _framebufferVP });
                _deviceContext.RSSetState(_cullBackRS);

                _deviceContext.PSSetShaderResources(1, new[] { _shadowmapSRV });
                _deviceContext.PSSetShader(_framebufferPS);

                //_deviceContext.DrawInstanced(8, 24, 0, 0);

                _deviceContext.PSSetShaderResources(1, new IComObject<ID3D11ShaderResourceView>[] { null });
                #endregion
                
                // DirectWrite Renderer
                RendererDW.RenderDirectWrite();

                _swapChain.Present(1, 0);
            }
            finally
            {
                _rendering = false;
            }
        }

        private void Dispose()
        {
            _disposed = true;

            // we want to dispose all objects as a whole
            while (_rendering) { }
            _deviceContext?.Dispose();
            _swapChain?.Dispose();
            _framebufferRTV?.Dispose();
            _framebufferDSV?.Dispose();
            _shadowmapDSV?.Dispose();
            _shadowmapSRV?.Dispose();
            _constantBuffer?.Dispose();
            _vertexBuffer?.Dispose();
            _vertexBufferSRV?.Dispose();
            _depthStencilState?.Dispose();
            _cullBackRS?.Dispose();
            _cullFrontRS?.Dispose();
            _framebufferVS?.Dispose();
            _framebufferPS?.Dispose();
            _shadowmapVS?.Dispose();
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Constants
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public float[] CameraProjection;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public float[] LightProjection;
            public XMFLOAT4 LightRotation;
            public XMFLOAT4 ModelRotation;
            public XMFLOAT4 ModelTranslation;
            public XMFLOAT4 ShadowmapSize;
        };

        // note: this is *not* the same IID as DirectN.ISwapChainPanelNative which corresponds to the Windows.UI.Xaml.Media namespace
        // this one corresponds to the Microsoft.UI.Xaml.Media namespace
        [ComImport, Guid("63aad0b8-7c24-40ff-85a8-640d944cc325"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public partial interface ISwapChainPanelNative
        {
            [PreserveSig]
            HRESULT SetSwapChain(IDXGISwapChain swapChain);
        }
    }
}
