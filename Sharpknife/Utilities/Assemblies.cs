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
	public class Assemblies
	{
		/// <summary>
		/// Returns the matching attribute for the specified value.
		/// </summary>
		/// <typeparam name="T">the attribute</typeparam>
		/// <param name="value">the value</param>
		/// <returns>the result</returns>
		public static string GetAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
		{
			//get
			var attribute = (T) Attribute.GetCustomAttribute(Assembly.GetEntryAssembly(), typeof(T));
			var result = value.Invoke(attribute);

			return result;
		}
	}
}
