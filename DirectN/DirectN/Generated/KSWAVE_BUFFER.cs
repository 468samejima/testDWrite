﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\shared\ksmedia.h(2627,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct KSWAVE_BUFFER
    {
        public uint Attributes;
        public uint BufferSize;
        public IntPtr BufferAddress;
    }
}
