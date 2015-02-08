using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Common
{
	/// <summary>
	/// Represents a handle wrapper for a native <see cref="IntPtr" /> pointer on the operating system.
	/// </summary>
	public class NativeHandle : IDisposable
	{
		/// <summary>
		/// Creates a new native handle.
		/// </summary>
		/// <param name="pointer">the pointer</param>
		public NativeHandle(IntPtr pointer)
		{
			this.Pointer = pointer;
		}

		/// <summary>
		/// Destroys the native handle.
		/// </summary>
		~NativeHandle()
		{
			this.Dispose();
		}

		/// <summary>
		/// Disposes of the handle.
		/// </summary>
		public void Dispose()
		{
			//close
			Win32.CloseHandle(this.Pointer);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// The pointer for the handle.
		/// </summary>
		public IntPtr Pointer
		{
			get;
			set;
		}
	}
}
