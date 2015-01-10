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
		/// Populates the fields on this form.
		/// </summary>
		public virtual void PopulateFields()
		{

		}

		/// <summary>
		/// Confirms the contents of this form.
		/// </summary>
		public virtual void ConfirmContents()
		{

		}

		/// <summary>
		/// Initialises this form.
		/// </summary>
		public void InitialiseForm()
		{
			this.PopulateFields();
		}

		#region Event Handlers

		private void OKHandler(object sender, EventArgs eventArgs)
		{
			this.ConfirmContents();
			this.Close();
		}

		private void CancelHandler(object sender, EventArgs eventArgs)
		{
			this.Close();
		}

		#endregion
	}
}
