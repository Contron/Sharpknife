using System;
using System.IO;
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
		/// Creates a new persistence container for the specified file.
		/// </summary>
		/// <param name="location">the file</param>
		public Persistence(string location)
		{
			this.Location = location ?? throw new ArgumentNullException(nameof(location));
		}

		/// <summary>
		/// Loads (or creates) the instance from disk.
		/// </summary>
		public void Load()
		{
			if (File.Exists(this.Location))
			{
				var serializer = new XmlSerializer(typeof(T));

				using (var stream = File.OpenRead(this.Location))
				using (var reader = XmlReader.Create(stream))
				{
					this.Instance = serializer.Deserialize(stream) as T ?? new T();
				}
			}
			else
			{
				this.Instance = new T();
			}
		}

		/// <summary>
		/// Saves the instance to disk.
		/// </summary>
		public void Save()
		{
			var directory = Path.GetDirectoryName(this.Location);

			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			var serializer = new XmlSerializer(typeof(T));

			using (var stream = File.OpenWrite(this.Location))
			using (var writer = XmlWriter.Create(stream, Persistence<T>.settings))
			{
				serializer.Serialize(stream, this.Instance);
			}
		}

		/// <summary>
		/// Gets the file.
		/// </summary>
		public string Location { get; private set; }

		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		public T Instance { get; set; }

		private static readonly XmlWriterSettings settings = new XmlWriterSettings()
		{
			Indent = true,
			IndentChars = "\t",
			OmitXmlDeclaration = true
		};
	}
}
