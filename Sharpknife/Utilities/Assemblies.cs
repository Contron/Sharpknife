using System;
using System.Collections.Generic;
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
			var result = value.Invoke(attribute);

			return result;
		}

		/// <summary>
		/// Returns all the types that inherit from the specified type.
		/// </summary>
		/// <param name="type">the type</param>
		/// <returns>the sub types</returns>
		public static List<Type> GetSubTypesOf(Type type)
		{
			//find
			var types = Assembly.GetAssembly(type).GetTypes().Where(currentType => currentType.IsSubclassOf(type));
			var result = types.ToList();

			return result;
		}
	}
}
