using Sharpknife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Persistence
{
	/// <summary>
	/// Represents a manager for a collection of objects.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public class ObjectCollectionManager<T> : Manager<List<T>>
	{
		/// <summary>
		/// Creates a new object collection manager.
		/// </summary>
		/// <param name="file">the file</param>
		public ObjectCollectionManager(string file) : base(file)
		{

		}
	}
}
