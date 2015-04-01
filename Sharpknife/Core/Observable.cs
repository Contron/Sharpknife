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
		/// Returns the value of the specified property, or null if it does not exist.
		/// </summary>
		/// <param name="property">the property</param>
		/// <returns>the value</returns>
		protected object Get([CallerMemberName] string property = null)
		{
			if (property == null)
			{
				throw new ArgumentNullException(property);
			}

			//get
			var result = this.properties.ContainsKey(property) ? this.properties[property] : null;

			return result;
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
				throw new ArgumentNullException(property);
			}

			//set
			this.properties[property] = value;
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

		private Dictionary<string, object> properties;
	}
}
