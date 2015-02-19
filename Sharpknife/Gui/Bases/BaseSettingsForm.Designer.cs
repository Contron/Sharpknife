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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.buttonsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonsPanel
			// 
			this.buttonsPanel.Size = new System.Drawing.Size(490, 50);
			this.buttonsPanel.TabIndex = 1;
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(400, 10);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(320, 10);
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Location = new System.Drawing.Point(10, 10);
			this.tabControl.Multiline = true;
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(460, 200);
			this.tabControl.TabIndex = 0;
			// 
			// BaseSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.ClientSize = new System.Drawing.Size(484, 261);
			this.Controls.Add(this.tabControl);
			this.Name = "BaseSettingsForm";
			this.Text = "Settings";
			this.Controls.SetChildIndex(this.buttonsPanel, 0);
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.buttonsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		#pragma warning disable 1591

		protected System.Windows.Forms.TabControl tabControl;

		#pragma warning restore 1591
	}
}
