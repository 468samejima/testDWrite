﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\mediaobj.h(284,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct _DMO_OUTPUT_DATA_BUFFER
    {
        public IntPtr pBuffer;
        public uint dwStatus;
        public long rtTimestamp;
        public long rtTimelength;
    }
}
