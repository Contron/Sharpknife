using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// A collection of quick shortcuts for common dialog tasks.
	/// </summary>
	public class Dialogs
	{
		/// <summary>
		/// Shows an open dialog.
		/// </summary>
		/// <typeparam name="T">the type to open</typeparam>
		/// <param name="parent">the parent</param>
		/// <param name="title">the title</param>
		/// <param name="filter">the filter</param>
		/// <returns>the tuple of results</returns>
		public static Tuple<bool, T> ShowOpenDialog<T>(Form parent, string title, string filter)
		{
			//context
			var header = ("Open " + title);

			//browse
			var dialog = new OpenFileDialog()
			{
				Title = header,
				Filter = filter,
				FileName = title
			};
			var result = dialog.ShowDialog(parent);

			if (result != DialogResult.OK)
			{
				return new Tuple<bool, T>(false, default(T));
			}

			try
			{
				//load
				var element = Serialization.Load<T>(dialog.FileName);

				return new Tuple<bool, T>(true, element);
			}
			catch
			{
				//error
				MessageBox.Show(string.Format("The {0} could not be opened successfully.", title.ToLower()), header, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return new Tuple<bool, T>(false, default(T));
			}
		}

		/// <summary>
		/// Shows a save dialog.
		/// </summary>
		/// <typeparam name="T">the type to save</typeparam>
		/// <param name="parent">the parent</param>
		/// <param name="title">the title</param>
		/// <param name="filter">the filter</param>
		/// <param name="element">the element</param>
		/// <returns>the tuple of results</returns>
		public static Tuple<bool, T> ShowSaveDialog<T>(Form parent, string title, string filter, T element)
		{
			//context
			var header = ("Save " + title);

			//browse
			var dialog = new SaveFileDialog()
			{
				Title = header,
				Filter = filter,
				FileName = title
			};
			var result = dialog.ShowDialog(parent);

			if (result != DialogResult.OK)
			{
				return new Tuple<bool, T>(false, default(T));
			}

			try
			{
				//save
				Serialization.Save<T>(dialog.FileName, element);

				return new Tuple<bool, T>(true, element);
			}
			catch
			{
				//error
				MessageBox.Show(string.Format("The {0} could not be saved successfully.", title.ToLower()), header, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return new Tuple<bool, T>(false, default(T));
			}
		}
	}
}
