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
			
		}

		/// <summary>
		/// Sets the specified field to the specified value, notifying that the specified property has changed.
		/// </summary>
		/// <typeparam name="T">the type of the field</typeparam>
		/// <param name="field">the field</param>
		/// <param name="value">the value</param>
		/// <param name="property">the property</param>
		protected void Set<T>(ref T field, T value, [CallerMemberName] string property = null)
		{
			if (property == null)
			{
				throw new ArgumentNullException(nameof(property));
			}

			field = value;

			this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(property)));
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
	}
}
