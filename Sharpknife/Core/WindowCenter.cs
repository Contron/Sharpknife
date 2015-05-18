using Microsoft.Win32;
using Sharpknife.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents a windowing center to independently show and close <see cref="Window" /> objects.
	/// </summary>
	public class WindowCenter
	{
		/// <summary>
		/// Creates a new window center.
		/// </summary>
		public WindowCenter()
		{
			this.windows = new List<Window>();
		}

		/// <summary>
		/// Shows the specified window, using the currently active window as a parent.
		/// </summary>
		/// <param name="window">the window</param>
		public void Show(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}

			this.PrepareWindow(window).Show();
		}

		/// <summary>
		/// Shows the specified window modally, using the currently active window as a parent.
		/// </summary>
		/// <param name="window">the window</param>
		/// <returns>the result</returns>
		public bool ShowModally(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}

			var result = this.PrepareWindow(window).ShowDialog();
			var actual = result.HasValue ? result.Value : false;

			return actual;
		}

		/// <summary>
		/// Shows the specified window, ensuring that only one instance is visible.
		/// If an existing instance is visible, it will be brought to the front.
		/// </summary>
		/// <param name="window">the window</param>
		public void ShowOnce(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}

			var duplicate = this.windows
				.Where(child => child.GetType() == window.GetType())
				.FirstOrDefault();

			if (duplicate != null)
			{
				window.Close();

				duplicate.Activate();
				duplicate.Focus();

				if (duplicate.WindowState == WindowState.Minimized)
				{
					duplicate.WindowState = WindowState.Normal;
				}
			}
			else
			{
				window.Show();
			}
		}

		/// <summary>
		/// Shows the specified file dialog modally, using the currently active window as a parent.
		/// </summary>
		/// <param name="dialog">the dialog</param>
		/// <returns>the path</returns>
		public string ShowFileDialog(FileDialog dialog)
		{
			if (dialog == null)
			{
				throw new ArgumentNullException("dialog");
			}

			var owner = this.GetCurrentWindow();
			var result = dialog.ShowDialog(owner);
			var actual = result == true ? dialog.FileName : null;

			return actual;
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
		/// Closes the currently active window, if any.
		/// </summary>
		/// <param name="result">the dialog result</param>
		public void CloseCurrentWindow(bool result = false)
		{
			//find
			var window = this.GetCurrentWindow();

			if (window != null)
			{
				if (result)
				{
					window.DialogResult = true;
				}

				window.Close();
			}
		}

		/// <summary>
		/// Returns the currently active window, if there is one.
		/// </summary>
		/// <returns>the currently active window</returns>
		public Window GetCurrentWindow()
		{
			var window = Application.Current.Windows
				.OfType<Window>()
				.Where(child => child.IsActive)
				.FirstOrDefault();

			return window;
		}

		private Window PrepareWindow(Window window)
		{
			window.Owner = this.GetCurrentWindow();
			window.Loaded += (sender, eventArgs) => this.windows.Add(window);
			window.Closed += (sender, eventArgs) => this.windows.Remove(window);

			return window;
		}

		/// <summary>
		/// Gets the instance of the window center.
		/// </summary>
		public static readonly WindowCenter Instance = new WindowCenter();

		private List<Window> windows;
	}
}
