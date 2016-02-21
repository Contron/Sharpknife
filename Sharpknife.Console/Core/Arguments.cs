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
		/// Creates a new arguments parser with the specified arguments.
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
			this.flags = new List<string>();

			this.Parse();
		}

		/// <summary>
		/// Returns the value of the specified option, or <c>null</c> if it does not exist.
		/// </summary>
		/// <param name="name">the name</param>
		/// <param name="placeholder">the default value</param>
		/// <returns>the value</returns>
		public string GetOption(string name, string placeholder = null)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			if (this.arguments.ContainsKey(name))
			{
				return this.arguments[name];
			}

			return placeholder;
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
