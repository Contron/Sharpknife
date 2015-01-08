using Sharpknife.Gui.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sharpknife.Gui.Dialogs
{
	/// <summary>
	/// Represents a modal message dialog.
	/// </summary>
	public partial class MessageForm : BaseDialogForm
	{
		/// <summary>
		/// Shows a modal message form.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public static void Show(Form owner, string title = "Message", string message = "Message")
		{
			//show
			var messageForm = new MessageForm(title, message);
			messageForm.ShowDialog(owner);
		}

		/// <summary>
		/// Creates a new message form.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public MessageForm(string title, string message) : base()
		{
			this.InitializeComponent();
			this.InitialiseMessage(title, message);
		}

		/// <summary>
		/// Initialises the message.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		private void InitialiseMessage(string title, string message)
		{
			this.Text = title;
			this.messageLabel.Text = message;
		}

		#region Event Handlers

		private void CloseHandler(object sender, EventArgs eventArgs)
		{
			this.Close();
		}

		#endregion
	}
}
