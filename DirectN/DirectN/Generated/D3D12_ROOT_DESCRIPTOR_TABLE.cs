﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\d3d12.h(3406,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct D3D12_ROOT_DESCRIPTOR_TABLE
    {
        public uint NumDescriptorRanges;
        public IntPtr pDescriptorRanges;
    }
}
