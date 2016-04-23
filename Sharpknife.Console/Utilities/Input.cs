using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sharpknife.Console.Utilities
{
	/// <summary>
	/// A collection of simplistic console input methods.
	/// </summary>
	public static class Input
	{
		/// <summary>
		/// Prompts the <see cref="System.Console" /> for a response with the specified message.
		/// </summary>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static string ReadMessage(string message)
		{
			var result = string.Empty;

			while (true)
			{
				result = Input.ReadLine(message);

				if (!string.IsNullOrWhiteSpace(result))
				{
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Prompts the <see cref="System.Console" /> for a numeric response with the specified message.
		/// </summary>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static int ReadNumber(string message)
		{
			var result = 0;

			while (true)
			{
				var line = Input.ReadLine(message);
				var parsed = int.TryParse(line, out result);

				if (parsed)
				{
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Prompts the <see cref="System.Console" /> for a boolean response with the specified message.
		/// </summary>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static bool ReadQuestion(string message)
		{
			var result = false;

			while (true)
			{
				var line = Input.ReadLine(message).ToLower();

				var yes = line == "y";
				var no = line == "n";
				
				if (yes || no)
				{
					result = yes;

					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Prompts the <see cref="System.Console" /> to press any key before continuing.
		/// </summary>
		public static void WaitForAnyKey()
		{
			Output.WriteWarning("Press any key to continue.");

			System.Console.ReadKey(true);
		}

		/// <summary>
		/// Reads a line from the <see cref="System.Console" /> with the specified message.
		/// </summary>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static string ReadLine(string message)
		{
			Output.Write(ConsoleColor.Green, $"{message}: ");

			return System.Console.ReadLine();
		}
	}
}
