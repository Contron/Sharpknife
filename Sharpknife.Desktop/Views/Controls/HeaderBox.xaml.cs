using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sharpknife.Desktop.Views.Controls
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
			this.TextBlocks = new ObservableCollection<TextBlock>();

			this.InitializeComponent();
		}

		/// <summary>
		/// Gets the text blocks property.
		/// </summary>
		public static readonly DependencyProperty TextBlocksProperty = DependencyProperty.Register(nameof(HeaderBox.TextBlocks), typeof(ObservableCollection<TextBlock>), typeof(HeaderBox));

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
