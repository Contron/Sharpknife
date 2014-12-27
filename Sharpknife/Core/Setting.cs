using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents a single setting.
	/// </summary>
	public class Setting
	{
		/// <summary>
		/// Creates a new setting.
		/// </summary>
		/// <param name="key">the key</param>
		/// <param name="value">the value</param>
		public Setting(string key, object value)
		{
			this.Key = key;
			this.Value = value;
		}

		/// <summary>
		/// Creates a new, default setting.
		/// </summary>
		public Setting() : this("Setting", 0)
		{

		}

		/// <summary>
		/// The key of this setting.
		/// </summary>
		public string Key
		{
			get;
			set;
		}

		/// <summary>
		/// The value of this setting.
		/// </summary>
		public object Value
		{
			get;
			set;
		}

		/// <summary>
		/// The integer value of this setting.
		/// </summary>
		public int IntValue
		{
			get
			{
				return (int) this.Value;
			}
		}

		/// <summary>
		/// The long value of this setting.
		/// </summary>
		public long LongValue
		{
			get
			{
				return (long) this.Value;
			}
		}

		/// <summary>
		/// The double value of this setting.
		/// </summary>
		public double DoubleValue
		{
			get
			{
				return (double) this.Value;
			}
		}

		/// <summary>
		/// The string value of this setting.
		/// </summary>
		public string StringValue
		{
			get
			{
				return (string) this.Value;
			}
		}
	}
}
