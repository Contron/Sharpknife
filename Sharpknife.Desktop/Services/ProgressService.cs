using Sharpknife.Desktop.ViewModels;
using Sharpknife.Desktop.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a progress service to independently display and hide <see cref="ProgressWindow" />s.
	/// </summary>
	public class ProgressService
	{
		private ProgressService()
		{
			this.view = null;
			this.viewModel = null;
		}

		/// <summary>
		/// Shows a progress window with the specified title and status.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="status">the status</param>
		public async void Show(string title, string status)
		{
			if (title == null)
			{
				throw new ArgumentNullException(nameof(title));
			}

			if (status == null)
			{
				throw new ArgumentNullException(nameof(status));
			}

			if (this.view != null)
			{
				throw new InvalidOperationException("Progress window is already visible.");
			}

			this.viewModel = new ProgressViewModel()
			{
				Title = title,
				Status = status
			};

			this.view = new ProgressWindow()
			{
				DataContext = this.viewModel
			};

			await Task.Run(() =>
			{
				WindowService.Instance.ShowModally(this.view);
			});
		}

		/// <summary>
		/// Updates the status and progress.
		/// The progress can be from 0 to 100.
		/// </summary>
		/// <param name="status">the status</param>
		/// <param name="progress">the progress</param>
		public void Update(string status, int progress = 0)
		{
			if (this.view == null)
			{
				throw new InvalidOperationException("Progress window is not visible.");
			}

			this.viewModel.Status = status;
			this.viewModel.Progress = progress;
		}

		/// <summary>
		/// Closes the progress window.
		/// </summary>
		public void Close()
		{
			if (this.view == null)
			{
				throw new InvalidOperationException("Progress window is not visible.");
			}

			this.viewModel.Completed = true;

			WindowService.Instance.Close(this.view);

			this.view = null;
			this.viewModel = null;
		}

		/// <summary>
		/// Gets the instance of the progress service.
		/// </summary>
		public static ProgressService Instance
		{
			get
			{
				return ProgressService.instance;
			}
		}

		private static readonly ProgressService instance = new ProgressService();

		private ProgressWindow view;
		private ProgressViewModel viewModel;
	}
}
