using Microsoft.Win32;
using Sharpknife.Desktop.Views;
using Sharpknife.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a dialog service to display common dialogs.
	/// </summary>
	public class DialogService
	{
		/// <summary>
		/// Creates a new dialog service.
		/// </summary>
		public DialogService()
		{
			this.progress = null;
		}

		/// <summary>
		/// Shows a file dialog.
		/// </summary>
		/// <param name="dialog">the dialog</param>
		/// <returns>the path, or null</returns>
		public string ShowFileDialog(FileDialog dialog)
		{
			var result = dialog.ShowDialog(WindowService.Instance.GetCurrent());
			var path = result.HasValue ? dialog.FileName : null;

			return path;
		}

		/// <summary>
		/// Shows a message dialog with the specified title and message.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public void ShowMessage(string title, string message)
		{
			var view = new MessageView()
			{
				DataContext = new MessageViewModel(title, message),
				Owner = WindowService.Instance.GetCurrent()
			};

			view.ShowDialog();
		}

		/// <summary>
		/// Shows an about dialog.
		/// </summary>
		public void ShowAbout()
		{
			var view = new AboutView()
			{
				Owner = WindowService.Instance.GetCurrent()
			};

			view.ShowDialog();
		}

		/// <summary>
		/// Shows the progress view.
		/// </summary>
		/// <param name="status">the status</param>
		public void ShowProgress(string status)
		{
			if (this.progress != null)
			{
				throw new InvalidOperationException();
			}

			this.progress = new ProgressView()
			{
				DataContext = new ProgressViewModel(status),
				Owner = WindowService.Instance.GetCurrent()
			};

			Task.Run(() => this.progress.Dispatcher.Invoke(() =>
			{
				this.progress.ShowDialog();
			}));
		}

		/// <summary>
		/// Closes the progress view.
		/// </summary>
		public void CloseProgress()
		{
			if (this.progress == null)
			{
				throw new InvalidOperationException();
			}

			var viewModel = this.progress.DataContext as ProgressViewModel;

			if (viewModel != null)
			{
				viewModel.Busy = false;
			}

			this.progress.Hide();
			this.progress = null;
		}

		/// <summary>
		/// Gets the instance of the dialog service.
		/// </summary>
		public static readonly DialogService Instance = new DialogService();

		private ProgressView progress;
	}
}
