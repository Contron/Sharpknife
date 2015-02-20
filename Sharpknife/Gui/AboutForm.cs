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
	/// Represents an about form that displays general information about the application.
	/// </summary>
	public partial class AboutForm : BaseForm
	{
		/// <summary>
		/// Shows a modal about form.
		/// </summary>
		/// <param name="owner">the owner</param>
		public static void Show(Form owner)
		{
			//show
			var aboutForm = new AboutForm();
			aboutForm.ShowDialog(owner);
		}

		/// <summary>
		/// Creates a new about form.
		/// </summary>
		public AboutForm()
		{
			this.icon = null;

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
			this.nameLabel.Text = versionInfo.ProductName;
			this.versionLabel.Text = string.Format("Version {0}", versionInfo.FileVersion);
			this.copyrightLabel.Text = string.Format("Copyright {0}", versionInfo.LegalCopyright);
		}

		/// <summary>
		/// Applies the icon of the owner to the image box.
		/// </summary>
		private void ApplyIcon()
		{
			if (this.Owner != null)
			{
				//get
				var icon = this.Owner.Icon;

				if (icon != null)
				{
					//apply
					this.icon = icon.ToBitmap();
					this.iconPictureBox.Image = this.icon;
				}
			}
		}
		
		/// <summary>
		/// Disposes of the icon.
		/// </summary>
		private void DisposeIcon()
		{
			if (this.icon != null)
			{
				//dispose
				this.icon.Dispose();
			}
		}

		#region Event Handlers

		private void LoadHandler(object sender, EventArgs eventArgs)
		{
			this.ApplyIcon();
		}

		private void ClosedHandler(object sender, FormClosedEventArgs eventArgs)
		{
			this.DisposeIcon();
		}

		#endregion

		private Bitmap icon;
	}
}
