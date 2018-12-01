﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\spatialaudiometadata.h(315,5)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [Guid("1b17ca01-2955-444d-a430-537dc589a844"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface ISpatialAudioMetadataWriter
    {
        [PreserveSig]
        HRESULT Open(/* [annotation][in] _In_ */ ISpatialAudioMetadataItems metadataItems);
        
        [PreserveSig]
        HRESULT WriteNextItem(/* [annotation][in] _In_ */ ushort frameOffset);
        
        [PreserveSig]
        HRESULT WriteNextItemCommand(/* [annotation][in] _In_ */ byte commandID, /* [annotation][size_is][in] _In_reads_bytes_opt_(valueBufferLength) */ [MarshalAs(UnmanagedType.IUnknown)] object valueBuffer, /* [annotation][in] _In_ */ uint valueBufferLength);
        
        [PreserveSig]
        HRESULT Close();
    }
}
