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
	/// Represents a modal message form to inform the user of a particular message.
	/// </summary>
	public partial class MessageForm : BaseDialogForm
	{
		/// <summary>
		/// Shows a modal message form.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		/// <returns>the dialog result</returns>
		public static DialogResult Show(Form owner, string title = "Message", string message = "Message")
		{
			//show
			var messageForm = new MessageForm(title, message);
			var dialogResult = messageForm.ShowDialog(owner);

			return dialogResult;
		}

		/// <summary>
		/// Creates a new message form.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public MessageForm(string title, string message) : base(title, message)
		{
			this.InitializeComponent();
		}

		#region Event Handlers

		private void CloseHandler(object sender, EventArgs eventArgs)
		{
			this.Close();
		}

		#endregion
	}
}
