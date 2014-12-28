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
			this.MessagePanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// MessagePanel
			// 
			this.MessagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MessagePanel.BackColor = System.Drawing.SystemColors.Window;
			this.MessagePanel.Location = new System.Drawing.Point(0, 0);
			this.MessagePanel.Name = "MessagePanel";
			this.MessagePanel.Size = new System.Drawing.Size(340, 70);
			this.MessagePanel.TabIndex = 0;
			// 
			// BaseDialogForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.ClientSize = new System.Drawing.Size(334, 111);
			this.Controls.Add(this.MessagePanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BaseDialogForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Base Dialog Form";
			this.Load += new System.EventHandler(this.LoadHandler);
			this.ResumeLayout(false);

		}

		#endregion

		/// <summary>
		/// The message panel.
		/// </summary>
		public System.Windows.Forms.Panel MessagePanel;
	}
}
