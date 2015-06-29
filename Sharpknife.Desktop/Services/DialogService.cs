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

		}

		/// <summary>
		/// Shows a file dialog.
		/// </summary>
		/// <param name="dialog">the dialog</param>
		/// <returns>the path</returns>
		public string ShowFileDialog(FileDialog dialog)
		{
			var result = dialog.ShowDialog(WindowService.Instance.GetCurrent());
			var path = result.GetValueOrDefault() ? dialog.FileName : null;

			return path;
		}

		/// <summary>
		/// Shows a multiple selection file dialog.
		/// </summary>
		/// <param name="dialog">the dialog</param>
		/// <returns>the paths</returns>
		public List<string> ShowMultipleFileDialog(OpenFileDialog dialog)
		{
			dialog.Multiselect = true;

			var result = dialog.ShowDialog(WindowService.Instance.GetCurrent());
			var paths = new List<string>();

			if (result.GetValueOrDefault())
			{
				paths.AddRange(dialog.FileNames);
			}

			return paths;
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
				DataContext = new MessageViewModel(title, message)
			};

			WindowService.Instance.ShowModally(view);
		}

		/// <summary>
		/// Shows an about dialog.
		/// </summary>
		public void ShowAbout()
		{
			WindowService.Instance.ShowModally(new AboutView());
		}

		/// <summary>
		/// Gets the instance of the dialog service.
		/// </summary>
		public static readonly DialogService Instance = new DialogService();
	}
}
