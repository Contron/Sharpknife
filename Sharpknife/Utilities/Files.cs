using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// A collection of useful file utilities.
	/// </summary>
	public static class Files
	{
		/// <summary>
		/// Returns the friendly size of the specified size.
		/// </summary>
		/// <param name="size">the size</param>
		/// <returns>the result</returns>
		public static string GetSize(long size)
		{
			var sizes = new string[] { "bytes", "KB", "MB", "GB", "TB", "PB" };
			var order = 0;

			while (size >= 1024 && order + 1 < sizes.Length)
			{
				order++;
				size /= 1024;
			}

			var suffix = sizes[order];
			var result = string.Format("{0:0} {1}", size, suffix);

			return result;
		}

		/// <summary>
		/// Returns the type the specified extension.
		/// </summary>
		/// <param name="extension">the extension</param>
		/// <returns>the type</returns>
		public static string GetType(string extension)
		{
			if (extension == null)
			{
				throw new ArgumentNullException("extension");
			}

			var index = extension.LastIndexOf('.');

			if (index != -1)
			{
				extension = extension.Substring(index);
			}

			switch (extension)
			{
				case "png":
				case "jpg":
				case "jpeg":
				case "gif":
				{
					return "Image File";
				}
				case "mp3":
				case "wav":
				{
					return "Audio File";
				}
				case "mpg":
				case "mp4":
				case "webm":
				case "avi":
				{
					return "Video File";
				}
				case "rtf":
				case "txt":
				{
					return "Text Document";
				}
				case "htm":
				case "html":
				{
					return "HTML Document";
				}
				case "xml":
				{
					return "XML Document";
				}
				default:
				{
					return string.Format("{0} File", extension);
				}
			}
		}
	}
}
