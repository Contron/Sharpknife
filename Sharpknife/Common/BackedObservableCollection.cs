using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Common
{
	/// <summary>
	/// Represents an observable collection that is backed by an original <see cref="List{T}" />.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public class BackedObservableCollection<T> : ObservableCollection<T>
	{
		/// <summary>
		/// Creates a new backed observable collection.
		/// </summary>
		/// <param name="list">the list</param>
		public BackedObservableCollection(List<T> list) : base(list)
		{
			this.list = list;
		}

		/// <summary>
		/// Creates a new empty backed observable collection.
		/// </summary>
		public BackedObservableCollection() : this(null)
		{

		}

		/// <summary>
		/// Triggers the collection changed event.
		/// </summary>
		/// <param name="eventArgs">the event args</param>
		protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs eventArgs)
		{
			base.OnCollectionChanged(eventArgs);

			if (this.list == null)
			{
				return;
			}

			switch (eventArgs.Action)
			{
				case NotifyCollectionChangedAction.Add:
				{
					//add
					eventArgs.NewItems
						.Cast<T>()
						.ToList()
						.ForEach(item => this.list.Add(item));

					break;
				}
				case NotifyCollectionChangedAction.Remove:
				{
					//remove
					eventArgs.OldItems
						.Cast<T>()
						.ToList()
						.ForEach(item => this.list.Remove(item));

					break;
				}
				default:
				{
					//refresh
					this.list.Clear();
					this.list.AddRange(this);

					break;
				}
			}
		}

		private List<T> list;
	}
}
