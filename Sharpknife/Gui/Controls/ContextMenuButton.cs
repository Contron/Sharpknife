using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpknife.Gui.Controls
{
	/// <summary>
	/// Represents a context menu buttont that displays a <see cref="ContextMenu" /> when it is clicked.
	/// </summary>
	public class ContextMenuButton : Button
	{
		/// <summary>
		/// Creates a new context menu button.
		/// </summary>
		public ContextMenuButton()
		{
			this.ActionsContextMenuStrip = null;

			this.Click += this.ClickHandler;
		}

		/// <summary>
		/// Displays the context menu.
		/// </summary>
		private void DisplayMenu()
		{
			if (this.ActionsContextMenuStrip == null)
			{
				return;
			}

			//show
			this.ActionsContextMenuStrip.Show(this, 0, this.Height);
		}

		#region Event Handlers

		private void ClickHandler(object sender, EventArgs eventArgs)
		{
			this.DisplayMenu();
		}

		#endregion

		/// <summary>
		/// The context menu for the drop down button.
		/// </summary>
		[Category("Context Menu Button")]
		[Description("The context menu strip of actions that will be shown when the button is clicked.")]
		[DefaultValue(null)]
		public ContextMenuStrip ActionsContextMenuStrip
		{
			get;
			set;
		}
	}
}
