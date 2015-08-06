using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Core
{
	/// <summary>
	/// Represents an object that can be observed for changes.
	/// </summary>
	public abstract class Observable : INotifyPropertyChanged
	{
		/// <summary>
		/// Creates a new observable.
		/// </summary>
		public Observable()
		{
			this.properties = new Dictionary<string, object>();
		}

		/// <summary>
		/// Returns the value of the specified property.
		/// </summary>
		/// <param name="property">the property</param>
		/// <returns>the value</returns>
		protected object Get([CallerMemberName] string property = null)
		{
			if (property == null)
			{
				throw new ArgumentNullException(nameof(property));
			}

			if (this.properties.ContainsKey(property))
			{
				return this.properties[property];
			}

			return null;
		}

		/// <summary>
		/// Sets the value of the specified property.
		/// </summary>
		/// <param name="value">the value</param>
		/// <param name="property">the property</param>
		protected void Set(object value, [CallerMemberName] string property = null)
		{
			if (property == null)
			{
				throw new ArgumentNullException(nameof(property));
			}

			this.properties[property] = value;

			this.Notify(property);
		}

		/// <summary>
		/// Notifies that the specified property has changed.
		/// </summary>
		/// <param name="property">the property</param>
		protected void Notify(string property)
		{
			this.OnPropertyChanged(new PropertyChangedEventArgs(property));
		}

		/// <summary>
		/// Triggers the property changed event.
		/// </summary>
		/// <param name="eventArgs">the event args</param>
		protected void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
		{
			this.PropertyChanged?.Invoke(this, eventArgs);
		}

		/// <summary>
		/// Occurs when a property has changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		private Dictionary<string, object> properties;
	}
}
