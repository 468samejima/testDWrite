﻿// c:\program files (x86)\windows kits\10\include\10.0.17763.0\um\dxgidebug.h(135,9)
using System;
using System.Runtime.InteropServices;
using DXGI_INFO_QUEUE_MESSAGE_ID = System.Int32;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DXGI_INFO_QUEUE_FILTER_DESC
    {
        public uint NumCategories;
        public IntPtr pCategoryList;
        public uint NumSeverities;
        public IntPtr pSeverityList;
        public uint NumIDs;
        public IntPtr pIDList;
    }
}
