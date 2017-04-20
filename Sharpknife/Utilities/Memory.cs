using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// Provides a collection of methods to read and write process' memory.
	/// </summary>
	public static class Memory
	{
		/// <summary>
		/// Opens the specified process for memory operations.
		/// </summary>
		/// <param name="process">the process</param>
		/// <returns>the handle</returns>
		public static IntPtr Open(Process process)
		{
			return Memory.OpenProcess(0x0010 | 0x0020 | 0x0008, false, process.Id);
		}

		/// <summary>
		/// Reads the specified number of bytes from the specified process' address.
		/// </summary>
		/// <param name="handle">the process' handle</param>
		/// <param name="address">the address</param>
		/// <param name="length">the length to read</param>
		/// <returns>the buffer</returns>
		public static byte[] Read(IntPtr handle, IntPtr address, int length)
		{
			var buffer = new byte[length];
			var read = 0;

			Memory.ReadProcessMemory(handle.ToInt32(), address.ToInt32(), buffer, buffer.Length, ref read);

			return buffer;
		}

		/// <summary>
		/// Writes the specified buffer to the specified process' address.
		/// </summary>
		/// <param name="handle">the process' handle</param>
		/// <param name="address">the address</param>
		/// <param name="buffer">the buffer</param>
		public static void Write(IntPtr handle, IntPtr address, byte[] buffer)
		{
			var written = 0;

			Memory.WriteProcessMemory(handle.ToInt32(), address.ToInt32(), buffer, buffer.Length, ref written);
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);
	}
}
