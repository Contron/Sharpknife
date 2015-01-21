using Sharpknife.Gui.Bases;
using Sharpknife.Gui.Controls;
using Sharpknife.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sharpknife.Gui.Dialogs
{
	/// <summary>
	/// Represents a choice form which allows the user to select from a number of different choices.
	/// </summary>
	public partial class ChoiceForm : BaseDialogForm
	{
		/// <summary>
		/// Creates a new choice form.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="message">the message</param>
		public ChoiceForm(string title = "Select Option", string message = "Please select an option from below.") : base(title, message)
		{
			this.choices = 0;
			
			this.InitializeComponent();
		}

		/// <summary>
		/// Adds a new selectable choice.
		/// </summary>
		/// <param name="message">the message</param>
		/// <param name="action">the action</param>
		public void AddChoice(string message, Action action)
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}

			if (action == null)
			{
				throw new ArgumentNullException("action");
			}

			//context
			var height = 50;
			var gap = (this.choices > 0 ? 10 : 0);

			//positioning
			var location = new Point(0, (height * this.choices) + (gap * this.choices));
			var size = new Size(this.choicesPanel.Width, height);

			//button
			var button = new Button()
			{
				Text = message,
				Location = location,
				Size = size,
				Image = Resources.Action,
				ImageAlign = ContentAlignment.MiddleLeft,
				TextAlign = ContentAlignment.MiddleCenter,
				TextImageRelation = TextImageRelation.ImageBeforeText
			};
			button.Click += (sender, eventArgs) => this.InvokeAndClose(action);

			if (this.choices > 0)
			{
				//resize
				this.Height += (height + gap);
			}

			//add
			this.choicesPanel.Controls.Add(button);
			this.choices++;
		}

		/// <summary>
		/// Invokes the specified action after closing.
		/// </summary>
		/// <param name="action">the action</param>
		private void InvokeAndClose(Action action)
		{
			//close
			this.DialogResult = DialogResult.OK;
			this.Close();
			this.Dispose();

			//invoke
			action.Invoke();
		}

		#region Event Handlers

		private void CloseHandler(object sender, EventArgs eventArgs)
		{
			this.Close();
			this.Dispose();
		}

		#endregion

		private int choices;
	}
}
