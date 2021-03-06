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

#if !NO_INTEL_FORMATTER && !NO_FORMATTER
using System.Collections.Generic;
using Xunit;

namespace Iced.UnitTests.Intel.FormatterTests.Intel {
	public sealed class IntelFormatterTest32_NoMemSize_000 : FormatterTest {
		[Theory]
		[MemberData(nameof(Format_Data))]
		void Format(int index, InstructionInfo info, string formattedString) => FormatBase(index, info, formattedString, IntelFormatterFactory.Create_NoMemSize());
		public static IEnumerable<object[]> Format_Data => GetFormatData(infos, formattedStrings);

		static readonly InstructionInfo[] infos = InstructionInfos32_000.AllInfos;
		static readonly string[] formattedStrings = new string[InstructionInfos32_000.AllInfos_Length] {
			"data16 push es",
			"push es",
			"data16 pop es",
			"pop es",
			"data16 push cs",
			"push cs",
			"data16 push ss",
			"push ss",
			"data16 pop ss",
			"pop ss",
			"data16 push ds",
			"push ds",
			"data16 pop ds",
			"pop ds",
			"daa",
			"das",
			"aaa",
			"aas",
			"inc ax",
			"inc eax",
			"inc cx",
			"inc ecx",
			"inc dx",
			"inc edx",
			"inc bx",
			"inc ebx",
			"inc sp",
			"inc esp",
			"inc bp",
			"inc ebp",
			"inc si",
			"inc esi",
			"inc di",
			"inc edi",
			"dec ax",
			"dec eax",
			"dec cx",
			"dec ecx",
			"dec dx",
			"dec edx",
			"dec bx",
			"dec ebx",
			"dec sp",
			"dec esp",
			"dec bp",
			"dec ebp",
			"dec si",
			"dec esi",
			"dec di",
			"dec edi",
			"push eax",
			"push ecx",
			"push edx",
			"push ebx",
			"push esp",
			"push ebp",
			"push esi",
			"push edi",
			"pop eax",
			"pop ecx",
			"pop edx",
			"pop ebx",
			"pop esp",
			"pop ebp",
			"pop esi",
			"pop edi",
			"pusha",
			"pushad",
			"popa",
			"popad",
			"bound bx, dword ptr [eax]",
			"bound ebx, qword ptr [eax]",
			"arpl dx, si",
			"arpl [eax], bx",
			"push 0x3412a55a",
			"push 0xffffffa5",
			"data16 jo 0x004d",
			"jo 0x8000004c",
			"data16 jno 0x004d",
			"jno 0x8000004c",
			"data16 jb 0x004d",
			"jb 0x8000004c",
			"data16 jae 0x004d",
			"jae 0x8000004c",
			"data16 je 0x004d",
			"je 0x8000004c",
			"data16 jne 0x004d",
			"jne 0x8000004c",
			"data16 jbe 0x004d",
			"jbe 0x8000004c",
			"data16 ja 0x004d",
			"ja 0x8000004c",
			"data16 js 0x004d",
			"js 0x8000004c",
			"data16 jns 0x004d",
			"jns 0x8000004c",
			"data16 jp 0x004d",
			"jp 0x8000004c",
			"data16 jnp 0x004d",
			"jnp 0x8000004c",
			"data16 jl 0x004d",
			"jl 0x8000004c",
			"data16 jge 0x004d",
			"jge 0x8000004c",
			"data16 jle 0x004d",
			"jle 0x8000004c",
			"data16 jg 0x004d",
			"jg 0x8000004c",
			"pop esi",
			"pop dword ptr [eax]",
			"data16 call far 0x3412, 0x7856",
			"call far 0x78563412, 0xbc9a",
			"pushfd",
			"popfd",
			"data16 ret 0xa55a",
			"ret 0xa55a",
			"data16 ret",
			"ret",
			"les bx, [eax]",
			"les ebx, [eax]",
			"lds bx, [eax]",
			"lds ebx, [eax]",
			"enter 0xa55a, 0xa6",
			"leave",
			"into",
			"aam 0xa",
			"aad 0xa",
			"data16 addr16 loopne 0x004e",
			"addr16 loopne 0x8000004d",
			"data16 loopne 0x004d",
			"loopne 0x8000004c",
			"data16 addr16 loope 0x004e",
			"addr16 loope 0x8000004d",
			"data16 loope 0x004d",
			"loope 0x8000004c",
			"data16 addr16 loop 0x004e",
			"addr16 loop 0x8000004d",
			"data16 loop 0x004d",
			"loop 0x8000004c",
			"data16 jcxz 0x004e",
			"jcxz 0x8000004d",
			"data16 jecxz 0x004d",
			"jecxz 0x8000004c",
			"data16 call 0xa54e",
			"call 0x255a3407",
			"data16 jmp 0xa54e",
			"jmp 0x255a3407",
			"data16 jmp far 0x3412, 0x7856",
			"jmp far 0x78563412, 0xbcea",
			"data16 jmp 0x004d",
			"jmp 0x8000004c",
			"call cx",
			"call word ptr [eax]",
			"call ecx",
			"call dword ptr [eax]",
			"jmp dx",
			"jmp word ptr [eax]",
			"jmp edx",
			"jmp dword ptr [eax]",
			"push esi",
			"push dword ptr [eax]",
			"bndmov bnd1, bnd2",
			"bndmov bnd1, qword ptr [eax]",
			"bndcl bnd1, edx",
			"bndcl bnd1, [eax]",
			"bndcu bnd1, edx",
			"bndcu bnd1, [eax]",
			"bndmov bnd2, bnd1",
			"bndmov qword ptr [eax], bnd1",
			"bndmk bnd1, dword ptr [eax]",
			"bndcn bnd1, edx",
			"bndcn bnd1, [eax]",
			"mov esi, cr3",
			"mov esi, dr3",
			"mov cr3, esi",
			"mov dr3, esi",
			"vmread esi, ecx",
			"vmread dword ptr [eax], ebx",
			"vmwrite ecx, esi",
			"vmwrite ebx, dword ptr [eax]",
			"data16 jo 0xa54f",
			"jo 0xb412a550",
			"data16 jno 0xa54f",
			"jno 0xb412a550",
			"data16 jb 0xa54f",
			"jb 0xb412a550",
			"data16 jae 0xa54f",
			"jae 0xb412a550",
			"data16 je 0xa54f",
			"je 0xb412a550",
			"data16 jne 0xa54f",
			"jne 0xb412a550",
			"data16 jbe 0xa54f",
			"jbe 0xb412a550",
			"data16 ja 0xa54f",
			"ja 0xb412a550",
			"data16 js 0xa54f",
			"js 0xb412a550",
			"data16 jns 0xa54f",
			"jns 0xb412a550",
			"data16 jp 0xa54f",
			"jp 0xb412a550",
			"data16 jnp 0xa54f",
			"jnp 0xb412a550",
			"data16 jl 0xa54f",
			"jl 0xb412a550",
			"data16 jge 0xa54f",
			"jge 0xb412a550",
			"data16 jle 0xa54f",
			"jle 0xb412a550",
			"data16 jg 0xa54f",
			"jg 0xb412a550",
			"push fs",
			"pop fs",
			"push gs",
			"pop gs",
			"rdpid edx",
			"invept edx, [eax]",
			"invvpid edx, [eax]",
			"invpcid edx, [eax]",
			"salc",
			"data16 push 0xa55a",
			"data16 push 0xffa5",
			"insb [di], dx",
			"insb [edi], dx",
			"insw [di], dx",
			"insw [edi], dx",
			"insd [di], dx",
			"insd [edi], dx",
			"outsb dx, [si]",
			"outsb dx, [esi]",
			"outsw dx, [si]",
			"outsw dx, [esi]",
			"outsd dx, [si]",
			"outsd dx, [esi]",
			"mov fs, si",
			"data16 mov ds, [eax]",
			"mov fs, esi",
			"mov ds, [eax]",
			"pop si",
			"pop word ptr [eax]",
			"xchg ax, ax",
			"nop",
			"pushf",
			"popf",
			"mov al, [0xf0debc9a]",
			"addr16 mov al, [0xf0de]",
			"mov ax, [0xf0debc9a]",
			"addr16 mov ax, [0xf0de]",
			"mov eax, [0xf0debc9a]",
			"addr16 mov eax, [0xf0de]",
			"mov [0xf0debc9a], al",
			"addr16 mov [0xf0de], al",
			"mov [0xf0debc9a], ax",
			"addr16 mov [0xf0de], ax",
			"mov [0xf0debc9a], eax",
			"addr16 mov [0xf0de], eax",
			"movsb [di], [si]",
			"movsb [edi], [esi]",
			"movsw [di], [si]",
			"movsw [edi], [esi]",
			"movsd [di], [si]",
			"movsd [edi], [esi]",
			"cmpsb [si], [di]",
			"cmpsb [esi], [edi]",
			"cmpsw [si], [di]",
			"cmpsw [esi], [edi]",
			"cmpsd [si], [di]",
			"cmpsd [esi], [edi]",
			"stosb [di]",
			"stosb [edi]",
			"stosw [di]",
			"stosw [edi]",
			"stosd [di]",
			"stosd [edi]",
			"lodsb [si]",
			"lodsb [esi]",
			"lodsw [si]",
			"lodsw [esi]",
			"lodsd [si]",
			"lodsd [esi]",
			"scasb [di]",
			"scasb [edi]",
			"scasw [di]",
			"scasw [edi]",
			"scasd [di]",
			"scasd [edi]",
			"data16 xbegin 0x7fffa54f",
			"xbegin 0xb412a550",
			"data16 enter 0xa55a, 0xa6",
			"data16 leave",
			"data16 ret far 0xa55a",
			"ret far 0xa55a",
			"data16 ret far",
			"ret far",
			"iret",
			"iretd",
			"rol cl, cl",
			"rol byte ptr [eax], cl",
			"ror dl, cl",
			"ror byte ptr [eax], cl",
			"rcl bl, cl",
			"rcl byte ptr [eax], cl",
			"rcr ah, cl",
			"rcr byte ptr [eax], cl",
			"shl ch, cl",
			"shl byte ptr [eax], cl",
			"shr dh, cl",
			"shr byte ptr [eax], cl",
			"sar al, cl",
			"sar byte ptr [eax], cl",
			"rol cx, cl",
			"rol word ptr [eax], cl",
			"rol ecx, cl",
			"rol dword ptr [eax], cl",
			"ror dx, cl",
			"ror word ptr [eax], cl",
			"ror edx, cl",
			"ror dword ptr [eax], cl",
			"rcl bx, cl",
			"rcl word ptr [eax], cl",
			"rcl ebx, cl",
			"rcl dword ptr [eax], cl",
			"rcr sp, cl",
			"rcr word ptr [eax], cl",
			"rcr esp, cl",
			"rcr dword ptr [eax], cl",
			"shl bp, cl",
			"shl word ptr [eax], cl",
			"shl ebp, cl",
			"shl dword ptr [eax], cl",
			"shr si, cl",
			"shr word ptr [eax], cl",
			"shr esi, cl",
			"shr dword ptr [eax], cl",
			"sar ax, cl",
			"sar word ptr [eax], cl",
			"sar eax, cl",
			"sar dword ptr [eax], cl",
			"fldcw [eax]",
			"fnstcw [eax]",
			"fnstsw [eax]",
			"call far dword ptr [eax]",
			"call far fword ptr [eax]",
			"jmp far dword ptr [eax]",
			"jmp far fword ptr [eax]",
			"push si",
			"push word ptr [eax]",
			"sgdt [eax]",
			"sgdt [eax]",
			"sidt [eax]",
			"sidt [eax]",
			"lgdt [eax]",
			"lgdt [eax]",
			"lidt [eax]",
			"lidt [eax]",
			"lar cx, si",
			"lar bx, [eax]",
			"lar ecx, esi",
			"lar ebx, [eax]",
			"lsl cx, si",
			"lsl bx, [eax]",
			"lsl ecx, esi",
			"lsl ebx, [eax]",
			"bndldx bnd1, dword ptr [eax]",
			"bndstx dword ptr [eax], bnd1",
			"kmovw k2, k3",
			"kmovw k1, word ptr [eax]",
			"kmovb k2, k3",
			"kmovb k1, byte ptr [eax]",
			"kmovd k2, k3",
			"kmovd k1, dword ptr [eax]",
			"kmovw word ptr [eax], k1",
			"kmovb byte ptr [eax], k1",
			"kmovd dword ptr [eax], k1",
			"kmovw k2, ebx",
			"kmovb k2, ebx",
			"kmovd k2, ebx",
			"kmovw edx, k3",
			"kmovb edx, k3",
			"kmovd edx, k3",
			"kortestw k2, k3",
			"kortestq k2, k3",
			"kortestb k2, k3",
			"kortestd k2, k3",
			"ktestw k2, k3",
			"ktestq k2, k3",
			"ktestb k2, k3",
			"ktestd k2, k3",
			"data16 push fs",
			"data16 pop fs",
			"shld si, cx, cl",
			"shld [eax], bx, cl",
			"shld esi, ecx, cl",
			"shld [eax], ebx, cl",
			"data16 push gs",
			"data16 pop gs",
			"shrd si, cx, cl",
			"shrd [eax], bx, cl",
			"shrd esi, ecx, cl",
			"shrd [eax], ebx, cl",
			"lss bx, [eax]",
			"lss ebx, [eax]",
			"lfs bx, [eax]",
			"lfs ebx, [eax]",
			"lgs bx, [eax]",
			"lgs ebx, [eax]",
			"movzx cx, dh",
			"movzx bx, byte ptr [eax]",
			"movzx ecx, dh",
			"movzx ebx, byte ptr [eax]",
			"movzx cx, si",
			"movzx bx, word ptr [eax]",
			"movzx ecx, si",
			"movzx ebx, word ptr [eax]",
			"movsx cx, dh",
			"movsx bx, byte ptr [eax]",
			"movsx ecx, dh",
			"movsx ebx, byte ptr [eax]",
			"movsx cx, si",
			"movsx bx, word ptr [eax]",
			"movsx ecx, si",
			"movsx ebx, word ptr [eax]",
			"cmpxchg8b [eax]",
			"crc32 ecx, dh",
			"crc32 ebx, byte ptr [eax]",
			"crc32 ecx, si",
			"crc32 ebx, word ptr [eax]",
			"crc32 ecx, esi",
			"crc32 ebx, dword ptr [eax]",
			"addr16 maskmovq mmx2, mmx3",
			"maskmovq mmx2, mmx3",
			"addr16 maskmovdqu xmm2, xmm3",
			"maskmovdqu xmm2, xmm3",
			"addr16 vmaskmovdqu xmm2, xmm3",
			"vmaskmovdqu xmm2, xmm3",
			"outsb dx, fs:[esi]",
			"outsw dx, fs:[esi]",
			"outsd dx, fs:[esi]",
			"movsb es:[edi], fs:[esi]",
			"movsw es:[edi], fs:[esi]",
			"movsd es:[edi], fs:[esi]",
			"cmpsb fs:[esi], es:[edi]",
			"cmpsw fs:[esi], es:[edi]",
			"cmpsd fs:[esi], es:[edi]",
			"lodsb fs:[esi]",
			"lodsw fs:[esi]",
			"lodsd fs:[esi]",
			"xlat [bx]",
			"xlat fs:[ebx]",
			"maskmovq mmx2, mmx3, fs",
			"maskmovdqu xmm2, xmm3, fs",
			"vmaskmovdqu xmm2, xmm3, fs",
			"xlat [ebx]",
			"aam 0xfa",
			"aad 0xfa",
			"fldenv fpuenv14 ptr [eax]",
			"fldenv [eax]",
			"fnstenv fpuenv14 ptr [eax]",
			"fnstenv [eax]",
			"frstor fpustate94 ptr [eax]",
			"frstor [eax]",
			"fnsave fpustate94 ptr [eax]",
			"fnsave [eax]",
			"addr16 monitor",
			"monitor",
			"mwait",
			"mov al, fs:[0xf0debc9a]",
			"addr16 mov al, fs:[0xf0de]",
			"mov ax, fs:[0xf0debc9a]",
			"addr16 mov ax, fs:[0xf0de]",
			"mov eax, fs:[0xf0debc9a]",
			"addr16 mov eax, fs:[0xf0de]",
			"mov fs:[0xf0debc9a], al",
			"addr16 mov fs:[0xf0de], al",
			"mov fs:[0xf0debc9a], ax",
			"addr16 mov fs:[0xf0de], ax",
			"mov fs:[0xf0debc9a], eax",
			"addr16 mov fs:[0xf0de], eax",
			"mov cl, [eax]",
			"mov cl, [eax-0x12]",
			"mov cl, [eax-0x12345678]",
			"mov cl, [0xedcba988]",
			"mov cl, [eax+0x12]",
			"mov cl, [eax+0x12345678]",
			"mov cl, [0x12345678]",
			"mov cl, [eax+ecx]",
			"mov cl, [eax+ecx*2]",
			"mov cl, [eax+ecx*4]",
			"mov cl, [eax+ecx*8]",
			"mov cl, [eax+ecx-0x12]",
			"mov cl, [eax+ecx*2-0x12]",
			"mov cl, [eax+ecx*4-0x12]",
			"mov cl, [eax+ecx*8-0x12]",
			"mov cl, [eax+ecx+0x12]",
			"mov cl, [eax+ecx*2+0x12]",
			"mov cl, [eax+ecx*4+0x12]",
			"mov cl, [eax+ecx*8+0x12]",
			"mov cl, [eax+ecx-0x12345678]",
			"mov cl, [eax+ecx*2-0x12345678]",
			"mov cl, [eax+ecx*4-0x12345678]",
			"mov cl, [eax+ecx*8-0x12345678]",
			"mov cl, [eax+ecx+0x12345678]",
			"mov cl, [eax+ecx*2+0x12345678]",
			"mov cl, [eax+ecx*4+0x12345678]",
			"mov cl, [eax+ecx*8+0x12345678]",
			"mov cl, [ecx*1-0x12345678]",
			"mov cl, [ebp+ecx*2-0x12]",
			"mov cl, [ebp+ecx*4-0x12345678]",
			"mov cl, [ecx*8-0x12345678]",
			"mov cl, [ecx*1+0x12345678]",
			"mov cl, [ebp+ecx*2+0x12]",
			"mov cl, [ebp+ecx*4+0x12345678]",
			"mov cl, [ecx*8+0x12345678]",
			"mov cl, fs:[eax]",
			"mov cl, fs:[eax-0x12]",
			"mov cl, fs:[eax-0x12345678]",
			"mov cl, fs:[0xedcba988]",
			"mov cl, fs:[eax+0x12]",
			"mov cl, fs:[eax+0x12345678]",
			"mov cl, fs:[0x12345678]",
			"mov cl, fs:[eax+ecx]",
			"mov cl, fs:[eax+ecx*2]",
			"mov cl, fs:[eax+ecx*4]",
			"mov cl, fs:[eax+ecx*8]",
			"mov cl, fs:[eax+ecx-0x12]",
			"mov cl, fs:[eax+ecx*2-0x12]",
			"mov cl, fs:[eax+ecx*4-0x12]",
			"mov cl, fs:[eax+ecx*8-0x12]",
			"mov cl, fs:[eax+ecx+0x12]",
			"mov cl, fs:[eax+ecx*2+0x12]",
			"mov cl, fs:[eax+ecx*4+0x12]",
			"mov cl, fs:[eax+ecx*8+0x12]",
			"mov cl, fs:[eax+ecx-0x12345678]",
			"mov cl, fs:[eax+ecx*2-0x12345678]",
			"mov cl, fs:[eax+ecx*4-0x12345678]",
			"mov cl, fs:[eax+ecx*8-0x12345678]",
			"mov cl, fs:[eax+ecx+0x12345678]",
			"mov cl, fs:[eax+ecx*2+0x12345678]",
			"mov cl, fs:[eax+ecx*4+0x12345678]",
			"mov cl, fs:[eax+ecx*8+0x12345678]",
			"mov cl, fs:[ecx*1-0x12345678]",
			"mov cl, fs:[ebp+ecx*2-0x12]",
			"mov cl, fs:[ebp+ecx*4-0x12345678]",
			"mov cl, fs:[ecx*8-0x12345678]",
			"mov cl, fs:[ecx*1+0x12345678]",
			"mov cl, fs:[ebp+ecx*2+0x12]",
			"mov cl, fs:[ebp+ecx*4+0x12345678]",
			"mov cl, fs:[ecx*8+0x12345678]",
			"addr16 vmrun",
			"vmrun",
			"addr16 vmload",
			"vmload",
			"addr16 vmsave",
			"vmsave",
			"addr16 invlpga",
			"invlpga",
			"addr16 monitorx",
			"monitorx",
			"clzero ax",
			"clzero eax",
			"add cl, 0x5a",
			"add byte ptr [eax], 0x5a",
			"or dl, 0xa5",
			"or byte ptr [eax], 0xa5",
			"adc bl, 0x5a",
			"adc byte ptr [eax], 0x5a",
			"sbb ah, 0xa5",
			"sbb byte ptr [eax], 0xa5",
			"and ch, 0x5a",
			"and byte ptr [eax], 0x5a",
			"sub dh, 0xa5",
			"sub byte ptr [eax], 0xa5",
			"xor bh, 0x5a",
			"xor byte ptr [eax], 0x5a",
			"cmp al, 0xa5",
			"cmp byte ptr [eax], 0xa5",
			"frstpm",
			"fstdw ax",
			"fstsg ax",
			"jmpe cx",
			"jmpe word ptr [eax]",
			"jmpe edx",
			"jmpe dword ptr [eax]",
			"loadallreset286",
			"loadall286",
			"loadall386",
			"cflsh",
			"umov dh, cl",
			"umov [eax], bl",
			"umov si, cx",
			"umov [eax], bx",
			"umov esi, ecx",
			"umov [eax], ebx",
			"umov cl, dh",
			"umov bl, [eax]",
			"umov cx, si",
			"umov bx, [eax]",
			"umov ecx, esi",
			"umov ebx, [eax]",
			"mov esi, tr3",
			"mov tr3, esi",
			"wrecr",
			"rdecr",
			"xbts cx, si",
			"xbts bx, [eax]",
			"xbts ecx, esi",
			"xbts ebx, [eax]",
			"ibts si, cx",
			"ibts [eax], bx",
			"ibts esi, ecx",
			"ibts [eax], ebx",
			"cmpxchg486 dh, cl",
			"cmpxchg486 [eax], bl",
			"cmpxchg486 si, cx",
			"cmpxchg486 [eax], bx",
			"cmpxchg486 esi, ecx",
			"cmpxchg486 [eax], ebx",
			"zalloc [eax]",
			"umonitor bp",
			"umonitor ebp",
			"jmpe 0xa55a",
			"jmpe 0xa55a3412",
			"movdir64b bx, [bx+si]",
			"movdir64b ebx, [eax]",
			"mov eax, tr0",
			"mov eax, tr1",
			"mov eax, tr2",
			"mov eax, tr3",
			"mov eax, tr4",
			"mov eax, tr5",
			"mov eax, tr6",
			"mov eax, tr7",
		};
	}
}
#endif
