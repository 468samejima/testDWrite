﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\dxgiddi.h(312,9)
using System;

namespace DirectN
{
    [Flags]
    public enum DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS
    {
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_ROTATION_WITHOUT_INDEPENDENT_FLIP = 0x00000001,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_VERTICAL_FLIP = 0x00000002,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_HORIZONTAL_FLIP = 0x00000004,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_DEINTERLACE = 0x00000008,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_STEREO = 0x00000010,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_RGB = 0x00000020,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_YUV = 0x00000040,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_BILINEAR_FILTER = 0x00000080,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_HIGH_FILTER = 0x00000100,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_ROTATION = 0x00000200,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_FULLSCREEN_POST_COMPOSITION = 0x00000400,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_RESERVED1 = 0x00000800,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_SHARED = 0x00001000,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_IMMEDIATE = 0x00002000,
        DXGI_DDI_MULTIPLANE_OVERLAY_FEATURE_CAPS_PLANE0_FOR_VIRTUAL_MODE_ONLY = 0x00004000,
    }
}
