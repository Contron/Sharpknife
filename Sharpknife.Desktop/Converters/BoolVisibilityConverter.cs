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
	/// Represents a converter between a <see cref="bool" /> to a <see cref="Visibility" />.
	/// </summary>
	public class BoolVisibilityConverter : Converter
	{
		/// <summary>
		/// Creates a new converter.
		/// </summary>
		public BoolVisibilityConverter()
		{
			this.Invert = false;
		}

		/// <summary>
		/// Converts a <see cref="bool" /> to a <see cref="Visibility" />.
		/// </summary>
		/// <param name="value">the value</param>
		/// <returns>the visibility</returns>
		public override object Convert(object value)
		{
			var boolValue = value as bool?;

			if (boolValue != null)
			{
				if (this.Invert)
				{
					boolValue = !boolValue.Value;
				}

				return boolValue.Value ? Visibility.Visible : Visibility.Collapsed;
			}

			throw new ArgumentException(nameof(value));
		}

		/// <summary>
		/// Gets or sets if the converter is inverted.
		/// </summary>
		public bool Invert
		{
			get;
			set;
		}
	}
}
