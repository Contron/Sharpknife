﻿using System;
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
		/// <param name="predicate">the predicate</param>
		public Command(Action<object> command, Func<object, bool> predicate)
		{
			this.command = command;
			this.predicate = predicate;
		}

		/// <summary>
		/// Creates a new command.
		/// </summary>
		/// <param name="command">the command</param>
		public Command(Action<object> command) : this(command, parameter => true)
		{

		}

		/// <summary>
		/// Executes the command with the specified parameter.
		/// </summary>
		/// <param name="parameter">the parameter</param>
		public void Execute(object parameter)
		{
			if (this.command == null)
			{
				return;
			}

			this.command(parameter);
		}

		/// <summary>
		/// Returns if the command can execute with the specified parameter.
		/// </summary>
		/// <param name="parameter">the parameter</param>
		/// <returns>if the command can execute</returns>
		public bool CanExecute(object parameter)
		{
			if (this.predicate == null)
			{
				return false;
			}

			return this.predicate(parameter);
		}

		#region Event Triggers

		private void OnCanExecuteChanged()
		{
			if (this.CanExecuteChanged != null)
			{
				this.CanExecuteChanged(this, EventArgs.Empty);
			}
		}

		#endregion

		/// <summary>
		/// Occurs when the can execute status changes.
		/// </summary>
		public event EventHandler CanExecuteChanged;

		private Action<object> command;
		private Func<object, bool> predicate;
	}
}
