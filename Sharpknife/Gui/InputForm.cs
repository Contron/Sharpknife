using Sharpknife.Gui.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sharpknife.Gui
{
	/// <summary>
	/// Represents a input form to retrieve input from the user.
	/// </summary>
	public partial class InputForm : BaseDialogForm
	{
		/// <summary>
		/// Shows a modal input form.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static string Show(Form owner, string title = "Confirmation", string message = "Message")
		{
			//show
			var inputForm = new InputForm(title, message);
			var dialogResult = inputForm.ShowDialog(owner);

			return (dialogResult == DialogResult.OK ? inputForm.Input : null);
		}

		/// <summary>
		/// Creates a new input form.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public InputForm(string title, string message) : base(title, message)
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// The entered input for the input form.
		/// </summary>
		public string Input
		{
			get
			{
				return this.inputTextBox.Text;
			}
		}
	}
}
