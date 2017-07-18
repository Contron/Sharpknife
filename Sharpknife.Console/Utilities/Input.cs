using System;

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
			while (true)
			{
				var result = Input.ReadLine(message);

				if (!string.IsNullOrWhiteSpace(result))
				{
					return result;
				}
			}
		}

		/// <summary>
		/// Prompts the <see cref="System.Console" /> for a numeric response with the specified message.
		/// </summary>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static int ReadNumber(string message)
		{
			while (true)
			{
				var line = Input.ReadLine(message);

				if (int.TryParse(line, out var result))
				{
					return result;
				}
			}
		}

		/// <summary>
		/// Prompts the <see cref="System.Console" /> for a boolean response with the specified message.
		/// </summary>
		/// <param name="message">the message</param>
		/// <returns>the result</returns>
		public static bool ReadQuestion(string message)
		{
			while (true)
			{
				var line = Input.ReadLine(message).ToLower();

				var accept = line == "y" || line == "yes";
				var reject = line == "n" || line == "no";

				if (accept || reject)
				{
					return accept;
				}
			}
		}

		/// <summary>
		/// Prompts the <see cref="System.Console" /> to press any key before continuing.
		/// </summary>
		public static void Wait()
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
