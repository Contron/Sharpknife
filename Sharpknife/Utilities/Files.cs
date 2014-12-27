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
	public class Files
	{
		/// <summary>
		/// Calculates the human readable size of a file.
		/// </summary>
		/// <param name="size">the size</param>
		/// <returns>the human readable size</returns>
		public static string CalculateFriendlySize(long size)
		{
			//sizes
			var sizes = new string[] { "bytes", "KB", "MB", "GB", "TB", "PB" };
			var order = 0;

			while (size >= 1024 && ((order + 1) < sizes.Length))
			{
				//increment
				order++;
				size /= 1024;
			}

			//result
			var suffix = sizes[order];
			var result = string.Format("{0:0} {1}", size, suffix);

			return result;
		}
	}
}
