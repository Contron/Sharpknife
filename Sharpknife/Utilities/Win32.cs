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

		#region External Methods

		[DllImport("user32.dll")]
		private static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

		#endregion
	}
}
