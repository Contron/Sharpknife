using Sharpknife.Desktop.Core;

namespace Sharpknife.Desktop.Models
{
	/// <summary>
	/// Represents the status of a window with a message and a busy status.
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
		/// Returns a string representation.
		/// </summary>
		/// <returns>the representation</returns>
		public override string ToString()
		{
			return $"Status (Message: {this.Message}, Busy: {this.Busy})";
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
			get => (string) this.Get();
			set => this.Set(value);
		}

		/// <summary>
		/// Gets or sets if the status is busy.
		/// </summary>
		public bool Busy
		{
			get => (bool) this.Get();
			set => this.Set(value);
		}
	}
}
