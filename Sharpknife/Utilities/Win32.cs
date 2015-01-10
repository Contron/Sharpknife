using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// A collection of native Win32 methods that are encapsulated in friendly methods.
	/// </summary>
	public class Win32
	{
		/// <summary>
		/// Flashes the specified form in the task bar.
		/// </summary>
		/// <param name="form">the form</param>
		public static void FlashWindow(Form form)
		{
			Win32.FlashWindow(form.Handle, false);
		}

		/// <summary>
		/// Sends a message to the specified control.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(Control control, uint message, IntPtr data)
		{
			Win32.SendMessage(control.Handle, message, IntPtr.Zero, data);
		}

		/// <summary>
		/// Sends a message to the specified control.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(Control control, uint message, string data)
		{
			Win32.SendMessage(control.Handle, message, IntPtr.Zero, data);
		}

		/// <summary>
		/// Sends a message to the specified control.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(Control control, uint message, bool data)
		{
			Win32.SendMessage(control.Handle, message, IntPtr.Zero, data);
		}

		#region External Methods

		[DllImport("user32.dll")]
		private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, bool lParam);

		#endregion

		public class Constants
		{
			public static readonly int BS_COMMANDLINK = 0x0000000E;

			public static readonly uint BCM_SETNOTE = 0x00001609;
			public static readonly uint BCM_GETNOTE = 0x0000160A;
			public static readonly uint BCM_GETNOTELENGTH = 0x0000160B;

			public static readonly uint BCM_SETSHIELD = 0x0000160C;
		}
	}
}
