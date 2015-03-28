using Sharpknife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Gui.ViewModels
{
	internal class ProgressViewModel : Observable
	{
		public ProgressViewModel()
		{
			this.message = "Please wait...";
		}

		public string Message
		{
			get
			{
				return this.message;
			}
			set
			{
				this.SetNotify(ref this.message, value);
			}
		}

		private string message;
	}
}
