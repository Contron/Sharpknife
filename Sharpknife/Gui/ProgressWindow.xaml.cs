using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sharpknife.Gui
{
	/// <summary>
	/// Represents a progress window to monitor the state of a <see cref="BackgroundWorker" /> until completion.
	/// </summary>
	public partial class ProgressWindow : Window
	{
		/// <summary>
		/// Shows a modal progress window for the specified background worker.
		/// It will be started if it is not already running.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="backgroundWorker">the background worker</param>
		public static void Show(Window owner, BackgroundWorker backgroundWorker)
		{
			if (!backgroundWorker.IsBusy)
			{
				//run
				backgroundWorker.RunWorkerAsync();
			}

			//show
			var window = new ProgressWindow(backgroundWorker)
			{
				Owner = owner
			};
			window.ShowDialog();
		}

		/// <summary>
		/// Creates a new progress window.
		/// </summary>
		/// <param name="backgroundWorker">the background worker</param>
		public ProgressWindow(BackgroundWorker backgroundWorker)
		{
			this.backgroundWorker = backgroundWorker;

			this.InitializeComponent();
			this.StartProgress();
		}

		/// <summary>
		/// Starts the progress.
		/// </summary>
		private void StartProgress()
		{
			//events
			this.backgroundWorker.ProgressChanged += this.ProgressChangedHandler;
			this.backgroundWorker.RunWorkerCompleted += this.RunWorkCompletedHandler;

			//update
			this.statusLabel.Text = "Performing operation...";
			this.progressBar.IsIndeterminate = true;
			this.cancelButton.IsEnabled = this.backgroundWorker.WorkerSupportsCancellation;
		}

		/// <summary>
		/// Updates the progress.
		/// </summary>
		/// <param name="amount">the amount</param>
		/// <param name="userState">the user state</param>
		private void UpdateProgress(int amount, object userState)
		{
			if (this.backgroundWorker.CancellationPending)
			{
				return;
			}

			//update
			this.progressBar.Value = amount;
			this.progressBar.IsIndeterminate = amount <= 0;

			if (userState is string)
			{
				//status
				this.statusLabel.Text = (string) userState;
			}
		}

		/// <summary>
		/// Cancels the progress.
		/// </summary>
		private void CancelProgress()
		{
			//cancel
			this.backgroundWorker.CancelAsync();

			//update
			this.statusLabel.Text = "Cancelling operation...";
			this.progressBar.IsIndeterminate = true;
			this.cancelButton.IsEnabled = false;
		}

		/// <summary>
		/// Attempts to cancel the progress.
		/// </summary>
		/// <param name="eventArgs">the event args</param>
		private void AttemptCancelProgress(CancelEventArgs eventArgs)
		{
			if (!this.backgroundWorker.IsBusy)
			{
				return;
			}

			if (this.backgroundWorker.WorkerSupportsCancellation && this.backgroundWorker.IsBusy)
			{
				//cancel
				this.CancelProgress();
			}
			else
			{
				//beep
				SystemSounds.Beep.Play();
			}

			//ignore
			eventArgs.Cancel = true;
		}

		#region Event Handlers

		private void ClosingHandler(object sender, CancelEventArgs eventArgs)
		{
			this.AttemptCancelProgress(eventArgs);
		}

		private void ProgressChangedHandler(object sender, ProgressChangedEventArgs eventArgs)
		{
			this.UpdateProgress(eventArgs.ProgressPercentage, eventArgs.UserState);
		}

		private void RunWorkCompletedHandler(object sender, RunWorkerCompletedEventArgs eventArgs)
		{
			this.Close();
		}

		private void CancelHandler(object sender, RoutedEventArgs eventArgs)
		{
			this.CancelProgress();
		}

		#endregion

		private BackgroundWorker backgroundWorker;
	}
}
