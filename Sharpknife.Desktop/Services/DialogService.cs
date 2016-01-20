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
		/// <param name="index">the filter index</param>
		/// <returns>the path</returns>
		public string ShowOpenDialog(string filter = null, int index = 0)
		{
			var dialog = new OpenFileDialog()
			{
				Title = "Open",
				Filter = filter,
				FilterIndex = index,
				CheckPathExists = true,
				CheckFileExists = true
			};

			return this.ShowDialog(dialog);
		}

		/// <summary>
		/// Show a save dialog with the specified filter.
		/// </summary>
		/// <param name="filter">the filter</param>
		/// <param name="index">the filter index</param>
		/// <returns>the path</returns>
		public string ShowSaveDialog(string filter = null, int index = 0)
		{
			var dialog = new SaveFileDialog()
			{
				Title = "Save",
				Filter = filter,
				FilterIndex = index,
				CreatePrompt = true,
				OverwritePrompt = true
			};

			return this.ShowDialog(dialog);
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

		private string ShowDialog(FileDialog dialog)
		{
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
