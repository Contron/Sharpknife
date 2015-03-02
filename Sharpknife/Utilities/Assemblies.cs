using System;
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
			return new Uri(string.Format("pack://application:,,,/{0};component/{1}", Assembly.GetCallingAssembly().FullName, location));
		}

		/// <summary>
		/// Returns the matching attribute for the specified value.
		/// </summary>
		/// <typeparam name="T">the attribute</typeparam>
		/// <param name="value">the value</param>
		/// <returns>the result</returns>
		public static string GetAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			//get
			var attribute = (T) Attribute.GetCustomAttribute(Assembly.GetEntryAssembly(), typeof(T));
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
			var types = Assembly.GetAssembly(type).GetTypes().Where(currentType => currentType.IsSubclassOf(type)).ToList();

			return types;
		}

		/// <summary>
		/// Gets the current application path.
		/// </summary>
		public static string ApplicationPath
		{
			get
			{
				//folders
				var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				var assembly = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
				var path = Path.Combine(folder, assembly);

				return path;
			}
		}
	}
}
