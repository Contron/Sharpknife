using Sharpknife.Core;
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
	/// Represents a buttons box with the standard OK and Cancel buttons.
	/// </summary>
	public partial class ButtonsBox : UserControl
	{
		/// <summary>
		/// Creates a new buttons box.
		/// </summary>
		public ButtonsBox()
		{
			this.OKCommand = null;
			this.CancelCommand = null;

			this.OKVisibility = Visibility.Visible;
			this.CancelVisibility = Visibility.Visible;

			this.InitializeComponent();
		}

		/// <summary>
		/// Gets the OK command property.
		/// </summary>
		public static readonly DependencyProperty OKCommandProperty = DependencyProperty.Register("OKCommand", typeof(ICommand), typeof(ButtonsBox));

		/// <summary>
		/// Gets the Cancel command property.
		/// </summary>
		public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(ButtonsBox));

		/// <summary>
		/// Gets the OK visibility property.
		/// </summary>
		public static readonly DependencyProperty OKVisibilityProperty = DependencyProperty.Register("OKVisibility", typeof(Visibility), typeof(ButtonsBox));

		/// <summary>
		/// Gets the Cancel visibility property.
		/// </summary>
		public static readonly DependencyProperty CancelVisibilityProperty = DependencyProperty.Register("CancelVisibility", typeof(Visibility), typeof(ButtonsBox));

		/// <summary>
		/// Gets or sets the OK command for the buttons box.
		/// </summary>
		public ICommand OKCommand
		{
			get
			{
				return (ICommand) this.GetValue(ButtonsBox.OKCommandProperty);
			}
			set
			{
				this.SetValue(ButtonsBox.OKCommandProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the Cancel command for the buttons box.
		/// </summary>
		public ICommand CancelCommand
		{
			get
			{
				return (ICommand) this.GetValue(ButtonsBox.CancelCommandProperty);
			}
			set
			{
				this.SetValue(ButtonsBox.CancelCommandProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the OK button visibility for the buttons box.
		/// </summary>
		public Visibility OKVisibility
		{
			get
			{
				return (Visibility) this.GetValue(ButtonsBox.OKVisibilityProperty);
			}
			set
			{
				this.SetValue(ButtonsBox.OKVisibilityProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the Cancel button visibility for the buttons box.
		/// </summary>
		public Visibility CancelVisibility
		{
			get
			{
				return (Visibility) this.GetValue(ButtonsBox.CancelVisibilityProperty);
			}
			set
			{
				this.SetValue(ButtonsBox.CancelVisibilityProperty, value);
			}
		}
	}
}
