// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

.assembly extern legacy library mscorlib {}

.assembly shl.exe{}

.class public _shl {

.method public static int32 return(int32) {
.maxstack	2
	ldarg	0
	ret
}
.method public static int64 return(int64) {
.maxstack	2
	ldarg	0
	ret
}

.method public static int32 main(class [mscorlib]System.String[]) {
.entrypoint
.maxstack	10
	ldc.i4	0x7FFFFFFF
	call	int32 _shl::return(int32)
	ldc.i4	0x1
	call	int32 _shl::return(int32)
	shl
	ldc.i4	0xFFFFFFFE
	call	int32 _shl::return(int32)
	ceq
	brfalse	FAIL
        ldc.i8  0x7FFFFFFFFFFFFFFF
        call    int64 _shl::return(int64)
        ldc.i4  0x1
        call    int32 _shl::return(int32)
        shl
        ldc.i8  0xFFFFFFFFFFFFFFFE
        call    int64 _shl::return(int64)
        ceq
        brfalse FAIL

PASS:
	ldc.i4 100
	ret
FAIL:
	ldc.i4	0x0
	ret
}
}
