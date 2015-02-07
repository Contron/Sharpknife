using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sharpknife.Gui.Bases
{
	/// <summary>
	/// Represents a base modal form with the standard OK and Cancel buttons.
	/// </summary>
	public partial class BaseModalForm : BaseForm
	{
		/// <summary>
		/// Creates a new base modal form.
		/// </summary>
		public BaseModalForm()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Populates the contents of the form.
		/// </summary>
		protected virtual void PopulateContents()
		{

		}

		/// <summary>
		/// Confirms the contents of the form.
		/// </summary>
		protected virtual void ConfirmContents()
		{

		}

		/// <summary>
		/// Completes the form
		/// </summary>
		/// <param name="confirm">if the contents should be confirmed</param>
		private void Complete(bool confirm)
		{
			if (confirm)
			{
				//confirm
				this.ConfirmContents();
			}

			//close
			this.Close();
			this.Dispose();
		}

		#region Event Handlers

		private void LoadHandler(object sender, EventArgs eventArgs)
		{
			this.PopulateContents();
		}

		private void OKHandler(object sender, EventArgs eventArgs)
		{
			this.Complete(true);
		}

		private void CancelHandler(object sender, EventArgs eventArgs)
		{
			this.Complete(false);
		}

		#endregion
	}
}
