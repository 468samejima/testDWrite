﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\dxgiddi.h(862,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DXGIDDI_MULTIPLANE_OVERLAY_ALLOCATION_INFO
    {
        public int PresentAllocation;
        public uint SubResourceIndex;
    }
}
