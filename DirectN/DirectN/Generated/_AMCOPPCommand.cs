﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\strmif.h(17413,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct _AMCOPPCommand
    {
        public Guid macKDI;
        public Guid guidCommandID;
        public uint dwSequence;
        public uint cbSizeData;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4056)] 
        public byte CommandData;
    }
}
