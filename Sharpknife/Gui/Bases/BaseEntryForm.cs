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
	/// Represents a base entry form.
	/// </summary>
	public partial class BaseEntryForm : BaseForm
	{
		/// <summary>
		/// Creates a new entry form.
		/// </summary>
		public BaseEntryForm() : base()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Populates the fields on the form.
		/// </summary>
		public virtual void PopulateFields()
		{

		}

		/// <summary>
		/// Confirms the contents of the form.
		/// </summary>
		public virtual void ConfirmContents()
		{

		}

		#region Event Handlers

		private void LoadHandler(object sender, EventArgs eventArgs)
		{
			this.PopulateFields();
		}

		private void OKHandler(object sender, EventArgs eventArgs)
		{
			this.ConfirmContents();

			this.Close();
			this.Dispose();
		}

		private void CancelHandler(object sender, EventArgs eventArgs)
		{
			this.Close();
			this.Dispose();
		}

		#endregion
	}
}
