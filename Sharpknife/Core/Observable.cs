using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents an implementation of <see cref="INotifyPropertyChanged" /> which can be subclassed to provide notification support.
	/// </summary>
	public class Observable : INotifyPropertyChanged
	{
		/// <summary>
		/// Sets the specified field, triggering a property changed event.
		/// </summary>
		/// <typeparam name="T">the type</typeparam>
		/// <param name="field">the field</param>
		/// <param name="value">the value</param>
		/// <param name="property">the property</param>
		protected void SetNotify<T>(ref T field, T value, [CallerMemberName] string property = null)
		{
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}

			//change
			field = value;
			this.NotifyPropertyChanged(property);
		}

		/// <summary>
		/// Notifies that the specified property has changed.
		/// </summary>
		/// <param name="property">the property</param>
		protected void NotifyPropertyChanged([CallerMemberName] string property = null)
		{
			if (property == null)
			{
				throw new ArgumentNullException("property");
			}

			//trigger
			this.OnPropertyChanged(property);
		}

		/// <summary>
		/// Triggers the property changed event.
		/// </summary>
		/// <param name="property">the property</param>
		protected void OnPropertyChanged(string property)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}

		/// <summary>
		/// Occurs when a property changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
