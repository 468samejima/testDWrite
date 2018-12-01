﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\d2d1_3.h(505,1)
using System;
using System.Runtime.InteropServices;
using D2D1_MATRIX_3X2_F = DirectN.D2D_MATRIX_3X2_F;

namespace DirectN
{
    /// <summary>
    /// Represents a collection of style properties to be used by methods like ID2D1DeviceContext2::DrawInk when rendering ink. The ink style defines the nib (pen tip) shape and transform.
    /// </summary>
    [Guid("bae8b344-23fc-4071-8cb5-d05d6f073848"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface ID2D1InkStyle
    {
        [PreserveSig]
        void SetNibTransform(/* _In_ */ ref D2D1_MATRIX_3X2_F transform);
        
        [PreserveSig]
        void GetNibTransform(/* _Out_ */ out D2D1_MATRIX_3X2_F transform);
        
        [PreserveSig]
        void SetNibShape(D2D1_INK_NIB_SHAPE nibShape);
        
        [PreserveSig]
        D2D1_INK_NIB_SHAPE GetNibShape();
    }
}
