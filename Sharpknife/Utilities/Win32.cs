using System;
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
	public class Win32
	{
		/// <summary>
		/// Flashes the specified form in the task bar.
		/// </summary>
		/// <param name="form">the form</param>
		public static void FlashWindow(Form form)
		{
			Win32.Internal.FlashWindow(form.Handle, false);
		}

		/// <summary>
		/// Sends a message to the specified control.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(Control control, uint message, IntPtr data)
		{
			Win32.Internal.SendMessage(control.Handle, message, IntPtr.Zero, data);
		}

		/// <summary>
		/// Sends a message to the specified control.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(Control control, uint message, string data)
		{
			Win32.Internal.SendMessage(control.Handle, message, IntPtr.Zero, data);
		}

		/// <summary>
		/// Sends a message to the specified control.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(Control control, uint message, bool data)
		{
			Win32.Internal.SendMessage(control.Handle, message, IntPtr.Zero, data);
		}

		/// <summary>
		/// Opens a handle to a process.
		/// </summary>
		/// <param name="process">the process</param>
		/// <returns>the handle</returns>
		public static IntPtr OpenProcess(Process process)
		{
			return Win32.Internal.OpenProcess(Win32.Constants.PROCESS_VM_OPERATION | Win32.Constants.PROCESS_WM_READ | Win32.Constants.PROCESS_VM_WRITE, false, process.Id);
		}

		/// <summary>
		/// Reads from a process' memory into the specified buffer.
		/// </summary>
		/// <param name="pointer">the pointer</param>
		/// <param name="address">the address</param>
		/// <param name="buffer">the buffer</param>
		/// <param name="bytesRead">the number of bytes read</param>
		/// <returns>if memory was read successfully</returns>
		public static bool ReadProcessMemory(IntPtr pointer, IntPtr address, byte[] buffer, ref int bytesRead)
		{
			return Win32.Internal.ReadProcessMemory(pointer, address, buffer, buffer.Length, ref bytesRead);
		}

		/// <summary>
		/// Writes to a process' memory from the specified buffer.
		/// </summary>
		/// <param name="pointer">the pointer</param>
		/// <param name="address">the address</param>
		/// <param name="buffer">the buffer</param>
		/// <param name="bytesWritten">the number of bytes written</param>
		/// <returns>if memory was written successfully</returns>
		public static bool WriteProcessMemory(IntPtr pointer, IntPtr address, byte[] buffer, ref int bytesWritten)
		{
			return Win32.Internal.WriteProcessMemory(pointer, address, buffer, buffer.Length, ref bytesWritten);
		}

		/// <summary>
		/// Closes a handle.
		/// </summary>
		/// <param name="handle">the handle</param>
		/// <returns>if the handle was closed successfully</returns>
		public static bool CloseHandle(IntPtr handle)
		{
			return Win32.Internal.CloseHandle(handle);
		}

		/// <summary>
		/// Returns the last Win32 error message.
		/// This does not actually call a native method, but is rather a convenience method that wraps the <see cref="Marshal.GetLastWin32Error" /> method.
		/// </summary>
		/// <returns></returns>
		public static int GetLastError()
		{
			return Marshal.GetLastWin32Error();
		}

		/// <summary>
		/// A collection of common Win32 external methods.
		/// </summary>
		public class Internal
		{
			#pragma warning disable 1591

			[DllImport("user32.dll")]
			public static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

			[DllImport("user32.dll", CharSet = CharSet.Unicode)]
			public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

			[DllImport("user32.dll", CharSet = CharSet.Unicode)]
			public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

			[DllImport("user32.dll", CharSet = CharSet.Unicode)]
			public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, bool lParam);

			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern bool CloseHandle(IntPtr hObject);

			#pragma warning restore 1591
		}

		/// <summary>
		/// A collection of common Win32 message codes.
		/// </summary>
		public class Constants
		{
			#pragma warning disable 1591

			public static readonly int BS_COMMANDLINK = 0x0000000E;

			public static readonly int PROCESS_WM_READ = 0x0010;
			public static readonly int PROCESS_VM_WRITE = 0x0020;
			public static readonly int PROCESS_VM_OPERATION = 0x0008;

			public static readonly uint BCM_SETNOTE = 0x00001609;
			public static readonly uint BCM_GETNOTE = 0x0000160A;
			public static readonly uint BCM_GETNOTELENGTH = 0x0000160B;

			public static readonly uint BCM_SETSHIELD = 0x0000160C;

			#pragma warning restore 1591
		}
	}
}
