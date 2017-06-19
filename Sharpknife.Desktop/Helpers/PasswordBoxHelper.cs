using System.Windows;
using System.Windows.Controls;

namespace Sharpknife.Desktop.Helpers
{
	/// <summary>
	/// Represents an attached helper to provide the ability to bind to a <see cref="PasswordBox" />'s <see cref="PasswordBox.Password" /> property.
	/// </summary>
	public class PasswordBoxHelper
	{
		/// <summary>
		/// Returns if the helper is attached to the specified instance.
		/// </summary>
		/// <param name="instance"></param>
		/// <returns>the result</returns>
		public bool GetAttached(DependencyObject instance)
		{
			return (bool) instance.GetValue(PasswordBoxHelper.AttachedProperty);
		}

		/// <summary>
		/// Sets if the helper is attached to the specified instance.
		/// </summary>
		/// <param name="instance">the instance</param>
		/// <param name="value">the value</param>
		public static void SetAttached(DependencyObject instance, bool value)
		{
			instance.SetValue(PasswordBoxHelper.AttachedProperty, value);
		}

		/// <summary>
		/// Gets the password of the specified instance.
		/// </summary>
		/// <param name="instance">the instance</param>
		/// <returns>the password</returns>
		public string GetPassword(DependencyObject instance)
		{
			return (string) instance.GetValue(PasswordBoxHelper.PasswordProperty);
		}

		/// <summary>
		/// Sets the password of the specified instance to the specified value.
		/// </summary>
		/// <param name="instance">the instance</param>
		/// <param name="value">the value</param>
		public static void SetPassword(DependencyObject instance, string value)
		{
			instance.SetValue(PasswordBoxHelper.PasswordProperty, value);
		}

		private static void AttachedChanged(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			var password = instance as PasswordBox;

			if (password != null)
			{
				var value = args.NewValue as bool?;

				if (value != null)
				{
					if (value.Value)
					{
						password.PasswordChanged += PasswordBoxHelper.PasswordBoxPasswordChanged;
					}
					else
					{
						password.PasswordChanged -= PasswordBoxHelper.PasswordBoxPasswordChanged;
					}
				}
			}
		}

		private static void PasswordChanged(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			var password = instance as PasswordBox;

			if (password != null)
			{
				var value = args.NewValue as string;

				if (value != null)
				{
					password.Password = value;
				}
			}
		}

		private static void PasswordBoxPasswordChanged(object sender, RoutedEventArgs args)
		{
			var password = sender as PasswordBox;

			if (password != null)
			{
				PasswordBoxHelper.SetPassword(password, password.Password);
			}
		}

		/// <summary>
		/// Gets the attached property.
		/// </summary>
		public static readonly DependencyProperty AttachedProperty = DependencyProperty.RegisterAttached("Attached", typeof(bool), typeof(PasswordBoxHelper), new FrameworkPropertyMetadata(false, PasswordBoxHelper.AttachedChanged));

		/// <summary>
		/// Gets the password property.
		/// </summary>
		public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxHelper), new FrameworkPropertyMetadata(string.Empty, PasswordBoxHelper.PasswordChanged));
	}
}
