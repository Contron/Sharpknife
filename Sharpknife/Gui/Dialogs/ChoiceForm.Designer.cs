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
			this.buttonsPanel = new System.Windows.Forms.Panel();
			this.cancelButton = new System.Windows.Forms.Button();
			this.buttonsPanel.SuspendLayout();
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
			// buttonsPanel
			// 
			this.buttonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonsPanel.BackColor = System.Drawing.SystemColors.Window;
			this.buttonsPanel.Controls.Add(this.cancelButton);
			this.buttonsPanel.Location = new System.Drawing.Point(0, 140);
			this.buttonsPanel.Name = "buttonsPanel";
			this.buttonsPanel.Size = new System.Drawing.Size(340, 50);
			this.buttonsPanel.TabIndex = 2;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(250, 10);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(70, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CloseHandler);
			// 
			// ChoiceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(334, 181);
			this.ControlBox = false;
			this.Controls.Add(this.buttonsPanel);
			this.Controls.Add(this.choicesPanel);
			this.Name = "ChoiceForm";
			this.Controls.SetChildIndex(this.choicesPanel, 0);
			this.Controls.SetChildIndex(this.buttonsPanel, 0);
			this.buttonsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel choicesPanel;
		private System.Windows.Forms.Panel buttonsPanel;
		private System.Windows.Forms.Button cancelButton;
	}
}
