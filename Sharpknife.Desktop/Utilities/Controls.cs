using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Sharpknife.Desktop.Utilities
{
	/// <summary>
	/// A collection of common control methods.
	/// </summary>
	public static class Controls
	{
		/// <summary>
		/// Return a <see cref="DependencyObject" /> of the specified type in the visual hierarchy.
		/// </summary>
		/// <typeparam name="T">the type</typeparam>
		/// <param name="root">the root object</param>
		/// <returns>the instance</returns>
		public static T Find<T>(DependencyObject root) where T : DependencyObject
		{
			if (root == null)
			{
				throw new ArgumentNullException(nameof(root));
			}

			if (root.GetType() == typeof(T))
			{
				return (T) root;
			}

			for (var index = 0; index < VisualTreeHelper.GetChildrenCount(root); index++)
			{
				var child = VisualTreeHelper.GetChild(root, index);

				if (child != null)
				{
					var instance = Controls.Find<T>(child);

					if (instance != null)
					{
						return instance;
					}
				}
			}

			return null;
		}
	}
}
