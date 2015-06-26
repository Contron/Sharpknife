using Sharpknife.Desktop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.ViewModels
{
	internal class ProgressViewModel : Observable
	{
		public ProgressViewModel(string status)
		{
			this.Status = status;
			this.Busy = true;
		}

		public ProgressViewModel() : this("Status")
		{

		}

		public string Status
		{
			get
			{
				return (string) this.Get();
			}
			set
			{
				this.Set(value);
			}
		}

		public bool Busy
		{
			get
			{
				return (bool) this.Get();
			}
			set
			{
				this.Set(value);
			}
		}
	}
}
