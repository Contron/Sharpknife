namespace Sharpknife.Gui.Dialogs
{
	partial class ChoiceForm
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
			this.choicesPanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// choicesPanel
			// 
			this.choicesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.choicesPanel.Location = new System.Drawing.Point(10, 80);
			this.choicesPanel.Name = "choicesPanel";
			this.choicesPanel.Size = new System.Drawing.Size(310, 50);
			this.choicesPanel.TabIndex = 1;
			// 
			// ChoiceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.ClientSize = new System.Drawing.Size(334, 141);
			this.Controls.Add(this.choicesPanel);
			this.Name = "ChoiceForm";
			this.Controls.SetChildIndex(this.choicesPanel, 0);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel choicesPanel;
	}
}
