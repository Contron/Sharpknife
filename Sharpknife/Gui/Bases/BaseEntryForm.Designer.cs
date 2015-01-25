namespace Sharpknife.Gui.Bases
{
	partial class BaseEntryForm
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
			this.ButtonsPanel = new System.Windows.Forms.Panel();
			this.AbortButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.ButtonsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPanel
			// 
			this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonsPanel.BackColor = System.Drawing.SystemColors.Window;
			this.ButtonsPanel.Controls.Add(this.AbortButton);
			this.ButtonsPanel.Controls.Add(this.OKButton);
			this.ButtonsPanel.Location = new System.Drawing.Point(0, 220);
			this.ButtonsPanel.Name = "ButtonsPanel";
			this.ButtonsPanel.Size = new System.Drawing.Size(340, 50);
			this.ButtonsPanel.TabIndex = 0;
			// 
			// AbortButton
			// 
			this.AbortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.AbortButton.Location = new System.Drawing.Point(250, 10);
			this.AbortButton.Name = "AbortButton";
			this.AbortButton.Size = new System.Drawing.Size(70, 23);
			this.AbortButton.TabIndex = 1;
			this.AbortButton.Text = "Cancel";
			this.AbortButton.UseVisualStyleBackColor = true;
			this.AbortButton.Click += new System.EventHandler(this.CancelHandler);
			// 
			// OKButton
			// 
			this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKButton.Location = new System.Drawing.Point(170, 10);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(70, 23);
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKHandler);
			// 
			// BaseEntryForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.CancelButton = this.AbortButton;
			this.ClientSize = new System.Drawing.Size(334, 261);
			this.Controls.Add(this.ButtonsPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BaseEntryForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Base Entry Form";
			this.Load += new System.EventHandler(this.LoadHandler);
			this.ButtonsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		/// <summary>
		/// The buttons panel for the form.
		/// </summary>
		protected System.Windows.Forms.Panel ButtonsPanel;

		/// <summary>
		/// The Cancel button for the form.
		/// </summary>
		protected System.Windows.Forms.Button AbortButton;

		/// <summary>
		/// The OK button for the form.
		/// </summary>
		protected System.Windows.Forms.Button OKButton;
	}
}
