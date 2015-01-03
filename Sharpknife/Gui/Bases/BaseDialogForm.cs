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
	/// Represents a base dialog (modal) form.
	/// </summary>
	public partial class BaseDialogForm : BaseForm
	{
		/// <summary>
		/// Creates a new base dialog form.
		/// </summary>
		public BaseDialogForm() : base()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Notifies that this form has loaded.
		/// </summary>
		private void NotifyForm()
		{
			//play
			SystemSounds.Beep.Play();
		}

		#region Event Handlers

		private void LoadHandler(object sender, EventArgs eventArgs)
		{
			this.NotifyForm();
		}

		#endregion
	}
}
