﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\dxva9typ.h(896,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct _DXVA_COPPStatusData
    {
        public Guid rApp;
        public uint dwFlags;
        public uint dwData;
        public uint ExtendedInfoValidMask;
        public uint ExtendedInfoData;
    }
}
