using Sharpknife.Desktop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sharpknife.Desktop.Converters
{
	/// <summary>
	/// Represents a converter to inverse a <see cref="bool" />.
	/// </summary>
	public class InverseBoolConverter : Converter
	{
		/// <summary>
		/// Inverses a <see cref="bool" />.
		/// </summary>
		/// <param name="value">the value</param>
		/// <returns>the visibility</returns>
		public override object Convert(object value)
		{
			var boolValue = value as bool?;

			if (boolValue != null)
			{
				return !boolValue.Value;
			}

			throw new ArgumentException(nameof(value));
		}
	}
}
