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
	public class SettingsManager : Manager<List<Setting>>
	{
		/// <summary>
		/// Creates a new settings manager.
		/// </summary>
		/// <param name="directory">the directory</param>
		/// <param name="file">the file</param>
		/// <param name="element">the element</param>
		public SettingsManager(string directory, string file, List<Setting> element) : base(directory, file, element)
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

		/// <summary>
		/// Returns the matching setting with the specified key, or null.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>the setting, or null</returns>
		public Setting Get(string key)
		{
			//result
			var result = this.Element.FirstOrDefault(setting => setting.Key == key);

			return result;
		}

		/// <summary>
		/// Sets or creates a setting for the specified key and value.
		/// </summary>
		/// <param name="key">the key</param>
		/// <param name="value">the value</param>
		public void Set(string key, object value)
		{
			//setting
			var setting = this.Get(key);

			if (setting != null)
			{
				//update
				setting.Value = value;
			}
			else
			{
				//add
				this.Element.Add(new Setting(key, value));
			}
		}

		/// <summary>
		/// The internal list of settings.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>the setting</returns>
		public Setting this[string key]
		{
			get
			{
				return this.Get(key);
			}
			set
			{
				this.Set(key, value);
			}
		}
	}
}
