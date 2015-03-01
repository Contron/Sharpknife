using Sharpknife.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Sharpknife.Gui.Controls
{
	/// <summary>
	/// Represents a vertical fill layout panel to layout controls vertically and with full width.
	/// </summary>
	public class VerticalFillLayoutPanel : Panel
	{
		/// <summary>
		/// Creates a new vertical fill layout panel.
		/// </summary>
		public VerticalFillLayoutPanel()
		{
			this.spacing = 10;
			this.layoutEngine = new VerticalFillLayoutEngine();
		}

		/// <summary>
		/// Scrolls to the specified control.
		/// </summary>
		/// <param name="activeControl">the active control</param>
		/// <returns>the point</returns>
		protected override Point ScrollToControl(Control activeControl)
		{
			return this.DisplayRectangle.Location;
		}

		/// <summary>
		/// Gets the layout engine for the panel.
		/// </summary>
		public override LayoutEngine LayoutEngine
		{
			get
			{
				return this.layoutEngine;
			}
		}

		/// <summary>
		/// Gets or sets the spacing for the panel.
		/// </summary>
		[Category("Children")]
		[Description("The spacing between controls within the panel.")]
		[DefaultValue(10)]
		public int Spacing
		{
			get
			{
				return this.spacing;
			}
			set
			{
				this.spacing = value;

				this.Refresh();
			}
		}

		private int spacing;

		private VerticalFillLayoutEngine layoutEngine;
	}
}
