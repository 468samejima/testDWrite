﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\audiopolicy.h(1105,5)
using System;
using System.Runtime.InteropServices;

namespace DirectN
{
    [Guid("77aa99a0-1bd6-484f-8bc7-2c654c9a9b6f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IAudioSessionManager2 : IAudioSessionManager
    {
        // IAudioSessionManager
        [PreserveSig]
        new HRESULT GetAudioSessionControl(/* [annotation][in] _In_opt_ */ [MarshalAs(UnmanagedType.LPStruct)] Guid AudioSessionGuid, /* [annotation][in] _In_ */ uint StreamFlags, /* [annotation][out] _Outptr_ */ out IAudioSessionControl SessionControl);
        
        [PreserveSig]
        new HRESULT GetSimpleAudioVolume(/* [annotation][in] _In_opt_ */ [MarshalAs(UnmanagedType.LPStruct)] Guid AudioSessionGuid, /* [annotation][in] _In_ */ uint StreamFlags, /* [annotation][out] _Outptr_ */ out ISimpleAudioVolume AudioVolume);
        
        // IAudioSessionManager2
        [PreserveSig]
        HRESULT GetSessionEnumerator(/* [retval][out] */ out IAudioSessionEnumerator SessionEnum);
        
        [PreserveSig]
        HRESULT RegisterSessionNotification(ref IAudioSessionNotification SessionNotification);
        
        [PreserveSig]
        HRESULT UnregisterSessionNotification(ref IAudioSessionNotification SessionNotification);
        
        [PreserveSig]
        HRESULT RegisterDuckNotification(/* [string][in] */ [MarshalAs(UnmanagedType.LPWStr)] string sessionID, /* [annotation][in] _In_ */ IAudioVolumeDuckNotification duckNotification);
        
        [PreserveSig]
        HRESULT UnregisterDuckNotification(/* [annotation][in] _In_ */ IAudioVolumeDuckNotification duckNotification);
    }
}