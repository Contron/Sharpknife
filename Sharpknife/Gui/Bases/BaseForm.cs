using Sharpknife.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpknife.Gui.Bases
{
	/// <summary>
	/// Represents a base form.
	/// </summary>
	public partial class BaseForm : Form
	{
		/// <summary>
		/// Creates a new base form.
		/// </summary>
		public BaseForm()
		{
			this.InitializeComponent();
			this.NativeStyling();
		}

		/// <summary>
		/// Applies the parent icon.
		/// </summary>
		private void ApplyParentIcon()
		{
			if (this.Owner != null)
			{
				//icon
				this.Icon = this.Owner.Icon;
			}
		}

		#region Event Handlers

		private void LoadHandler(object sender, EventArgs eventArgs)
		{
			this.ApplyParentIcon();
		}

		#endregion
	}
}
