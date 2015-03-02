using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents a notification center to send and receive loosely coupled events.
	/// </summary>
	public class NotificationCenter
	{
		/// <summary>
		/// Creates a new notification center.
		/// </summary>
		public NotificationCenter()
		{
			this.listeners = new Dictionary<string, List<Action<object>>>();
		}

		/// <summary>
		/// Posts a notification with the specified <see cref="object" /> parameter.
		/// </summary>
		/// <param name="notification">the notification</param>
		/// <param name="parameter">the parameter</param>
		public void Post(string notification, object parameter)
		{
			if (!this.listeners.ContainsKey(notification))
			{
				return;
			}

			//post
			this.listeners[notification].ForEach(action => action(parameter));
		}

		/// <summary>
		/// Subscribes the specified <see cref="Action" /> to the specified notification.
		/// </summary>
		/// <param name="notification">the notification</param>
		/// <param name="action">the action</param>
		public void Subscribe(string notification, Action<object> action)
		{
			if (!this.listeners.ContainsKey(notification))
			{
				//create
				this.listeners[notification] = new List<Action<object>>();
			}

			//add
			this.listeners[notification].Add(action);
		}

		/// <summary>
		/// Unsubscribes the specified <see cref="Action" /> from the specified notification.
		/// </summary>
		/// <param name="notification">the notification</param>
		/// <param name="action">the action</param>
		public void Unsubscribe(string notification, Action<object> action)
		{
			if (!this.listeners.ContainsKey(notification))
			{
				return;
			}

			//remove
			this.listeners[notification].Remove(action);
		}

		/// <summary>
		/// Unsubscribes all subscribed <see cref="Action "/>s from the specified notification.
		/// </summary>
		/// <param name="notification">the notification</param>
		public void UnsubscribeAll(string notification)
		{
			if (!this.listeners.ContainsKey(notification))
			{
				return;
			}

			//clear
			this.listeners[notification].Clear();
		}

		/// <summary>
		/// The static instance of the notification center.
		/// </summary>
		public static readonly NotificationCenter Instance = new NotificationCenter();

		private Dictionary<string, List<Action<object>>> listeners;
	}
}
