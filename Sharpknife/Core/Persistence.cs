using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents a container around a <see cref="object" /> to manage persistence.
	/// </summary>
	/// <typeparam name="T">the type to contain</typeparam>
	public class Persistence<T> where T : class, new()
	{
		/// <summary>
		/// Creates a new persistence container for the specified file.
		/// </summary>
		/// <param name="path">the file</param>
		public Persistence(string path)
		{
			this.Path = System.IO.Path.ChangeExtension(System.IO.Path.GetFullPath(path ?? throw new ArgumentNullException(nameof(path))), "xml");
		}

		/// <summary>
		/// Creates a new persistence container using the name of the type.
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
			return $"Persistence (Location: {this.Path})";
		}

		/// <summary>
		/// Loads the instance from file, or creates a new instance.
		/// </summary>
		public void Load()
		{
			if (File.Exists(this.Path))
			{
				var serializer = new XmlSerializer(typeof(T));

				using (var stream = File.OpenRead(this.Path))
				using (var reader = XmlReader.Create(stream))
				{
					this.Instance = serializer.Deserialize(reader) as T ?? new T();
				}
			}
			else
			{
				this.Instance = new T();
			}
		}

		/// <summary>
		/// Saves the instance to file.
		/// </summary>
		public void Save()
		{
			var directory = System.IO.Path.GetDirectoryName(this.Path);

			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			var serializer = new XmlSerializer(typeof(T));

			using (var stream = File.OpenWrite(this.Path))
			using (var writer = XmlWriter.Create(stream, Persistence<T>.settings))
			{
				serializer.Serialize(writer, this.Instance);
			}
		}

		/// <summary>
		/// Gets the path to the file.
		/// </summary>
		public string Path { get; }

		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		public T Instance { get; set; }

		private static XmlWriterSettings settings = new XmlWriterSettings()
		{
			OmitXmlDeclaration = true,
			Indent = true,
			IndentChars = "\t"
		};
	}
}
