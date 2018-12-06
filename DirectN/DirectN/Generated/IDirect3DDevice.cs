﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\d3d.h(394,1)
using System;
using System.Runtime.InteropServices;
using LPD3DMATRIX = DirectN._D3DMATRIX;
using LPDIRECT3DEXECUTEBUFFER = DirectN.IDirect3DExecuteBuffer;
using LPDIRECT3DTEXTURE = DirectN.IDirect3DTexture;
using LPDIRECT3DVIEWPORT = DirectN.IDirect3DViewport;

namespace DirectN
{
    [Guid("a37624ab-8d5f-4650-9d3e-9eae3d9bc670"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IDirect3DDevice
    {
        [PreserveSig]
        HRESULT Initialize(ref IDirect3D __unnamed_0, [MarshalAs(UnmanagedType.LPStruct)] Guid __unnamed_1, ref _D3DDeviceDesc __unnamed_2);
        
        [PreserveSig]
        HRESULT GetCaps(ref _D3DDeviceDesc __unnamed_0, ref _D3DDeviceDesc __unnamed_1);
        
        [PreserveSig]
        HRESULT SwapTextureHandles(ref LPDIRECT3DTEXTURE __unnamed_0, ref LPDIRECT3DTEXTURE __unnamed_1);
        
        [PreserveSig]
        HRESULT CreateExecuteBuffer(ref _D3DExecuteBufferDesc __unnamed_0, ref LPDIRECT3DEXECUTEBUFFER __unnamed_1, [MarshalAs(UnmanagedType.IUnknown)] object __unnamed_2);
        
        [PreserveSig]
        HRESULT GetStats(ref _D3DSTATS __unnamed_0);
        
        [PreserveSig]
        HRESULT Execute(ref LPDIRECT3DEXECUTEBUFFER __unnamed_0, ref LPDIRECT3DVIEWPORT __unnamed_1, uint __unnamed_2);
        
        [PreserveSig]
        HRESULT AddViewport(ref LPDIRECT3DVIEWPORT __unnamed_0);
        
        [PreserveSig]
        HRESULT DeleteViewport(ref LPDIRECT3DVIEWPORT __unnamed_0);
        
        [PreserveSig]
        HRESULT NextViewport(ref LPDIRECT3DVIEWPORT __unnamed_0, ref LPDIRECT3DVIEWPORT __unnamed_1, uint __unnamed_2);
        
        [PreserveSig]
        HRESULT Pick(ref LPDIRECT3DEXECUTEBUFFER __unnamed_0, ref LPDIRECT3DVIEWPORT __unnamed_1, uint __unnamed_2, ref _D3DRECT __unnamed_3);
        
        [PreserveSig]
        HRESULT GetPickRecords(ref uint __unnamed_0, ref _D3DPICKRECORD __unnamed_1);
        
        [PreserveSig]
        HRESULT EnumTextureFormats(ref IntPtr __unnamed_0, ref IntPtr __unnamed_1);
        
        [PreserveSig]
        HRESULT CreateMatrix(ref uint __unnamed_0);
        
        [PreserveSig]
        HRESULT SetMatrix(uint __unnamed_0, ref LPD3DMATRIX __unnamed_1);
        
        [PreserveSig]
        HRESULT GetMatrix(uint __unnamed_0, ref _D3DMATRIX __unnamed_1);
        
        [PreserveSig]
        HRESULT DeleteMatrix(uint __unnamed_0);
        
        [PreserveSig]
        HRESULT BeginScene();
        
        [PreserveSig]
        HRESULT EndScene();
        
        [PreserveSig]
        HRESULT GetDirect3D(ref IDirect3D __unnamed_0);
    }
}