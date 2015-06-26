using Sharpknife.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace Sharpknife.Desktop.Views
{
	/// <summary>
	/// Represents a progress window to indicate a long-running operation.
	/// </summary>
	public partial class ProgressView : Window
	{
		/// <summary>
		/// Creates a new progress view.
		/// </summary>
		public ProgressView()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Triggers the closing event.
		/// </summary>
		/// <param name="eventArgs">the event args</param>
		protected override void OnClosing(CancelEventArgs eventArgs)
		{
			base.OnClosing(eventArgs);

			var viewModel = this.DataContext as ProgressViewModel;

			if (viewModel != null)
			{
				eventArgs.Cancel = viewModel.Busy;
			}
		}
	}
}
