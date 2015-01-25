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
	/// Represents an entry form that allows the user to configure an object via its properties.
	/// </summary>
	public partial class EntryForm : BaseForm
	{
		/// <summary>
		/// Shows a modal entry form with the specified title and element.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="title">the title</param>
		/// <param name="element">the element</param>
		public static void Show(Form owner, string title, object element)
		{
			//show
			var entryForm = new EntryForm(title, element);
			entryForm.ShowDialog(owner);
		}

		/// <summary>
		/// Creates a new entry form.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="element">the element</param>
		public EntryForm(string title, object element)
		{
			this.InitializeComponent();
			this.InitialiseEditor(title, element);
		}

		/// <summary>
		/// Initialises the editor.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="element">the element</param>
		private void InitialiseEditor(string title, object element)
		{
			//set
			this.Text = title;
			this.propertyGrid.SelectedObject = element;
		}

		#region Event Handlers

		private void OKHandler(object sender, EventArgs eventArgs)
		{
			this.Close();
			this.Dispose();
		}

		#endregion
	}
}
