using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Sharpknife.Desktop.Controls
{
	/// <summary>
	/// Represents a buttons box that can contain <see cref="Button" />s.
	/// </summary>
	[ContentProperty(nameof(ButtonsBox.Buttons))]
	public partial class ButtonsBox : UserControl
	{
		/// <summary>
		/// Creates a new buttons box.
		/// </summary>
		public ButtonsBox()
		{
			this.Buttons = new ObservableCollection<Button>();

			this.InitializeComponent();
		}

		/// <summary>
		/// Gets the buttons property.
		/// </summary>
		public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register(nameof(ButtonsBox.Buttons), typeof(ObservableCollection<Button>), typeof(ButtonsBox));

		/// <summary>
		/// Gets or sets the buttons.
		/// </summary>
		public ObservableCollection<Button> Buttons
		{
			get => (ObservableCollection<Button>) this.GetValue(ButtonsBox.ButtonsProperty);
			set => this.SetValue(ButtonsBox.ButtonsProperty, value);
		}
	}
}
