// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;


public class GenException<T> : Exception
{
}

public interface IGen
{
    bool ExceptionTest();
}

public class Gen<T> : IGen
{
    public bool ExceptionTest()
    {
        try
        {
            Console.WriteLine("in try");
            throw new GenException<T>();
        }
        catch (GenException<T> exp)
        {
            Console.WriteLine("in catch: " + exp.Message);
            return true;
        }
    }
}

public class Test
{
    private static TestUtil.TestLog testLog;

    static Test()
    {
        // Create test writer object to hold expected output
        StringWriter expectedOut = new StringWriter();

        // Write expected output to string writer object
        Exception[] expList = new Exception[] {
            new GenException<Exception>(),
            new GenException<GenException<Exception>>(),
            new GenException<GenException<GenException<Exception>>>(),
            new GenException<GenException<GenException<GenException<Exception>>>>(),
            new GenException<GenException<GenException<GenException<GenException<Exception>>>>>(),
            new GenException<GenException<GenException<GenException<GenException<GenException<Exception>>>>>>(),
            new GenException<GenException<GenException<GenException<GenException<GenException<GenException<Exception>>>>>>>(),
            new GenException<GenException<GenException<GenException<GenException<GenException<GenException<GenException<Exception>>>>>>>>(),
            new GenException<GenException<GenException<GenException<GenException<GenException<GenException<GenException<GenException<Exception>>>>>>>>>(),
            new GenException<GenException<GenException<GenException<GenException<GenException<GenException<GenException<GenException<GenException<Exception>>>>>>>>>>()
        };
        for (int i = 0; i < expList.Length; i++)
        {
            expectedOut.WriteLine("in try");
            expectedOut.WriteLine("in catch: " + expList[i].Message);
            expectedOut.WriteLine("{0}", true);
        }

        // Create and initialize test log object
        testLog = new TestUtil.TestLog(expectedOut);

    }

    public static int Main()
    {
        //Start recording
        testLog.StartRecording();

        // create test list
        IGen[] genList = new IGen[] {
            new Gen<Exception>(),
            new Gen<GenException<Exception>>(),
            new Gen<GenException<GenException<Exception>>>(),
            new Gen<GenException<GenException<GenException<Exception>>>>(),
            new Gen<GenException<GenException<GenException<GenException<Exception>>>>>(),
            new Gen<GenException<GenException<GenException<GenException<GenException<Exception>>>>>>(),
            new Gen<GenException<GenException<GenException<GenException<GenException<GenException<Exception>>>>>>>(),
            new Gen<GenException<GenException<GenException<GenException<GenException<GenException<GenException<Exception>>>>>>>>(),
            new Gen<GenException<GenException<GenException<GenException<GenException<GenException<GenException<GenException<Exception>>>>>>>>>(),
            new Gen<GenException<GenException<GenException<GenException<GenException<GenException<GenException<GenException<GenException<Exception>>>>>>>>>>()
        };

        // run test
        for (int i = 0; i < genList.Length; i++)
        {
            Console.WriteLine(genList[i].ExceptionTest());
        }

        // stop recoding
        testLog.StopRecording();

        return testLog.VerifyOutput();
    }

}
