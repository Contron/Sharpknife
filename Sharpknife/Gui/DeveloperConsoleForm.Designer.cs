namespace Sharpknife.Gui
{
	partial class DeveloperConsoleForm
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
			this.outputTextBox = new System.Windows.Forms.TextBox();
			this.inputTextBox = new System.Windows.Forms.TextBox();
			this.executeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// outputTextBox
			// 
			this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.outputTextBox.Location = new System.Drawing.Point(10, 10);
			this.outputTextBox.Multiline = true;
			this.outputTextBox.Name = "outputTextBox";
			this.outputTextBox.ReadOnly = true;
			this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.outputTextBox.Size = new System.Drawing.Size(310, 210);
			this.outputTextBox.TabIndex = 0;
			this.outputTextBox.WordWrap = false;
			// 
			// inputTextBox
			// 
			this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.inputTextBox.Location = new System.Drawing.Point(10, 230);
			this.inputTextBox.Name = "inputTextBox";
			this.inputTextBox.Size = new System.Drawing.Size(230, 23);
			this.inputTextBox.TabIndex = 1;
			this.inputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterExecuteHandler);
			// 
			// executeButton
			// 
			this.executeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.executeButton.Location = new System.Drawing.Point(250, 230);
			this.executeButton.Name = "executeButton";
			this.executeButton.Size = new System.Drawing.Size(70, 23);
			this.executeButton.TabIndex = 2;
			this.executeButton.Text = "Execute";
			this.executeButton.UseVisualStyleBackColor = true;
			this.executeButton.Click += new System.EventHandler(this.ExecuteHandler);
			// 
			// DeveloperConsoleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.ClientSize = new System.Drawing.Size(334, 261);
			this.Controls.Add(this.executeButton);
			this.Controls.Add(this.inputTextBox);
			this.Controls.Add(this.outputTextBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(200, 200);
			this.Name = "DeveloperConsoleForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Developer Console";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox outputTextBox;
		private System.Windows.Forms.TextBox inputTextBox;
		private System.Windows.Forms.Button executeButton;
	}
}
