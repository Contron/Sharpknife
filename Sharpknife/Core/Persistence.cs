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
		/// Creates a new persistence container with the specified name.
		/// </summary>
		/// <param name="name">the name</param>
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
		/// Creates a new persistence container.
		/// </summary>
		public Persistence() : this(typeof(T).Name)
		{

		}

		/// <summary>
		/// Returns a string representation.
		/// </summary>
		/// <returns>the representation</returns>
		public override string ToString()
		{
			return $"Persistence (Name: {this.name})";
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

		/// <summary>
		/// Returns the directory of the persistence file.
		/// </summary>
		/// <returns></returns>
		protected virtual string GetDirectory()
		{
			return "Configuration";
		}

		/// <summary>
		/// Returns the full path to the persistence file.
		/// </summary>
		/// <returns></returns>
		protected virtual string GetPath()
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
