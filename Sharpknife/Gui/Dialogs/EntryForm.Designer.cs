namespace Sharpknife.Gui.Dialogs
{
	partial class EntryForm
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
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.buttonsPanel = new System.Windows.Forms.Panel();
			this.okButton = new System.Windows.Forms.Button();
			this.contentPanel = new System.Windows.Forms.Panel();
			this.buttonsPanel.SuspendLayout();
			this.contentPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// propertyGrid
			// 
			this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
			this.propertyGrid.Size = new System.Drawing.Size(308, 298);
			this.propertyGrid.TabIndex = 0;
			// 
			// buttonsPanel
			// 
			this.buttonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonsPanel.BackColor = System.Drawing.SystemColors.Window;
			this.buttonsPanel.Controls.Add(this.okButton);
			this.buttonsPanel.Location = new System.Drawing.Point(0, 320);
			this.buttonsPanel.Name = "buttonsPanel";
			this.buttonsPanel.Size = new System.Drawing.Size(340, 50);
			this.buttonsPanel.TabIndex = 1;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(250, 10);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(70, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OKHandler);
			// 
			// contentPanel
			// 
			this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.contentPanel.Controls.Add(this.propertyGrid);
			this.contentPanel.Location = new System.Drawing.Point(10, 10);
			this.contentPanel.Name = "contentPanel";
			this.contentPanel.Size = new System.Drawing.Size(310, 300);
			this.contentPanel.TabIndex = 0;
			// 
			// EntryForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.ClientSize = new System.Drawing.Size(334, 361);
			this.Controls.Add(this.buttonsPanel);
			this.Controls.Add(this.contentPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EntryForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Entry Form";
			this.buttonsPanel.ResumeLayout(false);
			this.contentPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel buttonsPanel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private System.Windows.Forms.Panel contentPanel;
	}
}
