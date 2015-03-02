using Microsoft.Win32;
using Sharpknife.Common;
using Sharpknife.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// A collection of quick shortcuts for common dialog tasks.
	/// </summary>
	public static class Dialogs
	{
		/// <summary>
		/// Shows an open dialog.
		/// </summary>
		/// <typeparam name="T">the type to open</typeparam>
		/// <param name="parent">the parent</param>
		/// <param name="title">the title</param>
		/// <param name="filter">the filter</param>
		/// <returns>the result</returns>
		public static FileDialogResult<T> ShowOpenDialog<T>(Window parent, string title, string filter)
		{
			//context
			var header = string.Format("Open {0}", title);

			//browse
			var dialog = new OpenFileDialog()
			{
				Title = header,
				Filter = filter,
				FileName = title
			};
			var result = dialog.ShowDialog(parent);

			if (result != true)
			{
				return new FileDialogResult<T>();
			}

			try
			{
				//load
				var fileName = dialog.FileName;
				var element = Serialization.LoadFromFile<T>(fileName);

				return new FileDialogResult<T>(element, fileName);
			}
			catch (Exception exception)
			{
				//error
				MessageWindow.Show(null, header, string.Format("The {0} could not be opened successfully.", title.ToLower()));

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
		public static FileDialogResult<T> ShowSaveDialog<T>(Window parent, string title, string filter, T element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

			//context
			var header = string.Format("Save {0}", title);

			//browse
			var dialog = new SaveFileDialog()
			{
				Title = header,
				Filter = filter,
				FileName = title
			};
			var result = dialog.ShowDialog(parent);

			if (result != true)
			{
				return new FileDialogResult<T>();
			}

			try
			{
				//save
				var fileName = dialog.FileName;
				Serialization.SaveToFile<T>(fileName, element);

				return new FileDialogResult<T>(element, fileName);
			}
			catch (Exception exception)
			{
				//error
				MessageWindow.Show(null, header, string.Format("The {0} could not be saved successfully.", title.ToLower()));

				return new FileDialogResult<T>(exception);
			}
		}
	}
}
