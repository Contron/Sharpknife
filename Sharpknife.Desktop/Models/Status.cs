using Sharpknife.Desktop.Core;

namespace Sharpknife.Desktop.Models
{
	/// <summary>
	/// Represents the status of a window with a message and a busy status.
	/// </summary>
	public sealed class Status : Observable
	{
		/// <summary>
		/// Creates a new status.
		/// </summary>
		public Status()
		{
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
		/// Returns a string representation.
		/// </summary>
		/// <returns>the representation</returns>
		public override string ToString()
		{
			return $"Status (Message: {this.Message}, Busy: {this.Busy})";
		}

		/// <summary>
		/// Gets the message.
		/// </summary>
		public string Message
		{
			get => this.message;
			set => this.Set(ref this.message, value);
		}

		/// <summary>
		/// Gets the busy status.
		/// </summary>
		public bool Busy
		{
			get => this.busy;
			set => this.Set(ref this.busy, value);
		}

		private string message = null;
		private bool busy = false;
	}
}
