﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\d3dnthal.h(280,5)
using System;
using System.Runtime.InteropServices;
using PDD_SURFACE_LOCAL = DirectN._DD_SURFACE_LOCAL;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct _D3DNTHAL_CONTEXTCREATEDATA__union_1
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] __bits;
        public IntPtr lpDDS => InteropRuntime.GetBits<IntPtr>(__bits, 0, 64);
        public IntPtr lpDDSLcl => InteropRuntime.GetBits<IntPtr>(__bits, 0, 64);
    }
}
