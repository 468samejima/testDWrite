using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using WinRT;

namespace DirectN.WinUI3.testDWrite
{
    internal class RendererDirectWrite
    {
        private float m_width;
        public float Width { get => m_width; set => m_width = value; }
        private float m_height;
        public float Height { get => m_height; set => m_height = value; }

        private IComObject<IDWriteFactory> m_DWriteFactory = null;
        private IComObject<ID2D1Factory3> m_d2dFactory = null;
        private IComObject<IDXGIDevice1> m_dxgiDevice = null;
        private IComObject<ID2D1Device> m_d2dDevice = null;
        private IComObject<ID2D1DeviceContext> m_d2dDeviceContext = null;
        private IComObject<IDXGISurface> m_dxgiSurface = null;

        private double m_orgX = 0.0;
        public double OrgX { get => m_orgX; set => m_orgX = value; }
        private double m_orgY = 0.0;
        public double OrgY { get => m_orgY; set => m_orgY = value; }

        public DWStrings StrData;

        public double ViewScale = 1;

        public RendererDirectWrite()
        {
            DWString str = new()
            {
                Str = "testTEXT",
                Height = 62,
                FontColor = Windows.UI.Color.FromArgb(255, 255, 255, 255)
            };

            StrData = [str];
        }

        /// <summary>
        /// Initialize DirectWriteFunction
        /// </summary>
        public void InitDirectWrite(IComObject<IDXGIDevice1> _dxgiDevice, IComObject<ID3D11Texture2D> _texture2d)
        {
            m_dxgiDevice = _dxgiDevice;
            m_DWriteFactory = DWriteFunctions.DWriteCreateFactory(DWRITE_FACTORY_TYPE.DWRITE_FACTORY_TYPE_SHARED);
            m_d2dFactory = D2D1Functions.D2D1CreateFactory<ID2D1Factory3>(D2D1_FACTORY_TYPE.D2D1_FACTORY_TYPE_SINGLE_THREADED);
            m_d2dDevice = m_d2dFactory.CreateDevice<ID2D1Device>(m_dxgiDevice);
            m_d2dDeviceContext = m_d2dDevice.CreateDeviceContext(D2D1_DEVICE_CONTEXT_OPTIONS.D2D1_DEVICE_CONTEXT_OPTIONS_NONE);
            m_dxgiSurface = _texture2d.AsComObject<IDXGISurface>();

            CreateBitmap();
        }

        public void ReleaseDWResources()
        {
            if (m_d2dBitmap != null)
            {
                m_d2dBitmap.Dispose();
                m_d2dBitmap = null;
            }
            if (m_dxgiSurface != null)
            {
                m_dxgiSurface.Dispose();
                m_dxgiSurface = null;
            }
            if (m_d2dDeviceContext != null)
            {
                m_d2dDeviceContext.Dispose();
                m_d2dDeviceContext = null;
            }
            if (m_d2dDevice != null)
            {
                m_d2dDevice.Dispose();
                m_d2dDevice = null;
            }
        }

        public void ResizeDirectWriteResources(IComObject<ID3D11Texture2D> _texture2d)
        {
            m_d2dDevice = m_d2dFactory.CreateDevice<ID2D1Device>(m_dxgiDevice);
            m_d2dDeviceContext = m_d2dDevice.CreateDeviceContext(D2D1_DEVICE_CONTEXT_OPTIONS.D2D1_DEVICE_CONTEXT_OPTIONS_NONE);
            m_dxgiSurface = _texture2d.AsComObject<IDXGISurface>();
            CreateBitmap();
        }

        private void CreateBitmap()
        {
            //特に意味のあることはしていない↓
            D2D1_COLOR_SPACE colSpace = D2D1_COLOR_SPACE.D2D1_COLOR_SPACE_SRGB;
            IComObject<ID2D1ColorContext> cCon
                = ID2D1DeviceContextExtensions.CreateColorContext
                    (m_d2dDeviceContext, colSpace);
            //ここまで

            // 描画先 Bitmap 取得    attention
            D2D1_BITMAP_PROPERTIES1 bitmapProps = new D2D1_BITMAP_PROPERTIES1()
            {
                pixelFormat = new()
                {
                    format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,
                    alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_PREMULTIPLIED
                },
                dpiX = 96.0f, // 解像度 Dots Per Inch
                dpiY = 96.0f,
                bitmapOptions = D2D1_BITMAP_OPTIONS.D2D1_BITMAP_OPTIONS_TARGET | D2D1_BITMAP_OPTIONS.D2D1_BITMAP_OPTIONS_CANNOT_DRAW,
                colorContext = cCon.GetInterfacePointer<ID2D1ColorContext>()    //←別に0で良い
            };

            m_d2dBitmap = m_d2dDeviceContext.CreateBitmapFromDxgiSurface(m_dxgiSurface, bitmapProps);
        }

