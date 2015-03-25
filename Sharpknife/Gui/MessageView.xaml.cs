using Sharpknife.Gui.ViewModels;
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
using System.Windows.Shapes;

namespace Sharpknife.Gui
{
	/// <summary>
	/// Represents a message window to display information to the user.
	/// </summary>
	public partial class MessageView : Window
	{
		/// <summary>
		/// Creates a new message view.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public MessageView(string title, string message)
		{
			this.DataContext = new MessageViewModel(title, message);

			this.InitializeComponent();
		}
	}
}
