using System.Windows;
using System.Windows.Controls;
using Sharpknife.Desktop.Models;

namespace Sharpknife.Desktop.Controls
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
			this.InitializeComponent();
		}

		/// <summary>
		/// Gets the status property.
		/// </summary>
		public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(nameof(StatusBox.Status), typeof(Status), typeof(StatusOverlay), new PropertyMetadata(new Status()));

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		public Status Status
		{
			get => (Status) this.GetValue(StatusBox.StatusProperty);
			set => this.SetValue(StatusBox.StatusProperty, value);
		}
	}
}
