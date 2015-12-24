using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a service to manage persistence and serialization of objects.
	/// </summary>
	public class PersistenceService
	{
		class Entry
		{
			public Entry(string name, object instance)
			{
				this.Name = name;
				this.Instance = instance;
			}

			public string Name
			{
				get;
				set;
			}

			public object Instance
			{
				get;
				set;
			}
		}

		private PersistenceService()
		{
			this.entries = new List<Entry>();

			this.Hook();
		}

		/// <summary>
		/// Gets an object from persistence with the specified type and name.
		/// </summary>
		/// <typeparam name="T">the type</typeparam>
		/// <param name="name">the name</param>
		/// <returns>the object</returns>
		public T Get<T>(string name)
		{
			var entry = this.entries.FirstOrDefault(current => current.Name == name);

			if (entry == null)
			{
				entry = this.Store(name, typeof(T));
			}

			return (T) entry.Instance;
		}

		/// <summary>
		/// Syncs all loaded persistence objects and writes them to file.
		/// </summary>
		public void Sync()
		{
			foreach (var entry in this.entries)
			{
				this.Save(entry.Name, entry.Instance, entry.Instance.GetType());
			}
		}

		private Entry Store(string name, Type type)
		{
			var instance = this.Load(name, type);
			var entry = new Entry(name, instance);

			this.entries.Add(entry);

			return entry;
		}

		private object Load(string name, Type type)
		{
			var path = this.GetPath(name);

			if (!File.Exists(path))
			{
				return Activator.CreateInstance(type);
			}

			var serializer = new XmlSerializer(type);

			using (var stream = File.Open(path, FileMode.Open))
			{
				return serializer.Deserialize(stream);
			}
		}

		private void Save(string name, object instance, Type type)
		{
			var path = this.GetPath(name);
			var directory = Path.GetExtension(path);

			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			var serializer = new XmlSerializer(type);

			using (var stream = File.Open(path, FileMode.Open))
			{
				serializer.Serialize(stream, instance);
			}
		}

		private string GetPath(string name)
		{
			return Path.Combine(Assemblies.GetApplicationPath(), $"{name}.xml");
		}

		private void Hook()
		{
			Application.Current.Exit += (sender, eventArgs) => this.Sync();
		}

		/// <summary>
		/// Gets the instance of the persistence service.
		/// </summary>
		public static PersistenceService Instance
		{
			get
			{
				return PersistenceService.instance;
			}
		}

		private static readonly PersistenceService instance = new PersistenceService();

		private List<Entry> entries;
	}
}
