using Microsoft.Win32;
using Sharpknife.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a window service to display <see cref="Window" />s.
	/// </summary>
	public class WindowService
	{
		/// <summary>
		/// Creates a new window service.
		/// </summary>
		public WindowService()
		{

		}

		/// <summary>
		/// Opens the specified window.
		/// </summary>
		/// <param name="window">the window</param>
		public void Open(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}

			this.Open(window, false);
		}

		/// <summary>
		/// Opens the specified window modally.
		/// </summary>
		/// <param name="window">the window</param>
		public void OpenModally(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}

			this.Open(window, true);
		}

		/// <summary>
		/// Closes the specified window.
		/// </summary>
		/// <param name="window">the window</param>
		public void Close(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}

			window.Close();
		}

		/// <summary>
		/// Closes the current window.
		/// </summary>
		public void CloseCurrent()
		{
			var window = this.GetCurrent();

			if (window != null)
			{
				window.Close();
			}
		}

		/// <summary>
		/// Returns the currently window.
		/// </summary>
		/// <returns>the window</returns>
		public Window GetCurrent()
		{
			var window = Application.Current.Windows
				.OfType<Window>()
				.FirstOrDefault(child => child.IsActive);

			return window;
		}

		private void Open(Window window, bool modal)
		{
			window.Owner = this.GetCurrent();

			if (modal)
			{
				window.ShowDialog();
			}
			else
			{
				window.Show();
			}
		}

		/// <summary>
		/// Gets the instance of the window service.
		/// </summary>
		public static readonly WindowService Instance = new WindowService();
	}
}
