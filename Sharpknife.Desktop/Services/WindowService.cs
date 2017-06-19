using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a window service to display <see cref="Window" />s.
	/// </summary>
	public sealed class WindowService
	{
		private WindowService()
		{
			this.windows = new List<Window>();
		}

		/// <summary>
		/// Shows the specified window.
		/// </summary>
		/// <param name="window">the window</param>
		public void Show(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException(nameof(window));
			}

			this.DoShow(window, false);
		}

		/// <summary>
		/// Shows the specified window once.
		/// </summary>
		/// <param name="window"></param>
		public void ShowOnce(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException(nameof(window));
			}

			var duplicate = this.windows.FirstOrDefault(child => child.GetType() == window.GetType());

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
				this.DoShow(window, false);
			}
		}

		/// <summary>
		/// Shows the specified window modally.
		/// </summary>
		/// <param name="window">the window</param>
		public void ShowModally(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException(nameof(window));
			}

			this.DoShow(window, true);
		}

		/// <summary>
		/// Closes the specified window.
		/// </summary>
		/// <param name="window">the window</param>
		public void Close(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException(nameof(window));
			}

			this.DoClose(window);
		}

		/// <summary>
		/// Closes the currently active window.
		/// </summary>
		public void CloseActive()
		{
			var window = this.GetActive();

			if (window != null)
			{
				this.DoClose(window);
			}
		}

		/// <summary>
		/// Returns the currently active window.
		/// </summary>
		/// <returns>the window</returns>
		public Window GetActive()
		{
			return Application.Current.Windows
				.OfType<Window>()
				.FirstOrDefault(window => window.IsActive);
		}

		private void DoShow(Window window, bool modal)
		{
			this.windows.Add(window);

			window.Dispatcher.Invoke(() =>
			{
				window.Owner = this.GetActive();

				if (modal)
				{
					window.ShowDialog();
				}
				else
				{
					window.Show();
				}
			});
		}

		private void DoClose(Window window)
		{
			this.windows.Remove(window);

			window.Dispatcher.Invoke(() =>
			{
				window.Close();
			});
		}

		/// <summary>
		/// Gets the instance of the window service.
		/// </summary>
		public static WindowService Instance => WindowService.instance;

		private static readonly WindowService instance = new WindowService();

		private List<Window> windows;
	}
}
