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
			this.Message = "Ready";
			this.Busy = false;
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

				this.OnPropertyChanged("Visibility");
				this.OnPropertyChanged("Enabled");
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
