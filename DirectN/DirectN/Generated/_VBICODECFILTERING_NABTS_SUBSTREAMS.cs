﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\shared\ksmedia.h(4566,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct _VBICODECFILTERING_NABTS_SUBSTREAMS
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] 
        public uint[] SubstreamMask;
    }
}
