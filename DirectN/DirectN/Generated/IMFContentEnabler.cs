﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\mfidl.h(7378,5)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [Guid("d3c4ef59-49ce-4381-9071-d5bcd044c770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IMFContentEnabler
    {
        [PreserveSig]
        HRESULT GetEnableType(/* [out] __RPC__out */ out Guid pType);
        
        [PreserveSig]
        HRESULT GetEnableURL(/* optional(LPWSTR) */ IntPtr ppwszURL, /* [out] __RPC__out */ out uint pcchURL, /* [unique][out][in] __RPC__inout_opt */ ref __MIDL___MIDL_itf_mfidl_0000_0032_0001 pTrustStatus);
        
        [PreserveSig]
        HRESULT GetEnableData(/* optional(BYTE) */ out IntPtr ppbData, /* [out] __RPC__out */ out uint pcbData);
        
        [PreserveSig]
        HRESULT IsAutomaticSupported(/* [out] __RPC__out */ out bool pfAutomatic);
        
        [PreserveSig]
        HRESULT AutomaticEnable();
        
        [PreserveSig]
        HRESULT MonitorEnable();
        
        [PreserveSig]
        HRESULT Cancel();
    }
}
