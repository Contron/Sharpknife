using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents a list that can be observed for changes. Changes will be propogated to the original backing list.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public class ObservableList<T> : ObservableCollection<T>
	{
		/// <summary>
		/// Creates a new observable list.
		/// </summary>
		/// <param name="list">the backing list</param>
		public ObservableList(List<T> list) : base(list)
		{
			this.list = list;
		}

		/// <summary>
		/// Creates a new empty observable list.
		/// </summary>
		public ObservableList() : this(null)
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

			//refresh
			this.list.Clear();
			this.list.AddRange(this);
		}

		private List<T> list;
	}
}
