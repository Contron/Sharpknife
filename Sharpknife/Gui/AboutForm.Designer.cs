namespace Sharpknife.Gui
{
	partial class AboutForm
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
			this.nameLabel = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.copyrightLabel = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.iconPictureBox = new System.Windows.Forms.PictureBox();
			this.headerPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
			this.headerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// nameLabel
			// 
			this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nameLabel.Location = new System.Drawing.Point(100, 10);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(220, 20);
			this.nameLabel.TabIndex = 0;
			this.nameLabel.Text = "Name";
			// 
			// versionLabel
			// 
			this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.versionLabel.Location = new System.Drawing.Point(100, 50);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(220, 20);
			this.versionLabel.TabIndex = 1;
			this.versionLabel.Text = "Version";
			// 
			// copyrightLabel
			// 
			this.copyrightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.copyrightLabel.Location = new System.Drawing.Point(100, 70);
			this.copyrightLabel.Name = "copyrightLabel";
			this.copyrightLabel.Size = new System.Drawing.Size(220, 20);
			this.copyrightLabel.TabIndex = 2;
			this.copyrightLabel.Text = "Copyright";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(250, 110);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(70, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OKHandler);
			// 
			// iconPictureBox
			// 
			this.iconPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.iconPictureBox.Location = new System.Drawing.Point(10, 10);
			this.iconPictureBox.Name = "iconPictureBox";
			this.iconPictureBox.Size = new System.Drawing.Size(80, 80);
			this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.iconPictureBox.TabIndex = 4;
			this.iconPictureBox.TabStop = false;
			// 
			// headerPanel
			// 
			this.headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.headerPanel.BackColor = System.Drawing.SystemColors.Window;
			this.headerPanel.Controls.Add(this.iconPictureBox);
			this.headerPanel.Controls.Add(this.nameLabel);
			this.headerPanel.Controls.Add(this.copyrightLabel);
			this.headerPanel.Controls.Add(this.versionLabel);
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Size = new System.Drawing.Size(340, 100);
			this.headerPanel.TabIndex = 0;
			// 
			// AboutForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.ClientSize = new System.Drawing.Size(334, 141);
			this.Controls.Add(this.headerPanel);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "About";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClosedHandler);
			this.Load += new System.EventHandler(this.LoadHandler);
			((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
			this.headerPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.Label copyrightLabel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.PictureBox iconPictureBox;
		private System.Windows.Forms.Panel headerPanel;
	}
}
