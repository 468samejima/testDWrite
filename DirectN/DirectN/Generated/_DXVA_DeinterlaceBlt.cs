﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\dxva9typ.h(584,9)
using System;
using System.Runtime.InteropServices;
using RECT = DirectN.tagRECT;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct _DXVA_DeinterlaceBlt
    {
        public uint Size;
        public uint Reserved;
        public long rtTarget;
        public RECT DstRect;
        public RECT SrcRect;
        public uint NumSourceSurfaces;
        public float Alpha;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] 
        public _DXVA_VideoSample[] Source;
    }
}