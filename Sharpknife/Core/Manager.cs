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
		/// <param name="file">the file</param>
		public Manager(string file)
		{
			this.Directory = Assemblies.ApplicationPath;
			this.File = Path.Combine(this.Directory, string.Format("{0}.xml", file));
			this.Element = new T();

			this.serializer = new XmlSerializer(typeof(T));
		}

		/// <summary>
		/// Loads the element from file.
		/// </summary>
		public void Load()
		{
			if (System.IO.Directory.Exists(this.Directory) && System.IO.File.Exists(this.File))
			{
				using (var fileStream = System.IO.File.Open(this.File, FileMode.Open))
				{
					//deserialize
					this.Element = (T) this.serializer.Deserialize(fileStream);
				}
			}
		}

		/// <summary>
		/// Saves the element to file.
		/// </summary>
		public void Save()
		{
			if (!System.IO.Directory.Exists(this.Directory))
			{
				//create
				System.IO.Directory.CreateDirectory(this.Directory);
			}

			using (var fileStream = System.IO.File.Open(this.File, FileMode.Create))
			{
				//serialize
				this.serializer.Serialize(fileStream, this.Element);
			}
		}

		/// <summary>
		/// Gets or sets the directory for the manager.
		/// </summary>
		public string Directory
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the file for the manager.
		/// </summary>
		public string File
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the element for the manager.
		/// </summary>
		public T Element
		{
			get;
			set;
		}

		private XmlSerializer serializer;
	}
}
