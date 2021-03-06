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

#if !NO_ENCODER
using System;
using Iced.Intel;
using Xunit;

namespace Iced.UnitTests.Intel.EncoderTests {
	public sealed class BlockEncoderTest64_iprel : BlockEncoderTest {
		const int bitness = 64;
		const ulong origRip = 0x8000;
		const ulong newRip = 0x8000000000000000;

		[Fact]
		void IpRel_fwd_bwd() {
			var originalData = new byte[] {
				/*0000*/ 0xB0, 0x01,// mov al,1
				/*0002*/ 0x48, 0x8B, 0x05, 0x1F, 0x00, 0x00, 0x00,// mov rax,[8028h]
				/*0009*/ 0xB0, 0x02,// mov al,2
				/*000B*/ 0x48, 0x8B, 0x05, 0xEE, 0xFF, 0xFF, 0xFF,// mov rax,[8000h]
				/*0012*/ 0xB0, 0x03,// mov al,3
				/*0014*/ 0x67, 0x48, 0x8B, 0x05, 0x0C, 0x00, 0x00, 0x00,// mov rax,[8028h]
				/*001C*/ 0xB0, 0x04,// mov al,4
				/*001E*/ 0x67, 0x48, 0x8B, 0x05, 0xDA, 0xFF, 0xFF, 0xFF,// mov rax,[8000h]
				/*0026*/ 0xB0, 0x05,// mov al,5
				/*0028*/ 0xB0, 0x06,// mov al,6
			};
			var newData = new byte[] {
				/*0000*/ 0xB0, 0x01,// mov al,1
				/*0002*/ 0x48, 0x8B, 0x05, 0x1D, 0x00, 0x00, 0x00,// mov rax,[8000000000000026h]
				/*0009*/ 0xB0, 0x02,// mov al,2
				/*000B*/ 0x48, 0x8B, 0x05, 0xEE, 0xFF, 0xFF, 0xFF,// mov rax,[8000000000000000h]
				/*0012*/ 0xB0, 0x03,// mov al,3
				/*0014*/ 0x48, 0x8B, 0x05, 0x0B, 0x00, 0x00, 0x00,// mov rax,[8000000000000026h]
				/*001B*/ 0xB0, 0x04,// mov al,4
				/*001D*/ 0x48, 0x8B, 0x05, 0xDC, 0xFF, 0xFF, 0xFF,// mov rax,[8000000000000000h]
				/*0024*/ 0xB0, 0x05,// mov al,5
				/*0026*/ 0xB0, 0x06,// mov al,6
			};
			var expectedInstructionOffsets = new uint[] {
				0x0000,
				0x0002,
				0x0009,
				0x000B,
				0x0012,
				0x0014,
				0x001B,
				0x001D,
				0x0024,
				0x0026,
			};
			var expectedRelocInfos = Array.Empty<RelocInfo>();
			const BlockEncoderOptions options = BlockEncoderOptions.None;
			EncodeBase(bitness, origRip, originalData, newRip, newData, options, decoderOptions, expectedInstructionOffsets, expectedRelocInfos);
		}

