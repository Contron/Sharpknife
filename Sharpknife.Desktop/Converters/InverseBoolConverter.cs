using System;
using Sharpknife.Desktop.Core;

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
			var next = value as bool?;

			if (next != null)
			{
				return !next.Value;
			}

			throw new ArgumentException(nameof(value));
		}
	}
}
