using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace Sharpknife.Desktop.Views.Controls
{
	/// <summary>
	/// Represents a button that can have a <see cref="ContextMenu" /> attached to it when clicked.
	/// </summary>
	[ContentProperty("DisplayMenu")]
	public class MenuButton : Button
	{
		/// <summary>
		/// Creates a new menu button.
		/// </summary>
		public MenuButton()
		{
			this.DisplayMenu = null;
		}

		/// <summary>
		/// Triggers the click event.
		/// </summary>
		protected override void OnClick()
		{
			base.OnClick();

			if (this.DisplayMenu == null)
			{
				return;
			}

			if (!this.DisplayMenu.IsOpen)
			{
				this.DisplayMenu.PlacementTarget = this;
				this.DisplayMenu.Placement = PlacementMode.Bottom;

				this.DisplayMenu.IsOpen = true;
			}
		}

		/// <summary>
		/// Gets the display menu property.
		/// </summary>
		public static readonly DependencyProperty DisplayMenuProperty = DependencyProperty.Register("DisplayMenu", typeof(ContextMenu), typeof(MenuButton));

		/// <summary>
		/// Gets or sets the display menu.
		/// </summary>
		public ContextMenu DisplayMenu
		{
			get => (ContextMenu) this.GetValue(MenuButton.DisplayMenuProperty);
			set => this.SetValue(MenuButton.DisplayMenuProperty, value);
		}
	}
}
