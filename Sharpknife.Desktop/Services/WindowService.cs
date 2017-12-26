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

			this.InternalShow(window, false);
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

			var duplicate = Application.Current.Windows
				.OfType<Window>()
				.FirstOrDefault(child => child.GetType() == window.GetType());

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
				this.InternalShow(window, false);
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

			this.InternalShow(window, true);
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

			this.InternalClose(window);
		}

		/// <summary>
		/// Closes the currently active window.
		/// </summary>
		public void CloseActive()
		{
			var window = this.Active;

			if (window != null)
			{
				this.InternalClose(window);
			}
		}

		private void InternalShow(Window window, bool modal)
		{
			window.Dispatcher.Invoke(() =>
			{
				window.Owner = this.Active;

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

		private void InternalClose(Window window)
		{
			window.Dispatcher.Invoke(() =>
			{
				window.Close();
			});
		}

		/// <summary>
		/// Gets the instance of the window service.
		/// </summary>
		public static WindowService Instance => WindowService.instance;

		/// <summary>
		/// Gets the currently active window.
		/// </summary>
		public Window Active => Application.Current.Windows
			.OfType<Window>()
			.FirstOrDefault(window => window.IsActive);

		private static readonly WindowService instance = new WindowService();
	}
}
