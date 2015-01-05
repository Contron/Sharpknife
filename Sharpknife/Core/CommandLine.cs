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
	/// Represents a class to assist in taking command-line arguments.
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

			this.Header();
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
		/// Displays the header.
		/// </summary>
		private void Header()
		{
			//version info
			var versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

			//header
			Debug.Warning(versionInfo.ProductName);
			Debug.Warning(string.Format("Version {0}, {1}", versionInfo.FileVersion, versionInfo.LegalCopyright));
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
		/// The dictionary of arguments for this command line.
		/// </summary>
		public Dictionary<string, object> Arguments
		{
			get;
			private set;
		}

		private string[] arguments;
	}
}
