using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// A collection of one-off serialization methods to quickly load and save XML files.
	/// </summary>
	public static class Serialization
	{
		/// <summary>
		/// Loads an element from the specified file.
		/// </summary>
		/// <typeparam name="T">the type</typeparam>
		/// <param name="file">the file</param>
		/// <returns>the result</returns>
		public static T Load<T>(string file)
		{
			if (file == null)
			{
				throw new ArgumentNullException("file");
			}

			//serializer
			var serializer = new XmlSerializer(typeof(T));
			
			using (FileStream fileStream = File.Open(file, FileMode.Open))
			{
				return (T) serializer.Deserialize(fileStream);
			}
		}

		/// <summary>
		/// Saves an element to the specified file.
		/// </summary>
		/// <typeparam name="T">the type</typeparam>
		/// <param name="file">the file</param>
		/// <param name="element">the element</param>
		public static void Save<T>(string file, T element)
		{
			if (file == null)
			{
				throw new ArgumentNullException("file");
			}

			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

			//serializer
			var serializer = new XmlSerializer(typeof(T));

			using (FileStream fileStream = File.Open(file, FileMode.Create))
			{
				serializer.Serialize(fileStream, element);
			}
		}
	}
}
