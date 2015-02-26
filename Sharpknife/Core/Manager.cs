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
	/// Represents a manager that can control the persistence of any type by providing the appropriate methods to load and save it from an XML file.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public abstract class Manager<T> where T : new()
	{
		/// <summary>
		/// Creates a new manager.
		/// </summary>
		/// <param name="file">the file</param>
		/// <param name="format">the format</param>
		public Manager(string file, string format)
		{
			this.Directory = Sharpknife.ApplicationPath;
			this.File = Path.Combine(this.Directory, string.Format("{0}.{1}", file, format));
			this.Element = new T();
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

			using (var fileStream = System.IO.File.Open(this.File, FileMode.Open))
			{
				//load
				this.Element = this.LoadFromSource(fileStream);
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
				//save
				this.SaveToSource(fileStream, this.Element);
			}
		}

		/// <summary>
		/// Loads from the source file.
		/// </summary>
		/// <param name="fileStream">the file stream</param>
		/// <returns>the element</returns>
		protected abstract T LoadFromSource(FileStream fileStream);

		/// <summary>
		/// Saves to the source file.
		/// </summary>
		/// <param name="fileStream">the file stream</param>
		/// <param name="element">the element</param>
		protected abstract void SaveToSource(FileStream fileStream, T element);

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
	}
}
