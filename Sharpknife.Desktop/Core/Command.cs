using System;
using System.Windows.Input;
using Sharpknife.Desktop.Services;

namespace Sharpknife.Desktop.Core
{
	/// <summary>
	/// Represents an implementation of <see cref="ICommand" /> which can wrap a <see cref="Action" /> to act as a command.
	/// </summary>
	public class Command : ICommand
	{
		/// <summary>
		/// Creates a new command.
		/// </summary>
		/// <param name="action">the action</param>
		/// <param name="predicate">the predicate</param>
		public Command(Action action, Func<bool> predicate)
		{
			this.action = action;
			this.predicate = predicate;
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
		public void Execute(object parameter = null)
		{
			this.action?.Invoke();
		}

		/// <summary>
		/// Returns if the command can execute with the specified parameter.
		/// </summary>
		/// <param name="parameter">the parameter</param>
		/// <returns>if the command can execute</returns>
		public bool CanExecute(object parameter = null)
		{
			return this.predicate?.Invoke() ?? true;
		}

		/// <summary>
		/// Attempts to execute the command, only if <see cref="CanExecute(object)" /> returns <c>true</c>.
		/// <param name="parameter">the parameter</param>
		/// </summary>
		public void TryExecute(object parameter = null)
		{
			if (this.CanExecute(parameter))
			{
				this.Execute(parameter);
			}
		}

		/// <summary>
		/// Gets the command to close the active <see cref="System.Windows.Window" />.
		/// </summary>
		public static Command Close
		{
			get
			{
				return new Command(() => WindowService.Instance.CloseActive());
			}
		}

		/// <summary>
		/// Gets the command to display the <see cref="Sharpknife.Desktop.Views.AboutView" />.
		/// </summary>
		public static Command About
		{
			get
			{
				return new Command(() => DialogService.Instance.ShowAbout());
			}
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

		private Action action;
		private Func<bool> predicate;
	}
}
