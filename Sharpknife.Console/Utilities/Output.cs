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
		/// Prints a message to the <see cref="System.Console" />.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Message(string message)
		{
			Output.WriteLine(ConsoleColor.Gray, message);
		}

		/// <summary>
		/// Prints a warning message to the <see cref="System.Console" />.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Warning(string message)
		{
			Output.WriteLine(ConsoleColor.Yellow, message);
		}

		/// <summary>
		/// Prints an error message to the <see cref="System.Console" />.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Error(string message)
		{
			Output.WriteLine(ConsoleColor.Red, message);
		}

		/// <summary>
		/// Prints a standard application header to the <see cref="System.Console" />.
		/// </summary>
		/// <remarks>
		/// Contains the application's full name, along with its current version and copyright notice.
		/// </remarks>
		public static void Header()
		{
			Output.Warning(Assemblies.GetAttribute<AssemblyProductAttribute>().Product);
			Output.Warning($"Version {Assemblies.GetAttribute<AssemblyFileVersionAttribute>().Version}, Copyright {Assemblies.GetAttribute<AssemblyCopyrightAttribute>().Copyright}");
		}

		/// <summary>
		/// Prints a separator line to the <see cref="System.Console" />.
		/// The line will be the value of <see cref="System.Console.BufferWidth" />.
		/// </summary>
		public static void Separator()
		{
			var width = System.Console.BufferWidth - 12;

			Output.Message(string.Concat(Enumerable.Repeat("=", width)));
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
