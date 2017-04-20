using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a notification service to send and receive loosely-coupled events.
	/// Handlers are kept using a <see cref="WeakReference" />, meaning that in most cases manual unsubscription is not necessary. Deallocated handlers are removed automatically.
	/// </summary>
	public sealed class NotificationService
	{
		interface IListener
		{
			WeakReference Reference
			{
				get;
			}
		}

		class Listener<T> : IListener where T : class
		{
			public Listener(Action<T> action)
			{
				this.Reference = new WeakReference(action);
			}

			public WeakReference Reference
			{
				get;
				private set;
			}

			public Action<T> Action
			{
				get
				{
					return this.Reference.Target as Action<T>;
				}
			}
		}

		private NotificationService()
		{
			this.listeners = new Dictionary<string, List<IListener>>();
		}

		/// <summary>
		/// Posts the specified notification with the specified parameter.
		/// </summary>
		/// <typeparam name="T">the parameter type</typeparam>
		/// <param name="notification">the notification</param>
		/// <param name="parameter">the parameter</param>
		public void Post<T>(string notification, T parameter = null) where T : class
		{
			if (notification == null)
			{
				throw new ArgumentNullException(nameof(notification));
			}

			if (!this.listeners.ContainsKey(notification))
			{
				return;
			}
			
			// Purge all old handlers that have been deallocated by the garbage collector.

			foreach (var entry in this.listeners)
			{
				entry.Value.RemoveAll(listener => listener.Reference.Target == null);
			}

			var listeners = this.listeners[notification].OfType<Listener<T>>();

			foreach (var listener in listeners)
			{
				listener.Action?.Invoke(parameter);
			}
		}

		/// <summary>
		/// Subscribes to the specified notification with the specified handler.
		/// </summary>
		/// <typeparam name="T">the handler type</typeparam>
		/// <param name="notification">the notification</param>
		/// <param name="action">the action</param>
		public void Subscribe<T>(string notification, Action<T> action) where T : class
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
				this.listeners[notification] = new List<IListener>();
			}

			this.listeners[notification].Add(new Listener<T>(action));
		}

		/// <summary>
		/// Unsubscribes the specified handler from the specified notification.
		/// </summary>
		/// <typeparam name="T">the handler type</typeparam>
		/// <param name="notification">the notification</param>
		/// <param name="action">the action</param>
		public void Unsubscribe<T>(string notification, Action<T> action) where T : class
		{
			if (notification == null)
			{
				throw new ArgumentNullException(nameof(notification));
			}

			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			if (this.listeners.ContainsKey(notification))
			{
				var listener = this.listeners[notification]
					.OfType<Listener<T>>()
					.FirstOrDefault(current => current.Action == action);

				if (listener != null)
				{
					this.listeners[notification].Remove(listener);
				}
			}
		}

		/// <summary>
		/// Unsubscribes all handlers from the specified notification.
		/// </summary>
		/// <param name="notification"></param>
		public void UnsubscribeAll(string notification)
		{
			if (notification == null)
			{
				throw new ArgumentNullException(nameof(notification));
			}

			if (this.listeners.ContainsKey(notification))
			{
				this.listeners[notification].Clear();
			}
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

		private Dictionary<string, List<IListener>> listeners;
	}
}