        private IComObject<ID2D1Bitmap1> m_d2dBitmap;
        public void RenderDirectWrite()
        {
            foreach (var str in StrData)
            {
                DrawText(str);
            }
        }
        private void DrawText(DWString str)
        {
            var height = GetViewHeight(str.Height);
            var fontstyle = DWRITE_FONT_STYLE.DWRITE_FONT_STYLE_NORMAL;
            if (str.IsItalic) fontstyle = DWRITE_FONT_STYLE.DWRITE_FONT_STYLE_ITALIC;
            // string localeName = null
            
            // テキストフォーマットの作成
            IComObject<IDWriteTextFormat> format = m_DWriteFactory.CreateTextFormat
                (
                    str.FontFace,
                    height,
                    null,           // IDWriteFontCollection NULLの場合、システムフォントコレクションを示す
                    str.FontWeight, // DWRITE_FONT_WEIGHT
                    fontstyle       // DWRITE_FONT_STYLE
                );

            // 描画矩形の取得
            D2D_RECT_F rect = GetRect(str, height, ref format);

            SetRotation(str, rect);
 
            // Color
            var d3dColor = new _D3DCOLORVALUE()
            {
                r = str.FontColor.R / 255.0f,
                g = str.FontColor.G / 255.0f,
                b = str.FontColor.B / 255.0f,
                a = str.FontColor.A / 255.0f
            };
            var brush = m_d2dDeviceContext.CreateSolidColorBrush(d3dColor);

            m_d2dDeviceContext.BeginDraw();
            m_d2dDeviceContext.SetTarget(m_d2dBitmap);
            
            //m_d2dDeviceContext.DrawRectangle(rect, backbrush);
            
            m_d2dDeviceContext.DrawText(
                str.Str,
                format,
                rect,
                brush,
                D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_ENABLE_COLOR_FONT
            );
            m_d2dDeviceContext.EndDraw();
        }
        private float GetViewHeight(float height) => (float)(height / ViewScale);

        private D2D_RECT_F GetRect(DWString str, float height, ref IComObject<IDWriteTextFormat> format)
        {
            // レイアウトの作成 IComObject<IDWriteTextLayout>
            var layout = m_DWriteFactory.CreateTextLayout(
                    format,
                    str.Str,
                    str.Str.Length
                );

            DWRITE_TEXT_METRICS1 metrics = layout.GetMetrics1();
            // Widthの取得
            float textWidth = metrics.width;

            // baselineの取得
            float over = 0*(metrics.height - height) / 2;

            // Anchor
            SetAnchor(textWidth, height, str.Anchor, out float shiftX, out float shiftY);

            // 文字起点の作成
            //float posx = str.Pos.X - shiftX;
            //float posy = str.Pos.Y - shiftY;
            //D2D_POINT_2F pos = GetDWPos(posx, posy, height);
            D2D_POINT_2F pos = GetDWPos(str.Pos.X, str.Pos.Y, height);

            // 矩形の設定
            D2D_RECT_F rect = new()
            {
                left = pos.x,
                top = pos.y - over,
                right = pos.x + textWidth + 1,
                bottom = pos.y + height - over,
            };
            return rect;
        }
        private void SetAnchor(float width, float height, int Align, out float shiftX, out float shiftY)
        {
            shiftX = 0; shiftY = 0;
            switch (Align)
            {
                case 0:
                    shiftX += 0;
                    shiftY += 0;
                    break;
                case 1:
                    shiftX += width / 2;
                    shiftY += 0;
                    break;
                case 2:
                    shiftX += width;
                    shiftY += 0;
                    break;
                case 3:
                    shiftX += 0;
                    shiftY += height / 2;
                    break;
                case 4:
                    shiftX += width / 2;
                    shiftY += height / 2;
                    break;
                case 5:
                    shiftX += width;
                    shiftY += height / 2;
                    break;
                case 6:
                    shiftX += 0;
                    shiftY += height;
                    break;
                case 7:
                    shiftX += width / 2;
                    shiftY += height;
                    break;
                case 8:
                    shiftX += width;
                    shiftY += height;
                    break;
                default:
                    break;
            }
            shiftX *= (float)ViewScale;
            shiftY *= (float)ViewScale;
        }
        /// <summary>
        /// 文字起点の取得
        /// </summary>
        private D2D_POINT_2F GetDWPos(float _x, float _y, float height)
        {
            var x = (_x + m_orgX) / (float)ViewScale + m_width / 2;
            var y = m_height / 2 - (_y + m_orgY) / (float)ViewScale - height;
            return new(x, y);
        }

        private void SetRotation(DWString str, D2D_RECT_F rect)
        {
            Vector2 pos = new();
            float top = rect.top;
            float bottom = rect.bottom;
            float vertMid = (top + bottom) / 2;
            float left = rect.left;
            float right = rect.right;
            float horzMid = (left + right) / 2;
            switch (str.Anchor)
            {
                    // 下段
                case 0:
                    pos = new(left, bottom);
                    break;
                case 1:
                    pos = new(horzMid, bottom);
                    break;
                case 2:
                    pos = new(right, bottom);
                    break;
                    // 中段
                case 3:
                    pos = new(left, vertMid);
                    break;
                case 4:
                    pos = new(horzMid, vertMid);
                    break;
                case 5:
                    pos = new(right, vertMid);
                    break;
                    // 上段
                case 6:
                    pos = new(left, top);
                    break;
                case 7:
                    pos = new(horzMid, top);
                    break;
                case 8:
                    pos = new(right, top);
                    break;
                default:
                    break;
            }
            // 回転の設定
            D2D_MATRIX_3X2_F matrix = D2D_MATRIX_3X2_F.Rotation(str.Ang, pos.X, pos.Y);
            m_d2dDeviceContext.Object.SetTransform(matrix);
        }

    }
}
