using Sharpknife.Gui.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Sharpknife.Gui
{
	/// <summary>
	/// Represents a message form to display information to the user.
	/// </summary>
	public partial class MessageForm : BaseForm
	{
		/// <summary>
		/// Shows a modal message form with the specified title and message.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public static void Show(Form owner, string title, string message)
		{
			//show
			new MessageForm(title, message).ShowDialog(owner);
		}

		/// <summary>
		/// Creates a new message form.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public MessageForm(string title, string message)
		{
			this.InitializeComponent();
			this.InitialisePrompt(title, message);
		}

		/// <summary>
		/// Initialises the prompt.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="message"></param>
		private void InitialisePrompt(string title, string message)
		{
			//set
			this.Text = title;
			this.messageLabel.Text = message;

			//notify
			SystemSounds.Beep.Play();
		}
	}
}
