﻿/*
    Copyright (C) 2018 de4dot@gmail.com

    This file is part of Iced.

    Iced is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Iced is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with Iced.  If not, see <https://www.gnu.org/licenses/>.
*/

using Iced.Intel;
using Xunit;

namespace Iced.UnitTests.Intel.DecoderTests {
	public sealed class DecoderTest_1_00_07 : DecoderTest {
		[Fact]
		void Test16_Add_rm8_r8_1() {
			var decoder = CreateDecoder16("00 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm8_r8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.DH, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.CL, instr.Op1Register);
		}

		[Fact]
		void Test16_Add_rm8_r8_2() {
			var decoder = CreateDecoder16("00 38");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm8_r8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Memory, instr.Op0Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.BX, instr.MemoryBase);
			Assert.Equal(Register.SI, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt8, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.BH, instr.Op1Register);
		}

		[Fact]
		void Test32_Add_rm8_r8_1() {
			var decoder = CreateDecoder32("00 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm8_r8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.DH, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.CL, instr.Op1Register);
		}

		[Fact]
		void Test32_Add_rm8_r8_2() {
			var decoder = CreateDecoder32("00 38");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm8_r8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Memory, instr.Op0Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.EAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt8, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.BH, instr.Op1Register);
		}

		[Theory]
		[InlineData("00 CE", 2, Register.DH, Register.CL)]
		[InlineData("40 00 D5", 3, Register.BPL, Register.DL)]
		[InlineData("40 00 FA", 3, Register.DL, Register.DIL)]
		[InlineData("45 00 F0", 3, Register.R8L, Register.R14L)]
		[InlineData("41 00 D9", 3, Register.R9L, Register.BL)]
		[InlineData("44 00 EC", 3, Register.SPL, Register.R13L)]
		[InlineData("66 67 4E 00 EC", 5, Register.SPL, Register.R13L)]
		void Test64_Add_rm8_r8_1(string hexBytes, int byteLength, Register reg1, Register reg2) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm8_r8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(reg1, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(reg2, instr.Op1Register);
		}

		[Fact]
		void Test64_Add_rm8_r8_2() {
			var decoder = CreateDecoder64("00 38");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm8_r8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Memory, instr.Op0Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.RAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt8, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.BH, instr.Op1Register);
		}

		[Fact]
		void Test16_Add_rm16_r16_1() {
			var decoder = CreateDecoder16("01 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm16_r16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.SI, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.CX, instr.Op1Register);
		}

		[Fact]
		void Test16_Add_rm16_r16_2() {
			// Add an extra space here to prevent duplicate test case warning. The modrm tests have the same test case,
			// and all of these tests are used by the encoder.
			var decoder = CreateDecoder16("01 18 ");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm16_r16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Memory, instr.Op0Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.BX, instr.MemoryBase);
			Assert.Equal(Register.SI, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt16, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.BX, instr.Op1Register);
		}

