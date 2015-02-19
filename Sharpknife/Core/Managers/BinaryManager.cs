using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Core.Managers
{
	/// <summary>
	/// Represents a manager that saves its contents to a binary file.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public abstract class BinaryManager<T> : Manager<T> where T : new()
	{
		/// <summary>
		/// Creates a new binary manager.
		/// </summary>
		/// <param name="file">the file</param>
		public BinaryManager(string file) : base(file, "bin")
		{
			this.binaryFormatter = new BinaryFormatter();
		}

		/// <summary>
		/// Loads from the source file.
		/// </summary>
		/// <param name="fileStream">the file stream</param>
		/// <returns>the element</returns>
		protected override T LoadFromSource(FileStream fileStream)
		{
			return (T) this.binaryFormatter.Deserialize(fileStream);
		}

		/// <summary>
		/// Saves to the source file.
		/// </summary>
		/// <param name="fileStream">the file stream</param>
		/// <param name="element">the element</param>
		protected override void SaveToSource(FileStream fileStream, T element)
		{
			this.binaryFormatter.Serialize(fileStream, element);
		}

		private BinaryFormatter binaryFormatter;
	}
}
