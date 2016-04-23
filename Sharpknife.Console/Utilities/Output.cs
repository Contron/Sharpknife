using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Console.Utilities
{
	/// <summary>
	/// A collection of simplistic console output methods.
	/// </summary>
	public static class Output
	{
		/// <summary>
		/// Writes the specified message to the <see cref="System.Console" /> .
		/// </summary>
		/// <param name="message">the message</param>
		public static void WriteMessage(string message)
		{
			Output.WriteLine(ConsoleColor.Gray, message);
		}

		/// <summary>
		/// Writes the specified warning message to the <see cref="System.Console" />.
		/// </summary>
		/// <param name="message">the message</param>
		public static void WriteWarning(string message)
		{
			Output.WriteLine(ConsoleColor.Yellow, message);
		}

		/// <summary>
		/// Writes the specified error message to the <see cref="System.Console" />.
		/// </summary>
		/// <param name="message">the message</param>
		public static void WriteError(string message)
		{
			Output.WriteLine(ConsoleColor.Red, message);
		}

		/// <summary>
		/// Writes an application header <see cref="System.Console" />, containing the application's name, version, and copyright notice.
		/// </summary>
		public static void WriteHeader()
		{
			Output.WriteWarning(Assemblies.GetAttribute<AssemblyProductAttribute>().Product);
			Output.WriteWarning($"Version {Assemblies.GetAttribute<AssemblyFileVersionAttribute>().Version}, Copyright {Assemblies.GetAttribute<AssemblyCopyrightAttribute>().Copyright}");
		}

		/// <summary>
		/// Writes the specified line (with a new line) to the <see cref="System.Console" /> with the specified <see cref="ConsoleColor" />.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="message">the message</param>
		public static void WriteLine(ConsoleColor colour, string message)
		{
			Output.Write(colour, message + Environment.NewLine);
		}

		/// <summary>
		/// Writes the specified line to the <see cref="System.Console" /> with the specified <see cref="ConsoleColor" />.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="message">the message</param>
		public static void Write(ConsoleColor colour, string message)
		{
			var time = DateTime.Now.ToString("HH:mm:ss");

			System.Console.ForegroundColor = colour;
			System.Console.Write($"[{time}] {message}");
			System.Console.ResetColor();
		}
	}
}
