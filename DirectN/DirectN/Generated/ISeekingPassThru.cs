﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\strmif.h(8646,5)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [Guid("36b73883-c2c8-11cf-8b46-00805f6cef60"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface ISeekingPassThru
    {
        [PreserveSig]
        HRESULT Init(/* [in] */ bool bSupportRendering, /* [in] */ IPin pPin);
    }
}
