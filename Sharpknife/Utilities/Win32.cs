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
	public static class Win32
	{
		/// <summary>
		/// Flashes the specified <see cref="Form" /> in the task bar.
		/// </summary>
		/// <param name="form">the form</param>
		public static void FlashWindow(Form form)
		{
			if (form == null)
			{
				throw new ArgumentNullException("form");
			}

			Win32.Internal.FlashWindow(form.Handle, false);
		}

		/// <summary>
		/// Sends a message to the specified <see cref="Control" />.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(Control control, uint message, IntPtr data)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}

			if (data == null)
			{
				throw new ArgumentNullException("data");
			}

			Win32.Internal.SendMessage(control.Handle, message, IntPtr.Zero, data);
		}

		/// <summary>
		/// Sends a message to the specified <see cref="Control" />.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(Control control, uint message, string data)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}

			if (data == null)
			{
				throw new ArgumentNullException("data");
			}

			Win32.Internal.SendMessage(control.Handle, message, IntPtr.Zero, data);
		}

		/// <summary>
		/// Sends a message to the specified <see cref="Control" />.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(Control control, uint message, bool data)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}

			Win32.Internal.SendMessage(control.Handle, message, IntPtr.Zero, data);
		}

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

			return Win32.Internal.OpenProcess(Win32.Constants.PROCESS_VM_OPERATION | Win32.Constants.PROCESS_WM_READ | Win32.Constants.PROCESS_VM_WRITE, false, process.Id);
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
