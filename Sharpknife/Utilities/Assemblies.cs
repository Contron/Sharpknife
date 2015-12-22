﻿using System;
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
		/// Returns the path belonging to the application, optionally with the specified subdirectories.
		/// </summary>
		/// <param name="subdirectories">the subdirectories</param>
		/// <returns>the path</returns>
		public static string GetApplicationPath(params string[] subdirectories)
		{
			var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var assembly = Assembly.GetEntryAssembly().GetName().Name;

			var root = Path.Combine(folder, assembly);
			var child = Path.Combine(subdirectories);
			var final = Path.Combine(root, child);

			return final;
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
