using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Sharpknife.Desktop.Core
{
	/// <summary>
	/// Represents an implementation of <see cref="IValueConverter" /> with simpler methods.
	/// </summary>
	public abstract class Converter : IValueConverter
	{
		/// <summary>
		/// Converts the specified value to the specified type.
		/// </summary>
		/// <param name="value">the value</param>
		/// <param name="targetType">the target type</param>
		/// <param name="parameter">the parameter</param>
		/// <param name="culture">the culture</param>
		/// <returns>the result</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.Convert(value);
		}

		/// <summary>
		/// Converts the specified value back from the specified type.
		/// </summary>
		/// <param name="value">the value</param>
		/// <param name="targetType">the target type</param>
		/// <param name="parameter">the parameter</param>
		/// <param name="culture">the culture</param>
		/// <returns>the result</returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.ConvertBack(value);
		}

		/// <summary>
		/// Converts the specified value into a different type.
		/// </summary>
		/// <param name="value">the value</param>
		/// <returns>the result</returns>
		public virtual object Convert(object value)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Converts the specified value back into its original type.
		/// </summary>
		/// <param name="value">the value</param>
		/// <returns>the result</returns>
		public virtual object ConvertBack(object value)
		{
			throw new NotImplementedException();
		}
	}
}
