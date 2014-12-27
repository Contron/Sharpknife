using Sharpknife.Gui.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sharpknife.Gui
{
	/// <summary>
	/// Represents a progress form.
	/// </summary>
	public partial class ProgressForm : BaseForm
	{
		/// <summary>
		/// Creates a new progress form.
		/// </summary>
		/// <param name="backgroundWorker">the background worker</param>
		public ProgressForm(BackgroundWorker backgroundWorker)
		{
			this.backgroundWorker = backgroundWorker;
			this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.ProgressChanged);
			this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkCompleted);

			this.InitializeComponent();
			this.StartProgress();
		}

		/// <summary>
		/// Starts the progress.
		/// </summary>
		private void StartProgress()
		{
			//update
			this.statusLabel.Text = "Performing operation...";
			this.cancelButton.Enabled = this.backgroundWorker.WorkerSupportsCancellation;
			this.progressBar.Value = 0;
			this.progressBar.Style = (this.backgroundWorker.WorkerReportsProgress ? ProgressBarStyle.Blocks : ProgressBarStyle.Marquee);
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
			this.progressBar.Style = ProgressBarStyle.Marquee;
			this.cancelButton.Enabled = false;
		}

		#region Utility Methods

		/// <summary>
		/// Updates the progress bar.
		/// </summary>
		/// <param name="amount">the amount</param>
		private void QuickUpdateProgress(int amount)
		{
			//update
			this.progressBar.Value = amount;
		}

		#endregion

		#region Event Handlers

		private void ProgressChanged(object sender, ProgressChangedEventArgs eventArgs)
		{
			this.QuickUpdateProgress(eventArgs.ProgressPercentage);
		}

		private void RunWorkCompleted(object sender, RunWorkerCompletedEventArgs eventArgs)
		{
			this.Close();
		}

		private void CancelHandler(object sender, EventArgs eventArgs)
		{
			this.CancelProgress();
		}

		#endregion

		private BackgroundWorker backgroundWorker;
	}
}
