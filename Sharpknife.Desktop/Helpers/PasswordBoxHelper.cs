using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Sharpknife.Desktop.Helpers
{
	public class PasswordBoxHelper
	{
		public bool GetAttached(DependencyObject instance)
		{
			return (bool) instance.GetValue(PasswordBoxHelper.AttachedProperty);
		}

		public static void SetAttached(DependencyObject instance, bool value)
		{
			instance.SetValue(PasswordBoxHelper.AttachedProperty, value);
		}

		public string GetPassword(DependencyObject instance)
		{
			return (string) instance.GetValue(PasswordBoxHelper.PasswordProperty);
		}

		public static void SetPassword(DependencyObject instance, string value)
		{
			instance.SetValue(PasswordBoxHelper.PasswordProperty, value);
		}

		private static void AttachedChanged(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			var passwordBox = instance as PasswordBox;

			if (passwordBox != null)
			{
				var value = args.NewValue as bool?;

				if (value != null)
				{
					if (value.Value)
					{
						passwordBox.PasswordChanged += PasswordBoxHelper.PasswordBoxPasswordChanged;
					}
					else
					{
						passwordBox.PasswordChanged -= PasswordBoxHelper.PasswordBoxPasswordChanged;
					}
				}
			}
		}

		private static void PasswordChanged(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			var passwordBox = instance as PasswordBox;

			if (passwordBox != null)
			{
				var value = args.NewValue as string;

				if (value != null)
				{
					passwordBox.Password = value;
				}
			}
		}

		private static void PasswordBoxPasswordChanged(object sender, RoutedEventArgs args)
		{
			var passwordBox = sender as PasswordBox;

			if (passwordBox != null)
			{
				PasswordBoxHelper.SetPassword(passwordBox, passwordBox.Password);
			}
		}

		public static readonly DependencyProperty AttachedProperty = DependencyProperty.RegisterAttached("Attached", typeof(bool), typeof(PasswordBoxHelper), new FrameworkPropertyMetadata(false, PasswordBoxHelper.AttachedChanged));
		public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxHelper), new FrameworkPropertyMetadata(string.Empty, PasswordBoxHelper.PasswordChanged));
	}
}
