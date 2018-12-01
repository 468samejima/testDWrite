﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\d2d1.h(307,9)
using System;
using System.Runtime.InteropServices;
using D2D1_COLOR_F = DirectN._D3DCOLORVALUE;

namespace DirectN
{
    /// <summary>
    /// Contains the position and color of a gradient stop.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct D2D1_GRADIENT_STOP
    {
        public float position;
        public D2D1_COLOR_F color;
    }
}
