using Sharpknife.Common;
using Sharpknife.Gui.Dialogs;
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
		/// <returns>the result</returns>
		public static FileDialogResult<T> ShowOpenDialog<T>(Form parent, string title, string filter)
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
				return new FileDialogResult<T>();
			}

			try
			{
				//load
				var fileName = dialog.FileName;
				var element = Serialization.Load<T>(fileName);

				return new FileDialogResult<T>(element, fileName);
			}
			catch (Exception exception)
			{
				//error
				MessageForm.Show(null, header, string.Format("The {0} could not be opened successfully.", title.ToLower()));

				return new FileDialogResult<T>(exception);
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
		/// <returns>the result</returns>
		public static FileDialogResult<T> ShowSaveDialog<T>(Form parent, string title, string filter, T element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

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
				return new FileDialogResult<T>();
			}

			try
			{
				//save
				var fileName = dialog.FileName;
				Serialization.Save<T>(fileName, element);

				return new FileDialogResult<T>(element, fileName);
			}
			catch (Exception exception)
			{
				//error
				MessageForm.Show(null, header, string.Format("The {0} could not be saved successfully.", title.ToLower()));

				return new FileDialogResult<T>(exception);
			}
		}
	}
}
