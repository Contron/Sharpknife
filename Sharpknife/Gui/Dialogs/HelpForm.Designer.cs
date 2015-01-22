namespace Sharpknife.Gui.Dialogs
{
	partial class HelpForm
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
			this.articlesTreeView = new System.Windows.Forms.TreeView();
			this.articleTextBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.buttonsPanel = new System.Windows.Forms.Panel();
			this.buttonsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// articlesTreeView
			// 
			this.articlesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.articlesTreeView.HideSelection = false;
			this.articlesTreeView.Location = new System.Drawing.Point(10, 10);
			this.articlesTreeView.Name = "articlesTreeView";
			this.articlesTreeView.Size = new System.Drawing.Size(150, 200);
			this.articlesTreeView.TabIndex = 0;
			this.articlesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SwapHelpHandler);
			// 
			// articleTextBox
			// 
			this.articleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.articleTextBox.Location = new System.Drawing.Point(170, 10);
			this.articleTextBox.Multiline = true;
			this.articleTextBox.Name = "articleTextBox";
			this.articleTextBox.ReadOnly = true;
			this.articleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.articleTextBox.Size = new System.Drawing.Size(300, 200);
			this.articleTextBox.TabIndex = 1;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(400, 10);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(70, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OKHandler);
			// 
			// buttonsPanel
			// 
			this.buttonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonsPanel.BackColor = System.Drawing.SystemColors.Window;
			this.buttonsPanel.Controls.Add(this.okButton);
			this.buttonsPanel.Location = new System.Drawing.Point(0, 220);
			this.buttonsPanel.Name = "buttonsPanel";
			this.buttonsPanel.Size = new System.Drawing.Size(490, 50);
			this.buttonsPanel.TabIndex = 2;
			// 
			// HelpForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.ClientSize = new System.Drawing.Size(484, 261);
			this.Controls.Add(this.buttonsPanel);
			this.Controls.Add(this.articleTextBox);
			this.Controls.Add(this.articlesTreeView);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 200);
			this.Name = "HelpForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Help";
			this.buttonsPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView articlesTreeView;
		private System.Windows.Forms.TextBox articleTextBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Panel buttonsPanel;

	}
}
