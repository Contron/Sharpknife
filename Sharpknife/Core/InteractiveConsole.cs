using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents an interactive console that can have commands registered and issued to it.
	/// </summary>
	public class InteractiveConsole
	{
		/// <summary>
		/// Creates a new interactive console.
		/// </summary>
		public InteractiveConsole()
		{
			this.Commands = new Dictionary<string, Command>();

			this.AddDefaultCommands();
		}

		/// <summary>
		/// Executes the specified command.
		/// </summary>
		/// <param name="command">the command</param>
		/// <returns>the output</returns>
		public string Execute(string command)
		{
			if (!this.Commands.ContainsKey(command))
			{
				return "Unknown command.";
			}

			//execute
			var function = this.Commands[command];
			var result = function.Invoke();

			return result;
		}

		/// <summary>
		/// Adds the default commands.
		/// </summary>
		private void AddDefaultCommands()
		{
			this.Commands["help"] = this.Help;
			this.Commands["exit"] = this.Exit;
			this.Commands["version"] = this.Version;
			this.Commands["memory"] = this.MemoryUsage;
		}

		#region Default Commands

		private string Help()
		{
			//result
			var result = new StringBuilder();

			foreach (var command in this.Commands.Keys)
			{
				//append
				result.AppendLine(command);
			}

			return result.ToString().TrimEnd(Environment.NewLine.ToArray());
		}

		private string Exit()
		{
			//exit
			Environment.Exit(0);

			return "Exited successfully.";
		}

		private string Version()
		{
			//result
			var result = new StringBuilder();
			result.AppendLine(string.Format("Environment version: {0}.", Environment.Version.ToString(4)));
			result.Append(string.Format("OS version: {0}.", Environment.OSVersion));

			return result.ToString();
		}

		private string MemoryUsage()
		{
			//result
			var result = new StringBuilder();
			result.AppendLine(string.Format("Managed memory: {0}.", Files.CalculateFriendlySize(GC.GetTotalMemory(false))));
			result.AppendLine(string.Format("Process memory: {0}.", Files.CalculateFriendlySize(Process.GetCurrentProcess().PagedMemorySize64)));
			result.Append(string.Format("Active threads: {0}.", Process.GetCurrentProcess().Threads.Count));

			return result.ToString();
		}

		#endregion

		/// <summary>
		/// Executes this command.
		/// </summary>
		/// <returns>the result</returns>
		public delegate string Command();

		/// <summary>
		/// The dictionary of commands in this console.
		/// </summary>
		public Dictionary<string, Command> Commands
		{
			get;
			set;
		}
	}
}
