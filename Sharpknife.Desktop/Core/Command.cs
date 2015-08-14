using Sharpknife.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sharpknife.Desktop.Core
{
	/// <summary>
	/// Represents an implementation of <see cref="ICommand" /> which can wrap a <see cref="Action" /> to act as a command.
	/// </summary>
	public class Command : ICommand
	{
		/// <summary>
		/// Creates a new <see cref="Command" /> to close the current window.
		/// </summary>
		/// <returns></returns>
		public static Command CreateClose()
		{
			return new Command(() => WindowService.Instance.CloseActive());
		}

		/// <summary>
		/// Creates a new <see cref="Command" /> to show an about dialog.
		/// </summary>
		/// <returns></returns>
		public static Command CreateAbout()
		{
			return new Command(() => DialogService.Instance.ShowAbout());
		}

		/// <summary>
		/// Creates a new command.
		/// </summary>
		/// <param name="action">the action</param>
		/// <param name="predicate">the predicate</param>
		public Command(Action action, Func<bool> predicate)
		{
			this.Action = action;
			this.Predicate = predicate;
		}

		/// <summary>
		/// Creates a new command.
		/// </summary>
		/// <param name="action">the action</param>
		public Command(Action action) : this(action, null)
		{

		}

		/// <summary>
		/// Executes the command with the specified parameter.
		/// <param name="parameter">the parameter</param>
		/// </summary>
		public void Execute(object parameter)
		{
			this.Action?.Invoke();
		}

		/// <summary>
		/// Returns if the command can execute with the specified parameter.
		/// </summary>
		/// <param name="parameter">the parameter</param>
		/// <returns>if the command can execute</returns>
		public bool CanExecute(object parameter)
		{
			return this.Predicate?.Invoke() ?? true;
		}

		/// <summary>
		/// Occurs when the can execute state changes.
		/// </summary>
		public event EventHandler CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
			}
		}

		/// <summary>
		/// Gets or sets the action.
		/// </summary>
		public Action Action
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the predicate.
		/// </summary>
		public Func<bool> Predicate
		{
			get;
			set;
		}
	}
}
