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
		/// Creates a new persistence container with the specified path and file name.
		/// </summary>
		/// <param name="path">the path</param>
		/// <param name="name">the file name</param>
		public Persistence(string path, string name)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			this.Instance = null;

			this.path = path;
			this.name = name;

			this.settings = new XmlWriterSettings()
			{
				Indent = true,
				IndentChars = "\t",
				OmitXmlDeclaration = true
			};
		}

		/// <summary>
		/// Creates a new persistence container with the specified path.
		/// </summary>
		/// <param name="path">the path</param>
		public Persistence(string path) : this(path, typeof(T).Name)
		{

		}

		/// <summary>
		/// Creates a new persistence container using the default path and name.
		/// </summary>
		public Persistence() : this("Configuration")
		{

		}

		/// <summary>
		/// Loads the instance from storage.
		/// </summary>
		public void Load()
		{
			if (!File.Exists(this.Path))
			{
				this.Instance = new T();

				return;
			}

			var serializer = new XmlSerializer(typeof(T));

			using (var stream = File.Open(this.Path, FileMode.Open))
			{
				this.Instance = serializer.Deserialize(stream) as T;
			}
		}

		/// <summary>
		/// Saves the instance to storage.
		/// </summary>
		public void Save()
		{
			if (!Directory.Exists(this.path))
			{
				Directory.CreateDirectory(this.path);
			}

			var serializer = new XmlSerializer(typeof(T));

			using (var stream = File.Open(this.Path, FileMode.Create))
			using (var writer = XmlWriter.Create(stream, this.settings))
			{
				serializer.Serialize(writer, this.Instance);
			}
		}

		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		public T Instance
		{
			get;
			set;
		}

		private string path;
		private string name;

		private XmlWriterSettings settings;

		private string Path
		{
			get
			{
				return System.IO.Path.Combine(this.path, $"{this.name}.xml");
			}
		}

	}
}
