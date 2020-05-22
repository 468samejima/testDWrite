﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\d3d11.h(6436,5)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [Guid("9eb576dd-9f77-4d86-81aa-8bab5fe490e2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface ID3D11Predicate : ID3D11Query
    {
        // ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(/* [annotation] _Outptr_ */ out ID3D11Device ppDevice);
        
        [PreserveSig]
        new HRESULT GetPrivateData(/* [annotation] _In_ */ [MarshalAs(UnmanagedType.LPStruct)] Guid guid, /* [annotation] _Inout_ */ ref uint pDataSize, /* optional(void) */ IntPtr pData);
        
        [PreserveSig]
        new HRESULT SetPrivateData(/* [annotation] _In_ */ [MarshalAs(UnmanagedType.LPStruct)] Guid guid, /* [annotation] _In_ */ uint DataSize, /* optional(void) */ IntPtr pData);
        
        [PreserveSig]
        new HRESULT SetPrivateDataInterface(/* [annotation] _In_ */ [MarshalAs(UnmanagedType.LPStruct)] Guid guid, /* optional(IUnknown) */ IntPtr pData);
        
        // ID3D11Asynchronous
        [PreserveSig]
        new uint GetDataSize();
        
        // ID3D11Query
        [PreserveSig]
        new void GetDesc(/* [annotation] _Out_ */ out D3D11_QUERY_DESC pDesc);
        
        // ID3D11Predicate
    }
}
