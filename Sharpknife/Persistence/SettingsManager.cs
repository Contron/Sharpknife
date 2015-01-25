using Sharpknife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Persistence
{
	/// <summary>
	/// Represents a manager to store settings.
	/// </summary>
	public class SettingsManager : Manager<Dictionary<string, object>>
	{
		/// <summary>
		/// Creates a new settings manager.
		/// </summary>
		/// <param name="file">the file</param>
		public SettingsManager(string file) : base(file)
		{

		}
	}
}
