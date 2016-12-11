using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents a container around a <see cref="object" /> to manage persistence.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Persistence<T> where T : class, new()
	{
		/// <summary>
		/// Creates a new persistence container with the specified name and directory.
		/// </summary>
		/// <param name="name">the name</param>
		/// <param name="directory">the directory</param>
		public Persistence(string name, string directory)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			if (directory == null)
			{
				throw new ArgumentNullException(nameof(directory));
			}

			this.Instance = null;

			this.name = name;
			this.directory = directory;

			this.settings = new XmlWriterSettings()
			{
				Indent = true,
				IndentChars = "\t",
				OmitXmlDeclaration = true
			};
		}

		/// <summary>
		/// Creates a new persistence container.
		/// </summary>
		public Persistence() : this(typeof(T).Name, "Configuration")
		{

		}

		/// <summary>
		/// Returns a string representation.
		/// </summary>
		/// <returns>the representation</returns>
		public override string ToString()
		{
			return $"Persistence (Name: {this.name}, Directory: {this.directory})";
		}

		/// <summary>
		/// Loads the instance.
		/// Returns a new instance if it does not exist.
		/// </summary>
		public void Load()
		{
			var path = this.GetPath();

			if (!File.Exists(path))
			{
				this.Instance = new T();

				return;
			}

			var serializer = new XmlSerializer(typeof(T));

			using (var stream = File.Open(path, FileMode.Open))
			{
				this.Instance = serializer.Deserialize(stream) as T;
			}
		}

		/// <summary>
		/// Saves the instance.
		/// </summary>
		public void Save()
		{
			if (!Directory.Exists(this.directory))
			{
				Directory.CreateDirectory(this.directory);
			}

			var serializer = new XmlSerializer(typeof(T));

			using (var stream = File.Open(this.GetPath(), FileMode.Create))
			using (var writer = XmlWriter.Create(stream, this.settings))
			{
				serializer.Serialize(writer, this.Instance);
			}
		}

		private string GetPath()
		{
			return Path.Combine(this.directory, $"{this.name}.xml");
		}

		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		public T Instance
		{
			get;
			set;
		}

		private string name;
		private string directory;

		private XmlWriterSettings settings;
	}
}