		[Fact]
		void Test32_Add_rm16_r16_1() {
			var decoder = CreateDecoder32("66 01 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm16_r16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.SI, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.CX, instr.Op1Register);
		}

		[Fact]
		void Test32_Add_rm16_r16_2() {
			var decoder = CreateDecoder32("66 01 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm16_r16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Memory, instr.Op0Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.EAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt16, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.BX, instr.Op1Register);
		}

		[Theory]
		[InlineData("66 01 CE", 3, Register.SI, Register.CX)]
		[InlineData("66 44 01 C5", 4, Register.BP, Register.R8W)]
		[InlineData("66 41 01 D6", 4, Register.R14W, Register.DX)]
		[InlineData("66 45 01 D0", 4, Register.R8W, Register.R10W)]
		[InlineData("66 41 01 D9", 4, Register.R9W, Register.BX)]
		[InlineData("66 44 01 EC", 4, Register.SP, Register.R13W)]
		void Test64_Add_rm16_r16_1(string hexBytes, int byteLength, Register reg1, Register reg2) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm16_r16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(reg1, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(reg2, instr.Op1Register);
		}

		[Fact]
		void Test64_Add_rm16_r16_2() {
			var decoder = CreateDecoder64("66 01 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm16_r16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Memory, instr.Op0Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.RAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt16, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.BX, instr.Op1Register);
		}

		[Fact]
		void Test16_Add_rm32_r32_1() {
			var decoder = CreateDecoder16("66 01 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm32_r32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ESI, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.ECX, instr.Op1Register);
		}

		[Fact]
		void Test16_Add_rm32_r32_2() {
			var decoder = CreateDecoder16("66 01 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm32_r32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Memory, instr.Op0Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.BX, instr.MemoryBase);
			Assert.Equal(Register.SI, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt32, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.EBX, instr.Op1Register);
		}

		[Fact]
		void Test32_Add_rm32_r32_1() {
			var decoder = CreateDecoder32("01 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm32_r32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ESI, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.ECX, instr.Op1Register);
		}

		[Fact]
		void Test32_Add_rm32_r32_2() {
			var decoder = CreateDecoder32("01 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm32_r32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Memory, instr.Op0Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.EAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt32, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.EBX, instr.Op1Register);
		}

		[Theory]
		[InlineData("01 CE", 2, Register.ESI, Register.ECX)]
		[InlineData("44 01 C5", 3, Register.EBP, Register.R8D)]
		[InlineData("41 01 D6", 3, Register.R14D, Register.EDX)]
		[InlineData("45 01 D0", 3, Register.R8D, Register.R10D)]
		[InlineData("41 01 D9", 3, Register.R9D, Register.EBX)]
		[InlineData("44 01 EC", 3, Register.ESP, Register.R13D)]
		void Test64_Add_rm32_r32_1(string hexBytes, int byteLength, Register reg1, Register reg2) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm32_r32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(reg1, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(reg2, instr.Op1Register);
		}

		[Fact]
		void Test64_Add_rm32_r32_2() {
			var decoder = CreateDecoder64("01 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm32_r32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Memory, instr.Op0Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.RAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt32, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.EBX, instr.Op1Register);
		}

		[Theory]
		[InlineData("48 01 CE", 3, Register.RSI, Register.RCX)]
		[InlineData("4C 01 C5", 3, Register.RBP, Register.R8)]
		[InlineData("49 01 D6", 3, Register.R14, Register.RDX)]
		[InlineData("4D 01 D0", 3, Register.R8, Register.R10)]
		[InlineData("49 01 D9", 3, Register.R9, Register.RBX)]
		[InlineData("4C 01 EC", 3, Register.RSP, Register.R13)]
		void Test64_Add_rm64_r64_1(string hexBytes, int byteLength, Register reg1, Register reg2) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm64_r64, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(reg1, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(reg2, instr.Op1Register);
		}

		[Fact]
		void Test64_Add_rm64_r64_2() {
			var decoder = CreateDecoder64("48 01 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_rm64_r64, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Memory, instr.Op0Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.RAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt64, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.RBX, instr.Op1Register);
		}

		[Fact]
		void Test16_Add_r8_rm8_1() {
			var decoder = CreateDecoder16("02 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r8_rm8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.CL, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.DH, instr.Op1Register);
		}

		[Fact]
		void Test16_Add_r8_rm8_2() {
			var decoder = CreateDecoder16("02 38");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r8_rm8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.BH, instr.Op0Register);

			Assert.Equal(OpKind.Memory, instr.Op1Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.BX, instr.MemoryBase);
			Assert.Equal(Register.SI, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt8, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);
		}

		[Fact]
		void Test32_Add_r8_rm8_1() {
			var decoder = CreateDecoder32("02 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r8_rm8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.CL, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.DH, instr.Op1Register);
		}

		[Fact]
		void Test32_Add_r8_rm8_2() {
			var decoder = CreateDecoder32("02 38");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r8_rm8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.BH, instr.Op0Register);

			Assert.Equal(OpKind.Memory, instr.Op1Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.EAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt8, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);
		}

		[Theory]
		[InlineData("02 CE", 2, Register.CL, Register.DH)]
		[InlineData("40 02 D5", 3, Register.DL, Register.BPL)]
		[InlineData("40 02 FA", 3, Register.DIL, Register.DL)]
		[InlineData("45 02 F0", 3, Register.R14L, Register.R8L)]
		[InlineData("41 02 D9", 3, Register.BL, Register.R9L)]
		[InlineData("44 02 EC", 3, Register.R13L, Register.SPL)]
		[InlineData("66 67 4E 02 EC", 5, Register.R13L, Register.SPL)]
		void Test64_Add_r8_rm8_1(string hexBytes, int byteLength, Register reg1, Register reg2) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r8_rm8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(reg1, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(reg2, instr.Op1Register);
		}

		[Fact]
		void Test64_Add_r8_rm8_2() {
			var decoder = CreateDecoder64("02 38");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r8_rm8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.BH, instr.Op0Register);

			Assert.Equal(OpKind.Memory, instr.Op1Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.RAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt8, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);
		}

		[Fact]
		void Test16_Add_r16_rm16_1() {
			var decoder = CreateDecoder16("03 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r16_rm16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.CX, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.SI, instr.Op1Register);
		}

		[Fact]
		void Test16_Add_r16_rm16_2() {
			var decoder = CreateDecoder16("03 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r16_rm16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.BX, instr.Op0Register);

			Assert.Equal(OpKind.Memory, instr.Op1Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.BX, instr.MemoryBase);
			Assert.Equal(Register.SI, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt16, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);
		}

		[Fact]
		void Test32_Add_r16_rm16_1() {
			var decoder = CreateDecoder32("66 03 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r16_rm16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.CX, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.SI, instr.Op1Register);
		}

		[Fact]
		void Test32_Add_r16_rm16_2() {
			var decoder = CreateDecoder32("66 03 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r16_rm16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.BX, instr.Op0Register);

			Assert.Equal(OpKind.Memory, instr.Op1Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.EAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt16, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);
		}

		[Theory]
		[InlineData("66 03 CE", 3, Register.CX, Register.SI)]
		[InlineData("66 44 03 C5", 4, Register.R8W, Register.BP)]
		[InlineData("66 41 03 D6", 4, Register.DX, Register.R14W)]
		[InlineData("66 45 03 D0", 4, Register.R10W, Register.R8W)]
		[InlineData("66 41 03 D9", 4, Register.BX, Register.R9W)]
		[InlineData("66 44 03 EC", 4, Register.R13W, Register.SP)]
		void Test64_Add_r16_rm16_1(string hexBytes, int byteLength, Register reg1, Register reg2) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r16_rm16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(reg1, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(reg2, instr.Op1Register);
		}

		[Fact]
		void Test64_Add_r16_rm16_2() {
			var decoder = CreateDecoder64("66 03 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r16_rm16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.BX, instr.Op0Register);

			Assert.Equal(OpKind.Memory, instr.Op1Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.RAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt16, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);
		}

		[Fact]
		void Test16_Add_r32_rm32_1() {
			var decoder = CreateDecoder16("66 03 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r32_rm32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ECX, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.ESI, instr.Op1Register);
		}

		[Fact]
		void Test16_Add_r32_rm32_2() {
			var decoder = CreateDecoder16("66 03 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r32_rm32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.EBX, instr.Op0Register);

			Assert.Equal(OpKind.Memory, instr.Op1Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.BX, instr.MemoryBase);
			Assert.Equal(Register.SI, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt32, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);
		}

		[Fact]
		void Test32_Add_r32_rm32_1() {
			var decoder = CreateDecoder32("03 CE");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r32_rm32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ECX, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(Register.ESI, instr.Op1Register);
		}

		[Fact]
		void Test32_Add_r32_rm32_2() {
			var decoder = CreateDecoder32("03 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r32_rm32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.EBX, instr.Op0Register);

			Assert.Equal(OpKind.Memory, instr.Op1Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.EAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt32, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);
		}

		[Theory]
		[InlineData("03 CE", 2, Register.ECX, Register.ESI)]
		[InlineData("44 03 C5", 3, Register.R8D, Register.EBP)]
		[InlineData("41 03 D6", 3, Register.EDX, Register.R14D)]
		[InlineData("45 03 D0", 3, Register.R10D, Register.R8D)]
		[InlineData("41 03 D9", 3, Register.EBX, Register.R9D)]
		[InlineData("44 03 EC", 3, Register.R13D, Register.ESP)]
		void Test64_Add_r32_rm32_1(string hexBytes, int byteLength, Register reg1, Register reg2) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r32_rm32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(reg1, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(reg2, instr.Op1Register);
		}

		[Fact]
		void Test64_Add_r32_rm32_2() {
			var decoder = CreateDecoder64("03 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r32_rm32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.EBX, instr.Op0Register);

			Assert.Equal(OpKind.Memory, instr.Op1Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.RAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt32, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);
		}

		[Theory]
		[InlineData("48 03 CE", 3, Register.RCX, Register.RSI)]
		[InlineData("4C 03 C5", 3, Register.R8, Register.RBP)]
		[InlineData("49 03 D6", 3, Register.RDX, Register.R14)]
		[InlineData("4D 03 D0", 3, Register.R10, Register.R8)]
		[InlineData("49 03 D9", 3, Register.RBX, Register.R9)]
		[InlineData("4C 03 EC", 3, Register.R13, Register.RSP)]
		void Test64_Add_r64_rm64_1(string hexBytes, int byteLength, Register reg1, Register reg2) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r64_rm64, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(reg1, instr.Op0Register);

			Assert.Equal(OpKind.Register, instr.Op1Kind);
			Assert.Equal(reg2, instr.Op1Register);
		}

		[Fact]
		void Test64_Add_r64_rm64_2() {
			var decoder = CreateDecoder64("48 03 18");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_r64_rm64, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.RBX, instr.Op0Register);

			Assert.Equal(OpKind.Memory, instr.Op1Kind);
			Assert.Equal(Register.DS, instr.MemorySegment);
			Assert.Equal(Register.RAX, instr.MemoryBase);
			Assert.Equal(Register.None, instr.MemoryIndex);
			Assert.Equal(0U, instr.MemoryDisplacement);
			Assert.Equal(1, instr.MemoryIndexScale);
			Assert.Equal(MemorySize.UInt64, instr.MemorySize);
			Assert.Equal(0, instr.MemoryDisplSize);
		}

		[Fact]
		void Test16_Add_AL_imm8_1() {
			var decoder = CreateDecoder16("04 5A");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_AL_imm8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.AL, instr.Op0Register);

			Assert.Equal(OpKind.Immediate8, instr.Op1Kind);
			Assert.Equal(0x5A, instr.Immediate8);
		}

		[Fact]
		void Test32_Add_AL_imm8_1() {
			var decoder = CreateDecoder32("04 A5");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_AL_imm8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.AL, instr.Op0Register);

			Assert.Equal(OpKind.Immediate8, instr.Op1Kind);
			Assert.Equal(0xA5, instr.Immediate8);
		}

		[Theory]
		[InlineData("04 A5", 2)]
		[InlineData("4F 04 A5", 3)]
		void Test64_Add_AL_imm8_1(string hexBytes, int byteLength) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_AL_imm8, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.AL, instr.Op0Register);

			Assert.Equal(OpKind.Immediate8, instr.Op1Kind);
			Assert.Equal(0xA5, instr.Immediate8);
		}

		[Fact]
		void Test16_Add_AX_imm16_1() {
			var decoder = CreateDecoder16("05 5AA5");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_AX_imm16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(3, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.AX, instr.Op0Register);

			Assert.Equal(OpKind.Immediate16, instr.Op1Kind);
			Assert.Equal(0xA55A, instr.Immediate16);
		}

		[Fact]
		void Test32_Add_AX_imm16_1() {
			var decoder = CreateDecoder32("66 05 A55A");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_AX_imm16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(4, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.AX, instr.Op0Register);

			Assert.Equal(OpKind.Immediate16, instr.Op1Kind);
			Assert.Equal(0x5AA5, instr.Immediate16);
		}

		[Theory]
		[InlineData("66 05 A55A", 4)]
		[InlineData("66 47 05 A55A", 5)]
		void Test64_Add_AX_imm16_1(string hexBytes, int byteLength) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_AX_imm16, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.AX, instr.Op0Register);

			Assert.Equal(OpKind.Immediate16, instr.Op1Kind);
			Assert.Equal(0x5AA5, instr.Immediate16);
		}

		[Fact]
		void Test16_Add_EAX_imm32_1() {
			var decoder = CreateDecoder16("66 05 5AA51234");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_EAX_imm32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(6, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.EAX, instr.Op0Register);

			Assert.Equal(OpKind.Immediate32, instr.Op1Kind);
			Assert.Equal(0x3412A55AU, instr.Immediate32);
		}

		[Fact]
		void Test32_Add_EAX_imm32_1() {
			var decoder = CreateDecoder32("05 A55A3412");
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_EAX_imm32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(5, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.EAX, instr.Op0Register);

			Assert.Equal(OpKind.Immediate32, instr.Op1Kind);
			Assert.Equal(0x12345AA5U, instr.Immediate32);
		}

		[Theory]
		[InlineData("05 A55A3412", 5)]
		[InlineData("47 05 A55A3412", 6)]
		void Test64_Add_EAX_imm32_1(string hexBytes, int byteLength) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_EAX_imm32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.EAX, instr.Op0Register);

			Assert.Equal(OpKind.Immediate32, instr.Op1Kind);
			Assert.Equal(0x12345AA5U, instr.Immediate32);
		}

		[Theory]
		[InlineData("48 05 A55A34A2", 6)]
		[InlineData("4F 05 A55A34A2", 6)]
		void Test64_Add_RAX_imm32_1(string hexBytes, int byteLength) {
			var decoder = CreateDecoder64(hexBytes);
			var instr = decoder.Decode();

			Assert.Equal(Code.Add_RAX_imm32, instr.Code);
			Assert.Equal(2, instr.OpCount);
			Assert.Equal(byteLength, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.RAX, instr.Op0Register);

			Assert.Equal(OpKind.Immediate32to64, instr.Op1Kind);
			Assert.Equal(0xFFFFFFFFA2345AA5UL, (ulong)instr.Immediate32to64);
		}

		[Fact]
		void Test16_Pushw_ES_1() {
			var decoder = CreateDecoder16("06");
			var instr = decoder.Decode();

			Assert.Equal(Code.Pushw_ES, instr.Code);
			Assert.Equal(1, instr.OpCount);
			Assert.Equal(1, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ES, instr.Op0Register);
		}

		[Fact]
		void Test32_Pushw_ES_1() {
			var decoder = CreateDecoder32("66 06");
			var instr = decoder.Decode();

			Assert.Equal(Code.Pushw_ES, instr.Code);
			Assert.Equal(1, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ES, instr.Op0Register);
		}

		[Fact]
		void Test16_Pushd_ES_1() {
			var decoder = CreateDecoder16("66 06");
			var instr = decoder.Decode();

			Assert.Equal(Code.Pushd_ES, instr.Code);
			Assert.Equal(1, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ES, instr.Op0Register);
		}

		[Fact]
		void Test32_Pushd_ES_1() {
			var decoder = CreateDecoder32("06");
			var instr = decoder.Decode();

			Assert.Equal(Code.Pushd_ES, instr.Code);
			Assert.Equal(1, instr.OpCount);
			Assert.Equal(1, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ES, instr.Op0Register);
		}

		[Fact]
		void Test16_Popw_ES_1() {
			var decoder = CreateDecoder16("07");
			var instr = decoder.Decode();

			Assert.Equal(Code.Popw_ES, instr.Code);
			Assert.Equal(1, instr.OpCount);
			Assert.Equal(1, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ES, instr.Op0Register);
		}

		[Fact]
		void Test32_Popw_ES_1() {
			var decoder = CreateDecoder32("66 07");
			var instr = decoder.Decode();

			Assert.Equal(Code.Popw_ES, instr.Code);
			Assert.Equal(1, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ES, instr.Op0Register);
		}

		[Fact]
		void Test16_Popd_ES_1() {
			var decoder = CreateDecoder16("66 07");
			var instr = decoder.Decode();

			Assert.Equal(Code.Popd_ES, instr.Code);
			Assert.Equal(1, instr.OpCount);
			Assert.Equal(2, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ES, instr.Op0Register);
		}

		[Fact]
		void Test32_Popd_ES_1() {
			var decoder = CreateDecoder32("07");
			var instr = decoder.Decode();

			Assert.Equal(Code.Popd_ES, instr.Code);
			Assert.Equal(1, instr.OpCount);
			Assert.Equal(1, instr.ByteLength);
			Assert.False(instr.HasRepePrefix);
			Assert.False(instr.HasRepnePrefix);
			Assert.False(instr.HasLockPrefix);
			Assert.Equal(Register.None, instr.SegmentPrefix);

			Assert.Equal(OpKind.Register, instr.Op0Kind);
			Assert.Equal(Register.ES, instr.Op0Register);
		}
	}
}
