using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Sharpknife.Desktop.Models;

namespace Sharpknife.Desktop.Controls
{
	/// <summary>
	/// Represents a status box with a message and progress bar to display the current <see cref="Status" />.
	/// </summary>
	public partial class StatusBox : UserControl
	{
		/// <summary>
		/// Creates a new status box.
		/// </summary>
		public StatusBox()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Gets the status property.
		/// </summary>
		public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(nameof(StatusBox.Status), typeof(Status), typeof(StatusBox), new PropertyMetadata(new Status()));

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
