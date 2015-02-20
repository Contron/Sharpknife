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
	/// Represents a manager to store settings.
	/// </summary>
	public class SettingsManager : BinaryManager<Dictionary<string, object>>
	{
		/// <summary>
		/// Creates a new settings manager.
		/// </summary>
		/// <param name="file">the file</param>
		public SettingsManager(string file) : base(file)
		{

		}

		/// <summary>
		/// Creates a new settings manager.
		/// </summary>
		public SettingsManager() : this("Settings")
		{

		}

		/// <summary>
		/// The dictionary of settings for the manager.
		/// </summary>
		/// <param name="index">the index</param>
		/// <returns>the value</returns>
		public object this[string index]
		{
			get
			{
				return this.Element[index];
			}
			set
			{
				this.Element[index] = value;
			}
		}
	}
}
