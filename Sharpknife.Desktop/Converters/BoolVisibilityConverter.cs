using System;
using System.Windows;
using Sharpknife.Desktop.Core;

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
			var next = value as bool?;

			if (next != null)
			{
				if (this.Invert)
				{
					next = !next.Value;
				}

				return next.Value ? Visibility.Visible : Visibility.Collapsed;
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
