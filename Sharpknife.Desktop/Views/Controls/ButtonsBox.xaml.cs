using Sharpknife.Desktop.Core;
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

namespace Sharpknife.Desktop.Views.Controls
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
			this.OkCommand = null;
			this.OkEnabled = true;
			this.OkVisibility = Visibility.Visible;

			this.CancelCommand = null;
			this.CancelEnabled = true;
			this.CancelVisibility = Visibility.Visible;

			this.InitializeComponent();
		}

		/// <summary>
		/// Gets the OK command property.
		/// </summary>
		public static readonly DependencyProperty OkCommandProperty = DependencyProperty.Register("OkCommand", typeof(Command), typeof(ButtonsBox));

		/// <summary>
		/// Gets the Cancel command property.
		/// </summary>
		public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register("CancelCommand", typeof(Command), typeof(ButtonsBox));

		/// <summary>
		/// Gets the OK enabled property.
		/// </summary>
		public static readonly DependencyProperty OkEnabledProperty = DependencyProperty.Register("OkEnabled", typeof(bool), typeof(ButtonsBox));

		/// <summary>
		/// Gets the Cancel enabled property.
		/// </summary>
		public static readonly DependencyProperty CancelEnabledProperty = DependencyProperty.Register("CancelEnabled", typeof(bool), typeof(ButtonsBox));

		/// <summary>
		/// Gets the OK visibility property.
		/// </summary>
		public static readonly DependencyProperty OkVisibilityProperty = DependencyProperty.Register("OkVisibility", typeof(Visibility), typeof(ButtonsBox));

		/// <summary>
		/// Gets the Cancel visibility property.
		/// </summary>
		public static readonly DependencyProperty CancelVisibilityProperty = DependencyProperty.Register("CancelVisibility", typeof(Visibility), typeof(ButtonsBox));

		/// <summary>
		/// Gets or sets the OK command.
		/// </summary>
		public Command OkCommand
		{
			get
			{
				return (Command) this.GetValue(ButtonsBox.OkCommandProperty);
			}
			set
			{
				this.SetValue(ButtonsBox.OkCommandProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the Cancel command.
		/// </summary>
		public Command CancelCommand
		{
			get
			{
				return (Command) this.GetValue(ButtonsBox.CancelCommandProperty);
			}
			set
			{
				this.SetValue(ButtonsBox.CancelCommandProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets if the OK button is enabled.
		/// </summary>
		public bool OkEnabled
		{
			get
			{
				return (bool) this.GetValue(ButtonsBox.OkEnabledProperty);
			}
			set
			{
				this.SetValue(ButtonsBox.OkEnabledProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the if the Cancel button is enabled.
		/// </summary>
		public bool CancelEnabled
		{
			get
			{
				return (bool) this.GetValue(ButtonsBox.CancelEnabledProperty);
			}
			set
			{
				this.SetValue(ButtonsBox.CancelEnabledProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the visibility of the OK button.
		/// </summary>
		public Visibility OkVisibility
		{
			get
			{
				return (Visibility) this.GetValue(ButtonsBox.OkVisibilityProperty);
			}
			set
			{
				this.SetValue(ButtonsBox.OkVisibilityProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the visibility of the Cancel button.
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
