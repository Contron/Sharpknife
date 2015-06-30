using Sharpknife.Desktop.Core;
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
	/// Represents a buttons box with the standard OK and Cancel buttons.
	/// </summary>
	[ContentProperty("Buttons")]
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
		public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register("Buttons", typeof(ObservableCollection<Button>), typeof(StatusBox));

		/// <summary>
		/// Gets or sets the buttons.
		/// </summary>
		public ObservableCollection<Button> Buttons
		{
			get
			{
				return (ObservableCollection<Button>) this.GetValue(ButtonsBox.ButtonsProperty);
			}
			set
			{
				this.SetValue(ButtonsBox.ButtonsProperty, value);
			}
		}
	}
}
