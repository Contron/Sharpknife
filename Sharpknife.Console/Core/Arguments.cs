using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Console.Core
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
			if (arguments == null)
			{
				throw new ArgumentNullException(nameof(arguments));
			}

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

		/// <summary>
		/// Returns the value of the specified argument, or the placeholder if it does not exist.
		/// </summary>
		/// <param name="name">the name</param>
		/// <param name="placeholder">the default value</param>
		/// <returns>the value</returns>
		public string GetArgument(string name, string placeholder = null)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			return this.arguments?[name] ?? placeholder;
		}

		/// <summary>
		/// Returns the value of the specified flag, or the placeholder if it does not exist.
		/// </summary>
		/// <param name="name">the name</param>
		/// <param name="placeholder">the default value</param>
		/// <returns>the flag</returns>
		public bool GetFlag(string name, bool placeholder = false)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			return this.flags?[name] ?? placeholder;
		}

		private string[] source;

		private Dictionary<string, string> arguments;
		private Dictionary<string, bool> flags;
	}
}
