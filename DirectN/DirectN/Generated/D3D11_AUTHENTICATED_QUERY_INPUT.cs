﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\d3d11.h(10798,9)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct D3D11_AUTHENTICATED_QUERY_INPUT
    {
        public Guid QueryType;
        public IntPtr hChannel;
        public uint SequenceNumber;
    }
}