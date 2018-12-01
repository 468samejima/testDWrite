﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\shared\dxgi1_2.h(1209,9)
using System;
using System.Runtime.InteropServices;
using POINT = DirectN.tagPOINT;
using RECT = DirectN.tagRECT;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DXGI_PRESENT_PARAMETERS
    {
        public uint DirtyRectsCount;
        public IntPtr pDirtyRects;
        public IntPtr pScrollRect;
        public IntPtr pScrollOffset;
    }
}
