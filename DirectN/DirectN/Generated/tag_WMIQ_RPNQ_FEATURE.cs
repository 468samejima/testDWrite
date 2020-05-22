﻿// c:\program files (x86)\windows kits\10\include\10.0.19041.0\um\wmiutils.h(1121,1)
using System;

namespace DirectN
{
    [Flags]
    public enum tag_WMIQ_RPNQ_FEATURE
    {
        WMIQ_RPNF_WHERE_CLAUSE_PRESENT = 0x00000001,
        WMIQ_RPNF_QUERY_IS_CONJUNCTIVE = 0x00000002,
        WMIQ_RPNF_QUERY_IS_DISJUNCTIVE = 0x00000004,
        WMIQ_RPNF_PROJECTION = 0x00000008,
        WMIQ_RPNF_FEATURE_SELECT_STAR = 0x00000010,
        WMIQ_RPNF_EQUALITY_TESTS_ONLY = 0x00000020,
        WMIQ_RPNF_COUNT_STAR = 0x00000040,
        WMIQ_RPNF_QUALIFIED_NAMES_USED = 0x00000080,
        WMIQ_RPNF_SYSPROP_CLASS_USED = 0x00000100,
        WMIQ_RPNF_PROP_TO_PROP_TESTS = 0x00000200,
        WMIQ_RPNF_ORDER_BY = 0x00000400,
        WMIQ_RPNF_ISA_USED = 0x00000800,
        WMIQ_RPNF_GROUP_BY_HAVING = 0x00001000,
        WMIQ_RPNF_ARRAY_ACCESS_USED = 0x00002000,
    }
}
