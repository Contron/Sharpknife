using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sharpknife.Gui.Editors
{
	/// <summary>
	/// Represents a collection editor window to edit the contents of a <see cref="List" />.
	/// </summary>
	public partial class CollectionWindow : Window
	{
		/// <summary>
		/// Creates a new collection window.
		/// </summary>
		/// <param name="list">the list</param>
		/// <param name="title">the title</param>
		public CollectionWindow(IList list, string title)
		{
			this.list = list;

			this.InitializeComponent();
			this.InitialiseEditor(title);
			this.UpdateList();
		}

		/// <summary>
		/// Adds a new item to the collection.
		/// </summary>
		private void AddNew()
		{
			//add
			this.OnAddClicked();
			this.UpdateList();
		}
		/// <summary>
		/// Edits the currently selected item.
		/// </summary>
		private void EditSelected()
		{
			//index
			var index = this.itemsListView.SelectedIndex;

			if (index == -1)
			{
				return;
			}

			//item
			var item = this.list[index];

			//trigger
			this.OnEditClicked(item);
			this.UpdateList();
		}
		/// <summary>
		/// Removes the currently selected item.
		/// </summary>
		private void RemoveSelected()
		{
			//index
			var index = this.itemsListView.SelectedIndex;

			if (index == -1)
			{
				return;
			}

			//item
			var item = this.list[index];

			//trigger
			this.OnRemoveClicked(item);
			this.UpdateList();
		}
		/// <summary>
		/// Clears all items from the collection.
		/// </summary>
		private void ClearAll()
		{
			//clear
			this.OnClearClicked();
			this.UpdateList();
		}
		/// <summary>
		/// Updates the list view.
		/// </summary>
		private void UpdateList()
		{
			//update
			this.itemsListView.ItemsSource = null;
			this.itemsListView.ItemsSource = this.list;
		}

		/// <summary>
		/// Initialises the editor.
		/// </summary>
		/// <param name="title">the title</param>
		private void InitialiseEditor(string title)
		{
			//update
			this.Title = title;
		}

		#region Event Triggers

		private void OnAddClicked()
		{
			if (this.AddClicked != null)
			{
				this.AddClicked(this, new RoutedEventArgs());
			}
		}

		private void OnEditClicked(object element)
		{
			if (this.EditClicked != null)
			{
				this.EditClicked(this, element);
			}
		}

		private void OnRemoveClicked(object element)
		{
			if (this.RemoveClicked != null)
			{
				this.RemoveClicked(this, element);
			}
		}

		private void OnClearClicked()
		{
			if (this.ClearClicked != null)
			{
				this.ClearClicked(this, new RoutedEventArgs());
			}
		}

		#endregion

		#region Event Handlers

		private void AddItemHandler(object sender, RoutedEventArgs eventArgs)
		{
			this.AddNew();
		}

		private void EditItemHandler(object sender, RoutedEventArgs eventArgs)
		{
			this.EditSelected();
		}

		private void RemoveItemHandler(object sender, RoutedEventArgs eventArgs)
		{
			this.RemoveSelected();
		}

		private void ClearItemsHandler(object sender, RoutedEventArgs eventArgs)
		{
			this.ClearAll();
		}

		#endregion

		/// <summary>
		/// Occurs when the Add button is clicked.
		/// </summary>
		public event RoutedEventHandler AddClicked;

		/// <summary>
		/// Occurs when the Edit button is clicked.
		/// </summary>
		public event EventHandler<object> EditClicked;

		/// <summary>
		/// Occurs when the Remove button is clicked.
		/// </summary>
		public event EventHandler<object> RemoveClicked;

		/// <summary>
		/// Occurs when the Clear button is clicked.
		/// </summary>
		public event RoutedEventHandler ClearClicked;

		private IList list;
	}
}
