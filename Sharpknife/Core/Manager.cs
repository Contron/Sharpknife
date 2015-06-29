using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents a manager that can easily control the persistence of an object via XML serialization.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public class Manager<T> where T : new()
	{
		/// <summary>
		/// Creates a new manager.
		/// </summary>
		/// <param name="directory">the directory</param>
		/// <param name="file">the file</param>
		public Manager(string directory, string file)
		{
			if (directory == null)
			{
				throw new ArgumentNullException("directory");
			}

			if (file == null)
			{
				throw new ArgumentNullException("file");
			}

			this.Path = System.IO.Path.Combine(directory, string.Format("{0}.xml", file));
			this.Element = new T();

			this.directory = System.IO.Path.GetDirectoryName(this.Path);
			this.serializer = new XmlSerializer(typeof(T));
		}

		/// <summary>
		/// Creates a new manager.
		/// </summary>
		/// <param name="file">the file</param>
		public Manager(string file) : this(Assemblies.GetApplicationPath(), file)
		{
			
		}

		/// <summary>
		/// Loads the element from file.
		/// </summary>
		public void Load()
		{
			if (!Directory.Exists(this.directory) || !File.Exists(this.Path))
			{
				return;
			}

			using (var stream = File.Open(this.Path, FileMode.Open))
			{
				this.Element = (T) this.serializer.Deserialize(stream);
			}
		}

		/// <summary>
		/// Saves the element to file.
		/// </summary>
		public void Save()
		{
			if (!Directory.Exists(this.directory))
			{
				Directory.CreateDirectory(this.directory);
			}

			using (var stream = File.Open(this.Path, FileMode.Create))
			{
				this.serializer.Serialize(stream, this.Element);
			}
		}

		/// <summary>
		/// Gets or sets the path of the file.
		/// </summary>
		public string Path
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the element.
		/// </summary>
		public T Element
		{
			get;
			set;
		}

		private string directory;
		private XmlSerializer serializer;
	}
}
