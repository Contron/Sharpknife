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
	/// Represents a progress window to indicate a task is in progress.
	/// </summary>
	public partial class ProgressWindow : Window
	{
		/// <summary>
		/// Creates a new progress window.
		/// </summary>
		public ProgressWindow()
		{
			this.InitializeComponent();
		}

		private void WindowClosing(object sender, CancelEventArgs args)
		{
			var viewModel = this.DataContext as ProgressViewModel;

			if (viewModel != null)
			{
				args.Cancel = !viewModel.Completed;
			}
		}
	}
}
