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
		/// Creates a new persistence container with the specified file name.
		/// </summary>
		/// <param name="name">the file name</param>
		public Persistence(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			this.Instance = null;

			this.name = name;
			this.settings = new XmlWriterSettings()
			{
				Indent = true,
				IndentChars = "\t",
				OmitXmlDeclaration = true
			};
		}

		/// <summary>
		/// Creates a new persistence container using the default path and name.
		/// </summary>
		public Persistence() : this(typeof(T).Name)
		{

		}

		/// <summary>
		/// Loads the instance from storage.
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
		/// Saves the instance to storage.
		/// </summary>
		public void Save()
		{
			var directory = this.GetDirectory();

			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			var serializer = new XmlSerializer(typeof(T));

			using (var stream = File.Open(this.GetPath(), FileMode.Create))
			using (var writer = XmlWriter.Create(stream, this.settings))
			{
				serializer.Serialize(writer, this.Instance);
			}
		}

		private string GetDirectory()
		{
			return "Configuration";
		}

		private string GetPath()
		{
			return Path.Combine(this.GetDirectory(), $"{this.name}.xml");
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
		private XmlWriterSettings settings;
	}
}
