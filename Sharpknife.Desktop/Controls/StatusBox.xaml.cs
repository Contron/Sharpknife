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
	[ContentProperty(nameof(StatusBox.Children))]
	public partial class StatusBox : UserControl
	{
		/// <summary>
		/// Creates a new status box.
		/// </summary>
		public StatusBox()
		{
			this.Status = new Status();
			this.Children = new ObservableCollection<UIElement>();

			this.InitializeComponent();
		}

		/// <summary>
		/// Gets the status property.
		/// </summary>
		public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(nameof(StatusBox.Status), typeof(Status), typeof(StatusBox));

		/// <summary>
		/// Gets the children property.
		/// </summary>
		public static readonly DependencyProperty ChildrenProperty = DependencyProperty.Register(nameof(StatusBox.Children), typeof(ObservableCollection<UIElement>), typeof(StatusBox));

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		public Status Status
		{
			get => (Status) this.GetValue(StatusBox.StatusProperty);
			set => this.SetValue(StatusBox.StatusProperty, value);
		}

		/// <summary>
		/// Gets or sets the children.
		/// </summary>
		public ObservableCollection<UIElement> Children
		{
			get => (ObservableCollection<UIElement>) this.GetValue(StatusBox.ChildrenProperty);
			set => this.SetValue(StatusBox.ChildrenProperty, value);
		}
	}
}
