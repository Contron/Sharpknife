using Sharpknife.Core;
using Sharpknife.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Persistence
{
	/// <summary>
	/// Represents a manager for a particular object.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public class ObjectManager<T> : XmlManager<T> where T : new()
	{
		/// <summary>
		/// Creates a new object manager.
		/// </summary>
		/// <param name="file">the file</param>
		public ObjectManager(string file) : base(file)
		{

		}
	}
}
