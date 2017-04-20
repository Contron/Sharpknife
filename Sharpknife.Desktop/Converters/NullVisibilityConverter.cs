using System.Windows;
using Sharpknife.Desktop.Core;

namespace Sharpknife.Desktop.Converters
{
	/// <summary>
	/// Represents a converter between a null value to a <see cref="Visibility" />.
	/// </summary>
	public class NullVisibilityConverter : Converter
	{
		/// <summary>
		/// Converts a null value to a <see cref="Visibility" />.
		/// </summary>
		/// <param name="value">the value</param>
		/// <returns>the visibility</returns>
		public override object Convert(object value)
		{
			return value != null ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
