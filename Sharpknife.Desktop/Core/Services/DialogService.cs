﻿using Microsoft.Win32;
using Sharpknife.Desktop.Views;
using Sharpknife.Desktop.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Core.Services
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
			var viewModel = new MessageViewModel(title, message);
			var view = new MessageView()
			{
				DataContext = viewModel
			};

			view.Owner = WindowService.Instance.GetCurrent();
			view.ShowDialog();
		}

		/// <summary>
		/// Shows an about dialog.
		/// </summary>
		public void ShowAbout()
		{
			var view = new AboutView();

			view.Owner = WindowService.Instance.GetCurrent();
			view.ShowDialog();
		}

		/// <summary>
		/// Gets the instance of the dialog service.
		/// </summary>
		public static readonly DialogService Instance = new DialogService();
	}
}
