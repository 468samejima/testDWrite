﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\d3dnthal.h(663,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct _D3DNTHAL_DP2INDEXEDLINESTRIP
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] 
        public ushort[] wV;
    }
}