		[Fact]
		void IpRel_fwd_bwd_other_near() {
			var originalData = new byte[] {
				/*0000*/ 0xB0, 0x01,// mov al,1
				/*0002*/ 0x48, 0x8B, 0x05, 0x1F, 0x00, 0x00, 0x00,// mov rax,[8028h]
				/*0009*/ 0xB0, 0x02,// mov al,2
				/*000B*/ 0x48, 0x8B, 0x05, 0xED, 0xFF, 0xFF, 0xFF,// mov rax,[7FFFh]
				/*0012*/ 0xB0, 0x03,// mov al,3
				/*0014*/ 0x67, 0x48, 0x8B, 0x05, 0x0C, 0x00, 0x00, 0x00,// mov rax,[8028h]
				/*001C*/ 0xB0, 0x04,// mov al,4
				/*001E*/ 0x67, 0x48, 0x8B, 0x05, 0xD9, 0xFF, 0xFF, 0xFF,// mov rax,[7FFFh]
				/*0026*/ 0xB0, 0x05,// mov al,5
			};
			var newData = new byte[] {
				/*0000*/ 0xB0, 0x01,// mov al,1
				/*0002*/ 0x48, 0x8B, 0x05, 0x1F, 0xF0, 0xFF, 0xFF,// mov rax,[8028h]
				/*0009*/ 0xB0, 0x02,// mov al,2
				/*000B*/ 0x48, 0x8B, 0x05, 0xED, 0xEF, 0xFF, 0xFF,// mov rax,[7FFFh]
				/*0012*/ 0xB0, 0x03,// mov al,3
				/*0014*/ 0x48, 0x8B, 0x05, 0x0D, 0xF0, 0xFF, 0xFF,// mov rax,[8028h]
				/*001B*/ 0xB0, 0x04,// mov al,4
				/*001D*/ 0x48, 0x8B, 0x05, 0xDB, 0xEF, 0xFF, 0xFF,// mov rax,[7FFFh]
				/*0024*/ 0xB0, 0x05,// mov al,5
			};
			var expectedInstructionOffsets = new uint[] {
				0x0000,
				0x0002,
				0x0009,
				0x000B,
				0x0012,
				0x0014,
				0x001B,
				0x001D,
				0x0024,
			};
			var expectedRelocInfos = Array.Empty<RelocInfo>();
			const BlockEncoderOptions options = BlockEncoderOptions.None;
			EncodeBase(bitness, origRip, originalData, origRip + 0x1000, newData, options, decoderOptions, expectedInstructionOffsets, expectedRelocInfos);
		}

		[Fact]
		void IpRel_fwd_bwd_other_long_low4GB() {
			var originalData = new byte[] {
				/*0000*/ 0xB0, 0x01,// mov al,1
				/*0002*/ 0x48, 0x8B, 0x05, 0x1F, 0x00, 0x00, 0x00,// mov rax,[8028h]
				/*0009*/ 0xB0, 0x02,// mov al,2
				/*000B*/ 0x48, 0x8B, 0x05, 0xED, 0xFF, 0xFF, 0xFF,// mov rax,[7FFFh]
				/*0012*/ 0xB0, 0x03,// mov al,3
				/*0014*/ 0x67, 0x48, 0x8B, 0x05, 0x0C, 0x00, 0x00, 0x00,// mov rax,[8028h]
				/*001C*/ 0xB0, 0x04,// mov al,4
				/*001E*/ 0x67, 0x48, 0x8B, 0x05, 0xD9, 0xFF, 0xFF, 0xFF,// mov rax,[7FFFh]
				/*0026*/ 0xB0, 0x05,// mov al,5
			};
			var newData = new byte[] {
				/*0000*/ 0xB0, 0x01,// mov al,1
				/*0002*/ 0x67, 0x48, 0x8B, 0x05, 0x1E, 0x80, 0x00, 0x00,// mov rax,[8028h]
				/*000A*/ 0xB0, 0x02,// mov al,2
				/*000C*/ 0x67, 0x48, 0x8B, 0x05, 0xEB, 0x7F, 0x00, 0x00,// mov rax,[7FFFh]
				/*0014*/ 0xB0, 0x03,// mov al,3
				/*0016*/ 0x67, 0x48, 0x8B, 0x05, 0x0A, 0x80, 0x00, 0x00,// mov rax,[8028h]
				/*001E*/ 0xB0, 0x04,// mov al,4
				/*0020*/ 0x67, 0x48, 0x8B, 0x05, 0xD7, 0x7F, 0x00, 0x00,// mov rax,[7FFFh]
				/*0028*/ 0xB0, 0x05,// mov al,5
			};
			var expectedInstructionOffsets = new uint[] {
				0x0000,
				0x0002,
				0x000A,
				0x000C,
				0x0014,
				0x0016,
				0x001E,
				0x0020,
				0x0028,
			};
			var expectedRelocInfos = Array.Empty<RelocInfo>();
			const BlockEncoderOptions options = BlockEncoderOptions.None;
			EncodeBase(bitness, origRip, originalData, newRip, newData, options, decoderOptions, expectedInstructionOffsets, expectedRelocInfos);
		}
	}
}
#endif
