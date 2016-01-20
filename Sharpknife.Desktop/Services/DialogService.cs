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
		private DialogService()
		{

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
