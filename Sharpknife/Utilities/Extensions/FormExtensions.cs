using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpknife.Utilities.Extensions
{
	/// <summary>
	/// A collection of <see cref="Form" /> extension methods.
	/// </summary>
	public static class FormExtensions
	{
		/// <summary>
		/// Flashes the window in the task bar.
		/// </summary>
		/// <param name="form">the form</param>
		public static void FlashInTaskbar(this Form form)
		{
			Win32.FlashWindow(form);
		}
	}
}
