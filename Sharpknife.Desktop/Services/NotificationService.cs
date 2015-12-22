using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a notification service to send and receive events.
	/// </summary>
	public class NotificationService
	{
		private NotificationService()
		{
			this.listeners = new Dictionary<string, List<Action<object>>>();
		}

		/// <summary>
		/// Posts a notification with the specified <see cref="object" /> parameter.
		/// </summary>
		/// <param name="notification">the notification</param>
		/// <param name="parameter">the parameter</param>
		public void Post(string notification, object parameter = null)
		{
			if (notification == null)
			{
				throw new ArgumentNullException(nameof(notification));
			}

			if (!this.listeners.ContainsKey(notification))
			{
				return;
			}

			foreach (var listener in this.listeners[notification])
			{
				listener.Invoke(parameter);
			}
		}

		/// <summary>
		/// Subscribes the specified <see cref="Action" /> to the specified notification.
		/// </summary>
		/// <param name="notification">the notification</param>
		/// <param name="action">the action</param>
		public void Subscribe(string notification, Action<object> action)
		{
			if (notification == null)
			{
				throw new ArgumentNullException(nameof(notification));
			}

			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			if (!this.listeners.ContainsKey(notification))
			{
				this.listeners[notification] = new List<Action<object>>();
			}

			this.listeners[notification].Add(action);
		}

		/// <summary>
		/// Unsubscribes the specified <see cref="Action" /> from the specified notification.
		/// </summary>
		/// <param name="notification">the notification</param>
		/// <param name="action">the action</param>
		public void Unsubscribe(string notification, Action<object> action)
		{
			if (notification == null)
			{
				throw new ArgumentNullException(nameof(notification));
			}

			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			if (!this.listeners.ContainsKey(notification))
			{
				return;
			}

			this.listeners[notification].Remove(action);
		}

		/// <summary>
		/// Unsubscribes all subscribed <see cref="Action "/>s from the specified notification.
		/// </summary>
		/// <param name="notification">the notification</param>
		public void UnsubscribeAll(string notification)
		{
			if (notification == null)
			{
				throw new ArgumentNullException(nameof(notification));
			}

			if (!this.listeners.ContainsKey(notification))
			{
				return;
			}

			this.listeners[notification].Clear();
		}

		/// <summary>
		/// Gets the instance of the notification service.
		/// </summary>
		public static NotificationService Instance
		{
			get
			{
				return NotificationService.instance;
			}
		}

		private static readonly NotificationService instance = new NotificationService();

		private Dictionary<string, List<Action<object>>> listeners;
	}
}
