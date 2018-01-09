using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sharpknife.Desktop.Core
{
	/// <summary>
	/// Represents an implementation of <see cref="INotifyPropertyChanged" /> to form an 'observable' object.
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

			this.OnPropertyChanged(new PropertyChangedEventArgs(property));
		}

		/// <summary>
		/// Explicitly notifies that the specified property has changed.
		/// </summary>
		/// <param name="property">the property</param>
		protected void Notify(string property)
		{
			if (property == null)
			{
				throw new ArgumentNullException(nameof(property));
			}

			this.OnPropertyChanged(new PropertyChangedEventArgs(property));
		}

		/// <summary>
		/// Triggers the property changed event.
		/// </summary>
		/// <param name="args">the event args</param>
		protected void OnPropertyChanged(PropertyChangedEventArgs args)
		{
			this.PropertyChanged?.Invoke(this, args);
		}

		/// <summary>
		/// Occurs when a property has changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		private Dictionary<string, object> properties;
	}
}
