using Sharpknife.Core;
using Sharpknife.Gui.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sharpknife.Gui
{
	/// <summary>
	/// Represents a developer console form to provide developer-specific features.
	/// </summary>
	public partial class DeveloperConsoleForm : BaseForm
	{
		/// <summary>
		/// Shows a developer console form.
		/// </summary>
		/// <param name="owner">the owner</param>
		public static void Hook(Form owner)
		{
			//show
			var developerConsoleForm = new DeveloperConsoleForm();
			developerConsoleForm.Show(owner);
		}

		/// <summary>
		/// Creates a new developer console form.
		/// </summary>
		public DeveloperConsoleForm()
		{
			this.console = new InteractiveConsole();

			this.InitializeComponent();
			this.InitialiseConsole();
			this.AppendHeader();
		}

		/// <summary>
		/// Appends a log message.
		/// </summary>
		/// <param name="message">the message</param>
		private void AppendLog(string message)
		{
			if (this.outputTextBox.Text.Length > 0)
			{
				//new line
				message = (Environment.NewLine + message);
			}

			//append
			this.outputTextBox.AppendText(message);
		}

		/// <summary>
		/// Initialises the console.
		/// </summary>
		private void InitialiseConsole()
		{
			//fonts
			this.outputTextBox.Font = new Font(FontFamily.GenericMonospace, 9);
			this.inputTextBox.Font = new Font(FontFamily.GenericMonospace, 9);
		}

		/// <summary>
		/// Appends the header.
		/// </summary>
		private void AppendHeader()
		{
			//header
			this.AppendLog("Developer console initialised.");
		}

		/// <summary>
		/// Executes the current input.
		/// </summary>
		private void ExecuteInput()
		{
			//get
			var command = this.inputTextBox.Text.Trim();

			if (string.IsNullOrWhiteSpace(command))
			{
				return;
			}

			//execute
			var result = this.console.Execute(command);

			//post
			this.AppendLog("> " + command);
			this.AppendLog(result);

			//clear
			this.inputTextBox.Text = string.Empty;
		}

		#region Event Handlers

		private void EnterExecuteHandler(object sender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == Keys.Enter)
			{
				this.ExecuteInput();

				//silence
				eventArgs.Handled = true;
				eventArgs.SuppressKeyPress = true;
			}
		}

		private void ExecuteHandler(object sender, EventArgs eventArgs)
		{
			this.ExecuteInput();
		}

		#endregion

		private InteractiveConsole console;
	}
}
