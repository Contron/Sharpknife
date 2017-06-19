using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// Provides a collection of methods to work with <see cref="Assembly" /> instances.
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
		/// Returns the specified <see cref="Attribute" /> for the entry assembly.
		/// </summary>
		/// <typeparam name="T">the attribute type</typeparam>
		/// <returns>the attribute</returns>
		public static T GetAttribute<T>() where T : Attribute
		{
			return Assembly.GetEntryAssembly().GetCustomAttribute<T>();
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
