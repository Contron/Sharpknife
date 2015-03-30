﻿using System;
using System.Collections.Generic;
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
		/// Returns the path belonging to the application, optionally with the specified subdirectories.
		/// </summary>
		/// <param name="subdirectories">the subdirectories</param>
		/// <returns>the path</returns>
		public static string GetApplicationPath(params string[] subdirectories)
		{
			//folders
			var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var assembly = Assembly.GetEntryAssembly().GetName().Name;
			
			//combine
			var rootPath = Path.Combine(folder, assembly);
			var subdirectoryPath = Path.Combine(subdirectories);
			var finalPath = Path.Combine(rootPath, subdirectoryPath);

			return finalPath;
		}

		/// <summary>
		/// Returns the value of the specified attribute, or null if it does not exist.
		/// </summary>
		/// <typeparam name="T">the attribute type</typeparam>
		/// <param name="type">the target type</param>
		/// <param name="value">the value</param>
		/// <returns>the result</returns>
		public static object GetAttributeValue<T>(Type type, Func<T, object> value) where T : Attribute
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}

			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			if (!Attribute.IsDefined(type, typeof(T)))
			{
				return null;
			}

			//retrieve
			var attribute = (T) Attribute.GetCustomAttribute(type, typeof(T));
			var result = value(attribute);

			return result;
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

			//find
			var types = Assembly.GetAssembly(type).GetTypes()
				.Where(currentType => currentType.IsSubclassOf(type))
				.ToList();

			return types;
		}
	}
}
