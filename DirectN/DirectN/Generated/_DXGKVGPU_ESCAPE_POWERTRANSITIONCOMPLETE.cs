﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\shared\d3dukmdt.h(189,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct _DXGKVGPU_ESCAPE_POWERTRANSITIONCOMPLETE
    {
        public _DXGKVGPU_ESCAPE_HEAD Header;
        public uint PowerState;
    }
}
