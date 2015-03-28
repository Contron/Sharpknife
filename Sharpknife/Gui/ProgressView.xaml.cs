using Sharpknife.Gui.ViewModels;
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

namespace Sharpknife.Gui
{
	/// <summary>
	/// Represents a progress view to display indeterminate progress to the user.
	/// </summary>
	public partial class ProgressView : Window
	{
		/// <summary>
		/// Creates a new progress view.
		/// </summary>
		public ProgressView()
		{
			this.Completed = false;

			this.DataContext = new ProgressViewModel();

			this.InitializeComponent();
		}

		private void ClosingHandler(object sender, CancelEventArgs eventArgs)
		{
			//cancel
			eventArgs.Cancel = !this.Completed;
		}

		/// <summary>
		/// Gets or sets if the progress is completed for the progress view.
		/// </summary>
		public bool Completed
		{
			get;
			set;
		}
	}
}
