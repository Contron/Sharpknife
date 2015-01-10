namespace Sharpknife.Gui.Bases
{
	partial class BaseDialogForm
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
			this.messagePanel = new System.Windows.Forms.Panel();
			this.messageLabel = new System.Windows.Forms.Label();
			this.messagePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// messagePanel
			// 
			this.messagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messagePanel.BackColor = System.Drawing.SystemColors.Window;
			this.messagePanel.Controls.Add(this.messageLabel);
			this.messagePanel.Location = new System.Drawing.Point(0, 0);
			this.messagePanel.Name = "messagePanel";
			this.messagePanel.Size = new System.Drawing.Size(340, 70);
			this.messagePanel.TabIndex = 0;
			// 
			// messageLabel
			// 
			this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messageLabel.Location = new System.Drawing.Point(10, 10);
			this.messageLabel.Name = "messageLabel";
			this.messageLabel.Size = new System.Drawing.Size(310, 50);
			this.messageLabel.TabIndex = 0;
			this.messageLabel.Text = "Message";
			this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BaseDialogForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.ClientSize = new System.Drawing.Size(334, 111);
			this.Controls.Add(this.messagePanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BaseDialogForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Base Dialog Form";
			this.Load += new System.EventHandler(this.LoadHandler);
			this.messagePanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel messagePanel;
		private System.Windows.Forms.Label messageLabel;

	}
}
