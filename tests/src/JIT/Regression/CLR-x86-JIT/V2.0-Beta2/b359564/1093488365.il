
.assembly Test1 {}

.assembly extern System.Console
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )
  .ver 4:0:0:0
}
.assembly extern mscorlib{auto}
.class FullProof {

.method static int32 Test() noinlining {
.maxstack 16
	ldc.r4 0
	conv.ovf.i4
	ldc.i4 -2147483648
	sub.ovf			
	ret
}

.method public static int32  Main()
{
.entrypoint
.maxstack 3
	.try
	{
		call int32 FullProof::Test()
		pop
		leave.s FAIL
	}
	catch [mscorlib]System.OverflowException
	{
		pop
		leave.s PASS
	}

FAIL:
	ldstr "FAIL"
	call void [System.Console]System.Console::WriteLine(string)
	ldc.i4.0
	br DONE

PASS:
	ldstr "PASS"
	call void [System.Console]System.Console::WriteLine(string)
	ldc.i4 100

DONE:

	ret
}
}
