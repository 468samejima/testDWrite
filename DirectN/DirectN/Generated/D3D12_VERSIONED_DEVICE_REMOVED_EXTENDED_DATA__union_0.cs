﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\d3d12.h(13134,5)
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct D3D12_VERSIONED_DEVICE_REMOVED_EXTENDED_DATA__union_0
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] __bits;
        public D3D12_DEVICE_REMOVED_EXTENDED_DATA Dred_1_0 => InteropRuntime.Get<D3D12_DEVICE_REMOVED_EXTENDED_DATA>(__bits, 0, 128);
    }
}