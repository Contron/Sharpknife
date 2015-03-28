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

namespace Sharpknife.Gui.Controls
{
	/// <summary>
	/// Represents a header box with a large title and description.
	/// </summary>
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
		/// Gets or sets the header for the header box.
		/// </summary>
		public string Header
		{
			get
			{
				return (string) this.GetValue(HeaderBox.HeaderProperty);
			}
			set
			{
				this.SetValue(HeaderBox.HeaderProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the description for the header box.
		/// </summary>
		public string Description
		{
			get
			{
				return (string) this.GetValue(HeaderBox.DescriptionProperty);
			}
			set
			{
				this.SetValue(HeaderBox.DescriptionProperty, value);
			}
		}

		/// <summary>
		/// Gets the header property.
		/// </summary>
		public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(HeaderBox), new UIPropertyMetadata("Header"));

		/// <summary>
		/// Gets the description property.
		/// </summary>
		public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(HeaderBox), new UIPropertyMetadata("Description"));
	}
}
