using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// A collection of useful debug utilities for printing and reading the console.
	/// </summary>
	public static class Debug
	{
		/// <summary>
		/// Writes the application header to the console.
		/// </summary>
		public static void Header()
		{
			//version info
			var versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

			//header
			Debug.Warning(versionInfo.ProductName);
			Debug.Warning(string.Format("Version {0}, {1}", versionInfo.FileVersion, versionInfo.LegalCopyright));
		}

		/// <summary>
		/// Writes formatted information to the console.
		/// </summary>
		/// <param name="message">the message</param>
		/// <param name="arguments">the format arguments</param>
		public static void Information(string message, params object[] arguments)
		{
			Debug.Information(string.Format(message, arguments));
		}

		/// <summary>
		/// Writes information to the console.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Information(string message)
		{
			Debug.WriteLine(ConsoleColor.Cyan, message);
		}

		/// <summary>
		/// Writes a warning message to the console.
		/// </summary>
		/// <param name="message">the message</param>
		/// <param name="arguments">the format arguments</param>
		public static void Warning(string message, params object[] arguments)
		{
			Debug.Warning(string.Format(message, arguments));
		}

		/// <summary>
		/// Writes a formatted warning to the console.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Warning(string message)
		{
			Debug.WriteLine(ConsoleColor.Yellow, message);
		}

		/// <summary>
		/// Writes a formatted error message to the console.
		/// </summary>
		/// <param name="message">the message</param>
		/// <param name="arguments">the format arguments</param>
		public static void Error(string message, params object[] arguments)
		{
			Debug.Error(string.Format(message, arguments));
		}

		/// <summary>
		/// Writes an error to the console.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Error(string message)
		{
			Debug.WriteLine(ConsoleColor.Red, message);
		}

		/// <summary>
		/// Prompts the user at the console for input.
		/// </summary>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static string MessagePrompt(string message)
		{
			//message
			Debug.Write(ConsoleColor.Green, message + ": ");
			Console.ResetColor();

			//read
			var result = Console.ReadLine();

			return (string.IsNullOrEmpty(result) ? null : result);
		}

		/// <summary>
		/// Prompts the user at the console for a question.
		/// </summary>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static bool QuestionPrompt(string message)
		{
			//message
			Debug.Write(ConsoleColor.Green, message + " (y/n): ");
			Console.ResetColor();

			//read
			var result = Console.ReadLine().ToLower();

			return (result == "y");
		}

		/// <summary>
		/// Prompts the user at the console for a number.
		/// </summary>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static int NumberPrompt(string message)
		{
			//result
			int number = 0;

			while (true)
			{
				//message
				Debug.Write(ConsoleColor.Green, message + ": ");
				Console.ResetColor();

				//read and parse
				var result = Console.ReadLine();
				var parsed = int.TryParse(result, out number);

				if (parsed)
				{
					break;
				}
			}

			return number;
		}

		/// <summary>
		/// Prompts the user at the console for a password.
		/// </summary>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static string PasswordPrompt(string message)
		{
			//message
			Debug.Write(ConsoleColor.Green, message + ": ");
			Console.ResetColor();

			//password
			var stringBuilder = new StringBuilder();

			while (true)
			{
				//key
				var keyInfo = Console.ReadKey(true);
				var key = keyInfo.Key;

				if (key == ConsoleKey.Enter)
				{
					//completed
					Console.WriteLine();

					break;
				}
				else if (key == ConsoleKey.Backspace)
				{
					if (stringBuilder.Length > 0)
					{
						//remove
						stringBuilder.Remove(stringBuilder.Length - 1, 1);
						Console.Write("\b \b");
					}
				}
				else
				{
					//append
					stringBuilder.Append(keyInfo.KeyChar);
					Console.Write("*");
				}

			}

			//result
			var result = stringBuilder.ToString();

			return (string.IsNullOrEmpty(result) ? null : result);
		}

		/// <summary>
		/// Prompts the user to press any key to continue.
		/// </summary>
		public static void AnyKeyPrompt()
		{
			//wait
			Debug.WriteLine(ConsoleColor.Yellow, "Press any key to continue.");
			Console.ReadKey(true);
		}

		/// <summary>
		/// Writes the specified message line with the specified colour and formatting options to the console.
		/// </summary>
		/// <param name="consoleColor">the console colour</param>
		/// <param name="message">the message</param>
		/// <param name="arguments">the arguments</param>
		public static void WriteLine(ConsoleColor consoleColor, string message, params object[] arguments)
		{
			Debug.WriteLine(consoleColor, string.Format(message, arguments));
		}

		/// <summary>
		/// Writes the specified message line with the specified colour to the console.
		/// </summary>
		/// <param name="consoleColor">the console colour</param>
		/// <param name="message">the message</param>
		public static void WriteLine(ConsoleColor consoleColor, string message)
		{
			Debug.Write(consoleColor, message + Environment.NewLine);
		}

		/// <summary>
		/// Writes the specified message with the specified colour to the console.
		/// </summary>
		/// <param name="consoleColor">the console colour</param>
		/// <param name="message">the message</param>
		public static void Write(ConsoleColor consoleColor, string message)
		{
			//time
			var time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

			//print
			Console.ForegroundColor = consoleColor;
			Console.Write(string.Format("[{0}] {1}", time, message));
			Console.ResetColor();
		}
	}
}
