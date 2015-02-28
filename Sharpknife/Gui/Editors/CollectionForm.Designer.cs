namespace Sharpknife.Gui.Editors
{
	partial class CollectionForm<T>
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
			this.addButton = new System.Windows.Forms.Button();
			this.editButton = new System.Windows.Forms.Button();
			this.removeButton = new System.Windows.Forms.Button();
			this.clearButton = new System.Windows.Forms.Button();
			this.listBox = new System.Windows.Forms.ListBox();
			this.buttonsPanel = new System.Windows.Forms.Panel();
			this.okButton = new System.Windows.Forms.Button();
			this.buttonsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addButton.Image = global::Sharpknife.Properties.Resources.Add;
			this.addButton.Location = new System.Drawing.Point(340, 10);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(30, 30);
			this.addButton.TabIndex = 1;
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.AddClickedHandler);
			// 
			// editButton
			// 
			this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.editButton.Image = global::Sharpknife.Properties.Resources.Edit;
			this.editButton.Location = new System.Drawing.Point(340, 50);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(30, 30);
			this.editButton.TabIndex = 2;
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.EditClickedHandler);
			// 
			// removeButton
			// 
			this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.removeButton.Image = global::Sharpknife.Properties.Resources.Remove;
			this.removeButton.Location = new System.Drawing.Point(340, 90);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(30, 30);
			this.removeButton.TabIndex = 3;
			this.removeButton.UseVisualStyleBackColor = true;
			this.removeButton.Click += new System.EventHandler(this.RemoveClickedHandler);
			// 
			// clearButton
			// 
			this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.clearButton.Image = global::Sharpknife.Properties.Resources.Clear;
			this.clearButton.Location = new System.Drawing.Point(340, 180);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(30, 30);
			this.clearButton.TabIndex = 4;
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.ClearClickedHandler);
			// 
			// listBox
			// 
			this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox.FormattingEnabled = true;
			this.listBox.IntegralHeight = false;
			this.listBox.ItemHeight = 15;
			this.listBox.Location = new System.Drawing.Point(10, 10);
			this.listBox.Name = "listBox";
			this.listBox.ScrollAlwaysVisible = true;
			this.listBox.Size = new System.Drawing.Size(320, 200);
			this.listBox.TabIndex = 0;
			// 
			// buttonsPanel
			// 
			this.buttonsPanel.BackColor = System.Drawing.SystemColors.Window;
			this.buttonsPanel.Controls.Add(this.okButton);
			this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPanel.Location = new System.Drawing.Point(0, 220);
			this.buttonsPanel.Name = "buttonsPanel";
			this.buttonsPanel.Size = new System.Drawing.Size(384, 41);
			this.buttonsPanel.TabIndex = 5;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(300, 10);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(70, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// CollectionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 261);
			this.Controls.Add(this.buttonsPanel);
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.clearButton);
			this.Controls.Add(this.removeButton);
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.addButton);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(250, 250);
			this.Name = "CollectionForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Collection Form";
			this.buttonsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.ListBox listBox;
		private System.Windows.Forms.Panel buttonsPanel;
		private System.Windows.Forms.Button okButton;
	}
}