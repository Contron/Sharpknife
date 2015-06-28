using Sharpknife.Desktop.ViewModels;
using Sharpknife.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a progress service to display a modal progress dialog.
	/// </summary>
	public class ProgressService
	{
		/// <summary>
		/// Shows a progress view for the specified action.
		/// </summary>
		/// <param name="status">the status</param>
		/// <param name="action">the action</param>
		public void Show(string status, Action action)
		{
			var view = new ProgressView()
			{
				DataContext = new ProgressViewModel(status)
			};

			view.Loaded += async (sender, eventArgs) =>
			{
				try
				{
					await Task.Run(action);
				}
				finally
				{
					this.Close(view);
				}
			};

			WindowService.Instance.ShowModally(view);
		}

		private void Close(ProgressView view)
		{
			var viewModel = view.DataContext as ProgressViewModel;

			if (viewModel != null)
			{
				viewModel.Busy = false;
			}

			WindowService.Instance.Close(view);
		}

		/// <summary>
		/// Gets the instance of the progress service.
		/// </summary>
		public static readonly ProgressService Instance = new ProgressService();
	}
}
