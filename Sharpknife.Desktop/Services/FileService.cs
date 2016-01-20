using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a file service to display <see cref="FileDialog" />s.
	/// </summary>
	class FileService
	{
		private FileService()
		{

		}

		/// <summary>
		/// Shows an open dialog with the specified filter.
		/// </summary>
		/// <param name="filter">the filter</param>
		/// <returns>the path</returns>
		public string ShowOpenDialog(string filter = null)
		{
			var dialog = new OpenFileDialog()
			{
				Title = "Open",
				Filter = filter,
				CheckPathExists = true,
				CheckFileExists = true
			};

			var result = dialog.ShowDialog(WindowService.Instance.GetActive());

			if (result != null)
			{
				if (result.Value)
				{
					return dialog.FileName;
				}
			}

			return null;
		}

		/// <summary>
		/// Show a save dialog with the specified filter.
		/// </summary>
		/// <param name="filter">the filter</param>
		public void ShowSaveDialog(string filter = null)
		{
			var dialog = new SaveFileDialog()
			{
				Title = "Save",
				Filter = filter,
				CreatePrompt = true,
				OverwritePrompt = true
			};

			dialog.ShowDialog(WindowService.Instance.GetActive());
		}

		/// <summary>
		/// Gets the instance of the file service.
		/// </summary>
		public static FileService Instance
		{
			get
			{
				return FileService.instance;
			}
		}

		private static readonly FileService instance = new FileService();
	}
}
