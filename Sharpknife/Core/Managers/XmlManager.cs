using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sharpknife.Core.Managers
{
	/// <summary>
	/// Represents a manager that saves its contents to an XML file.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class XmlManager<T> : Manager<T> where T : new()
	{
		/// <summary>
		/// Creates a new XML manager.
		/// </summary>
		/// <param name="file">the file</param>
		public XmlManager(string file) : base(file, "xml")
		{
			this.xmlSerializer = new XmlSerializer(typeof(T));
		}

		/// <summary>
		/// Loads from the source file.
		/// </summary>
		/// <param name="fileStream">the file stream</param>
		/// <returns>the element</returns>
		protected override T LoadFromSource(FileStream fileStream)
		{
			return (T) this.xmlSerializer.Deserialize(fileStream);
		}

		/// <summary>
		/// Saves to the source file.
		/// </summary>
		/// <param name="fileStream">the file stream</param>
		/// <param name="element">the element</param>
		protected override void SaveToSource(FileStream fileStream, T element)
		{
			this.xmlSerializer.Serialize(fileStream, element);
		}

		private XmlSerializer xmlSerializer;
	}
}
