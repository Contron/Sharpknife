using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpknife.Gui.Bases
{
	/// <summary>
	/// Represents a base dialog form.
	/// </summary>
	public partial class BaseDialogForm : BaseForm
	{
		/// <summary>
		/// Creates a new base dialog form.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public BaseDialogForm(string title, string message)
		{
			this.InitializeComponent();
			this.InitialisePrompt(title, message);
		}

		/// <summary>
		/// Creates a new base dialog form.
		/// </summary>
		public BaseDialogForm() : this("Title", "Message")
		{

		}

		/// <summary>
		/// Initialises the prompt.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		protected void InitialisePrompt(string title, string message)
		{
			//set
			this.Text = title;
			this.messageLabel.Text = message;
		}
	}
}
