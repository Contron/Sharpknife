using Sharpknife.Desktop.Views;
using Sharpknife.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a dialog service to display common dialogs.
	/// </summary>
	public class DialogService
	{
		private DialogService()
		{

		}

		/// <summary>
		/// Shows an open dialog with the specified filter.
		/// </summary>
		/// <param name="filter">the filter</param>
		/// <returns>the path</returns>
		public string ShowOpenDialog(string filter = null)
		{
			var dialog = new OpenFileDialog()
			{
				Title = "Open",
				Filter = filter,
				CheckPathExists = true,
				CheckFileExists = true
			};

			var result = dialog.ShowDialog(WindowService.Instance.GetActive());

			if (result != null)
			{
				if (result.Value)
				{
					return dialog.FileName;
				}
			}

			return null;
		}

		/// <summary>
		/// Show a save dialog with the specified filter.
		/// </summary>
		/// <param name="filter">the filter</param>
		public void ShowSaveDialog(string filter = null)
		{
			var dialog = new SaveFileDialog()
			{
				Title = "Save",
				Filter = filter,
				CreatePrompt = true,
				OverwritePrompt = true
			};

			dialog.ShowDialog(WindowService.Instance.GetActive());
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

		/// <summary>
		/// Gets the instance of the dialog service.
		/// </summary>
		public static DialogService Instance
		{
			get
			{
				return DialogService.instance;
			}
		}

		private static readonly DialogService instance = new DialogService();
	}
}
