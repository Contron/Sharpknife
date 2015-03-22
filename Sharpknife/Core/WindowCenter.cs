using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

			//show
			this.Prepare(window).Show();
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

			//show
			var result = this.Prepare(window).ShowDialog();
			var actual = result.HasValue ? result.Value : false;

			return actual;
		}

		/// <summary>
		/// Shows the specified window, ensuring that only one instance is visible.
		/// If an existing instance is visible, it will be brought to the front.
		/// </summary>
		/// <param name="window"></param>
		public void ShowOnce(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}

			//find
			var duplicate = this.windows.Where(child => child.GetType() == window.GetType()).FirstOrDefault();

			if (duplicate != null)
			{
				//cancel
				window.Close();

				//highlight
				duplicate.Activate();
				duplicate.Focus();

				if (duplicate.WindowState == WindowState.Minimized)
				{
					//display
					duplicate.WindowState = WindowState.Normal;
				}
			}
			else
			{
				//show
				this.Show(window);
			}
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

			//close
			window.Close();
		}

		/// <summary>
		/// Closes the currently active window, if any.
		/// </summary>
		public void CloseCurrentWindow()
		{
			//find
			var window = this.GetCurrentWindow();

			if (window != null)
			{
				//close
				window.Close();
			}
		}

		/// <summary>
		/// Returns the currently active window, if there is one.
		/// </summary>
		/// <returns>the currently active window</returns>
		public Window GetCurrentWindow()
		{
			//find
			var window = Application.Current.Windows.OfType<Window>()
				.Where(child => child.IsActive)
				.FirstOrDefault();

			return window;
		}

		private Window Prepare(Window window)
		{
			//hook
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
