using Sharpknife.Desktop.ViewModels;
using Sharpknife.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a progress service to display a modal progress dialog.
	/// </summary>
	public class ProgressService
	{
		/// <summary>
		/// Creates a new progress service.
		/// </summary>
		public ProgressService()
		{
			this.view = null;
			this.visible = false;
		}

		/// <summary>
		/// Shows the progress view.
		/// </summary>
		/// <param name="status">the status</param>
		public void Show(string status)
		{
			if (this.visible)
			{
				throw new InvalidOperationException("View is already open.");
			}

			this.view = new ProgressView()
			{
				DataContext = new ProgressViewModel(status),
				Owner = WindowService.Instance.GetCurrent()
			};
			this.visible = true;

			WindowService.Instance.ShowModally(this.view);
		}

		/// <summary>
		/// Closes the progress view.
		/// </summary>
		public void Close()
		{
			if (!this.visible)
			{
				throw new InvalidOperationException("View is already closed.");
			}

			var viewModel = this.view.DataContext as ProgressViewModel;

			if (viewModel != null)
			{
				viewModel.Busy = false;
			}

			this.visible = false;

			WindowService.Instance.Close(this.view);
		}

		/// <summary>
		/// Gets the instance of the progress service.
		/// </summary>
		public static readonly ProgressService Instance = new ProgressService();

		private ProgressView view;
		private bool visible;
	}
}
