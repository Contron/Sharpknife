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

		#region Event Triggers

		private void OnPropertyChanged(string property)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}

		#endregion

		/// <summary>
		/// Occurs when a property changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
