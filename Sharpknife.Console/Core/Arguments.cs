using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Console.Core
{
	/// <summary>
	/// Represents a parser for command-line arguments.
	/// </summary>
	public class Arguments
	{
		/// <summary>
		/// Parses the specified arguments.
		/// </summary>
		/// <param name="arguments">the arguments</param>
		/// <returns>the result</returns>
		public static Arguments Parse(string[] arguments)
		{
			var result = new Arguments(arguments);
			result.Parse();

			return result;
		}

		/// <summary>
		/// Creates a new arguments parser.
		/// </summary>
		/// <param name="arguments">the arguments</param>
		public Arguments(string[] arguments)
		{
			this.source = arguments;

			this.arguments = new Dictionary<string, string>();
			this.flags = new Dictionary<string, bool>();
		}

		/// <summary>
		/// Parses the current arguments.
		/// </summary>
		public void Parse()
		{
			for (var index = 0; index < this.source.Length; index++)
			{
				var argument = this.source[index];

				if (argument.StartsWith("-"))
				{
					var next = index + 1;

					if (next < this.source.Length)
					{
						this.arguments[argument] = this.source[next];
					}
				}
				else
				{
					this.flags[argument] = true;
				}
			}
		}

		private string[] source;

		private Dictionary<string, string> arguments;
		private Dictionary<string, bool> flags;
	}
}
