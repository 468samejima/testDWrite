﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\ocidl.h(3238,5)
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using LPCRECT = DirectN.tagRECT;
using OLE_XSIZE_HIMETRIC = System.Int32;
using OLE_YSIZE_HIMETRIC = System.Int32;

namespace DirectN
{
    [Guid("7bf80980-bf32-101a-8bbb-00aa00300cab"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IPicture
    {
        [PreserveSig]
        HRESULT get_Handle(/* [out] __RPC__out */ out IntPtr pHandle);
        
        [PreserveSig]
        HRESULT get_hPal(/* [out] __RPC__out */ out IntPtr phPal);
        
        [PreserveSig]
        HRESULT get_Type(/* [out] __RPC__out */ out short pType);
        
        [PreserveSig]
        HRESULT get_Width(/* [out] __RPC__out */ out OLE_XSIZE_HIMETRIC pWidth);
        
        [PreserveSig]
        HRESULT get_Height(/* [out] __RPC__out */ out OLE_YSIZE_HIMETRIC pHeight);
        
        [PreserveSig]
        HRESULT Render(/* [in] __RPC__in */ IntPtr hDC, /* [in] */ int x, /* [in] */ int y, /* [in] */ int cx, /* [in] */ int cy, /* [in] */ int xSrc, /* [in] */ int ySrc, /* [in] */ int cxSrc, /* [in] */ int cySrc, /* [in] __RPC__in */ ref LPCRECT pRcWBounds);
        
        [PreserveSig]
        HRESULT set_hPal(/* [in] */ IntPtr hPal);
        
        [PreserveSig]
        HRESULT get_CurDC(/* optional(HDC) */ out IntPtr phDC);
        
        [PreserveSig]
        HRESULT SelectPicture(/* [in] __RPC__in */ IntPtr hDCIn, /* optional(HDC) */ out IntPtr phDCOut, /* [out] __RPC__out */ out IntPtr phBmpOut);
        
        [PreserveSig]
        HRESULT get_KeepOriginalFormat(/* [out] __RPC__out */ out bool pKeep);
        
        [PreserveSig]
        HRESULT put_KeepOriginalFormat(/* [in] */ bool keep);
        
        [PreserveSig]
        HRESULT PictureChanged();
        
        [PreserveSig]
        HRESULT SaveAsFile(/* [in] __RPC__in_opt */ IStream pStream, /* [in] */ bool fSaveMemCopy, /* [out] __RPC__out */ out int pCbSize);
        
        [PreserveSig]
        HRESULT get_Attributes(/* [out] __RPC__out */ out uint pDwAttr);
    }
}
