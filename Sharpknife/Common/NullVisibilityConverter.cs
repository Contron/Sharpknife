using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Sharpknife.Common
{
	/// <summary>
	/// Represents a value converter to determine the <see cref="Visibility" /> based on the specified value.
	/// </summary>
	public class NullVisibilityConverter : IValueConverter
	{
		/// <summary>
		/// Converts an object to its matching visibility.
		/// </summary>
		/// <param name="value">the value</param>
		/// <param name="targetType">the target type</param>
		/// <param name="parameter">the parameter</param>
		/// <param name="culture">the culture</param>
		/// <returns>the result</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value == null ? Visibility.Collapsed : Visibility.Visible;
		}

		/// <summary>
		/// Converts an object to back from its matching visibility.
		/// </summary>
		/// <param name="value">the value</param>
		/// <param name="targetType">the target type</param>
		/// <param name="parameter">the parameter</param>
		/// <param name="culture">the culture</param>
		/// <returns>the result</returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
