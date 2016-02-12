using Sharpknife.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sharpknife.Desktop.Views
{
	/// <summary>
	/// Represents a message window to display information.
	/// </summary>
	public partial class MessageView : Window
	{
		/// <summary>
		/// Creates a new message view.
		/// </summary>
		public MessageView()
		{
			this.InitializeComponent();
		}

		private void WindowLoaded(object sender, RoutedEventArgs args)
		{
			SystemSounds.Beep.Play();
		}
	}
}
