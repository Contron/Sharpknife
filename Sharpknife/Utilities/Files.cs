using System;
using System.IO;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// Provides a collection of methods to work with files and paths.
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
			var count = 1;

			do
			{
				result = Path.Combine(directory, $"{name}{count}{extension}");
				count++;
			}
			while (File.Exists(result));

			return result;
		}

		/// <summary>
		/// Returns the friendly size of the specified size.
		/// </summary>
		/// <param name="size">the size</param>
		/// <returns>the result</returns>
		public static string GetSize(long size)
		{
			if (size < 1024)
			{
				return $"{size:N0} bytes";
			}

			if (size < 1048576)
			{
				return $"{size / 1024:N0} KB";
			}

			if (size < 1073741824)
			{
				return $"{size / 1048576:N0} MB";
			}

			if (size < 1099511627776)
			{
				return $"{size / 1073741824:N0} GB";
			}

			return $"{size / 1099511627776:N0} PB";
		}
	}
}
