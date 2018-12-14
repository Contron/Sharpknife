using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Sharpknife.Desktop.Converters
{
	/// <summary>
	/// Represents a converter between a null value to a <see cref="Visibility" />.
	/// </summary>
	public class NullVisibilityConverter : IValueConverter
	{
		/// <summary>
		/// Creates a new converter.
		/// </summary>
		public NullVisibilityConverter()
		{
			
		}

		/// <summary>
		/// Converts a null value to a <see cref="Visibility" />.
		/// </summary>
		/// <param name="value">the bool</param>
		/// <param name="targetType">the target type</param>
		/// <param name="parameter">the parameter</param>
		/// <param name="culture">the culture</param>
		/// <returns>the visibility</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (this.Invert ? value == null : value != null) ? Visibility.Visible : Visibility.Collapsed;
		}

		/// <summary>
		/// Converts back, this is unsupported and will always throw a <see cref="NotImplementedException" />.
		/// </summary>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets or sets if the converter is inverted.
		/// </summary>
		public bool Invert { get; set; } = false;
	}
}
