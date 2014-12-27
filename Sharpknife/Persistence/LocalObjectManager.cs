using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sharpknife.Persistence
{
	/// <summary>
	/// Represents a local object manager, which is a lightweight wrapper over a serializer.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class LocalObjectManager<T>
	{
		/// <summary>
		/// Creates a new local object manager.
		/// </summary>
		public LocalObjectManager()
		{
			this.xmlSerializer = new XmlSerializer(typeof(T));
		}

		/// <summary>
		/// Loads an element from the specified file.
		/// </summary>
		/// <param name="file">the file</param>
		/// <returns>the result, or null</returns>
		public T Load(string file)
		{
			if (!File.Exists(file))
			{
				return default(T);
			}

			using (FileStream fileStream = File.Open(file, FileMode.Open))
			{
				return (T) this.xmlSerializer.Deserialize(fileStream);
			}
		}

		/// <summary>
		/// Saves an element to the specified file.
		/// </summary>
		/// <param name="file">the file</param>
		/// <param name="element">the element</param>
		public void Save(string file, T element)
		{
			using (FileStream fileStream = File.Open(file, FileMode.Create))
			{
				this.xmlSerializer.Serialize(fileStream, element);
			}
		}

		private XmlSerializer xmlSerializer;
	}
}
