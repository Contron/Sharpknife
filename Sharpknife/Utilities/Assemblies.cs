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
	/// A collection of generic assembly related methods.
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

			var rootPath = Path.Combine(folder, assembly);
			var subdirectoryPath = Path.Combine(subdirectories);
			var finalPath = Path.Combine(rootPath, subdirectoryPath);

			return finalPath;
		}

		/// <summary>
		/// Returns a <see cref="Uri" /> to the specified resource for the calling assembly.
		/// </summary>
		/// <param name="location">the location</param>
		/// <returns>the URI</returns>
		public static Uri GetResource(string location)
		{
			if (location == null)
			{
				throw new ArgumentNullException("location");
			}

			return new Uri(string.Format("pack://application:,,,/{0};component/{1}", Assembly.GetCallingAssembly().FullName, location));
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
		public static List<Type> GetSubTypesOf(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}

			var types = Assembly.GetAssembly(type).GetTypes()
				.Where(currentType => currentType.IsSubclassOf(type))
				.ToList();

			return types;
		}
	}
}
