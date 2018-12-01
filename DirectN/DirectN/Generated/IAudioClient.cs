﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\audioclient.h(203,5)
using System;
using System.Runtime.InteropServices;
using REFERENCE_TIME = System.Int64;
using WAVEFORMATEX = DirectN.tWAVEFORMATEX;

namespace DirectN
{
    [Guid("1cb9ad4c-dbfa-4c32-b178-c2f568a703b2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IAudioClient
    {
        [PreserveSig]
        HRESULT Initialize(/* [annotation][in] _In_ */ _AUDCLNT_SHAREMODE ShareMode, /* [annotation][in] _In_ */ uint StreamFlags, /* [annotation][in] _In_ */ long hnsBufferDuration, /* [annotation][in] _In_ */ long hnsPeriodicity, /* [annotation][in] _In_ */ ref WAVEFORMATEX pFormat, /* [annotation][in] _In_opt_ */ [MarshalAs(UnmanagedType.LPStruct)] Guid AudioSessionGuid);
        
        [PreserveSig]
        HRESULT GetBufferSize(/* [annotation][out] _Out_ */ out uint pNumBufferFrames);
        
        [PreserveSig]
        HRESULT GetStreamLatency(/* [annotation][out] _Out_ */ out REFERENCE_TIME phnsLatency);
        
        [PreserveSig]
        HRESULT GetCurrentPadding(/* [annotation][out] _Out_ */ out uint pNumPaddingFrames);
        
        [PreserveSig]
        HRESULT IsFormatSupported(/* [annotation][in] _In_ */ _AUDCLNT_SHAREMODE ShareMode, /* [annotation][in] _In_ */ ref WAVEFORMATEX pFormat, /* optional(WAVEFORMATEX) */ out IntPtr ppClosestMatch);
        
        [PreserveSig]
        HRESULT GetMixFormat(/* [annotation][out] _Out_ */ out IntPtr ppDeviceFormat);
        
        [PreserveSig]
        HRESULT GetDevicePeriod(/* [annotation][out] _Out_opt_ */ out REFERENCE_TIME phnsDefaultDevicePeriod, /* [annotation][out] _Out_opt_ */ out REFERENCE_TIME phnsMinimumDevicePeriod);
        
        [PreserveSig]
        HRESULT Start();
        
        [PreserveSig]
        HRESULT Stop();
        
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT SetEventHandle(/* [in] */ IntPtr eventHandle);
        
        [PreserveSig]
        HRESULT GetService(/* [annotation][in] _In_ */ [MarshalAs(UnmanagedType.LPStruct)] Guid riid, /* [annotation][iid_is][out] _Out_ */ [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
    }
}
