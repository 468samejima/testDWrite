﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\mfidl.h(7601,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct _ASFFlatSynchronisedLyrics
    {
        public byte bTimeStampFormat;
        public byte bContentType;
        public uint dwLyricsLen;
    }
}
