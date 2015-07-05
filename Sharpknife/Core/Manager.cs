using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents a manager to load and save an element by using XML serialization.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public class Manager<T> where T : new()
	{
		/// <summary>
		/// Creates a new manager using the path from <see cref="Assemblies.GetApplicationPath" />.
		/// </summary>
		/// <param name="name">the file name</param>
		/// <returns>the manager</returns>
		public static Manager<T> CreatePersistence(string name)
		{
			return new Manager<T>(Path.Combine(Assemblies.GetApplicationPath(), string.Format("{0}.xml")));
		}

		/// <summary>
		/// Creates a new manager.
		/// </summary>
		/// <param name="path">the path</param>
		public Manager(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}

			this.Element = new T();

			this.path = path;
			this.serializer = new XmlSerializer(typeof(T));
		}

		/// <summary>
		/// Loads the element from the path.
		/// </summary>
		public void Load()
		{
			if (!File.Exists(this.path))
			{
				return;
			}

			using (var stream = File.Open(this.path, FileMode.Open))
			{
				this.Element = (T) this.serializer.Deserialize(stream);
			}
		}

		/// <summary>
		/// Saves the element to the path.
		/// </summary>
		public void Save()
		{
			var directory = Path.GetDirectoryName(this.path);

			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			using (var stream = File.Open(this.path, FileMode.Create))
			{
				this.serializer.Serialize(stream, this.Element);
			}
		}

		/// <summary>
		/// Gets or sets the element.
		/// </summary>
		public T Element
		{
			get;
			set;
		}

		private string path;
		private XmlSerializer serializer;
	}
}
