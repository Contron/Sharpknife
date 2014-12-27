using Sharpknife.Gui.Bases;
using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Sharpknife.Gui
{
	/// <summary>
	/// Represents an about form.
	/// </summary>
	public partial class AboutForm : BaseForm
	{
		/// <summary>
		/// Creates a new about form.
		/// </summary>
		public AboutForm()
		{
			this.InitializeComponent();
			this.PopulateInformation();
		}

		/// <summary>
		/// Updates the information.
		/// </summary>
		private void PopulateInformation()
		{
			//version info
			var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

			//labels
			this.nameLabel.Text = Assemblies.GetAssemblyAttribute<AssemblyTitleAttribute>(assembly => assembly.Title);
			this.versionLabel.Text = string.Format("Version {0}", versionInfo.FileVersion);
			this.copyrightLabel.Text = versionInfo.LegalCopyright;
		}

		/// <summary>
		/// Applies the owner form's icon.
		/// </summary>
		private void ApplyIcon()
		{
			if (this.Owner != null)
			{
				var icon = this.Owner.Icon;

				if (icon != null)
				{
					//apply
					this.iconPictureBox.Image = icon.ToBitmap();
				}
			}
		}

		#region Event Handlers

		private void OKHandler(object sender, EventArgs eventArgs)
		{
			this.Close();
		}

		private void LoadHandler(object sender, EventArgs eventArgs)
		{
			this.ApplyIcon();
		}

		#endregion
	}
}
