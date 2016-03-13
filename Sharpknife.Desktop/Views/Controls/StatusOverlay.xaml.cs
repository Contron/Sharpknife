using Sharpknife.Desktop.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sharpknife.Desktop.Views.Controls
{
	/// <summary>
	/// Represents a status overlay to modally display the current <see cref="Status" /> while it is busy.
	/// </summary>
	public partial class StatusOverlay : UserControl
	{
		/// <summary>
		/// Creates a new status overlay.
		/// </summary>
		public StatusOverlay()
		{
			this.Status = new Status();

			this.InitializeComponent();
		}

		/// <summary>
		/// Gets the status property.
		/// </summary>
		public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(nameof(StatusBox.Status), typeof(Status), typeof(StatusOverlay));

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		public Status Status
		{
			get
			{
				return (Status) this.GetValue(StatusBox.StatusProperty);
			}
			set
			{
				this.SetValue(StatusBox.StatusProperty, value);
			}
		}
	}
}
