using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Sharpknife.Desktop.Controls
{
	/// <summary>
	/// Represents a header box that can contain <see cref="TextBlock" />s.
	/// </summary>
	[ContentProperty(nameof(HeaderBox.TextBlocks))]
	public partial class HeaderBox : UserControl
	{
		/// <summary>
		/// Creates a new header box.
		/// </summary>
		public HeaderBox()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Gets the text blocks property.
		/// </summary>
		public static readonly DependencyProperty TextBlocksProperty = DependencyProperty.Register(nameof(HeaderBox.TextBlocks), typeof(ObservableCollection<TextBlock>), typeof(HeaderBox), new PropertyMetadata(new ObservableCollection<TextBlock>()));

		/// <summary>
		/// Gets or sets the text blocks.
		/// </summary>
		public ObservableCollection<TextBlock> TextBlocks
		{
			get => (ObservableCollection<TextBlock>) this.GetValue(HeaderBox.TextBlocksProperty);
			set => this.SetValue(HeaderBox.TextBlocksProperty, value);
		}
	}
}
