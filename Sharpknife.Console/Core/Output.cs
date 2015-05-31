using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Console.Core
{
	/// <summary>
	/// A collection of simplistic console output methods.
	/// </summary>
	public static class Output
	{
		/// <summary>
		/// Prints a message to the console.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Message(string message)
		{
			Output.WriteLine(ConsoleColor.Green, message);
		}

		/// <summary>
		/// Prints a warning message to the console.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Warning(string message)
		{
			Output.WriteLine(ConsoleColor.Yellow, message);
		}

		/// <summary>
		/// Prints an error message to the console.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Error(string message)
		{
			Output.WriteLine(ConsoleColor.Red, message);
		}

		/// <summary>
		/// Prints a standard application header to the console.
		/// Contains the application's name and copyright notice.
		/// </summary>
		public static void Header()
		{
			var information = Assemblies.GetInformation();

			Output.Warning(information.ProductName);
			Output.Warning(string.Format("Version {0}, Copyright {1}", information.FileVersion, information.LegalCopyright));
		}

		/// <summary>
		/// Writes the specified message (with a new line) to the console with the specified <see cref="ConsoleColor" />.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="message">the message</param>
		public static void WriteLine(ConsoleColor colour, string message)
		{
			Output.Write(colour, message + Environment.NewLine);
		}

		/// <summary>
		/// Writes the specified message to the console with the specified <see cref="ConsoleColor" />.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="message">the message</param>
		public static void Write(ConsoleColor colour, string message)
		{
			System.Console.ForegroundColor = colour;
			System.Console.Write(string.Format("[{0}] {1}", DateTime.Now.ToString("HH:mm:ss"), message));
			System.Console.ResetColor();
		}
	}
}
