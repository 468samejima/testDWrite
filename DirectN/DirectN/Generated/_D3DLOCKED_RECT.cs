﻿// c:\program files (x86)\windows kits\10\include\10.0.22621.0\shared\d3d9types.h(1760,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public partial struct _D3DLOCKED_RECT_32
    {
        public int Pitch;
        public IntPtr pBits;
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct _D3DLOCKED_RECT_64
    {
        public int Pitch;
        public IntPtr pBits;
    }
}
