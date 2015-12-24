using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// A collection of common assembly methods.
	/// </summary>
	public static class Assemblies
	{
		/// <summary>
		/// Returns the storage path belonging to the application.
		/// </summary>
		/// <returns>the path</returns>
		public static string GetApplicationPath()
		{
			var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var assembly = Assembly.GetEntryAssembly().GetName().Name;

			return Path.Combine(folder, assembly);
		}

		/// <summary>
		/// Returns the <see cref="FileVersionInfo" /> for the entry assembly.
		/// </summary>
		/// <returns>the information</returns>
		public static FileVersionInfo GetInformation()
		{
			return FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
		}

		/// <summary>
		/// Returns all the types that inherit from the specified type.
		/// </summary>
		/// <param name="type">the type</param>
		/// <returns>the sub types</returns>
		public static List<Type> GetSubTypes(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			var types = Assembly.GetAssembly(type).GetTypes()
				.Where(current => current.IsSubclassOf(type))
				.ToList();

			return types;
		}
	}
}
