using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Utilities
{
	/// <summary>
	/// A collection of methods to load resources.
	/// </summary>
	public static class Resources
	{
		/// <summary>
		/// Locates the resource at the specified path.
		/// </summary>
		/// <param name="path">the path</param>
		/// <returns>the URI</returns>
		public static Uri Locate(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			var name = Assembly.GetCallingAssembly().FullName;

			return new Uri($"pack://application:,,,/{name};component/{path}");
		}
	}
}
