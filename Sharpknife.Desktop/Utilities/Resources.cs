﻿using System;
using System.Reflection;
using System.Windows;

namespace Sharpknife.Desktop.Utilities
{
	/// <summary>
	/// Provides a collection of methods to load resources.
	/// </summary>
	public static class Resources
	{
		/// <summary>
		/// Locates the resource at the specified path.
		/// </summary>
		/// <param name="path">the path</param>
		/// <returns>the path</returns>
		public static string Locate(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			var name = Assembly.GetEntryAssembly().FullName;

			return $"pack://application:,,,/{name};component/{path}";
		}

		/// <summary>
		/// Returns the resource with the specified name.
		/// </summary>
		/// <param name="name">the name</param>
		/// <returns>the resource</returns>
		public static object Load(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			var resource = Application.Current.TryFindResource(name);

			if (resource == null)
			{
				throw new InvalidOperationException("Resource not found.");
			}

			return resource;
		}
	}
}
