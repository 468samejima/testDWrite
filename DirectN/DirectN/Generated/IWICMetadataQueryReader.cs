﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\wincodec.h(3032,5)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [Guid("30989668-e1c9-4597-b395-458eedb808df"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IWICMetadataQueryReader
    {
        [PreserveSig]
        HRESULT GetContainerFormat(/* [out] __RPC__out */ out Guid pguidContainerFormat);
        
        [PreserveSig]
        HRESULT GetLocation(/* [in] */ uint cchMaxLength, /* [size_is][unique][out][in] __RPC__inout_ecount_full_opt(cchMaxLength) */ [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] char[] wzNamespace, /* [out] __RPC__out */ out uint pcchActualLength);
        
        [PreserveSig]
        HRESULT GetMetadataByName(/* [in] __RPC__in */ [MarshalAs(UnmanagedType.LPWStr)] string wzName, /* [unique][out][in] __RPC__inout_opt */ PropVariant pvarValue);
        
        [PreserveSig]
        HRESULT GetEnumerator(/* optional(IEnumString) */ out IntPtr ppIEnumString);
    }
}
