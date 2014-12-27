using Sharpknife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Persistence
{
	/// <summary>
	/// Represents a settings manager designed to hold a list of settings.
	/// </summary>
	public class SettingsManager : Manager<Dictionary<string, object>>
	{
		/// <summary>
		/// Creates a new settings manager.
		/// </summary>
		/// <param name="directory">the directory</param>
		/// <param name="file">the file</param>
		/// <param name="element">the element</param>
		public SettingsManager(string directory, string file, Dictionary<string, object> element) : base(directory, file, element)
		{
			
		}

		/// <summary>
		/// Creates a new settings manager with a default dictionary.
		/// </summary>
		/// <param name="directory">the parent directory</param>
		/// <param name="file">the file</param>
		public SettingsManager(string directory, string file) : base(directory, file)
		{

		}

		/// <summary>
		/// Creates a new settings manager with a default location and dictionary.
		/// </summary>
		/// <param name="file">the file</param>
		public SettingsManager(string file) : base(file)
		{

		}
	}
}
