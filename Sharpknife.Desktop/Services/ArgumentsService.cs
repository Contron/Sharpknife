using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents an arguments service to retrieve application command-line arguments.
	/// </summary>
	public class ArgumentsService
	{
		private ArgumentsService()
		{

		}

		/// <summary>
		/// Returns the arguments supplied to the application, minus the name.
		/// </summary>
		/// <returns></returns>
		public List<string> Get()
		{
			var arguments = Environment.GetCommandLineArgs().ToList();

			if (arguments.Count > 0)
			{
				arguments.RemoveAt(0);
			}

			return arguments;
		}

		/// <summary>
		/// Gets the instance of the arguments service.
		/// </summary>
		public static ArgumentsService Instance
		{
			get
			{
				return ArgumentsService.instance;
			}
		}

		private static readonly ArgumentsService instance = new ArgumentsService();
	}
}
