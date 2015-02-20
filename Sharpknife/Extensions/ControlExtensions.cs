using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpknife.Extensions
{
	/// <summary>
	/// A collection of <see cref="Control" /> extension methods.
	/// </summary>
	public static class ControlExtensions
	{
		/// <summary>
		/// Invokes the specified action if required on the control's thread.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="action">the action</param>
		public static void InvokeIfRequired(this Control control, Action action)
		{
			if (control.InvokeRequired)
			{
				control.Invoke(action);
			}
			else
			{
				action();
			}
		}

		/// <summary>
		/// Sends a string message to the control.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(this Control control, uint message, string data)
		{
			Win32.SendMessage(control, message, data);
		}

		/// <summary>
		/// Sends a bool message to the control.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(this Control control, uint message, bool data)
		{
			Win32.SendMessage(control, message, data);
		}

		/// <summary>
		/// Sends a pointer message to the control.
		/// </summary>
		/// <param name="control">the control</param>
		/// <param name="message">the message</param>
		/// <param name="data">the data</param>
		public static void SendMessage(this Control control, uint message, IntPtr data)
		{
			Win32.SendMessage(control, message, data);
		}
	}
}
