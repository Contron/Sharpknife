using Sharpknife.Gui.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Sharpknife.Common
{
	/// <summary>
	/// Represents a vertical fill layout engine.
	/// </summary>
	public class VerticalFillLayoutEngine : LayoutEngine
	{
		/// <summary>
		/// Lays out the controls on the specified container.
		/// </summary>
		/// <param name="container">the container</param>
		/// <param name="eventArgs">the event args</param>
		/// <returns>the result</returns>
		public override bool Layout(object container, LayoutEventArgs eventArgs)
		{
			if (container is VerticalFillLayoutPanel)
			{
				//cast
				var panel = (VerticalFillLayoutPanel) container;
				var rectangle = panel.DisplayRectangle;
				var position = rectangle.Location;

				foreach (Control control in panel.Controls)
				{
					if (!control.Visible)
					{
						continue;
					}

					//apply
					control.Location = position;
					control.Size = new Size(rectangle.Width, control.Height);

					//move
					position.Offset(0, control.Height + panel.Spacing);
				}
			}

			return true;
		}
	}
}
