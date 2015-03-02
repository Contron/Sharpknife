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
			this.InitializeComponent();
		}

		#region Event Triggers

		private void OnOKClicked()
		{
			if (this.OKClicked != null)
			{
				this.OKClicked(this, new RoutedEventArgs());
			}
		}

		private void OnCancelClicked()
		{
			if (this.CancelClicked != null)
			{
				this.CancelClicked(this, new RoutedEventArgs());
			}
		}

		#endregion

		#region Event Handlers

		private void OKHandler(object sended, RoutedEventArgs eventArgs)
		{
			this.OnOKClicked();
		}

		private void CancelHandler(object sended, RoutedEventArgs eventArgs)
		{
			this.OnCancelClicked();
		}

		#endregion

		/// <summary>
		/// Occurs when the OK button is clicked.
		/// </summary>
		public event RoutedEventHandler OKClicked;

		/// <summary>
		/// Occurs when the Cancel button is clicked.
		/// </summary>
		public event RoutedEventHandler CancelClicked;

		/// <summary>
		/// Gets or sets if the OK button is hidden.
		/// </summary>
		public bool OKHidden
		{
			get
			{
				return this.okButton.Visibility == Visibility.Collapsed;
			}
			set
			{
				this.okButton.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
			}
		}

		/// <summary>
		/// Gets or sets if the Cancel button is hidden.
		/// </summary>
		public bool CancelHidden
		{
			get
			{
				return this.cancelButton.Visibility == Visibility.Collapsed;
			}
			set
			{
				this.cancelButton.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
			}
		}
	}
}
