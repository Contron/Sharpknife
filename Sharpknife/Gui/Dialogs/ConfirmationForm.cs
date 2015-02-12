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
	/// Represents a confirmation form to display a question to the user.
	/// </summary>
	public partial class ConfirmationForm : BaseDialogForm
	{
		/// <summary>
		/// Shows a modal confirmation form.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		/// <returns>the dialog result</returns>
		public static DialogResult Show(Form owner, string title = "Confirmation", string message = "Message")
		{
			//show
			var confirmationForm = new ConfirmationForm(title, message);
			var dialogResult = confirmationForm.ShowDialog(owner);

			return dialogResult;
		}

		/// <summary>
		/// Creates a new confirmation form.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public ConfirmationForm(string title, string message) : base(title, message)
		{
			this.InitializeComponent();
		}
	}
}
