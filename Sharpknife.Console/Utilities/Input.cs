using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Console.Utilities
{
	/// <summary>
	/// A collection of simplistic console input methods.
	/// </summary>
	public static class Input
	{
		/// <summary>
		/// Prompts the console for a response with the specified message.
		/// </summary>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static string Message(string message)
		{
			var result = string.Empty;

			while (true)
			{
				result = Input.PromptLine(message);

				if (!string.IsNullOrWhiteSpace(result))
				{
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Prompts the console for a numeric response with the specified message.
		/// </summary>
		/// <remarks>
		/// Control will not be returned until the user enters a valid response.
		/// </remarks>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static int Number(string message)
		{
			var result = 0;

			while (true)
			{
				var line = Input.PromptLine(message);
				var parsed = int.TryParse(line, out result);

				if (parsed)
				{
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Prompts the console for a boolean response with the specified message.
		/// </summary>
		/// <remarks>
		/// Control will not be returned until the user enters a valid response.
		/// </remarks>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static bool Question(string message)
		{
			var result = false;

			while (true)
			{
				var line = Input.PromptLine(message).ToLower();
				
				if (line == "y" || line == "n")
				{
					result = line == "y";

					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Prompts the console to press any key before continuing.
		/// </summary>
		public static void AnyKey()
		{
			Output.Warning("Press any key to continue.");

			System.Console.ReadKey(true);
		}

		private static string PromptLine(string message)
		{
			Output.Write(ConsoleColor.DarkGreen, string.Format("{0}: ", message));

			return System.Console.ReadLine();
		}
	}
}
