﻿using System;
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
	/// Represents a class that can be extended in order to provide the functionality of loading and saving any type to and from a file.
	/// The type can be modified at will.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public abstract class Manager<T> where T : new()
	{
		/// <summary>
		/// Creates a new manager.
		/// </summary>
		/// <param name="file">the file</param>
		public Manager(string file)
		{
			this.Directory = Sharpknife.ApplicationPath;
			this.File = Path.Combine(this.Directory, file + ".xml");
			this.Element = new T();

			this.xmlSerializer = new XmlSerializer(typeof(T));
		}

		/// <summary>
		/// Loads the element from file.
		/// </summary>
		public void Load()
		{
			if (!System.IO.Directory.Exists(this.Directory) || !System.IO.File.Exists(this.File))
			{
				return;
			}

			using (FileStream fileStream = System.IO.File.Open(this.File, FileMode.Open))
			{
				//deserialize
				this.Element = (T) this.xmlSerializer.Deserialize(fileStream);
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

			using (FileStream fileStream = System.IO.File.Open(this.File, FileMode.Create))
			{
				//serialize
				this.xmlSerializer.Serialize(fileStream, this.Element);
			}
		}

		/// <summary>
		/// The directory for the manager.
		/// </summary>
		public string Directory
		{
			get;
			set;
		}

		/// <summary>
		/// The file for the manager.
		/// </summary>
		public string File
		{
			get;
			set;
		}

		/// <summary>
		/// The element for the manager.
		/// </summary>
		public T Element
		{
			get;
			set;
		}

		private XmlSerializer xmlSerializer;
	}
}
