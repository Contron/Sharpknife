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

namespace Sharpknife.Gui
{
	/// <summary>
	/// Represents a message window to display one-off information to the user.
	/// </summary>
	public partial class MessageWindow : Window
	{
		/// <summary>
		/// Shows a modal message window with the specified title and message.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public static void Show(Window owner, string title, string message)
		{
			//show
			var window = new MessageWindow(title, message)
			{
				Owner = owner
			};
			window.ShowDialog();
		}

		/// <summary>
		/// Creates a new message window.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public MessageWindow(string title, string message)
		{
			this.InitializeComponent();
			this.InitialisePrompt(title, message);
		}

		/// <summary>
		/// Initialises the prompt.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		private void InitialisePrompt(string title, string message)
		{
			//update
			this.Title = title;
			this.messageTextBlock.Text = message;

			//beep
			SystemSounds.Beep.Play();
		}

		#region Event Handlers

		private void OKHandler(object sender, RoutedEventArgs eventArgs)
		{
			this.Close();
		}

		#endregion
	}
}
