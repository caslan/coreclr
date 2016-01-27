// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal struct AA
{
    public ulong tmp1;
    public ulong tmp2;
    public sbyte tmp3;

    public int q;

    public sbyte tmp4;
    public byte tmp5;

    public AA(int qq)
    {
        tmp1 = 106;
        tmp2 = 107;
        tmp3 = 108;
        tmp4 = 109;
        tmp5 = 110;
        q = qq;
    }

    public static AA[] a_init = new AA[101];
    public static AA[] a_zero = new AA[101];
    public static AA[,,] aa_init = new AA[1, 101, 2];
    public static AA[,,] aa_zero = new AA[1, 101, 2];
    public static object b_init = new AA(100);
    public static AA _init, _zero;

    public static int call_target(int arg) { return arg; }
    public static int call_target_ref(ref int arg) { return arg; }

    public void verify()
    {
        if (tmp1 != 106) throw new Exception("tmp1 corrupted");
        if (tmp2 != 107) throw new Exception("tmp2 corrupted");
        if (tmp3 != 108) throw new Exception("tmp3 corrupted");
        if (tmp4 != 109) throw new Exception("tmp4 corrupted");
        if (tmp5 != 110) throw new Exception("tmp5 corrupted");
    }

    public static void verify_all()
    {
        a_init[100].verify();
        a_zero[100].verify();
        aa_init[0, 99, 1].verify();
        aa_zero[0, 99, 1].verify();
        _init.verify();
        _zero.verify();
        BB.f_init.verify();
        BB.f_zero.verify();
    }

    public static void reset()
    {
        a_init[100] = new AA(100);
        a_zero[100] = new AA(0);
        aa_init[0, 99, 1] = new AA(100);
        aa_zero[0, 99, 1] = new AA(0);
        _init = new AA(100);
        _zero = new AA(0);
        BB.f_init = new AA(100);
        BB.f_zero = new AA(0);
    }
}

internal struct BB
{
    public static AA f_init, f_zero;
}
