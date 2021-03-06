// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


using System;

public class VInline
{
    private int _fi1;
    private int _fi2;
    public VInline(int ival)
    {
        _fi1 = ival;
        _fi2 = 0;
    }
    [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
    private void GetI1(ref int i)
    {
        i = _fi1;
    }
    public int Accumulate(int a)
    {
        int i = 0;
        GetI1(ref i); //here's the ldloca, passing the address of i as the arg
        i = i / _fi2;    //fi2 == 0 so this should always cause an exception
        return i;
    }
}
public class VIMain
{
    public static int Main()
    {
        int ret = 100;
        VInline vi = new VInline(1);
        int ival = 2;
        try
        {
            ival = vi.Accumulate(ival);  //this call should throw a divide by zero exception
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("exeption stack trace: " + e.StackTrace.ToString());  //display the stack trace
            if (e.StackTrace.ToString().Contains("Accumulate"))
            {
                Console.WriteLine("Fail, method Accumulate NOT inlined.");
                ret = 666;
            }
            else
            {
                Console.WriteLine("Pass, method Accumulate inlined.");
            }
        }

        return ret;
    }
}

