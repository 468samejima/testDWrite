﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\d3d12.h(14588,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct D3D12_PROTECTED_RESOURCE_SESSION_DESC1
    {
        public uint NodeMask;
        public D3D12_PROTECTED_RESOURCE_SESSION_FLAGS Flags;
        public Guid ProtectionType;
    }
}
