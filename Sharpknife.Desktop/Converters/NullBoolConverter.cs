using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Sharpknife.Desktop.Converters
{
	/// <summary>
	/// Represents a converter between a null value and a <see cref="bool" />.
	/// </summary>
	public class NullBoolConverter : IValueConverter
	{
		/// <summary>
		/// Creates a new converter.
		/// </summary>
		public NullBoolConverter()
		{
			this.Invert = false;
		}

		/// <summary>
		/// Converts a null or non-null value to a <see cref="bool" />>.
		/// </summary>
		/// <param name="value">the value</param>
		/// <param name="targetType">the target type</param>
		/// <param name="parameter">the parameter</param>
		/// <param name="culture">the culture</param>
		/// <returns>the visibility</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.Invert ? value == null : value != null;
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
		public bool Invert
		{
			get;
			set;
		}
	}
}
