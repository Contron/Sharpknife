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
	public class Command : Observable, ICommand
	{
		/// <summary>
		/// Creates a new command.
		/// </summary>
		/// <param name="action">the action</param>
		/// <param name="predicate">the predicate</param>
		/// <param name="gesture">the gesture</param>
		public Command(Action<object> action, Func<bool> predicate = null, KeyGesture gesture = null)
		{
			this.Action = action;
			this.Predicate = predicate;

			this.Gesture = gesture;
		}

		/// <summary>
		/// Creates a new command.
		/// </summary>
		/// <param name="action">the action</param>
		/// <param name="predicate">the predicate</param>
		/// <param name="gesture">the gesture</param>
		public Command(Action action, Func<bool> predicate = null, KeyGesture gesture = null) : this(parameter => action.Invoke(), predicate, gesture)
		{

		}

		/// <summary>
		/// Executes the command with the specified parameter.
		/// <param name="parameter">the parameter</param>
		/// </summary>
		public void Execute(object parameter)
		{
			if (this.Action != null)
			{
				this.Action.Invoke(parameter);
			}
		}

		/// <summary>
		/// Returns if the command can execute with the specified parameter.
		/// </summary>
		/// <param name="parameter">the parameter</param>
		/// <returns>if the command can execute</returns>
		public bool CanExecute(object parameter)
		{
			if (this.Predicate != null)
			{
				return this.Predicate();
			}

			return this.Action != null;
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
		public Action<object> Action
		{
			get
			{
				return (Action<object>) this.Get();
			}
			set
			{
				this.Set(value);
			}
		}

		/// <summary>
		/// Gets or sets the predicate.
		/// </summary>
		public Func<bool> Predicate
		{
			get
			{
				return (Func<bool>) this.Get();
			}
			set
			{
				this.Set(value);
			}
		}

		/// <summary>
		/// Gets or sets the gesture.
		/// </summary>
		public KeyGesture Gesture
		{
			get
			{
				return (KeyGesture) this.Get();
			}
			set
			{
				this.Set(value);

				this.OnPropertyChanged("GestureText");
			}
		}

		/// <summary>
		/// Gets the shortcut text.
		/// </summary>
		public string Shortcut
		{
			get
			{
				if (this.Gesture != null)
				{
					return this.Gesture.GetDisplayStringForCulture(CultureInfo.CurrentUICulture);
				}
				else
				{
					return null;
				}
			}
		}
	}
}
