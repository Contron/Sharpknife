using Sharpknife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Persistence
{
	/// <summary>
	/// Represents an object manager designed to hold a list of any type.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public class ObjectManager<T> : Manager<List<T>>
	{
		/// <summary>
		/// Creates a new object manager.
		/// </summary>
		/// <param name="directory">the directory</param>
		/// <param name="file">the file</param>
		/// <param name="element">the element</param>
		public ObjectManager(string directory, string file, List<T> element) : base(directory, file, element)
		{
			
		}

		/// <summary>
		/// Creates a new object manager with a default element.
		/// </summary>
		/// <param name="directory">the parent directory</param>
		/// <param name="file">the file</param>
		public ObjectManager(string directory, string file) : base(directory, file)
		{

		}

		/// <summary>
		/// Creates a new object manager with a default location and element.
		/// </summary>
		/// <param name="file">the file</param>
		public ObjectManager(string file) : base(file)
		{

		}
	}
}
