using Sharpknife.Desktop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sharpknife.Desktop.Models
{
	/// <summary>
	/// Represents the status of a window with a message, and a busy indicator.
	/// </summary>
	public class Status : Observable
	{
		/// <summary>
		/// Creates a new status.
		/// </summary>
		public Status()
		{
			this.Message = null;
			this.Busy = false;

			this.Reset();
		}

		/// <summary>
		/// Updates the status with the specified message and busy state.
		/// </summary>
		/// <param name="message">the message</param>
		/// <param name="busy">the busy state</param>
		public void Update(string message, bool busy = false)
		{
			this.Message = message;
			this.Busy = busy;
		}

		/// <summary>
		/// Resets the status.
		/// </summary>
		public void Reset()
		{
			this.Update("Ready");
		}

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		public string Message
		{
			get
			{
				return (string) this.Get();
			}
			set
			{
				this.Set(value);
			}
		}

		/// <summary>
		/// Gets or sets if the status is busy.
		/// </summary>
		public bool Busy
		{
			get
			{
				return (bool) this.Get();
			}
			set
			{
				this.Set(value);

				this.Notify("Visibility");
				this.Notify("Enabled");
			}
		}

		/// <summary>
		/// Gets the visibility of controls.
		/// </summary>
		public Visibility Visibility
		{
			get
			{
				return this.Busy ? Visibility.Visible : Visibility.Collapsed;
			}
		}

		/// <summary>
		/// Gets if the controls are enabled.
		/// </summary>
		public bool Enabled
		{
			get
			{
				return !this.Busy;
			}
		}
	}
}
