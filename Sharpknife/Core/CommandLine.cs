using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents a command-line interface to assist in a command-line application.
	/// </summary>
	public class CommandLine
	{
		/// <summary>
		/// Creates a new command line.
		/// </summary>
		/// <param name="arguments">the arguments</param>
		public CommandLine(string[] arguments)
		{
			this.Arguments = new Dictionary<string, object>();
			this.arguments = arguments;

			this.Parse();
		}

		/// <summary>
		/// Returns the value for the specified argument.
		/// </summary>
		/// <param name="name">the name</param>
		/// <param name="placeholder">the placeholder</param>
		/// <param name="throwException">if an exception should be thrown</param>
		/// <returns>the value, or placeholder</returns>
		public object GetArgument(string name, object placeholder = null, bool throwException = false)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}

			if (!this.Arguments.ContainsKey(name))
			{
				if (throwException)
				{
					throw new Exception(string.Format("Argument '{0}' has no supplied value.", name));
				}

				return placeholder;
			}

			//get
			var result = this.Arguments[name];

			return result;
		}

		/// <summary>
		/// Returns the string value for the specified argument.
		/// </summary>
		/// <param name="name">the name</param>
		/// <param name="placeholder">the placeholder</param>
		/// <returns>the value, or placeholder</returns>
		public string GetString(string name, string placeholder = null)
		{
			return (string) this.GetArgument(name, placeholder, true);
		}

		/// <summary>
		/// Returns the flag value for the specified argument.
		/// </summary>
		/// <param name="name">the name</param>
		/// <param name="placeholder">the placeholder</param>
		/// <returns>the value, or placeholder</returns>
		public bool GetFlag(string name, bool placeholder = false)
		{
			return (bool) this.GetArgument(name, placeholder, false);
		}

		/// <summary>
		/// Parses the arguments into a dictionary.
		/// </summary>
		private void Parse()
		{
			for (var index = 0; index < this.arguments.Length; index++)
			{
				//argument
				var argument = this.arguments[index];

				if (argument.StartsWith("-"))
				{
					//increment
					index++;

					if (index < this.arguments.Length)
					{
						//argument
						this.Arguments[argument] = this.arguments[index];
					}
				}
				else
				{
					//flag
					this.Arguments[argument] = true;
				}
			}
		}

		/// <summary>
		/// Gets the dictionary of arguments for the command line.
		/// </summary>
		public Dictionary<string, object> Arguments
		{
			get;
			private set;
		}

		private string[] arguments;
	}
}
