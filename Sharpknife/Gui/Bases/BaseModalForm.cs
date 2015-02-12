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
		/// Prepares the contents of the form.
		/// </summary>
		protected virtual void PrepareContents()
		{

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

		#region Event Handlers

		private void LoadHandler(object sender, EventArgs eventArgs)
		{
			this.PrepareContents();
			this.PopulateContents();
		}

		private void OKHandler(object sender, EventArgs eventArgs)
		{
			this.ConfirmContents();
		}

		#endregion
	}
}
