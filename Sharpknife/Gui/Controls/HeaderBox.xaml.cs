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
		/// Gets or sets the header of the header box.
		/// </summary>
		public string Header
		{
			get
			{
				return this.headerTextBlock.Text;
			}
			set
			{
				this.headerTextBlock.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the description of the header box.
		/// </summary>
		public string Description
		{
			get
			{
				return this.descriptionTextBlock.Text;
			}
			set
			{
				this.descriptionTextBlock.Text = value;
			}
		}
	}
}
