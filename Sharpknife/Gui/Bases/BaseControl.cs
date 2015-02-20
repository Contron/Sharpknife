using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sharpknife.Extensions;

namespace Sharpknife.Gui.Bases
{
	/// <summary>
	/// Represents a base control.
	/// </summary>
	public partial class BaseControl : UserControl
	{
		/// <summary>
		/// Creates a new base control.
		/// </summary>
		public BaseControl()
		{
			this.InitializeComponent();
			this.NativeStyling();
		}
	}
}
