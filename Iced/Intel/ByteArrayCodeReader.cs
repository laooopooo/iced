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

#if (!NO_DECODER32 || !NO_DECODER64) && !NO_DECODER
using System;

namespace Iced.Intel {
	/// <summary>
	/// A <see cref="CodeReader"/> that reads data from a byte array
	/// </summary>
	public sealed class ByteArrayCodeReader : CodeReader {
		readonly byte[] data;
		int currentPosition;
		readonly int startPosition;
		readonly int endPosition;

		/// <summary>
		/// Current position
		/// </summary>
		public int Position {
			get => currentPosition - startPosition;
			set {
				if ((uint)value > (uint)Count)
					throw new ArgumentOutOfRangeException(nameof(value));
				currentPosition = startPosition + value;
			}
		}

		/// <summary>
		/// Number of bytes that can be read
		/// </summary>
		public int Count => endPosition - startPosition;

		/// <summary>
		/// Checks if it's possible to read another byte
		/// </summary>
		public bool CanReadByte => currentPosition < endPosition;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="hexData">Hex bytes encoded in a string</param>
		public ByteArrayCodeReader(string hexData)
			: this(HexUtils.ToByteArray(hexData)) {
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">Data</param>
		public ByteArrayCodeReader(byte[] data) {
			this.data = data ?? throw new ArgumentNullException(nameof(data));
			currentPosition = 0;
			startPosition = 0;
			endPosition = data.Length;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">Data</param>
		/// <param name="index">Start index</param>
		/// <param name="count">Number of bytes</param>
		public ByteArrayCodeReader(byte[] data, int index, int count) {
			this.data = data ?? throw new ArgumentNullException(nameof(data));
			if (index < 0)
				throw new ArgumentOutOfRangeException(nameof(index));
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count));
			if ((ulong)(uint)index + (uint)count > (uint)data.Length)
				throw new ArgumentOutOfRangeException(nameof(count));
			currentPosition = index;
			startPosition = index;
			endPosition = index + count;
		}

		/// <summary>
		/// Reads the next byte or returns less than 0 if there are no more bytes
		/// </summary>
		/// <returns></returns>
		public override int ReadByte() {
			if (currentPosition >= endPosition)
				return -1;
			return data[currentPosition++];
		}
	}
}
#endif
