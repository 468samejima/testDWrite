﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\shared\ksmedia.h(7536,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct KSVPMAXPIXELRATE
    {
        public tagKS_AMVPSIZE Size;
        public uint MaxPixelsPerSecond;
        public uint Reserved;
    }
}
