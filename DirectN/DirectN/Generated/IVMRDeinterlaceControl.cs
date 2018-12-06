﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\strmif.h(19890,5)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [Guid("bb057577-0db8-4e6a-87a7-1a8c9a505a0f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IVMRDeinterlaceControl
    {
        [PreserveSig]
        HRESULT GetNumberOfDeinterlaceModes(/* [in] */ ref _VMRVideoDesc lpVideoDescription, /* [out][in] */ ref uint lpdwNumDeinterlaceModes, /* [out] */ out Guid lpDeinterlaceModes);
        
        [PreserveSig]
        HRESULT GetDeinterlaceModeCaps(/* [in] */ [MarshalAs(UnmanagedType.LPStruct)] Guid lpDeinterlaceMode, /* [in] */ ref _VMRVideoDesc lpVideoDescription, /* [out][in] */ ref _VMRDeinterlaceCaps lpDeinterlaceCaps);
        
        [PreserveSig]
        HRESULT GetDeinterlaceMode(/* [in] */ uint dwStreamID, /* [out] */ out Guid lpDeinterlaceMode);
        
        [PreserveSig]
        HRESULT SetDeinterlaceMode(/* [in] */ uint dwStreamID, /* [in] */ [MarshalAs(UnmanagedType.LPStruct)] Guid lpDeinterlaceMode);
        
        [PreserveSig]
        HRESULT GetDeinterlacePrefs(/* [out] */ out uint lpdwDeinterlacePrefs);
        
        [PreserveSig]
        HRESULT SetDeinterlacePrefs(/* [in] */ uint dwDeinterlacePrefs);
        
        [PreserveSig]
        HRESULT GetActualDeinterlaceMode(/* [in] */ uint dwStreamID, /* [out] */ out Guid lpDeinterlaceMode);
    }
}