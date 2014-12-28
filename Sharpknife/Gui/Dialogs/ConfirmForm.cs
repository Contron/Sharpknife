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
	/// Represents a modal confirmation dialog.
	/// </summary>
	public partial class ConfirmForm : BaseDialogForm
	{
		/// <summary>
		/// Shows a modal confirmation form.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		/// <returns>the dialog result</returns>
		public static DialogResult Show(Form owner, string title = "Confirm", string message = "Prompt")
		{
			//show
			var confirmForm = new ConfirmForm(title, message);
			var dialogResult = confirmForm.ShowDialog(owner);

			return dialogResult;
		}

		/// <summary>
		/// Creates a new confirmation form.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public ConfirmForm(string title, string message)
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
			this.Text = title;
			this.promptLabel.Text = message;
		}

		#region Event Handlers

		private void CloseHandler(object sender, EventArgs eventArgs)
		{
			this.Close();
		}

		#endregion
	}
}
