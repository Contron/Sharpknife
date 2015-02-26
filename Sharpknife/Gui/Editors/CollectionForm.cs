using Sharpknife.Gui.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpknife.Gui.Editors
{
	/// <summary>
	/// Represents a collection form to provide an easy interface to edit the elements of a collection.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public partial class CollectionForm<T> : BaseForm
	{
		/// <summary>
		/// Creates a new collection form.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="objects">the objects</param>
		public CollectionForm(string title, List<T> objects)
		{
			this.objects = objects;

			this.InitializeComponent();
			this.InitialiseEditor(title);
			this.RefreshList();
		}

		/// <summary>
		/// Adds a new item to the collection.
		/// </summary>
		private void AddNew()
		{
			//add
			this.OnAddClicked();
			this.RefreshList();
		}

		/// <summary>
		/// Edits the currently selected item.
		/// </summary>
		private void EditSelected()
		{
			if (this.listBox.SelectedIndex == -1)
			{
				return;
			}

			//item
			var index = this.listBox.SelectedIndex;
			var item = this.objects[index];

			//trigger
			this.OnEditClicked(item);
			this.RefreshList();
		}

		/// <summary>
		/// Removes the currently selected item.
		/// </summary>
		private void RemoveSelected()
		{
			if (this.listBox.SelectedIndex == -1)
			{
				return;
			}

			//item
			var index = this.listBox.SelectedIndex;
			var item = this.objects[index];

			//trigger
			this.OnRemoveClicked(item);
			this.RefreshList();
		}

		/// <summary>
		/// Clears all items from the collection.
		/// </summary>
		private void ClearAll()
		{
			//confirm
			var result = ConfirmationForm.Show(this, "Clear All", "Are you sure you want to clear all entries?");

			if (result == DialogResult.OK)
			{
				//clear
				this.OnClearClicked();
				this.RefreshList();
			}
		}

		/// <summary>
		/// Refreshes the list view.
		/// </summary>
		private void RefreshList()
		{
			//old index
			var selectedIndex = this.listBox.SelectedIndex;

			//refresh
			this.listBox.Items.Clear();
			this.objects.ForEach(element => this.listBox.Items.Add(element.ToString()));
			
			if (selectedIndex >= 0 && selectedIndex < this.listBox.Items.Count)
			{
				//reselect
				this.listBox.SelectedIndex = selectedIndex;
			}
		}

		/// <summary>
		/// Initialises the editor.
		/// </summary>
		/// <param name="title">the title</param>
		private void InitialiseEditor(string title)
		{
			//update
			this.Text = title;
		}

		#region Event Triggers

		private void OnAddClicked()
		{
			if (this.AddClicked != null)
			{
				this.AddClicked(this, EventArgs.Empty);
			}
		}

		private void OnEditClicked(T target)
		{
			if (this.EditClicked != null)
			{
				this.EditClicked(this, target);
			}
		}

		private void OnRemoveClicked(T target)
		{
			if (this.RemoveClicked != null)
			{
				this.RemoveClicked(this, target);
			}
		}

		private void OnClearClicked()
		{
			if (this.ClearClicked != null)
			{
				this.ClearClicked(this, EventArgs.Empty);
			}
		}

		#endregion

		#region Event Handlers

		private void AddClickedHandler(object sender, EventArgs eventArgs)
		{
			this.AddNew();
		}

		private void EditClickedHandler(object sender, EventArgs eventArgs)
		{
			this.EditSelected();
		}

		private void RemoveClickedHandler(object sender, EventArgs eventArgs)
		{
			this.RemoveSelected();
		}

		private void ClearClickedHandler(object sender, EventArgs eventArgs)
		{
			this.ClearAll();
		}

		#endregion

		/// <summary>
		/// Occurs when the Add button is clicked.
		/// </summary>
		public event EventHandler AddClicked;

		/// <summary>
		/// Occurs when the Edit button is clicked.
		/// </summary>
		public event EventHandler<T> EditClicked;

		/// <summary>
		/// Occurs when the Remove button is clicked.
		/// </summary>
		public event EventHandler<T> RemoveClicked;

		/// <summary>
		/// Occurs when the Clear button is clicked.
		/// </summary>
		public event EventHandler ClearClicked;

		private List<T> objects;
	}
}
