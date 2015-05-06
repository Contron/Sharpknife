using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents an implementation of <see cref="ICommand" /> which can wrap a <see cref="Action" /> to act as a command.
	/// </summary>
	public class Command : ICommand
	{
		/// <summary>
		/// Creates a new command.
		/// </summary>
		/// <param name="command">the command</param>
		public Command(Action<object> command)
		{
			this.command = command;
		}

		/// <summary>
		/// Creates a new command.
		/// </summary>
		/// <param name="command">the command</param>
		public Command(Action command) : this(parameter => command.Invoke())
		{

		}

		/// <summary>
		/// Executes the command with the specified parameter.
		/// <param name="parameter">the parameter</param>
		/// </summary>
		public void Execute(object parameter)
		{
			if (this.command == null)
			{
				return;
			}

			this.command.Invoke(parameter);
		}

		/// <summary>
		/// Returns if the command can execute with the specified parameter.
		/// </summary>
		/// <param name="parameter">the parameter</param>
		/// <returns>if the command can execute</returns>
		public bool CanExecute(object parameter)
		{
			if (this.command == null)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Triggers the can execute changed event.
		/// </summary>
		protected void OnCanExecuteChanged()
		{
			if (this.CanExecuteChanged != null)
			{
				this.CanExecuteChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Occurs when the can execute state changes.
		/// </summary>
		public event EventHandler CanExecuteChanged;

		private Action<object> command;
	}
}
