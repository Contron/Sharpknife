using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// A collection of common file methods.
	/// </summary>
	public static class Files
	{
		/// <summary>
		/// Returns a unique file name for the specified path, ensuring that no other file exists.
		/// </summary>
		/// <param name="path">the path</param>
		/// <returns>the result</returns>
		public static string GetUniquePath(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			var directory = Path.GetDirectoryName(path);
			var name = Path.GetFileNameWithoutExtension(path);
			var extension = Path.GetExtension(path);

			var result = path;
			var count = 0;

			while (File.Exists(result) || count <= 0)
			{
				count++;

				result = Path.Combine(directory, $"{name}{count}{extension}");
			}

			return result;
		}

		/// <summary>
		/// Returns the friendly size of the specified size.
		/// </summary>
		/// <param name="size">the size</param>
		/// <returns>the result</returns>
		public static string GetSize(long size)
		{
			var sizes = new string[] { "bytes", "KB", "MB", "GB", "TB", "PB", "EB" };
			var order = 0;

			while (size >= 1024 && order + 1 < sizes.Length)
			{
				order++;
				size /= 1024;
			}

			var suffix = sizes[order];
			var result = $"{size:0} {suffix}";

			return result;
		}
	}
}
