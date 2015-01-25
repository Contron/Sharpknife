using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Sharpknife.Gui.Bases
{
	/// <summary>
	/// Represents a base dialog form, which is styled to look like a modal dialog box to display information to the user.
	/// </summary>
	public partial class BaseDialogForm : BaseForm
	{
		/// <summary>
		/// Creates a new base dialog form.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public BaseDialogForm(string title = "Dialog", string message = "Message") : this()
		{
			this.InitialisePrompt(title, message);
		}

		/// <summary>
		/// Creates a new default base dialog form.
		/// </summary>
		public BaseDialogForm() : base()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Notifies that the form has loaded.
		/// </summary>
		private void NotifyForm()
		{
			//play
			SystemSounds.Beep.Play();
		}

		/// <summary>
		/// Initialises the prompt.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		private void InitialisePrompt(string title, string message)
		{
			this.Text = title;
			this.messageLabel.Text = message;
		}

		#region Event Handlers

		private void LoadHandler(object sender, EventArgs eventArgs)
		{
			this.NotifyForm();
		}

		#endregion
	}
}
