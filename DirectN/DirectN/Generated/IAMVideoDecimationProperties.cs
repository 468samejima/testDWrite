﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\strmif.h(14829,5)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [Guid("60d32930-13da-11d3-9ec6-c4fcaef5c7be"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IAMVideoDecimationProperties
    {
        [PreserveSig]
        HRESULT QueryDecimationUsage(/* [annotation][out] _Out_ */ out _DECIMATION_USAGE lpUsage);
        
        [PreserveSig]
        HRESULT SetDecimationUsage(/* [in] */ _DECIMATION_USAGE Usage);
    }
}
