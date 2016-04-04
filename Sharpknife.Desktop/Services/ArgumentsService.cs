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
	public sealed class ArgumentsService
	{
		private ArgumentsService()
		{

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

		/// <summary>
		/// Gets the supplied arguments, without the executable's name.
		/// </summary>
		public List<string> Arguments
		{
			get
			{
				return Environment.GetCommandLineArgs()
					.Skip(1)
					.ToList();
			}
		}

		private static readonly ArgumentsService instance = new ArgumentsService();
	}
}
