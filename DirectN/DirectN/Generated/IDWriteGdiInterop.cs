﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\dwrite.h(4540,1)
using System;
using System.Runtime.InteropServices;
using LOGFONTW = DirectN.tagLOGFONTW;

namespace DirectN
{
    /// <summary>
    /// The GDI interop interface provides interoperability with GDI.
    /// </summary>
    [Guid("1edd9491-9853-4299-898f-6432983b6f3a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IDWriteGdiInterop
    {
        [PreserveSig]
        HRESULT CreateFontFromLOGFONT(/* _In_ */ ref LOGFONTW logFont, /* _COM_Outptr_ */ out IDWriteFont font);
        
        [PreserveSig]
        HRESULT ConvertFontToLOGFONT(/* _In_ */ IDWriteFont font, /* _Out_ */ out LOGFONTW logFont, /* _Out_ */ out bool isSystemFont);
        
        [PreserveSig]
        HRESULT ConvertFontFaceToLOGFONT(/* _In_ */ IDWriteFontFace font, /* _Out_ */ out LOGFONTW logFont);
        
        [PreserveSig]
        HRESULT CreateFontFaceFromHdc(ref IntPtr hdc, /* _COM_Outptr_ */ out IDWriteFontFace fontFace);
        
        [PreserveSig]
        HRESULT CreateBitmapRenderTarget(/* optional(HDC) */ IntPtr hdc, uint width, uint height, /* _COM_Outptr_ */ out IDWriteBitmapRenderTarget renderTarget);
    }
}
