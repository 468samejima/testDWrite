﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\d2d1svg.h(1683,1)
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using D2D1_COLOR_F = DirectN._D3DCOLORVALUE;
using D2D1_POINT_2F = DirectN.D2D_POINT_2F;
using D2D1_SIZE_F = DirectN.D2D_SIZE_F;

namespace DirectN
{
    [Guid("86b88e4d-afa4-4d7b-88e4-68a51c4a0aec"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface ID2D1SvgDocument
    {
        [PreserveSig]
        HRESULT SetViewportSize(D2D1_SIZE_F viewportSize);
        
        [PreserveSig]
        D2D1_SIZE_F GetViewportSize();
        
        [PreserveSig]
        HRESULT SetRoot(/* _In_opt_ */ ID2D1SvgElement root);
        
        [PreserveSig]
        void GetRoot(/* _Outptr_result_maybenull_ */ out ID2D1SvgElement root);
        
        [PreserveSig]
        HRESULT FindElementById(/* _In_ */ [MarshalAs(UnmanagedType.LPWStr)] string id, /* _COM_Outptr_result_maybenull_ */ out ID2D1SvgElement svgElement);
        
        [PreserveSig]
        HRESULT Serialize(/* _In_ */ IStream outputXmlStream, /* _In_opt_ */ ID2D1SvgElement subtree);
        
        [PreserveSig]
        HRESULT Deserialize(/* _In_ */ IStream inputXmlStream, /* _COM_Outptr_ */ out ID2D1SvgElement subtree);
        
        [PreserveSig]
        HRESULT CreatePaint(D2D1_SVG_PAINT_TYPE paintType, /* optional(D2D1_COLOR_F) */ IntPtr color, /* _In_opt_ */ [MarshalAs(UnmanagedType.LPWStr)] string id, /* _COM_Outptr_ */ out ID2D1SvgPaint paint);
        
        [PreserveSig]
        HRESULT CreateStrokeDashArray(/* _In_reads_opt_(dashesCount) */ [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_SVG_LENGTH[] dashes, uint dashesCount, /* _COM_Outptr_ */ out ID2D1SvgStrokeDashArray strokeDashArray);
        
        [PreserveSig]
        HRESULT CreatePointCollection(/* _In_reads_opt_(pointsCount) */ [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_POINT_2F[] points, uint pointsCount, /* _COM_Outptr_ */ out ID2D1SvgPointCollection pointCollection);
        
        [PreserveSig]
        HRESULT CreatePathData(/* _In_reads_opt_(segmentDataCount) */ [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] segmentData, uint segmentDataCount, /* _In_reads_opt_(commandsCount) */ [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_SVG_PATH_COMMAND[] commands, uint commandsCount, /* _COM_Outptr_ */ out ID2D1SvgPathData pathData);
    }
}
