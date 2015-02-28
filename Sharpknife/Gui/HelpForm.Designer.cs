namespace Sharpknife.Gui
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
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.buttonsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// articlesTreeView
			// 
			this.articlesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.articlesTreeView.HideSelection = false;
			this.articlesTreeView.Location = new System.Drawing.Point(0, 0);
			this.articlesTreeView.Name = "articlesTreeView";
			this.articlesTreeView.Size = new System.Drawing.Size(150, 200);
			this.articlesTreeView.TabIndex = 0;
			this.articlesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SwapHelpHandler);
			// 
			// articleTextBox
			// 
			this.articleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.articleTextBox.Location = new System.Drawing.Point(0, 0);
			this.articleTextBox.Multiline = true;
			this.articleTextBox.Name = "articleTextBox";
			this.articleTextBox.ReadOnly = true;
			this.articleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.articleTextBox.Size = new System.Drawing.Size(300, 200);
			this.articleTextBox.TabIndex = 0;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(400, 10);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(70, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// buttonsPanel
			// 
			this.buttonsPanel.BackColor = System.Drawing.SystemColors.Window;
			this.buttonsPanel.Controls.Add(this.okButton);
			this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPanel.Location = new System.Drawing.Point(0, 220);
			this.buttonsPanel.Name = "buttonsPanel";
			this.buttonsPanel.Size = new System.Drawing.Size(484, 41);
			this.buttonsPanel.TabIndex = 1;
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer.Location = new System.Drawing.Point(10, 10);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.articlesTreeView);
			this.splitContainer.Panel1MinSize = 100;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.articleTextBox);
			this.splitContainer.Panel2MinSize = 200;
			this.splitContainer.Size = new System.Drawing.Size(460, 200);
			this.splitContainer.SplitterDistance = 150;
			this.splitContainer.SplitterWidth = 10;
			this.splitContainer.TabIndex = 0;
			this.splitContainer.TabStop = false;
			// 
			// HelpForm
			// 
			this.AcceptButton = this.okButton;
			this.ClientSize = new System.Drawing.Size(484, 261);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.buttonsPanel);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 200);
			this.Name = "HelpForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Help";
			this.buttonsPanel.ResumeLayout(false);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView articlesTreeView;
		private System.Windows.Forms.TextBox articleTextBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Panel buttonsPanel;
		private System.Windows.Forms.SplitContainer splitContainer;
	}
}
