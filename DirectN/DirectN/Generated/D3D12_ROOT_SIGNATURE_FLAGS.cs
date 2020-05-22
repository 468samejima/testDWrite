﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\d3d12.h(3461,1)
using System;

namespace DirectN
{
    [Flags]
    public enum D3D12_ROOT_SIGNATURE_FLAGS
    {
        D3D12_ROOT_SIGNATURE_FLAG_NONE = 0x00000000,
        D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT = 0x00000001,
        D3D12_ROOT_SIGNATURE_FLAG_DENY_VERTEX_SHADER_ROOT_ACCESS = 0x00000002,
        D3D12_ROOT_SIGNATURE_FLAG_DENY_HULL_SHADER_ROOT_ACCESS = 0x00000004,
        D3D12_ROOT_SIGNATURE_FLAG_DENY_DOMAIN_SHADER_ROOT_ACCESS = 0x00000008,
        D3D12_ROOT_SIGNATURE_FLAG_DENY_GEOMETRY_SHADER_ROOT_ACCESS = 0x00000010,
        D3D12_ROOT_SIGNATURE_FLAG_DENY_PIXEL_SHADER_ROOT_ACCESS = 0x00000020,
        D3D12_ROOT_SIGNATURE_FLAG_ALLOW_STREAM_OUTPUT = 0x00000040,
        D3D12_ROOT_SIGNATURE_FLAG_LOCAL_ROOT_SIGNATURE = 0x00000080,
        D3D12_ROOT_SIGNATURE_FLAG_DENY_AMPLIFICATION_SHADER_ROOT_ACCESS = 0x00000100,
        D3D12_ROOT_SIGNATURE_FLAG_DENY_MESH_SHADER_ROOT_ACCESS = 0x00000200,
    }
}
