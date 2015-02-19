using Sharpknife.Gui.Bases;
using Sharpknife.Utilities;
using Sharpknife.Utilities.Extensions;
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
	/// Represents a progress form, which can be used to display and control a background worker.
	/// </summary>
	public partial class ProgressForm : BaseForm
	{
		/// <summary>
		/// Shows a modal progress form, starting the specified <see cref="BackgroundWorker" /> if necessary.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="backgroundWorker">the background worker</param>
		public static void Show(Form owner, BackgroundWorker backgroundWorker)
		{
			if (!backgroundWorker.IsBusy)
			{
				//start
				backgroundWorker.RunWorkerAsync();
			}

			//show
			var progressForm = new ProgressForm(backgroundWorker);
			progressForm.ShowDialog(owner);
		}

		/// <summary>
		/// Creates a new progress form.
		/// </summary>
		/// <param name="backgroundWorker">the background worker</param>
		public ProgressForm(BackgroundWorker backgroundWorker) : base()
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
			this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.ProgressChanged);
			this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkCompleted);

			//update
			this.statusLabel.Text = "Performing operation...";
			this.progressBar.Style = ProgressBarStyle.Marquee;
			this.cancelButton.Enabled = this.backgroundWorker.WorkerSupportsCancellation;
		}

		/// <summary>
		/// Updates the progress.
		/// </summary>
		/// <param name="amount">the amount</param>
		private void UpdateProgress(int amount)
		{
			//update
			this.progressBar.Value = amount;
			this.progressBar.Style = (amount <= 0 ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks);
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

		/// <summary>
		/// Completes the progress.
		/// </summary>
		private void CompleteProgress()
		{
			if (!this.Focused)
			{
				if (this.Owner != null)
				{
					//flash
					this.FlashInTaskbar();
				}
			}

			//close
			this.Close();
			this.Dispose();
		}

		#region Event Handlers

		private void ProgressChanged(object sender, ProgressChangedEventArgs eventArgs)
		{
			this.UpdateProgress(eventArgs.ProgressPercentage);
		}

		private void RunWorkCompleted(object sender, RunWorkerCompletedEventArgs eventArgs)
		{
			this.CompleteProgress();
		}

		private void CancelHandler(object sender, EventArgs eventArgs)
		{
			this.CancelProgress();
		}

		#endregion

		private BackgroundWorker backgroundWorker;
	}
}
