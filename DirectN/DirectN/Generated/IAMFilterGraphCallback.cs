﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\strmif.h(16887,1)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [Guid("56a868fd-0ad4-11ce-b0a3-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IAMFilterGraphCallback
    {
        [PreserveSig]
        HRESULT UnableToRender(IPin pPin);
    }
}
