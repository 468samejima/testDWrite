﻿// generated from <Windows SDK Path>\um\d3d12.h
using System.Runtime.InteropServices;

namespace DirectN
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct D3D12_ROOT_PARAMETER
    {
        public D3D12_ROOT_PARAMETER_TYPE ParameterType;
        public uint __pad0;
        public D3D12_ROOT_PARAMETER__union_0 __union_1;
        public D3D12_SHADER_VISIBILITY ShaderVisibility;
        public uint __pad1;
    }
}
