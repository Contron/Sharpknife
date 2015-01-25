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
			this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.buttonsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonsPanel
			// 
			this.buttonsPanel.BackColor = System.Drawing.SystemColors.Window;
			this.buttonsPanel.Controls.Add(this.cancelButton);
			this.buttonsPanel.Controls.Add(this.okButton);
			this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonsPanel.Location = new System.Drawing.Point(0, 220);
			this.buttonsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonsPanel.Name = "buttonsPanel";
			this.buttonsPanel.Size = new System.Drawing.Size(334, 41);
			this.buttonsPanel.TabIndex = 0;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(249, 10);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(10);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelHandler);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(164, 10);
			this.okButton.Margin = new System.Windows.Forms.Padding(10, 10, 0, 10);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OKHandler);
			// 
			// BaseEntryForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(334, 261);
			this.Controls.Add(this.buttonsPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BaseEntryForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Base Entry Form";
			this.Load += new System.EventHandler(this.LoadHandler);
			this.buttonsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;


	}
}
