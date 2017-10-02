using System;
using System.Collections.Generic;

namespace Sharpknife.Console.Core
{
	/// <summary>
	/// Represents a parser for command-line arguments.
	/// </summary>
	public class Arguments
	{
		/// <summary>
		/// Creates a new arguments parser with the specified arguments.
		/// </summary>
		/// <param name="arguments">the arguments</param>
		public Arguments(string[] arguments)
		{
			this.source = arguments ?? throw new ArgumentNullException(nameof(arguments));

			this.arguments = new Dictionary<string, string>();
			this.flags = new List<string>();

			this.Parse();
		}

		/// <summary>
		/// Returns a string representation.
		/// </summary>
		/// <returns>the representation</returns>
		public override string ToString()
		{
			return $"Arguments (Arguments: {this.arguments}, Flags: {this.flags})";
		}

		/// <summary>
		/// Returns the value of the specified option, or <c>null</c> if it does not exist.
		/// </summary>
		/// <param name="name">the name</param>
		/// <returns>the value</returns>
		public string GetOption(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			if (this.arguments.ContainsKey(name))
			{
				return this.arguments[name];
			}

			return null;
		}

		/// <summary>
		/// Returns the value of the specified flag, or <c>false</c> if it does not exist.
		/// </summary>
		/// <param name="name">the name</param>
		/// <returns>the flag</returns>
		public bool GetFlag(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			if (this.flags.Contains(name))
			{
				return true;
			}

			return false;
		}

		private void Parse()
		{
			var index = 0;

			while (index < this.source.Length)
			{
				var argument = this.source[index];

				if (argument.StartsWith("-"))
				{
					var name = argument.Substring(1);
					var next = index + 1;

					if (next < this.source.Length)
					{
						this.arguments[name] = this.source[next];

						index += 2;
					}
				}
				else
				{
					this.flags.Add(argument);

					index++;
				}
			}
		}

		private string[] source;

		private Dictionary<string, string> arguments;
		private List<string> flags;
	}
}
