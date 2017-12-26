using System;
using Microsoft.Win32;
using Sharpknife.Desktop.ViewModels;
using Sharpknife.Desktop.Views;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a dialog service to display common dialogs.
	/// </summary>
	public sealed class DialogService
	{
		private DialogService()
		{

		}

		/// <summary>
		/// Shows an <see cref="OpenFileDialog" /> dialog with the specified filter.
		/// </summary>
		/// <param name="filter">the filter</param>
		/// <param name="index">the filter index</param>
		/// <returns>the path</returns>
		public string ShowOpenDialog(string filter = null, int index = 0)
		{
			return this.InternalShow(new OpenFileDialog()
			{
				Title = "Open",
				Filter = filter,
				FilterIndex = index,
				CheckPathExists = true,
				CheckFileExists = true
			});
		}

		/// <summary>
		/// Show a <see cref="SaveFileDialog" /> with the specified filter.
		/// </summary>
		/// <param name="filter">the filter</param>
		/// <param name="index">the filter index</param>
		/// <returns>the path</returns>
		public string ShowSaveDialog(string filter = null, int index = 0)
		{
			return this.InternalShow(new SaveFileDialog()
			{
				Title = "Save",
				Filter = filter,
				FilterIndex = index,
				CreatePrompt = true,
				OverwritePrompt = true
			});
		}

		/// <summary>
		/// Shows a <see cref="MessageView" /> with the specified title and message.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public void ShowMessage(string title, string message)
		{
			if (title == null)
			{
				throw new ArgumentNullException(nameof(title));
			}

			if (message == null)
			{
				throw new ArgumentNullException(nameof(message));
			}

			WindowService.Instance.ShowModally(new MessageView()
			{
				DataContext = new MessageViewModel()
				{
					Title = title,
					Message = message
				}
			});
		}

		/// <summary>
		/// Shows an <see cref="AboutView" />.
		/// </summary>
		public void ShowAbout()
		{
			WindowService.Instance.ShowModally(new AboutView());
		}

		private string InternalShow(FileDialog dialog)
		{
			var result = dialog.ShowDialog(WindowService.Instance.Active);

			if (result != null && result.Value)
			{
				return dialog.FileName;
			}

			return null;
		}

		/// <summary>
		/// Gets the instance of the dialog service.
		/// </summary>
		public static DialogService Instance => DialogService.instance;

		private static readonly DialogService instance = new DialogService();
	}
}
