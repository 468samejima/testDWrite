﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\d3d10.h(2612,5)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [Guid("c902b03f-60a7-49ba-9936-2a3ab37a7e33"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface ID3D10View : ID3D10DeviceChild
    {
        // ID3D10DeviceChild
        [PreserveSig]
        new void GetDevice(/* [annotation] _Out_ */ out ID3D10Device ppDevice);
        
        [PreserveSig]
        new HRESULT GetPrivateData(/* [annotation] _In_ */ [MarshalAs(UnmanagedType.LPStruct)] Guid guid, /* [annotation] _Inout_ */ ref uint pDataSize, /* [annotation] _Out_writes_bytes_opt_(*pDataSize) */ [MarshalAs(UnmanagedType.IUnknown)] out object pData);
        
        [PreserveSig]
        new HRESULT SetPrivateData(/* [annotation] _In_ */ [MarshalAs(UnmanagedType.LPStruct)] Guid guid, /* [annotation] _In_ */ uint DataSize, /* [annotation] _In_reads_bytes_opt_(DataSize) */ [MarshalAs(UnmanagedType.IUnknown)] object pData);
        
        [PreserveSig]
        new HRESULT SetPrivateDataInterface(/* [annotation] _In_ */ [MarshalAs(UnmanagedType.LPStruct)] Guid guid, /* [annotation] _In_opt_ */ [MarshalAs(UnmanagedType.IUnknown)] object pData);
        
        // ID3D10View
        [PreserveSig]
        void GetResource(/* [annotation] _Out_ */ out ID3D10Resource ppResource);
    }
}
