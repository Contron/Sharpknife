using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Sharpknife.Desktop.Converters
{
	/// <summary>
	/// Represents a converter between a <see cref="bool" /> to a <see cref="Visibility" />.
	/// </summary>
	public class BoolVisibilityConverter : IValueConverter
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
		/// <param name="value">the bool</param>
		/// <param name="targetType">the target type</param>
		/// <param name="parameter">the parameter</param>
		/// <param name="culture">the culture</param>
		/// <returns>the visibility</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool target)
			{
				return (this.Invert ? !target : target) ? Visibility.Visible : Visibility.Collapsed;
			}

			throw new ArgumentException(nameof(value));
		}

		/// <summary>
		/// Converts back, this is not supported.
		/// </summary>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
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
