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
		public static T LoadFromFile<T>(string file)
		{
			if (file == null)
			{
				throw new ArgumentNullException("file");
			}

			using (var stream = File.Open(file, FileMode.Open))
			{
				return (T) new XmlSerializer(typeof(T)).Deserialize(stream);
			}
		}

		/// <summary>
		/// Loads an element from the specified text.
		/// </summary>
		/// <typeparam name="T">the type</typeparam>
		/// <param name="text">the text</param>
		/// <returns>the result</returns>
		public static T LoadFromString<T>(string text)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}

			using (var reader = new StringReader(text))
			{
				return (T) new XmlSerializer(typeof(T)).Deserialize(reader);
			}
		}

		/// <summary>
		/// Saves an element to the specified file.
		/// </summary>
		/// <typeparam name="T">the type</typeparam>
		/// <param name="file">the file</param>
		/// <param name="element">the element</param>
		public static void SaveToFile<T>(string file, T element)
		{
			if (file == null)
			{
				throw new ArgumentNullException("file");
			}

			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

			using (var stream = File.Open(file, FileMode.Create))
			{
				new XmlSerializer(typeof(T)).Serialize(stream, element);
			}
		}
	}
}
