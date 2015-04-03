﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// A collection of native Win32 methods that are encapsulated in managed methods.
	/// </summary>
	public static class Win32
	{
		/// <summary>
		/// Opens a handle to a <see cref="Process" />.
		/// </summary>
		/// <param name="process">the process</param>
		/// <returns>the handle</returns>
		public static IntPtr OpenProcess(Process process)
		{
			if (process == null)
			{
				throw new ArgumentNullException("process");
			}

			return Win32.Internal.OpenProcess(0x0008 | 0x0010 | 0x0020, false, process.Id);
		}

		/// <summary>
		/// Reads from the memory of a <see cref="Process" /> into the specified buffer.
		/// </summary>
		/// <param name="pointer">the pointer</param>
		/// <param name="address">the address</param>
		/// <param name="length">the length</param>
		/// <returns>the read memory</returns>
		public static byte[] ReadProcessMemory(IntPtr pointer, IntPtr address, int length)
		{
			if (pointer == null)
			{
				throw new ArgumentNullException("pointer");
			}

			if (address == null)
			{
				throw new ArgumentNullException("pointer");
			}

			if (length <= 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			//context
			var buffer = new byte[length];
			var bytesRead = 0;
			
			//read
			Win32.Internal.ReadProcessMemory(pointer, address, buffer, buffer.Length, ref bytesRead);

			return buffer;
		}

		/// <summary>
		/// Writes to the memory of a <see cref="Process" /> from the specified buffer.
		/// </summary>
		/// <param name="pointer">the pointer</param>
		/// <param name="address">the address</param>
		/// <param name="buffer">the buffer</param>
		/// <returns>if memory was written successfully</returns>
		public static bool WriteProcessMemory(IntPtr pointer, IntPtr address, byte[] buffer)
		{
			if (pointer == null)
			{
				throw new ArgumentNullException("pointer");
			}

			if (address == null)
			{
				throw new ArgumentNullException("pointer");
			}

			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}

			//context
			var bytesWritten = 0;
			var success = Win32.Internal.WriteProcessMemory(pointer, address, buffer, buffer.Length, ref bytesWritten);

			return success;
		}

		/// <summary>
		/// Closes a <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">the handle</param>
		/// <returns>if the handle was closed successfully</returns>
		public static bool CloseHandle(IntPtr handle)
		{
			if (handle == null)
			{
				throw new ArgumentNullException("handle");
			}

			return Win32.Internal.CloseHandle(handle);
		}

		/// <summary>
		/// Returns the last Win32 error message.
		/// This does not actually call a native method, but is rather a convenience method that wraps the <see cref="Marshal.GetLastWin32Error" /> method for consistency.
		/// </summary>
		/// <returns></returns>
		public static int GetLastError()
		{
			return Marshal.GetLastWin32Error();
		}

		internal class Internal
		{
			[DllImport("kernel32.dll", SetLastError = true)]
			internal static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

			[DllImport("kernel32.dll", SetLastError = true)]
			internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

			[DllImport("kernel32.dll", SetLastError = true)]
			internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

			[DllImport("kernel32.dll", SetLastError = true)]
			internal static extern bool CloseHandle(IntPtr hObject);
		}
	}
}
