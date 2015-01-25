namespace Sharpknife.Gui.Bases
{
	partial class BaseSettingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.TabControl = new System.Windows.Forms.TabControl();
			this.ButtonsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabControl
			// 
			this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabControl.Location = new System.Drawing.Point(10, 10);
			this.TabControl.Name = "TabControl";
			this.TabControl.SelectedIndex = 0;
			this.TabControl.Size = new System.Drawing.Size(310, 200);
			this.TabControl.TabIndex = 1;
			// 
			// BaseSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.ClientSize = new System.Drawing.Size(334, 261);
			this.Controls.Add(this.TabControl);
			this.Name = "BaseSettingsForm";
			this.Text = "Base Settings Form";
			this.Controls.SetChildIndex(this.ButtonsPanel, 0);
			this.Controls.SetChildIndex(this.TabControl, 0);
			this.ButtonsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		/// <summary>
		/// The tab control for the form.
		/// </summary>
		protected System.Windows.Forms.TabControl TabControl;
	}
}
