using Sharpknife.Utilities;
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
	/// Represents a command link button, which are used to present various options to the user.
	/// </summary>
	public class CommandLink : Button
	{
		/// <summary>
		/// Creates a new command link.
		/// </summary>
		public CommandLink() : base()
		{
			this.shield = false;
			this.note = null;

			this.FlatStyle = FlatStyle.System;
		}

		/// <summary>
		/// If the shield is visible for the command link.
		/// </summary>
		[Category("Command Link")]
		[Description("If the shield is visible for the command link. A shield usually indicates an administrative action.")]
		[DefaultValue(false)]
		public bool Shield
		{
			get
			{
				return this.shield;
			}
			set
			{
				this.shield = value;

				Win32.SendMessage(this, Win32.Constants.BCM_SETSHIELD, this.shield = value);
			}
		}

		/// <summary>
		/// The note for the command link.
		/// </summary>
		[Category("Command Link")]
		[Description("The note text that is visible underneath the title of the command link.")]
		[DefaultValue("")]
		public string Note
		{
			get
			{
				return this.note;
			}
			set
			{
				this.note = value;

				Win32.SendMessage(this, Win32.Constants.BCM_SETNOTE, this.note);
			}
		}

		/// <summary>
		/// The default size of the command link.
		/// </summary>
		protected override Size DefaultSize
		{
			get
			{
				return new Size(180, 60);
			}
		}

		/// <summary>
		/// The creation parameters for the command link.
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				var createParams = base.CreateParams;
				createParams.Style |= Win32.Constants.BS_COMMANDLINK;

				return createParams;
			}
		}

		private bool shield;
		private string note;
	}
}
